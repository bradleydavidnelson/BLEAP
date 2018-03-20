using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLEAP
{
    public partial class Main
    {
        /// <summary>
        /// This event indicates when an advertisement packet is received.
        /// Once all advertisement info has been received, relevant devices are added to the discovery panel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void GAPScanResponseEvent(object sender, Bluegiga.BLE.Events.GAP.ScanResponseEventArgs e)
        {
            String log = String.Format("ble_evt_gap_scan_response: rssi={0}, packet_type={1}, sender=[ {2}], address_type={3}, bond={4}, data=[ {5}]" + Environment.NewLine,
                (SByte)e.rssi,
                e.packet_type,
                ByteArrayToHexString(e.sender),
                e.address_type,
                e.bond,
                ByteArrayToHexString(e.data)
                );
            Document(log);

            // Convert the address to an integer to use as a dictionary key
            UInt16 senderKey = BitConverter.ToUInt16(e.sender, 0);

            // If the device is not in our dictionary, add it.
            if (knownDevices.ContainsKey(senderKey) == false)
            {
                knownDevices.Add(senderKey, new BTDevice());
                knownDevices[senderKey].address = e.sender;
                knownDevices[senderKey].addrType = e.address_type;
                knownDevices[senderKey].hasService = false;
                knownDevices[senderKey].isListed = false;
            }

            BTDevice device = knownDevices[senderKey];

            // If the device is unlisted: decode the packet
            if (device.isListed == false)
            {
                // Connectable Advertisement Packet (0x00)
                // This packet includes the services advertised by the device
                if (e.packet_type == (byte)0)
                {
                    List<byte[]> services = ExtractServices(e.data);

                    // Check for custom service UUIDs
                    if (services.Any(a => a.SequenceEqual(serviceUUID)))
                    {
                        device.hasService = true;
                    }
                }

                if (device.hasService)
                {
                    Label lbl = new Label();
                    Button btn = new Button();

                    ThreadSafeDelegate(delegate
                    {
                        // Name Label
                        lbl.Anchor = AnchorStyles.Left;
                        lbl.AutoSize = true;
                        lbl.Text = device.name + Environment.NewLine + ByteArrayToHexAddress(device.address);

                        // Connect Button
                        btn.Anchor = AnchorStyles.Right;
                        btn.Size = new Size(70, 23);
                        btn.Text = "Connect";
                        btn.Click += new EventHandler(ConnectToDevice);
                        btn.BringToFront();
                        lookupFromButton.Add(btn, device);

                        // Add components to lists
                        discLabels.Add(lbl);
                        discButtons.Add(btn);

                        // Add components to the device dictionary
                        device.discoveryLabel = lbl;
                        device.connectButton = btn;
                        device.isListed = true;

                        discoveryTable.Controls.Add(lbl, 0, discoveryTable.RowCount - 1);
                        discoveryTable.Controls.Add(btn, 1, discoveryTable.RowCount - 1);
                        discoveryTable.RowCount++;

                        // Create indications queue
                        device.attHandleCCC = new Queue<ushort>();
                    });

                    device.isListed = true;
                }
            }

            // Scan Response Packet (0x04)
            // This packet includes the name of the device
            if (e.packet_type == (byte)4)
            {
                if (e.data.Length > 2)
                {
                    device.name = Encoding.ASCII.GetString(e.data, 2, e.data.Length - 2);
                }
                else
                {
                    device.name = "(unnamed)";
                }
                
                if (device.discoveryLabel != null)
                {
                    ThreadSafeDelegate(delegate { device.discoveryLabel.Text = device.name + Environment.NewLine + ByteArrayToHexAddress(device.address); });
                }
            }
        }

        /// <summary>
        /// This event indicates when a connection has been established.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ConnectionStatusEvent(object sender, Bluegiga.BLE.Events.Connection.StatusEventArgs e)
        {
            String log = String.Format("ble_evt_connection_status: connection={0}, flags={1}, address=[ {2}], address_type={3}, conn_interval={4}, timeout={5}, latency={6}, bonding={7}" + Environment.NewLine,
                e.connection,
                e.flags,
                ByteArrayToHexString(e.address),
                e.address_type,
                e.conn_interval,
                e.timeout,
                e.latency,
                e.bonding
                );
            Document(log);

            // Has a new connection been established?
            if ((e.flags & 0x05) == 0x05)
            {
                try
                {
                    BTDevice device = knownDevices[BitConverter.ToUInt16(e.address, 0)];

                    connectedDevice = device;

                    // Add to the connection dictionary
                    devicesConnected.Add(e.connection, device);
                    device.connection = e.connection;

                    // Update the interface
                    foreach (BTDevice d in knownDevices.Values)
                    {
                        if (d.connectButton != null)
                        {
                            ThreadSafeDelegate(delegate { d.connectButton.Enabled = false; });
                        }
                    }
                    ThreadSafeDelegate(delegate { device.connectButton.Enabled = true; });
                    ThreadSafeDelegate(delegate { device.connectButton.Text = "Disconnect"; });

                    // The connection is established
                    device.isConnected = true;
                    Document(String.Format("Connected to {0}", ByteArrayToHexAddress(e.address)) + Environment.NewLine);

                    // Perform service discovery
                    Byte[] cmd = bglib.BLECommandATTClientReadByGroupType(e.connection, 0x0001, 0xFFFF, new Byte[] { 0x00, 0x28 }); // "service" UUID is 0x2800 (little-endian for UUID uint8array)
                    Document(String.Format("=> TX ({0}) [ {1}]", cmd.Length, ByteArrayToHexString(cmd)) + Environment.NewLine);
                    bglib.SendCommand(serialAPI, cmd);

                    // update state
                    currentProcedure = STATE_FINDING_SERVICES;
                }
                catch (KeyNotFoundException ex)
                {
                    // TODO Does this work??
                    MessageBox.Show(ex.ToString());

                    // Disconnect
                    currentProcedure = STATE_DISCONNECTING;

                    // Disconnect from the specified device
                    Byte[] cmd = bglib.BLECommandConnectionDisconnect(e.connection);
                    Document(String.Format("=> TX ({0}) [ {1}]", cmd.Length, ByteArrayToHexString(cmd)) + Environment.NewLine);
                    bglib.SendCommand(serialAPI, cmd);

                    // Stop advertising
                    cmd = bglib.BLECommandGAPEndProcedure();
                    Document(String.Format("=> TX ({0}) [ {1}]", cmd.Length, ByteArrayToHexString(cmd)) + Environment.NewLine);
                    bglib.SendCommand(serialAPI, cmd);

                    // Reset GAP Mode
                    cmd = bglib.BLECommandGAPSetMode(0, 0);
                    Document(String.Format("=> TX ({0}) [ {1}]", cmd.Length, ByteArrayToHexString(cmd)) + Environment.NewLine);
                    bglib.SendCommand(serialAPI, cmd);

                    // Update state
                    currentProcedure = STATE_STANDBY;

                    GAPScan();
                }
            }
        }

        /// <summary>
        /// This event is produced when a Bluetooth connection is disconnected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ConnectionDisconnectedEvent(object sender, Bluegiga.BLE.Events.Connection.DisconnectedEventArgs e)
        {
            String log = String.Format("ble_evt_connection_disconnected: connection={0}, reason={1}" + Environment.NewLine,
                e.connection,
                e.reason
                );
            Document(log);

            // Confirm that the device is in our dictionary
            if (devicesConnected.ContainsKey(e.connection))
            {
                BTDevice device = devicesConnected[e.connection];
                device.isConnected = false;

                // TODO not this
                connectedDevice = null;

                // Remove from list of connected devices
                devicesConnected.Remove(device.connection);

                // Change disconnect button
                foreach (BTDevice d in knownDevices.Values)
                {
                    // TODO Throws null reference exception
                    if (d.connectButton != null)
                    {
                        ThreadSafeDelegate(delegate { d.connectButton.Enabled = true; });
                    }
                }
                ThreadSafeDelegate(delegate { device.connectButton.Text = "Connect"; });

                if (dataTable != null)
                {
                    DisposeDataTable();
                }

                // Restart scanning
                GAPScan();

                // Disconntion from Link Supervision Timeout (0x0208)
                // When the device loses connection in this way, attempt to reconnect automatically
                if (e.reason == 520)
                {
                    // TODO: Handle link loss
                }
            }
        }

        /// <summary>
        /// This event is produced when an attribute group (a service) is found. Typically this event
        /// is produced after Read by Group Type command.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ATTClientGroupFoundEvent(object sender, Bluegiga.BLE.Events.ATTClient.GroupFoundEventArgs e)
        {
            String log = String.Format("ble_evt_attclient_group_found: connection={0}, start={1}, end={2}, uuid=[ {3}]" + Environment.NewLine,
                e.connection,
                e.start,
                e.end,
                ByteArrayToHexString(e.uuid)
                );
            Document(log);

            BTDevice device = devicesConnected[e.connection];

            // Check for custom service among services discovered
            if (e.uuid.SequenceEqual(serviceUUID))
            {
                // Search for attributes within custom service
                Document(String.Format("Found attribute group for custom service: start={0}, end={1}", e.start, e.end) + Environment.NewLine);
                device.attServiceStart = e.start;
                device.attServiceEnd = e.end;
            }
        }

        /// <summary>
        /// This event is generated when characteristics type mappings are found. This happens
        /// typically after Find Information command has been issued to discover all attributes of a
        /// service.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ATTClientFindInformationFoundEvent(object sender, Bluegiga.BLE.Events.ATTClient.FindInformationFoundEventArgs e)
        {
            String log = String.Format("ble_evt_attclient_find_information_found: connection={0}, chrhandle={1}, uuid=[ {2}]" + Environment.NewLine,
                e.connection,
                e.chrhandle,
                ByteArrayToHexString(e.uuid)
                );
            Document(log);

            BTDevice device = devicesConnected[e.connection];

            // Data packet attribute
            if (e.uuid.SequenceEqual(dataUUID))
            {
                Document(String.Format("Found attribute for data packet: handle={0}", e.chrhandle));
                device.attHandleData = e.chrhandle;
            }

            // Control attribute
            else if (e.uuid.SequenceEqual(controlUUID))
            {
                Document(String.Format("Found attribute for control packet: handle={0}", e.chrhandle));
                device.attHandleControl = e.chrhandle;
            }

            // Digital potentiometer attribute
            else if (e.uuid.SequenceEqual(potUUID))
            {
                Document(String.Format("Found attribute for potentiometer packet: handle={0}", e.chrhandle));
                device.attHandlePot = e.chrhandle;
            }

            // Temperature attribute (Status packet in older devices)
            else if (e.uuid.SequenceEqual(statusUUID))
            {
                Document(String.Format("Found attribute for temperature packet: handle={0}", e.chrhandle));
                device.attHandleTemp = e.chrhandle;
            }

            // Temperature2 attribute (Status packet in older devices)
            else if (e.uuid.SequenceEqual(temp2UUID))
            {
                Document(String.Format("Found attribute for temperature2 packet: handle={0}", e.chrhandle));
                device.attHandleTemp2 = e.chrhandle;
            }

            // Rail attribute
            else if (e.uuid.SequenceEqual(railUUID))
            {
                Document(String.Format("Found attribute for rail packet: handle={0}", e.chrhandle));
                device.attHandleRail = e.chrhandle;
            }

            // PH attribute
            else if (e.uuid.SequenceEqual(phUUID))
            {
                Document(String.Format("Found attribute for pH packet: handle={0}", e.chrhandle));
                device.attHandlePH = e.chrhandle;

            }

            // PH Calibration attribute
            else if (e.uuid.SequenceEqual(phCalUUID))
            {
                Document(String.Format("Found attribute for pHCal packet: handle={0}", e.chrhandle));
                device.attHandlePHCal = e.chrhandle;

            }

            // Client characteristic configuration attributes
            else if (e.uuid.SequenceEqual(new Byte[] { 0x02, 0x29 })) // Little endian
            {
                Document(String.Format("Found attribute for client characteristic configuration: handle={0}", e.chrhandle));
                device.attHandleCCC.Enqueue(e.chrhandle);
            }
        }

        /// <summary>
        /// This event is produced at the GATT client when an attribute protocol event is completed
        /// and a new operation can be issued. This event is for example produced after an Attribute
        /// Write command is successfully used to write a value to a remote device.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ATTClientProcedureCompletedEvent(object sender, Bluegiga.BLE.Events.ATTClient.ProcedureCompletedEventArgs e)
        {
            String log = String.Format("ble_evt_attclient_procedure_completed: connection={0}, result={1}, chrhandle={2}" + Environment.NewLine,
                e.connection,
                e.result,
                e.chrhandle
                );
            Console.Write(log);
            ThreadSafeDelegate(delegate { txtLog.AppendText(log); });

            BTDevice device = devicesConnected[e.connection];

            switch (currentProcedure)
            {
                // If we just finished searching for services...
                case STATE_FINDING_SERVICES:
                    // Was the custom service found?
                    if (device.attServiceEnd > 0)
                    {
                        // Search for attributes
                        Byte[] cmd = bglib.BLECommandATTClientFindInformation(e.connection, device.attServiceStart, device.attServiceEnd);
                        Document(String.Format("ble_cmd_att_client_find_information: connection={0}, start={1}, end={2}",
                            e.connection, device.attServiceStart, device.attServiceEnd));
                        //Document(String.Format("=> TX ({0}) [ {1}]", cmd.Length, ByteArrayToHexString(cmd)) + Environment.NewLine);
                        bglib.SendCommand(serialAPI, cmd);

                        // Update state
                        currentProcedure = STATE_FINDING_ATTRIBUTES;
                    }
                    else
                    {
                        Document("Could not find desired service." + Environment.NewLine);
                    }
                    break;

                // If we just finished searching for attributes within the discovered service...
                case STATE_FINDING_ATTRIBUTES:
                    // Were all necessary attributes found?
                    if (device.attHandleData > 0)
                    {
                        // TODO Generate data table
                        CreateDataTable(device);

                        // TODO Setup save file
                        CreateLogFile(device);

                        // Update state
                        if (device.attHandleCCC.Count > 0)
                        {
                            // Enable indications
                            Byte[] cmd = bglib.BLECommandATTClientAttributeWrite(e.connection, device.attHandleCCC.Peek(), new Byte[] { 0x03, 0x00 }); // Little endian
                            Document(String.Format("ble_cmd_att_client_attribute_write: connection={0}, att_handle={1}, data=[ {2}]",
                                e.connection, device.attHandleCCC.Peek(), "00 03 "));
                            //Document(String.Format("=> TX ({0}) [ {1}]", cmd.Length, ByteArrayToHexString(cmd)) + Environment.NewLine);
                            bglib.SendCommand(serialAPI, cmd);

                            currentProcedure = STATE_ENABLING_INDICATIONS;
                        }
                        else
                        {
                            currentProcedure = STATE_READY;

                            // Check sleep mode
                            Byte[] cmd = bglib.BLECommandATTClientReadByHandle(e.connection, device.attHandleControl);
                            Document(String.Format("ble_cmd_att_client_read_by_handle: connection={0}, handle={1}",
                                e.connection, device.attHandleControl));
                            //Document(String.Format("=> TX ({0}) [ {1}]", cmd.Length, ByteArrayToHexString(cmd)) + Environment.NewLine);
                            bglib.SendCommand(serialAPI, cmd);

                            // Allow multiple connections
                            //GAPScan();
                        }
                    }
                    else
                    {
                        Document("Could not find all attributes." + Environment.NewLine);
                    }
                    break;

                // Enable more indications if necessary
                case STATE_ENABLING_INDICATIONS:
                    // Indication was enabled, remove from queue
                    device.attHandleCCC.Dequeue();

                    // Are there more indications to enable?
                    if (device.attHandleCCC.Count > 0)
                    {
                        Byte[] cmd = bglib.BLECommandATTClientAttributeWrite(e.connection, device.attHandleCCC.Peek(), new Byte[] { 0x03, 0x00 }); // Little endian
                        Document(String.Format("ble_cmd_att_client_attribute_write: connection={0}, att_handle={1}, data=[ {2}]",
                                e.connection, device.attHandleCCC.Peek(), "00 03 "));
                        //ThreadSafeDelegate(delegate { txtLog.AppendText(String.Format("=> TX ({0}) [ {1}]", cmd.Length, ByteArrayToHexString(cmd)) + Environment.NewLine); });
                        bglib.SendCommand(serialAPI, cmd);

                    }
                    else
                    {
                        currentProcedure = STATE_READY;

                        // Check flash memory
                        if (device.attHandlePHCal > 0)
                        {
                            // Check sleep mode
                            Byte[] cmd2 = bglib.BLECommandATTClientReadByHandle(e.connection, device.attHandlePHCal);
                            Document(String.Format("ble_cmd_att_client_read_by_handle: connection={0}, handle={1}",
                                e.connection, device.attHandlePHCal));
                            //ThreadSafeDelegate(delegate { txtLog.AppendText(String.Format("=> TX ({0}) [ {1}]", cmd2.Length, ByteArrayToHexString(cmd2)) + Environment.NewLine); });
                            bglib.SendCommand(serialAPI, cmd2);
                        }

                        // Check sleep mode
                        Byte[] cmd = bglib.BLECommandATTClientReadByHandle(e.connection, device.attHandleControl);
                        Document(String.Format("ble_cmd_att_client_read_by_handle: connection={0}, handle={1}",
                            e.connection, device.attHandleControl));
                        //ThreadSafeDelegate(delegate { txtLog.AppendText(String.Format("=> TX ({0}) [ {1}]", cmd.Length, ByteArrayToHexString(cmd)) + Environment.NewLine); });
                        bglib.SendCommand(serialAPI, cmd);

                        // Allow multiple connections
                        //GAPScan();
                    }
                    break;

                // Are we fully connected?
                case STATE_READY:
                    // Was the control handle updated?
                    if (e.chrhandle == device.attHandleControl)
                    {
                        // Check sleep mode
                        Byte[] cmd = bglib.BLECommandATTClientReadByHandle(e.connection, device.attHandleControl);
                        Document(String.Format("ble_cmd_att_client_read_by_handle: connection={0}, handle={1}",
                            e.connection, device.attHandleControl));
                        //ThreadSafeDelegate(delegate { txtLog.AppendText(String.Format("=> TX ({0}) [ {1}]", cmd.Length, ByteArrayToHexString(cmd)) + Environment.NewLine); });
                        bglib.SendCommand(serialAPI, cmd);
                    }
                    break;

                case STATE_DISCONNECTING:
                    //DeviceHandlerSleep(device);

                    // Disconnect from the device
                    Disconnect(device);
                    GAPScan();

                    currentProcedure = STATE_READY;
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// This event is produced at the GATT client side when an attribute value is passed from the
        /// GATT server to the GATT client. This event is for example produced after a successful
        /// Read by Handle operation or when an attribute is indicated or notified by the remote
        /// device.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ATTClientAttributeValueEvent(object sender, Bluegiga.BLE.Events.ATTClient.AttributeValueEventArgs e)
        {
            String log = String.Format("ble_evt_attclient_attribute_value: connection={0}, atthandle={1}, type={2}, value=[ {3}]" + Environment.NewLine,
                e.connection,
                e.atthandle,
                e.type,
                ByteArrayToHexString(e.value)
                );
            Document(log);

            // What if we get connected to a device that isn't in our dictionary?
            if (devicesConnected.ContainsKey(e.connection) == false)
            {
                return;
            }

            BTDevice device = devicesConnected[e.connection];

            // DATA PACKET
            if (e.atthandle == device.attHandleData)
            {
                int length = e.value.Length / 2;

                // Decode packet
                // The following decodes each pair of bytes into a single data point
                double[] val = new double[length];
                for (int i = 0; i < length; i++)
                {
                    Int16 raw = BitConverter.ToInt16(e.value, 2 * i);
                    val[i] = raw * reference / resolution;
                }

                // TODO: Can we make this local in the other functions?
                device.currTime = device.timer.ElapsedMilliseconds;

                // Write the data
                UpdateLog(device, val);
                UpdateTable(device, val);
                UpdatePlot(device, val);

                device.prevTime = device.currTime;

                if (device.attHandlePH > 0)
                {
                    // TODO: Calculate pH
                    double ph = CalculatePH(val[length - 1]);

                    // Display
                    ThreadSafeDelegate(delegate { device.phLabel.Text = String.Format("{0:0.0}", ph); });
                }
            }

            // CONTROL PACKET
            if (e.atthandle == device.attHandleControl)
            {
                // Sleep bit
                if ((e.value[0] & 0x01) == 0x00) // Device is asleep
                {
                    DeviceHandlerSleep(device);
                }
                else if ((e.value[0] & 0x01) == 0x01) // Device is awake
                {
                    DeviceHandlerWake(device);
                }
            }

            // POTENTIOMETER PACKET
            if (e.atthandle == device.attHandlePot)
            {
                Console.WriteLine(ByteArrayToHexString(e.value));

                // Convert to number
                int value;

                if (BitConverter.IsLittleEndian)
                {
                    value = BitConverter.ToInt16(e.value.Reverse().ToArray(), 0) % 1024;
                }
                else
                {
                    value = BitConverter.ToInt16(e.value, 0) % 1024;
                }

                // TODO Update calibration
                //ThreadSafeDelegate(delegate { calForm.calBox.Value = value; });
            }

            // TEMPERATURE PACKET
            if (e.atthandle == device.attHandleTemp)
            {
                Document("Temp1");
                // new code: Temperature packet has 2 bytes
                if (e.value.Length == 2)
                {
                    // Get data
                    //Int16 data = BitConverter.ToInt16(e.value, 0);
                    Int16 value;
                    if (BitConverter.IsLittleEndian)
                    {
                        value = BitConverter.ToInt16(e.value, 0);
                        //value = BitConverter.ToInt16(e.value.Reverse().ToArray(), 0);
                    }
                    else
                    {
                        value = BitConverter.ToInt16(e.value.Reverse().ToArray(), 0);
                        //value = BitConverter.ToInt16(e.value, 0);
                    }

                    double Vo = value * reference / resolution;
                    Document(String.Format("Measured temperature: {0} mV", Vo));
                    // LMT89
                    device.temp = Math.Sqrt(2196200D + (1.8639D - (Vo/1000D)) / (0.00000388D)) - 1481.96D;

                    // Display temperature
                    ThreadSafeDelegate(delegate { device.tempLabel.Text = String.Format("{0:0.0}", device.temp); });
                }
            }

            // TEMPERATURE2 PACKET
            if (e.atthandle == device.attHandleTemp2)
            {
                Document("Temp2");
                Int16 value;
                if (BitConverter.IsLittleEndian)
                {
                    value = BitConverter.ToInt16(e.value, 0);
                }
                else
                {
                    value = BitConverter.ToInt16(e.value.Reverse().ToArray(), 0);
                }

                device.temp = (value * reference / resolution) * 10 / 45 - 169; // Not really characterized, but it should be close

                // Display temperature
                ThreadSafeDelegate(delegate { device.temp2Label.Text = String.Format("{0:0.0}", device.temp); });
            }

            // RAIL PACKET
            if (e.atthandle == device.attHandleRail)
            {
                if (e.value.Length == 2)
                {
                    // Get data
                    Int16 data = BitConverter.ToInt16(e.value, 0);

                    // Calculate rail
                    device.rail = data * reference / resolution;

                    // Display temperature
                    ThreadSafeDelegate(delegate { device.railLabel.Text = Convert.ToString(device.rail); });
                }
            }

            // PH OFFSET PACKET
            if (e.atthandle == device.attHandlePHCal)
            {
                phOffset = BitConverter.ToSingle(e.value, 0);
                Console.WriteLine("Offset at {0}", phOffset);
            }
        }
    }
}
