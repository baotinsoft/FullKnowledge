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
using System.IO;
using System.Threading;

namespace Land
{
    public partial class frmLand : Form
    {
        // Fields
        private DBLand db = new DBLand();
        private int iId, districtId, wardId;
        private int pageAll = (29152/20);
        string pathGen = Application.StartupPath + @"\Data\General\";
        string pathDetail = Application.StartupPath + @"\Data\Detail\";
        private bool isAuto = false;
        int pages = 0;

        // Methods
        public frmLand(int pages)
        {
            isAuto = pages > 0 ? true : false;
            this.pages = pages;
            InitializeComponent();
        }

        private void GenWeb()
        {            
            txtMessage.Text = "";
            string code = db.UrlDefinitionList(2)[0].Code, url;
            // get Land
            int pageStart = Convert.ToInt32(txtPageStart.Text);
            int pageGet = txtTotalPages.Text == "0" ? pageAll : Convert.ToInt32(txtTotalPages.Text);
            for (int page = pageStart; page <= pageGet; page++)
            {
                url = code.Replace("o=1", "o=" + page);
                if (!WebLib.HttpPost(url, pathGen, page))
                {
                    txtMessage.AppendText("Không lấy được dữ liệu từ " + url);
                    txtMessage.AppendText(Environment.NewLine);
                }
                else
                {
                    txtMessage.AppendText("Lấy xong dữ liệu từ " + url);
                    txtMessage.AppendText(Environment.NewLine);
                }
            }
            GenDisk();              
        }

        private void GenDisk()
        {
            int pageStart = Convert.ToInt32(txtPageStart.Text);
            int pageGet = txtTotalPages.Text == "0" ? pageAll : Convert.ToInt32(txtTotalPages.Text);

            string[] files = Directory.GetFiles(pathGen);
            string[] lstSource = new string[28];
            string str6 = pathGen + @"\" + WebLib.GetDateName(DateTime.Now.Date) + "-";
            int index, count = 0;
            for (int i = pageStart; i <= pageGet; i++)
            {
                string str5;
                string str7 = str6;
                try
                {
                    str7 = str7 + i + ".htm";
                    count = 0;
                    StreamReader reader = new StreamReader(str7);
                    int length;
                    if ((str5 = reader.ReadToEnd()) != null)
                    {
                        if ((length = str5.IndexOf("<div class=\"chotot-list-row\"")) >= 0)
                        {
                            str5 = str5.Substring(length + 31, str5.Length - length - 31);
                            while ((index = str5.IndexOf("title=\"")) >= 0)
                            {
                                str5 = str5.Substring(index + 7, (str5.Length - index) - 7);
                                length = str5.IndexOf("\"");
                                lstSource[0] = str5.Substring(0, length).Trim(); //title

                                length = str5.IndexOf("href=\"");
                                str5 = str5.Substring(length + 6, str5.Length - length - 6);
                                length = str5.IndexOf("\"");
                                lstSource[22] = str5.Substring(0, length); //url
                                str5 = str5.Substring(length, str5.Length - length);


                                length = str5.IndexOf("<div class=\"ad-price\"");
                                str5 = str5.Substring(length + 21, (str5.Length - length) - 21);
                                index = str5.IndexOf(">");
                                str5 = str5.Substring(index + 1, (str5.Length - index) - 1);
                                index = str5.IndexOf("</div>");
                                lstSource[19] = str5.Substring(0, index).Replace("đ", "").Replace(".", "").Trim(); //price
                                index = str5.IndexOf("<span class=\"municipality\">");
                                str5 = str5.Substring(index + 27, (str5.Length - index) - 27);
                                index = str5.IndexOf("</span>");
                                lstSource[26] = str5.Substring(0, index).Replace("ở", "").Trim(); //district

                                //<span class="subtext">(
                                index = str5.IndexOf("class=\"listing_thumbs_date\"");
                                if (str5.Substring(0, index).IndexOf("(Môi giới)") != -1)
                                    lstSource[7] = "true"; //isAgent
                                else
                                    lstSource[7] = "false"; //isAgent

                                str5 = str5.Substring(index + 27, str5.Length - index - 27);
                                index = str5.IndexOf(">") + 1;
                                str5 = str5.Substring(index, str5.Length - index);
                                index = str5.IndexOf("</div>");
                                lstSource[25] = str5.Substring(0, index).Replace("\r\n", "").Replace("\t", "").Trim(); //Posted DateTime
                                lstSource[25] = ParseDate(lstSource[25]);

                                index = str5.IndexOf("<div class=\"clear_row\"></div>");
                                str5 = str5.Substring(index + 29, str5.Length - index - 29);

                                lstSource = ClearTag(lstSource);
                                db.LandInsert(lstSource);
                                count++;
                            }
                        }
                        else
                            txtMessage.Text = txtMessage.Text + "Records: " + count + "Lỗi file: " + str7 + "!\r\n";
                    }
                    txtMessage.Text = txtMessage.Text + "Records: " + count + ". Xử lý xong file " + str7 + "!\r\n";
                    reader.Close();
                }
                catch (Exception) { txtMessage.Text = txtMessage.Text + "Records: " + count + "Lỗi file: " + str7 + "!\r\n"; }
            }
            txtMessage.Text += "Finish!";
            if (chkDelFile.Checked)
                Array.ForEach(Directory.GetFiles(pathGen), delegate (string tempFile) { File.Delete(tempFile); });
        }

