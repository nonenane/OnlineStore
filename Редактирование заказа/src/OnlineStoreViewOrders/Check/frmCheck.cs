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
    public partial class frmCheck : Form
    {

        public int id_tOrder { get; set; }
        public int num_Order { get; set; }
        public int id_status { set; private get; }
        public DateTime DateOrder { set; private get; }

        private DataTable dtCheck;
        public frmCheck()
        {
            InitializeComponent();
        }

        private void dgvCheck_Init()
        {
            dtCheck = Config.connect.GetCheckvsOrder(id_tOrder);
            dgvCheck.AutoGenerateColumns = false;
            dgvCheck.DataSource = dtCheck;
            GetPackage();
            getSumma();
        }

        private void frmCheck_Load(object sender, EventArgs e)
        {
            ToolTip ttButton = new ToolTip();
            ttButton.SetToolTip(btnExit, "Выход");
            ttButton.SetToolTip(btnAdd, "Добавить чек");
            ttButton.SetToolTip(btnDelCheck, "Удалить чек");
            ttButton.SetToolTip(btnViewCheck, "Просмотр чека");
            this.Text = "Чеки по заказу № " + num_Order.ToString();
            btnAdd.Visible = btnDelCheck.Visible = !new List<int>(new int[] { 3, 4 }).Contains(id_status);
            dgvCheck_Init();

        }

        private void EnableButtons()
        {
            if (dtCheck != null && dtCheck.Rows.Count > 0)
            {
                btnDelCheck.Enabled = btnViewCheck.Enabled = true;
            }
            else
            {
                btnDelCheck.Enabled = btnViewCheck.Enabled = false;
            }
        }

        private void GetPackage()
        {
            if (dtCheck != null && dtCheck.Rows.Count > 0)
            {

                DataTable dtTemp = dtCheck.AsEnumerable().Where(r => r.Field<bool>("isPackage") == true).Count() > 0 ?
                     dtCheck.AsEnumerable().Where(r => r.Field<bool>("isPackage") == true).CopyToDataTable() : null;
                DataTable dtPack = null;
                if (dtTemp != null && dtTemp.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtTemp.Rows)
                    {
                        if (dtPack == null)
                            dtPack = Config.connect.getPackage(int.Parse(dr["CheckNumber"].ToString()),
                                 DateTime.Parse(dr["DateCheck"].ToString()),
                                 int.Parse(dr["KassNumber"].ToString()));
                        else
                            dtPack.Merge(Config.connect.getPackage(int.Parse(dr["CheckNumber"].ToString()),
                                DateTime.Parse(dr["DateCheck"].ToString()),
                                int.Parse(dr["KassNumber"].ToString())));
                    }

                    int totalCount = 0;
                    if (dtPack != null && dtPack.Rows.Count > 0)
                        totalCount = dtPack.AsEnumerable().Sum(r => r.Field<int>("totalCount"));
                    lCountPackage.Text = "Кол-во пакетов: " + totalCount.ToString()+ " шт.";
                }
                else
                {
                    lCountPackage.Text = "Кол-во пакетов: 0 шт.";
                }
            }
            else
            {
                lCountPackage.Text = "Кол-во пакетов: 0 шт.";
            }
            EnableButtons();
        }

        private void getSumma()
        {
            object objSumma = dtCheck.Compute("Sum(Summa)", "isPackage = 1");
            if (objSumma != DBNull.Value)
                lSumPackage.Text = $"Сумма: {((decimal)objSumma).ToString("0.00")} руб.";
            else
                lSumPackage.Text = $"Сумма: 0 руб.";

            objSumma = dtCheck.Compute("Sum(Summa)", "isPackage = 0");
            if (objSumma != DBNull.Value)
                tbResult.Text = ((decimal)objSumma).ToString("0.00");
            else
                tbResult.Text = "0.00";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Check.frmAddCheck frm = new Check.frmAddCheck() { id_tOrder = id_tOrder, DateOrder = DateOrder };
            frm.ShowDialog();
            dgvCheck_Init();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvCheck_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void dgvCheck_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            Color rowcolor = Color.White;

            if (dtCheck != null && dtCheck.DefaultView.Count > 0)
                if ((bool)dtCheck.DefaultView[e.RowIndex]["isPackage"])
                    rowcolor = panel1.BackColor;

            dgv.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor =
                     dgv.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = rowcolor;
        }

        private void btnDelCheck_Click(object sender, EventArgs e)
        {
            if (dtCheck.DefaultView.Count == 0)
                return;

            if (MessageBox.Show("Хотите удалить выбранный чек?", "Запрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int idCheck = int.Parse(dtCheck.DefaultView[dgvCheck.CurrentRow.Index]["id"].ToString());
                Config.connect.DelCheckOrder(idCheck);
                MessageBox.Show("Чек номер " + dtCheck.DefaultView[dgvCheck.CurrentRow.Index]["CheckNumber"].ToString() + " удален из заказа",
                    "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvCheck_Init();
            }
        }

        private void btnViewCheck_Click(object sender, EventArgs e)
        {
            Check.frmView frm = new Check.frmView()
            {
                doc_id = int.Parse(dtCheck.DefaultView[dgvCheck.CurrentRow.Index]["CheckNumber"].ToString()),
                date = DateTime.Parse(dtCheck.DefaultView[dgvCheck.CurrentRow.Index]["DateCheck"].ToString()),
                terminal = int.Parse(dtCheck.DefaultView[dgvCheck.CurrentRow.Index]["KassNumber"].ToString())
            };
            frm.ShowDialog();
        }
    }
}
