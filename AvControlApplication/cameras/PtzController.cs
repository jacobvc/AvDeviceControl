using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Visca;

namespace AVDeviceControl
{
    public enum LogLevel
    {
        Verbose = 1,
        Info = 2,
        Warning = 3,
    }
    public class PtzController
    {
        public static LogLevel logLevel = LogLevel.Warning;

        SerialViscaTransport transport = null;
        public ViscaProtocolProcessor controller;
        private ViscaCameraParameters cameraParams = new ViscaCameraDefaultParameters();

        public PtzCamera Camera { get; set; } = null;
        public ViscaInfo info = new ViscaInfo();

        byte address = 1;

        public PtzController()
        {
        }

        #region Connect / Disconnect
        public string Connect(bool serial, CameraConfig config)
        {
            string error;
            if (serial)
            {
                if (controller != null || transport != null)
                {
                    Disconnect();
                }
                transport = new SerialViscaTransport(config.Port, int.Parse(config.Baud));
                error = transport.Start();
                if (error == null)
                {
                    controller = new ViscaProtocolProcessor(
                      new Action<byte[]>(b => { transport?.sendBytes(b); }),
                      LogAction);
                }
                else
                {
                    return error;
                }
            }
            else
            {
                //tabControl1.SelectedTab = tabControl;
                return "ONLY Serial VISCA is currently supported"; //  Only support serial for now
            }
            // Hook up incoming data
            transport.receive += controller.ProcessIncomingData;

            PollViscaInfo();

            ViscaCameraId id = ViscaCameraId.Camera1;
            byte cameraAddress = (byte)id;

            cameraParams = new Rocware10xUsbCamera();
            Camera = new PtzCamera(id, cameraParams, this);

            Camera.Connect();

            return error;
        }

        public void PollViscaInfo()
        {
            ViscaInfoInquiry inq = new ViscaInfoInquiry(address, InfoArrived);
            controller.EnqueueCommand(inq);
        }

        private static void LogAction(byte level, string format, object[] args)
        {
            if (level >= (int)logLevel)
            {
                Console.WriteLine("PT LOG:[{0}]", String.Format(format, args));
            }
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

    }
}
