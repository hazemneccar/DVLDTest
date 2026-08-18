using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static DVLD_Business.clsApplication;
using static DVLD_Business.clsTestType;

namespace DVLD_Business
{
    public class clsTestAppointment
    {
        public enum enMode
        {
            AddNew=0,Update=1
        }
        public enMode mode=enMode.AddNew;
        public int TestAppointmentId { get; set; }
        public clsTestType.enTestType TestTypeId { get; set; }
        public clsTestType TestTypeInfo { get; set; }
        public int LocalDrivingAppID { get; set; }
        public clslocalDrivingApp LocalDrivingAppInfo { get; set; }
        public DateTime AppointmentDate { get; set; }
        public float PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public clsUser CreatedByUserInfo {  get; set; }
        public bool isLocked { get; set; }
        public int RetakeTestApplicationID { get; set; }
        public clsApplication RetakeApplicationInfo { get; set; }
        private clsTestAppointment(
        int testAppointmentID, enTestType testTypeID, int localDrivingAppID,
            DateTime appointmentDate, float paidFees, int createdByUserID, bool isLocked, int retakeTestApplicationID)
        {
            this.mode = enMode.Update;
            this.TestAppointmentId = testAppointmentID;
            this.TestTypeId = testTypeID;
            this.LocalDrivingAppID = localDrivingAppID;
            this.AppointmentDate = appointmentDate;
            this.PaidFees = paidFees;
            this.CreatedByUserID = createdByUserID;
            this.isLocked = isLocked;
            this.RetakeTestApplicationID = retakeTestApplicationID;

            this.TestTypeInfo = clsTestType.Find(testTypeID);
            this.LocalDrivingAppInfo = clslocalDrivingApp.Find(localDrivingAppID);
            this.CreatedByUserInfo = clsUser.Find(createdByUserID);

            if (retakeTestApplicationID > 0) //RetakeTestApplication var demek
                this.RetakeApplicationInfo = clsApplication.Find(retakeTestApplicationID);
            else
                this.RetakeApplicationInfo = null;
        }
        public clsTestAppointment()
        {
            this.mode = enMode.AddNew;
            this.TestAppointmentId = -1; 
            this.TestTypeId = enTestType.VisionTest;
            this.LocalDrivingAppID = -1;
            this.AppointmentDate = DateTime.Now;
            this.PaidFees = 0;
            this.CreatedByUserID = -1;
            this.isLocked = false;
            this.RetakeTestApplicationID = -1;

            this.TestTypeInfo = null;
            this.LocalDrivingAppInfo = null;
            this.CreatedByUserInfo = null;
            this.RetakeApplicationInfo = null;
        }
        public static clsTestAppointment Find(int TestAppointmentId)
        {
            int testTypeId = -1, localDrivingAppID = -1, createdByUserID = -1, retakeTestApplicationID = -1;
            DateTime appointmentDate = DateTime.Now; 
            float paidFees = 0;  
            bool isLocked = false; 

            if (clsTestAppointmentData.GetTestAppointmentInfoByID(TestAppointmentId, ref testTypeId, ref localDrivingAppID, ref appointmentDate, ref paidFees, ref createdByUserID, ref isLocked, ref retakeTestApplicationID))
                return new clsTestAppointment(TestAppointmentId, (clsTestType.enTestType)testTypeId, localDrivingAppID, appointmentDate, paidFees, createdByUserID, isLocked, retakeTestApplicationID);

            return null;
        }
        public static clsTestAppointment GetLastTestAppointment(int localDrivingAppID,enTestType testTypeId)
        {
            int TestAppointmentId = -1, createdByUserID = -1, retakeTestApplicationID = -1;
            DateTime appointmentDate = DateTime.Now;
            float paidFees = 0;
            bool isLocked = false;

            if (clsTestAppointmentData.GetLastTestAppointment(ref TestAppointmentId,localDrivingAppID,(short)testTypeId, ref appointmentDate, ref paidFees, ref createdByUserID, ref isLocked, ref retakeTestApplicationID))
                return new clsTestAppointment(TestAppointmentId, testTypeId, localDrivingAppID, appointmentDate, paidFees, createdByUserID, isLocked, retakeTestApplicationID);

            return null;
        }
        public static DataTable GetAllTestAppointments()
        {
            return DVLD_DataAccess.clsTestAppointmentData.GetAllTestAppointments();
        }
        public static DataTable GetAppTestAppointmentsByTestType(int localDrivingAppID, enTestType testTypeID)
        {
            return DVLD_DataAccess.clsTestAppointmentData.GetAppTestAppointmentsByTestType(localDrivingAppID, (short)testTypeID);
        }
        public DataTable GetAppTestAppointmentsByTestType(enTestType testTypeID)
        {
            return GetAppTestAppointmentsByTestType(this.LocalDrivingAppID, testTypeID);
        }
        private int _GetTestID()
        {
            return DVLD_DataAccess.clsTestAppointmentData.GetTestID(this.TestAppointmentId);
        }

