using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Microsoft.AnalysisServices;
//using Microsoft.AnalysisServices.AdomdServer;
using Microsoft.AnalysisServices.AdomdClient;
//using Microsoft.AnalysisServices.AdomdServer;

namespace StockPredict
{
    class ADOMDLib
    {
        public static string str_Con_SQL = "Data Source=localhost;" +
                "Initial Catalog=Stock;Integrated Security=true";
        public static string str_Con_Ana = "location=localhost; Initial Catalog=StockPredict";
        public static string str_Con_Server = "Provider=SQLNCLI.1;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=StockPredict;Data Source=localhost";
        public static int iPrev_Trend;
        public static double iPrev_GA;




        /*---------------------------------
         * Description: Forecast by TimeSeriesPredict
         * Input:
         *  strStockCode: Stock Code
         *  iCount: quantity of future prediction
         *  txtProgress: textbox to show result
         * Output:
         *  True: Sucessful; False: Error
        ----------------------------------- */
        public static void Forecast(System.Windows.Forms.TextBox txtProgress, string strStockCode, int iCount)
        {
            // Forecast quantity need more than 1 (>=1)
            if (iCount < 1) return;

            bool bTrend = true; //true: increase; false: decrease
            double dOld;

            // Data Engine
            DataSet dset = new DataSet();
            SqlConnection cn1 = new SqlConnection(str_Con_SQL);
            cn1.Open();
            //Create the Stock data adapter with the
            //calculated column appended
            SqlCommand cmd1 = new SqlCommand();

            // Assign connection object and sql query to command object
            cmd1.Connection = cn1;
            cmd1.CommandText = "SELECT TOP 10 CloseDate, ClosePrice, OpenPrice, LowPrice, HighPrice FROM " +
                strStockCode + " WHERE ID+10 > (SELECT MAX(ID) FROM " + strStockCode + ")";
            SqlDataReader rdr = cmd1.ExecuteReader();

            // Assign 10 last value of Stock to Arrays
            double[,] dArrPast = new double[10, 4];


            // Analysis Service
            // Create connection and command objects.
            AdomdConnection cn = new AdomdConnection(str_Con_Ana);
            AdomdCommand cmd = new AdomdCommand();
            //Initialize command with query
            cmd.Connection = cn;

            cmd.CommandText = "select flattened PredictTimeSeries([ClosePrice],-9," + iCount +
            ") FROM " + strStockCode;

            // Open connection and execute query
            cn.Open();
            AdomdDataReader reader = cmd.ExecuteReader();

            // Display Historical data
            txtProgress.Text = "";
            //txtProgress.AppendText("Dữ liệu thực tế");
            txtProgress.AppendText(Environment.NewLine);
            txtProgress.AppendText("Date          \tHistorical Price        \tForecast Price");
            txtProgress.AppendText(Environment.NewLine);

            int j = -1;
            while (rdr.Read())
            {
                // Historical Price
                dOld = rdr.GetDouble(1);
                txtProgress.AppendText(Convert.ToDateTime(rdr.GetValue(0)).ToShortDateString() + "  \t" + dOld.ToString() + "    \t\t");

                j++;
                // Assign Historical vals to dArrPass
                dArrPast[j, 0] = rdr.GetDouble(1);
                dArrPast[j, 1] = rdr.GetDouble(2);
                dArrPast[j, 2] = rdr.GetDouble(3);
                dArrPast[j, 3] = rdr.GetDouble(4);

                // Forecast Price
                reader.Read();
                txtProgress.AppendText(Math.Round(Convert.ToSingle(reader.GetValue(1)), 1) + "");
                txtProgress.AppendText(Environment.NewLine);

                // Date of forecast
                if (j == 9)
                {
                    DateTime dtTemp, dtSave;
                    double dNew = 0;
                    dtSave = rdr.GetDateTime(0);
                    for (int k = 0; k < iCount; k++)
                    {
                        dtTemp = dtSave.AddDays(1);
                        // Saturday(2) and Sunday(3) are holiday
                        while ((dtTemp.DayOfWeek == DayOfWeek.Saturday) || (dtTemp.DayOfWeek == DayOfWeek.Sunday)) dtTemp = dtTemp.AddDays(1);
                        dtSave = dtTemp;
                        txtProgress.AppendText(dtTemp.ToShortDateString() + "           \t\t\t");
                        reader.Read();
                        if (reader.GetDouble(1)>0)
                        {
                            dNew = Math.Round(reader.GetDouble(1),1);
                            txtProgress.AppendText(Math.Round(dNew, 1) + "");
                        }
                        else
                            txtProgress.AppendText("Not");

                        txtProgress.AppendText(Environment.NewLine);
                    }
                    bTrend = (dNew - dOld) >= 0 ? true : false;
                }
            }
            rdr.Close();
            reader.Close();

            // Check accuracy of Mining model
            cmd.CommandText = "SELECT PredictStdev([ClosePrice]),PredictVariance([ClosePrice]) FROM " + strStockCode;
            reader = cmd.ExecuteReader();
            reader.Read();

            // Display Standard Deviation value
            txtProgress.AppendText("=====================");
            txtProgress.AppendText(Environment.NewLine);
            txtProgress.AppendText("Giá trị độ lệch chuẩn: ");
            txtProgress.AppendText(reader.GetValue(0).ToString());
            txtProgress.AppendText(Environment.NewLine);
            txtProgress.AppendText("Giá trị độ lệch: ");
            txtProgress.AppendText(reader.GetValue(1).ToString());
            txtProgress.AppendText(Environment.NewLine);
            reader.Close();

            // Display trend
            int iTrend = AnalysisLib.IdentifyTrend(bTrend, dArrPast, strStockCode);
            string sTrend = ((iTrend % 10)==1) ? "Tăng" : "Giảm";
            txtProgress.AppendText("Xu hướng tương lai: " + sTrend);

            //Close connection
            cn.Close();
        }

