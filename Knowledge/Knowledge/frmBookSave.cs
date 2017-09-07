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
    public partial class frmBookSave : Form
    {
        int id;
        public int languageId, page;
        public decimal size;
        public string file;
        DBKnowledge db = new DBKnowledge();
        string targetPath = @"D:\Ebooks\";
        public frmBookSave()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int authorId = 0, publisherId = 0, formatId = 0, typeId = 0;
            languageId = 0;
            page = 0;
            size = 0;

            try
            {
                authorId = Convert.ToInt32(cboAuthor.SelectedValue);
            }
            catch (Exception) {  }
            if (authorId == 0) authorId = db.AuthorInsert(cboAuthor.Text);
            try
            {
                publisherId = Convert.ToInt32(cboPublisher.SelectedValue);
            }
            catch (Exception) {  }
            if (publisherId == 0) publisherId = db.DefinitionInsert(3, cboPublisher.Text); ;

            try
            {
                formatId = Convert.ToInt32(cboFormat.SelectedValue);
            }
            catch (Exception) {  }
            if (formatId == 0) formatId = db.DefinitionInsert(1, cboFormat.Text);

            try
            {
                typeId = Convert.ToInt32(cboType.SelectedValue);
            }
            catch (Exception) {  }
            if (typeId == 0) typeId = db.DefinitionInsert(4, cboType.Text);

            try
            {
                size = Convert.ToDecimal(txtSize.Text);
            }
            catch (Exception) { }

            try
            {
                page = Convert.ToInt32(txtPages.Text);
            }
            catch (Exception) { }

            string path = targetPath + ((Definition)cboType.SelectedItem).Code;
            string fileName = txtName.Text + "." + ((Definition)cboFormat.SelectedItem).Code;
            if (File.Exists(txtPath.Text.Length == 0 ? targetPath : txtPath.Text + @"\" + fileName))
                File.Move(txtPath.Text.Length == 0?targetPath:txtPath.Text + @"\" + fileName , path + @"\" + fileName);


            if (id == 0) db.EbookInsert(txtName.Text, authorId, txtDescription.Text, publisherId, txtISBN.Text, Convert.ToInt32(txtYear.Text), page, Convert.ToInt32(cboLanguage.SelectedValue), size, formatId, path, typeId, txtUrl.Text, "");
            else db.EbookEdit(id, txtName.Text, authorId, txtDescription.Text, publisherId, txtISBN.Text, Convert.ToInt32(txtYear.Text), page, Convert.ToInt32(cboLanguage.SelectedValue), size, formatId, path, typeId, txtUrl.Text);
            ResetData();
            btnSearch.PerformClick();
        }

        private void frmBookSave_Load(object sender, EventArgs e)
        {
            List<Definition> lst2 = db.DefinitionList(2);
            cboLanguage.DataSource = lst2;
            cboLanguage.ValueMember = "Id";
            cboLanguage.DisplayMember = "Code";

            List<Definition> lst1 = db.DefinitionList(1, "Select Format");
            cboFormat.DataSource = lst1;
            cboFormat.ValueMember = "Id";
            cboFormat.DisplayMember = "Code";

            List<Definition> lst3 = db.DefinitionList(3);
            cboPublisher.DataSource = lst3;
            cboPublisher.ValueMember = "Id";
            cboPublisher.DisplayMember = "Code";

            List<Definition> lst4 = db.DefinitionList(4, "Select Type");
            cboType.DataSource = lst4;
            cboType.ValueMember = "Id";
            cboType.DisplayMember = "Code";


            if (file != null && file.Length > 0)
            {
                int last = file.LastIndexOf('\\');
                int point = file.IndexOf('.');

                txtPath.Text = file.Substring(0, last);
                txtName.Text = file.Substring(last + 1, file.Length - last - 1 - (file.Length - point));
                cboLanguage.SelectedValue = languageId;

                cboFormat.Text = file.Substring(point + 1, file.Length - point - 1).ToUpper();

                txtPages.Text = page.ToString();
                txtSize.Text = size.ToString();
            }
            dgvList.DataSource = db.EbookList();
        }

        private void frmBookSave_SizeChanged(object sender, EventArgs e)
        {
            dgvList.Width = this.Width - dgvList.Location.X - 10;
            dgvList.Height = this.Height - dgvList.Location.Y - 10;
        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            vEbook row = (vEbook)dgvList.Rows[e.RowIndex].DataBoundItem;
            id = row.Id;
            txtName.Text = row.Name;
            cboAuthor.SelectedValue = row.AuthorId;
            cboPublisher.SelectedValue = row.PublisherId;
            txtDescription.Text = row.Description;
            txtPages.Text = row.Pages.ToString();
            cboLanguage.SelectedValue = row.LanguageId;
            txtSize.Text = row.Size.ToString();
            txtISBN.Text = row.ISBN;
            txtYear.Text = row.Year.ToString();
            cboType.SelectedValue = row.TypeId;
            cboFormat.SelectedValue = row.FormatId;
            txtPath.Text = row.Path;
            txtUrl.Text = row.Url;
        }

        private void ResetData()
        {
            id = 0;
            foreach(Control control in this.Controls)
            {
                if (control is TextBox) ((TextBox)control).Text = "";
                if (control is ComboBox) ((ComboBox)control).SelectedValue = 0;
            }
        }

        public List<string> Search()
        {
            var files = new List<string>();
            foreach (DriveInfo d in DriveInfo.GetDrives().Where(x => x.IsReady))
            {
                try
                {
                    files.AddRange(Directory.GetFiles(d.RootDirectory.FullName, "*.pdf", SearchOption.AllDirectories));
                }
                catch (Exception e)
                {
                }
            }

            return files;
        }

        private void btnAutoSave_Click(object sender, EventArgs e)
        {
            Auto();
        }

        private void AutoRecursion()
        {
            if (txtPath.Text.Length == 0) return;

            //string[] files = Directory.GetFiles(txtPath.Text, "*.*", SearchOption.AllDirectories);
            var files = Search();

            PdfReader reader;
            int formatId = 2, last, point;
            string path, name, ext;
            FileInfo f;
            foreach (string fileName in files)
            {
                last = fileName.LastIndexOf('\\');
                point = fileName.LastIndexOf('.');
                ext = fileName.Substring(point + 1, fileName.Length - point - 1).ToLower();
                if (ext == "zip" || ext == "rar") continue;
                formatId = db.DefinitionInsert(1, ext);

                name = fileName.Substring(last + 1, fileName.Length - last - 1 - (fileName.Length - point));
                if (db.EbookExist(name)) continue;

                path = fileName.Substring(0, last);
                if (path == @"E:\Ebooks") continue;
                languageId = 1001;

                page = 0;
                try
                {
                    if (ext == "pdf")
                    {
                        reader = new PdfReader(fileName);
                        page = reader.NumberOfPages;
                        reader.Close();
                    }
                }
                catch (Exception) { }

                f = new FileInfo(fileName);
                size = f.Length;

                db.EbookInsert(name, 0, "", 0, "", 0, page, languageId, size, formatId, path, 0, txtUrl.Text, txtUrlDownload.Text);
            }
        }

        private void Auto()
        {
            if (txtPath.Text.Length == 0) return;

            string[] files = Directory.GetFiles(txtPath.Text, "*.*", SearchOption.TopDirectoryOnly);

            PdfReader reader;
            int formatId = 2, last, point;
            string path, name, ext;
            FileInfo f;
            foreach (string fileName in files)
            {
                last = fileName.LastIndexOf('\\');
                point = fileName.LastIndexOf('.');
                ext = fileName.Substring(point + 1, fileName.Length - point - 1).ToLower();
                if (ext == "zip" || ext == "rar") continue;
                formatId = db.DefinitionInsert(1, ext);

                name = fileName.Substring(last + 1, fileName.Length - last - 1 - (fileName.Length - point));
                if (db.EbookExist(name)) continue;
                                
                languageId = (int)cboLanguage.SelectedValue;

                page = 0;
                try
                {
                    if (ext == "pdf")
                    {
                        reader = new PdfReader(fileName);
                        page = reader.NumberOfPages;
                        reader.Close();
                    }
                }
                catch (Exception) { }

                f = new FileInfo(fileName);
                size = f.Length;

                int typeId = (int)cboType.SelectedValue;
                if (typeId == 0) return;
                path = targetPath + ((Definition)cboType.SelectedItem).Code;
                File.Move(fileName, path + fileName.Substring(last, fileName.Length - last));

                int authorId = db.AuthorInsert(cboAuthor.Text);

                db.EbookInsert(name, 0, "", 0, "", 0, page, languageId, size, formatId, path, typeId, txtUrl.Text, txtUrlDownload.Text);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvList.DataSource = db.EbookList(txtName.Text, (int)cboType.SelectedValue, (int)cboFormat.SelectedValue);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            foreach(Control item in this.Controls)
            {
                if (item is TextBox) item.Text = "";
                else if (item is ComboBox) ((ComboBox)item).SelectedIndex = 0;
            }
        }

        private void btnUpdateType_Click(object sender, EventArgs e)
        {
            db.EbookUpdateType();
        }



    }
}