        public static bool AddNewTestAppointment(int localDrivingAppID, enTestType testType,
            DateTime appointmentDate, int createdByUserID)
        {
            clsApplication RetakeApplication = null;
            if (clsTest.isPersonHaveActiveTestAppointment(localDrivingAppID, testType))
                return false;
            if (clslocalDrivingApp.DoesPassPreviousTestType(localDrivingAppID, testType) || clslocalDrivingApp.Find(localDrivingAppID).ApplicationStatus == enApplicationStatus.Completed)
                return false;
            if (clsTest.isPersonFaildPrevTest(localDrivingAppID, testType))
                RetakeApplication = clsTest.CreateRetakeApp(localDrivingAppID, createdByUserID);


            clsTestAppointment testAppointment = new clsTestAppointment();
            testAppointment.TestTypeId = testType;
            testAppointment.LocalDrivingAppID = localDrivingAppID;
            testAppointment.AppointmentDate = appointmentDate;
            testAppointment.PaidFees = clsTestType.Find(testType).TestTypeFees;
            if (RetakeApplication != null)
            {
                testAppointment.PaidFees += RetakeApplication.PaidFees;
                testAppointment.RetakeTestApplicationID = RetakeApplication.ApplicationID;
            }
            testAppointment.CreatedByUserID = createdByUserID;
            testAppointment.isLocked = false;
            testAppointment.TestAppointmentId = clsTestAppointmentData.AddNewTestAppointment((int)testAppointment.TestTypeId,
                testAppointment.LocalDrivingAppID, testAppointment.AppointmentDate, testAppointment.PaidFees,
                testAppointment.CreatedByUserID, testAppointment.isLocked, testAppointment.RetakeTestApplicationID
            );
            return (testAppointment.TestAppointmentId != -1);

            //return testAppointment.Save();
        }
        public static bool UpdateTestAppointment(int testAppointmentID, DateTime appointmentDate, int createdByUserID)
        {
            clsTestAppointment testAppointment = clsTestAppointment.Find(testAppointmentID);
            if (testAppointment != null)
            {
                if (!testAppointment.isLocked)
                {
                    testAppointment.AppointmentDate = appointmentDate;
                    testAppointment.CreatedByUserID = createdByUserID;
                    return (testAppointment.Save());
                }
            }
            return false;
        }

        protected bool _AddNewTestAppointment()
        {
            clsApplication RetakeApplication = null;
            if (clsTest.isPersonHaveActiveTestAppointment(this.LocalDrivingAppID,this.TestTypeId))
                return false;
            if (clslocalDrivingApp.DoesPassTestType(this.LocalDrivingAppID, this.TestTypeId) || clslocalDrivingApp.Find(this.LocalDrivingAppID).ApplicationStatus == enApplicationStatus.Completed)
                return false;
            if (clsTest.isPersonFaildPrevTest(this.LocalDrivingAppID, this.TestTypeId))
                RetakeApplication = clsTest.CreateRetakeApp(this.LocalDrivingAppID, this.CreatedByUserID);


            clsTestAppointment testAppointment = new clsTestAppointment();
            testAppointment.TestTypeId = this.TestTypeId;
            testAppointment.LocalDrivingAppID = this.LocalDrivingAppID;
            testAppointment.AppointmentDate = this.AppointmentDate;
            testAppointment.PaidFees = clsTestType.Find(this.TestTypeId).TestTypeFees;
            if (RetakeApplication != null)
            {
                testAppointment.RetakeTestApplicationID = RetakeApplication.ApplicationID;
            }
            testAppointment.CreatedByUserID = this.CreatedByUserID;
            testAppointment.isLocked = false;
            testAppointment.TestAppointmentId = clsTestAppointmentData.AddNewTestAppointment((int)testAppointment.TestTypeId,
                testAppointment.LocalDrivingAppID, testAppointment.AppointmentDate, testAppointment.PaidFees,
                testAppointment.CreatedByUserID, testAppointment.isLocked, testAppointment.RetakeTestApplicationID
            );
            return (testAppointment.TestAppointmentId != -1);
        }
        protected bool _UpdateTestAppointment()
        {
            return clsTestAppointmentData.UpdateTestAppointment(this.TestAppointmentId,
                (int)this.TestTypeId,this.LocalDrivingAppID,this.AppointmentDate,this.PaidFees,
                this.CreatedByUserID,this.isLocked,this.RetakeTestApplicationID
            );
        }
        public bool Save()
        {
            switch (mode)
            {
                case enMode.AddNew:
                    if (_AddNewTestAppointment())
                    {
                        mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _UpdateTestAppointment();
            }

            return false;
        }

        

    }
}
