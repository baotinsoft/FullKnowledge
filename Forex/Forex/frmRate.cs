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
    public partial class frmRate : Form
    {
        DBHistorical db = new DBHistorical();

        public frmRate()
        {
            InitializeComponent();
        }

        private void frmRate_Load(object sender, EventArgs e)
        {
            cboForex.ValueMember = "Id";
            cboForex.DisplayMember = "CodeNum";
            cboForex.DataSource = db.DefinitionList(1);
            cboForex.SelectedValue = 12;

            //dgvList.DataSource = db.DateRateList(0);
        }

        private void cboForex_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvList.DataSource = db.DateRateList((int)cboForex.SelectedValue);
        }

        private void frmRate_Resize(object sender, EventArgs e)
        {
            dgvList.Width = this.Width - dgvList.Left - 10;
            dgvList.Height = this.Height - dgvList.Top - 10;
        }
    }
}
