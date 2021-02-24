using Nwuram.Framework.Logging;
using Nwuram.Framework.Settings.Connection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace OnlineStoreViewOrders.statisticOrder
{
    public partial class frmStatistic : Form
    {
        frmListPeriod frmLPeriod;

        public frmStatistic()
        {
            InitializeComponent();

            ToolTip tp = new ToolTip();
            tp.SetToolTip(btGetDataPopularTovar, "Рассчитать");
            tp.SetToolTip(btPrintPopularTovar, "Печать");
            tp.SetToolTip(btnExit, "Выход");

            if (Config.connect==null)
                Config.connect = new Procedures(ConnectionSettings.GetServer(), ConnectionSettings.GetDatabase(),
                    ConnectionSettings.GetUsername(), ConnectionSettings.GetPassword(), ConnectionSettings.ProgramName);

            frmLPeriod = new frmListPeriod();
            frmLPeriod.Owner = this;
            dgvDataTovar.AutoGenerateColumns = false;
            dgvPeriod.AutoGenerateColumns = false;
            dgvStatistic.AutoGenerateColumns = false;
            updatePeriod();

            chart1.Series.Clear();
            chart1.ChartAreas.Clear();
        }

        private void frmStatistic_Load(object sender, EventArgs e)
        {
            dicCheckBoxVsColumnName.Add("chbCountOrder", "cntOrder");
            dicCheckBoxVsColumnName.Add("chbSumOrder", "sumOrder");
            dicCheckBoxVsColumnName.Add("chbPriceDelivery", "SummaDelivery");
            dicCheckBoxVsColumnName.Add("chbDeliveryCost", "DeliveryCost");
            dicCheckBoxVsColumnName.Add("chbResultDelivery", "ostDelivery");
            dicCheckBoxVsColumnName.Add("chbDeltaNote", "delta");


            DataTable dtDeps = Config.connect.getDeps(true);
            cmbDeps.DataSource = dtDeps;
            cmbDeps.DisplayMember = "cName";
            cmbDeps.ValueMember = "id";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            frmLPeriod.Dispose();
            Close();
        }

        //int iina = 0;
        private void button1_Click(object sender, EventArgs e)
        {
        }

        #region "популярный товар"
        private void tbPercentOrder_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }

            if ((e.KeyChar == ',') && ((sender as TextBox).Text.ToString().Contains(e.KeyChar) || (sender as TextBox).Text.ToString().Length == 0))
            {
                e.Handled = true;
            }
            else
                if ((!Char.IsNumber(e.KeyChar) && (e.KeyChar != ',')))
            {
                if (e.KeyChar != '\b')
                { e.Handled = true; }
            }
        }

        private void dgvDataTovar_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            int width = 0;

            foreach (DataGridViewColumn col in dgvDataTovar.Columns)
            {
                if (!col.Visible) continue;

                if (col.Name.Equals(cEan.Name))
                {
                    tbEan.Location = new Point(dgvDataTovar.Location.X + 1 + width, tbEan.Location.Y);
                    tbEan.Size = new Size(cEan.Width, tbEan.Size.Height);
                }
                else if (col.Name.Equals(cNameTovar.Name))
                {
                    tbNameTovar.Location = new Point(dgvDataTovar.Location.X + 1 + width, tbEan.Location.Y);
                    tbNameTovar.Size = new Size(cNameTovar.Width, tbEan.Size.Height);
                }

                width += col.Width;
            }
        }

        private void tbPercentOrder_Leave(object sender, EventArgs e)
        {
            if (tbPercentOrder.Text.Trim().Length == 0)
                tbPercentOrder.Text = "0,00";
            else
            {
                decimal value;
                if(!decimal.TryParse(tbPercentOrder.Text,out value)) { tbPercentOrder.Text = "0,00"; return; }

                if (value > 100) { tbPercentOrder.Text = "100,00";return; }
                tbPercentOrder.Text = value.ToString("0.00");
            }
            filter();
        }

        private DataTable dtPopularTovar;
        private async void btGetDataPopularTovar_Click(object sender, EventArgs e)
        {
            dtPopularTovar = null;

            if ((dgvPeriod.DataSource as DataTable).Rows.Count == 0)
            {
                MessageBox.Show("Необходимо выбрать период выборки!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvDataTovar.DataSource = null;
                return;
            }

            var result = await Task<bool>.Factory.StartNew(() =>
            {
                Config.DoOnUIThread(() =>
            {
                blockers.SaveControlsEnabledState(this);
                blockers.SetControlsEnabled(this, false);
                progressBar1.Visible = true;
            }, this);

                foreach (DataRow row in (dgvPeriod.DataSource as DataTable).Rows)
                {
                    int id_period = (int)row["id"];
                    DateTime dateStart = (DateTime)row["dateStart"];
                    DateTime dateEnd = (DateTime)row["dateEnd"];

                    DataTable dtTmp = Config.connect.getPopularTovarInfo(dateStart, dateEnd, id_period);
                    if (dtTmp == null || dtTmp.Rows.Count == 0) continue;

                    if (dtPopularTovar == null)
                        dtPopularTovar = dtTmp.Copy();
                    else
                        dtPopularTovar.Merge(dtTmp);
                }

                Config.DoOnUIThread(() =>
                {
                    progressBar1.Visible = false;
                    blockers.RestoreControlEnabledState(this);
                    filter();
                    dgvDataTovar.DataSource = dtPopularTovar;
                }, this);
                return true;
            });
          

        }

        private void filter()
        {
            if (dtPopularTovar == null || dtPopularTovar.Rows.Count == 0)
            {
                btPrintPopularTovar.Enabled = false;
                return;
            }

            try
            {
                string filter = "";

                if ((int)cmbDeps.SelectedValue != 0)
                    filter += (filter.Length == 0 ? "" : " and ") + $"id_Departments  = {cmbDeps.SelectedValue}";

                if (tbEan.Text.Trim().Length != 0)
                    filter += (filter.Length == 0 ? "" : " and ") + $"ean like '%{tbEan.Text.Trim()}%'";
                
                if (tbNameTovar.Text.Trim().Length != 0)
                    filter += (filter.Length == 0 ? "" : " and ") + $"cName like '%{tbNameTovar.Text.Trim()}%'";

                if (tbPercentOrder.Text.Trim().Length != 0)
                    filter += (filter.Length == 0 ? "" : " and ") + $"prcBuy >= {tbPercentOrder.Text.Replace(",",".")}";


                dtPopularTovar.DefaultView.RowFilter = filter;
                dtPopularTovar.DefaultView.Sort = "id_period asc";
            }
            catch
            {
                dtPopularTovar.DefaultView.RowFilter = "id_Departments = -1";
            }
            finally
            {
                btPrintPopularTovar.Enabled = dtPopularTovar.DefaultView.Count != 0;                
            }
        }

        private void cmbDeps_SelectionChangeCommitted(object sender, EventArgs e)
        {
            filter();
        }

        private void tbEan_TextChanged(object sender, EventArgs e)
        {
            filter();
        }

        private void setWidthColumn(int indexRow, int indexCol, int width, Nwuram.Framework.ToExcelNew.ExcelUnLoad report)
        {
            report.SetColumnWidth(indexRow, indexCol, indexRow, indexCol, width);
        }

        private void btPrintPopularTovar_Click(object sender, EventArgs e)
        {
            if (dtPopularTovar == null || dtPopularTovar.DefaultView.Count == 0) return;

            Nwuram.Framework.ToExcelNew.ExcelUnLoad report = new Nwuram.Framework.ToExcelNew.ExcelUnLoad();

            int indexRow = 1;

            int maxColumns = 0;

            foreach (DataGridViewColumn col in dgvDataTovar.Columns)
                if (col.Visible)
                {
                    maxColumns++;
                    if (col.Name.Equals("cPeriod")) setWidthColumn(indexRow, maxColumns, 17, report);
                    if (col.Name.Equals("cEan")) setWidthColumn(indexRow, maxColumns, 14, report);
                    if (col.Name.Equals("cNameTovar")) setWidthColumn(indexRow, maxColumns, 36, report);
                    if (col.Name.Equals("cPrice")) setWidthColumn(indexRow, maxColumns, 13, report);
                    if (col.Name.Equals("cCount")) setWidthColumn(indexRow, maxColumns, 12, report);
                    if (col.Name.Equals("cPrcPopular")) setWidthColumn(indexRow, maxColumns, 20, report);
                }

            #region "Head"
            report.Merge(indexRow, 1, indexRow, maxColumns);
            report.AddSingleValue($"Отчёт по популярным товарам", indexRow, 1);
            report.SetFontBold(indexRow, 1, indexRow, 1);
            report.SetFontSize(indexRow, 1, indexRow, 1, 16);
            report.SetCellAlignmentToCenter(indexRow, 1, indexRow, 1);
            indexRow++;
            indexRow++;

            report.Merge(indexRow, 1, indexRow, maxColumns);
            report.AddSingleValue("Выгрузил: " + Nwuram.Framework.Settings.User.UserSettings.User.FullUsername, indexRow, 1);
            indexRow++;

            report.Merge(indexRow, 1, indexRow, maxColumns);
            report.AddSingleValue("Дата выгрузки: " + DateTime.Now.ToString(), indexRow, 1);
            indexRow++;
            indexRow++;
            #endregion

            int indexCol = 0;
            foreach (DataGridViewColumn col in dgvDataTovar.Columns)
                if (col.Visible)
                {
                    indexCol++;
                    report.AddSingleValue(col.HeaderText, indexRow, indexCol);
                }
            report.SetFontBold(indexRow, 1, indexRow, maxColumns);
            report.SetBorders(indexRow, 1, indexRow, maxColumns);
            report.SetCellAlignmentToCenter(indexRow, 1, indexRow, maxColumns);
            report.SetCellAlignmentToJustify(indexRow, 1, indexRow, maxColumns);
            report.SetWrapText(indexRow, 1, indexRow, maxColumns);
            indexRow++;

            foreach (DataRowView row in dtPopularTovar.DefaultView)
            {
                indexCol = 1;
                report.SetWrapText(indexRow, indexCol, indexRow, maxColumns);
                foreach (DataGridViewColumn col in dgvDataTovar.Columns)
                {
                    if (col.Visible)
                    {
                        if (row[col.DataPropertyName] is DateTime)
                            report.AddSingleValue(((DateTime)row[col.DataPropertyName]).ToShortDateString(), indexRow, indexCol);
                        else
                           if (row[col.DataPropertyName] is decimal)
                        {
                            report.AddSingleValueObject(row[col.DataPropertyName], indexRow, indexCol);
                            report.SetFormat(indexRow, indexCol, indexRow, indexCol, "0.00");
                        }
                        else
                            report.AddSingleValue(row[col.DataPropertyName].ToString(), indexRow, indexCol);

                        indexCol++;
                    }
                }

                report.SetBorders(indexRow, 1, indexRow, maxColumns);
                report.SetCellAlignmentToCenter(indexRow, 1, indexRow, maxColumns);
                report.SetCellAlignmentToJustify(indexRow, 1, indexRow, maxColumns);

                indexRow++;
            }

            report.Show();

            #region log
            Logging.StartFirstLevel(79);
            Logging.Comment("Произведена выгрузка статистики по онлайн магазину по популярным товарам");
            DataTable dtPeriod = dgvPeriod.DataSource as DataTable;
            int id_Period =(int) cmbPeriod.SelectedValue;
            DateTime dateStart, dateEnd;
            if (id_Period!=0)
            {
                EnumerableRowCollection<DataRow> rcoll = dtPeriod.AsEnumerable().Where(r => r.Field<int>("id") == id_Period);
                dateStart =(DateTime) rcoll.FirstOrDefault()["dateStart"];
                dateEnd = (DateTime)rcoll.FirstOrDefault()["dateEnd"];
            }
            else
            {
                dateStart = dtPeriod.AsEnumerable().Min(r => r.Field<DateTime>("dateStart"));
                dateEnd = dtPeriod.AsEnumerable().Max(r => r.Field<DateTime>("dateEnd"));
            }
            Logging.Comment($"Наименование периода: {cmbPeriod.Text}, Дата начала периода: {dateStart.ToShortDateString()}, Дата окончания периода: {dateEnd.ToShortDateString()}");
            Logging.Comment($"Отдел: id: {cmbDeps.SelectedValue.ToString()}, Наименование: {cmbDeps.Text}");
            Logging.Comment($"Доля заказов с товаром: {tbPercentOrder.Text}");
            Logging.Comment("Завершение выгрузки статистики по популярным товарам");
            Logging.StopFirstLevel();
            #endregion
        }


        #endregion

        #region "Статистика по периодам"

        Dictionary<string, string> dicCheckBoxVsColumnName = new Dictionary<string, string>();

        private void button4_Click(object sender, EventArgs e)
        {
            if (frmLPeriod.WindowState != FormWindowState.Normal)
                frmLPeriod.WindowState = FormWindowState.Normal;
            else
            frmLPeriod.Show();
        }

        public void updatePeriod()
        {
            EnumerableRowCollection<DataRow> rowCollcect = frmLPeriod.dtData.AsEnumerable().Where(r => r.Field<bool>("isSelect"));
            if (rowCollcect.Count() > 0)
                dgvPeriod.DataSource = rowCollcect.CopyToDataTable();
            else
                dgvPeriod.DataSource = frmLPeriod.dtData.Clone();

            createPeridoCombobox();
            paintGraphic();
            //frmLPeriod.Hide();
            if (this.WindowState != FormWindowState.Normal)
                this.Show();
        }

        public void createPeridoCombobox()
        {
            DataTable dtListPeriod = (dgvPeriod.DataSource as DataTable).Copy();
            DataRow newRow = dtListPeriod.NewRow();
            newRow["id"] = 0;
            newRow["cName"] = "Все периоды";
            dtListPeriod.Rows.Add(newRow);
            dtListPeriod.DefaultView.Sort = "id asc";

            cmbPeriod.DataSource = dtListPeriod;
            cmbPeriod.DisplayMember = "cName";
            cmbPeriod.ValueMember = "id";
        }

        private void dgvPeriod_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            DataTable dtData = (dgvPeriod.DataSource as DataTable);
            if (e.RowIndex != -1 && dtData != null && dtData.DefaultView.Count != 0)
            {
                Color rColor = Color.White;
                DataRowView row = dtData.DefaultView[e.RowIndex];

                dgvPeriod.Rows[e.RowIndex].DefaultCellStyle.BackColor = rColor;
                dgvPeriod.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = rColor;
                dgvPeriod.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;

                if ((int)row["r"] != -1 && (int)row["g"] != -1 && (int)row["b"] != -1)
                    dgvPeriod.Rows[e.RowIndex].Cells[cColor.Index].Style.BackColor =
                    dgvPeriod.Rows[e.RowIndex].Cells[cColor.Index].Style.SelectionBackColor = Color.FromArgb((int)row["r"], (int)row["g"], (int)row["b"]);
            }
        }

        private void dgvPeriod_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {

            DataGridView dgv = sender as DataGridView;
            //Рисуем рамку для выделеной строки
            if (dgv.Rows[e.RowIndex].Selected)
            {
                int width = dgv.Width;
                Rectangle r = dgv.GetRowDisplayRectangle(e.RowIndex, false);
                Rectangle rect = new Rectangle(r.X, r.Y, width - 1, r.Height - 1);

                ControlPaint.DrawBorder(e.Graphics, rect,
                    SystemColors.Highlight, 2, ButtonBorderStyle.Solid,
                    SystemColors.Highlight, 2, ButtonBorderStyle.Solid,
                    SystemColors.Highlight, 2, ButtonBorderStyle.Solid,
                    SystemColors.Highlight, 2, ButtonBorderStyle.Solid);
            }
        }

        private void btDataStatistic_Click(object sender, EventArgs e)
        {

            chart1.Series.Clear();
            chart1.ChartAreas.Clear();

            if ((dgvPeriod.DataSource as DataTable).Rows.Count == 0 )
            {
                MessageBox.Show("Необходимо выбрать период выборки!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return; 
            }

            getDataStastic();
            return;
            /*
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            
            chartArea.AxisY.Minimum = 0;
            chartArea.AxisY.Maximum = 3;
            chartArea.Name = "myGraph";

            chartArea.AxisX.MajorGrid.Interval = 0.1;
            chartArea.AxisY.MajorGrid.Interval = 0.1;
            chart1.ChartAreas.Add(chartArea);
            */

            chart1.ChartAreas.Add("area");

            int[] x = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
            int[] y = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };

            for (int i = 1; i <= 20; i++)
            {
                chart1.Series.Add("series" + i.ToString());
                //chart1.Series["series" + i.ToString()].Color = Color.FromArgb(255 - y[i] * 20, 0, 255 - y[i] * 10);
                if (y[i] >= 7)
                    chart1.Series["series" + i.ToString()].Color = Color.Red;
                else
                    chart1.Series["series" + i.ToString()].Color = Color.Blue;
                chart1.Series["series" + i.ToString()].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                chart1.Series["series" + i.ToString()].Points.AddXY(x[i - 1], y[i - 1]);
                chart1.Series["series" + i.ToString()].Points.AddXY(x[i], y[i]);
            }


            Random rn = new Random();


            //for (int j = 0; j < 10; j++)
            //{
            //    chart1.Series.Add(j.ToString());
            //    if (j == 0)
            //        chart1.ChartAreas.Add(j.ToString());


            //    string[] labels = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j" };
            //    int i = 0;
            //    for (double y = 0.1; y < 1; y += 0.1)
            //    {
            //        chart1.Series[j].Points.AddXY(i + 1, rn.NextDouble());
            //        if (j == 0)
            //            chart1.ChartAreas[j].AxisX.CustomLabels.Add(new CustomLabel(i, i + 2, labels[i], 0, LabelMarkStyle.Box));
            //        i++;
            //    }
            //}
            //iina++;
        }
  
        private DataTable dtDataStatic;
        private Nwuram.Framework.UI.Service.EnableControlsServiceInProg blockers = new Nwuram.Framework.UI.Service.EnableControlsServiceInProg();

        private async void getDataStastic()
        {
            dtDataStatic = null;
            DataTable dtPeriod = (dgvPeriod.DataSource as DataTable);
            var result = await Task<bool>.Factory.StartNew(() =>
            {
                Config.DoOnUIThread(() =>
                {
                    blockers.SaveControlsEnabledState(this);
                    blockers.SetControlsEnabled(this, false);
                    progressBar1.Visible = true;
                }, this);

                foreach (DataRow row in dtPeriod.Rows)
                {
                    int id_period = (int)row["id"];
                    DateTime dateStart = (DateTime)row["dateStart"];
                    DateTime dateEnd = (DateTime)row["dateEnd"];

                    DataTable dtHead = Config.connect.getStasticOrder(dateStart, dateEnd, id_period);
                    DataTable dtBody = Config.connect.getSumOrderWithRCena(dateStart, dateEnd, id_period);


                    if (dtHead != null && dtHead.Rows.Count > 0)
                    {
                        if (dtBody != null && dtBody.Rows.Count > 0)
                        {
                            dtHead.Rows[0]["sumResult"] = dtBody.Rows[0]["sumResult"];
                        }

                        dtHead.Rows[0]["ostDelivery"] = (decimal)dtHead.Rows[0]["SummaDelivery"] - (decimal)dtHead.Rows[0]["DeliveryCost"] - (decimal)dtHead.Rows[0]["sumPackage"];
                        dtHead.Rows[0]["delta"] = (decimal)dtHead.Rows[0]["sumGoods"] - (decimal)dtHead.Rows[0]["sumResult"];
                    }


                    if (dtDataStatic == null)
                        dtDataStatic = dtHead.Copy();
                    else
                        dtDataStatic.Merge(dtHead);
                }

                if (dtDataStatic == null || dtDataStatic.Rows.Count == 0)
                {
                    Config.DoOnUIThread(() =>
                    {
                        dgvStatistic.DataSource = null;
                        blockers.RestoreControlEnabledState(this);
                        progressBar1.Visible = false;                        
                    }, this);
                    
                    return false;
                }

                foreach (DataRow rowPeriod in dtPeriod.Rows)
                {
                    int id_period = (int)rowPeriod["id"];
                    EnumerableRowCollection<DataRow> rowCollect = dtDataStatic.AsEnumerable().Where(r => r.Field<int>("id_period") == id_period);

                    foreach (DataRow row in rowCollect)
                    {
                        row["namePeriod"] = $"{rowPeriod["cName"]} -[{((DateTime)rowPeriod["dateStart"]).ToShortDateString()} - {((DateTime)rowPeriod["dateEnd"]).ToShortDateString()}] ";
                    }
                }

              
                Config.DoOnUIThread(() =>
                {
                    dgvStatistic.DataSource = dtDataStatic;
                    blockers.RestoreControlEnabledState(this);
                    progressBar1.Visible = false;
                    paintGraphic();
                }, this);
                return true;
            });
        }

        private void paintGraphic()
        {
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();

            if (dtDataStatic == null || dtDataStatic.Rows.Count == 0) return;

            Random rn = new Random();
            if (rbParamet.Checked)
            {
                chart1.ChartAreas.Add("0");

                foreach (DataRow row in (dgvPeriod.DataSource as DataTable).Rows)
                {
                    Series ser = new Series();
                    ser.Name = $"ser{row["id"]}";
                    ser.LegendText = $"{row["cName"]}";
                    ser.Color = Color.FromArgb((int)row["r"], (int)row["g"], (int)row["b"]);
                    chart1.Series.Add(ser);
                }

                int indexSeries = 0;                

                foreach (Control cnt in gLegends.Controls)
                {
                    if (cnt is CheckBox)
                    {
                        CheckBox checkBox = (cnt as CheckBox);
                        if (checkBox.Checked)
                        {                         
                            foreach (DataRow row in (dgvPeriod.DataSource as DataTable).Rows)
                            {
                                EnumerableRowCollection<DataRow> rowCollect = dtDataStatic.AsEnumerable()
                                    .Where(r => r.Field<int>("id_period") == (int)row["id"]);
                                if (rowCollect.Count() > 0)
                                    chart1.Series[$"ser{row["id"]}"].Points.AddXY(indexSeries + 1, rowCollect.First()[dicCheckBoxVsColumnName[checkBox.Name]]);
                                else
                                    chart1.Series[$"ser{row["id"]}"].Points.AddXY(indexSeries + 1, 0);
                            }

                            chart1.ChartAreas[0].AxisX.CustomLabels.Add(new CustomLabel(indexSeries, indexSeries + 2, checkBox.Text, indexSeries % 2, LabelMarkStyle.None));
                            indexSeries++;
                        }
                    }
                }
            }
            else if (rbPeriod.Checked)
            {
                chart1.ChartAreas.Add("0");

                foreach (Control cnt in gLegends.Controls)
                {
                    if (cnt is CheckBox)
                    {
                        CheckBox checkBox = (cnt as CheckBox);
                        if (checkBox.Checked)
                        {
                            Series ser = new Series();
                            ser.Name = checkBox.Name.Replace("chb", "ser");
                            ser.LegendText = checkBox.Text;
                            ser.Color = gLegends.Controls[checkBox.Name.Replace("chb", "p")].BackColor;
                            chart1.Series.Add(ser);
                        }
                    }
                }
                int i = 0;
                DataTable dtData = (dgvPeriod.DataSource as DataTable);
                foreach (DataRow row in dtData.Rows)
                {
                    EnumerableRowCollection<DataRow> rowCollect = dtDataStatic.AsEnumerable()
                                .Where(r => r.Field<int>("id_period") == (int)row["id"]);
                    //if (rowCollect.Count() == 0) continue;

                    foreach (Series ser in chart1.Series)
                    {
                        string nameSeries = ser.Name;
                        if (rowCollect.Count() == 0)
                            chart1.Series[nameSeries].Points.AddXY(i + 1, 0);
                        else                                
                            chart1.Series[nameSeries].Points.AddXY(i + 1, rowCollect.First()[dicCheckBoxVsColumnName[nameSeries.Replace("ser", "chb")]]);
                    }
                    i++;
                }

                i = 0;
                foreach (DataRow row in dtData.Rows)
                {
                    chart1.ChartAreas[0].AxisX.CustomLabels.Add(new CustomLabel(i, i + 2, (string)row["cName"], i % 2, LabelMarkStyle.None));
                    i++;
                }
            }
        }

        #endregion

        class legends
        {
            public legends()
            { }
            public string name { set; get; }
            public Color color { set; get; }
        }

        private List<legends> listLegends;

        private void chbCountOrder_CheckedChanged(object sender, EventArgs e)
        {
            paintGraphic();
            //chart1.Series.Clear();
            //chart1.ChartAreas.Clear();

            //chart1.ChartAreas.Add("0");
            //foreach (Control cnt in gLegends.Controls)
            //{
            //    if (cnt is CheckBox)
            //    {
            //        CheckBox checkBox = (cnt as CheckBox);
            //        if (checkBox.Checked)
            //        {
            //            Series ser = new Series();
            //            ser.Name = checkBox.Name.Replace("chb", "ser");
            //            ser.LegendText = checkBox.Text;
            //            ser.Color = gLegends.Controls[checkBox.Name.Replace("chb", "p")].BackColor;
            //            chart1.Series.Add(ser);
            //        }
            //    }
            //}           
        }

        private void rbParamet_CheckedChanged(object sender, EventArgs e)
        {
            paintGraphic();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dtDataStatic == null || dtDataStatic.DefaultView.Count == 0) return;

            Nwuram.Framework.ToExcelNew.ExcelUnLoad report = new Nwuram.Framework.ToExcelNew.ExcelUnLoad();

            int indexRow = 1;

            int maxColumns = 0;

            foreach (DataGridViewColumn col in dgvStatistic.Columns)
                if (col.Visible)
                {
                    maxColumns++;
                    if (col.Name.Equals("dataGridViewTextBoxColumn1")) setWidthColumn(indexRow, maxColumns, 22, report);
                    if (col.Name.Equals("cStaticCountOrder")) setWidthColumn(indexRow, maxColumns, 13, report);
                    if (col.Name.Equals("cStaticSumOrder")) setWidthColumn(indexRow, maxColumns, 17, report);
                    if (col.Name.Equals("cStaticSumTransfer")) setWidthColumn(indexRow, maxColumns, 13, report);
                    if (col.Name.Equals("cStatic_1")) setWidthColumn(indexRow, maxColumns, 12, report);
                    if (col.Name.Equals("cStatic_2")) setWidthColumn(indexRow, maxColumns, 12, report);
                    if (col.Name.Equals("cStatic_3")) setWidthColumn(indexRow, maxColumns, 12, report);
                }

            #region "Head"
            report.Merge(indexRow, 1, indexRow, maxColumns);
            report.AddSingleValue($"Отчёт по статистике", indexRow, 1);
            report.SetFontBold(indexRow, 1, indexRow, 1);
            report.SetFontSize(indexRow, 1, indexRow, 1, 16);
            report.SetCellAlignmentToCenter(indexRow, 1, indexRow, 1);
            indexRow++;
            indexRow++;

            report.Merge(indexRow, 1, indexRow, maxColumns);
            report.AddSingleValue("Выгрузил: " + Nwuram.Framework.Settings.User.UserSettings.User.FullUsername, indexRow, 1);
            indexRow++;

            report.Merge(indexRow, 1, indexRow, maxColumns);
            report.AddSingleValue("Дата выгрузки: " + DateTime.Now.ToString(), indexRow, 1);
            indexRow++;
            indexRow++;
            #endregion

            int indexCol = 0;
            foreach (DataGridViewColumn col in dgvStatistic.Columns)
                if (col.Visible)
                {
                    indexCol++;
                    report.AddSingleValue(col.HeaderText, indexRow, indexCol);
                }
            report.SetFontBold(indexRow, 1, indexRow, maxColumns);
            report.SetBorders(indexRow, 1, indexRow, maxColumns);
            report.SetCellAlignmentToCenter(indexRow, 1, indexRow, maxColumns);
            report.SetCellAlignmentToJustify(indexRow, 1, indexRow, maxColumns);
            report.SetWrapText(indexRow, 1, indexRow, maxColumns);
            indexRow++;

            foreach (DataRowView row in dtDataStatic.DefaultView)
            {
                indexCol = 1;
                report.SetWrapText(indexRow, indexCol, indexRow, maxColumns);
                foreach (DataGridViewColumn col in dgvStatistic.Columns)
                {
                    if (col.Visible)
                    {
                        if (row[col.DataPropertyName] is DateTime)
                            report.AddSingleValue(((DateTime)row[col.DataPropertyName]).ToShortDateString(), indexRow, indexCol);
                        else
                           if (row[col.DataPropertyName] is decimal)
                        {
                            report.AddSingleValueObject(row[col.DataPropertyName], indexRow, indexCol);
                            report.SetFormat(indexRow, indexCol, indexRow, indexCol, "0.00");
                        }
                        else
                            report.AddSingleValue(row[col.DataPropertyName].ToString(), indexRow, indexCol);

                        indexCol++;
                    }
                }

                report.SetBorders(indexRow, 1, indexRow, maxColumns);
                report.SetCellAlignmentToCenter(indexRow, 1, indexRow, maxColumns);
                report.SetCellAlignmentToJustify(indexRow, 1, indexRow, maxColumns);

                indexRow++;
            }

            report.Show();

            #region log
            Logging.StartFirstLevel(79);
            Logging.Comment("Произведена выгрузка статистики по онлайн-магазину");
            foreach (DataRow dr in (dgvPeriod.DataSource as DataTable).Rows)
            {
                Logging.Comment($"Наименование периода: {dr["cName"].ToString()}, Начало: {dr["dateStart"].ToString()}, Конец: {dr["dateEnd"].ToString()}");
            }
            Logging.Comment("Завершение выгрузки статистики по онлайн-магазину");
            Logging.StopFirstLevel();
            #endregion
        }
    }
}
