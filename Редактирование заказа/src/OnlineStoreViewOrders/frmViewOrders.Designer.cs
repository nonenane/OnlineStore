﻿namespace OnlineStoreViewOrders
{
    partial class frmViewOrders
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmViewOrders));
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.OrderNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Buyer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDelivery = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Payment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsPackage = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.историяСтатусовЗаказаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьСтоимостьДоставкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.заказВОбработкеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.заказВыполненToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.заказОтменёнToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.lblDateStart = new System.Windows.Forms.Label();
            this.lblDateEnd = new System.Windows.Forms.Label();
            this.tbCommentOrder = new System.Windows.Forms.TextBox();
            this.lblCommentOrder = new System.Windows.Forms.Label();
            this.tbComment = new System.Windows.Forms.TextBox();
            this.lblComment = new System.Windows.Forms.Label();
            this.tbNumber = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbMail = new System.Windows.Forms.TextBox();
            this.tbPhone = new System.Windows.Forms.TextBox();
            this.tbAddress = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsConnect = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbSumOrders = new System.Windows.Forms.TextBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.btnAllReport = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnAddFromSite = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.pEnd = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.pInWork = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.pCancel = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.btCreateReport = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.tbDeliveryDate = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbDeliveryCost = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.cmsPackage.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvOrders
            // 
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.AllowUserToDeleteRows = false;
            this.dgvOrders.AllowUserToResizeRows = false;
            this.dgvOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrders.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOrders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OrderNumber,
            this.id,
            this.DateOrder,
            this.Buyer,
            this.Email,
            this.Phone,
            this.Address,
            this.Column2,
            this.cDelivery,
            this.Payment});
            this.dgvOrders.Location = new System.Drawing.Point(12, 69);
            this.dgvOrders.MultiSelect = false;
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.RowHeadersVisible = false;
            this.dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.Size = new System.Drawing.Size(961, 287);
            this.dgvOrders.TabIndex = 0;
            this.dgvOrders.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrders_CellEnter);
            this.dgvOrders.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvOrders_CellMouseDoubleClick);
            this.dgvOrders.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvOrders_CellMouseDown);
            this.dgvOrders.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgvOrders_ColumnWidthChanged);
            this.dgvOrders.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvOrders_RowPostPaint);
            this.dgvOrders.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvOrders_RowPrePaint);
            // 
            // OrderNumber
            // 
            this.OrderNumber.DataPropertyName = "OrderNumber";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.OrderNumber.DefaultCellStyle = dataGridViewCellStyle7;
            this.OrderNumber.FillWeight = 63.05103F;
            this.OrderNumber.HeaderText = "Номер заказа";
            this.OrderNumber.Name = "OrderNumber";
            this.OrderNumber.ReadOnly = true;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // DateOrder
            // 
            this.DateOrder.DataPropertyName = "DateOrder";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DateOrder.DefaultCellStyle = dataGridViewCellStyle8;
            this.DateOrder.FillWeight = 109.2885F;
            this.DateOrder.HeaderText = "Дата заказа";
            this.DateOrder.Name = "DateOrder";
            this.DateOrder.ReadOnly = true;
            // 
            // Buyer
            // 
            this.Buyer.DataPropertyName = "FIO";
            this.Buyer.FillWeight = 109.2885F;
            this.Buyer.HeaderText = "ФИО покупателя";
            this.Buyer.Name = "Buyer";
            this.Buyer.ReadOnly = true;
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            this.Email.FillWeight = 109.2885F;
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            // 
            // Phone
            // 
            this.Phone.DataPropertyName = "Phone";
            this.Phone.FillWeight = 109.2885F;
            this.Phone.HeaderText = "Телефон";
            this.Phone.Name = "Phone";
            this.Phone.ReadOnly = true;
            // 
            // Address
            // 
            this.Address.DataPropertyName = "Address";
            this.Address.FillWeight = 109.2885F;
            this.Address.HeaderText = "Адрес";
            this.Address.Name = "Address";
            this.Address.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "sumOrder";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle9;
            this.Column2.FillWeight = 81.21827F;
            this.Column2.HeaderText = "Сумма заказа";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // cDelivery
            // 
            this.cDelivery.DataPropertyName = "SummaDelivery";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.cDelivery.DefaultCellStyle = dataGridViewCellStyle10;
            this.cDelivery.HeaderText = "Сумма доставки";
            this.cDelivery.Name = "cDelivery";
            this.cDelivery.ReadOnly = true;
            // 
            // Payment
            // 
            this.Payment.DataPropertyName = "paymentType";
            this.Payment.FillWeight = 109.2885F;
            this.Payment.HeaderText = "Способ оплаты";
            this.Payment.Name = "Payment";
            this.Payment.ReadOnly = true;
            // 
            // cmsPackage
            // 
            this.cmsPackage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.историяСтатусовЗаказаToolStripMenuItem,
            this.изменитьСтоимостьДоставкиToolStripMenuItem,
            this.заказВОбработкеToolStripMenuItem,
            this.заказВыполненToolStripMenuItem,
            this.заказОтменёнToolStripMenuItem});
            this.cmsPackage.Name = "cmsPackage";
            this.cmsPackage.Size = new System.Drawing.Size(242, 136);
            this.cmsPackage.Opening += new System.ComponentModel.CancelEventHandler(this.cmsPackage_Opening);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(241, 22);
            this.toolStripMenuItem1.Text = "Указать количество пакетов";
            this.toolStripMenuItem1.Visible = false;
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // историяСтатусовЗаказаToolStripMenuItem
            // 
            this.историяСтатусовЗаказаToolStripMenuItem.Name = "историяСтатусовЗаказаToolStripMenuItem";
            this.историяСтатусовЗаказаToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.историяСтатусовЗаказаToolStripMenuItem.Text = "Журнал статусов заказа";
            this.историяСтатусовЗаказаToolStripMenuItem.Click += new System.EventHandler(this.историяСтатусовЗаказаToolStripMenuItem_Click);
            // 
            // изменитьСтоимостьДоставкиToolStripMenuItem
            // 
            this.изменитьСтоимостьДоставкиToolStripMenuItem.Name = "изменитьСтоимостьДоставкиToolStripMenuItem";
            this.изменитьСтоимостьДоставкиToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.изменитьСтоимостьДоставкиToolStripMenuItem.Text = "Изменить стоимость доставки";
            this.изменитьСтоимостьДоставкиToolStripMenuItem.Click += new System.EventHandler(this.изменитьСтоимостьДоставкиToolStripMenuItem_Click);
            // 
            // заказВОбработкеToolStripMenuItem
            // 
            this.заказВОбработкеToolStripMenuItem.Name = "заказВОбработкеToolStripMenuItem";
            this.заказВОбработкеToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.заказВОбработкеToolStripMenuItem.Text = "Заказ в обработке";
            this.заказВОбработкеToolStripMenuItem.Click += new System.EventHandler(this.заказВОбработкеToolStripMenuItem_Click);
            // 
            // заказВыполненToolStripMenuItem
            // 
            this.заказВыполненToolStripMenuItem.Name = "заказВыполненToolStripMenuItem";
            this.заказВыполненToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.заказВыполненToolStripMenuItem.Text = "Заказ выполнен";
            this.заказВыполненToolStripMenuItem.Click += new System.EventHandler(this.заказВыполненToolStripMenuItem_Click);
            // 
            // заказОтменёнToolStripMenuItem
            // 
            this.заказОтменёнToolStripMenuItem.Name = "заказОтменёнToolStripMenuItem";
            this.заказОтменёнToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.заказОтменёнToolStripMenuItem.Text = "Заказ отменён";
            this.заказОтменёнToolStripMenuItem.Click += new System.EventHandler(this.заказОтменёнToolStripMenuItem_Click);
            // 
            // dtpStart
            // 
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStart.Location = new System.Drawing.Point(33, 10);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(96, 20);
            this.dtpStart.TabIndex = 1;
            this.dtpStart.ValueChanged += new System.EventHandler(this.dtpStart_ValueChanged);
            // 
            // dtpEnd
            // 
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEnd.Location = new System.Drawing.Point(163, 10);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(92, 20);
            this.dtpEnd.TabIndex = 2;
            this.dtpEnd.ValueChanged += new System.EventHandler(this.dtpEnd_ValueChanged);
            // 
            // lblDateStart
            // 
            this.lblDateStart.AutoSize = true;
            this.lblDateStart.Location = new System.Drawing.Point(12, 14);
            this.lblDateStart.Name = "lblDateStart";
            this.lblDateStart.Size = new System.Drawing.Size(16, 13);
            this.lblDateStart.TabIndex = 3;
            this.lblDateStart.Text = "с:";
            // 
            // lblDateEnd
            // 
            this.lblDateEnd.AutoSize = true;
            this.lblDateEnd.Location = new System.Drawing.Point(135, 14);
            this.lblDateEnd.Name = "lblDateEnd";
            this.lblDateEnd.Size = new System.Drawing.Size(22, 13);
            this.lblDateEnd.TabIndex = 4;
            this.lblDateEnd.Text = "по:";
            // 
            // tbCommentOrder
            // 
            this.tbCommentOrder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCommentOrder.Location = new System.Drawing.Point(15, 453);
            this.tbCommentOrder.Multiline = true;
            this.tbCommentOrder.Name = "tbCommentOrder";
            this.tbCommentOrder.ReadOnly = true;
            this.tbCommentOrder.Size = new System.Drawing.Size(492, 49);
            this.tbCommentOrder.TabIndex = 5;
            // 
            // lblCommentOrder
            // 
            this.lblCommentOrder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCommentOrder.AutoSize = true;
            this.lblCommentOrder.Location = new System.Drawing.Point(12, 437);
            this.lblCommentOrder.Name = "lblCommentOrder";
            this.lblCommentOrder.Size = new System.Drawing.Size(141, 13);
            this.lblCommentOrder.TabIndex = 6;
            this.lblCommentOrder.Text = "Комментарий покупателя:";
            // 
            // tbComment
            // 
            this.tbComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbComment.Location = new System.Drawing.Point(513, 453);
            this.tbComment.Multiline = true;
            this.tbComment.Name = "tbComment";
            this.tbComment.ReadOnly = true;
            this.tbComment.Size = new System.Drawing.Size(459, 49);
            this.tbComment.TabIndex = 7;
            // 
            // lblComment
            // 
            this.lblComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblComment.AutoSize = true;
            this.lblComment.Location = new System.Drawing.Point(510, 437);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(134, 13);
            this.lblComment.TabIndex = 8;
            this.lblComment.Text = "Комментарий сборщика:";
            // 
            // tbNumber
            // 
            this.tbNumber.Location = new System.Drawing.Point(12, 43);
            this.tbNumber.Name = "tbNumber";
            this.tbNumber.Size = new System.Drawing.Size(75, 20);
            this.tbNumber.TabIndex = 11;
            this.tbNumber.TextChanged += new System.EventHandler(this.tbNumber_TextChanged);
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(207, 43);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(109, 20);
            this.tbName.TabIndex = 12;
            this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // tbMail
            // 
            this.tbMail.Location = new System.Drawing.Point(363, 43);
            this.tbMail.Name = "tbMail";
            this.tbMail.Size = new System.Drawing.Size(120, 20);
            this.tbMail.TabIndex = 13;
            this.tbMail.TextChanged += new System.EventHandler(this.tbMail_TextChanged);
            // 
            // tbPhone
            // 
            this.tbPhone.Location = new System.Drawing.Point(489, 43);
            this.tbPhone.Name = "tbPhone";
            this.tbPhone.Size = new System.Drawing.Size(108, 20);
            this.tbPhone.TabIndex = 14;
            this.tbPhone.TextChanged += new System.EventHandler(this.tbPhone_TextChanged);
            // 
            // tbAddress
            // 
            this.tbAddress.Location = new System.Drawing.Point(603, 43);
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.Size = new System.Drawing.Size(120, 20);
            this.tbAddress.TabIndex = 15;
            this.tbAddress.TextChanged += new System.EventHandler(this.tbAddress_TextChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsConnect});
            this.statusStrip1.Location = new System.Drawing.Point(0, 505);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(993, 22);
            this.statusStrip1.TabIndex = 18;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsConnect
            // 
            this.tsConnect.Name = "tsConnect";
            this.tsConnect.Size = new System.Drawing.Size(61, 17);
            this.tsConnect.Text = "tsConnect";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(535, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Идет загрузка заказов с сайта...";
            this.label1.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.panel1.Location = new System.Drawing.Point(15, 396);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(16, 16);
            this.panel1.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 398);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(287, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Содержит товары, у которых отличается цена продажи";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(566, 366);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Общая сумма";
            // 
            // tbSumOrders
            // 
            this.tbSumOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSumOrders.Enabled = false;
            this.tbSumOrders.Location = new System.Drawing.Point(650, 362);
            this.tbSumOrders.Name = "tbSumOrders";
            this.tbSumOrders.Size = new System.Drawing.Size(85, 20);
            this.tbSumOrders.TabIndex = 26;
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.BackColor = System.Drawing.Color.White;
            this.btnEdit.Image = global::OnlineStoreViewOrders.Properties.Resources.documentediting_editdocuments_text_documentedi_2820;
            this.btnEdit.Location = new System.Drawing.Point(864, 415);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(32, 32);
            this.btnEdit.TabIndex = 29;
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnView
            // 
            this.btnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnView.BackColor = System.Drawing.Color.White;
            this.btnView.Image = global::OnlineStoreViewOrders.Properties.Resources.Zoomview_6277;
            this.btnView.Location = new System.Drawing.Point(902, 415);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(32, 32);
            this.btnView.TabIndex = 28;
            this.btnView.UseVisualStyleBackColor = false;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnAllReport
            // 
            this.btnAllReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAllReport.BackColor = System.Drawing.Color.White;
            this.btnAllReport.Image = ((System.Drawing.Image)(resources.GetObject("btnAllReport.Image")));
            this.btnAllReport.Location = new System.Drawing.Point(940, 415);
            this.btnAllReport.Name = "btnAllReport";
            this.btnAllReport.Size = new System.Drawing.Size(32, 32);
            this.btnAllReport.TabIndex = 27;
            this.btnAllReport.UseVisualStyleBackColor = false;
            this.btnAllReport.Click += new System.EventHandler(this.btnAllReport_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheck.BackColor = System.Drawing.Color.White;
            this.btnCheck.Image = global::OnlineStoreViewOrders.Properties.Resources._4213403_bill_check_ecommerce_invoice_payment_receipt_shopping_115368;
            this.btnCheck.Location = new System.Drawing.Point(764, 4);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(32, 32);
            this.btnCheck.TabIndex = 24;
            this.btnCheck.UseVisualStyleBackColor = false;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnAddFromSite
            // 
            this.btnAddFromSite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddFromSite.BackColor = System.Drawing.Color.White;
            this.btnAddFromSite.Image = global::OnlineStoreViewOrders.Properties.Resources.iconfinder_download_4341287_120571;
            this.btnAddFromSite.Location = new System.Drawing.Point(727, 4);
            this.btnAddFromSite.Name = "btnAddFromSite";
            this.btnAddFromSite.Size = new System.Drawing.Size(32, 32);
            this.btnAddFromSite.TabIndex = 19;
            this.btnAddFromSite.UseVisualStyleBackColor = false;
            this.btnAddFromSite.Click += new System.EventHandler(this.btnAddFromSite_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.BackColor = System.Drawing.Color.White;
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.Location = new System.Drawing.Point(801, 4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(32, 32);
            this.btnPrint.TabIndex = 17;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.White;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.Location = new System.Drawing.Point(949, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(32, 32);
            this.btnExit.TabIndex = 16;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.BackColor = System.Drawing.Color.White;
            this.btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.Image")));
            this.btnUpdate.Location = new System.Drawing.Point(838, 4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(32, 32);
            this.btnUpdate.TabIndex = 10;
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.BackColor = System.Drawing.Color.White;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(875, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(32, 32);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Visible = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // pEnd
            // 
            this.pEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pEnd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(255)))), ((int)(((byte)(179)))));
            this.pEnd.Location = new System.Drawing.Point(15, 370);
            this.pEnd.Name = "pEnd";
            this.pEnd.Size = new System.Drawing.Size(16, 16);
            this.pEnd.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 372);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Выполнен";
            // 
            // pInWork
            // 
            this.pInWork.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pInWork.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(207)))), ((int)(((byte)(11)))));
            this.pInWork.Location = new System.Drawing.Point(99, 370);
            this.pInWork.Name = "pInWork";
            this.pInWork.Size = new System.Drawing.Size(16, 16);
            this.pInWork.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(121, 372);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "В обработке";
            // 
            // pCancel
            // 
            this.pCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            this.pCancel.Location = new System.Drawing.Point(193, 370);
            this.pCancel.Name = "pCancel";
            this.pCancel.Size = new System.Drawing.Size(16, 16);
            this.pCancel.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(215, 372);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Отменён";
            // 
            // btCreateReport
            // 
            this.btCreateReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btCreateReport.BackColor = System.Drawing.Color.White;
            this.btCreateReport.Location = new System.Drawing.Point(912, 4);
            this.btCreateReport.Name = "btCreateReport";
            this.btCreateReport.Size = new System.Drawing.Size(32, 32);
            this.btCreateReport.TabIndex = 30;
            this.btCreateReport.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(766, 366);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Дата доставки";
            // 
            // tbDeliveryDate
            // 
            this.tbDeliveryDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDeliveryDate.Enabled = false;
            this.tbDeliveryDate.Location = new System.Drawing.Point(855, 362);
            this.tbDeliveryDate.Name = "tbDeliveryDate";
            this.tbDeliveryDate.Size = new System.Drawing.Size(117, 20);
            this.tbDeliveryDate.TabIndex = 26;
            this.tbDeliveryDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(735, 390);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "Затраты на доставку";
            // 
            // tbDeliveryCost
            // 
            this.tbDeliveryCost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDeliveryCost.Enabled = false;
            this.tbDeliveryCost.Location = new System.Drawing.Point(855, 386);
            this.tbDeliveryCost.Name = "tbDeliveryCost";
            this.tbDeliveryCost.Size = new System.Drawing.Size(85, 20);
            this.tbDeliveryCost.TabIndex = 26;
            this.tbDeliveryCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(946, 390);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "руб.";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(376, 10);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(141, 21);
            this.cmbStatus.TabIndex = 31;
            this.cmbStatus.SelectionChangeCommitted += new System.EventHandler(this.cmbStatus_SelectionChangeCommitted);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(279, 14);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "Статусы заказа:";
            // 
            // frmViewOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 527);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.btCreateReport);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.btnAllReport);
            this.Controls.Add(this.tbDeliveryCost);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbDeliveryDate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbSumOrders);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pCancel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pInWork);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pEnd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddFromSite);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.tbAddress);
            this.Controls.Add(this.tbPhone);
            this.Controls.Add(this.tbMail);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.tbNumber);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblComment);
            this.Controls.Add(this.tbComment);
            this.Controls.Add(this.lblCommentOrder);
            this.Controls.Add(this.tbCommentOrder);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblDateEnd);
            this.Controls.Add(this.lblDateStart);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.dgvOrders);
            this.MinimumSize = new System.Drawing.Size(1001, 554);
            this.Name = "frmViewOrders";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Просмотр заказов";
            this.Load += new System.EventHandler(this.frmViewOrders_Load);
            this.SizeChanged += new System.EventHandler(this.frmViewOrders_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.cmsPackage.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label lblDateStart;
        private System.Windows.Forms.Label lblDateEnd;
        private System.Windows.Forms.TextBox tbCommentOrder;
        private System.Windows.Forms.Label lblCommentOrder;
        private System.Windows.Forms.TextBox tbComment;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox tbNumber;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbMail;
        private System.Windows.Forms.TextBox tbPhone;
        private System.Windows.Forms.TextBox tbAddress;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsConnect;
        private System.Windows.Forms.Button btnAddFromSite;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip cmsPackage;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn Buyer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDelivery;
        private System.Windows.Forms.DataGridViewTextBoxColumn Payment;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbSumOrders;
        private System.Windows.Forms.Button btnAllReport;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.ToolStripMenuItem историяСтатусовЗаказаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изменитьСтоимостьДоставкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem заказВОбработкеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem заказВыполненToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem заказОтменёнToolStripMenuItem;
        private System.Windows.Forms.Panel pEnd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pInWork;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pCancel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btCreateReport;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbDeliveryDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbDeliveryCost;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label label10;
    }
}

