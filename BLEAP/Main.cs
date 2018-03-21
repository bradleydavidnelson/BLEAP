using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace BLEAP
{
    public partial class Main : Form
    {
        private Bluegiga.BGLib bglib = new Bluegiga.BGLib();
        private bool isAttached = false;

        // BLE Devices
        public Dictionary<UInt16, BTDevice> knownDevices = new Dictionary<UInt16, BTDevice>();
        public Dictionary<byte, BTDevice> devicesConnected = new Dictionary<byte, BTDevice>();
        public Dictionary<object, BTDevice> lookupFromButton = new Dictionary<object, BTDevice>();
        public Dictionary<object, BTDevice> resetDict = new Dictionary<object, BTDevice>();
        public Dictionary<object, BTDevice> lookupBySleepButton = new Dictionary<object, BTDevice>();
        public Dictionary<object, Button> timerDict = new Dictionary<object, Button>();
        public int discoveryCount = 0;
        public BTDevice connectedDevice = null;

        // Data log file
        static string saveFolder;

        // Measurement variables
        public int reference = 2500;    // ADC Reference voltage
        public int resolution = 2047;   // ADC Resolution
        //Timer connectingTimer;

        public int potValue = -1;

        // UUIDs (Little endian)
        private static Byte[] serviceUUID = new Byte[] { 0x80, 0x64, 0xBF, 0xCC, 0x8A, 0x5F, 0x11, 0x90, 0x4F, 0x48, 0x28, 0xA8, 0x18, 0xA3, 0x51, 0xA4 };
        private static Byte[] GTUUID = new Byte[] { 0x01, 0x64, 0xBF, 0xCC, 0x8A, 0x5F, 0x11, 0x90, 0x4F, 0x48, 0x28, 0xA8, 0x18, 0xA3, 0x51, 0xA4 };
        private static Byte[] pHUUID = new Byte[] { 0x02, 0x64, 0xBF, 0xCC, 0x8A, 0x5F, 0x11, 0x90, 0x4F, 0x48, 0x28, 0xA8, 0x18, 0xA3, 0x51, 0xA4 };
        private static Byte[] GWUUID = new Byte[] { 0x03, 0x64, 0xBF, 0xCC, 0x8A, 0x5F, 0x11, 0x90, 0x4F, 0x48, 0x28, 0xA8, 0x18, 0xA3, 0x51, 0xA4 };
        private static Byte[] dataUUID = new Byte[] { 0x66, 0xFE, 0xD5, 0x33, 0xF9, 0xB2, 0x14, 0xB1, 0xE7, 0x11, 0x20, 0x51, 0xC6, 0x74, 0x35, 0xAC };
        private static Byte[] controlUUID = new Byte[] { 0x5B, 0x97, 0xAC, 0xDE, 0x8A, 0xE4, 0x2B, 0x89, 0xFA, 0x46, 0xEF, 0x75, 0xBA, 0x16, 0x22, 0x93 };
        private static Byte[] phCalUUID = new Byte[] { 0x5C, 0x97, 0xAC, 0xDE, 0x8A, 0xE4, 0x00, 0x00, 0xE7, 0x11, 0x00, 0x00, 0xBA, 0x16, 0x22, 0x93 };
        private static Byte[] potUUID = new Byte[] { 0x66, 0xFE, 0xD5, 0x33, 0xF9, 0xB2, 0x14, 0xB1, 0xE7, 0x11, 0x1B, 0x55, 0xB6, 0xE3, 0xFA, 0x2A };
        private static Byte[] statusUUID = new Byte[] { 0xA0, 0xDB, 0xD3, 0x6A, 0x00, 0xA6, 0x7B, 0x85, 0xE7, 0x11, 0xA4, 0x70, 0xA6, 0x32, 0x1E, 0x74 };
        private static Byte[] temp2UUID = new Byte[] { 0xA1, 0xDB, 0xD3, 0x6A, 0x00, 0xA6, 0x7B, 0x85, 0xE7, 0x11, 0xA4, 0x70, 0xA6, 0x32, 0x1E, 0x74 };
        private static Byte[] railUUID = new Byte[] { 0xA0, 0xDB, 0xD3, 0x6A, 0x00, 0xA6, 0x7B, 0x85, 0xE7, 0x11, 0xA4, 0x70, 0xA6, 0x32, 0x1E, 0x75 };
        private static Byte[] phUUID = new Byte[] { 0x0A, 0xB5, 0xB6, 0x78, 0xC2, 0xCE, 0xC4, 0xAB, 0xE7, 0x11, 0xA5, 0xC0, 0x3C, 0xBA, 0x4E, 0x2F };

        // Device states
        public const UInt16 STATE_STANDBY = 0;
        public const UInt16 STATE_READY = 1;
        public const UInt16 STATE_CONNECTING = 2;
        public const UInt16 STATE_FINDING_SERVICES = 3;
        public const UInt16 STATE_FINDING_ATTRIBUTES = 4;
        public const UInt16 STATE_CHECKING_FLASH = 7;
        public const UInt16 STATE_ENABLING_INDICATIONS = 5;
        public const UInt16 STATE_DISCONNECTING = 6;
        public UInt16 currentProcedure = STATE_STANDBY;        // current application state

        // GUI components
        private List<Panel> discPanels = new List<Panel>();
        private List<Label> discLabels = new List<Label>();
        private List<Button> discButtons = new List<Button>();
        private TableLayoutPanel dataTable;

        private float phOffset = 0;

        private bool disableGraph = true;

        /// <summary>
        /// 
        /// </summary>
        public Main()
        {
            InitializeComponent();

            Configure();

            // initialize COM port combobox with list of ports
            try
            {
                comboPorts.DataSource = new BindingSource(GetPortList(), null); // If no serial devices are connected, the program will crash
                comboPorts.ValueMember = "Key";
                comboPorts.DisplayMember = "Value";
                ConfigurePorts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            bglib.BLEEventGAPScanResponse += new Bluegiga.BLE.Events.GAP.ScanResponseEventHandler(GAPScanResponseEvent);
            bglib.BLEEventConnectionStatus += new Bluegiga.BLE.Events.Connection.StatusEventHandler(ConnectionStatusEvent);
            bglib.BLEEventConnectionDisconnected += new Bluegiga.BLE.Events.Connection.DisconnectedEventHandler(ConnectionDisconnectedEvent);
            bglib.BLEEventATTClientGroupFound += new Bluegiga.BLE.Events.ATTClient.GroupFoundEventHandler(ATTClientGroupFoundEvent);
            bglib.BLEEventATTClientFindInformationFound += new Bluegiga.BLE.Events.ATTClient.FindInformationFoundEventHandler(ATTClientFindInformationFoundEvent);
            bglib.BLEEventATTClientProcedureCompleted += new Bluegiga.BLE.Events.ATTClient.ProcedureCompletedEventHandler(ATTClientProcedureCompletedEvent);
            bglib.BLEEventATTClientAttributeValue += new Bluegiga.BLE.Events.ATTClient.AttributeValueEventHandler(ATTClientAttributeValueEvent);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AttachDetachUSB(object sender, EventArgs e)
        {
            if (isAttached)
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
                Document(String.Format("{0} closed",serialAPI.PortName));
                btnAttach.Text = "Attach";
                statusCOM.Text = "COM";
                statusCOM.ForeColor = Color.Gray;
                isAttached = false;
            }
            else
            {
                // Open the port designated by comboPorts.SelectedValue
                Document("Opening serial port '" + comboPorts.SelectedValue + "'..." + Environment.NewLine);
                serialAPI.PortName = comboPorts.SelectedValue.ToString();
                try
                {
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
                Document(String.Format("{0} opened",serialAPI.PortName));
                btnAttach.Text = "Detach";
                statusCOM.Text = String.Format("{0}", comboPorts.SelectedValue);
                statusCOM.ForeColor = Color.Black;
                isAttached = true;

                GAPScan();
            }
        }

        /// <summary>
        /// Convert byte array to "55:44:33:22:11:00" string
        /// </summary>
        /// <param name="ba"></param>
        /// <returns></returns>
        public string ByteArrayToHexAddress(Byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            for (int i = ba.Length - 1; i > 0; i--)
            {
                hex.AppendFormat("{0:x2}:", ba[i]);
            }
            hex.AppendFormat("{0:x2}", ba[0]);
            return hex.ToString();
        }

        /// <summary>
        /// Convert byte array to "00 11 22 33 44 55 " string
        /// </summary>
        /// <param name="ba"></param>
        /// <returns></returns>
        public string ByteArrayToHexString(Byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2} ", b);
            return hex.ToString();
        }

        /// <summary>
        /// Converts the measured voltage to pH.
        /// </summary>
        /// <param name="raw">Raw measurement (mV)</param>
        /// <returns>pH</returns>
        private double CalculatePH(double raw)
        {
            double slope = 0.004;
            return (raw * slope) + phOffset;
        }

        private void Configure()
        {
            // Open config file
            //Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            // Configure save location
            saveFolder = ConfigurationManager.AppSettings.Get("SaveLocation");
            if (!Directory.Exists(saveFolder))
            {
                SetSaveLocation(null, null);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConnectToDevice(object sender, EventArgs e)
        {
            BTDevice device = lookupFromButton[(Button)sender];

            if (!device.isConnected)
            {
                ThreadSafeDelegate(delegate { ((Button)sender).Text = "Connecting..."; });

                // Form a direct connection
                Byte[] cmd = bglib.BLECommandGAPConnectDirect(device.address, device.addrType, 0x20, 0x30, 0x100, 0); // 125ms interval, 125ms window, active scanning
                Document(String.Format("ble_cmd_gap_connect_direct: address=[{0}], address_type={1}, conn_interval_min={2}, conn_interval_max={3}, timeout={4}, latency ={5}",
                    device.address, device.addrType, 0x20, 0x30, 0x100, 0));
                //Document(String.Format("=> TX ({0}) [ {1}]", cmd.Length, ByteArrayToHexString(cmd)) + Environment.NewLine);
                bglib.SendCommand(serialAPI, cmd);

                // update state
                currentProcedure = STATE_CONNECTING;

                // TODO Setup timer
            }
            else
            {
                Disconnect(device);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="device"></param>
        private void CreateLogFile(BTDevice device)
        {
            if (Directory.Exists(saveFolder))
            {
                // Basic header
                string header = "Uptime (ms),Sensor,ADC0 (mV)";

                if (device.attHandleDualData > 0)
                {
                    header = header + ",ADC1 (mV)";
                }
                if (device.attHandlePH > 0)
                {
                    header = header + ",pH";
                }
                if (device.attHandleRail > 0)
                {
                    header = header + ",Supply (mV)";
                }
                if (device.attHandleTemp > 0)
                {
                    header = header + ",Temperature (C)";
                }

                // Generate the file
                device.filePath = saveFolder + "\\" + device.name + "_" + DateTime.Now.ToString("MMddyyyyhhmmss") + ".csv";
                using (StreamWriter output = new StreamWriter(device.filePath, false))
                {
                    output.WriteLine(header);
                }
            }
            else
            {
                MessageBox.Show("No save location specified. Data will not be recorded.");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="device">Device to transition to sleep mode</param>
        private void DeviceHandlerSleep(BTDevice device)
        {
            device.isAwake = false;
            ThreadSafeDelegate(delegate { device.sleepButton.Text = "Wake"; });
            ThreadSafeDelegate(delegate { device.sleepButton.Enabled = true; });

            // Empty table
            foreach (Label tableElement in device.labels)
            {
                ThreadSafeDelegate(delegate { tableElement.Text = ""; });
            }
            ThreadSafeDelegate(delegate { device.nameLabel.Text = device.name; });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="device">Device to transition to wake mode</param>
        private void DeviceHandlerWake(BTDevice device)
        {
            device.isAwake = true;
            ThreadSafeDelegate(delegate { device.sleepButton.Text = "Sleep"; });
            ThreadSafeDelegate(delegate { device.sleepButton.Enabled = true; });
        }

        private void Disconnect(BTDevice device)
        {
            currentProcedure = STATE_DISCONNECTING;

            // Enter sleep mode
            Byte[] cmd = bglib.BLECommandATTClientAttributeWrite(device.connection, device.attHandleControl, new Byte[] { 0x00 });
            Document(String.Format("ble_cmd_att_client_attribute_write: connection={0}, chrhandle={1}, data=[ 00 ]",
                device.connection, device.attHandleControl));
            bglib.SendCommand(serialAPI, cmd);

            // Disconnect from the specified device
            cmd = bglib.BLECommandConnectionDisconnect(device.connection);
            Document(String.Format("ble_cmd_connection_disconnect: connection={0}", device.connection));
            bglib.SendCommand(serialAPI, cmd);

            // Stop advertising
            cmd = bglib.BLECommandGAPEndProcedure();
            Document(String.Format("ble_cmd_gap_end_procedure"));
            bglib.SendCommand(serialAPI, cmd);

            // Reset GAP Mode
            cmd = bglib.BLECommandGAPSetMode(0, 0);
            Document("ble_cmd_gap_set_mode: discover=0, connect=0");
            bglib.SendCommand(serialAPI, cmd);

            // TODO Update interface
            ThreadSafeDelegate(delegate { device.connectButton.Text = "Connect"; });
            //ThreadSafeDelegate(delegate { device.sleepButton.Enabled = false; });
            //ThreadSafeDelegate(delegate { device.sleepButton.Text = ""; });

            // Update state
            currentProcedure = STATE_STANDBY;

            GAPScan();
        }

        /// <summary>
        /// Extracts advertised services from the advertisement data.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private List<byte[]> ExtractServices(byte[] data)
        {
            // Extract advertised service information from packet
            List<Byte[]> ad_services = new List<Byte[]>();
            Byte[] this_field = { };
            int bytes_left = 0;
            int field_offset = 0;
            for (int i = 0; i < data.Length; i++)
            {
                if (bytes_left == 0)
                {
                    bytes_left = data[i];
                    this_field = new Byte[data[i]];
                    field_offset = i + 1;
                }
                else
                {
                    this_field[i - field_offset] = data[i];
                    bytes_left--;
                    if (bytes_left == 0)
                    {
                        if (this_field[0] == 0x02 || this_field[0] == 0x03)
                        {
                            // partial or complete list of 16-bit UUIDs
                            ad_services.Add(this_field.Skip(1).Take(2).ToArray());
                        }
                        else if (this_field[0] == 0x04 || this_field[0] == 0x05)
                        {
                            // partial or complete list of 32-bit UUIDs
                            ad_services.Add(this_field.Skip(1).Take(4).ToArray());
                        }
                        else if (this_field[0] == 0x06 || this_field[0] == 0x07)
                        {
                            // partial or complete list of 128-bit UUIDs
                            ad_services.Add(this_field.Skip(1).Take(16).ToArray());
                        }
                    }
                }
            }

            return ad_services;
        }

        /// <summary>
        /// 
        /// </summary>
        private void GAPScan()
        {
            Byte[] cmd;

            // Set scan parameters
            cmd = bglib.BLECommandGAPSetScanParameters(0xC8, 0xC8, 1); // 125ms interval, 125ms window, active scanning
            Document(String.Format("ble_cmd_gap_set_scan_parameters: scan_interval=[ {0}], scan_window=[ {1}], active={2}",
                "00 c8 ", "00 c8 ", "1"));
            bglib.SendCommand(serialAPI, cmd);

            // Begin scanning for BLE peripherals
            cmd = bglib.BLECommandGAPDiscover(1); // generic discovery mode
            Document("ble_cmd_gap_discover: mode=1");
            bglib.SendCommand(serialAPI, cmd);

            // Update state
            currentProcedure = STATE_READY;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenCalibrationForm(object sender, EventArgs e)
        {
            CalibratePH calForm = new CalibratePH(this);
            calForm.Show();
        }

        private void Quit(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Reset the USB receiver.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetAll(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure?", "Reset All...", MessageBoxButtons.YesNo);

            // TODO This should only be an option is the USB device is attached.

            if (result == DialogResult.Yes)
            {
                // Reset
                Document("Resetting access point..." + Environment.NewLine);

                Byte[] cmd = bglib.BLECommandSystemReset(0);
                Document("ble_cmd_system_reset: boot_in_dfu=0");
                bglib.SendCommand(serialAPI, cmd);

                isAttached = false;
                btnAttach.Text = "Attach";

                // TODO Clear everything
            }
        }

        /// <summary>
        /// Sets a new save folder from a dialog box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetSaveLocation(object sender, EventArgs e)
        {
            // Open "Save As..." dialog
            DialogResult result = dialogSaveAs.ShowDialog();

            // If a directory was specified...
            if (result == DialogResult.OK)
            {
                saveFolder = dialogSaveAs.SelectedPath;

                try
                {
                    // Open the config file
                    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                    // Update the config file
                    if (config.AppSettings.Settings["SaveLocation"] == null)
                    {
                        config.AppSettings.Settings.Add(new KeyValueConfigurationElement("SaveLocation", ""));
                    }
                    config.AppSettings.Settings["SaveLocation"].Value = saveFolder;
                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);
                }
                catch (ConfigurationErrorsException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

            // If a directory was not specified...
            else if (result == DialogResult.Cancel)
            {
                if (!Directory.Exists(saveFolder))
                {
                    MessageBox.Show("No valid directory has been specified. Data will not be recorded.");
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void SetPHOffset(float value)
        {
            byte[] cmd = bglib.BLECommandATTClientAttributeWrite(connectedDevice.connection, connectedDevice.attHandlePHCal, BitConverter.GetBytes(value));
            Document(String.Format("ble_cmd_att_client_attribute_write: handle={0}, att_handle={1}, data=[ {2}]",
                connectedDevice.connection, connectedDevice.attHandlePHCal, ByteArrayToHexString(BitConverter.GetBytes(value))));
            bglib.SendCommand(serialAPI, cmd);

            phOffset = value;
        }

        /// <summary>
        /// Thread-safe operations from event handlers
        /// I love StackOverflow: http://stackoverflow.com/q/782274
        /// </summary>
        /// <param name="method"></param>
        public void ThreadSafeDelegate(MethodInvoker method)
        {
            if (InvokeRequired)
                BeginInvoke(method);
            else
                method.Invoke();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToggleComVisibility(object sender, EventArgs e)
        {
            if (splitCom.Panel1Collapsed)
            {
                splitCom.Panel1Collapsed = false;
                menuViewCom.Checked = true;
            }
            else
            {
                splitCom.Panel1Collapsed = true;
                menuViewCom.Checked = false;
            }
        }

        private void ToggleGraphVisibility(object sender, EventArgs e)
        {
            if (splitData.Panel2Collapsed)
            {
                splitData.Panel2Collapsed = false;
                menuViewGraph.Checked = true;
            }
            else
            {
                splitData.Panel2Collapsed = true;
                menuViewGraph.Checked = false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToggleLogVisibility(object sender, EventArgs e)
        {
            if (splitLog.Panel2Collapsed)
            {
                splitLog.Panel2Collapsed = false;
                menuViewLog.Checked = true;
            }
            else
            {
                splitLog.Panel2Collapsed = true;
                menuViewLog.Checked = false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newData"></param>
        private void UpdateLog(BTDevice device, double[] newData)
        {
            double period = (device.currTime - device.prevTime) / newData.Length;

            // Write data to output file
            using (StreamWriter output = new StreamWriter(device.filePath, true))
            {
                if (device.attHandleDualData == 0)
                {
                    for (int k = 0; k < newData.Length; k++)
                    {
                        string outputLine = String.Format("{0},{1},{2}",
                            device.currTime - (((newData.Length - 1) - k) * period),
                            device.name,
                            newData[k]);

                        if (device.attHandlePH > 0)
                        {
                            double pHValue = CalculatePH(newData[k]);
                            outputLine = outputLine + String.Format(",{0}", pHValue);
                        }
                        if (device.attHandleRail > 0)
                        {
                            outputLine = outputLine + String.Format(",{0}", device.rail);
                        }
                        if (device.attHandleTemp > 0)
                        {
                            outputLine = outputLine + String.Format(",{0:0.0}", device.temp);
                        }
                        if (device.attHandlePot > 0)
                        {
                            outputLine = outputLine + String.Format(",{0}", potValue);
                        }
                        output.WriteLine(outputLine);
                    }
                }
                else
                {
                    for (int k = 0; k < newData.Length / 2; k = k + 2)
                    {
                        string outputLine = String.Format("{0},{1},{2},{3}",
                            device.currTime - (((newData.Length - 1) - k) * period),
                            device.name,
                            newData[k],
                            newData[k + 1]);

                        // No pH
                        if (device.attHandleRail > 0)
                        {
                            outputLine = outputLine + String.Format(",{0}", device.rail);
                        }
                        if (device.attHandleTemp > 0)
                        {
                            outputLine = outputLine + String.Format(",{0:0.0}", device.temp);
                        }
                        if (device.attHandlePot > 0)
                        {
                            outputLine = outputLine + String.Format(",{0}", potValue);
                        }
                        output.WriteLine(outputLine);
                    }
                }
            }
        }

        /// <summary>
        /// Adds newly received data to the plot.
        /// </summary>
        /// <param name="newData">Contains new Y-values to add.</param>
        private void UpdatePlot(BTDevice device, double[] newData)
        {
            if (disableGraph)
            {
                return;
            }
            
            // Display past data for some time period:
            double secondsToDisplay = -10;

            ThreadSafeDelegate(delegate
            {
                dataChart.ChartAreas["ChartArea"].AxisX.Maximum = 0;
                dataChart.ChartAreas["ChartArea"].AxisX.Minimum = secondsToDisplay;
                dataChart.ChartAreas["ChartArea"].AxisX.Title = "Time (s)";
                dataChart.ChartAreas["ChartArea"].AxisY.Title = "Data (mV)";
            });

            // First, add new data
            double period = (device.currTime - device.prevTime) / newData.Length;
            for (int k = 0; k < newData.Length; k++)
            {
                double xValue = (k * period) / 1000; // in seconds
                double yValue = newData[k];
                ThreadSafeDelegate(delegate { dataChart.Series[device.name].Points.AddXY(xValue, yValue); });
            }

            // Second, shift all data left and remove old data
            double secToShift = (device.currTime - device.prevTime) / 1000;
            ThreadSafeDelegate(delegate
            {
                Collection<DataPoint> dataToRemove = new Collection<DataPoint>();
                foreach (DataPoint dataPoint in dataChart.Series[device.name].Points)
                {
                    dataPoint.XValue = dataPoint.XValue - secToShift;
                    if (dataPoint.XValue <= secondsToDisplay)
                    {
                        dataToRemove.Add(dataPoint);
                    }
                }
                foreach (DataPoint dataPoint in dataToRemove)
                {
                    dataChart.Series[device.name].Points.Remove(dataPoint);
                }
            });

            // Finally, refresh
            ThreadSafeDelegate(delegate { dataChart.Refresh(); });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="device"></param>
        /// <param name="newData"></param>
        private void UpdateTable(BTDevice device, double[] newData)
        {
            // Display in labels
            TimeSpan t = TimeSpan.FromMilliseconds(device.currTime);
            String timeString = String.Format("{0:D2}:{1:D2}:{2:D2}:{3:D2}.{4:D2}", t.Days, t.Hours, t.Minutes, t.Seconds, t.Milliseconds);
            ThreadSafeDelegate(delegate { device.uptimeLabel.Text = Convert.ToString(timeString); });
            ThreadSafeDelegate(delegate { device.ADC0Label.Text = Convert.ToString(newData[newData.Length - 1]); });

            // TODO: Handle pH mode
        }

        private void Document(String s)
        {
            if (!s.EndsWith(Environment.NewLine))
            {
                s = s + Environment.NewLine;
            }
            Console.Write(s);
            ThreadSafeDelegate(delegate { txtLog.AppendText(s); });
        }

        private void Exit(object sender, FormClosingEventArgs e)
        {
            // TODO handle this.
        }
    }
}
