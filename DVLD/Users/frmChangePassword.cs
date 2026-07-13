using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Users
{
    public partial class frmChangePassword : Form
    {
        private int _UserID=-1;
        private clsUser _UserInfo;

        public frmChangePassword(int UserID)
        {
            InitializeComponent();
            if (clsUser.isUserExist(UserID))
            {
                _UserID = UserID;
                _UserInfo = clsUser.Find(UserID);
                ctrlUserCard1.LoadUserInfo(UserID);
            }
            else { 
                MessageBox.Show("There is no this user!");
                this.Close();
                return;
            }
        }

        private void tbCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if (tbCurrentPassword.Text==string.Empty)
            {
                errorProvider1.SetError(tbCurrentPassword, "You should fill this field!");

            }
            else if (tbCurrentPassword.Text!=_UserInfo.Password)
            {
                errorProvider1.SetError(tbCurrentPassword, "Password must be correct with previus Password!");
            }
            else
                errorProvider1.SetError(tbCurrentPassword, "");

        }

        private void tbNewPassword_TextChanged(object sender, EventArgs e)
        {
            if (tbNewPassword.Text == string.Empty)
            {
                errorProvider1.SetError(tbNewPassword, "You should fill this field!");

            }
            else
                errorProvider1.SetError(tbNewPassword, "");
        }

        private void tbConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            if (tbConfirmPassword.Text == string.Empty)
            {
                errorProvider1.SetError(tbCurrentPassword, "You should fill this field!");

            }
            else if (tbConfirmPassword.Text != tbNewPassword.Text)
            {
                errorProvider1.SetError(tbConfirmPassword, "2 password should be same!");
            }
            else
                errorProvider1.SetError(tbConfirmPassword, "");
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
        private bool SaveNewPassword()
        {
            return clsUser.ChangePassword(_UserID, tbConfirmPassword.Text);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            ValidateChildren();
            if (HasValidationError())
            {
                MessageBox.Show("Check all fields!");
                return;
            }
            if (SaveNewPassword())
            {
                MessageBox.Show("Password Changed successfully!");
            }
            else
                MessageBox.Show("Error while saving!");

        }
    }
}
