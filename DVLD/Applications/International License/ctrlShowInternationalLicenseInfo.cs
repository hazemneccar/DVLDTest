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

namespace DVLD.Applications.International_License
{
    public partial class ctrlShowInternationalLicenseInfo : UserControl
    {
        private clsInternationalLicense _InternationalLicenseInfo;
        private int _InternationalLicenseId;
        public ctrlShowInternationalLicenseInfo()
        {
            InitializeComponent();
        }
        private void ResetAllValues()
        {
            imgProfile.Image = Resources.Male_512;
            lblDateOfBirth.Text = "";
            lblDriverID.Text = "";
            lblExpirationDate.Text = "";
            lblGender.Text = "";
            lblIsActive.Text = "";
            lblIssueDate.Text = "";
            lblNationalNo.Text = "";
            lblApplicationID.Text = "";
            lblIntLicenseID.Text = "";
            lblLicenseID.Text = "";
        }

        public void LoadInternationalLicenseInfo(int IntLicenseID)
        {
            clsInternationalLicense internationalLicense = clsInternationalLicense.Find(IntLicenseID);
            if (internationalLicense!=null)
            {
                _InternationalLicenseInfo=internationalLicense;
                _InternationalLicenseId = IntLicenseID;
                ResetAllValues();
                lblDateOfBirth.Text = clsFormat.DateToShort(_InternationalLicenseInfo.DriverInfo.PersonInfo.DateOfBirth);
                lblApplicationID.Text = _InternationalLicenseInfo.ApplicationID.ToString();
                lblDriverID.Text = _InternationalLicenseInfo.DriverID.ToString();
                lblExpirationDate.Text = clsFormat.DateToShort(_InternationalLicenseInfo.ExpirationDate);
                switch (_InternationalLicenseInfo.DriverInfo.PersonInfo.Gender)
                {
                    case clsPerson.enGender.enMale:
                        if (_InternationalLicenseInfo.DriverInfo.PersonInfo.ImagePath == null)
                            imgProfile.Image = Resources.Male_512;
                        else
                            if (File.Exists(_InternationalLicenseInfo.DriverInfo.PersonInfo.ImagePath))
                            imgProfile.ImageLocation = _InternationalLicenseInfo.DriverInfo.PersonInfo.ImagePath;
                        lblGender.Text = "Male";
                        break;
                    case clsPerson.enGender.enFemale:
                        if (_InternationalLicenseInfo.DriverInfo.PersonInfo.ImagePath == null)
                            imgProfile.Image = Resources.Female;
                        else
                            if (File.Exists(_InternationalLicenseInfo.DriverInfo.PersonInfo.ImagePath))
                            imgProfile.ImageLocation = _InternationalLicenseInfo.DriverInfo.PersonInfo.ImagePath;
                        lblGender.Text = "Female";
                        break;
                    default:
                        lblGender.Text = "Unknown";
                        break;
                }
                lblIntLicenseID.Text = _InternationalLicenseInfo.InternationalLicenseID.ToString();
                lblIsActive.Text = (_InternationalLicenseInfo.isActive) ? "Yes":"No";
                lblIssueDate.Text = clsFormat.DateToShort(_InternationalLicenseInfo.IssueDate);
                lblLicenseID.Text = _InternationalLicenseInfo.IssuedUsingLocalLicenseID.ToString();
                lblName.Text = _InternationalLicenseInfo.DriverInfo.PersonInfo.FullName;
                lblNationalNo.Text = _InternationalLicenseInfo.DriverInfo.PersonInfo.NationalID;
            }
        }
    }
}
