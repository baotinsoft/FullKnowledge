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
    public partial class frmNews : Form
    {
        public string url;
        int id;
        DBHistorical db = new DBHistorical();
        public frmNews()
        {
            InitializeComponent();
        }

        private void frmNews_Load(object sender, EventArgs e)
        {
            cboRuleType.DataSource = db.DefinitionCbo(5);
            cboRuleType.DisplayMember = "CodeNum";
            cboRuleType.ValueMember = "Id";
            
            cboUsedFor.DataSource = db.DefinitionCbo(6);
            cboUsedFor.DisplayMember = "CodeNum";
            cboUsedFor.ValueMember = "Id";

            cboRule.DataSource = db.RuleCbo();
            cboRule.DisplayMember = "Rules";
            cboRule.ValueMember = "Id";

            dgvList.DataSource = db.NewsList();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            panAction.Visible = false;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            int effectDateCount = 0, effectMoney = 0;
            try
            {
                effectDateCount = Convert.ToInt32(txtEffectDateCount.Text);
            }
            catch (Exception) { }

            try
            {
                effectMoney = Convert.ToInt32(txtEffectMoney.Text);
            }
            catch (Exception) { }

            if (id == 0)
                db.NewsAdd(txtUrl.Text, txtRate.result, (int)cboRuleType.SelectedValue, (int)cboUsedFor.SelectedValue, (int)cboRule.SelectedValue, txtComment.Text, effectDateCount, effectMoney, dtPublishDate.Value);
            else
                db.NewsEdit(id, txtUrl.Text, txtRate.result, (int)cboRuleType.SelectedValue, (int)cboUsedFor.SelectedValue, (int)cboRule.SelectedValue, txtComment.Text, effectDateCount, effectMoney, dtPublishDate.Value);
            ResetData();

        }
        private void ResetData()
        {
            panAction.Visible = false;
            id = 0;
            txtRate.Text = "";
            txtUrl.Text = "";
            txtComment.Text = "";
            dgvList.DataSource = db.NewsList();
        }

        private void dgvList_Add(object sender, EventArgs e)
        {
            panAction.Visible = true;
        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = dgvList.iEditId;
            New news = db.NewsRecord(id);
            txtUrl.Text = news.Url;
            frmNewsDisplay frm = new frmNewsDisplay();
            frm.url = news.Url;
            frm.Display();
            frm.Show();
            txtComment.Text = news.Comment;
            txtRate.Text = news.Rate.ToString();
            try
            {
                cboRuleType.SelectedValue = news.TypeId;
            }
            catch (Exception) { }
            try
            {
                cboUsedFor.SelectedValue = news.UsedId;
            }
            catch (Exception) { }
            try
            {
                cboRule.SelectedValue = news.RuleId;
            }
            catch (Exception) { }
            txtEffectDateCount.Text = news.EffectDateCount.ToString();
            txtEffectMoney.Text = news.EffectMoney.ToString();
            dtPublishDate.Value = news.PublishDate == null ? DateTime.Now : news.PublishDate.Value;

            panAction.Visible = true;
        }

        private void dgvList_Del(object sender, EventArgs e)
        {
            db.NewsDelete(dgvList.arrDelFullId);
            dgvList.ResetSelected();
            dgvList.DataSource = db.NewsList();
        }

        public void Store()
        {
            panAction.Visible = true;
            txtUrl.Text = url;
        }

    }
}
