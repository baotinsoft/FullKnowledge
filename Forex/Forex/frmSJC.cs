using Forex.DBContext;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Globalization;

namespace Forex
{
    public partial class frmSJC : Form
    {
        DBHistorical db = new DBHistorical();
        public bool exit;
        public frmSJC()
        {
            InitializeComponent();
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            //ParseSJC(GetHistoricalData("http://www.sjc.com.vn/xml/tygiavang.xml", null, null, 1));
            ParseForex(GetHistoricalData("http://vietcombank.com.vn/ExchangeRates/ExrateXML.aspx", "<ExrateList>", "</ExrateList>", 1));

            string rate = GetHistoricalData("http://vietcombank.com.vn/InterestRates/", "<th>Kỳ hạn</th>", "</table>", 2);
            //get old sjc
            List<DateTime> dates = db.SJCMissing(Convert.ToInt32(cboDays.Text));
            foreach(DateTime date in dates)
            {
                ParseHistorySJC(GetHistoricalData("http://www.giavangonline.com/goldhistory.php?date=" + date.Year + "-" + date.Month + "-" + date.Day, "<div id=\"sjcexchange\">", "</table>", 2));
            }
        }

        private string GetHistoricalData(string url, string searchBegin, string searchEnd, int type)
        {
            try
            {
                var rqst = (HttpWebRequest)WebRequest.Create(url);

                rqst.Method = "GET";
                switch (type)
                {
                    case 1:
                        rqst.ContentType = "text/xml";
                        break;
                    case 2:
                        rqst.ContentType = "text/html";
                        break;
                }
                
                //rqst.ContentLength = 0;
                //rqst.Timeout = 5000;


                var rspns = (HttpWebResponse)rqst.GetResponse();
                var reader = new StreamReader(rspns.GetResponseStream());
                string tmp = reader.ReadToEnd();
                int posBegin, posEnd;
                if (searchBegin == null)
                    posBegin = 0;
                else
                    posBegin = tmp.IndexOf(searchBegin);

                if (searchEnd == null)
                    posEnd = tmp.Length + 1;
                else
                    posEnd = tmp.IndexOf(searchEnd, posBegin + 1) + searchEnd.Length + 1;

                return tmp.Substring(posBegin, posEnd - posBegin - 1);
            }
            catch (Exception e) { }
            return "";
        }

        private void ParseSJC(string historical)
        {
            if (historical.Length == 0 || historical.Length < 1500) return;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(historical);

            XmlNodeList firstNode = xmlDoc.GetElementsByTagName("ratelist");
            DateTime priceDate;
            bool isAddChildren;
            string temp;
            foreach (XmlNode parentNode in firstNode)
            {
                isAddChildren = true;
                temp = parentNode.Attributes["updated"].Value;
                priceDate = DateTime.ParseExact(temp, "hh:mm:ss tt dd/MM/yyyy", null);
                decimal tempBuy, tempSell;
                foreach (XmlNode childrenNode in parentNode)
                {                    
                    foreach (XmlNode grandchild in childrenNode)
                    {
                        if (isAddChildren)
                        {
                            tempBuy = Convert.ToDecimal(grandchild.Attributes["buy"].Value.Replace(".", ""));
                            tempSell = Convert.ToDecimal(grandchild.Attributes["sell"].Value.Replace(".",""));
                            db.SJCAdd(priceDate, tempBuy, tempSell);
                            isAddChildren = false;
                        }
                        tempBuy = Convert.ToDecimal(grandchild.Attributes["buy"].Value.Replace(".", ""));
                        tempSell = Convert.ToDecimal(grandchild.Attributes["sell"].Value.Replace(".", ""));
                        db.SJCDetailAdd(priceDate, tempBuy, tempSell, childrenNode.Attributes["name"].Value, grandchild.Attributes["type"].Value);
                    }

                }
            }
        }

