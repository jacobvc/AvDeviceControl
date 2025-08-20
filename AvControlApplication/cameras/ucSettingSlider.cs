using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AVDeviceControl.ucVolumeSlider;

namespace AVDeviceControl
{
    using System.ComponentModel;

    public partial class ucSettingSlider : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private decimal _value;
        public decimal Value
        {
            get => _value;
            set
            {
                if (_value != value)
                {
                    _value = value;
                    slider.Value = value; // update the internal slider
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Value)));
                }
            }
        }

        public ucSettingSlider()
        {
            InitializeComponent();
            slider.ValueChanged += Slider_ValueChanged;
        }

        private void Slider_ValueChanged(object sender, EventArgs e)
        {
            Value = slider.Value; // this will raise PropertyChanged
        }

 
        // Public properties for internal controls
        [Browsable(true)]
        [Category("Behavior")]
        public int Minimum
        {
            get => (int)slider.Minimum;
            set => slider.Minimum = value;
        }

        [Browsable(true)]
        [Category("Behavior")]
        public int Maximum
        {
            get => (int)slider.Maximum;
            set => slider.Maximum = value;
        }

        [Browsable(true)]
        [Category("Appearance")]
        public int ScaleDivisions
        {
            get => (int)slider.ScaleDivisions;
            set => slider.ScaleDivisions = value;
        }

        [Browsable(true)]
        [Category("Appearance")]
        public bool ShowBorder
        {
            get => slider.ShowBorder;
            set => slider.ShowBorder = value;
        }

        [Browsable(true)]
        [Category("Appearance")]
        public string LabelText
        {
            get => label.Text;
            set => label.Text = value;
        }
        [Browsable(true)]
        [Category("Appearance")]
        public bool ShowDivisionsText
        {
            get => slider.ShowDivisionsText;
            set => slider.ShowDivisionsText = value;
        }
        [Browsable(true)]
        [Category("Appearance")]
        public int ScaleSubDivisions
        {
            get => (int)slider.ScaleSubDivisions;
            set => slider.ScaleSubDivisions = value;
        }

        [Browsable(true)]
        [Category("Appearance")]
        public Color BorderColor
        {
            get => slider.BorderColor;
            set => slider.BorderColor = value;
        }
    }
}
