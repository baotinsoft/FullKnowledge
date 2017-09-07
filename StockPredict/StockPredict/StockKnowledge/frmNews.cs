using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using StockKnowledge.DBContext;
using System.IO;

namespace StockKnowledge
{
    public partial class frmNews : Form
    {
        int iId;
        DBKnowledge db = new DBKnowledge();
        public frmNews()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (iId > 0) db.NewsEdit(iId, txtName.Text, rtbDetail.Text, Convert.ToInt32(cboNewsType.SelectedValue), chkGood.Checked, Convert.ToInt32(cboBranch.SelectedValue), Convert.ToInt32(cboStock.SelectedValue), dtPublish.Value.Date, txtLink.Text);
            else db.NewsInsert(txtName.Text, rtbDetail.Text, Convert.ToInt32(cboNewsType.SelectedValue), chkGood.Checked, Convert.ToInt32(cboBranch.SelectedValue), Convert.ToInt32(cboStock.SelectedValue), dtPublish.Value.Date, txtLink.Text);
            DataLoad();
            DataReset();
        }

        private void frmNews_Load(object sender, EventArgs e)
        {
            DataLoad();
        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            iId = Convert.ToInt32(dgvList.Rows[e.RowIndex].Cells[0].Value);
            txtName.Text = Convert.ToString(dgvList.Rows[e.RowIndex].Cells[1].Value);
            rtbDetail.Text = Convert.ToString(dgvList.Rows[e.RowIndex].Cells[2].Value);
            dtPublish.Value = Convert.ToDateTime(dgvList.Rows[e.RowIndex].Cells[3].Value);
            cboNewsType.SelectedValue = Convert.ToInt32(dgvList.Rows[e.RowIndex].Cells[4].Value);
            chkGood.Checked = Convert.ToBoolean(dgvList.Rows[e.RowIndex].Cells[5].Value);
            cboBranch.SelectedValue = Convert.ToInt32(dgvList.Rows[e.RowIndex].Cells[6].Value);
            cboStock.SelectedValue = Convert.ToInt32(dgvList.Rows[e.RowIndex].Cells[7].Value);
            txtLink.Text = dgvList.Rows[e.RowIndex].Cells[8].Value.ToString();
        }

        private void DataLoad()
        {
            dgvList.DataSource = db.NewsList();

            cboNewsType.ValueMember = "Id";
            cboNewsType.DisplayMember = "Name";
            cboNewsType.DataSource = db.DefinitionList(4);

            cboBranch.ValueMember = "Id";
            cboBranch.DisplayMember = "Branch1";
            cboBranch.DataSource = db.BranchList();

            cboStock.ValueMember = "Id";
            cboStock.DisplayMember = "Code";
            cboStock.DataSource = db.StockList();
        }

        private void DataReset()
        {
            iId = 0;
            txtName.Text = "";
            rtbDetail.Text = "";
            chkGood.Checked = false;
            cboNewsType.SelectedIndex = 0;
            cboStock.SelectedIndex = 0;
            cboBranch.SelectedIndex = 0;
        }

        private void btnAuto_Click(object sender, EventArgs e)
        {
            txtMessage.Text = "";
            int pageAll = chkAll.Checked ? 308 : 2;
            List<string>urls = db.GetUrls(10002);
            string dir = Application.StartupPath + @"\Data\News\";
            // get info from hsx.vn
            int orderNum = 1;
            foreach (string url in urls)
            {
                if (!WebLib.HttpPost(url, dir, orderNum, ""))
                {
                    txtMessage.AppendText("Không lấy được dữ liệu từ url:" + url);
                    txtMessage.AppendText(Environment.NewLine);
                }
                else
                {
                    txtMessage.AppendText("Lấy xong dữ liệu từ url" + url);
                    txtMessage.AppendText(Environment.NewLine);
                    orderNum++;
                }
            }


            //import data
            string[] files = Directory.GetFiles(dir);
            StreamReader read;
            string content;
            string[] data = new string[4];
            int pos, len, typeId;
            string file = dir + WebLib.GetDateName() + "-";
            string file1;
            for (int page = 1; page < orderNum; page++)
            {
                file1 = file;
                file1 += page + ".htm";
                read = new StreamReader(file1);
                content = read.ReadToEnd();
                //http://www.psi.vn
                typeId = db.UrlType(urls[page-1]);
                if (urls[page-1].Substring(0, "http://www.psi.vn".Length) == "http://www.psi.vn")
                {
                    while ((pos = content.IndexOf("<item>")) != -1)
                    {
                        content = content.Substring(pos + 21);
                        pos = content.IndexOf("</title>");
                        data[0] = content.Substring(0, pos); // title

                        content = content.Substring(pos + 21);
                        pos = content.IndexOf("</link>");
                        data[1] = content.Substring(0, pos); // link


                        content = content.Substring(pos + 28);
                        pos = content.IndexOf("</description>");
                        data[2] = content.Substring(0, pos); // description

                        content = content.Substring(pos + 49);
                        pos = content.IndexOf("</pubDate>");
                        data[3] = content.Substring(0, pos);
                        if (db.NewsInsert(data[0], data[2], typeId, false, 0, 0, Convert.ToDateTime(data[3]), data[1]) == 0)
                        {
                            txtMessage.Text += "Dữ liệu bị trùng: " + parseArray(data) + "!\r\n";
                            break;
                        }
                    }
                }
                else
                {
                    while ((pos = content.IndexOf("<item>")) != -1)
                    {
                        content = content.Substring(pos + 13);
                        pos = content.IndexOf("</title>");
                        data[0] = content.Substring(0, pos); //title

                        content = content.Substring(pos + 25);
                        pos = content.IndexOf("/>");
                        content = content.Substring(pos + 2);
                        pos = content.IndexOf("</description>");
                        data[1] = content.Substring(0, pos); //description

                        content = content.Substring(pos + 20);
                        pos = content.IndexOf("</link>");
                        data[2] = content.Substring(0, pos); //link

                        content = content.Substring(pos + 16);
                        pos = content.IndexOf("</pubDate>");
                        data[3] = content.Substring(0, pos);


                        if (db.NewsInsert(data[0], data[1], typeId, false, 0, 0, Convert.ToDateTime(data[3]), data[2]) == 0)
                        {
                            txtMessage.Text += "Dữ liệu bị trùng: " + parseArray(data) + "!\r\n";
                            break;
                        }
                    }
                }
                
                txtMessage.Text += "Xử lý xong file " + file1 + "!\r\n";
                read.Close();
            }
            txtMessage.Text += "Xử lý hoan tat!";
            ClearFolder(dir);


        }

        private string parseArray(string[] arr)
        {
            string sReturn = "";
            foreach (string s in arr)
                sReturn += s + ";";
            return sReturn;
        }

        private void ClearFolder(string FolderName)
        {
            DirectoryInfo dir = new DirectoryInfo(FolderName);

            foreach (FileInfo fi in dir.GetFiles())
            {
                fi.IsReadOnly = false;
                fi.Delete();
            }

            foreach (DirectoryInfo di in dir.GetDirectories())
            {
                ClearFolder(di.FullName);
                di.Delete();
            }
        }

        private void frmNews_SizeChanged(object sender, EventArgs e)
        {
            dgvList.Width = this.Width - dgvList.Location.X - 10;
            dgvList.Height = this.Height - dgvList.Location.Y - 10;
            txtMessage.Height = this.Height - txtMessage.Location.Y - 10;

        }
    }
}
