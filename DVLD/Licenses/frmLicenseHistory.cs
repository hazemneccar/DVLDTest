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

namespace DVLD.Licenses
{
    public partial class frmLicenseHistory : Form
    {
        private int _DriverID=-1;
        public frmLicenseHistory(int driverID)
        {
            InitializeComponent();
            _DriverID = driverID;
        }
        public frmLicenseHistory()
        {
            InitializeComponent();
        }
            private void frmLicenseHistory_Load(object sender, EventArgs e)
            {
                if (_DriverID!=-1)
                {
                    ctrlPersonCardWithFilter1.FilterEnabled = false;
                    ctrlPersonCardWithFilter1.LoadPersonInfo(clsDriver.Find(_DriverID).PersonID);
                    ctrlDriverLicenses1.LoadDriverLicensesInfo(_DriverID);
                }
                else
                {
                    ctrlPersonCardWithFilter1.FilterEnabled = true;
                    ctrlPersonCardWithFilter1.FilterFocus();
                }
            }

        private void ctrlPersonCardWithFilter1_OnPersonSelected(int obj)
        {
            clsDriver driver = clsDriver.FindByPersonID(obj);

            if (driver != null && ctrlPersonCardWithFilter1.FilterEnabled)
            {
                _DriverID = driver.DriverID;
                frmLicenseHistory_Load(null, null);
            }
            else
            {
                _DriverID = -1;
                ctrlDriverLicenses1.Clear();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
