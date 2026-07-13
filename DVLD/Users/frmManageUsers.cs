using DVLD.Users.Controls;
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

namespace DVLD.Users
{
    public partial class frmManageUsers : Form
    {
        public frmManageUsers()
        {
            InitializeComponent();
            RefreshData();
            cbIsUserActive.SelectedIndex = 0;
        }
        private static DataView _dtAllUsers;

        private void RefreshData()
        {
            cbFilterBy.SelectedIndex = 0;
            cbIsUserActive.SelectedIndex = 0;

            tbFilterValue.Text = "";
            _dtAllUsers = DVLD_Business.clsUser.GetAllUsers().DefaultView;
            dgvUsers.DataSource = _dtAllUsers;

            if (dgvUsers.Rows.Count > 0)
            {
                dgvUsers.Columns[0].HeaderText = "User ID";
                dgvUsers.Columns[0].Width = 90;

                dgvUsers.Columns[1].HeaderText = "Person ID";
                dgvUsers.Columns[1].Width = 90;

                dgvUsers.Columns[2].HeaderText = "Full Name";
                dgvUsers.Columns[2].Width = 300;

                dgvUsers.Columns[3].HeaderText = "User Name";
                dgvUsers.Columns[3].Width = 125;

                dgvUsers.Columns[4].HeaderText = "Is Active";
                dgvUsers.Columns[4].Width = 80;
            }
            lblRecordsCount.Text = _dtAllUsers.Count.ToString();
        }

        private void ApplyFilterByCB_AbuHadhoud()
        {
            string FilterColumn = "";
            switch (cbFilterBy.Text)
            {
                case "None":
                    break;
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;
                case "User ID":
                    FilterColumn = "UserID";
                    break;
                case "Full Name":
                    FilterColumn = "FullName";
                    break;
                case "User Name":
                    FilterColumn = "UserName";
                    break;
                case "Is Active":
                    FilterColumn = "IsActive";
                    break;
                default:
                    FilterColumn = "";
                    break;
            }
            if ((tbFilterValue.Visible == true && tbFilterValue.Text.Trim() == "")
                 || (cbIsUserActive.Visible == true && cbIsUserActive.Text.Trim() == "")
                 || FilterColumn == "")
            {
                _dtAllUsers.RowFilter = "";
                lblRecordsCount.Text = dgvUsers.Rows.Count.ToString();
                return;
            }
            if (FilterColumn == "PersonID" || FilterColumn == "UserID")
                _dtAllUsers.RowFilter = string.Format("[{0}]={1}", FilterColumn, tbFilterValue.Text.Trim());
            else if (FilterColumn == "IsActive")
            {
                switch(cbIsUserActive.Text)
                {
                    case "All":
                        _dtAllUsers.RowFilter = "";
                        break;
                    case "Yes":
                        _dtAllUsers.RowFilter = "IsActive = true";;
                        break;
                    case "No":
                        _dtAllUsers.RowFilter = "IsActive = false" ;
                        break;
                    default:
                        FilterColumn = "None";
                        break;
                }
            }
            else
                _dtAllUsers.RowFilter = string.Format("[{0}] LIKE '%{1}%'", FilterColumn, tbFilterValue.Text.Trim());
            lblRecordsCount.Text = dgvUsers.Rows.Count.ToString();
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblFilterValue_TextChanged(object sender, EventArgs e)
        {
            ApplyFilterByCB_AbuHadhoud();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.Text == "None" || cbFilterBy.Text == "Is Active")
            {
                tbFilterValue.Visible = false;
                if (cbFilterBy.Text == "Is Active")
                {
                    cbIsUserActive.Visible = true;
                } 
            }
            else
            {
                tbFilterValue.Visible = true;
                cbIsUserActive.Visible = false;

            }

        }

        private void cbIsUserActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(_dtAllUsers!=null)
                ApplyFilterByCB_AbuHadhoud();
        }

        private void showDetailstsm_Click(object sender, EventArgs e)
        {
            int.TryParse(dgvUsers.CurrentRow.Cells["UserID"].Value.ToString(), out int SelectedID);
            frmUserInfo frmUserInfo = new frmUserInfo(SelectedID);
            frmUserInfo.ShowDialog();
        }

        private void AddNewUser_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frmAddUpdateUser = new frmAddUpdateUser();
            frmAddUpdateUser.ShowDialog();
            RefreshData();
        }

        private void edittsm_Click(object sender, EventArgs e)
        {
            int.TryParse(dgvUsers.CurrentRow.Cells["UserID"].Value.ToString(), out int SelectedID);
            frmAddUpdateUser frmAddUpdateUser = new frmAddUpdateUser(SelectedID);
            frmAddUpdateUser.ShowDialog();
            RefreshData();
        }

        private void deletetsm_Click(object sender, EventArgs e)
        {
            int.TryParse(dgvUsers.CurrentRow.Cells["UserID"].Value.ToString(), out int SelectedID);
            if (clsUser.isUserExist(SelectedID))
            {
                if (MessageBox.Show("Are you sure that you'll delete this user?", "Alert", MessageBoxButtons.YesNo)==DialogResult.Yes)
                {
                    if (clsUser.DeleteUser(SelectedID))
                        MessageBox.Show("Deleted successfully!");
                    else
                        MessageBox.Show("The person is linked with other data!, you just can deactivate this user!");
                }
                else
                {
                    MessageBox.Show("User not found!");
                }
            }
        }

        private void changePasswordtsm_Click(object sender, EventArgs e)
        {
            int.TryParse(dgvUsers.CurrentRow.Cells["UserID"].Value.ToString(), out int SelectedID);
            frmChangePassword frmchangePassword = new frmChangePassword(SelectedID);
            frmchangePassword.ShowDialog();
        }

        private void tbFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {

            //this will allow only digits if person id is selected
            if (cbFilterBy.Text == "Person ID" || cbFilterBy.Text == "User ID")

                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }

}
