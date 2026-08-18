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

namespace DVLD.Tests
{
    public partial class DeactivatedfrmScheduleTest : Form
    {
        private clsTestType.enTestType _testType = clsTestType.enTestType.VisionTest;
        private int _LocalAppID;
        private clslocalDrivingApp _LocalAppInfo;
        private int _TestAppointmentID=-1;
        private clsTestAppointment _TestAppointmentInfo;

        private enum enMode { AddNew=0, Update=1 }
        private enMode _enMode=enMode.AddNew;
        public DeactivatedfrmScheduleTest(int LocalAppID,clsTestType.enTestType testType)
        {
            InitializeComponent();
            _testType = testType;
            _LocalAppID = LocalAppID;
            _LocalAppInfo=clslocalDrivingApp.Find(LocalAppID);
            _enMode = enMode.AddNew;
        }
        public DeactivatedfrmScheduleTest(int localAppID, clsTestType.enTestType testType,int testAppointmentID)
        {
            InitializeComponent();
            _testType = testType;
            _LocalAppID = localAppID;
            _LocalAppInfo = clslocalDrivingApp.Find(localAppID);
            _TestAppointmentID=testAppointmentID;
            _TestAppointmentInfo = clsTestAppointment.Find(_TestAppointmentID);
            if (_TestAppointmentInfo.isLocked)
            {
                lblLockedWarning.Visible=true;
                dtpTestDate.Enabled = false;
                btnSave.Enabled = false;
            }
            _enMode = enMode.Update;
        }
        private void ResetDefaultValues()
        {
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
        private void LoadAppInfo()
        {
            float TestFees=0,RetakeFees = 0;
            lblLocalAppID.Text = _LocalAppInfo.LocalDrivingAppID.ToString();
            lblDriverClass.Text=clsLicenseClass.Find(_LocalAppInfo.LicenseClassID).ClassName;
            lblPersonName.Text=_LocalAppInfo.PersonFullName;

            int TestTrials= _LocalAppInfo.TotalTrialsPerTest(_testType);
            lblTrials.Text = TestTrials.ToString();
            
          
            switch (_enMode)
            {
                case enMode.AddNew:
                    TestFees = clsTestType.Find(_testType).TestTypeFees;
                    lblTestFees.Text = TestFees.ToString();
                    dtpTestDate.MinDate = DateTime.Today;
                    if (TestTrials > 0)
                    {
                        gbRetakeTest.Enabled = true;
                        RetakeFees = clsApplicationType.Find(clsApplication.enApplicationTypes.RetakeTest).ApplicationFees;
                        lblRetakeTestFees.Text = RetakeFees.ToString();
                        lblTotalFees.Text = (TestFees + RetakeFees).ToString();
                    }
                    break;
                case enMode.Update:
                    dtpTestDate.Value=_TestAppointmentInfo.AppointmentDate;
                    if (_TestAppointmentInfo.AppointmentDate > DateTime.Today)
                    {
                        dtpTestDate.MinDate= DateTime.Today;
                    }
                    TestFees = _TestAppointmentInfo.PaidFees;
                    lblTestFees.Text = TestFees.ToString();
                    if (_TestAppointmentInfo.RetakeTestApplicationID!=-1)
                    {
                        gbRetakeTest.Enabled = true;
                        RetakeFees = _TestAppointmentInfo.RetakeApplicationInfo.PaidFees;

                        lblTestFees.Text = TestFees.ToString();

                        lblRetakeTestFees.Text=RetakeFees.ToString();
                        lblTotalFees.Text = (RetakeFees + TestFees).ToString();
                        lblRetakeTestID.Text = _TestAppointmentInfo.RetakeTestApplicationID.ToString();
                    }
                    break;
                default:
                    break;
            }
        }
        private void frmScheduleTest_Load(object sender, EventArgs e)
        {
            ResetDefaultValues();
            if (_LocalAppInfo != null)
            {
                LoadAppInfo();
            }
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
                    clsTestAppointment testAppontment = new clsTestAppointment();
                    testAppontment.LocalDrivingAppID = _LocalAppID;
                    testAppontment.TestTypeId = _testType;
                    testAppontment.AppointmentDate = dtpTestDate.Value;
                    testAppontment.CreatedByUserID = clsGlobal.CurrentUser.UserID;
                    if (testAppontment.Save())
                    {
                        if (testAppontment.RetakeTestApplicationID != -1)
                            lblRetakeTestID.Text = testAppontment.RetakeTestApplicationID.ToString();
                        MessageBox.Show("Test appointment saved successfully");

                    }
                    else
                        MessageBox.Show("Cannot save this appointment!");
                    break;
                case enMode.Update:
                    _TestAppointmentInfo.AppointmentDate=dtpTestDate.Value;
                    _TestAppointmentInfo.CreatedByUserID = clsGlobal.CurrentUser.UserID;
                    if (_TestAppointmentInfo.Save())
                        MessageBox.Show("Test appointment Updated successfully");
                    else
                        MessageBox.Show("Cannot update this appointment!");
                    break;
                default:
                    break;
            }
            
            this.Close();
        }
    }
}
