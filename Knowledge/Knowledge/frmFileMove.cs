using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Knowledge.DBContext;
using System.IO;

namespace Knowledge
{
    public partial class frmFileMove : Form
    {
        DBKnowledge db = new DBKnowledge();

        public frmFileMove()
        {
            InitializeComponent();
        }

        private void frmOneType_Load(object sender, EventArgs e)
        {
            txtFromDir.Text = @"D:\Ebooks";
            List<Definition> lst = db.DefinitionList(4, "Select Type");
            cboType.DataSource = lst;
            cboType.ValueMember = "Id";
            cboType.DisplayMember = "Code";
        }

        private void btnOneType_Click(object sender, EventArgs e)
        {
            if (cboType.SelectedIndex > 0) OneType(cboType.SelectedIndex);
        }

        private void frmAllTypes_Click(object sender, EventArgs e)
        {
            AllTypes();
        }

        private void AllTypes()
        {
            List<Definition> lst = db.DefinitionList(4);
            foreach(Definition item in lst)
            {
                if (item.Id > 0) OneType(item.Id);
            }

        }

        private void OneType(int typeId)
        {
            List<vEbook> lst = db.EbookList(typeId);
            string sourcePath = txtFromDir.Text;
            string destPath = txtToDir.Text + @"\" + db.DefinitionById(typeId).Code;
            string fileName;
            foreach(vEbook item in lst)
            {
                fileName = item.Name + "." + item.Format;
                if (File.Exists(item.Path == null ? sourcePath : item.Path + @"\" + fileName))
                    File.Move(item.Path == null ? sourcePath : item.Path + @"\" + fileName, destPath + @"\" + fileName);
            }
        }

        private void UpdateOneType(int typeId)
        {
            string destPath = txtToDir.Text + @"\" + db.DefinitionById(typeId).Code;
            string[] files = Directory.GetFiles(destPath);
            foreach (string fileName in files)
            {
                db.EbookUpdateType(fileName.Substring(fileName.LastIndexOf('\\') + 1, fileName.IndexOf('.') - fileName.LastIndexOf('\\') - 1), typeId);
            }
        }

        private void UpdateAllTypes()
        {
            List<Definition> lst = db.DefinitionList(4);
            foreach (Definition item in lst)
            {
                if (item.Id > 0) UpdateOneType(item.Id);
            }
        }

        private void btnUpdateOneType_Click(object sender, EventArgs e)
        {
            UpdateOneType(cboType.SelectedIndex);
        }

        private void btnUpdateAllTypes_Click(object sender, EventArgs e)
        {
            UpdateAllTypes();
        }
    }
}
