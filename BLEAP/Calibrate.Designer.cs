namespace BLEAP
{
    partial class Calibrate
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
            this.tabs = new System.Windows.Forms.TabControl();
            this.pagePH = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.comboPH = new System.Windows.Forms.ComboBox();
            this.lblPHDevice = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPH = new System.Windows.Forms.TextBox();
            this.txtMV = new System.Windows.Forms.TextBox();
            this.btnPHConfirm = new System.Windows.Forms.Button();
            this.pagePot = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblPotDevice = new System.Windows.Forms.Label();
            this.comboPot = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnPotOkay = new System.Windows.Forms.Button();
            this.lblPotValue = new System.Windows.Forms.Label();
            this.numPotValue = new System.Windows.Forms.NumericUpDown();
            this.tabs.SuspendLayout();
            this.pagePH.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.pagePot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPotValue)).BeginInit();
            this.SuspendLayout();
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.pagePH);
            this.tabs.Controls.Add(this.pagePot);
            this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabs.Location = new System.Drawing.Point(0, 0);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(219, 162);
            this.tabs.TabIndex = 0;
            // 
            // pagePH
            // 
            this.pagePH.Controls.Add(this.splitContainer1);
            this.pagePH.Location = new System.Drawing.Point(4, 22);
            this.pagePH.Margin = new System.Windows.Forms.Padding(0);
            this.pagePH.Name = "pagePH";
            this.pagePH.Size = new System.Drawing.Size(211, 136);
            this.pagePH.TabIndex = 0;
            this.pagePH.Text = "pH";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Panel1MinSize = 32;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel4);
            this.splitContainer1.Size = new System.Drawing.Size(211, 136);
            this.splitContainer1.SplitterDistance = 32;
            this.splitContainer1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.comboPH, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblPHDevice, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(211, 32);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // comboPH
            // 
            this.comboPH.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboPH.FormattingEnabled = true;
            this.comboPH.Location = new System.Drawing.Point(53, 5);
            this.comboPH.Name = "comboPH";
            this.comboPH.Size = new System.Drawing.Size(121, 21);
            this.comboPH.TabIndex = 0;
            // 
            // lblPHDevice
            // 
            this.lblPHDevice.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblPHDevice.AutoSize = true;
            this.lblPHDevice.Location = new System.Drawing.Point(3, 9);
            this.lblPHDevice.Name = "lblPHDevice";
            this.lblPHDevice.Size = new System.Drawing.Size(44, 13);
            this.lblPHDevice.TabIndex = 1;
            this.lblPHDevice.Text = "Device:";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.txtPH, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.txtMV, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.btnPHConfirm, 1, 2);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 89F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(211, 100);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Known pH:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Known mV:";
            // 
            // txtPH
            // 
            this.txtPH.Location = new System.Drawing.Point(83, 3);
            this.txtPH.Name = "txtPH";
            this.txtPH.Size = new System.Drawing.Size(100, 20);
            this.txtPH.TabIndex = 2;
            // 
            // txtMV
            // 
            this.txtMV.Location = new System.Drawing.Point(83, 29);
            this.txtMV.Name = "txtMV";
            this.txtMV.Size = new System.Drawing.Size(100, 20);
            this.txtMV.TabIndex = 3;
            // 
            // btnPHConfirm
            // 
            this.btnPHConfirm.Location = new System.Drawing.Point(83, 55);
            this.btnPHConfirm.Name = "btnPHConfirm";
            this.btnPHConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnPHConfirm.TabIndex = 4;
            this.btnPHConfirm.Text = "Confirm";
            this.btnPHConfirm.UseVisualStyleBackColor = true;
            // 
            // pagePot
            // 
            this.pagePot.Controls.Add(this.splitContainer2);
            this.pagePot.Location = new System.Drawing.Point(4, 22);
            this.pagePot.Margin = new System.Windows.Forms.Padding(0);
            this.pagePot.Name = "pagePot";
            this.pagePot.Size = new System.Drawing.Size(211, 136);
            this.pagePot.TabIndex = 1;
            this.pagePot.Text = "Potentiometer";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer2.Panel1MinSize = 32;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tableLayoutPanel3);
            this.splitContainer2.Size = new System.Drawing.Size(211, 136);
            this.splitContainer2.SplitterDistance = 32;
            this.splitContainer2.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.lblPotDevice, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.comboPot, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(211, 32);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // lblPotDevice
            // 
            this.lblPotDevice.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblPotDevice.AutoSize = true;
            this.lblPotDevice.Location = new System.Drawing.Point(3, 9);
            this.lblPotDevice.Name = "lblPotDevice";
            this.lblPotDevice.Size = new System.Drawing.Size(44, 13);
            this.lblPotDevice.TabIndex = 1;
            this.lblPotDevice.Text = "Device:";
            // 
            // comboPot
            // 
            this.comboPot.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboPot.FormattingEnabled = true;
            this.comboPot.Location = new System.Drawing.Point(53, 5);
            this.comboPot.Name = "comboPot";
            this.comboPot.Size = new System.Drawing.Size(121, 21);
            this.comboPot.TabIndex = 3;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.btnPotOkay, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.lblPotValue, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.numPotValue, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(211, 100);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // btnPotOkay
            // 
            this.btnPotOkay.Location = new System.Drawing.Point(80, 43);
            this.btnPotOkay.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.btnPotOkay.Name = "btnPotOkay";
            this.btnPotOkay.Size = new System.Drawing.Size(75, 23);
            this.btnPotOkay.TabIndex = 4;
            this.btnPotOkay.Text = "Okay";
            this.btnPotOkay.UseVisualStyleBackColor = true;
            this.btnPotOkay.Click += new System.EventHandler(this.Close);
            // 
            // lblPotValue
            // 
            this.lblPotValue.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblPotValue.AutoSize = true;
            this.lblPotValue.Location = new System.Drawing.Point(10, 13);
            this.lblPotValue.Name = "lblPotValue";
            this.lblPotValue.Size = new System.Drawing.Size(37, 13);
            this.lblPotValue.TabIndex = 2;
            this.lblPotValue.Text = "Value:";
            // 
            // numPotValue
            // 
            this.numPotValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numPotValue.Location = new System.Drawing.Point(53, 10);
            this.numPotValue.Maximum = new decimal(new int[] {
            1023,
            0,
            0,
            0});
            this.numPotValue.Name = "numPotValue";
            this.numPotValue.Size = new System.Drawing.Size(75, 20);
            this.numPotValue.TabIndex = 5;
            this.numPotValue.ValueChanged += new System.EventHandler(this.SetPotValue);
            // 
            // Calibrate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(219, 162);
            this.Controls.Add(this.tabs);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Calibrate";
            this.ShowInTaskbar = false;
            this.Text = "Calibrate...";
            this.TopMost = true;
            this.tabs.ResumeLayout(false);
            this.pagePH.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.pagePot.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPotValue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage pagePH;
        private System.Windows.Forms.TabPage pagePot;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblPotDevice;
        private System.Windows.Forms.ComboBox comboPot;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.NumericUpDown numPotValue;
        private System.Windows.Forms.Label lblPotValue;
        private System.Windows.Forms.Button btnPotOkay;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label lblPHDevice;
        private System.Windows.Forms.ComboBox comboPH;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPH;
        private System.Windows.Forms.TextBox txtMV;
        private System.Windows.Forms.Button btnPHConfirm;
    }
}