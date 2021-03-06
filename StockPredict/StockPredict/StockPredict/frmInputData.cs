using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using WindowFramework;
using StockPredict.DBContext;
using AmiBroker;

using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Reflection;
using System.Runtime.InteropServices;
using java.util.zip;
using java.util;
using java.io;

namespace StockPredict
{
    public partial class frmInputData : Form
    {
        public bool isTask, isAll;
        public int previousDays;
        DBStock db = new DBStock();
        string pathCafef = Application.StartupPath + @"\Data\cafef";
        public frmInputData(bool exit, int days, bool all)
        {
            InitializeComponent();
            isTask = exit;
            if (days > 0) previousDays = days;
            else previousDays = Convert.ToInt32(DateTime.Now.Date.Subtract(db.PriceLastDate().Date).TotalDays);
            isAll = all;
            chkAll.Checked = all;
            txtDays.Text = previousDays.ToString();
        }

        private void frmInputData_Load(object sender, EventArgs e)
        {
            if (isTask)
            {
                this.Hide();
                btnDownload.PerformClick();
                btnCafef.PerformClick();
                Application.Exit();
            }
            lblLastDate.Text = "Ngày sau cùng: " + db.PriceLastDate().ToString("dd/MM/yyyy");
        }


        private void btnBSC_Click(object sender, EventArgs e)
        {
            string sDir = @"D:\Stock\Data\BSC";
            odlgDataFile.InitialDirectory = sDir;
            if (odlgDataFile.ShowDialog() == DialogResult.OK)
            {
                txtComment.Text = "Đang xử lý nhập liệu từ BSC...";
                txtComment.Refresh();
                string sFile = odlgDataFile.FileName;
                ParseData.UpdateStockData("", sFile, true);
                txtComment.Text = "Đã xử lý xong nhập liệu từ BSC!";
            }
        }

        private void btnHSC_Click(object sender, EventArgs e)
        {
            txtComment.Text = "Đang xử lý nhập liệu từ HSC...";
            txtComment.Refresh();
            string sDir = @"D:\Stock\Data\HSC";
            WebLib.OverBidOffer(sDir);
            txtComment.Text = "Đã xử lý xong nhập liệu từ HSC!";
        }

        private void btnHSX_Click(object sender, EventArgs e)
        {
            txtComment.Text = "Đang xử lý nhập liệu từ HSX...";
            txtComment.Refresh();
            string sDir = @"D:\Stock\Data\HSX";
            //MessageBox.Show(sDir);
            WebLib.HSX(sDir);
            txtComment.Text = "Đã xử lý xong nhập liệu từ HSX!";
        }