        /*---------------------------------
         * Description: Forecast by TimeSeriesPredict + process Technology Analysis, Over Bid(mua)/Offer(ban)
         * Input:
         *  strStockCode: Stock Code
         *  iCount: quantity of future prediction
         *  txtProgress: textbox to show result
         * Output:
         *  True: Sucessful; False: Error
        ----------------------------------- */
        public static void ForecastTest(System.Windows.Forms.TextBox txtProgress, string strStockCode, int iCount, bool bAnalysis, bool bServey, bool bOver)
        {
            // Forecast quantity need more than 1 (>=1)
            if (iCount < 1) return;

            bool bTrend = true; //true: increase; false: decrease
            double dOld;

            // Data Engine
            DataSet dset = new DataSet();
            SqlConnection cn1 = new SqlConnection(str_Con_SQL);
            cn1.Open();
            //Create the Stock data adapter with the
            //calculated column appended
            SqlCommand cmd1 = new SqlCommand();

            // Assign connection object and sql query to command object
            cmd1.Connection = cn1;
            cmd1.CommandText = "SELECT FromDate, ToDate FROM StockForecastModel WHERE StockCode='" 
                + strStockCode + "'";
            SqlDataReader rdr = cmd1.ExecuteReader();
            rdr.Read();
            string sFromDate = rdr.GetDateTime(0).ToShortDateString();
            string sToDate = rdr.GetDateTime(1).ToShortDateString();
            rdr.Close();

            // Count record of from/to date
            cmd1.CommandText = "SELECT Count(ID) FROM " +
                strStockCode + " WHERE CloseDate <= '" + sToDate + "' AND CloseDate >='"
                + sFromDate + "'";
            rdr = cmd1.ExecuteReader();
            rdr.Read();
            int iCountRecord = rdr.GetInt32(0);
            rdr.Close();

            // Get historical values of from/to date
            cmd1.CommandText = "SELECT CloseDate, ClosePrice, OpenPrice, LowPrice, HighPrice, OverBid, OverOffer, Volume FROM " +
                strStockCode + " WHERE CloseDate <= '" + sToDate + "' AND CloseDate >='" 
                + sFromDate + "' ORDER BY CloseDate ASC";
            rdr = cmd1.ExecuteReader();

            // Display Historical data
            txtProgress.Text = "";
            txtProgress.AppendText("Ngày          \tGiá Quá Khứ        \tGiá Dự Báo");
            txtProgress.AppendText(Environment.NewLine);
            txtProgress.AppendText("=====================");
            txtProgress.AppendText(Environment.NewLine);
            txtProgress.AppendText("Dữ liệu quá khứ:");
            txtProgress.AppendText(Environment.NewLine);


            // Assign 10 last value of Historical values to Arrays and show all historical values in GUI
            double[,] dArrPast = new double[10, 4];
            int[,] iArrOver = new int[10, 2];
            int[] iArrVolume = new int[10];
            DateTime[] dtArrPast = new DateTime[10];
            int j = -1;
            for (int i = 0; i < iCountRecord; i++)
            {
                rdr.Read();
                //int a;
                if (i > iCountRecord - 11)
                {
                    j++;
                    dtArrPast[j] = rdr.GetDateTime(0);
                    dArrPast[j, 0] = rdr.GetDouble(1);
                    dArrPast[j, 1] = rdr.GetDouble(2);
                    dArrPast[j, 2] = rdr.GetDouble(3);
                    dArrPast[j, 3] = rdr.GetDouble(4);
                    try
                    {
                        iArrOver[j, 0] = rdr.GetInt32(5);// Bid/Buy: mua
                        iArrOver[j, 1] = rdr.GetInt32(6);//Offer/Sale: ban
                    }
                    catch (Exception e) { iArrOver[j, 0] = 0; iArrOver[j, 1] = 0; };
                    
                    iArrVolume[j] = rdr.GetInt32(7); // Volume

                    txtProgress.AppendText(dtArrPast[j].ToShortDateString() + "  \t" + dArrPast[j, 0].ToString() + "    \t\t");
                }
                else
                {
                    try
                    {
                        txtProgress.AppendText(rdr.GetDateTime(0).ToShortDateString() + "  \t" + rdr.GetDouble(1).ToString() + "    \t\t");
                    }
                    catch (Exception e1) { };
                }

                txtProgress.AppendText(Environment.NewLine);
            }

            rdr.Close();

            // Forecast value
            General.GetParam(); // get limit of price from DB, ex: +/-5%,+/-2%

            // Technology Analysis
            int iTrend = 0;
            if (bAnalysis)
                iTrend = AnalysisLib.IdentifyTrend(bTrend, dArrPast, strStockCode); // Use Analysis to change MAX,MIN in StockPredict model
            
            //Over Bid(Buy)/Offer(Sale)
            double dH=0;
            if (bOver)
                dH = UseOver(iArrVolume, iArrOver[9, 0], iArrOver[9, 1]);

            // Servey: bServey
            double dServey = 0;
            if (bServey)
                dServey = UseServey();

            AdomdConnection cn = new AdomdConnection(str_Con_Ana);
            AdomdCommand cmd = new AdomdCommand();
            cn.Open();
            cmd.Connection = cn;
            AdomdDataReader reader = null;

            txtProgress.AppendText(Environment.NewLine);
            txtProgress.AppendText("=====================");
            txtProgress.AppendText(Environment.NewLine);
            txtProgress.AppendText("Dự báo:");
            txtProgress.AppendText(Environment.NewLine);

            // Multi forecast
            DateTime dtForecast = dtArrPast[9];
            double dNew = 0;

            DateTime[] dtArrCDate = new DateTime[iCount];
            double[] dArrCPrice = new double[iCount];
            int iTmp = -1;

            // Get value of Multi Table
            try
            {
                cmd1.CommandText = "SELECT CloseDate, ClosePrice FROM " + strStockCode
                    + "_Multi WHERE CloseDate>'" + dtForecast.ToShortDateString() + "' ORDER BY CloseDate ASC";
                rdr = cmd1.ExecuteReader();
                while (rdr.Read())
                {
                    iTmp++;
                    dtArrCDate[iTmp] = rdr.GetDateTime(0);
                    dArrCPrice[iTmp] = rdr.GetDouble(1);
                }
                if (iTmp >= 0) dtForecast = dtArrCDate[iTmp];
            }
            catch (Exception e) { };
            rdr.Close();

            for (int k = 0; k < iCount; k++)
            {
                if (k <= iTmp) // forecast by getting forecasted values from file Multi
                {
                    dtForecast = dtArrCDate[k];
                    txtProgress.AppendText(dtArrCDate[k].ToShortDateString() + "           \t\t\t");
                    dNew = dArrCPrice[k];
                    txtProgress.AppendText(Math.Round(dArrCPrice[k], 2) + "");
                    txtProgress.AppendText(Environment.NewLine);
                }
                else // forecast by PredictTimeSeries
                {
                    dtForecast = DateInWeek(dtForecast);
                    cmd.CommandText = "select flattened PredictTimeSeries([ClosePrice],1,1) FROM " + strStockCode;
                    reader = cmd.ExecuteReader();
                    reader.Read();
                    if (reader.GetDouble(1) > 0)
                    {
                        //dNew = Math.Round(reader.GetDouble(1),1);
                        dNew = reader.GetDouble(1);
                        txtProgress.AppendText("Microsoft Time Series:");
                        txtProgress.AppendText(Environment.NewLine);
                        txtProgress.AppendText(dtForecast.ToShortDateString() + "           \t\t\t");
                        txtProgress.AppendText(Math.Round(dNew, 2) + "");
                        txtProgress.AppendText(Environment.NewLine);
                        if (k == 0)
                            if (bOver)   // Over
                            {
                                //dNew = Math.Round(dArrPast[9, 0] * (1 + ((dNew - dArrPast[9, 0]) / dArrPast[9, 0] + dH) / 2),1);
                                dNew = dArrPast[9, 0] * (1 + ((dNew - dArrPast[9, 0]) / dArrPast[9, 0] + dH) / 2);
                                txtProgress.AppendText("Sử dụng thêm Dư mua/Dư bán:");
                                txtProgress.AppendText(Environment.NewLine);
                                txtProgress.AppendText(dtForecast.ToShortDateString() + "           \t\t\t");
                                txtProgress.AppendText(Math.Round(dNew, 2) + "");
                                txtProgress.AppendText(Environment.NewLine);
                            }

                        if (bServey && k<4) // Servey
                        {
                            //dNew = Math.Round(dArrPast[9, 0] * (1 + ((dNew - dArrPast[9, 0]) / dArrPast[9, 0] + dServey) / 2),1);
                            dNew = dArrPast[9, 0] * (1 + ((dNew - dArrPast[9, 0]) / dArrPast[9, 0] + dServey) / 2);
                            txtProgress.AppendText("Sử dụng thêm khảo sát nhà đầu tư/chuyên gia:");
                            txtProgress.AppendText(Environment.NewLine);
                            txtProgress.AppendText(dtForecast.ToShortDateString() + "           \t\t\t");
                            txtProgress.AppendText(Math.Round(dNew, 2) + "");
                            txtProgress.AppendText(Environment.NewLine);
                        }



                        //txtProgress.AppendText(Math.Round(dNew, 1) + "");
                    }
                    else
                        txtProgress.AppendText("Not");
                    reader.Close();
                    if (iCount > 1)
                    {
                        // Store forecast value into Multi table
                        cmd1.CommandText = "INSERT INTO " + strStockCode + "_Multi(CloseDate,ClosePrice) VALUES('"
                            + dtForecast.ToShortDateString() + "'," + dNew.ToString().Replace(",", ".") + ")";
                        cmd1.ExecuteNonQuery();
                        // Add more a value into StockPredict DB and change MAX,MIN and reprocess model
                        ADOLib.MAXIMUM_SERIES_VALUE = dNew * (1 + General.iLimit);
                        ADOLib.MINIMUM_SERIES_VALUE = dNew * (1 - General.iLimit);
                        Server svr = new Server();
                        svr.Connect(str_Con_Server);

                        //bAll=true. Because bMulti=true => move all training data in Multi into StockPredict
                        ADOLib.UpdateTrainDB(svr, strStockCode, true, dtForecast, dtForecast, true);
                    }

                    txtProgress.AppendText(Environment.NewLine);
                }
                // Show real value (if have)
                try
                {
                    cmd1.CommandText = "SELECT ClosePrice FROM " +
                        strStockCode + " WHERE CloseDate = '" + dtForecast.ToShortDateString() + "'";
                    rdr = cmd1.ExecuteReader();
                    rdr.Read();
                    double dTmp = rdr.GetDouble(0);
                    txtProgress.AppendText("Giá trị thực tế:");
                    txtProgress.AppendText(Environment.NewLine);
                    txtProgress.AppendText(dtForecast.ToShortDateString() + "           \t\t\t");
                    txtProgress.AppendText(dTmp + "");
                    txtProgress.AppendText(Environment.NewLine);
                    txtProgress.AppendText("---");
                    txtProgress.AppendText(Environment.NewLine);
                    rdr.Close();
                }
                catch (Exception e) { rdr.Close(); }

            }
            bTrend = (dNew - dArrPast[9,0]) >= 0 ? true : false;



            txtProgress.AppendText("=====================");
            txtProgress.AppendText(Environment.NewLine);
            txtProgress.AppendText("Xu hướng tương lai:");
            txtProgress.AppendText(Environment.NewLine);

            // Analysis, Servey, Over
            
            // Display trend
            string sTrend;
            if (bAnalysis)
            {
                if (iTrend < 20)
                {
                    txtProgress.AppendText(" Phân tích kỹ thuật: không có mẫu đồ thị nào khớp với dữ liệu quá khứ của mô hình!");
                    txtProgress.AppendText(Environment.NewLine);
                }
                else
                {
                    sTrend = ((iTrend % 10) == 1) ? "Tăng" : "Giảm";
                    txtProgress.AppendText(" Phân tích kỹ thuật: " + sTrend);
                    txtProgress.AppendText(Environment.NewLine);
                }
            }

            sTrend = bTrend ? "Tăng" : "Giảm";
            txtProgress.AppendText(" Xu hướng sau cùng: " + sTrend);


            //Close connection
            cn.Close();
            cn1.Close();
        }

