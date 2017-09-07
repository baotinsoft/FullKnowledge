using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using StockPredict.DBContext;
using WindowFramework;

namespace StockPredict
{
    public partial class frmViewInfo_Market : Form
    {
        DBStock db = new DBStock();
        public frmViewInfo_Market()
        {
            InitializeComponent();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            LoadData(dtFrom.Value, dtTo.Value);
        }

        //************* Data **************

        private void ResetData()
        {
            //giPos = 0;
            //txtParamValue.Text = "0";
            //txtParamDesc.Text = "";
            //txtParamMask.Text = "";
            //txtID.Text = "";
            //dtDate.Text = DateTime.Now.ToString();
        }

        private void LoadData()
        {
            DataTable table = db.PriceList(298); //VNINDEX
            dgvHO.DataSource = table;
            if (dgvHO.Columns.Count > 0)
            {
                dgvHO.Columns[0].Visible = false;
                dgvHO.Columns[1].Visible = false;
            }
            table = db.PriceList(299); //HAINDEX
            dgvHA.DataSource = table;
            if (dgvHA.Columns.Count > 0)
            {
                dgvHA.Columns[0].Visible = false;
                dgvHA.Columns[1].Visible = false;
            }
        }

        private void LoadData(DateTime dtFrom, DateTime dtTo)
        {
            DataTable table = db.PriceList(298, dtFrom, dtTo); //VNINDEX
            dgvHO.DataSource = table;
            if (dgvHO.Columns.Count > 0)
            {
                dgvHO.Columns[0].Visible = false;
                dgvHO.Columns[1].Visible = false;
            }
            table = db.PriceList(299, dtFrom, dtTo); //HAINDEX
            dgvHA.DataSource = table;
            if (dgvHA.Columns.Count > 0)
            {
                dgvHA.Columns[0].Visible = false;
                dgvHA.Columns[1].Visible = false;
            }
        }

        private void frmViewInfo_Market_Load(object sender, EventArgs e)
        {
            LoadData();
        }

    }
}
