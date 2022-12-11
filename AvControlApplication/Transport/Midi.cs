using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tmds.MDns;
using RtMidi.Core;
using RtMidi.Core.Devices;
using RtMidi.Core.Devices.Infos;
using RtMidi.Core.Messages;

namespace AVDeviceControl
{
    public class Midi
    {
        List<IMidiInputDeviceInfo> devices = new List<IMidiInputDeviceInfo>();
        List<MidiConnection> connections = new List<MidiConnection>();
        public Midi() {
        }

        public IMidiInputDeviceInfo[] Devices
        {
            get
            {
                devices.Clear();

                foreach (var inputDeviceInfo in MidiDeviceManager.Default.InputDevices)
                {
                    //Console.WriteLine($"Opening {inputDeviceInfo.Name}");
                    devices.Add(inputDeviceInfo);
                }
                return devices.ToArray();
            }
        }

        public class MidiConnection
        {
            public IMidiInputDeviceInfo inpInfo;
            public IMidiInputDevice inp;
            public IMidiOutputDevice outp = null;

            public MidiConnection(IMidiInputDeviceInfo inpInfo, IMidiInputDevice inp)
            {
                this.inpInfo = inpInfo;
                this.inp = inp;

                //inp.SysEx += Inp_SysEx;
            }

        }

        public MidiConnection Connect(IMidiInputDeviceInfo deviceInfo)
        {
            MidiConnection conn = null;
            try
            {
                var inputDevice = deviceInfo.CreateDevice();
                IMidiOutputDevice outp = null;
                bool ok = inputDevice.Open();

                if (ok)
                {
                    conn = new MidiConnection(deviceInfo, inputDevice);
                    connections.Add(conn);
                    foreach (var dev in MidiDeviceManager.Default.OutputDevices)
                    {
                        if (dev.Name.Equals(deviceInfo.Name))
                        {
                            outp = dev.CreateDevice();
                            conn.outp = outp;
                            if (outp != null)
                            {
                                outp.Open();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Connect FAILED! " + ex.Message);
            }

            return conn;
        }
        public void Disconnect(MidiConnection conn)
        {
            conn.inp.Close();
            if (conn.outp != null)
            {
                conn.outp.Close();
            }
            connections.Remove(conn);
        }
    }
}

