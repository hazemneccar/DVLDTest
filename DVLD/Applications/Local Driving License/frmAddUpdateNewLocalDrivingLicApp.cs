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

namespace DVLD.Applications.Local_Driving_License
{
    public partial class frmAddUpdateNewLocalDrivingLicApp : Form
    {
        private enum enMode { AddNew=0,Update=1 }
        private enMode _Mode= enMode.AddNew;

        private int _PersonID = -1;
        private int _LocalDrivingLicAppID = -1;
        private clslocalDrivingApp _LocalDrivingLicAppInfo;
        public frmAddUpdateNewLocalDrivingLicApp()
        {
            InitializeComponent();
            _Mode= enMode.AddNew;
        }
        public frmAddUpdateNewLocalDrivingLicApp(int LocalDrivingLicAppID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            if (clslocalDrivingApp.Find(LocalDrivingLicAppID)==null)
            {
                MessageBox.Show("Local application ID not found!");
                this.Close();
                return;
            }
            _LocalDrivingLicAppID = LocalDrivingLicAppID;

        }
        private void CreateNewLocalDrivingLicApp()
        {
            _LocalDrivingLicAppInfo.ApplicationDate = DateTime.Now;
            _LocalDrivingLicAppInfo.ApplicationStatus = clsApplication.enApplicationStatus.New;
            _LocalDrivingLicAppInfo.PaidFees = clsApplicationType.Find(clsApplication.enApplicationTypes.NewLocalDrivingLicense).ApplicationFees;
            _LocalDrivingLicAppInfo.CreatedByUserID = 21;
            _LocalDrivingLicAppInfo.ApplicationTypeID = clsApplication.enApplicationTypes.NewLocalDrivingLicense;

            lblApplicationDate.Text = clsFormat.DateToShort(_LocalDrivingLicAppInfo.ApplicationDate);
            lblApplicationFees.Text = _LocalDrivingLicAppInfo.PaidFees.ToString();
            lblCreatedByUser.Text = clsUser.Find(_LocalDrivingLicAppInfo.CreatedByUserID).UserName;
        }
        private void LoadAllLicenseClasses()
        {
            DataTable dt = clsLicenseClass.GetAllLicenseClasses();
            foreach (DataRow Class in dt.Rows)
            {
                cbAllLicenseClasses.Items.Add(Class["ClassName"]);
            }
            cbAllLicenseClasses.SelectedIndex = 2;
        }
        private void ResetDefaultValues()
        {
            LoadAllLicenseClasses();
            switch (_Mode)
            {
                case enMode.AddNew:
                    lblTitle.Text = "New Local Driving License Application";
                    this.Text = "New Local Driving Licence Application";
                    _LocalDrivingLicAppInfo=new clslocalDrivingApp();
                    tpApplicationInfo.Enabled = false;
                    btnSave.Enabled = false;
                    CreateNewLocalDrivingLicApp();

                    break;
                case enMode.Update:
                    lblTitle.Text = "Update Local Driving License Application";
                    this.Text = "Update Local Driving License Application";
                    _LocalDrivingLicAppInfo=clslocalDrivingApp.Find(_LocalDrivingLicAppID);
                    _PersonID = _LocalDrivingLicAppInfo.ApplicantPersonID;
                    tpApplicationInfo.Enabled = true;
                    btnNext.Enabled = true;
                    btnSave.Enabled = true;
                    break;
                default:
                    break;
            }
        }
        private void LoadInfo()
        {
            ctrlPersonCardWithFilter1.LoadPersonInfo(_PersonID);
            ctrlPersonCardWithFilter1.FilterEnabled = false;
            lblLocalApplicationID.Text = _LocalDrivingLicAppInfo.LocalDrivingAppID.ToString();
            lblApplicationDate.Text = _LocalDrivingLicAppInfo.ApplicationDate.ToString();
            lblApplicationFees.Text = _LocalDrivingLicAppInfo.PaidFees.ToString();
            lblCreatedByUser.Text = clsUser.Find(_LocalDrivingLicAppInfo.CreatedByUserID).UserName;
            cbAllLicenseClasses.SelectedIndex= cbAllLicenseClasses.FindString(clsLicenseClass.Find(_LocalDrivingLicAppInfo.LicenseClassID).ClassName);
        }

        private void frmNewLocalDrivingLicApp_Load(object sender, EventArgs e)
        {
            ResetDefaultValues();
            if (_Mode==enMode.Update)
            {
                LoadInfo();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tpApplicationInfo;
            btnSave.Enabled=true;
            this.AcceptButton = btnSave;
        }

        private void ctrlPersonCardWithFilter1_OnPersonSelected(int obj)
        {
            _PersonID = obj;
            btnNext.Enabled = true;
            this.AcceptButton=btnNext;
            tpApplicationInfo.Enabled = true;
            _LocalDrivingLicAppInfo.ApplicantPersonID = _PersonID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            clsLicenseClass.enLicenseClasses SelectedLicenseClassID= clsLicenseClass.Find(cbAllLicenseClasses.Text).LicenseClassID;
            if (clsLicenseClass.Find(SelectedLicenseClassID).MinimumAllowedAge > clsUtilityBusiness.CalculateAge(clsPerson.Find(_PersonID).DateOfBirth))
            {
                MessageBox.Show("Your age is tutmuyor efendim!");
                return;
            }
            int ActiveAppID =clslocalDrivingApp.GetActiveApplicationIDForLicenseClass(_PersonID, 
                clsApplication.enApplicationTypes.NewLocalDrivingLicense, (clsLicenseClass.enLicenseClasses)SelectedLicenseClassID);

            if (ActiveAppID!=-1)
            {
                MessageBox.Show("There is active Local license ID with this Type with Lic ID=" +clsLicense.GetActiveLicenseIDByPersonID(_PersonID, SelectedLicenseClassID) + 
                    ". Please select another person! or renew it using renew page!");
                return;
            }
            _LocalDrivingLicAppInfo.LicenseClassID = SelectedLicenseClassID;
            _LocalDrivingLicAppInfo.LastStatusDate = DateTime.Now;
            if (_LocalDrivingLicAppInfo.Save())
            {
                MessageBox.Show("Saved successfully!");
                lblLocalApplicationID.Text = _LocalDrivingLicAppInfo.LocalDrivingAppID.ToString();
            }
            else
                MessageBox.Show("Error while saving!");
        }

        private void frmAddUpdateNewLocalDrivingLicApp_Activated(object sender, EventArgs e)
        {
            ctrlPersonCardWithFilter1.FilterFocus();
        }
    }
}