        private string ParseDate(string data)
        {
            //ngày 17 tháng 5<br>21:57
            //Hôm qua<br>08:56
            //7 phút trước
            //5 giờ 29 phút trước
            int pos, hour = 0, minute = 0;
            pos = data.IndexOf("giờ");
            if (pos > 0)
            {
                hour = Convert.ToInt32(data.Substring(0, pos - 1));
                data = data.Substring(pos + 3, data.Length - pos - 3);
            }

            pos = data.IndexOf("phút");
            if (pos > 0)
            {
                minute = Convert.ToInt32(data.Substring(0, pos - 1));
                data = data.Substring(pos + 4, data.Length - pos - 4);
            }
            if (hour > 0)
                data = DateTime.Now.AddHours(-hour).AddMinutes(-minute).ToString();
            else if (minute > 0)
                    data = DateTime.Now.AddMinutes(-minute).ToString();

            pos = data.IndexOf("Hôm qua");
            if (pos >= 0)
            {
                data = data.Substring(pos + 13, data.Length - pos - 13);
                hour = Convert.ToInt32(data.Substring(0, 2));
                minute = Convert.ToInt32(data.Substring(3, 2));
                data = DateTime.Now.Date.AddDays(-1).AddHours(hour).AddMinutes(minute).ToString();
            }

            pos = data.IndexOf("ngày");
            if (pos >= 0)
            {
                int day, month, year;
                data = data.Substring(pos + 5, data.Length - pos - 5);
                day = Convert.ToInt32(data.Substring(0, 2));
                month = Convert.ToInt32(data.Substring(8, 2).Replace("<",""));
                //year = Convert.ToInt32(data.Substring(0, 2));
                pos = data.IndexOf(":");
                data = data.Substring(pos - 2, 5);
                hour = Convert.ToInt32(data.Substring(0, 2));
                minute = Convert.ToInt32(data.Substring(3, 2));
                data = (new DateTime(DateTime.Now.Year, month, day)).AddHours(hour).AddMinutes(minute).ToString();
            }

            return data;
        }

        private void btnGenWeb_Click(object sender, EventArgs e)
        {
            GenWeb();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (iId > 0)
            {
                db.LandEdit(iId, txtTitle.Text, txtAddress.Text, ToInt(cboStreet.SelectedValue), ToInt(cboDistrict.SelectedValue), ToInt(cboWard.SelectedValue), ToDecimal(txtAlleyWide.Text), txtContact.Text, txtPhone.Text, chkAgent.Checked, chkDeadline.Checked, txtComment.Text, ToDecimal(txtArea.Text), ToDecimal(txtWide.Text), ToDecimal(txtLength.Text), ToInt(cboDirection.SelectedValue), chkHouse.Checked, ToInt(cboHouseLevel.SelectedValue), ToInt(txtBedRoom.Text),
                    ToInt(txtBedRoom.Text), ToInt(txtFloor.Text), ToDecimal(txtPrice.Text), ToDecimal(txtAgentPrice.Text), ToDecimal(txtExpectedPrice.Text), txtUrl.Text, ToDecimal(txtTax.Text), chkMezzanine.Checked, chkIsSale.Checked, ToDecimal(txtPricePerMet.Text));
            }
            else
            {
                db.LandInsert(txtTitle.Text, txtAddress.Text, ToInt(cboStreet.SelectedValue), ToInt(cboDistrict.SelectedValue), ToInt(cboWard.SelectedValue), ToDecimal(txtAlleyWide.Text), txtContact.Text, txtPhone.Text, chkAgent.Checked, chkDeadline.Checked, txtComment.Text, ToDecimal(txtArea.Text), ToDecimal(txtWide.Text), ToDecimal(txtLength.Text), ToInt(cboDirection.SelectedValue), chkHouse.Checked, ToInt(cboHouseLevel.SelectedValue), ToInt(txtBedRoom.Text),
                    ToInt(txtBedRoom.Text), ToInt(txtFloor.Text), ToDecimal(txtPrice.Text), ToDecimal(txtAgentPrice.Text), ToDecimal(txtExpectedPrice.Text), txtUrl.Text, ToDecimal(txtTax.Text), chkMezzanine.Checked, chkIsSale.Checked, ToDecimal(txtPricePerMet.Text));
            }
            DataLoad();
            DataReset();
        }

