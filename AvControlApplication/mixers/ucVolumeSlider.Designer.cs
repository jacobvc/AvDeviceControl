
namespace AVDeviceControl
{
    partial class ucVolumeSlider
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucVolumeSlider));
            this.chkMute = new System.Windows.Forms.CheckBox();
            this.sld = new ColorSlider.ColorSlider();
            this.SuspendLayout();
            // 
            // chkMute
            // 
            this.chkMute.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkMute.Checked = true;
            this.chkMute.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMute.Location = new System.Drawing.Point(-1, 0);
            this.chkMute.Name = "chkMute";
            this.chkMute.Size = new System.Drawing.Size(52, 20);
            this.chkMute.TabIndex = 7;
            this.chkMute.Text = "checkBox1";
            this.chkMute.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkMute.UseVisualStyleBackColor = true;
            // 
            // sld
            // 
            this.sld.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.sld.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(77)))), ((int)(((byte)(95)))));
            this.sld.BarPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(94)))), ((int)(((byte)(110)))));
            this.sld.BarPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.sld.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.sld.ElapsedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sld.ElapsedPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(130)))), ((int)(((byte)(208)))));
            this.sld.ElapsedPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(140)))), ((int)(((byte)(180)))));
            this.sld.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.sld.ForeColor = System.Drawing.Color.White;
            this.sld.InputColor = System.Drawing.Color.SpringGreen;
            this.sld.InputValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.sld.LargeChange = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.sld.Location = new System.Drawing.Point(0, 20);
            this.sld.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.sld.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.sld.Name = "sld";
            this.sld.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.sld.ScaleDivisions = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.sld.ScaleSubDivisions = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.sld.ShowDivisionsText = false;
            this.sld.ShowInput = true;
            this.sld.ShowSmallScale = false;
            this.sld.Size = new System.Drawing.Size(48, 129);
            this.sld.SmallChange = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.sld.TabIndex = 6;
            this.sld.Text = "colorSlider1";
            this.sld.ThumbImage = ((System.Drawing.Image)(resources.GetObject("sld.ThumbImage")));
            this.sld.ThumbInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sld.ThumbPenColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sld.ThumbRoundRectSize = new System.Drawing.Size(16, 16);
            this.sld.ThumbSize = new System.Drawing.Size(16, 16);
            this.sld.TickAdd = 0F;
            this.sld.TickColor = System.Drawing.Color.White;
            this.sld.TickDivide = 0F;
            this.sld.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // ucVolumeSlider
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.chkMute);
            this.Controls.Add(this.sld);
            this.Name = "ucVolumeSlider";
            this.Size = new System.Drawing.Size(52, 150);
            this.ResumeLayout(false);

        }

        #endregion

        private ColorSlider.ColorSlider sld;
        private System.Windows.Forms.CheckBox chkMute;
    }
}
