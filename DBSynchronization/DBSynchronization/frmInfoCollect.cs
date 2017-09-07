using DBSynchronization.DataContext;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using WindowFramework;

namespace DBSynchronization
{
    public partial class frmInfoCollect : Form
    {
        LibDB db = new LibDB();
        public string dbName, sqlConn;
        int controlCount, next = 7, colsCount, itemTypeId;
        string[,] lst, lstOrder;
        public frmInfoCollect()
        {
            InitializeComponent();
        }

        private void cboTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTable.SelectedIndex == -1) return;

            int urlId;
            TableRequest obj = db.TableRequestByName(cboTable.Text, out urlId);

            if (obj == null)
            {
                cboUrl.Text = "";
                cboUrl.SelectedIndex = -1;
            }
            else
            {
                cboUrl.SelectedValue = urlId;
                chkDaily.Checked = obj.IsDaily.Value;
                Url url = db.UrlGet((int)cboUrl.SelectedValue);
                txtPath.Text = url.StorePath;
                txtAlphaBegin.Text = url.AlphaFrom;
                txtAlphaEnd.Text = url.AlphaTo;
                txtBegin.Text = url.ValueFrom == null ? null : url.ValueFrom.ToString();
                txtEnd.Text = url.ValueTo == null ? null : url.ValueTo.ToString();

            }

