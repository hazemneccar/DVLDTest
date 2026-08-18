using DVLD.Licenses.Local_Licenses;
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

namespace DVLD.Licenses.Controls
{
    public partial class ctrlDriverLicenses : UserControl
    {
        private int _DriverID;
        private clsDriver _Driver;
        DataTable _dtAllLocalDriverLicenses;        
        DataTable _dtAllInternationalDriverLicenses;

        public ctrlDriverLicenses()
        {
            InitializeComponent();
        }
        private void LoadLocalLicensesInfo()
        {
            if (_dtAllLocalDriverLicenses.Rows.Count>0)
            {
                DataTable _dtNewLocalDriverLicenses = _dtAllLocalDriverLicenses.DefaultView.ToTable(false,
                "LicenseID","ApplicationID","ClassName","IssueDate","ExpirationDate","IsActive");
                dgvLocalLicenses.DataSource = _dtNewLocalDriverLicenses;

                dgvLocalLicenses.Columns[0].HeaderText = "Lic. ID";
                dgvLocalLicenses.Columns[0].Width = 80;

                dgvLocalLicenses.Columns[1].HeaderText = "App. ID";
                dgvLocalLicenses.Columns[1].Width = 80;

                dgvLocalLicenses.Columns[2].HeaderText = "Class Name";
                dgvLocalLicenses.Columns[2].Width = 180;

                dgvLocalLicenses.Columns[3].HeaderText = "Issue Date";
                dgvLocalLicenses.Columns[3].Width = 120;

                dgvLocalLicenses.Columns[4].HeaderText = "Expiration Date";
                dgvLocalLicenses.Columns[4].Width = 120;

                dgvLocalLicenses.Columns[5].HeaderText = "Is Active";
                dgvLocalLicenses.Columns[5].Width = 80;
            }
            lblLocalTotalRecords.Text = _dtAllLocalDriverLicenses.Rows.Count.ToString();
        }
        private void LoadInternationalLicensesInfo()
        {
            if (_dtAllInternationalDriverLicenses.Rows.Count > 0)
            {
                DataTable _dtNewInternationalDriverLicenses = _dtAllInternationalDriverLicenses.DefaultView.ToTable(false,
               "InternationalLicenseID", "ApplicationID", "IssuedUsingLocalLicenseID", "IssueDate", "ExpirationDate", "IsActive");
                dgvInternationalLicenses.DataSource = _dtNewInternationalDriverLicenses;


                dgvInternationalLicenses.Columns[0].HeaderText = "Int. License ID";
                dgvInternationalLicenses.Columns[0].Width = 90;

                dgvInternationalLicenses.Columns[1].HeaderText = "Application ID";
                dgvInternationalLicenses.Columns[1].Width = 90;

                dgvInternationalLicenses.Columns[2].HeaderText = "L.License ID";
                dgvInternationalLicenses.Columns[2].Width = 100;

                dgvInternationalLicenses.Columns[3].HeaderText = "Issue Date";
                dgvInternationalLicenses.Columns[3].Width = 140;

                dgvInternationalLicenses.Columns[4].HeaderText = "Expiration Date";
                dgvInternationalLicenses.Columns[4].Width = 140;

                dgvInternationalLicenses.Columns[5].HeaderText = "Is Active";
                dgvInternationalLicenses.Columns[5].Width = 80;
            }
            lblInternationalTotalLicenses.Text = _dtAllInternationalDriverLicenses.Rows.Count.ToString();
        }
        public void LoadDriverLicensesInfo(int DriverID)
        {
            _Driver = clsDriver.Find(DriverID);
            if (_Driver == null)
                return;
            _dtAllLocalDriverLicenses =clsLicense.GetDriverLicenses(DriverID);
            _dtAllInternationalDriverLicenses = clsInternationalLicense.GetAllInternationalLicensesByDriverID(DriverID);
            LoadLocalLicensesInfo();
            LoadInternationalLicensesInfo();
        }
        public void LoadDriverLicensesInfoByPersonID(int PersonID)
        {
            if (clsPerson.Find(PersonID) == null)
                return;
            _Driver = clsDriver.FindByPersonID(PersonID);
            if (_Driver!=null)
            {
                _DriverID = _Driver.DriverID;
                _dtAllLocalDriverLicenses = clsLicense.GetDriverLicenses(_DriverID);
                _dtAllInternationalDriverLicenses = clsInternationalLicense.GetAllInternationalLicensesByDriverID(_DriverID);
                LoadLocalLicensesInfo();
                LoadInternationalLicensesInfo();
            }
            
        }
        public void Clear()
        {
            _dtAllInternationalDriverLicenses.Clear();
            _dtAllLocalDriverLicenses.Clear();
        }

        private void showLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int.TryParse(dgvLocalLicenses.CurrentRow.Cells["_LicenseID"].Value.ToString(), out int SelectedID);
            frmShowLicenseInfo frm = new frmShowLicenseInfo(SelectedID);
            frm.ShowDialog();
        }
    }
}
