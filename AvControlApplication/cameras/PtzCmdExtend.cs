using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
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
                    Debug.WriteLine($"Recieved packet length {viscaRxPacket.PayLoad.Length} is not ViscaInfo Inquiry (>= 5)");
                    //throw new ArgumentOutOfRangeException("ViscaInfo", "Recieved packet length {viscaRxPacket.PayLoad.Length} is not ViscaInfo Inquiry");
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
            return new GenericPositionCommand(address, position, camera.limitsByPropertyName.getInt(p.name), p);
        }

        public GenericPositionInquiry Inquiry(Action<short> action)
        {
            return new GenericPositionInquiry(p, address, position => { action(position); });
        }
        public class GenericPositionCommand : ViscaPositionCommand
        {
            private readonly GenericParameters p;
            public GenericPositionCommand(byte address, int position, IViscaRangeLimits<int> limits,
                GenericParameters parameters)
                : base(address, position, limits)
            {
                p = parameters;
                Append(new byte[] { parameters.category, p.valueCmd });
                AppendPosition();
                Debug.WriteLine($"GenericInterface({p.name}): Position({position}) sending {BitConverter.ToString(_bytes, 0, Length)}");
            }
        }

        public class GenericPositionInquiry : ViscaInquiry
        {
            private readonly Action<short> _completionAction;
            private readonly GenericParameters p;
            public GenericPositionInquiry(GenericParameters parameters, byte address, Action<short> action)
                : base(address)
            {
                this.p = parameters;
                Append(new byte[] { p.category, p.inqCmd });
                _completionAction = action;
                //Debug.WriteLine($"GenericInterface({p.name}): Inquiry sending {BitConverter.ToString(_bytes, 0, Length)}");
            }

            public override void Process(ViscaRxPacket viscaRxPacket)
            {
                if (_completionAction != null)
                {
                    if (viscaRxPacket.PayLoad.Length >= 4)
                    {
                        if (viscaRxPacket.PayLoad.Length == 4)
                        {
                            short value = ((short)((viscaRxPacket.PayLoad[0] << 12) +
                                     (viscaRxPacket.PayLoad[1] << 8) +
                                     (viscaRxPacket.PayLoad[2] << 4) +
                                      viscaRxPacket.PayLoad[3])
                             );
                            _completionAction(value);
                            Debug.WriteLine($"GenericInterface({p.name}): Received value ({value})");
                        }
                        else
                        {
                            throw new ArgumentOutOfRangeException("viscaRxPacket",
                              $"GenericInterface({p.name}): Recieved packet (payload length {viscaRxPacket.PayLoad.Length}) is too long");

                        }
                    }
                    else
                        throw new ArgumentOutOfRangeException("viscaRxPacket",
                          $"GenericInterface({p.name}): Recieved packet (payload length {viscaRxPacket.PayLoad.Length}) is too short");
                }
            }
        }
        public override string ToString()
        {
            return $"Device{this.address} {this.p.name}";
        }
    }
}