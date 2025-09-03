using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Controls;
using System.Windows.Forms;
using Visca;

namespace AVDeviceControl
{
    public partial class DebugForm : Form
    {
        public DebugForm()
        {
            InitializeComponent();
            pnlKey.Visible = false;
        }

        public RichTextBox TextBox
        {
            get { return rtfDebug; }
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
                if (rtfDebug.Lines.Length > numMaxLines.Value)
                {
                    // For now, just clear when it gets too big
                    rtfDebug.Clear();
                    /*
                    List<string> lines = new List<string>(rtfDebug.Lines);
                    while (lines.Count >= numMaxLines.Value)
                    {
                        lines.RemoveAt(0); // Remove the top elements
                    }
                    rtfDebug.Lines = lines.ToArray();
                    */
                }
                rtfDebug.SelectionColor = colors[(byte)level];
                rtfDebug.AppendText(text + Environment.NewLine);
                rtfDebug.SelectionColor = Color.Black;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            rtfDebug.Clear();
        }

        private void btnKey_MouseDown(object sender, MouseEventArgs e)
        {
            pnlKey.Visible = true;
        }

        private void btnKey_MouseUp(object sender, MouseEventArgs e)
        {
            pnlKey.Visible = false;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            rtfDebug.SelectAll();
            rtfDebug.SelectionBackColor = Color.White;
            var Options = RichTextBoxFinds.None;
            int StartIndex = 0;
            if (txtFind.Text.Length > 0 && rtfDebug.Text.Length > 0)
            {
                while ((StartIndex = rtfDebug.Find(txtFind.Text, 
                  StartIndex, Options)) != -1)
                {
                    rtfDebug.Focus();
                    rtfDebug.Select(StartIndex, txtFind.Text.Length);
                    rtfDebug.SelectionBackColor = Color.Yellow;
                    StartIndex += txtFind.Text.Length;
                }
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
