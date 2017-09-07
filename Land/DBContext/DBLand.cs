using Land.DBContext;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowFramework;

namespace Land.DBContext
{
    class DBLand
    {
        DBLandDataContext db = new DBLandDataContext();
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
        public int DefinitionExist(string name, int groupId, int num1)
        {
            if (name.Length == 0) return 0;
            try
            {
                return db.Definitions.Where(v => v.GroupId == groupId).Where(v => v.Name == name).First().Id;
            }
            catch (Exception) { }
            Definition obj = new Definition();
            obj.Name = name;
            obj.GroupId = groupId;
            if (num1 > 0) obj.Num1 = num1;
            db.Definitions.InsertOnSubmit(obj);
            db.SubmitChanges();
            return obj.Id;
        }

        public List<vDefinition> DefinitionList(int iGroupId)
        {
            List<vDefinition> lst = (from t in db.vDefinitions
                    where t.GroupId == iGroupId
                    select t).ToList();
            vDefinition item = new vDefinition();
            item.Code = "Select Item";
            item.Name = "Select Item";
            item.Id = 0;
            lst.Insert(0, item);
            return lst;
        }

        //public DataTable DefinitionListForCbo(int iGroupId)
        //{
        //    DataTable table = (from t in db.vDefinitions
        //                             where t.GroupId == iGroupId
        //                             select new { t.Id, t.Name }).ToADOTable();
        //    DataRow row = table.NewRow();
        //    row["Id"] = 0;
        //    row["Name"] = "Select Item";
        //    table.Rows.Add(row);
        //    return table;
        //}
        public List<vDefinition> UrlDefinitionList(int iGroupId)
        {
            return (from t in db.vDefinitions
                                     where t.GroupId == iGroupId
                                     select t).ToList();
        }

        public List<Definition> DefinitionList(int iGroupId, int num1)
        {
            return (from t in db.Definitions
                    where t.GroupId == iGroupId && t.Num1 == num1
                    select t).ToList();
        }

        public int DefinitionAdd(int groupId, string code, string name)
        {
            try
            {
                return db.Definitions.Where(v => v.GroupId == groupId).Where(v => v.Name.ToLower() == name).First().Id;
            }
            catch (Exception) { }
            //Get last ID
            int iLastId = db.Definitions.Where(v => v.GroupId == groupId).OrderByDescending(v => v.Id).First().Id;

            Definition obj = new Definition();
            obj.Id = iLastId + 1;
            obj.GroupId = groupId;
            obj.Code = code;
            obj.Name = name;
            db.Definitions.InsertOnSubmit(obj);
            db.SubmitChanges();
            return obj.Id;
        }

        public void DefinitionEdit(int id, string code, string name)
        {
            Definition obj = db.Definitions.Where(v => v.Id == id).First();
            obj.Code = code;
            obj.Name = name;
            db.SubmitChanges();
        }

        public void DefinitionDelete(int id)
        {
            Definition obj = db.Definitions.Where(v => v.Id == id).First();
            db.Definitions.DeleteOnSubmit(obj);
            db.SubmitChanges();
        }
        #endregion

        #region Land
        public void LandUpdateArea()
        {
            List<Land> lst = db.Lands.Where(v => (v.Area == null || v.Area == 0) && v.Comment != null).ToList();
            string tmp, tmp1, tmp2;
            int i;
            foreach(Land item in lst)
            {
                tmp = item.Comment;
                i = tmp.IndexOf('x');
                if (i == -1) continue;

                try
                {
                    tmp1 = tmp.Substring(i - 3, 3).Replace(" ", "").Replace("m", "");
                    tmp2 = tmp.Substring(i + 1, 3).Replace(" ", "").Replace("m", "");
                    tmp = "";
                    for (int j = 0; j < tmp1.Length; j++)
                    {
                        if (tmp1[j] >= '0' && tmp1[j] <= '9')
                            tmp += tmp1[j];
                    }
                    item.Wide = Convert.ToDecimal(tmp);
                    tmp = "";

                    for (int j = 0; j < tmp2.Length; j++)
                    {
                        if (tmp2[j] >= '0' && tmp2[j] <= '9')
                            tmp += tmp2[j];
                    }
                    item.Length = Convert.ToDecimal(tmp);
                    item.Area = item.Wide * item.Length;
                    item.PricePerMet = item.Price / item.Area;
                    db.SubmitChanges();
                }
                catch (Exception) { }
            }
        }
        public DateTime LastUpdateDate()
        {
            return db.Lands.OrderByDescending(v => v.CreatedDate).First().CreatedDate.Value;
        }
        public List<VLand> LandList()
        {
            return db.VLands.Take(50).OrderByDescending(v=>v.Id).ToList();
        }

