﻿
namespace AVDeviceControl
{
    partial class ucViscaCamera
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;


        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabUsbCam = new System.Windows.Forms.TabPage();
            this.chkComReverse = new System.Windows.Forms.CheckBox();
            this.cameraConfigBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnRefreshPorts = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbBaud = new System.Windows.Forms.ComboBox();
            this.cmbComPort = new System.Windows.Forms.ComboBox();
            this.btnConnectSerial = new System.Windows.Forms.Button();
            this.tabIpCam = new System.Windows.Forms.TabPage();
            this.chkIpReverse = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnDelete2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnConnectIp = new System.Windows.Forms.Button();
            this.rtspUrl = new System.Windows.Forms.TextBox();
            this.ipAddress = new System.Windows.Forms.TextBox();
            this.tabCamControl = new System.Windows.Forms.TabPage();
            this.lstLivePresets = new System.Windows.Forms.ListBox();
            this.ptControl = new AVDeviceControl.ucPtControl();
            this.tbZoom = new ColorSlider.ColorSlider();
            this.tabPresets = new System.Windows.Forms.TabPage();
            this.btnMenuOk = new System.Windows.Forms.Button();
            this.btnMenuOff = new System.Windows.Forms.Button();
            this.btnMenuOn = new System.Windows.Forms.Button();
            this.btnDelPreset = new System.Windows.Forms.Button();
            this.grpPresets = new System.Windows.Forms.GroupBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.cmbPresetSpeed = new System.Windows.Forms.ComboBox();
            this.presetsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPresetZoom = new System.Windows.Forms.TextBox();
            this.txtPresetTilt = new System.Windows.Forms.TextBox();
            this.txtPresetPan = new System.Windows.Forms.TextBox();
            this.txtPresetName = new System.Windows.Forms.TextBox();
            this.btnNewPreset = new System.Windows.Forms.Button();
            this.lstPresets = new System.Windows.Forms.ListBox();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.ucCamSettings1 = new AVDeviceControl.ucCamSettings();
            this.chkIp = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnCtlDisconnect = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.cameraBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1.SuspendLayout();
            this.tabUsbCam.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cameraConfigBindingSource)).BeginInit();
            this.tabIpCam.SuspendLayout();
            this.tabCamControl.SuspendLayout();
            this.tabPresets.SuspendLayout();
            this.grpPresets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.presetsBindingSource)).BeginInit();
            this.tabSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cameraBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControl1.Controls.Add(this.tabUsbCam);
            this.tabControl1.Controls.Add(this.tabIpCam);
            this.tabControl1.Controls.Add(this.tabCamControl);
            this.tabControl1.Controls.Add(this.tabPresets);
            this.tabControl1.Controls.Add(this.tabSettings);
            this.tabControl1.Location = new System.Drawing.Point(0, 22);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(281, 179);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabUsbCam
            // 
            this.tabUsbCam.Controls.Add(this.chkComReverse);
            this.tabUsbCam.Controls.Add(this.btnRefreshPorts);
            this.tabUsbCam.Controls.Add(this.btnDelete);
            this.tabUsbCam.Controls.Add(this.label2);
            this.tabUsbCam.Controls.Add(this.label1);
            this.tabUsbCam.Controls.Add(this.cmbBaud);
            this.tabUsbCam.Controls.Add(this.cmbComPort);
            this.tabUsbCam.Controls.Add(this.btnConnectSerial);
            this.tabUsbCam.Location = new System.Drawing.Point(4, 25);
            this.tabUsbCam.Name = "tabUsbCam";
            this.tabUsbCam.Padding = new System.Windows.Forms.Padding(3);
            this.tabUsbCam.Size = new System.Drawing.Size(273, 150);
            this.tabUsbCam.TabIndex = 1;
            this.tabUsbCam.Text = "Configure";
            this.tabUsbCam.UseVisualStyleBackColor = true;
            // 
            // chkComReverse
            // 
            this.chkComReverse.AutoSize = true;
            this.chkComReverse.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.cameraConfigBindingSource, "Reverse", true));
            this.chkComReverse.Location = new System.Drawing.Point(7, 78);
            this.chkComReverse.Name = "chkComReverse";
            this.chkComReverse.Size = new System.Drawing.Size(88, 17);
            this.chkComReverse.TabIndex = 16;
            this.chkComReverse.Text = "Reverse Pan";
            this.chkComReverse.UseVisualStyleBackColor = true;
            // 
            // cameraConfigBindingSource
            // 
            this.cameraConfigBindingSource.DataSource = typeof(AVDeviceControl.CameraConfig);
            this.cameraConfigBindingSource.CurrentItemChanged += new System.EventHandler(this.cameraConfigBindingSource_CurrentItemChanged);
            // 
            // btnRefreshPorts
            // 
            this.btnRefreshPorts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshPorts.Location = new System.Drawing.Point(240, 25);
            this.btnRefreshPorts.Name = "btnRefreshPorts";
            this.btnRefreshPorts.Size = new System.Drawing.Size(25, 23);
            this.btnRefreshPorts.TabIndex = 12;
            this.btnRefreshPorts.Text = "...";
            this.btnRefreshPorts.UseVisualStyleBackColor = true;
            this.btnRefreshPorts.Click += new System.EventHandler(this.BtnRefreshPorts_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(210, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(55, 20);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Baud Rate";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "COM Port";
            // 
            // cmbBaud
            // 
            this.cmbBaud.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbBaud.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cameraConfigBindingSource, "Baud", true));
            this.cmbBaud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBaud.FormattingEnabled = true;
            this.cmbBaud.Location = new System.Drawing.Point(73, 51);
            this.cmbBaud.Name = "cmbBaud";
            this.cmbBaud.Size = new System.Drawing.Size(161, 21);
            this.cmbBaud.TabIndex = 6;
            // 
            // cmbComPort
            // 
            this.cmbComPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbComPort.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.cameraConfigBindingSource, "Port", true));
            this.cmbComPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbComPort.FormattingEnabled = true;
            this.cmbComPort.Location = new System.Drawing.Point(73, 26);
            this.cmbComPort.Name = "cmbComPort";
            this.cmbComPort.Size = new System.Drawing.Size(161, 21);
            this.cmbComPort.TabIndex = 5;
            // 
            // btnConnectSerial
            // 
            this.btnConnectSerial.Location = new System.Drawing.Point(4, 4);
            this.btnConnectSerial.Name = "btnConnectSerial";
            this.btnConnectSerial.Size = new System.Drawing.Size(55, 20);
            this.btnConnectSerial.TabIndex = 4;
            this.btnConnectSerial.Text = "Connect";
            this.btnConnectSerial.UseVisualStyleBackColor = true;
            this.btnConnectSerial.Click += new System.EventHandler(this.BtnConnectSerial_Click);
            // 
            // tabIpCam
            // 
            this.tabIpCam.Controls.Add(this.chkIpReverse);
            this.tabIpCam.Controls.Add(this.label7);
            this.tabIpCam.Controls.Add(this.textBox1);
            this.tabIpCam.Controls.Add(this.btnDelete2);
            this.tabIpCam.Controls.Add(this.label5);
            this.tabIpCam.Controls.Add(this.label4);
            this.tabIpCam.Controls.Add(this.btnConnectIp);
            this.tabIpCam.Controls.Add(this.rtspUrl);
            this.tabIpCam.Controls.Add(this.ipAddress);
            this.tabIpCam.Location = new System.Drawing.Point(4, 25);
            this.tabIpCam.Name = "tabIpCam";
            this.tabIpCam.Padding = new System.Windows.Forms.Padding(3);
            this.tabIpCam.Size = new System.Drawing.Size(273, 150);
            this.tabIpCam.TabIndex = 0;
            this.tabIpCam.Text = "Configure";
            this.tabIpCam.UseVisualStyleBackColor = true;
            // 
            // chkIpReverse
            // 
            this.chkIpReverse.AutoSize = true;
            this.chkIpReverse.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.cameraConfigBindingSource, "Reverse", true));
            this.chkIpReverse.Location = new System.Drawing.Point(12, 101);
            this.chkIpReverse.Name = "chkIpReverse";
            this.chkIpReverse.Size = new System.Drawing.Size(88, 17);
            this.chkIpReverse.TabIndex = 15;
            this.chkIpReverse.Text = "Reverse Pan";
            this.chkIpReverse.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(4, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "IP Port";
            // 
            // textBox1
            // 
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cameraConfigBindingSource, "CamIpPort", true));
            this.textBox1.Location = new System.Drawing.Point(79, 50);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(119, 20);
            this.textBox1.TabIndex = 13;
            // 
            // btnDelete2
            // 
            this.btnDelete2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete2.Location = new System.Drawing.Point(210, 4);
            this.btnDelete2.Name = "btnDelete2";
            this.btnDelete2.Size = new System.Drawing.Size(55, 20);
            this.btnDelete2.TabIndex = 12;
            this.btnDelete2.Text = "Delete";
            this.btnDelete2.UseVisualStyleBackColor = true;
            this.btnDelete2.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(5, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "RTSP URL";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(5, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "IP Address";
            // 
            // btnConnectIp
            // 
            this.btnConnectIp.Location = new System.Drawing.Point(4, 4);
            this.btnConnectIp.Name = "btnConnectIp";
            this.btnConnectIp.Size = new System.Drawing.Size(55, 20);
            this.btnConnectIp.TabIndex = 3;
            this.btnConnectIp.Text = "Connect";
            this.btnConnectIp.UseVisualStyleBackColor = true;
            this.btnConnectIp.Click += new System.EventHandler(this.BtnConnectIp_Click);
            // 
            // rtspUrl
            // 
            this.rtspUrl.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cameraConfigBindingSource, "CamRtsp", true));
            this.rtspUrl.Location = new System.Drawing.Point(80, 74);
            this.rtspUrl.Name = "rtspUrl";
            this.rtspUrl.Size = new System.Drawing.Size(119, 20);
            this.rtspUrl.TabIndex = 1;
            // 
            // ipAddress
            // 
            this.ipAddress.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cameraConfigBindingSource, "CamIp", true));
            this.ipAddress.Location = new System.Drawing.Point(80, 28);
            this.ipAddress.Name = "ipAddress";
            this.ipAddress.Size = new System.Drawing.Size(119, 20);
            this.ipAddress.TabIndex = 0;
            // 
            // tabCamControl
            // 
            this.tabCamControl.BackColor = System.Drawing.SystemColors.Control;
            this.tabCamControl.Controls.Add(this.lstLivePresets);
            this.tabCamControl.Controls.Add(this.ptControl);
            this.tabCamControl.Controls.Add(this.tbZoom);
            this.tabCamControl.Location = new System.Drawing.Point(4, 25);
            this.tabCamControl.Name = "tabCamControl";
            this.tabCamControl.Padding = new System.Windows.Forms.Padding(3);
            this.tabCamControl.Size = new System.Drawing.Size(273, 150);
            this.tabCamControl.TabIndex = 2;
            this.tabCamControl.Text = "PTZ";
            // 
            // lstLivePresets
            // 
            this.lstLivePresets.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstLivePresets.DisplayMember = "Name";
            this.lstLivePresets.FormattingEnabled = true;
            this.lstLivePresets.Location = new System.Drawing.Point(193, 9);
            this.lstLivePresets.Name = "lstLivePresets";
            this.lstLivePresets.Size = new System.Drawing.Size(74, 108);
            this.lstLivePresets.Sorted = true;
            this.lstLivePresets.TabIndex = 9;
            this.lstLivePresets.ValueMember = "Name";
            this.lstLivePresets.SelectedIndexChanged += new System.EventHandler(this.LstLivePresets_SelectedIndexChanged);
            // 
            // ptControl
            // 
            this.ptControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ptControl.AnglePan = -40D;
            this.ptControl.AngleTilt = -30D;
            this.ptControl.BackColor = System.Drawing.SystemColors.Control;
            this.ptControl.ColorBasePlane = System.Drawing.Color.RoyalBlue;
            this.ptControl.ColorCamera = System.Drawing.Color.Black;
            this.ptControl.ColorPosition = System.Drawing.Color.ForestGreen;
            this.ptControl.DebugMode = false;
            this.ptControl.LensDiamater = 12;
            this.ptControl.Location = new System.Drawing.Point(28, 3);
            this.ptControl.Margin = new System.Windows.Forms.Padding(4);
            this.ptControl.Name = "ptControl";
            this.ptControl.OblongY = 10;
            this.ptControl.OrthoRotation = -90F;
            this.ptControl.RadiusReduction = 9;
            this.ptControl.Size = new System.Drawing.Size(158, 122);
            this.ptControl.TabIndex = 4;
            this.ptControl.ZoomFraction = 0.6F;
            this.ptControl.ValueChanged += new AVDeviceControl.ucPtControl.PanTiltValueChangedEvent(this.PtControl_ValueChanged);
            // 
            // tbZoom
            // 
            this.tbZoom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tbZoom.BackColor = System.Drawing.SystemColors.Control;
            this.tbZoom.BarPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(94)))), ((int)(((byte)(110)))));
            this.tbZoom.BarPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.tbZoom.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.tbZoom.ColorSchema = ColorSlider.ColorSlider.ColorSchemas.RedColors;
            this.tbZoom.ElapsedInnerColor = System.Drawing.Color.Red;
            this.tbZoom.ElapsedPenColorBottom = System.Drawing.Color.Salmon;
            this.tbZoom.ElapsedPenColorTop = System.Drawing.Color.LightCoral;
            this.tbZoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.tbZoom.ForeColor = System.Drawing.Color.White;
            this.tbZoom.InputColor = System.Drawing.Color.SpringGreen;
            this.tbZoom.InputValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tbZoom.LargeChange = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.tbZoom.Location = new System.Drawing.Point(-5, 23);
            this.tbZoom.Margin = new System.Windows.Forms.Padding(2);
            this.tbZoom.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.tbZoom.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.tbZoom.Name = "tbZoom";
            this.tbZoom.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbZoom.ScaleDivisions = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.tbZoom.ScaleSubDivisions = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.tbZoom.ShowDivisionsText = true;
            this.tbZoom.ShowSmallScale = false;
            this.tbZoom.Size = new System.Drawing.Size(30, 96);
            this.tbZoom.SmallChange = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tbZoom.TabIndex = 8;
            this.tbZoom.Text = "colorSlider1";
            this.tbZoom.ThumbInnerColor = System.Drawing.Color.Red;
            this.tbZoom.ThumbPenColor = System.Drawing.Color.Red;
            this.tbZoom.ThumbRoundRectSize = new System.Drawing.Size(16, 16);
            this.tbZoom.ThumbSize = new System.Drawing.Size(16, 16);
            this.tbZoom.TickAdd = 0F;
            this.tbZoom.TickColor = System.Drawing.Color.White;
            this.tbZoom.TickDivide = 0F;
            this.tbZoom.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tbZoom.ValueChanged += new System.EventHandler(this.TbZoom_ValueChanged);
            this.tbZoom.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TbZoom_MouseUp);
            // 
            // tabPresets
            // 
            this.tabPresets.Controls.Add(this.btnMenuOk);
            this.tabPresets.Controls.Add(this.btnMenuOff);
            this.tabPresets.Controls.Add(this.btnMenuOn);
            this.tabPresets.Controls.Add(this.btnDelPreset);
            this.tabPresets.Controls.Add(this.grpPresets);
            this.tabPresets.Controls.Add(this.btnNewPreset);
            this.tabPresets.Controls.Add(this.lstPresets);
            this.tabPresets.Location = new System.Drawing.Point(4, 25);
            this.tabPresets.Name = "tabPresets";
            this.tabPresets.Size = new System.Drawing.Size(273, 150);
            this.tabPresets.TabIndex = 3;
            this.tabPresets.Text = "Presets";
            this.tabPresets.UseVisualStyleBackColor = true;
            // 
            // btnMenuOk
            // 
            this.btnMenuOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMenuOk.Location = new System.Drawing.Point(73, 116);
            this.btnMenuOk.Name = "btnMenuOk";
            this.btnMenuOk.Size = new System.Drawing.Size(33, 23);
            this.btnMenuOk.TabIndex = 6;
            this.btnMenuOk.Text = "Ok";
            this.btnMenuOk.UseVisualStyleBackColor = true;
            this.btnMenuOk.Click += new System.EventHandler(this.btnMenuOk_Click);
            // 
            // btnMenuOff
            // 
            this.btnMenuOff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMenuOff.Location = new System.Drawing.Point(37, 116);
            this.btnMenuOff.Name = "btnMenuOff";
            this.btnMenuOff.Size = new System.Drawing.Size(33, 23);
            this.btnMenuOff.TabIndex = 5;
            this.btnMenuOff.Text = "M-";
            this.btnMenuOff.UseVisualStyleBackColor = true;
            this.btnMenuOff.Click += new System.EventHandler(this.btnMenuOff_Click);
            // 
            // btnMenuOn
            // 
            this.btnMenuOn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMenuOn.Location = new System.Drawing.Point(2, 116);
            this.btnMenuOn.Name = "btnMenuOn";
            this.btnMenuOn.Size = new System.Drawing.Size(33, 23);
            this.btnMenuOn.TabIndex = 4;
            this.btnMenuOn.Text = "M+";
            this.btnMenuOn.UseVisualStyleBackColor = true;
            this.btnMenuOn.Click += new System.EventHandler(this.btnMenuOn_Click);
            // 
            // btnDelPreset
            // 
            this.btnDelPreset.Location = new System.Drawing.Point(58, 3);
            this.btnDelPreset.Name = "btnDelPreset";
            this.btnDelPreset.Size = new System.Drawing.Size(48, 23);
            this.btnDelPreset.TabIndex = 3;
            this.btnDelPreset.Text = "Delete";
            this.btnDelPreset.UseVisualStyleBackColor = true;
            this.btnDelPreset.Click += new System.EventHandler(this.BtnDelPreset_Click);
            // 
            // grpPresets
            // 
            this.grpPresets.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpPresets.Controls.Add(this.btnUpdate);
            this.grpPresets.Controls.Add(this.cmbPresetSpeed);
            this.grpPresets.Controls.Add(this.label12);
            this.grpPresets.Controls.Add(this.label11);
            this.grpPresets.Controls.Add(this.label10);
            this.grpPresets.Controls.Add(this.label9);
            this.grpPresets.Controls.Add(this.label8);
            this.grpPresets.Controls.Add(this.txtPresetZoom);
            this.grpPresets.Controls.Add(this.txtPresetTilt);
            this.grpPresets.Controls.Add(this.txtPresetPan);
            this.grpPresets.Controls.Add(this.txtPresetName);
            this.grpPresets.Location = new System.Drawing.Point(111, 3);
            this.grpPresets.Name = "grpPresets";
            this.grpPresets.Size = new System.Drawing.Size(158, 144);
            this.grpPresets.TabIndex = 2;
            this.grpPresets.TabStop = false;
            this.grpPresets.Text = "Preset";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(61, -2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(53, 20);
            this.btnUpdate.TabIndex = 10;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnPresetUpdate_Click);
            // 
            // cmbPresetSpeed
            // 
            this.cmbPresetSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPresetSpeed.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.presetsBindingSource, "Speed", true));
            this.cmbPresetSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPresetSpeed.FormattingEnabled = true;
            this.cmbPresetSpeed.Location = new System.Drawing.Point(44, 113);
            this.cmbPresetSpeed.Name = "cmbPresetSpeed";
            this.cmbPresetSpeed.Size = new System.Drawing.Size(114, 21);
            this.cmbPresetSpeed.TabIndex = 4;
            // 
            // presetsBindingSource
            // 
            this.presetsBindingSource.DataSource = typeof(AVDeviceControl.Preset);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(0, 116);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 13);
            this.label12.TabIndex = 9;
            this.label12.Text = "Speed";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(0, 94);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 13);
            this.label11.TabIndex = 8;
            this.label11.Text = "Zoom";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(0, 71);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(25, 13);
            this.label10.TabIndex = 7;
            this.label10.Text = "Tilt";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(0, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Pan";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(0, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Name";
            // 
            // txtPresetZoom
            // 
            this.txtPresetZoom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPresetZoom.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.presetsBindingSource, "Zoom", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N1"));
            this.txtPresetZoom.Location = new System.Drawing.Point(44, 90);
            this.txtPresetZoom.Name = "txtPresetZoom";
            this.txtPresetZoom.Size = new System.Drawing.Size(114, 20);
            this.txtPresetZoom.TabIndex = 3;
            // 
            // txtPresetTilt
            // 
            this.txtPresetTilt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPresetTilt.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.presetsBindingSource, "Tilt", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N1"));
            this.txtPresetTilt.Location = new System.Drawing.Point(44, 67);
            this.txtPresetTilt.Name = "txtPresetTilt";
            this.txtPresetTilt.Size = new System.Drawing.Size(114, 20);
            this.txtPresetTilt.TabIndex = 2;
            // 
            // txtPresetPan
            // 
            this.txtPresetPan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPresetPan.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.presetsBindingSource, "Pan", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N1"));
            this.txtPresetPan.Location = new System.Drawing.Point(44, 44);
            this.txtPresetPan.Name = "txtPresetPan";
            this.txtPresetPan.Size = new System.Drawing.Size(114, 20);
            this.txtPresetPan.TabIndex = 1;
            // 
            // txtPresetName
            // 
            this.txtPresetName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPresetName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.presetsBindingSource, "Name", true));
            this.txtPresetName.Location = new System.Drawing.Point(44, 21);
            this.txtPresetName.Name = "txtPresetName";
            this.txtPresetName.Size = new System.Drawing.Size(114, 20);
            this.txtPresetName.TabIndex = 0;
            this.txtPresetName.Leave += new System.EventHandler(this.TextBox2_Leave);
            // 
            // btnNewPreset
            // 
            this.btnNewPreset.Location = new System.Drawing.Point(2, 2);
            this.btnNewPreset.Name = "btnNewPreset";
            this.btnNewPreset.Size = new System.Drawing.Size(45, 23);
            this.btnNewPreset.TabIndex = 1;
            this.btnNewPreset.Text = "New";
            this.btnNewPreset.UseVisualStyleBackColor = true;
            this.btnNewPreset.Click += new System.EventHandler(this.BtnNewPreset_Click);
            // 
            // lstPresets
            // 
            this.lstPresets.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstPresets.DisplayMember = "Name";
            this.lstPresets.FormattingEnabled = true;
            this.lstPresets.Location = new System.Drawing.Point(3, 27);
            this.lstPresets.Name = "lstPresets";
            this.lstPresets.Size = new System.Drawing.Size(102, 82);
            this.lstPresets.Sorted = true;
            this.lstPresets.TabIndex = 0;
            this.lstPresets.ValueMember = "Name";
            this.lstPresets.SelectedValueChanged += new System.EventHandler(this.LstPresets_SelectedValueChanged);
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.ucCamSettings1);
            this.tabSettings.Location = new System.Drawing.Point(4, 25);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Size = new System.Drawing.Size(273, 150);
            this.tabSettings.TabIndex = 4;
            this.tabSettings.Text = "Settings";
            this.tabSettings.UseVisualStyleBackColor = true;
            // 
            // ucCamSettings1
            // 
            this.ucCamSettings1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucCamSettings1.Location = new System.Drawing.Point(0, 0);
            this.ucCamSettings1.Name = "ucCamSettings1";
            this.ucCamSettings1.Size = new System.Drawing.Size(273, 150);
            this.ucCamSettings1.TabIndex = 0;
            // 
            // chkIp
            // 
            this.chkIp.AutoSize = true;
            this.chkIp.Location = new System.Drawing.Point(183, 3);
            this.chkIp.Name = "chkIp";
            this.chkIp.Size = new System.Drawing.Size(60, 17);
            this.chkIp.TabIndex = 11;
            this.chkIp.Text = "IP Cam";
            this.chkIp.UseVisualStyleBackColor = true;
            this.chkIp.CheckedChanged += new System.EventHandler(this.ChkIsIp_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cameraConfigBindingSource, "Name", true));
            this.txtName.Location = new System.Drawing.Point(65, 1);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(112, 20);
            this.txtName.TabIndex = 13;
            // 
            // btnCtlDisconnect
            // 
            this.btnCtlDisconnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCtlDisconnect.Location = new System.Drawing.Point(191, 1);
            this.btnCtlDisconnect.Margin = new System.Windows.Forms.Padding(2);
            this.btnCtlDisconnect.Name = "btnCtlDisconnect";
            this.btnCtlDisconnect.Size = new System.Drawing.Size(78, 20);
            this.btnCtlDisconnect.TabIndex = 10;
            this.btnCtlDisconnect.Text = "Disconnect";
            this.btnCtlDisconnect.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCtlDisconnect.UseVisualStyleBackColor = true;
            this.btnCtlDisconnect.Click += new System.EventHandler(this.btnCtlDisconnect_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Location = new System.Drawing.Point(1, 0);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(21, 21);
            this.btnLeft.TabIndex = 15;
            this.btnLeft.Text = "<";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnRight
            // 
            this.btnRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRight.Location = new System.Drawing.Point(258, 0);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(21, 21);
            this.btnRight.TabIndex = 16;
            this.btnRight.Text = ">";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // cameraBindingSource
            // 
            this.cameraBindingSource.DataSource = typeof(AVDeviceControl.PtzCamera);
            // 
            // ucViscaCamera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btnCtlDisconnect);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.btnLeft);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chkIp);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ucViscaCamera";
            this.Size = new System.Drawing.Size(281, 200);
            this.Load += new System.EventHandler(this.UcViscaCamera_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabUsbCam.ResumeLayout(false);
            this.tabUsbCam.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cameraConfigBindingSource)).EndInit();
            this.tabIpCam.ResumeLayout(false);
            this.tabIpCam.PerformLayout();
            this.tabCamControl.ResumeLayout(false);
            this.tabPresets.ResumeLayout(false);
            this.grpPresets.ResumeLayout(false);
            this.grpPresets.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.presetsBindingSource)).EndInit();
            this.tabSettings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cameraBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabUsbCam;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbBaud;
        private System.Windows.Forms.ComboBox cmbComPort;
        private System.Windows.Forms.Button btnConnectSerial;
        private System.Windows.Forms.TabPage tabIpCam;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnConnectIp;
        private System.Windows.Forms.TextBox rtspUrl;
        private System.Windows.Forms.TextBox ipAddress;
        private System.Windows.Forms.TabPage tabCamControl;
        private System.Windows.Forms.BindingSource cameraConfigBindingSource;
        private System.Windows.Forms.CheckBox chkIp;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnDelete2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox1;
        private ColorSlider.ColorSlider tbZoom;
        private System.Windows.Forms.TabPage tabPresets;
        private System.Windows.Forms.ListBox lstPresets;
        private System.Windows.Forms.Button btnNewPreset;
        private System.Windows.Forms.GroupBox grpPresets;
        private System.Windows.Forms.TextBox txtPresetName;
        private System.Windows.Forms.BindingSource presetsBindingSource;
        private System.Windows.Forms.TextBox txtPresetTilt;
        private System.Windows.Forms.TextBox txtPresetPan;
        private System.Windows.Forms.TextBox txtPresetZoom;
        private System.Windows.Forms.Button btnDelPreset;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox lstLivePresets;
        private System.Windows.Forms.ComboBox cmbPresetSpeed;
        private System.Windows.Forms.Button btnRefreshPorts;
        private System.Windows.Forms.BindingSource cameraBindingSource;
        private System.Windows.Forms.TabPage tabSettings;
        private ucCamSettings ucCamSettings1;
        private System.Windows.Forms.Button btnCtlDisconnect;
        private System.Windows.Forms.Button btnUpdate;
        private ucPtControl ptControl;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnMenuOff;
        private System.Windows.Forms.Button btnMenuOn;
        private System.Windows.Forms.Button btnMenuOk;
        private System.Windows.Forms.CheckBox chkComReverse;
        private System.Windows.Forms.CheckBox chkIpReverse;
    }
}
