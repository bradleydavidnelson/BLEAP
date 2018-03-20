namespace BLEAP
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuView = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewCom = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewGraph = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewLog = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSensor = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSensorCalibrate = new System.Windows.Forms.ToolStripMenuItem();
            this.splitLog = new System.Windows.Forms.SplitContainer();
            this.splitCom = new System.Windows.Forms.SplitContainer();
            this.LayoutCOM = new System.Windows.Forms.TableLayoutPanel();
            this.lblCOM = new System.Windows.Forms.Label();
            this.comboPorts = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnAttach = new System.Windows.Forms.Button();
            this.splitDiscovery = new System.Windows.Forms.SplitContainer();
            this.grpDiscovery = new System.Windows.Forms.GroupBox();
            this.discoveryTable = new System.Windows.Forms.TableLayoutPanel();
            this.splitData = new System.Windows.Forms.SplitContainer();
            this.dataChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusCOM = new System.Windows.Forms.ToolStripStatusLabel();
            this.serialAPI = new System.IO.Ports.SerialPort(this.components);
            this.dialogSaveAs = new System.Windows.Forms.FolderBrowserDialog();
            this.menuSensorResetAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitLog)).BeginInit();
            this.splitLog.Panel1.SuspendLayout();
            this.splitLog.Panel2.SuspendLayout();
            this.splitLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitCom)).BeginInit();
            this.splitCom.Panel1.SuspendLayout();
            this.splitCom.Panel2.SuspendLayout();
            this.splitCom.SuspendLayout();
            this.LayoutCOM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitDiscovery)).BeginInit();
            this.splitDiscovery.Panel1.SuspendLayout();
            this.splitDiscovery.Panel2.SuspendLayout();
            this.splitDiscovery.SuspendLayout();
            this.grpDiscovery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitData)).BeginInit();
            this.splitData.Panel2.SuspendLayout();
            this.splitData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataChart)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuView,
            this.menuSensor});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(708, 24);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFileSaveAs,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(37, 20);
            this.menuFile.Text = "File";
            // 
            // menuFileSaveAs
            // 
            this.menuFileSaveAs.Name = "menuFileSaveAs";
            this.menuFileSaveAs.Size = new System.Drawing.Size(123, 22);
            this.menuFileSaveAs.Text = "Save As...";
            this.menuFileSaveAs.Click += new System.EventHandler(this.SetSaveLocation);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(120, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.Quit);
            // 
            // menuView
            // 
            this.menuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuViewCom,
            this.menuViewGraph,
            this.menuViewLog});
            this.menuView.Name = "menuView";
            this.menuView.Size = new System.Drawing.Size(44, 20);
            this.menuView.Text = "View";
            // 
            // menuViewCom
            // 
            this.menuViewCom.Checked = true;
            this.menuViewCom.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuViewCom.Name = "menuViewCom";
            this.menuViewCom.Size = new System.Drawing.Size(132, 22);
            this.menuViewCom.Text = "COM Ports";
            this.menuViewCom.Click += new System.EventHandler(this.ToggleComVisibility);
            // 
            // menuViewGraph
            // 
            this.menuViewGraph.Name = "menuViewGraph";
            this.menuViewGraph.Size = new System.Drawing.Size(132, 22);
            this.menuViewGraph.Text = "Graph";
            this.menuViewGraph.Click += new System.EventHandler(this.ToggleGraphVisibility);
            // 
            // menuViewLog
            // 
            this.menuViewLog.Checked = true;
            this.menuViewLog.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuViewLog.Name = "menuViewLog";
            this.menuViewLog.Size = new System.Drawing.Size(132, 22);
            this.menuViewLog.Text = "Log";
            this.menuViewLog.Click += new System.EventHandler(this.ToggleLogVisibility);
            // 
            // menuSensor
            // 
            this.menuSensor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSensorCalibrate,
            this.toolStripMenuItem2,
            this.menuSensorResetAll});
            this.menuSensor.Name = "menuSensor";
            this.menuSensor.Size = new System.Drawing.Size(54, 20);
            this.menuSensor.Text = "Sensor";
            // 
            // menuSensorCalibrate
            // 
            this.menuSensorCalibrate.Name = "menuSensorCalibrate";
            this.menuSensorCalibrate.Size = new System.Drawing.Size(152, 22);
            this.menuSensorCalibrate.Text = "Calibrate...";
            this.menuSensorCalibrate.Click += new System.EventHandler(this.OpenCalibrationForm);
            // 
            // splitLog
            // 
            this.splitLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitLog.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitLog.Location = new System.Drawing.Point(0, 24);
            this.splitLog.Name = "splitLog";
            this.splitLog.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitLog.Panel1
            // 
            this.splitLog.Panel1.Controls.Add(this.splitCom);
            // 
            // splitLog.Panel2
            // 
            this.splitLog.Panel2.Controls.Add(this.txtLog);
            this.splitLog.Size = new System.Drawing.Size(708, 385);
            this.splitLog.SplitterDistance = 273;
            this.splitLog.TabIndex = 1;
            this.splitLog.DoubleClick += new System.EventHandler(this.ToggleLogVisibility);
            // 
            // splitCom
            // 
            this.splitCom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitCom.IsSplitterFixed = true;
            this.splitCom.Location = new System.Drawing.Point(0, 0);
            this.splitCom.Name = "splitCom";
            this.splitCom.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitCom.Panel1
            // 
            this.splitCom.Panel1.Controls.Add(this.LayoutCOM);
            // 
            // splitCom.Panel2
            // 
            this.splitCom.Panel2.Controls.Add(this.splitDiscovery);
            this.splitCom.Size = new System.Drawing.Size(708, 273);
            this.splitCom.SplitterDistance = 29;
            this.splitCom.TabIndex = 0;
            // 
            // LayoutCOM
            // 
            this.LayoutCOM.ColumnCount = 4;
            this.LayoutCOM.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.LayoutCOM.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.LayoutCOM.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.LayoutCOM.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 400F));
            this.LayoutCOM.Controls.Add(this.lblCOM, 0, 0);
            this.LayoutCOM.Controls.Add(this.comboPorts, 1, 0);
            this.LayoutCOM.Controls.Add(this.btnRefresh, 2, 0);
            this.LayoutCOM.Controls.Add(this.btnAttach, 3, 0);
            this.LayoutCOM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutCOM.Location = new System.Drawing.Point(0, 0);
            this.LayoutCOM.Margin = new System.Windows.Forms.Padding(0);
            this.LayoutCOM.Name = "LayoutCOM";
            this.LayoutCOM.RowCount = 1;
            this.LayoutCOM.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutCOM.Size = new System.Drawing.Size(708, 29);
            this.LayoutCOM.TabIndex = 0;
            // 
            // lblCOM
            // 
            this.lblCOM.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCOM.AutoSize = true;
            this.lblCOM.Location = new System.Drawing.Point(3, 8);
            this.lblCOM.Name = "lblCOM";
            this.lblCOM.Size = new System.Drawing.Size(56, 13);
            this.lblCOM.TabIndex = 0;
            this.lblCOM.Text = "COM Port:";
            // 
            // comboPorts
            // 
            this.comboPorts.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboPorts.FormattingEnabled = true;
            this.comboPorts.Location = new System.Drawing.Point(65, 4);
            this.comboPorts.Name = "comboPorts";
            this.comboPorts.Size = new System.Drawing.Size(222, 21);
            this.comboPorts.TabIndex = 1;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRefresh.Location = new System.Drawing.Point(293, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(60, 23);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // btnAttach
            // 
            this.btnAttach.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnAttach.Location = new System.Drawing.Point(359, 3);
            this.btnAttach.Name = "btnAttach";
            this.btnAttach.Size = new System.Drawing.Size(60, 23);
            this.btnAttach.TabIndex = 3;
            this.btnAttach.Text = "Attach";
            this.btnAttach.UseVisualStyleBackColor = true;
            this.btnAttach.Click += new System.EventHandler(this.AttachDetachUSB);
            // 
            // splitDiscovery
            // 
            this.splitDiscovery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitDiscovery.Location = new System.Drawing.Point(0, 0);
            this.splitDiscovery.Margin = new System.Windows.Forms.Padding(0);
            this.splitDiscovery.Name = "splitDiscovery";
            // 
            // splitDiscovery.Panel1
            // 
            this.splitDiscovery.Panel1.Controls.Add(this.grpDiscovery);
            // 
            // splitDiscovery.Panel2
            // 
            this.splitDiscovery.Panel2.Controls.Add(this.splitData);
            this.splitDiscovery.Size = new System.Drawing.Size(708, 240);
            this.splitDiscovery.SplitterDistance = 187;
            this.splitDiscovery.TabIndex = 0;
            // 
            // grpDiscovery
            // 
            this.grpDiscovery.Controls.Add(this.discoveryTable);
            this.grpDiscovery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDiscovery.Location = new System.Drawing.Point(0, 0);
            this.grpDiscovery.Name = "grpDiscovery";
            this.grpDiscovery.Size = new System.Drawing.Size(187, 240);
            this.grpDiscovery.TabIndex = 0;
            this.grpDiscovery.TabStop = false;
            this.grpDiscovery.Text = "Discovered Devices";
            // 
            // discoveryTable
            // 
            this.discoveryTable.AutoScroll = true;
            this.discoveryTable.ColumnCount = 2;
            this.discoveryTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.discoveryTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.discoveryTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.discoveryTable.Location = new System.Drawing.Point(3, 16);
            this.discoveryTable.Name = "discoveryTable";
            this.discoveryTable.RowCount = 1;
            this.discoveryTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.discoveryTable.Size = new System.Drawing.Size(181, 221);
            this.discoveryTable.TabIndex = 0;
            // 
            // splitData
            // 
            this.splitData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitData.Location = new System.Drawing.Point(0, 0);
            this.splitData.Margin = new System.Windows.Forms.Padding(0);
            this.splitData.Name = "splitData";
            this.splitData.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitData.Panel2
            // 
            this.splitData.Panel2.Controls.Add(this.dataChart);
            this.splitData.Panel2Collapsed = true;
            this.splitData.Size = new System.Drawing.Size(517, 240);
            this.splitData.SplitterDistance = 54;
            this.splitData.TabIndex = 0;
            // 
            // dataChart
            // 
            this.dataChart.BackColor = System.Drawing.Color.Transparent;
            chartArea6.AxisX.MajorGrid.Enabled = false;
            chartArea6.AxisY.MajorGrid.Enabled = false;
            chartArea6.BackColor = System.Drawing.Color.Transparent;
            chartArea6.Name = "ChartArea";
            this.dataChart.ChartAreas.Add(chartArea6);
            this.dataChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataChart.Location = new System.Drawing.Point(0, 0);
            this.dataChart.Name = "dataChart";
            series6.BorderWidth = 2;
            series6.ChartArea = "ChartArea";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Name = "Series1";
            this.dataChart.Series.Add(series6);
            this.dataChart.Size = new System.Drawing.Size(150, 46);
            this.dataChart.TabIndex = 0;
            this.dataChart.Text = "chart1";
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.SystemColors.Window;
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Location = new System.Drawing.Point(0, 0);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(708, 108);
            this.txtLog.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusCOM});
            this.statusStrip1.Location = new System.Drawing.Point(0, 409);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(708, 24);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusCOM
            // 
            this.statusCOM.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.statusCOM.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.statusCOM.ForeColor = System.Drawing.SystemColors.GrayText;
            this.statusCOM.Name = "statusCOM";
            this.statusCOM.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.statusCOM.Size = new System.Drawing.Size(42, 19);
            this.statusCOM.Text = "COM";
            // 
            // folderBrowserDialog1
            // 
            this.dialogSaveAs.Description = "Select a directory which will contain .csv data files.";
            // 
            // menuSensorResetAll
            // 
            this.menuSensorResetAll.Name = "menuSensorResetAll";
            this.menuSensorResetAll.Size = new System.Drawing.Size(152, 22);
            this.menuSensorResetAll.Text = "Reset All";
            this.menuSensorResetAll.Click += new System.EventHandler(this.ResetAll);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(149, 6);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 433);
            this.Controls.Add(this.splitLog);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menu);
            this.MainMenuStrip = this.menu;
            this.Name = "Main";
            this.Text = "BLE Access Point";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Exit);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.splitLog.Panel1.ResumeLayout(false);
            this.splitLog.Panel2.ResumeLayout(false);
            this.splitLog.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitLog)).EndInit();
            this.splitLog.ResumeLayout(false);
            this.splitCom.Panel1.ResumeLayout(false);
            this.splitCom.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitCom)).EndInit();
            this.splitCom.ResumeLayout(false);
            this.LayoutCOM.ResumeLayout(false);
            this.LayoutCOM.PerformLayout();
            this.splitDiscovery.Panel1.ResumeLayout(false);
            this.splitDiscovery.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitDiscovery)).EndInit();
            this.splitDiscovery.ResumeLayout(false);
            this.grpDiscovery.ResumeLayout(false);
            this.splitData.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitData)).EndInit();
            this.splitData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataChart)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuSensor;
        private System.Windows.Forms.ToolStripMenuItem menuSensorCalibrate;
        private System.Windows.Forms.SplitContainer splitLog;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.ToolStripMenuItem menuView;
        private System.Windows.Forms.ToolStripMenuItem menuViewLog;
        private System.Windows.Forms.ToolStripMenuItem menuViewGraph;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitCom;
        private System.Windows.Forms.TableLayoutPanel LayoutCOM;
        private System.Windows.Forms.Label lblCOM;
        private System.Windows.Forms.ComboBox comboPorts;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnAttach;
        private System.Windows.Forms.ToolStripMenuItem menuViewCom;
        private System.Windows.Forms.SplitContainer splitDiscovery;
        private System.Windows.Forms.GroupBox grpDiscovery;
        private System.IO.Ports.SerialPort serialAPI;
        private System.Windows.Forms.ToolStripStatusLabel statusCOM;
        private System.Windows.Forms.TableLayoutPanel discoveryTable;
        private System.Windows.Forms.SplitContainer splitData;
        private System.Windows.Forms.DataVisualization.Charting.Chart dataChart;
        private System.Windows.Forms.ToolStripMenuItem menuFileSaveAs;
        private System.Windows.Forms.FolderBrowserDialog dialogSaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem menuSensorResetAll;
    }
}

