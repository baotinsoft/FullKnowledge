//using Microsoft.SqlServer.MessageBox;
using Microsoft.AnalysisServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Common;
//using Microsoft.SqlServer.Management.Smo;
using Microsoft.AnalysisServices.AdomdServer;


namespace StockPredict
{
    class ADOLib
    {
        public static string strProgress;
        
        public static double COMPLEXITY_PENALTY;             
        //public static string PERIODICITY_HINT;
        public static double AUTO_DETECT_PERIODICITY;
        public static double MAXIMUM_SERIES_VALUE;
        public static double MINIMUM_SERIES_VALUE;
        public static int HISTORIC_MODEL_COUNT=1; //default
        public static int HISTORIC_MODEL_GAP=10; //default

        public const int i_Save_HMG = 10;
        public const int iMinLen = 80;

        public static string str_Con_SQL = "Data Source=localhost;" +
                "Initial Catalog=Stock;Integrated Security=true";
        public static string str_Con_Svr = "Provider=SQLNCLI.1;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Stock;Data Source=localhost";
        
        public static Microsoft.AnalysisServices.Server ConnectServer(string strConn)
        {
            Server svr = new Server();
            svr.Connect(strConn);
            return svr;
        }

        /*---------------------------------
         * Description: Create data source view for model
         * Input:
         *  bAll: True: use all data of the stock; False: only use data from date to date
         *  bMulti: True: multi step forecasting; False: one step forecasting
         *  bFirst: True: the first time of creating model => create Multi table
         *      ; False: only update for multi forecasting => update StockPredict from updated Multi table
        ----------------------------------- */
        private static void CreateDataAccessObjects(Database db, string strStockCode, bool bAll, DateTime dtFrom, DateTime dtTo, bool bMulti, bool bFirst)
        {
            //Create connection to datasource to extract schema to dataset
            DataSet dset = new DataSet();
            SqlConnection cn = new SqlConnection(str_Con_SQL);
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            SqlDataReader rdr;

            //Create the Stock data adapter with the
            //calculated column appended
            string sSelect, sDate;
            if (strStockCode.ToUpper() != "VNINDEX" && strStockCode.Length < 11 && !bMulti)
                sSelect = "SELECT * FROM ";
            else
                sSelect = "SELECT ID, ClosePrice FROM ";


            if (bMulti) //Multi step forecasting
            {
                // Check exist of table StockCode_Multi
                string strQuery = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='" + strStockCode +  "_Multi'";
                cmd.CommandText = strQuery;
                rdr = cmd.ExecuteReader();
                // If not exist then create Multi table
                bool bExist = rdr.Read();
                rdr.Close();
                if (!bExist || bFirst)
                {
                    // If exist Multi table Then Drop
                    if (bExist)
                    {
                        try
                        {
                            cmd.CommandText = "DROP TABLE " + strStockCode + "_Multi";
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex1) { }
                    }
                    if (bAll)
                    {
                        // Create table Stock_Multi and its data
                        cmd.CommandText = "SELECT ID, CloseDate, ClosePrice INTO " + strStockCode
                            + "_Multi FROM " + strStockCode;
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        // Create table Stock_Multi and its data
                        cmd.CommandText = "SELECT ID, CloseDate, ClosePrice INTO " + strStockCode
                            + "_Multi FROM " + strStockCode
                            + " WHERE CloseDate>='" + dtFrom + "' AND CloseDate<='" + dtTo + "'";
                        cmd.ExecuteNonQuery();
                    }
                }

                sSelect += strStockCode + "_Multi";
                sDate = "SELECT MAX(CloseDate),MIN(CloseDate) FROM "
                    + strStockCode + "_Multi";
            }
            else
            {
                if (bAll)
                {
                    sSelect += strStockCode;
                    sDate = "SELECT MAX(CloseDate),MIN(CloseDate) FROM "
                        + strStockCode;
                }
                else
                {
                    sSelect += strStockCode + " WHERE CloseDate>='" + dtFrom + "' AND CloseDate<='" + dtTo + "'";
                    sDate = "SELECT MAX(CloseDate),MIN(CloseDate) FROM "
                        + strStockCode + " WHERE CloseDate>='" + dtFrom + "' AND CloseDate<='" + dtTo + "'";
                }
            }

            cmd.CommandText = sDate;
            rdr = cmd.ExecuteReader();
            rdr.Read();
            dtTo = rdr.GetDateTime(0);
            dtFrom = rdr.GetDateTime(1);
            rdr.Close();

            //Update Forecast Model
            try
            {
                cmd.CommandText = "Update StockForecastModel Set FromDate='" + dtFrom + "',ToDate='"
                    + dtTo + "' Where StockCode='" + strStockCode + "'";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex) { MessageBox.Show("Không thể cập nhật StockForecastModel!"); }

            SqlDataAdapter daStock = new SqlDataAdapter(sSelect, cn);
            daStock.FillSchema(dset, SchemaType.Mapped, strStockCode);

            //add extended properties to the DataSet indicating it is a names query
            dset.Tables[strStockCode].ExtendedProperties.Add("TableType", "View"); //this is one of the key statements to make this a named query
            dset.Tables[strStockCode].ExtendedProperties.Add("QueryDefinition", sSelect); //this is one of the key statements to make this a named query
            dset.Tables[strStockCode].ExtendedProperties.Add("IsLogical", "True");
            dset.Tables[strStockCode].ExtendedProperties.Add("DbSchemaName", "dbo");
            dset.Tables[strStockCode].ExtendedProperties.Add("DbTableName", strStockCode);
            dset.Tables[strStockCode].ExtendedProperties.Add("FriendlyName", strStockCode);

            try
            {
                // Create the dsv, add the dataset, and add to the database
                DataSourceView dsv;
                if ((dsv = db.DataSourceViews.FindByName(strStockCode)) == null)
                {
                    dsv = new DataSourceView(strStockCode, strStockCode);
                    dsv.DataSourceID = "Stock";
                    dsv.Schema = dset;
                    db.DataSourceViews.Add(dsv);
                }
                else
                {
                    dsv.DataSourceID = "Stock";
                    dsv.Schema = dset;
                    // Send the data source view definition to the server
                    dsv.Update();
                }
            }
            catch (Exception e) { MessageBox.Show("Please reinput another stock code. The stock code is exist"); }
            // Update the database to create the objects on the server.
            db.Update(UpdateOptions.ExpandFull);
        }

