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
        public frmChangeSummaDelivery()
        {
            InitializeComponent();
            ToolTip tp = new ToolTip();
            tp.SetToolTip(btClose, "Выход");
            tp.SetToolTip(btSave, "Сохранить");
        }

        private void frmChangeSummaDelivery_Load(object sender, EventArgs e)
        {
            tbSumma.Text = SummaDelivery.ToString("0.00");
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

            decimal SummaDelivery = decimal.Parse(tbSumma.Text.Replace(".", ","));

            DataTable dtResult = Config.connect.updateSummaDelivery(idtOrder, SummaDelivery);
            this.SummaDelivery = SummaDelivery;
            MessageBox.Show("Данные сохранены.", "Сохранение данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
        }

    }
}
