using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Microsoft.AnalysisServices;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;

//using ADOLib;


namespace StockPredict
{
    public partial class frmForecast : Form
    {
        public Microsoft.AnalysisServices.Server svr;
        public Microsoft.AnalysisServices.Database db;
        const string strConnect = "Provider=SQLNCLI.1;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=StockPredict;Data Source=localhost";
        public frmForecast()
        {
            InitializeComponent();
            //svr = new Server();
            ADOLib.MSList(cboStock, strConnect);
        }
 
        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();

        }


        private void btnForcast_Click(object sender, EventArgs e)
        {
            if (cboStock.SelectedIndex == -1)
                MessageBox.Show("Bạn cần chọn mô hình của chứng khoán cần xử lý");
            else
            {
                txtProgress.Text = "Đang dự báo ...";
                int iMulti = Convert.ToInt16(txtNumber.Text);
                if (cboStock.SelectedIndex > -1)
                    ADOMDLib.ForecastTest(txtProgress, cboStock.Text, iMulti, chkAnalysis.Checked, chkServey.Checked, chkOver.Checked);
            }
        }

        private void btnResetMulti_Click(object sender, EventArgs e)
        {
            if (cboStock.SelectedIndex == -1)
                MessageBox.Show("Bạn cần chọn mô hình của chứng khoán cần xử lý");
            else
            {
                txtProgress.Text = "Đang xóa dữ liệu dự báo cũ ...";
                txtProgress.Refresh();
                ADOMDLib.ResetMulti(cboStock.Text, true);
                txtProgress.Text = "Hoàn tất việc xóa dữ liệu dự báo cũ ...";
            }
        }
 
    }
}