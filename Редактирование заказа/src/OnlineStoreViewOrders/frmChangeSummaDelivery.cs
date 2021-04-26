using Nwuram.Framework.Logging;
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
    public partial class frmChangeSummaDelivery : Form
    {
        public int idtOrder { set; private get; }
        public decimal SummaDelivery { set; get; }
        public DateTime PlanDeliveryDate { set; get; }
        public DateTime DateOrder { set; get; }
        public string DeliveryType { set; get; }
        public string Address { set; get; }
        public string Phone { private set; get; }
        public string Email {private set; get; }
        public string FIO { private set; get; }

        private bool isEditData = false;

        public frmChangeSummaDelivery()
        {
            InitializeComponent();
            ToolTip tp = new ToolTip();
            tp.SetToolTip(btClose, "Выход");
            tp.SetToolTip(btSave, "Сохранить");
        }

        private void frmChangeSummaDelivery_Load(object sender, EventArgs e)
        {
            dtpPlanDeliveryDate.Value = PlanDeliveryDate.Date;
            dtpPlanDeliveryDate.MinDate = DateOrder.Date;
            tbSumma.Text = SummaDelivery.ToString("0.00");
            tbAddress.Text = Address;
            rbDelivery.Checked = DeliveryType.Equals("Доставка");
            rbUserDelivery.Checked = DeliveryType.Equals("Самовывоз");
            DataTable dtInfo = Config.connect.getOrderInfo(idtOrder);
            if (dtInfo != null && dtInfo.Rows.Count > 0)
            {
                tbFirstName.Text = dtInfo.Rows[0]["NameBuyer"].ToString();
                tbLastName.Text = dtInfo.Rows[0]["LastnameBuyer"].ToString();
                tbEmail.Text = dtInfo.Rows[0]["Email"].ToString();
                tbPhone.Text = dtInfo.Rows[0]["Phone"].ToString();
            }
            isEditData = false;
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (tbSumma.Text.Trim().Length == 0)
            {
                MessageBox.Show($"Необходимо указать \"{label3.Text}\"", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbSumma.Focus();
                return;
            }

            if (tbLastName.Text.Trim().Length == 0)
            {
                MessageBox.Show($"Необходимо указать \"{lLastName.Text}\"", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbLastName.Focus();
                return;
            }

            if (tbFirstName.Text.Trim().Length == 0)
            {
                MessageBox.Show($"Необходимо указать \"{lFirstName.Text}\"", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbFirstName.Focus();
                return;
            }

            if (tbEmail.Text.Trim().Length == 0)
            {
                MessageBox.Show($"Необходимо указать \"{lEmail.Text}\"", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbEmail.Focus();
                return;
            }

            if (tbPhone.Text.Trim().Length == 0)
            {
                MessageBox.Show($"Необходимо указать \"{lPhone.Text}\"", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbPhone.Focus();
                return;
            }

            if (tbAddress.Text.Trim().Length == 0)
            {
                MessageBox.Show(Config.centralText($"Не указан адрес доставки заказа.\nСохранение невозможно.\n"), "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbAddress.Focus();
                return;
            }

            decimal SummaDelivery;
            if (!decimal.TryParse(tbSumma.Text.Replace(".", ","), out SummaDelivery))
            {
                MessageBox.Show($"Необходимо указать \"{label3.Text}\"", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbSumma.Focus();
                return;
            }

            if (SummaDelivery == 0 && rbDelivery.Checked)
            {
                if (MessageBox.Show(Config.centralText("Вы уверены что хотите установить\nстоимость доставки товара 0.00 руб.?\n"), "Проверка стоимости доставки",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            }

            string _DeliveryType = rbDelivery.Checked ? "Доставка" : rbUserDelivery.Checked ? "Самовывоз" : "";
            string _Address = tbAddress.Text;

            DataTable dtResult = Config.connect.updateSummaDelivery(idtOrder, SummaDelivery, dtpPlanDeliveryDate.Value.Date, _Address, _DeliveryType, tbLastName.Text, tbFirstName.Text, tbPhone.Text, tbEmail.Text);
           
            #region log
            DataTable dtInfo = Config.connect.getOrderInfo(idtOrder);
            if (dtInfo!=null && dtInfo.Rows.Count>0)
            {
                string numOrder = dtInfo.Rows[0]["OrderNumber"].ToString();
                string dateOrder = dtInfo.Rows[0]["DateOrder"].ToString();
                string FIO = dtInfo.Rows[0]["FIO"].ToString(); 
                string summOrder = dtInfo.Rows[0]["sumOrder"].ToString();
                string summDelivery = dtInfo.Rows[0]["SummaDelivery"].ToString();
                string typePayment = dtInfo.Rows[0]["namePayment"].ToString();

                Logging.StartFirstLevel(1589);
                Logging.Comment("Изменение стоимости доставки");
                Logging.Comment($"id заказа: {idtOrder}, номер заказa: {numOrder}, Дата заказа: {dateOrder}, ФИО покупателя: {FIO}, Сумма заказа: {summOrder}, " +
                    $"Способ оплаты: {typePayment}");

                Logging.VariableChange($"{label1.Text}", dtpPlanDeliveryDate.Value.Date, this.PlanDeliveryDate.Date);
                Logging.VariableChange("Сумма доставки", SummaDelivery, this.SummaDelivery);
                Logging.VariableChange("Тип доставки", _DeliveryType, this.DeliveryType);
                Logging.VariableChange("Адрес", _Address, this.Address);

                Logging.VariableChange(lLastName.Text,tbLastName.Text, dtInfo.Rows[0]["LastnameBuyer"].ToString());
                Logging.VariableChange(lFirstName.Text, tbFirstName.Text, dtInfo.Rows[0]["NameBuyer"].ToString());
                Logging.VariableChange(lEmail.Text, tbEmail.Text, dtInfo.Rows[0]["Email"].ToString());
                Logging.VariableChange(lPhone.Text, tbPhone.Text, dtInfo.Rows[0]["Phone"].ToString());

                Logging.Comment("Завершение изменения стоимости доставки");
                Logging.StopFirstLevel();
            }
            #endregion

            this.SummaDelivery = SummaDelivery;
            this.PlanDeliveryDate = dtpPlanDeliveryDate.Value.Date;
            this.DeliveryType = _DeliveryType;
            this.Address = _Address;
            this.Phone = tbPhone.Text;
            this.Email = tbEmail.Text;
            this.FIO = $"{tbLastName.Text} {tbFirstName.Text}";

            isEditData = false;
            MessageBox.Show("Данные сохранены.", "Сохранение данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
        }

        private void tbSumma_KeyPress(object sender, KeyPressEventArgs e)
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

        private void RbUserDelivery_Click(object sender, EventArgs e)
        {
            tbSumma.Text = "0.00";
            isEditData = true;
        }

        private void FrmChangeSummaDelivery_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = isEditData && DialogResult.No == MessageBox.Show("На форме есть не сохранённые данные.\nЗакрыть форму без сохранения данных?\n", "Закрытие формы", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        }

        private void DtpPlanDeliveryDate_ValueChanged(object sender, EventArgs e)
        {
            isEditData = true;
        }

        private void RbDelivery_CheckedChanged(object sender, EventArgs e)
        {
            isEditData = true;
        }

        private void TbSumma_TextChanged(object sender, EventArgs e)
        {
            isEditData = true;
        }

        private void TbAddress_TextChanged(object sender, EventArgs e)
        {
            isEditData = true;
        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }
    }
}
