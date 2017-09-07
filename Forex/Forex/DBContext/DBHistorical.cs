using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using WindowFramework;
using System.Data.SqlTypes;
using System.Data.Linq;

namespace Forex.DBContext
{
    class DBHistorical
    {
        HistoricalDBDataContext db = new HistoricalDBDataContext();

        #region General
        public DateTime GetDate()
        {
            return db.ServerDates.First().ServerDate1;
        }
        #endregion

        #region Definition
        public List<Definition> DefinitionList(int group)
        {
            return db.Definitions.Where(v => v.GroupId == group).ToList();
        }

        public DataTable DefinitionCbo(int groupId)
        {
            return (from t in db.Definitions
                    where t.GroupId == groupId
                    select new { t.Id, t.CodeNum }).ToADOTable();
                                       
        }

        public int DefinitionId(string code, int group)
        {
            try
            {
                return db.Definitions.Where(v => v.CodeNum == code).First().Id;
            }
            catch (Exception) {
                Definition item = new Definition();
                item.CodeNum = code;
                item.GroupId = group;
                db.Definitions.InsertOnSubmit(item);
                db.SubmitChanges();
                return item.Id;
            }
            return 0;
        }

        #endregion

        #region SJC
        public List<DateTime> SJCMissing(int days)
        {
            DateTime date = DateTime.Now.Date.AddDays(-days);
            List<DateTime> dates = new List<DateTime>();
            var lst = (from t in db.SJCs
                     where t.PriceDate > date
                     select new { t.PriceDate }).ToList();

            DateTime from = DateTime.Now.Date.AddDays(1);
            for(int i=0;i<days;i++)
            {
                from = from.AddDays(-1).Date;
                try
                {
                    lst.Where(v => v.PriceDate.Value.Date == from).First();
                }
                catch (Exception) { dates.Add(from); }
            }
         
            return dates;
        }
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
                               orderby t.AvgBuy
                               select new { Id = t.WeekDayNum, t.WeekDay, t.AvgBuy, t.AvgSell, t.AvgDifferent }).ToADOTable();

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
            //if (months == 0 && years == 0)
            //{
            //    table = (from t in db.VAvgMonthYearSJCs
            //             orderby t.Year descending, t.AvgBuy ascending,t.Different ascending
            //             select new { t.Id, t.Month, t.Year, t.AvgBuy, t.AvgSell, BuyVariant = t.AvgBuy, SellVariant = t.AvgSell, t.Different }).ToADOTable();
            //}
            //else
            //{
            //    DateTime checkDate = DateTime.Now.AddMonths(-months);
            //    checkDate = checkDate.AddYears(-years);
            //    table = (from t in db.AvgMonthYear(checkDate)
            //             orderby t.Year descending, t.AvgBuy ascending, t.Different ascending
            //             select new { t.Id, t.Month, t.Year, t.AvgBuy, t.AvgSell, BuyVariant = t.AvgBuy, SellVariant = t.AvgSell, t.Different }).ToADOTable();
            //}
            table = (from t in db.AvgMonthYear(DateTime.Now.AddMonths(-months).AddYears(-years))
                     orderby t.Year descending, t.AvgBuy ascending, t.Different ascending
                     select new { t.Id, t.Month, t.Year, t.AvgBuy, t.AvgSell, BuyVariant = t.AvgBuy, SellVariant = t.AvgSell, t.Different }).ToADOTable();
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
            //DataTable table;
            //if (months == 0 && years == 0)
            //{
            //    table = (from t in db.VAvgMonthYearGolds
            //             orderby t.Year descending, t.Month ascending
            //             select t).ToADOTable();
            //}
            //else
            //{
            //    DateTime checkDate = DateTime.Now.AddMonths(-months);
            //    checkDate = checkDate.AddYears(-years);
            //    table = (from t in db.AvgMonthYearGold(checkDate)
            //             orderby t.Year descending, t.Month ascending
            //             select t).ToADOTable();
            //}
            //return table;

