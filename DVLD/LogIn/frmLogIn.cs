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

namespace DVLD.Users
{
    public partial class frmLogIn : Form
    {
        public frmLogIn()
        {
            InitializeComponent();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            clsUser User = clsUser.FindByUsernameAndPassword(tbUserName.Text.Trim(), tbPassword.Text);
            if (User != null)
            {
                if (!User.isActive)
                {
                    tbUserName.Focus();
                    MessageBox.Show("This user is not active, contant with your admin!");
                    return;
                }
                if (chkRememberMe.Checked)
                {
                    clsGlobal.RememberUsernameAndPassword(tbUserName.Text.Trim(),tbPassword.Text);
                }
                else
                {
                    clsGlobal.RememberUsernameAndPassword("", "");
                }
                clsGlobal.CurrentUser = User;
                this.Hide();
                frmMain frmmain = new frmMain(this);
                frmmain.ShowDialog();
                //this.Close();
            }
            else
            {
                tbUserName.Focus();
                MessageBox.Show("Invalid Username/Password", "Wrong Credintials");
            }
        }
        private void frmLogIn_Load(object sender, EventArgs e)
        {
            string UserName = "",Password="";
            if(clsGlobal.GetStoredCredential(ref UserName,ref Password)) {
                tbUserName.Text = UserName;
                tbPassword.Text = Password;
                chkRememberMe.Checked = true;
            }
            else
                chkRememberMe.Checked = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
