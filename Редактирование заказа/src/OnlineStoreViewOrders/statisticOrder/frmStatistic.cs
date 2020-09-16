using Nwuram.Framework.Settings.Connection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

            chart1.Series.Clear();
            chart1.ChartAreas.Clear();
        }

        private void frmStatistic_Load(object sender, EventArgs e)
        {
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
        private void btGetDataPopularTovar_Click(object sender, EventArgs e)
        {
            DateTime dateStart = new DateTime(2020, 09, 01);
            DateTime dateEnd = new DateTime(2020, 09, 20);
            int id_period = 1;

            dtPopularTovar = Config.connect.getPopularTovarInfo(dateStart, dateEnd, id_period);
            filter();
            dgvDataTovar.DataSource = dtPopularTovar;
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
        }


        #endregion

        private void button4_Click(object sender, EventArgs e)
        {
            
            frmLPeriod.Show();
        }

        public void updatePeriod()
        {
            EnumerableRowCollection<DataRow> rowCollcect = frmLPeriod.dtData.AsEnumerable().Where(r => r.Field<bool>("isSelect"));
            if (rowCollcect.Count() > 0)
                dgvPeriod.DataSource = rowCollcect.CopyToDataTable();
            else
                dgvPeriod.DataSource = frmLPeriod.dtData.Clone();
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

            /*
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            
            chartArea.AxisY.Minimum = 0;
            chartArea.AxisY.Maximum = 3;
            chartArea.Name = "myGraph";

            chartArea.AxisX.MajorGrid.Interval = 0.1;
            chartArea.AxisY.MajorGrid.Interval = 0.1;
            chart1.ChartAreas.Add(chartArea);
            */

            Random rn = new Random();


            for (int j = 0; j < 10; j++)
            {
                chart1.Series.Add(j.ToString());
                if (j == 0)
                    chart1.ChartAreas.Add(j.ToString());


                string[] labels = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j" };
                int i = 0;
                for (double y = 0.1; y < 1; y += 0.1)
                {
                    chart1.Series[j].Points.AddXY(i + 1, rn.NextDouble());
                    if (j == 0)
                        chart1.ChartAreas[j].AxisX.CustomLabels.Add(new CustomLabel(i, i + 2, labels[i], 0, LabelMarkStyle.Box));
                    i++;
                }
            }
            //iina++;
        }
    }
}
