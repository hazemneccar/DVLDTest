using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsInternationalLicense
    {
        public enum enMode
        {
            AddNew = 0, Update = 1
        }
        public enMode mode { get; set; }
        public int InternationalLicenseID { get; set; }
        public int ApplicationID { get; set; }
        public clsApplication ApplicationInfo { get; set; }
        public int DriverID { get; set; }
        public clsDriver DriverInfo { get; set; }
        public int IssuedUsingLocalLicenseID { get; set; }
        public clslocalDrivingApp IssuedUsingLocalLicenseInfo { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; } 
        public bool isActive { get; set; }
        public int CreatedByUserID { get; set; }
        public clsInternationalLicense()
        {
            this.mode = enMode.AddNew;
            this.InternationalLicenseID = -1;
            this.ApplicationID = -1;
            this.ApplicationInfo = null;
            this.DriverID = -1;
            this.DriverInfo = null;
            this.IssuedUsingLocalLicenseID = -1;
            this.IssuedUsingLocalLicenseInfo = null;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;
            this.isActive = false;
            this.CreatedByUserID = -1;
        }
        private clsInternationalLicense(int internationalLicenseID, int applicationID, int driverID,
            int issuedUsingLocalLicenseID, DateTime issueDate, DateTime expirationDate,
            bool isActive, int createdByUserID)
        {
            this.mode = enMode.Update;
            this.InternationalLicenseID = internationalLicenseID;
            this.ApplicationID = applicationID;
            this.DriverID = driverID;
            this.IssuedUsingLocalLicenseID = issuedUsingLocalLicenseID;
            this.IssueDate = issueDate;
            this.ExpirationDate = expirationDate;
            this.isActive = isActive;
            this.CreatedByUserID = createdByUserID;

            this.ApplicationInfo = clsApplication.Find(applicationID);
            this.DriverInfo = clsDriver.Find(driverID);
            this.IssuedUsingLocalLicenseInfo = clslocalDrivingApp.Find(issuedUsingLocalLicenseID);
        }
        protected bool _AddNewInternationalLicense()
        {
            this.InternationalLicenseID = clsInternationalLicenseData.AddNewInternationalLicense(this.ApplicationID, this.DriverID, this.IssuedUsingLocalLicenseID, this.IssueDate, this.ExpirationDate, this.isActive, this.CreatedByUserID);
            return (this.InternationalLicenseID != -1);
        }

        protected bool _UpdateInternationalLicense()
        {
            return clsInternationalLicenseData.UpdateInternationalLicense(this.InternationalLicenseID, this.ApplicationID, this.DriverID, this.IssuedUsingLocalLicenseID, this.IssueDate, this.ExpirationDate, this.isActive, this.CreatedByUserID);
        }

        public bool Save()
        {
            switch (mode)
            {
                case enMode.AddNew:
                    if (_AddNewInternationalLicense())
                    {
                        mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _UpdateInternationalLicense();
            }

            return false;
        }
        public static clsInternationalLicense Find(int internationalLicenseID)
        {
            int applicationID = -1, driverID = -1, issuedUsingLocalLicenseID = -1, createdByUserID = -1;
            DateTime issueDate = DateTime.Now, expirationDate = DateTime.Now; 
            bool isActive = false;

            if (DVLD_DataAccess.clsInternationalLicenseData.GetInternationalLicenseInfoByID(internationalLicenseID, ref applicationID, ref driverID, ref issuedUsingLocalLicenseID, ref issueDate, ref expirationDate, ref isActive, ref createdByUserID))
                return new clsInternationalLicense(internationalLicenseID, applicationID, driverID, issuedUsingLocalLicenseID, issueDate, expirationDate, isActive, createdByUserID);

            return null;
        }
        public static clsInternationalLicense FindByLocalDrivingLicenseID(int issuedUsingLocalLicenseID)
        {
            int internationalLicenseID = -1, applicationID = -1, driverID = -1, createdByUserID = -1;
            DateTime issueDate = DateTime.Now, expirationDate = DateTime.Now; bool isActive = false;

            if (DVLD_DataAccess.clsInternationalLicenseData.GetInternationalLicenseInfoByLocalLicenseID(issuedUsingLocalLicenseID, ref internationalLicenseID, ref applicationID, ref driverID, ref issueDate, ref expirationDate, ref isActive, ref createdByUserID))
                return new clsInternationalLicense(internationalLicenseID, applicationID, driverID, issuedUsingLocalLicenseID, issueDate, expirationDate, isActive, createdByUserID);

            return null;
        }
        public static clsInternationalLicense FindByDriverLicenseID(int driverID)
        {
            int internationalLicenseID = -1, applicationID = -1, issuedUsingLocalLicenseID = -1, createdByUserID = -1;
            DateTime issueDate = DateTime.Now, expirationDate = DateTime.Now; bool isActive = false;

            if (DVLD_DataAccess.clsInternationalLicenseData.GetInternationalLicenseInfoByDriverID(ref issuedUsingLocalLicenseID, ref internationalLicenseID, ref applicationID, driverID, ref issueDate, ref expirationDate, ref isActive, ref createdByUserID))
                return new clsInternationalLicense(internationalLicenseID, applicationID, driverID, issuedUsingLocalLicenseID, issueDate, expirationDate, isActive, createdByUserID);

            return null;
        }
        public static DataTable GetAllInternationalLicensesByDriverID(int driverID)
        {
            return DVLD_DataAccess.clsInternationalLicenseData.GetAllInternationalLicensesByDriverID(driverID);
        }
        public static DataTable GetAllInternationalLicenses()
        {
            return DVLD_DataAccess.clsInternationalLicenseData.GetAllInternationalLicenses();
        }
        public static bool DeleteInternationalLicense(int internationalLicenseID)
        {
            return clsInternationalLicenseData.DeleteInternationalLicense(internationalLicenseID);
        }
        public static bool IsLocalLicenseClassIsSuitableToBeInternational(int LocalLicenseID)
        {
            clsLicense localLicenseInfo=clsLicense.Find(LocalLicenseID);
            return localLicenseInfo.LicenseClass==(int)clsLicenseClass.enLicenseClasses.Class3OrdinaryDrivingLicense;
        }
        public static bool IsLocalLicenseActive(int LocalLicenseID)
        {
            clsLicense localLicenseInfo = clsLicense.Find(LocalLicenseID);
            return localLicenseInfo.isActive;
        }
        public static bool IsLocalLicenseExpired(int LocalLicenseID)
        {
            return clsLicense.isLicenseExpired(LocalLicenseID);
        }
        public static bool DoesLocalLicenseHaveActiveInternationalLicense(int LocalLicenseID)
        {
            clsLicense LicenseInfo = clsLicense.Find(LocalLicenseID);

            if (LicenseInfo != null)
                return clsInternationalLicense.FindByLocalDrivingLicenseID(LocalLicenseID).isActive;
            return false;
        }
        public static int DoesDriverHaveActiveInternationalLicense(int DriverID)
        {
            return DVLD_DataAccess.clsInternationalLicenseData.GetInternationalLicenseIDByDriverID(DriverID);
        }

        public static bool AddInternationalLicense(int LocalLicenseID,int createdByUserID)
        {
            clslocalDrivingApp LocalLicenseInfo=clslocalDrivingApp.Find(LocalLicenseID);


            if (!IsLocalLicenseActive(LocalLicenseID))
                return false;
            if (IsLocalLicenseExpired(LocalLicenseID))
                return false;
            if (!IsLocalLicenseClassIsSuitableToBeInternational(LocalLicenseID))
                return false;
            if (DoesLocalLicenseHaveActiveInternationalLicense(LocalLicenseID))
                return false;

            clsApplication InternationalLicApp = new clsApplication();
            InternationalLicApp.ApplicantPersonID = LocalLicenseInfo.ApplicantPersonID;
            InternationalLicApp.ApplicationTypeID = clsApplication.enApplicationTypes.NewInternationalDrivingLicense;
            InternationalLicApp.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            InternationalLicApp.PaidFees = clsApplicationType.Find(clsApplication.enApplicationTypes.NewInternationalDrivingLicense).ApplicationFees;
            InternationalLicApp.CreatedByUserID = createdByUserID;
            if (!InternationalLicApp.Save())
                return false;

            clsInternationalLicense license = new clsInternationalLicense();
            license.ApplicationID = InternationalLicApp.ApplicationID;
            license.IssuedUsingLocalLicenseID = LocalLicenseID;
            license.IssueDate = DateTime.Now;
            license.ExpirationDate = DateTime.Now.AddYears(1);
            license.isActive = true;
            license.CreatedByUserID = createdByUserID;
            if (!license.Save())
                return false;
            return true;
            
        }
    }
}
