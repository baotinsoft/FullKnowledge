using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StockPredict.DBContext;
using System.Diagnostics;

namespace StockPredict
{
    public partial class frmStockMonitor : Form
    {
        DBStock db = new DBStock();
        public int stockId;
        public frmStockMonitor()
        {
            InitializeComponent();
        }

        private void frmStockMonitor_SizeChanged(object sender, EventArgs e)
        {
            dgvList.Height = this.Height - dgvList.Location.Y;
            dgvList.Width = this.Width;
        }

        private void frmStockMonitor_Load(object sender, EventArgs e)
        {
            dgvList.DataSource = db.MonitorList();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtId.Text.Length > 0)
            {
                db.MonitorDelete(Convert.ToInt32(txtId.Text));
                dgvList.DataSource = db.MonitorList();
            }
        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            stockId = Convert.ToInt32(dgvList[1, dgvList.SelectedCells[0].RowIndex].Value);
            txtId.Text = stockId.ToString();
            if (chkPriceHistory.Checked)
            {
                frmPriceHistory frm = new frmPriceHistory();
                frm.days = 10;
                frm.lstId = new List<int>();
                frm.lstId.Add(stockId);
                frm.RefreshAction(true);
                frm.Show();
            }

            if (chkStockInfo.Checked)
            {
                Process.Start("chrome.exe", db.StockInfoUrl(stockId));
            }

            if (chkStockHolder.Checked)
            {
                frmStockHolder frm = new frmStockHolder();
                frm.stockId = stockId;
                frm.Show();
            }
        }
    }
}
