using DBSynchronization.DataContext;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DBSynchronization
{
    class DataList
    {
        public int Id;
        public string Value;
        public DataList(int i, string v)
        {
            Id = i;
            Value = v;
        }
    }
    class LibDB
    {
        SqlConnection sqlConn;
        DBSyncDataContext db = new DBSyncDataContext();

        public string conn { get; set; }
        public string connSource { get; set; }
        public string connDest { get; set; }

        #region Definition
        public List<Definition> DefinitionList(int groupId)
        {
            return db.Definitions.Where(v=>v.GroupId == groupId).ToList();
        }

        #endregion

        public string DBName()
        {
            return sqlConn.Database;
        }

        public void OpenConnection()
        {
            try
            {
                sqlConn = new SqlConnection(conn);
                sqlConn.Open();
            }
            catch (Exception) { }
        }

        public void CloseConnection()
        {
            sqlConn.Close();
        }

        public List<string> GetDBs()
        {
            List<string> items = new List<string>();
            try
            {
                if (sqlConn.State == ConnectionState.Open) sqlConn.Close();
                sqlConn.Open();
                SqlCommand sqlCom = new System.Data.SqlClient.SqlCommand();
                sqlCom.Connection = sqlConn;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "sp_databases";
                SqlDataReader sqlDR;
                sqlDR = sqlCom.ExecuteReader();
               
                while (sqlDR.Read())
                {
                    items.Add(sqlDR.GetString(0));
                }

                sqlCom.Dispose();
            }
            catch (Exception ex) { }
            return items;
        }

        public List<string> GetTables(string db)
        {
            List<string> items = new List<string>();
            try
            {
                sqlConn.Close();
                sqlConn.Open();
                sqlConn.ChangeDatabase(db);
                DataTable schema = sqlConn.GetSchema("Tables");
                foreach (DataRow row in schema.Rows)
                    if (row[3].ToString() == "BASE TABLE" && row[2].ToString() != "sysdiagrams")
                        items.Add(row[2].ToString());
            }
            catch (Exception ex) { }
            return items;
        }

        public List<string> GetTables(string db, string currentConn)
        {
            List<string> items = new List<string>();
            try
            {
                sqlConn.Close();
                sqlConn.ConnectionString = currentConn;
                sqlConn.Open();
                DataTable schema = sqlConn.GetSchema("Tables");
                foreach (DataRow row in schema.Rows)
                    if (row[3].ToString() == "BASE TABLE" && row[2].ToString() != "sysdiagrams")
                        items.Add(row[2].ToString());
            }
            catch (Exception ex) { }
            return items;
        }

        public List<string> GetColumns(string table, string DB, string server)
        {
            List<string> items = new List<string>();
            try
            {
                sqlConn.Close();
                //sqlConn.ConnectionString = "Data Source=" + server + ";Persist Security Info=True;User ID=sa;Password=123bt@123";
                sqlConn.Open();
                //if (DB.Length > 0)
                //    sqlConn.ChangeDatabase(DB);
                SqlCommand sqlCom = new System.Data.SqlClient.SqlCommand();
                sqlCom.Connection = sqlConn;
                sqlCom.CommandType = CommandType.Text;
                sqlCom.CommandText = "SELECT COLUMN_NAME FROM " + server + "." + DB + ".INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = N'" + table + "'";
                SqlDataReader sqlDR;
                sqlDR = sqlCom.ExecuteReader();

                while (sqlDR.Read())
                {
                    items.Add(sqlDR.GetString(0));
                }

                sqlCom.Dispose();
                sqlConn.Close();
                sqlConn.ConnectionString = conn;
            }
            catch (Exception ex) { }
            if (sqlConn.State == ConnectionState.Open)
                sqlConn.Close();

            return items;
        }


        public List<string> GetColumns(string table, string DB)
        {
            List<string> items = new List<string>();
            try
            {
                sqlConn.Close();
                sqlConn.Open();
                //if (DB.Length > 0)
                //    sqlConn.ChangeDatabase(DB);
                SqlCommand sqlCom = new System.Data.SqlClient.SqlCommand();
                sqlCom.Connection = sqlConn;
                sqlCom.CommandType = CommandType.Text;
                sqlCom.CommandText = "SELECT COLUMN_NAME FROM " + DB + ".INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = N'" + table + "'";                
                SqlDataReader sqlDR;
                sqlDR = sqlCom.ExecuteReader();

                while (sqlDR.Read())
                {
                    items.Add(sqlDR.GetString(0));
                }

                sqlCom.Dispose();
            }
            catch (Exception ex) { }
            if (sqlConn.State == ConnectionState.Open)
                sqlConn.Close();

            return items;
        }

        public string[,] GetColumnswithType(string table, string DB)
        {
            string[,] items = null;
            try
            {
                sqlConn.Close();
                sqlConn.Open();
                //if (DB.Length > 0)
                //    sqlConn.ChangeDatabase(DB);
                SqlCommand sqlCom = new System.Data.SqlClient.SqlCommand();
                sqlCom.Connection = sqlConn;
                sqlCom.CommandType = CommandType.Text;
                sqlCom.CommandText = "SELECT COLUMN_NAME, DATA_TYPE FROM " + DB + ".INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = N'" + table + "'";
                SqlDataReader sqlDR;
                sqlDR = sqlCom.ExecuteReader();

                using (DataTable dt = new DataTable())
                {
                    dt.Load(sqlDR);
                    int count = dt.Rows.Count - 1;
                    items = new string[count, 2];
                    for (int i = 0; i < count; i++ )
                    {
                        items[i, 0] = dt.Rows[i+1][0].ToString();
                        items[i, 1] = dt.Rows[i+1][1].ToString();
                    }
                }
                

                sqlCom.Dispose();
            }
            catch (Exception ex) { }
            if (sqlConn.State == ConnectionState.Open)
                sqlConn.Close();

            return items;
        }


        public List<string> GetForeignColumns(string table)
        {
            List<string> items = new List<string>();
            try
            {
                SqlCommand sqlCom = new System.Data.SqlClient.SqlCommand();
                sqlCom.Connection = sqlConn;
                sqlCom.CommandType = CommandType.Text;
                sqlCom.CommandText = "SELECT OBJECT_NAME(pt.parent_object_id) AS [Table], OBJECT_NAME(pt.constraint_object_id) AS FK, pc.name AS Referencing_col, rc.name AS Referenced_col"
                    + "FROM sys.foreign_key_columns AS pt INNER JOIN "
                    + "sys.columns AS pc ON pt.parent_object_id = pc.object_id AND pt.parent_column_id = pc.column_id INNER JOIN "
                    + "sys.columns AS rc ON pt.referenced_column_id = rc.column_id AND pt.referenced_object_id = rc.object_id "
                    + "WHERE (pt.referenced_object_id = OBJECT_ID('" + table + "'))";
                SqlDataReader sqlDR;
                sqlDR = sqlCom.ExecuteReader();

                while (sqlDR.Read())
                {
                    items.Add(sqlDR.GetString(2) + ";" + sqlDR.GetString(2));
                }

                sqlCom.Dispose();
            }
            catch (Exception ex) { }
            return items;
        }

        public bool ExecuteCommand(string sql)
        {
            try
            {
                if (sqlConn.State == ConnectionState.Open) sqlConn.Close();
                sqlConn.Open();
                SqlCommand sqlCom = new System.Data.SqlClient.SqlCommand();
                sqlCom.Connection = sqlConn;
                sqlCom.CommandType = CommandType.Text;
                sqlCom.CommandText = sql;
                sqlCom.ExecuteNonQuery();
                sqlCom.Dispose();
            }
            catch (Exception ex) {
                return false;
            }
            return true;
        }

        public bool Backup(string DB, string fileBackup)
        {
            try
            {
                if (sqlConn.State == ConnectionState.Open) sqlConn.Close();
                sqlConn.Open();
                SqlCommand sqlCom = new System.Data.SqlClient.SqlCommand();
                sqlCom.Connection = sqlConn;
                sqlCom.CommandType = CommandType.Text;
                sqlCom.CommandText = "Backup DB " + DB + " to disk='" + fileBackup + "'";
                sqlCom.ExecuteNonQuery();
                sqlCom.Dispose();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool Restore(string DB, string backupPath)
        {
            try
            {
                sqlConn.Close();
                sqlConn.Open();
                SqlCommand sqlCom = new System.Data.SqlClient.SqlCommand();
                sqlCom.Connection = sqlConn;
                sqlCom.CommandType = CommandType.Text;

                sqlCom.CommandText = "USE master";
                sqlCom.ExecuteNonQuery();

                //The below query will rollback any transaction which is
                  //running on that DB and brings SQL Server DB in a single user mode.
                string Alter1 = @"ALTER DB [" + DB + "] SET Single_User WITH Rollback Immediate";
                sqlCom.ExecuteNonQuery();

                string Restore = @"RESTORE DB [" + DB + "] FROM DISK = N'" + backupPath + @"' WITH  REPLACE";
                sqlCom.ExecuteNonQuery();

                // the below query change the DB back to multiuser
                string Alter2 = @"ALTER DB [" + DB + "] SET Multi_User";
                sqlCom.ExecuteNonQuery();

                sqlCom.Dispose();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool ExecuteCommand(string sql, string connString, string db)
        {
            try
            {
                sqlConn.Close();
                sqlConn.ConnectionString = connString;
                sqlConn.Open();
                sqlConn.ChangeDatabase(db);
                SqlCommand sqlCom = new System.Data.SqlClient.SqlCommand();
                sqlCom.Connection = sqlConn;
                sqlCom.CommandType = CommandType.Text;
                sqlCom.CommandText = sql;
                sqlCom.ExecuteNonQuery();
                sqlCom.Dispose();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }


        public SqlDataReader ExecuteQuery(string sql)
        {
            try
            {
                sqlConn.Close();
                sqlConn.Open();
                SqlCommand sqlCom = new System.Data.SqlClient.SqlCommand();
                sqlCom.Connection = sqlConn;
                sqlCom.CommandType = CommandType.Text;
                sqlCom.CommandText = sql;
                SqlDataReader reader = sqlCom.ExecuteReader();
                sqlCom.Dispose();
                return reader;
            }
            catch (Exception ex)
            {
            }
            return null;
        }

        public DataTable ExecuteQueryForCbo(string sql, string db)
        {
            try
            {
                sqlConn.Close();
                sqlConn.Open();
                sqlConn.ChangeDatabase(db);
                SqlCommand sqlCom = new System.Data.SqlClient.SqlCommand();
                sqlCom.Connection = sqlConn;
                sqlCom.CommandType = CommandType.Text;
                sqlCom.CommandText = sql;
                SqlDataReader reader = sqlCom.ExecuteReader();
                sqlCom.Dispose();
                DataTable dt = new DataTable();
                dt.Load(reader);
                DataRow row = dt.NewRow();
                row[0] = 0;
                row[1] = "";
                dt.Rows.InsertAt(row, 0);
                return dt;
            }
            catch (Exception ex)
            {
            }
            return null;
        }


        public SqlDataReader ExecuteQuery(string sql, string db)
        {
            try
            {
                sqlConn.Close();
                sqlConn.Open();
                sqlConn.ChangeDatabase(db);
                SqlCommand sqlCom = new System.Data.SqlClient.SqlCommand();
                sqlCom.Connection = sqlConn;
                sqlCom.CommandType = CommandType.Text;
                sqlCom.CommandText = sql;
                SqlDataReader reader = sqlCom.ExecuteReader();
                sqlCom.Dispose();
                //DataTable dt = new DataTable();
                //dt.Load(reader);
                //return dt;
                return reader;
            }
            catch (Exception ex)
            {
            }
            return null;
        }

        public List<DataList> DataListForCbo(string sql, string db)
        {
            SqlDataReader reader = ExecuteQuery(sql, db);
            List<DataList> lst = new List<DataList>();
            lst.Add(new DataList(0, ""));
            while (reader.Read())
            {
                lst.Add(new DataList(reader.GetInt32(0), reader.GetString(1)));
            }
            return lst;
        }



        public bool MergeTable(string sourceTable, string targetTable, string refColumn)
        {            
            try
            {                               
                int pos1 = sourceTable.IndexOf('.');
                string server = sourceTable.Substring(0, pos1);
                int pos2 = sourceTable.IndexOf('.', pos1+1);
                string DB = sourceTable.Substring(pos1 + 1, pos2 - pos1 - 1);
                pos2 = pos2 + 5;
                string table = sourceTable.Substring(pos2, sourceTable.Length - pos2);
                List<string> sourceColumn = GetColumns(table, DB, server);

                pos1 = targetTable.IndexOf('.');
                pos2 = targetTable.IndexOf('.', pos1 + 1);
                DB = targetTable.Substring(pos1 + 1, pos2 - pos1 - 1);
                pos2 = pos2 + 5;
                table = targetTable.Substring(pos2, targetTable.Length - pos2);
                List<string> targetColumn = GetColumns(table, DB);

                //check the same fields in 2 DB - tables
                foreach (string source in sourceColumn)
                    if (targetColumn.IndexOf(source) == -1) return false;

                if (refColumn.Length == 0) refColumn = "SourceId";
                //check exist refColumn in targetTable
                if (targetColumn.IndexOf(refColumn) == -1) //not exist, please insert refColumn into targetTable
                    ExecuteCommand("alter table " + table + " add " + refColumn + " int NULL", connDest, DB);

                sqlConn.Close();
                sqlConn.Open();

                SqlCommand sqlCom = new System.Data.SqlClient.SqlCommand();
                sqlCom.Connection = sqlConn;
                sqlCom.CommandType = CommandType.Text;
                
                string sql = "MERGE " + targetTable + " AS TARGET "
                    + "USING " + sourceTable + " AS SOURCE "
                    + "ON (TARGET."+ refColumn + " = SOURCE." + sourceColumn[0] + ") "
                    + "WHEN MATCHED AND ";
                
                for(int i=1;i<sourceColumn.Count;i++)
                    sql += "TARGET." + sourceColumn[i] + " <> SOURCE." + sourceColumn[i] + " OR ";
                sql = sql.Substring(0, sql.Length - 4) + " THEN UPDATE SET ";

                for (int i = 1; i < sourceColumn.Count; i++)
                    sql += "TARGET." + sourceColumn[i] + " = SOURCE." + sourceColumn[i] + ", ";
                sql = sql.Substring(0, sql.Length - 2) + " WHEN NOT MATCHED BY TARGET THEN INSERT (" + refColumn + ", ";
                
                for (int i = 1; i < sourceColumn.Count; i++)
                    sql += sourceColumn[i] + ", ";
                sql = sql.Substring(0, sql.Length - 2) + ") VALUES (";

                for (int i = 0; i < sourceColumn.Count; i++)
                    sql += "SOURCE." + sourceColumn[i] + ", ";
                sql = sql.Substring(0, sql.Length - 2)
                    + ") WHEN NOT MATCHED BY SOURCE AND TARGET." + refColumn + " is NOT null THEN DELETE;";

                sqlCom.CommandText = sql;
                
                //sql += "VALUES (SOURCE.Id, SOURCE.f1, SOURCE.f2, SOURCE.f3) "
                //    + "WHEN NOT MATCHED BY SOURCE AND TARGET.Test1Id is NOT null THEN "
                //    + "DELETE; "
                //    + "MERGE Table3 AS TARGET "
                //    + "USING Test2.dbo.Table3 AS SOURCE "
                //    + "ON (TARGET.Test2Id = SOURCE.Id) "
                //    + "WHEN MATCHED AND TARGET.f1 <> SOURCE.f1 "
                //    + "OR TARGET.f2 <> SOURCE.f2 OR TARGET.f3 <> SOURCE.f3 THEN "
                //    + "UPDATE SET TARGET.f1 = SOURCE.f1, "
                //    + "TARGET.f2 = SOURCE.f2, TARGET.f3 = SOURCE.f3 "
                //    + "WHEN NOT MATCHED BY TARGET THEN "
                //    + "INSERT (Test2Id, f1, f2, f3) "
                //    + "VALUES (SOURCE.Id, SOURCE.f1, SOURCE.f2, SOURCE.f3) "
                //    + "WHEN NOT MATCHED BY SOURCE AND TARGET.Test2Id is NOT null THEN "
                //    + "DELETE;";
                sqlCom.ExecuteNonQuery();
                sqlCom.Dispose();

                if (sqlConn.State == ConnectionState.Open)
                    sqlConn.Close();

            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public string MergeTableQuery(string sourceTable, string targetTable, string refColumn)
        {
            try
            {
                int pos1 = sourceTable.IndexOf('.');
                string server = sourceTable.Substring(0, pos1);
                int pos2 = sourceTable.IndexOf('.', pos1 + 1);
                string DB = sourceTable.Substring(pos1 + 1, pos2 - pos1 - 1);
                pos2 = pos2 + 5;
                string table = sourceTable.Substring(pos2, sourceTable.Length - pos2);
                List<string> sourceColumn = GetColumns(table, DB, server);

                pos1 = targetTable.IndexOf('.');
                pos2 = targetTable.IndexOf('.', pos1 + 1);
                DB = targetTable.Substring(pos1 + 1, pos2 - pos1 - 1);
                pos2 = pos2 + 5;
                table = targetTable.Substring(pos2, targetTable.Length - pos2);
                List<string> targetColumn = GetColumns(table, DB);

                //check the same fields in 2 DB - tables
                foreach (string source in sourceColumn)
                    if (targetColumn.IndexOf(source) == -1) return null;

                if (refColumn.Length == 0) refColumn = "SourceId";
                //check exist refColumn in targetTable
                if (targetColumn.IndexOf(refColumn) == -1) //not exist, please insert refColumn into targetTable
                    ExecuteCommand("alter table " + targetTable + " add " + refColumn + " int NULL");

                string sql = "MERGE " + targetTable + " AS TARGET "
                    + "USING " + sourceTable + " AS SOURCE "
                    + "ON (TARGET." + refColumn + " = SOURCE." + sourceColumn[0] + ") "
                    + "WHEN MATCHED AND ";

                for (int i = 1; i < sourceColumn.Count; i++)
                    sql += "TARGET." + sourceColumn[i] + " <> SOURCE." + sourceColumn[i] + " OR ";
                sql = sql.Substring(0, sql.Length - 4) + " THEN UPDATE SET ";

                for (int i = 1; i < sourceColumn.Count; i++)
                    sql += "TARGET." + sourceColumn[i] + " = SOURCE." + sourceColumn[i] + ", ";
                sql = sql.Substring(0, sql.Length - 2) + " WHEN NOT MATCHED BY TARGET THEN INSERT (" + refColumn + ", ";

                for (int i = 1; i < sourceColumn.Count; i++)
                    sql += sourceColumn[i] + ", ";
                sql = sql.Substring(0, sql.Length - 2) + ") VALUES (";

                for (int i = 0; i < sourceColumn.Count; i++)
                    sql += "SOURCE." + sourceColumn[i] + ", ";
                sql = sql.Substring(0, sql.Length - 2)
                    + ") WHEN NOT MATCHED BY SOURCE AND TARGET." + refColumn + " is NOT null THEN DELETE;";

                return sql;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public void MergeDB(string sourceDb, string destDb)
        {
            List<string> sourceTables = GetTables(sourceDb);
            List<string> descTables = GetTables(destDb);
            foreach(string table in sourceTables)
            {
                if (descTables.IndexOf(table) != -1)
                    MergeTable(sourceDb + ".dbo." + table, destDb + ".dbo." + table, "SourceId");
            }
        }

        //public DataTable AllServers()
        //{
        //    return SqlDataSourceEnumerator.Instance.GetDataSources();

        //    //return SmoApplication.EnumAvailableSqlServers(true);
        //}

        public SqlDataReader LinkedServerAdd(string name, string server)
        {
            if (name.Length > 0)
            {
                ExecuteCommand("EXEC master.dbo.sp_addlinkedserver @server = N'" + name + "', @srvproduct=N'SQLNCLI', @provider=N'SQLNCLI', @datasrc=N'" + server + "'");
                ExecuteCommand("Exec sp_addlinkedsrvlogin @rmtsrvname = '" + name + "', @useself = true, @locallogin = null, @rmtuser = 'sa', @rmtpassword = '123bt@123' ");
            }
            return ExecuteQuery("select * from sys.servers");
        }

        #region Server
        public int ServerAdd(string serverDest, string serverSource)
        {
            //check duplicated
            try
            {
                return (from t in db.ServerNames
                     where t.ServerSource == serverSource && t.ServerDest == serverDest
                     select new { t.Id }).First().Id;
            }
            catch (Exception) { }
            ServerName obj = new ServerName();
            obj.ServerDest = serverDest;
            obj.ServerSource = serverSource;
            obj.CreatedDate = DateTime.Now;
            db.ServerNames.InsertOnSubmit(obj);
            db.SubmitChanges();
            return obj.Id;
        }

        public int ServerEdit(int id, string serverDest, string serverSource)
        {
            ServerName obj = (from t in db.ServerNames
                     where t.Id == id
                     select t).First();
            obj.ServerDest = serverDest;
            obj.ServerSource = serverSource;
            obj.UpdatedDate = DateTime.Now;
            db.SubmitChanges();
            return obj.Id;
        }

        #endregion

        #region DB
        public int DBAdd(int serverId, string dbDest, string dbSource, bool isTwoDirection)
        {
            //check duplicated
            try
            {
                int id = (from t in db.DBs
                     where t.DBSource == dbSource && t.DBDest == dbDest
                     select new { t.Id }).First().Id;
                TableAdd(serverId, dbSource, dbDest, id, isTwoDirection);
                return id;
            }
            catch (Exception) { }
            DB obj = new DB();
            obj.DBDest = dbDest;
            obj.DBSource = dbSource;
            obj.ServerId = serverId;
            db.DBs.InsertOnSubmit(obj);
            db.SubmitChanges();

            TableAdd(serverId, dbSource, dbDest, obj.Id, isTwoDirection);

            return obj.Id;
        }

        public int DBEdit(int id, int serverId, string dbDest, string dbSource, bool isTwoDirection)
        {
            DB obj = (from t in db.DBs
                          where t.Id == id
                          select t).First();
            obj.DBDest = dbDest;
            obj.DBSource = dbSource;
            obj.ServerId = serverId;
            db.SubmitChanges();

            TableAdd(serverId, dbSource, dbDest, obj.Id, isTwoDirection);

            return obj.Id;
        }

        public List<DB> DBList()
        {
            return (from t in db.DBs
                        select t).ToList();
        }

        #endregion

        #region Tables
        public void TableAdd(int serverId, string dbSource, string dbDest, int dbId, bool isTwoDirection)
        {
            //clear old tables
            try
            {
                var tables = (from t in db.MergeTables
                 where t.DatabaseId == dbId
                 select t);
                db.MergeTables.DeleteAllOnSubmit(tables);
                db.SubmitChanges();
            }
            catch (Exception) { }
            //get server
            ServerName objServer = db.ServerNames.Where(v => v.Id == serverId).First();
            string serverSource = objServer.ServerSource;
            string serverDest = objServer.ServerDest;

            //update tables of the DB source/dest
            List<string> sourceTables = GetTables(serverSource + "." + dbSource, connSource);
            List<string> destTables = GetTables(serverDest + "." + dbDest, connDest);

            string query;
            foreach (string table in sourceTables)
            {
                if (destTables.IndexOf(table) != -1)
                {
                    query = MergeTableQuery(serverSource + "." + dbSource + ".dbo." + table, serverDest + "." + dbDest + ".dbo." + table, "SourceId");
                    if (query != null)
                    {
                        MergeTable objTable = new MergeTable();
                        objTable.MergeQuery = query;
                        objTable.DatabaseId = dbId;
                        objTable.TableName = table;
                        db.MergeTables.InsertOnSubmit(objTable);
                        db.SubmitChanges();
                    }
                    if (isTwoDirection)
                    {
                        query = MergeTableQuery(serverDest + "." + dbDest + ".dbo." + table, serverSource + "." + dbSource + ".dbo." + table, "SourceId");
                        if (query != null)
                        {
                            MergeTable objTable = new MergeTable();
                            objTable.MergeQuery = query;
                            objTable.DatabaseId = dbId;
                            objTable.TableName = table;
                            db.MergeTables.InsertOnSubmit(objTable);
                            db.SubmitChanges();
                        }
                    }
                }
            }
        }

        public List<string> TableList(int DBId)
        {
            return (from t in db.MergeTables
             where t.DatabaseId == DBId
             select t.MergeQuery).ToList();
        }
        #endregion

        #region Web Request
        public int TableAdd(string tableName, bool isDaily)
        {
            //check duplicated
            TableRequest obj;
            try
            {
                obj = (from t in db.TableRequests
                     where t.TableName == tableName
                     select t).First();
            }
            catch (Exception) { obj = new TableRequest(); }
            obj.TableName = tableName;
            obj.IsDaily = isDaily;
            db.TableRequests.InsertOnSubmit(obj);
            db.SubmitChanges();
            return obj.Id;
        }


        #endregion

        #region Url


        public Url UrlGet(int id)
        {
            try
            {
                return db.Urls.Where(v => v.Id == id).First();
            }
            catch (Exception) { return null; }
        }


        public List<Url> UrlList()
        {
            return db.Urls.ToList();
        }

        public Url UrlList(int id)
        {
            return db.Urls.Where(v => v.Id == id).First();
        }

        public int UrlInsert(string url, int tableId, bool loop, bool goolge, string search, int from, int to, string alphaFrom, string alphaTo, string path, bool isHttpPost, int contentTypeId)
        {
            Url obj;
            bool isUpdate = true;
            try
            {
                obj = db.Urls.Where(v => v.Url1 == url).First();
            }
            catch (Exception) { obj = new Url(); isUpdate = false; }
            obj.Url1 = url;
            obj.TableId = tableId;
            obj.Loop = loop;
            obj.Google = goolge;
            obj.Search = search;
            obj.ValueFrom = from;
            obj.ValueTo = to;
            obj.AlphaFrom = alphaFrom;
            obj.AlphaTo = alphaTo;
            obj.StorePath = path;
            obj.HttpPost = isHttpPost;
            obj.ContentTypeId = contentTypeId;
            if (!isUpdate)
                db.Urls.InsertOnSubmit(obj);
            db.SubmitChanges();
            return obj.Id;
        }
        #endregion

        #region UrlDetail
        public List<UrlDetail> UrlDetailGet(int urlId)
        {
            return db.UrlDetails.Where(v => v.UrlId == urlId).OrderBy(v => v.FieldNum).ToList();
        }

        public void UrlDetailInsert(int urlId, string[,] arrValue)
        {
            List<UrlDetail> lst = null;
            try
            {
                lst = db.UrlDetails.Where(v => v.UrlId == urlId).ToList();
            }
            catch (Exception) { }
            
            int len = arrValue.Length / 6;
            UrlDetail item;
            for (int i=0; i < len; i++)
            {
                if (arrValue[i, 2].Length > 0)
                {
                    try
                    {
                        item = lst.Where(v=>v.FieldNum == i).First();
                        item.SearchSkip = arrValue[i, 0];
                        item.SearchBegin = arrValue[i, 1];
                        item.SearchEnd = arrValue[i, 2];
                        item.FieldOrder = Convert.ToInt32(arrValue[i, 3]);
                        item.DataType = arrValue[i, 4];
                        item.DefGroup = arrValue[i, 5] == null ? 0: Convert.ToInt32(arrValue[i, 5]);

                        db.SubmitChanges();
                    }
                    catch (Exception) {
                        item = new UrlDetail();
                        item.UrlId = urlId;
                        item.SearchSkip = arrValue[i, 0];
                        item.SearchBegin = arrValue[i, 1];
                        item.SearchEnd = arrValue[i, 2];
                        item.FieldNum = i;
                        item.FieldOrder = Convert.ToInt32(arrValue[i, 3]);
                        item.DataType = arrValue[i, 4];
                        item.DefGroup = arrValue[i, 5] == null ? 0 : Convert.ToInt32(arrValue[i, 5]);
                        db.UrlDetails.InsertOnSubmit(item);
                        db.SubmitChanges();
                    }
                }
            }            
        }
        #endregion

        #region Table Request
        public TableRequest TableRequestByName(string tableName, out int urlId)
        {
            try
            {
                TableRequest obj = db.TableRequests.Where(v => v.TableName == tableName).First();
                urlId = db.Urls.Where(v => v.TableId == obj.Id).First().Id;
                return obj;
            }
            catch (Exception) { urlId = -1; return null; }
        }

        public TableRequest TableGet(int id)
        {
            return db.TableRequests.Where(v => v.Id == id).First();
        }

        public string TableNameByUrl(int urlId, string dbName)
        {
            try
            {
                int tableId = db.Urls.Where(v => v.Id == urlId).First().TableId.Value;
                TableRequest obj = db.TableRequests.Where(v => v.Id == tableId).First();
                if (dbName != obj.DBName)
                    return null;
                else
                    return obj.TableName;
            }
            catch (Exception) { return null; }
        }

        public List<TableRequest> TableRequestList()
        {
            return db.TableRequests.ToList();
        }

        public int TableRequestAdd(string name, bool isDaily)
        {
            TableRequest obj = null;
            bool isUpdate = true;
            try
            {
                obj = db.TableRequests.Where(v => v.TableName == name).First();
            }
            catch (Exception) { obj = new TableRequest(); isUpdate = false; }            
            obj.IsDaily = isDaily;
            if (!isUpdate)
            {
                obj.TableName = name;
                db.TableRequests.InsertOnSubmit(obj);
            }
            db.SubmitChanges();
            return obj.Id;
        }
        #endregion


    }
}
