using DVLD.Global_Classes;
using DVLD.Properties;
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
using System.IO;
namespace DVLD.Licenses.Local_Licenses.Controls
{
    public partial class ctrlLicenseInfo : UserControl
    {
        private clsLicense _License;
        public clsLicense SelectedLicenseInfo { get { return _License; } }

        private int _LicenseID;
        public int LicenseID { get { return _LicenseID; } }
        public ctrlLicenseInfo()
        {
            InitializeComponent();
        }
        private void ResetAllValues()
        {
            imgProfile.Image = Resources.Male_512;
            lblClassName.Text = "";
            lblDateOfBirth.Text = "";
            lblDriverID.Text = "";
            lblExpirationDate.Text = "";
            lblFullName.Text = "";
            lblGender.Text = "";
            lblIsActive.Text = "";
            lblIsDetained.Text = "";
            lblIssueDate.Text = "";
            lblIssueReason.Text = "";
            lblNationalNo.Text = "";
            lblNotes.Text = "";
        }
        public void LoadLicenseInfo(int LicenseID)
        {
            ResetAllValues();
            clsLicense License  = clsLicense.Find(LicenseID);
            if (License == null)
            {
                MessageBox.Show("License ID="+LicenseID.ToString() + " is not found!");
                return;
            }
            _License = License;
            lblLicenseID.Text = _License.LicenseID.ToString();
            lblClassName.Text = _License.LicenseClassInfo.ClassName;
            lblDateOfBirth.Text=clsFormat.DateToShort(_License.DriverInfo.PersonInfo.DateOfBirth);
            lblDriverID.Text=_License.DriverID.ToString();
            lblExpirationDate.Text = clsFormat.DateToShort(_License.ExpirationDate);
            lblFullName.Text = _License.DriverInfo.PersonInfo.FullName;
            
            switch (_License.DriverInfo.PersonInfo.Gender)
            {
                case clsPerson.enGender.enMale:
                    if (_License.DriverInfo.PersonInfo.ImagePath == null) 
                        imgProfile.Image = Resources.Male_512;
                    else
                        if (File.Exists(_License.DriverInfo.PersonInfo.ImagePath))
                            imgProfile.ImageLocation = _License.DriverInfo.PersonInfo.ImagePath;
                        lblGender.Text = "Male";
                    break;
                case clsPerson.enGender.enFemale:
                    if (_License.DriverInfo.PersonInfo.ImagePath == null)
                        imgProfile.Image = Resources.Female;
                    else
                        if (File.Exists(_License.DriverInfo.PersonInfo.ImagePath))
                            imgProfile.ImageLocation = _License.DriverInfo.PersonInfo.ImagePath;
                    lblGender.Text = "Female";
                    break;
                default:
                    lblGender.Text = "Unknown";
                    break;
            }
            lblIsActive.Text = _License.isActive ? "Yes" : "No";
            lblIsDetained.Text = _License.IsDetained ? "Yes" : "No";
            lblIssueDate.Text= clsFormat.DateToShort(_License.IssueDate);
            lblIssueReason.Text = _License.IssueReasonText;
            lblNationalNo.Text = _License.DriverInfo.PersonInfo.NationalID;
            lblNotes.Text = _License.Notes==string.Empty?"No notes":_License.Notes;
        }
    }
}
