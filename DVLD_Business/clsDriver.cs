using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsDriver
    {
        public enum enMode
        {
            AddNew=0,Update=1
        }
        public enMode mode {  get; set; }
        public int DriverID { get; set; }
        public int PersonID { get; set; }
        public clsPerson PersonInfo { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedDate { get; set; }
        public clsDriver ()
        {
            DriverID = -1;
            PersonID = -1;
            CreatedByUserID = -1;
            CreatedDate = DateTime.Today;
        }
        private clsDriver(int driverID, int personID, int createdByUserID, DateTime createdDate)
        {
            DriverID = driverID;
            PersonID = personID;
            clsPerson.Find(personID);
            CreatedByUserID = createdByUserID;
            CreatedDate = createdDate;
        }
        public static clsDriver Find(int driverID)
        {
            int personID = -1, createdByUserID = -1; DateTime createdDate = DateTime.Now;

            if (clsDriverData.GetDriverInfoByID(driverID, ref personID, ref createdByUserID, ref createdDate))
                return new clsDriver(driverID, personID, createdByUserID, createdDate);

            return null;
        }
        public static clsDriver FindByPersonID(int personID)
        {
            int driverID = -1, createdByUserID = -1; DateTime createdDate = DateTime.Now;

            if (clsDriverData.GetDriverInfoByPersonID(personID, ref driverID, ref createdByUserID, ref createdDate))
                return new clsDriver(driverID, personID, createdByUserID, createdDate);

            return null;
        }
        protected bool _AddNewDriver()
        {
            this.DriverID = clsDriverData.AddNewDriver(this.PersonID, this.CreatedByUserID, this.CreatedDate);
            return (this.DriverID != -1);
        }
        protected bool _UpdateDriver()
        {
            return clsDriverData.UpdateDriver(this.DriverID, this.PersonID, this.CreatedByUserID, this.CreatedDate);
        }
        public bool Save()
        {
            switch (mode)
            {
                case enMode.AddNew:
                    if (_AddNewDriver())
                    {
                        mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _UpdateDriver();
            }

            return false;
        }
        public static bool DeleteDriver(int DriverID)
        {
            return DVLD_DataAccess.clsDriverData.DeleteDriver(DriverID);
        }
        public static DataTable GetAllDrivers()
        {
            return DVLD_DataAccess.clsDriverData.GetAllDrivers();
        }
        public static DataTable GetDriverLicenses(int DriverID)
        {
            return DVLD_Business.clsLicense.GetDriverLicenses(DriverID);
        }
        public DataTable GetAllLicenses()
        {
            return GetDriverLicenses(this.DriverID);
        }
    }
}
