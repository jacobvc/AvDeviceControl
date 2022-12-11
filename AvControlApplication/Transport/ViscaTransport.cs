using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using System.IO.Ports;
using Visca;

namespace AVDeviceControl
{
    public abstract class ViscaTransport
    {
        public delegate void ReceiveData(byte[] data);
        public event ReceiveData receive;

        public abstract void Stop();
        public abstract string Start();
        public abstract void sendBytes(byte[] data);

        protected void DoReceive(byte[] data)
        {
            if (receive != null)
            {
                receive(data);
            }
        }
    }

    public class SerialViscaConfig
    {
        static public String[] SerialPorts
        {
            get
            {
                return SerialPort.GetPortNames();
            }
        }

        static public int[] BaudRates
        {
            get
            {
                return new int[] {
                    9600, 14400, 19200, 28800, 31250, 38400, 57600, 76800, 115200,
                    230400, 250000, 460800, 921600, 1000000 };
            }
        }
    }

    public class SerialViscaTransport : ViscaTransport
    {
        SerialPort serialPort = null;
        bool portActive = false;

        public string Port { get; }
        public int Baud { get; }

        public SerialViscaTransport(string port, int baud)
        {
            Port = port;
            Baud = baud;
        }

        void SerialStopThread()
        {
            if (serialPort != null)
            {
                portActive = false;
                try { serialPort.Close(); }
                catch (Exception) { }
                lock (serialPort)
                {
                    Thread.Sleep(1000);
                }

                serialPort.Dispose();
                serialPort = null;
            }
        }
        public override void Stop()
        {
            if (serialPort != null)
            {
                // WARNING WARNING If Invoke() is being used from DataReceived, DO NOT
                // Close() from the UI thread. It WILL deadlock!!
                ThreadStart th = new ThreadStart(SerialStopThread);
                new Thread(th).Start();
            }
        }

        public override string Start()
        {
            if (serialPort == null)
            {
                try
                {
                    serialPort = new SerialPort(Port, Baud);
                    serialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived);
                    serialPort.Open();
                    portActive = true;
                    return null;
                }
                catch (Exception ex)
                {
                    return "Can't open port: " + ex.Message;
                }
            }
            else
            {
                return "Serial port still stopping. Please try again.";
            }
        }

        public override void sendBytes(byte[] data)
        {
            if (serialPort != null && serialPort.IsOpen && portActive)
            {
                serialPort.Write(data, 0, data.Length);
            }
        }

        void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {

                int inBuffer;
                inBuffer = serialPort.BytesToRead;
                while (portActive && inBuffer > 0)
                {
                    byte[] byteBuffer = new byte[inBuffer];
                    serialPort.Read(byteBuffer, 0, inBuffer);
                    DoReceive(byteBuffer);
                    if (portActive)
                    {
                        inBuffer = serialPort.BytesToRead;
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
