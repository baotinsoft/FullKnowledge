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
    public partial class frmViewInfo_ChangePrice : Form
    {
        DBStock db = new DBStock();
        public frmViewInfo_ChangePrice()
        {
            InitializeComponent();
        }

        private void frmViewInfo_ChangePrice_Load(object sender, EventArgs e)
        {
            dtFrom.Value = DateTime.Now.Date;
            LoadData();
        }

        //************* Data **************

        private void ResetData()
        {
            txtSub.Text = "0";
            dtFrom.Text = DateTime.Now.ToString();
        }

        private void LoadData()
        {
            DataTable table = db.StockList(0,true);
            cboStockFrom.DataSource = table;
            cboStockFrom.DisplayMember = "Code";
            cboStockFrom.ValueMember = "Id";

            table = db.StockList(0,true);
            cboStockTo.DataSource = table;
            cboStockTo.DisplayMember = "Code";
            cboStockTo.ValueMember = "Id";

            table = db.StockList(0,false);
            lstStock.DataSource = table;
            lstStock.DisplayMember = "Code";
            lstStock.ValueMember = "Id";

            cboFiveBasicElement.DataSource = db.DefinitionListForCbo(11);
            cboFiveBasicElement.DisplayMember = "Name";
            cboFiveBasicElement.ValueMember = "Id";

        }


        private void View1()
        {
            int iStockFrom, iStockTo = 0, top = 0;

            try
            {
                top = Convert.ToInt32(txtTop.Text);
            }
            catch (Exception) { }

            if (cboStockFrom.Enabled)
            {
                iStockFrom = Convert.ToInt32(cboStockFrom.SelectedValue);
                iStockTo = Convert.ToInt32(cboStockTo.SelectedValue);
            }
            else iStockFrom = 0;

            int changePricePercent = 0;
            try
            {
                changePricePercent = Convert.ToInt32(txtChangePricePercent.Text);
            }
            catch (Exception) { }

            DataTable table;
            if (top == 0)
                table = db.ChangedPercentList(iStockFrom, iStockTo, dtFrom.Value, Convert.ToInt32(txtSub.Text), true, changePricePercent, chkAllMarket.Checked, Convert.ToInt32(txtQuantity.Text), Convert.ToInt32(txtMinPrice.Text), (int)cboFiveBasicElement.SelectedValue);
            else
                table = db.TopChangedPercentList(dtFrom.Value, Convert.ToInt32(txtSub.Text), true, top, chkAllMarket.Checked, Convert.ToInt32(txtQuantity.Text), (int)cboFiveBasicElement.SelectedValue);

            dgvPriceASC.DataSource = table;

            //if (dgvPriceASC.Columns.Count > 0)
            //{
            //    dgvPriceASC.Columns[0].Visible = false;
            //    //dgvPriceASC.Columns[1].Visible = false;
            //    //dgvPriceASC.Columns[2].Visible = false;
            //    //dgvAsc.Columns[1].HeaderText = "Kho";
            //}
            if (top == 0)
                table = db.ChangedPercentList(iStockFrom, iStockTo, dtFrom.Value, Convert.ToInt32(txtSub.Text), false, changePricePercent, chkAllMarket.Checked, Convert.ToInt32(txtQuantity.Text), Convert.ToInt32(txtMinPrice.Text), (int)cboFiveBasicElement.SelectedValue);
            else
                table = db.TopChangedPercentList(dtFrom.Value, Convert.ToInt32(txtSub.Text), false, top, chkAllMarket.Checked, Convert.ToInt32(txtQuantity.Text), (int)cboFiveBasicElement.SelectedValue);


            dgvPriceDESC.DataSource = table;

            //if (dgvPriceDESC.Columns.Count > 0)
            //{
            //    dgvPriceDESC.Columns[0].Visible = false;
            //    //dgvPriceDESC.Columns[1].Visible = false;
            //    //dgvPriceASC.Columns[2].Visible = false;
            //    //dgvAsc.Columns[1].HeaderText = "Kho";
            //}

        }

        private void View2()
        {
            int iCount = lstStock.SelectedIndices.Count;
            string sStockList = "";
            System.Data.DataRowView drv;
            for (int i = 0; i < iCount; i++)
            {
                lstStock.Items[lstStock.SelectedIndices[i]].GetType();
                //lstStock.Items[lstStock.SelectedIndices[i]].ToString();
                drv = (System.Data.DataRowView)lstStock.Items[lstStock.SelectedIndices[i]];
                sStockList += drv.Row[0] + ",";
                //sStockList += "'" + Convert.ToString(lstStock.SelectedItems[i]) + "',";
            }

            sStockList = sStockList.Substring(0, sStockList.Length - 1);

            int changePricePercent = 0;
            try
            {
                changePricePercent = Convert.ToInt32(txtChangePricePercent.Text);
            }
            catch (Exception) { }

            DataTable table = db.ChangedPercentList(sStockList, dtFrom.Value, Convert.ToInt32(txtSub.Text), true, changePricePercent, chkAllMarket.Checked, Convert.ToInt32(txtQuantity.Text), Convert.ToInt32(txtMinPrice.Text), (int)cboFiveBasicElement.SelectedValue);

            dgvCheckedPriceASC.DataSource = table;
            //if (dgvCheckedPriceASC.Columns.Count > 0)
            //{
            //    dgvCheckedPriceASC.Columns[0].Visible = false;
            //    //dgvPriceDESC.Columns[1].Visible = false;
            //    //dgvPriceASC.Columns[2].Visible = false;
            //    //dgvAsc.Columns[1].HeaderText = "Kho";
            //}
            table = db.ChangedPercentList(sStockList, dtFrom.Value, Convert.ToInt32(txtSub.Text), false, changePricePercent, chkAllMarket.Checked, Convert.ToInt32(txtQuantity.Text), Convert.ToInt32(txtMinPrice.Text), (int)cboFiveBasicElement.SelectedValue);
            dgvCheckedPriceDESC.DataSource = table;
        }


        private void chkAllStock_CheckedChanged(object sender, EventArgs e)
        {
            cboStockFrom.Enabled = !chkAllStock.Checked;
            cboStockTo.Enabled = !chkAllStock.Checked;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            View1();
        }

        private void btnView2_Click(object sender, EventArgs e)
        {
            View2();
        }

        private void btnViewBoth_Click(object sender, EventArgs e)
        {
            View1();
            View2();
        }

        private void cboStockFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboStockFrom.SelectedIndex > 0)
                cboStockTo.SelectedIndex = cboStockFrom.SelectedIndex;
        }

        private void btnAddMonitor_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAsc.Text.Length > 0) db.MonitorUpdate(Convert.ToInt32(txtAsc.Text), 35001, ascReason);
            }
            catch (Exception) { }

            try
            {
                if (txtDesc.Text.Length > 0) db.MonitorUpdate(Convert.ToInt32(txtDesc.Text), 35001, descReason);
            }
            catch (Exception) { }
        }

        string ascReason;
        private void dgvPriceASC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtAsc.Text = dgvPriceASC[0, dgvPriceASC.SelectedCells[0].RowIndex].Value.ToString();
            ascReason = "Gia tang: " + dgvPriceASC[dgvPriceASC.ColumnCount - 1, dgvPriceASC.SelectedCells[0].RowIndex].Value.ToString();
            History(Convert.ToInt32(dgvPriceASC[0, dgvPriceASC.SelectedCells[0].RowIndex].Value));
        }

        string descReason;
        private void dgvPriceDESC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtDesc.Text = dgvPriceDESC[0, dgvPriceDESC.SelectedCells[0].RowIndex].Value.ToString();
            descReason = "Gia giam: " + dgvPriceDESC[dgvPriceDESC.ColumnCount - 1, dgvPriceDESC.SelectedCells[0].RowIndex].Value.ToString();
            History(Convert.ToInt32(dgvPriceDESC[0, dgvPriceDESC.SelectedCells[0].RowIndex].Value));
        }

        private void History(int id)
        {
            if (chkPriceHistory.Checked)
            {
                frmPriceHistory frm = new frmPriceHistory();
                frm.days = Convert.ToInt32(txtSub.Text);
                frm.lstId = new List<int>();
                frm.lstId.Add(id);
                frm.RefreshAction(true);
                frm.Show();
            }
        }
    }
}