        /*---------------------------------
         * Description: Create Mining Structure
        ----------------------------------- */
        public static Microsoft.AnalysisServices.MiningStructure CreateMS(Microsoft.AnalysisServices.Server svr, string strStockCode, bool bAll, DateTime dtFrom, DateTime dtTo, bool bMulti)
        {            
            Database db = svr.Databases.GetByName("Stock");
            CreateDataAccessObjects(db, strStockCode,bAll,dtFrom,dtTo,bMulti,true);

            Microsoft.AnalysisServices.MiningStructure ms = db.MiningStructures.FindByName(strStockCode);

            if (ms != null)
            {

            //    string message = "Bạn muốn tạo mới mô hình dự báo cho cổ phiếu này?";
            //    string caption = "Recreate New Mining Model";
            //    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            //    DialogResult result;

            //    // Displays the MessageBox.

            //    result = MessageBox.Show(message, caption, buttons);

            //    if (result == DialogResult.Yes)
            //    {
            //        ms.Drop();
            //    }
            //    else
            //    {
            //        //CreateMM(ms, strStockCode);
            //        return ms;
            //    }
                ms.Drop();
            }

            // Add new Mining Structure
            ms = db.MiningStructures.Add(strStockCode, strStockCode);
            ms.Source = new DataSourceViewBinding(strStockCode);
            ms.CaseTableName = strStockCode;
         
            ScalarMiningStructureColumn intID = new ScalarMiningStructureColumn("ID", "ID");
            intID.Type = MiningStructureColumnTypes.Long;
            intID.Content = MiningStructureColumnContents.KeyTime;
            intID.IsKey = true;
            // Add data binding to the column.
            intID.KeyColumns.Add(strStockCode, "ID", OleDbType.Integer);
            // Add the column to the MiningStructure
            ms.Columns.Add(intID);

            ScalarMiningStructureColumn dblClosePrice = new ScalarMiningStructureColumn("ClosePrice", "ClosePrice");
            dblClosePrice.Type = MiningStructureColumnTypes.Double;
            dblClosePrice.Content = MiningStructureColumnContents.Continuous;
            dblClosePrice.KeyColumns.Add(strStockCode, "ClosePrice", OleDbType.Double);
            ms.Columns.Add(dblClosePrice);
            
            // Don't use Open,High,Low for VNIndex, Compressed Date, and Multi Step Forecast
            if (strStockCode.ToUpper() != "VNINDEX" && strStockCode.Length<11 && !bMulti)
            {
                ScalarMiningStructureColumn dblOpenPrice = new ScalarMiningStructureColumn("OpenPrice", "OpenPrice");
                dblOpenPrice.Type = MiningStructureColumnTypes.Double;
                dblOpenPrice.Content = MiningStructureColumnContents.Continuous;
                dblOpenPrice.KeyColumns.Add(strStockCode, "OpenPrice", OleDbType.Double);
                ms.Columns.Add(dblOpenPrice);

                ScalarMiningStructureColumn dblHighPrice = new ScalarMiningStructureColumn("HighPrice", "HighPrice");
                dblHighPrice.Type = MiningStructureColumnTypes.Double;
                dblHighPrice.Content = MiningStructureColumnContents.Continuous;
                dblHighPrice.KeyColumns.Add(strStockCode, "HighPrice", OleDbType.Double);
                ms.Columns.Add(dblHighPrice);

                ScalarMiningStructureColumn dblLowPrice = new ScalarMiningStructureColumn("LowPrice", "LowPrice");
                dblLowPrice.Type = MiningStructureColumnTypes.Double;
                dblLowPrice.Content = MiningStructureColumnContents.Continuous;
                dblLowPrice.KeyColumns.Add(strStockCode, "LowPrice", OleDbType.Double);
                ms.Columns.Add(dblLowPrice);

                //ScalarMiningStructureColumn lngVolume = new ScalarMiningStructureColumn("Volume", "Volume");
                //lngVolume.Type = MiningStructureColumnTypes.Long;
                //lngVolume.Content = MiningStructureColumnContents.Continuous;
                //lngVolume.KeyColumns.Add(strStockCode, "Volume", OleDbType.Double);
                //ms.Columns.Add(lngVolume);
            }
            ms.Update();
            CreateMM(ms, strStockCode, bMulti);
            return ms;
        }

