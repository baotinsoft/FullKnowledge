using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using WindowFramework;
using System.Data.SqlClient;

namespace StockKnowledge.DBContext
{
    class Term
    {
        public int Id {get; set; }
        public string Name {get; set; }
        public string En {get; set; }
        public string Vn { get; set; }
    }
    class DBKnowledge
    {
        KnowledgeDBDataContext db = new KnowledgeDBDataContext();

        #region General
        public string[,] GetColumnswithType(string table)
        {
            SqlConnection sqlConn = (SqlConnection)db.Connection;
            string[,] items = null;
            try
            {                
                sqlConn.Open();
                //if (DB.Length > 0)
                //    sqlConn.ChangeDatabase(DB);
                SqlCommand sqlCom = new System.Data.SqlClient.SqlCommand();
                sqlCom.Connection = sqlConn;
                sqlCom.CommandType = CommandType.Text;
                sqlCom.CommandText = "SELECT COLUMN_NAME, DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = N'" + table + "'";
                SqlDataReader sqlDR;
                sqlDR = sqlCom.ExecuteReader();

                using (DataTable dt = new DataTable())
                {
                    dt.Load(sqlDR);
                    int count = dt.Rows.Count - 1;
                    items = new string[count, 2];
                    for (int i = 0; i < count; i++)
                    {
                        items[i, 0] = dt.Rows[i + 1][0].ToString();
                        items[i, 1] = dt.Rows[i + 1][1].ToString();
                    }
                }


                sqlCom.Dispose();
            }
            catch (Exception ex) { }
            if (sqlConn.State == ConnectionState.Open)
                sqlConn.Close();

            return items;
        }
        #endregion

        #region DefinitionGroup
        public List<DefinitionGroup> GroupList()
        {
            return db.DefinitionGroups.ToList();
        }

        public void GroupInsert(string name, string description, int first, int last)
        {
            DefinitionGroup obj = new DefinitionGroup();
            obj.DefGroup = name;
            obj.Description = description;
            obj.First = first;
            obj.Last = last;
            obj.Id = db.DefinitionGroups.OrderByDescending(v => v.Id).First().Id + 1;
            db.DefinitionGroups.InsertOnSubmit(obj);
            db.SubmitChanges();
        }
        #endregion

        #region Definition
        public decimal CalculatorGet(int id, out string sourceMethod, string value, decimal price)
        {
            string method = (from t in db.Definitions
                    where t.Id == id
                    select new { t.CodeNum }).First().CodeNum;
            string[] items = method.Split(' ');
            string[] sourceItems = method.Split(' ');
            sourceMethod = "";
            string infix = "";
            for (int i = 0; i < items.Length; i++ )
            {
                if (items[i].Length == 5)
                {
                    items[i] = db.Definitions.Where(t => t.Id == Convert.ToInt32(items[i])).First().CodeNum;
                    if (sourceItems[i] == "20002")
                        sourceItems[i] = price.ToString();
                    else
                    {
                        int pos = value.IndexOf(sourceItems[i]);
                        if (pos > -1)
                        {
                            pos += 6;
                            int pos1 = value.Substring(pos).IndexOf(' ');
                            sourceItems[i] = value.Substring(pos, pos1 - pos);
                        }
                    }

                }
                infix += sourceItems[i];
                sourceMethod += items[i];
            }

            return LibExpression.EvaluateInfix(sourceMethod);
        }

        public List<Term> DefinitionListForCbo(int iGroupId)
        {
            List<Term> lst = (from t in db.Definitions
                    where t.DefGroupId == iGroupId
                    select new Term() { Id = t.Id, Name = t.CodeNum, En = t.Definition1, Vn = t.Description }).ToList();
            lst.Insert(0, new Term() { Id = 0, Name = "Select Term" });
            return lst;
        }

        public Term DefinitionById(int id)
        {
            return (from t in db.Definitions
                    where t.Id == id
                    select new Term() { Id = t.Id, Name = t.CodeNum, En = t.Definition1, Vn = t.Description }).First();
        }

