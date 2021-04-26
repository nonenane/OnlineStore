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
using Nwuram.Framework.Logging;


namespace OnlineStore.dictonatyTovar
{
    public partial class frmAddTovar : Form
    {
        public int id { set; private get; }
        public DataRowView row { set; private get; }
        private bool isEdit = false;
        private DataTable dtTemp;

        private int id_tovar, id_otdel;

        #region Начальные значения для лога
        private string old_ean;
        private string old_ShortName;
        private string old_FullName;
        private decimal old_rcenaOnline;
        private decimal old_actionPrice;
        private bool old_isActive;
        private int old_category;
        private decimal old_minOrder;
        private decimal old_maxOrder;
        private decimal old_Step;
        private decimal old_defaultNetto;
        private string old_priceSuffix;
        private string old_quanSuffix;
        private string old_ShortDescription;
        #endregion

        public frmAddTovar()
        {
            InitializeComponent();
            ToolTip tt = new ToolTip();
            tt.SetToolTip(btSave, "Сохранить");
            tt.SetToolTip(btClose, "Выход");
        }

        private void frmAddTovar_Load(object sender, EventArgs e)
        {
            if (id != 0)
            {
                id_tovar = (int)row["id_Tovar"];
                id_otdel = (int)row["id_otdel"];

                tbEan.Text = old_ean = (string)row["ean"];
                tbShotName.Text = old_ShortName = (string)row["ShortName"];
                tbShortDescription.Text = old_ShortDescription = row["ShortDescription"].ToString();
                tbFullName.Text = old_FullName = (string)row["FullName"];

                tbRcena.Text = ((decimal)row["rcena"]).ToString("0.00");

                tbPricePercent.Text = ((decimal)row["rcenaOnline"]).ToString("0.00");
                old_rcenaOnline = (decimal)row["rcenaOnline"];
                tbActionPrice.Text = ((decimal)row["rcenaPromo"]).ToString("0.00");
                old_actionPrice = (decimal)row["rcenaPromo"];
                chbActive.Checked = old_isActive = (bool)row["isActive"];
                init_combobox();
                cmbParentCategory.SelectedValue = old_category = (int)row["id_Category"];
                tbEan.Enabled = false;
                addTovarData();
                if (tbEan.Text.Trim().Length == 4)
                {
                    tbMinOrder.Text = ((decimal)row["MinOrder"]).ToString("0.000");
                    tbMaxOrder.Text = ((decimal)row["MaxOrder"]).ToString("0.000");
                    tbStep.Text = ((decimal)row["Step"]).ToString("0.000");
                    tbDefaultNetto.Text = ((decimal)row["DefaultNetto"]).ToString("0.000");
                    tbPriceSuffix.Text = old_priceSuffix = (string)row["PriceSuffix"];
                    tbQuantitySuffix.Text = old_quanSuffix = (string)row["QuantitySuffix"];
                    old_minOrder = (decimal)row["MinOrder"];
                    old_maxOrder = (decimal)row["MaxOrder"];
                    old_Step = (decimal)row["Step"];
                    old_defaultNetto = (decimal)row["DefaultNetto"];
                }

                //предложение по замене цены здесь и сейчас :)
                decimal rcena = (decimal)row["rcena"];
                decimal percent = (decimal)row["MarkUpPercent"];
                decimal pricePercent = (decimal)row["rcenaOnline"];
                if (Math.Round(pricePercent, 2) != Math.Truncate((rcena * (100 + percent)))/100)
                {
                    if (DialogResult.Yes == MessageBox.Show(Config.centralText("Цена товара изменилась.\nХотите поменять цену на сайте?\n"), "Редактирование товара", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                        tbPricePercent.Text = (Math.Truncate((rcena * (100 + percent))) / 100).ToString("0.00");
                }

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
                init_tovar_data();
            }
        }

        private void init_tovar_data()
        {
            //тут получение данных по товару
            Task<DataTable> task = Config.hCntMain.getGoods(tbEan.Text.Trim());
            task.Wait();

            if (task.Result == null)
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
            if ((bool) task.Result.Rows[0]["ExistTovar"])
            {
                MessageBox.Show(Config.centralText("Товар уже добавлен на сайт.\n"), "Добавление товара", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clearValue();
                return;
            }

            tbActionPrice.Clear();
            id_tovar = (int)task.Result.Rows[0]["id_tovar"];
            tbShotName.Text = (string)task.Result.Rows[0]["cNameShort"];            
            tbFullName.Text = (string)task.Result.Rows[0]["cNameFull"];
            tbShortDescription.Text = (string)task.Result.Rows[0]["cNameFull"];
            tbRcena.Text = ((decimal)task.Result.Rows[0]["rcena"]).ToString("0.00");
            
            
            
           // tbPricePercent.Text = (((decimal)task.Result.Rows[0]["rcena"]) *((decimal)(100 + Config.Margin)/100)).ToString("0.00");

            tbPricePercent.Text = (Math.Truncate(((decimal)task.Result.Rows[0]["rcena"] * (100 + (decimal) task.Result.Rows[0]["MarkUpPercent"]) / 100) * 100) / 100).ToString("0.00");

            id_otdel = (int)task.Result.Rows[0]["id_otdel"];
            init_combobox();
            addTovarData();
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
            string shortDescription = tbShortDescription.Text.Trim();
            int id_category = (int)cmbParentCategory.SelectedValue;
            decimal rcena = decimal.Parse(tbPricePercent.Text);
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


            task = Config.hCntMain.setDicGoods(id, id_tovar, shortname, fullName, id_category, rcena, actionPrice, isActive, shortDescription);
            task.Wait();

            if (task.Result == null)
            {
                MessageBox.Show(Config.centralText("При сохранение данных возникли ошибки записи.\nОбратитесь в ОЭЭС\n"), "Сохранение данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            id = (int)task.Result.Rows[0]["id"];


            decimal MinOrder = 0;
            decimal MaxOrder = -1;
            decimal Step = 0;
            decimal DefaultNetto = 0;
            string PriceSuffix = "";
            string QuantitySuffix = "";
            if (tbEan.Text.Trim().Length == 4)
            {
                MinOrder = decimal.Parse(tbMinOrder.Text);

                decimal.TryParse(tbMaxOrder.Text, out MaxOrder);
                //MaxOrder = decimal.Parse(tbMaxOrder.Text);
                Step = decimal.Parse(tbStep.Text);
                DefaultNetto = decimal.Parse(tbDefaultNetto.Text);
                PriceSuffix = tbPriceSuffix.Text.Trim();
                QuantitySuffix = tbQuantitySuffix.Text.Trim();


                task = Config.hCntMain.setAttribute(id, id, MinOrder, MaxOrder, Step, DefaultNetto, PriceSuffix, QuantitySuffix);
                task.Wait();

                if (task.Result == null)
                {
                    MessageBox.Show(Config.centralText("При сохранение данных возникли ошибки записи.\nОбратитесь в ОЭЭС\n"), "Сохранение данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }


            MessageBox.Show("Данные сохранены", "Сохранение данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
            isEdit = false;
            this.DialogResult = DialogResult.OK;

            #region Логирование
            if (tbEan.Enabled) //если можно редактировать поле ean - это добавление
            {
                Logging.StartFirstLevel(5);
                Logging.Comment("Добавление товара артикул: " + id_tovar);
                Logging.Comment("EAN: " + tbEan.Text);
                Logging.Comment("Короткое наименование товара: " + shortname);
                Logging.Comment("Полное наименование товара: " + fullName);
                Logging.Comment($"Короткое описание товара: {shortDescription}");
                Logging.Comment("Категория товара: " + cmbParentCategory.Text);
                Logging.Comment("ID категории товара: " + id_category);
                Logging.Comment("Базовая цена товара: " + rcena);
                Logging.Comment("Акционная цена товара: " + actionPrice);
                Logging.Comment("Действующий товар: " + chbActive.Checked);
                if (cmbParentCategory.SelectedValue!=null)
                {
                    Logging.Comment($"Категория id: {cmbParentCategory.SelectedValue.ToString()}, Наименование: {cmbParentCategory.Text}");
                }
                if (tbEan.Text.Trim().Length==4)
                {
                    Logging.Comment("Минимальное количество заказа: " + MinOrder);
                    
                    if (MaxOrder!=-1)
                        Logging.Comment("Масимальное количество заказа: " + MaxOrder);
                    Logging.Comment("Возможный шаг количества при заказе товара: " + Step);
                    Logging.Comment("Значение заказанного товара по умолчанию: " + DefaultNetto) ;
                    Logging.Comment("Суффикс к цене товара: " + PriceSuffix);
                    Logging.Comment("Суффикс к количеству товара: " + QuantitySuffix);
                }
                Logging.Comment("Окончание добавления товара");
                Logging.StopFirstLevel();
            }
            else //иначе редактирование
            {
                bool mainInform = false;
                if (!(shortname == old_ShortName && fullName == old_FullName && id_category == old_category && rcena == old_rcenaOnline
                    && actionPrice == old_actionPrice && chbActive.Checked == old_isActive))
                {
                    Logging.StartFirstLevel(36);
                    Logging.Comment("Редактирование товара артикул: " + id_tovar);
                    Logging.Comment("EAN товара: " + tbEan.Text);
                    Logging.VariableChange("Короткое наименование товара", shortname, old_ShortName);
                    Logging.VariableChange("Полное наименование товара", fullName, old_FullName);
                    Logging.VariableChange("Короткое описание товара", shortDescription, old_ShortDescription);
                    Logging.VariableChange("Категория товара", id_category, old_category);
                    Logging.VariableChange("Базовая цена товара", rcena, old_rcenaOnline);
                    Logging.VariableChange("Акционная цена товара", (actionPrice == null ? 0 : actionPrice), old_actionPrice);
                    Logging.VariableChange("Действующий товар", chbActive.Checked, old_isActive);
                    mainInform = true;
                }
                if (tbEan.Text.Trim().Length==4)
                {
                    if (!mainInform)
                    {
                        Logging.StartFirstLevel(36);
                        Logging.Comment("Редактирование товара артикул: " + id_tovar);
                        Logging.Comment("Наименование товара: " + fullName);
                        Logging.Comment("EAN товара: " + tbEan.Text);
                    }
                    Logging.VariableChange("Минимальное количество заказа", MinOrder, old_minOrder);
                    if (MaxOrder!=-1)
                        Logging.VariableChange("Максимальное количество заказа", MaxOrder, old_maxOrder);
                    Logging.VariableChange("Возможный шаг количества при заказе", Step, old_Step);
                    Logging.VariableChange("Значение заказанного товара по умолчанию", DefaultNetto, old_defaultNetto);
                    Logging.VariableChange("Суффикс к цене товара", PriceSuffix, old_priceSuffix);
                    Logging.VariableChange("Суффикс к количеству товара", QuantitySuffix, old_quanSuffix);
                }
                Logging.Comment("Окончание редактирования товара");
                Logging.StopFirstLevel();
            }
            #endregion
        }

        private bool validateToSave()
        {
            if (id_tovar == 0) { MessageBox.Show(Config.centralText("Необходимо заполнить поле \"EAN\"\n товара для заполнения данных на форме!\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning); tbEan.Focus(); return false; }
            if (tbShotName.Text.Trim().Length == 0) { MessageBox.Show("Необходимо заполнить \"Короткое наименование товара\"!", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning); tbShotName.Focus(); return false; }
            if (tbFullName.Text.Trim().Length == 0) { MessageBox.Show("Необходимо заполнить \"Полное наименование товара\"!", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning); tbFullName.Focus(); return false; }
            if (tbShortDescription.Text.Trim().Length == 0) { MessageBox.Show("Необходимо заполнить \"Короткое описание товара\"!", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning); tbShortDescription.Focus(); return false; }
            if (cmbParentCategory.SelectedIndex == -1 || cmbParentCategory.SelectedValue == null) { MessageBox.Show("Необходимо выбрать \"Категорию товара\"!", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning); cmbParentCategory.Focus(); return false; }
        
            /*if (tbActionPrice.Text.Trim().Length ==0)
            {
                MessageBox.Show("Необходимо ввести цену для распродажи", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }*/
            decimal _tmpValue = 0, _tmpPrice = 0;

            if (!decimal.TryParse(tbPricePercent.Text, out _tmpPrice))
            { MessageBox.Show("Необходимо заполнить \"Цену товара\"!", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning); tbRcena.Focus(); return false; }

            if(_tmpPrice==0)
            { MessageBox.Show("Необходимо заполнить \"Цену товара\"!", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning); tbRcena.Focus(); return false; }

            if (tbActionPrice.Text.Trim().Length > 0 && !decimal.TryParse(tbActionPrice.Text, out _tmpValue))
            {
                MessageBox.Show("Необходимо заполнить \"Акционную цену товара\"!", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning); tbActionPrice.Focus(); return false;
            }
            if (tbActionPrice.Text.Trim().Length > 0)
                if (_tmpPrice > _tmpValue && _tmpValue!=0)
                { MessageBox.Show(Config.centralText("Цена продажи онлайн должна быть\n меньше старой цены товара!\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning); tbActionPrice.Focus(); return false; }


            if (tbEan.Text.Trim().Length == 4)
            {
                if (tbMinOrder.Text.Trim().Length == 0)
                {
                    MessageBox.Show(Config.centralText($"Необходимо заполнить:\n \"{lMinOrder.Text.Replace(":", "")}\"!\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbMinOrder.Focus(); return false;
                }
               /* if (tbMaxOrder.Text.Trim().Length == 0)
                {
                    MessageBox.Show(Config.centralText($"Необходимо заполнить:\n \"{lMaxOrder.Text.Replace(":", "")}\"!\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbMaxOrder.Focus(); return false;
                }*/
                if (tbStep.Text.Trim().Length == 0)
                {
                    MessageBox.Show(Config.centralText($"Необходимо заполнить:\n \"{lStep.Text.Replace(":", "")}\"!\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbStep.Focus(); return false;
                }
                if (tbDefaultNetto.Text.Trim().Length == 0)
                {
                    MessageBox.Show(Config.centralText($"Необходимо заполнить:\n \"{lDefaultNetto.Text.Replace(":", "")}\"!\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbDefaultNetto.Focus(); return false;
                }
                if (tbPriceSuffix.Text.Trim().Length == 0)
                {
                    MessageBox.Show(Config.centralText($"Необходимо заполнить:\n \"{lPriceSuffix.Text.Replace(":", "")}\"!\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbPriceSuffix.Focus(); return false;
                }
                if (tbQuantitySuffix.Text.Trim().Length == 0)
                {
                    MessageBox.Show(Config.centralText($"Необходимо заполнить:\n \"{lQuantitySuffix.Text.Replace(":", "")}\"!\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbQuantitySuffix.Focus(); return false;
                }

                decimal _tmpMin = 0, _tmpMax = -1, _tmpDefault = 0,_tmpStep = 0;

                if (!decimal.TryParse(tbMinOrder.Text, out _tmpMin))
                {
                    MessageBox.Show(Config.centralText($"Необходимо заполнить:\n \"{lMinOrder.Text.Replace(":", "")}\"!\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbMinOrder.Focus(); return false;
                }

                if (_tmpMin < 0 || _tmpMin > 100)
                {
                    MessageBox.Show(Config.centralText($"Значение \"{lMinOrder.Text.Replace(":", "")}\"\n должно быть от 0 до 100.\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbMinOrder.Focus(); return false;
                }

                bool _maxParsed = decimal.TryParse(tbMaxOrder.Text, out _tmpMax);

               /* if (!decimal.TryParse(tbMaxOrder.Text, out _tmpMax))
                {
                    MessageBox.Show(Config.centralText($"Необходимо заполнить:\n \"{lMaxOrder.Text.Replace(":", "")}\"!\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbMaxOrder.Focus(); return false;
                }
                */
                if (_maxParsed)
                    if (_tmpMax < 0 || _tmpMax > 100)
                    {
                        MessageBox.Show(Config.centralText($"Значение \"{lMaxOrder.Text.Replace(":", "")}\"\n должно быть от 0 до 100.\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbMaxOrder.Focus(); return false;
                    }
                
                if (_maxParsed)
                    if (_tmpMin > _tmpMax)
                    {
                        MessageBox.Show(Config.centralText($"Минимальное количество заказа должно быть меньше\n Максимального количества заказа!\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbMinOrder.Focus(); return false;
                    }
                if (_maxParsed)
                    if (!decimal.TryParse(tbDefaultNetto.Text, out _tmpDefault))
                    {
                        MessageBox.Show(Config.centralText($"Необходимо заполнить:\n \"{lDefaultNetto.Text.Replace(":", "")}\"!\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbDefaultNetto.Focus(); return false;
                    }

                if (_tmpDefault < 0 || _tmpDefault > 100)
                {
                    MessageBox.Show(Config.centralText($"Значение \"{lDefaultNetto.Text.Replace(":", "")}\"\n должно быть от 0 до 100.\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbDefaultNetto.Focus(); return false;
                }
                if (_maxParsed)
                    if (_tmpDefault < _tmpMin || _tmpDefault > _tmpMax)
                    {
                        MessageBox.Show(Config.centralText($"Значение заказанного товара по умолчанию\nдолжно быть от {_tmpMin.ToString("0.000")} до {_tmpMax.ToString("0.000")} \n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbDefaultNetto.Focus(); return false;
                    }

                if (!decimal.TryParse(tbStep.Text, out _tmpStep))
                {
                    MessageBox.Show(Config.centralText($"Необходимо заполнить:\n \"{lStep.Text.Replace(":", "")}\"!\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbStep.Focus(); return false;
                }

                if (_tmpStep < 0 || _tmpStep > 100)
                {
                    MessageBox.Show(Config.centralText($"Значение \"{lStep.Text.Replace(":", "")}\"\n должно быть от 0 до 100.\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbStep.Focus(); return false;
                }
                if (_maxParsed)
                    if (_tmpStep > _tmpMax / 2)
                    {
                        MessageBox.Show(Config.centralText($"Значение \"{lStep.Text.Replace(":", "")}\"\n должно быть от 0 до {(_tmpMax / 2).ToString("0.000")}.\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbStep.Focus(); return false;
                    }

            }

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
                dtCategory.DefaultView.RowFilter = "isActive = 1 and isParent = 0";
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

        private void tbMinOrder_Validating(object sender, CancelEventArgs e)
        {
            TextBox tb = (sender as TextBox);
            string text = tb.Text;

            if (text.Trim().Length == 0) return;

            decimal value;
            if (!decimal.TryParse(text, out value))
            { e.Cancel = true; return; }

            //if (tb.Name.Equals(tbDefaultNetto.Name))
            //{
            //    decimal valueMin, valueMax;
            //    if (decimal.TryParse(tbMinOrder.Text, out valueMin))
            //        if (decimal.TryParse(tbMaxOrder.Text, out valueMax))
            //            if (value < valueMin || value > valueMax) { e.Cancel = true; return; }
            //}
            //else
            //if (value < 0 || value > 100)
            //{ e.Cancel = true; return; }

            tb.Text = value.ToString("0.000");
        }

        private void tbEan_Validating(object sender, CancelEventArgs e)
        {
            if (tbEan.Enabled && tbEan.Text.Trim().Length>0)
                init_tovar_data();
        }

        private void tbRcena_Validating(object sender, CancelEventArgs e)
        {
            TextBox tb = (sender as TextBox);
            string text = tb.Text;

            if (text.Trim().Length == 0) return;

            decimal value;
            if (!decimal.TryParse(text, out value))
            { e.Cancel = true; return; }

            //if (value < 0 || value > 100)
            //    e.Cancel = true;

            tb.Text = value.ToString("0.00");
        }

        private void tbMinOrder_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbMinOrder_Leave(object sender, EventArgs e)
        {
           
        }

        private void tbMinOrder_Validated(object sender, EventArgs e)
        {
            tbDefaultNetto.Text = tbMinOrder.Text;
        }

        private void addTovarData()
        {
            if (tbEan.Text.Trim().Length != 4)
                this.Size = new Size(480, this.Height);
            else
                this.Size = new Size(880, this.Size.Height);
        }
    }
}
