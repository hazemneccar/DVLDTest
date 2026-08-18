using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DVLD_Business.clsApplication;
using static DVLD_Business.clsLicenseClass;
using static DVLD_Business.clsTestType;

namespace DVLD_Business
{
    public class clsTest
    {
        public enum enMode
        {
            AddNew=0,Update=1
        }
        public enMode mode;
        public int TestID { get; set; }
        public int TestAppointmentID { get; set; }
        public clsTestAppointment TestAppointmentInfo { get; set; }
        public bool TestResult { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }
        public clsTest()
        {
            TestID = -1;
            TestAppointmentID = -1;
            TestResult = false;
            Notes = "";
            CreatedByUserID = -1;
        }
        private clsTest(int testID, int testAppointmentID, bool testResult, string notes, int createdByUserID)
        {
            TestID = testID;
            TestAppointmentID = testAppointmentID;
            TestAppointmentInfo = clsTestAppointment.Find(testAppointmentID);
            TestResult = testResult;
            Notes = notes;
            CreatedByUserID = createdByUserID;
        }
        public static clsTest Find(int testID)
        {
            int testAppointmentID = -1, createdByUserID = -1; 
            bool testResult = false; 
            string notes = "";

            if (clsTestData.GetTestInfoByID(testID, ref testAppointmentID, ref testResult, ref notes, ref createdByUserID))
                return new clsTest(testID, testAppointmentID, testResult, notes, createdByUserID);
            else
                return null;
        }
        public static clsTest FindByTestAppointmentID(int testAppointmentID)
        {
            int testID = -1, createdByUserID = -1;
            bool testResult = false;
            string notes = "";

            if (clsTestData.GetTestInfoByTestAppointmentID(ref testID, testAppointmentID, ref testResult, ref notes, ref createdByUserID))
                return new clsTest(testID, testAppointmentID, testResult, notes, createdByUserID);
            else
                return null;
        }

        public static clsTest FindLastTestByPersonAndLicenseClass(int PersonID, enLicenseClasses LicenseClassID, clsTestType.enTestType testType)
        {
            int testID=-1,testAppointmentID = -1, createdByUserID = -1;
            bool testResult = false;
            string notes = "";

            if (clsTestData.FindLastTestByPersonAndLicenseClass(PersonID,(int)LicenseClassID,(short)testType
                ,ref testID, ref testAppointmentID, ref testResult, ref notes, ref createdByUserID))
                return new clsTest(testID,testAppointmentID, testResult, notes, createdByUserID);
            else
                return null;
        }
        protected bool _AddNewTest()
        {
            this.TestID = clsTestData.AddNewTest(this.TestAppointmentID, this.TestResult, this.Notes, this.CreatedByUserID);
            return (this.TestID != -1);
        }
        protected bool _UpdateTest()
        {
            return clsTestData.UpdateTest(this.TestID, this.TestAppointmentID, this.TestResult, this.Notes, this.CreatedByUserID);
        }
        public bool Save()
        {
            switch (mode)
            {
                case enMode.AddNew:
                    if (_AddNewTest())
                    {
                        mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _UpdateTest();
            }

            return false;
        }
        public static DataTable GetAllTests()
        {
            return DVLD_DataAccess.clsTestData.GetAllTests();
        }
        public static short GetPassedTestCount(int localDrivingAppID)
        {
            return clsTestData.GetPassedTestCount(localDrivingAppID);
        }
        public static bool PassedAllTests(int localDrivingAppID)
        {
            return (clsTestData.GetPassedTestCount(localDrivingAppID)==3);
        }



        public static bool isPersonFaildPrevTest(int localDrivingID, enTestType testType)
        {
            return DVLD_DataAccess.clsTestData.isPersonFaildPrevTest(localDrivingID, (short)testType);
        }
        public static bool isPersonHaveActiveTestAppointment(int localDrivingID, enTestType testType)
        {
            return DVLD_DataAccess.clslocalDrivingAppData.isThereAnActiveScheduledTest(localDrivingID, (short)testType);

        }
        public static clsApplication CreateRetakeApp(int localDrivingID, int createdByUserID)
        {
            clslocalDrivingApp LocalDrivingAppInfo = clslocalDrivingApp.Find(localDrivingID);
            clsApplication RetakeAppInfo = new clsApplication();
            RetakeAppInfo.ApplicantPersonID = LocalDrivingAppInfo.ApplicantPersonID;
            RetakeAppInfo.ApplicationTypeID = enApplicationTypes.RetakeTest;
            RetakeAppInfo.PaidFees = clsApplicationType.Find(enApplicationTypes.RetakeTest).ApplicationFees;
            RetakeAppInfo.CreatedByUserID = createdByUserID;
            if (RetakeAppInfo.Save())
                return RetakeAppInfo;
            else
                return null;
        }
        
        public static bool SetTestAppointmentLocked(int testAppointmentID)
        {
            return DVLD_DataAccess.clsTestData.SetTestAppointmentLocked(testAppointmentID);
        }
        public static bool SetTestResult(int testAppointmentID, bool testResult, string notes, int createdByUserID)
        {
            clsTest Test = new clsTest();
            Test.TestAppointmentID = testAppointmentID;
            Test.TestResult = testResult;
            Test.Notes = notes;
            Test.CreatedByUserID = createdByUserID;
            if (Test.Save())
            {
                SetTestAppointmentLocked(testAppointmentID);
                return true;
            }
            return false;
        }
    }
}
