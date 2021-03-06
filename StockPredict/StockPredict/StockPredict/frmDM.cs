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
    public partial class frmModel : Form
    {
        public Server svr;
        public Database db;
        public frmModel()
        {
            InitializeComponent();
            svr = new Server();
        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            txtProgress.Text = "Đang xử lý ...";
            if (svr.Connected)
            {
                btnConnect.Text = "1. Kết nối";
                svr.Disconnect();
                btnMiningModel.Enabled = false;
                btnProcess.Enabled = false;
            }
            else
            {
                btnConnect.Text = "1. Thoát kết nối";
                svr = ADOLib.ConnectServer(txtConnectStr.Text);
                btnMiningModel.Enabled = true;
                btnProcess.Enabled = true;
            }
            txtProgress.Text = "Xử lý xong!";
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
        private void btnMiningModel_Click(object sender, EventArgs e)
        {
            txtProgress.Text = "Đang xử lý ...";
            if (!(txtStockCode.Text == null))
            {
                ADOLib.CreateMS(svr, txtStockCode.Text);
            }
            txtProgress.Text = "Tạo xong mô hình!";
        }

        private void frmDM_Load(object sender, EventArgs e)
        {

        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            txtProgress.Text = "Đang xử lý ...";
            ADOLib.ProcessDB(svr, txtProgress);
            txtProgress.AppendText(Environment.NewLine);
            txtProgress.AppendText("Xử lý xong!");
        }

    }
}