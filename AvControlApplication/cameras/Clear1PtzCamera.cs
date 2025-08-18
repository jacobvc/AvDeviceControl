using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;
using Visca;
using static AVDeviceControl.GenericPositionInterface;
using static Visca.Visca;

namespace AVDeviceControl
{
    /// <summary>
    /// Represents a ClearOne PTZ camera, extending the base PTZ camera functionality.
    /// </summary>
    public class Clear1PtzCamera : PtzCamera
    {
        private GenericPositionInterface hueInterface;
        private readonly GenericPositionInquiry _rClear1HueInquiry;
        private int _Clear1Hue;
        private bool _suppressSet = false;

        GenericParameters hueParameters = new GenericParameters(
            name: "Hue",
            inqCmd: 0x4f,
            valueCmd: 0x4f,
            category: Category.Camera1
         );

        public static class PtzParametersExtend
        {
            public static ViscaRangeLimits<int> Brightness
              = new ViscaRangeLimits<int>(0, 14, "Brightness limits");
            public static ViscaRangeLimits<int> Aperture
              = new ViscaRangeLimits<int>(0, 14, "Aperture limits");
            public static ViscaRangeLimits<int> BGain
              = new ViscaRangeLimits<int>(0, 20, "BGain limits");
            public static ViscaRangeLimits<int> RGain
              = new ViscaRangeLimits<int>(0, 20, "RGain limits");
            public static ViscaRangeLimits<int> Hue
              = new ViscaRangeLimits<int>(0, 14, "Hue limits");
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="Clear1PtzCamera"/> class.
        /// </summary>
        /// <param name="id">Camera ID.</param>
        /// <param name="parameters">Camera parameters.</param>
        /// <param name="ptz">PTZ controller.</param>
        public Clear1PtzCamera(ViscaCameraId id, ViscaCameraParameters parameters, PtzController ptz)
            : base(id, parameters, ptz)
        {
            hueInterface = new GenericPositionInterface(hueParameters, (byte)id, this);
            _rClear1HueInquiry = hueInterface.Inquiry(updateClear1Hue);

            _pollCommands.Add(_rClear1HueInquiry);

            ptz.controller.EnqueueCommand(_rClear1HueInquiry);
        }
        public override string ToString()
        {
            return base.ToString()
                + "\tHue:\t\t" + Hue + "\r\n";
        }

        protected virtual void OnClear1HueChanged(PositionEventArgs e)
        {
            _Clear1Hue = e.Position;
        }

        public override int Hue
        {
            get { return _Clear1Hue; }
            set
            {
                if (_Clear1Hue != value)
                {
                    _visca.EnqueueCommand(hueInterface.Command(value));
                }
            }
        }

        protected void updateClear1Hue(short Clear1Hue)
        {
            if (_Clear1Hue != Clear1Hue)
            {
                _Clear1Hue = Clear1Hue;
                OnClear1HueChanged(new PositionEventArgs(Clear1Hue));
            }
        }
        // Expose Clear1ViscaCamera functionality as needed
    }
}