        /*---------------------------------
         * Description: Create Mining Model
        ----------------------------------- */
        public static void CreateMM(Microsoft.AnalysisServices.MiningStructure ms, string strStockCode, bool bMulti)
        {
            if (ms.MiningModels.ContainsName(strStockCode))
            {
                ms.MiningModels[strStockCode].Drop();
            }
            Microsoft.AnalysisServices.MiningModel mm = ms.CreateMiningModel(true, strStockCode);
            mm.Algorithm = MiningModelAlgorithms.MicrosoftTimeSeries;

            InitialParameters(strStockCode);

            // 0.1:0.05 -> from 0 to (1-0.1)/0.05=18
            mm.AlgorithmParameters.Add("COMPLEXITY_PENALTY", COMPLEXITY_PENALTY);

            // {5,20,60}, 0:0.1 -> from 0 to (1-0.1)/0.05=18
            mm.AlgorithmParameters.Add("PERIODICITY_HINT", "{5,20,60}");
            mm.AlgorithmParameters.Add("AUTO_DETECT_PERIODICITY", AUTO_DETECT_PERIODICITY);

            // Defeult: 1, 10
            mm.AlgorithmParameters.Add("HISTORIC_MODEL_COUNT", HISTORIC_MODEL_COUNT);
            mm.AlgorithmParameters.Add("HISTORIC_MODEL_GAP", HISTORIC_MODEL_GAP);

            // Max, Min Time Series
            mm.AlgorithmParameters.Add("MAXIMUM_SERIES_VALUE", MAXIMUM_SERIES_VALUE);
            mm.AlgorithmParameters.Add("MINIMUM_SERIES_VALUE", MINIMUM_SERIES_VALUE);


            mm.AllowDrillThrough = true;

            mm.Columns["ID"].Usage = MiningModelColumnUsages.Key;
            mm.Columns["ClosePrice"].Usage = MiningModelColumnUsages.Predict;
            if (strStockCode.ToUpper() != "VNINDEX" && !bMulti)
            {
                mm.Columns["OpenPrice"].Usage = MiningModelColumnUsages.Input;
                mm.Columns["HighPrice"].Usage = MiningModelColumnUsages.Input;
                mm.Columns["LowPrice"].Usage = MiningModelColumnUsages.Input;
                //mm.Columns["Volume"].Usage = MiningModelColumnUsages.Input;
            }
            mm.Update();

            // Update parameters into StockForecastModel
            UpdateForecastModel(strStockCode);
        }

        /*---------------------------------
         * Description: Update Mining Model with parameters
         * Input:
         *  mm: Mining Model
         *  strStockCode: Code of Stock
         *  bPrev: True: move to previous; False: loop
         * Output:
         *  True: Loop; False: Stop
        ----------------------------------- */
        public static bool UpdateMM(Microsoft.AnalysisServices.MiningModel mm, string strStockCode, bool bPrev)
        {
            mm.AlgorithmParameters.Clear();
            // Default:10; 10:5 -> from 0 to (n-10)/5
            //mm.AlgorithmParameters.Add("MINIMUM_SUPPORT", 10);
            
            // 0.1:0.05 -> from 0 to (1-0.1)/0.05=18
            mm.AlgorithmParameters.Add("COMPLEXITY_PENALTY", COMPLEXITY_PENALTY);
            
            // {5,20,60}, 0:0.1 -> from 0 to (1-0.1)/0.05=18
            mm.AlgorithmParameters.Add("PERIODICITY_HINT", "{5,20,60}");
            mm.AlgorithmParameters.Add("AUTO_DETECT_PERIODICITY", AUTO_DETECT_PERIODICITY);
            
            // Defeult: 1, 10
            mm.AlgorithmParameters.Add("HISTORIC_MODEL_COUNT", HISTORIC_MODEL_COUNT);
            mm.AlgorithmParameters.Add("HISTORIC_MODEL_GAP", HISTORIC_MODEL_GAP);

            // Max, Min Time Series
            mm.AlgorithmParameters.Add("MAXIMUM_SERIES_VALUE", MAXIMUM_SERIES_VALUE);
            mm.AlgorithmParameters.Add("MINIMUM_SERIES_VALUE", MINIMUM_SERIES_VALUE);

            mm.Update();
            mm.Process(ProcessType.ProcessFull);
            if (bPrev) return false;
            else return ADOMDLib.CheckResult(strStockCode);
        }

