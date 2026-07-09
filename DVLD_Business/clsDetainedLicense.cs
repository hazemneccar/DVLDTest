using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using static DVLD_Business.clsApplication;

namespace DVLD_Business
{
    public class clsDetainedLicense
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode mode = enMode.AddNew;
        public int DetainID { get; set; }
        public int LicenseID { get; set; }
        public DateTime DetainDate { get; set; }
        public float FineFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsReleased { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int ReleasedByUserID { get; set; }
        public int ReleaseApplicationID { get; set; }
        public clsDetainedLicense()
        {
            this.DetainID=-1; 
            this.LicenseID=-1;
            this.DetainDate=DateTime.Now;
            this.FineFees = 0;
            this.CreatedByUserID = -1;
            this.IsReleased= false;
            this.ReleaseDate = DateTime.Now;
            this.ReleasedByUserID = -1;
            this.ReleaseApplicationID = -1;
        }
        public clsDetainedLicense(int detainID, int licenseID, DateTime detainDate, float fineFees,
            int createdByUserID,bool isReleased,DateTime releaseDate,int releaseByUserID,int releaseApplicationID)
        {
            this.DetainID = detainID;
            this.LicenseID = licenseID;
            this.DetainDate = detainDate;
            this.FineFees = fineFees;
            this.CreatedByUserID = createdByUserID;
            this.IsReleased = isReleased;
            this.ReleaseDate = releaseDate;
            this.ReleasedByUserID = releaseByUserID;
            this.ReleaseApplicationID = releaseApplicationID;
        }

        public static clsDetainedLicense Find(int detainID)
        {
            int licenseID = -1, createdByUserID = -1, releasedByUserID = -1, releaseApplicationID = -1;
            DateTime detainDate = System.DateTime.Now, releaseDate = DateTime.Now;
            float fineFees = 0;
            bool isReleased = false;

            if (clsDetainedLicenseData.GetDetainedLicenseInfoByID(detainID, ref licenseID, ref detainDate,
             ref fineFees, ref createdByUserID, ref isReleased, ref releaseDate, ref releasedByUserID, ref releaseApplicationID))
                return new clsDetainedLicense(detainID, licenseID, detainDate, fineFees, createdByUserID,
                 isReleased, releaseDate, releasedByUserID, releaseApplicationID);

            return null;
        }
        public static clsDetainedLicense FindByLicenseID(int licenseID)
        {
            int detainID = -1; int createdByUserID = -1; int releasedByUserID = -1; int releaseApplicationID = -1;
            DateTime detainDate = DateTime.Now; DateTime releaseDate = DateTime.MaxValue;
            float fineFees = 0;
            bool isReleased = false;

            if (clsDetainedLicenseData.GetDetainedLicenseInfoByLicenseID(licenseID, ref detainID, ref detainDate,
                ref fineFees, ref createdByUserID, ref isReleased, ref releaseDate, ref releasedByUserID, ref releaseApplicationID))
                return new clsDetainedLicense(detainID, licenseID, detainDate, fineFees, createdByUserID,
                    isReleased, releaseDate, releasedByUserID, releaseApplicationID);

            return null;
        }

        protected bool _AddNewDetainedLicense()
        {
            this.DetainID = clsDetainedLicenseData.AddNewDetainedLicense(this.LicenseID, 
                this.DetainDate, this.FineFees, this.CreatedByUserID, this.IsReleased,
                this.ReleaseDate, this.ReleasedByUserID, this.ReleaseApplicationID);
            return (this.DetainID != -1);
        }

        protected bool _UpdateDetainedLicense()
        {
            return clsDetainedLicenseData.UpdateDetainedLicense(this.DetainID, this.LicenseID,
                this.DetainDate, this.FineFees, this.CreatedByUserID, this.IsReleased,
                this.ReleaseDate, this.ReleasedByUserID, this.ReleaseApplicationID);
        }
        public bool Save()
        {
            switch (mode)
            {
                case enMode.AddNew:
                    if (_AddNewDetainedLicense())
                    {
                        mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _UpdateDetainedLicense();
            }

            return false;
        }
        public static DataTable GetAllDetainedLicenses()
        {
            return clsDetainedLicenseData.GetAllDetainedLicenses();
        }
        public static int GetDetainedLicenseIDByLicenseID(int LicenseID)
        {
            return DVLD_DataAccess.clsDetainedLicenseData.GetDetainedLicenseAppID(LicenseID);
        }
        public bool IsLicenseActive()
        {
            return clsLicense.Find(LicenseID).isActive;
        }
        public bool IsLicenseDetained()
        {
            return DVLD_DataAccess.clsDetainedLicenseData.IsLicenseDetained(this.LicenseID);
        }
        public static bool IsLicenseDetained(int licenseID)
        {
            return DVLD_DataAccess.clsDetainedLicenseData.IsLicenseDetained(licenseID);
        }
        public static int DetainLicense(int licenseID, float fineFees, int createdByUserID)
        {
            return clsLicense.DetainLicense(licenseID, fineFees, createdByUserID);
        }
        public static bool ReleaseLicense(int licenseID, int ReleasedByUserID, ref int ApplicationID)
        {
            return clsLicense.ReleaseLicense(licenseID,ReleasedByUserID,ref ApplicationID);
        }
    }
}
