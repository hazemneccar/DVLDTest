using DVLD.Global_Classes;
using DVLD.Licenses;
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

namespace DVLD.Applications.Replace_License
{
    public partial class frmReplaceLicense : Form
    {
        private int _LicenseID;
        private clsLicense _LicenseInfo;

        private int _NewLicenseID = -1;
        private clsLicense _NewLicenseInfo;

        private clsLicense.enIssueReason _IssueReason=clsLicense.enIssueReason.ReplacementForDamaged;
        public frmReplaceLicense()
        {
            InitializeComponent();
        }
        private void LoadDefaultValues()
        {
            lblAppDate.Text = clsFormat.DateToShort(DateTime.Now);
           
            lblCreatedByUserID.Text = clsGlobal.CurrentUser.UserName;
            lblOldLicenseID.Text = _LicenseID.ToString();
            lblReplacedAppID.Text = "[???]";
            lblReplacedLicID.Text = "[???]";
        }
        private void ctrlLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            clsLicense License = clsLicense.Find(obj);
            if (License == null)
            {
                MessageBox.Show("There is no this License Info!!");
                btnIssue.Enabled = false;
                return;
            }
            linkShowLicensesHistory.Enabled = true;
            _LicenseInfo = License;
            _LicenseID = License.LicenseID;
            if (License.isLicenseExpired())
            {
                MessageBox.Show("This License must be expired!, it will exprire on " + clsFormat.DateToShort(License.ExpirationDate) + " !");
                btnIssue.Enabled = false;
                return;
            }
            if (!License.isActive)
            {
                MessageBox.Show("This License must be active!!");
                btnIssue.Enabled = false;
                return;
            }
            
            btnIssue.Enabled = true;
            LoadDefaultValues();
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (_LicenseInfo.isLicenseExpired())
                return;
            if (!_LicenseInfo.isActive)
                return;
            if (MessageBox.Show("Are you sure you want to replace this license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                clsLicense NewLicense = _LicenseInfo.Replace(_IssueReason,clsGlobal.CurrentUser.UserID);
                if (NewLicense != null)
                {
                    _NewLicenseInfo = NewLicense;
                    _NewLicenseID = NewLicense.LicenseID;
                    MessageBox.Show("License Replaced Successfully with ID=" + _NewLicenseID);
                    linkShowLicenseInfo.Enabled = true;
                    btnIssue.Enabled = false;
                    lblReplacedAppID.Text = _NewLicenseInfo.ApplicationID.ToString();
                    lblReplacedLicID.Text = _NewLicenseID.ToString();
                }
                else
                {
                    MessageBox.Show("Error while saving!");

                }
            }
        }

        private void Replacement_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDamagedLicense.Checked)
            {
                _IssueReason = clsLicense.enIssueReason.ReplacementForDamaged;
                lblAppFees.Text = clsApplicationType.Find(clsApplication.enApplicationTypes.ReplacementForDamagedDrivingLicense).ApplicationFees.ToString();
                lblTitle.Text = "Replacement For Damaged License";
            }
            else
            {
                _IssueReason = clsLicense.enIssueReason.ReplacementForLost;
                lblAppFees.Text = clsApplicationType.Find(clsApplication.enApplicationTypes.ReplacementForLostDrivingLicense).ApplicationFees.ToString();
                lblTitle.Text = "Replacement For Lost License";
            }
        }

        private void linkShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo(_NewLicenseID);
            frm.ShowDialog();
        }

        private void linkShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int DriverID = _LicenseInfo.DriverID;
            frmLicenseHistory frm = new frmLicenseHistory(DriverID);
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
