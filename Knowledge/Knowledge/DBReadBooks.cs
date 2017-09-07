using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Knowledge.DBContext
{
    class DBKnowledge
    {
        DBKnowledgeDataContext db = new DBKnowledgeDataContext();

        #region DefinitionGroup
        public List<DefinitionGroup> GroupList(string select)
        {
            List<DefinitionGroup> lst = db.DefinitionGroups.ToList();
            lst.Insert(0, new DefinitionGroup() { DefGroup = select, Id = 0 });
            return lst;
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
        public List<Definition> ItemTypeList(int typeId)
        {
            int groupId = db.Definitions.Where(v => v.Id == typeId).First().Num1.Value;
            return db.Definitions.Where(v => v.GroupId == groupId).ToList();
        }

        public int DefinitionId(int groupId, string code)
        {
            try
            {
                return (from t in db.Definitions
                        where (groupId == 0 || t.GroupId == groupId) && t.Code == code
                        select t).First().Id;
            }
            catch (Exception) { return 0; }
        }

        public Definition DefinitionById(int id)
        {
            return db.Definitions.Where(v => v.Id == id).First();
        }


        public List<Definition> DefinitionList(int groupId)
        {
            return db.Definitions.Where(v =>groupId == 0 || v.GroupId == groupId).ToList();
        }

        public List<Definition> DefinitionList(int groupId, string select)
        {
            List<Definition> lst = db.Definitions.Where(v => v.GroupId == groupId).ToList();
            lst.Insert(0, new Definition() { Code = select, Id = 0, GroupId = groupId });
            return lst;
        }


        public int DefinitionInsert(int iGroupId, string code)
        {
            if (code == null) return 0;
            code = code.ToUpper();
            //check exist
            try
            {
                return db.Definitions.Where(v => v.Code == code).First().Id;
            }
            catch (Exception) { }

            //Get last ID
            int iLastId = db.Definitions.Where(v => v.GroupId == iGroupId).OrderByDescending(v => v.Id).First().Id;

            Definition obj = new Definition();
            obj.Id = iLastId + 1;
            obj.GroupId = iGroupId;
            obj.Code = code.ToUpper();
            obj.Name = code;
            db.Definitions.InsertOnSubmit(obj);
            db.SubmitChanges();
            return obj.Id;
        }

        public void DefinitionInsert(int iGroupId, string code, string name)
        {
            //Get last ID
            int iLastId = db.Definitions.Where(v => v.GroupId == iGroupId).OrderByDescending(v => v.Id).First().Id;

            Definition obj = new Definition();
            obj.Id = iLastId + 1;
            obj.GroupId = iGroupId;
            obj.Code = code;
            obj.Name = name;
            db.Definitions.InsertOnSubmit(obj);
            db.SubmitChanges();
        }

        public void DefinitionEdit(int iId, string code, string name)
        {
            Definition obj = db.Definitions.Where(v => v.Id == iId).First();
            obj.Code = code;
            obj.Name = name;
            db.SubmitChanges();
        }

        public void DefinitionInsert(int groupId, string code, string name, string description, int num1, int num2)
        {
            //Get last ID
            int iLastId = db.Definitions.Where(v => v.GroupId == groupId).OrderByDescending(v => v.Id).First().Id;

            Definition obj = new Definition();
            obj.Id = iLastId + 1;
            obj.GroupId = groupId;
            obj.Code = code;
            obj.Name = name;
            obj.Description = description;
            obj.Num1 = num1;
            obj.Num2 = num2;

            db.Definitions.InsertOnSubmit(obj);
            db.SubmitChanges();
        }

        public void DefinitionEdit(int iId, string code, string name, string description, int num1, int num2, int groupId)
        {
            Definition obj = db.Definitions.Where(v => v.Id == iId).First();
            obj.GroupId = groupId;
            obj.Code = code;
            obj.Name = name;
            obj.Description = description;
            obj.Num1 = num1;
            obj.Num2 = num2;
            db.SubmitChanges();
        }


        public void DefinitionDelete(int iId)
        {
            Definition obj = db.Definitions.Where(v => v.Id == iId).First();
            db.Definitions.DeleteOnSubmit(obj);
            db.SubmitChanges();
        }
        #endregion

        #region Ebooks
        public List<vEbook> EbookList()
        {
            return db.vEbooks.OrderByDescending(t => t.Id).ToList();
        }

        public List<vEbook> EbookList(int typeId)
        {
            return db.vEbooks.Where(v=>v.TypeId == typeId).OrderByDescending(t=>t.Id).ToList();
        }

        public List<vEbook> EbookList(string name, int typeId, int formatId)
        {
            return (from t in db.vEbooks
                    where (name.Length == 0 || t.Name.Contains(name)) && (typeId == 0 || t.TypeId == typeId)
                    && (formatId == 0 || t.FormatId == formatId)
                    select t).ToList();
        }


        public bool EbookExist(string name)
        {
            try
            {
                return db.Ebooks.Where(v => v.Name == name).First() != null ? true : false;
            }
            catch (Exception) { return false; }
            
        }

        public void EbookUpdateType(string name, int typeId)
        {
            try
            {
                Ebook obj = db.Ebooks.Where(v => v.Name == name).First();
                if (obj.TypeId == 0)
                {
                    obj.TypeId = typeId;
                    db.SubmitChanges();
                }
            }
            catch (Exception) { }
        }

        public void EbookInsert(string name, int authorId, string description, int publisherId, string isbn,
            int year, int pages, int languageId, decimal size, int formatId, string path, int typeId, string url, string urlDownload)
        {
            Ebook obj;
            bool insert = true;
            try
            {
                obj = db.Ebooks.Where(v=>v.Name == name).First();
                insert = false;
            }
            catch (Exception) { obj = new Ebook(); insert = true; }

            obj.Name = name;
            obj.AuthorId = authorId;
            obj.Description = description;
            obj.PublisherId = publisherId;
            obj.ISBN = isbn;
            obj.Year = year;
            obj.Pages = pages;
            obj.LanguageId = languageId;
            obj.Size = size;
            obj.FormatId = formatId;
            obj.Path = path;
            obj.TypeId = typeId;
            obj.Url = url;
            obj.UrlDownload = urlDownload;
            if (insert) db.Ebooks.InsertOnSubmit(obj);
            db.SubmitChanges();
        }

        public void EbookInsert(Ebook sourceObj)
        {
            Ebook obj;
            bool insert = true;
            try
            {
                obj = db.Ebooks.Where(v => v.Name == sourceObj.Name).First();
                insert = false;
            }
            catch (Exception) { obj = new Ebook(); insert = true; }

            obj.Name = sourceObj.Name;
            obj.AuthorId = sourceObj.AuthorId;
            obj.Description = sourceObj.Description;
            obj.PublisherId = sourceObj.PublisherId;
            obj.ISBN = sourceObj.ISBN;
            obj.Year = sourceObj.Year;
            obj.Pages = sourceObj.Pages;
            obj.LanguageId = sourceObj.LanguageId;
            obj.Size = sourceObj.Size;
            obj.FormatId = sourceObj.FormatId;
            obj.Path = sourceObj.Path;
            obj.TypeId = sourceObj.TypeId;
            obj.Url = sourceObj.Url;
            obj.UrlDownload = sourceObj.UrlDownload;
            if (insert) db.Ebooks.InsertOnSubmit(obj);
            db.SubmitChanges();
        }

        public void EbookInsert(string[] sourceObj)
        {
            Ebook obj;
            bool insert = true;
            try
            {
                obj = db.Ebooks.Where(v => v.Name == sourceObj[2]).First();
                insert = false;
            }
            catch (Exception) { obj = new Ebook(); insert = true; }

            obj.TypeId = DefinitionInsert(4, sourceObj[1]);


            obj.Name = sourceObj[2];
            obj.Description = sourceObj[3];
            obj.AuthorId = AuthorInsert(sourceObj[4]);
            obj.PublisherId = DefinitionInsert(3, sourceObj[5]);
            obj.ISBN = sourceObj[6];
            try
            {
                obj.Year = Convert.ToInt32(sourceObj[7]);
            }
            catch (Exception) { }
            obj.Pages = Convert.ToInt32(sourceObj[8]);
            obj.LanguageId = DefinitionInsert(2, sourceObj[9]);
            obj.Size = Convert.ToDecimal(sourceObj[10]);
            obj.FormatId = DefinitionInsert(2, sourceObj[11]);
            //Url Download
            string downloadUrl = sourceObj[14].Replace("<a href='", "");
            int pos = downloadUrl.IndexOf("'>");
            if (pos > -1)
            {
                downloadUrl = downloadUrl.Substring(0, pos);
                obj.UrlDownload = downloadUrl;
                //DownloadFile(downloadUrl, @"E:\Ebooks\New\" + obj.Name + "." + sourceObj[10]);
            }

            obj.Url = sourceObj[13];
            obj.Path = null;
            if (insert)
            {
                obj.HasFile = false;
                db.Ebooks.InsertOnSubmit(obj);
            }
            db.SubmitChanges();
        }

        public static bool HttpPost(string uri, string sPath)
        {
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

                StreamWriter sw = new StreamWriter(sPath);
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

        public void DownloadFile(string uri, string sPath)
        {
            using (WebClient webClient = new WebClient())
            {
                webClient.DownloadFile(uri, sPath);
            }
        }

        public void EbookEdit(int id, string name, int authorId, string description, int publisherId, string isbn,
    int year, int pages, int languageId, decimal size, int formatId, string path, int typeId, string url)
        {
            Ebook obj = db.Ebooks.Where(v=>v.Id == id).First();
            obj.Name = name;
            obj.AuthorId = authorId;
            obj.Description = description;
            obj.PublisherId = publisherId;
            obj.ISBN = isbn;
            obj.Year = year;
            obj.Pages = pages;
            obj.LanguageId = languageId;
            obj.Size = size;
            obj.FormatId = formatId;
            obj.Path = path;
            obj.TypeId = typeId;
            obj.Url = url;
            db.SubmitChanges();
        }

        public void EbookDelete(int iId)
        {
            Ebook obj = db.Ebooks.Where(v => v.Id == iId).First();
            db.Ebooks.DeleteOnSubmit(obj);
            db.SubmitChanges();
        }

        public void EbookUpdateType()
        {
            List<Ebook> lst = (from t in db.Ebooks
                               where t.TypeId == 0 && t.Path != "E:\\Ebooks"
                               select t).ToList();
            foreach(Ebook item in lst)
            {
                item.TypeId = DefinitionId(4, item.Path.Substring(10, item.Path.Length - 10).ToUpper());
            }
            db.SubmitChanges();
        }
        #endregion

        #region Author

        public int AuthorInsert(string name)
        {
            //check exist
            try
            {
                return db.Authors.Where(v => v.Name == name).First().Id;
            }
            catch (Exception) { }
            Author obj = new Author();
            obj.Name = name;
            db.Authors.InsertOnSubmit(obj);
            db.SubmitChanges();
            return obj.Id;
        }
        #endregion

        #region Knowledge
        public List<Knowledge> KnowledgeList(int typeId, string title)
        {
            return (from t in db.Knowledges
                    where (typeId == 0 || t.TypeId == typeId) && (title.Length == 0 || t.Title.StartsWith(title))
                    orderby t.Id descending
                    select t).ToList();
        }

        public void KnowledgeInsert(string[] sourceObj)
        {
            try
            {
                if (db.Knowledges.Where(v => v.Title == sourceObj[2]).First().Id > 0) return;
            }
            catch (Exception) { }
            try
            {
                Knowledge obj = new Knowledge();
                obj.TypeId = Convert.ToInt32(sourceObj[1]);
                obj.Title = sourceObj[2].Trim();
                obj.Description = sourceObj[3].Trim();
                obj.Url = sourceObj[4];
                obj.IsFile = Convert.ToBoolean(sourceObj[5]);
                db.Knowledges.InsertOnSubmit(obj);

                db.SubmitChanges();
            }
            catch (Exception) { }
        }


        public void KnowledgeInsert(int typeId, string title, string content, string url, bool isFile)
        {
            try
            {
                if (db.Knowledges.Where(v => v.Title == title).First().Id > 0) return;
            }
            catch (Exception) { }
            Knowledge obj = new Knowledge();
            obj.TypeId = typeId;
            obj.Title = title.Trim();
            obj.Description = content.Trim();
            obj.Url = url;
            obj.IsFile = isFile;
            db.Knowledges.InsertOnSubmit(obj);
            db.SubmitChanges();
        }

        public void KnowledgeEdit(int id, int typeId, string title, string content, string url, bool isFile)
        {
            Knowledge obj = db.Knowledges.Where(v=>v.Id == id).First();
            obj.TypeId = typeId;
            obj.Title = title.Trim();
            obj.Description = content.Trim();
            obj.Url = url;
            obj.IsFile = isFile;
            db.SubmitChanges();
        }
        #endregion

        #region Term
        public List<Term> TermList(int typeId, string en, string vn)
        {
            return (from t in db.Terms
                    where (typeId == 0 || t.TypeId == typeId) && (en.Length == 0 || t.En.StartsWith(en))
                    && (vn.Length == 0 || t.Vn.StartsWith(vn))
                    orderby t.Id descending
                    select t).ToList();
        }

        public void TermInsert(string[] sourceObj)
        {
            try
            {
                if (db.Terms.Where(v => v.En == sourceObj[3] || v.Vn == sourceObj[2]).First().Id > 0) return;
            }
            catch (Exception) { }
            Term obj = new Term();
            obj.TypeId = Convert.ToInt32(sourceObj[1]);
            obj.Vn = sourceObj[2].Trim();
            obj.En = sourceObj[3].Trim();
            obj.Description = sourceObj[4].Trim();
            obj.Url = sourceObj[5];
            db.Terms.InsertOnSubmit(obj);
            db.SubmitChanges();
        }

        public void TermInsert(int typeId, string en, string vn, string content, string url)
        {
            try
            {
                int id = db.Terms.Where(v => v.En == en || v.Vn == vn).First().Id;
                if (db.Terms.Where(v => v.En == en || v.Vn == vn).First().Id > 0) return;
            }
            catch (Exception) { }
            Term obj = new Term();
            obj.TypeId = typeId;
            obj.En = en.Trim();
            obj.Vn = vn.Trim();
            obj.Description = content.Trim();
            obj.Url = url;
            db.Terms.InsertOnSubmit(obj);
            db.SubmitChanges();
        }

        public void TermEdit(int id, int typeId, string en, string vn, string content, string url)
        {
            Term obj = db.Terms.Where(v => v.Id == id).First();
            obj.TypeId = typeId;
            obj.En = en.Trim();
            obj.Vn = vn.Trim();            
            obj.Description = content.Trim();
            obj.Url = url;
            db.SubmitChanges();
        }
        #endregion

        #region Collect
        public IEnumerable<string> ColumnName(int type)
        {
            string table = "";
            switch(type)
            {
                case 7001:
                    table = "Ebooks";
                    break;
                case 7002:
                    table = "Knowledge";
                    break;
                case 7003:
                    table = "Term";
                    break;
            }
            return db.ExecuteQuery<string>("SELECT name FROM sys.columns WHERE object_id = OBJECT_ID('" + table + "');");
        }
        #endregion

        #region Url
        public Url UrlGet(int id)
        {
            return db.Urls.Where(v => v.Id == id).First();
        }

        public int TypeByUrl(int id)
        {
            return db.Urls.Where(v => v.Id == id).First().TypeId.Value;
        }

        public List<Url> UrlList()
        {
            return db.Urls.ToList();
        }

        public Url UrlList(int id)
        {
            return db.Urls.Where(v => v.Id == id).First();
        }

        public int UrlInsert(string url, int typeId, bool loop, bool goolge, string search)
        {
            Url obj;
            try
            {
                obj = db.Urls.Where(v => v.Url1 == url).First();
            }
            catch (Exception) { obj = new Url(); }            
            obj.Url1 = url;
            obj.TypeId = typeId;
            obj.Loop = loop;
            obj.Google = goolge;
            obj.Search = search;
            if (obj.Id == null || obj.Id == 0)
                db.Urls.InsertOnSubmit(obj);
            db.SubmitChanges();
            return obj.Id;
        }
        #endregion

        #region UrlDetail
        public List<UrlDetail> UrlDetailGet(int urlId)
        {
            return db.UrlDetails.Where(v => v.UrlId == urlId).OrderBy(v=>v.FieldNum).ToList();
        }

        public void UrlDetailInsert(int urlId, string[,] arrValue)
        {            
            try
            {
                if (db.UrlDetails.Where(v => v.UrlId == urlId).First().Id > 0) return;
            }
            catch (Exception) { }
            UrlDetail obj;   
            int len = arrValue.Length/3;
            for (int i=0; i<len; i++)
            {
                if (arrValue[i, 2].Length > 0)
                {
                    obj = new UrlDetail();
                    obj.UrlId = urlId;
                    obj.SearchBegin = arrValue[i, 0];
                    obj.SearchEnd = arrValue[i, 1];
                    obj.FieldNum = i;
                    obj.FieldOrder = Convert.ToInt32(arrValue[i, 2]);
                    db.UrlDetails.InsertOnSubmit(obj);
                }
            }
            db.SubmitChanges();
        }
        #endregion

    }
}
