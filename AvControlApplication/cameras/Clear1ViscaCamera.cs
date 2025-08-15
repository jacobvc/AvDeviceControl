using System;
using System.Windows.Media.Media3D;
using Visca;

namespace AVDeviceControl
{
    public class Clear1ViscaCamera : ViscaCamera
    {
        private readonly ViscaClear1HueInquiry _rClear1HueInquiry;

        public Clear1ViscaCamera(
            ViscaCameraId id,
            ViscaCameraParameters parameters,
            ViscaProtocolProcessor visca)
            : base(id, parameters, visca)
        {
            _rClear1HueInquiry = new ViscaClear1HueInquiry(
                (byte)id,
                position => { updateClear1Hue(position); }
            );
        }

        public event EventHandler<PositionEventArgs> Clear1HueChanged;

        protected virtual void OnClear1HueChanged(PositionEventArgs e)
        {
            EventHandler<PositionEventArgs> handler = Clear1HueChanged;
#if SSHARP
                if (handler != null)
                    handler(this, e);
#else
            handler?.Invoke(this, e);
#endif
        }
        private int _Clear1Hue;

        protected void updateClear1Hue(short Clear1Hue)
        {
            if (_Clear1Hue != Clear1Hue)
            {
                _Clear1Hue = Clear1Hue;
                OnClear1HueChanged(new PositionEventArgs(Clear1Hue));
            }
        }
 
        public int Clear1Hue
        {
            get { return _Clear1Hue; }
            set { _visca.EnqueueCommand(new ViscaClear1HueValue(1, value, new PtzParametersExtend().Clear1Hue)); }
        }

        // You can override ViscaCamera methods or add new functionality here
        public override string ToString()
        {
            return base.ToString()
             + "\tHue:\t\t" + Clear1Hue + "\r\n";

        }
    }
}