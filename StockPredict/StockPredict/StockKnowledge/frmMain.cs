using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StockKnowledge
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void mnuTerms_Click(object sender, EventArgs e)
        {
            frmTerms frm = new frmTerms();
            frm.Show();
        }

        private void mnuNews_Click(object sender, EventArgs e)
        {
            frmNews frm = new frmNews();
            frm.Show();
        }

        private void mnuEvents_Click(object sender, EventArgs e)
        {
            frmEvents frm = new frmEvents();
            frm.Show();
        }

        private void mnuDefinition_Click(object sender, EventArgs e)
        {
            frmDefinition frm = new frmDefinition();
            frm.Show();
        }

        private void mnuPortfolio_Click(object sender, EventArgs e)
        {
            frmPortfolio frm = new frmPortfolio();
            frm.Show();
        }

        private void mnuBranchStock_Click(object sender, EventArgs e)
        {
            (new frmBranchStock()).Show();
        }
    }
}
