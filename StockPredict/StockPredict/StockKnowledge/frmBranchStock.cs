using System;
using System.Drawing;
using System.Windows.Forms;
using StockKnowledge.DBContext;
using System.IO;
using System.Collections.Generic;

namespace StockKnowledge
{
    public partial class frmBranchStock : Form
    {
        int iId, iGroupId;
        DBKnowledge db = new DBKnowledge();

        public frmBranchStock()
        {
            InitializeComponent();
        }

        private void frmDefinition_SizeChanged(object sender, EventArgs e)
        {
            dgvList.Height = this.Height - dgvList.Location.Y - 40;
            dgvStock.Height = this.Height - dgvStock.Location.Y - 40;
            dgvStock.Width = this.Width - dgvStock.Location.X - 30;
        }

        private void frmDefinition_Load(object sender, EventArgs e)
        {
            string[,] controls = db.GetColumnswithType("Branch");
            TextBox txt;
            ComboBox cbo;
            Label lbl;
            int w = 200, h = 30, s = 4;
            for(int i=0; i<controls.Length/2; i++)
            {
                lbl = new Label();
                lbl.Text = controls[i, 0] + ":";
                lbl.Location = new Point(2*(i % s) * w, h * (i / s));
                this.Controls.Add(lbl);
                if (controls[i,0].IndexOf("Id") != -1)
                {
                    cbo = new ComboBox();
                    cbo.Name = "cbo" + controls[i, 0];
                    switch (controls[i,0])
                    {
                        case "GroupId":                            
                            cbo.DataSource = db.BranchListForCbo();
                            cbo.ValueMember = "Id";
                            cbo.DisplayMember = "Branch1";
                            break;
                        case "FiveBasicElementId":
                            cbo.DataSource = db.DefinitionListForCbo(11);
                            cbo.ValueMember = "Id";
                            cbo.DisplayMember = "Name";
                            break;
                    }
                    cbo.Width = w;
                    cbo.Location = new Point((2*(i % s)+ 1) * w, h * (i / s));

                    this.Controls.Add(cbo);

                }
                else
                {
                    txt = new TextBox();
                    txt.Name = "txt" + controls[i, 0];
                    txt.Location = new Point((2*(i % s) + 1) * w, h * (i / s));
                    txt.Width = w;
                    this.Controls.Add(txt);
                }
            }
            dgvList.DataSource = db.BranchList();
        }


        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            /*if (iId == 0)
            else*/
            ResetData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            db.BranchDelete(iId);
            ResetData();
        }

