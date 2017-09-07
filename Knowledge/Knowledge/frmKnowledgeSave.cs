using iTextSharp.text.pdf;
using Knowledge.DBContext;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Knowledge
{
    public partial class frmKnowledgeSave : Form
    {
        public int func;
        int id;
        public int languageId, page;
        public decimal size;
        public string file;
        DBKnowledge db = new DBKnowledge();
        string dirImage = @"D:\Data\Knowledge";
        public frmKnowledgeSave(int func)
        {
            this.func = func;
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int typeId = 0;
            
            try
            {
                typeId = Convert.ToInt32(cboType.SelectedValue);
            }
            catch (Exception) {  }
            if (typeId == 0) typeId = db.DefinitionInsert(5, cboType.Text);

            string dirSource = dirImage;
            if (func == 1)
            {
                if (id == 0) id = db.KnowledgeInsert(typeId, txtTitle.Text, txtDescription.Text, txtUrl.Text, chkIsFile.Checked);
                else db.KnowledgeEdit(id, typeId, txtTitle.Text, txtDescription.Text, txtUrl.Text, chkIsFile.Checked);
                dirSource += @"\Knowledge\";
            }
            else
            {
                if (id == 0) id = db.RuleInsert(typeId, txtTitle.Text, txtDescription.Text, txtUrl.Text, chkIsFile.Checked);
                else db.RuleEdit(id, typeId, txtTitle.Text, txtDescription.Text, txtUrl.Text, chkIsFile.Checked);
                dirSource += @"\Rule\";
            }

            int i = 1;
            foreach (var item in lstFile.Items)
            {
                if (item.ToString().IndexOf(dirSource) == -1)
                {
                    File.Copy(item.ToString(), dirSource + id + "_" + i + ".jpg");
                    i++;
                }
            }

            ResetData();
            btnSearch.PerformClick();
        }

        private void frmKnowledgeSave_Load(object sender, EventArgs e)
        {
            List<Definition> lst = db.DefinitionList(5, "Select Type");
            cboType.DataSource = lst;
            cboType.ValueMember = "Id";
            cboType.DisplayMember = "Code";
            if (func == 1)
                dgvList.DataSource = db.KnowledgeList(0, "");
            else
                dgvList.DataSource = db.RuleList(0, "");
        }

        private void frmKnowledgeSave_SizeChanged(object sender, EventArgs e)
        {
            //txtDescription.Width = this.Width - txtDescription.Location.X - 10;
            dgvList.Width = this.Width - dgvList.Location.X - 10;
            dgvList.Height = this.Height - dgvList.Location.Y - 10;
        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            string dirSource = dirImage;
            if (func == 1)
            {
                Knowledge.DBContext.Knowledge row = (Knowledge.DBContext.Knowledge)dgvList.Rows[e.RowIndex].DataBoundItem;
                id = row.Id;
                txtDescription.Text = row.Description;
                txtTitle.Text = row.Title.ToString();
                cboType.SelectedValue = row.TypeId;
                chkIsFile.Checked = row.IsFile.Value;
                txtUrl.Text = row.Url;
                dirSource += @"\Knowledge\";
            }
            else
            {
                Knowledge.DBContext.Rule row = (Knowledge.DBContext.Rule)dgvList.Rows[e.RowIndex].DataBoundItem;
                id = row.Id;
                txtDescription.Text = row.Description;
                txtTitle.Text = row.Title.ToString();
                cboType.SelectedValue = row.TypeId;
                chkIsFile.Checked = row.IsFile.Value;
                txtUrl.Text = row.Url;
                dirSource += @"\Rule\";
            }

            string []files = Directory.GetFiles(dirSource, "*" + id + "_*");
            foreach (string file in files)
                lstFile.Items.Add(file);
        }

        private void ResetData()
        {
            id = 0;
            foreach(Control control in this.Controls)
            {
                if (control is TextBox) ((TextBox)control).Text = "";
                if (control is ComboBox) ((ComboBox)control).SelectedValue = 0;
                if (control is ListBox) ((ListBox)control).Items.Clear();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtTitle.Text = "";
            txtDescription.Text = "";
            txtUrl.Text = "";
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {            
            dlgBrowse.Filter = "Jpeg Files|*.jpg";
            dlgBrowse.Title = "Select an Image File";
            if (dlgBrowse.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string[] files = dlgBrowse.FileNames;
                foreach (string file in files)
                    lstFile.Items.Add(file);
            }
        }

        private void lstFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstFile.SelectedIndex > -1) picShow.Image = new Bitmap(lstFile.Items[lstFile.SelectedIndex].ToString());
        }

        private void picShow_Click(object sender, EventArgs e)
        {
            if (picShow.Width < 200)
            {
                picShow.Width = picShow.Width * 4;
                picShow.Height = picShow.Height * 4;
            }
            else
            {
                picShow.Width = picShow.Width / 4;
                picShow.Height = picShow.Height / 4;

            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (func == 1)
                dgvList.DataSource = db.KnowledgeList((int)cboType.SelectedValue, txtTitle.Text);
            else
                dgvList.DataSource = db.RuleList((int)cboType.SelectedValue, txtTitle.Text);
        }

    }
}
