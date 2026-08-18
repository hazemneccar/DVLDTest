using DVLD.Applications.Application_Types;
using DVLD.Applications.International_License;
using DVLD.Applications.Local_Driving_License;
using DVLD.Applications.Replace_License;
using DVLD.Drivers;
using DVLD.Global_Classes;
using DVLD.Licenses.Detain;
using DVLD.People;
using DVLD.Tests.TestTypes;
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
            frmMain_FormClosing(null, null);
            this.Close();
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListApplicationTypes frm =new frmListApplicationTypes();
            frm.ShowDialog();
        }

        private void locaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateNewLocalDrivingLicApp frm = new frmAddUpdateNewLocalDrivingLicApp();
            frm.ShowDialog();
        }

        private void localDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageLocalDrivingLicApp frm = new frmManageLocalDrivingLicApp();
            frm.ShowDialog();
        }

        private void msDrivers_Click(object sender, EventArgs e)
        {
            frmShowDrivers frm = new frmShowDrivers();
            frm.ShowDialog();
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddNewInternationalLicense frm = new frmAddNewInternationalLicense();
            frm.ShowDialog();
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRenewLocalLicense frm = new frmRenewLocalLicense();
            frm.ShowDialog();
        }

        private void replacementForToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReplaceLicense frm = new frmReplaceLicense();
            frm.ShowDialog();
        }

        private void realeseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense frm = new frmReleaseDetainedLicense();
            frm.ShowDialog();
        }

        private void retakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageLocalDrivingLicApp frm = new frmManageLocalDrivingLicApp();
            frm.ShowDialog();
        }

        private void internationalLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageInternationalLicenseApp frm = new frmManageInternationalLicenseApp();
            frm.ShowDialog();
        }

        private void manageDetainedLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDetainedList frm = new frmDetainedList();
            frm.ShowDialog();
        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDetainLicense frm = new frmDetainLicense();
            frm.ShowDialog();
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense frm = new frmReleaseDetainedLicense();
            frm.ShowDialog();
        }

        private void manageTestTyprsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListTestTypes frm = new frmListTestTypes();
            frm.ShowDialog();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            _frmLogIn.Show();
        }
    }
}