        string digit = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
        string group = CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator;
        private decimal ConvertS2N(string source)
        {
            //1,111.22
            int posDigit = source.IndexOf(digit); //.
            int posGroup = source.IndexOf(group); //,
            if (posDigit < posGroup) //the oppersite currentculture
            {
                source = source.Replace(digit, "");
                source = source.Replace(group, digit);
            }
            return Convert.ToDecimal(source);
        }

        private void ParseForex(string historical)
        {
            if (historical.Length == 0) return;

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(historical);

            string type = "";
            decimal buy = 0, transfer = 0, sell = 0;
                        
            XmlNodeList firstNode = xmlDoc.GetElementsByTagName("ExrateList");
            DateTime updateDate = Convert.ToDateTime(firstNode[0].ChildNodes[0].InnerText);
            foreach (XmlNode parentNode in firstNode)
            {
                foreach (XmlNode childrenNode in parentNode)
                {
                    if (childrenNode.Name == "Exrate")
                    {
                        type = childrenNode.Attributes[0].Value;
                        buy = ConvertS2N(childrenNode.Attributes[2].Value);
                        transfer = ConvertS2N(childrenNode.Attributes[3].Value);
                        sell = ConvertS2N(childrenNode.Attributes[4].Value);
                    }
                    if (!(buy == 0 || transfer == 0 || sell == 0))
                        db.ForexAdd(buy, transfer, sell, type, updateDate);
                }
            }
        }

        private void ParseVNForex(string historical)
        {
            if (historical.Length == 0) return;

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(historical + ">");

            string type;
            decimal buy, transfer, sell;
            DateTime date = DateTime.Now.Date;

            XmlNodeList rootNode = xmlDoc.GetElementsByTagName("ExrateList");
            foreach (XmlNode parentNode in rootNode)
            {
                foreach (XmlNode childrenNode in parentNode)
                {
                    if (childrenNode.Name == "DateTime")
                    {
                        date = Convert.ToDateTime(childrenNode.Value);
                    }
                    else if(childrenNode.Name == "Exrate")
                    {
                        type = childrenNode.Attributes["CurrencyCode"].Value;
                        string temp = childrenNode.Attributes[2].Value.Replace(",", string.Empty);
                        temp = temp.Replace('.', ',');
                        buy = Convert.ToDecimal(temp);
                        temp = childrenNode.Attributes[3].Value.Replace(",", string.Empty);
                        temp = temp.Replace('.', ',');
                        transfer = Convert.ToDecimal(temp);
                        temp = childrenNode.Attributes[4].Value.Replace(",", string.Empty);
                        temp = temp.Replace('.', ',');
                        sell = Convert.ToDecimal(temp);
                        db.ForexAdd(buy, transfer, sell, type, date);
                    }
                }
            }
        }

