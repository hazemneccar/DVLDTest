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
    public partial class frmListApplicationTypes : Form
    {
        DataTable _AllApplicationTypes;
        public frmListApplicationTypes()
        {
            InitializeComponent();
        }
        private void frmListApplicationTypes_Load(object sender, EventArgs e)
        {
            _AllApplicationTypes= clsApplicationType.GetAllApplicationTypes();
            dgvApplicationTypes.DataSource = _AllApplicationTypes;
            lblRecordCount.Text = _AllApplicationTypes.Rows.Count.ToString();

            if (dgvApplicationTypes.Rows.Count > 0)
            {
                dgvApplicationTypes.Columns[0].HeaderText = "ID";
                dgvApplicationTypes.Columns[0].Width = 80;

                dgvApplicationTypes.Columns[1].HeaderText = "Title";
                dgvApplicationTypes.Columns[1].Width = 250;

                dgvApplicationTypes.Columns[2].HeaderText = "Fees";
                dgvApplicationTypes.Columns[2].Width = 100;
            }
        }

        private void tsmEdit_Click(object sender, EventArgs e)
        {
            int.TryParse(dgvApplicationTypes.CurrentRow.Cells["ApplicationTypeID"].Value.ToString(), out int SelectedID);

            frmEditApplicationType frmEdit = new frmEditApplicationType(SelectedID);
            frmEdit.ShowDialog();
            frmListApplicationTypes_Load(null, null);
        }
    }
}
