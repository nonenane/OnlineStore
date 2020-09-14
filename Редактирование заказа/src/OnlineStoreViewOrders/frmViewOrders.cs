using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OnlineShopOrders;
using Nwuram.Framework.Settings.User;
using Nwuram.Framework.ToExcel;
using Nwuram.Framework.Settings.Connection;
using WooCommerceNET.WooCommerce.v3;
using WooCommerceNET;
using Nwuram.Framework.Logging;
using System.Diagnostics;


namespace OnlineStoreViewOrders
{
    public partial class frmViewOrders : Form
    {
        string code = UserSettings.User.StatusCode;

        public DataTable dtOrders;
        public DataTable dtContentOrder;

        private bool isLoadData=false;

        public frmViewOrders()
        {
            InitializeComponent();
            Config.connect = new Procedures(ConnectionSettings.GetServer(), ConnectionSettings.GetDatabase(),
              ConnectionSettings.GetUsername(), ConnectionSettings.GetPassword(), ConnectionSettings.ProgramName);
            Config._LASTLOADDATE = Convert.ToDateTime(Config.connect.GetDateLastUpdate().Rows[0]["value"].ToString());
            Logging.Init(ConnectionSettings.GetServer(), ConnectionSettings.GetDatabase(), ConnectionSettings.GetUsername(), ConnectionSettings.GetPassword(), ConnectionSettings.ProgramName);
        }

        private void KillExcel()
        {
            Process[] prc = Process.GetProcessesByName("EXCEL");
            foreach (var a in prc)
                a.Kill();
        }

        private void frmViewOrders_Load(object sender, EventArgs e)
        {
            isLoadData = true;
            ToolTip ttButton = new ToolTip();
            ttButton.SetToolTip(btnAdd, "Добавить заказы");
            ttButton.SetToolTip(btnExit, "Выход");
            ttButton.SetToolTip(btnPrint, "Печать отчета");
            ttButton.SetToolTip(btnUpdate, "Обновить заказы");
            ttButton.SetToolTip(btnAddFromSite, "Добавление заказов с сайта");
            ttButton.SetToolTip(btnCheck, "Добавление чеков");
            ttButton.SetToolTip(btnAllReport, "Печать с формы");
            ttButton.SetToolTip(btnView, "Просмотр заказа");
            ttButton.SetToolTip(btnEdit, "Редактирование заказа");
            tsConnect.Text = Nwuram.Framework.Settings.Connection.ConnectionSettings.GetServer() + " " +
                Nwuram.Framework.Settings.Connection.ConnectionSettings.GetDatabase();
            if (UserSettings.User.StatusCode.ToLower() == "пр")
                setEnabledPR();
            this.Text = ConnectionSettings.ProgramName + " " + UserSettings.User.FullUsername;

            dtpStart.MaxDate = DateTime.Now.AddDays(-1);
            dtpEnd.MaxDate = DateTime.Now;

            dtpStart.Value = DateTime.Now.Date.AddDays(-1); ;
            dtpEnd.Value = DateTime.Now.Date;
            init_combobox();
            GetOrders();
            isLoadData = false;

        }

        private void setEnabledPR()
        {
            btnAddFromSite.Enabled = btnCheck.Enabled = btnAdd.Enabled = false;
        }

        private void GetOrders()
        {
            dtOrders = Config.connect.Get_tOrders(dtpStart.Value.Date, dtpEnd.Value.Date.AddDays(1));
            dgvOrders.AutoGenerateColumns = false;
            dgvOrders.DataSource = dtOrders;
            EnabledControls();
            FilterOrders();
        }

        private void EnabledControls()
        {
            if (dgvOrders.CurrentRow == null || dtOrders.DefaultView.Count == 0)
            {
                btnPrint.Enabled = false;
                btnCheck.Enabled = false;
                btnAllReport.Enabled = false;
                btnView.Enabled = false;
                btnEdit.Enabled = false;
            }
            else 
            { 
                btnPrint.Enabled = true;
                btnCheck.Enabled = true;
                btnAllReport.Enabled = true;
                btnView.Enabled = true;
                btnEdit.Enabled = true;
            }
            if (UserSettings.User.StatusCode.ToLower() == "пр")
                btnCheck.Enabled = false;


            int id_Status = 0;
            if (dgvOrders.CurrentRow != null && dgvOrders.CurrentRow.Index != -1 && dtOrders != null && dtOrders.DefaultView.Count != 0)
                id_Status = (int)dtOrders.DefaultView[dgvOrders.CurrentRow.Index]["id_Status"];
            btnEdit.Enabled = new List<int>(new int[] { 1, 2 }).Contains(id_Status);

        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            GetOrders();
        }

        private void dgvOrders_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataRow dr = dtOrders.AsEnumerable().Where(x => x.Field<int>("id") == int.Parse(dgvOrders.CurrentRow.Cells["id"].Value.ToString())).First();
            tbComment.Text = dr["Comment"].ToString();
            tbCommentOrder.Text = dr["CommentOrder"].ToString();

