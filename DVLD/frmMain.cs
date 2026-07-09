using DVLD.People;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        private void OpenChildForm<T>() where T : Form, new()
        {
            // 1. Adım: Form zaten açık mı diye kontrol et
            foreach (Form openForm in this.MdiChildren)
            {
                if (openForm is T)
                {
                    openForm.Activate(); // Açıksa öne getir
                    return;              // Metottan çık, yenisini açma
                }
            }

            // 2. Adım: Açık değilse generic olarak yeni bir tane oluştur
            T frm = new T();
            frm.MdiParent = this;
            frm.Show();
        }

        private void msPeople_Click(object sender, EventArgs e)
        {
            OpenChildForm<frmManagePeople>();
        }
    }
}
