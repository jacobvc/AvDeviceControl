using AVDeviceControl.Properties;

namespace AVDeviceControl
{
    partial class ucSettingSlider
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label = new System.Windows.Forms.Label();
            this.slider = new ColorSlider.ColorSlider();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label.Location = new System.Drawing.Point(0, 0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(49, 23);
            this.label.TabIndex = 4;
            this.label.Text = "label1";
            this.label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // slider
            // 
            this.slider.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.slider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(77)))), ((int)(((byte)(95)))));
            this.slider.BarPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(94)))), ((int)(((byte)(110)))));
            this.slider.BarPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.slider.BorderColor = System.Drawing.Color.DarkGray;
            this.slider.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.slider.ElapsedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.slider.ElapsedPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(130)))), ((int)(((byte)(208)))));
            this.slider.ElapsedPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(140)))), ((int)(((byte)(180)))));
            this.slider.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.slider.ForeColor = System.Drawing.Color.White;
            this.slider.InputColor = System.Drawing.Color.SpringGreen;
            this.slider.InputValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.slider.LargeChange = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.slider.Location = new System.Drawing.Point(0, 17);
            this.slider.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.slider.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.slider.Name = "slider";
            this.slider.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.slider.ScaleDivisions = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.slider.ScaleSubDivisions = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.slider.ShowDivisionsText = true;
            this.slider.ShowSmallScale = true;
            this.slider.Size = new System.Drawing.Size(66, 157);
            this.slider.SmallChange = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.slider.TabIndex = 3;
            this.slider.Text = "colorSlider4";
            this.slider.ThumbImage = global::AVDeviceControl.Properties.Resources.slider_knob_small;
            this.slider.ThumbInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.slider.ThumbPenColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.slider.ThumbRoundRectSize = new System.Drawing.Size(16, 16);
            this.slider.ThumbSize = new System.Drawing.Size(16, 16);
            this.slider.TickAdd = 0F;
            this.slider.TickColor = System.Drawing.Color.White;
            this.slider.TickDivide = 1F;
            this.slider.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // ucSettingSlider
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.slider);
            this.Controls.Add(this.label);
            this.Name = "ucSettingSlider";
            this.Size = new System.Drawing.Size(49, 174);
            this.ResumeLayout(false);

        }

        #endregion

        private ColorSlider.ColorSlider slider;
        private System.Windows.Forms.Label label;
    }
}
