using AVDeviceControl.transport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Visca;
using static AVDeviceControl.Preset;

namespace AVDeviceControl
{
    public enum LogLevel
    {
        Verbose = 1,
        Info = 2,
        Warning = 3,
        Error = 4,
        None = 5
    }
    public class PtzController
    {
        public static LogLevel logLevel = LogLevel.Warning;

        ViscaTransport transport = null;
        public event Aborted Abort;
        public ViscaProtocolProcessor controller;
        private ViscaCameraParameters cameraParams = new ViscaCameraDefaultParameters();

        public PtzCamera Camera { get; set; } = null;
        public ViscaInfo info = new ViscaInfo();

        byte address = 1;

        public PtzController()
        {
        }

        #region Connect / Disconnect
        public string Connect(bool serial, CameraConfig config, Action<byte, string, object[]> logAction = null)
        {
            if (logAction == null)
            {
                logAction = LogAction;
            }
            string error;
            if (serial)
            {
                if (controller != null || transport != null)
                {
                    Disconnect();
                }
                transport = new SerialViscaTransport(config.Port, int.Parse(config.Baud));
            }
            else
            {
                transport = new TcpViscaTransport(config.CamIp, config.CamIpPort);
            }
            error = transport.Start();
            if (error == null)
            {
                controller = new ViscaProtocolProcessor(
                  new Action<byte[]>(b => { transport?.sendBytes(b); }),
                  logAction);
            }
            else
            {
                return error;
            }
            // Hook up incoming data
            transport.receive += controller.ProcessIncomingData;
            transport.abort += Transport_abort;

            PollViscaInfo();

            ViscaCameraId id = ViscaCameraId.Camera1;
            byte cameraAddress = (byte)id;

            if (config.CameraModel == CameraName.ClearOne.ToString())
            {
                Camera = new Clear1PtzCamera(id, this);
            }
            else // if (config.CameraModel == CameraName.Other)
            {
                Camera = new PtzCamera(id, this);
            }

            Camera.Connect();

            return error;
        }

        private void Transport_abort(string reason)
        {
            Abort?.Invoke(reason);
        }

        public void PollViscaInfo()
        {
            ViscaInfoInquiry inq = new ViscaInfoInquiry(address, InfoArrived);
            controller.EnqueueCommand(inq);
        }

        private void InfoArrived(ViscaInfo e)
        {
            this.info = e;
            Console.WriteLine(e.ToString());
        }

        public void Disconnect()
        {
            Camera?.Dispose();
            Camera = null;
            controller?.Dispose();
            controller = null;
            if (transport != null)
            {
                transport.Stop();
                transport = null;
            }
        }
        #endregion

        private static void LogAction(byte level, string format, object[] args)
        {
            if (level >= (int)logLevel)
            {
                Console.WriteLine("PT LOG:[{0}]", String.Format(format, args));
            }
        }

    }
}
