namespace BLEAP
{
    partial class CalibrateStrain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.numCal = new System.Windows.Forms.NumericUpDown();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.lblDevice = new System.Windows.Forms.Label();
            this.cmbDevices = new System.Windows.Forms.ComboBox();
            this.lblValue = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numCal)).BeginInit();
            this.SuspendLayout();
            // 
            // numCal
            // 
            this.numCal.Location = new System.Drawing.Point(95, 33);
            this.numCal.Maximum = new decimal(new int[] {
            1023,
            0,
            0,
            0});
            this.numCal.Name = "numCal";
            this.numCal.Size = new System.Drawing.Size(91, 20);
            this.numCal.TabIndex = 1;
            this.numCal.ValueChanged += new System.EventHandler(this.SetPotValue);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(95, 59);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 2;
            this.btnConfirm.Text = "Okay";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.AcceptCalibration);
            // 
            // lblDevice
            // 
            this.lblDevice.AutoSize = true;
            this.lblDevice.Location = new System.Drawing.Point(12, 9);
            this.lblDevice.Name = "lblDevice";
            this.lblDevice.Size = new System.Drawing.Size(44, 13);
            this.lblDevice.TabIndex = 3;
            this.lblDevice.Text = "Device:";
            // 
            // cmbDevices
            // 
            this.cmbDevices.FormattingEnabled = true;
            this.cmbDevices.Location = new System.Drawing.Point(95, 6);
            this.cmbDevices.Name = "cmbDevices";
            this.cmbDevices.Size = new System.Drawing.Size(91, 21);
            this.cmbDevices.TabIndex = 4;
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Location = new System.Drawing.Point(19, 35);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(37, 13);
            this.lblValue.TabIndex = 0;
            this.lblValue.Text = "Value:";
            // 
            // CalibrateStrain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 101);
            this.Controls.Add(this.lblDevice);
            this.Controls.Add(this.cmbDevices);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.numCal);
            this.Controls.Add(this.btnConfirm);
            this.Name = "CalibrateStrain";
            this.Text = "Potentiometer Calibration";
            ((System.ComponentModel.ISupportInitialize)(this.numCal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown numCal;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Label lblDevice;
        private System.Windows.Forms.ComboBox cmbDevices;
        private System.Windows.Forms.Label lblValue;
    }
}