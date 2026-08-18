using DVLD.Properties;
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
using static DVLD_Business.clsApplication;

namespace DVLD.Tests
{
    public partial class frmScheduleTestAppointment : Form
    {
        private clsTestType.enTestType _TestType=clsTestType.enTestType.VisionTest;
        private DataView _dtAllAppointments;
        private int _LocalAppID;

        public frmScheduleTestAppointment(int LocalAppID,clsTestType.enTestType testType)
        {
            InitializeComponent();
            _TestType = testType;
            _LocalAppID = LocalAppID;
        }
        
        private void RefreshData()
        {
            _dtAllAppointments = DVLD_Business.clsTestAppointment.GetAppTestAppointmentsByTestType(_LocalAppID, _TestType).DefaultView;
            dgvAppointments.DataSource = _dtAllAppointments;
            if (dgvAppointments.Rows.Count>0)
            {
                dgvAppointments.Columns[0].HeaderText = "Appointment ID";
                dgvAppointments.Columns[0].Width = 110;

                dgvAppointments.Columns[1].HeaderText = "Appointment Date";
                dgvAppointments.Columns[1].Width = 150;

                dgvAppointments.Columns[2].HeaderText = "Appointment Fees";
                dgvAppointments.Columns[2].Width = 150;

                dgvAppointments.Columns[3].HeaderText = "Is Locked";
                dgvAppointments.Columns[3].Width = 100;
            }
            lblTotalRecords.Text = dgvAppointments.Rows.Count.ToString();
            ctrlLocalDrivingAppInfo1.LoadLocalAppInfoByLocalAppID(_LocalAppID);
        }
        public void ResetDefaultValues()
        {
            switch (_TestType)
            {
                case clsTestType.enTestType.VisionTest:
                    pbTestProfile.Image = Resources.Vision_512;
                    lblTitle.Text = "Vision Test Appointment";
                    this.Text= "Vision Test Appointment";
                    break;
                case clsTestType.enTestType.WrittenTest:
                    pbTestProfile.Image = Resources.Written_Test_512;
                    lblTitle.Text = "Written Test Appointment";
                    this.Text = "Written Test Appointment";
                    break;
                case clsTestType.enTestType.StreetTest:
                    pbTestProfile.Image = Resources.driving_test_512;
                    lblTitle.Text = "Street Test Appointment";
                    this.Text = "Street Test Appointment";
                    break;
                default:
                    break;
            }
        }
        private void frmScheduleTest_Load(object sender, EventArgs e)
        {
            ResetDefaultValues();
            RefreshData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnScheduleNewTest_Click(object sender, EventArgs e)
        {
            if (clsTest.isPersonHaveActiveTestAppointment(_LocalAppID, _TestType))
            {
                MessageBox.Show("There is Active test Appointment already!");
                return;
            }
            if (clslocalDrivingApp.DoesPassTestType(_LocalAppID, _TestType) || clslocalDrivingApp.Find(_LocalAppID).ApplicationStatus == enApplicationStatus.Completed)
            {
                MessageBox.Show("You are passed this test already!");
                return;
            }
            frmScheduleTest frm = new frmScheduleTest(_LocalAppID, _TestType);
            frm.ShowDialog();
            RefreshData();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*bool.TryParse(dgvAppointments.CurrentRow.Cells["IsLocked"].Value.ToString(), out bool IsLocked);
            if (IsLocked)
            {
                MessageBox.Show("You cannot edit finished applicaitions!");
                return;
            }*/
            int.TryParse(dgvAppointments.CurrentRow.Cells["TestAppointmentID"].Value.ToString(), out int SelectedID);
            frmScheduleTest frm = new frmScheduleTest(_LocalAppID, _TestType,SelectedID);
            frm.ShowDialog();
            RefreshData();
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool.TryParse(dgvAppointments.CurrentRow.Cells["IsLocked"].Value.ToString(), out bool IsLocked);
            if (IsLocked)
            {
                MessageBox.Show("You cannot take finished tests!");
                return;
            }
            int.TryParse(dgvAppointments.CurrentRow.Cells["TestAppointmentID"].Value.ToString(), out int SelectedID);
            frmTakeTest frm = new frmTakeTest(SelectedID);
            frm.ShowDialog();
            RefreshData();
        }
    }
}
