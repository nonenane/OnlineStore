namespace OnlineStoreViewOrders.Check
{
    partial class frmView
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
            this.btnExit = new System.Windows.Forms.Button();
            this.dgvCheck = new System.Windows.Forms.DataGridView();
            this.cEan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNetto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSumm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbEAN = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.pnlVozv = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCheck)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Image = global::OnlineStoreViewOrders.Properties.Resources.pngExit;
            this.btnExit.Location = new System.Drawing.Point(477, 277);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(32, 32);
            this.btnExit.TabIndex = 0;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvCheck
            // 
            this.dgvCheck.AllowUserToAddRows = false;
            this.dgvCheck.AllowUserToDeleteRows = false;
            this.dgvCheck.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCheck.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvCheck.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCheck.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cEan,
            this.cName,
            this.cNetto,
            this.cPrice,
            this.cSumm});
            this.dgvCheck.Location = new System.Drawing.Point(13, 42);
            this.dgvCheck.Name = "dgvCheck";
            this.dgvCheck.ReadOnly = true;
            this.dgvCheck.RowHeadersVisible = false;
            this.dgvCheck.Size = new System.Drawing.Size(496, 229);
            this.dgvCheck.TabIndex = 2;
            this.dgvCheck.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgvCheck_ColumnWidthChanged);
            this.dgvCheck.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvCheck_RowPostPaint);
            this.dgvCheck.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvCheck_RowPrePaint);
            // 
            // cEan
            // 
            this.cEan.DataPropertyName = "ean";
            this.cEan.FillWeight = 105.2016F;
            this.cEan.HeaderText = "EAN";
            this.cEan.Name = "cEan";
            this.cEan.ReadOnly = true;
            // 
            // cName
            // 
            this.cName.DataPropertyName = "nametovar";
            this.cName.FillWeight = 283.6846F;
            this.cName.HeaderText = "Наименование";
            this.cName.Name = "cName";
            this.cName.ReadOnly = true;
            // 
            // cNetto
            // 
            this.cNetto.DataPropertyName = "count";
            this.cNetto.FillWeight = 50F;
            this.cNetto.HeaderText = "Кол-во";
            this.cNetto.Name = "cNetto";
            this.cNetto.ReadOnly = true;
            // 
            // cPrice
            // 
            this.cPrice.DataPropertyName = "price";
            this.cPrice.FillWeight = 50F;
            this.cPrice.HeaderText = "Цена";
            this.cPrice.Name = "cPrice";
            this.cPrice.ReadOnly = true;
            // 
            // cSumm
            // 
            this.cSumm.DataPropertyName = "sumtovar";
            this.cSumm.FillWeight = 75F;
            this.cSumm.HeaderText = "Сумма";
            this.cSumm.Name = "cSumm";
            this.cSumm.ReadOnly = true;
            // 
            // tbEAN
            // 
            this.tbEAN.Location = new System.Drawing.Point(13, 16);
            this.tbEAN.Name = "tbEAN";
            this.tbEAN.Size = new System.Drawing.Size(96, 20);
            this.tbEAN.TabIndex = 3;
            this.tbEAN.TextChanged += new System.EventHandler(this.tbEAN_TextChanged);
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(115, 16);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(241, 20);
            this.tbName.TabIndex = 4;
            this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // pnlVozv
            // 
            this.pnlVozv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.pnlVozv.Location = new System.Drawing.Point(13, 292);
            this.pnlVozv.Name = "pnlVozv";
            this.pnlVozv.Size = new System.Drawing.Size(17, 17);
            this.pnlVozv.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 295);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Возврат";
            // 
            // btnPrint
            // 
            this.btnPrint.Image = global::OnlineStoreViewOrders.Properties.Resources.pngPrint;
            this.btnPrint.Location = new System.Drawing.Point(439, 276);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(32, 32);
            this.btnPrint.TabIndex = 7;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // frmView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 321);
            this.ControlBox = false;
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlVozv);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.tbEAN);
            this.Controls.Add(this.dgvCheck);
            this.Controls.Add(this.btnExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Просмотр чека";
            this.Load += new System.EventHandler(this.frmView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCheck)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DataGridView dgvCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn cEan;
        private System.Windows.Forms.DataGridViewTextBoxColumn cName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNetto;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSumm;
        private System.Windows.Forms.TextBox tbEAN;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Panel pnlVozv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPrint;
    }
}