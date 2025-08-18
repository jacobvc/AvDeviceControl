using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Visca;
using static AVDeviceControl.PtzCamera;
using static Visca.Visca;

namespace AVDeviceControl
{
    public static partial class Commands
    {
        public const byte Info = 0x02;
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
            Append(new byte[] { Category.Interface, Commands.Info });
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

    public class GenericParameters
    {
        public readonly string name;
        public readonly byte inqCmd;
        public readonly byte valueCmd;
        public readonly byte category;
        public GenericParameters(string name, byte inqCmd, byte valueCmd, byte category)
        {
            this.name = name;
            this.inqCmd = inqCmd;
            this.valueCmd = valueCmd;
            this.category = category;
        }
    }
    public class GenericPositionInterface
    {
        private readonly GenericParameters p;
        private readonly byte address;
        private readonly PtzCamera camera;

        // Constructor to initialize all fields
        public GenericPositionInterface(GenericParameters parameters,
            byte address, PtzCamera camera)
        {
            this.p = parameters;
            this.address = address;
            this.camera = camera;
        }

        public GenericPositionCommand Command(int position)
        {
            return new GenericPositionCommand(address, position, camera.limits.getInt(p.name), p.category, p.valueCmd);
        }

        public GenericPositionInquiry Inquiry(Action<short> action)
        {
            return new GenericPositionInquiry(p.inqCmd, p.category, address,
              position => { action(position); });
        }
        public class GenericPositionCommand : ViscaPositionCommand
        {
            public GenericPositionCommand(byte address, int position, IViscaRangeLimits<int> limits,
                byte category, byte valueCmd)
                : base(address, position, limits)
            {
                Append(new byte[] { category, valueCmd });
                AppendPosition();
            }
        }

        public class GenericPositionInquiry : ViscaInquiry
        {
            private readonly Action<short> _completionAction;
            public GenericPositionInquiry(byte inqCmd, byte category, byte address, Action<short> action)
                : base(address)
            {
                Append(new byte[] { category, inqCmd });
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
                        throw new ArgumentOutOfRangeException("viscaRxPacket", "Recieved packet is not Clear1HueInquiry");
                }
            }
        }
        public override string ToString()
        {
            return String.Format("Device{0} {1}.Value 0x{1:X2} ()", this.address, this.p.name);
        }
    }
}