        public List<Term> DefinitionList(int iGroupId)
        {
            return (from t in db.Definitions
                    where t.DefGroupId == iGroupId
                    select new Term(){ Id=t.Id, Name=t.CodeNum, En=t.Definition1, Vn=t.Description }).ToList();
        }

        public List<vDefinition> SourceDefinitionList(int iGroupId)
        {
            return (from t in db.vDefinitions
                    where t.DefGroupId == iGroupId
                    select t).ToList();
        }

        public List<string> GetUrls(int type)
        {
            return (from t in db.Definitions
                    where t.DefGroupId == 7 && t.Num2 == type
                    select t.CodeNum).ToList();
        }

        public void DefinitionInsert(int iGroupId, string sName, string sEn, string sVN, int num1, int num2)
        {
            //Get last ID
            int iLastId = db.Definitions.Where(v => v.DefGroupId == iGroupId).OrderByDescending(v => v.Id).First().Id;

            Definition obj = new Definition();
            obj.Id = iLastId + 1;
            obj.DefGroupId = iGroupId;
            obj.CodeNum = sName;
            obj.Definition1 = sEn;
            obj.Description = sVN;
            obj.Num1 = num1;
            obj.Num2 = num2;
            obj.CreateDate = DateTime.Now;
            db.Definitions.InsertOnSubmit(obj);
            db.SubmitChanges();
        }

        public void DefinitionEdit(int iId, string sName, string sEn, string sVN, int num1, int num2)
        {
            Definition obj = db.Definitions.Where(v => v.Id == iId).First();
            obj.CodeNum = sName;
            obj.Definition1 = sEn;
            obj.Description = sVN;
            obj.Num1 = num1;
            obj.Num2 = num2;
            obj.CreateDate = DateTime.Now;
            db.SubmitChanges();
        }

        public void DefinitionDelete(int iId)
        {
            Definition obj = db.Definitions.Where(v => v.Id == iId).First();
            db.Definitions.DeleteOnSubmit(obj);
            db.SubmitChanges();
        }

        public int UrlType(string url)
        {
            return db.Definitions.Where(v => v.DefGroupId == 7).Where(v => v.CodeNum == url).Select(v => v.Num1).First().Value;
        }
        #endregion

        #region Branch
        public List<Branch> BranchList()
        {
            return db.Branches.ToList();
        }

        public List<Branch> BranchList(int fiveBasicElementId)
        {
            return db.Branches.Where(v=>v.FiveBasicElementId == fiveBasicElementId).ToList();
        }

        public List<Branch> BranchListForCbo()
        {
            List<Branch> lst = db.Branches.Where(v=>v.GroupId == null).ToList();
            lst.Insert(0, new Branch() { Id = 0, Branch1 = "Select Branch" });
            return lst;
        }

        public void BranchDelete(int id)
        {
            try
            {
                if (db.Stocks.Where(v => v.BranchId == id).First().Id > 0) return;
            }
            catch (Exception) { }
            Branch obj = db.Branches.Where(v => v.Id == id).First();
            db.Branches.DeleteOnSubmit(obj);
            db.SubmitChanges();
        }