        private void frmGet_Load(object sender, EventArgs e)
        {
            //ParseKitco("London Fix          GOLD          SILVER       PLATINUM           PALLADIUM\r\n                   AM       PM                  AM       PM         AM       PM\r\n   --------------------------------------------------------------------------------\r\n   Jun 05,2014   1244.75   1252.50   18.8100   1429.00   1440.00   834.00   839.00  \r\n   Jun 04,2014   1246.00   1245.25   18.7600   1421.00   1422.00   833.00   NA  \r\n   --------------------------------------------------------------------------------\r\n\r\n\r\n\t\t\t     ");

            SetSize();
            SetTitle();

            if (exit)
            {
                //Kitco-London Gold Fix
                try
                {
                    ParseKitco(GetHistoricalData("http://www.kitco.com/texten/texten.html", "London Fix", "New York Spot Price", 2));
                }
                catch (Exception) { }

                try
                {
                    ParseSJC(GetHistoricalData("http://www.sjc.com.vn/xml/tygiavang.xml", null, null, 1));
                }
                catch (Exception) { }


                try
                {
                    ParseForex(GetHistoricalData("http://vietcombank.com.vn/ExchangeRates/ExrateXML.aspx", "<ExrateList>", "</ExrateList>", 1));
                }
                catch (Exception) { }

                //try
                //{
                //    ParseVNForex(GetHistoricalData("http://www.vietcombank.com.vn/ExchangeRates/Default.aspx", "<ExrateList>", "</ExrateList>", 2));
                //}
                //catch (Exception) { }

                //string s = GetHistoricalData("http://www.oanda.com/currency/historical-rates/", null, null);
                try
                {
                    ParseCurrency(GetHistoricalData("http://www.oanda.com/currency/live-exchange-rates/", "1}, \"USD_TRY\":", ";\n    </script>\n", 2));
                    //ParseCurrency(GetHistoricalData("http://www.oanda.com/currency/live-exchange-rates/", "<a href=\" / currency / live - exchange - rates / EURUSD\" class=\"primary\">EUR/USD</a>", "<a href=\" / currency / live - exchange - rates / EURAUD\" class=\"primary\">EUR/AUD</a>", 2));
                }
                catch (Exception) { }

                Application.Exit();
            }
            else
            {
                dgvDisplay.UpdateHeader("Daily Price");
                dgvMonth.UpdateHeader("Month Avg Price of all");
                dgvMonthYear.UpdateHeader("Month Avg Price of Each Year");
                dgvWeekDay.UpdateHeader("WeekDay Avg Price of all");
                dgvMonthYear.DataSource = db.SJCMonthYear(Convert.ToInt32(cboMonths.Text), Convert.ToInt32(cboYears.Text));
                dgvMonth.DataSource = db.SJCMonth(Convert.ToInt32(cboMonths.Text), Convert.ToInt32(cboYears.Text));
                dgvDisplay.DataSource = db.SJCList(Convert.ToInt32(cboDays.Text));
                dgvWeekDay.DataSource = db.SJCWeekDay(Convert.ToInt32(cboMonths.Text), Convert.ToInt32(cboYears.Text));
            }

        }

        public void ParseHistorySJC(string data)
        {
            List<Definition> lst = db.DefinitionList(1);
            decimal ask, bid;
            string search;
            int rateId = db.RateAdd(DateTime.Now);
            string result = "";
            int pos;
            foreach (Definition item in lst)
            {
                if (item.CodeNum != "USD")
                {
                    search = "USD_" + item.CodeNum;
                    pos = data.IndexOf(search);
                    if (pos > 0)
                        result = data.Substring(pos + 70, 100);
                    else
                        result = "";
                    if (result.Length > 0)
                    {
                        try
                        {
                            int tmp = result.IndexOf("bid\":") + 7;
                            int tmp1 = result.IndexOf("\"", tmp) - tmp;
                            bid = Convert.ToDecimal(result.Substring(tmp, tmp1));
                            tmp = result.IndexOf("ask\":") + 7;
                            tmp1 = result.IndexOf("\"", tmp) - tmp;
                            ask = Convert.ToDecimal(result.Substring(tmp, tmp1));
                            db.RateDetailAdd(ask, bid, item.Id, rateId);
                        }
                        catch (Exception) { }
                    }
                }
            }
        }


        public void ParseCurrency(string data)
        {
            List<Definition> lst = db.DefinitionList(1);
            decimal ask, bid;
            string search;
            int rateId = db.RateAdd(DateTime.Now);
            string result = "";
            int pos;
            foreach (Definition item in lst)
            {
                if (item.CodeNum != "USD")
                {
                    search = "USD_" + item.CodeNum;
                    pos = data.IndexOf(search);
                    if (pos > 0)
                        result = data.Substring(pos + 70, 100);
                    else
                        result = "";
                    if (result.Length > 0)
                    {
                        try
                        {
                            int tmp = result.IndexOf("bid\":") + 7;
                            int tmp1 = result.IndexOf("\"", tmp) - tmp;
                            bid = Convert.ToDecimal(result.Substring(tmp, tmp1));
                            tmp = result.IndexOf("ask\":") + 7;
                            tmp1 = result.IndexOf("\"", tmp) - tmp;
                            ask = Convert.ToDecimal(result.Substring(tmp, tmp1));
                            db.RateDetailAdd(ask, bid, item.Id, rateId);
                        }
                        catch (Exception) { }
                    }
                }
            }
        }

