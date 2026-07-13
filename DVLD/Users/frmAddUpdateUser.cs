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

namespace DVLD.Users.Controls
{
    public partial class frmAddUpdateUser : Form
    {
        private int _PersonID=-1;
        private int _UserID=-1;
        public clsUser _UserInfo;
        public enum enMode { AddNew=0,Update=1 }
        public enMode Mode = enMode.AddNew;
        public frmAddUpdateUser()
        {
            InitializeComponent();
            tpLoginInfo.Enabled = false;
            Mode = enMode.AddNew;
            lblTitle.Text = "Add New User";
            ctrlPersonCardWithFilter1.FilterFocus();
            _UserInfo = new clsUser();
        }
        public frmAddUpdateUser(int UserID)
        {
            InitializeComponent();
            tpLoginInfo.Enabled = true;
            Mode = enMode.Update;
            lblTitle.Text = "Update User";
            if (clsUser.isUserExist(UserID))
            {
                _UserInfo =clsUser.Find(UserID);
                _UserID= UserID;
                _PersonID = _UserInfo.PersonID;
                _LoadInfo();
            }
            else
            {
                MessageBox.Show("There is no this user!");
                this.Close();
                return;
            }
        }
        private void _LoadInfo()
        {
            ctrlPersonCardWithFilter1.LoadPersonInfo(_PersonID);
            ctrlPersonCardWithFilter1.FilterEnabled = false;
            lblUserID.Text=_UserInfo.UserID.ToString();
            tbUserName.Text = _UserInfo.UserName;
            tbPassword.Text=_UserInfo.Password;
            tbConfirmPassword.Text = _UserInfo.Password;
            chkIsCtive.Checked = _UserInfo.isActive;
            btnSave.Enabled = true;
        }
        private void ctrlPersonCardWithFilter1_OnPersonSelected(int PersonID)
        {
            btnNext.Enabled = true;
            _PersonID = PersonID;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (clsPerson.Find(_PersonID)!=null)
            {
                if ((Mode == enMode.AddNew && clsUser.FindByPersonID(_PersonID)==null) ||Mode==enMode.Update)
                {
                    tpLoginInfo.Enabled=true;
                    tabControl1.SelectedTab = tpLoginInfo;
                    btnSave.Enabled = true;
                }
                else
                {
                    tpLoginInfo.Enabled = false;
                    MessageBox.Show("Selected Person already has a user, choose another one","Error!",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    btnSave.Enabled = false;
                }
            }
            else
            {
                btnSave.Enabled = false;
                MessageBox.Show("Please select active person!");
            }
        }

        private void tbUserName_Validating(object sender, CancelEventArgs e)
        {
            if (tbUserName.Text==string.Empty) { 
                errorProvider1.SetError(tbUserName, "You sould fill this field!");
            }
            else if (clsUser.isUserExist(tbUserName.Text) && (_UserInfo.UserName !=tbUserName.Text)) {
                errorProvider1.SetError(tbUserName, "This username already exist!");
            }
            else
                errorProvider1.SetError(tbUserName, "");
        }

        private void tbPassword_Validating(object sender, CancelEventArgs e)
        {
            if (tbPassword.Text == string.Empty)
            {
                errorProvider1.SetError(tbPassword, "You sould fill this field!");
            }
            else
                errorProvider1.SetError(tbPassword, "");
        }
        private void tbConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (tbConfirmPassword.Text == string.Empty) 
            { 
                errorProvider1.SetError(tbConfirmPassword, "You sould fill this field!");
            }
            else if (tbPassword.Text != tbConfirmPassword.Text)
            {
                errorProvider1.SetError(tbConfirmPassword, "2 Password is not same!");
            }
            else
                errorProvider1.SetError(tbConfirmPassword, "");
        }


        private void SaveInfo()
        {
            _UserInfo.PersonID = _PersonID;
            _UserInfo.UserName = tbUserName.Text;
            _UserInfo.Password = tbPassword.Text;
            _UserInfo.isActive = chkIsCtive.Checked;
            if (!_UserInfo.Save()) {
                MessageBox.Show("Error while saving");
                return;
            }
            if (Mode==enMode.AddNew)
            {
                Mode = enMode.Update;
                _UserID = _UserInfo.UserID;
                MessageBox.Show("User Added successfully with ID=" + _UserInfo.UserID);
                lblUserID.Text = _UserID.ToString();
                lblTitle.Text = "Update User";
            }
            else
                MessageBox.Show("User Info Updated Successfully!");


        }
        private bool HasValidationError()
        {
            foreach (Control c in this.Controls)
            {
                // Eğer kontrol bir Panel veya GroupBox içindeyse onları da taramak için
                if (HasChildrenErrors(c)) return true;
            }
            return false;
        }
        private bool HasChildrenErrors(Control control)
        {
            // Kontrolün üzerinde aktif bir hata mesajı var mı?
            if (!string.IsNullOrEmpty(errorProvider1.GetError(control)))
            {
                return true;
            }

            // Alt kontrolleri varsa (panel içi vs.) onları da kontrol et
            foreach (Control child in control.Controls)
            {
                if (HasChildrenErrors(child)) return true;
            }

            return false;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            this.ValidateChildren();
            if(HasValidationError()) { 
                MessageBox.Show("Check all fields!");
                return;
            }
            SaveInfo();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
