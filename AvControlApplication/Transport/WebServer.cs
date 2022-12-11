using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Threading.Tasks;
//using Microsoft.Extensions.Logging;
using System.Threading;
using Ninja.WebSockets;
using System.Collections.Generic;
using Serilog;
using Newtonsoft.Json.Linq;
using static System.Net.Mime.MediaTypeNames;
using System.Text;
using System.Linq;

namespace AVDeviceControl
{
    public abstract class WebSocketService
    {
        public abstract void SendAllSessions(String text);
        public abstract String OnOpen(WebSocket webSocket, CancellationToken token);
        public abstract void OnClose(WebSocket webSocket);
        public abstract bool OnRequest(JObject jRequest, JObject jResponse);
   }
    public class WebServer : IDisposable
    {
        private TcpListener _listener;
        private bool _isDisposed = false;
        ILogger _logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
        private readonly IWebSocketServerFactory _webSocketServerFactory;
        private readonly HashSet<string> _supportedSubProtocols;
        private readonly WebSocketService _service;
        // const int BUFFER_SIZE = 1 * 1024 * 1024 * 1024; // 1GB
        const int BUFFER_SIZE = 4 * 1024 * 1024; // 4MB

        public WebServer(IWebSocketServerFactory webSocketServerFactory,
            WebSocketService service, IList<string> supportedSubProtocols = null)
        {
            _webSocketServerFactory = webSocketServerFactory;
            _service = service;
            _supportedSubProtocols = new HashSet<string>(supportedSubProtocols ?? new string[0]);
        }

        private void ProcessTcpClient(TcpClient tcpClient)
        {
            Task.Run(() => ProcessTcpClientAsync(tcpClient));
        }

        private string GetSubProtocol(IList<string> requestedSubProtocols)
        {
            foreach (string subProtocol in requestedSubProtocols)
            {
                // match the first sub protocol that we support (the client should pass the most preferable sub protocols first)
                if (_supportedSubProtocols.Contains(subProtocol))
                {
                    _logger.Information($"Http header has requested sub protocol {subProtocol} which is supported");

                    return subProtocol;
                }
            }

            if (requestedSubProtocols.Count > 0)
            {
                _logger.Warning($"Http header has requested the following sub protocols: {string.Join(", ", requestedSubProtocols)}. There are no supported protocols configured that match.");
            }

            return null;
        }

        private async Task ProcessTcpClientAsync(TcpClient tcpClient)
        {
            CancellationTokenSource source = new CancellationTokenSource();

            try
            {
                if (_isDisposed)
                {
                    return;
                }

                // this worker thread stays alive until either of the following happens:
                // Client sends a close conection request OR
                // An unhandled exception is thrown OR
                // The server is disposed
                _logger.Information("Server: Connection opened. Reading Http header from stream");

                // get a secure or insecure stream
                Stream stream = tcpClient.GetStream();
                WebSocketHttpContext context = await _webSocketServerFactory.ReadHttpHeaderFromStreamAsync(stream);
                if (context.IsWebSocketRequest)
                {
                    string subProtocol = GetSubProtocol(context.WebSocketRequestedProtocols);
                    var options = new WebSocketServerOptions() { KeepAliveInterval = TimeSpan.FromSeconds(30), SubProtocol = subProtocol };
                    _logger.Information("Http header has requested an upgrade to Web Socket protocol. Negotiating Web Socket handshake");

                    WebSocket webSocket = await _webSocketServerFactory.AcceptWebSocketAsync(context, options);

                    _logger.Information("Web Socket handshake response sent. Stream ready.");
                    await RespondToWebSocketRequestAsync(webSocket, source.Token);
                }
                else
                {
                    _logger.Information("Http header contains no web socket upgrade request. Ignoring");
                }

                _logger.Information("Server: Connection closed");
            }
            catch (ObjectDisposedException)
            {
                // do nothing. This will be thrown if the Listener has been stopped
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
            finally
            {
                try
                {
                    tcpClient.Client.Close();
                    tcpClient.Close();
                    source.Cancel();
                }
                catch (Exception ex)
                {
                    _logger.Error($"Failed to close TCP connection: {ex}");
                }
            }
        }

        public async Task RespondToWebSocketRequestAsync(WebSocket webSocket, CancellationToken token)
        {
            ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[BUFFER_SIZE]);

            String onopen = _service.OnOpen(webSocket, token);
            if (onopen != null)
            {
                ArraySegment<byte> reply = new ArraySegment<byte>(
                    Encoding.UTF8.GetBytes(onopen));
                
                await webSocket.SendAsync(reply, WebSocketMessageType.Text, true, token);
            }
            while (true)
            {
                WebSocketReceiveResult result = await webSocket.ReceiveAsync(buffer, token);
                if (result.MessageType == WebSocketMessageType.Close)
                {
                    _logger.Information($"Client initiated close. Status: {result.CloseStatus} Description: {result.CloseStatusDescription}");
                    break;
                }

                if (result.Count > BUFFER_SIZE)
                {
                    await webSocket.CloseAsync(WebSocketCloseStatus.MessageTooBig,
                        $"Web socket frame cannot exceed buffer size of {BUFFER_SIZE:#,##0} bytes. Send multiple frames instead.",
                        token);
                    break;
                }
                ArraySegment<byte> request = new ArraySegment<byte>(buffer.Array, buffer.Offset, result.Count);
                String s = Encoding.ASCII.GetString(request.ToArray());

                JObject jRequest = JObject.Parse(s);
                int op = (int)jRequest["op"];
                JObject data = (JObject)jRequest["d"];

                JObject reply = new JObject();
                JObject jResponse = new JObject();
                reply.Add("d", jResponse);
                switch (op)
                {
                    case (int)ObsOpCode.Identify:
                        reply.Add("op", (int)ObsOpCode.Identified);
                        jResponse.Add("negotiatedRpcVersion", 1);
                        break;
                    case (int)ObsOpCode.Request:
                        reply.Add("op", (int)ObsOpCode.RequestResponse);
                        jResponse.Add("requestType", data["requestType"]);
                        jResponse.Add("requestId", data["requestId"]);
                        _service.OnRequest(data, jResponse);
                        break;
                    default:
                        reply = null;
                        break;
                }

                if (reply != null)
                {
                    ArraySegment<byte> replysegment = new ArraySegment<byte>(
                        Encoding.UTF8.GetBytes(reply.ToString()));
                    await webSocket.SendAsync(replysegment, WebSocketMessageType.Text, true, token);
                }
            }
            _service.OnClose(webSocket);
        }

        public async Task Listen(int port)
        {
            try
            {
                IPAddress localAddress = IPAddress.Any;
                _listener = new TcpListener(localAddress, port);
                _listener.Start();
                _logger.Information($"Server started listening on port {port}");
                while(true)
                {
                    TcpClient tcpClient = await _listener.AcceptTcpClientAsync();
                    ProcessTcpClient(tcpClient);
                }
            }
            catch (SocketException ex)
            {
                string message = string.Format("Error listening on port {0}. Make sure IIS or another application is not running and consuming your port.", port);
                throw new Exception(message, ex);
            }
        }
        
        public void Dispose()
        {
            if (!_isDisposed)
            {
                _isDisposed = true;

                // safely attempt to shut down the listener
                try
                {
                    if (_listener != null)
                    {
                        if (_listener.Server != null)
                        {
                            _listener.Server.Close();
                        }

                        _listener.Stop();
                    }
                }
                catch (Exception ex)
                {
                    _logger.Error( ex.ToString());
                }
                
                _logger.Information( "Web Server disposed");
            }
        }
    }
}