        public void ParseKitco(string data)
        {
            try
            {
                int pos = data.IndexOf("-\r\n") + 6;
                string temp = data.Substring(pos, data.Length - pos);
                
                //temp = 
                DateTime date = Convert.ToDateTime(temp.Substring(0, 11));
                pos = 14;
                temp = temp.Substring(pos, temp.Length - pos);
                decimal goldAM = Convert.ToDecimal(temp.Substring(0, 7));
                pos = 10;
                temp = temp.Substring(pos, temp.Length - pos);
                decimal goldPM = 0;
                if (temp.Substring(0, 2) != "NA")
                {
                    goldPM = Convert.ToDecimal(temp.Substring(0, 7));
                    temp = temp.Substring(pos, temp.Length - pos);
                }
                else
                    temp = temp.Substring(6, temp.Length - 6);

                decimal silver = 0;

                if (temp.Substring(0, 2) != "NA")
                {
                    silver = Convert.ToDecimal(temp.Substring(0, 7));
                    temp = temp.Substring(pos, temp.Length - pos);
                }
                else
                    temp = temp.Substring(6, temp.Length - 6);

                decimal platinumAM = Convert.ToDecimal(temp.Substring(0, 7));
                temp = temp.Substring(pos, temp.Length - pos);

                decimal platinumPM = 0;
                if (temp.Substring(0, 2) != "NA")
                {
                    platinumPM = Convert.ToDecimal(temp.Substring(0, 7));
                    temp = temp.Substring(pos, temp.Length - pos);
                }
                else
                    temp = temp.Substring(6, temp.Length - 6);

                decimal palladiumAM = Convert.ToDecimal(temp.Substring(0, 7));
                temp = temp.Substring(pos, temp.Length - pos);
                decimal palladiumPM = 0;
                if (temp.Substring(0, 2) != "NA")
                {
                    palladiumPM = Convert.ToDecimal(temp.Substring(0, 7));
                }
                db.LondonAdd(date, goldAM, goldPM, silver, platinumAM, platinumPM, palladiumAM, palladiumPM);
            }
            catch (Exception) { }
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
            //dgvMonth.Height = this.Height - dgvMonth.Location.Y;
            //dgvWeekDay.Height = dgvMonth.Height;

            dgvDisplay.Width = (this.Width / 2) - 20;
            dgvDisplay.Height = ((this.Height - dgvDisplay.Location.Y) / 2) - 20;

            dgvWeekDay.Width = dgvDisplay.Width;
            dgvWeekDay.Height = this.Height - dgvWeekDay.Location.Y - 20;

            dgvWeekDay.Top = dgvDisplay.Top + dgvDisplay.Height + 10;

            dgvMonthYear.Width = dgvDisplay.Width;
            dgvMonthYear.Height = dgvDisplay.Height;

            dgvMonthYear.Left = dgvWeekDay.Width + 10;

            dgvMonth.Width = dgvWeekDay.Width;
            dgvMonth.Height = dgvWeekDay.Height;

            dgvMonth.Top = dgvWeekDay.Top;
            dgvMonth.Left = dgvMonthYear.Left;
        }

