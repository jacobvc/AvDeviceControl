using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Visca;

namespace AVDeviceControl
{
    public class Rocware10xUsbCamera : ViscaCameraParameters
    {
        public Rocware10xUsbCamera()
        {
            /// <summary>
            /// Pan Speed values for VISCA are in range 0x01 to 0x18
            /// </summary>
            PanSpeedLimits = new ViscaRangeLimits<byte>(0x1, 0x18, "Pan Speed should be in range from 0x1 to 0x18");

            /// <summary>
            /// Tilt Speed values for VISCA are in range 0x01 to 0x14
            /// </summary>
            TiltSpeedLimits = new ViscaRangeLimits<byte>(0x1, 0x14, "Tilt Speed should be in range from 0x1 to 0x14");

            /// <summary>
            /// Zoom Speed values for VISCA are in range 0x00 to 0x07
            /// </summary>
            ZoomSpeedLimits = new ViscaRangeLimits<byte>(0x0, 0x7, "Zoom Speed should be in range from 0 to 7");

            /// <summary>
            /// Focus Speed values for VISCA are in range 0x00 to 0x07
            /// </summary>
            FocusSpeedLimits = new ViscaRangeLimits<byte>(0x0, 0x7, "Focus Speed should be in range from 0 to 7");
        }
    }
}
