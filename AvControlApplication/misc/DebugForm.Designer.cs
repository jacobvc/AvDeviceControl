namespace AVDeviceControl
{
    partial class DebugForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DebugForm));
            this.txtDebug = new System.Windows.Forms.RichTextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numMaxLines = new System.Windows.Forms.NumericUpDown();
            this.pnlKey = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnKey = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxLines)).BeginInit();
            this.pnlKey.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDebug
            // 
            this.txtDebug.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDebug.HideSelection = false;
            this.txtDebug.Location = new System.Drawing.Point(12, 31);
            this.txtDebug.Name = "txtDebug";
            this.txtDebug.Size = new System.Drawing.Size(597, 271);
            this.txtDebug.TabIndex = 0;
            this.txtDebug.Text = "";
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(508, 3);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(290, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Max Lines";
            // 
            // numMaxLines
            // 
            this.numMaxLines.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numMaxLines.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::AVDeviceControl.Properties.Settings.Default, "debugMaxLines", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numMaxLines.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numMaxLines.Location = new System.Drawing.Point(351, 5);
            this.numMaxLines.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numMaxLines.Name = "numMaxLines";
            this.numMaxLines.Size = new System.Drawing.Size(66, 20);
            this.numMaxLines.TabIndex = 3;
            this.numMaxLines.Value = global::AVDeviceControl.Properties.Settings.Default.debugMaxLines;
            // 
            // pnlKey
            // 
            this.pnlKey.BackColor = System.Drawing.Color.White;
            this.pnlKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlKey.Controls.Add(this.label8);
            this.pnlKey.Controls.Add(this.label7);
            this.pnlKey.Controls.Add(this.label6);
            this.pnlKey.Controls.Add(this.label5);
            this.pnlKey.Controls.Add(this.label4);
            this.pnlKey.Controls.Add(this.label3);
            this.pnlKey.Controls.Add(this.label2);
            this.pnlKey.Location = new System.Drawing.Point(47, 32);
            this.pnlKey.Name = "pnlKey";
            this.pnlKey.Size = new System.Drawing.Size(91, 135);
            this.pnlKey.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(3, 2);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 16);
            this.label8.TabIndex = 6;
            this.label8.Text = "Color Key";
            // 
            // label7
            // 
            this.label7.ForeColor = System.Drawing.Color.Purple;
            this.label7.Location = new System.Drawing.Point(6, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 16);
            this.label7.TabIndex = 5;
            this.label7.Text = "Always";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(6, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 16);
            this.label6.TabIndex = 4;
            this.label6.Text = "Error";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.Color.Orange;
            this.label5.Location = new System.Drawing.Point(6, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "Warning";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Info";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(6, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Debug";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.Green;
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Trace";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnKey
            // 
            this.btnKey.Location = new System.Drawing.Point(57, 8);
            this.btnKey.Name = "btnKey";
            this.btnKey.Size = new System.Drawing.Size(75, 23);
            this.btnKey.TabIndex = 5;
            this.btnKey.Text = "Key";
            this.btnKey.UseVisualStyleBackColor = true;
            this.btnKey.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnKey_MouseDown);
            this.btnKey.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnKey_MouseUp);
            // 
            // DebugForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 299);
            this.Controls.Add(this.btnKey);
            this.Controls.Add(this.pnlKey);
            this.Controls.Add(this.numMaxLines);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txtDebug);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DebugForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Debug Log";
            ((System.ComponentModel.ISupportInitialize)(this.numMaxLines)).EndInit();
            this.pnlKey.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtDebug;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numMaxLines;
        private System.Windows.Forms.Panel pnlKey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnKey;
    }
}