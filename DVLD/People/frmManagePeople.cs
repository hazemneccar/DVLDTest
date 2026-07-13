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

namespace DVLD.People
{
    public partial class frmManagePeople : Form
    {
        private static DataView _dtAllPeople;
        public frmManagePeople()
        {
            InitializeComponent();
        }
        private void RefreshData()
        {
            cbFilterBy.SelectedIndex = 0;
            lblFilterValue.Text = "";
            _dtAllPeople = DVLD_Business.clsPerson.GetAllPersons().DefaultView;
            dgvPeople.DataSource = _dtAllPeople;

            if (dgvPeople.Rows.Count>0)
            {
                dgvPeople.Columns[0].HeaderText = "Person ID";
                dgvPeople.Columns[0].Width = 70;

                dgvPeople.Columns[1].HeaderText = "National No.";
                dgvPeople.Columns[1].Width = 80;

                dgvPeople.Columns[2].HeaderText = "First Name";
                dgvPeople.Columns[2].Width = 95;

                dgvPeople.Columns[3].HeaderText = "Second Name";
                dgvPeople.Columns[3].Width = 90;

                dgvPeople.Columns[4].HeaderText = "Third Name";
                dgvPeople.Columns[4].Width = 90;

                dgvPeople.Columns[5].HeaderText = "Last Name";
                dgvPeople.Columns[5].Width = 95;

                dgvPeople.Columns[6].HeaderText = "Date Of Birth";
                dgvPeople.Columns[6].Width = 120;

                dgvPeople.Columns[7].HeaderText = "Gender";
                dgvPeople.Columns[7].Width = 80;

                dgvPeople.Columns[8].HeaderText = "Nationality";
                dgvPeople.Columns[8].Width = 100;

                dgvPeople.Columns[9].HeaderText = "Phone";
                dgvPeople.Columns[9].Width = 120;

                dgvPeople.Columns[10].HeaderText = "Email";
                dgvPeople.Columns[10].Width = 140;
            }

            lblRecordsCount.Text = _dtAllPeople.Count.ToString();
        }
        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void ApplyFilterByCB()
        {
            switch (cbFilterBy.Text)
            {
                case "None":
                    _dtAllPeople.RowFilter = $"";
                    break;
                case "Person ID":
                    _dtAllPeople.RowFilter = $"_PersonID = {lblFilterValue.Text}";
                    break;
                case "National No":
                        _dtAllPeople.RowFilter = $"NationalNo LIKE '%{lblFilterValue.Text}%'";
                    break;
                case "First Name":
                    _dtAllPeople.RowFilter = $"FirstName LIKE '%{lblFilterValue.Text}%'";
                    break;
                case "Second Name":
                    _dtAllPeople.RowFilter = $"SecondName LIKE '%{lblFilterValue.Text}%'";
                    break;
                case "Third Name":
                    _dtAllPeople.RowFilter = $"ThirdName LIKE '%{lblFilterValue.Text}%'";
                    break;
                case "Last Name":
                    _dtAllPeople.RowFilter = $"LastName LIKE '%{lblFilterValue.Text}%'";
                    break;
                case "Nationality":
                    _dtAllPeople.RowFilter = $"CountryName LIKE '%{lblFilterValue.Text}%'";
                    break;
                case "Gender":
                    _dtAllPeople.RowFilter = $"GenderCaption LIKE '%{lblFilterValue.Text}%'";
                    break;
                case "Phone":
                    _dtAllPeople.RowFilter = $"Phone LIKE '%{lblFilterValue.Text}%'";
                    break;
                case "Email":
                    _dtAllPeople.RowFilter = $"Email LIKE '%{lblFilterValue.Text}%'";
                    break;
            }
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
                case "National No":
                    FilterColumn = "NationalNo";
                    break;
                case "First Name":
                    FilterColumn = "FirstName";
                    break;
                case "Second Name":
                    FilterColumn = "SecondName";
                    break;
                case "Third Name":
                    FilterColumn = "ThirdName";
                    break;
                case "Last Name":
                    FilterColumn = "LastName";
                    break;
                case "Nationality":
                    FilterColumn = "CountryName";
                    break;
                case "Gender":
                    FilterColumn = "GenderCaption";
                    break;
                case "Phone":
                    FilterColumn = "Phone";
                    break;
                case "Email":
                    FilterColumn = "Email";
                    break;
                default:
                    FilterColumn = "None";
                    break;
            }
            if ((lblFilterValue.Visible==true && lblFilterValue.Text.Trim() == "")
                 || (cbCountries.Visible == true && cbCountries.Text.Trim() == "")
                 ||
                 FilterColumn=="None" )
            {
                _dtAllPeople.RowFilter = "";
                lblRecordsCount.Text = dgvPeople.Rows.Count.ToString();
                return;
            }
            if (FilterColumn == "PersonID")
                _dtAllPeople.RowFilter = string.Format("[{0}]={1}",FilterColumn,lblFilterValue.Text.Trim());
            else if (FilterColumn == "CountryName")
                _dtAllPeople.RowFilter = string.Format("[{0}] LIKE '%{1}%'", FilterColumn, cbCountries.Text.Trim());
            else
                _dtAllPeople.RowFilter = string.Format("[{0}] LIKE '%{1}%'", FilterColumn, lblFilterValue.Text.Trim());
            lblRecordsCount.Text = dgvPeople.Rows.Count.ToString();
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            ApplyFilterByCB_AbuHadhoud();
        }
        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.SelectedIndex!=0 && cbFilterBy.Text!= "Nationality") {
                lblFilterValue.Visible = true;
                cbCountries.Visible = false;
            }
            else
                lblFilterValue.Visible = false;

            if (cbFilterBy.Text== "Nationality")
            {
                cbCountries.Visible = true;
                DataTable dt= clsCountry.GetAllCounties();
                foreach (DataRow Country in dt.Rows)
                {
                    cbCountries.Items.Add(Country["CountryName"]);
                }
                cbCountries.FindString("Syria");
                cbCountries_SelectedIndexChanged(sender, e);
            }
        }
        private void cbCountries_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilterByCB_AbuHadhoud();
            //_dtAllPeople.RowFilter = $"CountryName = '{cbCountries.Text}'";

        }
        private void addNewPerson(object sender, EventArgs e)
        {
            Form frmAddNewUpdatePerson = new frmAddNewUpdatePerson();
            frmAddNewUpdatePerson.ShowDialog();
            RefreshData();
        }
        private void edittsm_Click(object sender, EventArgs e)
        {
            int.TryParse(dgvPeople.CurrentRow.Cells["PersonID"].Value.ToString(), out int SelectedID);
            Form frmAddNewUpdatePerson = new frmAddNewUpdatePerson(SelectedID);
            frmAddNewUpdatePerson.ShowDialog();
            RefreshData();

        }

        private void deletetsm_Click(object sender, EventArgs e)
        {
            int.TryParse(dgvPeople.CurrentRow.Cells["PersonID"].Value.ToString(), out int SelectedID);
            if (MessageBox.Show("Are you sure that you will delete ID="+SelectedID.ToString()+"?","Alert",MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                if (clsPerson.DeletePerson(SelectedID))
                    MessageBox.Show("Deleted successfully!");
                else
                    MessageBox.Show("The person is linked with other infos in the system,you just can deactivate this person!");
            }
            RefreshData();

        }

        private void showDetailstsm_Click(object sender, EventArgs e)
        {
            int.TryParse(dgvPeople.CurrentRow.Cells["PersonID"].Value.ToString(), out int SelectedID);
            Form frmAddNewUpdatePerson = new frmPersonInfo(SelectedID);
            frmAddNewUpdatePerson.ShowDialog();
            RefreshData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