        public List<VLand> LandSearch(int districtId)
        {
            return db.VLands.Where(v=>v.DistrictId==districtId).Take(50).OrderByDescending(v => v.Id).ToList();
        }


        public List<VLand> LandList(bool isArea)
        {
            return isArea? db.VLands.Where(v=>v.Area != null).Take(50).OrderByDescending(v => v.Id).ToList():db.VLands.Where(v=>v.Area == null).Take(50).OrderByDescending(v => v.Id).ToList();
        }

        public VLand Land(int id)
        {
            return db.VLands.Where(v=>v.Id == id).First();
        }

        public List<VLand> LandList(int fromId)
        {
            return db.VLands.Where(v=>v.Id >= fromId).ToList();
        }

        public List<int> LandIdList(int fromId)
        {
            return db.VLands.Where(v => v.Id >= fromId).Select(v=>v.Id).ToList();
        }

        public bool LandIsUpdated(int id)
        {
            try
            {
                return db.Lands.Where(v => v.Id == id).First().IsDetail.Value;
            }
            catch (Exception e) { return false; }
        }


        //get lands without detail
        public List<Land> LandNewList(out List<int> lst)
        {
            lst = db.Lands.Where(v => v.IsDetail == false).Select(v=>v.Id).ToList();
            return db.Lands.Where(v => v.IsDetail == false).ToList();
        }

        public void LandInsert(string title, string address, int streetId, int districtId, int wardId, decimal alleyWide, 
            string contact, string phone, bool isAgent, bool isDue, string comment, decimal area,
            decimal wide, decimal length, int directionId, bool isHouse, int houseLevel, int bedRoom, int restRoom,
            int floor, decimal price, decimal agentPrice, decimal expectedPrice, string url, decimal tax, bool isMezzanine, bool isSale, decimal pricePerMet)
        {
            Land obj = new Land();
            obj.Title = title;
            obj.Address = address;
            obj.StreetId = streetId;
            obj.WardId = wardId;
            obj.AlleyWide = alleyWide;
            obj.Contact = contact;
            obj.Phone = phone;
            obj.IsAgent = isAgent;
            obj.IsDue = isDue;
            obj.Comment = comment;
            obj.Area = area;
            obj.Wide = wide;
            obj.Length = length;
            obj.DirectionId = directionId;
            obj.IsHouse = isHouse;
            obj.HouseLevel = houseLevel;
            obj.Bedroom = bedRoom;
            obj.Restroom = restRoom;
            obj.Floor = floor;
            obj.Price = price / 1000000;
            obj.AgentPrice = agentPrice / 1000000;
            obj.ExpectedPrice = expectedPrice / 1000000;
            obj.Url = url;
            obj.Tax = tax;
            obj.IsMezzanine = isMezzanine;
            obj.CreatedDate = DateTime.Now;
            obj.IsSale = isSale;
            obj.PricePerMet = pricePerMet;

            db.Lands.InsertOnSubmit(obj);
            db.SubmitChanges();
        }


        public void LandInsert(string[] data)
        {
            if (data[0].Length == 0) return;
            try
            {
                int id;
                if ((id = (from t in db.Lands
                     where t.Title == data[0]
                     select t).First().Id) > 0) return;
            }
            catch (Exception) { }
            Land obj = new Land();

            obj.Title = data[0];
            //obj.Address = data[1];
            //obj.StreetId = data[2];
            //obj.WardId = DefinitionExist(data[3], ;
            //obj.AlleyWide = data[4];
            //obj.Contact = data[5];
            //obj.Phone = data[6];
            obj.IsAgent = Convert.ToBoolean(data[7]);
            //obj.IsDue = data[8];
            //obj.Comment = data[9];
            //obj.Area = data[10];
            //obj.Wide = data[11];
            //obj.Length = data[12];
            //obj.DirectionId = data[13];
            //obj.IsHouse = data[14];
            //obj.HouseLevel = data[15];
            //obj.Bedroom = data[16];
            //obj.Restroom = data[17];
            //obj.Floor = data[18];
            try
            {
                obj.Price = Convert.ToDecimal(data[19])/1000000;
            }
            catch (Exception) { }
            //obj.AgentPrice = data[20];
            //obj.ExpectedPrice = data[21];
            obj.Url = data[22];
            //obj.Tax = data[23];
            //obj.IsMezzanine = data[24];
            obj.CreatedDate = Convert.ToDateTime(data[25]);
            obj.DistrictId = DefinitionExist(data[26], 5, 0);
            //obj.IsSale = Convert.ToBoolean(data[27]);

            obj.IsDetail = false;

            db.Lands.InsertOnSubmit(obj);
            db.SubmitChanges();
        }