        /*---------------------------------
         * Description: In optimizing parameters, Check predict result of past and save checking into DB
        ----------------------------------- */        
        //public static double ForecastResult(string strStockCode, DateTime dtFrom, DateTime dtTo, int iID)
        //{
        //    int iTrend; //true: increase; false: decrease

        //    // Data Engine
        //    DataSet dset = new DataSet();
        //    SqlConnection cn1 = new SqlConnection(str_Con_SQL);
        //    cn1.Open();
        //    //Create the Stock data adapter with the
        //    //calculated column appended
        //    SqlCommand cmd1 = new SqlCommand();

        //    iID++;
        //    // Assign connection object and sql query to command object
        //    cmd1.Connection = cn1;
        //    SqlDataReader rdr;
        //    cmd1.CommandText = "SELECT TOP 2 ClosePrice FROM " +
        //        strStockCode + " WHERE ID <= " + iID + " ORDER BY ID DESC";
        //    rdr = cmd1.ExecuteReader();
        //    rdr.Read();
        //    double dVal = rdr.GetDouble(0);
        //    rdr.Read();
        //    double dPrev = rdr.GetDouble(0);
        //    rdr.Close();

        //    // Get forecase value
        //    AdomdConnection cn = new AdomdConnection(str_Con_Ana);
        //    AdomdCommand cmd = new AdomdCommand();
        //    cmd.Connection = cn;
        //    cmd.CommandText = "select flattened PredictTimeSeries([ClosePrice],1,1) FROM " + strStockCode;
        //    cn.Open();
        //    AdomdDataReader reader = cmd.ExecuteReader();
        //    reader.Read();
        //    double dForecast = Math.Round(reader.GetDouble(1),1);
        //    double dPercent = Math.Round((Math.Abs(dForecast-dVal))/dVal,2);
        //    reader.Close();

