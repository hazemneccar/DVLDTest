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
using static DVLD_Business.clsApplication;
using static DVLD_Business.clsTestType;

namespace DVLD.Tests
{
    public partial class ctrlScheduleTest : UserControl
    {
        public ctrlScheduleTest()
        {
            InitializeComponent();
        }
        private int _LocalAppID;
        private clslocalDrivingApp _LocalAppInfo;

        private int _TestAppointmentID = -1;
        private clsTestAppointment _TestAppointmentInfo;

        public enum enCreationMode { FirstTimeSchedule=0, RetakeTestSchedule=1}
        private enCreationMode _CreationMode= enCreationMode.FirstTimeSchedule;

        private clsTestType.enTestType _testType = clsTestType.enTestType.VisionTest;
        public clsTestType.enTestType TestType
        {
            get
            {
                return _testType;
            }
            set
            {
                _testType = value;
                switch (_testType)
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
        }

        private enum enMode { AddNew = 0, Update = 1 }
        private enMode _enMode = enMode.AddNew;
        public void LoadTestInfo(int localAppID, int testAppointmentID=-1)
        {
            if (testAppointmentID==-1)
                _enMode=enMode.AddNew;
            else
                _enMode=enMode.Update;

            _LocalAppID = localAppID;
            _LocalAppInfo = clslocalDrivingApp.Find(localAppID);
            _TestAppointmentID = testAppointmentID;
            if (_LocalAppInfo == null)
            {
                MessageBox.Show("There is no local Driving License App with ID=" + localAppID);
                btnSave.Enabled=false;
                return;
            }
            

            if (_LocalAppInfo.DoesAttendTestType(_testType))
            {
                _CreationMode = enCreationMode.RetakeTestSchedule;
                lblTitle.Text = "Retake Schedule Test";
                gbRetakeTest.Enabled = true;
                lblRetakeTestFees.Text = clsApplicationType.Find(clsApplication.enApplicationTypes.RetakeTest).ApplicationFees.ToString();
                lblRetakeTestID.Text = "[???]";
            }
            else
            {
                _CreationMode = enCreationMode.FirstTimeSchedule;
                lblTitle.Text = "Schedule Test";
                gbRetakeTest.Enabled = false;
                lblRetakeTestFees.Text = "0";
                lblRetakeTestID.Text = "N/A";
            }
            lblLocalAppID.Text = _LocalAppInfo.LocalDrivingAppID.ToString();
            lblDriverClass.Text = clsLicenseClass.Find(_LocalAppInfo.LicenseClassID).ClassName;
            lblPersonName.Text = _LocalAppInfo.PersonFullName;
            lblTrials.Text = _LocalAppInfo.TotalTrialsPerTest(_testType).ToString();
            if (_enMode==enMode.AddNew)
            {
                lblTestFees.Text = clsTestType.Find(_testType).TestTypeFees.ToString();
                dtpTestDate.MinDate = DateTime.Today;
                lblRetakeTestID.Text = "N/A";
                _TestAppointmentInfo = new clsTestAppointment();
            }
            else
            {
                if (!LoadAppInfo())
                    return;
            }
            lblTotalFees.Text = (Convert.ToSingle(lblTestFees.Text) + Convert.ToSingle(lblRetakeTestFees.Text)).ToString();
            if (!_HandleActiveTestAppointmentConstraint())
                return;
            if (!_HandlePrviousTestConstraint())
                return;
            if (!_HandleAppointmentLockedConstraint())
                return;
        }
        private bool LoadAppInfo()
        {
            _TestAppointmentInfo = clsTestAppointment.Find(_TestAppointmentID);
            if (_TestAppointmentInfo == null)
            {
                MessageBox.Show("There is no this Test appointment!");
                btnSave.Enabled = false;
                return false;
            }
            lblTestFees.Text = _TestAppointmentInfo.PaidFees.ToString();

            if (_TestAppointmentInfo.AppointmentDate > DateTime.Today)
                dtpTestDate.MinDate = DateTime.Today;
            else
                dtpTestDate.MinDate = _TestAppointmentInfo.AppointmentDate;
            dtpTestDate.Value = _TestAppointmentInfo.AppointmentDate;

            if (_TestAppointmentInfo.RetakeTestApplicationID == -1)
            {
                gbRetakeTest.Enabled = false;
                lblRetakeTestFees.Text = "0";
                lblRetakeTestID.Text = "N/A";
            }
            else
            {
                lblRetakeTestFees.Text = _TestAppointmentInfo.RetakeApplicationInfo.PaidFees.ToString();
                lblRetakeTestID.Text = _TestAppointmentInfo.RetakeTestApplicationID.ToString();
                lblTitle.Text = "Retake Schedule Test";
                gbRetakeTest.Enabled = true;
            }
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dtpTestDate.Value < DateTime.Today)
            {
                MessageBox.Show("This date is expired");
                return;
            }
            switch (_enMode)
            {
                case enMode.AddNew:
                    //Empty Object created in AddNew mode (LoadTestInfo) 
                    //_TestAppointmentInfo = new clsTestAppointment();
                    _TestAppointmentInfo.LocalDrivingAppID = _LocalAppID;
                    _TestAppointmentInfo.TestTypeId = _testType;
                    _TestAppointmentInfo.AppointmentDate = dtpTestDate.Value;
                    _TestAppointmentInfo.CreatedByUserID = clsGlobal.CurrentUser.UserID;
                    if (_TestAppointmentInfo.Save())
                    {
                        if (_TestAppointmentInfo.RetakeTestApplicationID != -1)
                            lblRetakeTestID.Text = _TestAppointmentInfo.RetakeTestApplicationID.ToString();
                        MessageBox.Show("Test appointment saved successfully");

                    }
                    else
                        MessageBox.Show("Cannot save this appointment!");
                    break;
                case enMode.Update:
                    _TestAppointmentInfo.AppointmentDate = dtpTestDate.Value;
                    _TestAppointmentInfo.CreatedByUserID = clsGlobal.CurrentUser.UserID;
                    if (_TestAppointmentInfo.Save())
                        MessageBox.Show("Test appointment Updated successfully");
                    else
                        MessageBox.Show("Cannot update this appointment!");
                    break;
                default:
                    break;
            }

            ParentForm.Close();
        }

        public bool _HandleActiveTestAppointmentConstraint()
        {
            if (_enMode==enMode.AddNew && clsTest.isPersonHaveActiveTestAppointment(_LocalAppID,_testType))
            {
                lblLockedWarning.Visible = true;
                lblLockedWarning.Text = "Person Already have an active appointment for this test";
                btnSave.Enabled = false;
                dtpTestDate.Enabled = false;
                return false ;
            }
            return true;
        }
        public bool _HandlePrviousTestConstraint()
        {
            if (clslocalDrivingApp.DoesPassTestType(_LocalAppID, _testType) || clslocalDrivingApp.Find(_LocalAppID).ApplicationStatus == enApplicationStatus.Completed)
            {
                lblLockedWarning.Visible = true;
                lblLockedWarning.Text = "Person Already passed this test";
                btnSave.Enabled = false;
                dtpTestDate.Enabled = false;
                return false;
            }
            return true;
        }
        public bool _HandleAppointmentLockedConstraint()
        {
            if (_TestAppointmentInfo.isLocked)
            {
                lblLockedWarning.Visible = true;
                lblLockedWarning.Text = "Person already sat for the Test, Appintment locked";
                dtpTestDate.Enabled = false;
                btnSave.Enabled = false;
                return false;
            }
            else
                lblLockedWarning.Visible = false;

            return true;
        }
    }
}
