using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;
using Visca;
using static AVDeviceControl.GenericPositionInterface;
using static Visca.Visca;

namespace AVDeviceControl
{
    public partial class PtzCamera
    {
        // Interfaces for generic position inquiries
        protected GenericPositionInterface brightInterface;
        protected GenericPositionInterface saturationInterface;
        protected GenericPositionInterface contrastInterface;
        protected GenericPositionInterface sharpnessInterface;
        protected GenericPositionInterface hueInterface;

        // backing variables for properties
        // Add these properties to the PtzCamera class

        protected int _brightness;
        protected int _saturation;
        protected int _contrast;
        protected int _sharpness;
        protected int _hue;
        public int Brightness
        {
            get { return _brightness; }
            set
            {
                _brightness = value; ptz.controller.EnqueueCommand(
              brightInterface.Command(value));
            }
        }
        protected virtual void onBrightnessChanged(PositionEventArgs e)
        {
            _brightness = e.Position;
        }

        protected void updateBrightness(short brightness)
        {
            if (_brightness != brightness)
            {
                _brightness = brightness;
                onBrightnessChanged(new PositionEventArgs(brightness));
            }
        }

        public int Saturation
        {
            get { return _saturation; }
            set
            {
                if (_saturation != value)
                {
                    ptz.controller.EnqueueCommand(saturationInterface.Command(value));
                }
            }
        }

        protected virtual void onSaturationChanged(PositionEventArgs e)
        {
            _saturation = e.Position;
        }

        protected void updateSaturation(short saturation)
        {
            if (_saturation != saturation)
            {
                _saturation = saturation;
                onSaturationChanged(new PositionEventArgs(saturation));
            }
        }

        public int Contrast
        {
            get { return _contrast; }
            set
            {
                if (_contrast != value)
                {
                    ptz.controller.EnqueueCommand(contrastInterface.Command(value));
                }
            }
        }

        protected virtual void onContrastChanged(PositionEventArgs e)
        {
            _contrast = e.Position;
        }

        protected void updateContrast(short contrast)
        {
            if (_contrast != contrast)
            {
                _contrast = contrast;
                onContrastChanged(new PositionEventArgs(contrast));
            }
        }

        public int Sharpness
        {
            get { return _sharpness; }
            set
            {
                if (_sharpness != value)
                {
                    ptz.controller.EnqueueCommand(sharpnessInterface.Command(value));
                }
            }
        }
        protected virtual void onSharpnessChanged(PositionEventArgs e)
        {
            _sharpness = e.Position;
        }

        protected void updateSharpness(short sharpness)
        {
            if (_sharpness != sharpness)
            {
                _sharpness = sharpness;
                onSharpnessChanged(new PositionEventArgs(sharpness));
            }
        }
        public int Hue
        {
            get { return _hue; }
            set
            {
                if (_hue != value)
                {
                    ptz.controller.EnqueueCommand(hueInterface.Command(value));
                }
            }
        }

        protected virtual void onHueChanged(PositionEventArgs e)
        {
            _hue = e.Position;
        }

        protected void updateHue(short hue)
        {
            if (_hue != hue)
            {
                _hue = hue;
                onHueChanged(new PositionEventArgs(hue));
            }
        }

    }
    /// <summary>
    /// Represents a ClearOne PTZ camera, extending the base PTZ camera functionality.
    /// </summary>
    public class Clear1PtzCamera : PtzCamera
    {
        // Interface parameters for GenericPositionInterface
        GenericParameters brightnessParameters = new GenericParameters(
             name: "Brightness",
             inqCmd: 0xa1,
             valueCmd: 0xa1,
             category: Category.Camera1
          );
        GenericParameters saturationParameters = new GenericParameters(
            name: "Saturation",
            inqCmd: 0x49,
            valueCmd: 0x58,
            category: Category.Camera1
         );
        GenericParameters contrastParameters = new GenericParameters(
            name: "Contrast",
            inqCmd: 0xa2,
            valueCmd: 0xa2,
            category: Category.Camera1
         );
        GenericParameters sharpnessParameters = new GenericParameters(
            name: "Sharpness",
            inqCmd: 0x42,
            valueCmd: 0x42,
            category: Category.Camera1
         );
        GenericParameters hueParameters = new GenericParameters(
            name: "Hue",
            inqCmd: 0x4f,
            valueCmd: 0x4f,
            category: Category.Camera1
         );

        public static class PtzParametersExtend
        {
            //public static ViscaRangeLimits<int> BGain
            //  = new ViscaRangeLimits<int>(0, 20, "BGain limitsByPropertyName");
            //public static ViscaRangeLimits<int> RGain
            //  = new ViscaRangeLimits<int>(0, 20, "RGain limitsByPropertyName");
            public static ViscaRangeLimits<int> Brightness
              = new ViscaRangeLimits<int>(0, 14, "Brightness limitsByPropertyName");
            public static ViscaRangeLimits<int> Saturation
              = new ViscaRangeLimits<int>(0, 14, "Saturation limitsByPropertyName");
            public static ViscaRangeLimits<int> Contrast
              = new ViscaRangeLimits<int>(0, 14, "Contrast limitsByPropertyName");
            public static ViscaRangeLimits<int> Sharpness
              = new ViscaRangeLimits<int>(60, 200, "Aperture limitsByPropertyName");
            public static ViscaRangeLimits<int> Hue
              = new ViscaRangeLimits<int>(0, 14, "Hue limitsByPropertyName");
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
            brightInterface = new GenericPositionInterface(brightnessParameters, (byte)id, this);
            InquiriesByPropertyName.Add("Brightness", brightInterface.Inquiry(updateBrightness));

            saturationInterface = new GenericPositionInterface(saturationParameters, (byte)id, this);
            InquiriesByPropertyName.Add("Saturation", saturationInterface.Inquiry(updateSaturation));

            contrastInterface = new GenericPositionInterface(contrastParameters, (byte)id, this);
            InquiriesByPropertyName.Add("Contrast", contrastInterface.Inquiry(updateContrast));

            sharpnessInterface = new GenericPositionInterface(sharpnessParameters, (byte)id, this);
            InquiriesByPropertyName.Add("Sharpness", sharpnessInterface.Inquiry(updateSharpness));

            hueInterface = new GenericPositionInterface(hueParameters, (byte)id, this);
            InquiriesByPropertyName.Add("Hue", hueInterface.Inquiry(updateHue));
        }
 
        // Expose Clear1ViscaCamera functionality as needed
    }
}