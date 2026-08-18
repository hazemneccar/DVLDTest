using DVLD.Licenses;
using DVLD.People;
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

namespace DVLD.Applications.International_License
{
    public partial class frmManageInternationalLicenseApp : Form
    {
        public frmManageInternationalLicenseApp()
        {
            InitializeComponent();
        }
        private static DataView _dtAllInternationalApps;
        private void RefreshData()
        {
            cbFilterBy.SelectedIndex = 0;

            tbFilterValue.Text = "";
            _dtAllInternationalApps = DVLD_Business.clsInternationalLicense.GetAllInternationalLicenses().DefaultView;
            dgvAllInternationalApps.DataSource = _dtAllInternationalApps;

            if (dgvAllInternationalApps.Rows.Count > 0)
            {
                dgvAllInternationalApps.Columns[0].HeaderText = "International License ID";
                dgvAllInternationalApps.Columns[0].Width = 80;

                dgvAllInternationalApps.Columns[1].HeaderText = "Application ID";
                dgvAllInternationalApps.Columns[1].Width = 190;

                dgvAllInternationalApps.Columns[2].HeaderText = "Driver ID";
                dgvAllInternationalApps.Columns[2].Width = 90;

                dgvAllInternationalApps.Columns[3].HeaderText = "Local License ID";
                dgvAllInternationalApps.Columns[3].Width = 90;

                dgvAllInternationalApps.Columns[4].HeaderText = "Issue Date";
                dgvAllInternationalApps.Columns[4].Width = 150;

                dgvAllInternationalApps.Columns[5].HeaderText = "Expiration Date";
                dgvAllInternationalApps.Columns[5].Width = 150;

                dgvAllInternationalApps.Columns[6].HeaderText = "Is Active";
                dgvAllInternationalApps.Columns[6].Width = 80;
            }
            lblRecordsCount.Text = _dtAllInternationalApps.Count.ToString();
        }

        private void ApplyFilterByCB_AbuHadhoud()
        {

                    if ((tbFilterValue.Text == string.Empty && tbFilterValue.Visible) ||
                        (cbIsUserActive.Text == "All" && cbIsUserActive.Visible))
            {
                _dtAllInternationalApps.RowFilter = "";
                lblRecordsCount.Text = dgvAllInternationalApps.Rows.Count.ToString();
                return;
            }
            string FilterColumn = "";
            switch (cbFilterBy.Text)
            {
                case "None":
                    FilterColumn = "";
                    break;
                case "International License ID":
                    FilterColumn = "InternationalLicenseID";
                    break;
                case "Application ID":
                    FilterColumn = "ApplicationID";
                    break;
                case "Driver ID":
                    FilterColumn = "DriverID";
                    break;
                case "Local License ID":
                    FilterColumn = "IssuedUsingLocalLicenseID";
                    break;
                case "Is Active":
                    FilterColumn = "IsActive";
                    break;
                default:
                    FilterColumn = "";
                    break;
            }
            if (FilterColumn == "")
            {
                _dtAllInternationalApps.RowFilter = FilterColumn;
                lblRecordsCount.Text = dgvAllInternationalApps.Rows.Count.ToString();
                return;
            }
            if (FilterColumn != "IsActive")
                _dtAllInternationalApps.RowFilter = string.Format("[{0}]={1}", FilterColumn, tbFilterValue.Text.Trim());
            else
            {
                switch (cbIsUserActive.Text)
                {
                    case "All":
                        _dtAllInternationalApps.RowFilter = "";
                        break;
                    case "Yes":
                        _dtAllInternationalApps.RowFilter = "IsActive = true";
                        break;
                    case "No":
                        _dtAllInternationalApps.RowFilter = "IsActive = false";
                        break;
                    default:
                        FilterColumn = "None";
                        break;
                }
            }
            lblRecordsCount.Text = dgvAllInternationalApps.Rows.Count.ToString();

        }

        private void frmManageInternationalLicenseApp_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void tbFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            //this will allow only digits if person id is selected
            if (cbFilterBy.Text != "Is Active")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void tbFilterValue_TextChanged(object sender, EventArgs e)
        {
            if (_dtAllInternationalApps != null)
                ApplyFilterByCB_AbuHadhoud();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.Text != "None")
            {
                tbFilterValue.Visible = true;
                cbIsUserActive.Visible = false;
                tbFilterValue.Focus();
            }
            if (cbFilterBy.Text == "Is Active")
            {
                tbFilterValue.Visible = false;
                cbIsUserActive.Visible = true;
            }
        }

        private void cbIsUserActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dtAllInternationalApps != null)
                ApplyFilterByCB_AbuHadhoud();
        }

        private void btnAddNewLocalApp_Click(object sender, EventArgs e)
        {
            frmAddNewInternationalLicense InternationalLicense =new frmAddNewInternationalLicense();
            InternationalLicense.ShowDialog();
            RefreshData();
        }

        private void cmsShowPersonDetails_Click(object sender, EventArgs e)
        {
            int.TryParse(dgvAllInternationalApps.CurrentRow.Cells["DriverID"].Value.ToString(), out int SelectedID);
            frmPersonInfo licenseInfo = new frmPersonInfo(clsDriver.Find(SelectedID).PersonID);
            licenseInfo.ShowDialog();
        }

        private void cmsShowLicenseDetails_Click(object sender, EventArgs e)
        {
            int.TryParse(dgvAllInternationalApps.CurrentRow.Cells["InternationalLicenseID"].Value.ToString(), out int SelectedID);
            frmshowInternationalLicenseInfo licenseInfo = new frmshowInternationalLicenseInfo(SelectedID);
            licenseInfo.ShowDialog();
        }

        private void cmsShowPersonLicenseHistory_Click(object sender, EventArgs e)
        {
            int.TryParse(dgvAllInternationalApps.CurrentRow.Cells["DriverID"].Value.ToString(), out int SelectedID);
            frmLicenseHistory frm = new frmLicenseHistory(SelectedID);
            frm.ShowDialog();
        }
    }
}
