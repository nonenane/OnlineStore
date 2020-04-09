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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.справочникToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.категорийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.формированиеCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выгрузитьВсеДоступныеТоварыВФайлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выгрузитьВыбранныеТоварыВФайлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отображаемыеНаФормеТоварыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выгрузитьИзмененныеТоварыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.btUpdate = new System.Windows.Forms.Button();
            this.btAdd = new System.Windows.Forms.Button();
            this.btEdit = new System.Windows.Forms.Button();
            this.btPrint = new System.Windows.Forms.Button();
            this.btDel = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникToolStripMenuItem,
            this.выходToolStripMenuItem,
            this.формированиеCSVToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1243, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // справочникToolStripMenuItem
            // 
            this.справочникToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.категорийToolStripMenuItem});
            this.справочникToolStripMenuItem.Name = "справочникToolStripMenuItem";
            this.справочникToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.справочникToolStripMenuItem.Text = "Справочник";
            // 
            // категорийToolStripMenuItem
            // 
            this.категорийToolStripMenuItem.Name = "категорийToolStripMenuItem";
            this.категорийToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.категорийToolStripMenuItem.Text = "Категорий";
            this.категорийToolStripMenuItem.Click += new System.EventHandler(this.категорийToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // формированиеCSVToolStripMenuItem
            // 
            this.формированиеCSVToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выгрузитьВсеДоступныеТоварыВФайлToolStripMenuItem,
            this.выгрузитьВыбранныеТоварыВФайлToolStripMenuItem,
            this.отображаемыеНаФормеТоварыToolStripMenuItem,
            this.выгрузитьИзмененныеТоварыToolStripMenuItem});
            this.формированиеCSVToolStripMenuItem.Name = "формированиеCSVToolStripMenuItem";
            this.формированиеCSVToolStripMenuItem.Size = new System.Drawing.Size(128, 20);
            this.формированиеCSVToolStripMenuItem.Text = "Формирование CSV";
            // 
            // выгрузитьВсеДоступныеТоварыВФайлToolStripMenuItem
            // 
            this.выгрузитьВсеДоступныеТоварыВФайлToolStripMenuItem.Name = "выгрузитьВсеДоступныеТоварыВФайлToolStripMenuItem";
            this.выгрузитьВсеДоступныеТоварыВФайлToolStripMenuItem.Size = new System.Drawing.Size(298, 22);
            this.выгрузитьВсеДоступныеТоварыВФайлToolStripMenuItem.Text = "Выгрузить все доступные товары в файл";
            // 
            // выгрузитьВыбранныеТоварыВФайлToolStripMenuItem
            // 
            this.выгрузитьВыбранныеТоварыВФайлToolStripMenuItem.Name = "выгрузитьВыбранныеТоварыВФайлToolStripMenuItem";
            this.выгрузитьВыбранныеТоварыВФайлToolStripMenuItem.Size = new System.Drawing.Size(298, 22);
            this.выгрузитьВыбранныеТоварыВФайлToolStripMenuItem.Text = "Выгрузить выбранные товары в файл ";
            // 
            // отображаемыеНаФормеТоварыToolStripMenuItem
            // 
            this.отображаемыеНаФормеТоварыToolStripMenuItem.Name = "отображаемыеНаФормеТоварыToolStripMenuItem";
            this.отображаемыеНаФормеТоварыToolStripMenuItem.Size = new System.Drawing.Size(298, 22);
            this.отображаемыеНаФормеТоварыToolStripMenuItem.Text = "Отображаемые на форме товары";
            this.отображаемыеНаФормеТоварыToolStripMenuItem.Click += new System.EventHandler(this.отображаемыеНаФормеТоварыToolStripMenuItem_Click);
            // 
            // выгрузитьИзмененныеТоварыToolStripMenuItem
            // 
            this.выгрузитьИзмененныеТоварыToolStripMenuItem.Name = "выгрузитьИзмененныеТоварыToolStripMenuItem";
            this.выгрузитьИзмененныеТоварыToolStripMenuItem.Size = new System.Drawing.Size(298, 22);
            this.выгрузитьИзмененныеТоварыToolStripMenuItem.Text = "Выгрузить измененные товары";
            this.выгрузитьИзмененныеТоварыToolStripMenuItem.Click += new System.EventHandler(this.выгрузитьИзмененныеТоварыToolStripMenuItem_Click);
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
            this.dgvData.Size = new System.Drawing.Size(1218, 403);
            this.dgvData.TabIndex = 27;
            this.dgvData.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvData_RowPostPaint);
            this.dgvData.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvData_RowPrePaint);
            this.dgvData.SelectionChanged += new System.EventHandler(this.dgvData_SelectionChanged);
            this.dgvData.Paint += new System.Windows.Forms.PaintEventHandler(this.dgvData_Paint);
            // 
            // cId_tovar
            // 
            this.cId_tovar.DataPropertyName = "id_Tovar";
            this.cId_tovar.HeaderText = "Артикул товара ";
            this.cId_tovar.Name = "cId_tovar";
            this.cId_tovar.ReadOnly = true;
            // 
            // cEan
            // 
            this.cEan.DataPropertyName = "ean";
            this.cEan.HeaderText = "EAN";
            this.cEan.Name = "cEan";
            this.cEan.ReadOnly = true;
            // 
            // cName
            // 
            this.cName.DataPropertyName = "ShortName";
            this.cName.HeaderText = "Наименование товара";
            this.cName.Name = "cName";
            this.cName.ReadOnly = true;
            // 
            // cNameCategory
            // 
            this.cNameCategory.DataPropertyName = "nameCategory";
            this.cNameCategory.HeaderText = "Категория товара";
            this.cNameCategory.Name = "cNameCategory";
            this.cNameCategory.ReadOnly = true;
            // 
            // cCountOnline
            // 
            this.cCountOnline.DataPropertyName = "countOnlineSell";
            this.cCountOnline.HeaderText = "Он-лайн продажи товара";
            this.cCountOnline.Name = "cCountOnline";
            this.cCountOnline.ReadOnly = true;
            // 
            // сMoveNow
            // 
            this.сMoveNow.DataPropertyName = "moveNow";
            this.сMoveNow.HeaderText = "Движение товара за сегодня";
            this.сMoveNow.Name = "сMoveNow";
            this.сMoveNow.ReadOnly = true;
            // 
            // cOstNow
            // 
            this.cOstNow.DataPropertyName = "ostNow";
            this.cOstNow.HeaderText = "Остаток товара в магазине на К21";
            this.cOstNow.Name = "cOstNow";
            this.cOstNow.ReadOnly = true;
            // 
            // cRcena
            // 
            this.cRcena.DataPropertyName = "rcena";
            this.cRcena.HeaderText = "Цена продажи";
            this.cRcena.Name = "cRcena";
            this.cRcena.ReadOnly = true;
            // 
            // cRcenaOnline
            // 
            this.cRcenaOnline.DataPropertyName = "rcenaOnline";
            this.cRcenaOnline.HeaderText = "Цена продажи он-лайн";
            this.cRcenaOnline.Name = "cRcenaOnline";
            this.cRcenaOnline.ReadOnly = true;
            // 
            // cRcenaOnlineAction
            // 
            this.cRcenaOnlineAction.DataPropertyName = "rcenaPromo";
            this.cRcenaOnlineAction.HeaderText = "Цена распродажи он-лайн";
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
            this.panel1.Location = new System.Drawing.Point(10, 528);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(19, 19);
            this.panel1.TabIndex = 29;
            // 
            // chbUnable
            // 
            this.chbUnable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chbUnable.AutoSize = true;
            this.chbUnable.Location = new System.Drawing.Point(35, 530);
            this.chbUnable.Name = "chbUnable";
            this.chbUnable.Size = new System.Drawing.Size(107, 17);
            this.chbUnable.TabIndex = 28;
            this.chbUnable.Text = "недействующие";
            this.chbUnable.UseVisualStyleBackColor = true;
            this.chbUnable.CheckedChanged += new System.EventHandler(this.chbUnable_CheckedChanged);
            // 
            // btUpdate
            // 
            this.btUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btUpdate.Image = global::OnlineStore.Properties.Resources.reload_8055;
            this.btUpdate.Location = new System.Drawing.Point(1199, 39);
            this.btUpdate.Name = "btUpdate";
            this.btUpdate.Size = new System.Drawing.Size(32, 32);
            this.btUpdate.TabIndex = 34;
            this.btUpdate.UseVisualStyleBackColor = true;
            this.btUpdate.Click += new System.EventHandler(this.btUpdate_Click);
            // 
            // btAdd
            // 
            this.btAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btAdd.Image = global::OnlineStore.Properties.Resources.compfile_1551;
            this.btAdd.Location = new System.Drawing.Point(1123, 521);
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
            this.btEdit.Location = new System.Drawing.Point(1161, 521);
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
            this.btPrint.Location = new System.Drawing.Point(1060, 521);
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
            this.btDel.Location = new System.Drawing.Point(1199, 521);
            this.btDel.Name = "btDel";
            this.btDel.Size = new System.Drawing.Size(32, 32);
            this.btDel.TabIndex = 31;
            this.btDel.UseVisualStyleBackColor = true;
            this.btDel.Click += new System.EventHandler(this.btDel_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1243, 559);
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
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
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
        private System.Windows.Forms.ToolStripMenuItem формированиеCSVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выгрузитьВсеДоступныеТоварыВФайлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выгрузитьВыбранныеТоварыВФайлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отображаемыеНаФормеТоварыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выгрузитьИзмененныеТоварыToolStripMenuItem;
    }
}

