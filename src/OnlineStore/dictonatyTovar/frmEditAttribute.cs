using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nwuram.Framework.Logging;

namespace OnlineStore.dictonatyTovar
{
    public partial class frmEditAttribute : Form
    {

        DataTable dtDeps, dtGroups;
        public frmEditAttribute()
        {
            InitializeComponent();
        }

        private void frmEditAttribute_Load(object sender, EventArgs e)
        {
            ToolTip btn = new ToolTip();
            btn.SetToolTip(btnExit, "Выход");
            btn.SetToolTip(btnAccept, "Обновить");
            dgvGroups.AutoGenerateColumns = false;
            cbDeps_Init();
            dgvGroups_Init();
        }

        private void cbDeps_Init()
        {

            Task<DataTable> task = Config.hCntMain.getDeps();
            task.Wait();
            dtDeps = task.Result;       
                cbDeps.DataSource = dtDeps;
                cbDeps.DisplayMember = "cName";
                cbDeps.ValueMember = "id";                    
        }

        private void cbDeps_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dgvGroups_Init();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvGroups_Init()
        {
            int id_otdel = -1;
         
                id_otdel = (int)cbDeps.SelectedValue;
            Task<DataTable> task = Config.hCntMain.GetInvGroup(id_otdel);
            task.Wait();
            dtGroups = task.Result;         
            dgvGroups.DataSource = dtGroups;
            dtGroups.DefaultView.RowFilter = "id_unit = 1";
        }

        private void tbDecimal_Validating(object sender, CancelEventArgs e)
        {
            TextBox tb = (sender as TextBox);
            string text = tb.Text;

            if (text.Trim().Length == 0) return;

            decimal value;
            if (!decimal.TryParse(text, out value))
            { e.Cancel = true; return; }
            tb.Text = value.ToString("0.000");
        }

        private void tbMin_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            string selectedGroups = "";
            foreach (DataRow dr in dtGroups.DefaultView.ToTable().Rows)
            {
                if (dr["selectedAtt"].ToString() == "True")
                    selectedGroups += dr["id"].ToString() + ",";
            }
            if (selectedGroups.Length == 0)
            {
                MessageBox.Show("Должна быть выбрана хотя бы одна группа", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            selectedGroups = selectedGroups.Substring(0, selectedGroups.Length - 1);

            Task<DataTable> task = Config.hCntMain.setAttributeGroup(selectedGroups,
                tbMin.Text.Trim().Length==0? null : tbMin.Text,
                tbMax.Text.Trim().Length==0? null: tbMax.Text,
                tbStep.Text.Trim().Length==0? null: tbStep.Text,
                tbDefault.Text.Trim().Length==0? null : tbDefault.Text,
                tbPriceSuffix.Text.Trim().Length==0 ? null: tbPriceSuffix.Text,
                tbQuantitySuffix.Text.Trim().Length ==0 ? null: tbQuantitySuffix.Text);
            task.Wait();
            MessageBox.Show("Атрибуты товаров для выбранных групп обновлены");
            setLog();
            Clear();
        }

        private void Clear()
        {
            tbMin.Text = tbMax.Text = tbDefault.Text = tbPriceSuffix.Text = tbQuantitySuffix.Text = tbStep.Text = "";
            foreach (DataRow dr in dtGroups.Rows)
            {
                dr["selectedAtt"] = false;
            }
            dtGroups.AcceptChanges();
        }
        private void setLog()
        {
            Logging.StartFirstLevel(1588);
            Logging.Comment("Добавление атрибутов группам");
            Logging.Comment($"id отдела: {cbDeps.SelectedValue.ToString()}, Наименование: {cbDeps.Text}");
            string strGroups = "Группы: ";
            foreach (DataRow dr in dtGroups.DefaultView.ToTable().Rows)
            {
                if ((bool)dr["selectedAtt"])
                {
                    strGroups += $"id: {dr["id"]}, Наименование: {dr["cname"]};";
                }
            }
            Logging.Comment(strGroups);
            Logging.Comment("Значения атрибутов");
            Logging.Comment($"Минимальное кол-во заказа: {tbMin.Text}");
            Logging.Comment($"Максимальное кол-во заказа: {tbMax.Text}");
            Logging.Comment($"Шаг кол-ва заказа: {tbStep.Text}");
            Logging.Comment($"Кол-во товара по умолчанию: {tbDefault.Text}");
            Logging.Comment($"Суффикс к цене товара: {tbPriceSuffix.Text}");
            Logging.Comment($"Суффикс к кол-ву товара: {tbQuantitySuffix.Text}");
            Logging.Comment("Завершение добавления атрибутов группам");
            Logging.StopFirstLevel();
        }
        private void dgvGroups_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex > -1)
                dtGroups.DefaultView[e.RowIndex]["selectedAtt"] = !(bool)dtGroups.DefaultView[e.RowIndex]["selectedAtt"];
        }

        private void dgvGroups_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void dgvGroups_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex != -1 && dtGroups != null && dtGroups.DefaultView.Count != 0)
            {
                Color rColor = Color.White;
                dgvGroups.Rows[e.RowIndex].DefaultCellStyle.BackColor = rColor;
                dgvGroups.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = rColor;
                dgvGroups.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;
            }
        }

        private bool selected = true;
        private void dgvGroups_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == cSelect.Index)
            {
                foreach (DataRow dr in dtGroups.Rows)
                {
                    dr["selectedAtt"] = selected;
                }
                selected = !selected;
                dtGroups.AcceptChanges();
            }
        }

        private void tbGroup_TextChanged(object sender, EventArgs e)
        {
            setFilter();
        }

        private void setFilter()
        {
            string filter = "";
            try
            {
                filter += (filter.Length == 0 ? "" : " and ") + $"cname like '%{tbGroup.Text}%'";
                dtGroups.DefaultView.RowFilter = filter;
            }
            catch
            {
                filter = "id = -1";
            }

            dtGroups.DefaultView.RowFilter = filter;
        }

        private void tbDecimal_KeyPress(object sender, KeyPressEventArgs e)
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


    }
}
