using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Land.DBContext;

namespace Land
{
    public partial class frmDefinition : Form
    {
        int id, groupId;
        DBLand db = new DBLand();

        public frmDefinition()
        {
            InitializeComponent();
        }

        private void frmDefinition_SizeChanged(object sender, EventArgs e)
        {
            dgvList.Width = this.Width;
        }

        private void frmDefinition_Load(object sender, EventArgs e)
        {
            cboGroup.DataSource = db.GroupList();
            cboGroup.ValueMember = "Id";
            cboGroup.DisplayMember = "DefGroup";
            cboGroup.SelectedIndex = 0;
            groupId = (int)cboGroup.SelectedValue;
            dgvList.DataSource = db.DefinitionList(groupId);
        }

        private void cboGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (groupId == 0) return;
            groupId = (int)cboGroup.SelectedValue;
            dgvList.DataSource = db.DefinitionList(groupId);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (id == 0)
                db.DefinitionAdd(groupId, txtCode.Text, txtName.Text);
            else
                db.DefinitionEdit(id, txtCode.Text, txtName.Text);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            db.DefinitionDelete(id);
            ResetData();
        }

        private void ResetData()
        {
            id = 0;
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
    }
}
