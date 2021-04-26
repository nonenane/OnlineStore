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
    public partial class frmAddTovar : Form
    {
        public int id_tOrder { get; set; }

        DataTable dtTovar;
        DataTable dtTovarsOrder;

        public frmAddTovar(DataTable dtTovarsOrder)
        {
            InitializeComponent();
            this.dtTovarsOrder = dtTovarsOrder;
        }

        private void tbEAN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                e.Handled = true;
        }

        private void tbEAN_KeyDown(object sender, KeyEventArgs e)
        {
            if (tbEAN.Enabled && e.KeyCode == Keys.Enter)
            {
                dtTovar = Config.connect.GetGoodByEan(tbEAN.Text);
                if (dtTovar.Rows.Count==0)
                {
                    MessageBox.Show("Товар с данным EAN отсутствует в базе","Информация", MessageBoxButtons.OK,MessageBoxIcon.Information);
                    tbEAN.Text = tbName.Text = tbNetto.Text = tbPrice.Text = "";
                    tbEAN.Focus();
                    return;
                }

                tbName.Text = dtTovar.Rows[0]["ShortName"].ToString();
                tbPrice.Text = dtTovar.Rows[0]["BasicPrice"].ToString();
                tbNetto.Focus();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {


            if (dtTovar == null || dtTovar.Rows.Count == 0)
            {
                MessageBox.Show("Товар не загружен", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dtTovarsOrder.AsEnumerable().Where(r=>r.Field<int>("id_Tovar").ToString() == dtTovar.Rows[0]["id_Tovar"].ToString()).Count() > 0 )
            {
                MessageBox.Show("Данный товар уже добавлен, можно изменить его количество", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbEAN.Text = tbName.Text = tbNetto.Text = tbPrice.Text = "";
                tbEAN.Focus();
                return;
            }
            if (tbNetto.Text.Trim().Length == 0)
            {
                MessageBox.Show("Не введено количество товара", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DataRow dr = dtTovarsOrder.NewRow();

            int maxPosition = dtTovarsOrder.AsEnumerable().Max(row => row.Field<int>("Position"));
            dr["Position"] = maxPosition + 1;
            dr["id_tOrders"] = id_tOrder;
            dr["id_Tovar"] = int.Parse(dtTovar.Rows[0]["id_Tovar"].ToString());
            dr["Netto"] = decimal.Parse(tbNetto.Text);
            dr["Price"] = dr["BasicPrice"] = decimal.Parse(tbPrice.Text);
            dr["nameTovar"] = tbName.Text;
            decimal brutto = 0.000M;
            if (tbEAN.Text.Length == 4)
                brutto = Convert.ToDecimal(dr["Netto"].ToString().Replace('.', ','));
            else
                brutto = Convert.ToDecimal(dtTovar.Rows[0]["brutto"].ToString().Replace('.', ','));
            dr["brutto"] = brutto;
            dr["sumTovar"] =(decimal.Parse( dr["netto"].ToString()) * decimal.Parse( dr["Price"].ToString())).ToString("0.00");
            dr["name"] = dtTovar.Rows[0]["nameDep"].ToString();
            dr["ean"] = dtTovar.Rows[0]["ean"].ToString();
            dtTovarsOrder.Rows.Add(dr);
            dtTovar.Dispose();

            tbEAN.Text = tbName.Text = tbNetto.Text = tbPrice.Text = "";
        }

        private void tbNetto_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tbNetto_Validating(object sender, CancelEventArgs e)
        {
           
            try
            {
                tbNetto.Text = decimal.Parse(tbNetto.Text.ToString()).ToString("0.000");
            }
            catch
            {
                tbNetto.Text = "";                
            }
        }

        private void frmAddTovar_Load(object sender, EventArgs e)
        {
            ToolTip ttButton = new ToolTip();
            ttButton.SetToolTip(btnExit, "Выход");
            ttButton.SetToolTip(btnAdd, "Добавить");
        }

        private void tbEAN_Leave(object sender, EventArgs e)
        {
            
           
        }

        private void tbNetto_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbNetto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAdd_Click(null, null);
            }
        }

        private void tbNetto_Enter(object sender, EventArgs e)
        {
            if (tbEAN.Text.Trim().Length>0)
            dtTovar = Config.connect.GetGoodByEan(tbEAN.Text);
            if (dtTovar.Rows.Count == 0)
            {
                MessageBox.Show("Товар с данным EAN отсутствует в базе", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbEAN.Text = "";
                tbEAN.Focus();
                return;
            }

            tbName.Text = dtTovar.Rows[0]["ShortName"].ToString();
            tbPrice.Text = dtTovar.Rows[0]["BasicPrice"].ToString();
        }
    }
}
