using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLEAP
{
    public partial class Main
    {
        /// <summary>
        /// Attach the selected USB device. If successful, begin the scanning procedure.
        /// </summary>
        private void AttachUSB()
        {
            // Open the port designated by comboPorts.SelectedValue
            Document("Opening serial port '" + comboPorts.SelectedValue + "'..." + Environment.NewLine);
            try
            {
                serialAPI.PortName = comboPorts.SelectedValue.ToString();
                serialAPI.Open();
                serialAPI.DiscardInBuffer();
                serialAPI.DiscardOutBuffer();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Document("Failed to open serial port" + Environment.NewLine);
                return;
            }
            Document(String.Format("{0} opened", serialAPI.PortName));
            btnAttach.Text = "Detach";
            statusCOM.Text = String.Format("{0}", comboPorts.SelectedValue);
            statusCOM.ForeColor = Color.Black;
            isAttached = true;

            // Begin scanning procedure
            GAPScan();
        }

        private void ConfigurePorts()
        {
            serialAPI.Handshake = System.IO.Ports.Handshake.RequestToSend;
            serialAPI.BaudRate = 115200;
            serialAPI.DataBits = 8;
            serialAPI.StopBits = System.IO.Ports.StopBits.One;
            serialAPI.Parity = System.IO.Ports.Parity.None;
            serialAPI.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(DataReceivedHandler);
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

            Document(String.Format("Data Received: {0}", ByteArrayToHexString(inData)));

            // Parse all bytes read through BGLib parser
            for (int i = 0; i < inData.Length; i++)
            {
                bglib.Parse(inData[i]);
            }
        }

        private void DetachUSB()
        {
            // TODO: If a connection is still active, disconnect from the device

            Document("Closing serial port..." + Environment.NewLine);
            try
            {
                serialAPI.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Document("Failed to close serial port" + Environment.NewLine);
                return;
            }
            Document(String.Format("{0} closed", serialAPI.PortName));
            btnAttach.Text = "Attach";
            statusCOM.Text = "COM";
            statusCOM.ForeColor = Color.Gray;
            isAttached = false;
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
