using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

//using Microsoft.Practices.EnterpriseLibrary.Data;
//using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.SqlClient;


namespace StockPredict
{
    public class ParseData
    {
        // connection string to SQL server
        //const string conStr = "Server=Localhost;Integrated Security=false;UID=sa;PWD=tinhban;Database=Stock";
        public static string str_Con_SQL = "Data Source=localhost;" +
               "Initial Catalog=Stock;Integrated Security=true";

        //public static SqlConnection conn;
       
        public ParseData()
        {
            ////Create Connection
            //conn = new SqlConnection(str_Con_SQL);
            //conn.Open();
        }

        /*---------------------------------
         * void CreateStockTable(string StockName)
         * Description: Create a new Stock Table
         * Input:
         *      StockCode: name of new Stock Table
        ----------------------------------- */
        private static void CreateStockTable(string sStockCode, SqlCommand cmdCreateTable)
        {
            try
            {
                // Search a table in database
                string sQuery = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='" + sStockCode + "'";
                cmdCreateTable.CommandText = sQuery;
                SqlDataReader rdr = cmdCreateTable.ExecuteReader();

                // If exist then Exit
                if (rdr.Read()) rdr.Close();
                else
                {
                    rdr.Close();
                    cmdCreateTable.Dispose();
                    cmdCreateTable.CommandText = "CREATE TABLE [dbo].[" + sStockCode + "](" +
                        "[ID] [int] IDENTITY(1,1) NOT NULL," +
                        "[CloseDate] [datetime] NULL," +
                        "[OpenPrice] [float] NULL," +
                        "[HighPrice] [float] NULL," +
                        "[LowPrice] [float] NULL," +
                        "[ClosePrice] [float] NULL," +
                        "[Volume] [int] NULL," +
                        "CONSTRAINT [PK_" + sStockCode + "] PRIMARY KEY CLUSTERED " +
                        "( [ID] ASC )WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]" +
                        ") ON [PRIMARY]";
                    cmdCreateTable.ExecuteNonQuery();
                    cmdCreateTable.Dispose();
                }

            }
            catch (Exception ex)
            { }
        }
        
        public static void CreateStockCompressTable(string sStockCode, SqlCommand cmdCreateTable)
        {
            try
            {
                // Search a table in database
                string sQuery = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='" + sStockCode + "_Compress'";
                cmdCreateTable.CommandText = sQuery;
                SqlDataReader rdr = cmdCreateTable.ExecuteReader();

                // If exist then Exit
                if (rdr.Read()) rdr.Close();
                else
                {
                    rdr.Close();
                    cmdCreateTable.Dispose();
                    cmdCreateTable.CommandText = "CREATE TABLE [dbo].[" + sStockCode + "_Compress](" +
                        "[ID] [int] IDENTITY(1,1) NOT NULL," +
                        "[CloseDate] [datetime] NULL," +
                        "[OpenPrice] [float] NULL," +
                        "[HighPrice] [float] NULL," +
                        "[LowPrice] [float] NULL," +
                        "[ClosePrice] [float] NULL," +
                        "[Volume] [int] NULL," +
                        "CONSTRAINT [PK_" + sStockCode + "_Compress] PRIMARY KEY CLUSTERED " +
                        "( [ID] ASC )WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]" +
                        ") ON [PRIMARY]";
                    cmdCreateTable.ExecuteNonQuery();
                    cmdCreateTable.Dispose();
                }

            }
            catch (Exception ex)
            { }
        }
        /*---------------------------------
         * void CreateURStockTable(string StockName)
         * Description: Create a new Update Stock Table which is saved parameters for updating
         * Input:
         *      StockName: name of new Stock Table
        ----------------------------------- */
        public static void CreateURStockTable(string StockName, SqlCommand cmdCreateTable)
        {
            try
            {
                cmdCreateTable.CommandText = "CREATE TABLE [dbo].[" + StockName + "_UR](" +
                        "[ID] [int] IDENTITY(1,1) NOT NULL," +
	                    "[ClosePrice] [float] NULL," +
	                    "[PredictPrice] [float] NULL," +
	                    "[GR] [float] NULL," +
                        "[Trend] [bit] NULL " +
                    "CONSTRAINT [PK_" + StockName + "_UR] PRIMARY KEY CLUSTERED " +
                    "( [ID] ASC )WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]" +
                    ") ON [PRIMARY]";

                cmdCreateTable.ExecuteNonQuery();
                cmdCreateTable.Dispose();
            }

            catch (Exception ex)
            { }
        }

