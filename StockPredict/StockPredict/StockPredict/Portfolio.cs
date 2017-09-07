﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using StockPredict.DBContext;

namespace StockPredict
{
    public partial class frmPortfolio : Form
    {
        int iId, stockId;
        bool compare = false;
        DBStock db = new DBStock();
        public frmPortfolio()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (stockId == 0) return;
            if (iId > 0) db.PortfolioEdit(iId, stockId, Convert.ToDecimal(txtBuyPrice.Text), Convert.ToDecimal(txtRealBuyPrice.Text), dtRealBuyDate.Value, Convert.ToDecimal(txtSalePrice.Text), Convert.ToDecimal(txtRealSalePrice.Text), dtRealSaleDate.Value);
            else db.PortfolioInsert(stockId, Convert.ToDecimal(txtBuyPrice.Text), Convert.ToDecimal(txtRealBuyPrice.Text), dtRealBuyDate.Value, Convert.ToDecimal(txtSalePrice.Text), Convert.ToDecimal(txtRealSalePrice.Text), dtRealSaleDate.Value);
            DataLoad();
            DataReset();
        }

        private void SetTitle()
        {
            dtStart.Value = DateTime.Now.Date.AddDays(-7);
        }

        private void frmPortfolio_Load(object sender, EventArgs e)
        {
            SetTitle();
            DataLoad();
        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (compare) return;
                stockId = Convert.ToInt32(dgvList.Rows[e.RowIndex].Cells["StockId"].Value);
                iId = Convert.ToInt32(dgvList.Rows[e.RowIndex].Cells["Id"].Value);
                cboStock.SelectedValue = stockId;
                if (dgvList.Rows[e.RowIndex].Cells["BuyPrice"].Value != null)
                {
                    txtBuyPrice.Text = Convert.ToString(dgvList.Rows[e.RowIndex].Cells["BuyPrice"].Value);
                    txtRealBuyPrice.Text = Convert.ToString(dgvList.Rows[e.RowIndex].Cells["BuyRealPrice"].Value);
                    dtRealBuyDate.Value = Convert.ToDateTime(dgvList.Rows[e.RowIndex].Cells["BuyRealDate"].Value);
                    txtSalePrice.Text = Convert.ToString(dgvList.Rows[e.RowIndex].Cells["SalePrice"].Value);
                    txtRealSalePrice.Text = Convert.ToString(dgvList.Rows[e.RowIndex].Cells["SaleRealPrice"].Value);
                    dtRealSaleDate.Value = Convert.ToDateTime(dgvList.Rows[e.RowIndex].Cells["SaleRealDate"].Value);
                }
                if (chkPriceHistory.Checked)
                {
                    frmPriceHistory frm = new frmPriceHistory();
                    frm.days = 10;
                    frm.lstId = new List<int>();
                    frm.lstId.Add(stockId);
                    frm.RefreshAction(true);
                    frm.Show();
                }

                if (chkStockHolder.Checked)
                {
                    frmStockHolder frm = new frmStockHolder();
                    frm.stockId = stockId;
                    frm.Show();
                }

            }
            catch (Exception) { }

        }

        private void DataLoad()
        {
            dgvList.DataSource = db.PortfolioList();

            cboStock.ValueMember = "Id";
            cboStock.DisplayMember = "Code";
            cboStock.DataSource = db.StockList(0, true);
            stockId = (int)cboStock.SelectedValue;
        }

        private void DataReset()
        {
            iId = 0;
            stockId = -1;
            txtBuyPrice.Text = "";
            cboStock.SelectedIndex = 0;
        }

        private void cboStock_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (stockId == 0) return;
            stockId = (int)cboStock.SelectedValue;
        }

        private void frmPortfolio_SizeChanged(object sender, EventArgs e)
        {
            dgvList.Width = this.Width - dgvList.Location.X;
            dgvList.Height = this.Height - dgvList.Location.Y;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            db.PortfolioDelete(iId);
            btnReset.PerformClick();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            DataReset();
            DataLoad();
            compare = false;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            dgvList.DataSource = db.PortfolioCompare(dtStart.Value);
            compare = true;
        }
    }
}
