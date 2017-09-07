using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Forex.DBContext;

namespace Forex
{
    public partial class frmRule : Form
    {
        DBHistorical db = new DBHistorical();
        int id;
        public frmRule()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            panAction.Visible = false;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {            
            if (id == 0)
                db.RuleAdd(txtRule.Text, txtRate.result, (int)cboRuleType.SelectedValue, (int)cboUsedFor.SelectedValue, txtComment.Text);
            else
                db.RuleEdit(id, txtRule.Text, txtRate.result, (int)cboRuleType.SelectedValue, (int)cboUsedFor.SelectedValue, txtComment.Text);
            ResetData();
        }

        private void frmRule_Load(object sender, EventArgs e)
        {
            cboRuleType.DataSource = db.DefinitionCbo(5);
            cboRuleType.DisplayMember = "CodeNum";
            cboRuleType.ValueMember = "Id";
            cboUsedFor.DataSource = db.DefinitionCbo(6);
            cboUsedFor.DisplayMember = "CodeNum";
            cboUsedFor.ValueMember = "Id";
            dgvList.DataSource = db.RuleList();
        }

        private void dgvList_Add(object sender, EventArgs e)
        {
            panAction.Visible = true;
        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = dgvList.iEditId;
            DBContext.Rule rule = db.RuleRecord(id);
            txtRule.Text = rule.Rules;
            txtComment.Text = rule.Comment;
            txtRate.Text = rule.Rate.ToString();
            try
            {
                cboRuleType.SelectedValue = rule.TypeId;
            }
            catch (Exception) { }
            try
            {
                cboUsedFor.SelectedValue = rule.UsedId;
            }
            catch (Exception) { }
            panAction.Visible = true;
        }

        private void ResetData()
        {
            panAction.Visible = false;
            id = 0;
            txtRate.Text = "";
            txtRule.Text = "";
            txtComment.Text = "";
            dgvList.DataSource = db.RuleList();
        }

        private void dgvList_Del(object sender, EventArgs e)
        {
            db.RuleDelete(dgvList.arrDelFullId);
            dgvList.ResetSelected();
            dgvList.DataSource = db.RuleList();
        }
    }
}
