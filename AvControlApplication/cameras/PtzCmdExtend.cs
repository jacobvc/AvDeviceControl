using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Visca;

namespace AVDeviceControl
{
    public static partial class Commands
    {
        public const byte Info = 0x02;

        public const byte Bright = 0x0D;
        public const byte BrightValue = 0x4D;
    }

    public class PtzParametersExtend
    {
        public ViscaRangeLimits<int> Brightness 
          = new ViscaRangeLimits<int>(0, 14, "Brightness limits");
        public ViscaRangeLimits<int> Arpeture
          = new ViscaRangeLimits<int>(0, 14, "Arpeture limits");
        public ViscaRangeLimits<int> BGain
          = new ViscaRangeLimits<int>(0, 20, "BGain limits");
        public ViscaRangeLimits<int> RGain
          = new ViscaRangeLimits<int>(0, 20, "RGain limits");
    }
    /// <summary>
    /// ViscaInfo class 
    /// </summary>
    public class ViscaInfo
    {
        public UInt16 vendor = 0;
        public UInt16 model = 0;
        public UInt16 rom_version = 0;
        public Byte socket_num = 0;

        public ViscaInfo() { }
        public ViscaInfo(UInt16 vendor, UInt16 model, UInt16 rom_version, Byte socket_num)
        {
            this.vendor = vendor;
            this.model = model;
            this.rom_version = rom_version;
            this.socket_num = socket_num;
        }
        public override string ToString()
        {
            return String.Format("Vendor 0x{0:X4}, Model 0x{1:X4}, Rom version 0x{2:X4}, Socket {3}",
                vendor, model, rom_version, socket_num);
        }
    }

    /// <summary>
    /// ViscaInfo inquiry command
    /// </summary>
    public class ViscaInfoInquiry : ViscaInquiry
    {
        private readonly Action<ViscaInfo> _completionAction;
        public ViscaInfoInquiry(byte address, Action<ViscaInfo> action)
            : base(address)
        {
            Append(new byte[] { /* Visca.Category.Interface */0x00, Commands.Info });
            _completionAction = action;
        }

        public override void Process(ViscaRxPacket viscaRxPacket)
        {
            if (_completionAction != null)
            {
                if (viscaRxPacket.PayLoad.Length >= 5)
                {
                    ViscaInfo info = new ViscaInfo(
                      (UInt16)((viscaRxPacket.PayLoad[0] << 8) | viscaRxPacket.PayLoad[1]),
                      (UInt16)((viscaRxPacket.PayLoad[2] << 8) | viscaRxPacket.PayLoad[3]),
                      (UInt16)((viscaRxPacket.PayLoad[4] << 8) | viscaRxPacket.PayLoad[5]),
                      viscaRxPacket.PayLoad[6]);
                    _completionAction(info);
                }
                else
                    throw new ArgumentOutOfRangeException("viscaRxPacket", "Recieved packet is not ViscaInfo Inquiry");
            }
        }
    }
    public class ViscaBrightValue : ViscaPositionCommand
    {
        public ViscaBrightValue(byte address, int position, PtzCamera camera)
        : this(address, position, camera.LimitsX.Brightness)
        { }

        public ViscaBrightValue(byte address, int position, IViscaRangeLimits<int> limits)
        : base(address, position, limits)
        {
            Append(new byte[]{ /* Visca.Category.Camera1 */0x04, Commands.BrightValue });
            AppendPosition();
        }

        public override string ToString()
        {
            return String.Format("Camera{0} Bright.Value 0x{1:X2} ({1})", this.Destination, Position);
        }
    }

    public class ViscaBrightInquiry : ViscaInquiry
    {
        private readonly Action<short> _completionAction;
        public ViscaBrightInquiry(byte address, Action<short> action)
        : base(address)
        {
            Append(new byte[] { /* Visca.Category.Camera1 */0x04, Commands.BrightValue });
            _completionAction = action;
        }

        public override void Process(ViscaRxPacket viscaRxPacket)
        {
            if (_completionAction != null)
            {
                if (viscaRxPacket.PayLoad.Length >= 4)
                {
                    if (viscaRxPacket.PayLoad.Length == 4)
                    {
                        _completionAction((short)((viscaRxPacket.PayLoad[0] << 12) +
                                 (viscaRxPacket.PayLoad[1] << 8) +
                                 (viscaRxPacket.PayLoad[2] << 4) +
                                  viscaRxPacket.PayLoad[3])
                         );
                    }
                }
                else
                    throw new ArgumentOutOfRangeException("viscaRxPacket", "Recieved packet is not Brightness Inquiry");
            }
        }

        public override string ToString()
        {
            return String.Format("Camera{0} Bright.Inquiry", this.Destination);
        }
    }
}
