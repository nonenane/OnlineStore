using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CsvHelper;


namespace OnlineStore.dictonatyTovar
{
    public partial class frmAddTovar : Form
    {
        public int id { set; private get; }
        public DataRowView row { set; private get; }
        private bool isEdit = false;
        private DataTable dtTemp;

        private int id_tovar, id_otdel;

        public frmAddTovar()
        {
            InitializeComponent();
        }

        private void frmAddTovar_Load(object sender, EventArgs e)
        {
            if (id != 0)
            {
                id_tovar = (int)row["id_Tovar"];
                id_otdel = (int)row["id_otdel"];

                tbEan.Text = (string)row["ean"];
                tbShotName.Text = (string)row["ShortName"];
                tbFullName.Text = (string)row["FullName"];
                tbRcena.Text = ((decimal)row["rcenaOnline"]).ToString("0.00");
                tbActionPrice.Text = ((decimal)row["rcenaPromo"]).ToString("0.00");
                chbActive.Checked = (bool)row["isActive"];
                init_combobox();
                cmbParentCategory.SelectedValue = (int)row["id_Category"];
                tbEan.Enabled = false;
            }
        }

        private void frmAddTovar_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = isEdit && MessageBox.Show(Config.centralText("На форме есть несохранёные данные.\nЗакрыть форму без сохранения данных?\n"), "Закрытие формы", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No;
        }

        private void tbInt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                e.Handled = true;
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

        private void tbName_KeyDown(object sender, KeyEventArgs e)
        {
            if (tbEan.Enabled && e.KeyCode == Keys.Enter)
            {
                //тут получение данных по товару
                Task<DataTable> task = Config.hCntMain.getGoods(tbEan.Text.Trim());
                task.Wait();

                if(task.Result==null)
                {
                    MessageBox.Show(Config.centralText("При получение данных возникли ошибки.\nОбратитесь в ОЭЭС\n"), "Получение данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    clearValue();
                    return;
                }

                if ((int)task.Result.Rows[0]["id"] != 0)
                {
                    int error = (int)task.Result.Rows[0]["id"];
                    if (error == -1)
                        MessageBox.Show(Config.centralText("Товар не найден.\n"), "Получение данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if (error == -2)
                        MessageBox.Show(Config.centralText("Товар резервный или уценённый.\n"), "Получение данных", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    clearValue();
                    return;
                }

                tbActionPrice.Clear();
                id_tovar = (int)task.Result.Rows[0]["id_tovar"];
                tbShotName.Text = (string)task.Result.Rows[0]["cNameShort"];
                tbFullName.Text = (string)task.Result.Rows[0]["cNameFull"];
                tbRcena.Text = ((decimal)task.Result.Rows[0]["rcena"]).ToString("0.00");
                id_otdel= (int)task.Result.Rows[0]["id_otdel"];
                init_combobox();
            }
        }

        private void clearValue()
        {
            tbEan.Clear();
            tbFullName.Clear();
            tbShotName.Clear();
            tbActionPrice.Clear();
            tbRcena.Clear();
            id_tovar = 0;
            id_otdel = -1;
            init_combobox();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (!validateToSave()) return;

            string shortname = tbShotName.Text.Trim();
            string fullName = tbFullName.Text.Trim();
            int id_category = (int)cmbParentCategory.SelectedValue;
            decimal rcena = decimal.Parse(tbRcena.Text);
            decimal? actionPrice = null;
            if (tbActionPrice.Text.Trim().Length > 0)
                actionPrice = decimal.Parse(tbActionPrice.Text);
            bool isActive = chbActive.Checked;

            Task<DataTable> task = Config.hCntMain.validateDicGoods(id, id_tovar);
            task.Wait();

            if (task.Result == null)
            {
                MessageBox.Show(Config.centralText("При проверке данных возникли ошибки записи.\nОбратитесь в ОЭЭС\n"), "Сохранение данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if ((int)task.Result.Rows[0]["id"] == -1)
            {
                MessageBox.Show(Config.centralText("В справочнике уже присутствует\n данный товар.\n"), "Сохранение данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            task = Config.hCntMain.setDicGoods(id, id_tovar, shortname, fullName, id_category, rcena, actionPrice, isActive);
            task.Wait();

            if (task.Result == null)
            {
                MessageBox.Show(Config.centralText("При сохранение данных возникли ошибки записи.\nОбратитесь в ОЭЭС\n"), "Сохранение данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            MessageBox.Show("Данные сохранены", "Сохранение данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
            isEdit = false;
            this.DialogResult = DialogResult.OK;
        }

        private bool validateToSave()
        {
            if (id_tovar == 0) { MessageBox.Show("Необходимо выбрать товар!", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning); tbEan.Focus(); return false; }
            if (tbShotName.Text.Trim().Length == 0) { MessageBox.Show("Необходимо заполнить \"Короткое наименование товара\"!", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning); tbShotName.Focus(); return false; }
            if (tbFullName.Text.Trim().Length == 0) { MessageBox.Show("Необходимо заполнить \"Полное наименование товара\"!", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning); tbFullName.Focus(); return false; }
            if (cmbParentCategory.SelectedIndex == -1 || cmbParentCategory.SelectedValue == null) { MessageBox.Show("Необходимо выбрать \"Категорию товара\"!", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning); cmbParentCategory.Focus(); return false; }

            decimal _tmpValue;

            if (!decimal.TryParse(tbRcena.Text, out _tmpValue))
            { MessageBox.Show("Необходимо заполнить \"Цену товара\"!", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning); tbRcena.Focus(); return false; }

            if (tbActionPrice.Text.Trim().Length > 0 && !decimal.TryParse(tbActionPrice.Text, out _tmpValue))
            { MessageBox.Show("Необходимо заполнить \"Акционную цену товара\"!", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning); tbActionPrice.Focus(); return false; }

            return true;
        }

        private void init_combobox()
        {
            Task<DataTable> task = Config.hCntMain.getDicCategoryWithDep(id_otdel);
            task.Wait();
            DataTable dtCategory = task.Result;
            task = null;

            if (dtCategory != null && dtCategory.Rows.Count > 0)
            {
                dtCategory.DefaultView.RowFilter = "isActive = 1";
            //    EnumerableRowCollection<DataRow> rowCollect = dtCategory.AsEnumerable().Where(r => r.Field<object>("id") == null || r.Field<object>("id") != DBNull.Value );
            //    if (rowCollect.Count() > 0)
            //    {
            //        rowCollect.First().Delete();
            //        dtCategory.AcceptChanges();
            //    }
            }

            cmbParentCategory.DataSource = dtCategory;
            cmbParentCategory.DisplayMember = "cName";
            cmbParentCategory.ValueMember = "id";
            cmbParentCategory.SelectedIndex = -1;
        }
    }
}