        private int ToInt(object strNumber)
        {
            if (strNumber == null) return 0;            
            try
            {
                return Convert.ToInt32(strNumber);
            }
            catch (Exception) { return 0; }
        }

        private decimal ToDecimal(object strNumber)
        {
            if (strNumber == null) return 0;
            try
            {
                return Convert.ToDecimal(strNumber);
            }
            catch (Exception) { return 0; }
        }

        private string[] ClearTag(string[] lstSource)
        {
            for (int i = 0; i < lstSource.Length; i++)
            {
                if (lstSource[i] != null)
                {
                    int num2;
                    int num3;
                    lstSource[i] = lstSource[i].Replace("\r\n", "").Replace("\t", "").Trim();
                    if ((((num2 = lstSource[i].IndexOf('<')) != -1) && ((num3 = lstSource[i].IndexOf('>')) != -1)) && (num3 > num2))
                    {
                        lstSource[i] = lstSource[i].Substring(num3, lstSource[i].Length - num3);
                    }
                }
            }
            return lstSource;
        }

        private void DataLoad()
        {
            lblLastDate.Text = "Last Date:" + db.LastUpdateDate();

            dgvList.DataSource = db.LandList();
            cboDirection.ValueMember = "Id";
            cboDirection.DisplayMember = "Code";
            cboDirection.DataSource = db.DefinitionList(1);

            cboDistrict.ValueMember = "Id";
            cboDistrict.DisplayMember = "Name";
            cboDistrict.DataSource = db.DefinitionList(5);

            cboWard.ValueMember = "Id";
            cboWard.DisplayMember = "Name";
            

            cboHouseLevel.ValueMember = "Id";
            cboHouseLevel.DisplayMember = "Code";
            cboHouseLevel.DataSource = db.DefinitionList(7);

            cboStreet.ValueMember = "Id";
            cboStreet.DisplayMember = "Name";
            cboStreet.DataSource = db.StreetList(0);

        }

