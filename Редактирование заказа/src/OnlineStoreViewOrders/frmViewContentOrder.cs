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
using Nwuram.Framework.Settings.User;

namespace OnlineStoreViewOrders
{
    public partial class frmViewContentOrder : Form
    {
        public frmViewContentOrder()
        {
            InitializeComponent();
        }
        public int idTOrder { get; set; }
        public bool needConnect2 { get; set; }
        public DateTime dateOrder { get; set; }
        public int numOrder { get; set; }

        public bool isEdit { get; private set; } = false;
        /// <summary>
        /// 0 - просмотр 1- редактирование
        /// </summary>
        public int callType { get; set; }
        DataTable dtGoods;
        DataTable dtGoodsOld;
        private void frmViewContentOrder_Load(object sender, EventArgs e)
        {
            this.Text = (callType==0 ? "Просмотр " : "Редактирование ") + "заказа № " + numOrder.ToString() + " от " + dateOrder.ToShortDateString();
            GetGoods();
            GetSum();
            GetBrutto();
            ToolTip ttButton = new ToolTip();
            ttButton.SetToolTip(btnExit, "Выход");
            ttButton.SetToolTip(btnAddTovar, "Добавить товар");
            ttButton.SetToolTip(btnSave, "Сохранить");
            if (UserSettings.User.StatusCode == "РКВ")
            {
                lblSum.Visible = false;
                dgvOrder.Columns["Netto"].ReadOnly = true;
            }
            if (UserSettings.User.StatusCode.ToLower() == "пр")
                setEnabledPR();

            if (callType == 0)
            {
                setEnabledPR();
            }
        }

        private void setEnabledPR()
        {
            dgvOrder.ReadOnly = true;
            btnAddTovar.Enabled = btnSave.Enabled = false;
        }

        private void GetBrutto()
        {
            decimal brutto = 0;
            foreach (DataRow dr in dtGoods.Rows)
            {
                if (dr["ean"].ToString().Trim().Length == 4)
                    brutto += Convert.ToDecimal(dr["Netto"].ToString().Replace('.',','));
                else
                    brutto += Convert.ToDecimal(dr["Netto"].ToString().Replace('.', ',')) * Convert.ToDecimal(dr["brutto"].ToString().Replace('.', ','));
            }
            label2.Text = "Вес заказа: " + Math.Round(brutto,3) + " кг.";
        }

        private void GetSum()
        {
            decimal sum = 0;
            foreach (DataRow dr in dtGoods.Rows)
            {
                sum += (decimal) dr["sumTovar"];
            }
            lblSum.Text = "Сумма заказа: " + sum.ToString() + " руб.";
        }
        private void GetGoods()
        {
            DataTable dtBuf;
            dtGoods = Config.connect.Get_Goods(idTOrder);

            dtGoodsOld = dtGoods.Copy();
            dgvOrder.AutoGenerateColumns = false;
            dgvOrder.DataSource = dtGoods;
            FilterGoods();
        }

        private void FilterGoods()
        {
            try
            {
                string search = "";
                if (UserSettings.User.StatusCode == "РКВ")                
                    search += "id_Departments = " + UserSettings.User.IdDepartment;

                if (tbName.Text.Trim().Length != 0)
                    search += (search.Length == 0 ? "" : " and ") + (string.Format("nameTovar like '%{0}%'", tbName.Text));
                if (tbEan.Text.Trim().Length != 0)
                    search += (search.Length == 0 ? "" : " and ") + (string.Format("ean like '%{0}%'", tbEan.Text));
                if (!chckDeleted.Checked)
                    search += (search.Length == 0 ? "" : " and ") + "Netto <> 0";
                dtGoods.DefaultView.RowFilter = search;
            }
            catch
            {

            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            if (CompareDataTable())
            {
                if (DialogResult.Yes == MessageBox.Show("Данные были изменены, Выйти без сохранения?", "Запрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    this.Close();
                }
                else
                    return;
            }
            this.Close();
        }

        private void tbEan_TextChanged(object sender, EventArgs e)
        {
            FilterGoods();
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            FilterGoods();
        }

        private void dgvOrder_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void dgvOrder_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            Color rowcolor = Color.White;

            if (dtGoods.DefaultView[e.RowIndex]["Price"].ToString().Replace('.',',') != dtGoods.DefaultView[e.RowIndex]["BasicPrice"].ToString().Replace('.',','))
                rowcolor = panel1.BackColor;
            dgv.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor =
                     dgv.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = rowcolor;

            if (decimal.Parse(dtGoods.DefaultView[e.RowIndex]["Netto"].ToString()) == 0)
                dgv.Rows[e.RowIndex].Cells["NameTovar"].Style.BackColor =
                    dgv.Rows[e.RowIndex].Cells["NameTovar"].Style.SelectionBackColor = panel2.BackColor;
        }

        private void dgvOrder_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            tbEan.Size = new Size(EAN.Width - 3, 20);
            tbEan.Location = new Point(dgvOrder.Location.X + Position.Width + cDep.Width, 12);

            tbName.Size = new Size(NameTovar.Width - 3, 20);
            tbName.Location = new Point(tbEan.Location.X + tbEan.Width + 3, 12);
        }

