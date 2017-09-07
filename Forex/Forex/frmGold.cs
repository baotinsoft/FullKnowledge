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
            dgvDisplay.UpdateHeader("Daily Price");
            dgvMonth.UpdateHeader("Month Avg Price of all");
            dgvMonthYear.UpdateHeader("Month Avg Price of Each Year");
            dgvWeekDay.UpdateHeader("WeekDay Avg Price of all");

            dgvMonthYear.DataSource = db.GoldMonthYear(Convert.ToInt32(cboMonths.Text), Convert.ToInt32(cboYears.Text));
            dgvMonth.DataSource = db.GoldMonth(Convert.ToInt32(cboMonths.Text), Convert.ToInt32(cboYears.Text));
            dgvDisplay.DataSource = db.GoldList(Convert.ToInt32(cboDays.Text));
            dgvWeekDay.DataSource = db.GoldWeekDay(Convert.ToInt32(cboMonths.Text), Convert.ToInt32(cboYears.Text));

        }

        private void frmGold_Resize(object sender, EventArgs e)
        {
            dgvDisplay.Width = (this.Width / 2) - 20;
            dgvDisplay.Height = ((this.Height - dgvDisplay.Location.Y) / 2) - 20;

            dgvWeekDay.Width = dgvDisplay.Width;
            dgvWeekDay.Height = this.Height - dgvWeekDay.Location.Y - 20;

            dgvWeekDay.Top = dgvDisplay.Top + dgvDisplay.Height + 10;

            dgvMonthYear.Width = dgvDisplay.Width;
            dgvMonthYear.Height = dgvDisplay.Height;

            dgvMonthYear.Left = dgvWeekDay.Width + 10;

            dgvMonth.Width = dgvWeekDay.Width;
            dgvMonth.Height = dgvWeekDay.Height;

            dgvMonth.Top = dgvWeekDay.Top;
            dgvMonth.Left = dgvMonthYear.Left;
        }
    }
}