        public static bool UpdateMMTest(Microsoft.AnalysisServices.MiningModel mm, string strStockCode, DateTime dtTo)
        {
            mm.AlgorithmParameters.Clear();
            // Default:10; 10:5 -> from 0 to (n-10)/5
            //mm.AlgorithmParameters.Add("MINIMUM_SUPPORT", 10);

            // 0.1:0.05 -> from 0 to (1-0.1)/0.05=18
            mm.AlgorithmParameters.Add("COMPLEXITY_PENALTY", COMPLEXITY_PENALTY);

            // {5,20,60}, 0:0.1 -> from 0 to (1-0.1)/0.05=18
            mm.AlgorithmParameters.Add("PERIODICITY_HINT", "{5,20,60}");
            mm.AlgorithmParameters.Add("AUTO_DETECT_PERIODICITY", AUTO_DETECT_PERIODICITY);

            // Defeult: 1, 10
            mm.AlgorithmParameters.Add("HISTORIC_MODEL_COUNT", HISTORIC_MODEL_COUNT);
            mm.AlgorithmParameters.Add("HISTORIC_MODEL_GAP", HISTORIC_MODEL_GAP);

            // Max, Min Time Series
            mm.AlgorithmParameters.Add("MAXIMUM_SERIES_VALUE", MAXIMUM_SERIES_VALUE);
            mm.AlgorithmParameters.Add("MINIMUM_SERIES_VALUE", MINIMUM_SERIES_VALUE);

            mm.Update();
            mm.Process(ProcessType.ProcessFull);
            return ADOMDLib.CheckResultTest(strStockCode,dtTo);
        }

        /*---------------------------------
          * Description: Update Mining Model and process StockPredict DB with new MAX, MIN when MAX,MIN are changed by Technology Analysis (IdentifyTrend)
         ----------------------------------- */
        public static bool UpdateMMbyAnalysis(string sStockCode)
        {
            Server svr = ConnectServer(str_Con_Svr);
            Database db = svr.Databases.GetByName("StockPredict");
            Microsoft.AnalysisServices.MiningStructure ms = db.MiningStructures.FindByName(sStockCode);
            Microsoft.AnalysisServices.MiningModel mm = ms.MiningModels.FindByName(sStockCode);
            mm.AlgorithmParameters.Remove("MAXIMUM_SERIES_VALUE");
            mm.AlgorithmParameters.Remove("MINIMUM_SERIES_VALUE");
            // Max, Min Time Series
            mm.AlgorithmParameters.Add("MAXIMUM_SERIES_VALUE", MAXIMUM_SERIES_VALUE);
            mm.AlgorithmParameters.Add("MINIMUM_SERIES_VALUE", MINIMUM_SERIES_VALUE);

            mm.Update();
            mm.Process(ProcessType.ProcessFull);

            // Update parameters into StockForecastModel
            try
            {
                SqlConnection conn = new SqlConnection(str_Con_SQL);
                conn.Open();
                SqlCommand cmdUpdate = conn.CreateCommand();
                cmdUpdate.CommandText = "Update StockForecastModel Set MAXIMUM_SERIES_VALUE=" + MAXIMUM_SERIES_VALUE.ToString().Replace(',', '.')
                    + ", MINIMUM_SERIES_VALUE=" + MINIMUM_SERIES_VALUE.ToString().Replace(',', '.')
                    + " Where StockCode='" + sStockCode + "'";
                cmdUpdate.ExecuteNonQuery();
                cmdUpdate.Dispose();
                conn.Close();
            }
            catch (Exception ex) { MessageBox.Show("Không thể cập nhật StockForecastModel!"); return false; }

            return true;
        }