        //    iTrend = ((dForecast - dPrev) * (dVal - dPrev)) >= 0 ? 1 : 0;


        //    // Insert into Result table
        //    cmd1.CommandText = "INSERT INTO " + strStockCode + "_RESULT VALUES("
        //        + ADOLib.COMPLEXITY_PENALTY.ToString().Replace(",", ".") + ","
        //        + ADOLib.AUTO_DETECT_PERIODICITY.ToString().Replace(",", ".") + ","
        //        + ADOLib.MAXIMUM_SERIES_VALUE.ToString().Replace(",", ".") + ","
        //        + ADOLib.MINIMUM_SERIES_VALUE.ToString().Replace(",", ".") + ","
        //        + ADOLib.HISTORIC_MODEL_COUNT + ","
        //        + ADOLib.HISTORIC_MODEL_GAP + ",'"
        //        + dtFrom.ToShortDateString() + "','"
        //        + dtTo.ToShortDateString() + "',"
        //        + dPrev.ToString().Replace(",", ".") + ","
        //        + dVal.ToString().Replace(",", ".") + ","
        //        + dForecast.ToString().Replace(",", ".") + ","
        //        + iTrend + ","
        //        + dPercent.ToString().Replace(",", ".") + ")";
        //    cmd1.ExecuteNonQuery();

        //    //Close connection
        //    cn.Close();
        //    cn1.Close();
        //    // return percentage
        //    return dPercent;
        //}

 

        /*---------------------------------
         * Description: Check value of Field
         * Input:
         *  sField: name of field
         *  sTmp: source string
         *  dVal
         * Output:
         *  true: pass; false: fail
        ----------------------------------- */
        private static bool CheckValue(string sField, string sTmp, double dVal)
        {
            bool bSign = false;
            string sVal;
            int iPos;
            if ((iPos=sTmp.IndexOf(sField))>=0)
            {
                // Handle value: only between [1-9] addition
                if (sTmp.Substring(iPos + 1, 1) == "-")
                {
                    dVal -= Convert.ToDouble(sTmp.Substring(iPos + 2, 1));
                }
                else if (sTmp.Substring(iPos + 1, 1) == "+")
                {
                    dVal += Convert.ToDouble(sTmp.Substring(iPos + 2, 1));
                }
    

                // Handle sign(>=,<)
                if (sTmp.Contains(">"))
                {
                    sVal = sTmp.Substring(sTmp.IndexOf(">=") + 3);
                    if (dVal > Convert.ToDouble(sVal))
                        bSign = true;
                }
                else
                {
                    sVal = sTmp.Substring(sTmp.IndexOf("<") + 2);
                    if (dVal < Convert.ToDouble(sVal))
                        bSign = true;
                }
            }
            return bSign;
        }

