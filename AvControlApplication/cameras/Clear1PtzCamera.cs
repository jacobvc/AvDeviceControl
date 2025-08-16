using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;
using Visca;

namespace AVDeviceControl
{
    /// <summary>
    /// Represents a ClearOne PTZ camera, extending the base PTZ camera functionality.
    /// </summary>
    public class Clear1PtzCamera : PtzCamera
    {
        private readonly ViscaClear1HueInquiry _rClear1HueInquiry;
        private int _Clear1Hue;
        private bool _suppressSet = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="Clear1PtzCamera"/> class.
        /// </summary>
        /// <param name="id">Camera ID.</param>
        /// <param name="parameters">Camera parameters.</param>
        /// <param name="ptz">PTZ controller.</param>
        public Clear1PtzCamera(ViscaCameraId id, ViscaCameraParameters parameters, PtzController ptz)
            : base(id, parameters, ptz)
        {
            _rClear1HueInquiry = new ViscaClear1HueInquiry(
                (byte)id,
                position => { updateClear1Hue(position); });

            _pollCommands.Add(_rClear1HueInquiry);

            _visca.EnqueueCommand(_rClear1HueInquiry);

            //extensionSource.DataSource = this;
            //DataBindings.Add("Clear1Hue", extensionSource, "Clear1Hue");     
            
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
                    _visca.EnqueueCommand(new ViscaClear1HueValue(1, value, new PtzParametersExtend().Hue));
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