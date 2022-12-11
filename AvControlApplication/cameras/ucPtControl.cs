using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media.Media3D;
//using System.Windows.Media.Media3D;
using HelixToolkit;
using HelixToolkit.Wpf;

namespace AVDeviceControl
{
    public partial class ucPtControl : System.Windows.Forms.UserControl
    {
        public class Data
        {
            public System.Drawing.Point value;
            public static int min_X = -10;
            public static int range_X = 20;
            public static int min_Y = -10;
            public static int range_Y = 20;

            public int Min_X { get { return min_X; } }
            public int Range_X { get { return range_X; } }
            public int Min_Y { get { return min_Y; } }
            public int Range_Y { get { return range_Y; } }

            public Data(System.Drawing.Point value)
            {
                this.value = value;
            }
        }

        HelixViewport3D viewport;

        bool isMoving = false;
        readonly int divisions = 3;
        System.Drawing.Point previousPoint = System.Drawing.Point.Empty;
        private double panAngle = 0;
        private double tiltAngle = 0;
        private bool debugMode = false;

        bool firing = false;
        private float zoomFraction = 0;

        public delegate void PanTiltValueChangedEvent(object sender, Data data);

        [Description("Event when value has changed")]
        [Category("Property Changed")]
        public event PanTiltValueChangedEvent ValueChanged = null;

        [Description("The color used to draw circles on the base plane")]
        [Category("Settings")]
        public Color ColorBasePlane { get; set; } = Color.RoyalBlue;
        [Description("The color used to indicate position arcs")]
        [Category("Settings")]
        public Color ColorPosition { get; set; } = Color.SteelBlue;
        [Description("The color used to draw the camera itself")]
        [Category("Settings")]
        public Color ColorCamera { get; set; } = Color.ForestGreen;
        [Description("Pan angle (initialized in static control")]
        [Category("Settings")]
        public double AnglePan { get => panAngle; 
          set { panAngle = value; ucWpfPtControl.Pan = value; } }
        [Description("Tilt angle (initialized in static control")]
        [Category("Settings")]
        public double AngleTilt { get => tiltAngle; 
          set { tiltAngle = value; ucWpfPtControl.Tilt = value; } }
        [Description("Rotation for projecting view")]
        [Category("Settings")]
        public float OrthoRotation { get; set; } = -45;
        [Description("3D base plane size reduction (distance from yop of control")]
        [Category("Settings")]
        public int RadiusReduction { get; set; } = 2;
        [Description("Elliptical - out of round")]
        [Category("Settings")]
        public int OblongY { get; set; } = 7;
        [Description("Provide some debug operations")]
        [Category("Settings")]
        public bool DebugMode
        {
            get { return debugMode; }
            set { debugMode = value; udPan.Visible = value; udTilt.Visible = value; }
        }
        [Description("Current zoom 0 to 1")]
        [Category("Settings")]
        public float ZoomFraction { get => zoomFraction; 
          set { zoomFraction = value; ucWpfPtControl.Zoom = value; } }
        [Description("Diameter to display lense")]
        [Category("Settings")]
        public int LensDiamater { get; set; } = 7;

        public ucPtControl()
        {
            InitializeComponent();
            slidTilt.Minimum = Data.min_Y;
            slidTilt.Maximum = Data.range_Y + Data.min_Y;
            slidTilt.Value = Data.min_Y + Data.range_Y / 2;
            slidPan.Minimum = Data.min_X;
            slidPan.Maximum = Data.range_X + Data.min_X;
            slidPan.Value = Data.min_X + Data.range_X / 2;

            ucWpfPtControl.MouseUp += PanTilt_MouseUp;
            ucWpfPtControl.MouseDown += PanTilt_MouseDown;
            ucWpfPtControl.MouseMove += PanTilt_MouseMove;
        }

        private void PanTilt_MouseDown(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Cross;
            DrawPoint(e.Location);
            isMoving = true;
        }

        private void PanTilt_MouseUp(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Default;
            isMoving = false;
            DrawPoint(System.Drawing.Point.Empty);
        }

        private void PanTilt_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMoving)
            {
                DrawPoint(e.Location);
            }
        }

        private void DrawPoint(System.Drawing.Point newPoint)
        {
            int x = 0;
            int y = 0;
            if (newPoint != System.Drawing.Point.Empty)
            {
                // Update previous point
                newPoint.X = Math.Max(0, Math.Min(newPoint.X, pnlPt.Width));
                newPoint.Y = Math.Max(0, Math.Min(newPoint.Y, pnlPt.Height));

                x = (int)(newPoint.X * Data.range_X / pnlPt.Width + Data.min_X);
                y = -(int)(newPoint.Y * Data.range_Y / pnlPt.Height + Data.min_Y);
            }
            ChangedEvent(x, y);
        }

        void ChangedEvent(int pan, int tilt)
        {
            if (!firing)
            {
                firing = true;
                slidPan.Value = pan;
                slidTilt.Value = tilt;
                System.Drawing.Point newPoint = new System.Drawing.Point(pan, tilt);
                if (!previousPoint.Equals(newPoint))
                {

                    this.CreateGraphics().FillRectangle(new SolidBrush(Color.White),
                       new Rectangle(0, 2, 38, 14));

                    this.CreateGraphics().DrawString(newPoint.X + "," + newPoint.Y,
                       this.Font, Brushes.Black, new System.Drawing.Point(0, 2));

                    if (ValueChanged != null)
                    {
                        if (newPoint == System.Drawing.Point.Empty)
                        {
                            ValueChanged(this, new Data(new System.Drawing.Point(0, 0)));
                        }
                        else
                        {
                            ValueChanged(this, new Data(newPoint));
                        }
                    }
                    previousPoint = newPoint;
                }
                firing = false;
            }
        }

        private void udPosition_ValueChanged(object sender, EventArgs e)
        {
            AnglePan = (double)udPan.Value;
            AngleTilt = (double)udTilt.Value;
            Invalidate();
        }

        private void slidTilt_MouseUp(object sender, MouseEventArgs e)
        {
            slidTilt.Value = 0;
        }

        private void slidTilt_ValueChanged(object sender, EventArgs e)
        {
            ChangedEvent(previousPoint.X, (int)slidTilt.Value);
        }

        private void slidPan_MouseUp(object sender, MouseEventArgs e)
        {
            slidPan.Value = 0;
        }

        private void slidPan_ValueChanged(object sender, EventArgs e)
        {
            ChangedEvent((int)slidPan.Value, previousPoint.Y);
        }
    }
}
