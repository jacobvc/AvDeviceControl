using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Visca;

namespace AVDeviceControl
{
    public class PtzCamera : ViscaCamera, IBindableComponent
    {
        byte address;
        public PtzController ptz;
        PtzMonitor monitor;

        #region Binding variables
        public event EventHandler Disposed;
        private BindingContext bindingContext;
        private ControlBindingsCollection dataBindings;
        ISite site;
        #endregion

        #region Properties
        public ViscaCameraParameters Limits { get; }
        public PtzParametersExtend LimitsX { get; }
        private int _brightness;

        public int Brightness
        {
            get { return _brightness; }
            set { _brightness = value;  ptz.controller.EnqueueCommand(
              new ViscaBrightValue(address, value, this)); }
        }

        public ViscaInfo PtzInfo { get { return ptz.info;  } }
        #endregion

        #region Constructors / Destructors
        public PtzCamera(ViscaCameraId id, ViscaCameraParameters parameters, PtzController ptz)
            : base(id, parameters, ptz?.controller)
        {
            this.address = (byte)id;
            this.ptz = ptz;

            if (parameters == null)
            {
                Limits = new ViscaCameraDefaultParameters();
            }
            else
            {
                Limits = parameters;
            }
            LimitsX = new PtzParametersExtend();
        }

        public void Dispose()
        {
            monitor?.Terminate();
        }
        #endregion

        public void Connect()
        {
            monitor = new PtzMonitor(this);

            monitor.Update();
            ptz.controller.EnqueueCommand(new ViscaBrightInquiry(address, ReceivedBrightness));

            PollEnabled = true;
            Poll();
        }

        public void UpdatePosition()
        {
            monitor.Update();
        }
        public void StartTrack()
        {
            monitor.Track();
        }
        public void EndTrack()
        {
            monitor.Arrived();
        }

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
        // Documented for Sony. Tested for Clear One
        public class ViscaOsdOk : ViscaCommand
        {
            public ViscaOsdOk(byte address)
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
        public void OsdOk() { ptz.controller.EnqueueCommand(new ViscaOsdOk(address)); }
        #endregion

        void ReceivedBrightness(short brightness)
        {
            _brightness = brightness;
        }
        /// <summary>
        /// Calculate the speed to use in the VISCA packet, assuming that a speed
        /// of 0 should become 1 
        /// </summary>
        private static byte AbsSpeed(int speed) => (byte)Math.Max(Math.Abs(speed), 1);

        public void ContinuousPanTilt(int panSpeed, int tiltSpeed)
        {
            Console.WriteLine("Pan " + panSpeed + " / Tilt " + tiltSpeed);
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
                }
            }
            StartTrack();
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
            }
            StartTrack();
        }

        public void MoveToPreset(Preset p, CameraConfig config)
        {
            Preset.PtSpeed ptSpeed = p.Speed;
            if (ptSpeed == Preset.PtSpeed.NOT_SET)
            {
                ptSpeed = Preset.PtSpeed.Normal;
            }
            byte speed = (byte)(this.Limits.TiltSpeedLimits.Low + (int)ptSpeed
               * (this.Limits.TiltSpeedLimits.High - this.Limits.TiltSpeedLimits.Low)
               / (int)Preset.PtSpeed.NOT_SET); // NOT_SET is tne number speed enums

            this.PanSpeed = speed;
            this.TiltSpeed = speed;

            short pan = (short)(p.Pan * config.CountsPerDegree);
            short tilt = (short)(p.Tilt * config.CountsPerDegree);

            Console.WriteLine("Preset: P=" + pan + ", T=" + tilt + ", Z=" 
              + p.Zoom * config.FullScaleZoom + ", SP=" + speed);
            this.PositionAbsolute(pan, tilt);

            this.ZoomSetPosition((int)(p.Zoom * config.FullScaleZoom));
            StartTrack();
        }


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
