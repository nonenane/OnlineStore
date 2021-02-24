namespace OnlineStore
{
    partial class frmSettings
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
            this.rbImgTovar = new System.Windows.Forms.RadioButton();
            this.rbImgCat = new System.Windows.Forms.RadioButton();
            this.rbWithoutImage = new System.Windows.Forms.RadioButton();
            this.tbSizeFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rbImgTovar
            // 
            this.rbImgTovar.AutoSize = true;
            this.rbImgTovar.Location = new System.Drawing.Point(12, 58);
            this.rbImgTovar.Name = "rbImgTovar";
            this.rbImgTovar.Size = new System.Drawing.Size(139, 17);
            this.rbImgTovar.TabIndex = 4;
            this.rbImgTovar.Text = "с картинкой по товару";
            this.rbImgTovar.UseVisualStyleBackColor = true;
            this.rbImgTovar.CheckedChanged += new System.EventHandler(this.rbImgTovar_CheckedChanged);
            // 
            // rbImgCat
            // 
            this.rbImgCat.AutoSize = true;
            this.rbImgCat.Location = new System.Drawing.Point(12, 35);
            this.rbImgCat.Name = "rbImgCat";
            this.rbImgCat.Size = new System.Drawing.Size(123, 17);
            this.rbImgCat.TabIndex = 5;
            this.rbImgCat.Text = "с общей картинкой";
            this.rbImgCat.UseVisualStyleBackColor = true;
            this.rbImgCat.CheckedChanged += new System.EventHandler(this.rbImgCat_CheckedChanged);
            // 
            // rbWithoutImage
            // 
            this.rbWithoutImage.AutoSize = true;
            this.rbWithoutImage.Checked = true;
            this.rbWithoutImage.Location = new System.Drawing.Point(12, 12);
            this.rbWithoutImage.Name = "rbWithoutImage";
            this.rbWithoutImage.Size = new System.Drawing.Size(93, 17);
            this.rbWithoutImage.TabIndex = 6;
            this.rbWithoutImage.TabStop = true;
            this.rbWithoutImage.Text = "без картинки";
            this.rbWithoutImage.UseVisualStyleBackColor = true;
            this.rbWithoutImage.CheckedChanged += new System.EventHandler(this.rbWithoutImage_CheckedChanged);
            // 
            // tbSizeFile
            // 
            this.tbSizeFile.Location = new System.Drawing.Point(12, 82);
            this.tbSizeFile.Name = "tbSizeFile";
            this.tbSizeFile.Size = new System.Drawing.Size(44, 20);
            this.tbSizeFile.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "файл выгрузки, Мб";
            // 
            // btExit
            // 
            this.btExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btExit.Image = global::OnlineStore.Properties.Resources.pngExit;
            this.btExit.Location = new System.Drawing.Point(185, 99);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(32, 32);
            this.btExit.TabIndex = 1;
            this.btExit.UseVisualStyleBackColor = true;
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(229, 143);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbSizeFile);
            this.Controls.Add(this.rbWithoutImage);
            this.Controls.Add(this.rbImgCat);
            this.Controls.Add(this.rbImgTovar);
            this.Controls.Add(this.btExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройки";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btExit;
        private System.Windows.Forms.RadioButton rbImgTovar;
        private System.Windows.Forms.RadioButton rbImgCat;
        private System.Windows.Forms.RadioButton rbWithoutImage;
        private System.Windows.Forms.TextBox tbSizeFile;
        private System.Windows.Forms.Label label1;
    }
}