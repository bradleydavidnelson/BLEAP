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
    public partial class CalibratePH : Form
    {
        private Main referencingForm;
        private const float PH_SLOPE = 0.004F;
        private float phValue;
        private float voltageValue;

        public CalibratePH(Main form)
        {
            referencingForm = form;

            InitializeComponent();
        }

        private void AcceptCalibration(object sender, EventArgs e)
        {
            if (txtPH.Text == "" || txtVoltage.Text == "")
            {
                MessageBox.Show("Please enter values for both pH and voltage.", "Error");
                return;
            }

            if (! float.TryParse(txtPH.Text, out phValue) || ! float.TryParse(txtVoltage.Text, out voltageValue))
            {
                MessageBox.Show("Please enter valid numbers for both pH and voltage.","Error");
                return;
            }

            // pH = mV * slope + offset
            float offset = phValue - (voltageValue * PH_SLOPE);

            referencingForm.SetPHOffset(offset);

            Dispose();
        }
    }
}
