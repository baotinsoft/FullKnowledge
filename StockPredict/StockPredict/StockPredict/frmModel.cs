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
//using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;


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
            txtProgress.Text = "Đang kết nối ...";
            txtProgress.Refresh();
            if (svr.Connected)
            {
                btnConnect.Text = "1. Kết nối";
                svr.Disconnect();
                btnMiningModel.Enabled = false;
                btnProcess.Enabled = false;
                btnUpdateTrain.Enabled = false;
            }
            else
            {
                btnConnect.Text = "1. Thoát kết nối";
                svr = ADOLib.ConnectServer(txtConnectStr.Text);
                btnMiningModel.Enabled = true;
                btnProcess.Enabled = true;
                btnUpdateTrain.Enabled = true;
            }
            txtProgress.Text = "Kết nối xong!";
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
            txtProgress.Text = "Đang tạo mô hình ...";
            txtProgress.Refresh();

            if (!(txtStockCode.Text == null))
            {
                ADOLib.CreateMS(svr, txtStockCode.Text, chkAll.Checked, dtpFrom.Value, dtpTo.Value, chkMulti.Checked);
            }
            else MessageBox.Show("Bạn cần nhập mã chứng khoán!");
            txtProgress.Text = "Tạo xong mô hình!";
        }


        private void btnProcess_Click(object sender, EventArgs e)
        {
            txtProgress.Text = "Đang xử lý ...";
            txtProgress.Refresh();

            ADOLib.ProcessTrainDB(svr, txtProgress);
            txtProgress.AppendText(Environment.NewLine);
            txtProgress.AppendText("Xử lý xong!");
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked)
            {
                dtpFrom.Enabled = false;
                dtpTo.Enabled = false;
            }
            else
            {
                dtpFrom.Enabled = true;
                dtpTo.Enabled = true;
            }
        }

        private void btnData_Click(object sender, EventArgs e)
        {
            if (odlgStock.ShowDialog() == DialogResult.OK)
            {
                string sFile = odlgStock.FileName;
                ParseData.UpdateStockData(txtStockCode.Text, sFile, chkAllData.Checked);
            }
        }

        private void btnUpdateTrain_Click(object sender, EventArgs e)
        {
            txtProgress.Text = "Đang cập nhật ...";
            txtProgress.Refresh();

            if (!(txtStockCode.Text == null))
            {
                ADOMDLib.ResetMulti(txtStockCode.Text, false);
                ADOLib.UpdateTrainDB(svr, txtStockCode.Text, chkAll.Checked, dtpFrom.Value, dtpTo.Value,chkMulti.Checked);
            }
            else MessageBox.Show("Bạn cần nhập mã chứng khoán!");
            txtProgress.Text = "Cập nhật xong!";
        }

        private void btnCompress_Click(object sender, EventArgs e)
        {
            txtProgress.Text = "Đang nén dữ liệu ...";
            if (odlgStock.ShowDialog() == DialogResult.OK)
            {
                string sFile = odlgStock.FileName;
                CompressLib.Compress(txtStockCode.Text, sFile);
            }
            txtProgress.Text = "Nén xong!";

        }

    }
}