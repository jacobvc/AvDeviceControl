using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using RtMidi.Core.Messages;
using RtMidi.Core.Enums;
using RtMidi.Core.Devices;
using System.Windows.Interop;

namespace AVDeviceControl
{
    public partial class frmMidiTest : Form
    {
        public delegate void Close(object sender, FormClosingEventArgs e);
        public event Close close = null;

        Midi.MidiConnection con;

        public frmMidiTest(Midi.MidiConnection con)
        {
            this.con = con;

            InitializeComponent();
        }

        private void frmMidiTest_Load(object sender, EventArgs e)
        {
            con.inp.SysEx += Inp_SysEx;
            con.inp.ChannelPressure += Inp_ChannelPressure;
            con.inp.ControlChange += Inp_ControlChange;
            con.inp.NoteOff += Inp_NoteOff;
            con.inp.NoteOn += Inp_NoteOn;
            con.inp.ProgramChange += Inp_ProgramChange;

        }

        private void frmMidiTest_FormClosing(object sender, FormClosingEventArgs e)
        {
            close?.Invoke(this, e);
        }

        public void SendShow(String label, byte[] msg)
        {
            Invoke(new Action(() => {
                if (msg.Length > 0)
                {
                    Emit("Sent " + label, "Data=" + BitConverter.ToString(msg));
                }
                else
                {
                    Emit("Sent " + label, "");
                }
            }));
        }

        void Emit(String type,  Channel channel, String msg)
        {
            rtxtOutput.AppendText(type + ": channel " + channel + ", msg:" + msg + "\n");
        }

        void Emit(String type, String msg)
        {
            rtxtOutput.AppendText(type + ": msg:" + msg + "\n");
        }

        private void Inp_ProgramChange(IMidiInputDevice sender, in ProgramChangeMessage msg)
        {
            ProgramChangeMessage amsg = msg;
            Invoke(new Action(() => { Emit("Program Change:", amsg.Channel, amsg.Program.ToString()); }));
        }

        private void Inp_NoteOn(IMidiInputDevice sender, in NoteOnMessage msg)
        {
            NoteOnMessage amsg = msg;
            Invoke(new Action(() => { Emit("Note On:", amsg.Channel, 
              "Key=" + amsg.Key.ToString() + ", velocity=" + amsg.Velocity.ToString()); }));
        }

        private void Inp_NoteOff(IMidiInputDevice sender, in NoteOffMessage msg)
        {
            NoteOffMessage amsg = msg;
            Invoke(new Action(() => {
                Emit("Note Off:", amsg.Channel,
                "Key=" + amsg.Key.ToString() + ", velocity=" + amsg.Velocity.ToString());
            }));
        }

        private void Inp_ControlChange(IMidiInputDevice sender, in ControlChangeMessage msg)
        {
            ControlChangeMessage amsg = msg;
            Invoke(new Action(() => {
                Emit("Control Change:", amsg.Channel,
                "Control=" + amsg.Control.ToString() + ", ControlFunction=" + amsg.ControlFunction.ToString()
                 + ", Value=" + amsg.Value.ToString());
            }));
        }

        private void Inp_ChannelPressure(IMidiInputDevice sender, in ChannelPressureMessage msg)
        {
            ChannelPressureMessage amsg = msg;
            Invoke(new Action(() => {
                Emit("Channel Pressure:", amsg.Channel,
                "Pressure=" + amsg.Pressure.ToString());
            }));
        }

        private void Inp_SysEx(IMidiInputDevice sender, in SysExMessage msg)
        {
            SysExMessage amsg = msg;
            Invoke(new Action(() => {
                Emit("SysEx:", "Data=" + BitConverter.ToString(amsg.Data));
            }));
        }
    }
}
