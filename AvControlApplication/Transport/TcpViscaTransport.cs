﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Documents;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace AVDeviceControl.transport
{
    internal class TcpViscaTransport : ViscaTransport
    {
        Socket client;
        byte[] buffer = new byte[1024];
        private Thread receiveThread;

        public string CamIp { get; }
        public string CamPort { get; }
        public TcpViscaTransport(string camIp, string camPort)
        {
            CamIp = camIp;
            CamPort = camPort;
        }
        public void Dispose()
        {
            client?.Close();
            client?.Dispose();
            receiveThread?.Abort();
        }
        public override void sendBytes(byte[] data)
        {
            try
            {
                client.Send(data);
            }
            catch (SocketException se)
            {
                Stop();
                Start();
            }
            catch (Exception ex)
            {
                DoAbort(ex.Message);
            }
        }

        public override string Start()
        {
            int port;
            if (int.TryParse(CamPort, out port))
            {
                try
                {
                    client = new Socket(SocketType.Stream, ProtocolType.Tcp);
                    client.SendTimeout = 1000;
                    IAsyncResult result = client.BeginConnect(CamIp, port, null, null);

                    bool success = result.AsyncWaitHandle.WaitOne(3000, true);

                    if (client.Connected)
                    {
                        receiveThread = new Thread(Receive);
                        receiveThread.Start();
                    }
                    else
                    {
                        client.Close();
                        return "TCP connect timeout on " + CamIp + ":" + port;
                    }
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            else
            {
                return "Port must be integer";
            }
            return null;
        }

        public override void Stop()
        {
            client?.Close();
            client = null;
        }
        private void Receive(object obj)
        {
            while (true)
            {
                try
                {
                    int count = client.Receive(buffer);
                    byte[] received = new byte[count];
                    Buffer.BlockCopy(buffer, 0, received, 0, count);

                    if (count > 0)
                    {
                        DoReceive(received);
                    }
                    else
                    {
                        Stop();
                        break;
                    }
                }
                catch (SocketException se)
                {
                    Stop();
                    if (se.SocketErrorCode != SocketError.ConnectionReset) { return; }
                    break;
                }
                catch (Exception ex)
                {

                    DoAbort(ex.Message);
                    return;
                }
            }
            Start();
        }
    }
}