using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsLicenseClass
    {
        public enum enMode
        {
            AddNew = 0, Update = 1
        }
        public enum enLicenseClasses
        {
            Class1SmallMotorcycle=1,
            Class2HeavyMotorcycleLicense = 2,
            Class3OrdinaryDrivingLicense= 3,
            Class4Commercial=4,
            Class5Agricultural=5,
            Class6SmallandMediumBus=6,
            Class7TruckandHeavyVehicle=7
        }
        public enMode mode { get; set; }
        public int LicenseClassID {  get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public short MinimumAllowedAge { get; set; }
        public short DefaultValidityLength { get; set; }
        public float ClassFees { get; set; }
        public clsLicenseClass()
        {
            this.mode = enMode.AddNew;
            this.LicenseClassID = -1;
            this.ClassName = "";
            this.ClassDescription = "";
            this.MinimumAllowedAge = 0;
            this.DefaultValidityLength = 0;
            this.ClassFees = 0.0f;
        }

        private clsLicenseClass(int licenseClassID, string className, string classDescription,
            short minimumAllowedAge, short defaultValidityLength, float classFees)
        {
            this.mode = enMode.Update;
            this.LicenseClassID = licenseClassID;
            this.ClassName = className;
            this.ClassDescription = classDescription;
            this.MinimumAllowedAge = minimumAllowedAge;
            this.DefaultValidityLength = defaultValidityLength;
            this.ClassFees = classFees;
        }

        public static clsLicenseClass Find(int licenseClassID)
        {
            string className = "", classDescription = ""; short minimumAllowedAge = 0, defaultValidityLength = 0; float classFees = 0.0f;

            if (clsLicenseClassData.GetLicenseClassInfoByID(licenseClassID, ref className, ref classDescription, ref minimumAllowedAge, ref defaultValidityLength, ref classFees))
                return new clsLicenseClass(licenseClassID, className, classDescription, minimumAllowedAge, defaultValidityLength, classFees);

            return null;
        }
        public static clsLicenseClass Find(string className)
        {
            int licenseClassID = -1;
            string classDescription = ""; 
            short minimumAllowedAge = 0, defaultValidityLength = 0; 
            float classFees = 0.0f;

            if (clsLicenseClassData.GetLicenseClassName(ref licenseClassID, className, ref classDescription, ref minimumAllowedAge, ref defaultValidityLength, ref classFees))
                return new clsLicenseClass(licenseClassID, className, classDescription, minimumAllowedAge, defaultValidityLength, classFees);

            return null;
        }
    }
}
