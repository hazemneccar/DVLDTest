using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsTestType
    {
        public enum enTestType
        {
            VisionTest=1,WrittenTest=2,StreetTest=3
        }
        public enTestType TestTypeID { get; set; }
        public string TestTypeTitle { get; set; }
        public string TestTypeDescription { get; set; }
        public float TestTypeFees { get; set; }
        private clsTestType(enTestType testTypeID, string testTypeTitle, 
            string testTypeDescription, float testTypeFees) {
            this.TestTypeID = testTypeID;
            this.TestTypeTitle= testTypeTitle;
            this.TestTypeDescription= testTypeDescription;
            this.TestTypeFees = testTypeFees;
        }

        public static clsTestType Find(enTestType testTypeID)
        {
            string testTypeTitle = "", testTypeDescription = "";
            float testTypeFees = 0;

            if (DVLD_DataAccess.clsTestTypeData.GetTestTypeInfoByID((int)testTypeID, ref testTypeTitle, ref testTypeDescription, ref testTypeFees))
                return new clsTestType((enTestType)testTypeID, testTypeTitle, testTypeDescription, testTypeFees);
            else
                return null;
        }
        public static DataTable GetAllTestTypes()
        {
            return DVLD_DataAccess.clsTestTypeData.GetAllTestTypes();
        }
        public bool UpdateTestType()
        {
            return DVLD_DataAccess.clsTestTypeData.UpdateTestType((int)this.TestTypeID, this.TestTypeTitle, this.TestTypeDescription, this.TestTypeFees);
        }
    }
}
