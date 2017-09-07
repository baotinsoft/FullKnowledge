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
    public partial class frmViewInfo_Finance : Form
    {
        DBStock db = new DBStock();
        public frmViewInfo_Finance()
        {
            InitializeComponent();
        }

        private void frmViewInfo_Finance_Load(object sender, EventArgs e)
        {
            LoadData();
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
            DataTable table = db.BranchList(0, 0);
            lstBranch.DataSource = table;
            lstBranch.DisplayMember = "Branch1";
            lstBranch.ValueMember = "Id";

            table = db.ParameterListShort(0);
            lstParameter.DataSource = table;
            lstParameter.DisplayMember = "Parameter1";
            lstParameter.ValueMember = "Id";

        }

        //private string MergeSelected(ListBox lst)
        //{
        //    string sReturn = "";
        //    int iCount = lst.SelectedIndices.Count;
        //    System.Data.DataRowView drv;
        //    for (int i = 0; i < iCount; i++)
        //    {
        //        lst.Items[lst.SelectedIndices[i]].GetType();
        //        drv = (System.Data.DataRowView)lst.Items[lst.SelectedIndices[i]];
        //        sReturn += drv.Row[0] + ",";
        //    }
        //    sReturn = sReturn.Substring(0, sReturn.Length - 1);
        //    return sReturn;
        //}

        private void View()
        {
            DataTable table;


            // Parameter
            //string sParamList = MergeSelected(lstParameter);


            // Stock
            if (lstStock.SelectedIndices.Count > 0)
            {
                table = db.FinanceList(1, lstStock.SelectedIndices.OfType<int>().ToList());
                dgvStock.DataSource = table;
                if (dgvStock.Columns.Count > 0)
                {
                    dgvStock.Columns[1].Visible = false;
                    dgvStock.Columns[2].Visible = false;
                }
            }

            // Branch
            if (lstBranch.SelectedIndices.Count > 0)
            {
                table = db.FinanceList(2, lstBranch.SelectedIndices.OfType<int>().ToList());

                dgvBranch.DataSource = table;
                if (dgvBranch.Columns.Count > 0)
                {
                    dgvBranch.Columns[1].Visible = false;
                    dgvBranch.Columns[2].Visible = false;
                }
            }
        
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            View();
        }

        private void btnUpdateStock_Click(object sender, EventArgs e)
        {
            DataTable table;
            if (chkAll.Checked)
            {
                table = db.StockList(0,true);
            }
            else
            {
                // Branch
                string sBranchList = "";
                int iCount = lstBranch.SelectedIndices.Count;
                System.Data.DataRowView drv;
                for (int i = 0; i < iCount; i++)
                {
                    lstBranch.Items[lstBranch.SelectedIndices[i]].GetType();
                    drv = (System.Data.DataRowView)lstBranch.Items[lstBranch.SelectedIndices[i]];
                    sBranchList += drv.Row[0] + ",";
                }
                sBranchList = sBranchList.Substring(0, sBranchList.Length - 1);

                table = db.StockListbyBranch(sBranchList);
            }
            lstStock.DataSource = table;
            lstStock.DisplayMember = "Stock";
            lstStock.ValueMember = "Id";
        }

        private void btnDefaultSave_Click(object sender, EventArgs e)
        {
            //string sDefault = MergeSelected(lstBranch);
            //db.ParameterDefaultEdit(4, sDefault);

            //sDefault = MergeSelected(lstParameter);
            //db.ParameterDefaultEdit(5, sDefault);

            //sDefault = MergeSelected(lstStock);
            //db.ParameterDefaultEdit(6, sDefault);
        }

        private void btnDefault_Click(object sender, EventArgs e)
        {
            // Branch
            DataTable table = db.ParameterDefaultList(4);
            string sDefault = table.Rows[0][0].ToString();
            string []arrDefault = sDefault.Split(',');
            for (int i=0;i<arrDefault.Length;i++)
                lstBranch.SelectedValue = Convert.ToInt32(arrDefault[i]);
            table = db.StockListbyBranch(sDefault);
            lstStock.DataSource = table;
            lstStock.DisplayMember = "Stock";
            lstStock.ValueMember = "Id";

            // Parameter
            table = db.ParameterDefaultList(5);
            sDefault = table.Rows[0][0].ToString();
            arrDefault = sDefault.Split(',');
            for (int i = 0; i < arrDefault.Length; i++)
                lstParameter.SelectedValue = Convert.ToInt32(arrDefault[i]);

            // Stock
            table = db.ParameterDefaultList(6);
            sDefault = table.Rows[0][0].ToString();
            arrDefault = sDefault.Split(',');
            for (int i = 0; i < arrDefault.Length; i++)
                lstStock.SelectedValue = Convert.ToInt32(arrDefault[i]);
        }


    }
}
