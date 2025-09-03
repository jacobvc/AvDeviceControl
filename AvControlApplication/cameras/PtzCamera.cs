using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Animation;
using Visca;
using static Visca.Visca;

namespace AVDeviceControl
{
    public partial class PtzCamera : ViscaCamera, IBindableComponent
    {
        byte address;
        public PtzController ptz;
        PtzMonitor ptMonitor;
        PtzMonitor zoomMonitor;
        public string[] propertyList = new string[0];


        #region Binding variables
        public event EventHandler Disposed;
        private BindingContext bindingContext;
        private ControlBindingsCollection dataBindings;
        ISite site;
        #endregion

        #region Properties

        public ViscaInfo PtzInfo { get { return ptz.info;  } }
        #endregion
        
        #region Constructors / Destructors
        public PtzCamera(ViscaCameraId id, PtzController ptz)
            : base(id, ptz?.controller)
        {
            this.address = (byte)id;
            this.ptz = ptz;
        }


        public new void Dispose()
        {
            ptMonitor?.Terminate();
            zoomMonitor?.Terminate();
        }
        #endregion

        #region Connect / Disconnect / Monitor
        public override void Connect()
        {
            ptMonitor = new PtzMonitor(this, false);
            zoomMonitor = new PtzMonitor(this, true);

            ptMonitor.Update();
            zoomMonitor.Update();

            PollEnabled = true;
            Poll();
        }

        public void PtEndTrack()
        {
            ptMonitor.Arrived();
        }
        public void ZoomEndTrack()
        {
            zoomMonitor.Arrived();
        }
        #endregion

        #region Custom commands for OAS Menu control (buttons on Preset tab)
        // Documented and tested for Clear One
        public class ViscaOsdMenu : ViscaCommand
        {
            String action;
            public ViscaOsdMenu(byte address, bool on)
            : base(address)
            {
                action = on ? "ON" : "OFF";
                Append(new byte[]{ 0x06, 0x06, (byte)(on ? 0x02 : 0x03) });
            }

            public override string ToString()
            {
                return String.Format("Camera{0} OSD Menu " + action, this.Destination);
            }
        }
        /*  Reference - Not in camera documents
        Menu Right: 8x 01 04 0B 02 FF
        Menu Left:  8x 01 04 0B 03 FF
        Menu Up:    8x 01 06 01 01 01 03 01 FF
        Menu Down:  8x 01 06 01 01 01 03 02 FF
        Menu +:     8x 01 06 06 02 FF
        Menu -:     8x 01 06 06 03 FF
        Menu Set:   8x 01 06 06 05 FF
         */
        public enum OsdKey
        {
            Up = 0x31,
            Left = 0x13,
            Right = 0x23,
            Down = 0x32,
            Set = 0x70,
        }
        public class ViscaOsdKey : ViscaCommand
        {
            public ViscaOsdKey(byte address, OsdKey key)
            : base(address)
            {
                switch (key) {
                    case OsdKey.Left:
                        Append(new byte[] { 0x04, 0x0b, 0x03 });
                        break;
                    case OsdKey.Right:
                        Append(new byte[] { 0x04, 0x0b, 0x02 });
                        break;
                    case OsdKey.Up:
                        Append(new byte[] { 0x06, 0x01, 0x01, 0x01, 0x03, 0x01 });
                        break;
                    case OsdKey.Down:
                        Append(new byte[] { 0x06, 0x01, 0x01, 0x01, 0x03, 0x02});
                        break;
                    case OsdKey.Set:
                        Append(new byte[] { 0x06, 0x06, 0x05 });
                        break;
                }
            }
            public ViscaOsdKey(byte address)
            : base(address)
            {
                Append(new byte[] { 0x06, 0x06, 0x05 });
            }