        /*---------------------------------
          * void CreateTable
          * Description: Create a new Table
          * Input:
          *      
         ----------------------------------- */
        public static void CreateTable(string srcName, string destName)
        {
            try
            {
                SqlConnection conn = new SqlConnection(str_Con_SQL);
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                string strQuery = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='" + destName + "'";
                cmd.CommandText = strQuery;
                SqlDataReader rdr = cmd.ExecuteReader();

                // If not exist then depend bDrop to drop or continue with expanded table
                if (!rdr.Read())
                {
                    rdr.Close();
                    cmd.CommandText = "SELECT * INTO " + destName + " FROM " + srcName;
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
            }
            catch (Exception ex)
            { }
        }

        /*---------------------------------
         * void CreateCRStockTable(string StockName)
         * Description: Create a new Stock Table
         * Input:
         *      StockName: name of new Stock Table
        ----------------------------------- */
        public static void CreateCRStockTable(string StockName, SqlCommand cmdCreateTable)
        {
            try
            {
                cmdCreateTable.CommandText = "CREATE TABLE [dbo].[" + StockName + "_CR](" +
	                "[ID] [int] IDENTITY(1,1) NOT NULL," +
	                "[COMPLEXITY_PENALTY] [float] NOT NULL," +
	                "[AUTO_DETECT_PERIODICITY] [float] NOT NULL," +
                    "[HISTORIC_MODEL_COUNT] [int] NOT NULL," +
                    "[HISTORIC_MODEL_GAP] [int] NOT NULL," +
	                "[TREND] [bit] NULL," +
	                "[GA] [float] NULL," +
                    "[PrevVal] [float] NULL," +
                    "[CurDate] [datetime] NULL," +
                    "[CurVal] [float] NULL," +
                    "[ForeVal] [float] NULL " +
                 "CONSTRAINT [PK_" + StockName + "_CR] PRIMARY KEY CLUSTERED " +
                "(" +
	                "[COMPLEXITY_PENALTY] ASC," +
	                "[AUTO_DETECT_PERIODICITY] ASC," +
                    "[HISTORIC_MODEL_COUNT] ASC," +
                    "[HISTORIC_MODEL_GAP] ASC" +
                ")WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]" +
                                    ") ON [PRIMARY]";

                cmdCreateTable.ExecuteNonQuery();
                cmdCreateTable.Dispose();
            }

            catch (Exception ex)
            { }
        }


        /*---------------------------------
         * void CreateCRTStockTable(string StockName)
         * Description: Create a new Stock Table
         * Input:
         *      sStockCode: name of new Stock Table
        ----------------------------------- */
        public static void CreateCRTStockTable(string sStockCode, SqlCommand cmdCreateTable)
        {
            try
            {
                cmdCreateTable.CommandText = "CREATE TABLE [dbo].[" + sStockCode + "_CRT](" +
                    "[COMPLEXITY_PENALTY] [float] NOT NULL," +
                    "[AUTO_DETECT_PERIODICITY] [float] NOT NULL," +
                    "[MAXIMUM_SERIES_VALUEY] [float] NOT NULL," +
                    "[MINIMUM_SERIES_VALUE] [float] NOT NULL," +
                    "[HISTORIC_MODEL_COUNT] [int] NOT NULL," +
                    "[HISTORIC_MODEL_GAP] [int] NOT NULL," +
                    "[PrevVal] [float] NULL," +
                    "[CurVal] [float] NULL," +
                    "[ForecastVal] [float] NULL," +
                    "[Trend] [bit] NULL," +
                    "[Percentage] [float] NULL)";

                cmdCreateTable.ExecuteNonQuery();
                cmdCreateTable.Dispose();
            }

            catch (Exception ex)
            { }
        }

        /*---------------------------------
         * void CreateStockTransaction(string StockName)
         * Description: Create a new Stock Transaction Table
         * Input:
         *      StockName: name of new Stock Table
        ----------------------------------- */
        private void CreateStockTransaction(string StockName, SqlCommand cmdCreateTable)
        {
            try
            {
                cmdCreateTable.CommandText = "CREATE TABLE [dbo].[" + StockName + "_Transaction](" +
                    "[ID] [int] IDENTITY(1,1) NOT NULL," +
                    "[SysDate] [datetime] NULL," +
                    "[OpenPrice] [float] NULL," +
                    "[BuyPrice1] [float] NULL," +
                    "[BuyQuantity1] [int] NULL," +
                    "[BuyPrice2] [float] NULL," +
                    "[BuyQuantity2] [float] NULL," +
                    "[BuyPrice3] [float] NULL," +
                    "[BuyQuantity3] [float] NULL," +
                    "[Price] [float] NULL," +
                    "[Quantity] [int] NULL," +
                    "[SalePrice1] [float] NULL," +
                    "[SaleQuantity1] [int] NULL," +
                    "[SalePrice2] [float] NULL," +
                    "[SaleQuantity2] [float] NULL," +
                    "[SalePrice3] [float] NULL," +
                    "[SaleQuantity3] [float] NULL," +
                    "CONSTRAINT [PK_" + StockName + "_Tracsaction] PRIMARY KEY CLUSTERED " +
                    "( [ID] ASC )WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]" +
                    ") ON [PRIMARY]";
                cmdCreateTable.ExecuteNonQuery();
                cmdCreateTable.Dispose();
            }

            catch (Exception ex)
            { }
        }



        /*---------------------------------
         * void Insert2StockTable(string StockName, string data)
         * Description: Insert stock data into Stock Table
         * StockName: name of Stock Table
         * data: data which is inserted into Stock Table
        ----------------------------------- */
        private static bool Insert2StockTable(string StockName, string data, SqlCommand cmdInsertData)
        {
            try
            {
                cmdInsertData.CommandText = "INSERT INTO " + StockName + "(CloseDate,OpenPrice,HighPrice,LowPrice,ClosePrice,Volume) VALUES(" + data + ")";
                cmdInsertData.ExecuteNonQuery();
                cmdInsertData.Dispose();
            }

            catch (Exception ex)
            {
                //string s = ex.ToString();
                return false;
            }
            return true;
        }


        /*---------------------------------
         * void Insert2StockTransaction(string StockName, string data)
         * Description: Insert stock data(vse.org.vn) into Stock Transaction
         * StockName: name of Stock Transaction table
         * data: data which is inserted into Stock Transaction table
        ----------------------------------- */
        //private bool Insert2StockTransaction(string StockName, string data)
        //{
        //    try
        //    {
        //        SqlCommand cmdInsertData = conn.CreateCommand();
        //        cmdInsertData.CommandText = "INSERT INTO " + StockName + "_Transaction(SysDate,OpenPrice,BuyPrice1,BuyQuantity1,BuyPrice2,BuyQuantity2,BuyPrice3,BuyQuantity3"
        //        + ",Price,Quantity,SalePrice1,SaleQuantity1,SalePrice2,SaleQuantity2,SalePrice3,SaleQuantity3,ClosePrice,Volume) VALUES(" + data + ")";
        //        cmdInsertData.ExecuteNonQuery();
        //        cmdInsertData.Dispose();
        //    }

        //    catch (Exception ex)
        //    {
        //        //string s = ex.ToString();
        //        return false;
        //    }
        //    return true;
        //}

        /*---------------------------------
         * bool InsertNewData(string sUp1, string sUp2)
         * Description: Insert stock data into Stock Table, UR_Stock table
         * sUp1, sUp2: Insert command string into Stock table, UR_Stock table
        ----------------------------------- */
        public static bool InsertNewDate(string strStockCode, string sUp1, string sUp2, SqlConnection conn)
        {
            try
            {
                SqlCommand cmdInsertData = conn.CreateCommand();
                cmdInsertData.CommandText = sUp1;
                cmdInsertData.ExecuteNonQuery();
                cmdInsertData.CommandText = sUp2;
                cmdInsertData.ExecuteNonQuery();
                cmdInsertData.Dispose();
            }

            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        /*---------------------------------
         * string ParseFromFile(string sFName)
         * Description: Move data from text file(bsc.com.vn) into DB
         * sFName: name of text file
        ----------------------------------- */
        public static void ParseFromFile(string sFName)
        {            
            StreamReader sr = new StreamReader(sFName);

            // Split lines of data by '\n'
            int j;
            string sLine = "";
            string sQuery = "";
            string sStockCode = "";

            SqlConnection conn = new SqlConnection(str_Con_SQL);
            conn.Open();
            SqlCommand cmdInsertData = conn.CreateCommand();
            while ((sLine = sr.ReadLine())!=null)
                {
                    //sLine = sr.ReadLine();
                    sQuery = "";
                    // Split parts of a line by comma ','
                    string[] splitStr = sLine.Split(new Char[] { ',' });
                    j = 1;
                    foreach (string s in splitStr)
                    {
                        switch (j)
                        {
                            case 1:
                                sStockCode = s;
                                break;
                            case 2:
                                sQuery += "'"+Convert.ToDateTime(s)+"'";
                                break;
                            default:
                                if (s.Length==0)
                                    sQuery += ",0";
                                else
                                    sQuery += "," + s;
                                break;
                        }
                        j++;
                    }

                    if (!Insert2StockTable(sStockCode, sQuery, cmdInsertData))
                    {
                        CreateStockTable(sStockCode, cmdInsertData);
                        Insert2StockTable(sStockCode, sQuery, cmdInsertData);
                    }
                }
            conn.Close();
            sr.Close();
            //return System.IO.Directory.GetCurrentDirectory() + "\\" + sFName;
        }

        /*---------------------------------
         * string ParseFromFile(string sFName)
         * Description: Move data from text file(bsc.com.vn) into DB
         * sFName: name of text file
        ----------------------------------- */
        public static void ParseFromStock(string sStockCode, string sFName)
        {
            StreamReader sr = new StreamReader(sFName);

            // Split lines of data by '\n'
            int j;
            string sLine = "";
            string sQuery = "";
            string sTemp = "";

            SqlConnection conn = new SqlConnection(str_Con_SQL);
            conn.Open();
            SqlCommand cmdInsertData = conn.CreateCommand();
            while ((sLine = sr.ReadLine()) != null)
            {
                //sLine = sr.ReadLine();
                sQuery = "";
                // Split parts of a line by comma ','
                string[] splitStr = sLine.Split(new Char[] { ',' });
                j = 1;
                foreach (string s in splitStr)
                {
                    switch (j)
                    {
                        case 1:
                            sTemp = s;
                            break;
                        case 2:
                            sQuery += "'" + Convert.ToDateTime(s) + "'";
                            break;
                        default:
                            if (s.Length == 0)
                                sQuery += ",0";
                            else
                                sQuery += "," + s;
                            break;
                    }
                    j++;
                }
                if (sTemp == sStockCode)
                {
                    if (!Insert2StockTable(sStockCode, sQuery, cmdInsertData))
                    {
                        CreateStockTable(sStockCode, cmdInsertData);
                        Insert2StockTable(sStockCode, sQuery, cmdInsertData);
                    }
                }
            }
            conn.Close();
            sr.Close();
            //return System.IO.Directory.GetCurrentDirectory() + "\\" + sFName;
        }


        /*---------------------------------
          * string ParseFromFileTransaction(string sFName)
          * Description: Move data from text file(vse.org.vn) into DB
          * sFName: name of text file
         ----------------------------------- */
        //public string ParseFromFileTransaction(string sFName)
        //{
        //    StreamReader sr = new StreamReader(System.IO.Directory.GetCurrentDirectory() + "\\" + sFName);

        //    // Split lines of data by '\n'
        //    int j;
        //    string sLine = "";
        //    string sQuery = "";
        //    string StockName = "";
        //    //for (int i = 0; i < 2; i++)
        //    //for (int i = 0; i < flenInt; i++)
        //    int cntI = 0;
        //    while ((sLine = sr.ReadLine()) != null)
        //    {
        //        cntI++;
        //        // Get SysDate
        //        if (cntI == 7)
        //        {
        //            sLine.Substring(45, 64);

        //        }
        //        sQuery = "";
        //        // Split parts of a line by comma ','
        //        string[] splitStr = sLine.Split(new Char[] { ',' });
        //        j = 1;
        //        foreach (string s in splitStr)
        //        {
        //            switch (j)
        //            {
        //                case 1:
        //                    StockName = s;
        //                    break;
        //                case 2:
        //                    sQuery += "'" + Convert.ToDateTime(s) + "'";
        //                    break;
        //                default:
        //                    if (s.Length == 0)
        //                        sQuery += ",0";
        //                    else
        //                        sQuery += "," + s;
        //                    break;
        //            }
        //            j++;
        //        }

        //        if (!Insert2StockTable(StockName, sQuery))
        //        {
        //            CreateStockTable(StockName);
        //            Insert2StockTable(StockName, sQuery);
        //        }
        //    }
        //    sr.Close();
        //    return System.IO.Directory.GetCurrentDirectory() + "\\" + sFName;
        //}

        /*---------------------------------
          * string IncrementalByDate(string sFName)
          * Description: Update data from text file(bsc.com.vn) into DB
          * sFName: name of text file
         ----------------------------------- */
        public static bool IncrementalByDate(string strStockCode, DateTime dtLastDate, double dCurF, double dPrevH, double dTrend, string sFName, SqlConnection conn)
        {
            StreamReader sr = new StreamReader(sFName);

            // Split lines of data by '\n'
            int j;
            string sLine = "";
            string sQuery = "";
            string StockName = "";
            DateTime dtCurDate;
            bool bQuit = false;
            string sUp1, sUp2;
            double dCurH=0;
            while ((sLine = sr.ReadLine()) != null)
            {
                sQuery = "";
                // Split parts of a line by comma ','
                string[] splitStr = sLine.Split(new Char[] { ',' });
                j = 1;
                foreach (string s in splitStr)
                {
                    switch (j)
                    {
                        case 1:
                            StockName = s;
                            break;
                        case 2:
                            dtCurDate = Convert.ToDateTime(s);
                            if (dtCurDate > dtLastDate.Add(TimeSpan.FromDays(1)) && StockName == strStockCode) bQuit = true;
                            sQuery += "'" + Convert.ToDateTime(s) + "'";
                            break;
                        default:
                            if (j == 3 && bQuit) dCurH = Convert.ToDouble(s);
                            if (s.Length == 0)
                                sQuery += ",0";
                            else
                                sQuery += "," + s;
                            break;
                    }
                    j++;
                }
                if (bQuit)
                {
                    double dG = Math.Round((dCurF - dCurH) / dCurH, 2);
                    bool bTrend = ((dCurH-dPrevH)*dTrend)>=0? true:false;
                    sUp1 = "INSERT INTO " + StockName + "(CloseDate,OpenPrice,HighPrice,LowPrice,ClosePrice,Volume) VALUES(" + sQuery + ")";
                    sUp2 = "INSERT INTO " + StockName + "_UR(ClosePrice,PredictPrice,GR,Trend) VALUES(" + 
                        dCurH + "," + Math.Round(dCurF,1) + "," + dG + ",'" + bTrend + "')";
                    InsertNewDate(StockName, sUp1, sUp2, conn);
                    sr.Close();
                    return true;
                }
            }
            sr.Close();
            return false;
        }


        /*---------------------------------
         * Description: Input stock price data from dat file into SQL DB (Stock)
        ----------------------------------- */
        public static void UpdateStockData(string sStockCode, string sFile, bool bAllData)
        {
            if (bAllData)
                ParseFromFile(sFile);
            else
                ParseFromStock(sStockCode,sFile);
        }


    }
}
