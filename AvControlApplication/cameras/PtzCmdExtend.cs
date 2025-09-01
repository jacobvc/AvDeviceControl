using System;
using Visca;
using static Visca.Visca;
using Ctl = AVDeviceControl.PtzController;

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
                {
                    Ctl.LogMessage(LogLevel.Error,
                      $"Received packet responseLength {viscaRxPacket.PayLoad.Length} is not ViscaInfo Inquiry (>= 5)");
                }
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
    public class GenericViscaInterface
    {
        private readonly GenericParameters p;
        private readonly byte address;
        private readonly byte responseLength;
        private readonly PtzCamera camera;

        // Constructor to initialize all fields
        public GenericViscaInterface(GenericParameters parameters,
            byte address, byte responseLength, PtzCamera camera)
        {
            this.p = parameters;
            this.address = address;
            this.responseLength = responseLength;
            this.camera = camera;
        }

        public GenericViscaCommand Command(int position)
        {
            return new GenericViscaCommand(address, position, responseLength, camera.limitsByPropertyName.GetInt(p.name), p);
        }

        public GenericValueInquiry Inquiry(Action<short> action)
        {
            return new GenericValueInquiry(p, address, responseLength, position => { action(position); });
        }
        public class GenericViscaCommand : ViscaDynamicCommand
        {
            private readonly GenericParameters p;
            public GenericViscaCommand(byte address, int position, byte responseLength, IViscaRangeLimits<int> limits,
                GenericParameters parameters)
                : base(address)
            {
                if (position < limits.Low || position > limits.High)
                {
                    Ctl.LogMessage(LogLevel.Error,
                      $"GenericInterface({parameters.name}): Value ({position}) out of range {limits.Message}");
                    //throw new ArgumentOutOfRangeException("position",
                    //  $"GenericInterface({parameters.name}): Value({position}) out of range {limits.Message}");
                }

                ViscaVariable[] bytes = new ViscaVariable[responseLength];
                for (int i = 0; i < responseLength; i++)
                {
                    bytes[responseLength - 1 - i] = new ViscaVariable("Byte " + i, 
                      (byte)(position & 0x0F));
                    position >>= 4;
                }
                p = parameters;
                Append(new byte[] { parameters.category, p.valueCmd });
                foreach (ViscaVariable b in bytes)
                    Append(b);
                Ctl.LogMessage(LogLevel.Trace,
                  ($"GenericInterface({p.name}): Position({position}) sending {BitConverter.ToString(_bytes, 0, Length)}"));
            }
        }

        public class GenericValueInquiry : ViscaInquiry
        {
            private readonly Action<short> _completionAction;
            private readonly GenericParameters p;
            private readonly byte responseLength;
            public GenericValueInquiry(GenericParameters parameters, byte address, byte responseLength, Action<short> action)
                : base(address)
            {
                this.p = parameters;
                this.responseLength = responseLength;
                Append(new byte[] { p.category, p.inqCmd });
                _completionAction = action;
                Ctl.LogMessage(LogLevel.Trace,
                  ($"GenericInterface({p.name}): Inquiry sending {BitConverter.ToString(_bytes, 0, Length)}"));
            }

            public override void Process(ViscaRxPacket viscaRxPacket)
            {
                if (_completionAction != null)
                {
                    if (viscaRxPacket.PayLoad.Length >= responseLength)
                    {
                        if (viscaRxPacket.PayLoad.Length == responseLength)
                        {
                            short tmp = 0;
                            for (int i = 0; i < responseLength; i++)
                            {
                                tmp += (short)(viscaRxPacket.PayLoad[i] << (4 * (responseLength - 1 - i)));
                            }
                            short value = ((short)((viscaRxPacket.PayLoad[0] << 12) +
                                 (viscaRxPacket.PayLoad[1] << 8) +
                                 (viscaRxPacket.PayLoad[2] << 4) +
                                  viscaRxPacket.PayLoad[3])
                         );
                            _completionAction(value);
                            Ctl.LogMessage(LogLevel.Info,
                              ($"GenericInterface({p.name}): Received value ({value}) {tmp}"));
                        }
                        else
                        {
                            Ctl.LogMessage(LogLevel.Error,
                              $"GenericInterface({p.name}): Recieved packet (payload responseLength {viscaRxPacket.PayLoad.Length}) is too long");
                            throw new ArgumentOutOfRangeException("viscaRxPacket",
                              $"GenericInterface({p.name}): Recieved packet (payload responseLength {viscaRxPacket.PayLoad.Length}) is too long");

                        }
                    }
                    else
                    {
                        Ctl.LogMessage(LogLevel.Error,
                          $"GenericInterface({p.name}): Recieved packet (payload responseLength {viscaRxPacket.PayLoad.Length}) is too short");
                        throw new ArgumentOutOfRangeException("viscaRxPacket",
                          $"GenericInterface({p.name}): Recieved packet (payload responseLength {viscaRxPacket.PayLoad.Length}) is too short");
                    }
                }
            }
        }
        public override string ToString()
        {
            return $"Device{this.address} {this.p.name}";
        }
    }
}