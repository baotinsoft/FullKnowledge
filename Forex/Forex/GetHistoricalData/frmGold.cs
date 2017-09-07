using GetHistoricalData.DBContext;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GetHistoricalData
{
    public partial class frmGold : Form
    {
        DBHistorical db = new DBHistorical();

        public frmGold()
        {
            InitializeComponent();
        }

        private void btnDisplayNear_Click(object sender, EventArgs e)
        {
            dgvMonthYear.DataSource = db.GoldMonthYear(Convert.ToInt32(cboMonths.Text), Convert.ToInt32(cboYears.Text));
            dgvMonth.DataSource = db.GoldMonth(Convert.ToInt32(cboMonths.Text), Convert.ToInt32(cboYears.Text));
            dgvDisplay.DataSource = db.GoldList(Convert.ToInt32(cboDays.Text));
            dgvWeekDay.DataSource = db.GoldWeekDay(Convert.ToInt32(cboMonths.Text), Convert.ToInt32(cboYears.Text));
        }

        private void frmGold_Load(object sender, EventArgs e)
        {
            dgvMonthYear.DataSource = db.GoldMonthYear(Convert.ToInt32(cboMonths.Text), Convert.ToInt32(cboYears.Text));
            dgvMonth.DataSource = db.GoldMonth(Convert.ToInt32(cboMonths.Text), Convert.ToInt32(cboYears.Text));
            dgvDisplay.DataSource = db.GoldList(Convert.ToInt32(cboDays.Text));
            dgvWeekDay.DataSource = db.GoldWeekDay(Convert.ToInt32(cboMonths.Text), Convert.ToInt32(cboYears.Text));

        }
    }
}
