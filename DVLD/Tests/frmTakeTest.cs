using DVLD.Global_Classes;
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
using static DVLD_Business.clsTestType;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD.Tests
{
    public partial class frmTakeTest : Form
    {
        private int _TestAppointmentID;
        private clsTestAppointment _TestAppointmentInfo;
        private int _TestID;
        private clsTest _TestInfo;
        public frmTakeTest(int testAppointmentID)
        {
            InitializeComponent();
            _TestAppointmentID = testAppointmentID;
            _TestAppointmentInfo=clsTestAppointment.Find(testAppointmentID);
        }
        private void ResetDefaultValues()
        {
            switch (_TestAppointmentInfo.TestTypeId)
            {
                case clsTestType.enTestType.VisionTest:
                    pbProfilePhoto.Image = Resources.Vision_512;
                    groupBox1.Text = "Vision Test";
                    break;
                case clsTestType.enTestType.WrittenTest:
                    pbProfilePhoto.Image = Resources.Written_Test_512;
                    groupBox1.Text = "Written Test";
                    break;
                case clsTestType.enTestType.StreetTest:
                    pbProfilePhoto.Image = Resources.driving_test_512;
                    groupBox1.Text = "Street Test";
                    break;
                default:
                    break;
            }
        }
        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            if (_TestAppointmentInfo == null)
            {
                MessageBox.Show("Does not found ths test appointment!");
                this.Close();
                return;
            }

            ResetDefaultValues();
            lblLocalAppID.Text = _TestAppointmentInfo.LocalDrivingAppID.ToString();
            lblDriverClass.Text = clsLicenseClass.Find(_TestAppointmentInfo.LocalDrivingAppInfo.LicenseClassID).ClassName;
            lblPersonName.Text = _TestAppointmentInfo.LocalDrivingAppInfo.PersonFullName;
            lblTrials.Text = _TestAppointmentInfo.LocalDrivingAppInfo.TotalTrialsPerTest(_TestAppointmentInfo.TestTypeId).ToString();
            lblDate.Text = _TestAppointmentInfo.AppointmentDate.ToString();

            if (_TestAppointmentInfo.isLocked)
            {
                clsTest testInfo = clsTest.FindByTestAppointmentID(_TestAppointmentID);
                if (testInfo!=null)
                {
                    _TestInfo = testInfo;
                    _TestID = testInfo.TestID;
                    if (testInfo.TestResult)
                        rbPass.Checked = true;
                    else
                        rbFail.Checked = true;
                    tbNotes.Text = testInfo.Notes;
                    lblErrorMessage.Visible = true;
                    rbPass.Enabled = false;
                    rbFail.Enabled = false;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_TestAppointmentInfo.isLocked)
            {
                _TestInfo.Notes = tbNotes.Text;
                if (_TestInfo.Save())
                {
                    MessageBox.Show("Data updated successfully");
                }
                else
                    MessageBox.Show("Error while saving!");
                this.Close();
            }
            if (MessageBox.Show("Are you sure you want to save? After save you cannot change the result","Confirm",MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                clsTest Test = new clsTest();
                Test.TestAppointmentID = _TestAppointmentID;
                Test.CreatedByUserID=clsGlobal.CurrentUser.UserID;
                Test.TestResult = rbPass.Checked;
                Test.Notes = tbNotes.Text.Trim();
                if (Test.Notes==string.Empty)
                    Test.Notes = "";
                if (Test.Save()) { 
                    MessageBox.Show("Data saved successfully");
                    lblTestFees.Text = Test.TestID.ToString();
                }
                else
                    MessageBox.Show("Error while saving!");
                this.Close();
            } 
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