            return (from t in db.AvgMonthYearGold(DateTime.Now.AddMonths(-months).AddYears(-years))
                     orderby t.Year descending, t.Month ascending
                     select t).ToADOTable();

        }


        public DataTable SJCMonth(int months, int years)
        {
            DataTable table;
            //if (months == 0 && years == 0)
            //{
            //    table = (from t in db.VAvgMonthSJCs
            //             orderby t.AvgBuy, t.Different
            //             select new { t.Id, t.Month, t.AvgBuy, t.AvgSell, BuyVariant = t.AvgBuy, SellVariant = t.AvgSell, t.Different }).ToADOTable();
            //}
            //else
            //{
            //    DateTime checkDate = DateTime.Now.AddMonths(-months);
            //    checkDate = checkDate.AddYears(-years);
            //    table = (from t in db.AvgMonth(checkDate)
            //             orderby t.AvgBuy, t.Different
            //             select new { t.Id, t.Month, t.AvgBuy, t.AvgSell, BuyVariant = t.AvgBuy, SellVariant = t.AvgSell, t.Different }).ToADOTable();
            //}

            table = (from t in db.AvgMonth(DateTime.Now.AddMonths(-months).AddYears(-years))
                     orderby t.AvgBuy, t.Different
                     select new { t.Id, t.Month, t.AvgBuy, t.AvgSell, BuyVariant = t.AvgBuy, SellVariant = t.AvgSell, t.Different }).ToADOTable();


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
            //DataTable table;
            //if (months == 0 && years == 0)
            //{
            //    table = (from t in db.VAvgMonthGolds
            //             orderby t.Month
            //             select t).ToADOTable();
            //}
            //else
            //{
            //    DateTime checkDate = DateTime.Now.AddMonths(-months);
            //    checkDate = checkDate.AddYears(-years);
            //    table = (from t in db.AvgMonthGold(checkDate)
            //             orderby t.Month
            //             select t).ToADOTable();
            //}
            //return table;
            return (from t in db.AvgMonthGold(DateTime.Now.AddMonths(-months).AddYears(-years))
                     orderby t.Month
                     select t).ToADOTable();

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

            if (priceDate == null) priceDate = DateTime.Now;

            obj.PriceDate = priceDate;
            obj.Buy = buy;
            obj.Sell = sell;
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
                itemId = DefinitionId(item, 4);

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

            if (priceDate == null) priceDate = DateTime.Now;

            SJCDetail obj = new SJCDetail();
            obj.PriceDate = priceDate;
            obj.Buy = buy;
            obj.Sell = sell;
            obj.CityId = cityId;
            obj.ItemId = itemId;
            db.SJCDetails.InsertOnSubmit(obj);
            db.SubmitChanges();
        }
        #endregion

        #region Forex
        public void ForexAdd(decimal buy, decimal transfer, decimal sell, string type, DateTime date)
        {

            DateTime priceDate;
            if (date == null)
                priceDate = DateTime.Now.Date;
            else
                priceDate = Convert.ToDateTime(date);
            int itemId = DefinitionId(type, 1);
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
            Console.WriteLine(obj.PriceDate.ToString());
            db.SubmitChanges();
        }
        #endregion    

        #region Rate
        public DataTable DateRateList(int forexTypeId)
        {
            return (from t in db.VAvgDateRates
                    where forexTypeId == 0 || t.ForexTypeId == forexTypeId
                    select t).ToADOTable();
        }

        public int RateAdd(DateTime priceDate)
        {
            try
            {
                Rate rate = new Rate();
                rate.PriceDate = priceDate;
                db.Rates.InsertOnSubmit(rate);
                db.SubmitChanges();
                return rate.Id;
            }
            catch (Exception) { }
            return 0;
        }

        #region RateDetail
        public int RateDetailAdd(decimal ask, decimal bid, int forexType, int rateId)
        {
            RateDetail detail = new RateDetail();
            detail.Ask = ask;
            detail.Bid = bid;
            detail.ForexTypeId = forexType;
            detail.RateId = rateId;
            db.RateDetails.InsertOnSubmit(detail);
            db.SubmitChanges();
            return detail.Id;
        }
        #endregion

        #endregion

        #region Trend
        public DataTable GoldTrend(DateTime dFrom, DateTime dTo)
        {
            try
            {
                return (from t in db.vSJC_Trends
                        where t.PriceDate >= dFrom && t.PriceDate <= dTo
                        select new { t.Id, t.PriceDate, t.Buy, t.Sell, t.BuySell, t.Trend }).ToADOTable();
            }
            catch (Exception) { }
            return null;
        }
        #endregion

        #region Rule
        public DataTable RuleList()
        {
            return db.VRules.ToADOTable();
        }

        public DataTable RuleCbo()
        {
            return (from t in db.Rules
                    select new { t.Id, t.Rules }).ToADOTable();
        }

        public Rule RuleRecord(int id)
        {
            return (from t in db.Rules
                    where t.Id == id
                        select t).First();
        }

        public void RuleAdd(string rule, decimal rate, int type, int used, string comment)
        {
            Rule obj = new Rule();
            obj.Rules = rule;
            obj.Rate = rate;
            obj.TypeId = type;
            obj.UsedId = used;
            obj.Comment = comment;
            db.Rules.InsertOnSubmit(obj);
            db.SubmitChanges();
        }

        public void RuleEdit(int id, string rule, decimal rate, int type, int used, string comment)
        {
            Rule obj = db.Rules.Where(v=>v.Id == id).First();
            obj.Rules = rule;
            obj.Rate = rate;
            obj.TypeId = type;
            obj.UsedId = used;
            obj.Comment = comment;
            db.SubmitChanges();
        }

        public void RuleDelete(int[] arrAll)
        {
            int[] arrId = arrAll.Where(v => v > 0).ToArray();
            foreach (int id in arrId)
            {
                try
                {
                    int exist = db.News.Where(v => v.RuleId == id).First().Id;
                }
                catch (Exception) {
                    Rule obj = db.Rules.Where(v => v.Id == id).First();
                    db.Rules.DeleteOnSubmit(obj);
                }
            }
        }

        #endregion

        #region News
        public DataTable NewsList()
        {
            return db.VNews.ToADOTable();
        }

        public New NewsRecord(int id)
        {
            return (from t in db.News
                    where t.Id == id
                    select t).First();
        }

        public void NewsAdd(string url, decimal rate, int type, int used, int ruleId, string comment, int effectDateCount, int effectMoney, DateTime publishDate)
        {
            New obj = new New();
            obj.Url = url;
            obj.Rate = rate;
            obj.TypeId = type;
            obj.UsedId = used;
            obj.RuleId = ruleId;
            obj.Comment = comment;
            obj.EffectDateCount = effectDateCount;
            obj.EffectMoney = effectMoney;
            obj.PublishDate = publishDate;
            db.News.InsertOnSubmit(obj);
            db.SubmitChanges();
        }

        public void NewsEdit(int id, string url, decimal rate, int type, int used, int ruleId, string comment, int effectDateCount, int effectMoney, DateTime publishDate)
        {
            New obj = db.News.Where(v => v.Id == id).First();
            obj.Url = url;
            obj.Rate = rate;
            obj.TypeId = type;
            obj.UsedId = used;
            obj.RuleId = ruleId;
            obj.Comment = comment;
            obj.EffectDateCount = effectDateCount;
            obj.EffectMoney = effectMoney;
            obj.PublishDate = publishDate;
            db.SubmitChanges();
        }

        public void NewsDelete(int[] arrAll)
        {
            int[] arrId = arrAll.Where(v => v > 0).ToArray();
            List<New> lst = (from t in db.News
                             where arrId.Contains(t.Id)
                             select t).ToList();
            db.News.DeleteAllOnSubmit(lst);
        }

        #endregion

        #region Kitco-London Fix
        public void LondonAdd(DateTime date, decimal goldAM, decimal goldPM, decimal silver, decimal platinumAM,
            decimal platinumPM, decimal palladiumAM, decimal palladiumPM)
        {
            try
            {
                int exist = (from t in db.LondonFixes
                             where t.PriceDate == date
                             select t).First().Id;
                if (exist > 0) return;
            }
            catch (Exception) { }
            LondonFix obj = new LondonFix();
            obj.PriceDate = date;
            obj.GoldAM = goldAM;
            obj.GoldPM = goldPM;
            obj.Silver = silver;
            obj.PlatinumAM = platinumAM;
            obj.PlatinumPM = platinumPM;
            obj.PalladiumAM = palladiumAM;
            obj.PalladiumPM = palladiumPM;
            db.LondonFixes.InsertOnSubmit(obj);
            db.SubmitChanges();
        }
        #endregion

        #region Compare Gold Price
        public DataTable CompareGoldVN_World(int month)
        {
            return (from t in db.CompareGoldPrices
                    where t.PriceDate >= DateTime.Now.Date.AddMonths(-month)
                    select t).ToADOTable();
        }
        #endregion
    }
}