        public static void ProcessUpdateMM(Server svr, string strStockCode, bool bCon)
        {
            Database db = svr.Databases.GetByName("StockPredict");
            Microsoft.AnalysisServices.MiningStructure ms = db.MiningStructures.FindByName(strStockCode);

            string strMsg, strCap;
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            if (ms == null)
            {
                strMsg = "Cấu trúc dự báo cho cổ phiếu này không tồn tại!";
                strCap = "Mining Structure";
                // Displays the MessageBox.
                MessageBox.Show(strMsg, strCap, buttons, MessageBoxIcon.Error);
                return;
            }

            Microsoft.AnalysisServices.MiningModel mm = ms.MiningModels.FindByName(strStockCode);
            if (mm == null)
            {
                strMsg = "Mô hình dự báo cho cổ phiếu này không tồn tại!";
                strCap = "Mining Model";
                // Displays the MessageBox.
                MessageBox.Show(strMsg, strCap, buttons, MessageBoxIcon.Error);
                return;
            }

          
            // Check exist table: CR
            ADOMDLib.ExistExpandTable(strStockCode,"_CR", bCon);

            // Initial parameters and get count of IDs
            int iCount_ID = InitialParameters(strStockCode);

            // Loop mining
            while (AUTO_DETECT_PERIODICITY < 0.95)
            {
                while (COMPLEXITY_PENALTY < 0.95)
                {
                    while (HISTORIC_MODEL_COUNT < 3)
                    {
                        while (HISTORIC_MODEL_GAP < 15)
                        {
                            HISTORIC_MODEL_GAP++;
                            if (!UpdateMM(mm, strStockCode, false))
                            {
                                // back to previous
                                //HISTORIC_MODEL_GAP--;
                                //UpdateMM(mm, strStockCode, true);
                                // Update parameters into StockForecastModel
                                UpdateForecastModel(strStockCode);
                                return;
                            }
                        }
                        HISTORIC_MODEL_GAP = i_Save_HMG;
                        HISTORIC_MODEL_COUNT++;
                    }
                    HISTORIC_MODEL_COUNT = 1;
                    COMPLEXITY_PENALTY += 0.05;
                }
                COMPLEXITY_PENALTY = 0.05;
                AUTO_DETECT_PERIODICITY += 0.05;
            }
            // Get the best parameters
            // Get the best parameters
            UpdateMM(mm, strStockCode, false);
            GetBestParam(strStockCode);
            UpdateForecastModel(strStockCode);

        }

        public static void ProcessUpdateMMTest(Server svr, string strStockCode, bool bCon)
        {
            Database db = svr.Databases.GetByName("StockPredict");
            Microsoft.AnalysisServices.MiningStructure ms = db.MiningStructures.FindByName(strStockCode);

            string strMsg, strCap;
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            if (ms == null)
            {
                strMsg = "Cấu trúc dự báo cho cổ phiếu này không tồn tại!";
                strCap = "Mining Structure";
                // Displays the MessageBox.
                MessageBox.Show(strMsg, strCap, buttons, MessageBoxIcon.Error);
                return;
            }

            Microsoft.AnalysisServices.MiningModel mm = ms.MiningModels.FindByName(strStockCode);
            if (mm == null)
            {
                strMsg = "Mô hình dự báo cho cổ phiếu này không tồn tại!";
                strCap = "Mining Model";
                // Displays the MessageBox.
                MessageBox.Show(strMsg, strCap, buttons, MessageBoxIcon.Error);
                return;
            }


            // Check exist table: CR
            ADOMDLib.ExistExpandTable(strStockCode, "_CRT", bCon);

            // Initial parameters
            DefaultParam(strStockCode);

            // Get ToDate from StockForecastModel
            SqlConnection cn = new SqlConnection(str_Con_SQL);
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "SELECT ToDate FROM StockForecastModel WHERE StockCode='" + strStockCode + "'";
            SqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            DateTime dtTo = rdr.GetDateTime(0);
            rdr.Close();
            cn.Close();

            // Loop mining
            while (AUTO_DETECT_PERIODICITY < 0.95)
            {
                while (COMPLEXITY_PENALTY < 0.95)
                {
                    while (HISTORIC_MODEL_COUNT < 3)
                    {
                        while (HISTORIC_MODEL_GAP < 15)
                        {
                            if (!UpdateMMTest(mm, strStockCode, dtTo))
                            {
                                // Update parameters into StockForecastModel
                                UpdateForecastModel(strStockCode);
                                return;
                            }
                            HISTORIC_MODEL_GAP++;
                        }
                        HISTORIC_MODEL_GAP = i_Save_HMG;
                        HISTORIC_MODEL_COUNT++;
                    }
                    HISTORIC_MODEL_COUNT = 1;
                    COMPLEXITY_PENALTY += 0.05;
                }
                COMPLEXITY_PENALTY = 0.05;
                AUTO_DETECT_PERIODICITY += 0.05;
            }

            // Get the best parameters
            UpdateMMTest(mm, strStockCode, dtTo);
            GetBestParamTest(strStockCode);
            UpdateForecastModel(strStockCode);

        }

