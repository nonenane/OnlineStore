namespace OnlineStoreViewOrders.TypeЕmployesОrder
{
    partial class frmAddDeliver
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
            this.btnExit = new System.Windows.Forms.Button();
            this.chbCollector = new System.Windows.Forms.CheckBox();
            this.chbKassTerminal = new System.Windows.Forms.CheckBox();
            this.chbDeliver = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Image = global::OnlineStoreViewOrders.Properties.Resources.pngGALOCHKA;
            this.btnAdd.Location = new System.Drawing.Point(78, 122);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(32, 32);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Image = global::OnlineStoreViewOrders.Properties.Resources.pngExit;
            this.btnExit.Location = new System.Drawing.Point(116, 122);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(32, 32);
            this.btnExit.TabIndex = 2;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // chbCollector
            // 
            this.chbCollector.AutoSize = true;
            this.chbCollector.Location = new System.Drawing.Point(19, 26);
            this.chbCollector.Name = "chbCollector";
            this.chbCollector.Size = new System.Drawing.Size(72, 17);
            this.chbCollector.TabIndex = 4;
            this.chbCollector.Text = "Сборщик";
            this.chbCollector.UseVisualStyleBackColor = true;
            // 
            // chbKassTerminal
            // 
            this.chbKassTerminal.AutoSize = true;
            this.chbKassTerminal.Location = new System.Drawing.Point(19, 49);
            this.chbKassTerminal.Name = "chbKassTerminal";
            this.chbKassTerminal.Size = new System.Drawing.Size(75, 17);
            this.chbKassTerminal.TabIndex = 4;
            this.chbKassTerminal.Text = "Пробитие";
            this.chbKassTerminal.UseVisualStyleBackColor = true;
            // 
            // chbDeliver
            // 
            this.chbDeliver.AutoSize = true;
            this.chbDeliver.Location = new System.Drawing.Point(19, 72);
            this.chbDeliver.Name = "chbDeliver";
            this.chbDeliver.Size = new System.Drawing.Size(85, 17);
            this.chbDeliver.TabIndex = 4;
            this.chbDeliver.Text = "Доставщик";
            this.chbDeliver.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chbDeliver);
            this.groupBox1.Controls.Add(this.chbCollector);
            this.groupBox1.Controls.Add(this.chbKassTerminal);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(134, 100);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Тип сотрудника";
            // 
            // frmAddDeliver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(160, 166);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddDeliver";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выберите тип сотрудника";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.CheckBox chbCollector;
        private System.Windows.Forms.CheckBox chbKassTerminal;
        private System.Windows.Forms.CheckBox chbDeliver;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}