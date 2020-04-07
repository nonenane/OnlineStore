namespace OnlineStore.dictonatyTovar
{
    partial class frmAddTovar
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
            this.btSave = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.tbEan = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbShotName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbFullName = new System.Windows.Forms.TextBox();
            this.cmbParentCategory = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbRcena = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbActionPrice = new System.Windows.Forms.TextBox();
            this.chbActive = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btSave
            // 
            this.btSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSave.Image = global::OnlineStore.Properties.Resources.filesave_2175;
            this.btSave.Location = new System.Drawing.Point(374, 264);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(32, 32);
            this.btSave.TabIndex = 6;
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.Image = global::OnlineStore.Properties.Resources.exit_8633;
            this.btClose.Location = new System.Drawing.Point(412, 264);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(32, 32);
            this.btClose.TabIndex = 7;
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // tbEan
            // 
            this.tbEan.Location = new System.Drawing.Point(183, 12);
            this.tbEan.MaxLength = 13;
            this.tbEan.Name = "tbEan";
            this.tbEan.Size = new System.Drawing.Size(104, 20);
            this.tbEan.TabIndex = 9;
            this.tbEan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbName_KeyDown);
            this.tbEan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbInt_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(145, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "EAN:";
            // 
            // tbShotName
            // 
            this.tbShotName.Location = new System.Drawing.Point(183, 38);
            this.tbShotName.MaxLength = 50;
            this.tbShotName.Multiline = true;
            this.tbShotName.Name = "tbShotName";
            this.tbShotName.Size = new System.Drawing.Size(262, 50);
            this.tbShotName.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Короткое наименование товара:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(163, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Полное наименование товара:";
            // 
            // tbFullName
            // 
            this.tbFullName.Location = new System.Drawing.Point(183, 94);
            this.tbFullName.MaxLength = 1000;
            this.tbFullName.Multiline = true;
            this.tbFullName.Name = "tbFullName";
            this.tbFullName.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbFullName.Size = new System.Drawing.Size(262, 82);
            this.tbFullName.TabIndex = 11;
            // 
            // cmbParentCategory
            // 
            this.cmbParentCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbParentCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParentCategory.FormattingEnabled = true;
            this.cmbParentCategory.Location = new System.Drawing.Point(183, 181);
            this.cmbParentCategory.Name = "cmbParentCategory";
            this.cmbParentCategory.Size = new System.Drawing.Size(262, 21);
            this.cmbParentCategory.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(76, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Категория товара:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(59, 212);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Базовая цена товара:";
            // 
            // tbRcena
            // 
            this.tbRcena.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbRcena.Location = new System.Drawing.Point(183, 208);
            this.tbRcena.MaxLength = 17;
            this.tbRcena.Name = "tbRcena";
            this.tbRcena.Size = new System.Drawing.Size(130, 20);
            this.tbRcena.TabIndex = 11;
            this.tbRcena.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbRcena.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbDecimal_KeyPress);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(44, 238);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(133, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Акционная  цена товара:";
            // 
            // tbActionPrice
            // 
            this.tbActionPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbActionPrice.Location = new System.Drawing.Point(183, 234);
            this.tbActionPrice.MaxLength = 17;
            this.tbActionPrice.Name = "tbActionPrice";
            this.tbActionPrice.Size = new System.Drawing.Size(130, 20);
            this.tbActionPrice.TabIndex = 11;
            this.tbActionPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbActionPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbDecimal_KeyPress);
            // 
            // chbActive
            // 
            this.chbActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chbActive.AutoSize = true;
            this.chbActive.Checked = true;
            this.chbActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbActive.Location = new System.Drawing.Point(183, 260);
            this.chbActive.Name = "chbActive";
            this.chbActive.Size = new System.Drawing.Size(130, 17);
            this.chbActive.TabIndex = 14;
            this.chbActive.Text = "Действующий товар";
            this.chbActive.UseVisualStyleBackColor = true;
            // 
            // frmAddTovar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 308);
            this.ControlBox = false;
            this.Controls.Add(this.chbActive);
            this.Controls.Add(this.cmbParentCategory);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbFullName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbActionPrice);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbRcena);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbShotName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbEan);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.btClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddTovar";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddTovar";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAddTovar_FormClosing);
            this.Load += new System.EventHandler(this.frmAddTovar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.TextBox tbEan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbShotName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbFullName;
        private System.Windows.Forms.ComboBox cmbParentCategory;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbRcena;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbActionPrice;
        private System.Windows.Forms.CheckBox chbActive;
    }
}