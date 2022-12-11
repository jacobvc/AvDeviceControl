using HelixToolkit.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using static HelixToolkit.Wpf.PlyReader;

namespace AVDeviceControl
{
    public delegate void WpfValueChanged(double value);
    /// <summary>
    /// Interaction logic for UcWpfPtControl.xaml
    /// </summary>
    public partial class UcWpfPtControl : UserControl
    {
        #region Variables
        double nominalZoomConeH = 800;
        double zoomConeBase = 40;
        double minZoomHeight = 400;
        double _zoom = .50;
        double _pan = 0;
        double _tilt = 0;

        public event WpfValueChanged PanChanged;
        public event WpfValueChanged TiltChanged;
        public event WpfValueChanged ZoomChanged;

        public new event System.Windows.Forms.MouseEventHandler MouseUp;
        public new event System.Windows.Forms.MouseEventHandler MouseDown;
        public new event System.Windows.Forms.MouseEventHandler MouseMove;
        #endregion

        #region Constructor / Form Events
        public UcWpfPtControl()
        {
            InitializeComponent();

            base.MouseDown += UcWpfPtControl_MouseDown;
            base.MouseUp += UcWpfPtControl_MouseUp;
            base.MouseMove += UcWpfPtControl_MouseMove;
        }

        private void UcWpfPtControl_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            MouseMove?.Invoke(sender, ToMouseArgs(e));
        }

        private void UcWpfPtControl_MouseUp(object sender, MouseEventArgs e)
        {
            MouseUp?.Invoke(sender, ToMouseArgs(e));
        }

        private void UcWpfPtControl_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDown?.Invoke(sender, ToMouseArgs(e));
        }

        private System.Windows.Forms.MouseEventArgs ToMouseArgs(MouseEventArgs e)
        {
            System.Windows.Forms.MouseButtons fButton = System.Windows.Forms.MouseButtons.None;
            if (e.LeftButton == MouseButtonState.Pressed) {
                fButton |= System.Windows.Forms.MouseButtons.Left;
            }
            if (e.RightButton == MouseButtonState.Pressed)
            {
                fButton |= System.Windows.Forms.MouseButtons.Right;
            }
            if (e.MiddleButton == MouseButtonState.Pressed)
            {
                fButton |= System.Windows.Forms.MouseButtons.Middle;
            }
            if (e.XButton1 == MouseButtonState.Pressed)
            {
                fButton |= System.Windows.Forms.MouseButtons.XButton1;
            }
            if (e.XButton2 == MouseButtonState.Pressed)
            {
                fButton |= System.Windows.Forms.MouseButtons.XButton2;
            }
            Point pos = e.GetPosition(this);
            System.Windows.Forms.MouseEventArgs args = new System.Windows.Forms.MouseEventArgs(
                fButton, fButton == System.Windows.Forms.MouseButtons.None ? 0: 1, (int)pos.X, (int)pos.Y, 0 );

            return args;
        }



        private void Form_Load(object sender, RoutedEventArgs e)
        {
            Pan = 0;
            Tilt = 0;
            Zoom = _zoom;
        }
        #endregion

        #region Properties
        public double Pan
        {
            get { return _pan; }
            set
            {
                _pan = value;
                Dispatcher.Invoke(delegate ()
                {
                    panRotate.Angle = value;
                });
                if (PanChanged != null) PanChanged(value);
            }
        }
        public double Tilt
        {
            get { return _tilt; }
            set
            {
                _tilt = value;
                Dispatcher.Invoke(delegate ()
                {
                    tiltRotate.Angle = value;
                });
                if (TiltChanged != null) TiltChanged(value);
            }
        }
        public double Zoom
        {
            get
            {
                return _zoom;
            }
            set
            {
                _zoom = value;
                Dispatcher.Invoke(delegate ()
                {
                    zoomCone.TopRadius = zoomConeBase * (11 - _zoom * 10);
                    zoomCone.Height = minZoomHeight + (nominalZoomConeH
                      - minZoomHeight) * Math.Sin(Math.PI / 2 * _zoom);
                });
                if (ZoomChanged != null) ZoomChanged(value);
            }
        }
        #endregion

        #region Control Events
        private void Zoom_Changed(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Zoom = e.NewValue;
        }

        private void Pan_Changed(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Pan = e.NewValue;
        }

        private void Tilt_Changed(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Tilt = e.NewValue;
        }
        #endregion
    }
}
