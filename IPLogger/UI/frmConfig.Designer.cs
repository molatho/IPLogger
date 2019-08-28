namespace IPLogger.UI
{
    partial class frmConfig
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cfgAutoStartSystem = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cfgPingTimeout = new System.Windows.Forms.NumericUpDown();
            this.cfgPingInterval = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.cfgAutoStartPinging = new System.Windows.Forms.CheckBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cfgPingTimeout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cfgPingInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.cfgAutoStartSystem, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.cfgPingTimeout, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.cfgPingInterval, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cfgAutoStartPinging, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnOk, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(278, 133);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // cfgAutoStartSystem
            // 
            this.cfgAutoStartSystem.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cfgAutoStartSystem.AutoSize = true;
            this.cfgAutoStartSystem.Location = new System.Drawing.Point(103, 3);
            this.cfgAutoStartSystem.Name = "cfgAutoStartSystem";
            this.cfgAutoStartSystem.Size = new System.Drawing.Size(151, 17);
            this.cfgAutoStartSystem.TabIndex = 1;
            this.cfgAutoStartSystem.Text = "Launch on System Startup";
            this.cfgAutoStartSystem.UseVisualStyleBackColor = true;
            this.cfgAutoStartSystem.CheckedChanged += new System.EventHandler(this.CfgAutoStartSystem_CheckedChanged);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Startup:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ping-Timeout (ms):";
            // 
            // cfgPingTimeout
            // 
            this.cfgPingTimeout.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cfgPingTimeout.Location = new System.Drawing.Point(103, 75);
            this.cfgPingTimeout.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.cfgPingTimeout.Name = "cfgPingTimeout";
            this.cfgPingTimeout.Size = new System.Drawing.Size(118, 20);
            this.cfgPingTimeout.TabIndex = 4;
            this.cfgPingTimeout.ValueChanged += new System.EventHandler(this.CfgPingTimeout_ValueChanged);
            // 
            // cfgPingInterval
            // 
            this.cfgPingInterval.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cfgPingInterval.Location = new System.Drawing.Point(103, 49);
            this.cfgPingInterval.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.cfgPingInterval.Name = "cfgPingInterval";
            this.cfgPingInterval.Size = new System.Drawing.Size(118, 20);
            this.cfgPingInterval.TabIndex = 3;
            this.cfgPingInterval.ValueChanged += new System.EventHandler(this.CfgPingInterval_ValueChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ping-Interval (ms):";
            // 
            // cfgAutoStartPinging
            // 
            this.cfgAutoStartPinging.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cfgAutoStartPinging.AutoSize = true;
            this.cfgAutoStartPinging.Location = new System.Drawing.Point(103, 26);
            this.cfgAutoStartPinging.Name = "cfgAutoStartPinging";
            this.cfgAutoStartPinging.Size = new System.Drawing.Size(106, 17);
            this.cfgAutoStartPinging.TabIndex = 2;
            this.cfgAutoStartPinging.Text = "Autostart Pinging";
            this.cfgAutoStartPinging.UseVisualStyleBackColor = true;
            this.cfgAutoStartPinging.CheckedChanged += new System.EventHandler(this.CfgAutoStartPinging_CheckedChanged);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(200, 107);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // frmConfig
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnOk;
            this.ClientSize = new System.Drawing.Size(284, 139);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmConfig";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "IPLogger Config";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cfgPingTimeout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cfgPingInterval)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.NumericUpDown cfgPingInterval;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown cfgPingTimeout;
        private System.Windows.Forms.CheckBox cfgAutoStartSystem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cfgAutoStartPinging;
        private System.Windows.Forms.Button btnOk;
    }
}