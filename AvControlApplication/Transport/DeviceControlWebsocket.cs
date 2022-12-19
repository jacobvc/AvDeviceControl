using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Diagnostics;

using Ninja.WebSockets;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Reflection;
using System.Linq;
using AVDeviceControl;
using System.Net.WebSockets;

namespace AVDeviceControl
{
    public partial class DeviceControlWebsocket
    {
        //public static DeviceControlWebsocket ws;
        WebSocketService service;

        #region Event Handlers
        /// <summary>
        /// Triggered when connected successfully to an obs-websocket server
        /// </summary>
        public event EventHandler Connected;

        /// <summary>
        /// Triggered when disconnected from an obs-websocket server
        /// </summary>
        public event EventHandler Disconnected;

        #endregion

        /// <summary>
        /// Underlying WebSocket connection to an obs-websocket server. Value is null when disconnected.
        /// </summary>
        public WebServer WSServer;
        static IWebSocketServerFactory _webSocketServerFactory;

        /// <summary>
        /// Constructor
        /// </summary>
        public DeviceControlWebsocket(AvDeviceCollection devices)
        {
            //ws = this;

            _webSocketServerFactory = new WebSocketServerFactory();

            devices.configurationChangedEvent += InternalConfigurationChangedEvent;
            devices.valueChangedEvent += InternalValueChangedEvent;

            List<String> protocols = new List<string> { "obswebsocket.json" };
            service = new PtzControl(devices);
            WSServer = new WebServer(_webSocketServerFactory,
                service, protocols);
        }

        public bool Start(int port)
        {
            _ = WSServer.Listen(port);
            return true;
        }
        public void Stop()
        {
            SendEvent("Exiting", null);
            WSServer.Dispose();
        }
        public void SendEvent(String eventType, JObject json)
        {
            JObject obsEvent = new JObject();
            obsEvent.Add("op", (int)ObsOpCode.Event);
            JObject data = new JObject();
            obsEvent.Add("d", data);
            data.Add("eventType", eventType);
            data.Add("eventIntent", 1);
            if (json != null)
            {
                data.Add("eventData", json);
            }

            service.SendAllSessions(obsEvent.ToString());
        }
        void InternalConfigurationChangedEvent(object sender)
        {
            SendEvent("ConfigurationChanged", null);
        }

        void InternalValueChangedEvent(object sender, ValueChangedEventArgs e)
        {
            switch (e.valueType)
            {
                case DeviceValueType.Mute:
                    {
                        JObject msg = new JObject();
                        msg.Add("mixername", (sender as ucVolumeSlider).MixerName);
                        msg.Add("channelname", (sender as ucVolumeSlider).Config.Name);
                        msg.Add("value", e.boolValue);
                        SendEvent("MuteChanged", msg);
                    }
                    break;
                case DeviceValueType.VolumeLevel:
                    {
                        JObject msg = new JObject();
                        msg.Add("mixername", (sender as ucVolumeSlider).MixerName);
                        msg.Add("channelname", (sender as ucVolumeSlider).Config.Name);
                        msg.Add("value", e.intValue);
                        SendEvent("VolumeLevelChanged", msg);
                    }
                    break;
                case DeviceValueType.VolumeSetting:
                    {
                        JObject msg = new JObject();
                        msg.Add("mixername", (sender as ucVolumeSlider).MixerName);
                        msg.Add("channelname", (sender as ucVolumeSlider).Config.Name);
                        msg.Add("value", e.intValue);
                        SendEvent("VolumeSettingChanged", msg);
                    }
                    break;
            }
        }
    }


    public class PtzControl : WebSocketService
    {
        AvDeviceCollection devices;
        class session
        {
            public WebSocket webSocket;
            public CancellationToken token;

            public session(WebSocket webSocket, CancellationToken token)
            {
                this.webSocket = webSocket;
                this.token = token;
            }
        }
        Dictionary<WebSocket, session> sessions = new Dictionary<WebSocket, session>();

        public PtzControl(AvDeviceCollection devices)
        {
            this.devices = devices;
        }

        public override String OnOpen(WebSocket webSocket, CancellationToken token)
        {
            sessions[webSocket] = new session(webSocket, token);
            return "{ \"op\": 0, \"d\": { \"obsWebSocketVersion\": \"5.0.1\", \"rpcVersion\": 1}}";
        }

        public override void OnClose(WebSocket webSocket)
        {
            sessions.Remove(webSocket);
        }

        public override void SendAllSessions(string text)
        {
            ArraySegment<byte> reply = new ArraySegment<byte>(
                Encoding.UTF8.GetBytes(text));
            foreach (session sess in sessions.Values)
            {
                sess.webSocket.SendAsync(reply, WebSocketMessageType.Text, 
                  true, sess.token);
            }
        }

