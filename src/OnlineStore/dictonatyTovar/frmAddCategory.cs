using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineStore.dictonatyTovar
{
    public partial class frmAddCategory : Form
    {
        public int id_tovar { set; private get; }
        public string nameTovar { set; private get; }
        public int id_deps { set; private get; }
        private DataTable dtDeps, dtCat, dtUseCategoryOld;
        public DataTable dtUseCategory { set; get; }
        public frmAddCategory()
        {
            InitializeComponent();
            dgvMain.AutoGenerateColumns = false;
            dgvSelect.AutoGenerateColumns = false;
        }

        private void FrmAddCategory_Load(object sender, EventArgs e)
        {
            tbName.Text = nameTovar;
            cbDeps_Init();
            initCategory();
            getUserCategory();
        }

        private void cbDeps_Init()
        {
            Task<DataTable> task = Config.hCntMain.getDeps();
            task.Wait();
            dtDeps = task.Result;
            cbDeps.DataSource = dtDeps;
            cbDeps.DisplayMember = "cName";
            cbDeps.ValueMember = "id";
            cbDeps.SelectedValue = id_deps;
        }

        private void initCategory()
        {
            dtCat = Config.hCntMain.getCategory(0, true).Result;

            if (dtCat != null && dtCat.Rows.Count > 0)
                while (dtCat.AsEnumerable().Where(r => r.Field<object>("id") == null).Count() != 0)
                    dtCat.AsEnumerable().Where(r => r.Field<object>("id") == null).First().Delete();

            setFilter();
            dgvMain.DataSource = dtCat;
        }

        private void getUserCategory()
        {            
            dtUseCategoryOld = dtUseCategory.Copy();
            dgvSelect.DataSource = dtUseCategory;
        }

        private void setFilter()
        {
            if (dtCat == null || dtCat.Rows.Count == 0) { btAdd.Enabled = btAddAll.Enabled = false; return; }
            try
            {
                string filter = "";

                filter += (filter.Length == 0 ? "" : " and ") + $"id_Departments = {cbDeps.SelectedValue}";

                if (tbFindTovar.Text.Trim().Length > 0)
                    filter += (filter.Length == 0 ? "" : " and ") + $"cName like '%{tbFindTovar.Text}%'";

                dtCat.DefaultView.RowFilter = filter;
            }
            catch {
                dtCat.DefaultView.RowFilter = "id = -1";
            }

            btAdd.Enabled = btAddAll.Enabled = dtCat.DefaultView.Count != 0;
            DgvMain_SelectionChanged(null, null);
        }

        private void BtClose_Click(object sender, EventArgs e)
        {
            //dtUseCategory = dtUseCategoryOld.Copy();
            this.DialogResult = DialogResult.Cancel;
        }

        private void BtSave_Click(object sender, EventArgs e)
        {
            dtUseCategoryOld = dtUseCategory.Copy();
            this.DialogResult = DialogResult.OK;
        }

        private void CbDeps_SelectionChangeCommitted(object sender, EventArgs e)
        {
            setFilter();
        }

        private void BtAddAll_Click(object sender, EventArgs e)
        {
            foreach (DataRowView row in dtCat.DefaultView)
            {
                EnumerableRowCollection<DataRow> rowCollect = dtUseCategory.AsEnumerable().Where(r => r.Field<int>("id_Category") == (int)row["id"]);
                if (rowCollect.Count() == 0)
                {
                    object id = DBNull.Value;

                    if (dtUseCategoryOld != null)
                    {
                        EnumerableRowCollection<DataRow> rowCollectID = dtUseCategoryOld.AsEnumerable().Where(r => r.Field<int>("id_Category") == (int)row["id"] && r.Field<object>("id") != null);
                        if (rowCollectID.Count() > 0)
                        {
                            id = (int)rowCollectID.First()["id"];
                            if (listDel.Contains((int)id)) listDel.Remove((int)id);
                        }
                    }

                    DataRow newRow = dtUseCategory.NewRow();
                    newRow["id"] = id;
                    newRow["id_Category"] = row["id"];
                    newRow["cName"] = row["cName"];
                    dtUseCategory.Rows.Add(newRow);
                }
            }
            btRemove.Enabled = btRemoveAll.Enabled = dtUseCategory.DefaultView.Count != 0;
            DgvMain_SelectionChanged(null, null);
        }

        private void BtAdd_Click(object sender, EventArgs e)
        {
            if (dgvMain.CurrentRow != null && dgvMain.CurrentRow.Index != -1)
            {
                DataRowView row = dtCat.DefaultView[dgvMain.CurrentRow.Index];

                if (dtUseCategory.AsEnumerable().Where(r => r.Field<int>("id_Category") == (int)row["id"]).Count() == 0)
                {
                    object id = DBNull.Value;
                    if (dtUseCategoryOld != null)
                    {
                        EnumerableRowCollection<DataRow> rowCollectID = dtUseCategoryOld.AsEnumerable().Where(r => r.Field<int>("id_Category") == (int)row["id"] && r.Field<object>("id") != null);
                        if (rowCollectID.Count() > 0)
                        {
                            id = (int)rowCollectID.First()["id"];
                            if (listDel.Contains((int)id)) listDel.Remove((int)id);
                        }
                    }

                    DataRow newRow = dtUseCategory.NewRow();
                    newRow["id"] = id;
                    newRow["id_Category"] = row["id"];
                    newRow["cName"] = row["cName"];
                    dtUseCategory.Rows.Add(newRow);

                    btRemove.Enabled = btRemoveAll.Enabled = dtUseCategory.DefaultView.Count != 0;
                }
                DgvMain_SelectionChanged(null, null);
            }
        }

        private void DgvMain_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMain.CurrentRow != null && dgvMain.CurrentRow.Index != -1 )
            {
                DataRowView row = dtCat.DefaultView[dgvMain.CurrentRow.Index];
                btAdd.Enabled = dtUseCategory==null || dtUseCategory.Rows.Count==0 || dtUseCategory.AsEnumerable().Where(r => r.Field<int>("id_Category") == (int)row["id"]).Count() == 0;
                btAddAll.Enabled = true;
            }
            else { btAdd.Enabled = btAddAll.Enabled = false; }
        }

        private List<int> listDel = new List<int>();

        private void TbFindTovar_TextChanged(object sender, EventArgs e)
        {
            setFilter();
        }

        private void FrmAddCategory_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool isEditData = dtUseCategory.AsEnumerable().Except(dtUseCategoryOld.AsEnumerable(), DataRowComparer.Default).Count() > 0;
            e.Cancel = isEditData &&  DialogResult.No == MessageBox.Show("На форме есть не сохранённые данные.\nЗакрыть форму без сохранения данных?\n", "Закрытие формы", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (!e.Cancel)
            {
                dtUseCategory = dtUseCategoryOld.Copy();
            }
        }

        private void BtRemove_Click(object sender, EventArgs e)
        {
            if (dgvSelect.CurrentRow != null && dgvSelect.CurrentRow.Index != -1)
            {
                DataRowView row = dtUseCategory.DefaultView[dgvSelect.CurrentRow.Index];
                if (row["id"] != DBNull.Value)
                    if (!listDel.Contains((int)row["id"])) listDel.Add((int)row["id"]);
                row.Delete();

                btRemove.Enabled = btRemoveAll.Enabled = dtUseCategory.DefaultView.Count != 0;

                DgvMain_SelectionChanged(null, null);
            }
        }

        private void BtRemoveAll_Click(object sender, EventArgs e)
        {           
        }
    }
}
