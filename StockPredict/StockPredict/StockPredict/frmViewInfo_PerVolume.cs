using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using StockPredict.DBContext;
using WindowFramework;

namespace StockPredict
{
    public partial class frmViewInfo_PerVolume : Form
    {        
        DBStock db = new DBStock();
        public frmViewInfo_PerVolume()
        {
            InitializeComponent();
        }

        private void frmViewInfo_PerVolume_Load(object sender, EventArgs e)
        {
            MatchSize();
            LoadData(0);
        }

        //************* Data **************

        private void ResetData()
        {
            cboTop.Text = "0";
            chkAll.Checked = false;
        }

        private void LoadData(int iTop)
        {
            int iMarket=0, iGroupFrom=0, iGroupTo=0, iBranchFrom=0, iBranchTo=0;

            if (!cboMarket.Enabled)
                iMarket = 0;
            else
                iMarket = Convert.ToInt32(cboMarket.SelectedValue);

            if (!cboGroupFrom.Enabled)
                iGroupFrom = 0;
            else
            {
                iGroupFrom = Convert.ToInt32(cboGroupFrom.SelectedValue);
                iGroupTo = Convert.ToInt32(cboGroupTo.SelectedValue);
                if (!cboBranchFrom.Enabled)
                    iBranchFrom = 0;
                else
                {
                    iBranchFrom = Convert.ToInt32(cboBranchFrom.SelectedValue);
                    iBranchTo = Convert.ToInt32(cboBranchTo.SelectedValue);
                }
            }

            DataTable table = db.PerVolumeASCList(iTop, iMarket, iGroupFrom, iGroupTo, iBranchFrom, iBranchTo);

            dgvAsc.DataSource = table;

            if (dgvAsc.Columns.Count > 0)
            {
                dgvAsc.Columns[0].Visible = false;
                dgvAsc.Columns[1].Visible = false;
                dgvAsc.Columns[2].Visible = false;
                dgvAsc.Columns[3].Visible = false;
                //dgvAsc.Columns[1].HeaderText = "Kho";
            }

            table = db.PerVolumeDESCList(iTop);

            dgvDesc.DataSource = table;

            if (dgvDesc.Columns.Count > 0)
            {
                dgvDesc.Columns[0].Visible = false;
                dgvDesc.Columns[1].Visible = false;
                dgvDesc.Columns[2].Visible = false;
                dgvDesc.Columns[3].Visible = false;
                //dgvAsc.Columns[1].HeaderText = "Kho";
            }

            table = db.MarketList();
            cboMarket.DataSource = table;
            cboMarket.DisplayMember = "CodeNum";
            cboMarket.ValueMember = "Id";

            table = db.BranchGroupList(0);
            cboGroupFrom.DataSource = table;
            cboGroupFrom.DisplayMember = "Branch1";
            cboGroupFrom.ValueMember = "Id";

            table = db.BranchGroupList(0);
            cboGroupTo.DataSource = table;
            cboGroupTo.DisplayMember = "Branch1";
            cboGroupTo.ValueMember = "Id";



        }

        private void MatchSize()
        {
            dgvAsc.Height = (frmViewInfo_PerVolume.ActiveForm.Height - 160) / 2;
            dgvDesc.Height = (frmViewInfo_PerVolume.ActiveForm.Height - 160) / 2;
            dgvAsc.Width = frmViewInfo_PerVolume.ActiveForm.Width - 20;
            dgvDesc.Width = frmViewInfo_PerVolume.ActiveForm.Width - 20;

            dgvAsc.Top = 110;
            dgvDesc.Top = dgvAsc.Top + dgvAsc.Height + 10;
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked)
            {
                LoadData(0);
                cboTop.Enabled = false;
            }
            else cboTop.Enabled = true;
        }

        private void cboTop_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData(Convert.ToInt32(cboTop.Text));
        }

        private void frmViewInfo_PerVolume_Resize(object sender, EventArgs e)
        {
            MatchSize();
        }

        private void cboTop_Enter(object sender, EventArgs e)
        {
            LoadData(Convert.ToInt32(cboTop.Text));

        }

        private void cboGroupTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboGroupTo.SelectedValue.ToString().IndexOf("System") < 0)
            {
                DataTable table = db.BranchList(Convert.ToInt32(cboGroupFrom.SelectedValue), Convert.ToInt32(cboGroupTo.SelectedValue));
                cboBranchFrom.DataSource = table;
                cboBranchFrom.DisplayMember = "Branch1";
                cboBranchFrom.ValueMember = "Id";

                table = db.BranchList(Convert.ToInt32(cboGroupFrom.SelectedValue), Convert.ToInt32(cboGroupTo.SelectedValue));
                cboBranchTo.DataSource = table;
                cboBranchTo.DisplayMember = "Branch1";
                cboBranchTo.ValueMember = "Id";
            }
        }

 
        private void chkMarket_CheckedChanged(object sender, EventArgs e)
        {
            cboMarket.Enabled = chkMarket.Checked;
        }

        private void chkGroup_CheckedChanged(object sender, EventArgs e)
        {
            cboGroupFrom.Enabled = chkGroup.Checked;
            cboGroupTo.Enabled = chkGroup.Checked;
        }

        private void chkBranch_CheckedChanged(object sender, EventArgs e)
        {
            cboBranchFrom.Enabled = chkBranch.Checked;
            cboBranchTo.Enabled = chkBranch.Checked;
        }



    }
}
