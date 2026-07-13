using DVLD.Applications.Application_Types;
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

namespace DVLD.Tests.TestTypes
{
    public partial class frmListTestTypes : Form
    {
        private DataTable _AllTestTypes;
        public frmListTestTypes()
        {
            InitializeComponent();
        }

        private void frmListTestTypes_Load(object sender, EventArgs e)
        {
            _AllTestTypes=clsTestType.GetAllTestTypes();
            dgvAllTestTypes.DataSource = _AllTestTypes;
            lblRecordCount.Text=_AllTestTypes.Rows.Count.ToString();

            if (dgvAllTestTypes.Rows.Count>0)
            {
                dgvAllTestTypes.Columns[0].HeaderText = "ID";
                dgvAllTestTypes.Columns[0].Width = 75;

                dgvAllTestTypes.Columns[1].HeaderText = "Title";
                dgvAllTestTypes.Columns[1].Width = 120;

                dgvAllTestTypes.Columns[2].HeaderText = "Description";
                dgvAllTestTypes.Columns[2].Width = 320;

                dgvAllTestTypes.Columns[3].HeaderText = "Fees";
                dgvAllTestTypes.Columns[3].Width = 75;
            }
        }

        private void editTestTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int.TryParse(dgvAllTestTypes.CurrentRow.Cells["TestTypeID"].Value.ToString(), out int SelectedID);

            frmEditTestType frmEdit = new frmEditTestType(SelectedID);
            frmEdit.ShowDialog();
            frmListTestTypes_Load(null, null);
        }
    }
}
