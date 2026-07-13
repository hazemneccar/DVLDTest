using DVLD.Applications.Application_Types;
using DVLD.Global_Classes;
using DVLD.People;
using DVLD.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmMain : Form
    {
        private Form _frmLogIn;
        public frmMain(Form frmLogIn)
        {
            InitializeComponent();
            _frmLogIn= frmLogIn;
        }
        private void OpenChildForm<T>() where T : Form, new()
        {
            // 1. Adım: Form zaten açık mı diye kontrol et
            foreach (Form openForm in this.MdiChildren)
            {
                if (openForm is T)
                {
                    openForm.Activate(); // Açıksa öne getir
                    return;              // Metottan çık, yenisini açma
                }
            }

            // 2. Adım: Açık değilse generic olarak yeni bir tane oluştur
            T frm = new T();
            frm.MdiParent = this;
            frm.Show();
        }

        private void msPeople_Click(object sender, EventArgs e)
        {
            frmManagePeople frm = new frmManagePeople();
            frm.ShowDialog();
        }

        private void msUsers_Click(object sender, EventArgs e)
        {
            frmManageUsers frm = new frmManageUsers();
            frm.ShowDialog();
        }

        private void currentUserInfotsm_Click(object sender, EventArgs e)
        {
            frmUserInfo frm = new frmUserInfo(clsGlobal.CurrentUser.UserID);
            frm.ShowDialog();
        }

        private void changePasswordtsm_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword(clsGlobal.CurrentUser.UserID);
            frm.ShowDialog();
        }

        private void signOuttsm_Click(object sender, EventArgs e)
        {
            clsGlobal.CurrentUser = null;
            _frmLogIn.Show();
            this.Close();
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListApplicationTypes frm =new frmListApplicationTypes();
            frm.ShowDialog();
        }
    }
}
