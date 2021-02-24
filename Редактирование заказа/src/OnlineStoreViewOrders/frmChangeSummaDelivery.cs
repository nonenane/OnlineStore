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
        public string DeliveryType { set; get; }
        public string Address { set; get; }

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
            dtpPlanDeliveryDate.MinDate = PlanDeliveryDate.Date;
            tbSumma.Text = SummaDelivery.ToString("0.00");
            tbAddress.Text = Address;
            rbDelivery.Checked = DeliveryType.Equals("Доставка");
            rbUserDelivery.Checked = DeliveryType.Equals("Самовывоз");
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

            if (SummaDelivery == 0)
            {
                if (MessageBox.Show(Config.centralText("Вы уверены что хотите установить\nстоимость доставки товара 0.00 руб.?\n"), "Проверка стоимости доставки",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            }

            string _DeliveryType = rbDelivery.Checked ? "Доставка" : rbUserDelivery.Checked ? "Самовывоз" : "";
            string _Address = tbAddress.Text;

            DataTable dtResult = Config.connect.updateSummaDelivery(idtOrder, SummaDelivery, dtpPlanDeliveryDate.Value.Date, _Address, _DeliveryType);
           
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
                Logging.VariableChange("Сумма доставки", SummaDelivery, this.SummaDelivery);
                Logging.VariableChange("Дата доставки", dtpPlanDeliveryDate.Value.Date, this.PlanDeliveryDate.Date);

                Logging.VariableChange("Адрес", _Address, this.Address);
                Logging.VariableChange("Тип доставки", _DeliveryType, this.DeliveryType);
                Logging.Comment("Завершение изменения стоимости доставки");
                Logging.StopFirstLevel();
            }
            #endregion
            this.SummaDelivery = SummaDelivery;
            this.PlanDeliveryDate = dtpPlanDeliveryDate.Value.Date;
            this.DeliveryType = _DeliveryType;
            this.Address = _Address;

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
    }
}
