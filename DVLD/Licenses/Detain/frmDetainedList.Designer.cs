namespace DVLD.Licenses.Detain
{
    partial class frmDetainedList
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
            this.tbFilterValue = new System.Windows.Forms.TextBox();
            this.cbIsReleased = new System.Windows.Forms.ComboBox();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsMnageLocalApps = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsShowPersonDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsShowLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsShowPersonLicenseHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsReleaseDetainedLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvAllLocalApps = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDetain = new System.Windows.Forms.Button();
            this.btnRelease = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmsMnageLocalApps.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllLocalApps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbFilterValue
            // 
            this.tbFilterValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFilterValue.Location = new System.Drawing.Point(329, 245);
            this.tbFilterValue.Name = "tbFilterValue";
            this.tbFilterValue.Size = new System.Drawing.Size(239, 27);
            this.tbFilterValue.TabIndex = 33;
            this.tbFilterValue.Visible = false;
            this.tbFilterValue.TextChanged += new System.EventHandler(this.tbFilterValue_TextChanged);
            this.tbFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFilterValue_KeyPress);
            // 
            // cbIsReleased
            // 
            this.cbIsReleased.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIsReleased.FormattingEnabled = true;
            this.cbIsReleased.Items.AddRange(new object[] {
            "All",
            "Yes",
            "No"});
            this.cbIsReleased.Location = new System.Drawing.Point(329, 244);
            this.cbIsReleased.Name = "cbIsReleased";
            this.cbIsReleased.Size = new System.Drawing.Size(185, 24);
            this.cbIsReleased.TabIndex = 31;
            this.cbIsReleased.Visible = false;
            this.cbIsReleased.SelectedIndexChanged += new System.EventHandler(this.cbIsReleased_SelectedIndexChanged);
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None",
            "Detain ID",
            "Is Released",
            "National Number",
            "Full Name",
            "Release Application ID"});
            this.cbFilterBy.Location = new System.Drawing.Point(116, 248);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(185, 24);
            this.cbFilterBy.TabIndex = 32;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 248);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 30;
            this.label2.Text = "Filter By:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(506, 190);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(277, 29);
            this.label1.TabIndex = 29;
            this.label1.Text = "List Detained Licenses";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(277, 6);
            // 
            // cmsMnageLocalApps
            // 
            this.cmsMnageLocalApps.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsMnageLocalApps.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsShowPersonDetails,
            this.cmsShowLicense,
            this.cmsShowPersonLicenseHistory,
            this.toolStripMenuItem6,
            this.cmsReleaseDetainedLicense});
            this.cmsMnageLocalApps.Name = "cmsMnageLocalApps";
            this.cmsMnageLocalApps.Size = new System.Drawing.Size(281, 190);
            this.cmsMnageLocalApps.Opening += new System.ComponentModel.CancelEventHandler(this.cmsMnageLocalApps_Opening);
            // 
            // cmsShowPersonDetails
            // 
            this.cmsShowPersonDetails.Image = global::DVLD.Properties.Resources.PersonDetails_32;
            this.cmsShowPersonDetails.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmsShowPersonDetails.Name = "cmsShowPersonDetails";
            this.cmsShowPersonDetails.Size = new System.Drawing.Size(280, 38);
            this.cmsShowPersonDetails.Text = "Show Person Details";
            this.cmsShowPersonDetails.Click += new System.EventHandler(this.cmsShowAppDetails_Click);
            // 
            // cmsShowLicense
            // 
            this.cmsShowLicense.Image = global::DVLD.Properties.Resources.License_View_32;
            this.cmsShowLicense.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmsShowLicense.Name = "cmsShowLicense";
            this.cmsShowLicense.Size = new System.Drawing.Size(280, 38);
            this.cmsShowLicense.Text = "Show License";
            this.cmsShowLicense.Click += new System.EventHandler(this.cmsShowLicense_Click);
            // 
            // cmsShowPersonLicenseHistory
            // 
            this.cmsShowPersonLicenseHistory.Image = global::DVLD.Properties.Resources.PersonLicenseHistory_32;
            this.cmsShowPersonLicenseHistory.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmsShowPersonLicenseHistory.Name = "cmsShowPersonLicenseHistory";
            this.cmsShowPersonLicenseHistory.Size = new System.Drawing.Size(280, 38);
            this.cmsShowPersonLicenseHistory.Text = "Show Person License History";
            this.cmsShowPersonLicenseHistory.Click += new System.EventHandler(this.cmsShowPersonLicenseHistory_Click);
            // 
            // cmsReleaseDetainedLicense
            // 
            this.cmsReleaseDetainedLicense.Image = global::DVLD.Properties.Resources.Release_Detained_License_32;
            this.cmsReleaseDetainedLicense.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmsReleaseDetainedLicense.Name = "cmsReleaseDetainedLicense";
            this.cmsReleaseDetainedLicense.Size = new System.Drawing.Size(280, 38);
            this.cmsReleaseDetainedLicense.Text = "Release Detained License";
            this.cmsReleaseDetainedLicense.Click += new System.EventHandler(this.cmsReleaseDetainedLicense_Click);
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsCount.Location = new System.Drawing.Point(130, 666);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(18, 20);
            this.lblRecordsCount.TabIndex = 36;
            this.lblRecordsCount.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 666);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 20);
            this.label3.TabIndex = 35;
            this.label3.Text = "# Records:";
            // 
            // dgvAllLocalApps
            // 
            this.dgvAllLocalApps.AllowUserToAddRows = false;
            this.dgvAllLocalApps.AllowUserToDeleteRows = false;
            this.dgvAllLocalApps.AllowUserToOrderColumns = true;
            this.dgvAllLocalApps.BackgroundColor = System.Drawing.Color.White;
            this.dgvAllLocalApps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllLocalApps.ContextMenuStrip = this.cmsMnageLocalApps;
            this.dgvAllLocalApps.Location = new System.Drawing.Point(12, 285);
            this.dgvAllLocalApps.Name = "dgvAllLocalApps";
            this.dgvAllLocalApps.ReadOnly = true;
            this.dgvAllLocalApps.RowHeadersWidth = 51;
            this.dgvAllLocalApps.RowTemplate.Height = 24;
            this.dgvAllLocalApps.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAllLocalApps.Size = new System.Drawing.Size(1283, 373);
            this.dgvAllLocalApps.TabIndex = 34;
            this.dgvAllLocalApps.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvAllLocalApps_CellMouseDown);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Image = global::DVLD.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1180, 666);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(108, 42);
            this.btnClose.TabIndex = 38;
            this.btnClose.Text = "     Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnDetain
            // 
            this.btnDetain.Image = global::DVLD.Properties.Resources.Detain_64;
            this.btnDetain.Location = new System.Drawing.Point(1103, 190);
            this.btnDetain.Name = "btnDetain";
            this.btnDetain.Size = new System.Drawing.Size(93, 82);
            this.btnDetain.TabIndex = 37;
            this.btnDetain.UseVisualStyleBackColor = true;
            this.btnDetain.Click += new System.EventHandler(this.btnDetain_Click);
            // 
            // btnRelease
            // 
            this.btnRelease.Image = global::DVLD.Properties.Resources.Release_Detained_License_64;
            this.btnRelease.Location = new System.Drawing.Point(1202, 190);
            this.btnRelease.Name = "btnRelease";
            this.btnRelease.Size = new System.Drawing.Size(93, 82);
            this.btnRelease.TabIndex = 37;
            this.btnRelease.UseVisualStyleBackColor = true;
            this.btnRelease.Click += new System.EventHandler(this.btnRelease_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.Properties.Resources.Detain_512;
            this.pictureBox1.Location = new System.Drawing.Point(545, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(176, 180);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            // 
            // frmDetainedList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1307, 706);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDetain);
            this.Controls.Add(this.btnRelease);
            this.Controls.Add(this.tbFilterValue);
            this.Controls.Add(this.cbIsReleased);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dgvAllLocalApps);
            this.Name = "frmDetainedList";
            this.Text = "frmDetainedList";
            this.Load += new System.EventHandler(this.frmDetainedList_Load);
            this.cmsMnageLocalApps.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllLocalApps)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnRelease;
        private System.Windows.Forms.TextBox tbFilterValue;
        private System.Windows.Forms.ComboBox cbIsReleased;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem cmsShowPersonLicenseHistory;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem cmsShowLicense;
        private System.Windows.Forms.ToolStripMenuItem cmsShowPersonDetails;
        private System.Windows.Forms.ContextMenuStrip cmsMnageLocalApps;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dgvAllLocalApps;
        private System.Windows.Forms.ToolStripMenuItem cmsReleaseDetainedLicense;
        private System.Windows.Forms.Button btnDetain;
    }
}