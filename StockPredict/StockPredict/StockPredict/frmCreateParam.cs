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
    public partial class frmCreateParam : Form
    {
        DBStock db = new DBStock();
        int giPos;
        public frmCreateParam()
        {
            InitializeComponent();
        }




        private void frmCreateParam_Load(object sender, EventArgs e)
        {

        }

        private void ResetData()
        {
            giPos = 0;
            txtParam.Text = "";
            txtVNParam.Text = "";
            txtDesc.Text = "";
            txtMask.Text = "";
            txtBranchPos.Text = "0";
            txtStockPos.Text = "";
        }

        private void LoadData()
        {
            DataTable table = db.GroupList(0);;
            cboGroup.DataSource = table;
            cboGroup.DisplayMember = "ParameterGroup1";
            cboGroup.ValueMember = "Id";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

    }
}
