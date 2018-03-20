using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace BLEAP
{
    public partial class Main
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="device"></param>
        private void CreateDataTable(BTDevice device)
        {
            Document("Building data table...");
            dataTable = new TableLayoutPanel();
            dataTable.Dock = DockStyle.Fill;
            dataTable.RowCount = 3;

            device.labels = new List<Label>();

            int colIndex = 0;

            // Sensor name
            if (device.name != null)
            {
                Document("Sensor name found...");
                // Heading row
                Label nameHead = new Label();
                nameHead.AutoSize = true;
                nameHead.Font = new Font(DefaultFont, FontStyle.Bold);
                nameHead.Text = "Sensor";
                dataTable.Controls.Add(nameHead, colIndex, 0);

                // Device row
                device.nameLabel = new Label();
                device.nameLabel.AutoSize = true;
                device.nameLabel.Dock = DockStyle.Fill;
                device.nameLabel.Text = device.name;
                device.nameLabel.TextAlign = ContentAlignment.MiddleCenter;
                device.labels.Add(device.nameLabel);
                dataTable.Controls.Add(device.nameLabel, colIndex, 1);

                colIndex++;
            }

            // TODO Reset button
            /*ToolStripMenuItem resetItem = new ToolStripMenuItem();
            resetItem.Click += new EventHandler(ResetPeripheral);
            resetItem.Text = "Reset";
            ContextMenuStrip resetMenu = new ContextMenuStrip();
            resetMenu.Items.Add(resetItem);
            resetDict.Add(resetItem, device);*/

            // Sensor ADC0
            if (true)
            {
                Console.WriteLine("ADC0 attribute found...");
                // Heading row
                Label ADC0Head = new Label();
                ADC0Head.AutoSize = true;
                ADC0Head.Font = new Font(DefaultFont, FontStyle.Bold);
                ADC0Head.Text = "ADC0 (mV)";
                dataTable.Controls.Add(ADC0Head, colIndex, 0);

                // Device row
                device.ADC0Label = new Label();
                device.ADC0Label.AutoSize = true;
                device.ADC0Label.Dock = DockStyle.Fill;
                device.ADC0Label.Text = "";
                device.ADC0Label.TextAlign = ContentAlignment.MiddleCenter;
                device.labels.Add(device.ADC0Label);
                dataTable.Controls.Add(device.ADC0Label, colIndex, 1);

                colIndex++;
            }

            // Sensor ADC1
            if (device.attHandleDualData > 0)
            {
                Console.WriteLine("ADC1 attribute found...");
                // Heading row
                Label ADC1Head = new Label();
                ADC1Head.AutoSize = true;
                ADC1Head.Font = new Font(DefaultFont, FontStyle.Bold);
                ADC1Head.Text = "ADC1 (mV)";
                dataTable.Controls.Add(ADC1Head, colIndex, 0);

                // Device row
                device.ADC1Label = new Label();
                device.ADC1Label.AutoSize = true;
                device.ADC1Label.Dock = DockStyle.Fill;
                device.ADC1Label.Text = "";
                device.ADC1Label.TextAlign = ContentAlignment.MiddleCenter;
                device.labels.Add(device.ADC1Label);
                dataTable.Controls.Add(device.ADC1Label, colIndex, 1);

                colIndex++;
            }

            // pH measurement
            if (device.attHandlePH > 0)
            {
                Console.WriteLine("PH attribute found...");
                // Heading row
                Label phHead = new Label();
                phHead.AutoSize = true;
                phHead.Font = new Font(DefaultFont, FontStyle.Bold);
                phHead.Text = "pH";
                dataTable.Controls.Add(phHead, colIndex, 0);

                // Device row
                device.phLabel = new Label();
                device.phLabel.AutoSize = true;
                device.phLabel.Dock = DockStyle.Fill;
                device.phLabel.Text = "";
                device.phLabel.TextAlign = ContentAlignment.MiddleCenter;
                device.labels.Add(device.phLabel);
                dataTable.Controls.Add(device.phLabel, colIndex, 1);

                colIndex++;
            }

            // Supply rail label
            if (device.attHandleRail > 0)
            {
                Console.WriteLine("Rail attribute found...");
                // Heading row
                Label railHead = new Label();
                railHead.AutoSize = true;
                railHead.Font = new Font(DefaultFont, FontStyle.Bold);
                railHead.Text = "Supply (mV)";
                dataTable.Controls.Add(railHead, colIndex, 0);

                // Device row
                device.railLabel = new Label();
                device.railLabel.AutoSize = true;
                device.railLabel.Dock = DockStyle.Fill;
                device.railLabel.Text = "";
                device.railLabel.TextAlign = ContentAlignment.MiddleCenter;
                device.labels.Add(device.railLabel);
                dataTable.Controls.Add(device.railLabel, colIndex, 1);

                colIndex++;
            }

            // Temperature label
            if (device.attHandleTemp > 0)
            {
                Console.WriteLine("Temperature attribute found...");
                // Heading row
                Label tempHead = new Label();
                tempHead.AutoSize = true;
                tempHead.Font = new Font(DefaultFont, FontStyle.Bold);
                tempHead.Text = "Temp. (C)";
                dataTable.Controls.Add(tempHead, colIndex, 0);

                // Device row
                device.tempLabel = new Label();
                device.tempLabel.AutoSize = true;
                device.tempLabel.Dock = DockStyle.Fill;
                device.tempLabel.Text = "";
                device.tempLabel.TextAlign = ContentAlignment.MiddleCenter;
                device.labels.Add(device.tempLabel);
                dataTable.Controls.Add(device.tempLabel, colIndex, 1);

                colIndex++;
            }

            // Onboard Temperature label
            if (device.attHandleTemp2 > 0)
            {
                Console.WriteLine("Temperature2 attribute found...");
                // Heading row
                Label temp2Head = new Label();
                temp2Head.AutoSize = true;
                temp2Head.Font = new Font(DefaultFont, FontStyle.Bold);
                temp2Head.Text = "Temp. (C)";
                dataTable.Controls.Add(temp2Head, colIndex, 0);

                // Device row
                device.temp2Label = new Label();
                device.temp2Label.AutoSize = true;
                device.temp2Label.Dock = DockStyle.Fill;
                device.temp2Label.Text = "";
                device.temp2Label.TextAlign = ContentAlignment.MiddleCenter;
                device.labels.Add(device.temp2Label);
                dataTable.Controls.Add(device.temp2Label, colIndex, 1);

                colIndex++;
            }

            // Uptime label
            if (true)
            {
                Console.WriteLine("Creating uptime label...");
                // Heading row
                Label uptimeHead = new Label();
                uptimeHead.AutoSize = true;
                uptimeHead.Font = new Font(DefaultFont, FontStyle.Bold);
                uptimeHead.Text = "Uptime";
                dataTable.Controls.Add(uptimeHead, colIndex, 0);

                // Device row
                device.uptimeLabel = new Label();
                device.uptimeLabel.AutoSize = true;
                device.uptimeLabel.Dock = DockStyle.Fill;
                device.uptimeLabel.Text = "";
                device.uptimeLabel.TextAlign = ContentAlignment.MiddleLeft;
                device.labels.Add(device.uptimeLabel);
                dataTable.Controls.Add(device.uptimeLabel, colIndex, 1);

                colIndex++;
            }

            // Sleep/wake button
            if (device.attHandleControl > 0)
            {
                Console.WriteLine("Creating sleep/wake button...");
                // Heading row
                Label sleepHead = new Label();
                sleepHead.Anchor = AnchorStyles.Right;
                sleepHead.AutoSize = true;
                sleepHead.Font = new Font(DefaultFont, FontStyle.Bold);
                sleepHead.Text = "Sleep Mode";
                dataTable.Controls.Add(sleepHead, colIndex, 0);

                // Device row
                device.sleepButton = new Button();
                device.sleepButton.Anchor = AnchorStyles.Right;
                device.sleepButton.Click += new EventHandler(SleepWakeDevice);
                device.sleepButton.Size = new Size(70, 23);
                device.sleepButton.Text = "Wake";
                dataTable.Controls.Add(device.sleepButton, colIndex, 1);
                lookupBySleepButton.Add(device.sleepButton, device);

                colIndex++;
            }

            // Uptime stopwatch
            device.timer = new Stopwatch();
            device.timer.Restart();

            // Add table to interface
            ThreadSafeDelegate(delegate { splitData.Panel1.Controls.Add(dataTable); });

            if (!disableGraph)
            {
                // TODO: Setup plot series, ideally somewhere else
                ThreadSafeDelegate(delegate
                {
                    dataChart.Series.Add(device.name);
                    dataChart.Series[device.name].ChartType = SeriesChartType.Line;
                    dataChart.Series[device.name].BorderWidth = 2;
                    dataChart.Series[device.name].Color = Color.Purple;
                });
            }
        }

        private void DisposeDataTable()
        {
            ThreadSafeDelegate(delegate
            {
                foreach (Control item in dataTable.Controls)
                {
                    Document(String.Format("Disposing {0}", item.Name));
                    item.Dispose();
                }
                dataTable.Dispose();
            });
        }

        private void SleepWakeDevice(object sender, EventArgs e)
        {
            BTDevice device = lookupBySleepButton[sender];

            if (device.isAwake)
            {
                // Enter sleep mode
                Byte[] cmd = bglib.BLECommandATTClientAttributeWrite(device.connection, device.attHandleControl, new Byte[] { 0x00 });
                Document(String.Format("ble_cmd_att_client_attribute_write: connection={0}, handle={1}, data=[ {2}]",
                    device.connection, device.attHandleControl, "00 "));
                //ThreadSafeDelegate(delegate { txtLog.AppendText(String.Format("=> TX ({0}) [ {1}]", cmd.Length, ByteArrayToHexString(cmd)) + Environment.NewLine); });
                bglib.SendCommand(serialAPI, cmd);
            }
            else
            {
                // Wake up
                Byte[] cmd = bglib.BLECommandATTClientAttributeWrite(device.connection, device.attHandleControl, new Byte[] { 0x01 });
                Document(String.Format("ble_cmd_att_client_attribute_write: connection={0}, handle={1}, data=[ {2}]",
                    device.connection, device.attHandleControl, "01 "));
                //ThreadSafeDelegate(delegate { txtLog.AppendText(String.Format("=> TX ({0}) [ {1}]", cmd.Length, ByteArrayToHexString(cmd)) + Environment.NewLine); });
                bglib.SendCommand(serialAPI, cmd);

                // Set prevTime for measurements
                device.prevTime = device.timer.ElapsedMilliseconds;
            }
        }
    }
}
