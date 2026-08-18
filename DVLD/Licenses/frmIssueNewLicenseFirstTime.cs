using DVLD.Global_Classes;
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

namespace DVLD.Licenses
{
    public partial class frmIssueNewLicenseFirstTime : Form
    {
        private int _LocalAppID=-1;
        private clslocalDrivingApp _LocalAppInfo;
        public frmIssueNewLicenseFirstTime(int localAppID)
        {
            InitializeComponent();
            _LocalAppID = localAppID;
            _LocalAppInfo = clslocalDrivingApp.Find(_LocalAppID);
        }

        private void frmIssueNewLicenseFirstTime_Load(object sender, EventArgs e)
        {
            if (_LocalAppInfo==null)
            {
                MessageBox.Show("There is no this Local App ID!");
                this.Close();
                return;
            }
            if(!_LocalAppInfo.PassedAllTests())
            {
                MessageBox.Show("You should finish all tests!");
                this.Close();
                return;
            }
            ctrlLocalDrivingAppInfo1.LoadLocalAppInfoByLocalAppID(_LocalAppID);
            lblClassFees.Text = clsLicenseClass.Find(_LocalAppInfo.LicenseClassID).ClassFees.ToString();
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (clsLicenseClass.Find(_LocalAppInfo.LicenseClassID).MinimumAllowedAge > clsUtilityBusiness.CalculateAge(_LocalAppInfo.ApplicantPersonInfo.DateOfBirth))
            {
                MessageBox.Show("Your age is tutmuyor efendim!");
            }

            int IssuedLicenseID = _LocalAppInfo.IssueLicenseForTheFirstTime(tbNotes.Text, clsGlobal.CurrentUser.UserID);
            if (IssuedLicenseID != -1)
            {
                MessageBox.Show("License Issued successfully with license ID=" + IssuedLicenseID.ToString());
            }
            else
            {
                MessageBox.Show("Error while saving!");
            }
            this.Close();
        }
    }
}
