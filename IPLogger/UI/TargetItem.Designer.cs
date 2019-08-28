namespace IPLogger.UI
{
    partial class TargetItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tgtName = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tgtImage = new System.Windows.Forms.PictureBox();
            this.tgtStatus = new System.Windows.Forms.Label();
            this.tgtUptime = new System.Windows.Forms.Label();
            this.tgtDown = new System.Windows.Forms.Label();
            this.tgtDetails = new System.Windows.Forms.Button();
            this.tgtToggle = new System.Windows.Forms.Button();
            this.tgtDelete = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tgtImage)).BeginInit();
            this.SuspendLayout();
            // 
            // tgtName
            // 
            this.tgtName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tgtName.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.tgtName, 3);
            this.tgtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tgtName.Location = new System.Drawing.Point(11, 3);
            this.tgtName.Name = "tgtName";
            this.tgtName.Size = new System.Drawing.Size(0, 13);
            this.tgtName.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.tgtName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tgtImage, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tgtStatus, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tgtUptime, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tgtDown, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.tgtDetails, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.tgtToggle, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.tgtDelete, 6, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(625, 62);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // tgtImage
            // 
            this.tgtImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tgtImage.Location = new System.Drawing.Point(0, 0);
            this.tgtImage.Margin = new System.Windows.Forms.Padding(0);
            this.tgtImage.Name = "tgtImage";
            this.tableLayoutPanel1.SetRowSpan(this.tgtImage, 3);
            this.tgtImage.Size = new System.Drawing.Size(8, 62);
            this.tgtImage.TabIndex = 1;
            this.tgtImage.TabStop = false;
            // 
            // tgtStatus
            // 
            this.tgtStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tgtStatus.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.tgtStatus, 2);
            this.tgtStatus.Location = new System.Drawing.Point(11, 23);
            this.tgtStatus.Name = "tgtStatus";
            this.tgtStatus.Size = new System.Drawing.Size(46, 13);
            this.tgtStatus.TabIndex = 0;
            this.tgtStatus.Text = "Status: -";
            // 
            // tgtUptime
            // 
            this.tgtUptime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tgtUptime.AutoSize = true;
            this.tgtUptime.Location = new System.Drawing.Point(11, 44);
            this.tgtUptime.Name = "tgtUptime";
            this.tgtUptime.Size = new System.Drawing.Size(70, 13);
            this.tgtUptime.TabIndex = 0;
            this.tgtUptime.Text = "Uptime 24h: -";
            // 
            // tgtDown
            // 
            this.tgtDown.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tgtDown.AutoSize = true;
            this.tgtDown.Location = new System.Drawing.Point(87, 44);
            this.tgtDown.Name = "tgtDown";
            this.tgtDown.Size = new System.Drawing.Size(68, 13);
            this.tgtDown.TabIndex = 0;
            this.tgtDown.Text = "Downtimes: -";
            // 
            // tgtDetails
            // 
            this.tgtDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tgtDetails.Image = global::IPLogger.Properties.Resources.ico_search;
            this.tgtDetails.Location = new System.Drawing.Point(538, 3);
            this.tgtDetails.Name = "tgtDetails";
            this.tableLayoutPanel1.SetRowSpan(this.tgtDetails, 2);
            this.tgtDetails.Size = new System.Drawing.Size(24, 24);
            this.tgtDetails.TabIndex = 3;
            this.tgtDetails.UseVisualStyleBackColor = true;
            this.tgtDetails.Click += new System.EventHandler(this.TgtDetails_Click);
            // 
            // tgtToggle
            // 
            this.tgtToggle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tgtToggle.Image = global::IPLogger.Properties.Resources.ico_stop;
            this.tgtToggle.Location = new System.Drawing.Point(568, 3);
            this.tgtToggle.Name = "tgtToggle";
            this.tableLayoutPanel1.SetRowSpan(this.tgtToggle, 2);
            this.tgtToggle.Size = new System.Drawing.Size(24, 24);
            this.tgtToggle.TabIndex = 3;
            this.tgtToggle.UseVisualStyleBackColor = true;
            this.tgtToggle.Click += new System.EventHandler(this.TgtToggle_Click);
            // 
            // tgtDelete
            // 
            this.tgtDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tgtDelete.Image = global::IPLogger.Properties.Resources.ico_delete;
            this.tgtDelete.Location = new System.Drawing.Point(598, 3);
            this.tgtDelete.Name = "tgtDelete";
            this.tableLayoutPanel1.SetRowSpan(this.tgtDelete, 2);
            this.tgtDelete.Size = new System.Drawing.Size(24, 24);
            this.tgtDelete.TabIndex = 3;
            this.tgtDelete.UseVisualStyleBackColor = true;
            this.tgtDelete.Click += new System.EventHandler(this.TgtDelete_Click);
            // 
            // TargetItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "TargetItem";
            this.Size = new System.Drawing.Size(625, 62);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tgtImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label tgtName;
        private System.Windows.Forms.PictureBox tgtImage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label tgtStatus;
        private System.Windows.Forms.Label tgtUptime;
        private System.Windows.Forms.Label tgtDown;
        private System.Windows.Forms.Button tgtDetails;
        private System.Windows.Forms.Button tgtToggle;
        private System.Windows.Forms.Button tgtDelete;
    }
}
