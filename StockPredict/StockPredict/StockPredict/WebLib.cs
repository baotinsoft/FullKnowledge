using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Data;
using System.Data.SqlClient;


namespace StockPredict
{
    public class WebLib
    {
        public static string str_Con_SQL = "Data Source=localhost;" +
               "Initial Catalog=Stock;Integrated Security=true";
        public static string str_Con_SQL_Port = "Data Source=localhost;" +
               "Initial Catalog=Portfolio;Integrated Security=true";
        public static string str_Con_SQL_Live = "Data Source=localhost;" +
               "Initial Catalog=StockLive;Integrated Security=true";

        /*---------------------------------
         * Description: Input Over Bid(mua)/Offer(ban) from hsc.com.vn
        ----------------------------------- */
        public static void OverBidOffer(string sPath)
        {
            DateTime dtTemp;
            StreamReader sr;

            string sTmp, sSBid = "OverBid", sSOffer = "OverOffer", sSearch = "?C=", sStock, sBid, sOffer;
            int iO1, iO2, iB1, iB2, iIndex, iTmp;

            string[] sArrFiles = Directory.GetFiles(sPath);
            int iQuantity = sArrFiles.Length;

            SqlConnection conn = new SqlConnection(str_Con_SQL);
            conn.Open();
            SqlCommand cmdUpdate = conn.CreateCommand();

            //for (int k = 0; k < 109; k++)
            //{
            //    try
            //    {
            //        cmdUpdate.CommandText = "ALTER TABLE " + arrStock[k] + " ADD OverBid int, OverOffer int";
            //        cmdUpdate.ExecuteNonQuery();
            //    }
            //    catch (Exception e) { }
            //}

            for (int i = 0; i < iQuantity; i++)
            {
                dtTemp = Convert.ToDateTime(sArrFiles[i].Substring(sArrFiles[i].Length - 14, 10).Replace('-', '/'));

                sr = new StreamReader(sArrFiles[i]);
                sTmp = sr.ReadToEnd();
                iTmp = sTmp.IndexOf("ShowBangGia1_div1");
                sTmp = sTmp.Substring(iTmp + 100);

                while ((iIndex = sTmp.IndexOf(sSearch)) > -1)
                {
                    sTmp = sTmp.Substring(iIndex + 3);
                    iTmp = sTmp.IndexOf("&amp;");
                    sStock = sTmp.Substring(0, iTmp);
                    // Bid
                    iTmp = sTmp.IndexOf(sSBid);
                    sTmp = sTmp.Substring(iTmp + 9);
                    sBid = sTmp.Substring(0, sTmp.IndexOf("span") - 2);
                    // Offer
                    iTmp = sTmp.IndexOf(sSOffer);
                    sTmp = sTmp.Substring(iTmp + 11);
                    sOffer = sTmp.Substring(0, sTmp.IndexOf("span") - 2);
                    //Update to DB
                    try
                    {
                        cmdUpdate.CommandText = "UPDATE " + sStock + " SET OverBid=" + sBid.Replace(".", "") + ", OverOffer="
                        + sOffer.Replace(".", "") + " WHERE CloseDate='" + dtTemp.ToShortDateString() + "'";
                        cmdUpdate.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        //cmdUpdate.CommandText = "ALTER TABLE " + sStock + " ADD OverBid int, OverOffer int";
                        //cmdUpdate.ExecuteNonQuery();
                        //cmdUpdate.CommandText = "UPDATE " + sStock + " SET OverBid=" + sBid.Replace(".", "") + ", OverOffer="
                        //+ sOffer.Replace(".", "") + " WHERE CloseDate='" + dtTemp.ToShortDateString() + "'";
                        //cmdUpdate.ExecuteNonQuery();
                    }
                }

                sr.Close();
            }
            conn.Close();

        }

