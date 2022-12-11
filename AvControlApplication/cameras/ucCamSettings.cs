using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Visca;

namespace AVDeviceControl
{
    public partial class ucCamSettings : UserControl
    {
        BindingSource _binding;
        public ucCamSettings()
        {
            InitializeComponent();
        }

        private void BindToPosition(ColorSlider.ColorSlider ctl, String member,
            ViscaRangeLimits<int> limits)
        {
            if (ctl.DataBindings.Count > 0)
            {
                ctl.DataBindings.RemoveAt(0);
            }
            ctl.DataBindings.Add(new Binding("Value", _binding, member, true, 
                DataSourceUpdateMode.OnPropertyChanged));
            ctl.Minimum = limits.Low;
            ctl.Maximum = limits.High;
            int range = limits.High - limits.Low;
            ctl.ScaleDivisions = (range > 20) ? 10 : range;
        }
        public BindingSource Binding
        {
            set
            {
                _binding = value;
                PtzCamera camera = _binding.DataSource as PtzCamera;
                if (camera != null)
                {
                    BindToPosition(sldBright, "Brightness", camera.LimitsX.Brightness);
                    BindToPosition(sldAperture, "Aperture", camera.LimitsX.Arpeture);
                    BindToPosition(sldRGain, "RGain", camera.LimitsX.BGain);
                    BindToPosition(sldBGain, "BGain", camera.LimitsX.RGain);
                }
             }
        }

        private void cameraInfo_VisibleChanged(object sender, EventArgs e)
        {
            PtzCamera camera = _binding.DataSource as PtzCamera;
            cameraInfo.Text = "";
            cameraInfo.Text = camera?.PtzInfo.ToString().Replace(",", "\r\n") + "\r\n"
              + camera?.ToString().Replace("\t", "  ");
        }
    }
}
