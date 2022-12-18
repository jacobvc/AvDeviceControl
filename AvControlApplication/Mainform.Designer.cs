
namespace AVDeviceControl
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.spltMain = new System.Windows.Forms.SplitContainer();
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSaveConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLoadConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSaveJSONCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.camerasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddCamera = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddMixer = new System.Windows.Forms.ToolStripMenuItem();
            this.miscToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCmbLog = new System.Windows.Forms.ToolStripComboBox();
            this.mnuWebsocket = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuWebsocketPort = new System.Windows.Forms.ToolStripTextBox();
            this.lblWebSocket = new System.Windows.Forms.Label();
            this.pnlPending = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblPending = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCommit = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.staLblConfigFile = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.spltMain)).BeginInit();
            this.spltMain.SuspendLayout();
            this.mnuMain.SuspendLayout();
            this.pnlPending.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // spltMain
            // 
            this.spltMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spltMain.Location = new System.Drawing.Point(0, 27);
            this.spltMain.Name = "spltMain";
            this.spltMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spltMain.Panel1
            // 
            this.spltMain.Panel1.AutoScroll = true;
            this.spltMain.Panel1.Resize += new System.EventHandler(this.spltMain_Panel1_Resize);
            this.spltMain.Panel2Collapsed = true;
            this.spltMain.Size = new System.Drawing.Size(554, 189);
            this.spltMain.SplitterDistance = 164;
            this.spltMain.SplitterWidth = 6;
            this.spltMain.TabIndex = 9;
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.camerasToolStripMenuItem,
            this.miscToolStripMenuItem});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(554, 24);
            this.mnuMain.TabIndex = 0;
            this.mnuMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSaveConfig,
            this.mnuLoadConfig,
            this.mnuSaveJSONCopy});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // mnuSaveConfig
            // 
            this.mnuSaveConfig.Name = "mnuSaveConfig";
            this.mnuSaveConfig.Size = new System.Drawing.Size(180, 22);
            this.mnuSaveConfig.Text = "Save Config";
            this.mnuSaveConfig.Click += new System.EventHandler(this.mnuSaveConfig_Click);
            // 
            // mnuLoadConfig
            // 
            this.mnuLoadConfig.Name = "mnuLoadConfig";
            this.mnuLoadConfig.Size = new System.Drawing.Size(180, 22);
            this.mnuLoadConfig.Text = "Load Config";
            this.mnuLoadConfig.Click += new System.EventHandler(this.mnuLoadConfig_Click);
            // 
            // mnuSaveJSONCopy
            // 
            this.mnuSaveJSONCopy.Name = "mnuSaveJSONCopy";
            this.mnuSaveJSONCopy.Size = new System.Drawing.Size(180, 22);
            this.mnuSaveJSONCopy.Text = "Save JSON Copy";
            this.mnuSaveJSONCopy.Click += new System.EventHandler(this.mnuSaveJSONCopy_Click);
            // 
            // camerasToolStripMenuItem
            // 
            this.camerasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddCamera,
            this.mnuAddMixer});
            this.camerasToolStripMenuItem.Name = "camerasToolStripMenuItem";
            this.camerasToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.camerasToolStripMenuItem.Text = "Devices";
            // 
            // mnuAddCamera
            // 
            this.mnuAddCamera.Name = "mnuAddCamera";
            this.mnuAddCamera.Size = new System.Drawing.Size(180, 22);
            this.mnuAddCamera.Text = "Add Camera";
            this.mnuAddCamera.Click += new System.EventHandler(this.mnuAddCamera_Click);
            // 
            // mnuAddMixer
            // 
            this.mnuAddMixer.Name = "mnuAddMixer";
            this.mnuAddMixer.Size = new System.Drawing.Size(180, 22);
            this.mnuAddMixer.Text = "Add Mixer";
            this.mnuAddMixer.Click += new System.EventHandler(this.mnuAddMixer_Click);
            // 
            // miscToolStripMenuItem
            // 
            this.miscToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCmbLog,
            this.mnuWebsocket});
            this.miscToolStripMenuItem.Name = "miscToolStripMenuItem";
            this.miscToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.miscToolStripMenuItem.Text = "Misc";
            // 
            // mnuCmbLog
            // 
            this.mnuCmbLog.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mnuCmbLog.Name = "mnuCmbLog";
            this.mnuCmbLog.Size = new System.Drawing.Size(121, 23);
            this.mnuCmbLog.SelectedIndexChanged += new System.EventHandler(this.mnuCmbLog_SelectedIndexChanged);
            // 
            // mnuWebsocket
            // 
            this.mnuWebsocket.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuWebsocketPort});
            this.mnuWebsocket.Name = "mnuWebsocket";
            this.mnuWebsocket.Size = new System.Drawing.Size(181, 22);
            this.mnuWebsocket.Text = "Websocket Port";
            // 
            // mnuWebsocketPort
            // 
            this.mnuWebsocketPort.Name = "mnuWebsocketPort";
            this.mnuWebsocketPort.Size = new System.Drawing.Size(100, 23);
            this.mnuWebsocketPort.TextChanged += new System.EventHandler(this.mnuWebsocketPort_TextChanged);
            // 
            // lblWebSocket
            // 
            this.lblWebSocket.AutoSize = true;
            this.lblWebSocket.Location = new System.Drawing.Point(167, 6);
            this.lblWebSocket.Name = "lblWebSocket";
            this.lblWebSocket.Size = new System.Drawing.Size(115, 13);
            this.lblWebSocket.TabIndex = 10;
            this.lblWebSocket.Text = "Websocket not started";
            // 
            // pnlPending
            // 
            this.pnlPending.BackColor = System.Drawing.Color.Transparent;
            this.pnlPending.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPending.Controls.Add(this.btnCancel);
            this.pnlPending.Controls.Add(this.lblPending);
            this.pnlPending.Controls.Add(this.label1);
            this.pnlPending.Controls.Add(this.btnCommit);
            this.pnlPending.Location = new System.Drawing.Point(227, 3);
            this.pnlPending.Name = "pnlPending";
            this.pnlPending.Size = new System.Drawing.Size(247, 21);
            this.pnlPending.TabIndex = 11;
            this.pnlPending.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(191, -1);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(51, 20);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblPending
            // 
            this.lblPending.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPending.Location = new System.Drawing.Point(70, 3);
            this.lblPending.Name = "lblPending";
            this.lblPending.Size = new System.Drawing.Size(65, 13);
            this.lblPending.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pending Port";
            // 
            // btnCommit
            // 
            this.btnCommit.Location = new System.Drawing.Point(136, -1);
            this.btnCommit.Margin = new System.Windows.Forms.Padding(0);
            this.btnCommit.Name = "btnCommit";
            this.btnCommit.Size = new System.Drawing.Size(51, 20);
            this.btnCommit.TabIndex = 0;
            this.btnCommit.Text = "Commit";
            this.btnCommit.UseVisualStyleBackColor = true;
            this.btnCommit.Click += new System.EventHandler(this.btnCommit_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.staLblConfigFile});
            this.statusStrip1.Location = new System.Drawing.Point(0, 219);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(554, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(65, 17);
            this.toolStripStatusLabel1.Text = "Config file:";
            // 
            // staLblConfigFile
            // 
            this.staLblConfigFile.Name = "staLblConfigFile";
            this.staLblConfigFile.Size = new System.Drawing.Size(118, 17);
            this.staLblConfigFile.Text = "toolStripStatusLabel2";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 241);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pnlPending);
            this.Controls.Add(this.lblWebSocket);
            this.Controls.Add(this.mnuMain);
            this.Controls.Add(this.spltMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuMain;
            this.MinimumSize = new System.Drawing.Size(570, 280);
            this.Name = "MainForm";
            this.Text = "Audio Visual Device Controller";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.spltMain)).EndInit();
            this.spltMain.ResumeLayout(false);
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.pnlPending.ResumeLayout(false);
            this.pnlPending.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.SplitContainer spltMain;
        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuSaveConfig;
        private System.Windows.Forms.ToolStripMenuItem mnuLoadConfig;
        private System.Windows.Forms.ToolStripMenuItem camerasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuAddCamera;
        private System.Windows.Forms.ToolStripMenuItem mnuSaveJSONCopy;
        private System.Windows.Forms.ToolStripMenuItem miscToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox mnuCmbLog;
        private System.Windows.Forms.ToolStripMenuItem mnuAddMixer;
        private System.Windows.Forms.ToolStripMenuItem mnuWebsocket;
        private System.Windows.Forms.ToolStripTextBox mnuWebsocketPort;
        private System.Windows.Forms.Label lblWebSocket;
        private System.Windows.Forms.Panel pnlPending;
        private System.Windows.Forms.Label lblPending;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCommit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel staLblConfigFile;
    }
}

