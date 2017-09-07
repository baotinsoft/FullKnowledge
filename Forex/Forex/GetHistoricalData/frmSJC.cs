using GetHistoricalData.DBContext;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace GetHistoricalData
{
    public partial class frmSJC : Form
    {
        DBHistorical db = new DBHistorical();
        public frmSJC()
        {
            InitializeComponent();
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            //ParseSJC(GetHistoricalData("http://www2.sjc.com.vn/xml/tygiavang.xml", null, null));
            //ParseForex(GetHistoricalData("http://vietcombank.com.vn/", "ctl00_Content_HomeSideBar_RatesBox_ExchangeRates_ExrateView", "</table>"));

            string rate = GetHistoricalData("http://vietcombank.com.vn/InterestRates/", "<th>Kỳ hạn</th>", "</table>");
        }

        private string GetHistoricalData(string url, string searchBegin, string searchEnd)
        {
            var rqst = (HttpWebRequest)WebRequest.Create(url);

            rqst.Method = "POST";
            rqst.ContentType = "text/xml";
            rqst.ContentLength = 0;
            rqst.Timeout = 3000;


            var rspns = (HttpWebResponse)rqst.GetResponse();
            var reader = new StreamReader(rspns.GetResponseStream());
            string tmp = reader.ReadToEnd();
            int posBegin, posEnd;
            if (searchBegin == null)
                posBegin = 0;
            else
                posBegin = tmp.IndexOf(searchBegin);

            if (searchEnd == null)
                posEnd = tmp.Length;
            else
                posEnd = tmp.IndexOf(searchEnd, posBegin+1);

            return tmp.Substring(posBegin, posEnd - posBegin - 1);
        }

        private void ParseSJC(string historical)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(historical);

            XmlNodeList firstNode = xmlDoc.GetElementsByTagName("ratelist");
            DateTime priceDate;
            bool isAddChildren;
            foreach (XmlNode parentNode in firstNode)
            {
                isAddChildren = true;
                priceDate = Convert.ToDateTime(parentNode.Attributes["updated"].Value);
                foreach (XmlNode childrenNode in parentNode)
                {                    
                    foreach (XmlNode grandchild in childrenNode)
                    {
                        if (isAddChildren)
                        {
                            db.SJCAdd(priceDate, Convert.ToDecimal(grandchild.Attributes["buy"].Value), Convert.ToDecimal(grandchild.Attributes["sell"].Value));
                            isAddChildren = false;
                        }
                        db.SJCDetailAdd(priceDate, Convert.ToDecimal(grandchild.Attributes["buy"].Value), Convert.ToDecimal(grandchild.Attributes["sell"].Value), childrenNode.Attributes["name"].Value, grandchild.Attributes["type"].Value);
                    }

                }
            }
        }

        private void ParseForex(string historical)
        {
            int pos = historical.IndexOf("<tr", 50);
            pos = historical.IndexOf("<tr", pos + 10);
            historical = "<root>" + historical.Substring(pos, historical.Length - pos) + "</root>";

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(historical);

            string type;
            decimal buy, transfer, sell;

            XmlNodeList firstNode = xmlDoc.GetElementsByTagName("root");
            foreach (XmlNode parentNode in firstNode)
            {
                foreach (XmlNode childrenNode in parentNode)
                {
                    type = childrenNode.ChildNodes[0].InnerText;
                    buy = Convert.ToDecimal(childrenNode.ChildNodes[1].InnerText);
                    transfer = Convert.ToDecimal(childrenNode.ChildNodes[2].InnerText);
                    sell = Convert.ToDecimal(childrenNode.ChildNodes[3].InnerText);
                    db.ForexAdd(buy, transfer, sell, type);
                }
            }
        }

        private void frmGet_Load(object sender, EventArgs e)
        {
            SetSize();
            SetTitle();
            ParseSJC(GetHistoricalData("http://www2.sjc.com.vn/xml/tygiavang.xml", null, null));
            ParseForex(GetHistoricalData("http://vietcombank.com.vn/", "ctl00_Content_HomeSideBar_RatesBox_ExchangeRates_ExrateView", "</table>"));
            dgvMonthYear.DataSource = db.SJCMonthYear(Convert.ToInt32(cboMonths.Text), Convert.ToInt32(cboYears.Text));
            dgvMonth.DataSource = db.SJCMonth(Convert.ToInt32(cboMonths.Text), Convert.ToInt32(cboYears.Text));
            dgvDisplay.DataSource = db.SJCList(Convert.ToInt32(cboDays.Text));
            dgvWeekDay.DataSource = db.SJCWeekDay(Convert.ToInt32(cboMonths.Text), Convert.ToInt32(cboYears.Text));
            //Application.Exit();
        }

        private void SetTitle()
        {
            dgvMonthYear.SizeFile = this.Name + "_Avg";
            dgvMonth.SizeFile = this.Name + "_MonthAvg";
        }

        private void frmGold_SizeChanged(object sender, EventArgs e)
        {
            SetSize();
        }

        private void SetSize()
        {
            //dgvAvg.Width = this.Width - dgvAvg.Location.X;
            //dgvMonthAvg.Width = dgvAvg.Width;
            dgvMonth.Height = this.Height - dgvMonth.Location.Y;
            dgvWeekDay.Height = dgvMonth.Height;
        }

        private void btnDisplayNear_Click(object sender, EventArgs e)
        {
            dgvMonthYear.DataSource = db.SJCMonthYear(Convert.ToInt32(cboMonths.Text), Convert.ToInt32(cboYears.Text));
            dgvMonth.DataSource = db.SJCMonth(Convert.ToInt32(cboMonths.Text), Convert.ToInt32(cboYears.Text));
            dgvDisplay.DataSource = db.SJCList(Convert.ToInt32(cboDays.Text));
            dgvWeekDay.DataSource = db.SJCWeekDay(Convert.ToInt32(cboMonths.Text), Convert.ToInt32(cboYears.Text));
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            try
            {
                txtComparePrice.Text = Convert.ToDecimal(dgvDisplay.arrReturn[2]).ToString(",000,000.00");
                txtPrice.Text = Convert.ToDecimal(txtPrice.Text).ToString(",000,000.00");
                txtResult.Text = (Convert.ToDecimal(txtQuan.Text) * (Convert.ToDecimal(txtComparePrice.Text) - Convert.ToDecimal(txtPrice.Text))).ToString(",000,000.00");
            }
            catch (Exception) { }
        }

        private void dgvDisplay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtComparePrice.Text = Convert.ToDecimal(dgvDisplay.arrReturn[2]).ToString(",000,000.00");
        }

        private void btnGold_Click(object sender, EventArgs e)
        {
            frmGold frm = new frmGold();
            frm.Show();
        }
    }
}
