using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using WindowFramework;
using System.Data.SqlClient;

namespace StockPredict.DBContext
{
    class Term
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string En { get; set; }
        public string Vn { get; set; }
    }
    class DBStock
    {
        StockDataContext db = new StockDataContext();
        public void CreateDB()
        {
            if (!db.DatabaseExists())
                db.CreateDatabase();
        }

        #region General
        #endregion

        #region Definition
        public List<Term> DefinitionListForCbo(int groupId)
        {
            List<Term> lst = (from t in db.Definitions
                              where t.DefGroupId == groupId
                              select new Term() { Id = t.Id, Name = t.CodeNum, En = t.Definition1, Vn = t.Description }).ToList();
            lst.Insert(0, new Term() { Id = 0, Name = "Select Term" });
            return lst;
        }

        #endregion

        //------------Call Store Proc---------------------------
        public void ChangePriceStat(int iFrom, int iTo, DateTime dtFrom, DateTime dtTo)
        {
            db.ReportChangePrice(iFrom, iTo, dtFrom, dtTo);
        }


        #region Stock
        public DataTable StockList(int iID, bool bSortId)
        {
            DataTable query;
            if (iID == 0)
                if (bSortId)
                    query = (from t in db.Stocks
                         orderby t.Id
                         select new { t.Id, t.Code }).ToADOTable();
                else
                    query = (from t in db.Stocks
                         orderby t.Code
                         select new { t.Id, t.Code }).ToADOTable();
            else
                if (bSortId)
                    query = (from t in db.Stocks
                             where t.Id == iID
                             orderby t.Id
                             select new { t.Id, t.Code }).ToADOTable();
                else
                    query = (from t in db.Stocks
                         where t.Id == iID
                             orderby t.Code
                             select new { t.Id, t.Code }).ToADOTable();

            return query;
        }

        public DataTable StockListbyBranch(string sBranchList)
        {
            db.GetStockListbyBranch(sBranchList);
            DataTable query;
            query = (from t in db.TempStockListbyBranches
                     select new { t.Id, t.Stock }).ToADOTable();

            return query;
        }

        public int StockId(string stock, string market)
        {
            try
            {
                return (from t in db.Stocks
                        where t.Code == stock
                        select new { t.Id }).First().Id;
            }
            catch (Exception) {
                Stock obj = new Stock();
                obj.Code = stock;
                obj.MarketId = db.Definitions.Where(v => v.CodeNum == market).First().Id;
                db.Stocks.InsertOnSubmit(obj);
                db.SubmitChanges();
                return obj.Id;
            }
        }
        #endregion

        //------------Market---------------------------
        public DataTable MarketList()
        {
            return (from t in db.Definitions
                         where t.DefGroupId == 1
                         select new { t.Id, t.CodeNum }).ToADOTable();
        }

        //------------Branch Group---------------------------
        public DataTable BranchGroupList(int id)
        {
            DataTable query;
            if (id == 0)
                query = (from t in db.Branches
                         where t.GroupId == null
                         select new { t.Id, t.Branch1 }).ToADOTable();
            else
                query = (from t in db.Branches
                         where t.GroupId == null && t.Id == id
                         select new { t.Id, t.Branch1 }).ToADOTable();

            return query;
        }

        //------------Branch---------------------------
        public DataTable BranchList(int iGroupFromId, int iGroupToId)
        {
            DataTable query;
            if (iGroupFromId == 0)
                query = (from t in db.Branches
                         select new { t.Id, t.Branch1 }).ToADOTable();
            else
                query = (from t in db.Branches
                         where t.Id >= iGroupFromId && t.Id <= iGroupToId
                         select new { t.Id, t.Branch1 }).ToADOTable();

            return query;
        }


        //------------Changed Percent---------------------------
        public DataTable ChangedPercentList(int iStockFromId, int iStockToId, DateTime dtTo, int iLen, bool isASC, int changePricePercent, bool isAll, int avgVolume, int minPrice, int fiveBasicElementId)
        {
            DataTable query;
            DateTime dtFrom = dtTo.AddDays(-iLen);
            if (isASC)
                query = db.fPrice(iStockFromId, iStockToId, dtFrom, dtTo, changePricePercent, isAll, avgVolume, minPrice, fiveBasicElementId).OrderBy(v=>v.ChangedPercent).ToADOTable();
            else
                query = db.fPrice(iStockFromId, iStockToId, dtFrom, dtTo, changePricePercent, isAll, avgVolume, minPrice, fiveBasicElementId).OrderByDescending(v => v.ChangedPercent).ToADOTable();
            return query;
        }

        public DataTable ChangedPercentList(string stockList, DateTime dtTo, int iLen, bool isASC, int changePricePercent, bool isAll, int avgVolume, int minPrice, int fiveBasicElementId)
        {
            string[] lst = stockList.Split(',');
            int[] lstId = new int[lst.Length];
            int i = 0;
            foreach(string item in lst)
            {
                lstId[i] = Convert.ToInt32(item);
                i++;
            }
            DataTable query;
            DateTime dtFrom = dtTo.AddDays(-iLen);
            if (isASC)
                query = db.fPrice(0, 0, dtFrom, dtTo, changePricePercent, isAll, avgVolume, minPrice, fiveBasicElementId).Where(v=>lstId.Contains(v.Id)).OrderBy(v => v.ChangedPercent).ToADOTable();
            else
                query = db.fPrice(0, 0, dtFrom, dtTo, changePricePercent, isAll, avgVolume, minPrice, fiveBasicElementId).Where(v => lstId.Contains(v.Id)).OrderByDescending(v => v.ChangedPercent).ToADOTable();
            return query;
        }

        public DataTable TopChangedPercentList(DateTime dtTo, int iLen, bool isIncrease, int top, bool isAll, int avgVolume, int fiveBasicElementId)
        {
            DataTable query = null;
            DateTime lastDate = PriceLastDate();
            if (dtTo > lastDate) dtTo = lastDate;
            else if (dtTo.DayOfWeek == DayOfWeek.Saturday) dtTo = dtTo.AddDays(-1);
            else if (dtTo.DayOfWeek == DayOfWeek.Sunday) dtTo = dtTo.AddDays(-2);
            DateTime dtFrom = dtTo.AddDays(-iLen);
            try
            {
                if (isIncrease)
                    query = db.fChangedPrice(dtFrom, dtTo, isAll, avgVolume, top, fiveBasicElementId).OrderByDescending(v => v.IncreasePercent).ToADOTable();
                else
                    query = db.fChangedPrice(dtFrom, dtTo, isAll, avgVolume, top, fiveBasicElementId).OrderBy(v => v.DecreasePercent).ToADOTable();
            }
            catch (Exception) { }
            return query;
        }


        //------------Parameter---------------------------
        public DataTable ParameterList(int iID)
        {
            DataTable query;
            if (iID == 0)
                query = (from t in db.Parameters
                         select t).ToADOTable();
            else
                query = (from t in db.Parameters
                         where t.Id == iID
                         select t).ToADOTable();

            return query;
        }

        public DataTable ParameterListbyStockPos(int iStockPos)
        {
            DataTable query;
                query = (from t in db.Parameters
                         where t.StockPos == iStockPos
                         select t).ToADOTable();

            return query;
        }

        public DataTable ParameterListShort(int iID)
        {
            DataTable query;
            if (iID == 0)
                query = (from t in db.Parameters
                         select  new{t.Id, t.Parameter1} ).ToADOTable();
            else
                query = (from t in db.Parameters
                         where t.Id == iID
                         select new { t.Id, t.Parameter1 }).ToADOTable();

            return query;
        }


        public DataTable ParameterListbyGroup(int iGroup)
        {
            DataTable query;
            if (iGroup == 0)
                query = (from t in db.Parameters
                         select new { t.Id, t.Parameter1 }).ToADOTable();
            else
                query = (from t in db.Parameters
                         where t.GroupId == iGroup
                         select new { t.Id, t.Parameter1 }).ToADOTable();

            return query;
        }
        public DataTable ParameterListbyGroup(int iGroup, int iGroup1)
        {
            DataTable query;
            if (iGroup==1)
                query = (from t in db.Parameters
                         where t.GroupId == iGroup || t.GroupId == iGroup1
                         orderby t.StockPos
                         select new { t.Id, t.Parameter1, t.StockPos }).ToADOTable();
            else
                query = (from t in db.Parameters
                         where t.GroupId == iGroup || t.GroupId == iGroup1
                         orderby t.BranchPos
                         select new { t.Id, t.Parameter1, t.StockPos }).ToADOTable();


            return query;
        }

        //public void ParameterInsertbyADO(int iGroupId, string sParam, string sVNParam, string sDesc, string sMask, int iStockPos, int iBranchPos)
        //{
        //    string sSQL;

        //    // create a connection object                
        //    string ConnectionString = "Integrated security =SSPI;" + "Initial Catalog = Stock;" + "Data Source = localhost; ";
        //    SqlConnection conn = new SqlConnection(ConnectionString);

        //    SqlCommand cmd;
        //    // Connection and SQL strings
        //    sSQL = "SELECT * FROM FinanceValue WHERE StockId=" + iStockId + " AND Term=" + iTerm;


        //    // create command object
        //    cmd = new SqlCommand(sSQL, conn);

        //    // open connection
        //    conn.Open();

        //    // call command's ExcuteReader
        //    SqlDataReader reader = cmd.ExecuteReader();
        //    if (!reader.Read()) // The record is not exist
        //        // Insert record
        //        FinanceValueInsert(iStockId, iTerm);

        //    sSQL = "UPDATE FinanceValue SET ";
        //    for (int i = 0; i < dValue.Count(); i++)
        //    {
        //        if (dValue[i] >= 0)
        //            sSQL += reader.GetName(i + 3) + "=" + dValue[i] + ",";
        //    }
        //    sSQL = sSQL.Substring(0, sSQL.Length - 1);
        //    sSQL += " WHERE StockId=" + iStockId + " AND Term=" + iTerm;
        //    reader.Close();

        //    try
        //    {
        //        // create command object
        //        cmd = new SqlCommand(sSQL, conn);
        //        cmd.CommandText = sSQL;
        //        cmd.ExecuteNonQuery();
        //    }

        //    finally
        //    {
        //        // close reader and connection
        //        conn.Close();
        //    }
        //}
        
        //------------Parameter Value---------------------------
        public DataTable ParameterValueList(int iID)
        {
            DataTable query;
            if (iID == 0)
                query = (from t in db.ParameterValues

                         select new { t }).ToADOTable();
            else
                query = (from t in db.ParameterValues
                         where t.Id == iID
                         select new { t }).ToADOTable();

            return query;
        }

        public DataTable ParameterValueList(int iStock, DateTime dtDate)
        {
            DataTable query;
            if (iStock == 0)
                query = (from t in db.ParameterValues
                         from t1 in db.Parameters
                         from t2 in db.Stocks
                         where t.ParameterId == t1.Id && t.StockId == t2.Id
                         select new { t.Id, t.ParameterId, t.StockId, t2.Code, t1.Parameter1, t.AffectDate, t.Value }).ToADOTable();
            else
                if (dtDate.Equals(DateTime.Now))
                    query = (from t in db.ParameterValues
                         from t1 in db.Parameters
                         from t2 in db.Stocks
                             where t.ParameterId == t1.Id && t.StockId == iStock && t.StockId == t2.Id
                             select new { t.Id, t.ParameterId, t.StockId, t2.Code, t1.Parameter1, t.AffectDate, t.Value }).ToADOTable();
                else
                    query = (from t in db.ParameterValues
                             from t1 in db.Parameters
                             from t2 in db.Stocks
                             where t.ParameterId == t1.Id && t.StockId == iStock && t.StockId == t2.Id && t.AffectDate >= dtDate
                             select new { t.Id, t.ParameterId, t.StockId, t2.Code, t1.Parameter1, t.AffectDate, t.Value }).ToADOTable();

            return query;
        }

        public int ParameterValueInsert(int iParam,int iStock,float fValue, DateTime dtDate)
        {
            ParameterValue obj = new ParameterValue();
            obj.ParameterId = iParam;
            obj.StockId = iStock;
            obj.Value = fValue;
            obj.AffectDate = dtDate;
            db.ParameterValues.InsertOnSubmit(obj);
            db.SubmitChanges();
            return obj.Id;
        }

        public int ParameterValueEdit(int iId, int iParam, int iStock, float fValue, DateTime dtDate)
        {
            ParameterValue obj = (from t in db.ParameterValues
                                   where t.Id == iId
                                   select t).First();
            obj.ParameterId = iParam;
            obj.StockId = iStock;
            obj.Value = fValue;
            obj.AffectDate = dtDate;
            db.SubmitChanges();
            return obj.Id;
        }

        public void ParameterValueDelete(int iId)
        {
            try
            {
                ParameterValue obj = (from t in db.ParameterValues
                                       where t.Id == iId
                                       select t).First();
                db.ParameterValues.DeleteOnSubmit(obj);
                db.SubmitChanges();
            }
            catch (Exception e)
            {
            }
        }

        //------------Finance---------------------------

        //public DataTable StockFinanceList(string sStockList)
        //{
        //    db.GetStockFinanceList(sStockList);
        //    DataTable query;
        //    query = (from t in db.TempStockFinanceLists
        //             select t).ToADOTable();

        //    return query;
        //}

        public DataTable FinanceList(int fromLst, List<int> lst)
        {
            if (fromLst == 1)
                return (from t in db.Stocks where lst.Contains(t.Id) select t).ToADOTable();
            else
                return (from t in db.Branches where lst.Contains(t.Id) select t).ToADOTable();
        }


        //------------Parameter Default---------------------------
        public DataTable ParameterDefaultList(int iType)
        {
            DataTable query;
            if (iType == 0)
                query = (from t in db.ParameterDefaults
                         select new { t.DefaultParam }).ToADOTable();
            else
                query = (from t in db.ParameterDefaults
                         where t.TypeId == iType
                         select new { t.DefaultParam }).ToADOTable();

            return query;
        }


        public int ParameterDefaultInsert(int iType, string sDefault)
        {
            ParameterDefault obj = new ParameterDefault();
            obj.TypeId = iType;
            obj.DefaultParam = sDefault;
            db.ParameterDefaults.InsertOnSubmit(obj);
            db.SubmitChanges();
            return obj.Id;
        }

        public int ParameterDefaultEdit(int iType, string sDefault)
        {
            ParameterDefault obj = (from t in db.ParameterDefaults
                                  where t.TypeId == iType
                                  select t).First();
            
            obj.DefaultParam = sDefault;
            db.SubmitChanges();
            return obj.Id;
        }

        //------------Finance Value---------------------------
        public DataTable FinanceValueList(int iStockId)
        {
            DataTable query;
            if (iStockId == 0)
                query = (from t in db.vStockFinances
                         select t).ToADOTable();
            else
                query = (from t in db.vStockFinances
                         where t.StockId == iStockId
                         select t).ToADOTable();
            
            return query;
        }

        public DataTable FinanceValueListbyTerm(int iTerm)
        {
            DataTable query;
            if (iTerm == 0)
                query = (from t in db.vStockFinances
                         select t).ToADOTable();
            else
                query = (from t in db.vStockFinances
                         where t.Term == iTerm
                         select t).ToADOTable();

            return query;
        }

        public DataTable FinanceValueList(int iStockId, int iTerm)
        {
            DataTable query;
            query = (from t in db.vStockFinances
                         where t.StockId == iStockId && t.Term == iTerm
                         select t).ToADOTable();

            return query;
        }

        public int FinanceValueInsert(int iStockId, int iTerm)
        {
            FinanceValue obj = new FinanceValue();
            obj.StockId = iStockId;
            obj.Term = iTerm;
            db.FinanceValues.InsertOnSubmit(obj);
            db.SubmitChanges();
            return obj.Id;
        }

        public void FinanceValueEditbyADO(int iStockId, int iTerm, double []dValue)
        {
            string sSQL;
            
            // create a connection object                
            string ConnectionString = "Integrated security =SSPI;" + "Initial Catalog = Stock;" + "Data Source = localhost; ";
            SqlConnection conn = new SqlConnection(ConnectionString);

            SqlCommand cmd;
            // Connection and SQL strings
            sSQL = "SELECT * FROM FinanceValue WHERE StockId=" + iStockId + " AND Term=" + iTerm;


            // create command object
            cmd = new SqlCommand(sSQL, conn);

            // open connection
            conn.Open();

            // call command's ExcuteReader
            SqlDataReader reader = cmd.ExecuteReader();
            if (!reader.Read()) // The record is not exist
                // Insert record
                FinanceValueInsert(iStockId, iTerm);

            sSQL = "UPDATE FinanceValue SET ";
            for (int i = 0; i < dValue.Count(); i++)
            {
                if (dValue[i] >= 0)
                    sSQL += reader.GetName(i+3) + "=" + dValue[i] + ",";
            }
            sSQL = sSQL.Substring(0, sSQL.Length - 1);
            sSQL += " WHERE StockId=" + iStockId + " AND Term=" + iTerm;
            reader.Close();                

            try
            {
                // create command object
                cmd = new SqlCommand(sSQL, conn); 
                cmd.CommandText = sSQL;
                cmd.ExecuteNonQuery();
            }

            finally
            {
                // close reader and connection
                conn.Close();
            }
        }

        //------------Branch Finance Value---------------------------
        public DataTable BranchFinanceValueList(int iBranchId)
        {
            DataTable query;
            if (iBranchId == 0)
                query = (from t in db.vBranchFinances
                         select t).ToADOTable();
            else
                query = (from t in db.vBranchFinances
                         where t.Id == iBranchId
                         select t).ToADOTable();

            return query;
        }

        public DataTable BranchFinanceValueListbyTerm(int iTerm)
        {
            DataTable query;
            if (iTerm == 0)
                query = (from t in db.vBranchFinances
                         select t).ToADOTable();
            else
                query = (from t in db.vBranchFinances
                         where t.Term == iTerm
                         select t).ToADOTable();

            return query;
        }

        public DataTable BranchFinanceValueList(int iBranchId, int iTerm)
        {
            DataTable query;
            query = (from t in db.vBranchFinances
                     where t.Id == iBranchId && t.Term == iTerm
                     select t).ToADOTable();

            return query;
        }

        //public int BranchFinanceValueInsert(int id, decimal income)
        //{
        //    Branch obj = (from t in db.Branches
        //                  where t.Id == id
        //                  select t).First();
            
        //    obj.Income = income;
        //    db.Branches.InsertOnSubmit(obj);
        //    db.SubmitChanges();
        //    return Convert.ToInt32(obj.Id);
        //}

        //public void BranchFinanceValueEditbyADO(int iBranchId, int iTerm, double[] dValue)
        //{
        //    string sSQL;

        //    // create a connection object                
        //    string ConnectionString = "Integrated security =SSPI;" + "Initial Catalog = Stock;" + "Data Source = localhost; ";
        //    SqlConnection conn = new SqlConnection(ConnectionString);

        //    SqlCommand cmd;
        //    // Connection and SQL strings
        //    sSQL = "SELECT * FROM BranchFinanceValue WHERE BranchId=" + iBranchId + " AND Term=" + iTerm;


        //    // create command object
        //    cmd = new SqlCommand(sSQL, conn);

        //    // open connection
        //    conn.Open();

        //    // call command's ExcuteReader
        //    SqlDataReader reader = cmd.ExecuteReader();
        //    if (!reader.Read()) // The record is not exist
        //        // Insert record
        //        BranchFinanceValueInsert(iBranchId, iTerm);

        //    sSQL = "UPDATE BranchFinanceValue SET ";
        //    for (int i = 0; i < dValue.Count(); i++)
        //    {
        //        if (dValue[i] >= 0)
        //            sSQL += reader.GetName(i+3) + "=" + dValue[i] + ",";
        //    }
        //    sSQL = sSQL.Substring(0, sSQL.Length - 1);
        //    sSQL += " WHERE BranchId=" + iBranchId + " AND Term=" + iTerm;
        //    reader.Close();

        //    try
        //    {
        //        // create command object
        //        cmd = new SqlCommand(sSQL, conn);
        //        cmd.CommandText = sSQL;
        //        cmd.ExecuteNonQuery();
        //    }

        //    finally
        //    {
        //        // close reader and connection
        //        conn.Close();
        //    }
        //}

        #region Price
        public DataTable PriceList(List<int> lstId, int days)
        {
            DataTable query;
            if (lstId.Count > 0)
                query = (from t in db.vPrices
                     where lstId.Contains(t.StockId.Value)
                     orderby t.Id descending
                     select t).Take(days).ToADOTable();
            else
                query = (from t in db.vPrices
                         orderby t.Id descending
                         select t).Take(days).ToADOTable();
            return query;
        }


        public DataTable PriceList(int iStockId)
        {
            DataTable query;
                query = (from t in db.Prices
                         where t.StockId == iStockId
                         select t ).ToADOTable();
            return query;
        }

        public DataTable PriceList(int iStockId, DateTime dtFrom, DateTime dtTo)
        {
            DataTable query;
            query = (from t in db.Prices
                     where t.StockId == iStockId && t.PriceDate >= dtFrom && t.PriceDate <= dtTo
                     select t).ToADOTable();
            return query;
        }

        public DateTime PriceLastDate()
        {
            return (from t in db.Prices
                    orderby t.PriceDate descending
                    select new { t.PriceDate }).First().PriceDate.Value;
        }

        #endregion

        //------------Group---------------------------
        public DataTable GroupList(int iGroupId)
        {
            DataTable query;
            if (iGroupId == 0)
                query = (from t in db.ParameterGroups
                         select t).ToADOTable();
            else
                query = (from t in db.ParameterGroups
                         where t.Id == iGroupId
                         select t).ToADOTable();

            return query;
        }


        #region Price
        public void PriceInsert(int stockId, DateTime priceDate, decimal Open, decimal High, decimal Low, decimal Close, int Volume)
        {
            try
            {
                if ((from t in db.Prices
                     where t.StockId == stockId && t.PriceDate == priceDate
                     select new {t.Id}).First().Id > 0)
                    return;
            }
            catch (Exception) { }
            Price obj = new Price();
            obj.StockId = stockId;
            obj.PriceDate = priceDate;
            obj.OpenPrice = Open;
            obj.HighPrice = High;
            obj.LowPrice = Low;
            obj.ClosePrice = Close;
            obj.Volume = Volume;
            db.Prices.InsertOnSubmit(obj);
            db.SubmitChanges();
        }
        #endregion

        #region StockMonitor
        public List<vStockMonitor> MonitorList()
        {
            return db.vStockMonitors.ToList();
        }

        public int MonitorUpdate(int stockId, int sourceId, string reason)
        {
            int id;
            try
            {
                StockMonitor obj = db.StockMonitors.Where(v => v.StockId == stockId).First();
                MonitorEdit(obj, sourceId, reason);
                StockHolder(stockId);
                return obj.Id;
            }
            catch (Exception) { return MonitorInsert(stockId, sourceId, reason); }
        }

        public int MonitorInsert(int stockId, int sourceId, string reason)
        {
            StockMonitor obj = new StockMonitor();
            obj.CreatedDate = DateTime.Now;
            obj.StockId = stockId;
            obj.SourceId = sourceId;
            obj.Reason = reason;
            db.StockMonitors.InsertOnSubmit(obj);
            Portfolio obj1 = new Portfolio();
            obj1.StockId = stockId;
            db.Portfolios.InsertOnSubmit(obj1);
            db.SubmitChanges();
            return obj.Id;
        }

        public void MonitorEdit(StockMonitor obj, int sourceId, string reason)
        {
            obj.CreatedDate = DateTime.Now;
            obj.SourceId = sourceId;
            obj.Reason = reason;
            db.SubmitChanges();
        }

        public void MonitorEdit(int id, int sourceId, string reason)
        {
            StockMonitor obj = db.StockMonitors.Where(v => v.Id == id).First();
            obj.CreatedDate = DateTime.Now;
            obj.SourceId = sourceId;
            obj.Reason = reason;
            db.SubmitChanges();
        }


        public void MonitorDelete(int id)
        {
            db.StockMonitors.DeleteOnSubmit(db.StockMonitors.Where(v => v.Id == id).First());
            db.SubmitChanges();
        }
        #endregion

        #region Portfolio
        public List<vPortfolio> PortfolioList()
        {
            return db.vPortfolios.ToList();
        }

        public void PortfolioInsert(int stockid, decimal buyPrice, decimal buyRealPrice, DateTime buyRealDate, decimal salePrice, decimal saleRealPrice, DateTime saleRealDate)
        {
            Portfolio obj = new Portfolio();
            obj.StockId = stockid;
            obj.BuyPrice = buyPrice;
            obj.BuyRealPrice = buyRealPrice;
            obj.BuyRealDate = buyRealDate;
            obj.SalePrice = salePrice;
            obj.SaleRealPrice = saleRealPrice;
            obj.SaleRealDate = saleRealDate;
            db.Portfolios.InsertOnSubmit(obj);
            db.SubmitChanges();
        }

        public void PortfolioEdit(int iId, int stockid, decimal buyPrice, decimal buyRealPrice, DateTime buyRealDate, decimal salePrice, decimal saleRealPrice, DateTime saleRealDate)
        {
            Portfolio obj = db.Portfolios.Where(v => v.Id == iId).First();
            obj.StockId = stockid;
            obj.BuyPrice = buyPrice;
            obj.BuyRealPrice = buyRealPrice;
            obj.BuyRealDate = buyRealDate;
            obj.SalePrice = salePrice;
            obj.SaleRealPrice = saleRealPrice;
            obj.SaleRealDate = saleRealDate;
            db.SubmitChanges();
        }

        public void PortfolioDelete(int iId)
        {
            Portfolio obj = db.Portfolios.Where(v => v.Id == iId).First();
            db.Portfolios.DeleteOnSubmit(obj);
            db.SubmitChanges();
        }

        public DataTable PortfolioCompare(DateTime dtStart)
        {
            // Example list.
            List<string[]> list = new List<string[]>();

            var lst = db.vPortfolios.OrderBy(v => v.StockId).ToList();
            int colCount = lst.Count + 1;
            string[] columns = new string[colCount];
            int[] stockIds = new int[colCount - 1];
            columns[0] = "Date";
            int i = 0;
            decimal[][] portfolioPrice = new decimal[colCount - 1][];
            foreach (var item in lst)
            {
                i++;
                columns[i] = item.Stock;
                stockIds[i - 1] = item.StockId.Value;
                portfolioPrice[i - 1] = new decimal[4];
                portfolioPrice[i - 1][0] = item.BuyPrice.Value;
                portfolioPrice[i - 1][1] = item.BuyRealPrice.Value;
                portfolioPrice[i - 1][2] = item.SalePrice.Value;
                portfolioPrice[i - 1][3] = item.SaleRealPrice.Value;
            }
            list.Add(columns);

            var table = (from t in db.Prices
                         where t.PriceDate >= dtStart && stockIds.Contains(t.StockId.Value)
                         orderby t.PriceDate descending, t.StockId ascending
                         select t);

            i = 1;
            string[] data = new string[colCount];
            decimal[] valueRow = new decimal[colCount - 1];
            List<decimal[]> value = new List<decimal[]>();

            decimal[] currentHigh = new decimal[colCount - 1];
            decimal[] currentLow = new decimal[colCount - 1];
            decimal[] currentClose = new decimal[colCount - 1];
            bool first = true;
            foreach (var row in table)
            {
                if (first)
                {
                    currentHigh[i - 1] = row.HighPrice.Value;
                    currentLow[i - 1] = row.LowPrice.Value;
                    currentClose[i - 1] = row.ClosePrice.Value;
                }
                if (i == 1)
                {
                    data = new string[colCount];
                    valueRow = new decimal[colCount - 1];
                    data[0] = row.PriceDate.ToString();
                    data[1] = row.ClosePrice.ToString();
                    valueRow[0] = row.ClosePrice.Value;
                }
                else
                {
                    data[i] = row.ClosePrice.ToString();
                    valueRow[i - 1] = row.ClosePrice.Value;
                }

                i++;
                if (i == colCount)
                {
                    list.Add(data);
                    value.Add(valueRow);
                    i = 1;
                    first = false;
                }
            }


            decimal[] max = new decimal[colCount - 1];
            decimal[] min = new decimal[colCount - 1];
            decimal[] average = new decimal[colCount - 1];

            int count = 0;
            foreach (decimal[] tmp in value)
            {
                for (i = 0; i < colCount - 1; i++)
                {
                    if (max[i] < tmp[i])
                        max[i] = tmp[i];
                    if (min[i] == 0 || min[i] > tmp[i])
                        min[i] = tmp[i];
                    count++;
                    average[i] += tmp[i];
                }
            }

            if (count == 0) return null;


            //Max
            data = new string[colCount];
            data[0] = "Max";
            for (i = 1; i < colCount; i++)
                data[i] = max[i - 1].ToString("0.00");
            list.Add(data);


            //Min
            data = new string[colCount];
            data[0] = "Min";
            for (i = 1; i < colCount; i++)
                data[i] = min[i - 1].ToString("0.00");
            list.Add(data);

            //Average
            data = new string[colCount];
            data[0] = "Average";
            for (i = 1; i < colCount; i++)
                data[i] = (average[i - 1] / count).ToString("0.00");
            list.Add(data);

            //Max-Min/Min
            data = new string[colCount];
            data[0] = "Max-Min/Min";
            for (i = 1; i < colCount; i++)
                data[i] = (100 * (max[i - 1] - min[i - 1]) / min[i - 1]).ToString("0.00");
            list.Add(data);

            //100 * (Sale - Buy)/Buy
            data = new string[colCount];
            data[0] = "100 * (Sale - Buy) / Buy";
            for (i = 1; i < colCount; i++)
                if (portfolioPrice[i - 1][0] > 0)
                    data[i] = (100 * (portfolioPrice[i - 1][2] - portfolioPrice[i - 1][0]) / portfolioPrice[i - 1][0]).ToString("0.00");
            list.Add(data);

            //100 * (RealSale - RealBuy) / RealBuy
            data = new string[colCount];
            data[0] = "100 * (RealSale - RealBuy) / RealBuy";
            for (i = 1; i < colCount; i++)
                if (portfolioPrice[i - 1][1] > 0)
                    data[i] = (100 * (portfolioPrice[i - 1][3] - portfolioPrice[i - 1][1]) / portfolioPrice[i - 1][1]).ToString("0.00");
            list.Add(data);

            //100 * (RealBuy - CurrentPrice) / CurrentPrice
            data = new string[colCount];
            data[0] = "100 * (RealBuy - CurrentPrice) / CurrentPrice";
            for (i = 1; i < colCount; i++)
                data[i] = (100 * (portfolioPrice[i - 1][1] - currentClose[i - 1]) / currentClose[i - 1]).ToString("0.00");
            list.Add(data);

            //100 * (RealSale - CurrentPrice) / CurrentPrice
            data = new string[colCount];
            data[0] = "100 * (RealSale - CurrentPrice) / CurrentPrice";
            for (i = 1; i < colCount; i++)
                data[i] = (100 * (portfolioPrice[i - 1][3] - currentClose[i - 1]) / currentClose[i - 1]).ToString("0.00");
            list.Add(data);

            //Current: High - Low
            data = new string[colCount];
            data[0] = "Current: High - Low";
            for (i = 1; i < colCount; i++)
                data[i] = (100 * (currentHigh[i - 1] - currentLow[i - 1]) / currentLow[i - 1]).ToString("0.00");
            list.Add(data);

            // Convert to DataTable.
            return ConvertListToDataTable(list);
        }

        private DataTable ConvertListToDataTable(List<string[]> list)
        {
            // New table.
            DataTable table = new DataTable();

            // Get max columns.
            int columns = 0;
            foreach (var array in list)
            {
                if (array.Length > columns)
                {
                    columns = array.Length;
                }
            }

            // Add columns.
            for (int i = 0; i < columns; i++)
            {
                table.Columns.Add(list[0][i]);
            }

            // Add rows.
            foreach (var array in list)
            {
                table.Rows.Add(array);
            }
            table.Rows.RemoveAt(0);

            return table;
        }

        #endregion

        #region Stock Info
        public string StockInfoUrl(int stockId)
        {
            return db.vStockInfos.Where(v => v.StockId == stockId).First().Url;
        }

        public void StockHolder(int stockId)
        {
            string code = db.Stocks.Where(v => v.Id == stockId).First().Code;
            Definition obj = db.Definitions.Where(v => v.Id == 35012).First();
            string url = obj.CodeNum.Replace("{code}", code);
            string method = "";
            switch(obj.Num1)
            {
                case 1:
                    method = "Get";
                    break;
                case 2:
                    method = "Post";
                    break;
                case 3:
                    method = "Put";
                    break;

            }
            string data = WindowFramework.LibWeb.HttpRequestData(url, method);
            int start = data.IndexOf("KL CP đang lưu hành :&nbsp;") + "KL CP đang lưu hành :&nbsp;".Length;
            data = data.Substring(start);
            int end = data.IndexOf("&nbsp;cp");
            int currentStock = Convert.ToInt32(data.Substring(0, end).Replace(",", ""));
            Stock stock = db.Stocks.Where(v => v.Id == stockId).First();
            stock.TotalStock = currentStock;
            db.SubmitChanges();

            string[] holder = new string[3];
            data = data.Substring(data.IndexOf("<table") + 6);
            data = data.Substring(data.IndexOf("<tr") + 3);
            data = data.Substring(data.IndexOf("<tr") + 3);

            //Delete all StockHolder of stockId
            var items = db.StockHolders.Where(v => v.StockId == stockId);
            db.StockHolders.DeleteAllOnSubmit(items);

            StockHolder stockHolder;
            while (data.IndexOf("<tr") < data.IndexOf("</table>"))
            {
                start = data.IndexOf("<td align=\"left\">") + "<td align=\"left\">".Length;
                data = data.Substring(start);
                end = data.IndexOf("</td>");

                holder[0] = StringClear(data.Substring(0, end)); // fullname
                data = data.Substring(end);

                start = data.IndexOf("<td align=\"right\">") + "<td align=\"right\">".Length;
                data = data.Substring(start);
                end = data.IndexOf("</td>");
                holder[1] = StringClear(data.Substring(0, end)); // quantity

                start = data.IndexOf("<td align=\"center\">") + "<td align=\"center\">".Length;
                data = data.Substring(start);
                end = data.IndexOf("</td>");
                holder[2] = StringClear(data.Substring(0, end)); // affect date
                //insert to StockHolder
                stockHolder = new StockHolder();
                stockHolder.StockId = stockId;
                stockHolder.StockHolderName = holder[0];
                stockHolder.Quantity = Convert.ToInt32(holder[1]);
                stockHolder.AffectedDate = DateTime.ParseExact(holder[2], "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                db.StockHolders.InsertOnSubmit(stockHolder);
                db.SubmitChanges();

            }
        }

        private string StringClear(string data)
        {
            int pos = data.IndexOf(">") + 1;
            if (pos > 0)
            {
                data = data.Substring(pos);
                pos = data.IndexOf("<");
                data = data.Substring(0, pos);
            }
            data = data.Replace("\r\n", "").Trim().Replace(",", "");
            return data;
        }

        public List<vStockHolder> StockHolderList(int stockId)
        {
            return db.vStockHolders.Where(v=>stockId == 0 || v.StockId == stockId).ToList();
        }

        #endregion
    }
}
