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

namespace DVLD.Tests
{
    public partial class frmScheduleTest : Form
    {
        private int _LocalAppID=-1;
        private clsTestType.enTestType _TestType=clsTestType.enTestType.VisionTest;
        private int _TestAppointment=-1;
        public frmScheduleTest(int localAppID,clsTestType.enTestType testType,int testAppontmentID=-1)
        {
            InitializeComponent();
            _LocalAppID = localAppID;
            _TestType = testType;
            _TestAppointment = testAppontmentID;
        }

        private void frmScheduleTest_Load(object sender, EventArgs e)
        {
            ctrlScheduleTest1.TestType= _TestType;
            ctrlScheduleTest1.LoadTestInfo(_LocalAppID,_TestAppointment);
        }
    }
}
