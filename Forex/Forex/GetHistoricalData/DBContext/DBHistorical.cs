using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowFramework;

namespace GetHistoricalData.DBContext
{
    class DBHistorical
    {
        HistoricalDBDataContext db = new HistoricalDBDataContext();

        #region Definition
        public int DefinitionId(string code)
        {
            return db.Definitions.Where(v => v.CodeNum == code).First().Id;
        }
        #endregion

        #region SJC
        public DataTable SJCWeekDay(int months, int years)
        {
            DateTime checkDate = DateTime.Now;
            if (months == 0 && years == 0)
            {
                checkDate = checkDate.AddMonths(-1);
            }
            else
            {
                checkDate = checkDate.AddMonths(-months);
                checkDate = checkDate.AddYears(-years);
            }

            DataTable table = (from t in db.AvgWeekDay(checkDate)
                               orderby t.WeekDayNum
                               select new { Id = t.WeekDayNum, t.WeekDay, t.AvgBuy, t.AvgSell }).ToADOTable();

                //db.AvgWeekDay(checkDate).OrderBy(v=>v.WeekDay).ToADOTable();
            //int count = table.Rows.Count;
            //for (int i = 0; i < count; i++)
            //{
            //    table.Rows[i][0] = i + 1;
            //}

            return table;
        }

        public DataTable GoldWeekDay(int months, int years)
        {
            DateTime checkDate = DateTime.Now;
            if (months == 0 && years == 0)
            {
                checkDate = checkDate.AddMonths(-1);
            }
            else
            {
                checkDate = checkDate.AddMonths(-months);
                checkDate = checkDate.AddYears(-years);
            }

            DataTable table = (from t in db.AvgWeekDayGold(checkDate)
                               orderby t.WeekDayNum
                               select t).ToADOTable();
            return table;
        }


        public DataTable SJCList(int days)
        {
            DateTime checkDate = DateTime.Now.AddDays(-days);
            return (from t in db.SJCs
                    where t.PriceDate >= checkDate
                    orderby t.PriceDate descending
                    select t).ToADOTable();
        }

        public DataTable GoldList(int days)
        {
            DateTime checkDate = DateTime.Now.AddDays(-days);
            return (from t in db.Golds
                    where t.PriceDate >= checkDate
                    orderby t.PriceDate descending
                    select t).ToADOTable();
        }

        public DataTable SJCMonthYear(int months, int years)
        {
            DataTable table;
            if (months == 0 && years == 0)
            {
                table = (from t in db.VAvgMonthYearSJCs
                         orderby t.Year descending, t.Month ascending
                         select new { t.Id, t.Month, t.Year, t.AvgBuy, t.AvgSell, BuyVariant = t.AvgBuy, SellVariant = t.AvgSell }).ToADOTable();
            }
            else
            {
                DateTime checkDate = DateTime.Now.AddMonths(-months);
                checkDate = checkDate.AddYears(-years);
                table = (from t in db.AvgMonthYear(checkDate)
                         orderby t.Year descending, t.Month ascending
                         select new { t.Id, t.Month, t.Year, t.AvgBuy, t.AvgSell, BuyVariant = t.AvgBuy, SellVariant = t.AvgSell }).ToADOTable();
            }

            int count = table.Rows.Count;
            for(int i = 0; i< count; i++)
            {
                //table.Rows[i][0] = i+1;
                if (i < count - 1)
                {
                    table.Rows[i][5] = (decimal)table.Rows[i][5] - (decimal)table.Rows[i + 1][5];
                    table.Rows[i][6] = (decimal)table.Rows[i][6] - (decimal)table.Rows[i + 1][6];
                }
            }
            return table;
        }

        public DataTable GoldMonthYear(int months, int years)
        {
            DataTable table;
            if (months == 0 && years == 0)
            {
                table = (from t in db.VAvgMonthYearGolds
                         orderby t.Year descending, t.Month ascending
                         select t).ToADOTable();
            }
            else
            {
                DateTime checkDate = DateTime.Now.AddMonths(-months);
                checkDate = checkDate.AddYears(-years);
                table = (from t in db.AvgMonthYearGold(checkDate)
                         orderby t.Year descending, t.Month ascending
                         select t).ToADOTable();
            }
            return table;
        }


