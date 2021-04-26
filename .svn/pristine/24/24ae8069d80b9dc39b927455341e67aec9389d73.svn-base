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
    public partial class frmPackage : Form
    {

        public int numberOrder { get; set; }
        public int id_Order { get; set; }

        public frmPackage()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPackage_Load(object sender, EventArgs e)
        {
            label2.Text = "Заказ № " + numberOrder;
            ToolTip tt = new ToolTip();
            tt.SetToolTip(btnOK, "Добавить");
            tt.SetToolTip(btnExit, "Выход");
            tbCountPackage.Text =  Config.connect.Get_PackageOrder(id_Order).Rows[0]["count"].ToString();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            int count;
            if (int.TryParse(tbCountPackage.Text,out count))
            {
                Config.connect.Set_tOrderPackage(count, id_Order);
                MessageBox.Show("Запись добавлена","Сообщение",MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Введите целое число", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
