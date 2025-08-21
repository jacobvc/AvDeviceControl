using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AVDeviceControl
{
    public partial class MainForm : Form
    {
        DeviceConfigCollection collection = new DeviceConfigCollection();
        AvDeviceCollection deviceControls = new AvDeviceCollection();

        DeviceControlWebsocket ws;
        Midi midi;

        DebugForm debugForm = new DebugForm();

        #region Constructor / Form Events
        public MainForm()
        {
            InitializeComponent();
            mnuDebugLevel.Items.AddRange(Enum.GetNames(typeof(LogLevel)));

            midi = new Midi();

        }

        private TextBoxTraceListener _textBoxListener;
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

            Properties.Settings.Default.logLevel = MnuLogLevel;
            if (WindowState != FormWindowState.Minimized)
            {
                Properties.Settings.Default.formLoc = this.Location;
                Properties.Settings.Default.formSize = this.Size;
                Properties.Settings.Default.Split = spltMain.SplitterDistance;
            }
            SaveSettings(false);

            Properties.Settings.Default.Save();
        }
        #endregion

        int MnuLogLevel
        {
            get { return (int)PtzController.logLevel; }
            set
            {
                PtzController.logLevel = (LogLevel)value;
                mnuDebugLevel.Text = PtzController.logLevel.ToString();
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
            if (Int32.TryParse(mnuWebsocketPort.Text, out iPort))
            {
                ws.Start(iPort);
                lblWebSocket.ForeColor = Color.Black;
                lblWebSocket.Text = "Websocket running on port " + mnuWebsocketPort.Text;
                Properties.Settings.Default.webSocketPort = port;
            }
            else
            {
                lblWebSocket.ForeColor = Color.Red;
                lblWebSocket.Text = "Websocket NOT RUNNING: Invalid Port";
                MessageBox.Show("Can't start websocket server. Port must be an integer.", "Websocket Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LogAction(byte level, string format, object[] args)
        {
            if (level >= MnuLogLevel)
            {
                Console.WriteLine("PT LOG:[{0}]", String.Format(format, args));
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
                dlg.Filter = "Device configuration files (*.cfg)|*.cfg";
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
            else
            {
                collection = new DeviceConfigCollection();
            }
            if (collection.DeviceCount == 0)
            {
                collection.AddCamera(new CameraConfig());
            }
            if (Properties.Settings.Default.logLevel == (int)LogLevel.Verbose) 
            {
                debugForm.Show();
                debugForm.FormClosing += (s, e) => {
                    if (_textBoxListener != null)
                    {
                        Debug.Listeners.Remove(_textBoxListener); // Or Trace.Listeners.Remove(_textBoxListener);
                        _textBoxListener.Dispose();
                        _textBoxListener = null;
                        //Debug.Listeners.Add(Console);
                    }
                };
                _textBoxListener = new TextBoxTraceListener(debugForm.TextBox);
                Debug.Listeners.Add(_textBoxListener); // Or Trace.Listeners.Add(_textBoxListener);
            }

            foreach (AvDeviceConfig dev in collection.devices)
            {
                if (dev is CameraConfig)
                {
                    AddCamera(dev as CameraConfig, spltMain.Panel1);
                }
                else if (dev is MixerConfig)
                {
                    AddMixer(dev as MixerConfig, spltMain.Panel1);
                }
            }
            PositionDevices(spltMain.Panel1);
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
                dlg.Filter = "Device configuration files (*.cfg)|*.cfg";
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
        private void AddCamera(CameraConfig cfg, SplitterPanel panel)
        {
            ucViscaCamera cam = new ucViscaCamera(cfg, LogAction);
            cam.Click += Device_click;
            cam.RqDelete += Camera_RqDelete;
            cam.RqMove += Cam_RqMove;
            deviceControls.AddCamera(cam);
            panel.Controls.Add(cam);

            PositionDevices(panel);

        }

        private void RemoveCamera(ucViscaCamera ctl, SplitterPanel panel)
        {
            ctl.Disconnect();
            collection.devices.Remove(ctl.Config);
            deviceControls.RemoveCamera(ctl);
            panel.Controls.Remove(ctl);

            PositionDevices(panel);
        }

        private void Camera_RqDelete(object sender, EventArgs e)
        {
            RemoveCamera(sender as ucViscaCamera, spltMain.Panel1);
        }

        private void Cam_RqMove(object sender, bool left)
        {
            MoveAvDevice((sender as ucViscaCamera).Config, left);
        }

        #endregion

        #region Mixer Devices
        private void AddMixer(MixerConfig cfg, SplitterPanel panel)
        {
            ucMixer brd = new ucMixer(midi, cfg);
            brd.Click += Device_click;
            brd.RqDelete += Mixer_RqDelete;
            brd.RqMove += Mixer_RqMove;
            deviceControls.AddMixer(brd);
            panel.Controls.Add(brd);

            PositionDevices(panel);
        }

        private void RemoveMixer(ucMixer ctl, SplitterPanel panel)
        {
            ctl.Disconnect();
            collection.devices.Remove(ctl.Config);
            deviceControls.RemoveMixer(ctl);
            panel.Controls.Remove(ctl);

            PositionDevices(panel);
        }

        private void Mixer_RqDelete(object sender, EventArgs e)
        {
            RemoveMixer(sender as ucMixer, spltMain.Panel1);
        }

        private void Mixer_RqMove(object sender, bool left)
        {
            MoveAvDevice((sender as ucMixer).Config, left);
        }
        #endregion

        #region All Devices
        private void RemoveAllDevices(Control panel)
        {
            for (int i = 0; i < deviceControls.DeviceCount; ++i)
            {
                ucAvDevice dev = deviceControls.Device(i);
                dev.Disconnect();
                panel.Controls.Remove(dev);
            }
            collection.devices.Clear();
            deviceControls.Clear();
        }

        private void MoveAvDevice(AvDeviceConfig config, bool left)
        {
            for (int i = 0; i < collection.devices.Count; ++i)
            {
                if (config == collection.devices[i])
                {
                    if (left && i > 0)
                    {
                        AvDeviceConfig tmp = collection.devices[i - 1];
                        collection.devices[i - 1] = config;
                        collection.devices[i] = tmp;
                        deviceControls.MoveUcDevice(i, left);
                        break;
                    }
                    else if (!left && i < collection.devices.Count - 1)
                    {
                        AvDeviceConfig tmp = collection.devices[i + 1];
                        collection.devices[i + 1] = config;
                        collection.devices[i] = tmp;
                        deviceControls.MoveUcDevice(i, left);
                        break;
                    }
                }
            }
            PositionDevices(spltMain.Panel1);
        }
        bool positioning = false;
        int minDeviceHeight = 220;
        private void PositionDevices(SplitterPanel panel)
        {
            if (deviceControls.DeviceCount > 0)
            {
                positioning = true;

                int clientHeight = panel.Parent.ClientRectangle.Height - 8; // space for scrollbar
                int clientWidth = panel.Parent.ClientRectangle.Width;
                int scrLeft = -panel.HorizontalScroll.Value;
                panel.VerticalScroll.Value = 0;
                // Column count based on panel size and aspect ratio
                double aCols = Math.Max(1,
                   (double)clientWidth / clientHeight * deviceControls.Device(0).AspectRatio);
                // Row / col count is based on best 2 dim fit of cells into panel
                aCols *= Math.Sqrt(aCols);
                int aRows = Math.Max(deviceControls.DeviceCount / (int)aCols, 1);
                int rows = aRows;
                int cols = (deviceControls.DeviceCount + rows - 1) / rows;
                // Cell height is smaller of "fill height", or "fill width"
                int cellHeight = Math.Min(clientHeight / rows,
                  (int)(clientWidth / cols / deviceControls.Device(0).AspectRatio));
                if (cellHeight < minDeviceHeight)
                {
                    cellHeight = minDeviceHeight;
                    //cols = (int)(clientWidth / (cellHeight * deviceControls.Device(0).AspectRatio));
                    //rows = Math.Max(deviceControls.DeviceCount / cols, 1);
                    Console.WriteLine("MinHeight " + aCols + "=>" + cols + " Cols, "
                      + aRows + "=>" + rows + " Rows, Cellheight " + cellHeight);
                }
                else
                {
                    Console.WriteLine("MinWidth " + cols + " Cols, " + rows + " Rows, Cellheight " + cellHeight);
                }
                int top = 0;
                int left = scrLeft;

                for (int i = 0; i < deviceControls.DeviceCount; ++i)
                {
                    ucAvDevice uc = deviceControls.Device(i);
                    uc.SetSize(cellHeight);
                    uc.Location = new Point(left, top);
                    left += uc.Width;
                    uc.ConfigureMoveable(i > 0, i < deviceControls.DeviceCount - 1);
                    if ((i + 1) % cols == 0)
                    {
                        top += cellHeight;
                        left = scrLeft;
                    }
                }
                panel.Invalidate();
                positioning = false;
            }
        }
        #endregion

        #endregion

        #region Control Events
        private void SpltMain_Panel1_Resize(object sender, EventArgs e)
        {
            if (!positioning)
            {
                PositionDevices(spltMain.Panel1);
            }
        }

        private void Device_click(object sender, EventArgs e)
        {
            //MessageBox.Show("Device clicked");
        }

        private void MnuAddCamera_Click(object sender, EventArgs e)
        {
            CameraConfig cfg = new CameraConfig();
            collection.AddCamera(cfg);
            AddCamera(cfg, spltMain.Panel1);
        }

        private void MnuAddMixer_Click(object sender, EventArgs e)
        {
            MixerConfig cfg = new MixerConfig();
            collection.AddMixer(cfg);
            AddMixer(cfg, spltMain.Panel1);
        }

        private void MnuLoadConfig_Click(object sender, EventArgs e)
        {
            LoadSettings(true);
        }

        private void MnuSaveConfig_Click(object sender, EventArgs e)
        {
            SaveSettings(true);
        }

        private void MnuSaveJSONCopy_Click(object sender, EventArgs e)
        {
            mnuSaveJSONCopy.Checked = !mnuSaveJSONCopy.Checked;
            Properties.Settings.Default.saveJsonConfigCopy = mnuSaveJSONCopy.Checked;
        }

        private void MnuCmbLog_SelectedIndexChanged(object sender, EventArgs e)
        {
            PtzController.logLevel = LogLevel.Warning;
            Enum.TryParse(mnuDebugLevel.Text, out PtzController.logLevel);
            MnuLogLevel = (int)PtzController.logLevel;
        }

        private void MnuWebsocketPort_TextChanged(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.webSocketPort
                != mnuWebsocketPort.Text.Trim())
            {
                pnlPending.Visible = true;
                lblPending.Text = mnuWebsocketPort.Text;
                lblPending.ForeColor = Color.Black;
            }
            else
            {
                pnlPending.Visible = false;
            }
        }

        private void BtnCommit_Click(object sender, EventArgs e)
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
                MessageBox.Show("Invalid port: " + lblPending.Text, "Port Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            pnlPending.Visible = false;
            mnuWebsocketPort.Text = Properties.Settings.Default.webSocketPort;
        }
        #endregion
    }

    public class TextBoxTraceListener : TraceListener
    {
        private TextBox _outputTextBox;

        public TextBoxTraceListener(TextBox outputTextBox)
        {
            _outputTextBox = outputTextBox ?? throw new ArgumentNullException(nameof(outputTextBox));
        }

        public override void Write(string message)
        {
            // Ensure thread safety when updating UI controls
            if (_outputTextBox.InvokeRequired)
            {
                _outputTextBox.Invoke(new Action(() => _outputTextBox.AppendText(message)));
            }
            else
            {
                _outputTextBox.AppendText(message);
            }
        }

        public override void WriteLine(string message)
        {
            Write(message + Environment.NewLine);
        }
    }
}
