namespace OnlineStoreViewOrders.statisticOrder
{
    partial class frmListPeriod
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListPeriod));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btHide = new System.Windows.Forms.Button();
            this.dgvDataTovar = new System.Windows.Forms.DataGridView();
            this.cV = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDateStart = new OnlineStoreViewOrders.statisticOrder.frmListPeriod.CalendarColumn();
            this.cDateEnd = new OnlineStoreViewOrders.statisticOrder.frmListPeriod.CalendarColumn();
            this.cColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataTovar)).BeginInit();
            this.SuspendLayout();
            // 
            // btHide
            // 
            this.btHide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btHide.BackColor = System.Drawing.Color.White;
            this.btHide.Image = ((System.Drawing.Image)(resources.GetObject("btHide.Image")));
            this.btHide.Location = new System.Drawing.Point(451, 372);
            this.btHide.Name = "btHide";
            this.btHide.Size = new System.Drawing.Size(32, 32);
            this.btHide.TabIndex = 20;
            this.btHide.UseVisualStyleBackColor = false;
            this.btHide.Click += new System.EventHandler(this.btHide_Click);
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDataTovar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDataTovar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataTovar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cV,
            this.cName,
            this.cDateStart,
            this.cDateEnd,
            this.cColor});
            this.dgvDataTovar.Location = new System.Drawing.Point(12, 12);
            this.dgvDataTovar.MultiSelect = false;
            this.dgvDataTovar.Name = "dgvDataTovar";
            this.dgvDataTovar.RowHeadersVisible = false;
            this.dgvDataTovar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDataTovar.ShowCellErrors = false;
            this.dgvDataTovar.ShowCellToolTips = false;
            this.dgvDataTovar.ShowEditingIcon = false;
            this.dgvDataTovar.ShowRowErrors = false;
            this.dgvDataTovar.Size = new System.Drawing.Size(471, 354);
            this.dgvDataTovar.TabIndex = 26;
            this.dgvDataTovar.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDataTovar_CellClick);
            this.dgvDataTovar.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDataTovar_RowPostPaint);
            this.dgvDataTovar.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvDataTovar_RowPrePaint);
            // 
            // cV
            // 
            this.cV.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cV.DataPropertyName = "isSelect";
            this.cV.HeaderText = "V";
            this.cV.MinimumWidth = 45;
            this.cV.Name = "cV";
            this.cV.Width = 45;
            // 
            // cName
            // 
            this.cName.DataPropertyName = "cName";
            this.cName.HeaderText = "Наименование";
            this.cName.Name = "cName";
            this.cName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cDateStart
            // 
            this.cDateStart.DataPropertyName = "dateStart";
            this.cDateStart.HeaderText = "Дата начала";
            this.cDateStart.Name = "cDateStart";
            // 
            // cDateEnd
            // 
            this.cDateEnd.DataPropertyName = "dateEnd";
            this.cDateEnd.HeaderText = "Дата окончания";
            this.cDateEnd.Name = "cDateEnd";
            // 
            // cColor
            // 
            this.cColor.HeaderText = "Цвет";
            this.cColor.Name = "cColor";
            this.cColor.ReadOnly = true;
            // 
            // frmListPeriod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 416);
            this.Controls.Add(this.dgvDataTovar);
            this.Controls.Add(this.btHide);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmListPeriod";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Список периодов";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmListPeriod_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataTovar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btHide;
        private System.Windows.Forms.DataGridView dgvDataTovar;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cV;
        private System.Windows.Forms.DataGridViewTextBoxColumn cName;
        private CalendarColumn cDateStart;
        private CalendarColumn cDateEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn cColor;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}