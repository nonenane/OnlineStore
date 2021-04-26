using Nwuram.Framework.Settings.Connection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace reportForNewUsersBuys
{
    public partial class frmReport : Form
    {
        private Nwuram.Framework.UI.Service.EnableControlsServiceInProg blockers = new Nwuram.Framework.UI.Service.EnableControlsServiceInProg();
        private Nwuram.Framework.ToExcelNew.ExcelUnLoad report = null;

        public frmReport()
        {
            InitializeComponent();
            if (Config.hCntMain == null)
                Config.hCntMain = new Procedures(ConnectionSettings.GetServer(), ConnectionSettings.GetDatabase(), ConnectionSettings.GetUsername(), ConnectionSettings.GetPassword(), ConnectionSettings.ProgramName);
        }

        private void FrmReport_Load(object sender, EventArgs e)
        {

        }

        private void DtpStart_ValueChanged(object sender, EventArgs e)
        {
            if (dtpStart.Value.Date > dtpEnd.Value.Date)
                dtpEnd.Value = dtpStart.Value.Date;
        }

      

        private void DtpEnd_ValueChanged(object sender, EventArgs e)
        {
            if (dtpStart.Value.Date > dtpEnd.Value.Date)
                dtpStart.Value = dtpEnd.Value.Date;
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void BtnAllReport_Click(object sender, EventArgs e)
        {
            DateTime startDate = dtpStart.Value.Date;
            DateTime endDate = dtpEnd.Value.Date;

            var result = await Task<bool>.Factory.StartNew(() =>
            {
                Config.DoOnUIThread(() =>
                {
                    blockers.SaveControlsEnabledState(this);
                    blockers.SetControlsEnabled(this, false);
                    progressBar1.Visible = progressBar1.Enabled = true;
                }, this);

                DataTable dtReport = null;
                dtReport = Config.hCntMain.getReportNewUserBuy(startDate, endDate).Result;
                
                if (dtReport == null || dtReport.Rows.Count < 2)
                {
                    Config.DoOnUIThread(() =>
                    {
                        blockers.RestoreControlEnabledState(this);
                        progressBar1.Visible = false;
                    }, this);
                    MessageBox.Show("Нет данных для формирования отчёта.", "Печать", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                report = new Nwuram.Framework.ToExcelNew.ExcelUnLoad();

                int indexRow = 1;
                int maxCol = 5;


                setWidthColumn(indexRow, 1, 32, report);
                setWidthColumn(indexRow, 2, 16, report);
                setWidthColumn(indexRow, 3, 34, report);
                setWidthColumn(indexRow, 4, 12, report);
                setWidthColumn(indexRow, 5, 12, report);

                report.Merge(indexRow, 1, indexRow, maxCol);
                report.AddSingleValue("Отчет по покупателям", indexRow, 1);
                report.SetCellAlignmentToJustify(indexRow, 1, indexRow, 1);
                report.SetCellAlignmentToCenter(indexRow, 1, indexRow, 1);
                report.SetFontSize(indexRow, 1, indexRow, 1, 18);
                indexRow++;

                report.Merge(indexRow, 1, indexRow, maxCol);
                report.AddSingleValue($"За период с {startDate.ToShortDateString()} по {endDate.ToShortDateString()}", indexRow, 1);
                report.SetCellAlignmentToJustify(indexRow, 1, indexRow, 1);
                report.SetCellAlignmentToCenter(indexRow, 1, indexRow, 1);
                indexRow++;
                indexRow++;


                insertBlockTypeUser(ref indexRow, maxCol, dtReport.AsEnumerable().Where(r => r.Field<bool>("isNewUser")), "Новые покупатели", "Итого новых покупателей");
                insertBlockTypeUser(ref indexRow, maxCol, dtReport.AsEnumerable().Where(r => !r.Field<bool>("isNewUser")), "Старые покупатели", "Итого старых покупателей");


                /*
                report.Merge(indexRow, 1, indexRow, maxCol);
                report.AddSingleValue("Новые покупатели", indexRow, 1);
                report.SetFontBold(indexRow, 1, indexRow, maxCol);
                report.SetBorders(indexRow, 1, indexRow, maxCol);
                indexRow++;

                report.AddSingleValue("ФИО покупателя", indexRow, 1);
                report.AddSingleValue("Номер телефона", indexRow, 2);
                report.AddSingleValue("E-mail", indexRow, 3);
                report.AddSingleValue("Кол-во заказов", indexRow, 4);
                report.SetFontBold(indexRow, 1, indexRow, maxCol);
                report.SetBorders(indexRow, 1, indexRow, maxCol);
                report.SetCellAlignmentToCenter(indexRow, 1, indexRow, maxCol);
                report.SetCellAlignmentToJustify(indexRow, 1, indexRow, maxCol);
                report.SetWrapText(indexRow, 1, indexRow, maxCol);
                indexRow++;

                foreach (DataRow row in dtReport.AsEnumerable().Where(r => r.Field<bool>("isNewUser")))
                {
                    setValueToCell(indexRow, 1, $"{row["LastnameBuyer"]} {row["NameBuyer"]}");
                    setValueToCell(indexRow, 2, row["Phone"]);
                    setValueToCell(indexRow, 3, row["Email"]);
                    setValueToCell(indexRow, 4, row["mainCount"]);

                    report.SetBorders(indexRow, 1, indexRow, maxCol);
                    report.SetCellAlignmentToJustify(indexRow, 1, indexRow, maxCol);
                    report.SetCellAlignmentToCenter(indexRow, 1, indexRow, 3);
                    report.SetCellAlignmentToRight(indexRow, 4, indexRow, 4);

                    indexRow++;
                }

                report.Merge(indexRow, 1, indexRow, maxCol);
                report.AddSingleValue("Итого новых покупателей - 999", indexRow, 1);
                report.SetFontBold(indexRow, 1, indexRow, maxCol);
                report.SetBorders(indexRow, 1, indexRow, maxCol);
                indexRow++;
                indexRow++;*/


                Config.DoOnUIThread(() =>
                {
                    blockers.RestoreControlEnabledState(this);
                    progressBar1.Visible = false;
                }, this);


                report.SetPageSetup(1, 9999, false);

                report.Show();
                return true;
            });
        }

        private void setWidthColumn(int indexRow, int indexCol, int width, Nwuram.Framework.ToExcelNew.ExcelUnLoad report)
        {
            report.SetColumnWidth(indexRow, indexCol, indexRow, indexCol, width);
        }

        private void setValueToCell(int indexRow, int indexCol, object value)
        {
            if (value is DateTime)
                report.AddSingleValue(((DateTime)value).ToShortDateString(), indexRow, indexCol);
            else
               if (value is decimal || value is double)
            {
                report.AddSingleValueObject(value, indexRow, indexCol);
                report.SetFormat(indexRow, indexCol, indexRow, indexCol, "0.00");
            }
            else if (value is int )
            {
                report.AddSingleValueObject(value, indexRow, indexCol);
                report.SetFormat(indexRow, indexCol, indexRow, indexCol, "0");
            }
            else
                report.AddSingleValue(value.ToString(), indexRow, indexCol);
        }

        private void insertBlockTypeUser(ref int indexRow,int maxCol,EnumerableRowCollection<DataRow> rows,string titleText,string bottonText)
        {
            report.Merge(indexRow, 1, indexRow, maxCol);
            report.AddSingleValue($"{titleText}", indexRow, 1);
            report.SetFontBold(indexRow, 1, indexRow, maxCol);
            report.SetBorders(indexRow, 1, indexRow, maxCol);
            report.SetCellAlignmentToCenter(indexRow, 1, indexRow, 1);
            report.SetFontSize(indexRow, 1, indexRow, 1, 14);
            indexRow++;

            report.AddSingleValue("ФИО покупателя", indexRow, 1);
            report.AddSingleValue("Номер телефона", indexRow, 2);
            report.AddSingleValue("E-mail", indexRow, 3);
            report.AddSingleValue("Кол-во заказов", indexRow, 4);
            report.AddSingleValue("Дата заказа", indexRow, 5);
            report.SetFontBold(indexRow, 1, indexRow, maxCol);
            report.SetBorders(indexRow, 1, indexRow, maxCol);
            report.SetCellAlignmentToCenter(indexRow, 1, indexRow, maxCol);
            report.SetCellAlignmentToJustify(indexRow, 1, indexRow, maxCol);
            report.SetWrapText(indexRow, 1, indexRow, maxCol);
            indexRow++;

            foreach (DataRow row in rows)
            {
                setValueToCell(indexRow, 1, $"{row["LastnameBuyer"]} {row["NameBuyer"]}");
                setValueToCell(indexRow, 2, row["Phone"]);
                setValueToCell(indexRow, 3, row["Email"]);
                setValueToCell(indexRow, 4, row["mainCount"]);
                setValueToCell(indexRow, 5, row["maxDate"]);

                report.SetBorders(indexRow, 1, indexRow, maxCol);
                report.SetCellAlignmentToJustify(indexRow, 1, indexRow, maxCol);
                report.SetCellAlignmentToCenter(indexRow, 1, indexRow, 5);
                report.SetCellAlignmentToRight(indexRow, 4, indexRow, 4);

                indexRow++;
            }

            report.Merge(indexRow, 1, indexRow, maxCol);
            report.AddSingleValue($"{bottonText} - {rows.Count()}", indexRow, 1);
            report.SetFontBold(indexRow, 1, indexRow, maxCol);
            report.SetBorders(indexRow, 1, indexRow, maxCol);
            indexRow++;
            indexRow++;
        }
    }
}