        private void DataReset()
        {
            iId = 0;
            txtAddress.Text = "";
            foreach (Control control in base.Controls)
            {
                try
                {
                    if (control is TextBox)
                    {
                        ((TextBox)control).Text = "";
                    }
                    if (control is ComboBox)
                    {
                        ((ComboBox)control).SelectedIndex = 0;
                    }
                }
                catch (Exception) { }
            }
        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                iId = Convert.ToInt32(dgvList.Rows[e.RowIndex].Cells[0].Value);
                VLand obj = db.Land(iId);
                txtTitle.Text = obj.Title;
                txtAddress.Text = obj.Address;
                
                if (obj.DistrictId != null)
                {
                    cboDistrict.SelectedValue = obj.DistrictId.Value;
                    if (obj.StreetId==null)
                        cboStreet.DataSource = db.StreetList(obj.DistrictId.Value);
                }

                txtAlleyWide.Text = obj.AlleyWide.ToString();
                txtContact.Text = obj.Contact;
                txtPhone.Text = obj.Phone;
                chkAgent.Checked = Convert.ToBoolean(obj.IsAgent);
                chkDeadline.Checked = Convert.ToBoolean(obj.IsDue);
                txtComment.Text = obj.Comment;
                txtArea.Text = obj.Area.ToString();
                txtWide.Text = obj.Wide.ToString();
                txtLength.Text = obj.Length.ToString();
                cboDirection.SelectedValue = obj.DirectionId == null? 0 : obj.DirectionId;
                chkHouse.Checked = Convert.ToBoolean(obj.IsHouse);
                cboHouseLevel.SelectedValue = obj.HouseLevel == null ? 0 : (int)obj.HouseLevel;
                txtRestRoom.Text = obj.Restroom.ToString();
                txtBedRoom.Text = obj.Bedroom.ToString();
                txtFloor.Text = obj.Floor.ToString();
                txtPrice.Text = obj.Price == null? "": obj.Price.Value.ToString("#,##0.00");
                txtExpectedPrice.Text = obj.ExpectedPrice == null? "" : obj.ExpectedPrice.Value.ToString("#,##0.00");
                txtUrl.Text = obj.Url;
                txtTax.Text = obj.Tax.ToString();
                chkMezzanine.Checked = Convert.ToBoolean(obj.IsMezzanine);
                txtAgentPrice.Text = obj.AgentPrice == null? "" : obj.AgentPrice.Value.ToString("#,##0.00");
                chkIsSale.Checked = Convert.ToBoolean(obj.IsSale);
                cboWard.SelectedValue = obj.WardId == null ? 0 : obj.WardId;
                cboStreet.SelectedValue = obj.StreetId == null ? 0 : obj.StreetId;
                txtPricePerMet.Text = obj.PricePerMet == null ? "" : obj.PricePerMet.Value.ToString("#,##0.00");
            }
        }


        private void frmLand_Load(object sender, EventArgs e)
        {
            if (pages > 0)
            {
                this.Hide();
                txtTotalPages.Text = pages + "";
                chkDelFile.Checked = true;
                GenWeb();
                DetailWeb();
                Application.Exit();
            }
            if (!isAuto) DataLoad();
        }

        private void frmLand_SizeChanged(object sender, EventArgs e)
        {
            dgvList.Width = (base.Width - dgvList.Location.X) - 10;
            dgvList.Height = (base.Height - dgvList.Location.Y) - 10;
            txtMessage.Height = (base.Height - txtMessage.Location.Y) - 10;
        }


