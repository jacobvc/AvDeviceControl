
namespace AVDeviceControl
{
    partial class ucMixer
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
            this.tpConfigure = new System.Windows.Forms.TabPage();
            this.chkTest = new System.Windows.Forms.CheckBox();
            this.chk01v96 = new System.Windows.Forms.CheckBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.dgChannels = new System.Windows.Forms.DataGridView();
            this.Channel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Control = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRefreshDevices = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDevices = new System.Windows.Forms.ComboBox();
            this.tpControl = new System.Windows.Forms.TabPage();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.mixerConfigBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.channelsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1.SuspendLayout();
            this.tpConfigure.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgChannels)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mixerConfigBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.channelsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tpConfigure);
            this.tabControl1.Controls.Add(this.tpControl);
            this.tabControl1.Location = new System.Drawing.Point(4, 29);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(230, 172);
            this.tabControl1.TabIndex = 0;
            // 
            // tpConfigure
            // 
            this.tpConfigure.Controls.Add(this.chkTest);
            this.tpConfigure.Controls.Add(this.chk01v96);
            this.tpConfigure.Controls.Add(this.btnDelete);
            this.tpConfigure.Controls.Add(this.btnConnect);
            this.tpConfigure.Controls.Add(this.dgChannels);
            this.tpConfigure.Controls.Add(this.btnRefreshDevices);
            this.tpConfigure.Controls.Add(this.label1);
            this.tpConfigure.Controls.Add(this.cmbDevices);
            this.tpConfigure.Location = new System.Drawing.Point(4, 22);
            this.tpConfigure.Name = "tpConfigure";
            this.tpConfigure.Padding = new System.Windows.Forms.Padding(3);
            this.tpConfigure.Size = new System.Drawing.Size(222, 146);
            this.tpConfigure.TabIndex = 0;
            this.tpConfigure.Text = "Configure";
            this.tpConfigure.UseVisualStyleBackColor = true;
            // 
            // chkTest
            // 
            this.chkTest.AutoSize = true;
            this.chkTest.Location = new System.Drawing.Point(123, 31);
            this.chkTest.Name = "chkTest";
            this.chkTest.Size = new System.Drawing.Size(47, 17);
            this.chkTest.TabIndex = 20;
            this.chkTest.Text = "Test";
            this.chkTest.UseVisualStyleBackColor = true;
            // 
            // chk01v96
            // 
            this.chk01v96.AutoSize = true;
            this.chk01v96.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.mixerConfigBindingSource, "Y01v96", true));
            this.chk01v96.Location = new System.Drawing.Point(70, 31);
            this.chk01v96.Name = "chk01v96";
            this.chk01v96.Size = new System.Drawing.Size(56, 17);
            this.chk01v96.TabIndex = 19;
            this.chk01v96.Text = "01v96";
            this.chk01v96.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(174, 29);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(55, 20);
            this.btnDelete.TabIndex = 18;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(7, 29);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(55, 20);
            this.btnConnect.TabIndex = 17;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // dgChannels
            // 
            this.dgChannels.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgChannels.AutoGenerateColumns = false;
            this.dgChannels.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgChannels.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgChannels.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.Channel,
            this.Control,
            this.Mute});
            this.dgChannels.DataSource = this.channelsBindingSource;
            this.dgChannels.Location = new System.Drawing.Point(0, 52);
            this.dgChannels.Name = "dgChannels";
            this.dgChannels.Size = new System.Drawing.Size(219, 91);
            this.dgChannels.TabIndex = 16;
            this.dgChannels.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgChannels_CellValidating);
            this.dgChannels.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgChannels_EditingControlShowing);
            // 
            // Channel
            // 
            this.Channel.DataPropertyName = "Channel";
            this.Channel.HeaderText = "Channel";
            this.Channel.Name = "Channel";
            this.Channel.Width = 71;
            // 
            // Control
            // 
            this.Control.DataPropertyName = "Control";
            this.Control.HeaderText = "Control";
            this.Control.Name = "Control";
            this.Control.Width = 65;
            // 
            // Mute
            // 
            this.Mute.DataPropertyName = "Mute";
            this.Mute.HeaderText = "Mute";
            this.Mute.Name = "Mute";
            this.Mute.Width = 56;
            // 
            // btnRefreshDevices
            // 
            this.btnRefreshDevices.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshDevices.Location = new System.Drawing.Point(196, 5);
            this.btnRefreshDevices.Name = "btnRefreshDevices";
            this.btnRefreshDevices.Size = new System.Drawing.Size(25, 23);
            this.btnRefreshDevices.TabIndex = 15;
            this.btnRefreshDevices.Text = "...";
            this.btnRefreshDevices.UseVisualStyleBackColor = true;
            this.btnRefreshDevices.Click += new System.EventHandler(this.btnRefreshDevices_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Device";
            // 
            // cmbDevices
            // 
            this.cmbDevices.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDevices.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mixerConfigBindingSource, "Device", true));
            this.cmbDevices.DisplayMember = "name";
            this.cmbDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDevices.FormattingEnabled = true;
            this.cmbDevices.Location = new System.Drawing.Point(73, 6);
            this.cmbDevices.Name = "cmbDevices";
            this.cmbDevices.Size = new System.Drawing.Size(117, 21);
            this.cmbDevices.TabIndex = 13;
            this.cmbDevices.ValueMember = "name";
            // 
            // tpControl
            // 
            this.tpControl.Location = new System.Drawing.Point(4, 22);
            this.tpControl.Name = "tpControl";
            this.tpControl.Padding = new System.Windows.Forms.Padding(3);
            this.tpControl.Size = new System.Drawing.Size(222, 146);
            this.tpControl.TabIndex = 1;
            this.tpControl.Text = "Control";
            this.tpControl.UseVisualStyleBackColor = true;
            this.tpControl.Resize += new System.EventHandler(this.tpControl_Resize);
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mixerConfigBindingSource, "Name", true));
            this.txtName.Location = new System.Drawing.Point(38, 3);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(123, 20);
            this.txtName.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Name";
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDisconnect.Location = new System.Drawing.Point(164, 4);
            this.btnDisconnect.Margin = new System.Windows.Forms.Padding(0);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(70, 20);
            this.btnDisconnect.TabIndex = 19;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // mixerConfigBindingSource
            // 
            this.mixerConfigBindingSource.DataSource = typeof(AVDeviceControl.MixerConfig);
            this.mixerConfigBindingSource.CurrentItemChanged += new System.EventHandler(this.mixerConfigBindingSource_CurrentItemChanged);
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.Width = 60;
            // 
            // channelsBindingSource
            // 
            this.channelsBindingSource.DataSource = typeof(AVDeviceControl.MidiChannel);
            // 
            // ucMixer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tabControl1);
            this.Name = "ucMixer";
            this.Size = new System.Drawing.Size(237, 200);
            this.tabControl1.ResumeLayout(false);
            this.tpConfigure.ResumeLayout(false);
            this.tpConfigure.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgChannels)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mixerConfigBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.channelsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpConfigure;
        private System.Windows.Forms.TabPage tpControl;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.BindingSource mixerConfigBindingSource;
        private System.Windows.Forms.Button btnRefreshDevices;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbDevices;
        private System.Windows.Forms.DataGridView dgChannels;
        private System.Windows.Forms.BindingSource channelsBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Channel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Control;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mute;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.CheckBox chk01v96;
        private System.Windows.Forms.CheckBox chkTest;
    }
}
