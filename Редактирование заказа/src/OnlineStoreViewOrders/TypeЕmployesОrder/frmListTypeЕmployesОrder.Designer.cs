namespace OnlineStoreViewOrders.TypeЕmployesОrder
{
    partial class frmListTypeЕmployesОrder
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListTypeЕmployesОrder));
            this.label1 = new System.Windows.Forms.Label();
            this.tbNameOrder = new System.Windows.Forms.TextBox();
            this.cmbDeps = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.tbFio = new System.Windows.Forms.TextBox();
            this.dgvDeliversMan = new System.Windows.Forms.DataGridView();
            this.btAdd = new System.Windows.Forms.Button();
            this.btRemote = new System.Windows.Forms.Button();
            this.cFIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.cUseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNameCollector = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cNameKassCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cNameDelivery = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeliversMan)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Заказ:";
            // 
            // tbNameOrder
            // 
            this.tbNameOrder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbNameOrder.Location = new System.Drawing.Point(62, 12);
            this.tbNameOrder.Name = "tbNameOrder";
            this.tbNameOrder.ReadOnly = true;
            this.tbNameOrder.Size = new System.Drawing.Size(776, 20);
            this.tbNameOrder.TabIndex = 20;
            // 
            // cmbDeps
            // 
            this.cmbDeps.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDeps.FormattingEnabled = true;
            this.cmbDeps.Location = new System.Drawing.Point(62, 38);
            this.cmbDeps.Name = "cmbDeps";
            this.cmbDeps.Size = new System.Drawing.Size(186, 21);
            this.cmbDeps.TabIndex = 33;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 42);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 13);
            this.label10.TabIndex = 32;
            this.label10.Text = "Отдел:";
            // 
            // dgvUsers
            // 
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.AllowUserToResizeRows = false;
            this.dgvUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cFIO});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUsers.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgvUsers.Location = new System.Drawing.Point(12, 91);
            this.dgvUsers.MultiSelect = false;
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.RowHeadersVisible = false;
            this.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.Size = new System.Drawing.Size(236, 381);
            this.dgvUsers.TabIndex = 34;
            // 
            // tbFio
            // 
            this.tbFio.Location = new System.Drawing.Point(12, 65);
            this.tbFio.Name = "tbFio";
            this.tbFio.Size = new System.Drawing.Size(236, 20);
            this.tbFio.TabIndex = 35;
            // 
            // dgvDeliversMan
            // 
            this.dgvDeliversMan.AllowUserToAddRows = false;
            this.dgvDeliversMan.AllowUserToDeleteRows = false;
            this.dgvDeliversMan.AllowUserToResizeRows = false;
            this.dgvDeliversMan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDeliversMan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvDeliversMan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDeliversMan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cUseName,
            this.cNameCollector,
            this.cNameKassCheck,
            this.cNameDelivery});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDeliversMan.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgvDeliversMan.Location = new System.Drawing.Point(335, 91);
            this.dgvDeliversMan.MultiSelect = false;
            this.dgvDeliversMan.Name = "dgvDeliversMan";
            this.dgvDeliversMan.ReadOnly = true;
            this.dgvDeliversMan.RowHeadersVisible = false;
            this.dgvDeliversMan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDeliversMan.Size = new System.Drawing.Size(503, 381);
            this.dgvDeliversMan.TabIndex = 34;
            // 
            // btAdd
            // 
            this.btAdd.Location = new System.Drawing.Point(254, 160);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(75, 23);
            this.btAdd.TabIndex = 36;
            this.btAdd.Text = ">";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.BtAdd_Click);
            // 
            // btRemote
            // 
            this.btRemote.Location = new System.Drawing.Point(254, 313);
            this.btRemote.Name = "btRemote";
            this.btRemote.Size = new System.Drawing.Size(75, 23);
            this.btRemote.TabIndex = 36;
            this.btRemote.Text = "<";
            this.btRemote.UseVisualStyleBackColor = true;
            this.btRemote.Click += new System.EventHandler(this.BtRemote_Click);
            // 
            // cFIO
            // 
            this.cFIO.DataPropertyName = "FIO";
            this.cFIO.HeaderText = "ФИО";
            this.cFIO.Name = "cFIO";
            this.cFIO.ReadOnly = true;
            // 
            // btSave
            // 
            this.btSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSave.BackColor = System.Drawing.Color.White;
            this.btSave.Image = global::OnlineStoreViewOrders.Properties.Resources.save_edit;
            this.btSave.Location = new System.Drawing.Point(768, 478);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(32, 32);
            this.btSave.TabIndex = 18;
            this.btSave.UseVisualStyleBackColor = false;
            this.btSave.Click += new System.EventHandler(this.BtSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.White;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.Location = new System.Drawing.Point(806, 478);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(32, 32);
            this.btnExit.TabIndex = 18;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // cUseName
            // 
            this.cUseName.DataPropertyName = "FIO";
            this.cUseName.HeaderText = "Сотрудники";
            this.cUseName.Name = "cUseName";
            this.cUseName.ReadOnly = true;
            // 
            // cNameCollector
            // 
            this.cNameCollector.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cNameCollector.DataPropertyName = "Collector";
            this.cNameCollector.HeaderText = "Сборщик";
            this.cNameCollector.MinimumWidth = 60;
            this.cNameCollector.Name = "cNameCollector";
            this.cNameCollector.ReadOnly = true;
            this.cNameCollector.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cNameCollector.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.cNameCollector.Width = 60;
            // 
            // cNameKassCheck
            // 
            this.cNameKassCheck.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cNameKassCheck.DataPropertyName = "KassCheck";
            this.cNameKassCheck.HeaderText = "Пробитие";
            this.cNameKassCheck.MinimumWidth = 60;
            this.cNameKassCheck.Name = "cNameKassCheck";
            this.cNameKassCheck.ReadOnly = true;
            this.cNameKassCheck.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cNameKassCheck.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.cNameKassCheck.Width = 60;
            // 
            // cNameDelivery
            // 
            this.cNameDelivery.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cNameDelivery.DataPropertyName = "Delivery";
            this.cNameDelivery.HeaderText = "Доставщик";
            this.cNameDelivery.MinimumWidth = 70;
            this.cNameDelivery.Name = "cNameDelivery";
            this.cNameDelivery.ReadOnly = true;
            this.cNameDelivery.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cNameDelivery.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.cNameDelivery.Width = 70;
            // 
            // frmListTypeЕmployesОrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 522);
            this.ControlBox = false;
            this.Controls.Add(this.btRemote);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.tbFio);
            this.Controls.Add(this.dgvDeliversMan);
            this.Controls.Add(this.dgvUsers);
            this.Controls.Add(this.cmbDeps);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tbNameOrder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.btnExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmListTypeЕmployesОrder";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Назначение сотрудников на заказ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmListTypeЕmployesОrder_FormClosing);
            this.Load += new System.EventHandler(this.FrmListTypeЕmployesОrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeliversMan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbNameOrder;
        private System.Windows.Forms.ComboBox cmbDeps;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.TextBox tbFio;
        private System.Windows.Forms.DataGridView dgvDeliversMan;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.Button btRemote;
        private System.Windows.Forms.DataGridViewTextBoxColumn cFIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn cUseName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cNameCollector;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cNameKassCheck;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cNameDelivery;
    }
}