        private void cboDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDistrict.SelectedIndex != -1)
            {
                districtId = Convert.ToInt32(cboDistrict.SelectedValue);
                cboWard.DataSource = db.DefinitionList(6, districtId);
            }
        }

        private void cboDistrict_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                districtId = db.DefinitionExist(cboDistrict.Text, 5, 0);
        }

        private void cboWard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && districtId > 0)
                wardId = db.DefinitionExist(cboWard.Text, 5, districtId);
        }

        private void cboWard_SelectedIndexChanged(object sender, EventArgs e)
        {
            wardId = Convert.ToInt32(cboWard.SelectedValue);
        }

        private void btnDetailWeb_Click(object sender, EventArgs e)
        {
            DetailWeb();
        }

        private void DetailWeb()
        {
            txtMessage.Text = "";
            string url;
            List<int> lstInt;
            List<DBContext.Land> lst = db.LandNewList(out lstInt);
            // get Land
            string fileName;
            foreach (DBContext.Land item in lst)
            {
                url = item.Url;
                fileName = pathDetail + @"\" + item.Id.ToString() + ".htm";
                if (File.Exists(fileName)) continue;

                if (!WebLib.HttpPost(url, pathDetail, item.Id.ToString()))
                {

                    txtMessage.AppendText("Không lấy được dữ liệu từ " + url);
                    txtMessage.AppendText(Environment.NewLine);
                    db.LandIsDetail(item.Id, true);
                }
                else
                {
                    txtMessage.AppendText("Lấy xong dữ liệu từ " + url);
                    txtMessage.AppendText(Environment.NewLine);
                }
            }
            DetailDisk();
        }

        private void DetailDisk()
        {
            txtMessage.Text = "";
            List<int> lstInt = db.LandIdList(Convert.ToInt32(txtTotalPages.Text));

            string[] files = Directory.GetFiles(pathDetail);
            string[] lstSource = new string[28];
            string file = pathDetail + @"\", str, temp;
            int length;
            StreamReader reader;
            string fileName;
            foreach (int item in lstInt)
            {
                fileName = file + item.ToString() + ".htm";
                if (!File.Exists(fileName)) continue;
                if (db.LandIsUpdated(item)) continue;
                reader = new StreamReader(fileName);
                try
                {

                    if ((str = reader.ReadToEnd()) != null)
                    {
                        if ((length = str.IndexOf("<div class=\"adparams_div\">")) >= 0)
                        {
                            str = str.Substring(length + 26, str.Length - length - 26);

                            length = str.IndexOf("Số phòng:");
                            if (length > -1)
                            {
                                temp = str.Substring(length + 18, str.Length - length - 18);
                                length = temp.IndexOf("</strong>");
                                if (length > -1)
                                {
                                    lstSource[16] = temp.Substring(0, length).Trim(); //BedRoom
                                    str = temp;
                                }
                            }

                            length = str.IndexOf("Loại:");
                            if (length > -1)
                            {
                                str = str.Substring(length + 14, str.Length - length - 14);
                                length = str.IndexOf("</strong>");
                                temp = str.Substring(0, length);
                                if (temp.IndexOf("Nhà ở") == -1) //Is House
                                    lstSource[14] = "false";
                                else
                                    lstSource[14] = "true";

                                if (temp.IndexOf("Cần bán") == -1) //Is Sale
                                    lstSource[27] = "false";
                                else
                                    lstSource[27] = "true";
                            }

                            length = str.IndexOf("Địa chỉ:");
                            if (length > -1)
                            {
                                temp = str.Substring(length + 17, str.Length - length - 17);
                                length = temp.IndexOf("</strong>");
                                if (length > -1)
                                {
                                    lstSource[1] = temp.Substring(0, length).Replace("\t", "").Replace("\n", "").Trim(); //Address
                                    str = temp;
                                }
                            }


                            length = str.IndexOf("<!-- Body -->");
                            if (length > -1)
                            {
                                temp = str.Substring(length + 13, str.Length - length - 13);
                                length = temp.IndexOf("</div>");
                                if (length > -1)
                                {
                                    lstSource[9] = temp.Substring(0, length).Replace("\t", "").Replace("\n", "").Trim(); //Comment
                                    str = temp;
                                }
                            }

                            //Area in comment
                            length = lstSource[9].IndexOf("Diện tích:");
                            if (length > -1)
                            {
                                temp = lstSource[9].Substring(length + 11, lstSource[9].Length - length - 11);
                                length = temp.IndexOf("m");
                                if (length > -1) lstSource[10] = temp.Substring(0, length).Trim(); //Area
                            }

                            lstSource = ClearTag(lstSource);
                            db.LandEdit(item, lstSource);

                        }
                    }
                    txtMessage.Text = txtMessage.Text + "Xử lý xong file " + fileName + "!\r\n";
                    reader.Close();
                    if (chkDelFile.Checked) File.Delete(fileName);
                }
                catch (Exception) { txtMessage.Text = "Lỗi trong file: " + fileName; db.LandIsDetail(item, false); }
            }
            txtMessage.Text = "Finish!";
            //if (chkDelFile.Checked)
            //    Array.ForEach(Directory.GetFiles(pathDetail), delegate (string tempFile) { File.Delete(tempFile); });
        }

        private void txtTotalPages_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                pageAll = Convert.ToInt32(txtTotalPages.Text);
        }

        private void btnDetailDisk_Click(object sender, EventArgs e)
        {
            DetailDisk();
        }

        private void btnGenDisk_Click(object sender, EventArgs e)
        {
            GenDisk();
        }

        private void btnDelAllFiles_Click(object sender, EventArgs e)
        {
            Array.ForEach(Directory.GetFiles(pathDetail), delegate (string tempFile) { File.Delete(tempFile); });
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvList.DataSource = db.LandSearch((int)cboDistrict.SelectedValue);
        }

        private void btnUpdateArea_Click(object sender, EventArgs e)
        {
            db.LandUpdateArea();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            lblComment.Text = "";
            lblLastDate.Text = "Last Date:" + db.LastUpdateDate();
            dgvList.DataSource = db.LandList();
        }

        private void btnCal_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtArea.Text.Length == 0)
                    txtArea.Text = (ToDecimal(txtLength.Text) * ToDecimal(txtWide.Text)).ToString();
                txtPricePerMet.Text = (ToDecimal(txtPrice.Text) / ToDecimal(txtArea.Text)).ToString();
            }
            catch (Exception) { }
        }

    }
}