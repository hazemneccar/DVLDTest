using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Applications.International_License
{
    public partial class frmshowInternationalLicenseInfo : Form
    {
        private int _IntLicenseID;
        public frmshowInternationalLicenseInfo(int IntLicenseID)
        {
            InitializeComponent();
            _IntLicenseID = IntLicenseID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmshowInternationalLicenseInfo_Load(object sender, EventArgs e)
        {
            ctrlShowInternationalLicenseInfo1.LoadInternationalLicenseInfo(_IntLicenseID);
        }
    }
}
