using DVLD.Global_Classes;
using DVLD.Licenses;
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

namespace DVLD.Applications.International_License
{
    public partial class frmAddNewInternationalLicense : Form
    {
        private int _LicenseID;
        private clsLicense _LicenseInfo;

        private int _IntLicenseID = -1;
        private clsInternationalLicense _IntLicenseInfo;
        public frmAddNewInternationalLicense()
        {
            InitializeComponent();
        }
        private void LoadDefaultValues()
        {
            lblAppDate.Text = clsFormat.DateToShort(DateTime.Now);
            lblCreatedBy.Text=clsGlobal.CurrentUser.UserName;
            lblExpirationDate.Text = clsFormat.DateToShort(DateTime.Now.AddYears(1));
            lblFees.Text = clsApplicationType.Find(clsApplication.enApplicationTypes.NewInternationalDrivingLicense).ApplicationFees.ToString();
            lblInternationalAppID.Text = "[???]";
            lblIntLicenseID.Text = "[???]";
            lblIssueDate.Text= clsFormat.DateToShort(DateTime.Now);
            lblLocalLicenseID.Text = _LicenseID.ToString();
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
            if (!License.isActive)
            {
                MessageBox.Show("License Must be Avtive!!");
                btnIssue.Enabled = false;
                return;
            }
           
            linkShowLicensesHistory.Enabled = true;
            if (License.isLicenseExpired())
            {
                MessageBox.Show("This License is expired!!");
                btnIssue.Enabled = false;
                return;
            }
            if (!clsInternationalLicense.IsLocalLicenseClassIsSuitableToBeInternational(License.LicenseID))
            {
                MessageBox.Show("License must be Class 3 (Ordinary License CLass)!!!");
                btnIssue.Enabled = false;
                return;
            }

            int IntLicNumID = clsInternationalLicense.DoesDriverHaveActiveInternationalLicense(License.DriverID);
            if (IntLicNumID != -1)
            {
                MessageBox.Show("There is Active International License with ID="+ IntLicNumID);
                btnIssue.Enabled = false;
                return;
            }

            
             _LicenseInfo = License;
            _LicenseID = License.LicenseID;
            btnIssue.Enabled = true;
            LoadDefaultValues();
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (_LicenseInfo.isLicenseExpired())
                return;
            if (clsInternationalLicense.DoesDriverHaveActiveInternationalLicense(_LicenseInfo.DriverID)!=-1)
                return;
            if (!clsInternationalLicense.IsLocalLicenseClassIsSuitableToBeInternational(_LicenseID))
                return;

            if (MessageBox.Show("Are you sure you want to issue the license?","Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Information)==DialogResult.Yes)
            {
                if (_LicenseInfo.AddInternationalLicense(clsGlobal.CurrentUser.UserID))
                {
                    _IntLicenseInfo = clsInternationalLicense.FindByLocalDrivingLicenseID(_LicenseID);
                    _IntLicenseID = _IntLicenseInfo.InternationalLicenseID;
                    lblInternationalAppID.Text = _IntLicenseInfo.ApplicationID.ToString();
                    lblIntLicenseID.Text = _IntLicenseID.ToString();
                    MessageBox.Show("International License Issued Successfully with ID=" + _IntLicenseID);
                    linkShowLicenseInfo.Enabled = true;
                    btnIssue.Enabled = false;
                }
            }
            
        }

        private void linkShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int DriverID = _LicenseInfo.DriverID;
            frmLicenseHistory frm = new frmLicenseHistory(DriverID);
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkShowLicenseInfo_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmshowInternationalLicenseInfo frm = new frmshowInternationalLicenseInfo(_IntLicenseID);
            frm.ShowDialog();
        }
    }
}
