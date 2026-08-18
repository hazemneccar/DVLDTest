using DVLD.Applications.Local_Driving_License;
using DVLD.Licenses.Local_Licenses;
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

namespace DVLD.Licenses.Detain
{
    public partial class frmDetainedList : Form
    {
        private DataView _dtAllDetainedLicense;
        public frmDetainedList()
        {
            InitializeComponent();
        }
        private void RefreshData()
        {
            cbFilterBy.SelectedIndex = 0;

            tbFilterValue.Text = "";
            _dtAllDetainedLicense = DVLD_Business.clsDetainedLicense.GetAllDetainedLicenses().DefaultView;
            dgvAllLocalApps.DataSource = _dtAllDetainedLicense;

            if (dgvAllLocalApps.Rows.Count > 0)
            {
                dgvAllLocalApps.Columns[0].HeaderText = "D. ID";
                dgvAllLocalApps.Columns[0].Width = 60;

                dgvAllLocalApps.Columns[1].HeaderText = "L. ID";
                dgvAllLocalApps.Columns[1].Width = 60;

                dgvAllLocalApps.Columns[2].HeaderText = "Detain Date";
                dgvAllLocalApps.Columns[2].Width = 120;

                dgvAllLocalApps.Columns[3].HeaderText = "Fine Fees";
                dgvAllLocalApps.Columns[3].Width = 80;

                dgvAllLocalApps.Columns[4].HeaderText = "Is Released";
                dgvAllLocalApps.Columns[4].Width = 80;

                dgvAllLocalApps.Columns[5].HeaderText = "Release Date";
                dgvAllLocalApps.Columns[5].Width = 120;

                dgvAllLocalApps.Columns[6].HeaderText = "N. No";
                dgvAllLocalApps.Columns[6].Width = 80;

                dgvAllLocalApps.Columns[7].HeaderText = "Full Name";
                dgvAllLocalApps.Columns[7].Width = 230;

                dgvAllLocalApps.Columns[8].HeaderText = "Rel.AppID";
                dgvAllLocalApps.Columns[8].Width = 75;
            }
            lblRecordsCount.Text = _dtAllDetainedLicense.Count.ToString();
        }

        private void frmDetainedList_Load(object sender, EventArgs e)
        {
            RefreshData();
        }
        private void ApplyFilterByCB_AbuHadhoud()
        {
            if ((tbFilterValue.Text == string.Empty && tbFilterValue.Visible) ||
                        (cbIsReleased.Text == "All" && cbIsReleased.Visible))
                {
                _dtAllDetainedLicense.RowFilter = "";
                lblRecordsCount.Text = dgvAllLocalApps.Rows.Count.ToString();
                return;
            }
            string FilterColumn = "";
            switch (cbFilterBy.Text)
            {
                case "None":
                    FilterColumn = "";
                    break;
                case "Detain ID":
                    FilterColumn = "DetainID";
                    break;
                case "Is Released":
                    FilterColumn = "IsReleased";
                    break;
                case "National Number":
                    FilterColumn = "NationalNo";
                    break;
                case "Full Name":
                    FilterColumn = "FullName";
                    break;
                case "Release Application ID":
                    FilterColumn = "ReleaseApplicationID";
                    break;
                default:
                    FilterColumn = "";
                    break;
            }
            cbIsReleased.Visible = FilterColumn== "IsReleased";
            tbFilterValue.Visible = FilterColumn != "IsReleased";
            if (FilterColumn == "")
            {
                _dtAllDetainedLicense.RowFilter = FilterColumn;
                lblRecordsCount.Text = dgvAllLocalApps.Rows.Count.ToString();
                return;
            }
            if (FilterColumn == "DetainID" || FilterColumn == "ReleaseApplicationID")
                _dtAllDetainedLicense.RowFilter = string.Format("[{0}]={1}", FilterColumn, tbFilterValue.Text.Trim());
            else if (FilterColumn == "IsReleased")
            {
                if (cbIsReleased.Text == "All")
                    _dtAllDetainedLicense.RowFilter = "";
                else if (cbIsReleased.Text == "Yes")
                    _dtAllDetainedLicense.RowFilter = "[IsReleased] = true";
                else
                    _dtAllDetainedLicense.RowFilter = "[IsReleased] = false";
                return;
            }
            else
            {
                _dtAllDetainedLicense.RowFilter = string.Format("[{0}] LIKE '%{1}%'", FilterColumn, tbFilterValue.Text.Trim());
            }
            lblRecordsCount.Text = dgvAllLocalApps.Rows.Count.ToString();

        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.Text == "None")
            {
                tbFilterValue.Visible = false;
                cbIsReleased.Visible = false;
                tbFilterValue.Focus();
            }
            else if (cbFilterBy.Text == "Is Released")
            {
                tbFilterValue.Visible = false;
                cbIsReleased.Visible = true;

            }
            else
            {
                tbFilterValue.Visible = true;
                cbIsReleased.Visible = false;

            }

        }

        private void tbFilterValue_TextChanged(object sender, EventArgs e)
        {
            if (_dtAllDetainedLicense != null)
                ApplyFilterByCB_AbuHadhoud();
        }

        private void tbFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Detain ID" || cbFilterBy.Text == "Release Application ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cbIsReleased_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dtAllDetainedLicense != null)
                ApplyFilterByCB_AbuHadhoud();
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense frmRelease = new frmReleaseDetainedLicense();
            frmRelease.ShowDialog();
            RefreshData();
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            frmDetainLicense frmDetain = new frmDetainLicense();
            frmDetain.ShowDialog();
            RefreshData();
        }

        private void cmsShowAppDetails_Click(object sender, EventArgs e)
        {
            string NationalNo =dgvAllLocalApps.CurrentRow.Cells["NationalNo"].Value.ToString();
            frmPersonInfo frm = new frmPersonInfo(NationalNo);
            frm.ShowDialog();
        }

       
        private void cmsShowLicense_Click(object sender, EventArgs e)
        {
            int.TryParse(dgvAllLocalApps.CurrentRow.Cells["LicenseID"].Value.ToString(), out int SelectedID);
            frmShowLicenseInfo frm = new frmShowLicenseInfo(SelectedID);
            frm.ShowDialog();
        }
        private void cmsShowPersonLicenseHistory_Click(object sender, EventArgs e)
        {
            int.TryParse(dgvAllLocalApps.CurrentRow.Cells["DriverID"].Value.ToString(), out int SelectedID);
            frmLicenseHistory frm = new frmLicenseHistory(SelectedID);
            frm.ShowDialog();
        }
        private void cmsReleaseDetainedLicense_Click(object sender, EventArgs e)
        {
            int.TryParse(dgvAllLocalApps.CurrentRow.Cells["LicenseID"].Value.ToString(), out int SelectedID);
            frmReleaseDetainedLicense frmRelease = new frmReleaseDetainedLicense(SelectedID);
            frmRelease.ShowDialog();
        }

        private void cmsMnageLocalApps_Opening(object sender, CancelEventArgs e)
        {
            cmsReleaseDetainedLicense.Enabled = !(bool)dgvAllLocalApps.CurrentRow.Cells["IsReleased"].Value;
        }

        private void dgvAllLocalApps_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvAllLocalApps.ClearSelection();
                dgvAllLocalApps.CurrentCell = dgvAllLocalApps.Rows[e.RowIndex].Cells["DetainID"];
                dgvAllLocalApps.Rows[e.RowIndex].Selected = true;
            }
        }
    }
}
