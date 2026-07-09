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
        public DataView PeopleDataView1;
        public frmManagePeople()
        {
            InitializeComponent();
        }
        private void RefreshData()
        {
            cbFilterBy.SelectedIndex = 0;
            PeopleDataView1 = DVLD_Business.clsPerson.GetAllPersons().DefaultView;
            dataGridView1.DataSource = PeopleDataView1;
            lblRecordsCount.Text = PeopleDataView1.Count.ToString();
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
                    PeopleDataView1.RowFilter = $"";
                    break;
                case "Person ID":
                    PeopleDataView1.RowFilter = $"_PersonID = {lblFilterValue.Text}";
                    break;
                case "National No":
                    PeopleDataView1.RowFilter = $"NationalNo LIKE '%{lblFilterValue.Text}%'";
                    break;
                case "First Name":
                    PeopleDataView1.RowFilter = $"FirstName LIKE '%{lblFilterValue.Text}%'";
                    break;
                case "Second Name":
                    PeopleDataView1.RowFilter = $"SecondName LIKE '%{lblFilterValue.Text}%'";
                    break;
                case "Third Name":
                    PeopleDataView1.RowFilter = $"ThirdName LIKE '%{lblFilterValue.Text}%'";
                    break;
                case "Last Name":
                    PeopleDataView1.RowFilter = $"LastName LIKE '%{lblFilterValue.Text}%'";
                    break;
                case "Nationality":
                    PeopleDataView1.RowFilter = $"CountryName LIKE '%{lblFilterValue.Text}%'";
                    break;
                case "Gender":
                    PeopleDataView1.RowFilter = $"GenderCaption LIKE '%{lblFilterValue.Text}%'";
                    break;
                case "Phone":
                    PeopleDataView1.RowFilter = $"Phone LIKE '%{lblFilterValue.Text}%'";
                    break;
                case "Email":
                    PeopleDataView1.RowFilter = $"Email LIKE '%{lblFilterValue.Text}%'";
                    break;
            }
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            ApplyFilterByCB();
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
            PeopleDataView1.RowFilter = $"CountryName = '{cbCountries.Text}'";
        }
        private void addNewPerson(object sender, EventArgs e)
        {
            Form frmAddNewUpdatePerson = new frmAddNewUpdatePerson();
            frmAddNewUpdatePerson.ShowDialog();
            RefreshData();
        }

        private void edittsm_Click(object sender, EventArgs e)
        {
            int.TryParse(dataGridView1.CurrentRow.Cells["PersonID"].Value.ToString(), out int SelectedID);
            Form frmAddNewUpdatePerson = new frmAddNewUpdatePerson(SelectedID);
            frmAddNewUpdatePerson.ShowDialog();
            RefreshData();

        }

        private void deletetsm_Click(object sender, EventArgs e)
        {
            int.TryParse(dataGridView1.CurrentRow.Cells["PersonID"].Value.ToString(), out int SelectedID);
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
            int.TryParse(dataGridView1.CurrentRow.Cells["PersonID"].Value.ToString(), out int SelectedID);
            Form frmAddNewUpdatePerson = new frmPersonInfo(SelectedID);
            frmAddNewUpdatePerson.ShowDialog();
            RefreshData();
        }
    }
}
