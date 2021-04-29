using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineStore.dictonaryCategory
{
    public partial class frmMultyGoodCategory : Form
    {
        public frmMultyGoodCategory()
        {
            InitializeComponent();
            dgvGoods.AutoGenerateColumns = false;
            dgvCategoryGood.AutoGenerateColumns = false;
        }

        private void FrmMultyGoodCategory_Load(object sender, EventArgs e)
        {
            cbDeps_Init();
        }

        private void cbDeps_Init()
        {
            Task<DataTable> task = Config.hCntMain.getDeps();
            task.Wait();
            DataTable dtDeps = task.Result;
            cbDeps.DataSource = dtDeps.Copy();
            cbDeps.DisplayMember = "cName";
            cbDeps.ValueMember = "id";

            cmbDepsCategory.DataSource = dtDeps.Copy();
            cmbDepsCategory.DisplayMember = "cName";
            cmbDepsCategory.ValueMember = "id";
            CbDeps_SelectionChangeCommitted(null, null);
            CmbDepsCategory_SelectionChangeCommitted(null, null);
        }

        private void getGoodsToMultyCategory()
        {
            int id_otdel = (int)cbDeps.SelectedValue;

            DataTable dtGoodsToMultyCategory = Config.hCntMain.getGoodsToMultyCategory(id_otdel).Result;            
            dgvGoods.DataSource = dtGoodsToMultyCategory;
            setFilterGood();
        }

        private void BtClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void CbDeps_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int id_otdel = (int)cbDeps.SelectedValue;
            DataTable dtTU = Config.hCntMain.getTU(id_otdel).Result;

            Config.DoOnUIThread(delegate ()
            {
                cmbGrp1.DataSource = dtTU;
                cmbGrp1.DisplayMember = "cName";
                cmbGrp1.ValueMember = "id";
            },this);


            DataTable dtInv = Config.hCntMain.getInv(id_otdel).Result;

            Config.DoOnUIThread(delegate ()
            {
                cmbGrp2.DataSource = dtInv;
                cmbGrp2.DisplayMember = "cName";
                cmbGrp2.ValueMember = "id";
            },this);

            getGoodsToMultyCategory();
        }

        private void CmbGrp1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cmbGrp2.SelectedIndex = 0;
            setFilterGood();
        }

        private void CmbGrp2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cmbGrp1.SelectedIndex = 0;
            setFilterGood();
        }

        private void CmbDepsCategory_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int id_otdel = (int)cmbDepsCategory.SelectedValue;
            DataTable dtCatergory = Config.hCntMain.getCategory(id_otdel, false).Result;

            EnumerableRowCollection<DataRow> rowCollection = dtCatergory.AsEnumerable().Where(r => r.Field<object>("id") == null);
            while (rowCollection.Count() > 0)
                rowCollection.First().Delete();

            cmbCategory.DataSource = dtCatergory;
            cmbCategory.DisplayMember = "cName";
            cmbCategory.ValueMember = "id";

            CmbCategory_SelectionChangeCommitted(null, null);
        }

        private void DgvUsers_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            int width = dgvGoods.Location.X + 1;

            foreach (DataGridViewColumn col in dgvGoods.Columns)
            {
                if (!col.Visible) continue;

                if (col.Name.Equals(cGoodEan.Name))
                {
                    tbGoodEan.Location = new Point(width, tbGoodEan.Location.Y);
                    tbGoodEan.Size = new Size(col.Width, tbGoodEan.Size.Height);
                }

                if (col.Name.Equals(cGoodName.Name))
                {
                    tbGoodName.Location = new Point(width, tbGoodEan.Location.Y);
                    tbGoodName.Size = new Size(col.Width, tbGoodEan.Size.Height);
                }
                width += col.Width;
            }

        }

        private void DgvCategoryGood_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            int width = dgvCategoryGood.Location.X + 1;

            foreach (DataGridViewColumn col in dgvCategoryGood.Columns)
            {
                if (!col.Visible) continue;

                if (col.Name.Equals(cCatEan.Name))
                {
                    tbCatEan.Location = new Point(width, tbCatEan.Location.Y);
                    tbCatEan.Size = new Size(col.Width, tbCatEan.Size.Height);
                }

                if (col.Name.Equals(cCatName.Name))
                {
                    tbCatName.Location = new Point(width, tbCatEan.Location.Y);
                    tbCatName.Size = new Size(col.Width, tbCatEan.Size.Height);
                }
                width += col.Width;
            }
        }

        private void CmbCategory_SelectionChangeCommitted(object sender, EventArgs e)
        {
            getUseGoodsCategoryToMultyCategory();
        }

        private void getUseGoodsCategoryToMultyCategory()
        {
            int id_Category = (int)cmbCategory.SelectedValue;

            DataTable dtUseGoodsCategoryToMultyCategory = Config.hCntMain.getUseGoodsCategoryToMultyCategory(id_Category).Result;            
            dgvCategoryGood.DataSource = dtUseGoodsCategoryToMultyCategory;
            setFilterCategory();
        }

        private async void BtAdd_Click(object sender, EventArgs e)
        {
            if (dgvGoods.CurrentRow != null && dgvGoods.CurrentRow.Index != -1)
            {
                int id_Category = (int)cmbCategory.SelectedValue;
                int id_goods = (int)(dgvGoods.DataSource as DataTable).DefaultView[dgvGoods.CurrentRow.Index]["id"];


                await Config.hCntMain.setGoodsVsCategory(null, id_goods, id_Category);

                CmbCategory_SelectionChangeCommitted(null, null);
            }
        }

        private async void BtAddAll_Click(object sender, EventArgs e)
        {
            if (dgvGoods.CurrentRow != null && dgvGoods.CurrentRow.Index != -1)
            {
                int id_Category = (int)cmbCategory.SelectedValue;
                foreach (DataRowView row in (dgvGoods.DataSource as DataTable).DefaultView)
                {
                    int id_goods = (int)row["id"];
                    await Config.hCntMain.setGoodsVsCategory(null, id_goods, id_Category);
                }
                CmbCategory_SelectionChangeCommitted(null, null);
            }
        }

        private async void BtRemote_Click(object sender, EventArgs e)
        {
            if (dgvCategoryGood.CurrentRow != null && dgvCategoryGood.CurrentRow.Index != -1)
            {
                int id_Category = (int)cmbCategory.SelectedValue;
                int id_goods = (int)(dgvCategoryGood.DataSource as DataTable).DefaultView[dgvCategoryGood.CurrentRow.Index]["id_Goods"];
                int id = (int)(dgvCategoryGood.DataSource as DataTable).DefaultView[dgvCategoryGood.CurrentRow.Index]["id"];

                await Config.hCntMain.setGoodsVsCategory(id, id_goods, id_Category);

                CmbCategory_SelectionChangeCommitted(null, null);
            }
        }

        private async void BtRemoteAll_Click(object sender, EventArgs e)
        {
            if (dgvCategoryGood.CurrentRow != null && dgvCategoryGood.CurrentRow.Index != -1)
            {
                int id_Category = (int)cmbCategory.SelectedValue;
                foreach (DataRowView row in (dgvCategoryGood.DataSource as DataTable).DefaultView)
                {
                    int id_goods = (int)row["id_Goods"];
                    int id = (int)row["id"];

                    await Config.hCntMain.setGoodsVsCategory(id, id_goods, id_Category);
                }
                CmbCategory_SelectionChangeCommitted(null, null);
            }
        }

        private void TbGoodEan_TextChanged(object sender, EventArgs e)
        {
            setFilterGood();
        }

        private void setFilterGood()
        {
            if(dgvGoods.DataSource ==null || (dgvGoods.DataSource as DataTable).Rows.Count==0)
            {
                btAdd.Enabled = btAddAll.Enabled = false;
                return;
            }

            string filter = "";
            try {

                if (cmbGrp1.SelectedIndex != 0)
                    filter += (filter.Length == 0 ? "" : " and ") + $"id_grp1 = {cmbGrp1.SelectedValue}";

                if (cmbGrp2.SelectedIndex != 0)
                    filter += (filter.Length == 0 ? "" : " and ") + $"id_grp2 = {cmbGrp2.SelectedValue}";

                if(tbGoodEan.Text.Length!=0)
                    filter += (filter.Length == 0 ? "" : " and ") + $"ean like '%{tbGoodEan.Text}%'";

                if (tbGoodName.Text.Length != 0)
                    filter += (filter.Length == 0 ? "" : " and ") + $"cname like '%{tbGoodName.Text}%'";

                (dgvGoods.DataSource as DataTable).DefaultView.RowFilter = filter;
            }
            catch
            {
                (dgvGoods.DataSource as DataTable).DefaultView.RowFilter = "id = -1";
            }

            btAdd.Enabled = btAddAll.Enabled = (dgvGoods.DataSource as DataTable).DefaultView.Count != 0;
        }

        private void TbCatEan_TextChanged(object sender, EventArgs e)
        {
            setFilterCategory();
        }

        private void setFilterCategory()
        {
            if (dgvCategoryGood.DataSource == null || (dgvCategoryGood.DataSource as DataTable).Rows.Count == 0)
            {
                btRemote.Enabled = btRemoteAll.Enabled = false;
                return;
            }

            string filter = "";
            try
            {

                if (tbCatEan.Text.Length != 0)
                    filter += (filter.Length == 0 ? "" : " and ") + $"ean like '%{tbCatEan.Text}%'";

                if (tbCatName.Text.Length != 0)
                    filter += (filter.Length == 0 ? "" : " and ") + $"cname like '%{tbCatName.Text}%'";

                (dgvCategoryGood.DataSource as DataTable).DefaultView.RowFilter = filter;
            }
            catch
            {
                (dgvCategoryGood.DataSource as DataTable).DefaultView.RowFilter = "id = -1";
            }

            btRemote.Enabled = btRemoteAll.Enabled = (dgvCategoryGood.DataSource as DataTable).DefaultView.Count != 0;
        }
    }
}
