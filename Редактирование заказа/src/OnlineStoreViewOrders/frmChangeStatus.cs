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
    public partial class frmChangeStatus : Form
    {        
        private bool isEditData = false;

        public int nextStatus { set; private get; }
        public DateTime dateOrder { set; private get; }
        public int idtOrder { set; private get; }
        public frmChangeStatus()
        {
            InitializeComponent();
            ToolTip tp = new ToolTip();
            tp.SetToolTip(btClose, "Выход");
            tp.SetToolTip(btSave, "Сохранить");

          
        }

        private void frmChangeStatus_Load(object sender, EventArgs e)
        {
            dtpDate.MinDate = dateOrder.Date;
            dtpDate.MaxDate = Config.connect.getDate().Date;

            if (nextStatus == 4)
            {
                label1.Visible = label3.Visible = label4.Visible = false;
                dtpDate.Visible = false;
                tbSumma.Visible = false;
                this.Size = new Size(265, 185);
            }

            isEditData = false;
        }

        private void tbKass_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (tbSumma.Visible && tbSumma.Text.Trim().Length == 0)
            {
                MessageBox.Show($"Необходимо указать \"{label3.Text}\"", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbSumma.Focus();
                return;
            }

            if (tbComment.Text.Trim().Length == 0)
            {
                MessageBox.Show($"Необходимо заполнить \"{label2.Text}\"", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbComment.Focus();
                return;
            }

            decimal? DeliveriCost = null;
            if (tbSumma.Visible)
            {
                DeliveriCost = decimal.Parse(tbSumma.Text);
                if (DeliveriCost == 0) {
                    MessageBox.Show($"Необходимо указать \"{label3.Text}\" отличные от 0", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbSumma.Focus();
                    return;
                }
            }
            

            DateTime? DeliveryDate = null;
            if (dtpDate.Visible) DeliveryDate = dtpDate.Value.Date;

            int id_status = nextStatus;
            string commentOrder = tbComment.Text.Trim();

            DataTable dtResult = Config.connect.setStatusOrder(idtOrder, DeliveriCost, DeliveryDate, id_status, commentOrder);
            isEditData = false;
            MessageBox.Show("Данные сохранены.", "Сохранение данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
        }

        private void frmChangeStatus_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = isEditData && DialogResult.No == MessageBox.Show("На форме есть не сохранённые данные.\nЗакрыть форму без сохранения данных?\n", "Закрытие формы", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            isEditData = true;
        }

        private void tbKass_TextChanged(object sender, EventArgs e)
        {
            isEditData = true;
        }
    }
}
