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

namespace StockPredict
{
    public partial class frmPriceHistory : Form
    {
        DBStock db = new DBStock();
        public List<int> lstId;
        public int days = 10;
        public frmPriceHistory()
        {
            InitializeComponent();
        }

        private void frmPriceHistory_SizeChanged(object sender, EventArgs e)
        {
            dgvList.Height = this.Height - dgvList.Location.Y;
            dgvList.Width = this.Width;
        }

        private void frmPriceHistory_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public void RefreshAction(bool isCall)
        {
            int iCount = 0;
            if (!isCall)
            {
                days = Convert.ToInt32(txtDays.Text);
                iCount = lstStock.SelectedIndices.Count;
                lstId = new List<int>();
                if (!(iCount == 0 || chkAllStock.Checked))
                {

                    for (int i = 0; i < iCount; i++)
                        lstId.Add(Convert.ToInt32(((System.Data.DataRowView)lstStock.Items[lstStock.SelectedIndices[i]])[0]));
                }
            }
            else
                txtDays.Text = days.ToString();
            dgvList.DataSource = db.PriceList(lstId, days);
        }

        private void LoadData()
        {
            DataTable table = db.StockList(0, false);
            lstStock.DataSource = table;
            lstStock.DisplayMember = "Code";
            lstStock.ValueMember = "Id";
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshAction(false);
        }
    }
}
