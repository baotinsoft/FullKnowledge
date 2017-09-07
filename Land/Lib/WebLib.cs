using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Data;
using System.Data.SqlClient;


namespace Land
{
    public class WebLib
    {
        public static string str_Con_SQL = "Data Source=localhost;" +
               "Initial Catalog=Stock;Integrated Security=true";
        public static string str_Con_SQL_Port = "Data Source=localhost;" +
               "Initial Catalog=Portfolio;Integrated Security=true";
        public static string str_Con_SQL_Live = "Data Source=localhost;" +
               "Initial Catalog=StockLive;Integrated Security=true";

        /*---------------------------------
          * Description: Download price from Internet
         ----------------------------------- */

        public static bool HttpPost(string uri, string sPath, string data, int page)
        {
            string sParam, sTmp;

            WebRequest webRequest = WebRequest.Create(uri);
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.Method = "POST";
            webRequest.ContentLength = data.Length;
            
            Stream os = null;
            try
            {
                // send the Post
                //webRequest.ContentLength = bytes.Length; //Count bytes to send
                os = webRequest.GetRequestStream();
                os.Write (Encoding.ASCII.GetBytes(data), 0, data.Length); //Send it
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

                sTmp = GetDateName(DateTime.Now);

                if (page > 0) sTmp += "-" + page;

                StreamWriter sw = new StreamWriter(sPath + sTmp + ".htm");
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

        public static bool HttpPost(string uri, string sPath, string name)
        {
            string sParam, sTmp;
            //StreamReader sr = new StreamReader(sFile);
            //sParam = sr.ReadToEnd();
            //sr.Close();
            //sParam = "ctl00$NewsMenuContent$Menu1$lblCachedHTMLCode=3&ctl00$LogoContent$UCLogoView1$lblCachedHTMLKey=market&ctl00$MainContent$lsThitruong=HCM&ctl00$MainContent$Date5=14/05/2008&ctl00$MainContent$Button1=Xem";
            //sParam = "ctl00_mainContent_Live3Price1_wdcdate=2008-06-20&";
            //sParam = sParam + "ctl00$mainContent$Live3Price1$wdcDate$dateInput_TextBox=20/06/2008&";
            //sParam = sParam + "ctl00_mainContent_Live3Price1_wdcDate_calendar_SD=[[2008,6,20]]";


            // parameters: name1=value1&name2=value2    
            WebRequest webRequest = WebRequest.Create(uri);
            //string ProxyString =
            // System.Configuration.ConfigurationManager.AppSettings
            // [GetConfigKey("proxy")];
            //webRequest.Proxy = new WebProxy (ProxyString, true);
            //Commenting out above required change to App.Config
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.Method = "POST";
            //webRequest.
            //byte[] bytes = Encoding.ASCII.GetBytes (sParam);
            Stream os = null;
            try
            { // send the Post
                //webRequest.ContentLength = bytes.Length; //Count bytes to send
                os = webRequest.GetRequestStream();
                //os.Write (bytes, 0, bytes.Length); //Send it
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


                StreamWriter sw = new StreamWriter(sPath + @"\" + name + ".htm");
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


        public static bool HttpPost(string uri, string sPath, int page)
        {
            string sParam, sTmp;
            //StreamReader sr = new StreamReader(sFile);
            //sParam = sr.ReadToEnd();
            //sr.Close();
            //sParam = "ctl00$NewsMenuContent$Menu1$lblCachedHTMLCode=3&ctl00$LogoContent$UCLogoView1$lblCachedHTMLKey=market&ctl00$MainContent$lsThitruong=HCM&ctl00$MainContent$Date5=14/05/2008&ctl00$MainContent$Button1=Xem";
            //sParam = "ctl00_mainContent_Live3Price1_wdcdate=2008-06-20&";
            //sParam = sParam + "ctl00$mainContent$Live3Price1$wdcDate$dateInput_TextBox=20/06/2008&";
            //sParam = sParam + "ctl00_mainContent_Live3Price1_wdcDate_calendar_SD=[[2008,6,20]]";


            // parameters: name1=value1&name2=value2    
            WebRequest webRequest = WebRequest.Create(uri);
            //string ProxyString =
            // System.Configuration.ConfigurationManager.AppSettings
            // [GetConfigKey("proxy")];
            //webRequest.Proxy = new WebProxy (ProxyString, true);
            //Commenting out above required change to App.Config
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.Method = "POST";
            //webRequest.
            //byte[] bytes = Encoding.ASCII.GetBytes (sParam);
            Stream os = null;
            try
            { // send the Post
                //webRequest.ContentLength = bytes.Length; //Count bytes to send
                os = webRequest.GetRequestStream();
                //os.Write (bytes, 0, bytes.Length); //Send it
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

                sTmp = GetDateName(DateTime.Now);

                if (page > 0) sTmp += "-" + page;

                StreamWriter sw = new StreamWriter(sPath + sTmp + ".htm");
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

        public static string GetDateName(DateTime date)
        {
            string sTmp = "";
            if (date.Month < 10)
                sTmp += "0" + date.Month;
            else
                sTmp += date.Month;
            sTmp += "-";
            if (date.Day < 10)
                sTmp += "0" + date.Day;
            else
                sTmp += date.Day;

            sTmp += "-" + date.Year;
            return sTmp;
        }

        public static bool HttpPostTime(string uri, string sPath, string sMarket)
        {
            string sParam, sTmp;

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

                sTmp = "";
                if (DateTime.Now.Month < 10)
                    sTmp += "0" + DateTime.Now.Month;
                else
                    sTmp += DateTime.Now.Month;
                sTmp += "-";
                if (DateTime.Now.Day < 10)
                    sTmp += "0" + DateTime.Now.Day;
                else
                    sTmp += DateTime.Now.Day;

                sTmp += "-";
                sTmp += DateTime.Now.Year + "-" + DateTime.Now.ToLongTimeString().Replace(':','_');

                StreamWriter sw = new StreamWriter(sPath + sMarket + "-" + sTmp + ".htm");
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


    }
}
