namespace OnlineStore.dictonaryCategory
{
    partial class frmMultyGoodCategory
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle33 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle34 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle35 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle36 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvGoods = new System.Windows.Forms.DataGridView();
            this.dgvCategoryGood = new System.Windows.Forms.DataGridView();
            this.btAddAll = new System.Windows.Forms.Button();
            this.btAdd = new System.Windows.Forms.Button();
            this.btRemote = new System.Windows.Forms.Button();
            this.btRemoteAll = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbGoodEan = new System.Windows.Forms.TextBox();
            this.tbGoodName = new System.Windows.Forms.TextBox();
            this.tbCatEan = new System.Windows.Forms.TextBox();
            this.tbCatName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbDeps = new System.Windows.Forms.ComboBox();
            this.cmbGrp1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbGrp2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbDepsCategory = new System.Windows.Forms.ComboBox();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cGoodEan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cGoodName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCatEan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCatName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGoods)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategoryGood)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvGoods
            // 
            this.dgvGoods.AllowUserToAddRows = false;
            this.dgvGoods.AllowUserToDeleteRows = false;
            this.dgvGoods.AllowUserToResizeRows = false;
            this.dgvGoods.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvGoods.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle33.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle33.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle33.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle33.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle33.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle33.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle33.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGoods.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle33;
            this.dgvGoods.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGoods.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cGoodEan,
            this.cGoodName});
            dataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle34.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle34.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle34.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle34.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle34.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle34.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvGoods.DefaultCellStyle = dataGridViewCellStyle34;
            this.dgvGoods.Location = new System.Drawing.Point(6, 140);
            this.dgvGoods.MultiSelect = false;
            this.dgvGoods.Name = "dgvGoods";
            this.dgvGoods.ReadOnly = true;
            this.dgvGoods.RowHeadersVisible = false;
            this.dgvGoods.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGoods.Size = new System.Drawing.Size(387, 404);
            this.dgvGoods.TabIndex = 35;
            this.dgvGoods.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.DgvUsers_ColumnWidthChanged);
            // 
            // dgvCategoryGood
            // 
            this.dgvCategoryGood.AllowUserToAddRows = false;
            this.dgvCategoryGood.AllowUserToDeleteRows = false;
            this.dgvCategoryGood.AllowUserToResizeRows = false;
            this.dgvCategoryGood.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCategoryGood.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle35.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle35.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle35.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle35.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle35.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle35.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCategoryGood.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle35;
            this.dgvCategoryGood.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategoryGood.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cCatEan,
            this.cCatName});
            dataGridViewCellStyle36.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle36.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle36.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle36.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle36.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle36.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle36.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCategoryGood.DefaultCellStyle = dataGridViewCellStyle36;
            this.dgvCategoryGood.Location = new System.Drawing.Point(6, 140);
            this.dgvCategoryGood.MultiSelect = false;
            this.dgvCategoryGood.Name = "dgvCategoryGood";
            this.dgvCategoryGood.ReadOnly = true;
            this.dgvCategoryGood.RowHeadersVisible = false;
            this.dgvCategoryGood.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCategoryGood.Size = new System.Drawing.Size(428, 404);
            this.dgvCategoryGood.TabIndex = 35;
            this.dgvCategoryGood.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.DgvCategoryGood_ColumnWidthChanged);
            // 
            // btAddAll
            // 
            this.btAddAll.Location = new System.Drawing.Point(427, 235);
            this.btAddAll.Name = "btAddAll";
            this.btAddAll.Size = new System.Drawing.Size(75, 23);
            this.btAddAll.TabIndex = 36;
            this.btAddAll.Text = ">>";
            this.btAddAll.UseVisualStyleBackColor = true;
            this.btAddAll.Click += new System.EventHandler(this.BtAddAll_Click);
            // 
            // btAdd
            // 
            this.btAdd.Location = new System.Drawing.Point(427, 282);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(75, 23);
            this.btAdd.TabIndex = 36;
            this.btAdd.Text = ">";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.BtAdd_Click);
            // 
            // btRemote
            // 
            this.btRemote.Location = new System.Drawing.Point(427, 386);
            this.btRemote.Name = "btRemote";
            this.btRemote.Size = new System.Drawing.Size(75, 23);
            this.btRemote.TabIndex = 36;
            this.btRemote.Text = "<";
            this.btRemote.UseVisualStyleBackColor = true;
            this.btRemote.Click += new System.EventHandler(this.BtRemote_Click);
            // 
            // btRemoteAll
            // 
            this.btRemoteAll.Location = new System.Drawing.Point(427, 431);
            this.btRemoteAll.Name = "btRemoteAll";
            this.btRemoteAll.Size = new System.Drawing.Size(75, 23);
            this.btRemoteAll.TabIndex = 36;
            this.btRemoteAll.Text = "<<";
            this.btRemoteAll.UseVisualStyleBackColor = true;
            this.btRemoteAll.Click += new System.EventHandler(this.BtRemoteAll_Click);
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.Image = global::OnlineStore.Properties.Resources.exit_8633;
            this.btClose.Location = new System.Drawing.Point(926, 577);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(32, 32);
            this.btClose.TabIndex = 37;
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.BtClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbGrp2);
            this.groupBox1.Controls.Add(this.cmbGrp1);
            this.groupBox1.Controls.Add(this.cbDeps);
            this.groupBox1.Controls.Add(this.tbGoodName);
            this.groupBox1.Controls.Add(this.tbGoodEan);
            this.groupBox1.Controls.Add(this.dgvGoods);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(399, 550);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Доступные товары";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbCatName);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.dgvCategoryGood);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.tbCatEan);
            this.groupBox2.Controls.Add(this.cmbCategory);
            this.groupBox2.Controls.Add(this.cmbDepsCategory);
            this.groupBox2.Location = new System.Drawing.Point(518, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(440, 550);
            this.groupBox2.TabIndex = 39;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Товары в категории";
            // 
            // tbGoodEan
            // 
            this.tbGoodEan.Location = new System.Drawing.Point(7, 114);
            this.tbGoodEan.MaxLength = 13;
            this.tbGoodEan.Name = "tbGoodEan";
            this.tbGoodEan.Size = new System.Drawing.Size(100, 20);
            this.tbGoodEan.TabIndex = 36;
            this.tbGoodEan.TextChanged += new System.EventHandler(this.TbGoodEan_TextChanged);
            // 
            // tbGoodName
            // 
            this.tbGoodName.Location = new System.Drawing.Point(113, 114);
            this.tbGoodName.Name = "tbGoodName";
            this.tbGoodName.Size = new System.Drawing.Size(100, 20);
            this.tbGoodName.TabIndex = 36;
            this.tbGoodName.TextChanged += new System.EventHandler(this.TbGoodEan_TextChanged);
            // 
            // tbCatEan
            // 
            this.tbCatEan.Location = new System.Drawing.Point(6, 114);
            this.tbCatEan.MaxLength = 13;
            this.tbCatEan.Name = "tbCatEan";
            this.tbCatEan.Size = new System.Drawing.Size(100, 20);
            this.tbCatEan.TabIndex = 36;
            this.tbCatEan.TextChanged += new System.EventHandler(this.TbCatEan_TextChanged);
            // 
            // tbCatName
            // 
            this.tbCatName.Location = new System.Drawing.Point(112, 114);
            this.tbCatName.Name = "tbCatName";
            this.tbCatName.Size = new System.Drawing.Size(100, 20);
            this.tbCatName.TabIndex = 36;
            this.tbCatName.TextChanged += new System.EventHandler(this.TbCatEan_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 38;
            this.label2.Text = "Отдел";
            // 
            // cbDeps
            // 
            this.cbDeps.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDeps.FormattingEnabled = true;
            this.cbDeps.Location = new System.Drawing.Point(86, 22);
            this.cbDeps.Name = "cbDeps";
            this.cbDeps.Size = new System.Drawing.Size(307, 21);
            this.cbDeps.TabIndex = 37;
            this.cbDeps.SelectionChangeCommitted += new System.EventHandler(this.CbDeps_SelectionChangeCommitted);
            // 
            // cmbGrp1
            // 
            this.cmbGrp1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGrp1.FormattingEnabled = true;
            this.cmbGrp1.Location = new System.Drawing.Point(86, 49);
            this.cmbGrp1.Name = "cmbGrp1";
            this.cmbGrp1.Size = new System.Drawing.Size(307, 21);
            this.cmbGrp1.TabIndex = 37;
            this.cmbGrp1.SelectionChangeCommitted += new System.EventHandler(this.CmbGrp1_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 38;
            this.label1.Text = "Т/У группа";
            // 
            // cmbGrp2
            // 
            this.cmbGrp2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGrp2.FormattingEnabled = true;
            this.cmbGrp2.Location = new System.Drawing.Point(86, 76);
            this.cmbGrp2.Name = "cmbGrp2";
            this.cmbGrp2.Size = new System.Drawing.Size(307, 21);
            this.cmbGrp2.TabIndex = 37;
            this.cmbGrp2.SelectionChangeCommitted += new System.EventHandler(this.CmbGrp2_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 38;
            this.label3.Text = "Инв. группа";
            // 
            // cmbDepsCategory
            // 
            this.cmbDepsCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepsCategory.FormattingEnabled = true;
            this.cmbDepsCategory.Location = new System.Drawing.Point(81, 25);
            this.cmbDepsCategory.Name = "cmbDepsCategory";
            this.cmbDepsCategory.Size = new System.Drawing.Size(353, 21);
            this.cmbDepsCategory.TabIndex = 37;
            this.cmbDepsCategory.SelectionChangeCommitted += new System.EventHandler(this.CmbDepsCategory_SelectionChangeCommitted);
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(81, 52);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(353, 21);
            this.cmbCategory.TabIndex = 37;
            this.cmbCategory.SelectionChangeCommitted += new System.EventHandler(this.CmbCategory_SelectionChangeCommitted);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 38;
            this.label4.Text = "Отдел";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 38;
            this.label5.Text = "Категория";
            // 
            // cGoodEan
            // 
            this.cGoodEan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cGoodEan.DataPropertyName = "ean";
            this.cGoodEan.HeaderText = "EAN";
            this.cGoodEan.MinimumWidth = 100;
            this.cGoodEan.Name = "cGoodEan";
            this.cGoodEan.ReadOnly = true;
            // 
            // cGoodName
            // 
            this.cGoodName.DataPropertyName = "cname";
            this.cGoodName.HeaderText = "Наименование";
            this.cGoodName.Name = "cGoodName";
            this.cGoodName.ReadOnly = true;
            // 
            // cCatEan
            // 
            this.cCatEan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cCatEan.DataPropertyName = "ean";
            this.cCatEan.HeaderText = "EAN";
            this.cCatEan.MinimumWidth = 100;
            this.cCatEan.Name = "cCatEan";
            this.cCatEan.ReadOnly = true;
            // 
            // cCatName
            // 
            this.cCatName.DataPropertyName = "cname";
            this.cCatName.HeaderText = "Наименование";
            this.cCatName.Name = "cCatName";
            this.cCatName.ReadOnly = true;
            // 
            // frmMultyGoodCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 621);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.btRemoteAll);
            this.Controls.Add(this.btRemote);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.btAddAll);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMultyGoodCategory";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Массовое назначение категорий товару";
            this.Load += new System.EventHandler(this.FrmMultyGoodCategory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGoods)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategoryGood)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvGoods;
        private System.Windows.Forms.DataGridView dgvCategoryGood;
        private System.Windows.Forms.Button btAddAll;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.Button btRemote;
        private System.Windows.Forms.Button btRemoteAll;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbGoodName;
        private System.Windows.Forms.TextBox tbGoodEan;
        private System.Windows.Forms.TextBox tbCatName;
        private System.Windows.Forms.TextBox tbCatEan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbGrp2;
        private System.Windows.Forms.ComboBox cmbGrp1;
        private System.Windows.Forms.ComboBox cbDeps;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.ComboBox cmbDepsCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn cGoodEan;
        private System.Windows.Forms.DataGridViewTextBoxColumn cGoodName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCatEan;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCatName;
    }
}