        public void LandEdit(int id, string[] data)
        {
            Land obj = db.Lands.Where(v => v.Id == id).First();

            //if (obj.Bedroom != null) return;

            //obj.Title = data[0];
            obj.Address = data[1];
            //obj.StreetId = data[2];
            //obj.WardId = DefinitionExist(data[3], ;
            //obj.AlleyWide = data[4];
            //obj.Contact = data[5];
            //obj.Phone = data[6];
            //obj.IsAgent = Convert.ToBoolean(data[7]);
            //obj.IsDue = data[8];
            obj.Comment = data[9];
            try
            {
                obj.Area = Convert.ToDecimal(data[10]);
            }
            catch (Exception) { }
            //obj.Wide = data[11];
            //obj.Length = data[12];
            //obj.DirectionId = data[13];
            obj.IsHouse = Convert.ToBoolean(data[14]);
            //obj.HouseLevel = data[15];
            try
            {
                obj.Bedroom = Convert.ToInt32(data[16]);
            }
            catch (Exception) { }
            //obj.Restroom = data[17];
            //obj.Floor = data[18];
            //try
            //{
            //    obj.Price = Convert.ToDecimal(data[19]);
            //}
            //catch (Exception) { }
            //obj.AgentPrice = data[20];
            //obj.ExpectedPrice = data[21];
            //obj.Url = data[22];
            //obj.Tax = data[23];
            //obj.IsMezzanine = data[24];
            //obj.CreatedDate = Convert.ToDateTime(data[25]);
            //obj.DistrictId = DefinitionExist(data[26], 5, 0);
            obj.IsSale = Convert.ToBoolean(data[27]);
            obj.IsDetail = true;

            db.SubmitChanges();
        }

        public void LandIsDetail(int id, bool value)
        {
            Land obj = db.Lands.Where(v => v.Id == id).First();
            obj.IsDetail = value;
            db.SubmitChanges();
        }


        public void LandEdit(int id, string title, string address, int streetId, int districtId, int wardId, decimal alleyWide,
            string contact, string phone, bool isAgent, bool isDue, string comment, decimal area,
            decimal wide, decimal length, int directionId, bool isHouse, int houseLevel, int bedRoom, int restRoom,
            int floor, decimal price, decimal agentPrice, decimal expectedPrice, string url, decimal tax, bool isMezzanine, bool isSale, decimal pricePerMet)
        {
            Land obj = db.Lands.Where(v => v.Id == id).First();
            obj.Title = title;
            obj.Address = address;
            obj.StreetId = streetId;
            obj.WardId = wardId;
            obj.AlleyWide = alleyWide;
            obj.Contact = contact;
            obj.Phone = phone;
            obj.IsAgent = isAgent;
            obj.IsDue = isDue;
            obj.Comment = comment;
            obj.Area = area;
            obj.Wide = wide;
            obj.Length = length;
            obj.DirectionId = directionId;
            obj.IsHouse = isHouse;
            obj.HouseLevel = houseLevel;
            obj.Bedroom = bedRoom;
            obj.Restroom = restRoom;
            obj.Floor = floor;
            obj.Price = price;
            obj.AgentPrice = agentPrice;
            obj.ExpectedPrice = expectedPrice;
            obj.Url = url;
            obj.Tax = tax;
            obj.IsMezzanine = isMezzanine;
            obj.IsSale = isSale;
            obj.PricePerMet = pricePerMet;

            db.SubmitChanges();
        }

        public void LandDelete(int id)
        {
            Land obj = db.Lands.Where(v => v.Id == id).First();
            db.Lands.DeleteOnSubmit(obj);
            db.SubmitChanges();
        }


        #endregion

        #region Street

        public List<Street> StreetList(int districtId)
        {
            List<Street> lst = db.Streets.Where(v=>districtId == 0 || v.DistrictId == districtId).ToList();
            Street item = new Street();
            item.Id = 0;
            item.Name = "Select Street";
            lst.Insert(0, item);
            return lst;
        }

        #endregion
    }
}
