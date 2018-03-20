namespace BLEAP
{
    partial class CalibratePH
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
            this.lblPH = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPH = new System.Windows.Forms.TextBox();
            this.txtVoltage = new System.Windows.Forms.TextBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblPH
            // 
            this.lblPH.AutoSize = true;
            this.lblPH.Location = new System.Drawing.Point(58, 9);
            this.lblPH.Name = "lblPH";
            this.lblPH.Size = new System.Drawing.Size(74, 13);
            this.lblPH.TabIndex = 0;
            this.lblPH.Text = "Measured pH:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Measured Voltage (mV):";
            // 
            // txtPH
            // 
            this.txtPH.Location = new System.Drawing.Point(139, 6);
            this.txtPH.Name = "txtPH";
            this.txtPH.Size = new System.Drawing.Size(100, 20);
            this.txtPH.TabIndex = 2;
            // 
            // txtVoltage
            // 
            this.txtVoltage.Location = new System.Drawing.Point(139, 32);
            this.txtVoltage.Name = "txtVoltage";
            this.txtVoltage.Size = new System.Drawing.Size(100, 20);
            this.txtVoltage.TabIndex = 3;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(90, 74);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 4;
            this.btnConfirm.Text = "Okay";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.AcceptCalibration);
            // 
            // CalibratePH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 122);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.txtVoltage);
            this.Controls.Add(this.txtPH);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblPH);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CalibratePH";
            this.Text = "Calibrate...";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPH;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPH;
        private System.Windows.Forms.TextBox txtVoltage;
        private System.Windows.Forms.Button btnConfirm;
    }
}