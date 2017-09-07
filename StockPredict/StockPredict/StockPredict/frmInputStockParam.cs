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
    public partial class frmInputStockParam : Form
    {
        DBStock db = new DBStock();
        int giPos, iPrev=-1;
        double[] dValue;
        public frmInputStockParam()
        {
            db.CreateDB();
            InitializeComponent();
        }


        //************* Data **************

        private void ResetData()
        {
            giPos = 0;
            txtParamValue.Text = "0";
            txtParamDesc.Text = "";
            txtParamMask.Text = "";
            txtParamVN.Text = "";
            txtID.Text = "";
            for (int i = 0; i < dValue.Count(); i++)
                dValue[i] = 0;            
        }

        private void LoadData()
        {
            DataTable table = db.StockList(0, true);
            cboStock.DataSource = table;
            cboStock.DisplayMember = "Stock";
            cboStock.ValueMember = "Id";

            table = db.ParameterListbyGroup(1,3);
            cboParam.DataSource = table;
            // set size of array
            dValue = new double[table.Rows.Count];
            
            cboParam.DisplayMember = "Parameter1";
            cboParam.ValueMember = "StockPos";

        }

        private void cboParam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboParam.SelectedValue.ToString().Length < 10)
            {
                if (iPrev >= 0)
                    dValue[iPrev] = Convert.ToDouble(txtParamValue.Text);
                iPrev = Convert.ToInt32(cboParam.SelectedValue)-4;

                DataTable table = db.ParameterListbyStockPos(Convert.ToInt32(cboParam.SelectedValue));
                txtParamVN.Text = table.Rows[0][3].ToString();
                txtParamDesc.Text = table.Rows[0][4].ToString();
                txtParamMask.Text = table.Rows[0][5].ToString();
                txtParamValue.Text = "" + dValue[Convert.ToInt32(cboParam.SelectedValue)-4];
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                db.FinanceValueEditbyADO(Convert.ToInt32(cboStock.SelectedValue), Convert.ToInt32(txtTerm.Text), dValue);
                ResetData();
            }
            catch (Exception e1) { }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < dValue.Count(); i++)
                dValue[i] = 0;            

            int iPos = dgvList.SelectedCells[0].RowIndex;
            giPos = Convert.ToInt32(dgvList.Rows[iPos].Cells[1].Value);
            for (int i = 4; i < dgvList.ColumnCount; i++)
                if (dgvList.Rows[iPos].Cells[i].Value.ToString().Length>0)
                    dValue[i-4] = Convert.ToDouble(dgvList.Rows[iPos].Cells[i].Value);
            txtID.Text = giPos + "";
            cboStock.SelectedValue = Convert.ToInt32(dgvList.Rows[iPos].Cells[2].Value);
            txtTerm.Text = dgvList.Rows[iPos].Cells[3].Value.ToString();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataTable table;
            if (chkAll.Checked) 
            {
                if (txtTerm.Text == "") table = db.FinanceValueListbyTerm(0);
                else table = db.FinanceValueListbyTerm(Convert.ToInt32(txtTerm.Text));
            }
            else
            {
                if (txtTerm.Text == "") table = db.FinanceValueList(Convert.ToInt32(cboStock.SelectedValue));
                else table = db.FinanceValueList(Convert.ToInt32(cboStock.SelectedValue),Convert.ToInt32(txtTerm.Text));
            }

            dgvList.DataSource = table;
            if (dgvList.Columns.Count > 0)
            {
                dgvList.Columns[1].Visible = false;
                dgvList.Columns[2].Visible = false;
            }
        }

        private void frmInputStockParam_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dValue[Convert.ToInt32(cboParam.SelectedValue)-4] = Convert.ToDouble(txtParamValue.Text);
        }

        private void dgvList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dValue[dgvList.SelectedCells[0].ColumnIndex - 4] = Convert.ToDouble(dgvList.Rows[dgvList.SelectedCells[0].RowIndex].Cells[dgvList.SelectedCells[0].ColumnIndex].Value);
            }
            catch (Exception e2) { }
        }

     }
}
