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
    public partial class frmStatConfig : Form
    {
        DBStock db = new DBStock();
        public frmStatConfig()
        {
            InitializeComponent();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            txtMessage.Text = "Đang chạy!";
            try
            {
                if(chkAll.Checked)
                    db.ChangePriceStat(1, 99999,
                        dtFrom.Value, dtTo.Value);
                else
                    db.ChangePriceStat(Convert.ToInt32(cboFrom.SelectedValue), Convert.ToInt32(cboTo.SelectedValue),
                        dtFrom.Value, dtTo.Value);
            }
            catch (Exception e1) { }
            txtMessage.Text = "Hoàn tất!";
        }

        //************* Data **************

        private void ResetData()
        {
            chkAll.Checked = false;
        }

        private void LoadData()
        {
            //DBCost db = new DBCost();
            DataTable table = db.StockList(0,true);
            cboFrom.DataSource = table;
            cboFrom.DisplayMember = "Stock";
            cboFrom.ValueMember = "Id";


            table = db.StockList(0,true);
            cboTo.DataSource = table;
            cboTo.DisplayMember = "Stock";
            cboTo.ValueMember = "Id";

        }

        private void frmStatConfig_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
