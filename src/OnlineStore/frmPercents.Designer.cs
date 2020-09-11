namespace OnlineStore
{
    partial class frmPercents
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvPercents = new System.Windows.Forms.DataGridView();
            this.cDep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cMargin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSale = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.chckUseSale = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chbUsedPrc = new System.Windows.Forms.CheckBox();
            this.tbNameGrp = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btAddGrp = new System.Windows.Forms.Button();
            this.btDelGrp = new System.Windows.Forms.Button();
            this.dgvDataGrp = new System.Windows.Forms.DataGridView();
            this.cmbDepsGrp = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.cmbInv = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTU = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chbUserPrcTovar = new System.Windows.Forms.CheckBox();
            this.tbNameTovar = new System.Windows.Forms.TextBox();
            this.tbEan = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.btAddGood = new System.Windows.Forms.Button();
            this.btDeleteTovar = new System.Windows.Forms.Button();
            this.dgvDataTovar = new System.Windows.Forms.DataGridView();
            this.cmbDepsTovar = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cNameGrp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cEan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNameTovar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPercents)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataGrp)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataTovar)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPercents
            // 
            this.dgvPercents.AllowUserToAddRows = false;
            this.dgvPercents.AllowUserToDeleteRows = false;
            this.dgvPercents.AllowUserToResizeRows = false;
            this.dgvPercents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPercents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPercents.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPercents.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvPercents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPercents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cDep,
            this.cMargin,
            this.cSale});
            this.dgvPercents.Location = new System.Drawing.Point(6, 6);
            this.dgvPercents.Name = "dgvPercents";
            this.dgvPercents.RowHeadersVisible = false;
            this.dgvPercents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPercents.ShowCellErrors = false;
            this.dgvPercents.ShowCellToolTips = false;
            this.dgvPercents.ShowEditingIcon = false;
            this.dgvPercents.ShowRowErrors = false;
            this.dgvPercents.Size = new System.Drawing.Size(796, 393);
            this.dgvPercents.TabIndex = 0;
            this.dgvPercents.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPercents_CellValidated);
            this.dgvPercents.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvPercents_CellValidating);
            this.dgvPercents.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvPercents_DataError);
            this.dgvPercents.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvPercents_EditingControlShowing_1);
            this.dgvPercents.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvPercents_RowPostPaint);
            this.dgvPercents.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvPercents_RowPrePaint);
            this.dgvPercents.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvPercents_KeyPress);
            // 
            // cDep
            // 
            this.cDep.DataPropertyName = "name";
            this.cDep.FillWeight = 152.2843F;
            this.cDep.HeaderText = "Отдел";
            this.cDep.Name = "cDep";
            this.cDep.ReadOnly = true;
            // 
            // cMargin
            // 
            this.cMargin.DataPropertyName = "MarkUpPercent";
            this.cMargin.FillWeight = 73.85786F;
            this.cMargin.HeaderText = "Процент наценки";
            this.cMargin.Name = "cMargin";
            // 
            // cSale
            // 
            this.cSale.DataPropertyName = "salePercent";
            this.cSale.FillWeight = 73.85786F;
            this.cSale.HeaderText = "Процент распродажи";
            this.cSale.Name = "cSale";
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.White;
            this.btnExit.Image = global::OnlineStore.Properties.Resources.pngExit;
            this.btnExit.Location = new System.Drawing.Point(770, 405);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(32, 32);
            this.btnExit.TabIndex = 1;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.Image = global::OnlineStore.Properties.Resources.filesave_2175;
            this.btnSave.Location = new System.Drawing.Point(732, 405);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(32, 32);
            this.btnSave.TabIndex = 2;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chckUseSale
            // 
            this.chckUseSale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chckUseSale.AutoSize = true;
            this.chckUseSale.Location = new System.Drawing.Point(6, 414);
            this.chckUseSale.Name = "chckUseSale";
            this.chckUseSale.Size = new System.Drawing.Size(193, 17);
            this.chckUseSale.TabIndex = 3;
            this.chckUseSale.Text = "Использовать цены распродажи";
            this.chckUseSale.UseVisualStyleBackColor = true;
            this.chckUseSale.CheckedChanged += new System.EventHandler(this.chckUseSale_CheckedChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(818, 471);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvPercents);
            this.tabPage1.Controls.Add(this.chckUseSale);
            this.tabPage1.Controls.Add(this.btnExit);
            this.tabPage1.Controls.Add(this.btnSave);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(810, 445);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Отделы";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chbUsedPrc);
            this.tabPage2.Controls.Add(this.tbNameGrp);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.btAddGrp);
            this.tabPage2.Controls.Add(this.btDelGrp);
            this.tabPage2.Controls.Add(this.dgvDataGrp);
            this.tabPage2.Controls.Add(this.cmbDepsGrp);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(810, 445);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Группы";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // chbUsedPrc
            // 
            this.chbUsedPrc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chbUsedPrc.AutoSize = true;
            this.chbUsedPrc.Location = new System.Drawing.Point(12, 414);
            this.chbUsedPrc.Name = "chbUsedPrc";
            this.chbUsedPrc.Size = new System.Drawing.Size(119, 17);
            this.chbUsedPrc.TabIndex = 17;
            this.chbUsedPrc.Text = "Назначен процент";
            this.chbUsedPrc.UseVisualStyleBackColor = true;
            this.chbUsedPrc.CheckedChanged += new System.EventHandler(this.chbUsedPrc_CheckedChanged);
            // 
            // tbNameGrp
            // 
            this.tbNameGrp.Location = new System.Drawing.Point(8, 37);
            this.tbNameGrp.Name = "tbNameGrp";
            this.tbNameGrp.Size = new System.Drawing.Size(323, 20);
            this.tbNameGrp.TabIndex = 16;
            this.tbNameGrp.TextChanged += new System.EventHandler(this.tbNameGrp_TextChanged);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Image = global::OnlineStore.Properties.Resources.pngExit;
            this.button1.Location = new System.Drawing.Point(770, 405);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(32, 32);
            this.button1.TabIndex = 14;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btAddGrp
            // 
            this.btAddGrp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btAddGrp.BackColor = System.Drawing.Color.Transparent;
            this.btAddGrp.Image = global::OnlineStore.Properties.Resources.compfile_1551;
            this.btAddGrp.Location = new System.Drawing.Point(659, 405);
            this.btAddGrp.Name = "btAddGrp";
            this.btAddGrp.Size = new System.Drawing.Size(32, 32);
            this.btAddGrp.TabIndex = 15;
            this.btAddGrp.UseVisualStyleBackColor = false;
            this.btAddGrp.Click += new System.EventHandler(this.btAddGrp_Click);
            // 
            // btDelGrp
            // 
            this.btDelGrp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btDelGrp.BackColor = System.Drawing.Color.Transparent;
            this.btDelGrp.Image = global::OnlineStore.Properties.Resources.editdelete_3805;
            this.btDelGrp.Location = new System.Drawing.Point(697, 405);
            this.btDelGrp.Name = "btDelGrp";
            this.btDelGrp.Size = new System.Drawing.Size(32, 32);
            this.btDelGrp.TabIndex = 15;
            this.btDelGrp.UseVisualStyleBackColor = false;
            this.btDelGrp.Click += new System.EventHandler(this.btDelGrp_Click);
            // 
            // dgvDataGrp
            // 
            this.dgvDataGrp.AllowUserToAddRows = false;
            this.dgvDataGrp.AllowUserToDeleteRows = false;
            this.dgvDataGrp.AllowUserToResizeRows = false;
            this.dgvDataGrp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDataGrp.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDataGrp.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDataGrp.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvDataGrp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataGrp.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cNameGrp,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.dgvDataGrp.Location = new System.Drawing.Point(8, 63);
            this.dgvDataGrp.MultiSelect = false;
            this.dgvDataGrp.Name = "dgvDataGrp";
            this.dgvDataGrp.ReadOnly = true;
            this.dgvDataGrp.RowHeadersVisible = false;
            this.dgvDataGrp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDataGrp.ShowCellErrors = false;
            this.dgvDataGrp.ShowCellToolTips = false;
            this.dgvDataGrp.ShowEditingIcon = false;
            this.dgvDataGrp.ShowRowErrors = false;
            this.dgvDataGrp.Size = new System.Drawing.Size(796, 336);
            this.dgvDataGrp.TabIndex = 13;
            this.dgvDataGrp.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgvDataGrp_ColumnWidthChanged);
            this.dgvDataGrp.SelectionChanged += new System.EventHandler(this.dgvDataGrp_SelectionChanged);
            // 
            // cmbDepsGrp
            // 
            this.cmbDepsGrp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepsGrp.FormattingEnabled = true;
            this.cmbDepsGrp.Location = new System.Drawing.Point(56, 6);
            this.cmbDepsGrp.Name = "cmbDepsGrp";
            this.cmbDepsGrp.Size = new System.Drawing.Size(169, 21);
            this.cmbDepsGrp.TabIndex = 12;
            this.cmbDepsGrp.SelectionChangeCommitted += new System.EventHandler(this.cmbDepsGrp_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Отдел:";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.cmbInv);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.cmbTU);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.chbUserPrcTovar);
            this.tabPage3.Controls.Add(this.tbNameTovar);
            this.tabPage3.Controls.Add(this.tbEan);
            this.tabPage3.Controls.Add(this.button4);
            this.tabPage3.Controls.Add(this.btAddGood);
            this.tabPage3.Controls.Add(this.btDeleteTovar);
            this.tabPage3.Controls.Add(this.dgvDataTovar);
            this.tabPage3.Controls.Add(this.cmbDepsTovar);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(810, 445);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Товар";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // cmbInv
            // 
            this.cmbInv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInv.FormattingEnabled = true;
            this.cmbInv.Location = new System.Drawing.Point(593, 8);
            this.cmbInv.Name = "cmbInv";
            this.cmbInv.Size = new System.Drawing.Size(169, 21);
            this.cmbInv.TabIndex = 28;
            this.cmbInv.SelectionChangeCommitted += new System.EventHandler(this.cmbInv_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(520, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Инв. группа:";
            // 
            // cmbTU
            // 
            this.cmbTU.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTU.FormattingEnabled = true;
            this.cmbTU.Location = new System.Drawing.Point(325, 8);
            this.cmbTU.Name = "cmbTU";
            this.cmbTU.Size = new System.Drawing.Size(169, 21);
            this.cmbTU.TabIndex = 29;
            this.cmbTU.SelectionChangeCommitted += new System.EventHandler(this.cmbTU_SelectionChangeCommitted);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(255, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Т\\У группа:";
            // 
            // chbUserPrcTovar
            // 
            this.chbUserPrcTovar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chbUserPrcTovar.AutoSize = true;
            this.chbUserPrcTovar.Location = new System.Drawing.Point(12, 414);
            this.chbUserPrcTovar.Name = "chbUserPrcTovar";
            this.chbUserPrcTovar.Size = new System.Drawing.Size(119, 17);
            this.chbUserPrcTovar.TabIndex = 25;
            this.chbUserPrcTovar.Text = "Назначен процент";
            this.chbUserPrcTovar.UseVisualStyleBackColor = true;
            this.chbUserPrcTovar.CheckedChanged += new System.EventHandler(this.chbUserPrcTovar_CheckedChanged);
            // 
            // tbNameTovar
            // 
            this.tbNameTovar.Location = new System.Drawing.Point(201, 37);
            this.tbNameTovar.MaxLength = 150;
            this.tbNameTovar.Name = "tbNameTovar";
            this.tbNameTovar.Size = new System.Drawing.Size(187, 20);
            this.tbNameTovar.TabIndex = 24;
            this.tbNameTovar.TextChanged += new System.EventHandler(this.tbEan_TextChanged);
            // 
            // tbEan
            // 
            this.tbEan.Location = new System.Drawing.Point(8, 37);
            this.tbEan.MaxLength = 13;
            this.tbEan.Name = "tbEan";
            this.tbEan.Size = new System.Drawing.Size(187, 20);
            this.tbEan.TabIndex = 24;
            this.tbEan.TextChanged += new System.EventHandler(this.tbEan_TextChanged);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.BackColor = System.Drawing.Color.White;
            this.button4.Image = global::OnlineStore.Properties.Resources.pngExit;
            this.button4.Location = new System.Drawing.Point(770, 405);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(32, 32);
            this.button4.TabIndex = 21;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btAddGood
            // 
            this.btAddGood.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btAddGood.BackColor = System.Drawing.Color.Transparent;
            this.btAddGood.Image = global::OnlineStore.Properties.Resources.compfile_1551;
            this.btAddGood.Location = new System.Drawing.Point(659, 405);
            this.btAddGood.Name = "btAddGood";
            this.btAddGood.Size = new System.Drawing.Size(32, 32);
            this.btAddGood.TabIndex = 22;
            this.btAddGood.UseVisualStyleBackColor = false;
            this.btAddGood.Click += new System.EventHandler(this.btAddGood_Click);
            // 
            // btDeleteTovar
            // 
            this.btDeleteTovar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btDeleteTovar.BackColor = System.Drawing.Color.Transparent;
            this.btDeleteTovar.Image = global::OnlineStore.Properties.Resources.editdelete_3805;
            this.btDeleteTovar.Location = new System.Drawing.Point(697, 405);
            this.btDeleteTovar.Name = "btDeleteTovar";
            this.btDeleteTovar.Size = new System.Drawing.Size(32, 32);
            this.btDeleteTovar.TabIndex = 23;
            this.btDeleteTovar.UseVisualStyleBackColor = false;
            this.btDeleteTovar.Click += new System.EventHandler(this.btDeleteTovar_Click);
            // 
            // dgvDataTovar
            // 
            this.dgvDataTovar.AllowUserToAddRows = false;
            this.dgvDataTovar.AllowUserToDeleteRows = false;
            this.dgvDataTovar.AllowUserToResizeRows = false;
            this.dgvDataTovar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDataTovar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDataTovar.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDataTovar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvDataTovar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataTovar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cEan,
            this.cNameTovar,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.dgvDataTovar.Location = new System.Drawing.Point(8, 63);
            this.dgvDataTovar.MultiSelect = false;
            this.dgvDataTovar.Name = "dgvDataTovar";
            this.dgvDataTovar.ReadOnly = true;
            this.dgvDataTovar.RowHeadersVisible = false;
            this.dgvDataTovar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDataTovar.ShowCellErrors = false;
            this.dgvDataTovar.ShowCellToolTips = false;
            this.dgvDataTovar.ShowEditingIcon = false;
            this.dgvDataTovar.ShowRowErrors = false;
            this.dgvDataTovar.Size = new System.Drawing.Size(796, 336);
            this.dgvDataTovar.TabIndex = 20;
            this.dgvDataTovar.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgvDataTovar_ColumnWidthChanged);
            this.dgvDataTovar.SelectionChanged += new System.EventHandler(this.dgvDataTovar_SelectionChanged);
            // 
            // cmbDepsTovar
            // 
            this.cmbDepsTovar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepsTovar.FormattingEnabled = true;
            this.cmbDepsTovar.Location = new System.Drawing.Point(56, 8);
            this.cmbDepsTovar.Name = "cmbDepsTovar";
            this.cmbDepsTovar.Size = new System.Drawing.Size(169, 21);
            this.cmbDepsTovar.TabIndex = 19;
            this.cmbDepsTovar.SelectionChangeCommitted += new System.EventHandler(this.cmbDepsTovar_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Отдел:";
            // 
            // cNameGrp
            // 
            this.cNameGrp.DataPropertyName = "cName";
            this.cNameGrp.FillWeight = 152.2843F;
            this.cNameGrp.HeaderText = "Инвентаризационная группа";
            this.cNameGrp.Name = "cNameGrp";
            this.cNameGrp.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "MarkUpPercent";
            this.dataGridViewTextBoxColumn2.FillWeight = 73.85786F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Процент наценки";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "salePercent";
            this.dataGridViewTextBoxColumn3.FillWeight = 73.85786F;
            this.dataGridViewTextBoxColumn3.HeaderText = "Процент распродажи";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // cEan
            // 
            this.cEan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cEan.DataPropertyName = "ean";
            this.cEan.HeaderText = "EAN";
            this.cEan.MinimumWidth = 110;
            this.cEan.Name = "cEan";
            this.cEan.ReadOnly = true;
            this.cEan.Width = 110;
            // 
            // cNameTovar
            // 
            this.cNameTovar.DataPropertyName = "cName";
            this.cNameTovar.FillWeight = 152.2843F;
            this.cNameTovar.HeaderText = "Наименование товара";
            this.cNameTovar.Name = "cNameTovar";
            this.cNameTovar.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "MarkUpPercent";
            this.dataGridViewTextBoxColumn4.FillWeight = 73.85786F;
            this.dataGridViewTextBoxColumn4.HeaderText = "Процент наценки";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "salePercent";
            this.dataGridViewTextBoxColumn5.FillWeight = 73.85786F;
            this.dataGridViewTextBoxColumn5.HeaderText = "Процент распродажи";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // frmPercents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 471);
            this.ControlBox = false;
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmPercents";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройка процентов";
            this.Load += new System.EventHandler(this.frmPercents_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPercents)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataGrp)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataTovar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDep;
        private System.Windows.Forms.DataGridViewTextBoxColumn cMargin;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSale;
        private System.Windows.Forms.CheckBox chckUseSale;
        private System.Windows.Forms.DataGridView dgvPercents;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ComboBox cmbDepsGrp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvDataGrp;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btAddGrp;
        private System.Windows.Forms.Button btDelGrp;
        private System.Windows.Forms.TextBox tbNameGrp;
        private System.Windows.Forms.CheckBox chbUsedPrc;
        private System.Windows.Forms.CheckBox chbUserPrcTovar;
        private System.Windows.Forms.TextBox tbEan;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btAddGood;
        private System.Windows.Forms.Button btDeleteTovar;
        private System.Windows.Forms.DataGridView dgvDataTovar;
        private System.Windows.Forms.ComboBox cmbDepsTovar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbNameTovar;
        private System.Windows.Forms.ComboBox cmbInv;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTU;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNameGrp;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn cEan;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNameTovar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
    }
}