        public void BranchInsert(string[] lstData)
        {
            for (int i = 0; i < lstData.Length; i++) lstData[i] = lstData[i].Replace("%", "").Replace(",","");
            Branch obj;
            bool exist = false;
            try
            {
                obj = db.Branches.Where(v => v.Branch1 == lstData[0]).First();
                exist = true;
            }
            catch (Exception) { obj = new Branch(); }
            
            obj.Branch1 = lstData[0];
            obj.ChangeNumber = lstData[1] == null ? 0 : Convert.ToDecimal(lstData[1]);
            obj.ChangePercent = lstData[2] == null ? 0 : Convert.ToDecimal(lstData[2]);
            obj.EPS = lstData[3] == null ? 0 : Convert.ToDecimal(lstData[3]);
            obj.PE = lstData[4] == null ? 0 : Convert.ToDecimal(lstData[4]);
            obj.ROA = lstData[5] == null ? 0 : Convert.ToDecimal(lstData[5]);
            obj.ROE = lstData[6] == null ? 0 : Convert.ToDecimal(lstData[6]);
            obj.AvgPrice = lstData[7] == null ? 0 : Convert.ToDecimal(lstData[7]);
            obj.BookValue = lstData[8] == null ? 0 : Convert.ToDecimal(lstData[8]);

            obj.PB = lstData[9] == null ? 0 : Convert.ToDecimal(lstData[9]);
            obj.Beta = lstData[10] == null ? 0 : Convert.ToDecimal(lstData[10]);
            obj.TotalStock = lstData[11] == null ? 0 : Convert.ToDecimal(lstData[11]);
            obj.ForeignStock = lstData[12] == null ? 0 : Convert.ToDecimal(lstData[12]);
            obj.ForeignPercent = lstData[13] == null ? 0 : Convert.ToDecimal(lstData[13]);
            obj.Capitalization = lstData[14] == null ? 0 : Convert.ToDecimal(lstData[14]);
            obj.Url = lstData[15];
            obj.UpdateDate = DateTime.Now.Date;
            if (!exist) db.Branches.InsertOnSubmit(obj);
            db.SubmitChanges();
        }

        #endregion

        #region Stock
        public List<Stock> StockListForCbo()
        {
            List<Stock> lst = db.Stocks.ToList();
            lst.Insert(0, new Stock() { Id = 0, Code = "Select Stock" });
            return lst;
        }

        public List<Stock> StockList()
        {
            return db.Stocks.ToList();
        }

        public List<Stock> StockList(int branchId)
        {
            return db.Stocks.Where(v=>v.BranchId == branchId).ToList();
        }

        public List<Stock> StockMissingDetailList()
        {
            return db.Stocks.Where(v => v.Stock1 == null).ToList();
        }


        public int StockInsert(string code)
        {
            Stock obj = new Stock();
            obj.Code = code;
            db.Stocks.InsertOnSubmit(obj);
            db.SubmitChanges();
            return obj.Id; 
        }

        public void StockInsert(string[] lstData, int branchId)
        {
            for (int i = 0; i < lstData.Length; i++) lstData[i] = lstData[i].Replace("%", "").Replace(",", "");
            Stock obj;
            bool exist = false;
            try
            {
                obj = db.Stocks.Where(v => v.Code == lstData[0]).First();
                exist = true;
            }
            catch (Exception) { obj = new Stock(); }

            obj.Code = lstData[0];
            obj.BranchId = branchId;

            obj.ChangeNumber = lstData[1] == null ? 0 : Convert.ToDecimal(lstData[1]);
            obj.ChangePercent = lstData[2] == null ? 0 : Convert.ToDecimal(lstData[2]);
            obj.EPS = lstData[3] == null ? 0 : Convert.ToDecimal(lstData[3]);
            obj.PE = lstData[4] == null ? 0 : Convert.ToDecimal(lstData[4]);
            obj.ROA = lstData[5] == null ? 0 : Convert.ToDecimal(lstData[5]);
            obj.ROE = lstData[6] == null ? 0 : Convert.ToDecimal(lstData[6]);
            obj.BookValue = lstData[7] == null ? 0 : Convert.ToDecimal(lstData[7]);

            obj.PB = lstData[8] == null ? 0 : Convert.ToDecimal(lstData[8]);
            obj.Beta = lstData[9] == null ? 0 : Convert.ToDecimal(lstData[9]);
            obj.TotalStock = lstData[10] == null ? 0 : Convert.ToDecimal(lstData[10]);
            obj.ForeignStock = lstData[11] == null ? 0 : Convert.ToDecimal(lstData[11]);
            try
            {
                obj.ForeignPercent = lstData[12] == null ? 0 : Convert.ToDecimal(lstData[12]);
            }
            catch (Exception) { }
            obj.Capitalization = lstData[13] == null ? 0 : Convert.ToDecimal(lstData[13]);

            obj.UpdateDate = DateTime.Now.Date;
            if (!exist) db.Stocks.InsertOnSubmit(obj);
            db.SubmitChanges();
        }

