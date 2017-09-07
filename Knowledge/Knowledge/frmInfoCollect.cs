using Knowledge.DBContext;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Knowledge
{
    public partial class frmInfoCollect : Form
    {
        DBKnowledge db = new DBKnowledge();
        int controlCount, next = 4, colsCount, itemTypeId;
        string[,] lst, lstOrder;
        public frmInfoCollect()
        {
            InitializeComponent();
        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int type = cboType.SelectedIndex;
            if (type == -1) return;
            while (this.Controls.Count > controlCount)
            {
                this.Controls.RemoveAt(controlCount);
            }
            IEnumerator<string> cols = db.ColumnName((int)cboType.SelectedValue).GetEnumerator();
            List<UrlDetail> lst = null;
            if (cboUrl.SelectedIndex != -1)
                lst = db.UrlDetailGet((int)cboUrl.SelectedValue);
            int i = 1, j = 0;
            TextBox t;
            while (cols.MoveNext())
            {
                t = new TextBox();
                t.Text = cols.Current;
                t.Name = t.Text;
                t.Location = new Point(10, 40 + 25 * i);
                this.Controls.Add(t);
                t = new TextBox();
                t.Location = new Point(120, 40 + 25 * i);
                this.Controls.Add(t);
                t = new TextBox();
                t.Location = new Point(230, 40 + 25 * i);
                this.Controls.Add(t);
                t = new TextBox();
                t.Location = new Point(340, 40 + 25 * i);
                this.Controls.Add(t);
                //insert value to textboxes
                if (lst!= null && j < lst.Count && lst[j].FieldNum == (i - 1))
                {
                    t = (TextBox)this.Controls[controlCount + (i - 1) * next + 1];
                    t.Text = lst[j].SearchBegin;
                    t = (TextBox)this.Controls[controlCount + (i - 1) * next + 2];
                    t.Text = lst[j].SearchEnd;
                    t = (TextBox)this.Controls[controlCount + (i - 1) * next + 3];
                    t.Text = lst[j].FieldOrder.ToString();
                    j++;
                }
                i++;
            }
            colsCount = i - 1;
            //SetValue();
            if (lst!= null)
                OrderUpdate();

            if (type > -1)
            {
                cboItemType.DataSource = db.ItemTypeList(Convert.ToInt32(cboType.SelectedValue));
                cboItemType.DisplayMember = "Code";
                cboItemType.ValueMember = "Id";
            }
        }

        private void frmInfoCollect_Load(object sender, EventArgs e)
        {
            controlCount = this.Controls.Count;
            cboType.DisplayMember = "Code";
            cboType.ValueMember = "Id";
            cboType.DataSource = db.DefinitionList(6);

            cboUrl.DisplayMember = "Url1";
            cboUrl.ValueMember = "Id";
            cboUrl.DataSource = db.UrlList();

        }

        private void btnCollect_Click(object sender, EventArgs e)
        {
            itemTypeId = Convert.ToInt32(cboItemType.SelectedValue);
            int alpha = cboUrl.Text.IndexOf("{A}");
            int num = cboUrl.Text.IndexOf("{N}");
            //get order condition
            lstOrder = new string[colsCount, 4];
            int pos;
            for (int i = 0; i < colsCount; i++ )
            {
                if (lst[i, 2].Length > 0)
                {
                    pos = Convert.ToInt32(lst[i, 2]) - 1;
                    lstOrder[pos, 0] = lst[i, 0];
                    lstOrder[pos, 1] = lst[i, 1];
                    lstOrder[pos, 2] = lst[i, 2];
                    lstOrder[pos, 3] = i.ToString();
                }
                    
            }

                if (chkGoolge.Checked)
                    ScanGoolge();
                else if (alpha > 0 && num > 0)
                    ScanBoth();
                else if (num > 0)
                    ScanNumber();
                else if (alpha > 0)
                    ScanAlpha();
        }

        private string PathSelect()
        {
            string path = Application.StartupPath + @"\Data\";
            switch ((int)cboType.SelectedIndex)
            {
                case 7001: // Books
                    path += @"Books\";
                    break;
                case 7002: //Knowledge
                    path += @"Knowledge\";
                    break;
                case 7003: //Term
                    path += @"Term\";
                    break;
            }
            return path;
        }

        private void ScanNumber()
        {
            int begin = Convert.ToInt32(txtBegin.Text);
            int end = Convert.ToInt32(txtEnd.Text);

            string url = cboUrl.Text;
            string tempUrl = url;
            string path = PathSelect();
            for (int i = begin; i <= end; i++)
            {
                tempUrl = tempUrl.Replace("{N}", i.ToString());
                //Get Term
                // get info from hsx.vn
                if (!HttpPost(tempUrl, path))
                {
                    txtComment.AppendText("Không lấy được dữ liệu từ" + tempUrl + " !");
                    txtComment.AppendText(Environment.NewLine);
                }
                else
                {
                    txtComment.AppendText("Lấy xong dữ liệu từ " + tempUrl + "!");
                    txtComment.AppendText(Environment.NewLine);
                }
                tempUrl = url;
            }
        }

        private void ScanAlpha()
        {
            char cBegin = Convert.ToChar(txtAlphaBegin.Text);
            char cEnd = Convert.ToChar(txtAlphaEnd.Text);

            int begin = Convert.ToInt32(cBegin);
            int end = Convert.ToInt32(cEnd);

            string url = cboUrl.Text;
            string tempUrl = url;
            string path = PathSelect();
            for (int i = begin; i <= end; i++)
            {
                tempUrl = tempUrl.Replace("{A}", Convert.ToChar(i).ToString());
                //Get Term
                // get info from hsx.vn
                if (!HttpPost(tempUrl, path))
                {
                    txtComment.AppendText("Không lấy được dữ liệu từ" + tempUrl + " !");
                    txtComment.AppendText(Environment.NewLine);
                }
                else
                {
                    txtComment.AppendText("Lấy xong dữ liệu từ " + tempUrl + "!");
                    txtComment.AppendText(Environment.NewLine);
                }
                tempUrl = url;
            }
        }

        private void ScanBoth()
        {
            char cBegin = Convert.ToChar(txtAlphaBegin.Text);
            char cEnd = Convert.ToChar(txtAlphaEnd.Text);

            int alphaBegin = Convert.ToInt32(cBegin);
            int alphaEnd = Convert.ToInt32(cEnd);

            int begin = Convert.ToInt32(txtBegin.Text);
            int end = Convert.ToInt32(txtEnd.Text);


            string url = cboUrl.Text;
            string tempUrl = url;
            string path = PathSelect();
            for (int i = alphaBegin; i <= alphaEnd; i++)
            {
                for (int j = begin; j <= end; j++)
                {
                    tempUrl = tempUrl.Replace("{A}", Convert.ToChar(i).ToString());
                    tempUrl = tempUrl.Replace("{N}", j.ToString());
                    //Get Term
                    // get info from hsx.vn
                    if (!HttpPost(tempUrl, path))
                    {
                        txtComment.AppendText("Không lấy được dữ liệu từ" + tempUrl + " !");
                        txtComment.AppendText(Environment.NewLine);
                    }
                    else
                    {
                        txtComment.AppendText("Lấy xong dữ liệu từ " + tempUrl + "!");
                        txtComment.AppendText(Environment.NewLine);
                    }
                    tempUrl = url;
                }
            }
        }

        private void ScanGoolge()
        {
            string insite = cboUrl.Text;
            string url = "https://www.google.com/search?q=" + txtGoolgeSearch.Text + "+site:" + insite + "&ie=utf-8&oe=utf-8";

            //get search google content
            string content;
            int pos1, pos2, pos3;
            string tempUrl, tempContent;
            string path = PathSelect();
            //click next page
            string pageBegin = "<a class=\"fl\" href=\"/search?q=";
            string pageEnd;
            string search = "url?q=" + insite;
            int page = 1;
            while ((content = RequestContent(url)) != "")
            {
                tempContent = content;
                while ((pos1 = tempContent.IndexOf(search) + 6) != -1)
                {
                    if ((pos2 = tempContent.IndexOf(".html", pos1)) == -1) break;

                    tempUrl = tempContent.Substring(pos1, pos2 - pos1 + 5);
                    tempContent = tempContent.Substring(pos2, tempContent.Length - pos2);
                    if (tempUrl.StartsWith(insite))
                    {
                        content = tempContent;
                        if (!HttpPost(tempUrl, path))
                        {
                            txtComment.AppendText("Không lấy được dữ liệu từ" + tempUrl + " !");
                            txtComment.AppendText(Environment.NewLine);
                        }
                        else
                        {
                            txtComment.AppendText("Lấy xong dữ liệu từ " + tempUrl + "!");
                            txtComment.AppendText(Environment.NewLine);
                        }
                    }
                }
                url = "https://www.google.com/search?q=" + txtGoolgeSearch.Text + "+site:" + insite + "&ie=utf-8&oe=utf-8&start=" + (10 * page);
                page++;
                if (page == 100) break;
                //if (page > 1)
                //{
                //    pageEnd = "start=" + 10 * (page - 1) + "&amp;sa=N";
                //    content = content.Substring(content.IndexOf(pageEnd) + pageEnd.Length);
                //}
                //pos1 = content.IndexOf(pageBegin) + pageBegin.Length - 10;
                //if (pos1 == -1) return;
                //pageEnd = "start=" + 10 * page + "&amp;sa=N";
                //pos2 = content.IndexOf(pageEnd, pos1) + pageEnd.Length;
                //pos3 = content.IndexOf("\">", pos2);
                //page++;
                //url = "https://www.google.com" + content.Substring(pos1 , pos3 - pos1);
            }
        }

        private string RequestContent(string uri)
        {
            //// parameters: name1=value1&name2=value2   
            ////WebRequest webRequest = WebRequest.Create(uri);
            //HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(uri);
            ////string ProxyString =
            //// System.Configuration.ConfigurationManager.AppSettings
            //// [GetConfigKey("proxy")];
            ////webRequest.Proxy = new WebProxy (ProxyString, true);
            ////Commenting out above required change to App.Config
            ////webRequest.ContentType = "application/x-www-form-urlencoded";
            //webRequest.Method = "POST";
            //webRequest.UserAgent = @"Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.8.0.4) Gecko/20060508 Firefox/1.5.0.4";

            ////webRequest.
            ////byte[] bytes = Encoding.ASCII.GetBytes (sParam);
            //Stream os = null;
            //try
            //{ // send the Post
            //    //webRequest.ContentLength = bytes.Length; //Count bytes to send
            //    os = webRequest.GetRequestStream();
            //    //os.Write (bytes, 0, bytes.Length); //Send it
            //}
            //catch (WebException ex)
            //{
            //    return "";
            //}
            //finally
            //{
            //    if (os != null)
            //    {
            //        os.Close();
            //    }
            //}

            //try
            //{ // get the response
            //    WebResponse webResponse = webRequest.GetResponse();
            //    if (webResponse == null)
            //    { return ""; }
            //    StreamReader reader = new StreamReader(webResponse.GetResponseStream());
            //    string content = reader.ReadToEnd();
            //    webResponse.Close();
            //    return content;
            //}
            //catch (WebException ex)
            //{
            //    return "";
            //}

            string html;
            try
            {
                var myUri = new Uri(uri);
                // Create a 'HttpWebRequest' object for the specified url. 
                var myHttpWebRequest = (HttpWebRequest)WebRequest.Create(myUri);
                // Set the user agent as if we were a web browser
                myHttpWebRequest.UserAgent = @"Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.8.0.4) Gecko/20060508 Firefox/1.5.0.4";

                var myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
                var stream = myHttpWebResponse.GetResponseStream();
                var reader = new StreamReader(stream);
                html = reader.ReadToEnd();
                // Release resources of response object.
                myHttpWebResponse.Close();
            }
            catch (WebException ex)
            {
                using (var sr = new StreamReader(ex.Response.GetResponseStream()))
                    html = sr.ReadToEnd();
            }
            txtComment.AppendText("Lấy xong dữ liệu từ " + uri + "!");
            txtComment.AppendText(Environment.NewLine);
            return html;
        } // end HttpPost



        private bool HttpPost(string uri, string sPath)
        {
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
                StreamReader reader = new StreamReader(webResponse.GetResponseStream());
                string content = reader.ReadToEnd();
                webResponse.Close();
                switch ((int)cboType.SelectedValue)
                {
                    case 7001: //Books
                        BookAuto(content, uri);
                        break;
                    case 7002: //Knowledge
                        KnowledgeAuto(content, uri);
                        break;
                    case 7003: //Term
                        TermAuto(content, uri);
                        break;
                }
                
                return true;
            }
            catch (WebException ex)
            {
                return false;
            }
        } // end HttpPost

        private void KnowledgeAuto(string content, string url)
        {
            int pos1, pos2 = 0, i, posIndex = 0;
            string[] sourceObj = new string[colsCount];
            while (chkLoop.Checked)
            {
                sourceObj[1] = itemTypeId.ToString();
                for (i = 0; i < colsCount; i++)
                {
                    if (lstOrder[i, 0] != null && lstOrder[i, 0].Length > 0)
                    {
                        pos1 = content.IndexOf(lstOrder[i, 0]) + lstOrder[i, 0].Length;
                        if (pos1 == -1) return;
                        pos2 = content.IndexOf(lstOrder[i, 1], pos1);
                        if (pos2 == -1) return;
                        posIndex = Convert.ToInt32(lstOrder[i, 3]);
                        sourceObj[posIndex] = content.Substring(pos1, pos2 - pos1);
                        content = content.Substring(pos2 + lstOrder[i, 1].Length);
                        //remove href: href="/thuat-ngu/audit-viec-kiem-toan~6423">
                        pos1 = sourceObj[posIndex].IndexOf("href=\"");
                        if (pos1 > -1)
                            pos2 = sourceObj[posIndex].IndexOf("\">", pos1);
                        if (pos1 >= 0 && pos2 >= 0)
                            sourceObj[posIndex] = sourceObj[posIndex].Substring(pos2 + 2);
                        while ((pos1 = sourceObj[posIndex].IndexOf('<')) != -1)
                        {
                            pos2 = sourceObj[posIndex].IndexOf('>', pos1);
                            if (pos2 == -1) break;
                            sourceObj[posIndex] = sourceObj[posIndex].Replace(sourceObj[posIndex].Substring(pos1, pos2 - pos1 + 1), "");
                        }
                        sourceObj[posIndex] = sourceObj[posIndex].Replace("\t", "");
                        sourceObj[posIndex] = sourceObj[posIndex].Replace("\n", "");
                    }
                }
                sourceObj[posIndex + 1] = url;
                sourceObj[posIndex + 2] = "False";
                //if (sourceObj[3].Length > 500 || sourceObj[2].Length > 500) return;
                db.KnowledgeInsert(sourceObj);
            }

        }


        private void TermAuto(string content, string url)
        {
            int pos1, pos2 = 0, i, posIndex;
            string[] sourceObj = new string[colsCount];
            while (chkLoop.Checked)
            {
                sourceObj[1] = itemTypeId.ToString();
                for (i = 0; i < colsCount; i++)
                {
                    if (lstOrder[i, 0] != null && lstOrder[i, 0].Length > 0)
                    {
                        pos1 = content.IndexOf(lstOrder[i, 0]) + lstOrder[i, 0].Length;
                        if (pos1 == -1) return;
                        pos2 = content.IndexOf(lstOrder[i, 1], pos1);
                        if (pos2 == -1) return;
                        posIndex = Convert.ToInt32(lstOrder[i, 3]);
                        sourceObj[posIndex] = content.Substring(pos1, pos2 - pos1);
                        content = content.Substring(pos2 + lstOrder[i, 1].Length);
                        //remove href: href="/thuat-ngu/audit-viec-kiem-toan~6423">
                        pos1 = sourceObj[posIndex].IndexOf("href=\"");
                        if (pos1 > -1)
                            pos2 = sourceObj[posIndex].IndexOf("\">", pos1);
                        if (pos1 >= 0 && pos2 >= 0)
                            sourceObj[posIndex] = sourceObj[posIndex].Substring(pos2 + 2);
                        while ((pos1 = sourceObj[posIndex].IndexOf('<')) != -1)
                        {
                            pos2 = sourceObj[posIndex].IndexOf('>', pos1);
                            if (pos2 == -1) break;
                            sourceObj[posIndex] = sourceObj[posIndex].Replace(sourceObj[posIndex].Substring(pos1, pos2 - pos1 + 1), "");
                        }
                        sourceObj[posIndex] = sourceObj[posIndex].Replace("\t", "");
                    }
                }
                sourceObj[i - 1] = url;
                if (sourceObj[3].Length > 500 || sourceObj[2].Length > 500) return;
                db.TermInsert(sourceObj);
            }

        }

        private void OrderUpdate()
        {
            lst = new string[colsCount, 3];            
            for (int i = 0; i < colsCount; i++)
            {
                lst[i, 2] = ((TextBox)this.Controls[controlCount + i * next + 3]).Text;
                if (lst[i, 2] != null)
                {
                    lst[i, 0] = ((TextBox)this.Controls[controlCount + i * next + 1]).Text;
                    lst[i, 1] = ((TextBox)this.Controls[controlCount + i * next + 2]).Text;
                }
            }
        }

        private void BookAuto(string content, string url)
        {
            int pos1 = 0, pos2 = 0, i;                   
            
            string[] sourceObj = new string[colsCount];
            sourceObj[1] = itemTypeId.ToString();
          
            for (i = 0; i < colsCount; i++)
            {
                if (lst[i,0].Length > 0)
                {
                    pos1 = content.IndexOf(lst[i, 0], pos2) + lst[i, 0].Length;
                    if (pos1 == -1) return;
                    pos2 = content.IndexOf(lst[i, 1], pos1);
                    if (pos2 == -1) return;
                    sourceObj[i] = content.Substring(pos1, pos2 - pos1);
                    //remove href: href="/thuat-ngu/audit-viec-kiem-toan~6423">
                    pos1 = sourceObj[i].IndexOf("href=\"");
                    pos2 = sourceObj[i].IndexOf("\">", pos1);
                    if (pos1 >= 0 && pos2 >= 0)
                        sourceObj[i] = sourceObj[i].Substring(pos2 + 2);
                    while ((pos1 = sourceObj[i].IndexOf('<')) != -1)
                    {
                        pos2 = sourceObj[i].IndexOf('>', pos1);
                        if (pos2 == -1) break;
                        sourceObj[i] = sourceObj[i].Replace(sourceObj[i].Substring(pos1, pos2 - pos1 + 1), "");
                    }
                    sourceObj[i] = sourceObj[i].Replace("\t", "");

                }
            }

            sourceObj[i - 1] = url;

            db.EbookInsert(sourceObj);
        }

        private void cboUrl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboUrl.SelectedIndex == -1) return;
            cboType.SelectedIndex = -1;
            cboType.SelectedValue = db.TypeByUrl(Convert.ToInt32(cboUrl.SelectedValue));
            Url obj = db.UrlGet(Convert.ToInt32(cboUrl.SelectedValue));
            txtBegin.Text = obj.ValueFrom.ToString();
            txtEnd.Text = obj.ValueTo.ToString();
            txtAlphaBegin.Text = obj.AlphaFrom;
            txtAlphaEnd.Text = obj.AlphaTo;
            txtGoolgeSearch.Text = obj.Search;
            chkGoolge.Checked = obj.Google.Value;
            chkLoop.Checked = obj.Loop.Value;
        }

        private void btnSaveUrl_Click(object sender, EventArgs e)
        {
            OrderUpdate();
            if (txtGoolgeSearch.Text.Length > 0) chkGoolge.Checked = true;
            db.UrlDetailInsert(db.UrlInsert(cboUrl.Text, Convert.ToInt32(cboType.SelectedValue), chkLoop.Checked, chkGoolge.Checked, txtGoolgeSearch.Text), lst);
        }
    }
}