            if ((int)dr["id_Status"] == 3)
            {
                tbDeliveryDate.Text = dr["DeliveryDate"].ToString();
                tbDeliveryCost.Text = dr["DeliveryCost"].ToString();
            }
            else
            {
                tbDeliveryDate.Text = tbDeliveryCost.Text = "";
            }

            EnabledControls();
        }

        private void dgvOrders_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                int idtOrder = int.Parse(dgvOrders.CurrentRow.Cells["id"].Value.ToString());
                bool needConnect2 = dtOrders.AsEnumerable().Where(x => x.Field<int>("id") == idtOrder).First()["dep6"].ToString() == "1" ? true : false;
                DateTime dateOrder = Convert.ToDateTime(dgvOrders.CurrentRow.Cells["DateOrder"].Value.ToString());
                int numOrder = int.Parse(dgvOrders.CurrentRow.Cells["OrderNumber"].Value.ToString());
                frmViewContentOrder viewContent = new frmViewContentOrder()
                {
                    idTOrder = idtOrder,
                    needConnect2 = needConnect2,
                    dateOrder = dateOrder,
                    numOrder = numOrder,
                    callType = 0
                };
                viewContent.ShowDialog();
                if (viewContent.isEdit)
                    GetOrders();
            }
        }

        private void FilterOrders()
        {
            try
            {
                string searchString = "";
                if (UserSettings.User.StatusCode == "РКВ")
                    searchString += "depRuk = 1";
                if (tbNumber.Text.Trim().Length != 0)
                    searchString += (searchString.Length == 0 ? "" : " and ") + (string.Format("OrderNumber like '%{0}%'", tbNumber.Text));
                if (tbName.Text.Trim().Length != 0)
                    searchString += (searchString.Length == 0 ? "" : " and ") + (string.Format("FIO like '%{0}%'", tbName.Text));
                if (tbMail.Text.Trim().Length != 0)
                    searchString += (searchString.Length == 0 ? "" : " and ") + (string.Format("Email like '%{0}%'", tbMail.Text));
                if (tbPhone.Text.Trim().Length != 0)
                    searchString += (searchString.Length == 0 ? "" : " and ") + (string.Format("Phone like '%{0}%'", tbPhone.Text));
                if (tbAddress.Text.Trim().Length != 0)
                    searchString += (searchString.Length == 0 ? "" : " and ") + (string.Format("Address like '%{0}%'", tbAddress.Text));
                if(cmbStatus.SelectedValue!=null && (int)cmbStatus.SelectedValue!=0)
                    searchString += (searchString.Length == 0 ? "" : " and ") + ($"id_Status = {cmbStatus.SelectedValue}");


                dtOrders.DefaultView.RowFilter = searchString;


                //сумму заказа считаем
                if (dtOrders.DefaultView.Count > 0)
                    tbSumOrders.Text = Convert.ToString(decimal.Round(Convert.ToDecimal(dtOrders.DefaultView.ToTable().Compute("SUM(sumOrder)", "")), 2));
                else tbSumOrders.Text = "0,00";

                EnabledControls();
            }
            catch
            {
                
            }
        }

        private void tbNumber_TextChanged(object sender, EventArgs e)
        {
            FilterOrders();
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            FilterOrders();
        }

        private void tbMail_TextChanged(object sender, EventArgs e)
        {
            FilterOrders();
        }

        private void tbPhone_TextChanged(object sender, EventArgs e)
        {
            FilterOrders();
        }

        private void tbAddress_TextChanged(object sender, EventArgs e)
        {
            FilterOrders();
        }

        private void dgvOrders_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (dgv.Rows[e.RowIndex].Selected)
            {
                int width = dgv.Width;
                Rectangle r = dgv.GetRowDisplayRectangle(e.RowIndex, false);
                Rectangle rect = new Rectangle(r.X, r.Y, width - 3, r.Height - 1);

                ControlPaint.DrawBorder(e.Graphics, rect,
                    SystemColors.Highlight, 2, ButtonBorderStyle.Solid,
                    SystemColors.Highlight, 2, ButtonBorderStyle.Solid,
                    SystemColors.Highlight, 2, ButtonBorderStyle.Solid,
                    SystemColors.Highlight, 2, ButtonBorderStyle.Solid);
            }
        }

        private void dgvOrders_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            Color rowcolor = Color.White;
            if (dtOrders.DefaultView[e.RowIndex]["havingBadPrice"].ToString() == "1")
                rowcolor = panel1.BackColor;

            if ((int)dtOrders.DefaultView[e.RowIndex]["id_Status"] == 3)
                rowcolor = pEnd.BackColor;
            else if ((int)dtOrders.DefaultView[e.RowIndex]["id_Status"] == 2)
                rowcolor = pInWork.BackColor;
            else if ((int)dtOrders.DefaultView[e.RowIndex]["id_Status"] == 4)
                rowcolor = pCancel.BackColor;

            dgv.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor =
                     dgv.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = rowcolor;
        }

        private void dgvOrders_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            tbNumber.Size = new Size(OrderNumber.Width - 3, 20);
            tbNumber.Location = new Point(dgvOrders.Location.X,43);

            tbName.Size = new Size(Buyer.Width - 3, 20);
            tbName.Location = new Point(tbNumber.Location.X + tbNumber.Size.Width+ DateOrder.Width+3, 43);

            tbMail.Size = new Size(Email.Width - 3, 20);
            tbMail.Location = new Point(tbName.Location.X + tbName.Size.Width+3, 43);

            tbPhone.Size = new Size(Phone.Width - 3, 20);
            tbPhone.Location = new Point(tbMail.Location.X + tbMail.Size.Width+3, 43);

            tbAddress.Size = new Size(Address.Width - 3, 20);
            tbAddress.Location = new Point(tbPhone.Location.X + tbPhone.Size.Width+3, 43);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddOrder frmAdd = new frmAddOrder();
            frmAdd.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DataTable dtBuf;
            KillExcel();
            int idtOrder = int.Parse(dgvOrders.CurrentRow.Cells["id"].Value.ToString());
            dtContentOrder = Config.connect.Get_Goods(idtOrder);

            dtContentOrder = dtContentOrder.Select("Netto > 0").OrderBy(r=>r.Field<int>("Position")).CopyToDataTable();
          
            HandmadeReport rep = new HandmadeReport();
            int rowStart = (code == "КД") ? 10 : 4;
            
            //шапочка
            rep.SetPageOrientationToLandscape();
            rep.AddSingleValue("Выгрузка товаров для заказа №" + int.Parse(dgvOrders.CurrentRow.Cells["OrderNumber"].Value.ToString()), 1, 1);
            rep.SetFontBold(1, 1, 1, 1);
            rep.AddSingleValue("№", rowStart, 1);
            rep.AddSingleValue("Отдел", rowStart, 2);
            rep.AddSingleValue("EAN", rowStart, 3);
            rep.AddSingleValue("Название", rowStart, 4);
            rep.AddSingleValue("Количество", rowStart, 5);
            rep.AddSingleValue("Цена", rowStart, 6);
            rep.AddSingleValue("Итого", rowStart, 7);
            rep.SetColumnWidth(1, 1, 1, 1, 4);
            rep.SetColumnWidth(1, 2, 1, 2, 15);
            rep.SetColumnWidth(1, 4, 1, 4, 60);
            rep.SetColumnWidth(1, 5, 1, 5, 12);
            rep.SetFontBold(rowStart, 1, rowStart, 7);
            rep.SetCellAlignmentToCenter(rowStart, 1, rowStart, 7);
            rowStart++;
            decimal brutto = 0;
            switch (code)
            {
                case "КД":
                    //шапка для КД
                    rep.AddSingleValue("Покупатель: " + dgvOrders.CurrentRow.Cells["Buyer"].Value.ToString(), 4, 1);
                    rep.AddSingleValue("Адрес доставки: " + dgvOrders.CurrentRow.Cells["Address"].Value.ToString(), 5, 1);
                    rep.AddSingleValue("Телефон: " + dgvOrders.CurrentRow.Cells["Phone"].Value.ToString(), 6, 1);
                    rep.AddSingleValue("Сумма заказа: " + dgvOrders.CurrentRow.Cells["Column2"].Value.ToString(), 7, 1);
                    rep.AddSingleValue("Сумма доставки: " + dgvOrders.CurrentRow.Cells["cDelivery"].Value.ToString(), 8, 1);
                    rep.Merge(9, 1, 9, 4);
                    rep.SetWrapText(9, 1, 9, 1);
                    rep.AddSingleValue("Комментарий покупателя: " + tbCommentOrder.Text,9,1);
                    rep.SetFontBold(4, 1, 8, 1);





                    dtContentOrder.Columns.Remove("id");
                    dtContentOrder.Columns.Remove("id_Tovar");
                    dtContentOrder.Columns.Remove("id_Departments");
                    dtContentOrder.Columns["ean"].DataType = Type.GetType("System.String");
                   // dtContentOrder.Columns["Netto"].DataType = dtContentOrder.Columns["Price"].DataType = 
                     //   dtContentOrder.Columns["sumTovar"].DataType = Type.GetType("System.Decimal");
                    
                    dtContentOrder.Columns.Add("badPrice", typeof(int));

                    DataTable dtClear = new DataTable();
                    dtClear.Columns.Add("clear", typeof(string));
                    foreach (DataRow dr in dtContentOrder.Rows)
                    {
                        if (dr["ean"].ToString().Trim().Length == 4)
                            brutto += Convert.ToDecimal(dr["Netto"].ToString());//.Replace('.', ','));
                        else
                            brutto += Convert.ToDecimal(dr["Netto"].ToString()) * Convert.ToDecimal(dr["brutto"].ToString());
                        if (dr["Price"].ToString() != dr["BasicPrice"].ToString())
                            dr["badPrice"] = 1;
                        else dr["badPrice"] = 0;
                        
                        dtClear.Rows.Add("");
                    }
                    dtContentOrder.Columns.Remove("brutto");
                    dtContentOrder.Columns.Remove("BasicPrice");
                    //вес заказа
                    rep.AddSingleValue("Вес заказа: " + decimal.Round(brutto, 3) + " кг.", 7, 5);
                    rep.SetFontBold(7, 5, 7, 5);
                    //
                    int crow = rowStart;
                    foreach (DataRow dr in dtContentOrder.Rows)
                    {
                        rep.AddSingleValue(dr["Position"].ToString(), crow, 1);
                        rep.AddSingleValue(dr["name"].ToString(), crow, 2);
                        rep.AddSingleValue(dr["ean"].ToString().Trim(), crow, 3);
                        rep.AddSingleValue(dr["nameTovar"].ToString(), crow, 4);
                        rep.AddSingleValue(dr["Netto"].ToString().Replace(',','.'), crow, 5);
                        rep.AddSingleValue(dr["Price"].ToString().Replace(',','.'), crow, 6);
                        rep.AddSingleValue(dr["sumTovar"].ToString().Replace(',','.'), crow, 7);
                        if (dr["badPrice"].ToString() == "1")
                            rep.SetCellColor(crow, 1, crow, 7, 46);
                      
                        crow++;
                    }


                    //rep.AddMultiValue(dtContentOrder, rowStart, 1, 46,"badPrice","1");
                    //обнуляем столбец badPrice )
                    rep.AddMultiValue(dtClear, rowStart, 8);
                    rep.AddMultiValue(dtClear, rowStart, 9);
                    //и делаем ему беленький цвет ))))
                    rep.SetCellColor(rowStart, 8, rowStart + dtContentOrder.Rows.Count, 9, 0);

                    rep.SetBorders(rowStart-1, 1, rowStart-1 + dtContentOrder.Rows.Count, 7);
                    rep.SetFormat(rowStart, 5, rowStart + dtContentOrder.Rows.Count, 5, "0.000");
                    rep.SetFormat(rowStart, 6, rowStart + dtContentOrder.Rows.Count, 7, "0.000");
                    rep.SetWrapText(rowStart, 4, rowStart + dtContentOrder.Rows.Count, 4);

                    rep.SetFormat(rowStart, 3, rowStart+dtContentOrder.Rows.Count, 3, "0");



                    rowStart = rowStart + dtContentOrder.Rows.Count;
                    rowStart += 2;
                    rep.SetCellColor(rowStart, 1, rowStart, 1, 46);
                    rep.AddSingleValue("=\"-Цена отличается от базовой цены\"", rowStart, 2);
                    rep.Show();
                    break;
                case "РКВ":
                    EnumerableRowCollection<DataRow> rows = dtContentOrder.AsEnumerable().Where(x => x.Field<Int16>("id_Departments") == UserSettings.User.IdDepartment);
                    if (rows.Count()==0)
                    {
                        MessageBox.Show("У выбранного заказа нет продуктов из отдела", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    DataTable dtOrder = rows.CopyToDataTable();
                    dtOrder.Columns.Add("badPrice", typeof(int));
                    DataTable dtClearR = new DataTable();
                    dtClearR.Columns.Add("clear", typeof(string));
                    foreach (DataRow dr in dtOrder.Rows)
                    {
                        if (dr["ean"].ToString().Trim().Length == 4)
                            brutto += Convert.ToDecimal(dr["Netto"].ToString().Replace('.', ','));
                        else
                            brutto += Convert.ToDecimal(dr["Netto"].ToString().Replace('.', ',')) * Convert.ToDecimal(dr["brutto"].ToString().Replace('.', ','));
                        if (dr["Price"].ToString().Replace('.', ',') != dr["BasicPrice"].ToString().Replace('.', ','))
                            dr["badPrice"] = 1;
                        else dr["badPrice"] = 0;
                        dtClearR.Rows.Add("");
                    }
                    dtOrder.Columns.Remove("id");
                    dtOrder.Columns.Remove("id_Tovar");
                    dtOrder.Columns.Remove("id_Departments");
                    dtOrder.Columns.Remove("brutto");
                    dtOrder.Columns.Remove("BasicPrice");
                    rep.AddSingleValue("Отдел: " + dtOrder.Rows[0]["name"].ToString(), 3, 1);
                    rep.SetFontBold(3, 1, 3, 1);
                    rep.AddSingleValue("Вес заказа: " + decimal.Round(brutto, 3) + " кг.", 3, 5);

                  

                    crow = rowStart;
                    foreach (DataRow dr in dtOrder.Rows)
                    {
                        rep.AddSingleValue(dr["Position"].ToString(), crow, 1);
                        rep.AddSingleValue(dr["name"].ToString(), crow, 2);
                        rep.AddSingleValue(dr["ean"].ToString().Trim(), crow, 3);
                        rep.AddSingleValue(dr["nameTovar"].ToString(), crow, 4);
                        rep.AddSingleValue(dr["Netto"].ToString().Replace(',', '.'), crow, 5);
                        rep.AddSingleValue(dr["Price"].ToString().Replace(',', '.'), crow, 6);
                        rep.AddSingleValue(dr["sumTovar"].ToString().Replace(',', '.'), crow, 7);
                        if (dr["badPrice"].ToString() == "1")
                            rep.SetCellColor(crow, 1, crow, 7, 46);
                        string zero = "";
                        for (int i = 0; i < dr["ean"].ToString().Length; i++)
                            zero += "0";
                        rep.SetFormat(crow, 3, crow, 3, zero);
                        crow++;
                    }
                    //rep.AddMultiValue(dtOrder, rowStart, 1, 46, "badPrice","1");
                    rep.SetFormat(rowStart, 3, rowStart + dtOrder.Rows.Count, 3, "0");
                    //обнуляем столбец badPrice
                    rep.AddMultiValue(dtClearR, rowStart, 8);
                    rep.AddMultiValue(dtClearR, rowStart, 9);
                    //и делаем ему беленький цвет ))))
                    rep.SetCellColor(rowStart, 8, rowStart + dtOrder.Rows.Count, 9, 0);

                    rep.SetBorders(rowStart-1, 1, rowStart-1 + dtOrder.Rows.Count, 7);
                    rep.SetBorders(rowStart - 1, 1, rowStart - 1 + dtOrder.Rows.Count, 7);
                    rep.SetFormat(rowStart, 3, rowStart + dtOrder.Rows.Count, 3, "0");
                    rep.SetFormat(rowStart, 5, rowStart + dtOrder.Rows.Count, 5, "0.000");
                    rep.SetFormat(rowStart, 6, rowStart + dtContentOrder.Rows.Count, 7, "0.000");
                    rep.SetWrapText(rowStart, 4, rowStart + dtOrder.Rows.Count, 4);
                   

                    rowStart = rowStart + dtOrder.Rows.Count;
                    rowStart += 2;
                    rep.SetCellColor(rowStart, 1, rowStart, 1, 46);
                    rep.AddSingleValue("=\"-Цена отличается от базовой цены\"", rowStart, 2);

                    rep.Show();
                    break;               
            }

        }

        private async void btnAddFromSite_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            btnAddFromSite.Enabled = false;
            // обновляем дату в конфиге
            DateTime newdate = DateTime.Now;
            Config.connect.SetDateLastUpdate();

            RestAPI rest = new RestAPI("https://narodniy.spb.ru/wp-json/wc/v3/", "ck_c0c3f4d52c11dcb2854bfb010a6ff8586b5ad87d",
            "cs_741fa4eb736404308353053f36a0a78e6f9a70fb");
            WCObject wc = new WCObject(rest);
            DataTable dtTorder;
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("consumer_key", "ck_c0c3f4d52c11dcb2854bfb010a6ff8586b5ad87d");
            dict.Add("consumer_secret", "cs_741fa4eb736404308353053f36a0a78e6f9a70fb");
            dict.Add("per_page", "100");
            dict.Add("page", "1");
           
            //результаты запроса к базе сайта
            List<Order> orders = new List<Order>();//= await wc.Order.GetAll(dict);
            List<Order> result = new List<Order>();
            int page = 1;
            DateTime dateNow = DateTime.Now;
            //запуливаем пока дата сейчас меньше, чем дата последнего обновления
            while (dateNow>Config._LASTLOADDATE && (result.Count==100 || result.Count==0))
            {
                dict["page"] = page.ToString();
                result = await wc.Order.GetAll(dict);
                orders.AddRange(result);
                page++;
                dateNow = (DateTime) result[result.Count - 1].date_created;
            }

            

            foreach (Order ord in orders)
            {
                int orderNumber = int.Parse(ord.number);
                DateTime orderDate = (DateTime) ord.date_created;
                string lastname = ord.billing.last_name;
                string firstname = ord.billing.first_name;
                string email = ord.billing.email;
                string phone = ord.billing.phone;
                string address = ord.billing.address_1;
                decimal summaDel = (decimal) ord.shipping_total;
                string commentOrder = ord.customer_note;
                string typePay = ord.payment_method_title;
                string commentOrder_2 = ord.billing.address_2;
                string fullComment = commentOrder_2 + "; " + commentOrder; 
                dtTorder = Config.connect.Set_tOrder(orderNumber, orderDate, lastname, firstname, email, phone, address, summaDel, fullComment, typePay);    
                
                //если добавили заказ
                if (dtTorder.Rows[0][0].ToString()!="")
                {
                    int id_tOrder = int.Parse(dtTorder.Rows[0][0].ToString());

                    #region LOG
                    Logging.StartFirstLevel(1529);
                    Logging.Comment("Добавление заказа id = " + id_tOrder.ToString());
                    Logging.Comment("Покупатель: " + lastname + " " + firstname +
                        ". Email: " +email +
                        ". Телефон: " + phone +
                        ". Адрес: " + address +
                        ". Стоимость доставки: " + summaDel +
                        ". Описание доставки: " + fullComment +
                        ". Способ оплаты: " + typePay);
                    Logging.Comment("Завершение добавления заказа");
                    Logging.StopFirstLevel();
                    #endregion

                    int id_inorder = (int) ord.line_items[0].id -1;
                    foreach (var prod in ord.line_items)
                    {
                        int sku = int.Parse(prod.sku);
                        decimal quantity =(decimal) prod.quantity;
                        decimal itemCost = (decimal) prod.price;
                        int Position = (int) prod.id - id_inorder;
                        Config.connect.Set_Order(id_tOrder, sku, "", Position, quantity, itemCost);
                        Position++;

                    }
                }

                else
                {
                    //обновляем дату
                    Config._LASTLOADDATE = newdate;
                    MessageBox.Show("Заказы с сайта добавлены", "Добавление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    label1.Visible = false;
                    btnAddFromSite.Enabled = true;
                    btnUpdate_Click(null, null);
                    return;
                }

            }
            //обновляем дату
            Config._LASTLOADDATE = newdate;
            MessageBox.Show("Заказы с сайта добавлены", "Добавление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            label1.Visible = false;
            btnAddFromSite.Enabled = true;
            btnUpdate_Click(null, null);
        }

        private void frmViewOrders_SizeChanged(object sender, EventArgs e)
        {
            lblComment.Location = new Point(this.Size.Width / 2, lblComment.Location.Y);
            tbComment.Location = new Point(this.Size.Width / 2, tbComment.Location.Y);

            tbCommentOrder.Size = new Size(this.Size.Width / 2 - 25, tbCommentOrder.Size.Height);
            tbComment.Size = new Size(this.Size.Width / 2 - 25, tbComment.Size.Height);

            tbSumOrders.Size = new Size(this.Column2.Width, tbSumOrders.Size.Height);
            tbSumOrders.Location = new Point(dgvOrders.Location.X + OrderNumber.Width + DateOrder.Width + Buyer.Width + Email.Width + Phone.Width 
                + Address.Width, tbSumOrders.Location.Y);

            label3.Location = new Point(tbSumOrders.Location.X - 80, label3.Location.Y);
        }

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            if (isLoadData) return;

            if (dtpEnd.Value < dtpStart.Value)
                dtpEnd.Value = dtpStart.Value;
            GetOrders();           
        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {
            if (isLoadData) return;

            if (dtpStart.Value > dtpEnd.Value)
                dtpStart.Value = dtpEnd.Value;
            GetOrders();
        }

        private void cmsPackage_Opening(object sender, CancelEventArgs e)
        {
            int id_Status = (int)dtOrders.DefaultView[dgvOrders.CurrentRow.Index]["id_Status"];
            изменитьСтоимостьДоставкиToolStripMenuItem.Visible = new List<string>(new string[] { "КД" }).Contains(Nwuram.Framework.Settings.User.UserSettings.User.StatusCode) && new List<int>(new int[] { 1, 2 }).Contains(id_Status);

            заказВОбработкеToolStripMenuItem.Visible = new List<string>(new string[] { "КД" }).Contains(Nwuram.Framework.Settings.User.UserSettings.User.StatusCode) && new List<int>(new int[] { 1,4 }).Contains(id_Status);

            заказВыполненToolStripMenuItem.Visible = new List<string>(new string[] { "КД" }).Contains(Nwuram.Framework.Settings.User.UserSettings.User.StatusCode) && new List<int>(new int[] { 2 }).Contains(id_Status);

            заказОтменёнToolStripMenuItem.Visible = new List<string>(new string[] { "КД" }).Contains(Nwuram.Framework.Settings.User.UserSettings.User.StatusCode) && new List<int>(new int[] { 1,2 }).Contains(id_Status);

        }

        private void dgvOrders_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < dgvOrders.ColumnCount && e.RowIndex < dgvOrders.RowCount && e.Button == MouseButtons.Right)
            {
                dgvOrders.CurrentCell = dgvOrders.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cmsPackage.Show(MousePosition);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmPackage frm = new frmPackage()
            {
                id_Order = int.Parse(dtOrders.DefaultView[dgvOrders.CurrentRow.Index]["id"].ToString()),
                numberOrder = int.Parse(dtOrders.DefaultView[dgvOrders.CurrentRow.Index]["OrderNumber"].ToString())
            };
            frm.ShowDialog();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (dtOrders.DefaultView.Count > 0)
            {
                frmCheck frm = new frmCheck()
                {
                    id_tOrder = int.Parse(dtOrders.DefaultView[dgvOrders.CurrentRow.Index]["id"].ToString()),
                    num_Order = int.Parse(dtOrders.DefaultView[dgvOrders.CurrentRow.Index]["OrderNumber"].ToString()),
                    id_status = 1
                };
                frm.ShowDialog();
            }
        }

        private void btnAllReport_Click(object sender, EventArgs e)
        {

            if (dtOrders.DefaultView.Count == 0)
                return;
            DataTable dtBuf;
            KillExcel();

            HandmadeReport rep = new HandmadeReport();

            rep.SetColumnWidth(1, 1, 1, 1, 7);
            rep.SetPageOrientationToLandscape();

            rep.SetColumnWidth(1, 2, 1, 2, 15);
            rep.SetColumnWidth(1, 3, 1, 3, 20);
            rep.SetColumnWidth(1, 4, 1, 4, 20);
            rep.SetColumnWidth(1, 5, 1, 5, 20);
            rep.SetColumnWidth(1, 6, 1, 6, 20);
            rep.SetColumnWidth(1, 7, 1, 8, 10);
            rep.SetColumnWidth(1, 9, 1, 9, 15);
            rep.SetColumnWidth(1, 10, 1, 11,15);

            rep.AddSingleValue("Заказы онлайн магазина", 1, 1);
            rep.SetFontSize(1, 1, 1, 1, 15);
            rep.SetFontBold(1, 1, 1, 1);

            rep.AddSingleValue("Дата от: " + dtpStart.Value.ToShortDateString(), 2, 1);
            rep.AddSingleValue("Дата до: " + dtpEnd.Value.ToShortDateString(), 3, 1);
            rep.AddSingleValue("Выгрузил: " + UserSettings.User.FullUsername, 2, 9);
            rep.AddSingleValue("Дата выгрузки: " + DateTime.Now.ToString(), 3, 10);

            rep.Merge(1, 1, 1, 11);
            rep.SetCellAlignmentToCenter(1, 1, 1, 1);
            rep.Merge(2, 9, 2, 11);
            rep.Merge(3, 10, 3, 11);
            rep.SetCellAlignmentToRight(2, 9, 3, 9);

            //шапка

            int row = 5;
            int startRow = row;
            rep.AddSingleValue("Номер", row, 1);
            rep.AddSingleValue("Дата", row, 2);
            rep.AddSingleValue("ФИО", row, 3);
            rep.AddSingleValue("Email", row, 4);
            rep.AddSingleValue("Телефон", row, 5);
            rep.AddSingleValue("Адрес", row, 6);
            rep.AddSingleValue("Стоимость заказа", row, 7);
            rep.AddSingleValue("Стоимость доставки", row, 8);
            rep.AddSingleValue("Способ оплаты", row, 9);
            rep.AddSingleValue("Комментарий покупателя", row, 10);
            rep.AddSingleValue("Комментарий сборщика", row, 11);
            rep.SetFontBold(row, 1, row, 11);
            rep.SetWrapText(row, 1, row, 11);            
            row++;

            foreach (DataRow dr in dtOrders.DefaultView.ToTable().Rows)
            {
                rep.AddSingleValue(dr["OrderNumber"].ToString(),row,1);
                rep.AddSingleValue(dr["DateOrder"].ToString(), row, 2);
                rep.AddSingleValue(dr["FIO"].ToString(), row, 3);
                rep.AddSingleValue(dr["Email"].ToString(), row, 4);
                rep.AddSingleValue(dr["Phone"].ToString(), row, 5);
                rep.AddSingleValue(dr["Address"].ToString(), row, 6);
                rep.AddSingleValue(dr["sumOrder"].ToString(), row, 7);
                rep.AddSingleValue(dr["SummaDelivery"].ToString(), row, 8);
                rep.AddSingleValue(dr["paymentType"].ToString(), row, 9);
                rep.AddSingleValue(dr["CommentOrder"].ToString(), row, 10);
                rep.AddSingleValue(dr["Comment"].ToString(), row, 11);
                row++;
                
            }
            row--;
            rep.SetWrapText(startRow, 1, row, 11);
            rep.SetCellAlignmentToJustify(startRow, 1, row, 11);
            rep.SetCellAlignmentToCenter(startRow, 1, row, 11);

            rep.SetFontSize(startRow + 1, 10, row, 11, 9);
            rep.SetBorders(startRow, 1, row, 11);
            rep.Show();

        }

        private void btnView_Click(object sender, EventArgs e)
        {
            int idtOrder = int.Parse(dgvOrders.CurrentRow.Cells["id"].Value.ToString());
            bool needConnect2 = dtOrders.AsEnumerable().Where(x => x.Field<int>("id") == idtOrder).First()["dep6"].ToString() == "1" ? true : false;
            DateTime dateOrder = Convert.ToDateTime(dgvOrders.CurrentRow.Cells["DateOrder"].Value.ToString());
            int numOrder = int.Parse(dgvOrders.CurrentRow.Cells["OrderNumber"].Value.ToString());
            frmViewContentOrder viewContent = new frmViewContentOrder()
            {
                idTOrder = idtOrder,
                needConnect2 = needConnect2,
                dateOrder = dateOrder,
                numOrder = numOrder
                , callType = 0
            };
            viewContent.ShowDialog();
            if (viewContent.isEdit)
                GetOrders();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int idtOrder = int.Parse(dgvOrders.CurrentRow.Cells["id"].Value.ToString());
            bool needConnect2 = dtOrders.AsEnumerable().Where(x => x.Field<int>("id") == idtOrder).First()["dep6"].ToString() == "1" ? true : false;
            DateTime dateOrder = Convert.ToDateTime(dgvOrders.CurrentRow.Cells["DateOrder"].Value.ToString());
            int numOrder = int.Parse(dgvOrders.CurrentRow.Cells["OrderNumber"].Value.ToString());
            frmViewContentOrder viewContent = new frmViewContentOrder()
            {
                idTOrder = idtOrder,
                needConnect2 = needConnect2,
                dateOrder = dateOrder,
                numOrder = numOrder
                ,
                callType = 1
            };
            viewContent.ShowDialog();
            if (viewContent.isEdit)
                GetOrders();
        }

        private void историяСтатусовЗаказаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int idtOrder = int.Parse(dgvOrders.CurrentRow.Cells["id"].Value.ToString());
            int numOrder = int.Parse(dgvOrders.CurrentRow.Cells["OrderNumber"].Value.ToString());

            new workWithStatus.frmJournalStatusOrder() { id = idtOrder, numOrder = numOrder }.ShowDialog();
        }

        private void заказВОбработкеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int idtOrder = int.Parse(dgvOrders.CurrentRow.Cells["id"].Value.ToString());
            if (DialogResult.No == MessageBox.Show("Сменить статус заказа?", "Запрос на действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)) return;

            DataTable dtResult = Config.connect.setStatusOrder(idtOrder, null, null, 2, null);
            dtOrders.DefaultView[dgvOrders.CurrentRow.Index]["id_Status"] = 2;
            dtOrders.AcceptChanges();
        }

        private void заказВыполненToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int idtOrder = int.Parse(dgvOrders.CurrentRow.Cells["id"].Value.ToString());
            DateTime _DateOrder = (DateTime)dgvOrders.CurrentRow.Cells["DateOrder"].Value;
            DataTable dtCheck = Config.connect.GetCheckvsOrder(idtOrder);
            if (dtCheck == null || dtCheck.Rows.Count == 0)
            {
                MessageBox.Show("К заказу не прикреплён чек с товарами.\nСмена статуса невозможна.\n", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            EnumerableRowCollection<DataRow> rowCollect = dtCheck.AsEnumerable().Where(r => !r.Field<bool>("isPackage"));
            if (rowCollect.Count() == 0)
            {
                MessageBox.Show("К заказу не прикреплён чек с товарами.\nСмена статуса невозможна.\n", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (DialogResult.No == MessageBox.Show("Статус \"Выполнен\" нельзя сменить\nпосле присвоения.\nПродолжить?\n", "Запрос на действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)) return;


            if (DialogResult.OK == new frmChangeStatus() { Text = "Смена статуса", nextStatus = 3,dateOrder = _DateOrder, idtOrder = idtOrder }.ShowDialog())
            {
                dtOrders.DefaultView[dgvOrders.CurrentRow.Index]["id_Status"] = 3;
                dtOrders.AcceptChanges();
            }

        }

        private void заказОтменёнToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int idtOrder = int.Parse(dgvOrders.CurrentRow.Cells["id"].Value.ToString());
            DateTime _DateOrder = (DateTime)dgvOrders.CurrentRow.Cells["DateOrder"].Value;

            if (DialogResult.No == MessageBox.Show("Сменить статус заказа?", "Запрос на действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)) return;

            if (DialogResult.OK == new frmChangeStatus() { Text = "Смена статуса", nextStatus = 4, dateOrder = _DateOrder, idtOrder = idtOrder }.ShowDialog())
            {
                dtOrders.DefaultView[dgvOrders.CurrentRow.Index]["id_Status"] = 4;
                dtOrders.AcceptChanges();
            }
        }

        private void изменитьСтоимостьДоставкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int idtOrder = int.Parse(dgvOrders.CurrentRow.Cells["id"].Value.ToString());
            int numOrder = int.Parse(dgvOrders.CurrentRow.Cells["OrderNumber"].Value.ToString());
            decimal SummaDelivery = (decimal)dtOrders.DefaultView[dgvOrders.CurrentRow.Index]["SummaDelivery"];
            frmChangeSummaDelivery frmCSD = new frmChangeSummaDelivery() { idtOrder = idtOrder, Text = $"Стоимость доставки заказа №{numOrder}", SummaDelivery = SummaDelivery };
            if (DialogResult.OK == frmCSD.ShowDialog())
            {
                dtOrders.DefaultView[dgvOrders.CurrentRow.Index]["SummaDelivery"] = frmCSD.SummaDelivery;
                dtOrders.AcceptChanges();
            }
        }

        private void init_combobox()
        {
            DataTable dtStatus = Config.connect.getListStatus(true);
            cmbStatus.DataSource = dtStatus;
            cmbStatus.DisplayMember = "cName";
            cmbStatus.ValueMember = "id";
        }

        private void cmbStatus_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FilterOrders();
        }
    }
}
