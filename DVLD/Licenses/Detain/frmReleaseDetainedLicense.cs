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
    public partial class frmReleaseDetainedLicense : Form
    {
        int _LicenseID = -1;
        clsLicense _LicenseInfo;
        int _DetainID = -1;
        clsDetainedLicense _DetainInfo;
        public frmReleaseDetainedLicense()
        {
            InitializeComponent();
        }
        public frmReleaseDetainedLicense(int licenseID)
        {
            InitializeComponent();
            clsLicense DetainedLicenseInfo = clsLicense.Find(licenseID);
            ctrlLicenseInfoWithFilter1.LoadLicenseInfo(licenseID);
            ctrlLicenseInfoWithFilter1.FilterEnabled = false;
        }
        private void FillDefalutValues()
        {
            //ctrlName.selectedLicenseInfo.DetainInfo.flnfln da kullanılabilirdi
            lblDetainID.Text = _DetainInfo.DetainID.ToString();
            lblAppFees.Text = clsApplicationType.Find(clsApplication.enApplicationTypes.ReleaseDetainedDrivingLicense).ApplicationFees.ToString();
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
            lblDetainDate.Text = clsFormat.DateToShort(_DetainInfo.DetainDate);
            lblApplicationID.Text = "[???]";
            lblFineFees.Text = _DetainInfo.FineFees.ToString();
            lblLicenseID.Text=_LicenseID.ToString();
            lblTotalFees.Text=(_DetainInfo.FineFees+Convert.ToSingle(lblAppFees.Text)).ToString();
        }

        private void ctrlLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            linkShowLicenseInfo.Enabled = true;
            linkShowLicensesHistory.Enabled = true;
            if (!clsLicense.Find(obj).IsDetained)
            {
                MessageBox.Show("This license is not detained already!");
                return;
            }
            btnRelease.Enabled = true;
            _LicenseID = obj;
            _LicenseInfo= clsLicense.Find(_LicenseID);
            _DetainInfo=clsDetainedLicense.FindByLicenseID(_LicenseID);
            FillDefalutValues();
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure that you will release this license?","Confirm",MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;
            int RelAppID = -1;
            if (_LicenseInfo.ReleaseLicense(clsGlobal.CurrentUser.UserID, ref RelAppID))
            { 
                if (RelAppID != -1)
                {
                    MessageBox.Show("License Released successfully!");
                    lblApplicationID.Text = RelAppID.ToString();
                    btnRelease.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Error while Released");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
    }
}
