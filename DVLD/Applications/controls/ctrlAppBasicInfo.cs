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

namespace DVLD.Applications.controls
{
    public partial class ctrlAppBasicInfo : UserControl
    {
        public ctrlAppBasicInfo()
        {
            InitializeComponent();
        }
        private int _PersonID=-1;
        private void ResetDefaultValue()
        {
            lblAppID.Text = "[???]";
            lblStatus.Text = "[???]";
            lblFees.Text = "[???]";
            lblType.Text = "[???]";
            lblApplicant.Text = "[???]";
            lblDate.Text = "[???]";
            lblStatusDate.Text = "[???]";
            lblCreatedBy.Text = "[???]";
        }
        public void LoadAppInfo(int ApplicationID)
        {
            ResetDefaultValue();
            clsApplication application = clsApplication.Find(ApplicationID);
            if (application == null)
            {
                MessageBox.Show("There is no this Application ID!");
                return;
            }
            _PersonID = application.ApplicantPersonID;
            lblAppID.Text= application.ApplicationID.ToString();
            switch (application.ApplicationStatus)
            {
                case clsApplication.enApplicationStatus.New:
                    lblStatus.Text = "New";
                    break;
                case clsApplication.enApplicationStatus.Cancelled:
                    lblStatus.Text = "Cancelled";
                    break;
                case clsApplication.enApplicationStatus.Completed:
                    lblStatus.Text = "Completed";
                    break;
                default:
                    break;
            }
            lblFees.Text = application.PaidFees.ToString();
            switch (application.ApplicationTypeID)
            {
                case clsApplication.enApplicationTypes.NewLocalDrivingLicense:
                    lblType.Text = "New Local Driving License";
                    break;
                case clsApplication.enApplicationTypes.RenewDrivingLicense:
                    lblType.Text = "Renew Driving License";
                    break;
                case clsApplication.enApplicationTypes.ReplacementForLostDrivingLicense:
                    lblType.Text = "Replacement For Lost Driving License";
                    break;
                case clsApplication.enApplicationTypes.ReplacementForDamagedDrivingLicense:
                    lblType.Text = "Replacement For Damaged Dricing License";

                    break;
                case clsApplication.enApplicationTypes.ReleaseDetainedDrivingLicense:
                    lblType.Text = "Release Detained Driving License";

                    break;
                case clsApplication.enApplicationTypes.NewInternationalDrivingLicense:
                    lblType.Text = "New International Driving License";
                    break;
                case clsApplication.enApplicationTypes.RetakeTest:
                    lblType.Text = "Retake Test";
                    break;
                default:
                    break;
            }
            lblApplicant.Text = clsPerson.Find(application.ApplicantPersonID).FullName;
            lblDate.Text=clsFormat.DateToShort(application.ApplicationDate);
            lblStatusDate.Text = clsFormat.DateToShort(application.LastStatusDate);
            lblCreatedBy.Text = clsUser.Find(application.CreatedByUserID).UserName;
        }

        private void linkLabelViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_PersonID==-1)
                return;
            
            frmPersonInfo frm = new frmPersonInfo(_PersonID);
            frm.ShowDialog();
        }
    }
}
