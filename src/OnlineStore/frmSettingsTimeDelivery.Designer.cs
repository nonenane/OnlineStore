namespace OnlineStore
{
    partial class frmSettingsTimeDelivery
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
            this.btExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpTimeDelivery = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btSave
            // 
            this.btSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSave.Image = global::OnlineStore.Properties.Resources.filesave_2175;
            this.btSave.Location = new System.Drawing.Point(218, 60);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(32, 32);
            this.btSave.TabIndex = 2;
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btExit
            // 
            this.btExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btExit.Image = global::OnlineStore.Properties.Resources.exit_8633;
            this.btExit.Location = new System.Drawing.Point(256, 60);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(32, 32);
            this.btExit.TabIndex = 2;
            this.btExit.UseVisualStyleBackColor = true;
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Время даты доставки*";
            // 
            // dtpTimeDelivery
            // 
            this.dtpTimeDelivery.CustomFormat = "HH:mm";
            this.dtpTimeDelivery.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTimeDelivery.Location = new System.Drawing.Point(144, 12);
            this.dtpTimeDelivery.Name = "dtpTimeDelivery";
            this.dtpTimeDelivery.ShowUpDown = true;
            this.dtpTimeDelivery.Size = new System.Drawing.Size(56, 20);
            this.dtpTimeDelivery.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 61);
            this.label2.TabIndex = 5;
            this.label2.Text = "* - при добавлении заказа после указанного времени, по умолчанию, доставка  будет" +
    " осуществляться на следующий день после заказа.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmSettingsTimeDelivery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 104);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpTimeDelivery);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.btExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSettingsTimeDelivery";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройки времени доставки";
            this.Load += new System.EventHandler(this.frmSettingsTimeDelivery_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btExit;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpTimeDelivery;
        private System.Windows.Forms.Label label2;
    }
}