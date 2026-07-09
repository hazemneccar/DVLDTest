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
    public partial class frmPersonInfo : Form
    {
        public frmPersonInfo(int PersonID)
        {
            InitializeComponent();
            ctrlPersonInfo1.LoadPersonInfo(PersonID);

        }
    }
}
