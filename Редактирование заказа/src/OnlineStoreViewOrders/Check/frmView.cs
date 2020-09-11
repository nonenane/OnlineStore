using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nwuram.Framework.ToExcel;
using Nwuram.Framework.Settings.User;
using System.Diagnostics;
using Nwuram.Framework.Logging;

namespace OnlineStoreViewOrders.Check
{
    public partial class frmView : Form
    {

        public int doc_id { get; set; }
        public DateTime date { get; set; }
        public int terminal { get; set; }
        
        DataTable dtCheckInfo;
        public frmView()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvCheck_Init()
        {
            dtCheckInfo = Config.connect.getCheckInfo(doc_id, date, terminal);
            dgvCheck.AutoGenerateColumns = false;
            dgvCheck.DataSource = dtCheckInfo;
        }

        private void filter()
        {
            string search = "";
            if (tbName.Text.Trim().Length != 0)
                search += (search.Length == 0 ? "" : " and ") + (string.Format("nametovar like '%{0}%'", tbName.Text));
            if (tbEAN.Text.Trim().Length != 0)
                search += (search.Length == 0 ? "" : " and ") + (string.Format("ean like '%{0}%'", tbEAN.Text));

            dtCheckInfo.DefaultView.RowFilter = search;
        }

        private void frmView_Load(object sender, EventArgs e)
        {
            dgvCheck_Init();
            EnableButtons();
        }

        private void EnableButtons()
        {
            if (dtCheckInfo != null && dtCheckInfo.DefaultView.Count > 0)
                btnPrint.Enabled = true;
            else
                btnPrint.Enabled = false;
        }

        private void dgvCheck_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            tbEAN.Location = new Point(dgvCheck.Location.X, tbEAN.Location.Y);
            tbEAN.Size = new Size(cEan.Width - 3, tbEAN.Height);

            tbName.Location = new Point(dgvCheck.Location.X + cEan.Width, tbName.Location.Y);
            tbName.Size = new Size(cName.Width - 3, tbName.Height);


        }

        private void dgvCheck_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (dgv.Rows[e.RowIndex].Selected)
            {
                int width = dgv.Width;
                Rectangle r = dgv.GetRowDisplayRectangle(e.RowIndex, false);
                Rectangle rect = new Rectangle(r.X, r.Y, width - 3, r.Height - 1);

                ControlPaint.DrawBorder(e.Graphics, rect,
                    SystemColors.Highlight, 2, ButtonBorderStyle.Solid,
                    SystemColors.Highlight, 2, ButtonBorderStyle.Solid,
                    SystemColors.Highlight, 2, ButtonBorderStyle.Solid,
                    SystemColors.Highlight, 2, ButtonBorderStyle.Solid);
            }
        }

        private void dgvCheck_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            Color color = Color.White;
            if ((decimal)dtCheckInfo.DefaultView[e.RowIndex]["price"] < 0)
                color = pnlVozv.BackColor;
            dgvCheck.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;
               dgvCheck.Rows[e.RowIndex].DefaultCellStyle.BackColor =
               dgvCheck.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = color;
        }

        private void tbEAN_TextChanged(object sender, EventArgs e)
        {
            filter();
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            filter();
        }


        private void KillExcel()
        {
            Process[] prc = Process.GetProcessesByName("EXCEL");
            foreach (var a in prc)
                a.Kill();
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            KillExcel();
            HandmadeReport rep = new HandmadeReport();
           
            rep.AddSingleValue("Чек №" + doc_id.ToString(), 1, 1);
            rep.AddSingleValue("Отчет выгрузил: " + UserSettings.User.FullUsername,2,1);
            rep.AddSingleValue("Дата выгрузки: " + DateTime.Now.ToShortDateString(),3,1);
            rep.SetFontBold(1, 1, 3, 1);
            #region Columns
            rep.SetColumnWidth(1, 1, 1, 1, 14);
            rep.SetColumnWidth(2, 2, 2, 2, 45);
            rep.SetColumnWidth(3, 3, 3, 3, 7);
            rep.SetColumnWidth(4, 4, 4, 4, 7);
            rep.SetColumnWidth(5, 5, 5, 5, 7);
            #endregion Columns
            int crow = 5;
            int startrow = crow;
            #region Шапка
            rep.AddSingleValue("EAN", crow, 1);
            rep.AddSingleValue("Наименование", crow, 2);
            rep.AddSingleValue("Кол-во", crow, 3);
            rep.AddSingleValue("Цена", crow, 4);
            rep.AddSingleValue("Сумма", crow, 5);
            rep.SetFontBold(crow, 1, crow, 5);
            rep.SetCellAlignmentToCenter(crow, 1, crow, 5);
            rep.SetCellAlignmentToJustify(crow, 1, crow, 5);
            #endregion Шапка
            crow++;
            #region Тело
            foreach (DataRow dr in dtCheckInfo.Rows)
            {
                rep.AddSingleValue(dr["ean"].ToString(), crow, 1);
                rep.AddSingleValue(dr["nametovar"].ToString(), crow, 2);
                rep.AddSingleValue(dr["count"].ToString().Replace(',', '.'), crow, 3);
                rep.AddSingleValue(dr["price"].ToString().Replace(',', '.'), crow, 4);
                rep.AddSingleValue(dr["sumtovar"].ToString().Replace(',', '.'), crow, 5);
                if (dr["count"].ToString()[0] == '-')
                    rep.SetCellColor(crow, 1, crow, 5, 54);
                crow++;

            }
            #endregion Тело
            crow--;
            #region хрень всякая
            rep.SetWrapText(startrow, 1, crow, 5);
            rep.SetBorders(startrow, 1, crow, 5);
            rep.SetFormat(startrow + 1, 1, crow, 1, "0");
            rep.SetFormat(startrow + 1, 3, crow, 3, "0.000");
            rep.SetFormat(startrow + 1, 4, crow, 5, "0.00");
            rep.SetCellAlignmentToLeft(startrow + 1, 2, crow, 2);
            rep.SetCellAlignmentToRight(startrow + 1, 1, crow, 1);
            rep.SetCellAlignmentToRight(startrow + 1, 3, crow, 5);


            rep.SetCellColor(crow + 2, 1, crow + 2, 1, 54);
            rep.AddSingleValue("=\"-Возврат товара\"", crow + 2, 2);
            rep.Show();
            #endregion

            #region LOG
            Logging.StartFirstLevel(79);
            Logging.Comment("Начало выгрузки чека");
            Logging.Comment("Чек номер " + doc_id.ToString() + " от " + date.ToShortDateString() + " касса " + terminal.ToString());
            Logging.Comment("Окончание выгрузки отчета");
            Logging.StopFirstLevel();
            
            #endregion LOG
        }
    }
}
