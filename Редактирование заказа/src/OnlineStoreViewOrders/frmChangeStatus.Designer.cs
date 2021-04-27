namespace OnlineStoreViewOrders
{
    partial class frmChangeStatus
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
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.tbComment = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btClose = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.btDeliversMan = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbNameDelivery = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tbNameKassCheck = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbNameCollector = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbSumma
            // 
            this.tbSumma.Location = new System.Drawing.Point(132, 38);
            this.tbSumma.MaxLength = 8;
            this.tbSumma.Name = "tbSumma";
            this.tbSumma.Size = new System.Drawing.Size(71, 20);
            this.tbSumma.TabIndex = 12;
            this.tbSumma.Text = "0.00";
            this.tbSumma.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbSumma.TextChanged += new System.EventHandler(this.tbKass_TextChanged);
            this.tbSumma.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbKass_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Затраты на доставку";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Дата доставки";
            // 
            // dtpDate
            // 
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(132, 12);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(98, 20);
            this.dtpDate.TabIndex = 9;
            this.dtpDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Комментарий";
            // 
            // tbComment
            // 
            this.tbComment.Location = new System.Drawing.Point(15, 87);
            this.tbComment.MaxLength = 1054;
            this.tbComment.Multiline = true;
            this.tbComment.Name = "tbComment";
            this.tbComment.Size = new System.Drawing.Size(305, 72);
            this.tbComment.TabIndex = 12;
            this.tbComment.TextChanged += new System.EventHandler(this.tbKass_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(209, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "руб.";
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.Image = global::OnlineStoreViewOrders.Properties.Resources.pngExit;
            this.btClose.Location = new System.Drawing.Point(288, 282);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(32, 32);
            this.btClose.TabIndex = 13;
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btSave
            // 
            this.btSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSave.Image = global::OnlineStoreViewOrders.Properties.Resources.pngGALOCHKA;
            this.btSave.Location = new System.Drawing.Point(250, 282);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(32, 32);
            this.btSave.TabIndex = 8;
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btDeliversMan
            // 
            this.btDeliversMan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btDeliversMan.BackColor = System.Drawing.SystemColors.Control;
            this.btDeliversMan.Image = global::OnlineStoreViewOrders.Properties.Resources.x_office_spreadsheet1;
            this.btDeliversMan.Location = new System.Drawing.Point(12, 282);
            this.btDeliversMan.Name = "btDeliversMan";
            this.btDeliversMan.Size = new System.Drawing.Size(32, 32);
            this.btDeliversMan.TabIndex = 39;
            this.btDeliversMan.UseVisualStyleBackColor = false;
            this.btDeliversMan.Click += new System.EventHandler(this.BtDeliversMan_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbNameDelivery);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.tbNameKassCheck);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.tbNameCollector);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Location = new System.Drawing.Point(15, 165);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(309, 110);
            this.groupBox2.TabIndex = 38;
            this.groupBox2.TabStop = false;
            // 
            // tbNameDelivery
            // 
            this.tbNameDelivery.Location = new System.Drawing.Point(78, 71);
            this.tbNameDelivery.Name = "tbNameDelivery";
            this.tbNameDelivery.ReadOnly = true;
            this.tbNameDelivery.Size = new System.Drawing.Size(212, 20);
            this.tbNameDelivery.TabIndex = 38;
            this.tbNameDelivery.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 75);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(66, 13);
            this.label13.TabIndex = 37;
            this.label13.Text = "Доставщик";
            this.label13.Visible = false;
            // 
            // tbNameKassCheck
            // 
            this.tbNameKassCheck.Location = new System.Drawing.Point(78, 45);
            this.tbNameKassCheck.Name = "tbNameKassCheck";
            this.tbNameKassCheck.ReadOnly = true;
            this.tbNameKassCheck.Size = new System.Drawing.Size(212, 20);
            this.tbNameKassCheck.TabIndex = 38;
            this.tbNameKassCheck.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 49);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 13);
            this.label12.TabIndex = 37;
            this.label12.Text = "Пробитие";
            this.label12.Visible = false;
            // 
            // tbNameCollector
            // 
            this.tbNameCollector.Location = new System.Drawing.Point(78, 20);
            this.tbNameCollector.Name = "tbNameCollector";
            this.tbNameCollector.ReadOnly = true;
            this.tbNameCollector.Size = new System.Drawing.Size(212, 20);
            this.tbNameCollector.TabIndex = 38;
            this.tbNameCollector.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 13);
            this.label11.TabIndex = 37;
            this.label11.Text = "Сборщик";
            this.label11.Visible = false;
            // 
            // frmChangeStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 319);
            this.ControlBox = false;
            this.Controls.Add(this.btDeliversMan);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.tbComment);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbSumma);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.btSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChangeStatus";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmChangeStatus";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmChangeStatus_FormClosing);
            this.Load += new System.EventHandler(this.frmChangeStatus_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.TextBox tbSumma;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbComment;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btDeliversMan;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbNameDelivery;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbNameKassCheck;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbNameCollector;
        private System.Windows.Forms.Label label11;
    }
}