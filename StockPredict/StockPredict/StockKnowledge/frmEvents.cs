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
    public partial class frmEvents : Form
    {
        int iId, iDateCount = 3;
        bool[] lstExistDate;

        DBKnowledge db = new DBKnowledge();
        public frmEvents()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (iId > 0) db.EventEdit(iId, rtbDetail.Text, Convert.ToInt32(cboEventType.SelectedValue), Convert.ToInt32(cboStock.SelectedValue), dtLastRegisterDate.Value.Date, dtNoRightDate.Value.Date, dtExecuteDate.Value.Date, Convert.ToInt32(cboMethod.SelectedValue), Convert.ToDecimal(txtValue.Text), lstExistDate);
            else db.EventInsert(rtbDetail.Text, Convert.ToInt32(cboEventType.SelectedValue), Convert.ToInt32(cboStock.SelectedValue), dtLastRegisterDate.Value.Date, dtNoRightDate.Value.Date, dtExecuteDate.Value.Date, Convert.ToInt32(cboMethod.SelectedValue), Convert.ToDecimal(txtValue.Text), lstExistDate);
            DataLoad();
            DataReset();
        }

        private void frmEvents_Load(object sender, EventArgs e)
        {
            lstExistDate = new bool[iDateCount];
            for (int i = 0; i < iDateCount; i++) lstExistDate[i] = true;
            DataLoad();
        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            iId = Convert.ToInt32(dgvList.Rows[e.RowIndex].Cells[0].Value);
            cboStock.SelectedValue = Convert.ToInt32(dgvList.Rows[e.RowIndex].Cells[1].Value);
            try
            {
                dtNoRightDate.Value = Convert.ToDateTime(dgvList.Rows[e.RowIndex].Cells[2].Value);
                lstExistDate[0] = true;
            }
            catch (Exception) { lstExistDate[0] = false; }

            try
            {
                dtLastRegisterDate.Value = Convert.ToDateTime(dgvList.Rows[e.RowIndex].Cells[3].Value);
                lstExistDate[1] = true;
            }
            catch (Exception) { lstExistDate[1] = false; }

            try
            {
                dtExecuteDate.Value = Convert.ToDateTime(dgvList.Rows[e.RowIndex].Cells[4].Value);
                lstExistDate[2] = true;
            }
            catch (Exception) { lstExistDate[2] = false; }

            rtbDetail.Text = Convert.ToString(dgvList.Rows[e.RowIndex].Cells[5].Value);
            txtValue.Text = Convert.ToString(dgvList.Rows[e.RowIndex].Cells[6].Value);                                  
            cboEventType.SelectedValue = Convert.ToInt32(dgvList.Rows[e.RowIndex].Cells[7].Value);
            cboMethod.SelectedValue = Convert.ToInt32(dgvList.Rows[e.RowIndex].Cells[8].Value);
            
        }

        private void DataLoad()
        {            
            dgvList.DataSource = db.EventList();

            cboEventType.ValueMember = "Id";
            cboEventType.DisplayMember = "Name";
            cboEventType.DataSource = db.DefinitionListForCbo(3);

            cboMethod.ValueMember = "Id";
            cboMethod.DisplayMember = "En";
            cboMethod.DataSource = db.DefinitionListForCbo(6);

            cboStock.ValueMember = "Id";
            cboStock.DisplayMember = "Code";
            cboStock.DataSource = db.StockListForCbo();
        }

        private void DataReset()
        {
            iId = 0;
            txtValue.Text = "";
            rtbDetail.Text = "";
            cboEventType.SelectedIndex = 0;
            cboStock.SelectedIndex = 0;
            cboMethod.SelectedIndex = 0;
            dtExecuteDate.Value = DateTime.Now;
            dtLastRegisterDate.Value = DateTime.Now;
            dtNoRightDate.Value = DateTime.Now;
        }

        private void btnCal_Click(object sender, EventArgs e)
        {
            string sourceMethod;
            txtResult.Text = db.CalculatorGet(iId, out sourceMethod, txtValue.Text, Convert.ToDecimal(txtCurPrice.Text)).ToString();
            txtMethod.Text = sourceMethod;
        }

        private void frmEvents_SizeChanged(object sender, EventArgs e)
        {
            dgvList.Width = this.Width - dgvList.Location.X - 10;
            dgvList.Height = this.Height - dgvList.Location.Y - 10;
            txtMessage.Height = this.Height - txtMessage.Location.Y - 10;
        }

        private void btnAuto_Click(object sender, EventArgs e)
        {
             Auto();
        }

        
        private void Auto()
        {
            txtMessage.Text = "";
            int pageAll = chkAll.Checked ? 308 : 2;
            string url = db.GetUrls(10001)[0];
            string temp;
            string dir = Application.StartupPath + @"\Data\Event\";
            // get info from hsx.vn
            for (int page = 1; page < pageAll; page++)
            {
                temp = url.Replace("currentPage=1", "currentPage=" + page);
                if (!WebLib.HttpPost(temp, dir, page, ""))
                {
                    txtMessage.AppendText("Không lấy được lịch sự kiện từ cophieu68.vn!");
                    txtMessage.AppendText(Environment.NewLine);
                }
                else
                {
                    txtMessage.AppendText("Lấy xong lịch sự kiện từ cophieu68.vn!");
                    txtMessage.AppendText(Environment.NewLine);
                }
            }

            //import data
            string[] files = Directory.GetFiles(dir);
            StreamReader read;
            string line;
            string[] data = new string[6];
            int pos;
            string file = dir + WebLib.GetDateName() + "-";
            string file1;
            for (int page = 1; page < pageAll; page++)
            {
                file1 = file;
                file1 += page + ".htm";
                read = new StreamReader(file1);
                while ((line = read.ReadLine()) != null)
                {
                    if (line.IndexOf("<td class=\"td_bottom3 td_bg1\"><a href=\"eventschedule.php?id=") < 0) continue;
                    pos = line.IndexOf("id=") + 3;
                    data[0] = line.Substring(pos, line.IndexOf("\"><strong>") - pos);
                    for (int i = 0; i < 3; i++)
                    {
                        line = read.ReadLine();
                        pos = line.IndexOf("\">") + 2;
                        data[i + 1] = line.Substring(pos, line.IndexOf("</td>") - pos);
                    }
                    line = read.ReadLine();
                    line = read.ReadLine();
                    pos = 6;
                    data[4] = line.Substring(pos, line.IndexOf("\t", pos) - pos);

                    line = read.ReadLine();
                    line = read.ReadLine();
                    pos = line.IndexOf("\t", 7);
                    data[5] = line.Substring(6, line.Length - pos);
                    if (db.EventInsert(data) == 0)
                    {
                        txtMessage.Text += "Dữ liệu bị trùng: " + parseArray(data) + "!\r\n";
                        break;
                    }
                }
                txtMessage.Text += "Xử lý xong file " + file1 + "!\r\n";
                read.Close();
            }
            txtMessage.Text += "Xử lý hoan tat!";
            ClearFolder(dir);
            dgvList.DataSource = db.EventList();
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

        private void btnFilter_Click(object sender, EventArgs e)
        {
            dgvList.DataSource = db.EventList((int)cboStock.SelectedValue, (int)cboEventType.SelectedValue);
        }

        private void txtStockSearch_TextChanged(object sender, EventArgs e)
        {
            dgvList.DataSource = db.EventList(txtStockSearch.Text);
        }

        //private void AutoCurrent()
        //{
        //    string url = db.SourceDefinitionList(7)[0].CodeNum;
        //    url = "http://www.cophieu68.vn/events.php?currentPage=1&stockname=&event_type=";
        //    string temp;
        //    string dir = Application.StartupPath + @"\Data\Event\";
        //    // get info from hsx.vn
        //    temp = url.Replace("currentPage=1", "currentPage=" + 1);
        //    if (!WebLib.HttpPost(temp, dir, 1))
        //    {
        //        txtMessage.AppendText("Không lấy được lịch sự kiện từ cophieu68.vn!");
        //        txtMessage.AppendText(Environment.NewLine);
        //    }
        //    else
        //    {
        //        txtMessage.AppendText("Lấy xong lịch sự kiện từ cophieu68.vn!");
        //        txtMessage.AppendText(Environment.NewLine);
        //    }

        //    //import data
        //    string[] files = Directory.GetFiles(dir);
        //    StreamReader read;
        //    string line;
        //    string[] data = new string[6];
        //    int pos;
        //    string file = dir + @"\" + WebLib.GetDateName() + "-1.htm";
        //    read = new StreamReader(file);
        //    while ((line = read.ReadLine()) != null)
        //    {
        //        if (line.IndexOf("<td class=\"td_bottom3 td_bg1\"><a href=\"eventschedule.php?id=") < 0) continue;
        //        pos = line.IndexOf("id=") + 3;
        //        data[0] = line.Substring(pos, line.IndexOf("\"><strong>") - pos);
        //        for (int i = 0; i < 3; i++)
        //        {
        //            line = read.ReadLine();
        //            pos = line.IndexOf("\">") + 2;
        //            data[i + 1] = line.Substring(pos, line.IndexOf("</td>") - pos);
        //        }
        //        line = read.ReadLine();
        //        line = read.ReadLine();
        //        pos = 6;
        //        data[4] = line.Substring(pos, line.IndexOf("\t", pos) - pos);

        //        line = read.ReadLine();
        //        line = read.ReadLine();
        //        pos = line.IndexOf("\t", 7);
        //        data[5] = line.Substring(6, line.Length - pos);
        //        db.EventInsert(data);                
        //    }
        //    txtMessage.Text += "Xử lý xong file " + file + "!\r\n";
        //    read.Close();
        //    Directory.Delete(dir);
        //}
    }
}