        private void btnDisplayNear_Click(object sender, EventArgs e)
        {
            dgvMonthYear.DataSource = db.SJCMonthYear(Convert.ToInt32(cboMonths.Text), Convert.ToInt32(cboYears.Text));
            dgvMonth.DataSource = db.SJCMonth(Convert.ToInt32(cboMonths.Text), Convert.ToInt32(cboYears.Text));
            dgvDisplay.DataSource = db.SJCList(Convert.ToInt32(cboDays.Text));
            dgvWeekDay.DataSource = db.SJCWeekDay(Convert.ToInt32(cboMonths.Text), Convert.ToInt32(cboYears.Text));
            SetSize();
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            try
            {
                txtComparePrice.Text = Convert.ToDecimal(dgvDisplay.arrReturn[2]).ToString("00,000.00");
                txtPrice.Text = Convert.ToDecimal(txtPrice.Text).ToString("00,000.00");
                txtResult.Text = (Convert.ToDecimal(txtQuan.Text) * (Convert.ToDecimal(txtComparePrice.Text) - Convert.ToDecimal(txtPrice.Text))).ToString(",000,000.00");
            }
            catch (Exception) { }
        }

        private void dgvDisplay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtComparePrice.Text = Convert.ToDecimal(dgvDisplay.arrReturn[2]).ToString("00,000.00");
        }

        private void btnGold_Click(object sender, EventArgs e)
        {
            frmGold frm = new frmGold();
            frm.Show();
        }

        private void btnUSDRate_Click(object sender, EventArgs e)
        {
            frmRate frm = new frmRate();
            frm.Show();
        }

        private int width = 50;
        private void dgvDisplay_MouseHover(object sender, EventArgs e)
        {
            dgvDisplay.Width = this.Width - dgvDisplay.Location.X - width;
            dgvWeekDay.Width = dgvDisplay.Width;
            dgvMonthYear.Width = width;
            dgvMonth.Width = dgvMonthYear.Width;
            dgvMonthYear.Left = this.Width - width;
            dgvMonth.Left = dgvMonthYear.Left;
        }

        private void dgvMonthYear_MouseHover(object sender, EventArgs e)
        {
            dgvMonthYear.Width = this.Width - width;
            dgvMonth.Width = dgvMonthYear.Width;
            dgvMonthYear.Left = width;
            dgvMonth.Left = dgvMonthYear.Left;
            dgvDisplay.Width = width;
            dgvWeekDay.Width = dgvDisplay.Width;
        }

        private void dgvMonth_Load(object sender, EventArgs e)
        {

        }

        private void mnuRulesGold_Click(object sender, EventArgs e)
        {
            frmRules_Gold frm = new frmRules_Gold();
            frm.Show();
        }

        private void mnuNewRule_Click(object sender, EventArgs e)
        {
            frmRule frm = new frmRule();
            frm.Show();
        }

        private void mnuNewsDisplay_Click(object sender, EventArgs e)
        {
            frmNewsDisplay frm = new frmNewsDisplay();
            frm.Show();
        }

        private void mnuNewsNew_Click(object sender, EventArgs e)
        {
            frmNews frm = new frmNews();
            frm.Show();
        }

        private void mnuCompareGoldPrice_Click(object sender, EventArgs e)
        {
            frmCompareGoldVN_World frm = new frmCompareGoldVN_World();
            frm.Show();
        }

        private void cboDays_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmSJC_Resize(object sender, EventArgs e)
        {
            dgvDisplay.Width = (this.Width / 2) - 20;
            dgvDisplay.Height = ((this.Height - dgvDisplay.Location.Y) / 2) - 20;

            dgvWeekDay.Width = dgvDisplay.Width;
            dgvWeekDay.Height = dgvDisplay.Height;

            dgvWeekDay.Top = dgvDisplay.Top + dgvDisplay.Height + 10;

            dgvMonthYear.Width = dgvDisplay.Width;
            dgvMonthYear.Height = dgvDisplay.Height;

            dgvMonthYear.Left = dgvWeekDay.Width + 10;

            dgvMonth.Width = dgvDisplay.Width;
            dgvMonth.Height = dgvDisplay.Height;

            dgvMonth.Top = dgvWeekDay.Top;
            dgvMonth.Left = dgvMonthYear.Left;
        }
    }
}
