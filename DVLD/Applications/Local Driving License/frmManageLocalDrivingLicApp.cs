using DVLD.Licenses;
using DVLD.Licenses.Local_Licenses;
using DVLD.Tests;
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

namespace DVLD.Applications.Local_Driving_License
{
    public partial class frmManageLocalDrivingLicApp : Form
    {
        public frmManageLocalDrivingLicApp()
        {
            InitializeComponent();
        }
        private static DataView _dtAllLocalApps;
        private void RefreshData()
        {
            cbFilterBy.SelectedIndex = 0;

            tbFilterValue.Text = "";
            _dtAllLocalApps = DVLD_Business.clslocalDrivingApp.GetAllLocalDrivingLicenseApplications().DefaultView;
            dgvAllLocalApps.DataSource = _dtAllLocalApps;

            if (dgvAllLocalApps.Rows.Count > 0)
            {
                dgvAllLocalApps.Columns[0].HeaderText = "ID";
                dgvAllLocalApps.Columns[0].Width = 80;

                dgvAllLocalApps.Columns[1].HeaderText = "Class Name";
                dgvAllLocalApps.Columns[1].Width = 190;

                dgvAllLocalApps.Columns[2].HeaderText = "National Number";
                dgvAllLocalApps.Columns[2].Width = 90;

                dgvAllLocalApps.Columns[3].HeaderText = "Full Name";
                dgvAllLocalApps.Columns[3].Width = 235;

                dgvAllLocalApps.Columns[4].HeaderText = "Application Date";
                dgvAllLocalApps.Columns[4].Width = 150;

                dgvAllLocalApps.Columns[5].HeaderText = "Passed Test Count";
                dgvAllLocalApps.Columns[5].Width = 80;

                dgvAllLocalApps.Columns[6].HeaderText = "Status";
                dgvAllLocalApps.Columns[6].Width = 80;
            }
            lblRecordsCount.Text = _dtAllLocalApps.Count.ToString();
        }

        private void frmManageLocalDrivingLicApp_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void addNewLocalAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateNewLocalDrivingLicApp frm = new frmAddUpdateNewLocalDrivingLicApp();
            frm.ShowDialog();
            RefreshData();
        }

