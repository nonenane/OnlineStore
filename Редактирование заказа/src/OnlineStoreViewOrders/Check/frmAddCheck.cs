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
            MessageBox.Show("Чек добавлен", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
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