        /*---------------------------------
         * Description: In optimizing parameters, Check predict result of past and save checking into DB
         * Input:
         *  strStockCode: Stock code
         * Output:
         *  true: continue; false: stop
        ----------------------------------- */        
        public static bool CheckResult(string strStockCode)
        {
            // Data Engine
            DataSet dset = new DataSet();
            SqlConnection cn1 = new SqlConnection(str_Con_SQL);
            cn1.Open();
            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = cn1;
            cmd1.CommandText = "SELECT TOP 2 CloseDate, ClosePrice FROM " +
                strStockCode + " WHERE CloseDate >= (SELECT ToDate FROM StockForecastModel WHERE StockCode='" + strStockCode + "') ORDER BY CloseDate ASC";
            SqlDataReader rdr = cmd1.ExecuteReader();


            // Analysis Service
            AdomdConnection cn = new AdomdConnection(str_Con_Ana);
            AdomdCommand cmd = new AdomdCommand();
            cmd.Connection = cn;
            cmd.CommandText = "select flattened predicttimeseries([ClosePrice],1,1) FROM " + strStockCode;
            cn.Open();
            AdomdDataReader reader = cmd.ExecuteReader();
            try
            {
                // Check Accuracy
                double dPrev, dCur, dF, dG;
                DateTime dtCur;
                rdr.Read();
                dPrev = rdr.GetDouble(1);

                rdr.Read();
                dtCur = rdr.GetDateTime(0);
                dCur = rdr.GetDouble(1);

                reader.Read();
                dF = Math.Round(reader.GetDouble(1),1);

                int iTrend = ((dF-dPrev)*(dCur-dPrev))>=0? 1 : 0 ;
                dG = Math.Round((dF - dCur)/dCur,2);

                // Close Reader
                rdr.Close();
                reader.Close();

                // Insert result into DB
                string sTemp = "INSERT INTO " + strStockCode + "_CR("+
                    "COMPLEXITY_PENALTY, AUTO_DETECT_PERIODICITY, HISTORIC_MODEL_COUNT, HISTORIC_MODEL_GAP, TREND," +
                    "GA,PrevVal,CurDate,CurVal,ForeVal) VALUES(" +
                    ADOLib.COMPLEXITY_PENALTY.ToString().Replace(',','.') + "," + ADOLib.AUTO_DETECT_PERIODICITY.ToString().Replace(',','.')
                    + "," + ADOLib.HISTORIC_MODEL_COUNT + "," + ADOLib.HISTORIC_MODEL_GAP + "," + iTrend
                    + "," + dG.ToString().Replace(",",".") 
                    + "," + dPrev.ToString().Replace(",",".") 
                    + "," +  dtCur.ToShortDateString()
                    + "," + dCur.ToString().Replace(",",".") 
                    + "," + dF.ToString().Replace(",",".")               
                    + ")";
                
                cmd1.CommandText = sTemp;
                cmd1.ExecuteNonQuery();

                // Close connection
                cn.Close();

                // Continue loop
                if (iTrend==1 && dG<=0.05)
                {   
                    return false;
                }
                // Stop loop
                else
                    return true;
            }
            catch (Exception ex) { return true; }

        }

        /*---------------------------------
         * Description: In optimizing parameters, Check predict result of test and save checking into DB
         * Input:
         *  strStockCode: Stock code
         * Output:
         *  true: continue; false: stop
        ----------------------------------- */
        public static bool CheckResultTest(string strStockCode, DateTime dtTo)
        {
            // Data Engine
            DataSet dset = new DataSet();
            SqlConnection cn1 = new SqlConnection(str_Con_SQL);
            cn1.Open();
            //Create the Stock data adapter with the
            //calculated column appended
            SqlCommand cmd1 = new SqlCommand();          

            cmd1.Connection = cn1;
            cmd1.CommandText = "SELECT TOP 2 ClosePrice FROM " +
                strStockCode + " WHERE CloseDate >= '" + dtTo.ToShortDateString() + "'";
            SqlDataReader rdr = cmd1.ExecuteReader();


            // Analysis Service
            // Create connection and command objects.
            AdomdConnection cn = new AdomdConnection(str_Con_Ana);
            AdomdCommand cmd = new AdomdCommand();
            //Initialize command with query
            cmd.Connection = cn;

            cmd.CommandText = "select flattened predicttimeseries([ClosePrice],1,1) FROM " + strStockCode;

            // Open connection and execute query
            cn.Open();

            AdomdDataReader reader = cmd.ExecuteReader();
            try
            {
                // Check Accuracy
                double dForecast, dPrev, dPrev1, dD;
                bool bTrend;
                reader.Read();
                dForecast = Math.Round(reader.GetDouble(1), 1);

                rdr.Read();
                dPrev1 = rdr.GetDouble(0);
                rdr.Read();
                dPrev = rdr.GetDouble(0);

                dD = Math.Round(Math.Abs(dForecast-dPrev)/dPrev,2);
                if ((dPrev - dPrev1) * (dForecast - dPrev1) >= 0) bTrend = true;
                else bTrend = false;


                // Close Reader
                rdr.Close();
                reader.Close();


                // Insert result into DB
                string sTemp = "INSERT INTO " + strStockCode + "_CRT VALUES("
                + ADOLib.COMPLEXITY_PENALTY.ToString().Replace(',','.') 
                + "," + ADOLib.AUTO_DETECT_PERIODICITY.ToString().Replace(',','.')
                + "," + ADOLib.MAXIMUM_SERIES_VALUE.ToString().Replace(',', '.')
                + "," + ADOLib.MINIMUM_SERIES_VALUE.ToString().Replace(',', '.')
                + "," + ADOLib.HISTORIC_MODEL_COUNT 
                + "," + ADOLib.HISTORIC_MODEL_GAP
                + "," + dPrev1.ToString().Replace(',', '.')
                + "," + dPrev.ToString().Replace(',', '.') 
                + "," + dForecast.ToString().Replace(',', '.') 
                + "," + ((bTrend) ? "1" : "0") + "," + dD.ToString().Replace(',', '.') + ")";
                cmd1.CommandText = sTemp;
                cmd1.ExecuteNonQuery();

                // Close connection
                cn.Close();
                cn1.Close();

                // Stop loop: right trend and <5%
                if (bTrend && dD <= 0.05)
                    return false;
                // Continue loop
                else
                    return true;
            }
            catch (Exception ex) { return false; }

        }

