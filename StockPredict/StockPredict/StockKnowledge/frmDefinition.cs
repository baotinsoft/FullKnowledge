using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StockKnowledge.DBContext;

namespace StockKnowledge
{
    public partial class frmDefinition : Form
    {
        int iId, iGroupId;
        DBKnowledge db = new DBKnowledge();

        public frmDefinition()
        {
            InitializeComponent();
        }

        private void frmDefinition_SizeChanged(object sender, EventArgs e)
        {
            dgvList.Width = this.Width - dgvList.Location.X - 10;
            dgvList.Height = this.Height - dgvList.Location.Y - 10;
            txtComment.Width = this.Width - txtComment.Location.X - 10;
        }

        private void frmDefinition_Load(object sender, EventArgs e)
        {
            cboGroup.DataSource = db.GroupList();
            cboGroup.ValueMember = "Id";
            cboGroup.DisplayMember = "DefGroup";
            cboGroup.SelectedIndex = 0;
            iGroupId = (int)cboGroup.SelectedValue;
            dgvList.DataSource = db.SourceDefinitionList(iGroupId);
        }

        private void cboGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (iGroupId == 0) return;
            iGroupId = (int)cboGroup.SelectedValue;
            ResetData();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (iId == 0)
                db.DefinitionInsert(iGroupId, txtCode.Text, txtName.Text, txtComment.Text, Convert.ToInt32(txtNum1.Text), Convert.ToInt32(txtNum2.Text));
            else
                db.DefinitionEdit(iId, txtCode.Text, txtName.Text, txtComment.Text, Convert.ToInt32(txtNum1.Text), Convert.ToInt32(txtNum2.Text));
            ResetData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            db.DefinitionDelete(iId);
            ResetData();
        }

        private void ResetData()
        {
            dgvList.DataSource = db.SourceDefinitionList(iGroupId);
            iId = 0;
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                    ((TextBox)item).Text = "";
            }
        }

        private void btnGroupSave_Click(object sender, EventArgs e)
        {
            db.GroupInsert(cboGroup.Text, "", 0, 0);
        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            vDefinition row = (vDefinition)dgvList.Rows[e.RowIndex].DataBoundItem;
            iId = row.Id;
            txtCode.Text = row.CodeNum;
            txtName.Text = row.Definition;
            txtNum1.Text = row.Num1.ToString();
            txtNum2.Text = row.Num2.ToString();
            txtComment.Text = row.Description;
            cboGroup.SelectedValue = row.DefGroupId;
        }
    }
}
