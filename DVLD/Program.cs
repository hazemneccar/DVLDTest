using DVLD.Applications.Application_Types;
using DVLD.People;
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
            Application.Run(new frmListTestTypes());
        }
    }
}