        public DataTable SJCMonth(int months, int years)
        {
            DataTable table;
            if (months == 0 && years == 0)
            {
                table = (from t in db.VAvgMonthSJCs
                         orderby t.Month
                         select new { t.Id, t.Month, t.AvgBuy, t.AvgSell, BuyVariant = t.AvgBuy, SellVariant = t.AvgSell }).ToADOTable();
            }
            else
            {
                DateTime checkDate = DateTime.Now.AddMonths(-months);
                checkDate = checkDate.AddYears(-years);
                table = (from t in db.AvgMonth(checkDate)
                         orderby t.Month
                         select new { t.Id, t.Month, t.AvgBuy, t.AvgSell, BuyVariant = t.AvgBuy, SellVariant = t.AvgSell }).ToADOTable();
            }

            int count = table.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                //table.Rows[i][0] = i + 1;
                if (i < count - 1)
                {
                    table.Rows[i][4] = (decimal)table.Rows[i][4] - (decimal)table.Rows[i + 1][4];
                    table.Rows[i][5] = (decimal)table.Rows[i][5] - (decimal)table.Rows[i + 1][5];
                }
            }

            return table;
        }

        public DataTable GoldMonth(int months, int years)
        {
            DataTable table;
            if (months == 0 && years == 0)
            {
                table = (from t in db.VAvgMonthGolds
                         orderby t.Month
                         select t).ToADOTable();
            }
            else
            {
                DateTime checkDate = DateTime.Now.AddMonths(-months);
                checkDate = checkDate.AddYears(-years);
                table = (from t in db.AvgMonthGold(checkDate)
                         orderby t.Month
                         select t).ToADOTable();
            }
            return table;
        }


        public void SJCAdd(DateTime priceDate, decimal buy, decimal sell)
        {
            //check Exist
            try
            {
                if (db.SJCs.Where(v => v.PriceDate == priceDate).First().Id > 0)
                    return;
            }
            catch (Exception) { }

            SJC obj = new SJC();
            obj.PriceDate = priceDate;
            obj.Buy = buy*100000;
            obj.Sell = sell*100000;
            db.SJCs.InsertOnSubmit(obj);
            db.SubmitChanges();
        }
        #endregion

        #region SJCDetail
        public void SJCDetailAdd(DateTime priceDate, decimal buy, decimal sell, string city, string item)
        {
            //int cityId = DefinitionId(city);
            
            int itemId = 0;
            if (item == "Vàng SJC")
                itemId = 1101;
            else
                itemId = DefinitionId(item);

            int cityId = 0;
            switch (city)
            {
                case "Hồ Chí Minh":
                    cityId = 1002;
                    break;
                case "Hà Nội":
                    cityId = 1001;
                    break;
                case "Đà  Nẵng":
                    cityId = 1004;
                    break;
                case "Nha Trang":
                    cityId = 1032; //Khánh Hòa
                    break;
                case "Cà Mau":
                    cityId = 1018;
                    break;
                case "Buôn Ma Thuột": //Đăk Lăk
                    cityId = 1019;
                    break;
                case "Bình Phước":
                    cityId = 1015;
                    break;
            }

            //check Exist
            try
            {
                if (db.SJCDetails.Where(v => v.PriceDate == priceDate && v.CityId == cityId && v.ItemId == itemId).First().Id > 0)
                    return;
            }
            catch (Exception) { }


            SJCDetail obj = new SJCDetail();
            obj.PriceDate = priceDate;
            obj.Buy = buy*100000;
            obj.Sell = sell*100000;
            obj.CityId = cityId;
            obj.ItemId = itemId;
            db.SJCDetails.InsertOnSubmit(obj);
            db.SubmitChanges();
        }
        #endregion

        #region Forex
        public void ForexAdd(decimal buy, decimal transfer, decimal sell, string type)
        {
            DateTime priceDate = DateTime.Now.Date;
            int itemId = DefinitionId(type);
            //check Exist
            try
            {
                if (db.Forexes.Where(v => v.PriceDate == priceDate && v.ItemId == itemId).First().Id > 0)
                    return;
            }
            catch (Exception) { }

            switch (type)
            {
                case "USD":
                    USD usd = new USD();
                    usd.PriceDate = priceDate;
                    usd.Buy = buy;
                    usd.Transfer = transfer;
                    usd.Sell = sell;
                    db.USDs.InsertOnSubmit(usd);
                    break;
                case "EUR":
                    EUR eur = new EUR();
                    eur.PriceDate = priceDate;
                    eur.Buy = buy;
                    eur.Transfer = transfer;
                    eur.Sell = sell;
                    db.EURs.InsertOnSubmit(eur);
                    break;
            }

            Forex obj = new Forex();
            obj.PriceDate = priceDate;
            obj.Buy = buy;
            obj.Transfer = transfer;
            obj.Sell = sell;
            obj.ItemId = itemId;
            db.Forexes.InsertOnSubmit(obj);
            db.SubmitChanges();
        }
        #endregion    
    }
}