        private void editLocalAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int.TryParse(dgvAllLocalApps.CurrentRow.Cells["LocalDrivingLicenseApplicationID"].Value.ToString(), out int SelectedID);
            frmAddUpdateNewLocalDrivingLicApp frm = new frmAddUpdateNewLocalDrivingLicApp(SelectedID);
            frm.ShowDialog();
            RefreshData();
        }
        private void btnAddNewLocalApp_Click(object sender, EventArgs e)
        {
            frmAddUpdateNewLocalDrivingLicApp frm = new frmAddUpdateNewLocalDrivingLicApp();
            frm.ShowDialog();
            RefreshData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            //this will allow only digits if person id is selected
            if (cbFilterBy.Text == "L.D.L App ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void ApplyFilterByCB_AbuHadhoud()
        {
            if (tbFilterValue.Text == string.Empty)
            {
                _dtAllLocalApps.RowFilter = "";
                lblRecordsCount.Text = dgvAllLocalApps.Rows.Count.ToString();
                return;
            }
            string FilterColumn = "";
            switch (cbFilterBy.Text)
            {
                case "None":
                    FilterColumn = "";
                    break;
                case "L.D.L App ID":
                    FilterColumn = "LocalDrivingLicenseApplicationID";
                    break;
                case "National Number":
                    FilterColumn = "NationalNo";
                    break;
                case "Full Name":
                    FilterColumn = "FullName";
                    break;
                case "Status":
                    FilterColumn = "ApplicationStatus";
                    break;
                default:
                    FilterColumn = "";
                    break;
            }
            if (FilterColumn == "") {
                _dtAllLocalApps.RowFilter=FilterColumn;
                lblRecordsCount.Text = dgvAllLocalApps.Rows.Count.ToString();
                return;
            }
            if (FilterColumn == "LocalDrivingLicenseApplicationID")
                _dtAllLocalApps.RowFilter = string.Format("[{0}]={1}", FilterColumn, tbFilterValue.Text.Trim());
            else
                _dtAllLocalApps.RowFilter = string.Format("[{0}] LIKE '%{1}%'", FilterColumn, tbFilterValue.Text.Trim());
            lblRecordsCount.Text = dgvAllLocalApps.Rows.Count.ToString();

        }


        private void tbFilterValue_TextChanged(object sender, EventArgs e)
        {
            if (_dtAllLocalApps != null)
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
        private void ResetDefaultcmsValues()
        {
            cmsShowAppDetails.Enabled = true;

            cmsEditApp.Enabled = false;
            cmsDeleteApp.Enabled = false;
            cmsCancelApp.Enabled = false;
            cmsScheduleTests.Enabled = false;
            cmsScheduleVisionTest.Enabled = false;
            cmsScheduleWrittenTest.Enabled = false;
            cmsScheduleStreetTest.Enabled = false;
            cmsIssueDrivingLicenseFirstTime.Enabled = false;
            cmsShowLicense.Enabled = false;

            cmsShowPersonLicenseHistory.Enabled = true;
        }
        private void dgvAllLocalApps_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvAllLocalApps.ClearSelection();
                dgvAllLocalApps.CurrentCell = dgvAllLocalApps.Rows[e.RowIndex].Cells["LocalDrivingLicenseApplicationID"];
                dgvAllLocalApps.Rows[e.RowIndex].Selected = true;
            }
        }

        private void cmsMnageLocalApps_Opening(object sender, CancelEventArgs e)
        {
            ResetDefaultcmsValues();
            int.TryParse(dgvAllLocalApps.CurrentRow.Cells["LocalDrivingLicenseApplicationID"].Value.ToString(), out int SelectedID);
            clslocalDrivingApp _SelectedLocalApp = clslocalDrivingApp.Find(SelectedID);

            if (_SelectedLocalApp == null)
                return;

            if (_SelectedLocalApp.ApplicationStatus == clslocalDrivingApp.enApplicationStatus.Completed)
            {
                cmsEditApp.Enabled = false;
                cmsDeleteApp.Enabled = false;
                cmsCancelApp.Enabled = false;
                cmsScheduleTests.Enabled = false;
                cmsIssueDrivingLicenseFirstTime.Enabled = false;

                cmsShowLicense.Enabled = true;
                cmsShowPersonLicenseHistory.Enabled = true;
            }

            else if (_SelectedLocalApp.ApplicationStatus == clslocalDrivingApp.enApplicationStatus.New)
            {
                cmsEditApp.Enabled = true;
                cmsDeleteApp.Enabled = !(_SelectedLocalApp.DoesAttendTestType(clsTestType.enTestType.VisionTest));
                cmsEditApp.Enabled = !(_SelectedLocalApp.DoesAttendTestType(clsTestType.enTestType.VisionTest));
                cmsCancelApp.Enabled = true;
                if (clslocalDrivingApp.GetPassedTestCount(SelectedID)==3)
                {
                    cmsScheduleTests.Enabled = false;
                    cmsIssueDrivingLicenseFirstTime.Enabled = true;
                }
                else
                {
                    cmsScheduleTests.Enabled = true;
                    
                    if (_SelectedLocalApp.DoesPassPreviousTestType(clsTestType.enTestType.StreetTest))
                        cmsScheduleStreetTest.Enabled = true;
                    else if (_SelectedLocalApp.DoesPassPreviousTestType(clsTestType.enTestType.WrittenTest))
                        cmsScheduleWrittenTest.Enabled = true;
                    else if (_SelectedLocalApp.DoesPassPreviousTestType(clsTestType.enTestType.VisionTest))
                        cmsScheduleVisionTest.Enabled = true;
                }

                cmsShowLicense.Enabled = false;
                cmsShowPersonLicenseHistory.Enabled = false;
            }
            else if (_SelectedLocalApp.ApplicationStatus == clslocalDrivingApp.enApplicationStatus.Cancelled)
                cmsDeleteApp.Enabled = !(_SelectedLocalApp.DoesAttendTestType(clsTestType.enTestType.VisionTest));
        }

        private void cmsDeleteApp_Click(object sender, EventArgs e)
        {
            int.TryParse(dgvAllLocalApps.CurrentRow.Cells["LocalDrivingLicenseApplicationID"].Value.ToString(), out int SelectedID);
            if (MessageBox.Show("Are you sure that you will delete Local App ID="+SelectedID.ToString()+"?","Warning",MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                if (clslocalDrivingApp.Delete(SelectedID))
                {
                    MessageBox.Show("Selected Application deleted successfully!");
                    RefreshData();
                }
                else
                    MessageBox.Show("Application linked with another data!, you can just cancel this application");
            }

        }

        private void cmsScheduleVisionTest_Click(object sender, EventArgs e)
        {
            int.TryParse(dgvAllLocalApps.CurrentRow.Cells["LocalDrivingLicenseApplicationID"].Value.ToString(), out int SelectedID);
            frmScheduleTestAppointment frm = new frmScheduleTestAppointment(SelectedID, clsTestType.enTestType.VisionTest);
            frm.ShowDialog();
            RefreshData();
        }
        private void cmsScheduleWrittenTest_Click(object sender, EventArgs e)
        {
            int.TryParse(dgvAllLocalApps.CurrentRow.Cells["LocalDrivingLicenseApplicationID"].Value.ToString(), out int SelectedID);
            frmScheduleTestAppointment frm = new frmScheduleTestAppointment(SelectedID, clsTestType.enTestType.WrittenTest);
            frm.ShowDialog();
            RefreshData();
        }
        private void cmsScheduleStreetTest_Click(object sender, EventArgs e)
        {
            int.TryParse(dgvAllLocalApps.CurrentRow.Cells["LocalDrivingLicenseApplicationID"].Value.ToString(), out int SelectedID);
            frmScheduleTestAppointment frm = new frmScheduleTestAppointment(SelectedID, clsTestType.enTestType.StreetTest);
            frm.ShowDialog();
            RefreshData();
        }
        private void cmsCancelApp_Click(object sender, EventArgs e)
        {
            int.TryParse(dgvAllLocalApps.CurrentRow.Cells["LocalDrivingLicenseApplicationID"].Value.ToString(), out int SelectedID);
            if (MessageBox.Show("Are you sure that you will cancel this Local App ?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (clslocalDrivingApp.Find(SelectedID).CancelApplication())
                {
                    MessageBox.Show("Selected Application cancelled successfully!");
                    RefreshData();
                }
                else
                    MessageBox.Show("You cannot cancel this Application!");
            }
        }

        private void cmsShowAppDetails_Click(object sender, EventArgs e)
        {
            int.TryParse(dgvAllLocalApps.CurrentRow.Cells["LocalDrivingLicenseApplicationID"].Value.ToString(), out int SelectedID);
            frmShowLocalDrivingAppInfo frm = new frmShowLocalDrivingAppInfo(SelectedID);
            frm.ShowDialog();
        }

        private void cmsIssueDrivingLicenseFirstTime_Click(object sender, EventArgs e)
        {
            int.TryParse(dgvAllLocalApps.CurrentRow.Cells["LocalDrivingLicenseApplicationID"].Value.ToString(), out int SelectedID);
            frmIssueNewLicenseFirstTime frm=new frmIssueNewLicenseFirstTime(SelectedID);
            frm.ShowDialog();
            RefreshData();
        }

        private void cmsShowLicense_Click(object sender, EventArgs e)
        {
            int.TryParse(dgvAllLocalApps.CurrentRow.Cells["LocalDrivingLicenseApplicationID"].Value.ToString(), out int SelectedID);
            clslocalDrivingApp localAppInfo= clslocalDrivingApp.Find(SelectedID);
            frmShowLicenseInfo frm = new frmShowLicenseInfo(localAppInfo.GetActiveLicenseID());
            frm.ShowDialog();
        }

        private void cmsShowPersonLicenseHistory_Click(object sender, EventArgs e)
        {
            int.TryParse(dgvAllLocalApps.CurrentRow.Cells["LocalDrivingLicenseApplicationID"].Value.ToString(), out int SelectedID);
            int DriverID=clsDriver.FindByPersonID(clslocalDrivingApp.Find(SelectedID).ApplicantPersonID).DriverID;
            frmLicenseHistory frm = new frmLicenseHistory(DriverID);
            frm.ShowDialog();
        }
    }
}
