using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace StockPredict
{
    public partial class frmExport2CSV : Form
    {
        public frmExport2CSV()
        {
            InitializeComponent();
            ADOLib.MSList(cboStockCode, "Provider=SQLNCLI.1;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=StockPredict;Data Source=localhost");
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (txtStockCode.Text != "")
            {
                fdlgBrowse.SelectedPath = System.IO.Directory.GetCurrentDirectory();
                DialogResult result = fdlgBrowse.ShowDialog();
                if (result == DialogResult.OK)
                {
                    ADOMDLib.ExportCSV(txtStockCode.Text, fdlgBrowse.SelectedPath);
                }
            }
            else
                MessageBox.Show("Nhập mã stock vào TextBox!");
        }

        private void btnExportBoth_Click(object sender, EventArgs e)
        {
            if (cboStockCode.Text != "")
            {
                fdlgBrowse.SelectedPath = System.IO.Directory.GetCurrentDirectory();
                DialogResult result = fdlgBrowse.ShowDialog();
                if (result == DialogResult.OK)
                {
                    //ADOMDLib.Export2CSV(cboStockCode.Text, fdlgBrowse.SelectedPath);
                    ADOMDLib.ExportMulti2CSV(cboStockCode.Text, fdlgBrowse.SelectedPath);                    
                }
            }
            else
                MessageBox.Show("Chọn mã stock trong ComboBox!");
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (txtStockCode.Text != "")
            {
                odlgOpen.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
                DialogResult result = odlgOpen.ShowDialog();
                if (result == DialogResult.OK)
                {
                    ParseData.ParseFromFile(odlgOpen.FileName);
                }
            }
            else
                MessageBox.Show("Nhập mã stock vào TextBox!");
        }
    }
}