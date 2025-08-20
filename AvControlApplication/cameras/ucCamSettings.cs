using AVDeviceControl.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Visca.Camera.PropertyDictionary;

namespace AVDeviceControl
{
    public partial class ucCamSettings : UserControl
    {
        Dictionary<String, ucSettingSlider> _sliders = new Dictionary<string, ucSettingSlider>();

        BindingSource _binding;
        public ucCamSettings()
        {
            InitializeComponent();
        }

        private void BindToPosition(String member)
        {
            PtzCamera camera = _binding.DataSource as PtzCamera;
            if (camera != null)
            {
                ucSettingSlider ctl = AddSlider(member);
                if (ctl.DataBindings.Count > 0)
                {
                    ctl.DataBindings.RemoveAt(0);
                }
                ViscaRangeDictionary.Limits limits = camera.limitsByPropertyName.get(member);
                ctl.DataBindings.Add(new Binding("Value", _binding, member, true, DataSourceUpdateMode.OnPropertyChanged));
                ctl.Minimum = limits.Low;
                ctl.Maximum = limits.High;
                int range = limits.High - limits.Low;
                ctl.ScaleDivisions = (range > 5) ? 5 : range;
                ctl.ShowBorder = true;
                //      ctl.BorderColor = Color.DarkGray;
                // ctl.LabelTextRotation = limits.High > 99 ? -90 : 0;
                ctl.ShowDivisionsText = true;
                ctl.LabelText = limits.Label;
            }
        }
        string[] _sliderList = new string[0];
        public string[] Sliders
        {
            set             {
                _sliderList = value;
            }
        }
        public BindingSource Binding
        {
            set
            {
                _binding = value;
                {
                    foreach (string propertyName in _sliderList)
                    {
                        BindToPosition(propertyName);
                    }
                }
            }
        }

        private ucSettingSlider AddSlider(String name)
        {
            if (_sliders.ContainsKey(name))
                return _sliders[name];

            ucSettingSlider sld = new ucSettingSlider();
            int visibleWidth = sld.Width;
            int width = sld.Width;

            int x = _sliders.Count * visibleWidth;

            sld.Left = x;

            grpCamera.Left = x + visibleWidth;
            Controls.Add(sld);

            _sliders[name] = sld;
            return sld;
        }

        private void cameraInfo_VisibleChanged(object sender, EventArgs e)
        {
            PtzCamera camera = _binding.DataSource as PtzCamera;
            cameraInfo.Text = "Camera Info";
            cameraInfo.Text += (("\r\n\t" + camera?.PtzInfo.ToString()).Replace(",", "\r\n\t") + "\r\n"
              + "\r\n" + camera?.ToString()).Replace("\t", "    ");
        }
    }
}
