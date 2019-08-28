namespace IPLogger.UI
{
    partial class frmTarget
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.infName = new System.Windows.Forms.Label();
            this.infAddress = new System.Windows.Forms.Label();
            this.infStatus = new System.Windows.Forms.Label();
            this.infUptime = new System.Windows.Forms.Label();
            this.infDowntimes = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.grphScroll = new System.Windows.Forms.HScrollBar();
            this.grphFromLbl = new System.Windows.Forms.Label();
            this.grphNowLbl = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.grphMode = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.grphLatestTimespan = new System.Windows.Forms.MaskedTextBox();
            this.grphBetweenStart = new System.Windows.Forms.DateTimePicker();
            this.grphBetweenEnd = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.grphToLbl = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dwn24h = new System.Windows.Forms.ListView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dwnAll = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label10 = new System.Windows.Forms.Label();
            this.infFile = new System.Windows.Forms.Label();
            this.graph1 = new IPLogger.UI.Graph();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(843, 77);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Information";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.infName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.infAddress, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.infStatus, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.infUptime, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.infDowntimes, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label10, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.infFile, 3, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(837, 58);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 22);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Adress:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 41);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Status:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(412, 3);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Uptime 24h/All:";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(393, 22);
            this.label5.Margin = new System.Windows.Forms.Padding(3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Downtimes 24h/All:";
            // 
            // infName
            // 
            this.infName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.infName.AutoSize = true;
            this.infName.Location = new System.Drawing.Point(51, 3);
            this.infName.Name = "infName";
            this.infName.Size = new System.Drawing.Size(10, 13);
            this.infName.TabIndex = 0;
            this.infName.Text = "-";
            // 
            // infAddress
            // 
            this.infAddress.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.infAddress.AutoSize = true;
            this.infAddress.Location = new System.Drawing.Point(51, 22);
            this.infAddress.Name = "infAddress";
            this.infAddress.Size = new System.Drawing.Size(10, 13);
            this.infAddress.TabIndex = 0;
            this.infAddress.Text = "-";
            // 
            // infStatus
            // 
            this.infStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.infStatus.AutoSize = true;
            this.infStatus.Location = new System.Drawing.Point(51, 41);
            this.infStatus.Name = "infStatus";
            this.infStatus.Size = new System.Drawing.Size(10, 13);
            this.infStatus.TabIndex = 0;
            this.infStatus.Text = "-";
            // 
            // infUptime
            // 
            this.infUptime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.infUptime.AutoSize = true;
            this.infUptime.Location = new System.Drawing.Point(498, 3);
            this.infUptime.Name = "infUptime";
            this.infUptime.Size = new System.Drawing.Size(10, 13);
            this.infUptime.TabIndex = 0;
            this.infUptime.Text = "-";
            // 
            // infDowntimes
            // 
            this.infDowntimes.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.infDowntimes.AutoSize = true;
            this.infDowntimes.Location = new System.Drawing.Point(498, 22);
            this.infDowntimes.Name = "infDowntimes";
            this.infDowntimes.Size = new System.Drawing.Size(10, 13);
            this.infDowntimes.TabIndex = 0;
            this.infDowntimes.Text = "-";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 77);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer1.Panel1.Controls.Add(this.graph1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(843, 292);
            this.splitContainer1.SplitterDistance = 512;
            this.splitContainer1.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.grphFromLbl, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.grphScroll, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.grphNowLbl, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.grphMode, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.label7, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.label8, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.label9, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.grphLatestTimespan, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.grphBetweenStart, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.grphBetweenEnd, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.button1, 2, 3);
            this.tableLayoutPanel2.Controls.Add(this.button2, 3, 3);
            this.tableLayoutPanel2.Controls.Add(this.button3, 4, 3);
            this.tableLayoutPanel2.Controls.Add(this.button4, 5, 3);
            this.tableLayoutPanel2.Controls.Add(this.grphToLbl, 5, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 150);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(512, 142);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // grphScroll
            // 
            this.grphScroll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.grphScroll, 6);
            this.grphScroll.Location = new System.Drawing.Point(0, 0);
            this.grphScroll.Name = "grphScroll";
            this.grphScroll.Size = new System.Drawing.Size(512, 17);
            this.grphScroll.TabIndex = 2;
            this.grphScroll.Scroll += new System.Windows.Forms.ScrollEventHandler(this.GrphScroll_Scroll);
            // 
            // grphFromLbl
            // 
            this.grphFromLbl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.grphFromLbl.AutoSize = true;
            this.grphFromLbl.Location = new System.Drawing.Point(3, 20);
            this.grphFromLbl.Margin = new System.Windows.Forms.Padding(3);
            this.grphFromLbl.Name = "grphFromLbl";
            this.grphFromLbl.Size = new System.Drawing.Size(64, 13);
            this.grphFromLbl.TabIndex = 3;
            this.grphFromLbl.Text = "--.--.---- --:--:--";
            // 
            // grphNowLbl
            // 
            this.grphNowLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.grphNowLbl.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.grphNowLbl, 4);
            this.grphNowLbl.Location = new System.Drawing.Point(224, 20);
            this.grphNowLbl.Margin = new System.Windows.Forms.Padding(3);
            this.grphNowLbl.Name = "grphNowLbl";
            this.grphNowLbl.Size = new System.Drawing.Size(64, 13);
            this.grphNowLbl.TabIndex = 3;
            this.grphNowLbl.Text = "--.--.---- --:--:--";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Mode:";
            // 
            // grphMode
            // 
            this.grphMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.grphMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.grphMode.FormattingEnabled = true;
            this.grphMode.Location = new System.Drawing.Point(73, 39);
            this.grphMode.Name = "grphMode";
            this.grphMode.Size = new System.Drawing.Size(221, 21);
            this.grphMode.TabIndex = 5;
            this.grphMode.SelectedIndexChanged += new System.EventHandler(this.GrphMode_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Timespan:";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(35, 98);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Start:";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(38, 124);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "End:";
            // 
            // grphLatestTimespan
            // 
            this.grphLatestTimespan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.grphLatestTimespan.Location = new System.Drawing.Point(73, 67);
            this.grphLatestTimespan.Mask = "99\\.99:00:00";
            this.grphLatestTimespan.Name = "grphLatestTimespan";
            this.grphLatestTimespan.Size = new System.Drawing.Size(221, 20);
            this.grphLatestTimespan.TabIndex = 6;
            this.grphLatestTimespan.ValidatingType = typeof(System.DateTime);
            this.grphLatestTimespan.TextChanged += new System.EventHandler(this.GrphLatestTimespan_TextChanged);
            // 
            // grphBetweenStart
            // 
            this.grphBetweenStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.grphBetweenStart.CustomFormat = "dd.MM.yyyy HH:mm:ss";
            this.grphBetweenStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.grphBetweenStart.Location = new System.Drawing.Point(73, 95);
            this.grphBetweenStart.Name = "grphBetweenStart";
            this.grphBetweenStart.Size = new System.Drawing.Size(221, 20);
            this.grphBetweenStart.TabIndex = 7;
            this.grphBetweenStart.ValueChanged += new System.EventHandler(this.GrphBetweenStart_ValueChanged);
            // 
            // grphBetweenEnd
            // 
            this.grphBetweenEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.grphBetweenEnd.CustomFormat = "dd.MM.yyyy HH:mm:ss";
            this.grphBetweenEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.grphBetweenEnd.Location = new System.Drawing.Point(73, 121);
            this.grphBetweenEnd.Name = "grphBetweenEnd";
            this.grphBetweenEnd.Size = new System.Drawing.Size(221, 20);
            this.grphBetweenEnd.TabIndex = 7;
            this.grphBetweenEnd.ValueChanged += new System.EventHandler(this.GrphBetweenEnd_ValueChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(300, 66);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "+1m";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(346, 66);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(47, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "+10m";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(399, 66);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(40, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "+1h";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(445, 66);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(40, 23);
            this.button4.TabIndex = 8;
            this.button4.Text = "+1d";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // grphToLbl
            // 
            this.grphToLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.grphToLbl.AutoSize = true;
            this.grphToLbl.Location = new System.Drawing.Point(445, 20);
            this.grphToLbl.Margin = new System.Windows.Forms.Padding(3);
            this.grphToLbl.Name = "grphToLbl";
            this.grphToLbl.Size = new System.Drawing.Size(64, 13);
            this.grphToLbl.TabIndex = 3;
            this.grphToLbl.Text = "--.--.---- --:--:--";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(327, 292);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dwn24h);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(319, 266);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Downtime 24h";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dwn24h
            // 
            this.dwn24h.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwn24h.FullRowSelect = true;
            this.dwn24h.HideSelection = false;
            this.dwn24h.Location = new System.Drawing.Point(3, 3);
            this.dwn24h.Name = "dwn24h";
            this.dwn24h.Size = new System.Drawing.Size(313, 260);
            this.dwn24h.TabIndex = 0;
            this.dwn24h.UseCompatibleStateImageBehavior = false;
            this.dwn24h.View = System.Windows.Forms.View.List;
            this.dwn24h.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Dwn24h_MouseDoubleClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dwnAll);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(280, 266);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Downtime All";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dwnAll
            // 
            this.dwnAll.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.dwnAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwnAll.FullRowSelect = true;
            this.dwnAll.HideSelection = false;
            this.dwnAll.Location = new System.Drawing.Point(3, 3);
            this.dwnAll.Name = "dwnAll";
            this.dwnAll.Size = new System.Drawing.Size(274, 260);
            this.dwnAll.TabIndex = 1;
            this.dwnAll.UseCompatibleStateImageBehavior = false;
            this.dwnAll.View = System.Windows.Forms.View.List;
            this.dwnAll.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.DwnAll_MouseDoubleClick);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Downtime";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(466, 41);
            this.label10.Margin = new System.Windows.Forms.Padding(3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(26, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "File:";
            // 
            // infFile
            // 
            this.infFile.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.infFile.AutoSize = true;
            this.infFile.Location = new System.Drawing.Point(498, 41);
            this.infFile.Name = "infFile";
            this.infFile.Size = new System.Drawing.Size(10, 13);
            this.infFile.TabIndex = 0;
            this.infFile.Text = "-";
            // 
            // graph1
            // 
            this.graph1.AxisModeMax = IPLogger.UI.Graph.eAxisMode.Dynamic;
            this.graph1.AxisModeMin = IPLogger.UI.Graph.eAxisMode.Static;
            this.graph1.AxisStaticMax = 100F;
            this.graph1.AxisStaticMin = 0F;
            this.graph1.BackColor = System.Drawing.Color.White;
            this.graph1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.graph1.Dock = System.Windows.Forms.DockStyle.Top;
            this.graph1.GraphMode = IPLogger.UI.Graph.eGraphMode.Latest;
            this.graph1.GraphModeFrom = new System.DateTime(2019, 8, 26, 12, 22, 34, 784);
            this.graph1.GraphModeLatest = System.TimeSpan.Parse("00:01:40");
            this.graph1.GraphModeTo = new System.DateTime(2019, 8, 27, 12, 22, 34, 784);
            this.graph1.LineMode = IPLogger.UI.Graph.eLineMode.ConnectedLines;
            this.graph1.Location = new System.Drawing.Point(0, 0);
            this.graph1.Name = "graph1";
            this.graph1.Provider = null;
            this.graph1.RefreshEnabled = true;
            this.graph1.RefreshRate = 62.5F;
            this.graph1.Size = new System.Drawing.Size(512, 150);
            this.graph1.TabIndex = 1;
            this.graph1.HasDrawn += new System.EventHandler(this.Graph1_HasDrawn);
            // 
            // frmTarget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 369);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmTarget";
            this.Text = "-";
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label infName;
        private System.Windows.Forms.Label infAddress;
        private System.Windows.Forms.Label infStatus;
        private System.Windows.Forms.Label infUptime;
        private System.Windows.Forms.Label infDowntimes;
        private Graph graph1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView dwn24h;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListView dwnAll;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.HScrollBar grphScroll;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label grphFromLbl;
        private System.Windows.Forms.Label grphToLbl;
        private System.Windows.Forms.Label grphNowLbl;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox grphMode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MaskedTextBox grphLatestTimespan;
        private System.Windows.Forms.DateTimePicker grphBetweenStart;
        private System.Windows.Forms.DateTimePicker grphBetweenEnd;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label infFile;
    }
}