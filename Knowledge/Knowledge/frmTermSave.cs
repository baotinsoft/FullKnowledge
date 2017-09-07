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
    public partial class frmTermSave : Form
    {
        int id;
        public int languageId, page;
        public decimal size;
        public string file;
        DBKnowledge db = new DBKnowledge();
        string targetPath = @"E:\Ebooks\";
        public frmTermSave()
        {
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


            if (id == 0) db.TermInsert(typeId, txtEn.Text, txtVn.Text, txtDescription.Text, txtUrl.Text);
            else db.TermEdit(id, typeId, txtEn.Text, txtVn.Text, txtDescription.Text, txtUrl.Text);
            ResetData(false);
            btnSearch.PerformClick();
        }

        private void frmTermSave_Load(object sender, EventArgs e)
        {
            List<Definition> lst = db.DefinitionList(5, "Select Type");
            cboType.DataSource = lst;
            cboType.ValueMember = "Id";
            cboType.DisplayMember = "Code";
            
            dgvList.DataSource = db.TermList(0, "","");
        }

        private void frmTermSave_SizeChanged(object sender, EventArgs e)
        {
            txtDescription.Width = this.Width - txtDescription.Location.X - 10;
            dgvList.Width = this.Width - dgvList.Location.X - 10;
            dgvList.Height = this.Height - dgvList.Location.Y - 10;
        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            Term row = (Term)dgvList.Rows[e.RowIndex].DataBoundItem;
            id = row.Id;
            txtDescription.Text = row.Description;
            txtEn.Text = row.En.ToString();
            txtVn.Text = row.Vn.ToString();
            cboType.SelectedValue = row.TypeId;
            txtUrl.Text = row.Url;
        }

        private void ResetData(bool changeType)
        {
            id = 0;
            foreach(Control control in this.Controls)
            {
                if (control is TextBox) ((TextBox)control).Text = "";
                if (control is ComboBox && changeType) ((ComboBox)control).SelectedValue = 0;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtDescription.Text = "";
            txtEn.Text = "";
            txtVn.Text = "";
            txtUrl.Text = "";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvList.DataSource = db.TermList((int)cboType.SelectedValue, txtEn.Text, txtVn.Text);
        }

    }
}
