using DVLD.Global_Classes;
using DVLD.Licenses.Local_Licenses;
using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Licenses.Detain
{
    public partial class frmDetainLicense : Form
    {
        private clsLicense _LicenseInfo;
        private int _LicenseID=-1;
        private clsDetainedLicense _DetainedLicenseInfo;
        private int _DetainedLicenseID;
        public frmDetainLicense()
        {
            InitializeComponent();
        }
        public frmDetainLicense(int LicenseID)
        {
            InitializeComponent();
            
            clsLicense DetainedLicenseInfo= clsLicense.Find(LicenseID);
            ctrlLicenseInfoWithFilter1.LoadLicenseInfo(LicenseID);
            ctrlLicenseInfoWithFilter1.FilterEnabled = false;
        }
        private void LoadDefaultValues()
        {
            lblDetainDate.Text = clsFormat.DateToShort(DateTime.Now);
            lblDetainAppID.Text = "[???]";
            lblDetainedLicenseID.Text = "[???]";
            lblCreatedByUser.Text = _LicenseID.ToString();
        }
        private void ctrlLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            clsLicense License = clsLicense.Find(obj);
            linkShowLicensesHistory.Enabled = (License!=null);
            if (License.IsDetained)
            {
                MessageBox.Show("This License is detained already");
                btnDetain.Enabled = false;
                return;
            }
            _LicenseInfo = License;
            _LicenseID = License.LicenseID;
            btnDetain.Enabled = true;
            LoadDefaultValues();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to renew this license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                int DetainLicenseID = _LicenseInfo.DetainLicense(Convert.ToSingle(tbAppFees.Text),clsGlobal.CurrentUser.UserID);
                if (DetainLicenseID != -1)
                {
                    MessageBox.Show("License detained successfully!");
                    _DetainedLicenseID = DetainLicenseID;
                    _DetainedLicenseInfo = clsDetainedLicense.Find(_DetainedLicenseID);
                    lblDetainAppID.Text = DetainLicenseID.ToString();
                    lblDetainDate.Text = clsFormat.DateToShort(DateTime.Now);
                    lblDetainedLicenseID.Text=_LicenseID.ToString();
                    lblCreatedByUser.Text = clsGlobal.CurrentUser.UserName;
                    btnDetain.Enabled=false;
                    linkShowLicenseInfo.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Error while saving!");
                }
            }
        }

        private void linkShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int DriverID = _LicenseInfo.DriverID;
            frmLicenseHistory frm = new frmLicenseHistory(DriverID);
            frm.ShowDialog();
        }

        private void linkShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo(_LicenseID);
            frm.ShowDialog();
        }

        private void frmDetainLicense_Load(object sender, EventArgs e)
        {

        }
    }
}
