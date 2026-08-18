namespace DVLD.Applications.Local_Driving_License
{
    partial class frmManageLocalDrivingLicApp
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
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvAllLocalApps = new System.Windows.Forms.DataGridView();
            this.cmsMnageLocalApps = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsShowAppDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsAddNewLocalApp = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsEditApp = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsDeleteApp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsCancelApp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsScheduleTests = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsScheduleVisionTest = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsScheduleWrittenTest = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsScheduleStreetTest = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsIssueDrivingLicenseFirstTime = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsShowLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsShowPersonLicenseHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.tbFilterValue = new System.Windows.Forms.TextBox();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddNewLocalApp = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cbIsActive = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllLocalApps)).BeginInit();
            this.cmsMnageLocalApps.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsCount.Location = new System.Drawing.Point(130, 659);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(18, 20);
            this.lblRecordsCount.TabIndex = 25;
            this.lblRecordsCount.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 659);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 20);
            this.label3.TabIndex = 24;
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
            this.dgvAllLocalApps.Location = new System.Drawing.Point(12, 278);
            this.dgvAllLocalApps.Name = "dgvAllLocalApps";
            this.dgvAllLocalApps.ReadOnly = true;
            this.dgvAllLocalApps.RowHeadersWidth = 51;
            this.dgvAllLocalApps.RowTemplate.Height = 24;
            this.dgvAllLocalApps.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAllLocalApps.Size = new System.Drawing.Size(1283, 373);
            this.dgvAllLocalApps.TabIndex = 23;
            this.dgvAllLocalApps.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvAllLocalApps_CellMouseDown);
            // 
            // cmsMnageLocalApps
            // 
            this.cmsMnageLocalApps.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsMnageLocalApps.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsShowAppDetails,
            this.toolStripMenuItem1,
            this.cmsAddNewLocalApp,
            this.cmsEditApp,
            this.cmsDeleteApp,
            this.toolStripMenuItem2,
            this.cmsCancelApp,
            this.toolStripMenuItem3,
            this.cmsScheduleTests,
            this.toolStripMenuItem4,
            this.cmsIssueDrivingLicenseFirstTime,
            this.toolStripMenuItem5,
            this.cmsShowLicense,
            this.toolStripMenuItem6,
            this.cmsShowPersonLicenseHistory});
            this.cmsMnageLocalApps.Name = "cmsMnageLocalApps";
            this.cmsMnageLocalApps.Size = new System.Drawing.Size(309, 382);
            this.cmsMnageLocalApps.Opening += new System.ComponentModel.CancelEventHandler(this.cmsMnageLocalApps_Opening);
            // 
            // cmsShowAppDetails
            // 
            this.cmsShowAppDetails.Image = global::DVLD.Properties.Resources.PersonDetails_32;
            this.cmsShowAppDetails.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmsShowAppDetails.Name = "cmsShowAppDetails";
            this.cmsShowAppDetails.Size = new System.Drawing.Size(308, 38);
            this.cmsShowAppDetails.Text = "Show Application Details";
            this.cmsShowAppDetails.Click += new System.EventHandler(this.cmsShowAppDetails_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(305, 6);
            // 
            // cmsAddNewLocalApp
            // 
            this.cmsAddNewLocalApp.Image = global::DVLD.Properties.Resources.Manage_Applications_32;
            this.cmsAddNewLocalApp.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmsAddNewLocalApp.Name = "cmsAddNewLocalApp";
            this.cmsAddNewLocalApp.Size = new System.Drawing.Size(308, 38);
            this.cmsAddNewLocalApp.Text = "Add New Local App";
            this.cmsAddNewLocalApp.Click += new System.EventHandler(this.addNewLocalAppToolStripMenuItem_Click);
            // 
            // cmsEditApp
            // 
            this.cmsEditApp.Image = global::DVLD.Properties.Resources.edit_32;
            this.cmsEditApp.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmsEditApp.Name = "cmsEditApp";
            this.cmsEditApp.Size = new System.Drawing.Size(308, 38);
            this.cmsEditApp.Text = "Edit Application";
            this.cmsEditApp.Click += new System.EventHandler(this.editLocalAppToolStripMenuItem_Click);
            // 
            // cmsDeleteApp
            // 
            this.cmsDeleteApp.Image = global::DVLD.Properties.Resources.Delete_32_2;
            this.cmsDeleteApp.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmsDeleteApp.Name = "cmsDeleteApp";
            this.cmsDeleteApp.Size = new System.Drawing.Size(308, 38);
            this.cmsDeleteApp.Text = "Delete Application";
            this.cmsDeleteApp.Click += new System.EventHandler(this.cmsDeleteApp_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(305, 6);
            // 
            // cmsCancelApp
            // 
            this.cmsCancelApp.Image = global::DVLD.Properties.Resources.Delete_32;
            this.cmsCancelApp.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmsCancelApp.Name = "cmsCancelApp";
            this.cmsCancelApp.Size = new System.Drawing.Size(308, 38);
            this.cmsCancelApp.Text = "Cancel Application";
            this.cmsCancelApp.Click += new System.EventHandler(this.cmsCancelApp_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(305, 6);
            // 
            // cmsScheduleTests
            // 
            this.cmsScheduleTests.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsScheduleVisionTest,
            this.cmsScheduleWrittenTest,
            this.cmsScheduleStreetTest});
            this.cmsScheduleTests.Image = global::DVLD.Properties.Resources.Schedule_Test_32;
            this.cmsScheduleTests.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmsScheduleTests.Name = "cmsScheduleTests";
            this.cmsScheduleTests.Size = new System.Drawing.Size(308, 38);
            this.cmsScheduleTests.Text = "Schedule Tests";
            // 
            // cmsScheduleVisionTest
            // 
            this.cmsScheduleVisionTest.Image = global::DVLD.Properties.Resources.Vision_Test_32;
            this.cmsScheduleVisionTest.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmsScheduleVisionTest.Name = "cmsScheduleVisionTest";
            this.cmsScheduleVisionTest.Size = new System.Drawing.Size(247, 38);
            this.cmsScheduleVisionTest.Text = "Schedule Vision Test";
            this.cmsScheduleVisionTest.Click += new System.EventHandler(this.cmsScheduleVisionTest_Click);
            // 
            // cmsScheduleWrittenTest
            // 
            this.cmsScheduleWrittenTest.Image = global::DVLD.Properties.Resources.Written_Test_32;
            this.cmsScheduleWrittenTest.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmsScheduleWrittenTest.Name = "cmsScheduleWrittenTest";
            this.cmsScheduleWrittenTest.Size = new System.Drawing.Size(247, 38);
            this.cmsScheduleWrittenTest.Text = "Schedule Written Test";
            this.cmsScheduleWrittenTest.Click += new System.EventHandler(this.cmsScheduleWrittenTest_Click);
            // 
            // cmsScheduleStreetTest
            // 
            this.cmsScheduleStreetTest.Image = global::DVLD.Properties.Resources.Street_Test_32;
            this.cmsScheduleStreetTest.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmsScheduleStreetTest.Name = "cmsScheduleStreetTest";
            this.cmsScheduleStreetTest.Size = new System.Drawing.Size(247, 38);
            this.cmsScheduleStreetTest.Text = "Schedule Street Test";
            this.cmsScheduleStreetTest.Click += new System.EventHandler(this.cmsScheduleStreetTest_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(305, 6);
            // 
            // cmsIssueDrivingLicenseFirstTime
            // 
            this.cmsIssueDrivingLicenseFirstTime.Image = global::DVLD.Properties.Resources.IssueDrivingLicense_32;
            this.cmsIssueDrivingLicenseFirstTime.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmsIssueDrivingLicenseFirstTime.Name = "cmsIssueDrivingLicenseFirstTime";
            this.cmsIssueDrivingLicenseFirstTime.Size = new System.Drawing.Size(308, 38);
            this.cmsIssueDrivingLicenseFirstTime.Text = "Issue Driving License (First Time)";
            this.cmsIssueDrivingLicenseFirstTime.Click += new System.EventHandler(this.cmsIssueDrivingLicenseFirstTime_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(305, 6);
            // 
            // cmsShowLicense
            // 
            this.cmsShowLicense.Image = global::DVLD.Properties.Resources.License_View_32;
            this.cmsShowLicense.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmsShowLicense.Name = "cmsShowLicense";
            this.cmsShowLicense.Size = new System.Drawing.Size(308, 38);
            this.cmsShowLicense.Text = "Show License";
            this.cmsShowLicense.Click += new System.EventHandler(this.cmsShowLicense_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(305, 6);
            // 
            // cmsShowPersonLicenseHistory
            // 
            this.cmsShowPersonLicenseHistory.Image = global::DVLD.Properties.Resources.PersonLicenseHistory_32;
            this.cmsShowPersonLicenseHistory.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmsShowPersonLicenseHistory.Name = "cmsShowPersonLicenseHistory";
            this.cmsShowPersonLicenseHistory.Size = new System.Drawing.Size(308, 38);
            this.cmsShowPersonLicenseHistory.Text = "Show Person License History";
            this.cmsShowPersonLicenseHistory.Click += new System.EventHandler(this.cmsShowPersonLicenseHistory_Click);
            // 
            // tbFilterValue
            // 
            this.tbFilterValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFilterValue.Location = new System.Drawing.Point(317, 241);
            this.tbFilterValue.Name = "tbFilterValue";
            this.tbFilterValue.Size = new System.Drawing.Size(239, 27);
            this.tbFilterValue.TabIndex = 22;
            this.tbFilterValue.Visible = false;
            this.tbFilterValue.TextChanged += new System.EventHandler(this.tbFilterValue_TextChanged);
            this.tbFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFilterValue_KeyPress);
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None",
            "L.D.L App ID",
            "National Number",
            "Full Name",
            "Status"});
            this.cbFilterBy.Location = new System.Drawing.Point(116, 241);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(185, 24);
            this.cbFilterBy.TabIndex = 21;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 241);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 19;
            this.label2.Text = "Filter By:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(437, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(400, 29);
            this.label1.TabIndex = 18;
            this.label1.Text = "Local Driving License Applicaiton";
            // 
            // btnAddNewLocalApp
            // 
            this.btnAddNewLocalApp.Image = global::DVLD.Properties.Resources.Application_Types_64;
            this.btnAddNewLocalApp.Location = new System.Drawing.Point(1202, 183);
            this.btnAddNewLocalApp.Name = "btnAddNewLocalApp";
            this.btnAddNewLocalApp.Size = new System.Drawing.Size(93, 82);
            this.btnAddNewLocalApp.TabIndex = 26;
            this.btnAddNewLocalApp.UseVisualStyleBackColor = true;
            this.btnAddNewLocalApp.Click += new System.EventHandler(this.btnAddNewLocalApp_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Image = global::DVLD.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1180, 659);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(108, 42);
            this.btnClose.TabIndex = 27;
            this.btnClose.Text = "     Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.Properties.Resources.Application_Types_512;
            this.pictureBox1.Location = new System.Drawing.Point(545, -8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(176, 180);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // cbIsActive
            // 
            this.cbIsActive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIsActive.FormattingEnabled = true;
            this.cbIsActive.Items.AddRange(new object[] {
            "None",
            "L.D.L App ID",
            "National Number",
            "Full Name",
            "Status"});
            this.cbIsActive.Location = new System.Drawing.Point(317, 244);
            this.cbIsActive.Name = "cbIsActive";
            this.cbIsActive.Size = new System.Drawing.Size(185, 24);
            this.cbIsActive.TabIndex = 21;
            this.cbIsActive.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // frmManageLocalDrivingLicApp
            // 
            this.AcceptButton = this.btnAddNewLocalApp;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1307, 706);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnAddNewLocalApp);
            this.Controls.Add(this.dgvAllLocalApps);
            this.Controls.Add(this.tbFilterValue);
            this.Controls.Add(this.cbIsActive);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmManageLocalDrivingLicApp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmManageLocalDrivingLicApp";
            this.Load += new System.EventHandler(this.frmManageLocalDrivingLicApp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllLocalApps)).EndInit();
            this.cmsMnageLocalApps.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnAddNewLocalApp;
        private System.Windows.Forms.DataGridView dgvAllLocalApps;
        private System.Windows.Forms.TextBox tbFilterValue;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip cmsMnageLocalApps;
        private System.Windows.Forms.ToolStripMenuItem cmsAddNewLocalApp;
        private System.Windows.Forms.ToolStripMenuItem cmsEditApp;
        private System.Windows.Forms.ToolStripMenuItem cmsShowAppDetails;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cmsDeleteApp;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem cmsCancelApp;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem cmsScheduleTests;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem cmsIssueDrivingLicenseFirstTime;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem cmsShowLicense;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem cmsShowPersonLicenseHistory;
        private System.Windows.Forms.ToolStripMenuItem cmsScheduleVisionTest;
        private System.Windows.Forms.ToolStripMenuItem cmsScheduleWrittenTest;
        private System.Windows.Forms.ToolStripMenuItem cmsScheduleStreetTest;
        private System.Windows.Forms.ComboBox cbIsActive;
    }
}