using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Applications.Local_Driving_License
{
    public partial class frmShowLocalDrivingAppInfo : Form
    {
        private int _LocalAppID;
        public frmShowLocalDrivingAppInfo(int LocalAppID)
        {
            InitializeComponent();
            _LocalAppID = LocalAppID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowLocalDrivingAppInfo_Load(object sender, EventArgs e)
        {
            if (clslocalDrivingApp.Find(_LocalAppID)!=null)
            {
                ctrlLocalDrivingAppInfo1.LoadLocalAppInfoByLocalAppID(_LocalAppID);
            }
        }
    }
}
