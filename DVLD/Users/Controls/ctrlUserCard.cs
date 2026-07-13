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

namespace DVLD.Users.Controls
{
    public partial class ctrlUserCard : UserControl
    {
        private int _UserID = -1;
        public int UserID
        {
            get { return _UserID; }
        }

        private clsUser _UserInfo;
        public clsUser UserInfo
        {
            get { return _UserInfo; }
        }

        public ctrlUserCard()
        {
            InitializeComponent();
        }
        private void _FillUserInfo()
        {
            ctrlPersonCard1.LoadPersonInfo(UserInfo.PersonID);
            lblUserID.Text = _UserID.ToString();
            lblUserName.Text = UserInfo.UserName;
            if (UserInfo.isActive == true)
                lblIsActive.Text = "Yes";
            else
                lblIsActive.Text = "No";
            
        }
        private void _ResetUserInfo()
        {
            lblUserID.Text = "[???]";
            lblUserName.Text = "[???]";
            lblIsActive.Text = "[???]";
        }
        public void LoadUserInfo(int UserID)
        {
            _UserInfo = clsUser.Find(UserID);
            if (_UserInfo != null)
            {
                _UserID = UserID;
                _FillUserInfo();
            }
            else
            {
                MessageBox.Show("There is no Person with User ID = " + UserID);
                _ResetUserInfo();
                return;
            }
        }
    }
}
