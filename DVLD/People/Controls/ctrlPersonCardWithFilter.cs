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

namespace DVLD.People.Controls
{
    public partial class ctrlPersonCardWithFilter : UserControl
    {
        /*
        private int _PersonID = -1;
        public int PersonID
        {
            get { return _PersonID; }
        }

        private clsPerson _PersonInfo;
        public clsPerson PersonInfo
        {
            get { return _PersonInfo; }
        }*/
        public ctrlPersonCardWithFilter()
        {
            InitializeComponent();
            //this.ParentChanged += ctrlPersonCard1_ParentChanged;
        }
        public enum enFilterMode
        {
            ByPersonID = 0, ByNationalNo = 1
        }
        public enFilterMode filterMode = enFilterMode.ByPersonID;

        private int _PersonID = -1;
        public int PersonID { get { return ctrlPersonCard1.PersonID; } }
        public clsPerson PersonInfo { get { return ctrlPersonCard1.PersonInfo; } }


        private bool _ShowAddPerson = true;
        public bool ShowAddPerson
        {
            get
            {
                return _ShowAddPerson;
            }
            set
            {
                _ShowAddPerson = value;
                btnAddNew.Visible = _ShowAddPerson;
            }
        }

        private bool _FilterEnabled = true;
        public bool FilterEnabled
        {
            get
            {
                return _FilterEnabled;
            }
            set
            {
                _FilterEnabled = value;
                gbFilters.Enabled = _FilterEnabled;
            }
        }



        // Define a custom event handler delegate with parameters
        public event Action<int> OnPersonSelected;
        // Create a protected method to raise the event with a parameter
        protected virtual void PersonSelected(int PersonID)
        {
            Action<int> handler = OnPersonSelected;
            if (handler != null)
            {
                handler(PersonID); // Raise the event with the parameter
            }
        }
        private void ctrlPersonCardWithFilter_Load(object sender, EventArgs e)
        {
            cbFilterType.SelectedIndex = 0;
            filterMode = enFilterMode.ByPersonID;
            tbFilterValue.Focus();
        }

        

        public void LoadPersonInfo(int PersonID)
        {
            cbFilterType.SelectedIndex = 0;
            filterMode = enFilterMode.ByPersonID;
            tbFilterValue.Text = PersonID.ToString();
            FindPerson();

        }
        public void LoadPersonInfo(string NationalNo)
        {
            cbFilterType.SelectedIndex = 1;
            filterMode = enFilterMode.ByNationalNo;
            tbFilterValue.Text = NationalNo;
            FindPerson();
        }
        private void cbFilterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbFilterValue.Text = "";
            tbFilterValue.Focus();
            if (cbFilterType.SelectedIndex == 0)
            {
                filterMode = enFilterMode.ByPersonID;
            }
            else if (cbFilterType.SelectedIndex == 1)
            {
                filterMode = enFilterMode.ByNationalNo;
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddNewUpdatePerson form = new frmAddNewUpdatePerson();
            form.DataBack += Form_DataBack_koko;
            form.ShowDialog();
        }
        private void FindPerson()
        {
            switch (filterMode)
            {
                case enFilterMode.ByPersonID:
                    if (clsValidation.ValidateInteger(tbFilterValue.Text))
                    {
                        _PersonID = Convert.ToInt32(tbFilterValue.Text);
                        if (clsPerson.IsPersonExist(_PersonID))
                        {
                            ctrlPersonCard1.LoadPersonInfo(_PersonID);
                        }
                        else
                        {
                            MessageBox.Show("There is no this ID, control ID number");
                            return;
                        }
                    }
                    else { 
                        MessageBox.Show("Your input must be a number!");
                        return ;
                    }
                    break;


                case enFilterMode.ByNationalNo:
                    if (clsPerson.IsPersonExist(tbFilterValue.Text))
                    {
                        ctrlPersonCard1.LoadPersonInfo(tbFilterValue.Text);
                    }
                    else
                    {
                        MessageBox.Show("There is no this National Number, control number please!");
                        return;
                    }
                    break;
                default:
                    break;
            }
            if (OnPersonSelected != null && FilterEnabled)
                // Raise the event with a parameter
                OnPersonSelected(ctrlPersonCard1.PersonID);
        }
        private void Form_DataBack_koko(object sender, int PersonID)
        {
            tbFilterValue.Text = PersonID.ToString();
            cbFilterType.SelectedIndex = 0;
            filterMode = enFilterMode.ByPersonID;
            FindPerson();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                FindPerson();
            }
            else
            {
                MessageBox.Show("The textbox is empty!");
            }
        }
        public void FilterFocus()
        {
            tbFilterValue.Focus();
        }

        private void tbFilterValue_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbFilterValue.Text))
                errorProvider1.SetError(tbFilterValue, "This field cannot be empty!");
            else
                errorProvider1.SetError(tbFilterValue, "");
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is Enter (character code 13)
            if (e.KeyChar == (char)13)
            {

                btnFind.PerformClick();
            }

            //this will allow only digits if person id is selected
            if (filterMode==enFilterMode.ByPersonID)
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void ctrlPersonCard1_ParentChanged(object sender, EventArgs e)
        {
            // Kontrolün yüklendiği ana formu buluyoruz
            /*Form parentForm = this.FindForm();

            if (parentForm != null)
            {
                // userControl içindeki butonunu formun AcceptButton'ı olarak ata
                // 'btnSave' yerine kendi butonunun adını yazmalısın
                parentForm.AcceptButton = this.btnFind;
            }*/
        }
    }
}