        /*---------------------------------
         * Description: Export data from DB to CSV files (Stock.csv)
         * Input:
         *  strStockCode: Name of CSV file
         *  strPath: Path of CSV file
         * Output:
         *  True: Sucessful; False: Error
        ----------------------------------- */
        public static bool ExportCSV(string strStockCode, string strPath)
        {
            // Data Engine
            DataSet dset = new DataSet();
            SqlConnection cn1 = new SqlConnection(str_Con_SQL);
            cn1.Open();
            SqlCommand cmd1 = new SqlCommand();
            // Assign connection object and sql query to command object
            cmd1.Connection = cn1;
            SqlDataReader rdr;

            cmd1.CommandText = "SELECT CloseDate, OpenPrice, HighPrice, LowPrice, ClosePrice, Volume FROM " +
                    strStockCode + " ORDER BY CloseDate DESC";
            rdr = cmd1.ExecuteReader();
            if (!rdr.HasRows) return false;
            StreamWriter sw = new StreamWriter(strPath + "\\" + strStockCode + ".csv");

            // Write to stock.csv file
            sw.WriteLine("Date,Open,High,Low,Close,Volume");
            while (rdr.Read())
            {
                sw.WriteLine(rdr.GetDateTime(0).ToString("dd-MMM-yy") + "," + rdr.GetDouble(1).ToString().Replace(',', '.') + "," +
                    rdr.GetDouble(2).ToString().Replace(',', '.') + "," + rdr.GetDouble(3).ToString().Replace(',', '.')
                    + "," + rdr.GetDouble(4).ToString().Replace(',', '.') + "," + rdr.GetInt32(5).ToString());
            }
            sw.Close();
            rdr.Close();
            cn1.Close();
            return true;
        }
        /*---------------------------------
         * Description: Export data from DB and Analysis DB to 2 CSV files (Stock.csv, Stock_ForeCast.csv)
         * Input:
         *  strStockCode: Name of CSV file
         *  strPath: Path of CSV file
         * Output:
         *  True: Sucessful; False: Error
        ----------------------------------- */
        public static bool Export2CSV(string strStockCode, string strPath)
        {
            // Data Engine
            DataSet dset = new DataSet();
            SqlConnection cn1 = new SqlConnection(str_Con_SQL);
            cn1.Open();
            SqlCommand cmd1 = new SqlCommand();
            // Assign connection object and sql query to command object
            cmd1.Connection = cn1;
            SqlDataReader rdr;

            cmd1.CommandText = "SELECT CloseDate, OpenPrice, HighPrice, LowPrice, ClosePrice, Volume FROM " +
                    strStockCode + " ORDER BY CloseDate DESC";
            rdr = cmd1.ExecuteReader();
            if (!rdr.HasRows) return false;

            StreamWriter sw = new StreamWriter(strPath + "\\" + strStockCode + ".csv");

            // Write to stock.csv file
            sw.WriteLine("Date,Open,High,Low,Close,Volume");
            int i = 0, j=0;
            DateTime[] arrTemp = new DateTime[11];
            while (rdr.Read())
            {
                i++;
                sw.WriteLine(rdr.GetDateTime(0).ToString("dd-MMM-yy") + "," + rdr.GetDouble(1).ToString().Replace(',','.') + "," +
                    rdr.GetDouble(2).ToString().Replace(',', '.') + "," + rdr.GetDouble(3).ToString().Replace(',', '.')
                    + "," + rdr.GetDouble(4).ToString().Replace(',', '.') + "," + rdr.GetInt32(5).ToString());
                if (i < 11)
                {
                    // Date of forecast
                    if (j == 0)
                    {
                        int k = 1;
                        DateTime dtTemp = rdr.GetDateTime(0).AddDays(1);
                        // Saturday(2) and Sunday(3) are holiday
                        while ((dtTemp.DayOfWeek == DayOfWeek.Saturday) || (dtTemp.DayOfWeek == DayOfWeek.Sunday)) dtTemp = dtTemp.AddDays(1);
                        arrTemp[j] = dtTemp;
                    }
                    j++;
                    arrTemp[j] = rdr.GetDateTime(0);
                }
            }
            sw.Close();
            rdr.Close();
            cn1.Close();

            // Analysis Service
            // Create connection and command objects.
            AdomdConnection cn = new AdomdConnection(str_Con_Ana);
            AdomdCommand cmd = new AdomdCommand();
            //Initialize command with query
            cmd.Connection = cn;

            cmd.CommandText = "select flattened predicttimeseries([ClosePrice],-9,1" +
            ") FROM " + strStockCode;

            // Open connection and execute query
            cn.Open();
            AdomdDataReader reader = cmd.ExecuteReader();

            //  If query of CSV is null, quit function
            if (j == 0) return false;
                
            sw = new StreamWriter(strPath + "\\" + strStockCode + "_forecast.csv");

            // Write to stock_forecast.csv file
            sw.WriteLine("Date,Close");

            i = 0;
            string s;
            string[] arrFClose = new string[11];
            while (reader.Read())
            {
                if (reader.GetValue(1) == null) arrFClose[i]="";
                else arrFClose[i] = Convert.ToString(Math.Round(reader.GetDouble(1), 1)).Replace(',', '.');
                i++;
            }
            j = 0;
            for (i = 10; i >= 0; i--)
            {
                sw.WriteLine(arrTemp[j].ToString("dd-MMM-yy") + "," + arrFClose[i]);
                j++;
            }
            sw.Close();
            reader.Close();
            cn.Close();
            return true;
        }

