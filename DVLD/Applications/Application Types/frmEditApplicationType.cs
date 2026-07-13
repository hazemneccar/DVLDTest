using DVLD.Global_Classes;
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

namespace DVLD.Applications.Application_Types
{
    public partial class frmEditApplicationType : Form
    {
        private int _ApplicationTypeID;
        private clsApplicationType _AppType;
        public frmEditApplicationType(int ApplicationTypeID)
        {
            InitializeComponent();
            _ApplicationTypeID = ApplicationTypeID;
        }

        private void frmEditApplicationType_Load(object sender, EventArgs e)
        {
            clsApplicationType AppType = clsApplicationType.Find((clsApplication.enApplicationTypes)_ApplicationTypeID);
            if (AppType != null) 
            {
                _AppType = AppType;
                lblAppTypeID.Text= _ApplicationTypeID.ToString();
                tbTitle.Text = _AppType.ApplicationTitle;
                tbFees.Text = _AppType.ApplicationFees.ToString();
            }
            else
            {
                MessageBox.Show("Wrong App ID!");
                this.Close();
            }
        }


        private void tbTitle_Validating(object sender, CancelEventArgs e)
        {
            if (tbTitle.Text == string.Empty)
            {
                errorProvider1.SetError(tbTitle, "You sould fill this field!");
            }
            else
                errorProvider1.SetError(tbTitle, "");
        }

        private void tbFees_Validating(object sender, CancelEventArgs e)
        {
            if (tbFees.Text == string.Empty)
            {
                errorProvider1.SetError(tbFees, "You sould fill this field!");
            }
            else if (!clsValidation.IsNumber(tbFees.Text.Trim()))
            {
                errorProvider1.SetError(tbFees, "Fees value must be number!");
            }
            else
                errorProvider1.SetError(tbFees, "");
        }

        private bool HasValidationError()
        {
            foreach (Control c in this.Controls)
            {
                // Eğer kontrol bir Panel veya GroupBox içindeyse onları da taramak için
                if (HasChildrenErrors(c)) return true;
            }
            return false;
        }
        private bool HasChildrenErrors(Control control)
        {
            // Kontrolün üzerinde aktif bir hata mesajı var mı?
            if (!string.IsNullOrEmpty(errorProvider1.GetError(control)))
            {
                return true;
            }

            // Alt kontrolleri varsa (panel içi vs.) onları da kontrol et
            foreach (Control child in control.Controls)
            {
                if (HasChildrenErrors(child)) return true;
            }

            return false;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.ValidateChildren();
            if (HasValidationError())
            {
                MessageBox.Show("Check all fields!");
                return;
            }

            _AppType.ApplicationTitle = tbTitle.Text.Trim();
            _AppType.ApplicationFees = Convert.ToSingle(tbFees.Text);

            if (_AppType.UpdateAppTypeInfo())
                MessageBox.Show("Updated successfully");
            else
                MessageBox.Show("Problem while saving!");

        }
    }
}
