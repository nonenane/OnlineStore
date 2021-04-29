using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineStoreViewOrders.TypeЕmployesОrder
{
    public partial class frmListTypeЕmployesОrder : Form
    {
        public string nameOrder { set; private get; }

        public int id_order { set; private get; }

        private List<int> listDelKadr = new List<int>();
        private DataTable dtDeliverOld;
        private bool isEditData = false;

        public string listNameCollector { private set;  get; }
        public string listNameKassCheck { private set;  get; }
        public string listNameDelivery { private set; get; }

        public frmListTypeЕmployesОrder()
        {
            InitializeComponent();
            dgvUsers.AutoGenerateColumns = false;
            dgvDeliversMan.AutoGenerateColumns = false;
        }

        private void FrmListTypeЕmployesОrder_Load(object sender, EventArgs e)
        {
            tbNameOrder.Text = nameOrder;

            DataTable dtDeps = Config.connect.getDeliverKadr(true).Result;
            cmbDeps.DataSource = dtDeps;
            cmbDeps.ValueMember = "id";
            cmbDeps.DisplayMember = "cName";

            DataTable dtDeliversKadr = Config.connect.getDeliverKadr(false).Result;
            dgvUsers.DataSource = dtDeliversKadr;


            DataTable dtDeliver = Config.connect.getTypeЕmployesОrder(id_order).Result;
            dtDeliverOld = dtDeliver.Copy();
            dgvDeliversMan.DataSource = dtDeliver;
        }

        private void BtAdd_Click(object sender, EventArgs e)
        {
            DataRowView selectRow = (dgvUsers.DataSource as DataTable).DefaultView[dgvUsers.CurrentRow.Index];

            if ((dgvDeliversMan.DataSource as DataTable).AsEnumerable().Where(r => r.Field<int>("id") == (int)selectRow["id"]).Count() > 0) return;

            frmAddDeliver frmAdd = new frmAddDeliver();
            if (frmAdd.ShowDialog() == DialogResult.OK)
            {
               
                DataRow row = (dgvDeliversMan.DataSource as DataTable).NewRow();

                row["id"] = selectRow["id"];
                row["FIO"] = selectRow["FIO"];
                row["Collector"] = frmAdd.isCollector;
                row["KassCheck"] = frmAdd.isKassTerminal;
                row["Delivery"] = frmAdd.isDeliver;

                (dgvDeliversMan.DataSource as DataTable).Rows.Add(row);
                dgvDeliversMan.Refresh();
                isEditData = true;
            }
        }


        private void BtRemote_Click(object sender, EventArgs e)
        {
            if (dgvDeliversMan.CurrentRow != null && dgvDeliversMan.CurrentRow.Index != -1)
            {
                DataRowView row = (dgvDeliversMan.DataSource as DataTable).DefaultView[dgvDeliversMan.CurrentRow.Index];
                if (row["idTypeЕmployesОrder"] != DBNull.Value) listDelKadr.Add((int)row["idTypeЕmployesОrder"]);
                row.Delete();
                dgvDeliversMan.Refresh();
                isEditData = true;
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private async void BtSave_Click(object sender, EventArgs e)
        {
            if (listDelKadr.Count > 0)
            {
                foreach (int delId in listDelKadr)
                {
                    await Config.connect.setTypeЕmployesОrder(delId, id_order, 0, false, false, false, true);
                }
            }

            listNameCollector = "";
            listNameKassCheck = "";
            listNameDelivery = "";

            foreach (DataRow row in (dgvDeliversMan.DataSource as DataTable).Rows)
            {
                int idTypeЕmployesОrder = 0;
                int id_tOrders = id_order;
                int idKadr = (int)row["id"];
                bool Collector = (bool)row["Collector"];
                bool KassCheck = (bool)row["KassCheck"];
                bool Delivery = (bool)row["Delivery"];
                bool isDel = false;

                if(Collector) listNameCollector+= (listNameCollector.Length==0?"":";")+$"{row["FIO"]}";
                if (KassCheck) listNameKassCheck += (listNameKassCheck.Length == 0 ? "" : ";") + $"{row["FIO"]}";
                if (Delivery) listNameDelivery += (listNameDelivery.Length == 0 ? "" : ";") + $"{row["FIO"]}";

                await Config.connect.setTypeЕmployesОrder(idTypeЕmployesОrder, id_tOrders, idKadr, Collector, KassCheck, Delivery, isDel);
            }

            isEditData = false;
            MessageBox.Show("Данные сохранены.", "Сохранение данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
        }

        private void FrmListTypeЕmployesОrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = isEditData && DialogResult.No == MessageBox.Show("На форме есть не сохранённые данные.\nЗакрыть форму без сохранения данных?\n", "Закрытие формы", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        }
    }
}