        /*---------------------------------
         * Description: Process Analysis DB
        ----------------------------------- */
        public static void ProcessTrainDB(Server svr, System.Windows.Forms.TextBox txtProgress)
        {
            Database db = svr.Databases.GetByName("StockPredict");

            txtProgress.Text = "";
            strProgress = "";
            Trace t;
            TraceEvent e;
            
            // Create the trace object to trace progress reports
            // and add the column containing the progress description.
            t = svr.Traces.Add();
            e = t.Events.Add(TraceEventClass.ProgressReportCurrent);
            e.Columns.Add(TraceColumn.TextData);
            e.Columns.Add(TraceColumn.EventClass);
            t.Update();
            // Add the handler for the trace event.
            t.OnEvent += new TraceEventHandler(ProgressReportHandler);

            // Start the trace process of the database, then stop it.
            t.Start();
            db.Process(ProcessType.ProcessFull);
            t.Stop();

            // Remove the trace from the server.
            t.Drop();
            txtProgress.Text = strProgress;

        }

        /*---------------------------------
         * Description: Progress Report for ProcessTrainDB function
        ----------------------------------- */
        private static void ProgressReportHandler(Object sender, TraceEventArgs e)
        {
            strProgress = strProgress + Environment.NewLine + e[TraceColumn.TextData];
        }

        /*---------------------------------
         * Description: Update created mining model list into cboStock of frmForecast
        ----------------------------------- */
        public static void MSList(ComboBox cboStock, string strConn)
        {
            Server svr = new Server();
            svr.Connect(strConn); 
            Database db = svr.Databases.GetByName("Stock");
            for (int i=0; i < db.MiningStructures.Count; i++)
                cboStock.Items.Add(db.MiningStructures[i].ID);
        }

        /*---------------------------------
         * Description: Initial parameters for Mining Model
        ----------------------------------- */
        public static int InitialParameters(string strStockCode)
        {
            SqlConnection cn = new SqlConnection(str_Con_SQL);
            cn.Open();
            SqlCommand cmd = new SqlCommand();

            // Assign connection object and sql query to command object
            cmd.Connection = cn;
            
            
            // Calculate MAX, MIN based on General\Limit
            cmd.CommandText = "SELECT ClosePrice, ID FROM " + strStockCode
                + " WHERE CloseDate = (SELECT ToDate FROM StockForecastModel WHERE StockCode='"
                + strStockCode + "')";
            SqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            double dTmp = rdr.GetDouble(0);
            int iCount_ID = rdr.GetInt32(1);
            rdr.Close();

            General.GetParam();
            MAXIMUM_SERIES_VALUE = dTmp * (1 + General.iLimit / 100);
            MINIMUM_SERIES_VALUE = dTmp * ( 1 - General.iLimit/100);


            string sTemp = "SELECT TOP 1 COMPLEXITY_PENALTY,AUTO_DETECT_PERIODICITY, COUNT_ID, HISTORIC_MODEL_COUNT, HISTORIC_MODEL_GAP FROM " + strStockCode + "_CR ORDER BY ID DESC";
            try
            {
                cmd.CommandText = sTemp;
                rdr = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                DefaultParam(strStockCode);
                rdr.Close();
                cn.Close();
                return iCount_ID;
            }
            // check if exist parameters and data is not changed
            if (rdr.Read() && rdr.GetInt32(2) == iCount_ID)
            {
                COMPLEXITY_PENALTY = rdr.GetDouble(0);
                AUTO_DETECT_PERIODICITY = rdr.GetDouble(1);
                HISTORIC_MODEL_COUNT = rdr.GetInt32(3);
                HISTORIC_MODEL_GAP = rdr.GetInt32(4);
            }
            else
            {
                DefaultParam(strStockCode);
            }
            rdr.Close();

            // Close connection
            cn.Close();

            return iCount_ID;
        }

        public static void DefaultParam(string sStockCode)
        {

            SqlConnection cn = new SqlConnection(str_Con_SQL);
            cn.Open();
            SqlCommand cmd = new SqlCommand();

            // Assign connection object and sql query to command object
            cmd.Connection = cn;
            
            //cmd.CommandText = "SELECT TOP 1 MAX(ClosePrice), MIN(ClosePrice), COUNT(ID) FROM " + strStockCode;

            //cmd.CommandText ="SELECT MAX(ClosePrice), MIN(ClosePrice) FROM " + sStockCode
            //+ " WHERE     (CloseDate >="
            //              + "(SELECT     FromDate"
            //                +" FROM          StockForecastModel"
            //                +" WHERE      (StockCode = '"+ sStockCode+"'))) AND (CloseDate <="
            //              + "(SELECT     ToDate"
            //                + " FROM          StockForecastModel AS StockForecastModel_1"
            //                + " WHERE      (StockCode = '" + sStockCode + "')))";

            cmd.CommandText = "SELECT ClosePrice FROM " + sStockCode
            + " WHERE     (CloseDate ="
                          + "(SELECT     ToDate"
                            + " FROM          StockForecastModel AS StockForecastModel_1"
                            + " WHERE      (StockCode = '" + sStockCode + "')))";


            SqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            double dTmp = rdr.GetDouble(0);
            rdr.Close();
            cn.Close();

            MAXIMUM_SERIES_VALUE = dTmp * 1.05;
            MINIMUM_SERIES_VALUE = dTmp * 0.95;


            COMPLEXITY_PENALTY = 0.1;
            AUTO_DETECT_PERIODICITY = 0.1;
            HISTORIC_MODEL_COUNT = 1;
            HISTORIC_MODEL_GAP = 10;
        }

