using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;

namespace AVDeviceControl
{
    public partial class MainForm : Form
    {
        DeviceConfigCollection collection = new DeviceConfigCollection();
        DeviceCollection deviceControls = new DeviceCollection();

        DeviceControlWebsocket ws;
        Midi midi;

        #region Constructor / Form Events
        public MainForm()
        {
            InitializeComponent();
            mnuCmbLog.Items.AddRange(Enum.GetNames(typeof(LogLevel)));

            midi = new Midi();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
           if (Properties.Settings.Default.formSize.Width != 0)
            {
                this.Location = Properties.Settings.Default.formLoc;
                this.Size = Properties.Settings.Default.formSize;
                //spltMain.SplitterDistance = Properties.Settings.Default.Split;
            }
            MnuLogLevel = Properties.Settings.Default.logLevel;
            mnuWebsocketPort.Text = Properties.Settings.Default.webSocketPort;

            StartWebSockServer(mnuWebsocketPort.Text);

            mnuSaveJSONCopy.Checked = Properties.Settings.Default.saveJsonConfigCopy;
            LoadSettings(false);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopWebSockServer();

            Properties.Settings.Default.formLoc = this.Location;
            Properties.Settings.Default.formSize = this.Size;
            Properties.Settings.Default.Split = spltMain.SplitterDistance;
            Properties.Settings.Default.logLevel = MnuLogLevel;
            SaveSettings(false);

            Properties.Settings.Default.Save();
        }
        #endregion

        string MnuLogLevel
        {
            get { return PtzController.logLevel.ToString(); }
            set
            {
                PtzController.logLevel = LogLevel.Warning;
                Enum.TryParse(value, out PtzController.logLevel);
                mnuCmbLog.Text = PtzController.logLevel.ToString();
            }
        }

        void StopWebSockServer()
        {
            ws?.Stop();
            lblWebSocket.Text = "Websocket NOT RUNNING";
        }
        void StartWebSockServer(String port)
        {
            ws = new DeviceControlWebsocket(deviceControls);
            int iPort;
            if (Int32.TryParse(mnuWebsocketPort.Text, out iPort)) {
                ws.Start(iPort);
                lblWebSocket.ForeColor = Color.Black;
                lblWebSocket.Text = "Websocket running on port " + mnuWebsocketPort.Text;
                Properties.Settings.Default.webSocketPort = port;
            }
            else
            {
                lblWebSocket.ForeColor = Color.Red;
                lblWebSocket.Text = "Websocket NOT RUNNING: Invalid Port";
                //MessageBox.Show("Can't start webserver. Port must be integer.");
            }
        }

        #region Device configuration settings and methods

        #region Device Configuration
        private void LoadSettings(bool ask)
        {
            RemoveAllDevices(spltMain.Panel1);
            collection = null;
            string filename = null;
            if (ask)
            {
                FileDialog dlg = new OpenFileDialog();
                dlg.Filter = "Camera configuration files (*.cfg)|*.cfg";
                dlg.Title = "Select camera configuration (.cfg) file to load";
                dlg.FileName = Properties.Settings.Default.cameraSettings;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    filename = dlg.FileName;
                }
            }
            else
            {
                filename = Properties.Settings.Default.cameraSettings;
            }
            if (File.Exists(filename))
            {
                collection = DeviceConfigCollection.Deserialize(filename);
            }

