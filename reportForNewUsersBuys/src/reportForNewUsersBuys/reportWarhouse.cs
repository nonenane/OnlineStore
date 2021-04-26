using Nwuram.Framework.Settings.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reportForNewUsersBuys
{
    public class reportWarhouse
    {
        private static Nwuram.Framework.ToExcelNew.ExcelUnLoad report = null;

        public static void creatReport(string listOrder)
        {
            if (Config.hCntMain == null)
                Config.hCntMain = new Procedures(ConnectionSettings.GetServer(), ConnectionSettings.GetDatabase(), ConnectionSettings.GetUsername(), ConnectionSettings.GetPassword(), ConnectionSettings.ProgramName);

            report = null;
            DataTable dtReport = null;
            try
            {
                dtReport = Config.hCntMain.getReportWarhouse(listOrder).Result;

                if (dtReport == null || dtReport.Rows.Count == 0) return;
               


                var groupDeps = dtReport.AsEnumerable().GroupBy(r => new { nameDeps = r.Field<string>("nameDep"), id_Departments = r.Field<Int16>("id_Departments") }).OrderByDescending(g=>g.Key.id_Departments);

                foreach (var gDep in groupDeps)
                {                    
                    EnumerableRowCollection<DataRow> rowCollect = dtReport.AsEnumerable().Where(r => r.Field<Int16>("id_Departments") == gDep.Key.id_Departments);
                    createTapDeps(gDep.Key.id_Departments,gDep.Key.nameDeps, rowCollect);
                }
                report.SetPageSetup(1, 9999, false);
                report.Show();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void setWidthColumn(int indexRow, int indexCol, int width, Nwuram.Framework.ToExcelNew.ExcelUnLoad report)
        {
            report.SetColumnWidth(indexRow, indexCol, indexRow, indexCol, width);
        }

        private static void setValueToCell(int indexRow, int indexCol, object value)
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
            else
                report.AddSingleValue(value.ToString(), indexRow, indexCol);
        }

        private static void reCalNetto(ref int count05, ref int count1, ref int count2,decimal tmpNetto, ref bool isUse05, ref bool isUse1, ref bool isUse2,ref int cntRow)
        {
            if (tmpNetto >= 2)
            {
                if (!isUse2) { cntRow++; isUse2 = true; }
                count2 += Decimal.ToInt32(tmpNetto / 2);
                decimal ost = tmpNetto % 2;
                if (ost > 0)
                    reCalNetto(ref count05, ref count1, ref count2, ost, ref isUse05, ref isUse1, ref isUse2, ref cntRow);
            }
            else
                if (tmpNetto >= 1)
            {
                if (!isUse1) { cntRow++; isUse1 = true; }
                count1 += Decimal.ToInt32(tmpNetto / 1);
                decimal ost = tmpNetto % 1;
                if (ost > 0)
                    reCalNetto(ref count05, ref count1, ref count2, ost, ref isUse05, ref isUse1, ref isUse2, ref cntRow);
            }
            else
            {
                if (!isUse05) { cntRow++; isUse05 = true; }
                count05 += Decimal.ToInt32(tmpNetto / (decimal)0.5);
                decimal ost = tmpNetto % (decimal)0.5;
                if (ost > 0)
                    reCalNetto(ref count05, ref count1, ref count2, ost, ref isUse05, ref isUse1, ref isUse2,ref cntRow);
            }

        }

        private static void createTapDeps(int id_Departments,string nameDep, EnumerableRowCollection<DataRow> rowCollect)
        {
            if (report == null) { report = new Nwuram.Framework.ToExcelNew.ExcelUnLoad(nameDep); } else { report.GoToNextSheet(nameDep); }

            int indexRow = 1;
            int maxCol = 5;
            int npp = 1;

            setWidthColumn(indexRow, 1, 8, report);
            setWidthColumn(indexRow, 2, 17, report);
            setWidthColumn(indexRow, 3, 60, report);
            setWidthColumn(indexRow, 4, 12, report);
            setWidthColumn(indexRow, 5, 12, report);

            report.Merge(indexRow, 1, indexRow, maxCol);
            report.AddSingleValue($"Отчёт по сборке товаров отдела \"{nameDep}\"", indexRow, 1);
            report.SetCellAlignmentToJustify(indexRow, 1, indexRow, 1);
            report.SetCellAlignmentToCenter(indexRow, 1, indexRow, 1);
            report.SetFontSize(indexRow, 1, indexRow, 1, 18);
            indexRow++;
            indexRow++;

            report.AddSingleValue("№ п/п", indexRow, 1);
            report.AddSingleValue("EAN товара", indexRow, 2);
            report.AddSingleValue("Наименование товара", indexRow, 3);
            report.AddSingleValue("Количество в заказе", indexRow, 4);
            report.AddSingleValue("Номер заказа", indexRow, 5);
            report.SetFontBold(indexRow, 1, indexRow, maxCol);
            report.SetBorders(indexRow, 1, indexRow, maxCol);
            report.SetCellAlignmentToCenter(indexRow, 1, indexRow, maxCol);
            report.SetCellAlignmentToJustify(indexRow, 1, indexRow, maxCol);
            report.SetWrapText(indexRow, 1, indexRow, maxCol);
            indexRow++;

            var groupGoods = rowCollect.AsEnumerable()
                .GroupBy(g => new { id_Tovar = g.Field<int>("id_Tovar")})
                .Select(s=>new {                    
                    s.Key.id_Tovar,
                    ean = s.Max(r=>r.Field<string>("ean")),
                    nameGood = s.Max(r => r.Field<string>("nameGood")),
                    Netto = s.Sum(r=>r.Field<decimal>("Netto"))
                });

            bool isColor = false;

            foreach (var gGood in groupGoods)
            {
                var groupOrderNote = rowCollect.AsEnumerable()
                    .Where(r => r.Field<int>("id_Tovar") == gGood.id_Tovar)
                    .GroupBy(g => new { OrderNumber = g.Field<int>("OrderNumber") })
                    .Select(s => new { s.Key.OrderNumber, Netto = s.Sum(r => r.Field<decimal>("Netto")) });

                int endRows = indexRow + groupOrderNote.Count()-1;
                report.Merge(indexRow, 1, endRows, 1);
                report.Merge(indexRow, 2, endRows, 2);
                report.Merge(indexRow, 3, endRows, 3);


                report.SetCellAlignmentToJustify(indexRow, 1, endRows, 3);
                report.SetCellAlignmentToCenter(indexRow, 1, endRows, 3);
                report.SetCellAlignmentToRight(indexRow, 4, endRows, 5);
                report.SetWrapText(indexRow, 1, endRows, 5);
                report.SetBorders(indexRow, 1, endRows, maxCol);
                if (isColor)
                    report.SetCellColor(indexRow, 1, endRows, maxCol, Color.LightGray);

                setValueToCell(indexRow, 1, npp);
                setValueToCell(indexRow, 2, gGood.ean);
                setValueToCell(indexRow, 3, gGood.nameGood);

                foreach (var gOrderNote in groupOrderNote)
                {
                    setValueToCell(indexRow, 4, gOrderNote.Netto);
                    setValueToCell(indexRow, 5, gOrderNote.OrderNumber);                                     
                    indexRow++;
                }

                indexRow = endRows;
                indexRow++;
                npp++;


                //Блок шучные
                if (gGood.ean.Length != 4 && groupOrderNote.Count()>1) {
                    report.Merge(indexRow, 1, indexRow, 3);
                    report.SetCellAlignmentToJustify(indexRow, 1, indexRow, 3);
                    report.SetCellAlignmentToCenter(indexRow, 1, indexRow, 3);
                    report.SetCellAlignmentToRight(indexRow, 4, indexRow, 5);
                    report.SetWrapText(indexRow, 1, indexRow, maxCol);
                    report.SetBorders(indexRow, 1, indexRow, maxCol);
                    report.SetFontBold(indexRow, 1, indexRow, maxCol);
                    setValueToCell(indexRow, 1, "Итого");
                    setValueToCell(indexRow, 4, gGood.Netto);
                    if (isColor)
                        report.SetCellColor(indexRow, 1, indexRow, maxCol, Color.LightGray);
                    indexRow++;
                }

                //Блок весовые
                if (gGood.ean.Length == 4 && id_Departments==4) {

                    var groupNetto = rowCollect.AsEnumerable()
                    .Where(r => r.Field<int>("id_Tovar") == gGood.id_Tovar && r.Field<decimal>("MinOrder")==(decimal)0.5)
                    .GroupBy(g => new { OrderNumber = g.Field<int>("OrderNumber"), Netto = g.Field<decimal>("Netto") })
                    .Select(s=>new {
                        s.Key.OrderNumber,
                        s.Key.Netto,
                        count= s.Count()
                    });

                    if (groupNetto.Count() > 0)
                    {

                        int count05 = 0;
                        int count1 = 0;
                        int count2 = 0;
                        bool isUse05 = false, isUse1 = false, isUse2 = false;
                        int cntRow = 0;

                        foreach (var gNetto in groupNetto)
                        {
                            decimal tmpNetto = gNetto.Netto;
                            if (tmpNetto == (decimal)0.5) { count05++; if (!isUse05) { cntRow++; isUse05 = true; } }
                            else
                            if (tmpNetto == 1)
                            {
                                count1++; if (!isUse1) { cntRow++; isUse1 = true; }
                            }
                            else
                            if (tmpNetto == 2)
                            {
                                count2++; if (!isUse2) { cntRow++; isUse2 = true; }
                            }
                            else
                            {
                                reCalNetto(ref count05, ref count1, ref count2, tmpNetto, ref isUse05, ref isUse1, ref isUse2, ref cntRow);
                            }
                        }
                      
                        endRows = indexRow + cntRow - 1;
                        report.Merge(indexRow, 1, endRows, 3);
                        report.SetCellAlignmentToJustify(indexRow, 1, endRows, 3);
                        report.SetCellAlignmentToCenter(indexRow, 1, endRows, 3);
                        report.SetCellAlignmentToRight(indexRow, 4, endRows, 5);
                        report.SetWrapText(indexRow, 1, endRows, maxCol);
                        report.SetBorders(indexRow, 1, endRows, maxCol);
                        report.SetFontBold(indexRow, 1, endRows, maxCol);
                        if (isColor)
                            report.SetCellColor(indexRow, 1, endRows, maxCol, Color.LightGray);
                        setValueToCell(indexRow, 1, "Итого");

                        if (count2 != 0)
                        {
                            setValueToCell(indexRow, 4, "2");
                            setValueToCell(indexRow, 5, $"{count2} пак.");
                            indexRow++;
                        }

                        if (count1 != 0)
                        {
                            setValueToCell(indexRow, 4, "1");
                            setValueToCell(indexRow, 5, $"{count1} пак.");
                            indexRow++;
                        }

                        if (count05 != 0)
                        {
                            setValueToCell(indexRow, 4, "0.5");
                            setValueToCell(indexRow, 5, $"{count05} пак.");
                            indexRow++;
                        }
                        
                        indexRow = endRows;
                        indexRow++;
                    }
                }

                isColor = !isColor;

            }
        }
    }
}
