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

namespace DVLD.Applications.International_License
{
    public partial class frmRenewLocalLicense : Form
    {
        private int _LicenseID;
        private clsLicense _LicenseInfo;

        private int _NewLicenseID = -1;
        private clsLicense _NewLicenseInfo;
        public frmRenewLocalLicense()
        {
            InitializeComponent();
        }
        private void LoadDefaultValues()
        {
            lblAppDate.Text = clsFormat.DateToShort(DateTime.Now);
            lblAppFees.Text = clsApplicationType.Find(clsApplication.enApplicationTypes.RetakeTest).ApplicationFees.ToString();
            lblLicenseFees.Text = clsLicenseClass.Find(_LicenseInfo.LicenseClass).ClassFees.ToString();
            lblTotalFees.Text=(Convert.ToSingle(lblAppFees.Text)+ Convert.ToSingle(lblLicenseFees.Text)).ToString();
            lblCreatedBy.Text=clsGlobal.CurrentUser.UserName;
            lblExpirationDate.Text = clsFormat.DateToShort(DateTime.Now.AddYears(clsLicenseClass.Find(_LicenseInfo.LicenseClass).DefaultValidityLength));
            lblIssueDate.Text = clsFormat.DateToShort(DateTime.Now);
            lblRenewAppID.Text = "[???]";
            lblRenewedLicenseID.Text = "[???]";
            lblOldLicenseID.Text = _LicenseID.ToString();
            
            tbNotes.Text = (_LicenseInfo.Notes != string.Empty)?_LicenseInfo.Notes:string.Empty;
        }
        private void ctrlLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            clsLicense License = clsLicense.Find(obj);
            if (License == null)
            {
                MessageBox.Show("There is no this License Info!!");
                btnRenew.Enabled = false;
                return;
            }
            linkShowLicensesHistory.Enabled = true;
            if (!License.isLicenseExpired())
            {
                MessageBox.Show("This License must be expired!, it will exprire on "+clsFormat.DateToShort(License.ExpirationDate)+" !");
                btnRenew.Enabled = false;
                return;
            }
            if (!License.isActive)
            {
                MessageBox.Show("This License must be active!!");
                btnRenew.Enabled = false;
                return;
            }
            _LicenseInfo = License;
            _LicenseID = License.LicenseID;
            btnRenew.Enabled = true;
            LoadDefaultValues();
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (!_LicenseInfo.isLicenseExpired())
                return;

            if (MessageBox.Show("Are you sure you want to renew this license?","Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Information)==DialogResult.Yes)
            {
                clsLicense NewLicense = _LicenseInfo.Renew(clsGlobal.CurrentUser.UserID, tbNotes.Text.Trim());
                if (NewLicense!=null)
                {
                    _NewLicenseInfo = NewLicense;
                    _NewLicenseID = NewLicense.LicenseID;
                    MessageBox.Show("License Renewed Successfully with ID=" + _NewLicenseID);
                    linkShowLicenseInfo.Enabled = true;
                    btnRenew.Enabled = false;
                    lblRenewAppID.Text = _NewLicenseInfo.ApplicationID.ToString();
                    lblRenewedLicenseID.Text = _NewLicenseID.ToString();
                }
                else
                {
                    MessageBox.Show("Error while saving!");

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
            frmShowLicenseInfo frm = new frmShowLicenseInfo(_NewLicenseID);
            frm.ShowDialog();
        }

        private void frmRenewLocalLicense_Activated(object sender, EventArgs e)
        {
            ctrlLicenseInfoWithFilter1.FilterFocus();
        }
    }
}
