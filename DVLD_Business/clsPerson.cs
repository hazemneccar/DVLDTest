using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsPerson
    {
        public enum enMode {enAddNew=0,enUpdate=1}
        public enMode mode=enMode.enAddNew;
        public string NationalID { get; set; }

        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get { 
                return (this.FirstName + " " + this.SecondName + " " + this.ThirdName + " " + this.LastName);}
        }
        public DateTime DateOfBirth { get; set; }
        public enum enGender
        {
            enMale = 0, enFemale = 1
        }
        public enGender Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int NationalityCountryID { get; set; }
        public clsCountry CountryInfo { get; set; }
        public string ImagePath { get; set; }


        clsPerson(int personID, string nationalID, string firstName, string secondName,
            string thirdName,string lastName, DateTime dateOfBirth, enGender gender, string address,
            string phone, string email, int nationalityCountryID, string imagePath)
        {
            this.PersonID = personID;
            this.NationalityCountryID = -1;
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.ThirdName = thirdName;
            this.LastName = lastName;
            this.DateOfBirth = dateOfBirth;
            this.Gender = gender;
            this.Address = address;
            this.Phone = phone;
            this.Email = email;
            this.NationalityCountryID = nationalityCountryID;
            this.CountryInfo = clsCountry.Find(nationalityCountryID);
            this.NationalID = nationalID;
            this.ImagePath = imagePath;
            mode=enMode.enUpdate;
        }

        public clsPerson()
        {
            this.PersonID = -1;
            this.NationalID = "";
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.DateOfBirth = DateTime.Now;
            this.Gender = enGender.enMale;
            this.Address = "";
            this.Phone = "";
            this.Email = "";
            this.NationalityCountryID = -1;
            this.ImagePath = "";
            mode = enMode.enAddNew;
        }

        protected bool _AddNewPerson()
        {
            this.PersonID=DVLD_DataAccess.clsPersonData.AddPerson(this.NationalID,this.FirstName, this.SecondName,
                this.ThirdName, this.LastName,this.DateOfBirth, (byte)this.Gender, this.Address, this.Phone, this.Email,
                this.NationalityCountryID,this.ImagePath);
            return (this.PersonID != -1);
        }
        protected bool _UpdatePerson()
        {
            return DVLD_DataAccess.clsPersonData.UpdatePerson(this.PersonID,this.NationalID, this.FirstName, this.SecondName,
                this.ThirdName, this.LastName, this.DateOfBirth, (byte)this.Gender, this.Address, this.Phone, this.Email,
                this.NationalityCountryID, this.ImagePath);
        }
        public static bool DeletePerson(int PersonID)
        {
            return DVLD_DataAccess.clsPersonData.DeletePerson(PersonID);
        }
        public static DataTable GetAllPersons()
        {
            return DVLD_DataAccess.clsPersonData.GetAllPersons();
        }
        public bool Save()
        {
            switch (mode)
            {
                case enMode.enAddNew:
                    if (_AddNewPerson()) {
                        mode=enMode.enUpdate;
                        return true;
                    }
                    else
                        return false;

                case enMode.enUpdate:
                    return _UpdatePerson();
                default:
                    break;

            }
            return false;
        }
        public static clsPerson Find(int PersonID)
        {
            string firstName = "", nationalID="", secondName = "", thirdName = "", lastName = "";
            string address = "", phone = "", email = "", imagePath = "";
            DateTime dateOfBirth = DateTime.Now;
            int nationalityCountryID = -1;
            byte gender = 0;
            if (DVLD_DataAccess.clsPersonData.GetPersonByPersonID(PersonID, ref nationalID,
                ref firstName, ref secondName, ref thirdName, ref lastName,
                ref dateOfBirth, ref gender, ref address, ref phone, ref email,
                ref nationalityCountryID, ref imagePath))
            {
                return new clsPerson(
                    PersonID,nationalID, firstName, secondName, thirdName, lastName,
                    dateOfBirth, (enGender)gender, address, phone, email,
                    nationalityCountryID, imagePath
                );
            }
            else
                return null;
        }

        public static clsPerson Find(string NationalID)
        {
            string firstName = "", secondName = "", thirdName = "", lastName = "";
            string address = "", phone = "", email = "", imagePath = "";
            DateTime dateOfBirth = DateTime.Now;
            int nationalityCountryID = -1, PersonID=-1;
            byte gender = 0;
            if (DVLD_DataAccess.clsPersonData.GetPersonByNationalNo(ref PersonID, NationalID,
                ref firstName, ref secondName, ref thirdName, ref lastName,
                ref dateOfBirth, ref gender, ref address, ref phone, ref email,
                ref nationalityCountryID, ref imagePath))
            {
                return new clsPerson(
                    PersonID, NationalID, firstName, secondName, thirdName, lastName,
                    dateOfBirth, (enGender)gender, address, phone, email,
                    nationalityCountryID, imagePath
                );
            }
            else
                return null;
        }

        public static bool IsPersonExist(int PersonID)
        {
            return DVLD_DataAccess.clsPersonData.IsPersonExist(PersonID);
        }

        public static bool IsPersonExist(string NationalNo)
        {
            return DVLD_DataAccess.clsPersonData.IsPersonExist(NationalNo);
        }
    }
}
