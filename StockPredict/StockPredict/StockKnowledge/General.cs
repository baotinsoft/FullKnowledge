using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace StockKnowledge
{
    class General
    {
        public static string str_Con_SQL = "Data Source=localhost;" +
                "Initial Catalog=Stock;Integrated Security=true";
        public static double iLimit;
        public static void SetParam(int iLmt, DateTime dtDate)

        {
            iLimit = iLmt;
            SqlConnection cn = new SqlConnection(str_Con_SQL);
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO StockParameter VALUES('" + dtDate + "'," + iLimit + ")";
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public static double GetParam()
        {
            SqlConnection cn = new SqlConnection(str_Con_SQL);
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "SELECT TOP (1) HOSELimit FROM StockParameter ORDER BY DateLimit DESC";
            SqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            //int i = rdr.GetInt16(0);
            //double f = rdr.GetInt16(0) * 0.01;
            iLimit = rdr.GetInt16(0) * 0.01;
            rdr.Close();
            cn.Close();
            return iLimit;
        }

    }
}