        private void dgvOrder_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dtGoods != null)
            {
                try
                {
                  
                    dtGoods.DefaultView[e.RowIndex]["Netto"] = decimal.Parse(dtGoods.DefaultView[e.RowIndex]["Netto"].ToString()).ToString("0.000").Replace(',', '.');
                    dtGoods.DefaultView[e.RowIndex]["sumTovar"] = (decimal.Parse(dtGoods.DefaultView[e.RowIndex]["Netto"].ToString().Replace('.', ',')) *
                        decimal.Parse(dtGoods.DefaultView[e.RowIndex]["Price"].ToString())).ToString("0.00");
                    decimal summa = 0.00M;
                    decimal brutto = 0.000M;
                

                    foreach (DataRow dr in dtGoods.Rows)
                    {
                        if (dr["ean"].ToString().Trim().Length == 4)
                            brutto += Convert.ToDecimal(dr["Netto"].ToString().Replace('.', ','));
                        else
                            brutto += Convert.ToDecimal(dr["Netto"].ToString().Replace('.', ',')) * Convert.ToDecimal(dr["brutto"].ToString().Replace('.', ','));
                        summa += Convert.ToDecimal(dr["sumTovar"].ToString());
                    }
                    label2.Text = "Вес заказа: " + Math.Round(brutto, 3) + " кг.";
                    lblSum.Text = "Сумма заказа: " + summa.ToString() + " руб.";
                    FilterGoods();
                }
                catch
                {

                }
            }
        }

        private void dgvOrder_Validating(object sender, CancelEventArgs e)
        {
            
        }

        private string RemoveLetters(string inpStr)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in inpStr)
            {
                if (Char.IsDigit(c))
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        private void dgvOrder_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == Netto.Index)
            {
                decimal tmp = 0.000M;
                if (!decimal.TryParse(dgvOrder.Rows[e.RowIndex].Cells["Netto"].Value.ToString().Replace('.',','),out tmp))
                {
                    MessageBox.Show("Введены неверные данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
                else
                {
                    if (dgvOrder.Rows[e.RowIndex].Cells["Netto"].Value.ToString().Trim().Length == 0)
                    {
                        MessageBox.Show("Введены неверные данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                    }
                    /*dtGoods.DefaultView[e.RowIndex]["Netto"] = decimal.Parse(dgvOrder.Rows[e.RowIndex].Cells["Netto"].Value.ToString()).ToString("0.000");
                    dtGoods.DefaultView[e.RowIndex]["sumTovar"] = (decimal.Parse(dgvOrder.Rows[e.RowIndex].Cells["Netto"].Value.ToString()) *
                        decimal.Parse(dtGoods.DefaultView[e.RowIndex]["Price"].ToString())).ToString("0.00");



                    dtGoods.DefaultView[e.RowIndex]["Netto"] = decimal.Parse(dtGoods.DefaultView[e.RowIndex]["Netto"].ToString()).ToString("0.000");
                    dtGoods.DefaultView[e.RowIndex]["sumTovar"] = (decimal.Parse(dtGoods.DefaultView[e.RowIndex]["Netto"].ToString()) *
                        decimal.Parse(dtGoods.DefaultView[e.RowIndex]["Price"].ToString())).ToString("0.00");*/
                    /* decimal summa = 0.00M;
                     decimal brutto = 0.000M;


                     foreach (DataRow dr in dtGoods.Rows)
                     {
                         if (dr["ean"].ToString().Trim().Length == 4)
                             brutto += Convert.ToDecimal(dr["Netto"].ToString().Replace('.', ','));
                         else
                             brutto += Convert.ToDecimal(dr["Netto"].ToString().Replace('.', ',')) * Convert.ToDecimal(dr["brutto"].ToString().Replace('.', ','));
                         summa += Convert.ToDecimal(dr["sumTovar"].ToString());
                     }
                     label2.Text = "Вес заказа: " + Math.Round(brutto, 3) + " кг.";
                     lblSum.Text = "Сумма заказа: " + summa.ToString() + " руб.";
                     FilterGoods();*/
                }
            }
        }

        private void dgvOrder_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
           
            
            if (dgvOrder.CurrentCell.ColumnIndex == Netto.Index)
            {
                e.Control.KeyPress -= new KeyPressEventHandler(NumericCheck);
                e.Control.KeyPress += new KeyPressEventHandler(NumericCheck);
            }
            else
            {
                e.Control.KeyPress -= new KeyPressEventHandler(NumericCheck);
            }
        }

        private static void NumericCheck(object sender, KeyPressEventArgs e)
        {
            DataGridViewTextBoxEditingControl s = sender as DataGridViewTextBoxEditingControl;
            if (s != null && (e.KeyChar == '.' || e.KeyChar == ','))
            {
                e.KeyChar = System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];
                e.Handled = s.Text.Contains(e.KeyChar);
            }
            else
                e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void SaveData()
        {
            Logging.StartFirstLevel(832);
            Logging.Comment("Редактирование заказа");
            Logging.Comment($"id заказа: {idTOrder}, номер заказа: {numOrder}");
            int n = dtGoodsOld.Rows.Count;
            for (int i = 0;i<n;i++)
            {
                if (dtGoodsOld.Rows[i]["Netto"].ToString() != dtGoods.Rows[i]["Netto"].ToString())
                {
                    Logging.Comment($"id товара: {dtGoods.Rows[i]["id_tovar"].ToString()}, ean: {dtGoods.Rows[0]["ean"].ToString()}, " +
                        $"Наименование: {dtGoods.Rows[i]["nameTovar"].ToString()}, Цена: {dtGoods.Rows[i]["Price"].ToString()}");
                    Logging.VariableChange($"Количество:", dtGoods.Rows[i]["Netto"], dtGoodsOld.Rows[i]["Netto"]);
                    Logging.VariableChange("Сумма", dtGoods.Rows[i]["sumTovar"], dtGoodsOld.Rows[i]["sumTovar"]);
                    Config.connect.Set_Order(int.Parse(dtGoods.Rows[i]["id_tOrders"].ToString()), int.Parse(dtGoods.Rows[i]["id_Tovar"].ToString()),
                        "", int.Parse(dtGoods.Rows[i]["Position"].ToString()), (dtGoods.Rows[i]["Netto"].ToString().Trim().Length>0 ? decimal.Parse(dtGoods.Rows[i]["Netto"].ToString().Replace('.',',')) : 0.000M), decimal.Parse(dtGoods.Rows[i]["Price"].ToString().Replace('.',',')));
                    isEdit = true;
                }
            }
            if (dtGoods.Rows.Count>n)
            {
                int newNumber = dtGoods.Rows.Count;
                for (int i = n;i<newNumber;i++)
                {
                    Logging.Comment($"Новый товар: id: {dtGoods.Rows[i]["id_tovar"].ToString()}, ean: {dtGoods.Rows[0]["ean"].ToString()}, " +
                        $"Наименование: {dtGoods.Rows[i]["nameTovar"].ToString()}, Цена: {dtGoods.Rows[i]["Price"].ToString()}, Количество: {dtGoods.Rows[i]["Netto"].ToString()}," +
                        $"Сумма: {dtGoods.Rows[i]["sumTovar"].ToString()}");
                    Config.connect.Set_Order(int.Parse(dtGoods.Rows[i]["id_tOrders"].ToString()), int.Parse(dtGoods.Rows[i]["id_Tovar"].ToString()),
                                            "", int.Parse(dtGoods.Rows[i]["Position"].ToString()), decimal.Parse(dtGoods.Rows[i]["Netto"].ToString().Replace('.', ',')), decimal.Parse(dtGoods.Rows[i]["Price"].ToString().Replace('.', ',')));
                    isEdit = true;
                }
            }
            Logging.Comment("Завершение редактирования заказа");
            Logging.StopFirstLevel();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {

     /*       bool error = false;
            foreach (DataRow dr in dtGoods.Rows)
            {
                if (dr["Netto"].ToString().Trim().Length == 0)
                    error = true;
            }

            if (error)
            {
                MessageBox.Show("Ошибка. Введите кол-во товара = 0", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            */
            SaveData();
            MessageBox.Show("Данные о заказе № " + numOrder.ToString() + " сохранены", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            GetGoods();
        }

        private void chckDeleted_CheckedChanged(object sender, EventArgs e)
        {
            FilterGoods();
        }

        private void btnAddTovar_Click(object sender, EventArgs e)
        {
            frmAddTovar frm = new frmAddTovar(dtGoods) { id_tOrder = idTOrder };
            frm.ShowDialog();



            decimal summa = 0.00M;
            decimal brutto = 0.000M;
            foreach (DataRow dr in dtGoods.Rows)
            {
                if (dr["ean"].ToString().Trim().Length == 4)
                    brutto += Convert.ToDecimal(dr["Netto"].ToString().Replace('.', ','));
                else
                    brutto += Convert.ToDecimal(dr["Netto"].ToString().Replace('.', ',')) * Convert.ToDecimal(dr["brutto"].ToString().Replace('.', ','));
                summa += Convert.ToDecimal(dr["sumTovar"].ToString());
            }
            label2.Text = "Вес заказа: " + Math.Round(brutto, 3) + " кг.";
            lblSum.Text = "Сумма заказа: " + summa.ToString() + " руб.";
        }


        /// <summary>
        /// проверка дататейблов до и после
        /// </summary>
        /// <returns></returns>
        private bool CompareDataTable()
        {
           
            if (dtGoods != null)
            {
                if (dtGoods.Rows.Count != dtGoodsOld.Rows.Count)
                    return true;
                int n = dtGoods.Rows.Count;
                for (int i = 0; i < n; i++)
                {
                    if (dtGoods.Rows[i]["Netto"].ToString() != dtGoodsOld.Rows[i]["Netto"].ToString())
                        return true;
                }
            }
            return false;

        }



        private void dgvOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvOrder_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
           
        }

        private void dgvOrder_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == Netto.Index)
            {

                if (dtGoods.DefaultView[e.RowIndex]["Netto"].ToString() == "")
                    dtGoods.DefaultView[e.RowIndex]["Netto"] = 0.000M;
                dtGoods.DefaultView[e.RowIndex]["Netto"] = decimal.Parse(dtGoods.DefaultView[e.RowIndex]["Netto"].ToString()).ToString("0.000");
                dtGoods.DefaultView[e.RowIndex]["sumTovar"] = (decimal.Parse(dtGoods.DefaultView[e.RowIndex]["Netto"].ToString()) *
                    decimal.Parse(dtGoods.DefaultView[e.RowIndex]["Price"].ToString())).ToString("0.00");

                decimal summa = 0.00M;
                decimal brutto = 0.000M;


                foreach (DataRow dr in dtGoods.Rows)
                {
                    if (dr["ean"].ToString().Trim().Length == 4)
                        brutto += Convert.ToDecimal(dr["Netto"].ToString().Replace('.', ','));
                    else
                        brutto += Convert.ToDecimal(dr["Netto"].ToString().Replace('.', ',')) * Convert.ToDecimal(dr["brutto"].ToString().Replace('.', ','));
                    summa += Convert.ToDecimal(dr["sumTovar"].ToString());
                }
                label2.Text = "Вес заказа: " + Math.Round(brutto, 3) + " кг.";
                lblSum.Text = "Сумма заказа: " + summa.ToString() + " руб.";
                dtGoods.AcceptChanges();
                FilterGoods();
            }
        }

        private void dgvOrder_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
        }

        private void dgvOrder_CancelRowEdit(object sender, QuestionEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv.CurrentCell.Value.ToString().Length == 0)
                e.Response = false;
        }
    }
}
