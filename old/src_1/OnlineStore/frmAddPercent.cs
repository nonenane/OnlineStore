using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineStore
{
    public partial class frmAddPercent : Form
    {
        private int id = 0;
        private bool isEditData = false;
        
        public DataRowView row { set; private get; }
        public bool isGroup { set; private get; }
        
        public frmAddPercent()
        {
            InitializeComponent(); 
            ToolTip tp = new ToolTip();
            tp.SetToolTip(btClose, "Выход");
            tp.SetToolTip(btSave, "Сохранить");
        }

        private void frmAddPercent_Load(object sender, EventArgs e)
        {
            tbName.Text = (string)row["cName"];
            id = (int)row["id"];
            if (row["id_percent"] != DBNull.Value)
            {
                Text = "Редактирование процентов";

                if (row["MarkUpPercent"] != DBNull.Value)
                    tbMakeUpPercent.Text = ((decimal)row["MarkUpPercent"]).ToString("0.00");

                if (row["salePercent"] != DBNull.Value)
                    tbDiscount.Text = ((decimal)row["salePercent"]).ToString("0.00");

            }

            isEditData = false;
        }

        private void tbMakeUpPercent_KeyPress(object sender, KeyPressEventArgs e)
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

        private void frmAddPercent_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = isEditData && DialogResult.No == MessageBox.Show("На форме есть не сохранённые данные.\nЗакрыть форму без сохранения данных?\n", "Закрытие формы", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            decimal? MarkUpPercent = null;
            decimal? salePercent = null;

            if (tbMakeUpPercent.Text.Trim().Length > 0)
            {
                decimal valueMUP;

                if (!decimal.TryParse(tbMakeUpPercent.Text, out valueMUP))
                {
                    MessageBox.Show(Config.centralText($"Необходимо заполнить\n \"{label2.Text}\"\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbMakeUpPercent.Focus();
                    return;
                }

                if (valueMUP > 100)
                {
                    MessageBox.Show(Config.centralText($"\"{label2.Text}\" должен быть от 0 до 100\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbMakeUpPercent.Focus();
                    return;
                }
                MarkUpPercent = valueMUP;
            }

            if (tbDiscount.Text.Trim().Length > 0)
            {
                decimal valueMUP;

                if (!decimal.TryParse(tbDiscount.Text, out valueMUP))
                {
                    MessageBox.Show(Config.centralText($"Необходимо заполнить\n \"{label3.Text}\"\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbDiscount.Focus();
                    return;
                }

                if (valueMUP > 100)
                {
                    MessageBox.Show(Config.centralText($"\"{label3.Text}\" должен быть от 0 до 100\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbDiscount.Focus();
                    return;
                }
                salePercent = valueMUP;
            }

            Task<DataTable> task = Config.hCntMain.setPercentSettingsGroups(id, MarkUpPercent, salePercent, isGroup, 0, false);
            task.Wait();

            if (task.Result == null || task.Result.Rows.Count == 0)
            {
                MessageBox.Show("Не удалось сохранить данные", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if ((int)task.Result.Rows[0]["id"] == -9999)
            {
                MessageBox.Show($"{task.Result.Rows[0]["msg"].ToString()}", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            isEditData = false;
            MessageBox.Show("Данные сохранены.", "Сохранение данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
