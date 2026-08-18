using DVLD.Licenses.Local_Licenses;
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
using static System.Net.Mime.MediaTypeNames;

namespace DVLD.Applications.controls
{
    public partial class ctrlLocalDrivingAppInfo : UserControl
    {
        private int _PersonID;
        private clsLicenseClass.enLicenseClasses _LicenseClass;
        private int _LocalDrivingLicenseID = -1;
        private clslocalDrivingApp _LocalDrivingLicenseInfo;
        public int LocalDrivingLicenseID
        {
            get {  return _LocalDrivingLicenseID; }
        }
        public ctrlLocalDrivingAppInfo()
        {
            InitializeComponent();
        }
        private void ResetDefaultValues()
        {
            lblLDLAppID.Text = "[???]";
            lblLicenseClass.Text = "[???]";
            lblPassedTests.Text = "[???]/3";
        }
        public void LoadLocalAppInfoByLocalAppID(int LocalAppID)
        {
            ResetDefaultValues();
            clslocalDrivingApp application = clslocalDrivingApp.Find(LocalAppID);
            if (application == null)
            {
                MessageBox.Show("There is no this Application ID!");
            }
            _LocalDrivingLicenseID = LocalAppID;
            _LocalDrivingLicenseInfo = application;
            _FillAppDate();
        }
        public void LoadLocalAppInfoByApplicationID(int ApplicationID)
        {
            ResetDefaultValues();
            clslocalDrivingApp application = clslocalDrivingApp.FindByAppID(ApplicationID);
            if (application == null)
            {
                MessageBox.Show("There is no this Application ID!");

            }
            _LocalDrivingLicenseID = application.LocalDrivingAppID;
            _LocalDrivingLicenseInfo = application;
            _FillAppDate();
        }
        private void _FillAppDate()
        {
            
            ctrlAppBasicInfo1.LoadAppInfo(_LocalDrivingLicenseInfo.ApplicationID);
            lblLDLAppID.Text = _LocalDrivingLicenseInfo.LocalDrivingAppID.ToString();
            lblPassedTests.Text = string.Format("{0}/3", _LocalDrivingLicenseInfo.GetPassedTestCount());
            lblLicenseClass.Text = clsLicenseClass.Find(_LocalDrivingLicenseInfo.LicenseClassID).ClassName;
            _PersonID = _LocalDrivingLicenseInfo.ApplicantPersonID;
            _LicenseClass = _LocalDrivingLicenseInfo.LicenseClassID;
            int ActiveLicense = clsLicense.GetActiveLicenseIDByPersonID(_PersonID, _LicenseClass);
            linklblShowLicenseInfo.Enabled = (ActiveLicense != -1);
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int ActiveLicense=clsLicense.GetActiveLicenseIDByPersonID(_PersonID, _LicenseClass);
            if (ActiveLicense!=-1)
            {
                frmShowLicenseInfo frm = new frmShowLicenseInfo(ActiveLicense);
                frm.ShowDialog();
            }
            
        }
    }
}