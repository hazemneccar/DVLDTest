using DVLD.Applications.Local_Driving_License;
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

namespace DVLD.Drivers
{
    public partial class frmShowDrivers : Form
    {
        public frmShowDrivers()
        {
            InitializeComponent();
        }
        private static DataView _dtAllDrivers;
        private void RefreshData()
        {
            cbFilterBy.SelectedIndex = 0;

            tbFilterValue.Text = "";
            _dtAllDrivers = DVLD_Business.clsDriver.GetAllDrivers().DefaultView;
            dgvAllDrivers.DataSource = _dtAllDrivers;

            if (dgvAllDrivers.Rows.Count > 0)
            {
                dgvAllDrivers.Columns[0].HeaderText = "Driver ID";
                dgvAllDrivers.Columns[0].Width = 80;

                dgvAllDrivers.Columns[1].HeaderText = "Person ID";
                dgvAllDrivers.Columns[1].Width = 80;

                dgvAllDrivers.Columns[2].HeaderText = "National No";
                dgvAllDrivers.Columns[2].Width = 90;

                dgvAllDrivers.Columns[3].HeaderText = "Full Name";
                dgvAllDrivers.Columns[3].Width = 235;

                dgvAllDrivers.Columns[4].HeaderText = "Date";
                dgvAllDrivers.Columns[4].Width = 150;

                dgvAllDrivers.Columns[5].HeaderText = "Active Licenses";
                dgvAllDrivers.Columns[5].Width = 80;
            }
            lblRecordsCount.Text = _dtAllDrivers.Count.ToString();
        }

        private void frmShowDrivers_Load(object sender, EventArgs e)
        {
            RefreshData();
        }
        private void tbFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            //this will allow only digits if person id is selected
            if (cbFilterBy.Text == "Driver ID" || cbFilterBy.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void ApplyFilterByCB_AbuHadhoud()
        {
            if (tbFilterValue.Text == string.Empty)
            {
                _dtAllDrivers.RowFilter = "";
                lblRecordsCount.Text = dgvAllDrivers.Rows.Count.ToString();
                return;
            }
            string FilterColumn = "";
            switch (cbFilterBy.Text)
            {
                case "None":
                    FilterColumn = "";
                    break;
                case "Driver ID":
                    FilterColumn = "DriverID";
                    break;
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;
                case "NationalNo":
                    FilterColumn = "NationalNo";
                    break;
                case "FullName":
                    FilterColumn = "FullName";
                    break;
                default:
                    FilterColumn = "";
                    break;
            }
            if (FilterColumn == "")
            {
                _dtAllDrivers.RowFilter = FilterColumn;
                lblRecordsCount.Text = dgvAllDrivers.Rows.Count.ToString();
                return;
            }
            if (FilterColumn == "DriverID" || FilterColumn == "PersonID")
                _dtAllDrivers.RowFilter = string.Format("[{0}]={1}", FilterColumn, tbFilterValue.Text.Trim());
            else
                _dtAllDrivers.RowFilter = string.Format("[{0}] LIKE '%{1}%'", FilterColumn, tbFilterValue.Text.Trim());
            lblRecordsCount.Text = _dtAllDrivers.Count.ToString();

        }


        private void tbFilterValue_TextChanged(object sender, EventArgs e)
        {
            if (_dtAllDrivers != null)
                ApplyFilterByCB_AbuHadhoud();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.Text != "None")
            {
                tbFilterValue.Visible = true;
                tbFilterValue.Focus();
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmsShowAppDetails_Click(object sender, EventArgs e)
        {
            int.TryParse(dgvAllDrivers.CurrentRow.Cells["PersonID"].Value.ToString(), out int SelectedID);
            frmPersonInfo frm = new frmPersonInfo(SelectedID);
            frm.ShowDialog();
        }

        private void cmsShowPersonLicenseHistory_Click(object sender, EventArgs e)
        {
            int.TryParse(dgvAllDrivers.CurrentRow.Cells["PersonID"].Value.ToString(), out int SelectedID);
            int DriverID = clsDriver.FindByPersonID(SelectedID).DriverID;
            frmLicenseHistory frm = new frmLicenseHistory(DriverID);
            frm.ShowDialog();
        }
    }
}
