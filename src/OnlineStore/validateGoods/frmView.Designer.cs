namespace OnlineStore.validateGoods
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmbInv = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTU = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDeps = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btUpdate = new System.Windows.Forms.Button();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbSingle = new System.Windows.Forms.RadioButton();
            this.rbMass = new System.Windows.Forms.RadioButton();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.cV = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cEan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNameTovarTerminal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbEan = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btPrint = new System.Windows.Forms.Button();
            this.btUpdatePrice = new System.Windows.Forms.Button();
            this.tbNameTerminal = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbInv
            // 
            this.cmbInv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInv.FormattingEnabled = true;
            this.cmbInv.Location = new System.Drawing.Point(350, 46);
            this.cmbInv.Name = "cmbInv";
            this.cmbInv.Size = new System.Drawing.Size(169, 21);
            this.cmbInv.TabIndex = 15;
            this.cmbInv.SelectionChangeCommitted += new System.EventHandler(this.cmbInv_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(277, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Инв. группа:";
            // 
            // cmbTU
            // 
            this.cmbTU.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTU.FormattingEnabled = true;
            this.cmbTU.Location = new System.Drawing.Point(350, 12);
            this.cmbTU.Name = "cmbTU";
            this.cmbTU.Size = new System.Drawing.Size(169, 21);
            this.cmbTU.TabIndex = 16;
            this.cmbTU.SelectionChangeCommitted += new System.EventHandler(this.cmbTU_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(280, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Т\\У группа:";
            // 
            // cmbDeps
            // 
            this.cmbDeps.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDeps.FormattingEnabled = true;
            this.cmbDeps.Location = new System.Drawing.Point(85, 12);
            this.cmbDeps.Name = "cmbDeps";
            this.cmbDeps.Size = new System.Drawing.Size(169, 21);
            this.cmbDeps.TabIndex = 18;
            this.cmbDeps.SelectionChangeCommitted += new System.EventHandler(this.cmbDeps_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Отдел:";
            // 
            // btUpdate
            // 
            this.btUpdate.Image = global::OnlineStore.Properties.Resources.button_refresh_15001__1_1;
            this.btUpdate.Location = new System.Drawing.Point(625, 8);
            this.btUpdate.Name = "btUpdate";
            this.btUpdate.Size = new System.Drawing.Size(49, 48);
            this.btUpdate.TabIndex = 35;
            this.btUpdate.UseVisualStyleBackColor = true;
            this.btUpdate.Click += new System.EventHandler(this.btUpdate_Click);
            // 
            // rbAll
            // 
            this.rbAll.AutoSize = true;
            this.rbAll.Checked = true;
            this.rbAll.Location = new System.Drawing.Point(15, 16);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(44, 17);
            this.rbAll.TabIndex = 36;
            this.rbAll.TabStop = true;
            this.rbAll.Text = "Все";
            this.rbAll.UseVisualStyleBackColor = true;
            this.rbAll.Click += new System.EventHandler(this.tbSingle_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbSingle);
            this.groupBox1.Controls.Add(this.rbMass);
            this.groupBox1.Controls.Add(this.rbAll);
            this.groupBox1.Location = new System.Drawing.Point(12, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(242, 40);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Тип товара";
            // 
            // rbSingle
            // 
            this.rbSingle.AutoSize = true;
            this.rbSingle.Location = new System.Drawing.Point(59, 16);
            this.rbSingle.Name = "rbSingle";
            this.rbSingle.Size = new System.Drawing.Size(68, 17);
            this.rbSingle.TabIndex = 36;
            this.rbSingle.Text = "штучный";
            this.rbSingle.UseVisualStyleBackColor = true;
            this.rbSingle.Click += new System.EventHandler(this.tbSingle_Click);
            // 
            // rbMass
            // 
            this.rbMass.AutoSize = true;
            this.rbMass.Location = new System.Drawing.Point(127, 16);
            this.rbMass.Name = "rbMass";
            this.rbMass.Size = new System.Drawing.Size(67, 17);
            this.rbMass.TabIndex = 36;
            this.rbMass.Text = "весовой";
            this.rbMass.UseVisualStyleBackColor = true;
            this.rbMass.Click += new System.EventHandler(this.tbSingle_Click);
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
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cV,
            this.cEan,
            this.cName,
            this.cNameTovarTerminal});
            this.dgvData.Location = new System.Drawing.Point(12, 112);
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(662, 390);
            this.dgvData.TabIndex = 38;
            this.dgvData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellContentClick);
            this.dgvData.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgvData_ColumnWidthChanged);
            // 
            // cV
            // 
            this.cV.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cV.DataPropertyName = "isSelect";
            this.cV.HeaderText = "V";
            this.cV.MinimumWidth = 30;
            this.cV.Name = "cV";
            this.cV.Width = 30;
            // 
            // cEan
            // 
            this.cEan.DataPropertyName = "ean";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.cEan.DefaultCellStyle = dataGridViewCellStyle8;
            this.cEan.FillWeight = 73.74648F;
            this.cEan.HeaderText = "EAN";
            this.cEan.Name = "cEan";
            this.cEan.ReadOnly = true;
            // 
            // cName
            // 
            this.cName.DataPropertyName = "nameTovarTerminal";
            this.cName.FillWeight = 137.0558F;
            this.cName.HeaderText = "Короткое наименование товара на сайте";
            this.cName.Name = "cName";
            this.cName.ReadOnly = true;
            // 
            // cNameTovarTerminal
            // 
            this.cNameTovarTerminal.DataPropertyName = "nameTovarOnlineStore";
            this.cNameTovarTerminal.HeaderText = "Наименование товара на кассе";
            this.cNameTovarTerminal.Name = "cNameTovarTerminal";
            this.cNameTovarTerminal.ReadOnly = true;
            // 
            // tbEan
            // 
            this.tbEan.Location = new System.Drawing.Point(41, 86);
            this.tbEan.MaxLength = 13;
            this.tbEan.Name = "tbEan";
            this.tbEan.Size = new System.Drawing.Size(123, 20);
            this.tbEan.TabIndex = 41;
            this.tbEan.TextChanged += new System.EventHandler(this.tbEan_TextChanged);
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(170, 86);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(156, 20);
            this.tbName.TabIndex = 40;
            this.tbName.TextChanged += new System.EventHandler(this.tbEan_TextChanged);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Image = global::OnlineStore.Properties.Resources.exit_8633;
            this.btnExit.Location = new System.Drawing.Point(642, 519);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(32, 32);
            this.btnExit.TabIndex = 49;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btPrint
            // 
            this.btPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btPrint.Image = global::OnlineStore.Properties.Resources.klpq_2511;
            this.btPrint.Location = new System.Drawing.Point(604, 519);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(32, 32);
            this.btPrint.TabIndex = 48;
            this.btPrint.UseVisualStyleBackColor = true;
            this.btPrint.Click += new System.EventHandler(this.btPrint_Click);
            // 
            // btUpdatePrice
            // 
            this.btUpdatePrice.Enabled = false;
            this.btUpdatePrice.Location = new System.Drawing.Point(240, 519);
            this.btUpdatePrice.Name = "btUpdatePrice";
            this.btUpdatePrice.Size = new System.Drawing.Size(193, 32);
            this.btUpdatePrice.TabIndex = 50;
            this.btUpdatePrice.Text = "Обновить наименование товара";
            this.btUpdatePrice.UseVisualStyleBackColor = true;
            this.btUpdatePrice.Click += new System.EventHandler(this.btUpdatePrice_Click);
            // 
            // tbNameTerminal
            // 
            this.tbNameTerminal.Location = new System.Drawing.Point(332, 86);
            this.tbNameTerminal.Name = "tbNameTerminal";
            this.tbNameTerminal.Size = new System.Drawing.Size(156, 20);
            this.tbNameTerminal.TabIndex = 40;
            this.tbNameTerminal.TextChanged += new System.EventHandler(this.tbEan_TextChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(535, 62);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(139, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 51;
            this.progressBar1.Visible = false;
            // 
            // frmView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 559);
            this.ControlBox = false;
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btUpdatePrice);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btPrint);
            this.Controls.Add(this.tbEan);
            this.Controls.Add(this.tbNameTerminal);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btUpdate);
            this.Controls.Add(this.cmbInv);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbTU);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbDeps);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmView";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Сравнение наименований товаров на кассе и сайте";
            this.Load += new System.EventHandler(this.frmView_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbInv;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTU;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbDeps;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btUpdate;
        private System.Windows.Forms.RadioButton rbAll;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbSingle;
        private System.Windows.Forms.RadioButton rbMass;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.TextBox tbEan;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btPrint;
        private System.Windows.Forms.Button btUpdatePrice;
        private System.Windows.Forms.TextBox tbNameTerminal;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cV;
        private System.Windows.Forms.DataGridViewTextBoxColumn cEan;
        private System.Windows.Forms.DataGridViewTextBoxColumn cName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNameTovarTerminal;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}