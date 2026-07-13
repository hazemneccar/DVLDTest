namespace DVLD.People
{
    partial class frmManagePeople
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
            this.dgvPeople = new System.Windows.Forms.DataGridView();
            this.cmsPeople = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showDetailstsm = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.addNewPersontsm = new System.Windows.Forms.ToolStripMenuItem();
            this.edittsm = new System.Windows.Forms.ToolStripMenuItem();
            this.deletetsm = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.sendEmailtsm = new System.Windows.Forms.ToolStripMenuItem();
            this.PhoneCalltsm = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.lblFilterValue = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cbCountries = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeople)).BeginInit();
            this.cmsPeople.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(561, 212);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Manage People";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 258);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Filter By:";
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None",
            "Person ID",
            "National No",
            "First Name",
            "Second Name",
            "Third Name",
            "Last Name",
            "Nationality",
            "Gender",
            "Phone",
            "Email"});
            this.cbFilterBy.Location = new System.Drawing.Point(77, 255);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(190, 24);
            this.cbFilterBy.TabIndex = 3;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // dgvPeople
            // 
            this.dgvPeople.AllowUserToAddRows = false;
            this.dgvPeople.AllowUserToDeleteRows = false;
            this.dgvPeople.AllowUserToOrderColumns = true;
            this.dgvPeople.BackgroundColor = System.Drawing.Color.White;
            this.dgvPeople.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPeople.ContextMenuStrip = this.cmsPeople;
            this.dgvPeople.Location = new System.Drawing.Point(1, 285);
            this.dgvPeople.Name = "dgvPeople";
            this.dgvPeople.ReadOnly = true;
            this.dgvPeople.RowHeadersWidth = 51;
            this.dgvPeople.RowTemplate.Height = 24;
            this.dgvPeople.Size = new System.Drawing.Size(1545, 298);
            this.dgvPeople.TabIndex = 4;
            // 
            // cmsPeople
            // 
            this.cmsPeople.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsPeople.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDetailstsm,
            this.toolStripMenuItem1,
            this.addNewPersontsm,
            this.edittsm,
            this.deletetsm,
            this.toolStripMenuItem2,
            this.sendEmailtsm,
            this.PhoneCalltsm});
            this.cmsPeople.Name = "cmsPeople";
            this.cmsPeople.Size = new System.Drawing.Size(204, 244);
            // 
            // showDetailstsm
            // 
            this.showDetailstsm.Image = global::DVLD.Properties.Resources.PersonDetails_32;
            this.showDetailstsm.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showDetailstsm.Name = "showDetailstsm";
            this.showDetailstsm.Size = new System.Drawing.Size(203, 38);
            this.showDetailstsm.Text = "Show Details";
            this.showDetailstsm.Click += new System.EventHandler(this.showDetailstsm_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(200, 6);
            // 
            // addNewPersontsm
            // 
            this.addNewPersontsm.Image = global::DVLD.Properties.Resources.AddPerson_32;
            this.addNewPersontsm.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.addNewPersontsm.Name = "addNewPersontsm";
            this.addNewPersontsm.Size = new System.Drawing.Size(203, 38);
            this.addNewPersontsm.Text = "Add New Person";
            this.addNewPersontsm.Click += new System.EventHandler(this.addNewPerson);
            // 
            // edittsm
            // 
            this.edittsm.Image = global::DVLD.Properties.Resources.edit_32;
            this.edittsm.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.edittsm.Name = "edittsm";
            this.edittsm.Size = new System.Drawing.Size(203, 38);
            this.edittsm.Text = "Edit";
            this.edittsm.Click += new System.EventHandler(this.edittsm_Click);
            // 
            // deletetsm
            // 
            this.deletetsm.Image = global::DVLD.Properties.Resources.Delete_32;
            this.deletetsm.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.deletetsm.Name = "deletetsm";
            this.deletetsm.Size = new System.Drawing.Size(203, 38);
            this.deletetsm.Text = "Delete";
            this.deletetsm.Click += new System.EventHandler(this.deletetsm_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(200, 6);
            // 
            // sendEmailtsm
            // 
            this.sendEmailtsm.Image = global::DVLD.Properties.Resources.send_email_32;
            this.sendEmailtsm.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.sendEmailtsm.Name = "sendEmailtsm";
            this.sendEmailtsm.Size = new System.Drawing.Size(203, 38);
            this.sendEmailtsm.Text = "Send Email";
            // 
            // PhoneCalltsm
            // 
            this.PhoneCalltsm.Image = global::DVLD.Properties.Resources.call_32;
            this.PhoneCalltsm.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.PhoneCalltsm.Name = "PhoneCalltsm";
            this.PhoneCalltsm.Size = new System.Drawing.Size(203, 38);
            this.PhoneCalltsm.Text = "Phone Call";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 589);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "#Records:";
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsCount.Location = new System.Drawing.Point(105, 590);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(0, 20);
            this.lblRecordsCount.TabIndex = 6;
            // 
            // lblFilterValue
            // 
            this.lblFilterValue.Location = new System.Drawing.Point(273, 255);
            this.lblFilterValue.Name = "lblFilterValue";
            this.lblFilterValue.Size = new System.Drawing.Size(179, 22);
            this.lblFilterValue.TabIndex = 7;
            this.lblFilterValue.Visible = false;
            this.lblFilterValue.TextChanged += new System.EventHandler(this.txtFilterValue_TextChanged);
            // 
            // button1
            // 
            this.button1.Image = global::DVLD.Properties.Resources.Add_Person_40;
            this.button1.Location = new System.Drawing.Point(1470, 212);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(65, 62);
            this.button1.TabIndex = 9;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.addNewPerson);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.Properties.Resources.People_400;
            this.pictureBox1.Location = new System.Drawing.Point(571, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 200);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // cbCountries
            // 
            this.cbCountries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCountries.FormattingEnabled = true;
            this.cbCountries.Location = new System.Drawing.Point(273, 255);
            this.cbCountries.Name = "cbCountries";
            this.cbCountries.Size = new System.Drawing.Size(179, 24);
            this.cbCountries.TabIndex = 10;
            this.cbCountries.Visible = false;
            this.cbCountries.SelectedIndexChanged += new System.EventHandler(this.cbCountries_SelectedIndexChanged);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Image = global::DVLD.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1438, 590);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(108, 42);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "     Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmManagePeople
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1547, 637);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.cbCountries);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblFilterValue);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvPeople);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Name = "frmManagePeople";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmManagePeople";
            this.Load += new System.EventHandler(this.frmManagePeople_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeople)).EndInit();
            this.cmsPeople.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.DataGridView dgvPeople;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.TextBox lblFilterValue;
        private System.Windows.Forms.ContextMenuStrip cmsPeople;
        private System.Windows.Forms.ToolStripMenuItem showDetailstsm;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addNewPersontsm;
        private System.Windows.Forms.ToolStripMenuItem edittsm;
        private System.Windows.Forms.ToolStripMenuItem deletetsm;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem sendEmailtsm;
        private System.Windows.Forms.ToolStripMenuItem PhoneCalltsm;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbCountries;
        private System.Windows.Forms.Button btnClose;
    }
}