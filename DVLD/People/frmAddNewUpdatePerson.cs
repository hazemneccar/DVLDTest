using DVLD.Global_Classes;
using DVLD.Properties;
using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace DVLD.People
{
    public partial class frmAddNewUpdatePerson : Form
    {
        public enum enMode { AddNew = 0, Update = 1 }
        private enMode _Mode;

        private int _PersonID;
        private clsPerson _Person;

        // Declare a delegate
        public delegate void DataBackEventHandler(object sender, int PersonID);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;

        public void LoadCountries()
        {
            DataTable dt = clsCountry.GetAllCounties();
            foreach (DataRow Country in dt.Rows)
            {
                cbCountries.Items.Add(Country["CountryName"]);
            }
            cbCountries.SelectedIndex = cbCountries.FindString("Turkiye");
        }
        public frmAddNewUpdatePerson()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
            
        }
        public frmAddNewUpdatePerson(int PersonID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            this._PersonID= PersonID;
        }
        private void _ResetDefaultValues()
        {
            LoadCountries();
            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New Person";
                _Person = new clsPerson();
            }
            else
            {
                lblTitle.Text = "Update Person";
            }
            SetInitialGenderPhoto();
            linklblRemove.Visible=(imgProfile.ImageLocation!=null);
            dtDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
            dtDateOfBirth.Value = dtDateOfBirth.MaxDate;
            tbFirstName.Text = "";
            tbSecondName.Text = "";
            tbThirdName.Text = "";
            tbLastName.Text = "";
            tbNationalNo.Text = "";
            rbMale.Checked = true;
            tbPhoneNumber.Text = "";
            tbEmail.Text = "";
            tbAddress.Text = "";
            imgProfile.ImageLocation = "";
        }
        public void _LoadInfo()
        {
            _Person = clsPerson.GetPersonInfoByPersonID(_PersonID);
            if (_Person == null)
            {
                MessageBox.Show("There is no person with ID="+_PersonID.ToString()+".");
                this.Close();
                return;
            }
            tbFirstName.Text= _Person.FirstName;
            tbSecondName.Text= _Person.SecondName;
            tbThirdName.Text = _Person.ThirdName;
            tbLastName.Text= _Person.LastName;

            tbNationalNo.Text = _Person.NationalID;
            dtDateOfBirth.Value = _Person.DateOfBirth;

            if (_Person.Gender == clsPerson.enGender.enMale)
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;
            CheckPhoto();

            tbPhoneNumber.Text = _Person.Phone;

            if (_Person.Email!="")
                tbEmail.Text = _Person.Email;

            cbCountries.SelectedIndex = cbCountries.FindString(clsCountry.Find(_Person.NationalityCountryID).CountryName);

            tbAddress.Text = _Person.Address;
        }
        private void CheckPhoto()
        {
            if (!string.IsNullOrEmpty(_Person.ImagePath))
            {
                imgProfile.ImageLocation = _Person.ImagePath;
                linklblRemove.Visible = true;
            }
            //else
                //SetInitialGenderPhoto();
        }
        private void frmAddNewUpdatePerson_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();
            if (_Mode==enMode.Update)
            {
                _LoadInfo();
            }
        }
        private void linklblSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory= true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                imgProfile.ImageLocation=openFileDialog1.FileName;
                linklblRemove.Visible = true;
            }
        }
        private void linklblRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            imgProfile.ImageLocation = "";
            linklblRemove.Visible = false;
            SetInitialGenderPhoto();
        }
        private void tbPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) //eğer IsControl silsek Backspace bile engellenir. Yani kullanıcı yazdığı sayıyı silemez.
            {
                e.Handled = true; // Karakteri engelle
            }
        }
        private void rbGender_CheckedChanged(object sender, EventArgs e)
        {
            SetInitialGenderPhoto();
        }

        private void SetInitialGenderPhoto()
        {
            if (imgProfile.ImageLocation != "")
                return;
            if (rbMale.Checked)
            {
                imgProfile.Image = Resources.Male;
            }
            else
            {
                imgProfile.Image = Resources.Female;
            }
        }
        private bool AddProfileImage()
        {

            if (_Person.ImagePath == imgProfile.ImageLocation)
                return true;

            if (_Person.ImagePath!="")
            {
                try
                {
                    File.Delete(_Person.ImagePath); //Delete old Imageee
                }
                catch {
                    //log it later
                }
            }

            if (imgProfile.ImageLocation != "")
            {
                string ImageLocation = imgProfile.ImageLocation;

                if (clsUtil.CopyImageToProjectImagesFolder(ref ImageLocation))
                {
                    imgProfile.ImageLocation=ImageLocation;
                    return true;
                }
                else
                {
                    MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                _Person.ImagePath = "";
            }
            return true;
        }

        private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {
            if (((TextBox)sender).Text.Trim() == string.Empty)
            {
                errorProvider1.SetError((TextBox)sender, "You should fill this field");
            }
            else
                errorProvider1.SetError((TextBox)sender, "");
        }

        private void tbEmail_Validating(object sender, CancelEventArgs e)
        {
            if (tbEmail.Text.Trim() == string.Empty)
                return;
            if (!clsValidation.ValidateEmail(tbEmail.Text.Trim()))
            {
                errorProvider1.SetError((TextBox)sender, "Type a true email!");
            }
            else
                errorProvider1.SetError((TextBox)sender, "");
        }
        private void tbNationalNo_Validating(object sender, CancelEventArgs e)
        {
            if (((TextBox)sender).Text.Trim() == string.Empty)
            {
                errorProvider1.SetError((TextBox)sender, "You should fill this field");
                e.Cancel = true;
                return;
            }
            else
            {
                errorProvider1.SetError((TextBox)sender, "");
            }


            if (tbNationalNo.Text.Trim() != _Person.NationalID && clsPerson.IsPersonExist(tbNationalNo.Text.Trim()))
            {
                errorProvider1.SetError((TextBox)sender, ((TextBox)sender).Text + " National kodu var zaten!");
                e.Cancel = true;
            }
            else
                errorProvider1.SetError((TextBox)sender, "");
        }
        public bool CheckAllValues()
        {
            if (tbFirstName.Text == string.Empty)
            {
                MessageBox.Show("You should Fill First name");
                return false;
            }

            if (tbSecondName.Text == string.Empty)
            {
                MessageBox.Show("You should Fill Second name");
                return false;
            }

            if (tbLastName.Text == string.Empty)
            {
                MessageBox.Show("You should Fill Last name");
                return false;
            }

            if (tbNationalNo.Text == string.Empty || (clsPerson.IsPersonExist(tbNationalNo.Text.Trim()) && _Mode==enMode.AddNew))
            {
                MessageBox.Show("You should Fill National Number and it can't be duplicated in Database");
                return false;
            }

            if (clsUtilityBusiness.CalculateAge(dtDateOfBirth.Value) < 18)
            {
                MessageBox.Show("You should control your age and the age must be greater than 18");
                return false;
            }

            if (tbPhoneNumber.Text == string.Empty)
            {
                MessageBox.Show("You should Fill Phone number");
                return false;
            }

            if (!clsValidation.ValidateEmail(tbEmail.Text))
            {
                MessageBox.Show("You should Control your gmail");
                return false;
            }

            if (clsCountry.Find(cbCountries.Text) == null)
            {
                MessageBox.Show("Country name is wrong");
                return false;
            }

            if (tbAddress.Text == string.Empty)
            {
                MessageBox.Show("You should Fill the address");
                return false;
            }

            return true;
        }
        public void SaveInfo()
        {
            _Person.FirstName = tbFirstName.Text.Trim();
            _Person.SecondName = tbSecondName.Text.Trim();
            _Person.ThirdName = tbThirdName.Text.Trim();
            _Person.LastName = tbLastName.Text.Trim();
            _Person.NationalID = tbNationalNo.Text.Trim();
            _Person.DateOfBirth = dtDateOfBirth.Value;

            if (rbMale.Checked)
                _Person.Gender = clsPerson.enGender.enMale;
            else
                _Person.Gender = clsPerson.enGender.enFemale;

            _Person.Phone = tbPhoneNumber.Text.Trim();

            if (tbEmail.Text != string.Empty)
                _Person.Email = tbEmail.Text.Trim();

            _Person.NationalityCountryID = clsCountry.Find(cbCountries.Text).ID;

            if (!AddProfileImage())
                return;
            if (imgProfile.ImageLocation != null)
                _Person.ImagePath = imgProfile.ImageLocation;
            else
                _Person.ImagePath = "";

            if (tbAddress.Text != string.Empty)
                _Person.Address = tbAddress.Text.Trim();

            if (_Person.Save()) {
                switch(_Mode)
                {
                    case enMode.AddNew:
                        MessageBox.Show("Added successfully, new ID=" + _Person.PersonID);
                        lblPersonID.Text = _Person.PersonID.ToString();
                        break;
                    case enMode.Update:
                        MessageBox.Show("Info Updated successfully");
                        break;
                }        
                DataBack?.Invoke(this,_Person.PersonID);
            }
            else
            {
                MessageBox.Show("You are big big problem");
            }
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            if (CheckAllValues())
            {
                SaveInfo();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
