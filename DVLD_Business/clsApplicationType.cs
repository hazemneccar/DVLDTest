using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsApplicationType
    {
        public clsApplication.enApplicationTypes ApplicationID { get; set; }
        public string ApplicationTitle { get; set; }
        public float ApplicationFees { get; set; }
        clsApplicationType(clsApplication.enApplicationTypes applicationID, string applicationTitle, float applicationFees)
        {
            this.ApplicationID = applicationID;
            this.ApplicationTitle = applicationTitle;
            this.ApplicationFees = applicationFees;

        }
        public static clsApplicationType Find(clsApplication.enApplicationTypes applicationTypeID)
        {
            string applicationTypeTitle = "";
            float applicationFees = 0;

            if (DVLD_DataAccess.clsApplicationTypeData.GetAppTypeInfoByID((int)applicationTypeID,
                ref applicationTypeTitle, ref applicationFees))
                return new clsApplicationType(applicationTypeID, applicationTypeTitle, applicationFees);
            else
                return null;
        }
        public bool UpdateAppTypeInfo()
        {
            return DVLD_DataAccess.clsApplicationTypeData.UpdateAppTypeInfo((int)this.ApplicationID, this.ApplicationTitle, this.ApplicationFees);
        }
        public static DataTable GetAllApplicationTypes()
        {
            return DVLD_DataAccess.clsApplicationTypeData.GetAllApplicationTypes();
        }
    }
}
