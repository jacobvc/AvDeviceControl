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
using Visca;

namespace AVDeviceControl
{
    public partial class ucCamSettings : UserControl
    {
        Dictionary<String, ColorSlider.ColorSlider> _sliders = new Dictionary<string, ColorSlider.ColorSlider>();

        BindingSource _binding;
        public ucCamSettings()
        {
            InitializeComponent();
        }

        private void BindToPosition(String member)
        {
            PtzCamera camera = _binding.DataSource as PtzCamera;
            if (camera != null) {
                ColorSlider.ColorSlider ctl = AddSlider(member);
                if (ctl.DataBindings.Count > 0)
                {
                    ctl.DataBindings.RemoveAt(0);
                }
                ViscaRangeDictionary.Limits limits = camera.limitsByPropertyName.get(member);
            ctl.DataBindings.Add(new Binding("Value", _binding, member, true,
                DataSourceUpdateMode.OnPropertyChanged));
                ctl.Minimum = limits.Low;
                ctl.Maximum = limits.High;
                int range = limits.High - limits.Low;
                ctl.ScaleDivisions = (range > 5) ? 5 : range;
                ctl.ShowBorder = true;
                ctl.BorderColor = Color.DarkGray;
                ctl.LabelTextRotation = -90;
            }
        }
        public BindingSource Binding
        {
            set
            {
                _binding = value;
                {
                    BindToPosition("Brightness");
                    BindToPosition("Aperture");
                    BindToPosition("RGain");
                    BindToPosition("BGain");
                    BindToPosition( "Hue");
                }
            }
        }

        private ColorSlider.ColorSlider AddSlider(String name)
        {
            if (_sliders.ContainsKey(name))
                return _sliders[name];

            int lblTop = 0;
            int sldTop = 17;
            int lblHeight = 23;

            int visibleWidth = 47;
            int width = 63;
            int height = this.Height - sldTop;

            int x = _sliders.Count * visibleWidth;

            Label lbl = new Label();
            lbl.Left = x;
            lbl.Top = lblTop;
            lbl.Width = visibleWidth;
            lbl.Height = lblHeight;
            lbl.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            lbl.Text = name;
            lbl.TextAlign = ContentAlignment.TopCenter;
            lbl.BorderStyle = BorderStyle.FixedSingle;


            ColorSlider.ColorSlider sld = new ColorSlider.ColorSlider();
            sld.Left = x;
            sld.Top = sldTop;
            sld.Width = width;
            sld.Height = height;
            sld.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom;
            sld.ShowDivisionsText = true;
            sld.Orientation = System.Windows.Forms.Orientation.Vertical;

            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucCamSettings));
            sld.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            sld.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(77)))), ((int)(((byte)(95)))));
            sld.BarPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(94)))), ((int)(((byte)(110)))));
            sld.BarPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            sld.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            sld.ElapsedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            sld.ElapsedPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(130)))), ((int)(((byte)(208)))));
            sld.ElapsedPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(140)))), ((int)(((byte)(180)))));
            sld.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            sld.ForeColor = System.Drawing.Color.White;
            sld.InputColor = System.Drawing.Color.SpringGreen;
            sld.ScaleSubDivisions = new decimal(new int[] {
            5,
            0,
            0,
            0});
            sld.ShowSmallScale = false;
            sld.TabIndex = 10;
            sld.ThumbImage = AVDeviceControl.Properties.Resources.slider_knob_small;
            sld.ThumbInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            sld.ThumbPenColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            sld.ThumbRoundRectSize = new System.Drawing.Size(16, 16);
            sld.ThumbSize = new System.Drawing.Size(16, 16);
            sld.TickAdd = 0F;
            sld.TickColor = System.Drawing.Color.White;
            sld.TickDivide = 0F;



            grpCamera.Left = x + visibleWidth;
            Controls.Add(lbl);
            Controls.Add(sld);

            lbl.SendToBack();
            sld.BringToFront();
            grpCamera.BringToFront();

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
