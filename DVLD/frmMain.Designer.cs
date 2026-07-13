namespace DVLD
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.msApplications = new System.Windows.Forms.ToolStripMenuItem();
            this.drivingLicensesServicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newDrivingLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.locaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.internationalLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renewDrivingLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.replacementForToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.realeseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.retakeTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageApplicationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localDrivingLicenseApplicationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.internationalLicenseApplicationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.detainLicencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageDetainedLicensesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detainLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.releaseDetainedLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageApplicationTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageTestTyprsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.msPeople = new System.Windows.Forms.ToolStripMenuItem();
            this.msDrivers = new System.Windows.Forms.ToolStripMenuItem();
            this.msUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.msAccountSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.currentUserInfotsm = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordtsm = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.signOuttsm = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msApplications,
            this.msPeople,
            this.msDrivers,
            this.msUsers,
            this.msAccountSettings});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1006, 72);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // msApplications
            // 
            this.msApplications.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.drivingLicensesServicesToolStripMenuItem,
            this.manageApplicationsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.detainLicencesToolStripMenuItem,
            this.manageApplicationTypesToolStripMenuItem,
            this.manageTestTyprsToolStripMenuItem});
            this.msApplications.Image = global::DVLD.Properties.Resources.Application_Types_64;
            this.msApplications.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.msApplications.Name = "msApplications";
            this.msApplications.Size = new System.Drawing.Size(170, 68);
            this.msApplications.Text = "Applications";
            // 
            // drivingLicensesServicesToolStripMenuItem
            // 
            this.drivingLicensesServicesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newDrivingLicenseToolStripMenuItem,
            this.renewDrivingLicenseToolStripMenuItem,
            this.toolStripMenuItem2,
            this.replacementForToolStripMenuItem,
            this.toolStripMenuItem3,
            this.realeseToolStripMenuItem,
            this.retakeTestToolStripMenuItem});
            this.drivingLicensesServicesToolStripMenuItem.Image = global::DVLD.Properties.Resources.LocalDriving_License;
            this.drivingLicensesServicesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.drivingLicensesServicesToolStripMenuItem.Name = "drivingLicensesServicesToolStripMenuItem";
            this.drivingLicensesServicesToolStripMenuItem.Size = new System.Drawing.Size(281, 38);
            this.drivingLicensesServicesToolStripMenuItem.Text = "Driving Licenses Services";
            // 
            // newDrivingLicenseToolStripMenuItem
            // 
            this.newDrivingLicenseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.locaToolStripMenuItem,
            this.internationalLicenseToolStripMenuItem});
            this.newDrivingLicenseToolStripMenuItem.Image = global::DVLD.Properties.Resources.New_Driving_License_32;
            this.newDrivingLicenseToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.newDrivingLicenseToolStripMenuItem.Name = "newDrivingLicenseToolStripMenuItem";
            this.newDrivingLicenseToolStripMenuItem.Size = new System.Drawing.Size(385, 38);
            this.newDrivingLicenseToolStripMenuItem.Text = "New Driving License";
            // 
            // locaToolStripMenuItem
            // 
            this.locaToolStripMenuItem.Image = global::DVLD.Properties.Resources.Local_32;
            this.locaToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.locaToolStripMenuItem.Name = "locaToolStripMenuItem";
            this.locaToolStripMenuItem.Size = new System.Drawing.Size(240, 38);
            this.locaToolStripMenuItem.Text = "Local License";
            // 
            // internationalLicenseToolStripMenuItem
            // 
            this.internationalLicenseToolStripMenuItem.Image = global::DVLD.Properties.Resources.International_32;
            this.internationalLicenseToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.internationalLicenseToolStripMenuItem.Name = "internationalLicenseToolStripMenuItem";
            this.internationalLicenseToolStripMenuItem.Size = new System.Drawing.Size(240, 38);
            this.internationalLicenseToolStripMenuItem.Text = "International License";
            // 
            // renewDrivingLicenseToolStripMenuItem
            // 
            this.renewDrivingLicenseToolStripMenuItem.Image = global::DVLD.Properties.Resources.Renew_Driving_License_32;
            this.renewDrivingLicenseToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.renewDrivingLicenseToolStripMenuItem.Name = "renewDrivingLicenseToolStripMenuItem";
            this.renewDrivingLicenseToolStripMenuItem.Size = new System.Drawing.Size(385, 38);
            this.renewDrivingLicenseToolStripMenuItem.Text = "Renew Driving License";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(382, 6);
            // 
            // replacementForToolStripMenuItem
            // 
            this.replacementForToolStripMenuItem.Image = global::DVLD.Properties.Resources.Damaged_Driving_License_32;
            this.replacementForToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.replacementForToolStripMenuItem.Name = "replacementForToolStripMenuItem";
            this.replacementForToolStripMenuItem.Size = new System.Drawing.Size(385, 38);
            this.replacementForToolStripMenuItem.Text = "Replacement for Lost or Damaged License";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(382, 6);
            // 
            // realeseToolStripMenuItem
            // 
            this.realeseToolStripMenuItem.Image = global::DVLD.Properties.Resources.Release_Detained_License_32;
            this.realeseToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.realeseToolStripMenuItem.Name = "realeseToolStripMenuItem";
            this.realeseToolStripMenuItem.Size = new System.Drawing.Size(385, 38);
            this.realeseToolStripMenuItem.Text = "Realese Detained Driving License ";
            // 
            // retakeTestToolStripMenuItem
            // 
            this.retakeTestToolStripMenuItem.Image = global::DVLD.Properties.Resources.Retake_Test_32;
            this.retakeTestToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.retakeTestToolStripMenuItem.Name = "retakeTestToolStripMenuItem";
            this.retakeTestToolStripMenuItem.Size = new System.Drawing.Size(385, 38);
            this.retakeTestToolStripMenuItem.Text = "Retake Test";
            // 
            // manageApplicationsToolStripMenuItem
            // 
            this.manageApplicationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.localDrivingLicenseApplicationsToolStripMenuItem,
            this.internationalLicenseApplicationsToolStripMenuItem});
            this.manageApplicationsToolStripMenuItem.Image = global::DVLD.Properties.Resources.Manage_Applications_32;
            this.manageApplicationsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.manageApplicationsToolStripMenuItem.Name = "manageApplicationsToolStripMenuItem";
            this.manageApplicationsToolStripMenuItem.Size = new System.Drawing.Size(281, 38);
            this.manageApplicationsToolStripMenuItem.Text = "Manage Applications";
            // 
            // localDrivingLicenseApplicationsToolStripMenuItem
            // 
            this.localDrivingLicenseApplicationsToolStripMenuItem.Image = global::DVLD.Properties.Resources.LocalDriving_License;
            this.localDrivingLicenseApplicationsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.localDrivingLicenseApplicationsToolStripMenuItem.Name = "localDrivingLicenseApplicationsToolStripMenuItem";
            this.localDrivingLicenseApplicationsToolStripMenuItem.Size = new System.Drawing.Size(330, 38);
            this.localDrivingLicenseApplicationsToolStripMenuItem.Text = "Local Driving License Applications";
            // 
            // internationalLicenseApplicationsToolStripMenuItem
            // 
            this.internationalLicenseApplicationsToolStripMenuItem.Image = global::DVLD.Properties.Resources.International_32;
            this.internationalLicenseApplicationsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.internationalLicenseApplicationsToolStripMenuItem.Name = "internationalLicenseApplicationsToolStripMenuItem";
            this.internationalLicenseApplicationsToolStripMenuItem.Size = new System.Drawing.Size(330, 38);
            this.internationalLicenseApplicationsToolStripMenuItem.Text = "International License Applications";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(278, 6);
            // 
            // detainLicencesToolStripMenuItem
            // 
            this.detainLicencesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageDetainedLicensesToolStripMenuItem,
            this.detainLicenseToolStripMenuItem,
            this.releaseDetainedLicenseToolStripMenuItem});
            this.detainLicencesToolStripMenuItem.Image = global::DVLD.Properties.Resources.Detain_32;
            this.detainLicencesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.detainLicencesToolStripMenuItem.Name = "detainLicencesToolStripMenuItem";
            this.detainLicencesToolStripMenuItem.Size = new System.Drawing.Size(281, 38);
            this.detainLicencesToolStripMenuItem.Text = "Detain Licenses";
            // 
            // manageDetainedLicensesToolStripMenuItem
            // 
            this.manageDetainedLicensesToolStripMenuItem.Image = global::DVLD.Properties.Resources.Detain_32;
            this.manageDetainedLicensesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.manageDetainedLicensesToolStripMenuItem.Name = "manageDetainedLicensesToolStripMenuItem";
            this.manageDetainedLicensesToolStripMenuItem.Size = new System.Drawing.Size(282, 38);
            this.manageDetainedLicensesToolStripMenuItem.Text = "Manage Detained Licenses";
            // 
            // detainLicenseToolStripMenuItem
            // 
            this.detainLicenseToolStripMenuItem.Image = global::DVLD.Properties.Resources.Detain_32;
            this.detainLicenseToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.detainLicenseToolStripMenuItem.Name = "detainLicenseToolStripMenuItem";
            this.detainLicenseToolStripMenuItem.Size = new System.Drawing.Size(282, 38);
            this.detainLicenseToolStripMenuItem.Text = "Detain License";
            // 
            // releaseDetainedLicenseToolStripMenuItem
            // 
            this.releaseDetainedLicenseToolStripMenuItem.Image = global::DVLD.Properties.Resources.Release_Detained_License_32;
            this.releaseDetainedLicenseToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.releaseDetainedLicenseToolStripMenuItem.Name = "releaseDetainedLicenseToolStripMenuItem";
            this.releaseDetainedLicenseToolStripMenuItem.Size = new System.Drawing.Size(282, 38);
            this.releaseDetainedLicenseToolStripMenuItem.Text = "Release Detained License";
            // 
            // manageApplicationTypesToolStripMenuItem
            // 
            this.manageApplicationTypesToolStripMenuItem.Image = global::DVLD.Properties.Resources.ApplicationType;
            this.manageApplicationTypesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.manageApplicationTypesToolStripMenuItem.Name = "manageApplicationTypesToolStripMenuItem";
            this.manageApplicationTypesToolStripMenuItem.Size = new System.Drawing.Size(281, 38);
            this.manageApplicationTypesToolStripMenuItem.Text = "Manage Application Types";
            this.manageApplicationTypesToolStripMenuItem.Click += new System.EventHandler(this.manageApplicationTypesToolStripMenuItem_Click);
            // 
            // manageTestTyprsToolStripMenuItem
            // 
            this.manageTestTyprsToolStripMenuItem.Image = global::DVLD.Properties.Resources.Manage_Applications_321;
            this.manageTestTyprsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.manageTestTyprsToolStripMenuItem.Name = "manageTestTyprsToolStripMenuItem";
            this.manageTestTyprsToolStripMenuItem.Size = new System.Drawing.Size(281, 38);
            this.manageTestTyprsToolStripMenuItem.Text = "Manage Test Types";
            // 
            // msPeople
            // 
            this.msPeople.Image = ((System.Drawing.Image)(resources.GetObject("msPeople.Image")));
            this.msPeople.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.msPeople.Name = "msPeople";
            this.msPeople.Size = new System.Drawing.Size(132, 68);
            this.msPeople.Text = "People";
            this.msPeople.Click += new System.EventHandler(this.msPeople_Click);
            // 
            // msDrivers
            // 
            this.msDrivers.Image = global::DVLD.Properties.Resources.Drivers_64;
            this.msDrivers.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.msDrivers.Name = "msDrivers";
            this.msDrivers.Size = new System.Drawing.Size(133, 68);
            this.msDrivers.Text = "Drivers";
            // 
            // msUsers
            // 
            this.msUsers.Image = global::DVLD.Properties.Resources.Users_2_64;
            this.msUsers.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.msUsers.Name = "msUsers";
            this.msUsers.Size = new System.Drawing.Size(122, 68);
            this.msUsers.Text = "Users";
            this.msUsers.Click += new System.EventHandler(this.msUsers_Click);
            // 
            // msAccountSettings
            // 
            this.msAccountSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentUserInfotsm,
            this.changePasswordtsm,
            this.toolStripMenuItem4,
            this.signOuttsm});
            this.msAccountSettings.Image = global::DVLD.Properties.Resources.account_settings_64;
            this.msAccountSettings.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.msAccountSettings.Name = "msAccountSettings";
            this.msAccountSettings.Size = new System.Drawing.Size(198, 68);
            this.msAccountSettings.Text = "Account Settings";
            // 
            // currentUserInfotsm
            // 
            this.currentUserInfotsm.Image = global::DVLD.Properties.Resources.PersonDetails_321;
            this.currentUserInfotsm.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.currentUserInfotsm.Name = "currentUserInfotsm";
            this.currentUserInfotsm.Size = new System.Drawing.Size(219, 38);
            this.currentUserInfotsm.Text = "Current User Info";
            this.currentUserInfotsm.Click += new System.EventHandler(this.currentUserInfotsm_Click);
            // 
            // changePasswordtsm
            // 
            this.changePasswordtsm.Image = global::DVLD.Properties.Resources.Password_32;
            this.changePasswordtsm.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.changePasswordtsm.Name = "changePasswordtsm";
            this.changePasswordtsm.Size = new System.Drawing.Size(219, 38);
            this.changePasswordtsm.Text = "Change Password";
            this.changePasswordtsm.Click += new System.EventHandler(this.changePasswordtsm_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(216, 6);
            // 
            // signOuttsm
            // 
            this.signOuttsm.Image = global::DVLD.Properties.Resources.sign_out_32__2;
            this.signOuttsm.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.signOuttsm.Name = "signOuttsm";
            this.signOuttsm.Size = new System.Drawing.Size(219, 38);
            this.signOuttsm.Text = "Sign Out";
            this.signOuttsm.Click += new System.EventHandler(this.signOuttsm_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::DVLD.Properties.Resources.Driver___Vehicle;
            this.pictureBox1.Location = new System.Drawing.Point(0, 72);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1006, 457);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(38)))), ((int)(((byte)(35)))));
            this.ClientSize = new System.Drawing.Size(1006, 529);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem msApplications;
        private System.Windows.Forms.ToolStripMenuItem msPeople;
        private System.Windows.Forms.ToolStripMenuItem msDrivers;
        private System.Windows.Forms.ToolStripMenuItem msUsers;
        private System.Windows.Forms.ToolStripMenuItem msAccountSettings;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem drivingLicensesServicesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newDrivingLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renewDrivingLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem replacementForToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem realeseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem retakeTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageApplicationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem detainLicencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageApplicationTypesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageTestTyprsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem locaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem internationalLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem currentUserInfotsm;
        private System.Windows.Forms.ToolStripMenuItem changePasswordtsm;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem signOuttsm;
        private System.Windows.Forms.ToolStripMenuItem localDrivingLicenseApplicationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem internationalLicenseApplicationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageDetainedLicensesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detainLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem releaseDetainedLicenseToolStripMenuItem;
    }
}

