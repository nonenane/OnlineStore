namespace OnlineStore
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.справочникToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.категорийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.категорийИГруппToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.формированиеCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выгрузитьВсеДоступныеТоварыВФайлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выгрузитьВыбранныеТоварыВФайлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отображаемыеНаФормеТоварыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выгрузитьИзмененныеТоварыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Settings = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиПроцентовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmbDeps = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTU = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbInv = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbParentCategory = new System.Windows.Forms.ComboBox();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.cId_tovar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cEan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNameCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCountOnline = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.сMoveNow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cOstNow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cRcena = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cRcenaOnline = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cRcenaOnlineAction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbName = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chbUnable = new System.Windows.Forms.CheckBox();
            this.tbStock = new System.Windows.Forms.TextBox();
            this.lblStock = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tbEan = new System.Windows.Forms.TextBox();
            this.gbPriceChange = new System.Windows.Forms.GroupBox();
            this.btChangePrice = new System.Windows.Forms.Button();
            this.rbSelected = new System.Windows.Forms.RadioButton();
            this.rbView = new System.Windows.Forms.RadioButton();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.chckPrice = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.chckUnloaded = new System.Windows.Forms.CheckBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.chckSale = new System.Windows.Forms.CheckBox();
            this.btnEditAttribute = new System.Windows.Forms.Button();
            this.btnAddTovars = new System.Windows.Forms.Button();
            this.btnViewOrders = new System.Windows.Forms.Button();
            this.btUpdate = new System.Windows.Forms.Button();
            this.btAdd = new System.Windows.Forms.Button();
            this.btEdit = new System.Windows.Forms.Button();
            this.btPrint = new System.Windows.Forms.Button();
            this.btDel = new System.Windows.Forms.Button();
            this.настройкиВремениДняПереносаДоставкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.gbPriceChange.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникToolStripMenuItem,
            this.формированиеCSVToolStripMenuItem,
            this.Settings,
            this.выходToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1251, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // справочникToolStripMenuItem
            // 
            this.справочникToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.категорийToolStripMenuItem,
            this.категорийИГруппToolStripMenuItem});
            this.справочникToolStripMenuItem.Name = "справочникToolStripMenuItem";
            this.справочникToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.справочникToolStripMenuItem.Text = "Справочник";
            // 
            // категорийToolStripMenuItem
            // 
            this.категорийToolStripMenuItem.Name = "категорийToolStripMenuItem";
            this.категорийToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.категорийToolStripMenuItem.Text = "Категорий";
            this.категорийToolStripMenuItem.Click += new System.EventHandler(this.категорийToolStripMenuItem_Click);
            // 
            // категорийИГруппToolStripMenuItem
            // 
            this.категорийИГруппToolStripMenuItem.Name = "категорийИГруппToolStripMenuItem";
            this.категорийИГруппToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.категорийИГруппToolStripMenuItem.Text = "Категорий и групп";
            this.категорийИГруппToolStripMenuItem.Click += new System.EventHandler(this.категорийИГруппToolStripMenuItem_Click);
            // 
            // формированиеCSVToolStripMenuItem
            // 
            this.формированиеCSVToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выгрузитьВсеДоступныеТоварыВФайлToolStripMenuItem,
            this.выгрузитьВыбранныеТоварыВФайлToolStripMenuItem,
            this.отображаемыеНаФормеТоварыToolStripMenuItem,
            this.выгрузитьИзмененныеТоварыToolStripMenuItem});
            this.формированиеCSVToolStripMenuItem.Name = "формированиеCSVToolStripMenuItem";
            this.формированиеCSVToolStripMenuItem.Size = new System.Drawing.Size(115, 20);
            this.формированиеCSVToolStripMenuItem.Text = "Формирование CSV";
            // 
            // выгрузитьВсеДоступныеТоварыВФайлToolStripMenuItem
            // 
            this.выгрузитьВсеДоступныеТоварыВФайлToolStripMenuItem.Name = "выгрузитьВсеДоступныеТоварыВФайлToolStripMenuItem";
            this.выгрузитьВсеДоступныеТоварыВФайлToolStripMenuItem.Size = new System.Drawing.Size(286, 22);
            this.выгрузитьВсеДоступныеТоварыВФайлToolStripMenuItem.Text = "Выгрузить все доступные товары в файл";
            this.выгрузитьВсеДоступныеТоварыВФайлToolStripMenuItem.Click += new System.EventHandler(this.выгрузитьВсеДоступныеТоварыВФайлToolStripMenuItem_Click);
            // 
            // выгрузитьВыбранныеТоварыВФайлToolStripMenuItem
            // 
            this.выгрузитьВыбранныеТоварыВФайлToolStripMenuItem.Name = "выгрузитьВыбранныеТоварыВФайлToolStripMenuItem";
            this.выгрузитьВыбранныеТоварыВФайлToolStripMenuItem.Size = new System.Drawing.Size(286, 22);
            this.выгрузитьВыбранныеТоварыВФайлToolStripMenuItem.Text = "Выгрузить выбранные товары в файл ";
            this.выгрузитьВыбранныеТоварыВФайлToolStripMenuItem.Click += new System.EventHandler(this.выгрузитьВыбранныеТоварыВФайлToolStripMenuItem_Click);
            // 
            // отображаемыеНаФормеТоварыToolStripMenuItem
            // 
            this.отображаемыеНаФормеТоварыToolStripMenuItem.Name = "отображаемыеНаФормеТоварыToolStripMenuItem";
            this.отображаемыеНаФормеТоварыToolStripMenuItem.Size = new System.Drawing.Size(286, 22);
            this.отображаемыеНаФормеТоварыToolStripMenuItem.Text = "Отображаемые на форме товары";
            this.отображаемыеНаФормеТоварыToolStripMenuItem.Click += new System.EventHandler(this.отображаемыеНаФормеТоварыToolStripMenuItem_Click);
            // 
            // выгрузитьИзмененныеТоварыToolStripMenuItem
            // 
            this.выгрузитьИзмененныеТоварыToolStripMenuItem.Name = "выгрузитьИзмененныеТоварыToolStripMenuItem";
            this.выгрузитьИзмененныеТоварыToolStripMenuItem.Size = new System.Drawing.Size(286, 22);
            this.выгрузитьИзмененныеТоварыToolStripMenuItem.Text = "Выгрузить измененные товары";
            this.выгрузитьИзмененныеТоварыToolStripMenuItem.Click += new System.EventHandler(this.выгрузитьИзмененныеТоварыToolStripMenuItem_Click);
            // 
            // Settings
            // 
            this.Settings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.настройкиCSVToolStripMenuItem,
            this.настройкиПроцентовToolStripMenuItem,
            this.настройкиВремениДняПереносаДоставкиToolStripMenuItem});
            this.Settings.Name = "Settings";
            this.Settings.Size = new System.Drawing.Size(73, 20);
            this.Settings.Text = "Настройки";
            this.Settings.Click += new System.EventHandler(this.Settings_Click);
            // 
            // настройкиCSVToolStripMenuItem
            // 
            this.настройкиCSVToolStripMenuItem.Name = "настройкиCSVToolStripMenuItem";
            this.настройкиCSVToolStripMenuItem.Size = new System.Drawing.Size(296, 22);
            this.настройкиCSVToolStripMenuItem.Text = "Настройки CSV";
            this.настройкиCSVToolStripMenuItem.Click += new System.EventHandler(this.настройкиCSVToolStripMenuItem_Click);
            // 
            // настройкиПроцентовToolStripMenuItem
            // 
            this.настройкиПроцентовToolStripMenuItem.Name = "настройкиПроцентовToolStripMenuItem";
            this.настройкиПроцентовToolStripMenuItem.Size = new System.Drawing.Size(296, 22);
            this.настройкиПроцентовToolStripMenuItem.Text = "Настройки процентов";
            this.настройкиПроцентовToolStripMenuItem.Click += new System.EventHandler(this.настройкиПроцентовToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // cmbDeps
            // 
            this.cmbDeps.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDeps.FormattingEnabled = true;
            this.cmbDeps.Location = new System.Drawing.Point(79, 27);
            this.cmbDeps.Name = "cmbDeps";
            this.cmbDeps.Size = new System.Drawing.Size(169, 21);
            this.cmbDeps.TabIndex = 10;
            this.cmbDeps.SelectionChangeCommitted += new System.EventHandler(this.cmbDeps_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Отдел:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(274, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Т\\У группа:";
            // 
            // cmbTU
            // 
            this.cmbTU.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTU.FormattingEnabled = true;
            this.cmbTU.Location = new System.Drawing.Point(344, 27);
            this.cmbTU.Name = "cmbTU";
            this.cmbTU.Size = new System.Drawing.Size(169, 21);
            this.cmbTU.TabIndex = 10;
            this.cmbTU.SelectionChangeCommitted += new System.EventHandler(this.cmbTU_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(271, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Инв. группа:";
            // 
            // cmbInv
            // 
            this.cmbInv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInv.FormattingEnabled = true;
            this.cmbInv.Location = new System.Drawing.Point(344, 54);
            this.cmbInv.Name = "cmbInv";
            this.cmbInv.Size = new System.Drawing.Size(169, 21);
            this.cmbInv.TabIndex = 10;
            this.cmbInv.SelectionChangeCommitted += new System.EventHandler(this.cmbInv_SelectionChangeCommitted);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Категория:";
            // 
            // cmbParentCategory
            // 
            this.cmbParentCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParentCategory.FormattingEnabled = true;
            this.cmbParentCategory.Location = new System.Drawing.Point(79, 54);
            this.cmbParentCategory.Name = "cmbParentCategory";
            this.cmbParentCategory.Size = new System.Drawing.Size(169, 21);
            this.cmbParentCategory.TabIndex = 10;
            this.cmbParentCategory.SelectedIndexChanged += new System.EventHandler(this.cmbParentCategory_SelectedIndexChanged);
            this.cmbParentCategory.SelectionChangeCommitted += new System.EventHandler(this.cmbParentCategory_SelectionChangeCommitted);
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToResizeRows = false;
            this.dgvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cId_tovar,
            this.cEan,
            this.cName,
            this.cNameCategory,
            this.cCountOnline,
            this.сMoveNow,
            this.cOstNow,
            this.cRcena,
            this.cRcenaOnline,
            this.cRcenaOnlineAction});
            this.dgvData.Location = new System.Drawing.Point(13, 113);
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(1218, 390);
            this.dgvData.TabIndex = 27;
            this.dgvData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellClick);
            this.dgvData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellDoubleClick);
            this.dgvData.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvData_RowPostPaint);
            this.dgvData.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvData_RowPrePaint);
            this.dgvData.SelectionChanged += new System.EventHandler(this.dgvData_SelectionChanged);
            this.dgvData.Paint += new System.Windows.Forms.PaintEventHandler(this.dgvData_Paint);
            // 
            // cId_tovar
            // 
            this.cId_tovar.DataPropertyName = "id_Tovar";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.cId_tovar.DefaultCellStyle = dataGridViewCellStyle2;
            this.cId_tovar.FillWeight = 50.04749F;
            this.cId_tovar.HeaderText = "Артикул товара ";
            this.cId_tovar.Name = "cId_tovar";
            this.cId_tovar.ReadOnly = true;
            // 
            // cEan
            // 
            this.cEan.DataPropertyName = "ean";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.cEan.DefaultCellStyle = dataGridViewCellStyle3;
            this.cEan.FillWeight = 73.74648F;
            this.cEan.HeaderText = "EAN";
            this.cEan.Name = "cEan";
            this.cEan.ReadOnly = true;
            // 
            // cName
            // 
            this.cName.DataPropertyName = "ShortName";
            this.cName.FillWeight = 137.0558F;
            this.cName.HeaderText = "Наименование товара";
            this.cName.Name = "cName";
            this.cName.ReadOnly = true;
            // 
            // cNameCategory
            // 
            this.cNameCategory.DataPropertyName = "nameCategory";
            this.cNameCategory.FillWeight = 105.5929F;
            this.cNameCategory.HeaderText = "Категория товара";
            this.cNameCategory.Name = "cNameCategory";
            this.cNameCategory.ReadOnly = true;
            // 
            // cCountOnline
            // 
            this.cCountOnline.DataPropertyName = "countOnlineSell";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.cCountOnline.DefaultCellStyle = dataGridViewCellStyle4;
            this.cCountOnline.FillWeight = 105.5929F;
            this.cCountOnline.HeaderText = "Он-лайн продажи товара";
            this.cCountOnline.Name = "cCountOnline";
            this.cCountOnline.ReadOnly = true;
            // 
            // сMoveNow
            // 
            this.сMoveNow.DataPropertyName = "moveNow";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.сMoveNow.DefaultCellStyle = dataGridViewCellStyle5;
            this.сMoveNow.FillWeight = 105.5929F;
            this.сMoveNow.HeaderText = "Движение товара за сегодня";
            this.сMoveNow.Name = "сMoveNow";
            this.сMoveNow.ReadOnly = true;
            // 
            // cOstNow
            // 
            this.cOstNow.DataPropertyName = "ostNow";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.cOstNow.DefaultCellStyle = dataGridViewCellStyle6;
            this.cOstNow.FillWeight = 105.5929F;
            this.cOstNow.HeaderText = "Остаток товара в магазине на К21";
            this.cOstNow.Name = "cOstNow";
            this.cOstNow.ReadOnly = true;
            // 
            // cRcena
            // 
            this.cRcena.DataPropertyName = "rcena";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.cRcena.DefaultCellStyle = dataGridViewCellStyle7;
            this.cRcena.FillWeight = 105.5929F;
            this.cRcena.HeaderText = "Цена продажи";
            this.cRcena.Name = "cRcena";
            this.cRcena.ReadOnly = true;
            // 
            // cRcenaOnline
            // 
            this.cRcenaOnline.DataPropertyName = "rcenaOnline";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.cRcenaOnline.DefaultCellStyle = dataGridViewCellStyle8;
            this.cRcenaOnline.FillWeight = 105.5929F;
            this.cRcenaOnline.HeaderText = "Цена продажи он-лайн";
            this.cRcenaOnline.Name = "cRcenaOnline";
            this.cRcenaOnline.ReadOnly = true;
            // 
            // cRcenaOnlineAction
            // 
            this.cRcenaOnlineAction.DataPropertyName = "rcenaPromo";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.cRcenaOnlineAction.DefaultCellStyle = dataGridViewCellStyle9;
            this.cRcenaOnlineAction.FillWeight = 105.5929F;
            this.cRcenaOnlineAction.HeaderText = "Старая цена для распродажи";
            this.cRcenaOnlineAction.Name = "cRcenaOnlineAction";
            this.cRcenaOnlineAction.ReadOnly = true;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(13, 87);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(156, 20);
            this.tbName.TabIndex = 26;
            this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(13, 509);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(19, 19);
            this.panel1.TabIndex = 29;
            // 
            // chbUnable
            // 
            this.chbUnable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chbUnable.AutoSize = true;
            this.chbUnable.Location = new System.Drawing.Point(35, 511);
            this.chbUnable.Name = "chbUnable";
            this.chbUnable.Size = new System.Drawing.Size(107, 17);
            this.chbUnable.TabIndex = 28;
            this.chbUnable.Text = "недействующие";
            this.chbUnable.UseVisualStyleBackColor = true;
            this.chbUnable.CheckedChanged += new System.EventHandler(this.chbUnable_CheckedChanged);
            // 
            // tbStock
            // 
            this.tbStock.Location = new System.Drawing.Point(744, 87);
            this.tbStock.Name = "tbStock";
            this.tbStock.Size = new System.Drawing.Size(95, 20);
            this.tbStock.TabIndex = 35;
            this.tbStock.TextChanged += new System.EventHandler(this.tbStock_TextChanged);
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Location = new System.Drawing.Point(579, 90);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(159, 13);
            this.lblStock.TabIndex = 36;
            this.lblStock.Text = "Выгружать с остатком более:";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(150, 509);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(19, 19);
            this.panel2.TabIndex = 31;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(194, 513);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(168, 13);
            this.label5.TabIndex = 37;
            this.label5.Text = "Базовая цена не соответствует";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 555);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1251, 22);
            this.statusStrip1.TabIndex = 38;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsLabel
            // 
            this.tsLabel.Name = "tsLabel";
            this.tsLabel.Size = new System.Drawing.Size(109, 17);
            this.tsLabel.Text = "toolStripStatusLabel1";
            // 
            // tbEan
            // 
            this.tbEan.Location = new System.Drawing.Point(175, 87);
            this.tbEan.MaxLength = 13;
            this.tbEan.Name = "tbEan";
            this.tbEan.Size = new System.Drawing.Size(123, 20);
            this.tbEan.TabIndex = 39;
            this.tbEan.TextChanged += new System.EventHandler(this.tbEan_TextChanged);
            // 
            // gbPriceChange
            // 
            this.gbPriceChange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPriceChange.Controls.Add(this.btChangePrice);
            this.gbPriceChange.Controls.Add(this.rbSelected);
            this.gbPriceChange.Controls.Add(this.rbView);
            this.gbPriceChange.Controls.Add(this.rbAll);
            this.gbPriceChange.Location = new System.Drawing.Point(1002, 27);
            this.gbPriceChange.Name = "gbPriceChange";
            this.gbPriceChange.Size = new System.Drawing.Size(229, 80);
            this.gbPriceChange.TabIndex = 41;
            this.gbPriceChange.TabStop = false;
            this.gbPriceChange.Text = "Обновление цены";
            this.gbPriceChange.Enter += new System.EventHandler(this.gbPriceChange_Enter);
            // 
            // btChangePrice
            // 
            this.btChangePrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btChangePrice.Enabled = false;
            this.btChangePrice.Image = global::OnlineStore.Properties.Resources.btnChangePrice;
            this.btChangePrice.Location = new System.Drawing.Point(191, 44);
            this.btChangePrice.Name = "btChangePrice";
            this.btChangePrice.Size = new System.Drawing.Size(32, 32);
            this.btChangePrice.TabIndex = 42;
            this.btChangePrice.UseVisualStyleBackColor = true;
            this.btChangePrice.Click += new System.EventHandler(this.btChangePrice_Click);
            // 
            // rbSelected
            // 
            this.rbSelected.AutoSize = true;
            this.rbSelected.Location = new System.Drawing.Point(6, 57);
            this.rbSelected.Name = "rbSelected";
            this.rbSelected.Size = new System.Drawing.Size(175, 17);
            this.rbSelected.TabIndex = 2;
            this.rbSelected.TabStop = true;
            this.rbSelected.Text = "Обновить выбранные товары";
            this.rbSelected.UseVisualStyleBackColor = true;
            this.rbSelected.CheckedChanged += new System.EventHandler(this.rbSelected_CheckedChanged);
            // 
            // rbView
            // 
            this.rbView.AutoSize = true;
            this.rbView.Location = new System.Drawing.Point(6, 37);
            this.rbView.Name = "rbView";
            this.rbView.Size = new System.Drawing.Size(163, 17);
            this.rbView.TabIndex = 1;
            this.rbView.TabStop = true;
            this.rbView.Text = "Обновить видимые товары";
            this.rbView.UseVisualStyleBackColor = true;
            this.rbView.CheckedChanged += new System.EventHandler(this.rbView_CheckedChanged);
            // 
            // rbAll
            // 
            this.rbAll.AutoSize = true;
            this.rbAll.Location = new System.Drawing.Point(6, 19);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(135, 17);
            this.rbAll.TabIndex = 0;
            this.rbAll.TabStop = true;
            this.rbAll.Text = "Обновить все товары";
            this.rbAll.UseVisualStyleBackColor = true;
            this.rbAll.CheckedChanged += new System.EventHandler(this.rbAll_CheckedChanged);
            // 
            // chckPrice
            // 
            this.chckPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chckPrice.AutoSize = true;
            this.chckPrice.Location = new System.Drawing.Point(173, 513);
            this.chckPrice.Name = "chckPrice";
            this.chckPrice.Size = new System.Drawing.Size(15, 14);
            this.chckPrice.TabIndex = 42;
            this.chckPrice.UseVisualStyleBackColor = true;
            this.chckPrice.CheckedChanged += new System.EventHandler(this.chckPrice_CheckedChanged);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(456, 515);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 13);
            this.label6.TabIndex = 39;
            this.label6.Text = "Не выгружены на сайт";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(238)))), ((int)(((byte)(189)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Location = new System.Drawing.Point(418, 512);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(19, 19);
            this.panel3.TabIndex = 38;
            // 
            // chckUnloaded
            // 
            this.chckUnloaded.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chckUnloaded.AutoSize = true;
            this.chckUnloaded.Location = new System.Drawing.Point(443, 515);
            this.chckUnloaded.Name = "chckUnloaded";
            this.chckUnloaded.Size = new System.Drawing.Size(15, 14);
            this.chckUnloaded.TabIndex = 43;
            this.chckUnloaded.UseVisualStyleBackColor = true;
            this.chckUnloaded.CheckedChanged += new System.EventHandler(this.chckUnloaded_CheckedChanged);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(230)))), ((int)(((byte)(115)))));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Location = new System.Drawing.Point(585, 512);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(19, 19);
            this.panel4.TabIndex = 39;
            // 
            // chckSale
            // 
            this.chckSale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chckSale.AutoSize = true;
            this.chckSale.Location = new System.Drawing.Point(610, 514);
            this.chckSale.Name = "chckSale";
            this.chckSale.Size = new System.Drawing.Size(89, 17);
            this.chckSale.TabIndex = 44;
            this.chckSale.Text = "Распродажа";
            this.chckSale.UseVisualStyleBackColor = true;
            this.chckSale.CheckedChanged += new System.EventHandler(this.chckSale_CheckedChanged);
            // 
            // btnEditAttribute
            // 
            this.btnEditAttribute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditAttribute.Image = global::OnlineStore.Properties.Resources.editdocument_105148;
            this.btnEditAttribute.Location = new System.Drawing.Point(1047, 508);
            this.btnEditAttribute.Name = "btnEditAttribute";
            this.btnEditAttribute.Size = new System.Drawing.Size(32, 32);
            this.btnEditAttribute.TabIndex = 46;
            this.btnEditAttribute.UseVisualStyleBackColor = true;
            this.btnEditAttribute.Click += new System.EventHandler(this.btnEditAttribute_Click);
            // 
            // btnAddTovars
            // 
            this.btnAddTovars.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddTovars.Image = global::OnlineStore.Properties.Resources.add_book_icon_icons_com_71795;
            this.btnAddTovars.Location = new System.Drawing.Point(1085, 508);
            this.btnAddTovars.Name = "btnAddTovars";
            this.btnAddTovars.Size = new System.Drawing.Size(32, 32);
            this.btnAddTovars.TabIndex = 45;
            this.btnAddTovars.UseVisualStyleBackColor = true;
            this.btnAddTovars.Click += new System.EventHandler(this.btnAddTovars_Click);
            // 
            // btnViewOrders
            // 
            this.btnViewOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewOrders.Image = global::OnlineStore.Properties.Resources.viewOrder;
            this.btnViewOrders.Location = new System.Drawing.Point(945, 508);
            this.btnViewOrders.Name = "btnViewOrders";
            this.btnViewOrders.Size = new System.Drawing.Size(32, 32);
            this.btnViewOrders.TabIndex = 40;
            this.btnViewOrders.UseVisualStyleBackColor = true;
            this.btnViewOrders.Click += new System.EventHandler(this.btnViewOrders_Click);
            // 
            // btUpdate
            // 
            this.btUpdate.Image = global::OnlineStore.Properties.Resources.button_refresh_15001__1_1;
            this.btUpdate.Location = new System.Drawing.Point(519, 27);
            this.btUpdate.Name = "btUpdate";
            this.btUpdate.Size = new System.Drawing.Size(49, 48);
            this.btUpdate.TabIndex = 34;
            this.btUpdate.UseVisualStyleBackColor = true;
            this.btUpdate.Click += new System.EventHandler(this.btUpdate_Click);
            // 
            // btAdd
            // 
            this.btAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btAdd.Image = global::OnlineStore.Properties.Resources.compfile_1551;
            this.btAdd.Location = new System.Drawing.Point(1123, 508);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(32, 32);
            this.btAdd.TabIndex = 32;
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // btEdit
            // 
            this.btEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btEdit.Image = global::OnlineStore.Properties.Resources.edit_1761;
            this.btEdit.Location = new System.Drawing.Point(1161, 508);
            this.btEdit.Name = "btEdit";
            this.btEdit.Size = new System.Drawing.Size(32, 32);
            this.btEdit.TabIndex = 33;
            this.btEdit.UseVisualStyleBackColor = true;
            this.btEdit.Click += new System.EventHandler(this.btEdit_Click);
            // 
            // btPrint
            // 
            this.btPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btPrint.Image = global::OnlineStore.Properties.Resources.klpq_2511;
            this.btPrint.Location = new System.Drawing.Point(983, 508);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(32, 32);
            this.btPrint.TabIndex = 30;
            this.btPrint.UseVisualStyleBackColor = true;
            this.btPrint.Click += new System.EventHandler(this.btPrint_Click);
            // 
            // btDel
            // 
            this.btDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btDel.Image = global::OnlineStore.Properties.Resources.editdelete_3805;
            this.btDel.Location = new System.Drawing.Point(1199, 508);
            this.btDel.Name = "btDel";
            this.btDel.Size = new System.Drawing.Size(32, 32);
            this.btDel.TabIndex = 31;
            this.btDel.UseVisualStyleBackColor = true;
            this.btDel.Click += new System.EventHandler(this.btDel_Click);
            // 
            // настройкиВремениДняПереносаДоставкиToolStripMenuItem
            // 
            this.настройкиВремениДняПереносаДоставкиToolStripMenuItem.Name = "настройкиВремениДняПереносаДоставкиToolStripMenuItem";
            this.настройкиВремениДняПереносаДоставкиToolStripMenuItem.Size = new System.Drawing.Size(296, 22);
            this.настройкиВремениДняПереносаДоставкиToolStripMenuItem.Text = "Настройка времени дня переноса доставки";
            this.настройкиВремениДняПереносаДоставкиToolStripMenuItem.Click += new System.EventHandler(this.настройкиВремениДняПереносаДоставкиToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1251, 577);
            this.Controls.Add(this.btnEditAttribute);
            this.Controls.Add(this.btnAddTovars);
            this.Controls.Add(this.chckSale);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.chckUnloaded);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chckPrice);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.gbPriceChange);
            this.Controls.Add(this.btnViewOrders);
            this.Controls.Add(this.tbEan);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblStock);
            this.Controls.Add(this.tbStock);
            this.Controls.Add(this.btUpdate);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.btEdit);
            this.Controls.Add(this.btPrint);
            this.Controls.Add(this.btDel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.chbUnable);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.cmbInv);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbTU);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbParentCategory);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbDeps);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1259, 604);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.gbPriceChange.ResumeLayout(false);
            this.gbPriceChange.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem справочникToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem категорийToolStripMenuItem;
        private System.Windows.Forms.ComboBox cmbDeps;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTU;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbInv;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbParentCategory;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chbUnable;
        private System.Windows.Forms.Button btPrint;
        private System.Windows.Forms.Button btDel;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.Button btEdit;
        private System.Windows.Forms.Button btUpdate;
        private System.Windows.Forms.ToolStripMenuItem формированиеCSVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выгрузитьВсеДоступныеТоварыВФайлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выгрузитьВыбранныеТоварыВФайлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отображаемыеНаФормеТоварыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выгрузитьИзмененныеТоварыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Settings;
        private System.Windows.Forms.TextBox tbStock;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsLabel;
        private System.Windows.Forms.TextBox tbEan;
        private System.Windows.Forms.Button btnViewOrders;
        private System.Windows.Forms.GroupBox gbPriceChange;
        private System.Windows.Forms.RadioButton rbSelected;
        private System.Windows.Forms.RadioButton rbView;
        private System.Windows.Forms.RadioButton rbAll;
        private System.Windows.Forms.Button btChangePrice;
        private System.Windows.Forms.CheckBox chckPrice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox chckUnloaded;
        private System.Windows.Forms.DataGridViewTextBoxColumn cId_tovar;
        private System.Windows.Forms.DataGridViewTextBoxColumn cEan;
        private System.Windows.Forms.DataGridViewTextBoxColumn cName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNameCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCountOnline;
        private System.Windows.Forms.DataGridViewTextBoxColumn сMoveNow;
        private System.Windows.Forms.DataGridViewTextBoxColumn cOstNow;
        private System.Windows.Forms.DataGridViewTextBoxColumn cRcena;
        private System.Windows.Forms.DataGridViewTextBoxColumn cRcenaOnline;
        private System.Windows.Forms.DataGridViewTextBoxColumn cRcenaOnlineAction;
        private System.Windows.Forms.ToolStripMenuItem настройкиCSVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкиПроцентовToolStripMenuItem;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.CheckBox chckSale;
        private System.Windows.Forms.Button btnAddTovars;
        private System.Windows.Forms.ToolStripMenuItem категорийИГруппToolStripMenuItem;
        private System.Windows.Forms.Button btnEditAttribute;
        private System.Windows.Forms.ToolStripMenuItem настройкиВремениДняПереносаДоставкиToolStripMenuItem;
    }
}

