using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using System.Windows.Forms;

namespace AVDeviceControl
{
    public class ucAvDevice : UserControl
    {
        public ucAvDevice() { }

        virtual public String DeviceName { get; }
        virtual public String Connect() { return "Not Implemented"; }
        virtual public void Disconnect() { }
        virtual public void SetSize(int clientHeight)
        {
            Size = new System.Drawing.Size(clientHeight * Width / Height, clientHeight);
        }
        virtual public void ConfigureMoveable(bool left, bool right) { }
    }
}
