namespace OnlineStoreViewOrders
{
    partial class frmViewContentOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmViewContentOrder));
            this.dgvOrder = new System.Windows.Forms.DataGridView();
            this.Position = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EAN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameTovar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Netto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SummTovar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbEan = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lblSum = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chckDeleted = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnAddTovar = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.tbComment = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvOrder
            // 
            this.dgvOrder.AllowUserToAddRows = false;
            this.dgvOrder.AllowUserToDeleteRows = false;
            this.dgvOrder.AllowUserToResizeRows = false;
            this.dgvOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOrder.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrder.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOrder.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Position,
            this.cDep,
            this.EAN,
            this.NameTovar,
            this.Netto,
            this.Price,
            this.SummTovar});
            this.dgvOrder.Location = new System.Drawing.Point(12, 38);
            this.dgvOrder.MultiSelect = false;
            this.dgvOrder.Name = "dgvOrder";
            this.dgvOrder.RowHeadersVisible = false;
            this.dgvOrder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrder.ShowRowErrors = false;
            this.dgvOrder.Size = new System.Drawing.Size(754, 240);
            this.dgvOrder.TabIndex = 0;
            this.dgvOrder.CancelRowEdit += new System.Windows.Forms.QuestionEventHandler(this.dgvOrder_CancelRowEdit);
            this.dgvOrder.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrder_CellContentClick);
            this.dgvOrder.CellContextMenuStripNeeded += new System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventHandler(this.dgvOrder_CellContextMenuStripNeeded);
            this.dgvOrder.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrder_CellValidated);
            this.dgvOrder.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvOrder_CellValidating);
            this.dgvOrder.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgvOrder_ColumnWidthChanged);
            this.dgvOrder.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvOrder_DataError);
            this.dgvOrder.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvOrder_EditingControlShowing);
            this.dgvOrder.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvOrder_RowPostPaint);
            this.dgvOrder.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvOrder_RowPrePaint);
            this.dgvOrder.Validating += new System.ComponentModel.CancelEventHandler(this.dgvOrder_Validating);
            // 
            // Position
            // 
            this.Position.DataPropertyName = "Position";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Position.DefaultCellStyle = dataGridViewCellStyle2;
            this.Position.FillWeight = 25.03671F;
            this.Position.HeaderText = "№";
            this.Position.Name = "Position";
            this.Position.ReadOnly = true;
            // 
            // cDep
            // 
            this.cDep.DataPropertyName = "name";
            this.cDep.FillWeight = 97.78143F;
            this.cDep.HeaderText = "Отдел";
            this.cDep.Name = "cDep";
            this.cDep.ReadOnly = true;
            // 
            // EAN
            // 
            this.EAN.DataPropertyName = "ean";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.EAN.DefaultCellStyle = dataGridViewCellStyle3;
            this.EAN.FillWeight = 95.93908F;
            this.EAN.HeaderText = "Код";
            this.EAN.Name = "EAN";
            this.EAN.ReadOnly = true;
            // 
            // NameTovar
            // 
            this.NameTovar.DataPropertyName = "nameTovar";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.NameTovar.DefaultCellStyle = dataGridViewCellStyle4;
            this.NameTovar.FillWeight = 287.0169F;
            this.NameTovar.HeaderText = "Наименование";
            this.NameTovar.Name = "NameTovar";
            this.NameTovar.ReadOnly = true;
            // 
            // Netto
            // 
            this.Netto.DataPropertyName = "Netto";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Netto.DefaultCellStyle = dataGridViewCellStyle5;
            this.Netto.FillWeight = 63.05667F;
            this.Netto.HeaderText = "Количество";
            this.Netto.Name = "Netto";
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Price.DefaultCellStyle = dataGridViewCellStyle6;
            this.Price.FillWeight = 62.02179F;
            this.Price.HeaderText = "Цена";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            // 
            // SummTovar
            // 
            this.SummTovar.DataPropertyName = "sumTovar";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.SummTovar.DefaultCellStyle = dataGridViewCellStyle7;
            this.SummTovar.FillWeight = 69.14739F;
            this.SummTovar.HeaderText = "Сумма";
            this.SummTovar.Name = "SummTovar";
            this.SummTovar.ReadOnly = true;
            // 
            // tbEan
            // 
            this.tbEan.Location = new System.Drawing.Point(48, 12);
            this.tbEan.Name = "tbEan";
            this.tbEan.Size = new System.Drawing.Size(100, 20);
            this.tbEan.TabIndex = 2;
            this.tbEan.TextChanged += new System.EventHandler(this.tbEan_TextChanged);
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(154, 12);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(331, 20);
            this.tbName.TabIndex = 3;
            this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // lblSum
            // 
            this.lblSum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSum.AutoSize = true;
            this.lblSum.Location = new System.Drawing.Point(565, 15);
            this.lblSum.Name = "lblSum";
            this.lblSum.Size = new System.Drawing.Size(40, 13);
            this.lblSum.TabIndex = 4;
            this.lblSum.Text = "сумма";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.panel1.Location = new System.Drawing.Point(12, 291);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(16, 16);
            this.panel1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 294);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Цена отличается от базовой цены";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(536, 294);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Вес заказа";
            // 
            // chckDeleted
            // 
            this.chckDeleted.AutoSize = true;
            this.chckDeleted.Location = new System.Drawing.Point(37, 313);
            this.chckDeleted.Name = "chckDeleted";
            this.chckDeleted.Size = new System.Drawing.Size(124, 17);
            this.chckDeleted.TabIndex = 9;
            this.chckDeleted.Text = "Удаленные товары";
            this.chckDeleted.UseVisualStyleBackColor = true;
            this.chckDeleted.CheckedChanged += new System.EventHandler(this.chckDeleted_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.panel2.Location = new System.Drawing.Point(12, 313);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(16, 16);
            this.panel2.TabIndex = 6;
            // 
            // btnAddTovar
            // 
            this.btnAddTovar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddTovar.Image = global::OnlineStoreViewOrders.Properties.Resources.ic_add_circle_outline_128_28123;
            this.btnAddTovar.Location = new System.Drawing.Point(658, 284);
            this.btnAddTovar.Name = "btnAddTovar";
            this.btnAddTovar.Size = new System.Drawing.Size(32, 32);
            this.btnAddTovar.TabIndex = 10;
            this.btnAddTovar.UseVisualStyleBackColor = true;
            this.btnAddTovar.Click += new System.EventHandler(this.btnAddTovar_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Image = global::OnlineStoreViewOrders.Properties.Resources.pngGALOCHKA;
            this.btnSave.Location = new System.Drawing.Point(696, 284);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(32, 32);
            this.btnSave.TabIndex = 8;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.Location = new System.Drawing.Point(734, 284);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(32, 32);
            this.btnExit.TabIndex = 1;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // tbComment
            // 
            this.tbComment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbComment.Location = new System.Drawing.Point(221, 284);
            this.tbComment.Multiline = true;
            this.tbComment.Name = "tbComment";
            this.tbComment.Size = new System.Drawing.Size(309, 53);
            this.tbComment.TabIndex = 11;
            // 
            // frmViewContentOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 342);
            this.ControlBox = false;
            this.Controls.Add(this.tbComment);
            this.Controls.Add(this.btnAddTovar);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.chckDeleted);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblSum);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.tbEan);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.dgvOrder);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(794, 358);
            this.Name = "frmViewContentOrder";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Просмотр заказа №";
            this.Load += new System.EventHandler(this.frmViewContentOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOrder;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox tbEan;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lblSum;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox chckDeleted;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnAddTovar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Position;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDep;
        private System.Windows.Forms.DataGridViewTextBoxColumn EAN;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameTovar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Netto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn SummTovar;
        private System.Windows.Forms.TextBox tbComment;
    }
}