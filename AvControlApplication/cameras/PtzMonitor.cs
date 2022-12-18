using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Visca;

namespace AVDeviceControl
{
    class PtzMonitor
    {
        public static bool IgnoreTimeoutConfig = true;
        public bool terminate = false;

        ViscaCamera camera;
        readonly AutoResetEvent msgActivity = new AutoResetEvent(false);
        System.Threading.Timer isRespondingTimer;
        int maxResponseMs = 2000;

        public PtzMonitor(ViscaCamera camera)
        {
            this.camera = camera;

            new Thread(new ThreadStart(StatusThread)).Start();
            isRespondingTimer = new System.Threading.Timer(
              RespondTimeout, this, Timeout.Infinite, Timeout.Infinite);
        }

        public System.Threading.Timer Timer { get { return isRespondingTimer; } }

        public void Track(int maxTimeMs = 2000)
        {
            maxResponseMs = maxTimeMs;
            msgActivity.Set();
        }
        public void Terminate()
        {
            terminate = true;
            msgActivity.Set();
        }

        public void Update()
        {
            Timer.Change(maxResponseMs, Timeout.Infinite);
            camera.PanTiltPositionPoll();
            camera.ZoomPositionPoll();
        }

        public void Arrived()
        {
            Timer.Change(Timeout.Infinite, Timeout.Infinite);
        }
        void StatusThread()
        {
            terminate = false;
            while (!terminate)
            {
                msgActivity.WaitOne();
                int count = 10;

                while (!terminate && --count > 0)
                {
                    Thread.Sleep(1000);
                    Update();
                }
            }

        }
        public bool ignoreTimeout = IgnoreTimeoutConfig;
        bool timeoutMsgbusy = false;
        static void RespondTimeout(object o)
        {
            PtzMonitor mon = o as PtzMonitor;
            if (mon != null)
            {
                if (!mon.ignoreTimeout && !mon.timeoutMsgbusy)
                {
                    mon.timeoutMsgbusy = true;
                    if (MessageBox.Show("Device doesn't appear to be responding.\r\nIgnore future warnings?", "Request timeout",
                        MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        mon.ignoreTimeout = true;
                    }
                    mon.timeoutMsgbusy = false;
                }
            }
        }
    }
}
