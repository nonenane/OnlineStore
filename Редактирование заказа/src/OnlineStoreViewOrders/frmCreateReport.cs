using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineStoreViewOrders
{
    public partial class frmCreateReport : Form
    {
        public frmCreateReport()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void setWidthColumn(int indexRow, int indexCol, int width, Nwuram.Framework.ToExcelNew.ExcelUnLoad report)
        {
            report.SetColumnWidth(indexRow, indexCol, indexRow, indexCol, width);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (!chbCancel.Checked && !chbComplete.Checked) return;

            

            Nwuram.Framework.ToExcelNew.ExcelUnLoad report = new Nwuram.Framework.ToExcelNew.ExcelUnLoad();
            bool isShow = false;


            if (chbComplete.Checked)
            {
                DataTable dtDataStatus3 = Config.connect.getReportData(dtpStart.Value, dtpEnd.Value, 3);
                DataTable dtDataStatus3Body = Config.connect.getSumNotesOrderWithRCena(dtpStart.Value, dtpEnd.Value, 3);

                if (dtDataStatus3 != null && dtDataStatus3.Rows.Count > 0)
                {
                    isShow = true;
                    report.changeNameTab("Выполненные");

                    int indexRow = 1;
                    int maxColumns = 12;

                    setWidthColumn(indexRow, 1, 20, report);
                    setWidthColumn(indexRow, 2, 20, report);
                    setWidthColumn(indexRow, 3, 20, report);
                    setWidthColumn(indexRow, 4, 20, report);
                    setWidthColumn(indexRow, 5, 20, report);
                    setWidthColumn(indexRow, 6, 20, report);
                    setWidthColumn(indexRow, 7, 20, report);
                    setWidthColumn(indexRow, 8, 20, report);
                    setWidthColumn(indexRow, 9, 20, report);
                    setWidthColumn(indexRow, 10, 20, report);
                    setWidthColumn(indexRow, 11, 20, report);
                    setWidthColumn(indexRow, 12, 20, report);

                    #region "Head"
                    report.Merge(indexRow, 1, indexRow, maxColumns);
                    report.AddSingleValue($"Отчёт об выполненных заказах с {dtpStart.Value.ToShortDateString()} по {dtpEnd.Value.ToShortDateString()}", indexRow, 1);
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

                    report.AddSingleValue("№ п/п", indexRow, 1);
                    report.AddSingleValue("Номер заказа", indexRow, 2);                    
                    report.AddSingleValue("Сумма заказа", indexRow, 3);
                    report.AddSingleValue("Дата доставки", indexRow, 4);
                    report.AddSingleValue("Сумма чека", indexRow, 5);
                    report.AddSingleValue("№ чека", indexRow, 6);
                    report.AddSingleValue("Стоимость доставки", indexRow, 7);
                    report.AddSingleValue("Кол-во пакетов", indexRow, 8);
                    report.AddSingleValue("Стоимость пакетов", indexRow, 9);
                    report.AddSingleValue("Затраты на доставку", indexRow, 10);
                    report.AddSingleValue("Остаток на доставку", indexRow, 11);
                    report.AddSingleValue("∆ по чеку", indexRow, 12);


                    report.SetFontBold(indexRow, 1, indexRow, maxColumns);
                    report.SetBorders(indexRow, 1, indexRow, maxColumns);
                    report.SetWrapText(indexRow, 1, indexRow, maxColumns);
                    report.SetCellAlignmentToCenter(indexRow, 1, indexRow, maxColumns);
                    report.SetCellAlignmentToJustify(indexRow, 1, indexRow, maxColumns);
                    indexRow++;

                    int npp = 1;

                    foreach (DataRowView row in dtDataStatus3.DefaultView)
                    {
                        report.SetWrapText(indexRow, 1, indexRow, maxColumns);

                        report.AddSingleValue(npp.ToString(), indexRow, 1);
                        report.AddSingleValue(row["OrderNumber"].ToString(), indexRow, 2);                        
                        report.AddSingleValueObject(row["sumOrder"], indexRow, 3);
                        report.SetFormat(indexRow, 3, indexRow, 3, "0.00");
                        report.AddSingleValue(((DateTime)row["DeliveryDate"]).ToShortDateString(), indexRow, 4);
                        report.AddSingleValueObject(row["sumNote"], indexRow, 5);
                        report.SetFormat(indexRow, 5, indexRow, 5, "0.00");
                        report.AddSingleValue($"Касса:{row["KassNumber"]} Чек:{row["CheckNumber"]}", indexRow, 6);

                        report.AddSingleValueObject(row["SummaDelivery"], indexRow, 7);
                        report.SetFormat(indexRow, 7, indexRow, 7, "0.00");

                        report.AddSingleValueObject(row["CountPackage"], indexRow, 8);
                        report.SetFormat(indexRow, 8, indexRow, 8, "0.00");

                        report.AddSingleValueObject(row["sumPackage"], indexRow, 9);
                        report.SetFormat(indexRow, 9, indexRow, 9, "0.00");

                        report.AddSingleValueObject(row["DeliveryCost"], indexRow, 10);
                        report.SetFormat(indexRow, 10, indexRow, 10, "0.00");

                        decimal value = (decimal)row["SummaDelivery"] - (decimal)row["sumPackage"] - (decimal)row["DeliveryCost"];
                        report.AddSingleValueObject(value, indexRow, 11);
                        report.SetFormat(indexRow, 11, indexRow, 11, "0.00");

                        report.AddSingleValueObject(0, indexRow, 12);
                        report.SetFormat(indexRow, 12, indexRow, 12, "0.00");                        


                        report.SetBorders(indexRow, 1, indexRow, maxColumns);
                        report.SetCellAlignmentToCenter(indexRow, 1, indexRow, maxColumns);
                        report.SetCellAlignmentToJustify(indexRow, 1, indexRow, maxColumns);
                        indexRow++;
                        npp++;
                    }

                }
            }

            if (chbCancel.Checked)
            {
                DataTable dtData = Config.connect.getReportData(dtpStart.Value, dtpEnd.Value, 4);
                if (dtData != null && dtData.Rows.Count > 0)
                {
                    if (!isShow)
                    {
                        isShow = true;
                        report.changeNameTab("Отменённые");
                    }
                    else
                    {
                        report.GoToNextSheet("Отменённые");
                    }

                    int indexRow = 1;
                    int maxColumns = 5;

                    setWidthColumn(indexRow, 1, 20, report);
                    setWidthColumn(indexRow, 2, 20, report);
                    setWidthColumn(indexRow, 3, 20, report);
                    setWidthColumn(indexRow, 4, 20, report);
                    setWidthColumn(indexRow, 5, 20, report);

                    #region "Head"
                    report.Merge(indexRow, 1, indexRow, maxColumns);
                    report.AddSingleValue($"Отчёт об отменённых заказах с {dtpStart.Value.ToShortDateString()} по {dtpEnd.Value.ToShortDateString()}", indexRow, 1);
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

                    report.AddSingleValue("№ п/п", indexRow, 1);
                    report.AddSingleValue("Номер заказа", indexRow, 2);
                    report.AddSingleValue("Дата заказа", indexRow, 3);
                    report.AddSingleValue("Сумма заказа", indexRow, 4);
                    report.AddSingleValue("Комментарий об отмене заказа", indexRow, 5);

                    report.SetFontBold(indexRow, 1, indexRow, maxColumns);
                    report.SetBorders(indexRow, 1, indexRow, maxColumns);
                    report.SetWrapText(indexRow, 1, indexRow, maxColumns);
                    report.SetCellAlignmentToCenter(indexRow, 1, indexRow, maxColumns);
                    report.SetCellAlignmentToJustify(indexRow, 1, indexRow, maxColumns);
                    indexRow++;

                    int npp = 1;

                    foreach (DataRowView row in dtData.DefaultView)
                    {
                        report.SetWrapText(indexRow, 1, indexRow, maxColumns);

                        report.AddSingleValue(npp.ToString(), indexRow, 1);
                        report.AddSingleValue(row["OrderNumber"].ToString(), indexRow, 2);
                        report.AddSingleValue(((DateTime)row["DateOrder"]).ToShortDateString(), indexRow, 3);
                        report.AddSingleValueObject(row["sumOrder"], indexRow, 4);
                        report.SetFormat(indexRow, 4, indexRow, 4, "0.00");
                        report.AddSingleValue(row["Comment"].ToString(), indexRow, 5);

                        report.SetBorders(indexRow, 1, indexRow, maxColumns);
                        report.SetCellAlignmentToCenter(indexRow, 1, indexRow, maxColumns);
                        report.SetCellAlignmentToJustify(indexRow, 1, indexRow, maxColumns);
                        indexRow++;
                        npp++;
                    }
                }
            }




            if (isShow)
                report.Show();
            else
            {
                MessageBox.Show("Нет данных для отчёта", "Выгрузка отчёта", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            if (dtpEnd.Value < dtpStart.Value)
                dtpEnd.Value = dtpStart.Value;
        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {
            if (dtpStart.Value > dtpEnd.Value)
                dtpStart.Value = dtpEnd.Value;
        }
    }
}
