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

namespace DVLD.People
{
    public partial class ctrlPersonInfo : UserControl
    {
        private clsPerson _PersonInfo;
        public ctrlPersonInfo()
        {
            InitializeComponent();
        }
        private void SetInitialGenderPhoto()
        {
            if (_PersonInfo.Gender == clsPerson.enGender.enMale)
                imgProfile.Image = Resources.Male;
            else
                imgProfile.Image = Resources.Female;
        }

        public void LoadPersonInfo(int PersonID)
        {
            _PersonInfo=clsPerson.GetPersonInfoByPersonID(PersonID);
            if (_PersonInfo!=null)
            {
                lblPersonID.Text = _PersonInfo.PersonID.ToString();
                lblFullName.Text=_PersonInfo.FullName.ToString();
                lblNationalNo.Text=_PersonInfo.NationalID.ToString();
                if (_PersonInfo.Gender == clsPerson.enGender.enMale)
                    lblGender.Text = "Male";
                else
                    lblGender.Text = "Female";
                lblEmail.Text= _PersonInfo.Email.ToString();
                lblAddress.Text=_PersonInfo.Address.ToString();
                lblDateOfBirth.Text=_PersonInfo.DateOfBirth.ToString();
                lblPhone.Text=_PersonInfo.Phone.ToString();
                lblCountry.Text = clsCountry.Find(_PersonInfo.NationalityCountryID).CountryName;
                if (!string.IsNullOrEmpty(_PersonInfo.ImagePath))
                    imgProfile.ImageLocation = _PersonInfo.ImagePath;
                else
                    SetInitialGenderPhoto();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frmAddNewUpdatePerson = new frmAddNewUpdatePerson(_PersonInfo.PersonID);
            frmAddNewUpdatePerson.ShowDialog();
            LoadPersonInfo(_PersonInfo.PersonID);
        }
    }
}
