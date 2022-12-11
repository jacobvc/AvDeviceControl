using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AVDeviceControl
{
    public partial class ucVolumeSlider : UserControl
    {
        MidiChannel config = null;
        bool settingValue = false;

        public delegate void MuteChanged(object sender, bool value);
        public event MuteChanged MuteChangedEvent = null;
        public delegate void ControlValueChanged(object sender, int value);
        public event ControlValueChanged ControlValueChangedEvent = null;

        #region Constructors
        public ucVolumeSlider()
        {
            InitializeComponent();
            BackColor = sld.BackColor;
            ForeColor = sld.ForeColor;
            chkMute.ForeColor = Color.Black;

            sld.Maximum = 127;
            sld.Minimum = 0;
        }
        public ucVolumeSlider(String mixerName, MidiChannel config) : this()
        {
            this.config = config;
            this.MixerName = mixerName;

            sld.ValueChanged += Sld_ValueChanged;

            chkMute.CheckedChanged += ChkMute_CheckedChanged;

            settingValue = true;

            chkMute.Text = config.Name;
            sld.Maximum = 127;
            sld.Minimum = 0;
            sld.Value = 100;
            sld.InputValue = 0;

            settingValue = false;
        }
        #endregion

        public String MixerName { get; set; } = "";
        public MidiChannel Config { get { return config;  } }

        public int InputValue
        {
            get { return (int)sld.InputValue; }
            set { sld.InputValue = value; }
        }

        public int ControlValue
        {
            get { return (int)sld.Value; }
            set { settingValue = true; sld.Value = value; settingValue = false; }
        }

        public bool Mute
        {
            get { return chkMute.Checked; }
            set { settingValue = true; Invoke(new Action(() => { chkMute.Checked = value; })); settingValue = false; }
        }

        public bool MuteButton { set { Invoke(new Action(() => { chkMute.Checked = value; })); } }
        public int MoveSlider { set { sld.Value = value; } }

        private void Sld_ValueChanged(object sender, EventArgs e)
        {
            if (!settingValue)
            {
                ControlValueChangedEvent(this, (int)sld.Value);
            }
        }
        private void ChkMute_CheckedChanged(object sender, EventArgs e)
        {
            chkMute.BackColor = chkMute.Checked ? Color.White: Color.Lime;
            if (!settingValue)
            {
                MuteChangedEvent(this, chkMute.Checked);
            }
        }

    }
}
