using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Knowledge
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void mnuList_Click(object sender, EventArgs e)
        {
            new frmDefinition().Show();
        }

        private void mnuEbookRead_Click(object sender, EventArgs e)
        {
            new frmRead(1).Show();
        }

        private void mnuEbookSave_Click(object sender, EventArgs e)
        {
            new frmBookSave().Show();
        }

        private void mnuKnowledgeRead_Click(object sender, EventArgs e)
        {
            new frmRead(2).Show();
        }

        private void mnuKnowledgeSave_Click(object sender, EventArgs e)
        {
            new frmKnowledgeSave(1).Show();
        }

        private void mnuTermSave_Click(object sender, EventArgs e)
        {
            new frmTermSave().Show();
        }

        private void mnuTermRead_Click(object sender, EventArgs e)
        {
            new frmRead(3).Show();
        }

        private void mnuFileMove_Click(object sender, EventArgs e)
        {
            frmFileMove frm = new frmFileMove();
            frm.Show();
        }

        private void mnuSettings_Click(object sender, EventArgs e)
        {
            frmSettings frm = new frmSettings();
            frm.Show();
        }

        private void mnuRulesRead_Click(object sender, EventArgs e)
        {
            new frmRead(4).Show();
        }

        private void mnuRulesSave_Click(object sender, EventArgs e)
        {
            new frmKnowledgeSave(2).Show();
        }
    }
}