            public override string ToString()
            {
                return String.Format("Camera{0} OSD Menu", this.Destination);
            }
        }
        public void OsdMenu(bool on) { ptz.controller.EnqueueCommand(new ViscaOsdMenu(address, on)); }
        public void OsdKeypress(OsdKey key) { 
            ptz.controller.EnqueueCommand(new ViscaOsdKey(address, key));
        }
        #endregion

        #region PTZ / Preset
        /// <summary>
        /// Calculate the speed to use in the VISCA packet, assuming that a speed
        /// of 0 should become 1 
        /// </summary>
        private static byte AbsSpeed(int speed) => (byte)Math.Max(Math.Abs(speed), 1);

        public void ContinuousPanTilt(int panSpeed, int tiltSpeed, bool reversePan)
        {
            Console.WriteLine("Pan " + panSpeed + (reversePan ? " REVERSE":"") + " / Tilt " + tiltSpeed);
            if (reversePan)
            {
                panSpeed = -panSpeed;
            }
            PanSpeed = AbsSpeed(panSpeed);
            TiltSpeed = AbsSpeed(tiltSpeed);

            if (panSpeed > 0)
            {
                if (tiltSpeed > 0)
                {
                    UpRight();
                }
                else if (tiltSpeed < 0)
                {
                    DownRight();
                }
                else
                {
                    Right();
                }
            }
            else if (panSpeed < 0)
            {
                if (tiltSpeed > 0)
                {
                    UpLeft();
                }
                else if (tiltSpeed < 0)
                {
                    DownLeft();
                }
                else
                {
                    Left();
                }
            }
            else // == 0
            {
                if (tiltSpeed > 0)
                {
                    Up();
                }
                else if (tiltSpeed < 0)
                {
                    Down();
                }
                else
                {
                    Stop();
                    ptMonitor.Track();
                }
            }
            //StartTrack();
        }

        public void ContinuousZoom(int zoomSpeed)
        {
            Console.WriteLine("Zoom: " + zoomSpeed);
            ZoomSpeed = (byte)Math.Abs(zoomSpeed);
            if (zoomSpeed > 0)
            {
                ZoomTeleWithSpeed();
            }
            else if (zoomSpeed < 0)
            {
                ZoomWideWithSpeed();
            }
            else
            {
                ZoomStop();
                zoomMonitor.Track();
            }
            //StartTrack();
        }

        public void MoveToPreset(Preset p, CameraConfig config)
        {
            Preset.PtSpeed ptSpeed = p.Speed;
            if (ptSpeed == Preset.PtSpeed.NOT_SET)
            {
                ptSpeed = Preset.PtSpeed.Normal;
            }
            byte speed = (byte)(this.limitsByPropertyName["TiltSpeed"].Low + (int)ptSpeed
               * (this.limitsByPropertyName["TiltSpeed"].High - this.limitsByPropertyName["TiltSpeed"].Low)
               / (int)Preset.PtSpeed.NOT_SET); // NOT_SET is tne number speed enums

            this.PanSpeed = speed;
            this.TiltSpeed = speed;

            short pan = (short)(p.Pan * config.CountsPerDegree);
            short tilt = (short)(p.Tilt * config.CountsPerDegree);

            Console.WriteLine("Preset: P=" + pan + ", T=" + tilt + ", Z=" 
              + p.Zoom * config.FullScaleZoom + ", SP=" + speed);
            this.PositionAbsolute(pan, tilt);

            this.ZoomSetPosition((int)(p.Zoom * config.FullScaleZoom));
            zoomMonitor.Track();
        }
        #endregion

        #region Binding boilerplate
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlBindingsCollection DataBindings
        {
            get
            {
                if (dataBindings == null)
                {
                    dataBindings = new ControlBindingsCollection(this);
                }
                return dataBindings;
            }
        }

        public BindingContext BindingContext
        {
            get
            {
                if (bindingContext == null)
                {
                    bindingContext = new BindingContext();
                }
                return bindingContext;
            }
            set
            {
                bindingContext = value;
            }
        }
        public ISite Site
        {
            get { return site; }
            set { site = value; }
        }
        #endregion
    }
}
