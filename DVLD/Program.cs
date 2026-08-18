using DVLD.Applications.Application_Types;
using DVLD.Applications.controls;
using DVLD.Applications.International_License;
using DVLD.Applications.Local_Driving_License;
using DVLD.Applications.Replace_License;
using DVLD.Drivers;
using DVLD.Licenses.Detain;
using DVLD.Licenses.Local_Licenses;
using DVLD.People;
using DVLD.Tests;
using DVLD.Tests.TestTypes;
using DVLD.Users;
using DVLD.Users.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new frmLogIn());
        }
    }
}
