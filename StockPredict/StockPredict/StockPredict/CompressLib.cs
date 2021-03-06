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
    class CompressLib
    {
        private const int lenArr = 1000;
        // connection string to SQL server
        private static string str_Con_SQL = "Data Source=localhost;" +
                "Initial Catalog=Stock;Integrated Security=true";
        private static int n;
        private const double R = 0.5;
        private static StreamReader sr;
        private static double[] arrPrice = new double[lenArr];
        private static double[,] arrOther = new double[lenArr, 3];
        private static int[] arrVolume = new int[lenArr];
        private static DateTime[] arrDate = new DateTime[lenArr];
        private static string sStockCode;
        SqlConnection cn;
        static SqlCommand cmd;

        public static void output(int iPos)
        {
            try
            {
                cmd.CommandText = "INSERT INTO " + sStockCode
                    + "_Compress(CloseDate, OpenPrice, HighPrice, LowPrice, ClosePrice, Volume) VALUES('"
                +arrDate[iPos] + "'," + arrOther[iPos, 0] + "," + arrOther[iPos, 1] + ","
                + arrOther[iPos, 2] + "," + arrPrice[iPos] + "," + arrVolume + ")";                
                cmd.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                string s = ex.ToString();
                //return null;

            }
        }

        /*---------------------------------
         * Description: Read lenArr record from text file into Source Array
         * Input:
         *      iPos: position of remain part in Source Array
         * Output: length of Source Array
        */
        public static int ReadIntoArr(int iPos)
        {
            string sLine;
            string[] sArrTmp = new string[7];
            while ((sLine = sr.ReadLine())!=null && iPos<lenArr)
            {
                sArrTmp = sLine.Split(',');
                iPos++;
                if (sArrTmp[0] == sStockCode)
                    for (int i = 1; i < 7; i++)
                    {
                        arrDate[iPos] = Convert.ToDateTime(sArrTmp[1]);
                        arrOther[iPos, 0] = Convert.ToDouble(sArrTmp[2]);
                        arrOther[iPos, 1] = Convert.ToDouble(sArrTmp[3]);
                        arrOther[iPos, 2] = Convert.ToDouble(sArrTmp[4]);
                        arrPrice[iPos] = Convert.ToDouble(sArrTmp[5]);
                        arrVolume[iPos] = Convert.ToInt32(sArrTmp[6]);
                    }
            }

            return iPos;
        }

        /*---------------------------------
         * Description: Compress data from dat file into StockCode_Compress table of Stock db
        ----------------------------------- */
        public static void Compress(string sStockCode1, string sFile)
        {
            SqlConnection cn = new SqlConnection(str_Con_SQL);
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            //ParseData..CreateStockCompressTable(
            ParseData.CreateStockCompressTable(sStockCode, cmd);
            sStockCode = sStockCode1;


            sr = new StreamReader(sFile);
            n = ReadIntoArr(-1);
            if (n > 2)
            {
                output(0);
                int i;
                i = FindFirst();
                if (i > 0 && i < n-1 && arrPrice[i] > arrPrice[0]) i = FindMaximum(i);
                while (i > 0 && i < n-1)
                {
                    i = FindMinimum(i);
                    i = FindMaximum(i);
                }
                output(n-1);
            }
            cn.Close();
        }

        private static int FindFirst()
        {
            int iMin = 0, iMax = 0, i = 1;
            while (arrPrice[i]!=0 && arrPrice[i] / arrPrice[iMin] < R && arrPrice[iMax] / arrPrice[i] < R)
            {
                if (arrPrice[i] < arrPrice[iMin]) iMin = i;
                if (arrPrice[i] > arrPrice[iMax]) iMax = i;
                i++;
                if (i == n)
                {
                    if (n == lenArr)
                    {
                        n = ReadIntoArr(0);
                        if (n == 0) return 0;
                        else i = 0;
                    }
                    else return 0;
                }
            }
            if (iMin < iMax) { if (iMin != 0) output(iMin); }
            else output(iMax);
            return i;
        }

        private static int FindMinimum(int i)
        {
            int iMin = i;
            while (arrPrice[i] != 0 && arrPrice[i] / arrPrice[iMin] < R)
            {
                if (arrPrice[i] < arrPrice[iMin]) iMin = i;
                i++;
                if (i == n)
                {
                    if (n == lenArr)
                    {
                        n = ReadIntoArr(iMin);
                        if (n == 0) return 0;
                        else
                        {
                            i = 1;
                            iMin = 0;
                        }
                    }
                    else return 0;
                }
            }
            if (i < n || arrPrice[iMin] < arrPrice[i]) output (iMin);
            return i;
        }

        private static int FindMaximum(int i)
        {
            int iMax = i;
            while (arrPrice[i] != 0 && arrPrice[iMax] / arrPrice[i] < R)
            {
                if (arrPrice[i] > arrPrice[iMax]) iMax = i;
                i++;
                if (i == n)
                {
                    if (n == lenArr)
                    {
                        n = ReadIntoArr(iMax);
                        if (n == 0) return 0;
                        else
                        {
                            i = 1;
                            iMax = 0;
                        }
                    }
                    else return 0;
                }
            }
            if (i < n || arrPrice[iMax] > arrPrice[i]) output (iMax);
            return i;
        }
    }
}
