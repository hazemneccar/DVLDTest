using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using static DVLD_Business.clsTestType;

namespace DVLD_Business
{
    public class clslocalDrivingApp:clsApplication
    {
        public new enum enMode
        {
            enAddNew=0,enUpdate=1
        }
        public new enMode mode= enMode.enAddNew;
        public int LocalDrivingAppID {  get; set; }
        public int LicenseClassID {  get; set; }
        public string PersonFullName
        {
            get { return base.ApplicantPersonInfo.FullName; }
        }
        private clslocalDrivingApp(int LocalDrivingAppID, int LicenseClassID, int applicationID, int applicantPersonID, DateTime applicationDate, int applicationTypeID,
            enApplicationStatus applicationStatus, DateTime lastStatusDate, float paidFees, int createdByUserID)
        {
            this.LocalDrivingAppID= LocalDrivingAppID;
            this.LicenseClassID = LicenseClassID;
            this.ApplicationID = applicationID;
            this.ApplicantPersonID = applicantPersonID;
            this.ApplicantPersonInfo = clsPerson.GetPersonInfoByPersonID(applicantPersonID);
            this.ApplicationDate = applicationDate;
            this.ApplicationTypeID =(enApplicationTypes) applicationTypeID;
            this.ApplicationTypeInfo = clsApplicationType.Find((clsApplication.enApplicationTypes)applicationTypeID);
            this.ApplicationStatus = applicationStatus;
            this.LastStatusDate = lastStatusDate;
            this.PaidFees = paidFees;
            this.CreatedByUserID = createdByUserID;

            mode = enMode.enUpdate;
        }
        public clslocalDrivingApp()
        {
            this.LocalDrivingAppID = -1;
            this.LicenseClassID = -1;
            this.ApplicationID = -1;
            this.ApplicantPersonID = -1;
            this.ApplicationDate = DateTime.Now;
            this.ApplicationTypeID = enApplicationTypes.NewLocalDrivingLicense;
            this.ApplicationStatus =enApplicationStatus.New;
            this.LastStatusDate = DateTime.Now;
            this.PaidFees = 0;
            this.CreatedByUserID = -1;

            mode = enMode.enAddNew;
        }
        public new static clslocalDrivingApp Find(int localDrivingLicenseApplicationID)
        {
            int applicationID = -1; int licenseClassID = -1;

            if (clslocalDrivingAppData.Find(localDrivingLicenseApplicationID, ref applicationID, ref licenseClassID))
            {
                clsApplication application=clsApplication.Find(applicationID);
                if (application!=null)
                {
                    return new clslocalDrivingApp(localDrivingLicenseApplicationID, 
                        licenseClassID, applicationID,application.ApplicantPersonID, application.ApplicationDate,
                        (int)application.ApplicationTypeID,application.ApplicationStatus, 
                        application.LastStatusDate, application.PaidFees, application.CreatedByUserID);
                }
                else
                    return null;
            }
            else
                return null;
        }
        public static clslocalDrivingApp FindByAppID(int applicationID)
        {
            int localDrivingLicenseApplicationID = -1; int licenseClassID = -1;

            if (clslocalDrivingAppData.FindByApplicationID(ref localDrivingLicenseApplicationID, applicationID, ref licenseClassID))
            {
                int applicantPersonID = -1; DateTime applicationDate = DateTime.Now; int applicationTypeID = -1;
                byte applicationStatus = 1; DateTime lastStatusDate = DateTime.Now; float paidFees = 0; int createdByUserID = -1;

                if (clsApplicationData.GetApplicationInfoByID(applicationID, ref applicantPersonID, ref applicationDate, ref applicationTypeID, ref applicationStatus, ref lastStatusDate, ref paidFees, ref createdByUserID))
                    return new clslocalDrivingApp(localDrivingLicenseApplicationID, licenseClassID, applicationID, applicantPersonID, applicationDate, applicationTypeID, (enApplicationStatus)applicationStatus, lastStatusDate, paidFees, createdByUserID);
                else
                    return null;
            }
            else
                return null;
        }
        public static clslocalDrivingApp FindByNationalityID(string nationalityID)
        {
            int localDrivingLicenseApplicationID = -1; int applicationID = -1; int licenseClassID = -1;

            if (clslocalDrivingAppData.FindByNationalNo(nationalityID, ref localDrivingLicenseApplicationID, ref applicationID, ref licenseClassID))
            {
                int applicantPersonID = -1; DateTime applicationDate = DateTime.Now; int applicationTypeID = -1;
                byte applicationStatus = 1; DateTime lastStatusDate = DateTime.Now; float paidFees = 0; int createdByUserID = -1;

                if (clsApplicationData.GetApplicationInfoByID(applicationID, ref applicantPersonID, ref applicationDate, ref applicationTypeID, ref applicationStatus, ref lastStatusDate, ref paidFees, ref createdByUserID))
                    return new clslocalDrivingApp(localDrivingLicenseApplicationID,licenseClassID, applicationID, applicantPersonID, applicationDate, applicationTypeID, (enApplicationStatus)applicationStatus, lastStatusDate, paidFees, createdByUserID);
                else
                    return null;
            }
            else
                return null;
        }
        public static clslocalDrivingApp FindByPersonID(int personID)
        {
            int localDrivingLicenseApplicationID = -1; int applicationID = -1; int licenseClassID = -1;

            if (clslocalDrivingAppData.FindByPersonID(personID, ref localDrivingLicenseApplicationID, ref applicationID, ref licenseClassID))
            {
                int applicantPersonID = -1; DateTime applicationDate = DateTime.Now; int applicationTypeID = -1;
                byte applicationStatus = 1; DateTime lastStatusDate = DateTime.Now; float paidFees = 0; int createdByUserID = -1;

                if (clsApplicationData.GetApplicationInfoByID(applicationID, ref applicantPersonID, ref applicationDate, ref applicationTypeID, ref applicationStatus, ref lastStatusDate, ref paidFees, ref createdByUserID))
                    return new clslocalDrivingApp(localDrivingLicenseApplicationID, licenseClassID, applicationID, applicantPersonID, applicationDate, applicationTypeID, (enApplicationStatus)applicationStatus, lastStatusDate, paidFees, createdByUserID);
                else
                    return null;
            }
            else
                return null;
        }
        protected bool _AddNewLocalDrivingApp()
        {
            this.LocalDrivingAppID=DVLD_DataAccess.clslocalDrivingAppData.AddNewLocalDrivingAppData(this.ApplicationID,this.LicenseClassID);
            return (this.LocalDrivingAppID != -1);
        }
        protected bool _UpdateLocalDrivingApplication()
        {
            if (clsApplicationData.UpdateApplication(this.ApplicationID, this.ApplicantPersonID, this.ApplicationDate,
                (int) this.ApplicationTypeID, (byte)this.ApplicationStatus, this.LastStatusDate, this.PaidFees, this.CreatedByUserID))
                return clslocalDrivingAppData.UpdateLocalDrivingApp(this.LocalDrivingAppID, this.ApplicationID, this.LicenseClassID);
            else
                return false;
        }
        public new bool Save()
        {
            base.mode =(clsApplication.enMode) this.mode;
            int ActiveApp = GetActiveApplicationIDForLicenseClass(this.ApplicationTypeID, this.LicenseClassID);
            if (ActiveApp != -1)             //there is no active Application
                return false;

            if (!base.Save())
                return false;
            switch (mode)
            {
                case enMode.enAddNew:
                    if (_AddNewLocalDrivingApp())
                    {
                        mode = enMode.enUpdate;
                        return true;
                    }
                    else
                        return false;
                case enMode.enUpdate:
                    return _UpdateLocalDrivingApplication();
            }
            return false;
        }
        /* HasActiveApplicationForClass
         * public static bool HasActiveApplicationForClass(int PersonID,int LicenseClassID,out int ActiveAppID)
        {
            ActiveAppID = -1;
            return (DVLD_DataAccess.clslocalDrivingAppData.GetActiveApplicationID(PersonID, LicenseClassID, ref ActiveAppID));
        }*/
        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            return clslocalDrivingAppData.GetAllLocalDrivingApplications();
        }
        public static bool Delete(int LocalDrivingAppID)
        {
            clslocalDrivingApp localDrivingInfo=clslocalDrivingApp.Find(LocalDrivingAppID);
            if (clslocalDrivingAppData.DeleteLocalDrivingApp(LocalDrivingAppID))
                if (clsApplication.DeleteApplication(localDrivingInfo.ApplicationID))
                    return true;
            return false;
        }
        public bool Delete()
        {
            if (clslocalDrivingAppData.DeleteLocalDrivingApp(this.LocalDrivingAppID))
                if (clsApplication.DeleteApplication(this.ApplicationID))
                    return true;
            return false;
        }
        public static bool DoesPassTestType(int localDrivingAppID, clsTestType.enTestType testTypeID)
        {
            return DVLD_DataAccess.clslocalDrivingAppData.DoesPassTestType(localDrivingAppID,(short) testTypeID);
        }
        public bool DoesPassTestType(clsTestType.enTestType testTypeID)
        {
            return DoesPassTestType(this.LocalDrivingAppID, testTypeID);
        }
        public static bool DoesPassPreviousTestType(int localDrivingAppID, clsTestType.enTestType testTypeID)
        {
            switch (testTypeID) {
                case enTestType.VisionTest:
                    return true;
                case enTestType.WrittenTest:
                    return DoesPassTestType(localDrivingAppID,testTypeID);
                case enTestType.StreetTest:
                    return DoesPassTestType(localDrivingAppID, testTypeID);
                default:
                    return false;
            }
        }
        public bool DoesPassPreviousTestType(clsTestType.enTestType testTypeID)
        {
            return DoesPassPreviousTestType(this.LocalDrivingAppID, testTypeID);
        }
        public static short TotalTrialsPerTest(int LocalDrivingAppID,clsTestType.enTestType testTypeID)
        {
            return DVLD_DataAccess.clslocalDrivingAppData.TotalTrialsPerTest(LocalDrivingAppID,(short)testTypeID);
        }
        public short TotalTrialsPerTest(clsTestType.enTestType testTypeID)
        {
            return TotalTrialsPerTest(this.LocalDrivingAppID, testTypeID);
        }
        public static bool DoesAttendTestType(int localDrivingID, enTestType testType)
        {
            return DVLD_DataAccess.clslocalDrivingAppData.DoesAttendTestType(localDrivingID, (short)testType);
        }
        public bool DoesAttendTestType(enTestType testType)
        {
            return DoesAttendTestType(this.LocalDrivingAppID, testType);
        }
        public static bool isThereAnActiveScheduledTest(int localDrivingID, enTestType testType)
        {
            return DVLD_DataAccess.clslocalDrivingAppData.isThereAnActiveScheduledTest(localDrivingID, (short)testType);
        }
        public bool isThereAnActiveScheduledTest(enTestType testType)
        {
            return isThereAnActiveScheduledTest(this.LocalDrivingAppID, testType);
        }
        public clsTest getLastTestByTestType(enTestType testType)
        {
            return clsTest.FindLastTestByPersonAndLicenseClass(this.ApplicantPersonID,this.LicenseClassID,testType);
        }
        public static short GetPassedTestCount(int localDrivingAppID)
        {
            return clsTest.GetPassedTestCount(localDrivingAppID);
        }
        public short GetPassedTestCount()
        {
            return GetPassedTestCount(this.LocalDrivingAppID);
        }
        public static bool PassedAllTests(int localDrivingAppID)
        {
            return (clsTestData.GetPassedTestCount(localDrivingAppID) == 3);
        }
        public bool PassedAllTests()
        {
            return (clsTestData.GetPassedTestCount(this.LocalDrivingAppID) == 3);
        }
        public static int CalculateAge(DateTime birthDate)
        {
            int age = DateTime.Today.Year - birthDate.Year;

            if (birthDate.Date > DateTime.Today.AddYears(-age))
                age--;

            return age;
        }
        public int IssueLicenseForTheFirstTime(string notes, int createdByUserID)
        {
            if (clsLicenseClass.Find(LicenseClassID).MinimumAllowedAge > CalculateAge(ApplicantPersonInfo.DateOfBirth)) //belki driver olur 18 yas altı!!!
                return -1;


            clsDriver Driver = clsDriver.FindByPersonID(ApplicantPersonID);
            if (Driver == null) { 
                Driver = new clsDriver();
                Driver.PersonID = this.ApplicantPersonID;
                Driver.CreatedByUserID= createdByUserID;
                if (!Driver.Save())
                    return -1;
                Driver.PersonInfo = clsPerson.GetPersonInfoByPersonID(this.ApplicantPersonID);
            }
            clsLicense license=new clsLicense();
            license.ApplicationID = this.ApplicationID;
            license.DriverID=Driver.DriverID;
            license.LicenseClass = this.LicenseClassID;
            license.LicenseClassInfo = clsLicenseClass.Find(LicenseClassID);
            license.IssueDate= DateTime.Now;
            license.ExpirationDate = DateTime.Now.AddYears(license.LicenseClassInfo.DefaultValidityLength);
            license.Notes= notes;
            license.PaidFees = license.LicenseClassInfo.ClassFees;
            license.isActive= true;
            license.IssueReason = clsLicense.enIssueReason.FirstTime;
            license.CreatedByUserID= createdByUserID;

            if (license.Save()) {
                base.CompleteApplication(this.ApplicationID);
                return license.LicenseID;
            }
            else 
                return -1;
        }   
        public bool IsLicenseIssued()
        {
            return (GetActiveLicenseID()!= -1);
        }
        public int GetActiveLicenseID()
        {
            return DVLD_Business.clsLicense.GetActiveLicenseIDByPersonID(this.ApplicantPersonID, this.LicenseClassID);
        }
    }
}