            while (this.Controls.Count > controlCount)
            {
                this.Controls.RemoveAt(controlCount);
            }
            //List<string> cols = db.GetColumns(cboTable.Text, dbName);
            string[,] colWithType = db.GetColumnswithType(cboTable.Text, dbName);
            //IEnumerator<string> cols = db.ColumnName(cboTable.Text).GetEnumerator();
            List<UrlDetail> lst = null;
            if (cboUrl.SelectedIndex != -1)
                lst = db.UrlDetailGet((int)cboUrl.SelectedValue);
            int j = 0;
            int count = colWithType.Length/2;
            TextBox t;
            ComboBox b = new ComboBox();
            for (int i = 0; i < count; i++ )
            {
                t = new TextBox();
                t.Text = colWithType[i, 0];
                t.Name = t.Text;
                t.Location = new Point(10, 65 + 25 * i);
                this.Controls.Add(t);

                for (int k = 1; k < 6; k++)
                {
                    t = new TextBox();
                    t.Location = new Point(10 + 110 * k, 65 + 25 * i);
                    this.Controls.Add(t);
                }
                if (colWithType[i, 1] == "int")
                {
                    b = new ComboBox();
                    b.DataSource = db.ExecuteQueryForCbo("select Id, DefGroup From DefinitionGroup", dbName);
                    b.DisplayMember = "DefGroup";
                    b.ValueMember = "Id";
                    b.Location = new Point(10 + 110 * 6, 65 + 25 * i);
                    this.Controls.Add(b);
                }
                else
                    this.Controls.Add(new Label());
                //insert value to textboxes
                if (lst != null && j < lst.Count && lst[j].FieldNum == i)
                {
                    t = (TextBox)this.Controls[controlCount + i * next + 1];
                    t.Text = lst[j].SearchSkip;
                    t = (TextBox)this.Controls[controlCount + i * next + 2];
                    t.Text = lst[j].SearchBegin;
                    t = (TextBox)this.Controls[controlCount + i * next + 3];
                    t.Text = lst[j].SearchEnd;
                    t = (TextBox)this.Controls[controlCount + i * next + 4];
                    t.Text = lst[j].FieldOrder.ToString();
                    t = (TextBox)this.Controls[controlCount + i * next + 5];
                    t.Text = colWithType[i, 1];
                    if (colWithType[i, 1] == "int")
                    {
                        b = (ComboBox)this.Controls[controlCount + i * next + 6];
                        if (lst[j].DefGroup == 0)
                        {
                            b.SelectedValue = 0;
                            b.SelectedText = "";
                        }
                        else
                            b.SelectedValue = lst[j].DefGroup;
                    }
                    j++;
                }
            }
            colsCount = count;
            //SetValue();
            if (lst!= null)
                OrderUpdate();

        }

        private void frmInfoCollect_Load(object sender, EventArgs e)
        {
            db.conn = sqlConn;
            db.OpenConnection();
            controlCount = this.Controls.Count;

            List<string> list = db.GetTables(dbName);
            cboTable.Items.Clear();
            foreach (string item in list)
                cboTable.Items.Add(item);

            cboUrl.DisplayMember = "Url1";
            cboUrl.ValueMember = "Id";
            cboUrl.DataSource = db.UrlList();

            cboContentType.DisplayMember = "CodeNum";
            cboContentType.ValueMember = "Id";
            cboContentType.DataSource = db.DefinitionList(1);

        }

        private void btnCollect_Click(object sender, EventArgs e)
        {
            itemTypeId = Convert.ToInt32(cboItemType.SelectedValue);
            int alpha = cboUrl.Text.IndexOf("{A}");
            int num = cboUrl.Text.IndexOf("{N}");
            ////get order condition
            //lstOrder = new string[colsCount, 4];
            //int pos;
            //for (int i = 0; i < colsCount; i++ )
            //{
            //    if (lst[i, 2].Length > 0)
            //    {
            //        pos = Convert.ToInt32(lst[i, 2]) - 1;
            //        lstOrder[pos, 0] = lst[i, 0];
            //        lstOrder[pos, 1] = lst[i, 1];
            //        lstOrder[pos, 2] = lst[i, 2];
            //        lstOrder[pos, 3] = i.ToString();
            //    }
                    
            //}

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
            if (txtPath.Text.Length != 0) return txtPath.Text + @"\";
            string path = Application.StartupPath + @"\Data\";
            switch ((int)cboTable.SelectedIndex)
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
                if (!WebLib.HttpPost(tempUrl, path, i))
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
                if (!WebLib.HttpPost(tempUrl, path, i))
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
                    if (!WebLib.HttpPost(tempUrl, path, j))
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
            int page = 1, i = 1;
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
                        if (!WebLib.HttpPost(tempUrl, path, i))
                        {
                            txtComment.AppendText("Không lấy được dữ liệu từ" + tempUrl + " !");
                            txtComment.AppendText(Environment.NewLine);
                        }
                        else
                        {
                            txtComment.AppendText("Lấy xong dữ liệu từ " + tempUrl + "!");
                            txtComment.AppendText(Environment.NewLine);
                        }
                        i++;
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


        private void OrderUpdate()
        {
            lst = new string[colsCount, 6];
            for (int i = 0; i < colsCount; i++)
            {
                lst[i, 2] = ((TextBox)this.Controls[controlCount + i * next + 3]).Text;
                if (lst[i, 2] != null)
                {
                    lst[i, 0] = ((TextBox)this.Controls[controlCount + i * next + 1]).Text;
                    lst[i, 1] = ((TextBox)this.Controls[controlCount + i * next + 2]).Text;
                    lst[i, 3] = ((TextBox)this.Controls[controlCount + i * next + 4]).Text;
                    lst[i, 4] = ((TextBox)this.Controls[controlCount + i * next + 5]).Text;
                    if (this.Controls[controlCount + i * next + 6].GetType().Name == "ComboBox")
                        lst[i, 5] = ((ComboBox)this.Controls[controlCount + i * next + 6]).SelectedValue == null ? null : ((ComboBox)this.Controls[controlCount + i * next + 6]).SelectedValue.ToString();
                }
            }
        }

        private void cboUrl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboUrl.SelectedIndex == -1) return;
            //cboTable.SelectedIndex = -1;
            cboTable.SelectedItem = db.TableNameByUrl(Convert.ToInt32(cboUrl.SelectedValue),dbName);
            Url obj = db.UrlGet(Convert.ToInt32(cboUrl.SelectedValue));
            if (obj != null)
            {
                txtBegin.Text = obj.ValueFrom.ToString();
                txtEnd.Text = obj.ValueTo.ToString();
                txtAlphaBegin.Text = obj.AlphaFrom;
                txtAlphaEnd.Text = obj.AlphaTo;
                txtGoolgeSearch.Text = obj.Search;
                chkGoolge.Checked = obj.Google.Value;
                chkLoop.Checked = obj.Loop.Value;
                chkHttpPost.Checked = obj.HttpPost.Value;
                cboContentType.SelectedValue = obj.ContentTypeId.Value;
            }
        }

        private void btnSaveUrl_Click(object sender, EventArgs e)
        {
            OrderUpdate();
            if (txtGoolgeSearch.Text.Length > 0) chkGoolge.Checked = true;
            int tableId = db.TableRequestAdd(cboTable.Text, chkDaily.Checked);
            int from = 0, to = 0;
            try
            {
                from = Convert.ToInt32(txtBegin.Text);
            }
            catch (Exception) { }

            try
            {
                to = Convert.ToInt32(txtEnd.Text);
            }
            catch (Exception) { }


            db.UrlDetailInsert(db.UrlInsert(cboUrl.Text, tableId, chkLoop.Checked, chkGoolge.Checked, txtGoolgeSearch.Text, from, to, txtAlphaBegin.Text, txtAlphaEnd.Text, txtPath.Text, chkHttpPost.Checked, Convert.ToInt32(cboContentType.SelectedValue)), lst);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (dlgBrowse.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = dlgBrowse.SelectedPath;
            }
        }

        private void btnStoreData_Click(object sender, EventArgs e)
        {

        }
    }
}
