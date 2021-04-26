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
            this.lMinOrder = new System.Windows.Forms.Label();
            this.tbMinOrder = new System.Windows.Forms.TextBox();
            this.lMaxOrder = new System.Windows.Forms.Label();
            this.tbMaxOrder = new System.Windows.Forms.TextBox();
            this.lStep = new System.Windows.Forms.Label();
            this.tbStep = new System.Windows.Forms.TextBox();
            this.lDefaultNetto = new System.Windows.Forms.Label();
            this.tbDefaultNetto = new System.Windows.Forms.TextBox();
            this.lPriceSuffix = new System.Windows.Forms.Label();
            this.tbPriceSuffix = new System.Windows.Forms.TextBox();
            this.lQuantitySuffix = new System.Windows.Forms.Label();
            this.tbQuantitySuffix = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbPricePercent = new System.Windows.Forms.TextBox();
            this.tbShortDescription = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbNameCategory = new System.Windows.Forms.TextBox();
            this.btAddCategory = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btSave
            // 
            this.btSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btSave.Image = global::OnlineStore.Properties.Resources.filesave_2175;
            this.btSave.Location = new System.Drawing.Point(375, 419);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(32, 32);
            this.btSave.TabIndex = 6;
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btClose.Image = global::OnlineStore.Properties.Resources.exit_8633;
            this.btClose.Location = new System.Drawing.Point(413, 419);
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
            this.tbEan.Validating += new System.ComponentModel.CancelEventHandler(this.tbEan_Validating);
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
            this.tbShotName.MaxLength = 150;
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
            this.cmbParentCategory.Location = new System.Drawing.Point(590, 426);
            this.cmbParentCategory.Name = "cmbParentCategory";
            this.cmbParentCategory.Size = new System.Drawing.Size(262, 21);
            this.cmbParentCategory.TabIndex = 13;
            this.cmbParentCategory.Visible = false;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(79, 273);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Категория товара:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(103, 363);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Цена товара:";
            // 
            // tbRcena
            // 
            this.tbRcena.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbRcena.Enabled = false;
            this.tbRcena.Location = new System.Drawing.Point(183, 360);
            this.tbRcena.MaxLength = 17;
            this.tbRcena.Name = "tbRcena";
            this.tbRcena.Size = new System.Drawing.Size(130, 20);
            this.tbRcena.TabIndex = 11;
            this.tbRcena.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbRcena.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbDecimal_KeyPress);
            this.tbRcena.Validating += new System.ComponentModel.CancelEventHandler(this.tbRcena_Validating);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 415);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(159, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Старая цена для распродажи:";
            // 
            // tbActionPrice
            // 
            this.tbActionPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbActionPrice.Location = new System.Drawing.Point(183, 412);
            this.tbActionPrice.MaxLength = 17;
            this.tbActionPrice.Name = "tbActionPrice";
            this.tbActionPrice.Size = new System.Drawing.Size(130, 20);
            this.tbActionPrice.TabIndex = 11;
            this.tbActionPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbActionPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbDecimal_KeyPress);
            this.tbActionPrice.Validating += new System.ComponentModel.CancelEventHandler(this.tbRcena_Validating);
            // 
            // chbActive
            // 
            this.chbActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chbActive.AutoSize = true;
            this.chbActive.Checked = true;
            this.chbActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbActive.Location = new System.Drawing.Point(183, 442);
            this.chbActive.Name = "chbActive";
            this.chbActive.Size = new System.Drawing.Size(130, 17);
            this.chbActive.TabIndex = 14;
            this.chbActive.Text = "Действующий товар";
            this.chbActive.UseVisualStyleBackColor = true;
            // 
            // lMinOrder
            // 
            this.lMinOrder.AutoSize = true;
            this.lMinOrder.Location = new System.Drawing.Point(538, 44);
            this.lMinOrder.Name = "lMinOrder";
            this.lMinOrder.Size = new System.Drawing.Size(181, 13);
            this.lMinOrder.TabIndex = 10;
            this.lMinOrder.Text = "Минимальное количество заказа:";
            // 
            // tbMinOrder
            // 
            this.tbMinOrder.Location = new System.Drawing.Point(725, 40);
            this.tbMinOrder.MaxLength = 17;
            this.tbMinOrder.Name = "tbMinOrder";
            this.tbMinOrder.Size = new System.Drawing.Size(127, 20);
            this.tbMinOrder.TabIndex = 11;
            this.tbMinOrder.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbMinOrder.TextChanged += new System.EventHandler(this.tbMinOrder_TextChanged);
            this.tbMinOrder.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbDecimal_KeyPress);
            this.tbMinOrder.Leave += new System.EventHandler(this.tbMinOrder_Leave);
            this.tbMinOrder.Validating += new System.ComponentModel.CancelEventHandler(this.tbMinOrder_Validating);
            this.tbMinOrder.Validated += new System.EventHandler(this.tbMinOrder_Validated);
            // 
            // lMaxOrder
            // 
            this.lMaxOrder.AutoSize = true;
            this.lMaxOrder.Location = new System.Drawing.Point(529, 69);
            this.lMaxOrder.Name = "lMaxOrder";
            this.lMaxOrder.Size = new System.Drawing.Size(190, 13);
            this.lMaxOrder.TabIndex = 10;
            this.lMaxOrder.Text = "Максимальное  количество заказа:";
            // 
            // tbMaxOrder
            // 
            this.tbMaxOrder.Location = new System.Drawing.Point(725, 65);
            this.tbMaxOrder.MaxLength = 17;
            this.tbMaxOrder.Name = "tbMaxOrder";
            this.tbMaxOrder.Size = new System.Drawing.Size(127, 20);
            this.tbMaxOrder.TabIndex = 11;
            this.tbMaxOrder.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbMaxOrder.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbDecimal_KeyPress);
            this.tbMaxOrder.Validating += new System.ComponentModel.CancelEventHandler(this.tbMinOrder_Validating);
            // 
            // lStep
            // 
            this.lStep.AutoSize = true;
            this.lStep.Location = new System.Drawing.Point(467, 95);
            this.lStep.Name = "lStep";
            this.lStep.Size = new System.Drawing.Size(252, 13);
            this.lStep.TabIndex = 10;
            this.lStep.Text = "Возможный шаг количества при заказе товара:";
            // 
            // tbStep
            // 
            this.tbStep.Location = new System.Drawing.Point(725, 91);
            this.tbStep.MaxLength = 17;
            this.tbStep.Name = "tbStep";
            this.tbStep.Size = new System.Drawing.Size(127, 20);
            this.tbStep.TabIndex = 11;
            this.tbStep.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbStep.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbDecimal_KeyPress);
            this.tbStep.Validating += new System.ComponentModel.CancelEventHandler(this.tbMinOrder_Validating);
            // 
            // lDefaultNetto
            // 
            this.lDefaultNetto.AutoSize = true;
            this.lDefaultNetto.Location = new System.Drawing.Point(484, 121);
            this.lDefaultNetto.Name = "lDefaultNetto";
            this.lDefaultNetto.Size = new System.Drawing.Size(235, 13);
            this.lDefaultNetto.TabIndex = 10;
            this.lDefaultNetto.Text = "Значение заказанного товара по умолчанию";
            // 
            // tbDefaultNetto
            // 
            this.tbDefaultNetto.Location = new System.Drawing.Point(725, 117);
            this.tbDefaultNetto.MaxLength = 17;
            this.tbDefaultNetto.Name = "tbDefaultNetto";
            this.tbDefaultNetto.Size = new System.Drawing.Size(127, 20);
            this.tbDefaultNetto.TabIndex = 11;
            this.tbDefaultNetto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbDefaultNetto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbDecimal_KeyPress);
            this.tbDefaultNetto.Validating += new System.ComponentModel.CancelEventHandler(this.tbMinOrder_Validating);
            // 
            // lPriceSuffix
            // 
            this.lPriceSuffix.AutoSize = true;
            this.lPriceSuffix.Location = new System.Drawing.Point(529, 146);
            this.lPriceSuffix.Name = "lPriceSuffix";
            this.lPriceSuffix.Size = new System.Drawing.Size(130, 13);
            this.lPriceSuffix.TabIndex = 10;
            this.lPriceSuffix.Text = "Суффикс к цене товара:";
            // 
            // tbPriceSuffix
            // 
            this.tbPriceSuffix.Location = new System.Drawing.Point(665, 143);
            this.tbPriceSuffix.MaxLength = 500;
            this.tbPriceSuffix.Multiline = true;
            this.tbPriceSuffix.Name = "tbPriceSuffix";
            this.tbPriceSuffix.Size = new System.Drawing.Size(187, 55);
            this.tbPriceSuffix.TabIndex = 11;
            this.tbPriceSuffix.Text = "за 1 кг";
            this.tbPriceSuffix.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lQuantitySuffix
            // 
            this.lQuantitySuffix.AutoSize = true;
            this.lQuantitySuffix.Location = new System.Drawing.Point(496, 208);
            this.lQuantitySuffix.Name = "lQuantitySuffix";
            this.lQuantitySuffix.Size = new System.Drawing.Size(163, 13);
            this.lQuantitySuffix.TabIndex = 10;
            this.lQuantitySuffix.Text = "Суффикс к количеству товара:";
            // 
            // tbQuantitySuffix
            // 
            this.tbQuantitySuffix.Location = new System.Drawing.Point(665, 205);
            this.tbQuantitySuffix.MaxLength = 500;
            this.tbQuantitySuffix.Multiline = true;
            this.tbQuantitySuffix.Name = "tbQuantitySuffix";
            this.tbQuantitySuffix.Size = new System.Drawing.Size(187, 72);
            this.tbQuantitySuffix.TabIndex = 11;
            this.tbQuantitySuffix.Text = "итоговый вес заказа может отличаться на +/- 100 гр.";
            this.tbQuantitySuffix.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(55, 389);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Цена продажи онлайн:";
            // 
            // tbPricePercent
            // 
            this.tbPricePercent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbPricePercent.Location = new System.Drawing.Point(183, 386);
            this.tbPricePercent.MaxLength = 17;
            this.tbPricePercent.Name = "tbPricePercent";
            this.tbPricePercent.Size = new System.Drawing.Size(130, 20);
            this.tbPricePercent.TabIndex = 16;
            this.tbPricePercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbPricePercent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbDecimal_KeyPress);
            this.tbPricePercent.Validating += new System.ComponentModel.CancelEventHandler(this.tbRcena_Validating);
            // 
            // tbShortDescription
            // 
            this.tbShortDescription.Location = new System.Drawing.Point(183, 182);
            this.tbShortDescription.MaxLength = 1000;
            this.tbShortDescription.Multiline = true;
            this.tbShortDescription.Name = "tbShortDescription";
            this.tbShortDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbShortDescription.Size = new System.Drawing.Size(262, 82);
            this.tbShortDescription.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(30, 185);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(147, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Короткое описание товара:";
            // 
            // tbNameCategory
            // 
            this.tbNameCategory.Location = new System.Drawing.Point(183, 270);
            this.tbNameCategory.MaxLength = 253451;
            this.tbNameCategory.Multiline = true;
            this.tbNameCategory.Name = "tbNameCategory";
            this.tbNameCategory.ReadOnly = true;
            this.tbNameCategory.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbNameCategory.Size = new System.Drawing.Size(262, 80);
            this.tbNameCategory.TabIndex = 19;
            // 
            // btAddCategory
            // 
            this.btAddCategory.Image = global::OnlineStore.Properties.Resources.edit_1761;
            this.btAddCategory.Location = new System.Drawing.Point(148, 318);
            this.btAddCategory.Name = "btAddCategory";
            this.btAddCategory.Size = new System.Drawing.Size(32, 32);
            this.btAddCategory.TabIndex = 20;
            this.btAddCategory.UseVisualStyleBackColor = true;
            this.btAddCategory.Click += new System.EventHandler(this.BtAddCategory_Click);
            // 
            // frmAddTovar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 467);
            this.ControlBox = false;
            this.Controls.Add(this.btAddCategory);
            this.Controls.Add(this.tbNameCategory);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbShortDescription);
            this.Controls.Add(this.tbPricePercent);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.chbActive);
            this.Controls.Add(this.cmbParentCategory);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbFullName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbActionPrice);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbQuantitySuffix);
            this.Controls.Add(this.lQuantitySuffix);
            this.Controls.Add(this.tbPriceSuffix);
            this.Controls.Add(this.lPriceSuffix);
            this.Controls.Add(this.tbDefaultNetto);
            this.Controls.Add(this.lDefaultNetto);
            this.Controls.Add(this.tbStep);
            this.Controls.Add(this.lStep);
            this.Controls.Add(this.tbMaxOrder);
            this.Controls.Add(this.lMaxOrder);
            this.Controls.Add(this.tbMinOrder);
            this.Controls.Add(this.lMinOrder);
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
        private System.Windows.Forms.Label lMinOrder;
        private System.Windows.Forms.TextBox tbMinOrder;
        private System.Windows.Forms.Label lMaxOrder;
        private System.Windows.Forms.TextBox tbMaxOrder;
        private System.Windows.Forms.Label lStep;
        private System.Windows.Forms.TextBox tbStep;
        private System.Windows.Forms.Label lDefaultNetto;
        private System.Windows.Forms.TextBox tbDefaultNetto;
        private System.Windows.Forms.Label lPriceSuffix;
        private System.Windows.Forms.TextBox tbPriceSuffix;
        private System.Windows.Forms.Label lQuantitySuffix;
        private System.Windows.Forms.TextBox tbQuantitySuffix;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbPricePercent;
        private System.Windows.Forms.TextBox tbShortDescription;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbNameCategory;
        private System.Windows.Forms.Button btAddCategory;
    }
}