        /*---------------------------------
         * Description: Export data from DB: Stock + Stock_Multi to 2 CSV files (Stock.csv, Stock_ForeCast.csv)
         * Input:
         *  strStockCode: Name of CSV file
         *  strPath: Path of CSV file
         * Output:
         *  True: Sucessful; False: Error
        ----------------------------------- */
        public static bool ExportMulti2CSV(string strStockCode, string strPath)
        {
            // Data Engine
            DataSet dset = new DataSet();
            SqlConnection cn1 = new SqlConnection(str_Con_SQL);
            cn1.Open();
            SqlCommand cmd1 = new SqlCommand();
            // Assign connection object and sql query to command object
            cmd1.Connection = cn1;
            SqlDataReader rdr;
            StreamWriter sw;
            // Export Stock table to CSV
            cmd1.CommandText = "SELECT CloseDate, OpenPrice, HighPrice, LowPrice, ClosePrice, Volume FROM " +
                    strStockCode + " ORDER BY CloseDate DESC";
            rdr = cmd1.ExecuteReader();
            if (!rdr.HasRows) return false;

            sw = new StreamWriter(strPath + "\\" + strStockCode + ".csv");

            // Write to stock.csv file
            sw.WriteLine("Date,Open,High,Low,Close,Volume");
            while (rdr.Read())
                sw.WriteLine(rdr.GetDateTime(0).ToString("dd-MMM-yy") + "," + rdr.GetDouble(1).ToString().Replace(',', '.') + "," +
                    rdr.GetDouble(2).ToString().Replace(',', '.') + "," + rdr.GetDouble(3).ToString().Replace(',', '.')
                    + "," + rdr.GetDouble(4).ToString().Replace(',', '.') + "," + rdr.GetInt32(5).ToString());

            sw.Close();
            rdr.Close();


            // Export Stock_Multi table to CSV
            //cmd1.CommandText = "SELECT CloseDate, ClosePrice FROM StockForecastModel," +
            //    strStockCode + "_multi WHERE StockCode='" + strStockCode 
            //    + "' AND CloseDate>ToDate ORDER BY CloseDate DESC";

            cmd1.CommandText = "SELECT CloseDate, ClosePrice FROM " +
                strStockCode + "_multi ORDER BY CloseDate DESC";


            rdr = cmd1.ExecuteReader();
            if (!rdr.HasRows) return false;

            sw = new StreamWriter(strPath + "\\" + strStockCode + "_forecast.csv");

            // Write to stock_forecast.csv file
            sw.WriteLine("Date,Close");
            while (rdr.Read())
                sw.WriteLine(rdr.GetDateTime(0).ToString("dd-MMM-yy") + "," + rdr.GetDouble(1).ToString().Replace(',', '.'));

            sw.Close();
            rdr.Close();

            // Close connection
            cn1.Close();
            return true;
        }


        public static void IncProcess(string strStockCode, string sFileName, bool bCon)
        {
            // Check exist tables (UR, CR)
            ADOMDLib.ExistExpandTable(strStockCode,"_UR", bCon);

            // Data Engine
            DataSet dset = new DataSet();
            SqlConnection cn1 = new SqlConnection(str_Con_SQL);
            cn1.Open();
            //Create the Stock data adapter with the
            //calculated column appended
            SqlCommand cmd1 = new SqlCommand();

            // Assign connection object and sql query to command object
            cmd1.Connection = cn1;
            cmd1.CommandText = "SELECT TOP 1 ClosePrice, CloseDate FROM " +
                strStockCode + " ORDER BY ID DESC";
            SqlDataReader rdr = cmd1.ExecuteReader();


            // Analysis Service
            // Create connection and command objects.
            AdomdConnection cn = new AdomdConnection(str_Con_Ana);
            AdomdCommand cmd = new AdomdCommand();
            //Initialize command with query
            cmd.Connection = cn;

            cmd.CommandText = "SELECT flattened predicttimeseries([ClosePrice],0,1) FROM " + strStockCode;

            // Open connection and execute query
            cn.Open();
            AdomdDataReader reader = cmd.ExecuteReader();

            // Update new data
            rdr.Read();
            double dPrevH = rdr.GetDouble(0);

            reader.Read();
            double dPrevF = reader.GetFloat(1);


            reader.Read();
            double dCurF = reader.GetFloat(1);

            double dTrend = dCurF - dPrevF;

            DateTime dtCloseDate = rdr.GetDateTime(1);

            rdr.Close();
            reader.Close();

            ParseData.IncrementalByDate(strStockCode, dtCloseDate, dCurF, dPrevH, dTrend, sFileName, cn1);


            //Close connection
            cn.Close();
        }


        public static void IncAllProcess(string strStockCode, string sFileName, bool bCon)
        {
            // Check exist tables (UR, CR)
            ADOMDLib.ExistExpandTable(strStockCode,"_UR", bCon);

            // Data Engine
            DataSet dset = new DataSet();
            SqlConnection cn1 = new SqlConnection(str_Con_SQL);
            cn1.Open();
            //Create the Stock data adapter with the
            //calculated column appended
            SqlCommand cmd1 = new SqlCommand();

            // Assign connection object and sql query to command object
            cmd1.Connection = cn1;

            cmd1.CommandText = "SELECT TOP 1 ClosePrice, CloseDate FROM " +
                strStockCode + " ORDER BY ID DESC";

            // Analysis Service
            // Create connection and command objects.
            AdomdConnection cn = new AdomdConnection(str_Con_Ana);
            AdomdCommand cmd = new AdomdCommand();
            //Initialize command with query
            cmd.Connection = cn;

            cmd.CommandText = "select flattened predicttimeseries([ClosePrice],0,1) FROM " + strStockCode;

            // Open connection and execute query
            cn.Open();
            double dPrevF, dCurF, dPrevH, dCurH, dTrend;
            DateTime dtCloseDate;

            do
            {
                SqlDataReader rdr = cmd1.ExecuteReader();

                AdomdDataReader reader = cmd.ExecuteReader();

                // Update new data
                rdr.Read();
                dPrevH = rdr.GetDouble(0);

                reader.Read();
                dPrevF = reader.GetFloat(1);


                reader.Read();
                dCurF = reader.GetFloat(1);

                dTrend = dCurF - dPrevF;

                dtCloseDate = rdr.GetDateTime(1);

                rdr.Close();
                reader.Close();
            }
            while (ParseData.IncrementalByDate(strStockCode, dtCloseDate, dCurF, dPrevH, dTrend, sFileName, cn1));


            //Close connection
            cn.Close();
        }

