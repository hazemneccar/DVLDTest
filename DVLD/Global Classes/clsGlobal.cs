using DVLD_Business;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Global_Classes
{
    public class clsGlobal
    {
        public static clsUser CurrentUser; /*{ get; set; }*/
        static string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\DVLD";
        static string Username_ValueName = "username";
        static string Password_ValueName = "password";

        public static bool RememberUsernameAndPassword(string Username, string Password)
        {
            string Username_ValueData = Username;
            string Password_ValueData = Password;
            try
            {
                Registry.SetValue(keyPath, Username_ValueName, Username_ValueData, RegistryValueKind.String);
                Registry.SetValue(keyPath, Password_ValueName, Password_ValueData, RegistryValueKind.String);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }
        public static bool GetStoredCredential(ref string Username, ref string Password)
        {
            try
            {
                Username = (string)Registry.GetValue(keyPath, Username_ValueName, null);
                Password = (string)Registry.GetValue(keyPath, Password_ValueName, null);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }

        }
    }
}
