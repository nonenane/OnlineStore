namespace OnlineStore.dictonatyTovar
{
    partial class frmAddAllTovar
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
            this.btnExit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lMaxOrder = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpRealiz = new System.Windows.Forms.DateTimePicker();
            this.cbDeps = new System.Windows.Forms.ComboBox();
            this.dgvGroups = new System.Windows.Forms.DataGridView();
            this.cName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tbMin = new System.Windows.Forms.TextBox();
            this.tbMax = new System.Windows.Forms.TextBox();
            this.tbStep = new System.Windows.Forms.TextBox();
            this.tbDefault = new System.Windows.Forms.TextBox();
            this.tbPriceSuffix = new System.Windows.Forms.TextBox();
            this.tbQuantitySuffix = new System.Windows.Forms.TextBox();
            this.tbLastUpdate = new System.Windows.Forms.TextBox();
            this.tbGroup = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroups)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Image = global::OnlineStore.Properties.Resources.exit_8633;
            this.btnExit.Location = new System.Drawing.Point(598, 298);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(32, 32);
            this.btnExit.TabIndex = 46;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Image = global::OnlineStore.Properties.Resources.filesave_2175;
            this.btnAdd.Location = new System.Drawing.Point(560, 298);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(32, 32);
            this.btnAdd.TabIndex = 47;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 48;
            this.label1.Text = "Дата реализации";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 49;
            this.label2.Text = "Отдел";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 50;
            this.label3.Text = "Инв. группа";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(335, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(153, 13);
            this.label4.TabIndex = 51;
            this.label4.Text = "Минимальное кол-во заказа";
            // 
            // lMaxOrder
            // 
            this.lMaxOrder.AutoSize = true;
            this.lMaxOrder.Location = new System.Drawing.Point(335, 50);
            this.lMaxOrder.Name = "lMaxOrder";
            this.lMaxOrder.Size = new System.Drawing.Size(162, 13);
            this.lMaxOrder.TabIndex = 52;
            this.lMaxOrder.Text = "Максимальное  кол-во заказа";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(335, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 13);
            this.label5.TabIndex = 53;
            this.label5.Text = "Шаг кол-ва заказа";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(335, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(153, 13);
            this.label6.TabIndex = 54;
            this.label6.Text = "Кол-во товара по умолчанию";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(336, 146);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 13);
            this.label7.TabIndex = 55;
            this.label7.Text = "Суффикс к цене товара";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(335, 199);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(135, 13);
            this.label8.TabIndex = 56;
            this.label8.Text = "Суффикс к кол-ву товара";
            // 
            // dtpRealiz
            // 
            this.dtpRealiz.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpRealiz.Location = new System.Drawing.Point(115, 16);
            this.dtpRealiz.Name = "dtpRealiz";
            this.dtpRealiz.Size = new System.Drawing.Size(82, 20);
            this.dtpRealiz.TabIndex = 57;
            // 
            // cbDeps
            // 
            this.cbDeps.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDeps.FormattingEnabled = true;
            this.cbDeps.Location = new System.Drawing.Point(115, 47);
            this.cbDeps.Name = "cbDeps";
            this.cbDeps.Size = new System.Drawing.Size(193, 21);
            this.cbDeps.TabIndex = 58;
            this.cbDeps.SelectionChangeCommitted += new System.EventHandler(this.cbDeps_SelectionChangeCommitted);
            // 
            // dgvGroups
            // 
            this.dgvGroups.AllowUserToAddRows = false;
            this.dgvGroups.AllowUserToDeleteRows = false;
            this.dgvGroups.AllowUserToResizeRows = false;
            this.dgvGroups.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGroups.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGroups.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cName,
            this.cSelect});
            this.dgvGroups.Location = new System.Drawing.Point(13, 97);
            this.dgvGroups.Name = "dgvGroups";
            this.dgvGroups.ReadOnly = true;
            this.dgvGroups.RowHeadersVisible = false;
            this.dgvGroups.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGroups.Size = new System.Drawing.Size(306, 198);
            this.dgvGroups.TabIndex = 59;
            this.dgvGroups.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGroups_CellContentClick);
            this.dgvGroups.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGroups_CellDoubleClick);
            this.dgvGroups.ColumnHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvGroups_ColumnHeaderMouseDoubleClick);
            this.dgvGroups.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvGroups_RowPostPaint);
            this.dgvGroups.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvGroups_RowPrePaint);
            // 
            // cName
            // 
            this.cName.DataPropertyName = "cname";
            this.cName.FillWeight = 172.5888F;
            this.cName.HeaderText = "Наименование группы";
            this.cName.Name = "cName";
            this.cName.ReadOnly = true;
            // 
            // cSelect
            // 
            this.cSelect.DataPropertyName = "selected";
            this.cSelect.FillWeight = 27.41116F;
            this.cSelect.HeaderText = "V";
            this.cSelect.Name = "cSelect";
            this.cSelect.ReadOnly = true;
            this.cSelect.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // tbMin
            // 
            this.tbMin.Location = new System.Drawing.Point(520, 19);
            this.tbMin.Name = "tbMin";
            this.tbMin.Size = new System.Drawing.Size(114, 20);
            this.tbMin.TabIndex = 60;
            this.tbMin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbDecimal_KeyPress);
            this.tbMin.Leave += new System.EventHandler(this.tbMin_Leave);
            this.tbMin.Validating += new System.ComponentModel.CancelEventHandler(this.tbDecimal_Validating);
            this.tbMin.Validated += new System.EventHandler(this.tbMin_Validated);
            // 
            // tbMax
            // 
            this.tbMax.Location = new System.Drawing.Point(520, 48);
            this.tbMax.Name = "tbMax";
            this.tbMax.Size = new System.Drawing.Size(114, 20);
            this.tbMax.TabIndex = 61;
            this.tbMax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbDecimal_KeyPress);
            this.tbMax.Validating += new System.ComponentModel.CancelEventHandler(this.tbDecimal_Validating);
            // 
            // tbStep
            // 
            this.tbStep.Location = new System.Drawing.Point(520, 77);
            this.tbStep.Name = "tbStep";
            this.tbStep.Size = new System.Drawing.Size(114, 20);
            this.tbStep.TabIndex = 62;
            this.tbStep.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbDecimal_KeyPress);
            this.tbStep.Validating += new System.ComponentModel.CancelEventHandler(this.tbDecimal_Validating);
            // 
            // tbDefault
            // 
            this.tbDefault.Location = new System.Drawing.Point(520, 109);
            this.tbDefault.Name = "tbDefault";
            this.tbDefault.Size = new System.Drawing.Size(114, 20);
            this.tbDefault.TabIndex = 63;
            this.tbDefault.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbDecimal_KeyPress);
            this.tbDefault.Validating += new System.ComponentModel.CancelEventHandler(this.tbDecimal_Validating);
            // 
            // tbPriceSuffix
            // 
            this.tbPriceSuffix.Location = new System.Drawing.Point(520, 135);
            this.tbPriceSuffix.MaxLength = 50;
            this.tbPriceSuffix.Multiline = true;
            this.tbPriceSuffix.Name = "tbPriceSuffix";
            this.tbPriceSuffix.Size = new System.Drawing.Size(114, 55);
            this.tbPriceSuffix.TabIndex = 64;
            this.tbPriceSuffix.Text = "за 1 кг";
            this.tbPriceSuffix.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbQuantitySuffix
            // 
            this.tbQuantitySuffix.Location = new System.Drawing.Point(520, 199);
            this.tbQuantitySuffix.MaxLength = 50;
            this.tbQuantitySuffix.Multiline = true;
            this.tbQuantitySuffix.Name = "tbQuantitySuffix";
            this.tbQuantitySuffix.Size = new System.Drawing.Size(114, 59);
            this.tbQuantitySuffix.TabIndex = 65;
            this.tbQuantitySuffix.Text = "итоговый вес заказа может отличаться на +/- 100 гр.";
            this.tbQuantitySuffix.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbLastUpdate
            // 
            this.tbLastUpdate.Enabled = false;
            this.tbLastUpdate.Location = new System.Drawing.Point(13, 309);
            this.tbLastUpdate.Name = "tbLastUpdate";
            this.tbLastUpdate.ReadOnly = true;
            this.tbLastUpdate.Size = new System.Drawing.Size(510, 20);
            this.tbLastUpdate.TabIndex = 66;
            // 
            // tbGroup
            // 
            this.tbGroup.Location = new System.Drawing.Point(115, 74);
            this.tbGroup.Name = "tbGroup";
            this.tbGroup.Size = new System.Drawing.Size(204, 20);
            this.tbGroup.TabIndex = 67;
            this.tbGroup.TextChanged += new System.EventHandler(this.tbGroup_TextChanged);
            // 
            // frmAddAllTovar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 342);
            this.ControlBox = false;
            this.Controls.Add(this.tbGroup);
            this.Controls.Add(this.tbLastUpdate);
            this.Controls.Add(this.tbQuantitySuffix);
            this.Controls.Add(this.tbPriceSuffix);
            this.Controls.Add(this.tbDefault);
            this.Controls.Add(this.tbStep);
            this.Controls.Add(this.tbMax);
            this.Controls.Add(this.tbMin);
            this.Controls.Add(this.dgvGroups);
            this.Controls.Add(this.cbDeps);
            this.Controls.Add(this.dtpRealiz);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lMaxOrder);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmAddAllTovar";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавить новые товары";
            this.Load += new System.EventHandler(this.frmAddAllTovar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroups)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lMaxOrder;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpRealiz;
        private System.Windows.Forms.ComboBox cbDeps;
        private System.Windows.Forms.DataGridView dgvGroups;
        private System.Windows.Forms.TextBox tbMin;
        private System.Windows.Forms.TextBox tbMax;
        private System.Windows.Forms.TextBox tbStep;
        private System.Windows.Forms.TextBox tbDefault;
        private System.Windows.Forms.TextBox tbPriceSuffix;
        private System.Windows.Forms.TextBox tbQuantitySuffix;
        private System.Windows.Forms.TextBox tbLastUpdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn cName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cSelect;
        private System.Windows.Forms.TextBox tbGroup;
    }
}