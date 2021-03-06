﻿using Nwuram.Framework.Logging;
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

        private Nwuram.Framework.UI.Service.EnableControlsServiceInProg blockers = new Nwuram.Framework.UI.Service.EnableControlsServiceInProg();
        private Nwuram.Framework.UI.Forms.frmLoad fLoad;


        private async void btnPrint_Click(object sender, EventArgs e)
        {
            if (!chbCancel.Checked && !chbComplete.Checked && !chbЕmployesОrder.Checked) return;

            var outer = Task.Factory.StartNew(() =>      // внешняя задача
            {
                Config.DoOnUIThread(() =>
                {
                    blockers.SaveControlsEnabledState(this);
                    blockers.SetControlsEnabled(this, false);
                    //progressBar1.Visible = progressBar1.Enabled = true;
                    fLoad = new Nwuram.Framework.UI.Forms.frmLoad();
                    fLoad.TopMost = false;
                    fLoad.Owner = this;
                    fLoad.TextWait = "Грузим отчётик!";
                    fLoad.Show();
                }, this);

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

                        decimal sumOrder = 0, sumNote = 0, SummaDelivery = 0, sumPackage = 0, DeliveryCost = 0, valueOst = 0, valueDelta = 0;


                        int indexRow = 1;
                        int maxColumns = 12;

                        setWidthColumn(indexRow, 1, 6, report);
                        setWidthColumn(indexRow, 2, 10, report);
                        setWidthColumn(indexRow, 3, 17, report);
                        setWidthColumn(indexRow, 4, 11, report);
                        setWidthColumn(indexRow, 5, 16, report);
                        setWidthColumn(indexRow, 6, 22, report);
                        setWidthColumn(indexRow, 7, 16, report);
                        setWidthColumn(indexRow, 8, 12, report);
                        setWidthColumn(indexRow, 9, 14, report);
                        setWidthColumn(indexRow, 10, 16, report);
                        setWidthColumn(indexRow, 11, 16, report);
                        setWidthColumn(indexRow, 12, 13, report);

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
                        report.AddSingleValue("Остаток по доставке", indexRow, 11);
                        report.AddSingleValue("∆ по чеку", indexRow, 12);


                        report.SetFontBold(indexRow, 1, indexRow, maxColumns);
                        report.SetBorders(indexRow, 1, indexRow, maxColumns);
                        report.SetWrapText(indexRow, 1, indexRow, maxColumns);
                        report.SetCellAlignmentToCenter(indexRow, 1, indexRow, maxColumns);
                        report.SetCellAlignmentToJustify(indexRow, 1, indexRow, maxColumns);
                        indexRow++;

                        int npp = 1;

                        var groupOrder = dtDataStatus3.AsEnumerable()
                            .GroupBy(r => new { id_tOrders = r.Field<int>("id_tOrders") })
                            .Select(g => new
                            {
                                g.Key.id_tOrders,
                                sumNote = g.Sum(r => r.Field<decimal>("sumNote"))
                            });

                        foreach (var g in groupOrder)
                        {
                            EnumerableRowCollection<DataRow> rowCollect = dtDataStatus3.AsEnumerable().Where(r => r.Field<int>("id_tOrders") == g.id_tOrders);
                            DataRow row = rowCollect.First();
                            int startRow = indexRow;
                            report.SetWrapText(indexRow, 1, indexRow + rowCollect.Count() - 1, maxColumns);
                            report.Merge(indexRow, 1, indexRow + rowCollect.Count() - 1, 1);
                            report.Merge(indexRow, 2, indexRow + rowCollect.Count() - 1, 2);
                            report.Merge(indexRow, 3, indexRow + rowCollect.Count() - 1, 3);
                            report.Merge(indexRow, 4, indexRow + rowCollect.Count() - 1, 4);
                            report.Merge(indexRow, 5, indexRow + rowCollect.Count() - 1, 5);

                            report.Merge(indexRow, 7, indexRow + rowCollect.Count() - 1, 7);
                            report.Merge(indexRow, 8, indexRow + rowCollect.Count() - 1, 8);
                            report.Merge(indexRow, 9, indexRow + rowCollect.Count() - 1, 9);
                            report.Merge(indexRow, 10, indexRow + rowCollect.Count() - 1, 10);
                            report.Merge(indexRow, 11, indexRow + rowCollect.Count() - 1, 11);
                            report.Merge(indexRow, 12, indexRow + rowCollect.Count() - 1, 12);



                            report.AddSingleValue(npp.ToString(), indexRow, 1);
                            report.AddSingleValue(row["OrderNumber"].ToString(), indexRow, 2);
                            report.AddSingleValueObject(row["sumOrder"], indexRow, 3);
                            report.SetFormat(indexRow, 3, indexRow, 3, "0.00");
                            report.AddSingleValue(((DateTime)row["DeliveryDate"]).ToShortDateString(), indexRow, 4);

                            report.AddSingleValueObject(g.sumNote, indexRow, 5);
                            report.SetFormat(indexRow, 5, indexRow, 5, "0.00");

                            report.AddSingleValueObject(row["SummaDelivery"], indexRow, 7);
                            report.SetFormat(indexRow, 7, indexRow, 7, "0.00");

                            report.AddSingleValueObject(row["CountPackage"], indexRow, 8);
                            report.SetFormat(indexRow, 8, indexRow, 8, "0.00");

                            report.AddSingleValueObject(row["sumPackage"], indexRow, 9);
                            report.SetFormat(indexRow, 9, indexRow, 9, "0.00");

                            report.AddSingleValueObject(row["DeliveryCost"], indexRow, 10);
                            report.SetFormat(indexRow, 10, indexRow, 10, "0.00");


                            sumOrder += (decimal)row["sumOrder"];
                            sumNote += g.sumNote;
                            SummaDelivery += (decimal)row["SummaDelivery"];
                            sumPackage += (decimal)row["sumPackage"];
                            DeliveryCost += (decimal)row["DeliveryCost"];

                            decimal value = (decimal)row["SummaDelivery"] - (decimal)row["sumPackage"] - (decimal)row["DeliveryCost"];
                            valueOst += value;
                            report.AddSingleValueObject(value, indexRow, 11);
                            report.SetFormat(indexRow, 11, indexRow, 11, "0.00");

                            if (dtDataStatus3Body != null)
                            {
                                decimal sum = dtDataStatus3Body.AsEnumerable().Where(r => r.Field<int>("id_tOrders") == (int)row["id_tOrders"]).Sum(r => r.Field<decimal>("resultSum"));
                                report.AddSingleValueObject(g.sumNote - sum, indexRow, 12);
                                valueDelta += g.sumNote - sum;
                            }
                            else
                                report.AddSingleValueObject(0, indexRow, 12);
                            report.SetFormat(indexRow, 12, indexRow, 12, "0.00");

                            foreach (DataRow rowSelect in rowCollect)
                            {
                                //report.AddSingleValueObject(rowSelect["sumNote"], indexRow, 5);
                                //report.SetFormat(indexRow, 5, indexRow, 5, "0.00");
                                report.AddSingleValue($"Касса:{rowSelect["KassNumber"]} Чек:{rowSelect["CheckNumber"]}", indexRow, 6);
                                indexRow++;
                            }




                            report.SetBorders(startRow, 1, indexRow - 1, maxColumns);
                            report.SetCellAlignmentToCenter(startRow, 1, indexRow - 1, maxColumns);
                            report.SetCellAlignmentToJustify(startRow, 1, indexRow - 1, maxColumns);
                            //indexRow++;
                            npp++;
                        }


                        report.SetFormat(indexRow, 2, indexRow, maxColumns, "0.00");

                        report.AddSingleValue($"Итого:", indexRow, 1);
                        report.AddSingleValueObject(sumOrder, indexRow, 3);
                        report.AddSingleValueObject(sumNote, indexRow, 5);
                        report.AddSingleValueObject(SummaDelivery, indexRow, 7);
                        report.AddSingleValueObject(sumPackage, indexRow, 9);
                        report.AddSingleValueObject(DeliveryCost, indexRow, 10);
                        report.AddSingleValueObject(valueOst, indexRow, 11);
                        report.AddSingleValueObject(valueDelta, indexRow, 12);

                        report.SetBorders(indexRow, 1, indexRow, maxColumns);
                        report.SetFontBold(indexRow, 1, indexRow, maxColumns);
                        report.SetCellAlignmentToCenter(indexRow, 1, indexRow, maxColumns);
                        report.SetCellAlignmentToJustify(indexRow, 1, indexRow, maxColumns);
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
                        decimal sumOrder = 0;

                        setWidthColumn(indexRow, 1, 9, report);
                        setWidthColumn(indexRow, 2, 18, report);
                        setWidthColumn(indexRow, 3, 16, report);
                        setWidthColumn(indexRow, 4, 16, report);
                        setWidthColumn(indexRow, 5, 40, report);

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

                            sumOrder += (decimal)row["sumOrder"];

                            report.SetBorders(indexRow, 1, indexRow, maxColumns);
                            report.SetCellAlignmentToCenter(indexRow, 1, indexRow, maxColumns);
                            report.SetCellAlignmentToJustify(indexRow, 1, indexRow, maxColumns);
                            indexRow++;
                            npp++;
                        }

                        report.SetFormat(indexRow, 2, indexRow, maxColumns, "0.00");

                        report.AddSingleValue($"Итого:", indexRow, 1);
                        report.AddSingleValueObject(sumOrder, indexRow, 4);

                        report.SetBorders(indexRow, 1, indexRow, maxColumns);
                        report.SetFontBold(indexRow, 1, indexRow, maxColumns);
                        report.SetCellAlignmentToCenter(indexRow, 1, indexRow, maxColumns);
                        report.SetCellAlignmentToJustify(indexRow, 1, indexRow, maxColumns);

                    }
                }

                if (chbЕmployesОrder.Checked)
                {
                    DataTable dtData = Config.connect.reportЕmployesОrder(dtpStart.Value, dtpEnd.Value);
                    if (dtData != null && dtData.Rows.Count > 0)
                    {
                        if (!isShow)
                        {
                            isShow = true;
                            report.changeNameTab("Отчет по сотрудникам");
                        }
                        else
                        {
                            report.GoToNextSheet("Отчет по сотрудникам");
                        }


                        int indexRow = 1;
                        int maxColumns = 8;
                        decimal sumOrder = 0;

                        setWidthColumn(indexRow, 1, 9, report);
                        setWidthColumn(indexRow, 2, 25, report);
                        setWidthColumn(indexRow, 3, 16, report);
                        setWidthColumn(indexRow, 4, 16, report);
                        setWidthColumn(indexRow, 5, 16, report);
                        setWidthColumn(indexRow, 6, 12, report);
                        setWidthColumn(indexRow, 7, 12, report);
                        setWidthColumn(indexRow, 8, 12, report);

                        #region "Head"
                        report.Merge(indexRow, 1, indexRow, maxColumns);
                        report.AddSingleValue($"Отчет по сотрудникам с {dtpStart.Value.ToShortDateString()} по {dtpEnd.Value.ToShortDateString()}", indexRow, 1);
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
                        report.AddSingleValue("ФИО сотрудника", indexRow, 2);
                        report.AddSingleValue("Дата заказа", indexRow, 3);
                        report.AddSingleValue("Номер заказа", indexRow, 4);
                        report.AddSingleValue("Позиций в заказе", indexRow, 5);
                        report.AddSingleValue("Сборщик", indexRow, 6);
                        report.AddSingleValue("Пробитие", indexRow, 7);
                        report.AddSingleValue("Доставщик", indexRow, 8);

                        report.SetFontBold(indexRow, 1, indexRow, maxColumns);
                        report.SetBorders(indexRow, 1, indexRow, maxColumns);
                        report.SetWrapText(indexRow, 1, indexRow, maxColumns);
                        report.SetCellAlignmentToCenter(indexRow, 1, indexRow, maxColumns);
                        report.SetCellAlignmentToJustify(indexRow, 1, indexRow, maxColumns);
                        indexRow++;


                        var groupCountCollector = dtData.AsEnumerable()
                        .Where(r => r.Field<bool>("Collector"))
                        .GroupBy(g => new { OrderNumber = g.Field<int>("OrderNumber") })
                        .Select(s => new { s.Key.OrderNumber, countCollector = s.Count() });

                        var groupKadr = dtData.AsEnumerable().GroupBy(r => new { id_Kadr = r.Field<int>("id_Kadr"), FIO = r.Field<string>("FIO") }).Select(s => new { s.Key.id_Kadr, s.Key.FIO });


                        int npp = 1;

                        foreach (var gKadr in groupKadr)
                        {
                            EnumerableRowCollection<DataRow> rowCollect = dtData.AsEnumerable().Where(r => r.Field<int>("id_Kadr") == gKadr.id_Kadr).OrderBy(r => r.Field<int>("OrderNumber"));
                            report.Merge(indexRow, 2, indexRow + rowCollect.Count() - 1, 2);
                            setValueToCell(indexRow, 2, gKadr.FIO, report);
                            var groupDate = rowCollect.AsEnumerable().GroupBy(g => new { DeliveryDate = g.Field<DateTime>("DeliveryDate") }).Select(s => new { s.Key.DeliveryDate });

                            decimal countCollector = 0;
                            int countKassCheck = 0;
                            int countDelivery = 0;

                            foreach (var gDate in groupDate)
                            {
                                EnumerableRowCollection<DataRow> rowCollectDate = rowCollect.Where(r => r.Field<DateTime>("DeliveryDate") == gDate.DeliveryDate);

                                report.Merge(indexRow, 3, indexRow + rowCollectDate.Count() - 1, 3);
                                setValueToCell(indexRow, 3, gDate.DeliveryDate, report);

                                foreach (DataRow row in rowCollectDate)
                                {
                                    report.SetWrapText(indexRow, 1, indexRow, maxColumns);

                                    setValueToCell(indexRow, 1, npp, report);
                                    setValueToCell(indexRow, 4, row["OrderNumber"], report);
                                    setValueToCell(indexRow, 5, row["countRow"], report);
                                    if ((bool)row["Collector"])
                                    {
                                        decimal valResult = Convert.ToDecimal((int)row["countRow"]) / Convert.ToDecimal(groupCountCollector.Where(r => r.OrderNumber == (int)row["OrderNumber"]).First().countCollector);
                                        countCollector += valResult;
                                        setValueToCell(indexRow, 6, valResult, report);
                                    }
                                    if ((bool)row["KassCheck"])
                                    {
                                        setValueToCell(indexRow, 7, row["KassCheck"], report);
                                        countKassCheck++;
                                    }
                                    if ((bool)row["Delivery"])
                                    {
                                        setValueToCell(indexRow, 8, row["Delivery"], report);
                                        countDelivery++;
                                    }

                                    report.SetBorders(indexRow, 1, indexRow, maxColumns);
                                    report.SetCellAlignmentToCenter(indexRow, 1, indexRow, maxColumns);
                                    report.SetCellAlignmentToJustify(indexRow, 1, indexRow, maxColumns);
                                    indexRow++;
                                    npp++;
                                }
                            }


                            report.Merge(indexRow, 1, indexRow, 5);
                            setValueToCell(indexRow, 1, $"Итого:", report);
                            setValueToCell(indexRow, 6, countCollector, report);
                            setValueToCell(indexRow, 7, countKassCheck, report);
                            setValueToCell(indexRow, 8, countDelivery, report);

                            report.SetBorders(indexRow, 1, indexRow, maxColumns);
                            report.SetFontBold(indexRow, 1, indexRow, maxColumns);
                            report.SetCellAlignmentToCenter(indexRow, 1, indexRow, maxColumns);
                            report.SetCellAlignmentToJustify(indexRow, 1, indexRow, maxColumns);
                            report.SetCellAlignmentToRight(indexRow, 1, indexRow, 1);
                            //report.SetCellAlignmentToRight(indexRow, 6, indexRow, maxColumns);

                            indexRow++;                            
                        }
                    }
                }

                Config.DoOnUIThread(() =>
                {
                    blockers.RestoreControlEnabledState(this);
                    fLoad.Dispose();
                }, this);

                if (isShow)
                {
                    report.SetPageSetup(1, 9999, true);
                    report.Show();
                }
                else
                {
                    MessageBox.Show("Нет данных для отчёта", "Выгрузка отчёта", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                #region логирование
                Logging.StartFirstLevel(79);
                Logging.Comment("Произведена выгрузка в Excel отчета по работе онлайн-магазина");
                Logging.Comment($"Период с: {dtpStart.Value.ToShortDateString()} по: {dtpEnd.Value.ToShortDateString()}");
                Logging.Comment($"Отчет о выполненых заказах: {(chbComplete.Checked ? "Да" : "Нет")}");
                Logging.Comment($"Отчет об отмененных заказах: {(chbCancel.Checked ? "Да" : "Нет")}");
                Logging.Comment("Завершение выгрузки отчета по работе онлайн магазина");
                Logging.StopFirstLevel();
                #endregion
            });
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

        private static void setValueToCell(int indexRow, int indexCol, object value,Nwuram.Framework.ToExcelNew.ExcelUnLoad report)
        {
            if (value is DateTime)
                report.AddSingleValue(((DateTime)value).ToShortDateString(), indexRow, indexCol);
            else
               if (value is decimal || value is double)
            {
                report.AddSingleValueObject(value, indexRow, indexCol);
                report.SetFormat(indexRow, indexCol, indexRow, indexCol, "0.00");
            }
            else if (value is int)
            {
                report.AddSingleValueObject(value, indexRow, indexCol);
                report.SetFormat(indexRow, indexCol, indexRow, indexCol, "0");
            }
            else if (value is bool)
            {
                report.AddSingleValue((bool)value ? "+" : "", indexRow, indexCol);
            }
            else
                report.AddSingleValue(value.ToString(), indexRow, indexCol);
        }
    }
}
