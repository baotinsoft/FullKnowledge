using Forex.DBContext;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Forex
{
    public partial class frmCompareGoldVN_World : Form
    {
        DBHistorical db = new DBHistorical();

        public frmCompareGoldVN_World()
        {
            InitializeComponent();
        }

        private void frmCompareGoldVN_World_Load(object sender, EventArgs e)
        {
            dgvList.DataSource = db.CompareGoldVN_World(1);
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            if (txtMonth.Text == "")
            {
                lblMessage.Text = "Please input month to compare";
                return;
            }
            else lblMessage.Text = "";
            dgvList.DataSource = db.CompareGoldVN_World(Convert.ToInt32(txtMonth.Text));
        }
    }
}