        public void StockUpdate(string[] lstData, int id)
        {
            for (int i = 0; i < lstData.Length; i++) lstData[i] = lstData[i].Replace("%", "").Replace(",", "");
            lstData[1] = lstData[1].Replace("\r\n", "").Replace("\t", "").Trim();
            lstData[0] = lstData[0].Substring(0, lstData[0].IndexOf("-") - 1);
            lstData[4] = lstData[4].Replace("triệu", "");
            lstData[5] = lstData[5].Replace(" ngàn", "");
            Stock obj;
            try
            {
                obj = db.Stocks.Where(v => v.Id == id).First();
            }
            catch (Exception) { obj = new Stock(); }

            obj.Stock1 = lstData[0];
            try
            {
                obj.EPS = lstData[1] == null ? 0 : Convert.ToDecimal(lstData[1]);
                obj.PE = lstData[2] == null ? 0 : Convert.ToDecimal(lstData[2]);
                obj.Capitalization = lstData[3] == null ? 0 : Convert.ToDecimal(lstData[3]);
                obj.TotalStock = lstData[4] == null ? 0 : Convert.ToDecimal(lstData[4]) * 1000000;
                obj.BookValue = lstData[5] == null ? 0 : Convert.ToDecimal(lstData[5]) * 1000;
                obj.ROE = lstData[6] == null ? 0 : Convert.ToDecimal(lstData[6]);
                obj.Beta = lstData[7] == null ? 0 : Convert.ToDecimal(lstData[7]);
            }
            catch (Exception) { }
            obj.UpdateDate = DateTime.Now.Date;
            db.SubmitChanges();
        }


        #endregion

        #region News
        public List<New> NewsList()
        {
            return db.News.OrderByDescending(v=>v.PublishDate).ToList();
        }

        public int NewsInsert(string sTitle, string sDetail, int iTypeId, bool bGood, int iBranchId, int iStockId, DateTime publishedDate, string link)
        {
            try
            {
                if (db.News.Where(v => v.Title == sTitle).First().Id > 0) return 0;
            }
            catch (Exception) { }
            New obj = new New();
            obj.Title = sTitle;
            obj.Detail = sDetail;
            obj.PublishDate = DateTime.Now;
            obj.NewsTypeId = iTypeId;
            obj.IsGood = bGood;
            obj.BranchId = iBranchId;
            obj.StockId = iStockId;
            obj.PublishDate = publishedDate;
            obj.Link = link;
            db.News.InsertOnSubmit(obj);
            db.SubmitChanges();
            return obj.Id;
        }

        public void NewsEdit(int iId, string sTitle, string sDetail, int iTypeId, bool bGood, int iBranchId, int iStockId, DateTime dtPublish, string link)
        {
            New obj = db.News.Where(v => v.Id == iId).First();
            obj.Title = sTitle;
            obj.Detail = sDetail;
            obj.PublishDate = DateTime.Now;
            obj.NewsTypeId = iTypeId;
            obj.IsGood = bGood;
            obj.BranchId = iBranchId;
            obj.StockId = iStockId;
            obj.PublishDate = dtPublish;
            obj.Link = link;
            db.SubmitChanges();
        }

        #endregion

        #region Events
        public List<vEvent> EventList(string stockCode)
        {
            return db.vEvents.Where(v => v.Code.StartsWith(stockCode)).OrderByDescending(v => v.NoRightDate).ToList();
        }

        public List<vEvent> EventList(int stockId, int typeId)
        {
            return db.vEvents.Where(v=>(stockId == 0 || v.StockId == stockId) && (typeId == 0 || v.Type == typeId)).OrderByDescending(v => v.NoRightDate).ToList();
        }

        public List<vEvent> EventList()
        {
            return db.vEvents.OrderByDescending(v=>v.NoRightDate).ToList();
        }

