using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using StockKnowledge.DBContext;

namespace StockKnowledge
{
    public partial class frmTerms : Form
    {
        int iGroupId = 2, iId;
        DBKnowledge db = new DBKnowledge();
        public frmTerms()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (iId > 0) db.DefinitionEdit(iId, txtName.Text, rtbEn.Text, rtbVn.Text, 0, 0);
            else db.DefinitionInsert(iGroupId, txtName.Text, rtbEn.Text, rtbVn.Text, 0, 0);
            DataLoad();
            DataReset();
        }

        private void frmTerms_Load(object sender, EventArgs e)
        {
            DataLoad();
        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            iId = Convert.ToInt32(dgvList.Rows[e.RowIndex].Cells[0].Value);
            txtName.Text = Convert.ToString(dgvList.Rows[e.RowIndex].Cells[1].Value);
            rtbEn.Text = Convert.ToString(dgvList.Rows[e.RowIndex].Cells[2].Value);
            rtbVn.Text = Convert.ToString(dgvList.Rows[e.RowIndex].Cells[3].Value);
        }

        private void DataLoad()
        {
            dgvList.DataSource = db.DefinitionList(iGroupId);
        }

        private void DataReset()
        {
            iId = 0;
            txtName.Text = "";
            rtbEn.Text = "";
            rtbVn.Text = "";
        }
    }
}
