using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Land
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }


        private void mnuUrls_Click(object sender, EventArgs e)
        {

        }

        private void mnuLand_Click(object sender, EventArgs e)
        {
            frmLand frm = new frmLand(0);
            frm.Show();
        }
    }
}
