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
    public partial class frmStockHolder : Form
    {
        DBStock db = new DBStock();
        public int stockId;
        public frmStockHolder()
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
            txtId.Text = stockId.ToString();
            dgvList.DataSource = db.StockHolderList(stockId);
        }


        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dgvList[1, dgvList.SelectedCells[0].RowIndex].Value.ToString();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            stockId = Convert.ToInt32(txtId.Text);
            dgvList.DataSource = db.StockHolderList(stockId);
        }
    }
}
