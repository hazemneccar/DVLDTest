namespace DVLD.Users
{
    partial class frmManageUsers
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.tbFilterValue = new System.Windows.Forms.TextBox();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.cmsManageUsers = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.label3 = new System.Windows.Forms.Label();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.cbIsUserActive = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.showDetailstsm = new System.Windows.Forms.ToolStripMenuItem();
            this.AddNewUsertsm = new System.Windows.Forms.ToolStripMenuItem();
            this.edittsm = new System.Windows.Forms.ToolStripMenuItem();
            this.deletetsm = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordtsm = new System.Windows.Forms.ToolStripMenuItem();
            this.sendGmailtsm = new System.Windows.Forms.ToolStripMenuItem();
            this.phoneCallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.cmsManageUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(407, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Manage Users";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 236);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Filter By:";
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None",
            "User ID",
            "Person ID",
            "Full Name",
            "User Name",
            "Is Active"});
            this.cbFilterBy.Location = new System.Drawing.Point(105, 236);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(185, 24);
            this.cbFilterBy.TabIndex = 3;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // tbFilterValue
            // 
            this.tbFilterValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFilterValue.Location = new System.Drawing.Point(306, 236);
            this.tbFilterValue.Name = "tbFilterValue";
            this.tbFilterValue.Size = new System.Drawing.Size(239, 27);
            this.tbFilterValue.TabIndex = 4;
            this.tbFilterValue.Visible = false;
            this.tbFilterValue.TextChanged += new System.EventHandler(this.lblFilterValue_TextChanged);
            this.tbFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFilterValue_KeyPress);
            // 
            // dgvUsers
            // 
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.AllowUserToOrderColumns = true;
            this.dgvUsers.BackgroundColor = System.Drawing.Color.White;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.ContextMenuStrip = this.cmsManageUsers;
            this.dgvUsers.Location = new System.Drawing.Point(1, 273);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.RowHeadersWidth = 51;
            this.dgvUsers.RowTemplate.Height = 24;
            this.dgvUsers.Size = new System.Drawing.Size(987, 373);
            this.dgvUsers.TabIndex = 5;
            // 
            // cmsManageUsers
            // 
            this.cmsManageUsers.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsManageUsers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDetailstsm,
            this.toolStripMenuItem1,
            this.AddNewUsertsm,
            this.edittsm,
            this.deletetsm,
            this.changePasswordtsm,
            this.toolStripMenuItem2,
            this.sendGmailtsm,
            this.phoneCallToolStripMenuItem});
            this.cmsManageUsers.Name = "cmsManageUsers";
            this.cmsManageUsers.Size = new System.Drawing.Size(210, 282);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(206, 6);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(206, 6);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 654);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "# Records:";
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsCount.Location = new System.Drawing.Point(119, 654);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(18, 20);
            this.lblRecordsCount.TabIndex = 7;
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
            this.cbIsUserActive.Location = new System.Drawing.Point(306, 239);
            this.cbIsUserActive.Name = "cbIsUserActive";
            this.cbIsUserActive.Size = new System.Drawing.Size(185, 24);
            this.cbIsUserActive.TabIndex = 3;
            this.cbIsUserActive.Visible = false;
            this.cbIsUserActive.SelectedIndexChanged += new System.EventHandler(this.cbIsUserActive_SelectedIndexChanged);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Image = global::DVLD.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(880, 652);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(108, 42);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "     Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // button1
            // 
            this.button1.Image = global::DVLD.Properties.Resources.Add_New_User_72;
            this.button1.Location = new System.Drawing.Point(895, 185);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 82);
            this.button1.TabIndex = 8;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.AddNewUser_Click);
            // 
            // showDetailstsm
            // 
            this.showDetailstsm.Image = global::DVLD.Properties.Resources.PersonDetails_32;
            this.showDetailstsm.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showDetailstsm.Name = "showDetailstsm";
            this.showDetailstsm.Size = new System.Drawing.Size(209, 38);
            this.showDetailstsm.Text = "Show Details";
            this.showDetailstsm.Click += new System.EventHandler(this.showDetailstsm_Click);
            // 
            // AddNewUsertsm
            // 
            this.AddNewUsertsm.Image = global::DVLD.Properties.Resources.Add_New_User_32;
            this.AddNewUsertsm.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.AddNewUsertsm.Name = "AddNewUsertsm";
            this.AddNewUsertsm.Size = new System.Drawing.Size(209, 38);
            this.AddNewUsertsm.Text = "Add New User";
            this.AddNewUsertsm.Click += new System.EventHandler(this.AddNewUser_Click);
            // 
            // edittsm
            // 
            this.edittsm.Image = global::DVLD.Properties.Resources.edit_32;
            this.edittsm.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.edittsm.Name = "edittsm";
            this.edittsm.Size = new System.Drawing.Size(209, 38);
            this.edittsm.Text = "Edit";
            this.edittsm.Click += new System.EventHandler(this.edittsm_Click);
            // 
            // deletetsm
            // 
            this.deletetsm.Image = global::DVLD.Properties.Resources.Delete_32;
            this.deletetsm.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.deletetsm.Name = "deletetsm";
            this.deletetsm.Size = new System.Drawing.Size(209, 38);
            this.deletetsm.Text = "Delete";
            this.deletetsm.Click += new System.EventHandler(this.deletetsm_Click);
            // 
            // changePasswordtsm
            // 
            this.changePasswordtsm.Image = global::DVLD.Properties.Resources.Password_32;
            this.changePasswordtsm.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.changePasswordtsm.Name = "changePasswordtsm";
            this.changePasswordtsm.Size = new System.Drawing.Size(209, 38);
            this.changePasswordtsm.Text = "Change Password";
            this.changePasswordtsm.Click += new System.EventHandler(this.changePasswordtsm_Click);
            // 
            // sendGmailtsm
            // 
            this.sendGmailtsm.Image = global::DVLD.Properties.Resources.send_email_32;
            this.sendGmailtsm.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.sendGmailtsm.Name = "sendGmailtsm";
            this.sendGmailtsm.Size = new System.Drawing.Size(209, 38);
            this.sendGmailtsm.Text = "Send Gmail";
            // 
            // phoneCallToolStripMenuItem
            // 
            this.phoneCallToolStripMenuItem.Image = global::DVLD.Properties.Resources.call_32;
            this.phoneCallToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.phoneCallToolStripMenuItem.Name = "phoneCallToolStripMenuItem";
            this.phoneCallToolStripMenuItem.Size = new System.Drawing.Size(209, 38);
            this.phoneCallToolStripMenuItem.Text = "Phone Call";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.Properties.Resources.Users_2_400;
            this.pictureBox1.Location = new System.Drawing.Point(412, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(176, 180);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // frmManageUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1010, 706);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvUsers);
            this.Controls.Add(this.tbFilterValue);
            this.Controls.Add(this.cbIsUserActive);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmManageUsers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmManageUsers";
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.cmsManageUsers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.TextBox tbFilterValue;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ContextMenuStrip cmsManageUsers;
        private System.Windows.Forms.ToolStripMenuItem showDetailstsm;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem AddNewUsertsm;
        private System.Windows.Forms.ToolStripMenuItem edittsm;
        private System.Windows.Forms.ToolStripMenuItem deletetsm;
        private System.Windows.Forms.ToolStripMenuItem changePasswordtsm;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem sendGmailtsm;
        private System.Windows.Forms.ToolStripMenuItem phoneCallToolStripMenuItem;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox cbIsUserActive;
    }
}