            if (collection != null)
            {
                Properties.Settings.Default.cameraSettings = filename;
                staLblConfigFile.Text = filename; 
            }
            else { 
                collection = new DeviceConfigCollection();
            }
            if (collection.CameraCount == 0)
            {
                collection.AddCamera(new CameraConfig());
            }
            foreach (CameraConfig cfg in collection.cameras)
            {
                AddCamera(cfg, spltMain.Panel1);
            }
            foreach (MixerConfig cfg in collection.mixers)
            {
                AddMixer(cfg, spltMain.Panel1);
            }
        }
        private void SaveSettings(bool ask)
        {
            string filename = null;
            if (!ask)
            {
                filename = Properties.Settings.Default.cameraSettings;
            }
            if (!File.Exists(filename))
            {
                FileDialog dlg = new SaveFileDialog();
                dlg.Filter = "Camera configuration files (*.cfg)|*.cfg";
                dlg.Title = "Save camera configuration to (.cfg) file";
                dlg.FileName = Properties.Settings.Default.cameraSettings;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    Properties.Settings.Default.cameraSettings = dlg.FileName;
                    staLblConfigFile.Text = dlg.FileName;

                }
            }
            collection.Serialize(Properties.Settings.Default.cameraSettings);
        }
        #endregion

        #region Camera Devices
        private void AddCamera(CameraConfig cfg, Control panel)
        {
            ucViscaCamera cam = new ucViscaCamera(cfg);
            cam.Click += Device_click;
            cam.RqDelete += Camera_RqDelete;
            deviceControls.AddCamera(cam);
            panel.Controls.Add(cam);

            PositionDevices(panel);
            
        }

        private void RemoveCamera(ucViscaCamera ctl, Control panel)
        {
            collection.cameras.Remove(ctl.Config);
            deviceControls.RemoveCamera(ctl);
            panel.Controls.Remove(ctl);

            PositionDevices(panel);
        }

        private void Camera_RqDelete(object sender, EventArgs e)
        {
            RemoveCamera(sender as ucViscaCamera, spltMain.Panel1);
        }

        #endregion

        #region Mixer Devices
        private void AddMixer(MixerConfig cfg, Control panel)
        {
            ucMixer brd = new ucMixer(midi, cfg);
            brd.Click += Device_click;
            brd.RqDelete += Mixer_RqDelete;
            deviceControls.AddMixer(brd);
            panel.Controls.Add(brd);

            PositionDevices(panel);
        }

        private void RemoveMixer(ucMixer ctl, Control panel)
        {
            collection.mixers.Remove(ctl.Config);
            deviceControls.RemoveMixer(ctl);
            panel.Controls.Remove(ctl);

            PositionDevices(panel);
        }

        private void Mixer_RqDelete(object sender, EventArgs e)
        {
            RemoveMixer(sender as ucMixer, spltMain.Panel1);
        }
        #endregion

        #region All Devices
        private void RemoveAllDevices(Control panel)
        {
            for (int i = 0; i < deviceControls.CameraCount; ++i)
            {
                panel.Controls.Remove(deviceControls.Camera(i));
            }
            for (int i = 0; i < deviceControls.MixerCount; ++i)
            {
                panel.Controls.Remove(deviceControls.Mixer(i));
            }
            collection.cameras.Clear();
            deviceControls.Clear();
        }

        private void PositionDevices(Control panel)
        {
            int clientHeight = panel.ClientRectangle.Height - 8; // space for scrollbar
            int left = 0;
            for (int i = 0; i < deviceControls.CameraCount; ++i)
            {
                ucViscaCamera cam = deviceControls.Camera(i);
                cam.Size = new Size(clientHeight * cam.Width / cam.Height, clientHeight);
                cam.Location = new Point(left, 0);
                left += cam.Width;
            }
            for (int i = 0; i < deviceControls.MixerCount; ++i)
            {
                ucMixer mixer = deviceControls.Mixer(i);
                mixer.Size = new Size(clientHeight * mixer.Width / mixer.Height, clientHeight);
                mixer.Location = new Point(left, 0);
                left += mixer.Width;
            }
        }
        #endregion

        #endregion

        #region Control Events
        private void spltMain_Panel1_Resize(object sender, EventArgs e)
        {
            PositionDevices(spltMain.Panel1);
        }

        private void Device_click(object sender, EventArgs e)
        {
            //MessageBox.Show("Camera clicked");
        }

        private void mnuAddCamera_Click(object sender, EventArgs e)
        {
            CameraConfig cfg = new CameraConfig();
            collection.AddCamera(cfg);
            AddCamera(cfg, spltMain.Panel1);
        }

        private void mnuAddMixer_Click(object sender, EventArgs e)
        {
            MixerConfig cfg = new MixerConfig();
            collection.AddMixer(cfg);
            AddMixer(cfg, spltMain.Panel1);
        }

        private void mnuLoadConfig_Click(object sender, EventArgs e)
        {
            LoadSettings(true);
        }

        private void mnuSaveConfig_Click(object sender, EventArgs e)
        {
            SaveSettings(true);
        }

        private void mnuSaveJSONCopy_Click(object sender, EventArgs e)
        {
            mnuSaveJSONCopy.Checked = !mnuSaveJSONCopy.Checked;
            Properties.Settings.Default.saveJsonConfigCopy = mnuSaveJSONCopy.Checked;
        }

        private void mnuCmbLog_SelectedIndexChanged(object sender, EventArgs e)
        {
            MnuLogLevel = mnuCmbLog.Text;
        }
        #endregion

        private void mnuWebsocketPort_TextChanged(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.webSocketPort
                != mnuWebsocketPort.Text.Trim())
            {
                pnlPending.Visible= true;
                lblPending.Text = mnuWebsocketPort.Text;
                lblPending.ForeColor = Color.Black;
            }
            else
            {
                pnlPending.Visible= false;
            }
        }

        private void btnCommit_Click(object sender, EventArgs e)
        {
            int port;
            if (Int32.TryParse(lblPending.Text, out port))
            {
                StopWebSockServer();
                StartWebSockServer(lblPending.Text);
                pnlPending.Visible = false;
            }
            else
            {
                lblPending.ForeColor = Color.Red;
                MessageBox.Show("Invalid port:" + lblPending.Text);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            pnlPending.Visible = false;
            mnuWebsocketPort.Text = Properties.Settings.Default.webSocketPort;
        }
    }
}