        private void ResetData()
        {
            dgvList.DataSource = db.BranchList();
            iId = 0;
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                    ((TextBox)item).Text = "";
                else if (item is ComboBox)
                    ((ComboBox)item).SelectedIndex = 0;
            }
        }

        private void btnAutoUpdate_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "Status: Auto Updating!";
            string dirBranch = @"D:\Data\Stock\Branch\";
            WebLib.HttpPost("http://www.cophieu68.vn/categorylist.php",  dirBranch, 0, "branch");
            StreamReader read = new StreamReader(dirBranch + WebLib.GetDateName() + ".htm");
            string content = read.ReadToEnd();
            int pos = content.IndexOf(">Vốn TT (Tỷ)</a>") + 100;
            int pos1;
            content = content.Substring(pos);
            string[] lstData = new string[16];


            while (content.IndexOf("</table>") > 50)
            {
                pos = content.IndexOf("http://www.cophieu68.vn/categorylist_detail.php?category=^");
                content = content.Substring(pos);
                pos1 = content.IndexOf("',");
                lstData[15] = content.Substring(0, pos1);

                pos = content.IndexOf("<strong>") + "<strong>".Length;
                content = content.Substring(pos);
                pos1 = content.IndexOf("</strong>");
                lstData[0] = content.Substring(0, pos1);
                pos = content.IndexOf("<span class=") + "<span class=".Length;
                content = content.Substring(pos);
                pos = content.IndexOf(">") + 1;
                content = content.Substring(pos);
                pos1 = content.IndexOf("<");
                lstData[1] = content.Substring(0, pos1);
                pos = content.IndexOf("(") + 1;
                content = content.Substring(pos);
                pos1 = content.IndexOf(")");
                lstData[2] = content.Substring(0, pos1);

                int start = 3;
                for (int i = 0; i < 11; i++)
                {
                    pos = content.IndexOf("align=\"right\" >") + "align=\"right\" >".Length;
                    content = content.Substring(pos);
                    pos1 = content.IndexOf("<");
                    if (i == 9)
                    {
                        lstData[start + i] = content.Substring(0, pos1);
                        pos = content.IndexOf("(") + 1;
                        content = content.Substring(pos);
                        pos1 = content.IndexOf(")");
                        lstData[++start + i] = content.Substring(0, pos1);
                    }
                    else lstData[start + i] = content.Substring(0, pos1);
                }
                content = content.Substring(pos1);
                db.BranchInsert(lstData);
            }
            read.Close();

            lblMsg.Text = "Status: Completed!";
        }

        private void btnBranchFind_Click(object sender, EventArgs e)
        {
            ComboBox cbo = (ComboBox)this.Controls["cboFiveBasicElementId"];
            dgvList.DataSource = db.BranchList(Convert.ToInt32(cbo.SelectedValue));
        }

        private void btnAutoUpdateStock_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "Status: Auto Updating!";
            List<Branch> lst = db.BranchList();
            string dirBranchStock = @"D:\Data\Stock\Branch\Stock";
            int pos, pos1;
            StreamReader read;
            string content;
            string[] lstData;
            //foreach (Branch item in lst)
            //{

            //    WebLib.HttpPost(item.Url, dirBranchStock, 0, "");
            //    read = new StreamReader(dirBranchStock + WebLib.GetDateName() + ".htm");
            //    content = read.ReadToEnd();
            //    pos = content.IndexOf(">Vốn TT (Tỷ)</a>") + 100;
            //    content = content.Substring(pos);
            //    lstData = new string[14];


            //    while (content.IndexOf("</table>") > 50)
            //    {
            //        pos = content.IndexOf("<strong>") + "<strong>".Length;
            //        content = content.Substring(pos);
            //        pos1 = content.IndexOf("</strong>");
            //        lstData[0] = content.Substring(0, pos1);
            //        pos = content.IndexOf("<span class=") + "<span class=".Length;
            //        content = content.Substring(pos);
            //        pos = content.IndexOf(">") + 1;
            //        content = content.Substring(pos);
            //        pos1 = content.IndexOf("<");
            //        lstData[1] = content.Substring(0, pos1);
            //        pos = content.IndexOf("(") + 1;
            //        content = content.Substring(pos);
            //        pos1 = content.IndexOf(")");
            //        lstData[2] = content.Substring(0, pos1);

            //        int start = 3;
            //        for (int i = 0; i < 10; i++)
            //        {
            //            pos = content.IndexOf("align=\"right\">") + "align=\"right\">".Length;
            //            content = content.Substring(pos);
            //            pos1 = content.IndexOf("<");
            //            if (i == 8)
            //            {
            //                lstData[start + i] = content.Substring(0, pos1);
            //                pos = content.IndexOf("(") + 1;
            //                content = content.Substring(pos);
            //                pos1 = content.IndexOf(")");
            //                lstData[++start + i] = content.Substring(0, pos1);
            //            }
            //            else lstData[start + i] = content.Substring(0, pos1);
            //        }
            //        content = content.Substring(pos1);
            //        db.StockInsert(lstData, item.Id);
            //    }
            //    read.Close();
            //}

            // Update missing detail
            Term term = db.DefinitionById(20515);
            List<Stock> lstStock = db.StockMissingDetailList();
            foreach(Stock stock in lstStock)
            {
                if (stock.Code.Length > 3) continue;
                try
                {
                    WebLib.HttpPost(term.Name.Replace("{code}", stock.Code), dirBranchStock, 0, stock.Code);
                }
                catch (Exception) { continue; }
                read = new StreamReader(dirBranchStock + stock.Code + ".htm");
                content = read.ReadToEnd();
                pos = content.IndexOf("<h1>") + "<h1>".Length;
                content = content.Substring(pos);
                lstData = new string[9];
                pos1 = content.IndexOf("</h1>");
                if (pos1 == -1) continue;
                lstData[0] = content.Substring(0, pos1);

                pos = content.IndexOf("margin-left:30px") + "margin-left:30px".Length;
                content = content.Substring(pos);

                for (int i=1;i<=8;i++)
                { 
                    pos = content.IndexOf("<td align=\"right\"><strong>") + "<td align=\"right\"><strong>".Length;
                    content = content.Substring(pos);
                    pos1 = content.IndexOf("</strong>");
                    lstData[i] = content.Substring(0, pos1);
                }
                content = content.Substring(pos1);
                db.StockUpdate(lstData, stock.Id);
                read.Close();
            }

            lblMsg.Text = "Status: Completed!";
            
        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            DataGridViewRow row = (DataGridViewRow)dgvList.Rows[e.RowIndex];
            int i = 0;
            iId = (int)row.Cells[i++].Value;
            dgvStock.DataSource = db.StockList(iId);
            foreach(Control item in this.Controls)
            {
                if (item is TextBox)
                    ((TextBox)item).Text = row.Cells[i++].Value == null?"": row.Cells[i-1].Value.ToString();
                else if (item is ComboBox)
                    ((ComboBox)item).SelectedValue = row.Cells[i++].Value == null?0: (int)row.Cells[i-1].Value;
            }
        }
    }
}
