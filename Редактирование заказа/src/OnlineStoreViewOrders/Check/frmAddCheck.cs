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

namespace OnlineStoreViewOrders.Check
{
    public partial class frmAddCheck : Form
    {
        public int id_tOrder { get; set; }
        public DateTime DateOrder { set; private get; }
        public frmAddCheck()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (tbCheck.Text.Trim().Length == 0 || tbKass.Text.Trim().Length == 0)
            {
                MessageBox.Show("Необходимо ввести числовые значения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DataTable dtCheckCheck = Config.connect.GetCheckInfo(dtpDate.Value.Date, int.Parse(tbCheck.Text), int.Parse(tbKass.Text));
            if (dtCheckCheck == null)
            {
                MessageBox.Show("Нет подключения к серверу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dtCheckCheck.Rows.Count == 0)
            {
                MessageBox.Show("Чек по дате, номеру и кассе не обнаружен", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (dtCheckCheck.Rows.Count > 0 && dtCheckCheck.Columns.Contains("id") && (int)dtCheckCheck.Rows[0]["id"] == -1)
            {
                MessageBox.Show("Данный чек уже используется в заказе", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            Config.connect.SetCheckOrder(
                int.Parse(dtCheckCheck.Rows[0]["doc_id"].ToString()),
                int.Parse(dtCheckCheck.Rows[0]["terminal"].ToString()),
                Convert.ToDateTime(dtCheckCheck.Rows[0]["time"].ToString()).Date,
                decimal.Parse(dtCheckCheck.Rows[0]["summa"].ToString()),
                id_tOrder,
                chckPackage.Checked);
            setLog(708);
            MessageBox.Show("Чек добавлен", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void setLog(int id_log)
        {
           
            DataTable dtInfo = Config.connect.getOrderInfo(id_tOrder);
            if (dtInfo == null || dtInfo.Rows.Count == 0)
                return;
            Logging.StartFirstLevel(id_log);
            Logging.Comment("Добавление чека");
            Logging.Comment($"id заказа: {id_tOrder}");
            Logging.Comment($"Номер заказа: {dtInfo.Rows[0]["OrderNumber"].ToString()}");
            Logging.Comment($"Дата и время заказа: {dtInfo.Rows[0]["DateOrder"].ToString()}");
            Logging.Comment($"ФИО покупателя: {dtInfo.Rows[0]["FIO"].ToString()}");
            Logging.Comment($"Сумма заказа: {dtInfo.Rows[0]["sumOrder"].ToString()}");
            Logging.Comment($"Сумма доставки: {dtInfo.Rows[0]["SummaDelivery"].ToString()}");
            Logging.Comment($"Тип оплаты: {dtInfo.Rows[0]["namePayment"].ToString()}");
            Logging.Comment($"Параметры добавленного чека - Дата: {dtpDate.Value.ToShortDateString()}, Номер чека: {tbCheck.Text}, Номер кассы: {tbKass.Text}, Пакет: {(chckPackage.Checked? "Да" : "Нет")}");
            Logging.Comment($"Завершение добавления чека");
            Logging.StopFirstLevel();
        }

        private void tbKass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                e.Handled = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddCheck_Load(object sender, EventArgs e)
        {
            ToolTip ttButton = new ToolTip();
            ttButton.SetToolTip(btnExit, "Выход");
            ttButton.SetToolTip(btnAdd, "Добавить");
            dtpDate.Value = DateOrder.Date;
        }

        private void tbCheck_KeyUp(object sender, KeyEventArgs e)
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

        private void tbCheck_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData == (Keys.Control | Keys.V))
            {
                (sender as TextBox).Text = RemoveLetters(Clipboard.GetText());
                //(sender as TextBox).Paste();
                //(sender as TextBox).Text = RemoveLetters((sender as TextBox).Text);
            }

            if (e.KeyData == (Keys.Control | Keys.C))
            {
                (sender as TextBox).Copy();
                
            }


        }

        private void tbCheck_TextChanged(object sender, EventArgs e)
        {
            (sender as TextBox).Text = RemoveLetters((sender as TextBox).Text);
        }
    }
}
