using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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

        public RichTextBox TextBox
        {
            get { return txtDebug; }
        }

        public void LogAction(byte level, string text)
        {
            Color[] colors = new Color[] { 
                Color.Purple,       // Trace
                Color.Blue,         // Debug
                Color.Black,        // Info
                Color.Orange,       // Warning
                Color.Red,          // Error
                Color.Purple };     // None == Special use
            if (InvokeRequired)
            {
                Invoke(new Action<byte, string>(LogAction), level, text);
            }
            else
            {
                txtDebug.SelectionColor = colors[level];
                txtDebug.AppendText(text + Environment.NewLine);
                txtDebug.SelectionColor = Color.Black;
                //txtDebug.SelectionStart = txtDebug.Text.Length;
                //txtDebug.ScrollToCaret();
            }
        }
    }
    public class TextBoxTraceListener : TraceListener
    {
        private RichTextBox _outputTextBox;

        public TextBoxTraceListener(RichTextBox outputTextBox)
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
