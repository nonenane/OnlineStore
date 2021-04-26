namespace OnlineStore.dictonatyTovar
{
    partial class frmEditAttribute
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
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.cbDeps = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvGroups = new System.Windows.Forms.DataGridView();
            this.cName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tbQuantitySuffix = new System.Windows.Forms.TextBox();
            this.tbPriceSuffix = new System.Windows.Forms.TextBox();
            this.tbDefault = new System.Windows.Forms.TextBox();
            this.tbStep = new System.Windows.Forms.TextBox();
            this.tbMax = new System.Windows.Forms.TextBox();
            this.tbMin = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lMaxOrder = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbGroup = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroups)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAccept
            // 
            this.btnAccept.Image = global::OnlineStore.Properties.Resources.filesave_2175;
            this.btnAccept.Location = new System.Drawing.Point(583, 273);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(32, 32);
            this.btnAccept.TabIndex = 1;
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnExit
            // 
            this.btnExit.Image = global::OnlineStore.Properties.Resources.exit_8633;
            this.btnExit.Location = new System.Drawing.Point(621, 273);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(32, 32);
            this.btnExit.TabIndex = 0;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // cbDeps
            // 
            this.cbDeps.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDeps.FormattingEnabled = true;
            this.cbDeps.Location = new System.Drawing.Point(55, 12);
            this.cbDeps.Name = "cbDeps";
            this.cbDeps.Size = new System.Drawing.Size(266, 21);
            this.cbDeps.TabIndex = 2;
            this.cbDeps.SelectionChangeCommitted += new System.EventHandler(this.cbDeps_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Отдел";
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
            this.dgvGroups.Location = new System.Drawing.Point(15, 70);
            this.dgvGroups.Name = "dgvGroups";
            this.dgvGroups.ReadOnly = true;
            this.dgvGroups.RowHeadersVisible = false;
            this.dgvGroups.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGroups.Size = new System.Drawing.Size(306, 198);
            this.dgvGroups.TabIndex = 60;
            this.dgvGroups.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGroups_CellContentClick);
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
            this.cSelect.DataPropertyName = "selectedAtt";
            this.cSelect.FillWeight = 27.41116F;
            this.cSelect.HeaderText = "V";
            this.cSelect.Name = "cSelect";
            this.cSelect.ReadOnly = true;
            this.cSelect.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // tbQuantitySuffix
            // 
            this.tbQuantitySuffix.Location = new System.Drawing.Point(539, 189);
            this.tbQuantitySuffix.MaxLength = 500;
            this.tbQuantitySuffix.Multiline = true;
            this.tbQuantitySuffix.Name = "tbQuantitySuffix";
            this.tbQuantitySuffix.Size = new System.Drawing.Size(114, 59);
            this.tbQuantitySuffix.TabIndex = 77;
            this.tbQuantitySuffix.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbPriceSuffix
            // 
            this.tbPriceSuffix.Location = new System.Drawing.Point(539, 125);
            this.tbPriceSuffix.MaxLength = 500;
            this.tbPriceSuffix.Multiline = true;
            this.tbPriceSuffix.Name = "tbPriceSuffix";
            this.tbPriceSuffix.Size = new System.Drawing.Size(114, 55);
            this.tbPriceSuffix.TabIndex = 76;
            this.tbPriceSuffix.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbDefault
            // 
            this.tbDefault.Location = new System.Drawing.Point(539, 99);
            this.tbDefault.Name = "tbDefault";
            this.tbDefault.Size = new System.Drawing.Size(114, 20);
            this.tbDefault.TabIndex = 75;
            this.tbDefault.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbDecimal_KeyPress);
            this.tbDefault.Validating += new System.ComponentModel.CancelEventHandler(this.tbDecimal_Validating);
            // 
            // tbStep
            // 
            this.tbStep.Location = new System.Drawing.Point(539, 67);
            this.tbStep.Name = "tbStep";
            this.tbStep.Size = new System.Drawing.Size(114, 20);
            this.tbStep.TabIndex = 74;
            this.tbStep.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbDecimal_KeyPress);
            this.tbStep.Validating += new System.ComponentModel.CancelEventHandler(this.tbDecimal_Validating);
            // 
            // tbMax
            // 
            this.tbMax.Location = new System.Drawing.Point(539, 38);
            this.tbMax.Name = "tbMax";
            this.tbMax.Size = new System.Drawing.Size(114, 20);
            this.tbMax.TabIndex = 73;
            this.tbMax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbDecimal_KeyPress);
            this.tbMax.Validating += new System.ComponentModel.CancelEventHandler(this.tbDecimal_Validating);
            // 
            // tbMin
            // 
            this.tbMin.Location = new System.Drawing.Point(539, 9);
            this.tbMin.Name = "tbMin";
            this.tbMin.Size = new System.Drawing.Size(114, 20);
            this.tbMin.TabIndex = 72;
            this.tbMin.TextChanged += new System.EventHandler(this.tbMin_TextChanged);
            this.tbMin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbDecimal_KeyPress);
            this.tbMin.Validating += new System.ComponentModel.CancelEventHandler(this.tbDecimal_Validating);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(354, 189);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(135, 13);
            this.label8.TabIndex = 71;
            this.label8.Text = "Суффикс к кол-ву товара";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(355, 136);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 13);
            this.label7.TabIndex = 70;
            this.label7.Text = "Суффикс к цене товара";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(354, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(153, 13);
            this.label6.TabIndex = 69;
            this.label6.Text = "Кол-во товара по умолчанию";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(354, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 13);
            this.label5.TabIndex = 68;
            this.label5.Text = "Шаг кол-ва заказа";
            // 
            // lMaxOrder
            // 
            this.lMaxOrder.AutoSize = true;
            this.lMaxOrder.Location = new System.Drawing.Point(354, 40);
            this.lMaxOrder.Name = "lMaxOrder";
            this.lMaxOrder.Size = new System.Drawing.Size(162, 13);
            this.lMaxOrder.TabIndex = 67;
            this.lMaxOrder.Text = "Максимальное  кол-во заказа";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(354, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(153, 13);
            this.label4.TabIndex = 66;
            this.label4.Text = "Минимальное кол-во заказа";
            // 
            // tbGroup
            // 
            this.tbGroup.Location = new System.Drawing.Point(88, 42);
            this.tbGroup.Name = "tbGroup";
            this.tbGroup.Size = new System.Drawing.Size(233, 20);
            this.tbGroup.TabIndex = 79;
            this.tbGroup.TextChanged += new System.EventHandler(this.tbGroup_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 78;
            this.label3.Text = "Инв. группа";
            // 
            // frmEditAttribute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 310);
            this.ControlBox = false;
            this.Controls.Add(this.tbGroup);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbQuantitySuffix);
            this.Controls.Add(this.tbPriceSuffix);
            this.Controls.Add(this.tbDefault);
            this.Controls.Add(this.tbStep);
            this.Controls.Add(this.tbMax);
            this.Controls.Add(this.tbMin);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lMaxOrder);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvGroups);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbDeps);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.btnExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmEditAttribute";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редактирование атрибутов";
            this.Load += new System.EventHandler(this.frmEditAttribute_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroups)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.ComboBox cbDeps;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvGroups;
        private System.Windows.Forms.TextBox tbQuantitySuffix;
        private System.Windows.Forms.TextBox tbPriceSuffix;
        private System.Windows.Forms.TextBox tbDefault;
        private System.Windows.Forms.TextBox tbStep;
        private System.Windows.Forms.TextBox tbMax;
        private System.Windows.Forms.TextBox tbMin;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lMaxOrder;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn cName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cSelect;
        private System.Windows.Forms.TextBox tbGroup;
        private System.Windows.Forms.Label label3;
    }
}