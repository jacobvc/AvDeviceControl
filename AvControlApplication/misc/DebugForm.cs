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
using Visca;

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

        public void LogAction(LogLevel level, string text)
        {
            Color[] colors = new Color[] { 
                Color.Green,        // Trace
                Color.Blue,         // Debug
                Color.Black,        // Info
                Color.Orange,       // Warning
                Color.Red,          // Error
                Color.Purple };     // None == Special use
            if (InvokeRequired)
            {
                Invoke(new Action<LogLevel, string>(LogAction), level, text);
            }
            else
            {
                if (txtDebug.Lines.Length > numMaxLines.Value)
                {
                    // For now, just clear when it gets too big
                    txtDebug.Clear();
                    /*
                    List<string> lines = new List<string>(txtDebug.Lines);
                    while (lines.Count >= numMaxLines.Value)
                    {
                        lines.RemoveAt(0); // Remove the top elements
                    }
                    txtDebug.Lines = lines.ToArray();
                    */
                }
                txtDebug.SelectionColor = colors[(byte)level];
                txtDebug.AppendText(text + Environment.NewLine);
                txtDebug.SelectionColor = Color.Black;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDebug.Clear();
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
