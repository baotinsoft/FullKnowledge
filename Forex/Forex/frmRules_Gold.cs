using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Forex.DBContext;


namespace Forex
{
    public partial class frmRules_Gold : Form
    {
        DBHistorical db = new DBHistorical();
        public frmRules_Gold()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            dgvList.DataSource = db.GoldTrend(dtFrom.Value, dtTo.Value);
        }

        private void frmRules_Gold_Load(object sender, EventArgs e)
        {
            dtFrom.Value = dtFrom.Value.AddYears(-1);
        }
    }
}
