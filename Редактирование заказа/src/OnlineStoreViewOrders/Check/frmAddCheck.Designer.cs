namespace OnlineStoreViewOrders.Check
{
    partial class frmAddCheck
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbCheck = new System.Windows.Forms.TextBox();
            this.tbKass = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.chckPackage = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::OnlineStoreViewOrders.Properties.Resources.pngGALOCHKA;
            this.btnAdd.Location = new System.Drawing.Point(134, 131);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(32, 32);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dtpDate
            // 
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(105, 12);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(98, 20);
            this.dtpDate.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Дата";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Номер чека";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Номер кассы";
            // 
            // tbCheck
            // 
            this.tbCheck.Location = new System.Drawing.Point(105, 47);
            this.tbCheck.MaxLength = 7;
            this.tbCheck.Name = "tbCheck";
            this.tbCheck.Size = new System.Drawing.Size(98, 20);
            this.tbCheck.TabIndex = 5;
            this.tbCheck.TextChanged += new System.EventHandler(this.tbCheck_TextChanged);
            this.tbCheck.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbCheck_KeyDown);
            this.tbCheck.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbKass_KeyPress);
            this.tbCheck.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbCheck_KeyUp);
            // 
            // tbKass
            // 
            this.tbKass.Location = new System.Drawing.Point(103, 78);
            this.tbKass.MaxLength = 4;
            this.tbKass.Name = "tbKass";
            this.tbKass.Size = new System.Drawing.Size(98, 20);
            this.tbKass.TabIndex = 6;
            this.tbKass.TextChanged += new System.EventHandler(this.tbCheck_TextChanged);
            this.tbKass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbCheck_KeyDown);
            this.tbKass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbKass_KeyPress);
            // 
            // btnExit
            // 
            this.btnExit.Image = global::OnlineStoreViewOrders.Properties.Resources.pngExit;
            this.btnExit.Location = new System.Drawing.Point(172, 131);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(32, 32);
            this.btnExit.TabIndex = 7;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // chckPackage
            // 
            this.chckPackage.AutoSize = true;
            this.chckPackage.Location = new System.Drawing.Point(103, 108);
            this.chckPackage.Name = "chckPackage";
            this.chckPackage.Size = new System.Drawing.Size(57, 17);
            this.chckPackage.TabIndex = 8;
            this.chckPackage.Text = "Пакет";
            this.chckPackage.UseVisualStyleBackColor = true;
            // 
            // frmAddCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(213, 175);
            this.Controls.Add(this.chckPackage);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.tbKass);
            this.Controls.Add(this.tbCheck);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.btnAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmAddCheck";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавление чека";
            this.Load += new System.EventHandler(this.frmAddCheck_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbCheck;
        private System.Windows.Forms.TextBox tbKass;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.CheckBox chckPackage;
    }
}