        /*---------------------------------
         * Description: Input stock price from hsx.vn
        ----------------------------------- */
        public static void HSX(string sPath)
        {
            DateTime dtTemp;
            StreamReader sr;
            SqlDataReader rdr;

            string sTmp, sStock, sO, sC, sH, sL, sVol, sPast;
            //int iO1, iO2, iB1, iB2, iIndex, iTmp, iStock;
            int iTmp, iStock;
            double dCeiling, dFloor, dO, dC, dH, dL, dPast;

            string[] sArrFiles = Directory.GetFiles(sPath);
            int iQuantity = sArrFiles.Length;

            SqlConnection conn = new SqlConnection(str_Con_SQL);
            conn.Open();
            SqlCommand cmdUpdate = conn.CreateCommand();

            // Get limit
            double iLimit = General.GetParam();

            for (int i = 0; i < iQuantity; i++)
            {
                //string s = sArrFiles[i].Substring(sArrFiles[i].Length-14, 10).Replace('-', '/');
                dtTemp = Convert.ToDateTime(sArrFiles[i].Substring(sArrFiles[i].Length - 14, 10).Replace('-', '/'));

                sr = new StreamReader(sArrFiles[i]);
                sTmp = sr.ReadToEnd();


                while ((iStock = sTmp.IndexOf("MCty=")) > -1)
                {
                    sTmp = sTmp.Substring(iStock + 5);
                    iTmp = sTmp.IndexOf("\"");
                    sStock = sTmp.Substring(0, iTmp);

                    iTmp = sTmp.IndexOf("Label22");
                    sTmp = sTmp.Substring(iTmp + 9);
                    iTmp = sTmp.IndexOf("<");
                    sPast = sTmp.Substring(0, iTmp).Replace(',', '.');

                    iTmp = sTmp.IndexOf("Label24");
                    sTmp = sTmp.Substring(iTmp + 9);
                    iTmp = sTmp.IndexOf("<");
                    sO = sTmp.Substring(0, iTmp).Replace(',', '.');

                    iTmp = sTmp.IndexOf("Label25");
                    sTmp = sTmp.Substring(iTmp + 9);
                    iTmp = sTmp.IndexOf("<");
                    sC = sTmp.Substring(0, iTmp).Replace(',', '.');

                    iTmp = sTmp.IndexOf("Label26");
                    sTmp = sTmp.Substring(iTmp + 9);
                    iTmp = sTmp.IndexOf("<");
                    sL = sTmp.Substring(0, iTmp).Replace(',', '.');

                    iTmp = sTmp.IndexOf("Label27");
                    sTmp = sTmp.Substring(iTmp + 9);
                    iTmp = sTmp.IndexOf("<");
                    sH = sTmp.Substring(0, iTmp).Replace(',', '.');

                    iTmp = sTmp.IndexOf("Label29");
                    sTmp = sTmp.Substring(iTmp + 9);
                    iTmp = sTmp.IndexOf("<");
                    sVol = sTmp.Substring(0, iTmp).Replace(".", "");

                    // Check limit
                    dPast = Convert.ToDouble(sPast);
                    dO = Convert.ToDouble(sO);
                    dC = Convert.ToDouble(sC);
                    dH = Convert.ToDouble(sH);
                    dL = Convert.ToDouble(sL);
                    dCeiling = dPast * (1 + iLimit);
                    dFloor = dPast * (1 - iLimit);
                    if (dO >= dFloor && dO <= dCeiling && dC >= dFloor && dC <= dCeiling &&
                        dH >= dFloor && dH <= dCeiling && dL >= dFloor && dL <= dCeiling)
                    {
                        //Insert to DB
                        try
                        {
                            cmdUpdate.CommandText = "SELECT ID FROM " + sStock
                                + " WHERE CloseDate='" + dtTemp.ToShortDateString() + "'";
                            rdr = cmdUpdate.ExecuteReader();
                            if (!rdr.Read())
                            {
                                rdr.Close();
                                cmdUpdate.CommandText = "INSERT INTO " + sStock
                                + "(CloseDate,OpenPrice,HighPrice,LowPrice,ClosePrice,Volume) VALUES('"
                                + dtTemp.ToShortDateString() + "'," + sO + "," + sH + "," + sL + ","
                                + sC + "," + sVol + ")";

                                cmdUpdate.ExecuteNonQuery();
                            }
                            else rdr.Close();
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }

                sr.Close();
            }
            conn.Close();

        }


        /*---------------------------------
         * Description: Input HCM company information from hsx.vn
        ----------------------------------- */
        public static void HCMCompany(string sPath)
        {
            StreamReader sr;
            SqlDataReader rdr;

            string sTmp, sStock, sComp, sStockQuan, sMarketQuan, sFirstDate;
            int iTmp, iStock;

            string[] sArrFiles = Directory.GetFiles(sPath);
            int iQuantity = sArrFiles.Length;

            SqlConnection conn = new SqlConnection(str_Con_SQL);
            conn.Open();
            SqlCommand cmdUpdate = conn.CreateCommand();

            for (int i = 0; i < iQuantity; i++)
            {
                sr = new StreamReader(sArrFiles[i]);
                sTmp = sr.ReadToEnd();

                while ((iStock = sTmp.IndexOf("MCty=")) > -1)
                {
                    sTmp = sTmp.Substring(iStock + 5);
                    iTmp = sTmp.IndexOf("\"");
                    sStock = sTmp.Substring(0, iTmp);

                    iTmp = sTmp.IndexOf("left\">");
                    sTmp = sTmp.Substring(iTmp + 6);
                    iTmp = sTmp.IndexOf("<");
                    sComp = sTmp.Substring(0, iTmp);

                    iTmp = sTmp.IndexOf("\">");
                    sTmp = sTmp.Substring(iTmp + 2);
                    iTmp = sTmp.IndexOf("<");
                    sStockQuan = sTmp.Substring(0, iTmp).Replace(".", "");

                    iTmp = sTmp.IndexOf("\">");
                    sTmp = sTmp.Substring(iTmp + 2);
                    iTmp = sTmp.IndexOf("<");
                    sMarketQuan = sTmp.Substring(0, iTmp).Replace(".", "");

                    iTmp = sTmp.IndexOf("\">");
                    sTmp = sTmp.Substring(iTmp + 2);
                    iTmp = sTmp.IndexOf("<");
                    sFirstDate = sTmp.Substring(0, iTmp);
                    sFirstDate = sFirstDate.Substring(3, 2) + "/" + sFirstDate.Substring(0, 2) + sFirstDate.Substring(5); // date format: mm/dd/yyyy

                    //Insert to DB
                    try
                    {
                        cmdUpdate.CommandText = "SELECT StockCode FROM Stock_Company WHERE StockCode='"
                            + sStock + "'";
                        rdr = cmdUpdate.ExecuteReader();
                        if (!rdr.Read())
                        {
                            rdr.Close();
                            cmdUpdate.CommandText = "INSERT INTO Stock_Company(StockCode,Company,StockQuantity,MarketQuantity,FirstDate,Market) VALUES('"
                                + sStock + "',N'" + sComp + "'," + sStockQuan + ","
                                + sMarketQuan + ",'" + sFirstDate + "',1)";
                            cmdUpdate.ExecuteNonQuery();
                        }
                        else rdr.Close();
                    }
                    catch (Exception ex)
                    {
                    }
                }

                sr.Close();
            }
            conn.Close();

        }


        /*---------------------------------
         * Description: Input HN company information from hsx.vn
        ----------------------------------- */
        public static void HNCompany(string sPath)
        {
            StreamReader sr;
            SqlDataReader rdr;

            string sTmp, sStock, sComp, sLegalEquity, sMarketQuan, sFirstDate;
            int iTmp, iStock;

            string[] sArrFiles = Directory.GetFiles(sPath);
            int iQuantity = sArrFiles.Length;

            SqlConnection conn = new SqlConnection(str_Con_SQL);
            conn.Open();
            SqlCommand cmdUpdate = conn.CreateCommand();

            for (int i = 0; i < iQuantity; i++)
            {
                sr = new StreamReader(sArrFiles[i]);
                sTmp = sr.ReadToEnd();
                while ((iStock = sTmp.IndexOf("IssuerID=")) > -1)
                {
                    sTmp = sTmp.Substring(iStock + 9);
                    iStock = sTmp.IndexOf(">");
                    sTmp = sTmp.Substring(iStock + 1);
                    iTmp = sTmp.IndexOf("<");
                    sStock = sTmp.Substring(0, iTmp);

                    iTmp = sTmp.IndexOf("2\">");
                    sTmp = sTmp.Substring(iTmp + 3);
                    iTmp = sTmp.IndexOf("<");
                    sComp = sTmp.Substring(0, iTmp);

                    iTmp = sTmp.IndexOf("\">");
                    sTmp = sTmp.Substring(iTmp + 2);
                    iTmp = sTmp.IndexOf("<");
                    sLegalEquity = sTmp.Substring(0, iTmp).Replace(",", "");

                    iTmp = sTmp.IndexOf("\">");
                    sTmp = sTmp.Substring(iTmp + 2);
                    iTmp = sTmp.IndexOf("<");
                    sMarketQuan = sTmp.Substring(0, iTmp).Replace(",", "");

                    iTmp = sTmp.IndexOf("\">");
                    sTmp = sTmp.Substring(iTmp + 2);
                    iTmp = sTmp.IndexOf("<");
                    sFirstDate = sTmp.Substring(0, iTmp);
                    sFirstDate = sFirstDate.Substring(3, 2) + "/" + sFirstDate.Substring(0, 2) + sFirstDate.Substring(5); // date format: mm/dd/yyyy

                    //Insert to DB
                    try
                    {
                        cmdUpdate.CommandText = "SELECT StockCode FROM Stock_Company WHERE StockCode='"
                            + sStock + "'";
                        rdr = cmdUpdate.ExecuteReader();
                        if (!rdr.Read())
                        {
                            rdr.Close();
                            cmdUpdate.CommandText = "INSERT INTO Stock_Company(StockCode,Company,LegalEquity,MarketQuantity,FirstDate,Market) VALUES('"
                                + sStock + "',N'" + sComp + "'," + sLegalEquity + ","
                                + sMarketQuan + ",'" + sFirstDate + "',2)";
                            cmdUpdate.ExecuteNonQuery();
                        }
                        else rdr.Close();
                    }
                    catch (Exception ex)
                    {
                    }
                }

                sr.Close();
            }
            conn.Close();

        }

        /*---------------------------------
         * Description: Input Financial factor from tvsi.com.vn
        ----------------------------------- */
        public static void FinanceTVSI(string sPath)
        {
            StreamReader sr;
            SqlDataReader rdr;

            string sTmp;
            string[] sArrFin = new string[25];
            int iTmp, iTmp1, iStock, j;

            string[] sArrFiles = Directory.GetFiles(sPath);
            int iQuantity = sArrFiles.Length;
            int iLen = sPath.Length;

            SqlConnection conn = new SqlConnection(str_Con_SQL);
            conn.Open();
            SqlCommand cmdUpdate = conn.CreateCommand();

            for (int i = 0; i < iQuantity; i++)
            {
                sr = new StreamReader(sArrFiles[i]);
                sTmp = sr.ReadToEnd();
                for (j = 0; j < 25; j++)
                {
                    iStock = sTmp.IndexOf("datagrid_otc");
                    sTmp = sTmp.Substring(iStock + 12);
                    iStock = sTmp.IndexOf(">");
                    sTmp = sTmp.Substring(iStock + 1);

                    if (j < 13 || j == 16 || j == 17 || j > 19)
                        iTmp = sTmp.IndexOf("<");
                    else
                        iTmp = sTmp.IndexOf(" %");
                    if (j < 13 || j > 22) sArrFin[j] = sTmp.Substring(0, iTmp).Replace(",", "").Trim();
                    else sArrFin[j] = sTmp.Substring(0, iTmp).Trim();
                    if (sArrFin[j] == "") sArrFin[j] = "0";
                }
                sTmp = sArrFiles[i].Substring(iLen + 1);
                iTmp = sTmp.IndexOf(".");
                sTmp = sTmp.Substring(0, iTmp - 1).Trim();
                //Insert to DB
                try
                {
                    cmdUpdate.CommandText = "UPDATE Stock_Company SET CurrentAssets=" + sArrFin[0]
                    + ",FixedAssets=" + sArrFin[1] + ",Inventory=" + sArrFin[2]
                    + ",ShortTermLiabilities=" + sArrFin[3] + ",LongTermLiabilities=" + sArrFin[4]
                    + ",OwnerEquity=" + sArrFin[5] + ",NetRevenue=" + sArrFin[6]
                    + ",CostofGoodsSold=" + sArrFin[7] + ",GrossMarginProfit=" + sArrFin[8]
                    + ",BusinessIncome=" + sArrFin[9] + ",FinancialIncome=" + sArrFin[10]
                    + ",NetIncomeBeforeTax=" + sArrFin[11] + ",NetIncome=" + sArrFin[12]
                    + ",ProfitMarginonSales=" + sArrFin[13] + ",ROA=" + sArrFin[14]
                    + ",ROE=" + sArrFin[15] + ",CurrentRatio=" + sArrFin[16]
                    + ",QuickRatio=" + sArrFin[17] + ",DebtRatio=" + sArrFin[18]
                    + ",LongDebtRatio=" + sArrFin[19] + ",InventoryTurnoverRatio=" + sArrFin[20]
                    + ",TotalAssetTurnover=" + sArrFin[21] + ",PE=" + sArrFin[22]
                    + ",EPSBasic=" + sArrFin[23] + ",EPSDiluted=" + sArrFin[24]
                    + " WHERE StockCode='" + sTmp + "'";
                    cmdUpdate.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                }

                sr.Close();
            }
            conn.Close();

        }

        /*---------------------------------
          * Description: Download price from Internet
         ----------------------------------- */
        public static bool HttpPost(string uri, string sPath)
        {
            string sParam, sTmp;
            //StreamReader sr = new StreamReader(sFile);
            //sParam = sr.ReadToEnd();
            //sr.Close();
            //sParam = "ctl00$NewsMenuContent$Menu1$lblCachedHTMLCode=3&ctl00$LogoContent$UCLogoView1$lblCachedHTMLKey=market&ctl00$MainContent$lsThitruong=HCM&ctl00$MainContent$Date5=14/05/2008&ctl00$MainContent$Button1=Xem";
            //sParam = "ctl00_mainContent_Live3Price1_wdcdate=2008-06-20&";
            //sParam = sParam + "ctl00$mainContent$Live3Price1$wdcDate$dateInput_TextBox=20/06/2008&";
            //sParam = sParam + "ctl00_mainContent_Live3Price1_wdcDate_calendar_SD=[[2008,6,20]]";


            // parameters: name1=value1&name2=value2    
            WebRequest webRequest = WebRequest.Create(uri);
            //string ProxyString =
            // System.Configuration.ConfigurationManager.AppSettings
            // [GetConfigKey("proxy")];
            //webRequest.Proxy = new WebProxy (ProxyString, true);
            //Commenting out above required change to App.Config
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.Method = "POST";
            //webRequest.
            //byte[] bytes = Encoding.ASCII.GetBytes (sParam);
            Stream os = null;
            try
            { // send the Post
                //webRequest.ContentLength = bytes.Length; //Count bytes to send
                os = webRequest.GetRequestStream();
                //os.Write (bytes, 0, bytes.Length); //Send it
            }
            catch (WebException ex)
            {
                return false;
            }
            finally
            {
                if (os != null)
                {
                    os.Close();
                }
            }

            try
            { // get the response
                WebResponse webResponse = webRequest.GetResponse();
                if (webResponse == null)
                { return false; }
                StreamReader srTmp = new StreamReader(webResponse.GetResponseStream());

                sTmp = "";
                if (DateTime.Now.Month < 10)
                    sTmp += "0" + DateTime.Now.Month;
                else
                    sTmp += DateTime.Now.Month;
                sTmp += "-";
                if (DateTime.Now.Day < 10)
                    sTmp += "0" + DateTime.Now.Day;
                else
                    sTmp += DateTime.Now.Day;

                sTmp += "-";
                sTmp += DateTime.Now.Year;

                StreamWriter sw = new StreamWriter(sPath + sTmp + ".htm");
                sw.Write(srTmp.ReadToEnd());
                sw.Close();
                webResponse.Close();
                return true;
            }
            catch (WebException ex)
            {
                return false;
            }
            return false;
        } // end HttpPost

        public static bool HttpPostTime(string uri, string sPath, string sMarket)
        {
            string sParam, sTmp;

            WebRequest webRequest = WebRequest.Create(uri);
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.Method = "POST";
            Stream os = null;
            try
            { // send the Post
                os = webRequest.GetRequestStream();
            }
            catch (WebException ex)
            {
                return false;
            }
            finally
            {
                if (os != null)
                {
                    os.Close();
                }
            }

            try
            { // get the response
                WebResponse webResponse = webRequest.GetResponse();
                if (webResponse == null)
                { return false; }
                StreamReader srTmp = new StreamReader(webResponse.GetResponseStream());

                sTmp = "";
                if (DateTime.Now.Month < 10)
                    sTmp += "0" + DateTime.Now.Month;
                else
                    sTmp += DateTime.Now.Month;
                sTmp += "-";
                if (DateTime.Now.Day < 10)
                    sTmp += "0" + DateTime.Now.Day;
                else
                    sTmp += DateTime.Now.Day;

                sTmp += "-";
                sTmp += DateTime.Now.Year + "-" + DateTime.Now.ToLongTimeString().Replace(':','_');

                StreamWriter sw = new StreamWriter(sPath + sMarket + "-" + sTmp + ".htm");
                sw.Write(srTmp.ReadToEnd());
                sw.Close();
                webResponse.Close();
                return true;
            }
            catch (WebException ex)
            {
                return false;
            }
            return false;
        } // end HttpPost

        /*---------------------------------
          * Description: Download financial factors of all stock from tvsi.com.vn: NOK
         ----------------------------------- */
        public static bool GetFinanceAll(string uri, string sPath)
        {
            SqlDataReader rdr;
            SqlConnection conn = new SqlConnection(str_Con_SQL);
            conn.Open();
            SqlCommand cmdUpdate = conn.CreateCommand();
            // Get all stock code from StockMarket
            cmdUpdate.CommandText = "SELECT StockCode FROM Stock_Company";
            rdr = cmdUpdate.ExecuteReader();

            string sParam, sTmp, sStock;
            WebRequest webRequest;
            WebResponse webResponse;
            StreamReader srTmp;
            Stream os;
            while (rdr.Read())
            {
                sStock = rdr.GetString(0);
                webRequest = WebRequest.Create(uri + sStock + "&msid=1");
                webRequest.ContentType = "application/x-www-form-urlencoded";
                webRequest.Method = "POST";
                os = null;
                try
                { // send the Post
                    os = webRequest.GetRequestStream();
                }
                catch (WebException ex)
                {
                    return false;
                }
                finally
                {
                    if (os != null)
                    {
                        os.Close();
                    }
                }

                try
                { // get the response
                    webResponse = webRequest.GetResponse();
                    if (webResponse == null)
                    { return false; }
                    srTmp = new StreamReader(webResponse.GetResponseStream());

                    StreamWriter sw = new StreamWriter(sPath + sStock + ".htm");
                    sw.Write(srTmp.ReadToEnd());
                    sw.Close();
                    webResponse.Close();
                }
                catch (WebException ex)
                {
                    return false;
                }
            }
            rdr.Close();
            conn.Close();
            return true;
        } // end HttpPost



        /*---------------------------------
        * Description: Input stock price from istock to HCM,HN price
       ----------------------------------- */
        public static void iStockPrice(string sPath)
        {
            string[] sArrFiles = Directory.GetFiles(sPath);
            int iQuantity = sArrFiles.Length;

            if (iQuantity == 0) return;

            DateTime dtTemp;
            StreamReader sr;
            //SqlDataReader rdr;

            string sTmp, sTmp1, sStock, sO, sC, sH, sL, sVol, sPast;
            //int iO1, iO2, iB1, iB2, iIndex, iTmp, iStock;
            int iTmp, iTmp1, iStock, iMarket;
            double dCeiling, dFloor, dO, dC, dH, dL, dPast;


            SqlConnection conn = new SqlConnection(str_Con_SQL);
            conn.Open();
            SqlCommand cmdUpdate = conn.CreateCommand();

            cmdUpdate.CommandText = "InsertPrice";
            cmdUpdate.CommandType = CommandType.StoredProcedure;

            cmdUpdate.Parameters.Add("Stock", SqlDbType.NVarChar, 10);
            cmdUpdate.Parameters.Add("CloseDate", SqlDbType.DateTime);
            cmdUpdate.Parameters.Add("OpenPrice", SqlDbType.Float);
            cmdUpdate.Parameters.Add("HighPrice", SqlDbType.Float);
            cmdUpdate.Parameters.Add("LowPrice", SqlDbType.Float);
            cmdUpdate.Parameters.Add("ClosePrice", SqlDbType.Float);
            cmdUpdate.Parameters.Add("Volume", SqlDbType.Int);
            cmdUpdate.Parameters.Add("MarketId", SqlDbType.Int);

            // Get limit
            double iLimit = General.GetParam();


            for (int i = 0; i < iQuantity; i++)
            {
                //string s = sArrFiles[i].Substring(sArrFiles[i].Length-14, 10).Replace('-', '/');
                //dtTemp = Convert.ToDateTime(sArrFiles[i].Substring(sArrFiles[i].Length - 14, 10).Replace('-', '/'));
                if (sArrFiles[i].Substring(0, 2) == "HO")
                    iMarket = 1;
                else
                    iMarket = 2;

                sr = new StreamReader(sArrFiles[i]);
                sr.ReadLine();
                while ((sTmp=sr.ReadLine())!=null)
                {
                    iTmp = sTmp.IndexOf(",");
                    sStock = sTmp.Substring(0, iTmp);

                    iTmp1 = sTmp.IndexOf(",", iTmp+1);
                    iTmp = sTmp.IndexOf(",", iTmp1+1);
                    sTmp1 = sTmp.Substring(iTmp1 + 1, 8);

                    dtTemp = new DateTime(Convert.ToInt32( sTmp1.Substring(0, 4)), Convert.ToInt32(sTmp1.Substring(4, 2)), Convert.ToInt32(sTmp1.Substring(6, 2)));

                    iTmp1 = sTmp.IndexOf(",", iTmp + 1);
                    iTmp = sTmp.IndexOf(",", iTmp1 + 1);
                    sO = sTmp.Substring(iTmp1 + 1, iTmp - iTmp1 - 1);
                    sO = sO.Replace('.', ',');

                    iTmp1 = sTmp.IndexOf(",", iTmp + 1);
                    sH = sTmp.Substring(iTmp + 1, iTmp1 - iTmp - 1);
                    sH = sH.Replace('.', ',');

                    iTmp = sTmp.IndexOf(",", iTmp1 + 1);
                    sL = sTmp.Substring(iTmp1 + 1, iTmp - iTmp1 - 1);
                    sL = sL.Replace('.', ',');

                    iTmp1 = sTmp.IndexOf(",", iTmp + 1);
                    sC = sTmp.Substring(iTmp + 1, iTmp1 - iTmp - 1);
                    sC = sC.Replace('.', ',');

                    iTmp = sTmp.IndexOf(",", iTmp1 + 1);
                    sVol = sTmp.Substring(iTmp1 + 1, iTmp - iTmp1 - 1);



                    //Insert to DB
                    try
                    {
                       
                        cmdUpdate.Parameters[0].Value = sStock;

                        cmdUpdate.Parameters[1].Value = dtTemp.ToShortDateString();

                        cmdUpdate.Parameters[2].Value = sO;

                        cmdUpdate.Parameters[3].Value = sH;

                        cmdUpdate.Parameters[4].Value = sL;

                        cmdUpdate.Parameters[5].Value = sC;

                        cmdUpdate.Parameters[6].Value = sVol;

                        cmdUpdate.Parameters[7].Value = iMarket;

                        cmdUpdate.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                    }

                }
                sr.Close();
            }
            conn.Close();

        }


        /*---------------------------------
          * Description: Reset price data
         ----------------------------------- */
        public static void ResetPrice()
        {
            SqlConnection conn = new SqlConnection(str_Con_SQL);
            conn.Open();
            SqlCommand cmdUpdate = conn.CreateCommand();

            //Reset data
            try
            {
                cmdUpdate.CommandText = "ResetPrice";
                cmdUpdate.CommandType = CommandType.StoredProcedure;
                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
            }
            conn.Close();

        }


        /*---------------------------------
         * Description: Get live price and put them into Live DB
        ----------------------------------- */
        public static void ExeLivePrice(string sPath)
        {
            int iInterest = 20;
            if (DateTime.Now.Hour > 8)
            {
                while (DateTime.Now.Hour <= 11)
                {
                    
                    if ((DateTime.Now.Second % iInterest) == 0)
                    {
                        // Ha Noi
                        WebLib.HttpPostTime("http://www.hastc.org.vn/InfoShow/OnlineShareContinuousInterface.aspx", sPath,"HN");
                        // HCM
                        if (DateTime.Now.Hour<10 && DateTime.Now.Minute<31)
                            WebLib.HttpPostTime("http://www.hsx.vn/LS_HSX/HoSTC_Livesecurity.htm", sPath, "HCM");
                    }
                }
            }

        }


    }
}
