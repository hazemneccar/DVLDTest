using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsCountry
    {
        public int ID { get; set; }
        public string CountryName { get; set; }
        public clsCountry() {
            ID = -1;
            CountryName = "";
        }
        private clsCountry(int iD, string countryName)
        {
            this.ID = iD;
            this.CountryName = countryName;
        }

        public static clsCountry Find(int iD)
        {
            string countryName = "";
            if (DVLD_DataAccess.clsCountryData.GetCountryInfoByID(iD, ref countryName))
                return new clsCountry(iD, countryName);
            else
                return null;
        }

        public static clsCountry Find(string countryName)
        {
            int iD = -1;
            if (DVLD_DataAccess.clsCountryData.GetCountryInfoByCountryName(ref iD, countryName))
                return new clsCountry(iD, countryName);
            else
                return null;
        }

        public static DataTable GetAllCounties()
        {
            return DVLD_DataAccess.clsCountryData.GetAllCountries();
        }


    }
}
