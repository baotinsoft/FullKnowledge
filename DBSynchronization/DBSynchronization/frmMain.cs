using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBSynchronization.DataContext;

namespace DBSynchronization
{
    public partial class frmMain : Form
    {
        LibDB db = new LibDB();
        string[] args;
        int funcs = 0;
        public frmMain(string[] args)
        {
            InitializeComponent();            
            if (args!=null)
            {
                this.args = args;
                funcs = Convert.ToInt32(args[0]);
            }
        }

        private void btnConnectDB_Click(object sender, EventArgs e)
        {
            db.conn = txtConnection.Text;
            db.OpenConnection();
        }

        private void btnCloseConnection_Click(object sender, EventArgs e)
        {
            db.CloseConnection();
        }

        private void btnGetDBs_Click(object sender, EventArgs e)
        {
            List<string> list = db.GetDBs();
            txtResult.Text = "";
            cboAllDBs.Items.Clear();
            foreach(string item in list)
            {
                txtResult.Text += item + "\r\n";
                cboAllDBs.Items.Add(item);
            }
        }

        private void btnGetTables_Click(object sender, EventArgs e)
        {
            List<string> list = db.GetTables(cboAllDBs.Text);
            txtResult.Text = "";
            cboAllTables.Items.Clear();
            foreach (string item in list)
            {
                txtResult.Text += item + "\r\n";
                cboAllTables.Items.Add(item);
            }
        }

        private void btnColumns_Click(object sender, EventArgs e)
        {
            List<string> list = db.GetColumns(cboAllTables.Text, db.DBName());
            txtResult.Text = "";
            cboAllColumns.Items.Clear();
            foreach (string item in list)
            {
                txtResult.Text += item + "\r\n";
                cboAllColumns.Items.Add(item);
            }
        }

        private void btnExecuteQuery_Click(object sender, EventArgs e)
        {
            txtResult.Text = "";
            ExecuteQuery(txtSql.Text);
        }

        private void ExecuteQuery(string sql)
        {            
            SqlDataReader reader = db.ExecuteQuery(sql);
            if (reader == null) return;
            int fieldCount = reader.FieldCount;
            for (int i = 0; i < fieldCount; i++)
            {
                txtResult.Text += reader.GetName(i) + "\t";
            }
            txtResult.Text += "\r\n";
            while (reader.Read())
            {
                for (int i = 0; i < fieldCount; i++)
                    txtResult.Text += reader[i] + "\t";
                txtResult.Text += "\r\n";
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            db.conn = txtConnection.Text;
            db.OpenConnection();
            if (funcs > 0) this.Hide();
            cboSyncDBs.DataSource = db.DBList();
            cboSyncDBs.DisplayMember = "DBDest";
            cboSyncDBs.ValueMember = "Id";
            db.conn = txtConnection.Text;

            switch(funcs)
            {
                case 0:
                    break;
                case 1: //add linked server
                    AddLinkedServer(args[1], args[2]);
                    break;
                case 2: //add new merge sql
                    AddMergeSQL(args[1], args[2]);
                    break;
                case 3: //run sync from merge sql

                    break;
            }

            if (funcs > 0) Application.Exit();
        }

        private void cboLinkedServers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLinkedServers.SelectedIndex > -1)
            {
                txtConnection.Text = "Data Source=" + ((KeyValuePair<string, string>)cboLinkedServers.SelectedItem).Value + ";Persist Security Info=True;User ID=sa;Password=123bt@123";
                db.conn = txtConnection.Text;
                db.OpenConnection();
                btnGetDBs.PerformClick();
            }

        }

        private void btnAddLinkedServer_Click(object sender, EventArgs e)
        {
            AddLinkedServer(txtLinkedServerName.Text, txtLinkedServerIP.Text);
        }

        private void AddLinkedServer(string name, string ip)
        {
            SqlDataReader reader = db.LinkedServerAdd(name, ip);
            if (reader == null || cboLinkedServers.DataSource != null) return;
            txtResult.Text = "";
            //cboLinkedServers.Items.Clear();
            Dictionary<string, string> test = new Dictionary<string, string>();
            while (reader.Read())
            {
                txtResult.Text += reader["name"] + "\r\n";
                test.Add(reader["name"].ToString(), reader["data_source"].ToString());
            }
            cboLinkedServers.DataSource = new BindingSource(test, null);
            cboLinkedServers.DisplayMember = "Key";
            cboLinkedServers.ValueMember = "Value";
        }

        private void btnMergeTable_Click(object sender, EventArgs e)
        {
            txtResult.Text = "";
            MergeTable(txtSourceTable.Text, txtDestTable.Text, "SourceId");
        }
        private void MergeTable(string sourceTable, string destTable, string refField)
        {
            txtResult.Text += "----------\r\n";
            txtResult.Text += "Merge Table from Source '" + sourceTable + "' to Dest '" + destTable  + "'\r\n";
            ExecuteQuery("Select * from " + sourceTable);
            txtResult.Text += "----------\r\n";
            ExecuteQuery("Select * from " + destTable);
            db.MergeTable(sourceTable, destTable, refField);
            db.MergeTable(destTable, sourceTable, refField);
            txtResult.Text += "----------\r\n";
            ExecuteQuery("Select * from " + destTable);
        }

        private void btnGetSourceDB_Click(object sender, EventArgs e)
        {
            db.connSource = "Data Source=" + ((KeyValuePair<string, string>)cboLinkedServers.SelectedItem).Value + ";Persist Security Info=True;User ID=sa;Password=123bt@123;Initial Catalog=" + cboAllDBs.Text;
            txtSourceDB.Text = cboLinkedServers.Text + "." + cboAllDBs.Text;
        }

