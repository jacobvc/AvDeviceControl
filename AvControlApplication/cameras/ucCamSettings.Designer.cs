
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
            this.grpCamera = new System.Windows.Forms.GroupBox();
            this.cameraInfo = new System.Windows.Forms.TextBox();
            this.grpCamera.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpCamera
            // 
            this.grpCamera.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grpCamera.Controls.Add(this.cameraInfo);
            this.grpCamera.Location = new System.Drawing.Point(3, 3);
            this.grpCamera.Name = "grpCamera";
            this.grpCamera.Size = new System.Drawing.Size(184, 150);
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
            this.cameraInfo.Size = new System.Drawing.Size(178, 131);
            this.cameraInfo.TabIndex = 0;
            this.cameraInfo.VisibleChanged += new System.EventHandler(this.CameraInfo_VisibleChanged);
            // 
            // ucCamSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.grpCamera);
            this.Name = "ucCamSettings";
            this.Size = new System.Drawing.Size(189, 150);
            this.grpCamera.ResumeLayout(false);
            this.grpCamera.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox grpCamera;
        private System.Windows.Forms.TextBox cameraInfo;
    }
}