        String validateNameDirAmount(JObject obj, String[] directions)
        {
            String s = "";
            String camera = (string)obj["cameraname"];
            if (camera == null)
            {
                s += "cameraname missing ";
            }
            String direction = (string)obj["direction"];
            if (direction == null)
            {
                s += "direction missing ";
            }
            else if (!directions.Contains(direction))
            {
                s += "direction: " + direction + " ";
            }
            String amount = (string)obj["amount"];
            if (amount == null)
            {
                s += "amount missing ";
            }
            if (s.Length == 0)
            {
                s = null;
            }
            return s;
        }

        public override bool OnRequest(JObject data, JObject jResponse)
        {
            JObject jRequest = (JObject)data["requestData"];
            JToken request = data["requestType"];
            JToken messageId = data["requestId"];

            JObject jStatus = new JObject();
            JObject jData = new JObject();
            jResponse.Add("requestStatus", jStatus);
            jResponse.Add("responseData", jData);

            if (request != null && messageId != null)
            {
                switch (request.ToString())
                {
                    case "GetAuthRequired":
                        jData.Add("authRequired", false);
                        jStatus.Add("result", true);
                        jStatus.Add("code", 0);
                        break;
                    case "GetVersion":
                        jData.Add("obsVersion", "1");
                        jData.Add("obsWebSocketVersion", "5.0.1");
                        jData.Add("rpcVersion", 1);
                        jData.Add("availableRequests", "");
                        jData.Add("supportedImageFormats", "[]");
                        /* 
                        "availableRequests": "AddFilterToSource,AddSceneItem,Authenticate,BroadcastCustomMessage,CreateScene,CreateSource,DeleteSceneItem,DisableStudioMode,DuplicateSceneItem,EnableStudioMode,ExecuteBatch,GetAudioActive,GetAudioMonitorType,GetAudioTracks,GetAuthRequired,GetBrowserSourceProperties,GetCurrentProfile,GetCurrentScene,GetCurrentSceneCollection,GetCurrentTransition,GetFilenameFormatting,GetMediaDuration,GetMediaSourcesList,GetMediaState,GetMediaTime,GetMute,GetOutputInfo,GetPreviewScene,GetRecordingFolder,GetRecordingStatus,GetReplayBufferStatus,GetSceneItemList,GetSceneItemProperties,GetSceneList,GetSceneTransitionOverride,GetSourceActive,GetSourceDefaultSettings,GetSourceFilterInfo,GetSourceFilters,GetSourceSettings,GetSourcesList,GetSourceTypesList,GetSpecialSources,GetStats,GetStreamingStatus,GetStreamSettings,GetStudioModeStatus,GetSyncOffset,GetTextFreetype2Properties,GetTextGDIPlusProperties,GetTransitionDuration,GetTransitionList,GetTransitionPosition,GetTransitionSettings,GetVersion,GetVideoInfo,GetVirtualCamStatus,GetVolume,ListOutputs,ListProfiles,ListSceneCollections,MoveSourceFilter,NextMedia,OpenProjector,PauseRecording,PlayPauseMedia,PreviousMedia,RefreshBrowserSource,ReleaseTBar,RemoveFilterFromSource,RemoveSceneTransitionOverride,ReorderSceneItems,ReorderSourceFilter,ResetSceneItem,RestartMedia,ResumeRecording,SaveReplayBuffer,SaveStreamSettings,ScrubMedia,SendCaptions,SetAudioMonitorType,SetAudioTracks,SetBrowserSourceProperties,SetCurrentProfile,SetCurrentScene,SetCurrentSceneCollection,SetCurrentTransition,SetFilenameFormatting,SetHeartbeat,SetMediaTime,SetMute,SetPreviewScene,SetRecordingFolder,SetSceneItemCrop,SetSceneItemPosition,SetSceneItemProperties,SetSceneItemRender,SetSceneItemTransform,SetSceneTransitionOverride,SetSourceFilterSettings,SetSourceFilterVisibility,SetSourceName,SetSourceRender,SetSourceSettings,SetStreamSettings,SetSyncOffset,SetTBarPosition,SetTextFreetype2Properties,SetTextGDIPlusProperties,SetTransitionDuration,SetTransitionSettings,SetVolume,Sleep,StartOutput,StartRecording,StartReplayBuffer,StartStopRecording,StartStopReplayBuffer,StartStopStreaming,StartStopVirtualCam,StartStreaming,StartVirtualCam,StopMedia,StopOutput,StopRecording,StopReplayBuffer,StopStreaming,StopVirtualCam,TakeSourceScreenshot,ToggleMute,ToggleStudioMode,TransitionToProgram,TriggerHotkeyByName,TriggerHotkeyBySequence",
                        "supported-image-export-formats": "bmp,cur,icns,ico,jpeg,jpg,pbm,pgm,png,ppm,tif,tiff,wbmp,webp,xbm,xpm",
                         */
                        jData.Add("platform", "Windows");
                        jData.Add("platformDescription", "Windows 10");
                        jData.Add("server", Assembly.GetEntryAssembly().GetName().Name);
                        jData.Add("versionStr", Assembly.GetEntryAssembly().GetName().Version.ToString());
                        jStatus.Add("result", true);
                        jStatus.Add("code", 0);
                        break;
                    case "GetAvDevices":
                        jData.Add("devices",devices.GetAvDevices());
                        jStatus.Add("result", true);
                        jStatus.Add("code", 0);
                        break;
                    case "MovePtz":
                        {
                            String error = validateNameDirAmount(jRequest,
                               new string[] { "up", "down", "left", "right" });
                            if (error == null)
                            {
                                String direction = (string)jRequest["direction"];
                               devices.Move((string)jRequest["cameraname"],
                                  (string)jRequest["direction"], (string)jRequest["amount"]);
                                jStatus.Add("result", true);
                                jStatus.Add("code", 0);
                            }
                            else
                            {
                                jStatus.Add("comment", error);
                                jStatus.Add("result", false);
                                jStatus.Add("code", -1);
                            }
                        }
                        break;
                    case "Zoom":
                        {
                            String error = validateNameDirAmount(jRequest,
                               new string[] { "in", "out" });
                            if (error == null)
                            {
                                String direction = (string)jRequest["direction"];
                               devices.SetZoom((string)jRequest["cameraname"],
                                  (string)jRequest["direction"], (string)jRequest["amount"]);
                                jStatus.Add("result", true);
                                jStatus.Add("code", 0);
                                //Console.WriteLine("Zoom cam: " + (string)obj["cameraname"]
                                //  + ", dir: " + (string)obj["direction"] + ", amount: " + (string)obj["amount"]);
                            }
                            else
                            {
                                jStatus.Add("comment", error);
                                jStatus.Add("result", false);
                                jStatus.Add("code", -1);
                            }
                        }
                        break;
                    case "Preset":
                        {
                            String camera = (string)jRequest["cameraname"];
                            if (camera != null)
                            {
                                String preset = (string)jRequest["preset"];
                                if (preset != null)
                                {
                                   devices.ExecPreset(camera, preset);
                                    jStatus.Add("result", true);
                                    jStatus.Add("code", 0);
                                }
                                else
                                {
                                    jStatus.Add("comment", "preset missing");
                                    jStatus.Add("result", false);
                                    jStatus.Add("code", -1);
                                }
                            }
                            else
                            {
                                jStatus.Add("comment", "cameraname missing");
                                jStatus.Add("result", false);
                                jStatus.Add("code", -1);
                            }
                        }
                        break;
                    case "Connect":
                        {
                            String camera = (string)jRequest["cameraname"];
                            if (camera != null)
                            {
                               devices.ConnectAvDevice(camera);
                                jStatus.Add("result", true);
                                jStatus.Add("code", 0);
                            }
                            else
                            {
                                jStatus.Add("comment", "cameraname missing");
                                jStatus.Add("result", false);
                                jStatus.Add("code", -1);
                            }
                        }
                        break;
                    case "Disconnect":
                        {
                            String camera = (string)jRequest["cameraname"];
                            if (camera != null)
                            {
                               devices.DisconnectAvDevice(camera);
                                jStatus.Add("result", true);
                                jStatus.Add("code", 0);
                            }
                            else
                            {
                                jStatus.Add("comment", "cameraname missing");
                                jStatus.Add("result", false);
                                jStatus.Add("code", -1);
                            }
                        }
                        break;
                    case "Mute":
                        {
                            String mixer = (string)jRequest["mixername"];
                            if (mixer != null)
                            {
                                String channelName = (string)jRequest["channelname"];
                                if (channelName != null)
                                {
                                    bool boolValue = (bool)jRequest["value"];
                                   devices.SetMute(mixer, channelName, boolValue);
                                    jStatus.Add("result", true);
                                    jStatus.Add("code", 0);
                                }
                            }
                            else
                            {
                                jStatus.Add("comment", "mixername missing");
                                jStatus.Add("result", false);
                                jStatus.Add("code", -1);
                            }
                        }
                        break;
                    case "VolumeSetting":
                        {
                            String mixer = (string)jRequest["mixername"];
                            if (mixer != null)
                            {
                                String channelName = (string)jRequest["channelname"];
                                if (channelName != null)
                                {
                                    int intValue = (int)jRequest["value"];
                                   devices.SetVolume(mixer, channelName, intValue);
                                    jStatus.Add("result", true);
                                    jStatus.Add("code", 0);
                                }
                            }
                            else
                            {
                                jStatus.Add("comment", "mixername missing");
                                jStatus.Add("result", false);
                                jStatus.Add("code", -1);
                            }
                        }
                        break;
                    default:
                        jStatus.Add("comment", "request-type " + request + " NOT SUPPORTED");
                        jStatus.Add("result", false);
                        jStatus.Add("code", -1);
                        break;
                }
            }
            else
            {
                jStatus.Add("result", false);
                jStatus.Add("code", -1);
                String errstr = "Malformed request. Missing: ";
                if (request == null)
                {
                    errstr += "requestType ";
                }
                if (messageId == null)
                {
                    errstr += "requestId";
                }
                jStatus.Add("comment", errstr);
            }

            return true;
        }
    }
}
