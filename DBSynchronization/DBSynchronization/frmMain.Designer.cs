namespace DBSynchronization
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCloseConnection = new System.Windows.Forms.Button();
            this.btnGetDBs = new System.Windows.Forms.Button();
            this.txtConnection = new System.Windows.Forms.TextBox();
            this.btnConnectDB = new System.Windows.Forms.Button();
            this.btnGetTables = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btnColumns = new System.Windows.Forms.Button();
            this.btnExecuteQuery = new System.Windows.Forms.Button();
            this.txtSql = new System.Windows.Forms.TextBox();
            this.txtDestTable = new System.Windows.Forms.TextBox();
            this.txtSourceTable = new System.Windows.Forms.TextBox();
            this.btnMergeTable = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLinkedServerIP = new System.Windows.Forms.TextBox();
            this.cboLinkedServers = new System.Windows.Forms.ComboBox();
            this.btnAddLinkedServer = new System.Windows.Forms.Button();
            this.txtLinkedServerName = new System.Windows.Forms.TextBox();
            this.cboAllDBs = new System.Windows.Forms.ComboBox();
            this.cboAllTables = new System.Windows.Forms.ComboBox();
            this.cboAllColumns = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSourceDB = new System.Windows.Forms.TextBox();
            this.txtDestDB = new System.Windows.Forms.TextBox();
            this.btnMergeDB = new System.Windows.Forms.Button();
            this.btnGetSourceDB = new System.Windows.Forms.Button();
            this.btnGetDestDB = new System.Windows.Forms.Button();
            this.btnGetDestTable = new System.Windows.Forms.Button();
            this.btnGetSourceTable = new System.Windows.Forms.Button();
            this.btnLinkedServers = new System.Windows.Forms.Button();
            this.btnStoreMergeDB = new System.Windows.Forms.Button();
            this.btnMergeDBFromSql = new System.Windows.Forms.Button();
            this.cboSyncDBs = new System.Windows.Forms.ComboBox();
            this.btnWebTable = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTable = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnConfigCollectData = new System.Windows.Forms.Button();
            this.btnGetTable = new System.Windows.Forms.Button();
            this.chkDaily = new System.Windows.Forms.CheckBox();
            this.chkTwoDirection = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnBrowseDB = new System.Windows.Forms.Button();
            this.txtDBFolder = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnRestore = new System.Windows.Forms.Button();
            this.btnBrowseBackup = new System.Windows.Forms.Button();
            this.txtBackupFolder = new System.Windows.Forms.TextBox();
            this.btnBackup = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.dlgBrowse = new System.Windows.Forms.FolderBrowserDialog();
            this.dlgSave = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCloseConnection
            // 
            this.btnCloseConnection.Location = new System.Drawing.Point(546, 9);
            this.btnCloseConnection.Name = "btnCloseConnection";
            this.btnCloseConnection.Size = new System.Drawing.Size(106, 23);
            this.btnCloseConnection.TabIndex = 0;
            this.btnCloseConnection.Text = "Close Connection";
            this.btnCloseConnection.UseVisualStyleBackColor = true;
            this.btnCloseConnection.Click += new System.EventHandler(this.btnCloseConnection_Click);
            // 
            // btnGetDBs
            // 
            this.btnGetDBs.Location = new System.Drawing.Point(390, 34);
            this.btnGetDBs.Name = "btnGetDBs";
            this.btnGetDBs.Size = new System.Drawing.Size(89, 23);
            this.btnGetDBs.TabIndex = 1;
            this.btnGetDBs.Text = "All DBs";
            this.btnGetDBs.UseVisualStyleBackColor = true;
            this.btnGetDBs.Click += new System.EventHandler(this.btnGetDBs_Click);
            // 
            // txtConnection
            // 
            this.txtConnection.Location = new System.Drawing.Point(12, 12);
            this.txtConnection.Name = "txtConnection";
            this.txtConnection.Size = new System.Drawing.Size(421, 20);
            this.txtConnection.TabIndex = 2;
            this.txtConnection.Text = "Data Source=localhost;Persist Security Info=True;User ID=sa;Password=123bt@123";
            // 
            // btnConnectDB
            // 
            this.btnConnectDB.Location = new System.Drawing.Point(439, 9);
            this.btnConnectDB.Name = "btnConnectDB";
            this.btnConnectDB.Size = new System.Drawing.Size(103, 23);
            this.btnConnectDB.TabIndex = 3;
            this.btnConnectDB.Text = "Open Connection";
            this.btnConnectDB.UseVisualStyleBackColor = true;
            this.btnConnectDB.Click += new System.EventHandler(this.btnConnectDB_Click);
            // 
            // btnGetTables
            // 
            this.btnGetTables.Location = new System.Drawing.Point(149, 61);
            this.btnGetTables.Name = "btnGetTables";
            this.btnGetTables.Size = new System.Drawing.Size(89, 23);
            this.btnGetTables.TabIndex = 4;
            this.btnGetTables.Text = "All Tables";
            this.btnGetTables.UseVisualStyleBackColor = true;
            this.btnGetTables.Click += new System.EventHandler(this.btnGetTables_Click);
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(801, 9);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(233, 416);
            this.txtResult.TabIndex = 5;
            // 
            // btnColumns
            // 
            this.btnColumns.Location = new System.Drawing.Point(390, 63);
            this.btnColumns.Name = "btnColumns";
            this.btnColumns.Size = new System.Drawing.Size(89, 23);
            this.btnColumns.TabIndex = 6;
            this.btnColumns.Text = "All Columns";
            this.btnColumns.UseVisualStyleBackColor = true;
            this.btnColumns.Click += new System.EventHandler(this.btnColumns_Click);
            // 
            // btnExecuteQuery
            // 
            this.btnExecuteQuery.Location = new System.Drawing.Point(691, 92);
            this.btnExecuteQuery.Name = "btnExecuteQuery";
            this.btnExecuteQuery.Size = new System.Drawing.Size(104, 62);
            this.btnExecuteQuery.TabIndex = 8;
            this.btnExecuteQuery.Text = "Execute Query";
            this.btnExecuteQuery.UseVisualStyleBackColor = true;
            this.btnExecuteQuery.Click += new System.EventHandler(this.btnExecuteQuery_Click);
            // 
            // txtSql
            // 
            this.txtSql.Location = new System.Drawing.Point(84, 92);
            this.txtSql.Multiline = true;
            this.txtSql.Name = "txtSql";
            this.txtSql.Size = new System.Drawing.Size(598, 62);
            this.txtSql.TabIndex = 9;
            // 
            // txtDestTable
            // 
            this.txtDestTable.Location = new System.Drawing.Point(451, 170);
            this.txtDestTable.Name = "txtDestTable";
            this.txtDestTable.Size = new System.Drawing.Size(132, 20);
            this.txtDestTable.TabIndex = 10;
            this.txtDestTable.Text = "dbmoc.Test.dbo.Table3";
            // 
            // txtSourceTable
            // 
            this.txtSourceTable.Location = new System.Drawing.Point(92, 170);
            this.txtSourceTable.Name = "txtSourceTable";
            this.txtSourceTable.Size = new System.Drawing.Size(132, 20);
            this.txtSourceTable.TabIndex = 11;
            this.txtSourceTable.Text = "dbmoc1.Test3.dbo.Table3";
            // 
            // btnMergeTable
            // 
            this.btnMergeTable.Location = new System.Drawing.Point(691, 167);
            this.btnMergeTable.Name = "btnMergeTable";
            this.btnMergeTable.Size = new System.Drawing.Size(104, 23);
            this.btnMergeTable.TabIndex = 12;
            this.btnMergeTable.Text = "Merge Table";
            this.btnMergeTable.UseVisualStyleBackColor = true;
            this.btnMergeTable.Click += new System.EventHandler(this.btnMergeTable_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Query string:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Source Table:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(371, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Dest Table:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(346, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "< - >";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 267);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Linked Server:";
            // 
            // txtLinkedServerIP
            // 
            this.txtLinkedServerIP.Location = new System.Drawing.Point(197, 264);
            this.txtLinkedServerIP.Name = "txtLinkedServerIP";
            this.txtLinkedServerIP.Size = new System.Drawing.Size(187, 20);
            this.txtLinkedServerIP.TabIndex = 21;
            // 
            // cboLinkedServers
            // 
            this.cboLinkedServers.FormattingEnabled = true;
            this.cboLinkedServers.Location = new System.Drawing.Point(15, 34);
            this.cboLinkedServers.Name = "cboLinkedServers";
            this.cboLinkedServers.Size = new System.Drawing.Size(121, 21);
            this.cboLinkedServers.TabIndex = 23;
            this.cboLinkedServers.SelectedIndexChanged += new System.EventHandler(this.cboLinkedServers_SelectedIndexChanged);
            // 
            // btnAddLinkedServer
            // 
            this.btnAddLinkedServer.Location = new System.Drawing.Point(390, 262);
            this.btnAddLinkedServer.Name = "btnAddLinkedServer";
            this.btnAddLinkedServer.Size = new System.Drawing.Size(106, 23);
            this.btnAddLinkedServer.TabIndex = 24;
            this.btnAddLinkedServer.Text = "Add Linked Server";
            this.btnAddLinkedServer.UseVisualStyleBackColor = true;
            this.btnAddLinkedServer.Click += new System.EventHandler(this.btnAddLinkedServer_Click);
            // 
            // txtLinkedServerName
            // 
            this.txtLinkedServerName.Location = new System.Drawing.Point(94, 265);
            this.txtLinkedServerName.Name = "txtLinkedServerName";
            this.txtLinkedServerName.Size = new System.Drawing.Size(97, 20);
            this.txtLinkedServerName.TabIndex = 25;
            // 
            // cboAllDBs
            // 
            this.cboAllDBs.FormattingEnabled = true;
            this.cboAllDBs.Location = new System.Drawing.Point(263, 34);
            this.cboAllDBs.Name = "cboAllDBs";
            this.cboAllDBs.Size = new System.Drawing.Size(121, 21);
            this.cboAllDBs.TabIndex = 26;
            this.cboAllDBs.SelectedIndexChanged += new System.EventHandler(this.cboAllDBs_SelectedIndexChanged);
            // 
            // cboAllTables
            // 
            this.cboAllTables.FormattingEnabled = true;
            this.cboAllTables.Location = new System.Drawing.Point(15, 63);
            this.cboAllTables.Name = "cboAllTables";
            this.cboAllTables.Size = new System.Drawing.Size(121, 21);
            this.cboAllTables.TabIndex = 27;
            this.cboAllTables.SelectedIndexChanged += new System.EventHandler(this.cboAllTables_SelectedIndexChanged);
            // 
            // cboAllColumns
            // 
            this.cboAllColumns.FormattingEnabled = true;
            this.cboAllColumns.Location = new System.Drawing.Point(263, 65);
            this.cboAllColumns.Name = "cboAllColumns";
            this.cboAllColumns.Size = new System.Drawing.Size(121, 21);
            this.cboAllColumns.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(346, 198);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "< - >";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(371, 199);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 32;
            this.label7.Text = "Dest DB:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 199);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 31;
            this.label8.Text = "Source DB:";
            // 
            // txtSourceDB
            // 
            this.txtSourceDB.Location = new System.Drawing.Point(92, 196);
            this.txtSourceDB.Name = "txtSourceDB";
            this.txtSourceDB.Size = new System.Drawing.Size(132, 20);
            this.txtSourceDB.TabIndex = 30;
            this.txtSourceDB.Text = "dbmoc1.Test3";
            // 
            // txtDestDB
            // 
            this.txtDestDB.Location = new System.Drawing.Point(451, 196);
            this.txtDestDB.Name = "txtDestDB";
            this.txtDestDB.Size = new System.Drawing.Size(132, 20);
            this.txtDestDB.TabIndex = 29;
            this.txtDestDB.Text = "dbmoc.Test";
            // 
            // btnMergeDB
            // 
            this.btnMergeDB.Location = new System.Drawing.Point(691, 193);
            this.btnMergeDB.Name = "btnMergeDB";
            this.btnMergeDB.Size = new System.Drawing.Size(104, 23);
            this.btnMergeDB.TabIndex = 34;
            this.btnMergeDB.Text = "Merge DB";
            this.btnMergeDB.UseVisualStyleBackColor = true;
            this.btnMergeDB.Click += new System.EventHandler(this.btnMergeDB_Click);
            // 
            // btnGetSourceDB
            // 
            this.btnGetSourceDB.Location = new System.Drawing.Point(230, 193);
            this.btnGetSourceDB.Name = "btnGetSourceDB";
            this.btnGetSourceDB.Size = new System.Drawing.Size(106, 23);
            this.btnGetSourceDB.TabIndex = 35;
            this.btnGetSourceDB.Text = "Get Source DB";
            this.btnGetSourceDB.UseVisualStyleBackColor = true;
            this.btnGetSourceDB.Click += new System.EventHandler(this.btnGetSourceDB_Click);
            // 
            // btnGetDestDB
            // 
            this.btnGetDestDB.Location = new System.Drawing.Point(589, 193);
            this.btnGetDestDB.Name = "btnGetDestDB";
            this.btnGetDestDB.Size = new System.Drawing.Size(93, 23);
            this.btnGetDestDB.TabIndex = 36;
            this.btnGetDestDB.Text = "Get Dest DB";
            this.btnGetDestDB.UseVisualStyleBackColor = true;
            this.btnGetDestDB.Click += new System.EventHandler(this.btnGetDestDB_Click);
            // 
            // btnGetDestTable
            // 
            this.btnGetDestTable.Location = new System.Drawing.Point(589, 167);
            this.btnGetDestTable.Name = "btnGetDestTable";
            this.btnGetDestTable.Size = new System.Drawing.Size(93, 23);
            this.btnGetDestTable.TabIndex = 38;
            this.btnGetDestTable.Text = "Get Dest Table";
            this.btnGetDestTable.UseVisualStyleBackColor = true;
            this.btnGetDestTable.Click += new System.EventHandler(this.btnGetDestTable_Click);
            // 
            // btnGetSourceTable
            // 
            this.btnGetSourceTable.Location = new System.Drawing.Point(230, 167);
            this.btnGetSourceTable.Name = "btnGetSourceTable";
            this.btnGetSourceTable.Size = new System.Drawing.Size(106, 23);
            this.btnGetSourceTable.TabIndex = 37;
            this.btnGetSourceTable.Text = "Get Source Table";
            this.btnGetSourceTable.UseVisualStyleBackColor = true;
            this.btnGetSourceTable.Click += new System.EventHandler(this.btnGetSourceTable_Click);
            // 
            // btnLinkedServers
            // 
            this.btnLinkedServers.Location = new System.Drawing.Point(149, 32);
            this.btnLinkedServers.Name = "btnLinkedServers";
            this.btnLinkedServers.Size = new System.Drawing.Size(89, 23);
            this.btnLinkedServers.TabIndex = 39;
            this.btnLinkedServers.Text = "Linked Servers";
            this.btnLinkedServers.UseVisualStyleBackColor = true;
            this.btnLinkedServers.Click += new System.EventHandler(this.btnLinkedServers_Click);
            // 
            // btnStoreMergeDB
            // 
            this.btnStoreMergeDB.Location = new System.Drawing.Point(230, 222);
            this.btnStoreMergeDB.Name = "btnStoreMergeDB";
            this.btnStoreMergeDB.Size = new System.Drawing.Size(106, 23);
            this.btnStoreMergeDB.TabIndex = 40;
            this.btnStoreMergeDB.Text = "Store Merge DB";
            this.btnStoreMergeDB.UseVisualStyleBackColor = true;
            this.btnStoreMergeDB.Click += new System.EventHandler(this.btnStoreMergeDB_Click);
            // 
            // btnMergeDBFromSql
            // 
            this.btnMergeDBFromSql.Location = new System.Drawing.Point(589, 222);
            this.btnMergeDBFromSql.Name = "btnMergeDBFromSql";
            this.btnMergeDBFromSql.Size = new System.Drawing.Size(134, 23);
            this.btnMergeDBFromSql.TabIndex = 41;
            this.btnMergeDBFromSql.Text = "Merge DB From SQL";
            this.btnMergeDBFromSql.UseVisualStyleBackColor = true;
            this.btnMergeDBFromSql.Click += new System.EventHandler(this.btnMergeDBFromSql_Click);
            // 
            // cboSyncDBs
            // 
            this.cboSyncDBs.FormattingEnabled = true;
            this.cboSyncDBs.Location = new System.Drawing.Point(451, 222);
            this.cboSyncDBs.Name = "cboSyncDBs";
            this.cboSyncDBs.Size = new System.Drawing.Size(132, 21);
            this.cboSyncDBs.TabIndex = 42;
            // 
            // btnWebTable
            // 
            this.btnWebTable.Location = new System.Drawing.Point(380, 20);
            this.btnWebTable.Name = "btnWebTable";
            this.btnWebTable.Size = new System.Drawing.Size(104, 23);
            this.btnWebTable.TabIndex = 43;
            this.btnWebTable.Text = "Web Table";
            this.btnWebTable.UseVisualStyleBackColor = true;
            this.btnWebTable.Click += new System.EventHandler(this.btnWebTable_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 13);
            this.label9.TabIndex = 45;
            this.label9.Text = "Table:";
            // 
            // txtTable
            // 
            this.txtTable.Location = new System.Drawing.Point(55, 20);
            this.txtTable.Name = "txtTable";
            this.txtTable.Size = new System.Drawing.Size(132, 20);
            this.txtTable.TabIndex = 44;
            this.txtTable.Text = "dbmoc1.Test3.dbo.Table3";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnConfigCollectData);
            this.groupBox1.Controls.Add(this.btnGetTable);
            this.groupBox1.Controls.Add(this.chkDaily);
            this.groupBox1.Controls.Add(this.txtTable);
            this.groupBox1.Controls.Add(this.btnWebTable);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Location = new System.Drawing.Point(12, 303);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(628, 57);
            this.groupBox1.TabIndex = 46;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Web Request";
            // 
            // btnConfigCollectData
            // 
            this.btnConfigCollectData.Location = new System.Drawing.Point(490, 20);
            this.btnConfigCollectData.Name = "btnConfigCollectData";
            this.btnConfigCollectData.Size = new System.Drawing.Size(122, 23);
            this.btnConfigCollectData.TabIndex = 48;
            this.btnConfigCollectData.Text = "Config Collect Data";
            this.btnConfigCollectData.UseVisualStyleBackColor = true;
            this.btnConfigCollectData.Click += new System.EventHandler(this.btnConfigCollectData_Click);
            // 
            // btnGetTable
            // 
            this.btnGetTable.Location = new System.Drawing.Point(266, 19);
            this.btnGetTable.Name = "btnGetTable";
            this.btnGetTable.Size = new System.Drawing.Size(106, 23);
            this.btnGetTable.TabIndex = 47;
            this.btnGetTable.Text = "Get Table";
            this.btnGetTable.UseVisualStyleBackColor = true;
            this.btnGetTable.Click += new System.EventHandler(this.btnGetTable_Click);
            // 
            // chkDaily
            // 
            this.chkDaily.AutoSize = true;
            this.chkDaily.Location = new System.Drawing.Point(207, 22);
            this.chkDaily.Name = "chkDaily";
            this.chkDaily.Size = new System.Drawing.Size(60, 17);
            this.chkDaily.TabIndex = 46;
            this.chkDaily.Text = "Is Daily";
            this.chkDaily.UseVisualStyleBackColor = true;
            // 
            // chkTwoDirection
            // 
            this.chkTwoDirection.AutoSize = true;
            this.chkTwoDirection.Location = new System.Drawing.Point(127, 226);
            this.chkTwoDirection.Name = "chkTwoDirection";
            this.chkTwoDirection.Size = new System.Drawing.Size(97, 17);
            this.chkTwoDirection.TabIndex = 47;
            this.chkTwoDirection.Text = "Two Directions";
            this.chkTwoDirection.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnBrowseDB);
            this.groupBox2.Controls.Add(this.txtDBFolder);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.btnRestore);
            this.groupBox2.Controls.Add(this.btnBrowseBackup);
            this.groupBox2.Controls.Add(this.txtBackupFolder);
            this.groupBox2.Controls.Add(this.btnBackup);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Location = new System.Drawing.Point(12, 377);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(628, 66);
            this.groupBox2.TabIndex = 48;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "DB Tools";
            // 
            // btnBrowseDB
            // 
            this.btnBrowseDB.Location = new System.Drawing.Point(232, 44);
            this.btnBrowseDB.Name = "btnBrowseDB";
            this.btnBrowseDB.Size = new System.Drawing.Size(35, 23);
            this.btnBrowseDB.TabIndex = 51;
            this.btnBrowseDB.Text = "...";
            this.btnBrowseDB.UseVisualStyleBackColor = true;
            this.btnBrowseDB.Click += new System.EventHandler(this.btnBrowseDB_Click);
            // 
            // txtDBFolder
            // 
            this.txtDBFolder.Location = new System.Drawing.Point(94, 46);
            this.txtDBFolder.Name = "txtDBFolder";
            this.txtDBFolder.Size = new System.Drawing.Size(132, 20);
            this.txtDBFolder.TabIndex = 49;
            this.txtDBFolder.Text = "D:\\Projects\\Database";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 49);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 13);
            this.label11.TabIndex = 50;
            this.label11.Text = "DB path:";
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(383, 19);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(122, 23);
            this.btnRestore.TabIndex = 48;
            this.btnRestore.Text = "Restore";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // btnBrowseBackup
            // 
            this.btnBrowseBackup.Location = new System.Drawing.Point(232, 20);
            this.btnBrowseBackup.Name = "btnBrowseBackup";
            this.btnBrowseBackup.Size = new System.Drawing.Size(35, 23);
            this.btnBrowseBackup.TabIndex = 47;
            this.btnBrowseBackup.Text = "...";
            this.btnBrowseBackup.UseVisualStyleBackColor = true;
            this.btnBrowseBackup.Click += new System.EventHandler(this.btnBrowseBackup_Click);
            // 
            // txtBackupFolder
            // 
            this.txtBackupFolder.Location = new System.Drawing.Point(94, 20);
            this.txtBackupFolder.Name = "txtBackupFolder";
            this.txtBackupFolder.Size = new System.Drawing.Size(132, 20);
            this.txtBackupFolder.TabIndex = 44;
            this.txtBackupFolder.Text = "D:\\Projects\\Database\\Backup";
            // 
            // btnBackup
            // 
            this.btnBackup.Location = new System.Drawing.Point(273, 20);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(104, 23);
            this.btnBackup.TabIndex = 43;
            this.btnBackup.Text = "Backup";
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 13);
            this.label10.TabIndex = 45;
            this.label10.Text = "Backup path:";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 455);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.chkTwoDirection);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cboSyncDBs);
            this.Controls.Add(this.btnMergeDBFromSql);
            this.Controls.Add(this.btnStoreMergeDB);
            this.Controls.Add(this.btnLinkedServers);
            this.Controls.Add(this.btnGetDestTable);
            this.Controls.Add(this.btnGetSourceTable);
            this.Controls.Add(this.btnGetDestDB);
            this.Controls.Add(this.btnGetSourceDB);
            this.Controls.Add(this.btnMergeDB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtSourceDB);
            this.Controls.Add(this.txtDestDB);
            this.Controls.Add(this.cboAllColumns);
            this.Controls.Add(this.cboAllTables);
            this.Controls.Add(this.cboAllDBs);
            this.Controls.Add(this.txtLinkedServerName);
            this.Controls.Add(this.btnAddLinkedServer);
            this.Controls.Add(this.cboLinkedServers);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtLinkedServerIP);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnMergeTable);
            this.Controls.Add(this.txtSourceTable);
            this.Controls.Add(this.txtDestTable);
            this.Controls.Add(this.txtSql);
            this.Controls.Add(this.btnExecuteQuery);
            this.Controls.Add(this.btnColumns);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.btnGetTables);
            this.Controls.Add(this.btnConnectDB);
            this.Controls.Add(this.txtConnection);
            this.Controls.Add(this.btnGetDBs);
            this.Controls.Add(this.btnCloseConnection);
            this.Name = "frmMain";
            this.Text = "DB Synchronization";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCloseConnection;
        private System.Windows.Forms.Button btnGetDBs;
        private System.Windows.Forms.TextBox txtConnection;
        private System.Windows.Forms.Button btnConnectDB;
        private System.Windows.Forms.Button btnGetTables;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button btnColumns;
        private System.Windows.Forms.Button btnExecuteQuery;
        private System.Windows.Forms.TextBox txtSql;
        private System.Windows.Forms.TextBox txtDestTable;
        private System.Windows.Forms.TextBox txtSourceTable;
        private System.Windows.Forms.Button btnMergeTable;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtLinkedServerIP;
        private System.Windows.Forms.ComboBox cboLinkedServers;
        private System.Windows.Forms.Button btnAddLinkedServer;
        private System.Windows.Forms.TextBox txtLinkedServerName;
        private System.Windows.Forms.ComboBox cboAllDBs;
        private System.Windows.Forms.ComboBox cboAllTables;
        private System.Windows.Forms.ComboBox cboAllColumns;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSourceDB;
        private System.Windows.Forms.TextBox txtDestDB;
        private System.Windows.Forms.Button btnMergeDB;
        private System.Windows.Forms.Button btnGetSourceDB;
        private System.Windows.Forms.Button btnGetDestDB;
        private System.Windows.Forms.Button btnGetDestTable;
        private System.Windows.Forms.Button btnGetSourceTable;
        private System.Windows.Forms.Button btnLinkedServers;
        private System.Windows.Forms.Button btnStoreMergeDB;
        private System.Windows.Forms.Button btnMergeDBFromSql;
        private System.Windows.Forms.ComboBox cboSyncDBs;
        private System.Windows.Forms.Button btnWebTable;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTable;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkDaily;
        private System.Windows.Forms.Button btnGetTable;
        private System.Windows.Forms.Button btnConfigCollectData;
        private System.Windows.Forms.CheckBox chkTwoDirection;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtDBFolder;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Button btnBrowseBackup;
        private System.Windows.Forms.TextBox txtBackupFolder;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.FolderBrowserDialog dlgBrowse;
        private System.Windows.Forms.Button btnBrowseDB;
        private System.Windows.Forms.SaveFileDialog dlgSave;
    }
}

