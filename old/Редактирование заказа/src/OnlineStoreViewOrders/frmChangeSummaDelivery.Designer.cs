namespace OnlineStoreViewOrders
{
    partial class frmChangeSummaDelivery
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
            this.tbSumma = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btClose = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpPlanDeliveryDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbUserDelivery = new System.Windows.Forms.RadioButton();
            this.rbDelivery = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.tbAddress = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbSumma
            // 
            this.tbSumma.Location = new System.Drawing.Point(188, 91);
            this.tbSumma.MaxLength = 8;
            this.tbSumma.Name = "tbSumma";
            this.tbSumma.Size = new System.Drawing.Size(71, 20);
            this.tbSumma.TabIndex = 17;
            this.tbSumma.Text = "0.00";
            this.tbSumma.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbSumma.TextChanged += new System.EventHandler(this.TbSumma_TextChanged);
            this.tbSumma.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSumma_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(265, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "руб.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Стоимость доставки";
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.Image = global::OnlineStoreViewOrders.Properties.Resources.pngExit;
            this.btClose.Location = new System.Drawing.Point(260, 269);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(32, 32);
            this.btClose.TabIndex = 18;
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // btSave
            // 
            this.btSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSave.Image = global::OnlineStoreViewOrders.Properties.Resources.pngGALOCHKA;
            this.btSave.Location = new System.Drawing.Point(222, 269);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(32, 32);
            this.btSave.TabIndex = 14;
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Предполагаемая дата доставки";
            // 
            // dtpPlanDeliveryDate
            // 
            this.dtpPlanDeliveryDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPlanDeliveryDate.Location = new System.Drawing.Point(188, 12);
            this.dtpPlanDeliveryDate.Name = "dtpPlanDeliveryDate";
            this.dtpPlanDeliveryDate.Size = new System.Drawing.Size(104, 20);
            this.dtpPlanDeliveryDate.TabIndex = 19;
            this.dtpPlanDeliveryDate.ValueChanged += new System.EventHandler(this.DtpPlanDeliveryDate_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbUserDelivery);
            this.groupBox1.Controls.Add(this.rbDelivery);
            this.groupBox1.Location = new System.Drawing.Point(14, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(278, 47);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Тип доставки";
            // 
            // rbUserDelivery
            // 
            this.rbUserDelivery.AutoSize = true;
            this.rbUserDelivery.Location = new System.Drawing.Point(132, 19);
            this.rbUserDelivery.Name = "rbUserDelivery";
            this.rbUserDelivery.Size = new System.Drawing.Size(84, 17);
            this.rbUserDelivery.TabIndex = 0;
            this.rbUserDelivery.Text = "Самовывоз";
            this.rbUserDelivery.UseVisualStyleBackColor = true;
            this.rbUserDelivery.Click += new System.EventHandler(this.RbUserDelivery_Click);
            // 
            // rbDelivery
            // 
            this.rbDelivery.AutoSize = true;
            this.rbDelivery.Checked = true;
            this.rbDelivery.Location = new System.Drawing.Point(24, 19);
            this.rbDelivery.Name = "rbDelivery";
            this.rbDelivery.Size = new System.Drawing.Size(78, 17);
            this.rbDelivery.TabIndex = 0;
            this.rbDelivery.TabStop = true;
            this.rbDelivery.Text = "Доставка ";
            this.rbDelivery.UseVisualStyleBackColor = true;
            this.rbDelivery.CheckedChanged += new System.EventHandler(this.RbDelivery_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Адрес доставки";
            // 
            // tbAddress
            // 
            this.tbAddress.Location = new System.Drawing.Point(12, 137);
            this.tbAddress.Multiline = true;
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.Size = new System.Drawing.Size(277, 126);
            this.tbAddress.TabIndex = 22;
            this.tbAddress.TextChanged += new System.EventHandler(this.TbAddress_TextChanged);
            // 
            // frmChangeSummaDelivery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 307);
            this.ControlBox = false;
            this.Controls.Add(this.tbAddress);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dtpPlanDeliveryDate);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.tbSumma);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChangeSummaDelivery";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmChangeSummaDelivery";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmChangeSummaDelivery_FormClosing);
            this.Load += new System.EventHandler(this.frmChangeSummaDelivery_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.TextBox tbSumma;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpPlanDeliveryDate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbUserDelivery;
        private System.Windows.Forms.RadioButton rbDelivery;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbAddress;
    }
}