        /*---------------------------------
         * Description: Check expand tables: _CR, _UR. First, search. If exist then rename. The last, create new table
         * Input:
         *  strStockCode: Code of Stock
         *  strTag: UR,CR
         *  bDrop: True: drop the expand table; False: keep expand table
         * Query: 
         *  DROP TABLE table_name
         *  EXEC sp_rename 'table_name_source','table_name_dest'
         *  SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES
        ----------------------------------- */
        public static void ExistExpandTable(string strStockCode, string strTag, bool bDrop)
        {
            SqlConnection conn = new SqlConnection(str_Con_SQL);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            // Search a table in database
            string strQuery = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='" + strStockCode + strTag + "'";
            cmd.CommandText = strQuery;
            SqlDataReader rdr = cmd.ExecuteReader();

            // If exist then depend bDrop to drop or continue with expanded table
            if (rdr.Read())
            {
                rdr.Close();
                // Rename table
                //strQuery = "EXEC sp_rename '" + strStockCode + strTag + "', '" + strStockCode + "_" + strTag + "_" + DateTime.Now.ToString() + "'";
                //cmd.CommandText = strQuery;
                //cmd.ExecuteNonQuery();
                //cmd.Dispose();

                // Drop table
                if (!bDrop)
                {
                    strQuery = "DROP TABLE " + strStockCode + strTag;
                    cmd.CommandText = strQuery;
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    if (strTag.Equals("_UR")) ParseData.CreateURStockTable(strStockCode, cmd);
                    else if (strTag.Equals("_CR")) ParseData.CreateCRStockTable(strStockCode, cmd);
                    else ParseData.CreateCRTStockTable(strStockCode, cmd);
                }
                conn.Close();

            }
            // Not exist then create expanded table
            else
            {
                rdr.Close();
                // Create expanded table
                if (strTag.Equals("_UR")) ParseData.CreateURStockTable(strStockCode, cmd);
                else if (strTag.Equals("_CR")) ParseData.CreateCRStockTable(strStockCode, cmd);
                else ParseData.CreateCRTStockTable(strStockCode, cmd);
                conn.Close();
            }

        }
        

        /*---------------------------------
         * Description: Search next normal date in week (not Saturday/Sunday)
        ----------------------------------- */
        private static DateTime DateInWeek(DateTime dtOld)
        {
            DateTime dtTemp = dtOld.AddDays(1);
            // Saturday(2) and Sunday(3) are holiday
            while ((dtTemp.DayOfWeek == DayOfWeek.Saturday) || (dtTemp.DayOfWeek == DayOfWeek.Sunday)) dtTemp = dtTemp.AddDays(1);
            return dtTemp;
        }

        /*---------------------------------
         * Description: remove old forecasted values in Multi and reprocess StockPredict DB
        ----------------------------------- */
        public static void ResetMulti(string sStockCode, bool bUpdateStockPredict)
        {
            SqlConnection cn1 = new SqlConnection(str_Con_SQL);
            cn1.Open();
            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = cn1;
            cmd1.CommandText = "SELECT ToDate FROM StockForecastModel WHERE StockCode='" + sStockCode + "'";
            SqlDataReader rdr = cmd1.ExecuteReader();
            rdr.Read();
            DateTime dtTo = rdr.GetDateTime(0);
            rdr.Close();
            cmd1.CommandText = "SELECT ClosePrice FROM " + sStockCode + " WHERE CloseDate='"
                + dtTo.ToShortDateString() + "'";
            rdr = cmd1.ExecuteReader();
            rdr.Read();
            double dCPrice = rdr.GetDouble(0);
            rdr.Close();

            
            cmd1.CommandText = "DELETE FROM " + sStockCode + "_Multi WHERE CloseDate>'" + dtTo.ToShortDateString() + "'";
            cmd1.ExecuteNonQuery();

            General.GetParam();
            ADOLib.MAXIMUM_SERIES_VALUE = dCPrice * (1 + General.iLimit);
            ADOLib.MINIMUM_SERIES_VALUE = dCPrice * (1 - General.iLimit);
            Server svr = new Server();
            svr.Connect(str_Con_Server);
            //bAll=true. Because bMulti=true => move all training data in Multi into StockPredict
            if (bUpdateStockPredict)
                ADOLib.UpdateTrainDB(svr, sStockCode, true, dtTo, dtTo, true);
        }

        /*---------------------------------
         * Description: process Over Bid(mua=buy)/Offer(ban=sale)
        ----------------------------------- */
        public static double UseOver(int[] iArrVolume, int iOBuy, int iOSale)
        {
            double dH = 0;
            double dOAvg = 0, dODiff;
            for (int i = 5; i < 10; i++) dOAvg += iArrVolume[i];
            dOAvg /= 5;
            dODiff = (iOBuy - iOSale) / dOAvg;

            if (dODiff == 0) dH = 5;
            else if (dODiff > 0) dH = 5 / (10 * dODiff + 1);
            else dH = 10 - (5 / (1 - 10 * dODiff));

            dH = (((dH * 2 * General.iLimit) / 10) - General.iLimit) / 100;

            return dH;
        }

        /*---------------------------------
         * Description: process Servey: trong pham vi % tang/giam: +/-5%
        ----------------------------------- */
        public static double UseServey()
        {
            return -0.02;
        }
    }
}
