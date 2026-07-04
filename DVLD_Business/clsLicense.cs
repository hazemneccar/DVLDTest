using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static DVLD_Business.clsApplication;

namespace DVLD_Business
{
    public class clsLicense
    {
        public enum enMode
        {
            AddNew = 0, Update = 1
        }
        public enum enIssueReason
        {
            FirstTime=1,Renew=2,ReplacementForDamaged=3,ReplacementForLost=4
        }
        public enMode mode { get; set; }
        public int LicenseID { get; set; }
        public int ApplicationID { get; set; }
        public clsApplication ApplicationInfo { get; set; }
        public int DriverID { get; set; }
        public clsDriver DriverInfo { get; set; }
        public int LicenseClass { get; set; }
        public clsLicenseClass LicenseClassInfo { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public float PaidFees { get; set; }
        public bool isActive { get; set; }
        public enIssueReason IssueReason { get; set; }
        public string IssueReasonText
        {
            get { return _GetIssueReasonText(this.IssueReason); }
        }
        public static string _GetIssueReasonText(enIssueReason issueReason)
        {
            switch (issueReason) {
                case enIssueReason.FirstTime:
                    return "First Time";
                case enIssueReason.Renew:
                    return "Renew";
                case enIssueReason.ReplacementForDamaged:
                    return "Replacement For Damaged";
                case enIssueReason.ReplacementForLost:
                    return "Replacement For Lost";
                default:
                    return "Unknown";

            }
        }
        public int CreatedByUserID { get; set; }
        public clsLicense()
        {
            this.mode = enMode.AddNew;
            this.LicenseID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.LicenseClass = -1;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;
            this.Notes = "";
            this.PaidFees = 0.0f;
            this.isActive = false;
            this.IssueReason = enIssueReason.FirstTime;
            this.CreatedByUserID = -1;
        }
        private clsLicense(int licenseID, int applicationID, int driverID, int licenseClass,
            DateTime issueDate, DateTime expirationDate, string notes, float paidFees,
            bool isActive, enIssueReason issueReason, int createdByUserID)
        {
            this.mode = enMode.Update;
            this.LicenseID = licenseID;
            this.DriverID = driverID;
            this.LicenseClass = licenseClass;
            this.IssueDate = issueDate;
            this.ExpirationDate = expirationDate;
            this.Notes = notes;
            this.PaidFees = paidFees;
            this.isActive = isActive;
            this.IssueReason = issueReason;
            this.CreatedByUserID = createdByUserID;

            this.DriverInfo = clsDriver.Find(driverID);
            this.LicenseClassInfo=clsLicenseClass.Find(licenseClass);
        }

        public static clsLicense Find(int licenseID)
        {
            int applicationID = -1, driverID = -1, licenseClass = -1, createdByUserID = -1;
            DateTime issueDate = DateTime.Now, expirationDate = DateTime.Now;
            string notes = ""; float paidFees = 0.0f; bool isActive = false; byte issueReason = 1;

            if (clsLicenseData.GetLicenseInfoByID(licenseID, ref applicationID, ref driverID, ref licenseClass, ref issueDate, ref expirationDate, ref notes, ref paidFees, ref isActive, ref issueReason, ref createdByUserID))
                return new clsLicense(licenseID, applicationID, driverID, licenseClass, issueDate, expirationDate, notes, paidFees, isActive, (enIssueReason)issueReason, createdByUserID);

            return null;
        }
        public static clsLicense FindByPersonID(int personID,int licenseClass)
        {
            int licenseID = -1, applicationID = -1, driverID = -1, createdByUserID = -1;
            DateTime issueDate = DateTime.Now, expirationDate = DateTime.Now;
            string notes = ""; float paidFees = 0.0f; bool isActive = false; byte issueReason = 1;

            if (clsLicenseData.GetLicenseInfoByPersonID(personID, licenseClass, ref licenseID, ref applicationID, ref driverID, ref licenseClass, ref issueDate, ref expirationDate, ref notes, ref paidFees, ref isActive, ref issueReason, ref createdByUserID))
                return new clsLicense(licenseID, applicationID, driverID, licenseClass, issueDate, expirationDate, notes, paidFees, isActive, (enIssueReason)issueReason, createdByUserID);

            return null;
        }
        protected bool _AddNewLicense()
        {
            this.LicenseID = clsLicenseData.AddNewLicense(this.ApplicationID, this.DriverID, this.LicenseClass, this.IssueDate, this.ExpirationDate, this.Notes, this.PaidFees, this.isActive, (byte)this.IssueReason, this.CreatedByUserID);
            return (this.LicenseID != -1);
        }
        protected bool _UpdateLicense()
        {
            return clsLicenseData.UpdateLicense(this.LicenseID, this.ApplicationID, this.DriverID, this.LicenseClass, this.IssueDate, this.ExpirationDate, this.Notes, this.PaidFees, this.isActive, (byte)this.IssueReason, this.CreatedByUserID);
        }
        public bool Save()
        {
            switch (mode)
            {
                case enMode.AddNew:
                    if (_AddNewLicense())
                    {
                        mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _UpdateLicense();
            }

            return false;
        }
        public static bool DeleteLicense(int licenseID)
        {
            return clsLicenseData.DeleteLicense(licenseID);
        }
        public static DataTable GetAllLicenses()
        {
            return DVLD_DataAccess.clsLicenseData.GetAllLicenses();
        }
        public static DataTable GetDriverLicenses(int DriverID)
        {
            return DVLD_DataAccess.clsLicenseData.GetDriverLicenses(DriverID);
        }
        public static bool isLicenseExistByPersonID(int personID, int licenseClass)
        {
            return (GetActiveLicenseIDByPersonID(personID, licenseClass) != -1);
        }
        public static bool isLicenseExpired(int licenseID)
        {
            return clsLicense.Find(licenseID).ExpirationDate < DateTime.Now;
        }
        public bool isLicenseExpired()
        {
            return this.ExpirationDate < DateTime.Now;
        }
        public static int GetActiveLicenseIDByPersonID(int personID, int licenseClass)
        {
            return DVLD_DataAccess.clsLicenseData.GetActiveLicenseIDByPersonID(personID, licenseClass); 
        }
        public bool DeactivateLicense()
        {
            return DeactivateLicense(this.LicenseID);
        }
        public static bool DeactivateLicense(int LicenseID)
        {
            return DVLD_DataAccess.clsLicenseData.DeactivateLicense(LicenseID);
        }

        public clsLicense Renew(int CreatedByUserID,string notes)
        {
            
            clsLicense OldLicense=this;
            if (clslocalDrivingApp.CalculateAge(OldLicense.ApplicationInfo.ApplicantPersonInfo.DateOfBirth)<
                OldLicense.LicenseClassInfo.MinimumAllowedAge)
            {
                return null;
            }
            if (OldLicense.ExpirationDate<DateTime.Now)
            {
                clsApplication RenewApplication = new clsApplication();
                RenewApplication.ApplicantPersonID = OldLicense.DriverInfo.PersonID;
                RenewApplication.ApplicationTypeID=enApplicationTypes.RenewDrivingLicense;
                RenewApplication.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
                RenewApplication.PaidFees = clsApplicationType.Find(enApplicationTypes.RenewDrivingLicense).ApplicationFees;
                RenewApplication.CreatedByUserID = CreatedByUserID;
                if (!RenewApplication.Save())
                {
                    return null;
                }

                clsLicense Newlicense = new clsLicense();
                Newlicense.ApplicationID = RenewApplication.ApplicationID;
                Newlicense.DriverID = OldLicense.DriverID;
                Newlicense.LicenseClass = OldLicense.LicenseClass;
                Newlicense.IssueDate = DateTime.Today;
                Newlicense.ExpirationDate = DateTime.Now.AddYears(OldLicense.LicenseClassInfo.DefaultValidityLength);
                Newlicense.Notes = notes;
                Newlicense.PaidFees = OldLicense.LicenseClassInfo.ClassFees;
                Newlicense.isActive=true;
                Newlicense.IssueDate = DateTime.Today;
                Newlicense.IssueReason = enIssueReason.Renew;
                if (!Newlicense.Save())
                {
                    return null;
                }
                DeactivateLicense(OldLicense.LicenseID);
                return Newlicense;
            }
            return null;
        }
        public clsLicense Replace(enIssueReason issueReason,int CreatedByUserID, string notes)
        {
            if (this.isLicenseExpired())
                return null;

            clsLicense oldLicense = this;
            clsApplication ReplaceApplication= new clsApplication();
            ReplaceApplication.ApplicantPersonID = oldLicense.DriverInfo.PersonID;
            ReplaceApplication.ApplicationDate = DateTime.Now;
           /*
            * ReplaceApplication.ApplicationTypeID = (issueReason == enIssueReason.ReplacementForDamaged) ?
                ReplaceApplication.ApplicationTypeID = enApplicationTypes.ReplacementForDamagedDrivingLicense :
                ReplaceApplication.ApplicationTypeID = enApplicationTypes.ReplacementForLostDrivingLicense;*/
            if (issueReason == enIssueReason.ReplacementForDamaged)
                ReplaceApplication.ApplicationTypeID = enApplicationTypes.ReplacementForDamagedDrivingLicense;
            else if (issueReason == enIssueReason.ReplacementForLost)
                ReplaceApplication.ApplicationTypeID = enApplicationTypes.ReplacementForLostDrivingLicense;

            ReplaceApplication.ApplicationStatus = enApplicationStatus.Completed;
            ReplaceApplication.LastStatusDate= DateTime.Now;
            ReplaceApplication.PaidFees = clsApplicationType.Find(ReplaceApplication.ApplicationTypeID).ApplicationFees;
            ReplaceApplication.CreatedByUserID = CreatedByUserID;

            if (!ReplaceApplication.Save())
                return null;

            clsLicense NewLicense = new clsLicense();
            NewLicense.ApplicationID = ReplaceApplication.ApplicationID;
            NewLicense.DriverID = oldLicense.DriverID;
            NewLicense.LicenseClass = oldLicense.LicenseClass;
            NewLicense.IssueDate=DateTime.Now;
            NewLicense.ExpirationDate= oldLicense.ExpirationDate;
            NewLicense.Notes = notes;
            NewLicense.PaidFees = 0;
            NewLicense.isActive = true;
            NewLicense.IssueReason = issueReason;
            NewLicense.CreatedByUserID= CreatedByUserID;
                
            if (!NewLicense.Save())
                return null;

            DeactivateLicense(this.LicenseID))
            return NewLicense;
        }
        public bool AddInternationalLicense(int CreatedByUserID)
        {
            return clsInternationalLicense.AddInternationalLicense(this.LicenseID, CreatedByUserID);
        }
    }
}
