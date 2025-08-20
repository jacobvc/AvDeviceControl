using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AVDeviceControl
{
    public partial class DebugForm : Form
    {
        public DebugForm()
        {
            InitializeComponent();
        }

        public TextBox TextBox
        {
            get { return txtDebug; }
        }

        public void AddText(string text)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(AddText), text);
            }
            else
            {
                txtDebug.AppendText(text + Environment.NewLine);
                txtDebug.SelectionStart = txtDebug.Text.Length;
                txtDebug.ScrollToCaret();
            }
        }
    }
}
