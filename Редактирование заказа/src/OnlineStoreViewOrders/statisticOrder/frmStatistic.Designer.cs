namespace OnlineStoreViewOrders.statisticOrder
{
    partial class frmStatistic
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStatistic));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.button2 = new System.Windows.Forms.Button();
            this.btDataStatistic = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tbNameTovar = new System.Windows.Forms.TextBox();
            this.tbEan = new System.Windows.Forms.TextBox();
            this.dgvDataTovar = new System.Windows.Forms.DataGridView();
            this.cPeriod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cEan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNameTovar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPrcPopular = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbPercentOrder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDeps = new System.Windows.Forms.ComboBox();
            this.cmbPeriod = new System.Windows.Forms.ComboBox();
            this.btPrintPopularTovar = new System.Windows.Forms.Button();
            this.btGetDataPopularTovar = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.dgvPeriod = new System.Windows.Forms.DataGridView();
            this.cName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDateStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDateEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataTovar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeriod)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1175, 582);
            this.tabControl1.TabIndex = 18;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvPeriod);
            this.tabPage1.Controls.Add(this.radioButton2);
            this.tabPage1.Controls.Add(this.radioButton1);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.btDataStatistic);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.chart1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1167, 556);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Статистика";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.Location = new System.Drawing.Point(165, 38);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(68, 17);
            this.radioButton2.TabIndex = 23;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Таблица";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(165, 15);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(85, 17);
            this.radioButton1.TabIndex = 23;
            this.radioButton1.Text = "Диаграмма";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.Image = global::OnlineStoreViewOrders.Properties.Resources.pngPrint;
            this.button2.Location = new System.Drawing.Point(55, 15);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(42, 42);
            this.button2.TabIndex = 21;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // btDataStatistic
            // 
            this.btDataStatistic.BackColor = System.Drawing.Color.Transparent;
            this.btDataStatistic.Image = global::OnlineStoreViewOrders.Properties.Resources.iconfinder_download_4341287_120571;
            this.btDataStatistic.Location = new System.Drawing.Point(7, 15);
            this.btDataStatistic.Name = "btDataStatistic";
            this.btDataStatistic.Size = new System.Drawing.Size(42, 42);
            this.btDataStatistic.TabIndex = 22;
            this.btDataStatistic.UseVisualStyleBackColor = false;
            this.btDataStatistic.Click += new System.EventHandler(this.btDataStatistic_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.radioButton3);
            this.groupBox3.Controls.Add(this.radioButton4);
            this.groupBox3.Location = new System.Drawing.Point(974, 294);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(185, 77);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Тип диаграммы";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Checked = true;
            this.radioButton3.Location = new System.Drawing.Point(6, 42);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(71, 17);
            this.radioButton3.TabIndex = 24;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Периоды";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(6, 19);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(84, 17);
            this.radioButton4.TabIndex = 25;
            this.radioButton4.Text = "Параметры";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.panel6);
            this.groupBox2.Controls.Add(this.panel5);
            this.groupBox2.Controls.Add(this.panel4);
            this.groupBox2.Controls.Add(this.panel3);
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Controls.Add(this.checkBox6);
            this.groupBox2.Controls.Add(this.checkBox5);
            this.groupBox2.Controls.Add(this.checkBox4);
            this.groupBox2.Controls.Add(this.checkBox3);
            this.groupBox2.Controls.Add(this.checkBox2);
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Location = new System.Drawing.Point(974, 124);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(185, 164);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Настройки легенды";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Yellow;
            this.panel6.Location = new System.Drawing.Point(10, 133);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(19, 19);
            this.panel6.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(80)))));
            this.panel5.Location = new System.Drawing.Point(10, 110);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(19, 19);
            this.panel5.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            this.panel4.Location = new System.Drawing.Point(10, 87);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(19, 19);
            this.panel4.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(112)))), ((int)(((byte)(192)))));
            this.panel3.Location = new System.Drawing.Point(10, 64);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(19, 19);
            this.panel3.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.panel2.Location = new System.Drawing.Point(10, 41);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(19, 19);
            this.panel2.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(240)))));
            this.panel1.Location = new System.Drawing.Point(10, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(19, 19);
            this.panel1.TabIndex = 1;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(35, 134);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(73, 17);
            this.checkBox6.TabIndex = 0;
            this.checkBox6.Text = "∆ по чеку";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(35, 111);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(133, 17);
            this.checkBox5.TabIndex = 0;
            this.checkBox5.Text = "Остаток по доставке";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(35, 88);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(133, 17);
            this.checkBox4.TabIndex = 0;
            this.checkBox4.Text = "Затраты на доставку";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(35, 65);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(131, 17);
            this.checkBox3.TabIndex = 0;
            this.checkBox3.Text = "Стоимость доставки";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(35, 42);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(105, 17);
            this.checkBox2.TabIndex = 0;
            this.checkBox2.Text = "Сумма заказов";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(35, 19);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(105, 17);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Кол-во заказов";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Location = new System.Drawing.Point(515, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(644, 112);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Настройки периода";
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.BackColor = System.Drawing.Color.White;
            this.button4.Image = global::OnlineStoreViewOrders.Properties.Resources.pngAdd;
            this.button4.Location = new System.Drawing.Point(595, 43);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(32, 32);
            this.button4.TabIndex = 24;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(8, 124);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Fire;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(960, 426);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tbNameTovar);
            this.tabPage2.Controls.Add(this.tbEan);
            this.tabPage2.Controls.Add(this.dgvDataTovar);
            this.tabPage2.Controls.Add(this.tbPercentOrder);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.cmbDeps);
            this.tabPage2.Controls.Add(this.cmbPeriod);
            this.tabPage2.Controls.Add(this.btPrintPopularTovar);
            this.tabPage2.Controls.Add(this.btGetDataPopularTovar);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1167, 556);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Популярные товары";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tbNameTovar
            // 
            this.tbNameTovar.Location = new System.Drawing.Point(201, 68);
            this.tbNameTovar.MaxLength = 150;
            this.tbNameTovar.Name = "tbNameTovar";
            this.tbNameTovar.Size = new System.Drawing.Size(187, 20);
            this.tbNameTovar.TabIndex = 27;
            this.tbNameTovar.TextChanged += new System.EventHandler(this.tbEan_TextChanged);
            // 
            // tbEan
            // 
            this.tbEan.Location = new System.Drawing.Point(8, 68);
            this.tbEan.MaxLength = 13;
            this.tbEan.Name = "tbEan";
            this.tbEan.Size = new System.Drawing.Size(187, 20);
            this.tbEan.TabIndex = 26;
            this.tbEan.TextChanged += new System.EventHandler(this.tbEan_TextChanged);
            // 
            // dgvDataTovar
            // 
            this.dgvDataTovar.AllowUserToAddRows = false;
            this.dgvDataTovar.AllowUserToDeleteRows = false;
            this.dgvDataTovar.AllowUserToResizeRows = false;
            this.dgvDataTovar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDataTovar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDataTovar.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDataTovar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDataTovar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataTovar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cPeriod,
            this.cEan,
            this.cNameTovar,
            this.cPrice,
            this.cCount,
            this.cPrcPopular});
            this.dgvDataTovar.Location = new System.Drawing.Point(8, 94);
            this.dgvDataTovar.MultiSelect = false;
            this.dgvDataTovar.Name = "dgvDataTovar";
            this.dgvDataTovar.ReadOnly = true;
            this.dgvDataTovar.RowHeadersVisible = false;
            this.dgvDataTovar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDataTovar.ShowCellErrors = false;
            this.dgvDataTovar.ShowCellToolTips = false;
            this.dgvDataTovar.ShowEditingIcon = false;
            this.dgvDataTovar.ShowRowErrors = false;
            this.dgvDataTovar.Size = new System.Drawing.Size(1151, 456);
            this.dgvDataTovar.TabIndex = 25;
            this.dgvDataTovar.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgvDataTovar_ColumnWidthChanged);
            // 
            // cPeriod
            // 
            this.cPeriod.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cPeriod.DataPropertyName = "namePeriod";
            this.cPeriod.HeaderText = "Период";
            this.cPeriod.MinimumWidth = 140;
            this.cPeriod.Name = "cPeriod";
            this.cPeriod.ReadOnly = true;
            this.cPeriod.Width = 150;
            // 
            // cEan
            // 
            this.cEan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cEan.DataPropertyName = "ean";
            this.cEan.HeaderText = "EAN";
            this.cEan.MinimumWidth = 110;
            this.cEan.Name = "cEan";
            this.cEan.ReadOnly = true;
            this.cEan.Width = 110;
            // 
            // cNameTovar
            // 
            this.cNameTovar.DataPropertyName = "cName";
            this.cNameTovar.FillWeight = 152.2843F;
            this.cNameTovar.HeaderText = "Наименование товара";
            this.cNameTovar.Name = "cNameTovar";
            this.cNameTovar.ReadOnly = true;
            // 
            // cPrice
            // 
            this.cPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cPrice.DataPropertyName = "midPrice";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.cPrice.DefaultCellStyle = dataGridViewCellStyle3;
            this.cPrice.HeaderText = "Средняя цена продажи";
            this.cPrice.MinimumWidth = 80;
            this.cPrice.Name = "cPrice";
            this.cPrice.ReadOnly = true;
            this.cPrice.Width = 80;
            // 
            // cCount
            // 
            this.cCount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cCount.DataPropertyName = "countTovar";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.cCount.DefaultCellStyle = dataGridViewCellStyle4;
            this.cCount.HeaderText = "Кол-во";
            this.cCount.MinimumWidth = 80;
            this.cCount.Name = "cCount";
            this.cCount.ReadOnly = true;
            this.cCount.Width = 80;
            // 
            // cPrcPopular
            // 
            this.cPrcPopular.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cPrcPopular.DataPropertyName = "prcBuy";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.cPrcPopular.DefaultCellStyle = dataGridViewCellStyle5;
            this.cPrcPopular.HeaderText = "Процент популярности";
            this.cPrcPopular.MinimumWidth = 80;
            this.cPrcPopular.Name = "cPrcPopular";
            this.cPrcPopular.ReadOnly = true;
            this.cPrcPopular.Width = 80;
            // 
            // tbPercentOrder
            // 
            this.tbPercentOrder.Location = new System.Drawing.Point(516, 13);
            this.tbPercentOrder.Name = "tbPercentOrder";
            this.tbPercentOrder.Size = new System.Drawing.Size(43, 20);
            this.tbPercentOrder.TabIndex = 22;
            this.tbPercentOrder.Text = "30,00";
            this.tbPercentOrder.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbPercentOrder.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPercentOrder_KeyPress);
            this.tbPercentOrder.Leave += new System.EventHandler(this.tbPercentOrder_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(376, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Доля заказов с товаром";
            // 
            // cmbDeps
            // 
            this.cmbDeps.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDeps.FormattingEnabled = true;
            this.cmbDeps.Location = new System.Drawing.Point(130, 40);
            this.cmbDeps.Name = "cmbDeps";
            this.cmbDeps.Size = new System.Drawing.Size(240, 21);
            this.cmbDeps.TabIndex = 20;
            this.cmbDeps.SelectionChangeCommitted += new System.EventHandler(this.cmbDeps_SelectionChangeCommitted);
            // 
            // cmbPeriod
            // 
            this.cmbPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPeriod.FormattingEnabled = true;
            this.cmbPeriod.Location = new System.Drawing.Point(130, 13);
            this.cmbPeriod.Name = "cmbPeriod";
            this.cmbPeriod.Size = new System.Drawing.Size(240, 21);
            this.cmbPeriod.TabIndex = 20;
            // 
            // btPrintPopularTovar
            // 
            this.btPrintPopularTovar.BackColor = System.Drawing.Color.Transparent;
            this.btPrintPopularTovar.Image = global::OnlineStoreViewOrders.Properties.Resources.pngPrint;
            this.btPrintPopularTovar.Location = new System.Drawing.Point(65, 13);
            this.btPrintPopularTovar.Name = "btPrintPopularTovar";
            this.btPrintPopularTovar.Size = new System.Drawing.Size(42, 42);
            this.btPrintPopularTovar.TabIndex = 19;
            this.btPrintPopularTovar.UseVisualStyleBackColor = false;
            this.btPrintPopularTovar.Click += new System.EventHandler(this.btPrintPopularTovar_Click);
            // 
            // btGetDataPopularTovar
            // 
            this.btGetDataPopularTovar.BackColor = System.Drawing.Color.Transparent;
            this.btGetDataPopularTovar.Image = global::OnlineStoreViewOrders.Properties.Resources.iconfinder_download_4341287_120571;
            this.btGetDataPopularTovar.Location = new System.Drawing.Point(17, 13);
            this.btGetDataPopularTovar.Name = "btGetDataPopularTovar";
            this.btGetDataPopularTovar.Size = new System.Drawing.Size(42, 42);
            this.btGetDataPopularTovar.TabIndex = 19;
            this.btGetDataPopularTovar.UseVisualStyleBackColor = false;
            this.btGetDataPopularTovar.Click += new System.EventHandler(this.btGetDataPopularTovar_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.White;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.Location = new System.Drawing.Point(1131, 588);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(32, 32);
            this.btnExit.TabIndex = 17;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // dgvPeriod
            // 
            this.dgvPeriod.AllowUserToAddRows = false;
            this.dgvPeriod.AllowUserToDeleteRows = false;
            this.dgvPeriod.AllowUserToResizeRows = false;
            this.dgvPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPeriod.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPeriod.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPeriod.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPeriod.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPeriod.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cName,
            this.cDateStart,
            this.cDateEnd,
            this.cColor});
            this.dgvPeriod.Location = new System.Drawing.Point(521, 25);
            this.dgvPeriod.MultiSelect = false;
            this.dgvPeriod.Name = "dgvPeriod";
            this.dgvPeriod.ReadOnly = true;
            this.dgvPeriod.RowHeadersVisible = false;
            this.dgvPeriod.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPeriod.ShowCellErrors = false;
            this.dgvPeriod.ShowCellToolTips = false;
            this.dgvPeriod.ShowEditingIcon = false;
            this.dgvPeriod.ShowRowErrors = false;
            this.dgvPeriod.Size = new System.Drawing.Size(581, 87);
            this.dgvPeriod.TabIndex = 27;
            this.dgvPeriod.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvPeriod_RowPostPaint);
            this.dgvPeriod.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvPeriod_RowPrePaint);
            // 
            // cName
            // 
            this.cName.DataPropertyName = "cName";
            this.cName.HeaderText = "Наименование";
            this.cName.Name = "cName";
            this.cName.ReadOnly = true;
            this.cName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cDateStart
            // 
            this.cDateStart.DataPropertyName = "dateStart";
            this.cDateStart.HeaderText = "Дата начала";
            this.cDateStart.Name = "cDateStart";
            this.cDateStart.ReadOnly = true;
            this.cDateStart.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cDateStart.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cDateEnd
            // 
            this.cDateEnd.DataPropertyName = "dateEnd";
            this.cDateEnd.HeaderText = "Дата окончания";
            this.cDateEnd.Name = "cDateEnd";
            this.cDateEnd.ReadOnly = true;
            this.cDateEnd.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cDateEnd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cColor
            // 
            this.cColor.HeaderText = "Цвет";
            this.cColor.Name = "cColor";
            this.cColor.ReadOnly = true;
            // 
            // frmStatistic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1175, 632);
            this.ControlBox = false;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnExit);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmStatistic";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmStatistic";
            this.Load += new System.EventHandler(this.frmStatistic_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataTovar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeriod)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button btPrintPopularTovar;
        private System.Windows.Forms.Button btGetDataPopularTovar;
        private System.Windows.Forms.ComboBox cmbDeps;
        private System.Windows.Forms.ComboBox cmbPeriod;
        private System.Windows.Forms.TextBox tbPercentOrder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbNameTovar;
        private System.Windows.Forms.TextBox tbEan;
        private System.Windows.Forms.DataGridView dgvDataTovar;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPeriod;
        private System.Windows.Forms.DataGridViewTextBoxColumn cEan;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNameTovar;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPrcPopular;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btDataStatistic;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridView dgvPeriod;
        private System.Windows.Forms.DataGridViewTextBoxColumn cName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDateStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDateEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn cColor;
    }
}