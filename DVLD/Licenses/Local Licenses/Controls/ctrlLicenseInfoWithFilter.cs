using DVLD.Global_Classes;
using DVLD.People;
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
using static DVLD.People.Controls.ctrlPersonCardWithFilter;

namespace DVLD.Licenses.Local_Licenses.Controls
{
    public partial class ctrlLicenseInfoWithFilter : UserControl
    {
        private int _LicenseID;
        public int LicenseID { get { return _LicenseID; } }
        private bool _FilterEnabled=true;
        private clsLicense LicenseInfo;
        public bool FilterEnabled {  
            get
            { 
                return _FilterEnabled; 
            } 
            set 
            { 
                _FilterEnabled = value;
                gbFilter.Enabled = _FilterEnabled;    
            }
        }

        public event Action<int> OnLicenseSelected;
        // Create a protected method to raise the event with a parameter
        protected virtual void LicenseSelected(int LicenseID)
        {
            Action<int> handler = OnLicenseSelected;
            if (handler != null)
            {
                handler(LicenseID); // Raise the event with the parameter
            }
        }


        public ctrlLicenseInfoWithFilter()
        {
            InitializeComponent();
        }
        public void LoadLicenseInfo(int LicenseID)
        {
            tbLicense.Text = LicenseID.ToString();
            ctrlLicenseInfo1.LoadLicenseInfo(LicenseID);
            gbFilter.Enabled = false;
            if (OnLicenseSelected != null && _FilterEnabled)
                // Raise the event with a parameter
                OnLicenseSelected(LicenseID);
        }
        private void btnView_Click(object sender, EventArgs e)
        {
            if (tbLicense.Text.Trim() == string.Empty)
                return;
            if (!clsValidation.ValidateInteger(tbLicense.Text.Trim()))
                return;
            int LicenseID= int.Parse(tbLicense.Text.Trim());
            clsLicense LicenseInfoTemp = clsLicense.Find(LicenseID);
            if (LicenseInfoTemp != null)
            {
                _LicenseID = LicenseID;
                this.LicenseInfo = LicenseInfoTemp;
                ctrlLicenseInfo1.LoadLicenseInfo(_LicenseID);
                if (OnLicenseSelected != null && _FilterEnabled)
                    // Raise the event with a parameter
                    OnLicenseSelected(_LicenseID);
            }
            else
            {
                MessageBox.Show("There is no this License!");
            }
        }
        public void FilterFocus()
        {
            tbLicense.Focus();
        }
        private void tbLicense_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                btnView.PerformClick();
            //this will allow only digits if person id is selected
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
