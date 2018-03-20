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
            this.lblInstructions = new System.Windows.Forms.Label();
            this.numCal = new System.Windows.Forms.NumericUpDown();
            this.btnConfirm = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numCal)).BeginInit();
            this.SuspendLayout();
            // 
            // lblInstructions
            // 
            this.lblInstructions.AutoSize = true;
            this.lblInstructions.Location = new System.Drawing.Point(12, 9);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(135, 13);
            this.lblInstructions.TabIndex = 0;
            this.lblInstructions.Text = "Set digital potentiometer to:";
            // 
            // numCal
            // 
            this.numCal.Location = new System.Drawing.Point(12, 35);
            this.numCal.Maximum = new decimal(new int[] {
            1023,
            0,
            0,
            0});
            this.numCal.Name = "numCal";
            this.numCal.Size = new System.Drawing.Size(62, 20);
            this.numCal.TabIndex = 1;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(92, 34);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 2;
            this.btnConfirm.Text = "Okay";
            this.btnConfirm.UseVisualStyleBackColor = true;
            // 
            // CalibrateStrain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(189, 70);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.numCal);
            this.Controls.Add(this.lblInstructions);
            this.Name = "CalibrateStrain";
            this.Text = "Calibrate...";
            ((System.ComponentModel.ISupportInitialize)(this.numCal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInstructions;
        private System.Windows.Forms.NumericUpDown numCal;
        private System.Windows.Forms.Button btnConfirm;
    }
}