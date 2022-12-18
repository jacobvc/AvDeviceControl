
namespace AVDeviceControl
{
    partial class ucCamSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucCamSettings));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.grpCamera = new System.Windows.Forms.GroupBox();
            this.cameraInfo = new System.Windows.Forms.TextBox();
            this.sldBGain = new ColorSlider.ColorSlider();
            this.sldRGain = new ColorSlider.ColorSlider();
            this.sldAperture = new ColorSlider.ColorSlider();
            this.sldBright = new ColorSlider.ColorSlider();
            this.grpCamera.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "Bright";
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(49, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "Aperture";
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(93, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 23);
            this.label3.TabIndex = 7;
            this.label3.Text = "RGain";
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(137, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 23);
            this.label4.TabIndex = 8;
            this.label4.Text = "BGain";
            // 
            // grpCamera
            // 
            this.grpCamera.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpCamera.Controls.Add(this.cameraInfo);
            this.grpCamera.Location = new System.Drawing.Point(188, 0);
            this.grpCamera.Name = "grpCamera";
            this.grpCamera.Size = new System.Drawing.Size(110, 150);
            this.grpCamera.TabIndex = 9;
            this.grpCamera.TabStop = false;
            this.grpCamera.Text = "Device";
            // 
            // cameraInfo
            // 
            this.cameraInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cameraInfo.Location = new System.Drawing.Point(3, 16);
            this.cameraInfo.Multiline = true;
            this.cameraInfo.Name = "cameraInfo";
            this.cameraInfo.ReadOnly = true;
            this.cameraInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.cameraInfo.Size = new System.Drawing.Size(104, 131);
            this.cameraInfo.TabIndex = 0;
            this.cameraInfo.VisibleChanged += new System.EventHandler(this.cameraInfo_VisibleChanged);
            // 
            // sldBGain
            // 
            this.sldBGain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.sldBGain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(77)))), ((int)(((byte)(95)))));
            this.sldBGain.BarPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(94)))), ((int)(((byte)(110)))));
            this.sldBGain.BarPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.sldBGain.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.sldBGain.ElapsedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sldBGain.ElapsedPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(130)))), ((int)(((byte)(208)))));
            this.sldBGain.ElapsedPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(140)))), ((int)(((byte)(180)))));
            this.sldBGain.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.sldBGain.ForeColor = System.Drawing.Color.White;
            this.sldBGain.LargeChange = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.sldBGain.Location = new System.Drawing.Point(140, 17);
            this.sldBGain.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.sldBGain.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.sldBGain.Name = "sldBGain";
            this.sldBGain.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.sldBGain.ScaleDivisions = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.sldBGain.ScaleSubDivisions = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.sldBGain.ShowDivisionsText = false;
            this.sldBGain.ShowSmallScale = false;
            this.sldBGain.Size = new System.Drawing.Size(63, 133);
            this.sldBGain.SmallChange = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.sldBGain.TabIndex = 3;
            this.sldBGain.Text = "colorSlider4";
            this.sldBGain.ThumbImage = ((System.Drawing.Image)(resources.GetObject("sldBGain.ThumbImage")));
            this.sldBGain.ThumbInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sldBGain.ThumbPenColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sldBGain.ThumbRoundRectSize = new System.Drawing.Size(16, 16);
            this.sldBGain.ThumbSize = new System.Drawing.Size(16, 16);
            this.sldBGain.TickAdd = 0F;
            this.sldBGain.TickColor = System.Drawing.Color.White;
            this.sldBGain.TickDivide = 0F;
            this.sldBGain.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // sldRGain
            // 
            this.sldRGain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.sldRGain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(77)))), ((int)(((byte)(95)))));
            this.sldRGain.BarPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(94)))), ((int)(((byte)(110)))));
            this.sldRGain.BarPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.sldRGain.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.sldRGain.ElapsedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sldRGain.ElapsedPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(130)))), ((int)(((byte)(208)))));
            this.sldRGain.ElapsedPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(140)))), ((int)(((byte)(180)))));
            this.sldRGain.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.sldRGain.ForeColor = System.Drawing.Color.White;
            this.sldRGain.LargeChange = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.sldRGain.Location = new System.Drawing.Point(96, 17);
            this.sldRGain.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.sldRGain.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.sldRGain.Name = "sldRGain";
            this.sldRGain.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.sldRGain.ScaleDivisions = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.sldRGain.ScaleSubDivisions = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.sldRGain.ShowDivisionsText = false;
            this.sldRGain.ShowSmallScale = false;
            this.sldRGain.Size = new System.Drawing.Size(63, 133);
            this.sldRGain.SmallChange = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.sldRGain.TabIndex = 2;
            this.sldRGain.Text = "colorSlider3";
            this.sldRGain.ThumbImage = ((System.Drawing.Image)(resources.GetObject("sldRGain.ThumbImage")));
            this.sldRGain.ThumbInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sldRGain.ThumbPenColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sldRGain.ThumbRoundRectSize = new System.Drawing.Size(16, 16);
            this.sldRGain.ThumbSize = new System.Drawing.Size(16, 16);
            this.sldRGain.TickAdd = 0F;
            this.sldRGain.TickColor = System.Drawing.Color.White;
            this.sldRGain.TickDivide = 0F;
            this.sldRGain.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // sldAperture
            // 
            this.sldAperture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.sldAperture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(77)))), ((int)(((byte)(95)))));
            this.sldAperture.BarPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(94)))), ((int)(((byte)(110)))));
            this.sldAperture.BarPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.sldAperture.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.sldAperture.ElapsedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sldAperture.ElapsedPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(130)))), ((int)(((byte)(208)))));
            this.sldAperture.ElapsedPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(140)))), ((int)(((byte)(180)))));
            this.sldAperture.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.sldAperture.ForeColor = System.Drawing.Color.White;
            this.sldAperture.LargeChange = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.sldAperture.Location = new System.Drawing.Point(52, 17);
            this.sldAperture.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.sldAperture.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.sldAperture.Name = "sldAperture";
            this.sldAperture.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.sldAperture.ScaleDivisions = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.sldAperture.ScaleSubDivisions = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.sldAperture.ShowDivisionsText = false;
            this.sldAperture.ShowSmallScale = false;
            this.sldAperture.Size = new System.Drawing.Size(63, 133);
            this.sldAperture.SmallChange = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.sldAperture.TabIndex = 1;
            this.sldAperture.Text = "colorSlider2";
            this.sldAperture.ThumbImage = ((System.Drawing.Image)(resources.GetObject("sldAperture.ThumbImage")));
            this.sldAperture.ThumbInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sldAperture.ThumbPenColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sldAperture.ThumbRoundRectSize = new System.Drawing.Size(16, 16);
            this.sldAperture.ThumbSize = new System.Drawing.Size(16, 16);
            this.sldAperture.TickAdd = 0F;
            this.sldAperture.TickColor = System.Drawing.Color.White;
            this.sldAperture.TickDivide = 0F;
            this.sldAperture.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // sldBright
            // 
            this.sldBright.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.sldBright.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(77)))), ((int)(((byte)(95)))));
            this.sldBright.BarPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(94)))), ((int)(((byte)(110)))));
            this.sldBright.BarPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.sldBright.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.sldBright.ElapsedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sldBright.ElapsedPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(130)))), ((int)(((byte)(208)))));
            this.sldBright.ElapsedPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(140)))), ((int)(((byte)(180)))));
            this.sldBright.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.sldBright.ForeColor = System.Drawing.Color.White;
            this.sldBright.LargeChange = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.sldBright.Location = new System.Drawing.Point(5, 17);
            this.sldBright.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.sldBright.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.sldBright.Name = "sldBright";
            this.sldBright.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.sldBright.ScaleDivisions = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.sldBright.ScaleSubDivisions = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.sldBright.ShowDivisionsText = false;
            this.sldBright.ShowSmallScale = false;
            this.sldBright.Size = new System.Drawing.Size(63, 133);
            this.sldBright.SmallChange = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.sldBright.TabIndex = 0;
            this.sldBright.Text = "colorSlider1";
            this.sldBright.ThumbImage = ((System.Drawing.Image)(resources.GetObject("sldBright.ThumbImage")));
            this.sldBright.ThumbInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sldBright.ThumbPenColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sldBright.ThumbRoundRectSize = new System.Drawing.Size(16, 16);
            this.sldBright.ThumbSize = new System.Drawing.Size(16, 16);
            this.sldBright.TickAdd = 0F;
            this.sldBright.TickColor = System.Drawing.Color.White;
            this.sldBright.TickDivide = 0F;
            this.sldBright.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // ucCamSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpCamera);
            this.Controls.Add(this.sldBGain);
            this.Controls.Add(this.sldRGain);
            this.Controls.Add(this.sldAperture);
            this.Controls.Add(this.sldBright);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ucCamSettings";
            this.Size = new System.Drawing.Size(301, 150);
            this.grpCamera.ResumeLayout(false);
            this.grpCamera.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ColorSlider.ColorSlider sldBright;
        private ColorSlider.ColorSlider sldAperture;
        private ColorSlider.ColorSlider sldRGain;
        private ColorSlider.ColorSlider sldBGain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox grpCamera;
        private System.Windows.Forms.TextBox cameraInfo;
    }
}