        /*---------------------------------
         * Description: Update data for Analysis DB and reprocess it
        ----------------------------------- */
        public static void UpdateTrainDB(Microsoft.AnalysisServices.Server svr, string sStockCode, bool bAll, DateTime dtFrom, DateTime dtTo, bool bMulti)
        {
            Database db = svr.Databases.GetByName("Stock");
            CreateDataAccessObjects(db, sStockCode, bAll, dtFrom, dtTo, bMulti, false);
            Microsoft.AnalysisServices.MiningModel mm = db.MiningStructures.GetByName(sStockCode).MiningModels.GetByName(sStockCode);
            // Max, Min Time Series
            mm.AlgorithmParameters.Remove("MAXIMUM_SERIES_VALUE");
            mm.AlgorithmParameters.Remove("MINIMUM_SERIES_VALUE");
            mm.AlgorithmParameters.Add("MAXIMUM_SERIES_VALUE", MAXIMUM_SERIES_VALUE);
            mm.AlgorithmParameters.Add("MINIMUM_SERIES_VALUE", MINIMUM_SERIES_VALUE);
            mm.Update();
            //db.MiningStructures.GetByName(sStockCode).Process(ProcessType.ProcessFull);
            //mm.Process(ProcessType.ProcessFull);
            db.Process(ProcessType.ProcessFull);
        }


        /*---------------------------------
         * Description: Update parameters of model into ForecastModel table
        ----------------------------------- */
        public static void UpdateForecastModel(string sStockCode)
        {
            // Update parameters into StockForecastModel
            try
            {
                SqlConnection conn = new SqlConnection(str_Con_SQL);
                conn.Open();
                SqlCommand cmdUpdate = conn.CreateCommand();
                cmdUpdate.CommandText = "Update StockForecastModel Set COMPLEXITY_PENALTY=" + COMPLEXITY_PENALTY.ToString().Replace(',', '.')
                    + ", PERIODICITY_HINT='{5,20,60}', AUTO_DETECT_PERIODICITY="
                    + AUTO_DETECT_PERIODICITY.ToString().Replace(',', '.')
                    + ", HISTORIC_MODEL_COUNT=" + HISTORIC_MODEL_COUNT
                    + ", HISTORIC_MODEL_GAP=" + HISTORIC_MODEL_GAP
                    + ", MAXIMUM_SERIES_VALUE=" + MAXIMUM_SERIES_VALUE.ToString().Replace(',', '.')
                    + ", MINIMUM_SERIES_VALUE=" + MINIMUM_SERIES_VALUE.ToString().Replace(',', '.')
                    + " Where StockCode='" + sStockCode + "'";
                cmdUpdate.ExecuteNonQuery();
                cmdUpdate.Dispose();
                conn.Close();
            }
            catch (Exception ex) { MessageBox.Show("Không thể cập nhật StockForecastModel!"); }
        }


        public static void GetBestParamTest(string sStockCode)
        {
            SqlConnection cn = new SqlConnection(str_Con_SQL);
            cn.Open();
            SqlCommand cmd = new SqlCommand();

            // Assign connection object and sql query to command object
            cmd.Connection = cn;

            cmd.CommandText = "SELECT TOP 1 * FROM " + sStockCode + "_CRT ORDER BY Percentage ASC, Trend DESC" ;

            SqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();

            COMPLEXITY_PENALTY = rdr.GetDouble(0);
            AUTO_DETECT_PERIODICITY = rdr.GetDouble(1);            
            MAXIMUM_SERIES_VALUE = rdr.GetDouble(2);
            MINIMUM_SERIES_VALUE = rdr.GetDouble(3);
            HISTORIC_MODEL_COUNT = rdr.GetInt32(4);
            HISTORIC_MODEL_GAP = rdr.GetInt32(5);

            rdr.Close();
            cn.Close();
        }

        public static void GetBestParam(string sStockCode)
        {
            SqlConnection cn = new SqlConnection(str_Con_SQL);
            cn.Open();
            SqlCommand cmd = new SqlCommand();

            // Assign connection object and sql query to command object
            cmd.Connection = cn;

            cmd.CommandText = "SELECT TOP 1 COMPLEXITY_PENALTY,AUTO_DETECT_PERIODICITY,HISTORIC_MODEL_COUNT,HISTORIC_MODEL_GAP FROM " 
                + sStockCode + "_CR ORDER BY ga ASC, trend DESC";

            SqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();

            COMPLEXITY_PENALTY = rdr.GetDouble(0);
            AUTO_DETECT_PERIODICITY = rdr.GetDouble(1);
            HISTORIC_MODEL_COUNT = rdr.GetInt32(2);
            HISTORIC_MODEL_GAP = rdr.GetInt32(3);

            rdr.Close();
            cn.Close();
        }


