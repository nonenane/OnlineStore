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

            DataTable dtData = Config.connect.getReportData(dtpStart.Value, dtpEnd.Value, 4);

            Nwuram.Framework.ToExcelNew.ExcelUnLoad report = new Nwuram.Framework.ToExcelNew.ExcelUnLoad();

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

            report.Show();
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
