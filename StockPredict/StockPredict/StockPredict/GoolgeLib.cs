using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Web;
using System.Text.RegularExpressions;

namespace StockPredict
{
    class GoolgeLib
    {
        public static int GetPosition(Uri url, string searchTerm)
        {
            string raw = "http://www.google.com/search?num=39&q={0}&btnG=Search";

            string search = raw; //string.Format(raw, HttpUtility.UrlEncode(searchTerm));
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(search);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.ASCII))
                {
                    string html = reader.ReadToEnd();
                    return FindPosition(html, url);
                }
            }
        }

        public static string GetString(Uri url, string searchTerm)
        {
            string raw = "http://www.google.com/search?num=39&q={0}&btnG=Search";

            string search = raw; //string.Format(raw, HttpUtility.UrlEncode(searchTerm));
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(search);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.ASCII))
                {
                    string html = reader.ReadToEnd();
                    return FindString(html, url);
                }
            }
        }


        private static int FindPosition(string html, Uri url)
        {
            string lookup = "(<a class=l href=\")(\\w+[a-zA-Z0-9.-?=/]*)";
            MatchCollection matches = Regex.Matches(html, lookup);
            for (int i = 0; i < matches.Count; i++)
            {
                string match = matches[i].Groups[2].Value;
                if (match.Contains(url.Host))
                    return i + 1;
            }
            return 0;
        }

        private static string FindString(string html, Uri url)
        {
            string lookup = "(<a class=l href=\")(\\w+[a-zA-Z0-9.-?=/]*)";
            MatchCollection matches = Regex.Matches(html, lookup);
            for (int i = 0; i < matches.Count; i++)
            {
                string match = matches[i].Groups[2].Value;
                if (match.Contains(url.Host))
                    return match;
            }
            return "";
        }
    }
}