        /*---------------------------------
        * Description: Run forecasting multi times, each time will add more a next value into StockPredict, 
        *   to check confidence of model
        ----------------------------------- */
        //public static void ProcessResult()
        //{
        //    //string[] sArrStock = new string[6] {"VNINDEX","PMS","REE","SAM","SGC","TCM"};
        //    string[] sArrStock = new string[6] { "PMS", "VNINDEX", "REE", "SAM", "SGC", "TCM" };
        //    DateTime [,] dtArrFT = new DateTime [6,2];
        //    //dtArrFT[0, 0] = Convert.ToDateTime("7/28/2000");
        //    //dtArrFT[0, 1] = Convert.ToDateTime("9/28/2000");
        //    //dtArrFT[1, 0] = Convert.ToDateTime("11/4/2003");
        //    //dtArrFT[1, 1] = Convert.ToDateTime("1/4/2004");


        //    dtArrFT[0, 0] = Convert.ToDateTime("11/4/2003");
        //    dtArrFT[0, 1] = Convert.ToDateTime("12/17/2007");

        //    dtArrFT[1, 0] = Convert.ToDateTime("7/28/2000");
        //    dtArrFT[1, 1] = Convert.ToDateTime("12/17/2007");
            
        //    dtArrFT[2, 0] = Convert.ToDateTime("7/28/2000");
        //    dtArrFT[2, 1] = Convert.ToDateTime("12/17/2007");

        //    dtArrFT[3, 0] = Convert.ToDateTime("7/28/2000");
        //    dtArrFT[3, 1] = Convert.ToDateTime("12/17/2007");

        //    dtArrFT[4, 0] = Convert.ToDateTime("9/5/2006");
        //    dtArrFT[4, 1] = Convert.ToDateTime("12/17/2007");

        //    dtArrFT[5, 0] = Convert.ToDateTime("10/15/2007");
        //    dtArrFT[5, 1] = Convert.ToDateTime("12/17/2007");
        //    int iID;

        //    Server svr = ConnectServer("Provider=SQLNCLI.1;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=StockPredict;Data Source=localhost");
        //    for (int i = 4; i < 6; i++)
        //        //for (int i = 0; i < 6; i++)
        //    {
        //        //Create Model
        //        CreateMS(svr,sArrStock[i], false, dtArrFT[i,0], dtArrFT[i,1]);
        //        ProcessUpdateMMTest(svr, sArrStock[i], false);
        //        iID = GetID(sArrStock[i], dtArrFT[i, 1]);
        //        while ((iID = Update1Val2Input(svr, sArrStock[i], iID, dtArrFT[i, 0])) > 0) ;
        //    }
        //}


        /*---------------------------------
        * Description: Increase more a value from Stock DB into StockPredict DB(Analysis DB), it used for checking confidence of model and used in ProcessResult function
        ----------------------------------- */
        //public static int Update1Val2Input(Server svr,string sStockCode, int iID, DateTime dtFrom)
        //{
        //    DateTime dtTo;
        //    SqlConnection cn = new SqlConnection(str_Con_SQL);
        //    cn.Open();
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.Connection = cn;
        //    iID++;
        //    double dVal;
        //    cmd.CommandText = "SELECT CloseDate, ClosePrice FROM " 
        //        + sStockCode + " WHERE ID = " + iID ;
        //    SqlDataReader rdr = cmd.ExecuteReader();
        //    try
        //    {
        //        // Current info
        //        rdr.Read(); 
        //        dVal = rdr.GetDouble(1);
        //        dtTo = rdr.GetDateTime(0);
        //    }
        //    catch (Exception e) { return 0; }
        //    rdr.Close();
        //    cn.Close();

        //    General.GetParam();
        //    ADOLib.MAXIMUM_SERIES_VALUE = dVal * (1 + General.iLimit);
        //    ADOLib.MINIMUM_SERIES_VALUE = dVal * (1 - General.iLimit);

        //    UpdateTrainDB(svr, sStockCode, false, dtFrom, dtTo,false);
        //    ADOMDLib.ForecastResult(sStockCode,dtFrom,dtTo,iID);
        //    return iID; //continue
        //}


        /*---------------------------------
        * Description: Get ID of the specific date and the specific Stock Code from Stock DB
        ----------------------------------- */
        public static int GetID(string sStockCode, DateTime dtDate)
        {
            SqlConnection cn = new SqlConnection(str_Con_SQL);
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "SELECT ID FROM " + sStockCode + " WHERE CloseDate='" + dtDate + "'";
            SqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            int iID = rdr.GetInt32(0);
            rdr.Close();
            cn.Close();
            return iID;
        }

 

    }
}
