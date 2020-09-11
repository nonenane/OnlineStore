namespace OnlineStoreViewOrders
{
    partial class frmCheck
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
            this.dgvCheck = new System.Windows.Forms.DataGridView();
            this.cDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCheck = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cKass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelCheck = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnViewCheck = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCheck)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCheck
            // 
            this.dgvCheck.AllowUserToAddRows = false;
            this.dgvCheck.AllowUserToDeleteRows = false;
            this.dgvCheck.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCheck.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvCheck.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCheck.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cDate,
            this.cCheck,
            this.cKass});
            this.dgvCheck.Location = new System.Drawing.Point(13, 25);
            this.dgvCheck.Name = "dgvCheck";
            this.dgvCheck.ReadOnly = true;
            this.dgvCheck.RowHeadersVisible = false;
            this.dgvCheck.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCheck.Size = new System.Drawing.Size(309, 167);
            this.dgvCheck.TabIndex = 3;
            this.dgvCheck.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvCheck_RowPostPaint);
            this.dgvCheck.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvCheck_RowPrePaint);
            // 
            // cDate
            // 
            this.cDate.DataPropertyName = "DateCheck";
            this.cDate.HeaderText = "Дата";
            this.cDate.Name = "cDate";
            this.cDate.ReadOnly = true;
            // 
            // cCheck
            // 
            this.cCheck.DataPropertyName = "CheckNumber";
            this.cCheck.HeaderText = "Чек";
            this.cCheck.Name = "cCheck";
            this.cCheck.ReadOnly = true;
            // 
            // cKass
            // 
            this.cKass.DataPropertyName = "KassNumber";
            this.cKass.HeaderText = "Касса";
            this.cKass.Name = "cKass";
            this.cKass.ReadOnly = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::OnlineStoreViewOrders.Properties.Resources.ic_add_circle_outline_128_28123;
            this.btnAdd.Location = new System.Drawing.Point(214, 198);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(32, 32);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelCheck
            // 
            this.btnDelCheck.Image = global::OnlineStoreViewOrders.Properties.Resources.delete_delete_exit_1577;
            this.btnDelCheck.Location = new System.Drawing.Point(252, 198);
            this.btnDelCheck.Name = "btnDelCheck";
            this.btnDelCheck.Size = new System.Drawing.Size(32, 32);
            this.btnDelCheck.TabIndex = 1;
            this.btnDelCheck.UseVisualStyleBackColor = true;
            this.btnDelCheck.Click += new System.EventHandler(this.btnDelCheck_Click);
            // 
            // btnExit
            // 
            this.btnExit.Image = global::OnlineStoreViewOrders.Properties.Resources.pngExit;
            this.btnExit.Location = new System.Drawing.Point(290, 198);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(32, 32);
            this.btnExit.TabIndex = 0;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 210);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Кол-во пакетов: ";
            // 
            // btnViewCheck
            // 
            this.btnViewCheck.Image = global::OnlineStoreViewOrders.Properties.Resources.Zoomview_6277;
            this.btnViewCheck.Location = new System.Drawing.Point(176, 198);
            this.btnViewCheck.Name = "btnViewCheck";
            this.btnViewCheck.Size = new System.Drawing.Size(32, 32);
            this.btnViewCheck.TabIndex = 5;
            this.btnViewCheck.UseVisualStyleBackColor = true;
            this.btnViewCheck.Click += new System.EventHandler(this.btnViewCheck_Click);
            // 
            // frmCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 235);
            this.ControlBox = false;
            this.Controls.Add(this.btnViewCheck);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvCheck);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnDelCheck);
            this.Controls.Add(this.btnExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmCheck";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Чеки по заказу";
            this.Load += new System.EventHandler(this.frmCheck_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCheck)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDelCheck;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dgvCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn cKass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnViewCheck;
    }
}