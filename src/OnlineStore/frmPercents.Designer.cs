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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvPercents = new System.Windows.Forms.DataGridView();
            this.cDep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cMargin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSale = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.chckUseSale = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPercents)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPercents
            // 
            this.dgvPercents.AllowUserToAddRows = false;
            this.dgvPercents.AllowUserToDeleteRows = false;
            this.dgvPercents.AllowUserToResizeRows = false;
            this.dgvPercents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPercents.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPercents.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPercents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPercents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cDep,
            this.cMargin,
            this.cSale});
            this.dgvPercents.Location = new System.Drawing.Point(12, 26);
            this.dgvPercents.Name = "dgvPercents";
            this.dgvPercents.RowHeadersVisible = false;
            this.dgvPercents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPercents.ShowCellErrors = false;
            this.dgvPercents.ShowCellToolTips = false;
            this.dgvPercents.ShowEditingIcon = false;
            this.dgvPercents.ShowRowErrors = false;
            this.dgvPercents.Size = new System.Drawing.Size(435, 226);
            this.dgvPercents.TabIndex = 0;
            this.dgvPercents.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
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
            this.btnExit.Image = global::OnlineStore.Properties.Resources.pngExit;
            this.btnExit.Location = new System.Drawing.Point(431, 258);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(32, 32);
            this.btnExit.TabIndex = 1;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.Image = global::OnlineStore.Properties.Resources.filesave_2175;
            this.btnSave.Location = new System.Drawing.Point(393, 258);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(32, 32);
            this.btnSave.TabIndex = 2;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chckUseSale
            // 
            this.chckUseSale.AutoSize = true;
            this.chckUseSale.Location = new System.Drawing.Point(13, 272);
            this.chckUseSale.Name = "chckUseSale";
            this.chckUseSale.Size = new System.Drawing.Size(193, 17);
            this.chckUseSale.TabIndex = 3;
            this.chckUseSale.Text = "Использовать цены распродажи";
            this.chckUseSale.UseVisualStyleBackColor = true;
            this.chckUseSale.CheckedChanged += new System.EventHandler(this.chckUseSale_CheckedChanged);
            // 
            // frmPercents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 302);
            this.ControlBox = false;
            this.Controls.Add(this.chckUseSale);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.dgvPercents);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmPercents";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройка процентов";
            this.Load += new System.EventHandler(this.frmPercents_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPercents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDep;
        private System.Windows.Forms.DataGridViewTextBoxColumn cMargin;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSale;
        private System.Windows.Forms.CheckBox chckUseSale;
        private System.Windows.Forms.DataGridView dgvPercents;
    }
}