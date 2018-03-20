using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLEAP
{
    public partial class Main
    {
        private void ConfigurePorts()
        {
            serialAPI.Handshake = System.IO.Ports.Handshake.RequestToSend;
            serialAPI.BaudRate = 115200;
            serialAPI.DataBits = 8;
            serialAPI.StopBits = System.IO.Ports.StopBits.One;
            serialAPI.Parity = System.IO.Ports.Parity.None;
            serialAPI.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(DataReceivedHandler);
        }

        private void ConnectToPort(String port)
        {
            Document("Opening serial port '" + comboPorts.SelectedValue.ToString() + "'..." + Environment.NewLine);
            serialAPI.PortName = port;
            serialAPI.Open();
            serialAPI.DiscardInBuffer();
            serialAPI.DiscardOutBuffer();
            Document("Port opened" + Environment.NewLine);
        }

        private void DataReceivedHandler(
                                object sender,
                                System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            System.IO.Ports.SerialPort sp = (System.IO.Ports.SerialPort)sender;
            Byte[] inData = new Byte[sp.BytesToRead];

            // Read all available bytes from serial port in one chunk
            try
            {
                sp.Read(inData, 0, inData.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                // TODO: Close serial port if it is open?
                return;
            }
            //ThreadSafeDelegate(delegate { txtLog.AppendText(String.Format("<= RX ({0}) [ {1}]", inData.Length, ByteArrayToHexString(inData)) + Environment.NewLine); });

            // Parse all bytes read through BGLib parser
            for (int i = 0; i < inData.Length; i++)
            {
                bglib.Parse(inData[i]);
            }
        }

        private Dictionary<String, String> GetPortList()
        {
            Dictionary<String, String> portList = new Dictionary<String, String>();

            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(@"Select * From Win32_SerialPort"))
            {
                foreach (ManagementObject port in searcher.Get())
                {
                    portList.Add((String)port["DeviceID"], (String)port["Caption"]);
                }
            }

            return portList;
        }
    }
}