        private void btnGetDestDB_Click(object sender, EventArgs e)
        {
            db.connDest = "Data Source=" + ((KeyValuePair<string, string>)cboLinkedServers.SelectedItem).Value + ";Persist Security Info=True;User ID=sa;Password=123bt@123;Initial Catalog=" + cboAllDBs.Text;
            txtDestDB.Text = cboLinkedServers.Text + "." + cboAllDBs.Text;
        }

        private void btnGetSourceTable_Click(object sender, EventArgs e)
        {
            txtSourceTable.Text = cboLinkedServers.Text + "." + cboAllDBs.Text + ".dbo." + cboAllTables.Text;
        }

        private void btnGetDestTable_Click(object sender, EventArgs e)
        {
            txtDestTable.Text = cboLinkedServers.Text + "." + cboAllDBs.Text + ".dbo." + cboAllTables.Text;
        }

        private void btnMergeDB_Click(object sender, EventArgs e)
        {
            List<string> sourceTables = db.GetTables(txtSourceDB.Text, db.connSource);
            List<string> destTables = db.GetTables(txtDestDB.Text, db.connDest);
            foreach(string table in sourceTables)
            {
                if (destTables.IndexOf(table) != -1)
                {
                    MergeTable(txtSourceDB.Text + ".dbo." + table, txtDestDB.Text + ".dbo." + table, "SourceId");
                    MergeTable(txtDestDB.Text + ".dbo." + table, txtSourceDB.Text + ".dbo." + table, "SourceId");
                }
            }
            
        }

        private void btnLinkedServers_Click(object sender, EventArgs e)
        {
            btnAddLinkedServer.PerformClick();
        }

        private void btnStoreMergeDB_Click(object sender, EventArgs e)
        {
            AddMergeSQL(txtSourceDB.Text, txtDestDB.Text);
        }

        private void AddMergeSQL(string source, string dest)
        {
            string serverSource = source;
            int pos = serverSource.IndexOf('.');
            string dbSource = serverSource.Substring(pos + 1, serverSource.Length - pos - 1);
            serverSource = serverSource.Substring(0, pos);
            string serverDest = dest;
            pos = serverDest.IndexOf('.');
            string dbDest = serverDest.Substring(pos + 1, serverDest.Length - pos - 1);
            serverDest = serverDest.Substring(0, pos);
            int serverId = db.ServerAdd(serverDest, serverSource);
            db.DBAdd(serverId, dbDest, dbSource, chkTwoDirection.Checked);
        }

        private void btnMergeDBFromSql_Click(object sender, EventArgs e)
        {
            RunMergedSQL(Convert.ToInt32(cboSyncDBs.SelectedValue));
        }

        private void RunMergedSQL(int dbId)
        {
            List<string> mergeQueries = db.TableList(dbId);
            foreach (string query in mergeQueries)
                db.ExecuteCommand(query);

        }

        private void btnWebTable_Click(object sender, EventArgs e)
        {
            db.TableAdd(txtTable.Text, chkDaily.Checked);
        }

        private void btnGetTable_Click(object sender, EventArgs e)
        {
            txtTable.Text = cboLinkedServers.Text.Length == 0?"localhost": cboLinkedServers.Text + "." + cboAllDBs.Text + ".dbo." + cboAllTables.Text;
        }

        private void btnConfigCollectData_Click(object sender, EventArgs e)
        {
            if (cboAllDBs.Text.Length == 0) return;
            frmInfoCollect frm = new frmInfoCollect();
            frm.dbName = cboAllDBs.Text;
            frm.sqlConn = txtConnection.Text;
            frm.Show();
        }

        private void cboAllDBs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAllDBs.SelectedIndex > -1) btnGetTables.PerformClick();
        }

        private void cboAllTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAllTables.SelectedIndex > -1) btnColumns.PerformClick();
        }

        private void btnBrowseBackup_Click(object sender, EventArgs e)
        {
            if (txtBackupFolder.Text.Length > 0) dlgBrowse.SelectedPath = txtBackupFolder.Text;
            DialogResult result = dlgBrowse.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtBackupFolder.Text = dlgBrowse.SelectedPath;
            }
        }

        private void btnBrowseDB_Click(object sender, EventArgs e)
        {
            if (txtDBFolder.Text.Length > 0) dlgBrowse.SelectedPath = txtDBFolder.Text;
            DialogResult result = dlgBrowse.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtDBFolder.Text = dlgBrowse.SelectedPath;
            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            string dbName = "";
            try
            {
                dbName = cboAllDBs.SelectedItem.ToString();
            }
            catch (Exception) { }
            if (txtBackupFolder.Text.Length > 0) dlgSave.InitialDirectory = txtBackupFolder.Text;
            dlgSave.Filter = "Text files (*.bak)|*.bak|All files (*.*)|*.*";
            if (dlgSave.ShowDialog() == DialogResult.OK)
            {
                // the below query get backup of DB you specified in combobox
                db.Backup(dbName, dlgSave.FileName);
                MessageBox.Show("DB BackUp has been created successful.");
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            string dbName = "";
            try
            {
                dbName = cboAllDBs.SelectedItem.ToString();
            }
            catch (Exception) { }

            if (txtBackupFolder.Text.Length > 0) dlgSave.InitialDirectory = txtBackupFolder.Text;
            dlgSave.Filter = "Text files (*.bak)|*.bak|All files (*.*)|*.*";
            if (dlgSave.ShowDialog() == DialogResult.OK)
            {
                db.Restore(dbName, dlgSave.FileName);
                MessageBox.Show("DB Restore has been created successful.");
            }
        }
    }
}