        public int EventInsert(string[] data)
        {
//            Mã CK 	Loại Sự Kiện 	Ngày GDKHQ 	Ngày Thực Hiện 	Cổ Tức 	Ghi Chú
//GHA 	Cổ tức bằng tiền 	11/08/2005 	05/09/2005 	3.50% 	350 đồng/cổ phiếu
            //check exist
            int stockId;
            try
            {
                stockId = db.Stocks.Where(v => v.Code == data[0].ToUpper()).First().Id;
            }
            catch (Exception) {
                stockId = StockInsert(data[0].ToUpper());
            }
            
            int type = db.Definitions.Where(v=>v.DefGroupId == 3).Where(v => v.CodeNum == data[1]).First().Id;
            
            DateTime norightDate = DateTime.Now;
            DateTime executeDate = DateTime.Now;

            if (data[2] != "N/A")
                norightDate = DateTime.ParseExact(data[2], "dd/MM/yyyy", CultureInfo.CurrentCulture);

            if (data[3] != "N/A")
                executeDate = DateTime.ParseExact(data[3], "dd/MM/yyyy", CultureInfo.CurrentCulture);

            try
            {
                if ((from t in db.Events
                     where t.StockId == stockId && t.Type == type && t.NoRightDate == norightDate && t.ExecuteDate == executeDate
                     select t).First().Id > 0) return 0;
            }
            catch (Exception) { }

            decimal value = 0;
            switch (type)
            {
                case 1001:
                    value = 100 * Convert.ToDecimal(data[4].Substring(0, data[4].Length - 1));
                    break;
            }

            Event obj = new Event();

            obj.StockId = stockId;
            obj.Type = type;
            //obj.LastRegisterDate = dtLastRegisterDate;
            if (data[2] != "N/A") obj.NoRightDate = norightDate;
            if (data[3] != "N/A") obj.ExecuteDate = executeDate;
            //obj.MethodId = method;
            obj.Value = value;
            obj.Description = data[4] + ";" + data[5];
            db.Events.InsertOnSubmit(obj);
            db.SubmitChanges();
            return obj.Id;
        }


        public void EventInsert(string description, int iTypeId, int iStockId, DateTime dtLastRegisterDate, DateTime dtNoRightDate, DateTime dtExecuteDate, int method, decimal value, bool[] lstExistDate)
        {
            Event obj = new Event();
            obj.Description = description;
            obj.StockId = iStockId;
            obj.Type = iTypeId;
            obj.NoRightDate = lstExistDate[0]? dtNoRightDate: (DateTime?)null;
            obj.LastRegisterDate = lstExistDate[1]? dtLastRegisterDate : (DateTime?)null;
            obj.ExecuteDate = lstExistDate[2]? dtExecuteDate : (DateTime?)null;
            obj.MethodId = method;
            obj.Value = value;
            db.Events.InsertOnSubmit(obj);
            db.SubmitChanges();
        }

        public void EventEdit(int iId, string description, int iTypeId, int iStockId, DateTime dtLastRegisterDate, DateTime dtNoRightDate, DateTime dtExecuteDate, int method, decimal value, bool[] lstExistDate)
        {
            Event obj = db.Events.Where(v => v.Id == iId).First();
            obj.Description = description;
            obj.StockId = iStockId;
            obj.Type = iTypeId;
            obj.NoRightDate = lstExistDate[0] ? dtNoRightDate : (DateTime?)null;
            obj.LastRegisterDate = lstExistDate[1] ? dtLastRegisterDate : (DateTime?)null;
            obj.ExecuteDate = lstExistDate[2] ? dtExecuteDate : (DateTime?)null;
            obj.MethodId = method;
            obj.Value = value;
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

            var lst = db.vPortfolios.OrderBy(v=>v.StockId).ToList();
            int colCount = lst.Count + 1;
            string[] columns = new string[colCount];
            int[] stockIds = new int[colCount-1];
            columns[0] = "Date";
            int i = 0;
            decimal[][] portfolioPrice = new decimal[colCount - 1][];
            foreach(var item in lst)
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
                if(first)
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
                    valueRow[i-1] = row.ClosePrice.Value;
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
            foreach(decimal[] tmp in value)
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


    }
}
