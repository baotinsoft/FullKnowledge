using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FullKnowledge
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void mnuDBSync_Click(object sender, EventArgs e)
        {
            string[] args = new string[1];
            args[0] = "0";
            (new DBSynchronization.frmMain(args)).Show();
        }

        private void mnuKnowledge_Click(object sender, EventArgs e)
        {
            (new Knowledge.frmMain()).Show();
        }

        private void mnuForex_Click(object sender, EventArgs e)
        {
            Forex.frmSJC frm = new Forex.frmSJC();
            frm.exit = false;
            frm.Show();
        }

        private void mnuLand_Click(object sender, EventArgs e)
        {
            (new Land.frmMain()).Show();
        }

        private void mnuStock_Click(object sender, EventArgs e)
        {
            (new StockKnowledge.frmMain()).Show();
        }
    }
}
