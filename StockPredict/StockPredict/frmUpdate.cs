using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Microsoft.AnalysisServices;
//using ADOLib;


namespace StockPredict
{
    public partial class frmUpdate : Form
    {
        public Server svr;
        public Database db;
        const string strConnect = "Provider=SQLNCLI.1;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=StockPredict;Data Source=localhost";
        public frmUpdate()
        {
            InitializeComponent();
            svr = new Server();
            ADOLib.MSList(cboStock, strConnect);
        }
 
        private void btnQuit_Click(object sender, EventArgs e)
        {
            try
            {
                if (null != this.svr)
                {
                    this.svr.Disconnect();
                }
            }
            finally
            {
                this.Close();
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (cboStock.SelectedIndex > -1)
            {
                txtProgress.Text = "Đang xử lý ...";
                ADOLib.ProcessUpdateMM(svr, cboStock.Text);
                txtProgress.Text ="Xử lý xong!";
            }
            else
                MessageBox.Show("Bạn chưa chọn mã chứng khoán!");
        }

        private void cmdInc_Click(object sender, EventArgs e)
        {
            txtProgress.Text = "Đang xử lý ...";
            odlgHisFile.ShowDialog();
            string sFile = odlgHisFile.FileName;
            ADOMDLib.IncProcess(cboStock.Text, sFile);
            txtProgress.Text = "Xử lý xong!";
        }

        private void btnUpdateAll_Click(object sender, EventArgs e)
        {
            txtProgress.Text = "Đang xử lý ...";
            odlgHisFile.ShowDialog();
            string sFile = odlgHisFile.FileName;
            ADOMDLib.IncAllProcess(cboStock.Text, sFile);
            txtProgress.Text = "Xử lý xong!";
        }



    }
}