        private void DownloadFile(string url, string file)
        {
            if (!LibWeb.DownloadFile(url, pathCafef + @"\" + file))
            {
                txtComment.AppendText("Không lấy được dữ liệu EOD từ cafef.vn!");
                txtComment.AppendText(Environment.NewLine);
            }
            else
            {
                txtComment.AppendText("Lấy xong dữ liệu EOD từ cafef.vn!");
                txtComment.AppendText(Environment.NewLine);
            }

        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            previousDays = (int)txtDays.result;
            string url, file;
            txtComment.Text = "Đang lấy dữ liệu hiện hành từ Internet...";
            txtComment.AppendText(Environment.NewLine);
            txtComment.Refresh();

            // get info from hsx.vn
            if (!WebLib.HttpPost("http://www.hsx.vn/hsx/Modules/Giaodich/Live3Price.aspx", Application.StartupPath + @"\Data\hsx\"))
            {
                txtComment.AppendText("Không lấy được dữ liệu từ hsx.vn!");
                txtComment.AppendText(Environment.NewLine);
            }
            else
            {
                txtComment.AppendText("Lấy xong dữ liệu từ hsx.vn!");
                txtComment.AppendText(Environment.NewLine);
            }

            // get EOD info from cafef
            //if (LibWeb.DownloadFile("http://images1.cafef.vn/data/" + DateTime.Now.AddDays(-1).ToString("yyyyMMdd") + "/CafeF.SolieuGD." + DateTime.Now.AddDays(-1).ToString("ddMMyyyy") + ".zip", @"D:\"))
            if (isAll)
            {
                //http://images1.cafef.vn/data/20140625/CafeF.SolieuGD.Upto25062014.zip
                url = "http://images1.cafef.vn/data/" + DateTime.Now.AddDays(-previousDays).ToString("yyyyMMdd") + "/CafeF.SolieuGD.Upto" + DateTime.Now.AddDays(-previousDays).ToString("ddMMyyyy") + ".zip";
                file = "CafeF.SolieuGD.Upto" + DateTime.Now.AddDays(-previousDays).ToString("ddMMyyyy") + ".zip";
                DownloadFile(url, file);
            }
            else
            {
                for (int i = 0; i <= previousDays; i++)
                {
                    url = "http://images1.cafef.vn/data/" + DateTime.Now.AddDays(-i).ToString("yyyyMMdd") + "/CafeF.SolieuGD." + DateTime.Now.AddDays(-i).ToString("ddMMyyyy") + ".zip";
                    file = "CafeF.SolieuGD." + DateTime.Now.AddDays(-i).ToString("ddMMyyyy") + ".zip";
                    DownloadFile(url, file);
                }
            }

            // get Index info from cafef
            if (isAll)
            {
                //http://images1.cafef.vn/data/20140625/CafeF.Index.Upto25062014.zip
                url = "http://images1.cafef.vn/data/" + DateTime.Now.AddDays(-previousDays).ToString("yyyyMMdd") + "/CafeF.Index.Upto" + DateTime.Now.AddDays(-previousDays).ToString("ddMMyyyy") + ".zip";
                file = "CafeF.Index.Upto" + DateTime.Now.AddDays(-previousDays).ToString("ddMMyyyy") + ".zip";
                DownloadFile(url, file);
            }
            else
            {
                for (int i = 0; i <= previousDays; i++)
                {
                    url = "http://images1.cafef.vn/data/" + DateTime.Now.AddDays(-i).ToString("yyyyMMdd") + "/CafeF.Index." + DateTime.Now.AddDays(-i).ToString("ddMMyyyy") + ".zip";
                    file = "CafeF.Index." + DateTime.Now.AddDays(-i).ToString("ddMMyyyy") + ".zip";
                    DownloadFile(url, file);
                }
            }

          
            // get info from hsc.com.vn
            if (!WebLib.HttpPost("http://hsc.com.vn/Market.aspx", Application.StartupPath + @"\Data\hsc\"))
            {
                txtComment.AppendText("Không lấy được dữ liệu từ hsc.com.vn!\n");
                txtComment.AppendText(Environment.NewLine);
                txtComment.AppendText("Hoàn tất!");
            }
            else
            {
                txtComment.AppendText("Lấy xong dữ liệu từ hsc.com.vn!");
                txtComment.AppendText(Environment.NewLine);
                txtComment.AppendText("Hoàn tất!");
            }
        }

        private void btnFinanceTVSI_Click(object sender, EventArgs e)
        {
            txtComment.AppendText("Đang lấy được dữ liệu tài chính từ tvsi.com.vn ...");
            txtComment.Refresh();
            // get info from hsc.com.vn
            if (!WebLib.GetFinanceAll("http://www.tvsi.com.vn/company.asp?MCK=", Application.StartupPath + @"\Data\Finance\"))
            {
                txtComment.AppendText("Không lấy được dữ liệu tài chính từ tvsi.com.vn!\n");
                txtComment.AppendText(Environment.NewLine);
                txtComment.AppendText("Hoàn tất!");
            }
            else
            {
                txtComment.AppendText("Lấy xong dữ liệu tài chính từ tvsi.com.vn!");
                txtComment.AppendText(Environment.NewLine);
                txtComment.AppendText("Hoàn tất!");
            }
        }

        private void btnHCM_Click(object sender, EventArgs e)
        {
            txtComment.Text = "Đang xử lý nhập thông tin các công ty của HCM từ HSX...";
            txtComment.Refresh();
            string sDir = Application.StartupPath + @"\Data\HCM";
            WebLib.HCMCompany(sDir);
            txtComment.Text = "Đã xử lý xong nhập thông tin các công ty của HCM từ HSX!";
        }

        private void btnHN_Click(object sender, EventArgs e)
        {
            txtComment.Text = "Đang xử lý nhập thông tin các công ty của HN từ hastc.org.vn ...";
            txtComment.Refresh();
            string sDir = Application.StartupPath + @"\Data\HN";
            WebLib.HNCompany(sDir);
            txtComment.Text = "Đã xử lý xong nhập thông tin các công ty của HN từ hastc.org.vn!";

        }

        private void btnInputTVSI_Click(object sender, EventArgs e)
        {
            txtComment.Text = "Đang xử lý nhập thông tin tài chính từ tvsi.com.vn ...";
            txtComment.Refresh();
            string sDir = Application.StartupPath + @"\Data\Finance";
            WebLib.FinanceTVSI(sDir);
            txtComment.Text = "Đã xử lý xong nhập thông tin tài chính từ tvsi.com.vn!";
        }

        private void btnLiveHCM_Click(object sender, EventArgs e)
        {
            txtComment.Text = "Đang xử lý nhập giá CK HCM (hsx.org) và HN (hastc.org.vn) vào Live ...";
            txtComment.Refresh();
            string sDir = Application.StartupPath + @"\Data\Live\";
            WebLib.ExeLivePrice(sDir);
            txtComment.Text = "Đã xử lý xong nhập giá CK HCM (hsx.org) và HN (hastc.org.vn) vào Live!";
        }

        private void btniStock_Click(object sender, EventArgs e)
        {
            txtComment.Text = "Đang xử lý nhập giá CK từ iStock vào DB ...";
            txtComment.Refresh();
            string sDir = Application.StartupPath + @"\Data\iStock";
            WebLib.iStockPrice(sDir);
            txtComment.Text = "Đã xử lý xong nhập giá CK từ iStock vào DB!";
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtComment.Text = "Đang xóa toàn bộ dữ liệu giá cũ ...";
            txtComment.Refresh();
            WebLib.ResetPrice();
            txtComment.Text = "Đã xóa xong toàn bộ dữ liệu giá cũ!";
        }

        private void btnGoolge_Click(object sender, EventArgs e)
        {
            Uri url = new Uri("http://www.example.com");
            int position = GoolgeLib.GetPosition(url, "ebook");
            txtComment.Text = "Vtri:" + position;
            txtComment.Text += GoolgeLib.GetString(url, "ebook");
        }

        public List<ZipEntry> GetZipFiles(ZipFile zipfil)
        {
            List<ZipEntry> lstZip = new List<ZipEntry>();
            Enumeration zipEnum = zipfil.entries();
            while (zipEnum.hasMoreElements())
            {
                ZipEntry zip = (ZipEntry)zipEnum.nextElement();
                lstZip.Add(zip);
            }
            return lstZip;
        }

        private string fileExt = ".csv";
        private void btnCafef_Click(object sender, EventArgs e)
        {
            //unzip
            string path = pathCafef;
            List<string> zipFiles = Directory.GetFiles(path).Where(v => v.Contains(".zip")).ToList();
            if (zipFiles.Count > 0)
            {
                string[] Files = Directory.GetFiles(path, fileExt);
                foreach (string file in Files) System.IO.File.Delete(file);
                foreach (string file in zipFiles)
                {
                    LibTools.Unzip(file, path);
                }
            }
            //store data to db
            List<string> files = Directory.GetFiles(path).Where(v => v.Contains(fileExt)).ToList();
            if (files.Count > 0)
            {
                StreamReader read;
                string line;
                string[] args;
                DateTime dateInput, resultDate = db.PriceLastDate();
                string market;
                txtComment.Text = "";
                foreach (string file in files)
                {
                    txtComment.Text += "Xử lý file: " + file + "\r\n";
                    read = new StreamReader(file);
                    market = file.Split('.')[1];
                    line = read.ReadLine(); //skip first line
                    while ((line = read.ReadLine()) != null)
                    {
                        args = line.Split(',');
                        //<Ticker>,<DTYYYYMMDD>,<Open>,<High>,<Low>,<Close>,<Volume>
                        //AAA,20140624,17.7000,17.8000,17.6000,17.8000,137500
                        dateInput = DateTime.ParseExact(args[1], "yyyyMMdd", null);

                        if (dateInput <= resultDate) break;

                        db.PriceInsert(db.StockId(args[0].Trim(), market), dateInput, Convert.ToDecimal(args[2]),
                        Convert.ToDecimal(args[3]), Convert.ToDecimal(args[4]), Convert.ToDecimal(args[5]), Convert.ToInt32(args[6]));
                    }
                    read.Close();
                    txtComment.Text += "Xử lý xong!\r\n";
                    //import into Ami Broker
                    //System.Type objType = System.Type.GetTypeFromProgID("Broker.Application");

                    //dynamic comObject = System.Activator.CreateInstance(objType);
                    //int result = comObject.Import(0, file, "cafef.format");
                    //if (result == 0)
                    //{
                    //    comObject.RefreshAll();
                    //    comObject.SaveDatabase();
                    //}
                    //txtComment.Text += "Import AmiBroker xong!\r\n ";

                }
            }

            //clear cafef folder
            try
            {
                Array.ForEach(Directory.GetFiles(path),
                  delegate(string pathItem) { System.IO.File.Delete(pathItem); });
            }
            catch (Exception) { }
            txtComment.Text += "Hoàn tất!";
            lblLastDate.Text = "Ngày sau cùng: " + db.PriceLastDate().ToString("dd/MM/yyyy");
        }


        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            isAll = chkAll.Checked;
        }

        private void mnuChangePrice_Click(object sender, EventArgs e)
        {
            (new frmViewInfo_ChangePrice()).Show();
        }


        private void mnuFinance_Click(object sender, EventArgs e)
        {
            (new frmViewInfo_Finance()).Show();
        }

        private void mnuMarket_Click(object sender, EventArgs e)
        {
            (new frmViewInfo_Market()).Show();
        }


        private void mnuMonitorStock_Click(object sender, EventArgs e)
        {
            (new frmStockMonitor()).Show();
        }

        private void priceHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new frmPriceHistory()).Show();
        }

        private void mnuPortfofio_Click(object sender, EventArgs e)
        {
            (new frmPortfolio()).Show();
        }

        private void mnuStockHolder_Click(object sender, EventArgs e)
        {
            (new frmStockHolder()).Show();
        }

        private void txtDays_PressEnter(object sender, EventArgs e)
        {
            try
            {
                lblFromDate.Text = Convert.ToDateTime(DateTime.Now.AddDays(-Convert.ToInt32(txtDays.Text))).ToString();
            }
            catch (Exception) { }
        }
    }
}