using DVLD.Global_Classes;
using DVLD.Properties;
using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.People
{
    public partial class ctrlPersonCard : UserControl
    {
        private int _PersonID=-1;
        public int PersonID
        {
            get { return _PersonID; }
        }

        private clsPerson _PersonInfo;
        public clsPerson PersonInfo
        {
            get { return _PersonInfo; }
        }
        public ctrlPersonCard()
        {
            InitializeComponent();
        }
        private void _SetInitialGenderPhoto()
        {
            if (_PersonInfo.Gender == clsPerson.enGender.enMale)
            { 
                imgProfile.Image = Resources.Male;
                pbGenderIcon.Image = Resources.Man_32;
            }
            else { 
                imgProfile.Image = Resources.Female;
                pbGenderIcon.Image = Resources.Woman_32;
            }
        }
        public void LoadPersonInfo(int PersonID)
        {
            _PersonInfo=clsPerson.Find(PersonID);
            if (_PersonInfo!=null)
            {
                _FillPersonInfo();  
            }
            else
            {
                _ResetPersonInfo();
                MessageBox.Show("There is no Person with PersonID = " + PersonID);
                return;
            }
        }
        public void LoadPersonInfo(string NationalNo)
        {
            _PersonInfo = clsPerson.Find(NationalNo);
            if (_PersonInfo != null)
            {
                _FillPersonInfo();
            }
            else
            {
                _ResetPersonInfo();
                MessageBox.Show("There is no Person with National No = " + NationalNo);
                return;
            }
        }

        private void _ResetPersonInfo()
        {
            _PersonID = -1;
            lblPersonID.Text = "???";
            lblFullName.Text = "???";
            lblNationalNo.Text = "???";
            lblGender.Text = "???";
            imgProfile.Image= Resources.Male;
            lblEmail.Text="???";
            lblAddress.Text="???";
            lblPhone.Text="???";
            lblDateOfBirth.Text="???";
            pbGenderIcon.Image = Resources.Man_32;
        }
        private void _FillPersonInfo()
        {
            _PersonID = _PersonInfo.PersonID;
            lblPersonID.Text = _PersonInfo.PersonID.ToString();
            lblFullName.Text = _PersonInfo.FullName;
            lblNationalNo.Text = _PersonInfo.NationalID;
            lblGender.Text = _PersonInfo.Gender == clsPerson.enGender.enMale ? "Male" : "Female";
            lblEmail.Text = _PersonInfo.Email;
            lblAddress.Text = _PersonInfo.Address;
            lblDateOfBirth.Text = clsFormat.DateToShort(_PersonInfo.DateOfBirth);
            lblPhone.Text = _PersonInfo.Phone;
            lblCountry.Text = clsCountry.Find(_PersonInfo.NationalityCountryID).CountryName;
            _SetInitialGenderPhoto();

            if (!string.IsNullOrEmpty(_PersonInfo.ImagePath))
            {
                if (File.Exists(_PersonInfo.ImagePath))
                    imgProfile.ImageLocation = _PersonInfo.ImagePath;
                else
                    MessageBox.Show("Could not find Profile Image!");
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
