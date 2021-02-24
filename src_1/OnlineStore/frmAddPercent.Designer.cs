namespace OnlineStore
{
    partial class frmAddPercent
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbMakeUpPercent = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbDiscount = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btSave
            // 
            this.btSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSave.BackColor = System.Drawing.Color.White;
            this.btSave.Image = global::OnlineStore.Properties.Resources.filesave_2175;
            this.btSave.Location = new System.Drawing.Point(322, 112);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(32, 32);
            this.btSave.TabIndex = 15;
            this.btSave.UseVisualStyleBackColor = false;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.BackColor = System.Drawing.Color.White;
            this.btClose.Image = global::OnlineStore.Properties.Resources.pngExit;
            this.btClose.Location = new System.Drawing.Point(360, 112);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(32, 32);
            this.btClose.TabIndex = 15;
            this.btClose.UseVisualStyleBackColor = false;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Наименование";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(142, 6);
            this.tbName.Multiline = true;
            this.tbName.Name = "tbName";
            this.tbName.ReadOnly = true;
            this.tbName.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbName.Size = new System.Drawing.Size(250, 57);
            this.tbName.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Процент наценки";
            // 
            // tbMakeUpPercent
            // 
            this.tbMakeUpPercent.Location = new System.Drawing.Point(142, 69);
            this.tbMakeUpPercent.MaxLength = 6;
            this.tbMakeUpPercent.Name = "tbMakeUpPercent";
            this.tbMakeUpPercent.Size = new System.Drawing.Size(121, 20);
            this.tbMakeUpPercent.TabIndex = 17;
            this.tbMakeUpPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbMakeUpPercent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbMakeUpPercent_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Процент распродажи";
            // 
            // tbDiscount
            // 
            this.tbDiscount.Location = new System.Drawing.Point(142, 95);
            this.tbDiscount.MaxLength = 6;
            this.tbDiscount.Name = "tbDiscount";
            this.tbDiscount.Size = new System.Drawing.Size(121, 20);
            this.tbDiscount.TabIndex = 17;
            this.tbDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbDiscount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbMakeUpPercent_KeyPress);
            // 
            // frmAddPercent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 156);
            this.ControlBox = false;
            this.Controls.Add(this.tbDiscount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbMakeUpPercent);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.btClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddPercent";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddPercent";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAddPercent_FormClosing);
            this.Load += new System.EventHandler(this.frmAddPercent_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbMakeUpPercent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbDiscount;
    }
}