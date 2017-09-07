using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Knowledge.DBContext;

namespace Knowledge
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
            dgvList.Width = this.Width - 10;
            dgvList.Height = this.Height - dgvList.Location.Y - 10;
        }

        private void frmDefinition_Load(object sender, EventArgs e)
        {
            cboGroup.DataSource = db.GroupList("Select Group");
            cboGroup.ValueMember = "Id";
            cboGroup.DisplayMember = "DefGroup";
            cboGroup.SelectedIndex = 0;
            iGroupId = (int)cboGroup.SelectedValue;
            dgvList.DataSource = db.DefinitionList(iGroupId);
        }

        private void cboGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboGroup.SelectedValue.GetType().Name != "Int32") return;
            iGroupId = (int)cboGroup.SelectedValue;
            dgvList.DataSource = db.DefinitionList(iGroupId);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int num1 = 0, num2 = 0;

            try
            {
                num1 = Convert.ToInt32(txtNum1.Text);
            }
            catch (Exception) { }

            try
            {
                num2 = Convert.ToInt32(txtNum2.Text);
            }
            catch (Exception) { }

            if (iId == 0)
                db.DefinitionInsert(iGroupId, txtCode.Text, txtName.Text, txtComment.Text, num1, num2);
            else
                db.DefinitionEdit(iId, txtCode.Text, txtName.Text, txtComment.Text, num1, num2, iGroupId);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            db.DefinitionDelete(iId);
            ResetData();
        }

        private void ResetData()
        {
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cboGroup.SelectedValue.GetType().Name == "Int32") iGroupId = (int)cboGroup.SelectedValue;            
            dgvList.DataSource = db.DefinitionSearch(iGroupId, txtCode.Text);
        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            Definition row = (Definition)dgvList.Rows[e.RowIndex].DataBoundItem;
            txtCode.Text = row.Code;
            txtName.Text = row.Name;
            txtNum1.Text = row.Num1.ToString();
            txtNum2.Text = row.Num2.ToString();
            txtComment.Text = row.Description;
            cboGroup.SelectedValue = row.GroupId;
        }
    }
}
