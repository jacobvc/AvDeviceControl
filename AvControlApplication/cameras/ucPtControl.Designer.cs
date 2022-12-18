
namespace AVDeviceControl
{
    partial class ucPtControl
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
            this.udPan = new System.Windows.Forms.NumericUpDown();
            this.udTilt = new System.Windows.Forms.NumericUpDown();
            this.pnlPt = new System.Windows.Forms.Panel();
            this.hostPt = new System.Windows.Forms.Integration.ElementHost();
            this.ucWpfPtControl = new AVDeviceControl.UcWpfPtControl();
            this.slidPan = new ColorSlider.ColorSlider();
            this.slidTilt = new ColorSlider.ColorSlider();
            ((System.ComponentModel.ISupportInitialize)(this.udPan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udTilt)).BeginInit();
            this.pnlPt.SuspendLayout();
            this.SuspendLayout();
            // 
            // udPan
            // 
            this.udPan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.udPan.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.udPan.Location = new System.Drawing.Point(76, 98);
            this.udPan.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.udPan.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.udPan.Name = "udPan";
            this.udPan.Size = new System.Drawing.Size(41, 20);
            this.udPan.TabIndex = 0;
            this.udPan.ValueChanged += new System.EventHandler(this.udPosition_ValueChanged);
            // 
            // udTilt
            // 
            this.udTilt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.udTilt.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.udTilt.Location = new System.Drawing.Point(76, 72);
            this.udTilt.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.udTilt.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            -2147483648});
            this.udTilt.Name = "udTilt";
            this.udTilt.Size = new System.Drawing.Size(41, 20);
            this.udTilt.TabIndex = 1;
            this.udTilt.ValueChanged += new System.EventHandler(this.udPosition_ValueChanged);
            // 
            // pnlPt
            // 
            this.pnlPt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPt.BackColor = System.Drawing.Color.Transparent;
            this.pnlPt.Controls.Add(this.hostPt);
            this.pnlPt.Controls.Add(this.udTilt);
            this.pnlPt.Controls.Add(this.slidPan);
            this.pnlPt.Controls.Add(this.udPan);
            this.pnlPt.Location = new System.Drawing.Point(20, 1);
            this.pnlPt.Name = "pnlPt";
            this.pnlPt.Size = new System.Drawing.Size(120, 120);
            this.pnlPt.TabIndex = 13;
            this.pnlPt.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanTilt_MouseDown);
            this.pnlPt.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PanTilt_MouseMove);
            this.pnlPt.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PanTilt_MouseUp);
            // 
            // hostPt
            // 
            this.hostPt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hostPt.Location = new System.Drawing.Point(3, 19);
            this.hostPt.Name = "hostPt";
            this.hostPt.Size = new System.Drawing.Size(119, 102);
            this.hostPt.TabIndex = 12;
            this.hostPt.Text = "elementHost1";
            this.hostPt.Child = this.ucWpfPtControl;
            // 
            // slidPan
            // 
            this.slidPan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.slidPan.BackColor = System.Drawing.Color.Transparent;
            this.slidPan.BarPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(94)))), ((int)(((byte)(110)))));
            this.slidPan.BarPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.slidPan.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.slidPan.ColorSchema = ColorSlider.ColorSlider.ColorSchemas.PlainColors;
            this.slidPan.ElapsedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.slidPan.ElapsedPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(130)))), ((int)(((byte)(208)))));
            this.slidPan.ElapsedPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(140)))), ((int)(((byte)(180)))));
            this.slidPan.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.slidPan.ForeColor = System.Drawing.Color.White;
            this.slidPan.InputColor = System.Drawing.Color.SpringGreen;
            this.slidPan.InputValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.slidPan.LargeChange = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.slidPan.Location = new System.Drawing.Point(0, -9);
            this.slidPan.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.slidPan.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.slidPan.Name = "slidPan";
            this.slidPan.ScaleDivisions = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.slidPan.ScaleSubDivisions = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.slidPan.ShowDivisionsText = true;
            this.slidPan.ShowSmallScale = false;
            this.slidPan.Size = new System.Drawing.Size(120, 40);
            this.slidPan.SmallChange = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.slidPan.TabIndex = 11;
            this.slidPan.Text = "colorSlider1";
            this.slidPan.ThumbInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.slidPan.ThumbPenColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.slidPan.ThumbRoundRectSize = new System.Drawing.Size(16, 16);
            this.slidPan.ThumbSize = new System.Drawing.Size(16, 16);
            this.slidPan.TickAdd = 0F;
            this.slidPan.TickColor = System.Drawing.Color.White;
            this.slidPan.TickDivide = 0F;
            this.slidPan.TickStyle = System.Windows.Forms.TickStyle.None;
            this.slidPan.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.slidPan.ValueChanged += new System.EventHandler(this.slidPan_ValueChanged);
            this.slidPan.MouseUp += new System.Windows.Forms.MouseEventHandler(this.slidPan_MouseUp);
            // 
            // slidTilt
            // 
            this.slidTilt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.slidTilt.BackColor = System.Drawing.SystemColors.Control;
            this.slidTilt.BarPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(94)))), ((int)(((byte)(110)))));
            this.slidTilt.BarPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.slidTilt.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.slidTilt.ElapsedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.slidTilt.ElapsedPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(130)))), ((int)(((byte)(208)))));
            this.slidTilt.ElapsedPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(140)))), ((int)(((byte)(180)))));
            this.slidTilt.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.slidTilt.ForeColor = System.Drawing.Color.White;
            this.slidTilt.InputColor = System.Drawing.Color.SpringGreen;
            this.slidTilt.InputValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.slidTilt.LargeChange = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.slidTilt.Location = new System.Drawing.Point(5, 20);
            this.slidTilt.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.slidTilt.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.slidTilt.Name = "slidTilt";
            this.slidTilt.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.slidTilt.ScaleDivisions = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.slidTilt.ScaleSubDivisions = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.slidTilt.ShowDivisionsText = false;
            this.slidTilt.ShowSmallScale = false;
            this.slidTilt.Size = new System.Drawing.Size(20, 95);
            this.slidTilt.SmallChange = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.slidTilt.TabIndex = 12;
            this.slidTilt.Text = "colorSlider2";
            this.slidTilt.ThumbInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.slidTilt.ThumbPenColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.slidTilt.ThumbRoundRectSize = new System.Drawing.Size(16, 16);
            this.slidTilt.ThumbSize = new System.Drawing.Size(16, 16);
            this.slidTilt.TickAdd = 0F;
            this.slidTilt.TickColor = System.Drawing.Color.White;
            this.slidTilt.TickDivide = 0F;
            this.slidTilt.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.slidTilt.ValueChanged += new System.EventHandler(this.slidTilt_ValueChanged);
            this.slidTilt.MouseUp += new System.Windows.Forms.MouseEventHandler(this.slidTilt_MouseUp);
            // 
            // ucPtControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.slidTilt);
            this.Controls.Add(this.pnlPt);
            this.Name = "ucPtControl";
            this.Size = new System.Drawing.Size(142, 122);
            ((System.ComponentModel.ISupportInitialize)(this.udPan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udTilt)).EndInit();
            this.pnlPt.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown udPan;
        private System.Windows.Forms.NumericUpDown udTilt;
        private ColorSlider.ColorSlider slidPan;
        private ColorSlider.ColorSlider slidTilt;
        private System.Windows.Forms.Panel pnlPt;
        private System.Windows.Forms.Integration.ElementHost hostPt;
        private UcWpfPtControl ucWpfPtControl;
    }
}
