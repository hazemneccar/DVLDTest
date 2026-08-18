using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DVLD_Business.clsTestType;

namespace DVLD_Business
{
    public class clsApplication
    {
        public enum enMode { enAddNew = 0, enUpdate = 1 }
        public enMode mode = enMode.enAddNew;
        public enum enApplicationStatus
        {
            New = 1, Cancelled = 2, Completed = 3
        }
        public enum enApplicationTypes
        {
            NewLocalDrivingLicense=1,
            RenewDrivingLicense=2,
            ReplacementForLostDrivingLicense=3,
            ReplacementForDamagedDrivingLicense=4,
            ReleaseDetainedDrivingLicense=5,
            NewInternationalDrivingLicense=6,
            RetakeTest=7
        }

        public int ApplicationID { get; set; }
        public int ApplicantPersonID { get; set; }
        public clsPerson ApplicantPersonInfo { get; set; }
        public DateTime ApplicationDate { get; set; }
        public enApplicationTypes ApplicationTypeID { get; set; }
        public clsApplicationType ApplicationTypeInfo { get; set; }
        public enApplicationStatus ApplicationStatus { get; set; }
        public DateTime LastStatusDate { get; set; }
        public float PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public clsUser CreatedUserInfo { get; set; }
        public clsApplication()
        {
            ApplicationID = -1;
            ApplicantPersonID = -1;
            ApplicationDate = DateTime.Now;
            ApplicationTypeID = enApplicationTypes.NewLocalDrivingLicense;
            ApplicationStatus = enApplicationStatus.New;
            LastStatusDate = DateTime.Now;
            PaidFees = 0;
            CreatedByUserID = -1;
            mode=enMode.enAddNew;
        }
        private clsApplication(int applicationID, int applicantPersonID, DateTime applicationDate, int applicationTypeID,
            enApplicationStatus applicationStatus, DateTime lastStatusDate, float paidFees, int createdByUserID)  
        {
            this.ApplicationID = applicationID;
            this.ApplicantPersonID = applicantPersonID;
            this.ApplicantPersonInfo = clsPerson.Find(applicationID);
            this.ApplicationDate = applicationDate;
            this.ApplicationTypeID = (enApplicationTypes)applicationTypeID;
            this.ApplicationTypeInfo=clsApplicationType.Find((clsApplication.enApplicationTypes)applicationTypeID);
            this.ApplicationStatus = applicationStatus;
            this.LastStatusDate = lastStatusDate;
            this.PaidFees = paidFees;
            this.CreatedByUserID = createdByUserID;
            this.CreatedUserInfo=clsUser.Find(createdByUserID);

            mode = enMode.enUpdate;
        }
        protected bool _AddNewApplication()
        {
            this.ApplicationID = clsApplicationData.AddNewApplication(this.ApplicantPersonID, this.ApplicationDate, 
                (int)this.ApplicationTypeID, (byte)this.ApplicationStatus, this.LastStatusDate, this.PaidFees, this.CreatedByUserID);

            return (this.ApplicationID != -1);
        }
        protected bool _UpdateApplication()
        {
            return clsApplicationData.UpdateApplication(this.ApplicationID, this.ApplicantPersonID, this.ApplicationDate, 
                (int)this.ApplicationTypeID, (byte)this.ApplicationStatus, this.LastStatusDate, this.PaidFees, this.CreatedByUserID);
        }
        public bool Save()
        {
            switch (mode)
            {
                case enMode.enAddNew:
                    if (_AddNewApplication())
                    {
                        mode = enMode.enUpdate;
                        return true;
                    }
                    else
                        return false;

                case enMode.enUpdate:
                    return _UpdateApplication();

                default:
                    break;
            }

            return false;
        }
        public static clsApplication Find(int applicationID) 
        {
            int applicantPersonID = -1, applicationTypeID = -1, createdByUserID = -1;
            DateTime applicationDate = DateTime.Now, lastStatusDate = DateTime.Now;
            byte applicationStatus = 1;  
            float paidFees = 0; 

            if (clsApplicationData.GetApplicationInfoByID(applicationID, ref applicantPersonID, ref applicationDate,
                ref applicationTypeID, ref applicationStatus, ref lastStatusDate, ref paidFees, ref createdByUserID))
                return new clsApplication(applicationID, applicantPersonID, applicationDate, applicationTypeID, 
                    (enApplicationStatus)applicationStatus, lastStatusDate, paidFees, createdByUserID);
            else
                return null;
        }
        public static bool isApplicationExist(int ApplicationID)
        {
            return DVLD_DataAccess.clsApplicationData.IsApplicationExist(ApplicationID);
        }
        public static bool Delete(int AppliacationID)
        {
            return DVLD_DataAccess.clsApplicationData.DeleteApplication(AppliacationID);
        }
        public bool CancelApplication()
        {
            return CancelApplication(this.ApplicationID);
        }
        public static bool CancelApplication(int ApplicationID)
        {
            return DVLD_DataAccess.clsApplicationData.UpdateStatus(ApplicationID, (short)enApplicationStatus.Cancelled);
        }
        public bool CompleteApplication()
        {
            return CompleteApplication(this.ApplicationID);
        }
        public static bool CompleteApplication(int ApplicationID)
        {
            return DVLD_DataAccess.clsApplicationData.UpdateStatus(ApplicationID, (short)enApplicationStatus.Completed);
        }
        public static int GetActiveApplicationID(int personID, enApplicationTypes ApplicationTypeID)
        {
            return DVLD_DataAccess.clsApplicationData.GetActiveApplicationID(personID,(int) ApplicationTypeID);
        }
        public int GetActiveApplicationID(enApplicationTypes ApplicationTypeID)
        {
            return DVLD_DataAccess.clsApplicationData.GetActiveApplicationID(this.ApplicantPersonID, (int)ApplicationTypeID);
        }
        public static bool DoesPersonHaveActiveApplication(int personID, enApplicationTypes ApplicationTypeID)
        {
            return DVLD_DataAccess.clsApplicationData.DoesPersonHaveActiveApplication(personID, (int)ApplicationTypeID);
        }
        public bool DoesPersonHaveActiveApplication(enApplicationTypes ApplicationTypeID)
        {
            return DoesPersonHaveActiveApplication(this.ApplicantPersonID, ApplicationTypeID);
        }
        public static int GetActiveApplicationIDForLicenseClass(int personID, enApplicationTypes ApplicationTypeID, clsLicenseClass.enLicenseClasses licenseClassID)
        {
            return DVLD_DataAccess.clsApplicationData.GetActiveApplicationIDForLicenseClass(personID,(int) ApplicationTypeID,(int) licenseClassID);
        }
        public int GetActiveApplicationIDForLicenseClass(enApplicationTypes ApplicationTypeID, clsLicenseClass.enLicenseClasses licenseClassID)
        {
            return DVLD_DataAccess.clsApplicationData.GetActiveApplicationIDForLicenseClass(this.ApplicantPersonID, (int)ApplicationTypeID,(int) licenseClassID);
        }
        public static bool DoesPersonHaveActiveApplicationForLicenseClass(int personID, enApplicationTypes ApplicationTypeID, clsLicenseClass.enLicenseClasses licenseClassID)
        {
            return DVLD_DataAccess.clsApplicationData.DoesPersonHaveActiveApplicationForLicenseClass(personID,(int) ApplicationTypeID,(int) licenseClassID);
        }
        public bool DoesPersonHaveActiveApplicationForLicenseClass(enApplicationTypes ApplicationTypeID, clsLicenseClass.enLicenseClasses licenseClassID)
        {
            return DVLD_DataAccess.clsApplicationData.DoesPersonHaveActiveApplicationForLicenseClass(this.ApplicantPersonID, (int)ApplicationTypeID,(int) licenseClassID);
        }
        public static bool isAvailableIssueLicense(int LocalDrivingAppID)
        {
            if (clslocalDrivingApp.PassedAllTests(LocalDrivingAppID))
            {
                if (clslocalDrivingApp.Find(LocalDrivingAppID).ApplicationStatus == clsApplication.enApplicationStatus.New)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
