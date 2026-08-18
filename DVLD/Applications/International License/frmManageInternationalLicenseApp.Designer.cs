namespace DVLD.Applications.International_License
{
    partial class frmManageInternationalLicenseApp
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAddNewLocalApp = new System.Windows.Forms.Button();
            this.tbFilterValue = new System.Windows.Forms.TextBox();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmsShowPersonLicenseHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsShowLicenseDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClose = new System.Windows.Forms.Button();
            this.cmsShowPersonDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsMnageLocalApps = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.dgvAllInternationalApps = new System.Windows.Forms.DataGridView();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.cbIsUserActive = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.cmsMnageLocalApps.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllInternationalApps)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.Properties.Resources.Application_Types_512;
            this.pictureBox1.Location = new System.Drawing.Point(545, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(176, 180);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            // 
            // btnAddNewLocalApp
            // 
            this.btnAddNewLocalApp.Image = global::DVLD.Properties.Resources.Application_Types_64;
            this.btnAddNewLocalApp.Location = new System.Drawing.Point(1202, 190);
            this.btnAddNewLocalApp.Name = "btnAddNewLocalApp";
            this.btnAddNewLocalApp.Size = new System.Drawing.Size(93, 82);
            this.btnAddNewLocalApp.TabIndex = 36;
            this.btnAddNewLocalApp.UseVisualStyleBackColor = true;
            this.btnAddNewLocalApp.Click += new System.EventHandler(this.btnAddNewLocalApp_Click);
            // 
            // tbFilterValue
            // 
            this.tbFilterValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFilterValue.Location = new System.Drawing.Point(317, 248);
            this.tbFilterValue.Name = "tbFilterValue";
            this.tbFilterValue.Size = new System.Drawing.Size(239, 27);
            this.tbFilterValue.TabIndex = 32;
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
            "International License ID",
            "Application ID",
            "Driver ID",
            "Local License ID",
            "Is Active"});
            this.cbFilterBy.Location = new System.Drawing.Point(116, 248);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(185, 24);
            this.cbFilterBy.TabIndex = 31;
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
            this.label1.Location = new System.Drawing.Point(437, 182);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(392, 29);
            this.label1.TabIndex = 29;
            this.label1.Text = "International License Applicaiton";
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
            // cmsShowLicenseDetails
            // 
            this.cmsShowLicenseDetails.Image = global::DVLD.Properties.Resources.License_View_32;
            this.cmsShowLicenseDetails.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmsShowLicenseDetails.Name = "cmsShowLicenseDetails";
            this.cmsShowLicenseDetails.Size = new System.Drawing.Size(280, 38);
            this.cmsShowLicenseDetails.Text = "Show License Details";
            this.cmsShowLicenseDetails.Click += new System.EventHandler(this.cmsShowLicenseDetails_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Image = global::DVLD.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1180, 666);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(108, 42);
            this.btnClose.TabIndex = 37;
            this.btnClose.Text = "     Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // cmsShowPersonDetails
            // 
            this.cmsShowPersonDetails.Image = global::DVLD.Properties.Resources.PersonDetails_32;
            this.cmsShowPersonDetails.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmsShowPersonDetails.Name = "cmsShowPersonDetails";
            this.cmsShowPersonDetails.Size = new System.Drawing.Size(280, 38);
            this.cmsShowPersonDetails.Text = "Show Person Details";
            this.cmsShowPersonDetails.Click += new System.EventHandler(this.cmsShowPersonDetails_Click);
            // 
            // cmsMnageLocalApps
            // 
            this.cmsMnageLocalApps.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsMnageLocalApps.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsShowPersonDetails,
            this.cmsShowLicenseDetails,
            this.cmsShowPersonLicenseHistory});
            this.cmsMnageLocalApps.Name = "cmsMnageLocalApps";
            this.cmsMnageLocalApps.Size = new System.Drawing.Size(281, 146);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 666);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 20);
            this.label3.TabIndex = 34;
            this.label3.Text = "# Records:";
            // 
            // dgvAllInternationalApps
            // 
            this.dgvAllInternationalApps.AllowUserToAddRows = false;
            this.dgvAllInternationalApps.AllowUserToDeleteRows = false;
            this.dgvAllInternationalApps.AllowUserToOrderColumns = true;
            this.dgvAllInternationalApps.BackgroundColor = System.Drawing.Color.White;
            this.dgvAllInternationalApps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllInternationalApps.ContextMenuStrip = this.cmsMnageLocalApps;
            this.dgvAllInternationalApps.Location = new System.Drawing.Point(27, 290);
            this.dgvAllInternationalApps.Name = "dgvAllInternationalApps";
            this.dgvAllInternationalApps.ReadOnly = true;
            this.dgvAllInternationalApps.RowHeadersWidth = 51;
            this.dgvAllInternationalApps.RowTemplate.Height = 24;
            this.dgvAllInternationalApps.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAllInternationalApps.Size = new System.Drawing.Size(1283, 373);
            this.dgvAllInternationalApps.TabIndex = 33;
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsCount.Location = new System.Drawing.Point(130, 666);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(18, 20);
            this.lblRecordsCount.TabIndex = 35;
            this.lblRecordsCount.Text = "0";
            // 
            // cbIsUserActive
            // 
            this.cbIsUserActive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIsUserActive.FormattingEnabled = true;
            this.cbIsUserActive.Items.AddRange(new object[] {
            "All",
            "Yes",
            "No"});
            this.cbIsUserActive.Location = new System.Drawing.Point(317, 248);
            this.cbIsUserActive.Name = "cbIsUserActive";
            this.cbIsUserActive.Size = new System.Drawing.Size(185, 24);
            this.cbIsUserActive.TabIndex = 38;
            this.cbIsUserActive.Visible = false;
            this.cbIsUserActive.SelectedIndexChanged += new System.EventHandler(this.cbIsUserActive_SelectedIndexChanged);
            // 
            // frmManageInternationalLicenseApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1307, 706);
            this.Controls.Add(this.cbIsUserActive);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnAddNewLocalApp);
            this.Controls.Add(this.tbFilterValue);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvAllInternationalApps);
            this.Controls.Add(this.lblRecordsCount);
            this.Name = "frmManageInternationalLicenseApp";
            this.Text = "frmManageInternationalLicenseApp";
            this.Load += new System.EventHandler(this.frmManageInternationalLicenseApp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.cmsMnageLocalApps.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllInternationalApps)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnAddNewLocalApp;
        private System.Windows.Forms.TextBox tbFilterValue;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem cmsShowPersonLicenseHistory;
        private System.Windows.Forms.ToolStripMenuItem cmsShowLicenseDetails;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ToolStripMenuItem cmsShowPersonDetails;
        private System.Windows.Forms.ContextMenuStrip cmsMnageLocalApps;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvAllInternationalApps;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.ComboBox cbIsUserActive;
    }
}