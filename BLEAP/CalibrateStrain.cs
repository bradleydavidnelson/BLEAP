using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLEAP
{
    public partial class CalibrateStrain : Form
    {
        private Main form;
        private List<BTDevice> devices;

        public CalibrateStrain(Main sendingForm, List<BTDevice> compatibleDevices)
        {
            form = sendingForm;
            devices = compatibleDevices;

            InitializeComponent();
        }

        private void SetPotValue(object sender, EventArgs e)
        {
            if (sender is NumericUpDown)
            {
                NumericUpDown control = (NumericUpDown)sender;

                // Convert to byte array
                Byte[] value = BitConverter.GetBytes((UInt16)control.Value);
                if (BitConverter.IsLittleEndian)
                {
                    value = value.Reverse().ToArray();
                }

                // Set command bits to write to wiper (command 1)
                value[0] = (Byte)(value[0] | 0x04);
                //potValue = (int)control.Value;

                // Write value
                //Byte[] cmd = form.bglib.BLECommandATTClientAttributeWrite(device.connection, device.attHandlePot, value);
                //form.Document(String.Format("ble_cmd_att_client_attribute_write: handle={0}, att_handle={1}, data=[ {2}]",
                //    device.connection,
                //    device.attHandlePot,
                //    value));
                //form.Transmit(cmd);
            }
        }

        private void AcceptCalibration(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
