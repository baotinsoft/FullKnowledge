namespace Land
{
    partial class frmLand
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
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.btnGenWeb = new System.Windows.Forms.Button();
            this.lblComment = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnDetailWeb = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cboStreet = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboDistrict = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboWard = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAlleyWide = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.chkAgent = new System.Windows.Forms.CheckBox();
            this.chkDeadline = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtArea = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtWide = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtLength = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cboDirection = new System.Windows.Forms.ComboBox();
            this.chkHouse = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtFloor = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtAgentPrice = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtExpectedPrice = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtTax = new System.Windows.Forms.TextBox();
            this.chkMezzanine = new System.Windows.Forms.CheckBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtBedRoom = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtRestRoom = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.cboHouseLevel = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.chkIsSale = new System.Windows.Forms.CheckBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtTotalPages = new System.Windows.Forms.TextBox();
            this.btnDetailDisk = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnCal = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.txtPricePerMet = new System.Windows.Forms.TextBox();
            this.lblLastDate = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.txtPageStart = new System.Windows.Forms.TextBox();
            this.btnGenDisk = new System.Windows.Forms.Button();
            this.chkDelFile = new System.Windows.Forms.CheckBox();
            this.btnDelAllFiles = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.chkArea = new System.Windows.Forms.CheckBox();
            this.btnUpdateArea = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(441, 123);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(116, 23);
            this.btnUpdate.TabIndex = 0;
            this.btnUpdate.Text = "Cập Nhật";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(98, 48);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(335, 20);
            this.txtAddress.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 54);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(43, 13);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Địa chỉ:";
            // 
            // dgvList
            // 
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Location = new System.Drawing.Point(716, 6);
            this.dgvList.Name = "dgvList";
            this.dgvList.Size = new System.Drawing.Size(282, 529);
            this.dgvList.TabIndex = 4;
            this.dgvList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellClick);
            // 
            // btnGenWeb
            // 
            this.btnGenWeb.Location = new System.Drawing.Point(441, 69);
            this.btnGenWeb.Name = "btnGenWeb";
            this.btnGenWeb.Size = new System.Drawing.Size(116, 23);
            this.btnGenWeb.TabIndex = 26;
            this.btnGenWeb.Text = "Tổng Quan Từ Web";
            this.btnGenWeb.UseVisualStyleBackColor = true;
            this.btnGenWeb.Click += new System.EventHandler(this.btnGenWeb_Click);
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.Location = new System.Drawing.Point(12, 500);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(48, 13);
            this.lblComment.TabIndex = 40;
            this.lblComment.Text = "Ghi Chú:";
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(98, 479);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(335, 56);
            this.txtComment.TabIndex = 39;
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(439, 186);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMessage.Size = new System.Drawing.Size(271, 349);
            this.txtMessage.TabIndex = 41;
            // 
            // btnDetailWeb
            // 
            this.btnDetailWeb.Location = new System.Drawing.Point(441, 96);
            this.btnDetailWeb.Name = "btnDetailWeb";
            this.btnDetailWeb.Size = new System.Drawing.Size(116, 23);
            this.btnDetailWeb.TabIndex = 50;
            this.btnDetailWeb.Text = "Chi Tiết Từ Web";
            this.btnDetailWeb.UseVisualStyleBackColor = true;
            this.btnDetailWeb.Click += new System.EventHandler(this.btnDetailWeb_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 54;
            this.label6.Text = "Đường:";
            // 
            // cboStreet
            // 
            this.cboStreet.FormattingEnabled = true;
            this.cboStreet.Location = new System.Drawing.Point(98, 76);
            this.cboStreet.Name = "cboStreet";
            this.cboStreet.Size = new System.Drawing.Size(335, 21);
            this.cboStreet.TabIndex = 53;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 56;
            this.label1.Text = "Quận:";
            // 
            // cboDistrict
            // 
            this.cboDistrict.FormattingEnabled = true;
            this.cboDistrict.Location = new System.Drawing.Point(98, 103);
            this.cboDistrict.Name = "cboDistrict";
            this.cboDistrict.Size = new System.Drawing.Size(335, 21);
            this.cboDistrict.TabIndex = 55;
            this.cboDistrict.SelectedIndexChanged += new System.EventHandler(this.cboDistrict_SelectedIndexChanged);
            this.cboDistrict.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboDistrict_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 58;
            this.label2.Text = "Phường:";
            // 
            // cboWard
            // 
            this.cboWard.FormattingEnabled = true;
            this.cboWard.Location = new System.Drawing.Point(98, 130);
            this.cboWard.Name = "cboWard";
            this.cboWard.Size = new System.Drawing.Size(335, 21);
            this.cboWard.TabIndex = 57;
            this.cboWard.SelectedIndexChanged += new System.EventHandler(this.cboWard_SelectedIndexChanged);
            this.cboWard.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboWard_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 60;
            this.label3.Text = "Hẻm rộng:";
            // 
            // txtAlleyWide
            // 
            this.txtAlleyWide.Location = new System.Drawing.Point(98, 157);
            this.txtAlleyWide.Name = "txtAlleyWide";
            this.txtAlleyWide.Size = new System.Drawing.Size(113, 20);
            this.txtAlleyWide.TabIndex = 59;
            this.txtAlleyWide.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 62;
            this.label4.Text = "Liên hệ:";
            // 
            // txtContact
            // 
            this.txtContact.Location = new System.Drawing.Point(98, 183);
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(335, 20);
            this.txtContact.TabIndex = 61;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(236, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 64;
            this.label5.Text = "Phone:";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(322, 157);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(113, 20);
            this.txtPhone.TabIndex = 63;
            // 
            // chkAgent
            // 
            this.chkAgent.AutoSize = true;
            this.chkAgent.Location = new System.Drawing.Point(15, 241);
            this.chkAgent.Name = "chkAgent";
            this.chkAgent.Size = new System.Drawing.Size(62, 17);
            this.chkAgent.TabIndex = 65;
            this.chkAgent.Text = "Môi giới";
            this.chkAgent.UseVisualStyleBackColor = true;
            // 
            // chkDeadline
            // 
            this.chkDeadline.AutoSize = true;
            this.chkDeadline.Location = new System.Drawing.Point(98, 241);
            this.chkDeadline.Name = "chkDeadline";
            this.chkDeadline.Size = new System.Drawing.Size(64, 17);
            this.chkDeadline.TabIndex = 66;
            this.chkDeadline.Text = "Hết hạn";
            this.chkDeadline.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 267);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 68;
            this.label7.Text = "Diện tích:";
            // 
            // txtArea
            // 
            this.txtArea.Location = new System.Drawing.Point(98, 264);
            this.txtArea.Name = "txtArea";
            this.txtArea.Size = new System.Drawing.Size(70, 20);
            this.txtArea.TabIndex = 67;
            this.txtArea.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(175, 267);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 13);
            this.label8.TabIndex = 70;
            this.label8.Text = "=";
            // 
            // txtWide
            // 
            this.txtWide.Location = new System.Drawing.Point(204, 264);
            this.txtWide.Name = "txtWide";
            this.txtWide.Size = new System.Drawing.Size(70, 20);
            this.txtWide.TabIndex = 69;
            this.txtWide.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(291, 267);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(12, 13);
            this.label9.TabIndex = 72;
            this.label9.Text = "x";
            // 
            // txtLength
            // 
            this.txtLength.Location = new System.Drawing.Point(316, 264);
            this.txtLength.Name = "txtLength";
            this.txtLength.Size = new System.Drawing.Size(70, 20);
            this.txtLength.TabIndex = 71;
            this.txtLength.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 293);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 13);
            this.label10.TabIndex = 74;
            this.label10.Text = "Hướng:";
            // 
            // cboDirection
            // 
            this.cboDirection.FormattingEnabled = true;
            this.cboDirection.Location = new System.Drawing.Point(98, 290);
            this.cboDirection.Name = "cboDirection";
            this.cboDirection.Size = new System.Drawing.Size(335, 21);
            this.cboDirection.TabIndex = 73;
            // 
            // chkHouse
            // 
            this.chkHouse.AutoSize = true;
            this.chkHouse.Location = new System.Drawing.Point(187, 241);
            this.chkHouse.Name = "chkHouse";
            this.chkHouse.Size = new System.Drawing.Size(46, 17);
            this.chkHouse.TabIndex = 75;
            this.chkHouse.Text = "Nhà";
            this.chkHouse.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 320);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 13);
            this.label11.TabIndex = 77;
            this.label11.Text = "Số tầng:";
            // 
            // txtFloor
            // 
            this.txtFloor.Location = new System.Drawing.Point(98, 317);
            this.txtFloor.Name = "txtFloor";
            this.txtFloor.Size = new System.Drawing.Size(70, 20);
            this.txtFloor.TabIndex = 76;
            this.txtFloor.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(170, 369);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(26, 13);
            this.label12.TabIndex = 79;
            this.label12.Text = "Giá:";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(202, 366);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(70, 20);
            this.txtPrice.TabIndex = 78;
            this.txtPrice.Text = "0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(11, 369);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(76, 13);
            this.label13.TabIndex = 81;
            this.label13.Text = "Giá từ môi giới:";
            // 
            // txtAgentPrice
            // 
            this.txtAgentPrice.Location = new System.Drawing.Point(98, 366);
            this.txtAgentPrice.Name = "txtAgentPrice";
            this.txtAgentPrice.Size = new System.Drawing.Size(70, 20);
            this.txtAgentPrice.TabIndex = 80;
            this.txtAgentPrice.Text = "0";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(282, 369);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(74, 13);
            this.label14.TabIndex = 83;
            this.label14.Text = "Giá từ k.vọng:";
            // 
            // txtExpectedPrice
            // 
            this.txtExpectedPrice.Location = new System.Drawing.Point(365, 366);
            this.txtExpectedPrice.Name = "txtExpectedPrice";
            this.txtExpectedPrice.Size = new System.Drawing.Size(70, 20);
            this.txtExpectedPrice.TabIndex = 82;
            this.txtExpectedPrice.Text = "0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(11, 421);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(23, 13);
            this.label15.TabIndex = 85;
            this.label15.Text = "Url:";
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(98, 418);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(335, 20);
            this.txtUrl.TabIndex = 84;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(11, 447);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(35, 13);
            this.label16.TabIndex = 87;
            this.label16.Text = "Thuế:";
            // 
            // txtTax
            // 
            this.txtTax.Location = new System.Drawing.Point(98, 444);
            this.txtTax.Name = "txtTax";
            this.txtTax.Size = new System.Drawing.Size(70, 20);
            this.txtTax.TabIndex = 86;
            this.txtTax.Text = "0";
            // 
            // chkMezzanine
            // 
            this.chkMezzanine.AutoSize = true;
            this.chkMezzanine.Location = new System.Drawing.Point(257, 241);
            this.chkMezzanine.Name = "chkMezzanine";
            this.chkMezzanine.Size = new System.Drawing.Size(78, 17);
            this.chkMezzanine.TabIndex = 88;
            this.chkMezzanine.Text = "Tầng Lửng";
            this.chkMezzanine.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(170, 320);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(77, 13);
            this.label17.TabIndex = 90;
            this.label17.Text = "Số phòng ngủ:";
            // 
            // txtBedRoom
            // 
            this.txtBedRoom.Location = new System.Drawing.Point(271, 317);
            this.txtBedRoom.Name = "txtBedRoom";
            this.txtBedRoom.Size = new System.Drawing.Size(70, 20);
            this.txtBedRoom.TabIndex = 89;
            this.txtBedRoom.Text = "0";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(11, 343);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(52, 13);
            this.label18.TabIndex = 92;
            this.label18.Text = "Số toalet:";
            // 
            // txtRestRoom
            // 
            this.txtRestRoom.Location = new System.Drawing.Point(98, 340);
            this.txtRestRoom.Name = "txtRestRoom";
            this.txtRestRoom.Size = new System.Drawing.Size(70, 20);
            this.txtRestRoom.TabIndex = 91;
            this.txtRestRoom.Text = "0";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(11, 212);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(51, 13);
            this.label19.TabIndex = 94;
            this.label19.Text = "Nhà cấp:";
            // 
            // cboHouseLevel
            // 
            this.cboHouseLevel.FormattingEnabled = true;
            this.cboHouseLevel.Location = new System.Drawing.Point(98, 209);
            this.cboHouseLevel.Name = "cboHouseLevel";
            this.cboHouseLevel.Size = new System.Drawing.Size(113, 21);
            this.cboHouseLevel.TabIndex = 95;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(12, 18);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(47, 13);
            this.label20.TabIndex = 97;
            this.label20.Text = "Tiêu đề:";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(98, 12);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(335, 20);
            this.txtTitle.TabIndex = 96;
            // 
            // chkIsSale
            // 
            this.chkIsSale.AutoSize = true;
            this.chkIsSale.Location = new System.Drawing.Point(355, 241);
            this.chkIsSale.Name = "chkIsSale";
            this.chkIsSale.Size = new System.Drawing.Size(45, 17);
            this.chkIsSale.TabIndex = 98;
            this.chkIsSale.Text = "Bán";
            this.chkIsSale.UseVisualStyleBackColor = true;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(572, 18);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(76, 13);
            this.label21.TabIndex = 100;
            this.label21.Text = "Tổng số trang:";
            // 
            // txtTotalPages
            // 
            this.txtTotalPages.Location = new System.Drawing.Point(658, 12);
            this.txtTotalPages.Name = "txtTotalPages";
            this.txtTotalPages.Size = new System.Drawing.Size(39, 20);
            this.txtTotalPages.TabIndex = 99;
            this.txtTotalPages.Text = "10";
            this.txtTotalPages.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTotalPages_KeyDown);
            // 
            // btnDetailDisk
            // 
            this.btnDetailDisk.Location = new System.Drawing.Point(563, 98);
            this.btnDetailDisk.Name = "btnDetailDisk";
            this.btnDetailDisk.Size = new System.Drawing.Size(116, 23);
            this.btnDetailDisk.TabIndex = 101;
            this.btnDetailDisk.Text = "Chi Tiết Từ Disk";
            this.btnDetailDisk.UseVisualStyleBackColor = true;
            this.btnDetailDisk.Click += new System.EventHandler(this.btnDetailDisk_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(514, 155);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(53, 23);
            this.btnRefresh.TabIndex = 102;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnCal
            // 
            this.btnCal.Location = new System.Drawing.Point(392, 264);
            this.btnCal.Name = "btnCal";
            this.btnCal.Size = new System.Drawing.Size(43, 23);
            this.btnCal.TabIndex = 103;
            this.btnCal.Text = "Cal";
            this.btnCal.UseVisualStyleBackColor = true;
            this.btnCal.Click += new System.EventHandler(this.btnCal_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(12, 395);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(49, 13);
            this.label22.TabIndex = 105;
            this.label22.Text = "Đơn Giá:";
            // 
            // txtPricePerMet
            // 
            this.txtPricePerMet.Location = new System.Drawing.Point(98, 392);
            this.txtPricePerMet.Name = "txtPricePerMet";
            this.txtPricePerMet.Size = new System.Drawing.Size(70, 20);
            this.txtPricePerMet.TabIndex = 104;
            this.txtPricePerMet.Text = "0";
            // 
            // lblLastDate
            // 
            this.lblLastDate.AutoSize = true;
            this.lblLastDate.Location = new System.Drawing.Point(511, 48);
            this.lblLastDate.Name = "lblLastDate";
            this.lblLastDate.Size = new System.Drawing.Size(56, 13);
            this.lblLastDate.TabIndex = 106;
            this.lblLastDate.Text = "Last Date:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(442, 18);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(78, 13);
            this.label23.TabIndex = 108;
            this.label23.Text = "Trang bắt đầu:";
            // 
            // txtPageStart
            // 
            this.txtPageStart.Location = new System.Drawing.Point(528, 12);
            this.txtPageStart.Name = "txtPageStart";
            this.txtPageStart.Size = new System.Drawing.Size(39, 20);
            this.txtPageStart.TabIndex = 107;
            this.txtPageStart.Text = "1";
            // 
            // btnGenDisk
            // 
            this.btnGenDisk.Location = new System.Drawing.Point(563, 69);
            this.btnGenDisk.Name = "btnGenDisk";
            this.btnGenDisk.Size = new System.Drawing.Size(116, 23);
            this.btnGenDisk.TabIndex = 109;
            this.btnGenDisk.Text = "Tổng Quan Từ Disk";
            this.btnGenDisk.UseVisualStyleBackColor = true;
            this.btnGenDisk.Click += new System.EventHandler(this.btnGenDisk_Click);
            // 
            // chkDelFile
            // 
            this.chkDelFile.AutoSize = true;
            this.chkDelFile.Location = new System.Drawing.Point(441, 47);
            this.chkDelFile.Name = "chkDelFile";
            this.chkDelFile.Size = new System.Drawing.Size(64, 17);
            this.chkDelFile.TabIndex = 110;
            this.chkDelFile.Text = "Xóa File";
            this.chkDelFile.UseVisualStyleBackColor = true;
            // 
            // btnDelAllFiles
            // 
            this.btnDelAllFiles.Location = new System.Drawing.Point(563, 123);
            this.btnDelAllFiles.Name = "btnDelAllFiles";
            this.btnDelAllFiles.Size = new System.Drawing.Size(116, 23);
            this.btnDelAllFiles.TabIndex = 111;
            this.btnDelAllFiles.Text = "Del All Files";
            this.btnDelAllFiles.UseVisualStyleBackColor = true;
            this.btnDelAllFiles.Click += new System.EventHandler(this.btnDelAllFiles_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(573, 155);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(54, 23);
            this.btnSearch.TabIndex = 112;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // chkArea
            // 
            this.chkArea.AutoSize = true;
            this.chkArea.Location = new System.Drawing.Point(441, 163);
            this.chkArea.Name = "chkArea";
            this.chkArea.Size = new System.Drawing.Size(74, 17);
            this.chkArea.TabIndex = 113;
            this.chkArea.Text = "Diện Tích";
            this.chkArea.UseVisualStyleBackColor = true;
            // 
            // btnUpdateArea
            // 
            this.btnUpdateArea.Location = new System.Drawing.Point(633, 154);
            this.btnUpdateArea.Name = "btnUpdateArea";
            this.btnUpdateArea.Size = new System.Drawing.Size(77, 23);
            this.btnUpdateArea.TabIndex = 114;
            this.btnUpdateArea.Text = "Update Area";
            this.btnUpdateArea.UseVisualStyleBackColor = true;
            this.btnUpdateArea.Click += new System.EventHandler(this.btnUpdateArea_Click);
            // 
            // frmLand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 541);
            this.Controls.Add(this.btnUpdateArea);
            this.Controls.Add(this.chkArea);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnDelAllFiles);
            this.Controls.Add(this.chkDelFile);
            this.Controls.Add(this.btnGenDisk);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.txtPageStart);
            this.Controls.Add(this.lblLastDate);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.txtPricePerMet);
            this.Controls.Add(this.btnCal);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnDetailDisk);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.txtTotalPages);
            this.Controls.Add(this.chkIsSale);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.cboHouseLevel);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.txtRestRoom);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txtBedRoom);
            this.Controls.Add(this.chkMezzanine);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtTax);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtExpectedPrice);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtAgentPrice);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtFloor);
            this.Controls.Add(this.chkHouse);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cboDirection);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtLength);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtWide);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtArea);
            this.Controls.Add(this.chkDeadline);
            this.Controls.Add(this.chkAgent);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtContact);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAlleyWide);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboWard);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboDistrict);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboStreet);
            this.Controls.Add(this.btnDetailWeb);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.lblComment);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.btnGenWeb);
            this.Controls.Add(this.dgvList);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.btnUpdate);
            this.Name = "frmLand";
            this.Text = "Land";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmLand_Load);
            this.SizeChanged += new System.EventHandler(this.frmLand_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.Button btnGenWeb;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnDetailWeb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboStreet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboDistrict;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboWard;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAlleyWide;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtContact;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.CheckBox chkAgent;
        private System.Windows.Forms.CheckBox chkDeadline;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtArea;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtWide;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtLength;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboDirection;
        private System.Windows.Forms.CheckBox chkHouse;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtFloor;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtAgentPrice;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtExpectedPrice;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtTax;
        private System.Windows.Forms.CheckBox chkMezzanine;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtBedRoom;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtRestRoom;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cboHouseLevel;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.CheckBox chkIsSale;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtTotalPages;
        private System.Windows.Forms.Button btnDetailDisk;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnCal;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtPricePerMet;
        private System.Windows.Forms.Label lblLastDate;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtPageStart;
        private System.Windows.Forms.Button btnGenDisk;
        private System.Windows.Forms.CheckBox chkDelFile;
        private System.Windows.Forms.Button btnDelAllFiles;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.CheckBox chkArea;
        private System.Windows.Forms.Button btnUpdateArea;
    }
}