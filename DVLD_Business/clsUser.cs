using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsUser
    {
        public int UserID;

        public int PersonID;
        public clsPerson PersonInfo;

        public string UserName { get; set; }
        public string Password { get; set; }
        public bool isActive { get; set; }

        public enum enMode { enAddNew=0,enUpdate=1}
        public enMode mode = enMode.enAddNew;

        private clsUser(int userID,int PersonID,string UserName,string Password,bool isActive) {
            this.UserID = userID;
            this.PersonID = PersonID;
            this.PersonInfo = clsPerson.Find(PersonID);
            this.UserName = UserName;
            this.Password = Password;
            this.isActive = isActive;
            mode = enMode.enUpdate;
        }
        public clsUser()
        {
            this.PersonID = -1;
            this.PersonInfo =null;
            this.UserName = "";
            this.Password = "";
            this.isActive = false;
            mode = enMode.enAddNew;
        }
        public static clsUser Find(int userID)
        {
            string userName = "", password = "";
            int personID = -1;
            bool isActive = false;

            if (DVLD_DataAccess.clsUserData.GetUserInfoByUserID(userID,
                ref personID, ref userName, ref password, ref isActive))
            {
                return new clsUser(userID, personID, userName, password, isActive);
            }
            else        
                return null;
        }
        public static clsUser FindByUsername(string userName)
        {
            string password = "";
            int personID = -1,userID=-1;
            bool isActive = false;

            if (DVLD_DataAccess.clsUserData.GetUserInfoByUsername(ref userID,
                ref personID, userName, ref password, ref isActive))
            {
                return new clsUser(userID, personID, userName, password, isActive);
            }
            else
                return null;
        }
        public static clsUser FindByPersonID(int personID)
        {
            string userName = "", password = "";
            int userID = -1;
            bool isActive = false;

            // DataAccess fonksiyonu ref parametreleriyle çağrılıyor
            if (DVLD_DataAccess.clsUserData.GetUserInfoByPersonID(personID,
                ref userID, ref userName, ref password, ref isActive))
            {
                // Kayıt bulunduysa, verilerle doldurulmuş yeni clsUser nesnesi döndürülüyor
                return new clsUser(userID, personID, userName, password, isActive);
            }
            else
            {
                return null;
            }
        }
        public static bool isUserExist(int userID)
        {
            return DVLD_DataAccess.clsUserData.IsUserExist(userID);
        }
        public static bool isUserExist(string username)
        {
            return DVLD_DataAccess.clsUserData.IsUserExist(username);
        }
        public static bool IsUserExistByPersonID(int personID)
        {
            return DVLD_DataAccess.clsUserData.IsUserExistByPersonID(personID);
        }
        public static clsUser FindByUsernameAndPassword(string userName, string password)
        {
            int userID = -1, personID = -1;
            bool isActive = false;

            if (DVLD_DataAccess.clsUserData.GetUserInfoByUsernameAndPassword(ref userID, ref personID, userName, password, ref isActive))
            {
                return new clsUser(userID, personID, userName, password, isActive);
            }
            else
                return null;
        }
        public static DataTable GetAllUsers()
        {
            return DVLD_DataAccess.clsUserData.GetAllUsers();
        }
        protected bool _AddNewUser()
        {
            this.UserID = DVLD_DataAccess.clsUserData.AddUser(this.PersonID, this.UserName,
                this.Password, this.isActive);

            return (this.UserID != -1);
        }
        protected bool _UpdateUser()
        {
            return DVLD_DataAccess.clsUserData.UpdateUser(this.UserID, this.PersonID,
                this.UserName, this.Password, this.isActive);
        }
        public bool Save()
        {
            switch (mode)
            {
                case enMode.enAddNew:
                    if (_AddNewUser())
                    {
                        mode = enMode.enUpdate;
                        return true;
                    }
                    else
                        return false;

                case enMode.enUpdate:
                    return _UpdateUser();

                default:
                    break;
            }
            return false;
        }
        public static bool ChangePassword(int UserID,string NewPassword)
        {
            return DVLD_DataAccess.clsUserData.ChangeUserPassword(UserID,NewPassword);
        }
        public static bool DeleteUser(int userID)
        {
            return DVLD_DataAccess.clsUserData.DeleteUser(userID);
        }
        
    }
}
