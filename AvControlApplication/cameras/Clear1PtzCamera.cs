using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Threading;
using System.Windows.Forms;
using Visca;
using static Visca.Visca;
using Ctl = AVDeviceControl.PtzController;

namespace AVDeviceControl
{
    public partial class PtzCamera
    {
        public event PropertyChangedEventHandler PropertyChanged;

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
            get
            {
                Ctl.LogMessage(LogLevel.Trace,
                  ($"Get Brightness ({_brightness})"));
                return _brightness;
            }
            set
            {
                if (_brightness != value)
                {
                    Ctl.LogMessage(LogLevel.Trace,
                      $"Brightness set to ({value})");
                    _brightness = value;
                    ptz.controller.EnqueueCommand(brightInterface.Command(value));
                }
            }
        }
        protected void updateBrightness(short brightness)
        {
            if (_brightness != brightness)
            {
                Ctl.LogMessage(LogLevel.Trace,
                    $"Brightness updated to ({brightness})");
                _brightness = brightness;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Brightness)));
            }
        }

        public int Saturation
        {
            get 
            {
                Ctl.LogMessage(LogLevel.Trace, ($"Get Satutation ({_saturation})"));
                return _saturation; 
            }
            set
            {
                if (_saturation != value)
                {
                    Ctl.LogMessage(LogLevel.Trace, ($"Saturation set to ({value})"));
                    _saturation = value;
                    ptz.controller.EnqueueCommand(saturationInterface.Command(value));
                }
            }
        }

        protected void updateSaturation(short saturation)
        {
            if (_saturation != saturation)
            {
                Ctl.LogMessage(LogLevel.Trace, ($"Saturation updated to ({saturation})"));
                _saturation = saturation;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Saturation)));
            }
        }

        public int Contrast
        {
            get 
            {
                Ctl.LogMessage(LogLevel.Trace, ($"Get Contrast ({_contrast})"));
                return _contrast; 
            }
            set
            {
                if (_contrast != value)
                {
                    Ctl.LogMessage(LogLevel.Trace, ($"Contrast set to ({value})"));
                    _contrast = value;
                    ptz.controller.EnqueueCommand(contrastInterface.Command(value));
                }
            }
        }

        protected void updateContrast(short contrast)
        {
            if (_contrast != contrast)
            {
                _contrast = contrast;
                Ctl.LogMessage(LogLevel.Trace, ($"Contrast updated to ({contrast})"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Contrast)));
            }
        }

        public int Sharpness
        {
            get 
            {
                Ctl.LogMessage(LogLevel.Trace, ($"Get Sharpness ({_sharpness})"));
                return _sharpness; 
            }
            set
            {
                if (_sharpness != value)
                {
                    Ctl.LogMessage(LogLevel.Trace, ($"Sharpness set to ({value})"));
                    ptz.controller.EnqueueCommand(sharpnessInterface.Command(value));
                }
            }
        }
        protected void updateSharpness(short sharpness)
        {
            if (_sharpness != sharpness)
            {
                _sharpness = sharpness;
                Ctl.LogMessage(LogLevel.Trace, ($"Sharpness updated to ({sharpness})"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Sharpness)));
            }
        }
        public int Hue
        {
            get 
            {
                Ctl.LogMessage(LogLevel.Trace, ($"Get Hue ({_hue})"));
                return _hue; 
            }
            set
            {
                if (_hue != value)
                {
                    Ctl.LogMessage(LogLevel.Trace, ($"Hue set to ({value})"));
                    ptz.controller.EnqueueCommand(hueInterface.Command(value));
                }
            }
        }

        protected void updateHue(short hue)
        {
            if (_hue != hue)
            {
                _hue = hue;
                Ctl.LogMessage(LogLevel.Trace, ($"Hue updated to ({hue})"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Hue)));
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
            //  = new ViscaRangeLimits<int>(0, 20, "BGain limits");
            //public static ViscaRangeLimits<int> RGain
            //  = new ViscaRangeLimits<int>(0, 20, "RGain limits");
            public static ViscaRangeLimits<int> Brightness
              = new ViscaRangeLimits<int>(0, 14, "Brightness limits");
            public static ViscaRangeLimits<int> Saturation
              = new ViscaRangeLimits<int>(0, 14, "Saturation limits");
            public static ViscaRangeLimits<int> Contrast
              = new ViscaRangeLimits<int>(0, 14, "Contrast limits");
            public static ViscaRangeLimits<int> Sharpness
              = new ViscaRangeLimits<int>(0, 14, "Aperture (sharpness) limits");
            public static ViscaRangeLimits<int> Hue
              = new ViscaRangeLimits<int>(0, 14, "Hue limits");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Clear1PtzCamera"/> class.
        /// </summary>
        /// <param name="id">Camera ID.</param>
        /// <param name="ptz">PTZ controller.</param>
        public Clear1PtzCamera(ViscaCameraId id, PtzController ptz) : base(id, ptz)
        {
            limitsByPropertyName.Add(typeof(PtzParametersExtend));

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

            propertyList = new string[]
            {
                "Brightness",
                "Saturation",
                "Contrast",
                "Sharpness",
                "Hue"
            };
            PollListNew();
            PollListAddRange(propertyList);
        }

        // Expose Clear1ViscaCamera functionality as needed
    }
}