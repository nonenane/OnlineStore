using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nwuram.Framework.Logging;

namespace OnlineStore
{
    public partial class frmPercents : Form
    {
        public frmPercents()
        {
            InitializeComponent();
            dgvDataGrp.AutoGenerateColumns = false;
            dgvPercents.AutoGenerateColumns = false;
            dgvDataTovar.AutoGenerateColumns = false;
        }

        DataTable dtPercent, dtPercentOld;
        public bool lChanged = false;
        private bool oldSale;


        private void frmPercents_Load(object sender, EventArgs e)
        {
            init_combobx();
            dgvPercents_Init();
            getGoods();
            getGroups();
            chckUseSale.Checked = Config.isSale;
            oldSale = Config.isSale;
        }
      
        private void dgvPercents_Init()
        {
            dtPercent = Config.hCntMain.GetPercents();
            dgvPercents.DataSource = dtPercent;

            dtPercentOld = dtPercent.Copy();
            //dtPercentOld = Config.hCntMain.GetPercents();

        }

        private bool EqualDataTable()
        {
            for (int i = 0; i < dtPercent.Rows.Count; i++)
                for (int j = 0; j < dtPercent.Columns.Count; j++)
                {
                    if (!(Equals(dtPercent.Rows[i][j],dtPercentOld.Rows[i][j])))
                        return false;

                }
            return true;
        }

        bool error = false;
        private void SaveData()
        {
            bool changed = false;
            error = false;
            foreach (DataRow dr in dtPercent.Rows)
            {
                if (decimal.Parse(dr["MarkUpPercent"].ToString()) > 100 || decimal.Parse(dr["MarkUpPercent"].ToString()) < 0 ||
                    decimal.Parse(dr["salePercent"].ToString()) > 100 || decimal.Parse(dr["salePercent"].ToString()) < 0)
                {
                    MessageBox.Show("Процент должен находиться в диапазоне от 0.00 до 100.00", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    error = true;
                    return;
                }
            }

            foreach (DataRow dr in dtPercent.Rows)
            {
                DataRow drold = dtPercentOld.AsEnumerable().Where(r => r.Field<int>("id") == (int) dr["id"]).First();
                if (!(Equals(dr["MarkUpPercent"],drold["MarkUpPercent"]) && Equals(dr["salePercent"],drold["salePercent"])))
                {
                    Config.hCntMain.SetPercents(int.Parse(dr["id_Department"].ToString()), decimal.Parse(dr["MarkUpPercent"].ToString()), decimal.Parse(dr["salePercent"].ToString()));
                    changed = true;
                }

            }

            if (oldSale!=chckUseSale.Checked)
            {
                Config.hCntMain.setConfig(chckUseSale.Checked ? "1" : "0");
                Config.isSale = chckUseSale.Checked;
            }

            lChanged = changed;
            #region Логирование
            if (changed)
            {
                Logging.StartFirstLevel(11);
                Logging.Comment("Изменение настроек процента наценки/распродажи отдела");
                foreach (DataRow dr in dtPercent.Rows)
                {
                    DataRow drold = dtPercentOld.AsEnumerable().Where(r => r.Field<int>("id") == (int)dr["id"]).First();
                    bool start = false;
                    if (!(Equals(dr["MarkUpPercent"], drold["MarkUpPercent"]) && Equals(dr["salePercent"], drold["salePercent"])))
                    {
                        Logging.Comment($"id отдела: {dr["id_Department"]}, название отдела: {dr["name"]}");
                        Logging.VariableChange("Процент наценки", dr["MarkUpPercent"], drold["MarkUpPercent"]);
                        Logging.VariableChange("Процент распродажи", dr["salePercent"], drold["salePercent"]);
                    }

                }
                //Logging.CompareDataTable(dtPercentOld, dtPercent, "id_Department", new int[4] {1, 2, 3, 4 });
                //Logging.CompareDataTable(dtPercentOld, dtPercent, "Код отдела", new int[4] { 1, 2, 3, 4 }, new string[] { "Код отдела", "Наименование отдела" }, new int[] { 1, 2, 3, 4 });
                Logging.Comment($"Использовать цены для распродажи: {(chckUseSale.Checked ? "Да" : "Нет")}");
                Logging.Comment("Завершение редактирования настроек процента наценки/распродажи");
                Logging.StopFirstLevel();
            }
            #endregion
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (!EqualDataTable())
            {
                if (MessageBox.Show(Config.centralText("Процент был изменен\nВы точно хотите выйти с формы?\n"), "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Close();
                }
                else return;
            }
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();
            if (error) return;
            Config.dtPercents =  Config.hCntMain.GetPercents();
            //dtPercent = Config.dtPercents.Copy();
            //dtPercentOld = Config.dtPercents.Copy();
            MessageBox.Show("Проценты сохранены", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvPercents_Init();
            //this.Close();
        }

        private void dgvPercents_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>-1)
            {
               
                if (e.ColumnIndex == 1)
                {


                    dgvPercents.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Math.Round(decimal.Parse(dgvPercents.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()), 2);
                    dtPercent.Rows[e.RowIndex]["MarkUpPercent"] = dgvPercents.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                }
                if (e.ColumnIndex == 2)
                {
                    
                     

                    dtPercent.Rows[e.RowIndex]["salePercent"] = dgvPercents.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                }


                dtPercent.AcceptChanges();
            }
        }

        private void chckUseSale_CheckedChanged(object sender, EventArgs e)
        {
            //Config.isSale = chckUseSale.Checked;
        }

        private void dgvPercents_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
     
            if (dgvPercents.CurrentCell.ColumnIndex == 1 || dgvPercents.CurrentCell.ColumnIndex == 2)
            {
                e.Control.KeyPress -= new KeyPressEventHandler(NumericCheck);
                e.Control.KeyPress += new KeyPressEventHandler(NumericCheck);
                
            }
            else
            {
                e.Control.KeyPress -= new KeyPressEventHandler(NumericCheck);
            }
        }
        
        private static void NumericCheck(object sender, KeyPressEventArgs e)
        {
            DataGridViewTextBoxEditingControl s = sender as DataGridViewTextBoxEditingControl;
            if (s != null && (e.KeyChar == '.' || e.KeyChar == ','))
            {
                e.KeyChar = System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];
                e.Handled = s.Text.Contains(e.KeyChar);
            }
            else
                e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void dgvPercents_KeyPress(object sender, KeyPressEventArgs e)
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

        private void dgvPercents_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            //Рисуем рамку для выделеной строки
            if (dgv.Rows[e.RowIndex].Selected)
            {
                int width = dgv.Width;
                Rectangle r = dgv.GetRowDisplayRectangle(e.RowIndex, false);
                Rectangle rect = new Rectangle(r.X, r.Y, width - 1, r.Height - 1);

                ControlPaint.DrawBorder(e.Graphics, rect,
                    SystemColors.Highlight, 2, ButtonBorderStyle.Solid,
                    SystemColors.Highlight, 2, ButtonBorderStyle.Solid,
                    SystemColors.Highlight, 2, ButtonBorderStyle.Solid,
                    SystemColors.Highlight, 2, ButtonBorderStyle.Solid);
            }
        }

        private void dgvPercents_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex != -1 && dtPercent != null && dtPercent.DefaultView.Count != 0)
            {
                Color rColor = Color.White;
                dgvPercents.Rows[e.RowIndex].DefaultCellStyle.BackColor = rColor;
                dgvPercents.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = rColor;
                dgvPercents.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;
            }
        }

        private void dgvPercents_EditingControlShowing_1(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvPercents.CurrentCell.ColumnIndex == 1 || dgvPercents.CurrentCell.ColumnIndex == 2)
            {
                e.Control.KeyPress -= new KeyPressEventHandler(NumericCheck);
                e.Control.KeyPress += new KeyPressEventHandler(NumericCheck);

            }
            else
            {
                e.Control.KeyPress -= new KeyPressEventHandler(NumericCheck);
            }
        }

        private void dgvPercents_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == cMargin.Index || e.ColumnIndex == cSale.Index)
            {
                decimal tmp = 0.00M;
                if (!decimal.TryParse(dtPercent.DefaultView[e.RowIndex][e.ColumnIndex == 2 ? "MarkUpPercent" : "salePercent"].ToString(),out tmp))
                    //||  !decimal.TryParse(dtPercent.DefaultView[e.RowIndex]["salePercent"].ToString(), out tmp))
                {
                    MessageBox.Show("Введены неверные данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
            }
        }

        private void dgvPercents_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == cMargin.Index) 
                dtPercent.DefaultView[e.RowIndex]["MarkUpPercent"] = decimal.Parse(dtPercent.DefaultView[e.RowIndex]["MarkUpPercent"].ToString()).ToString("0.00");
            if (e.ColumnIndex == cSale.Index)
                 dtPercent.DefaultView[e.RowIndex]["salePercent"] = decimal.Parse(dtPercent.DefaultView[e.RowIndex]["salePercent"].ToString()).ToString("0.00");
        }

        private void dgvPercents_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
        }






        #region "Общее"

        private void DoOnUIThread(MethodInvoker d)
        {
            if (this.InvokeRequired) { this.Invoke(d); } else { d(); }
        }

        private void init_combobx()
        {
            Task<DataTable> task = Config.hCntMain.getDeps();
            task.Wait();
            DataTable dtDeps = task.Result;
            DoOnUIThread(delegate ()
            {
                DataRow row = dtDeps.NewRow();
                row["id"] = 0;
                row["cName"] = "Все отделы";
                dtDeps.Rows.Add(row);
                dtDeps.DefaultView.Sort = "id asc";

                cmbDepsGrp.DataSource = dtDeps.DefaultView.ToTable().Copy();
                cmbDepsGrp.DisplayMember = "cName";
                cmbDepsGrp.ValueMember = "id";

                cmbDepsTovar.DataSource = dtDeps.DefaultView.ToTable().Copy();
                cmbDepsTovar.DisplayMember = "cName";
                cmbDepsTovar.ValueMember = "id";
            });
        }

        private void init_combobox(bool isAll)
        {
            DoOnUIThread(delegate () { //this.Enabled = false;
            });

            Task<DataTable> task;

            int id_otdel = -1;
            DoOnUIThread(delegate ()
            {
                id_otdel = (int)cmbDepsTovar.SelectedValue;
            });



            task = Config.hCntMain.getTU(id_otdel);
            task.Wait();
            DataTable dtTU = task.Result;
            task = null;

            DoOnUIThread(delegate ()
            {
                cmbTU.DataSource = dtTU;
                cmbTU.DisplayMember = "cName";
                cmbTU.ValueMember = "id";
            });


            task = Config.hCntMain.getInv(id_otdel);
            task.Wait();
            DataTable dtInv = task.Result;
            task = null;

            DoOnUIThread(delegate ()
            {
                cmbInv.DataSource = dtInv;
                cmbInv.DisplayMember = "cName";
                cmbInv.ValueMember = "id";
            });

            DoOnUIThread(delegate () {
                //this.Enabled = true;
                cmbTU.SelectedIndex = 0;
                cmbInv.SelectedIndex = 0;
                setFilterTovar();
            });
        }

        #endregion

        #region "Группы"
        private void dgvDataGrp_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            tbNameGrp.Location = new Point(dgvDataGrp.Location.X + 1, tbNameGrp.Location.Y);
            tbNameGrp.Size = new Size(cNameGrp.Width, tbNameGrp.Size.Height);
        }

        private void cmbDepsGrp_SelectionChangeCommitted(object sender, EventArgs e)
        {
            setFilterGrp();
        }

        DataTable dtGroups, dtGoods;

        private void getGroups()
        {
            Task<DataTable> task = Config.hCntMain.getGrp2VsPercentSettingsGroups();
            task.Wait();

            dtGroups = task.Result;
            setFilterGrp();
            dgvDataGrp.DataSource = dtGroups;
        }

        private void tbNameGrp_TextChanged(object sender, EventArgs e)
        {
            setFilterGrp();
        }

        private void setFilterGrp()
        {
            if (dtGroups == null || dtGroups.Rows.Count == 0)
            {
                btDelGrp.Enabled = false;
                return;
            }

            try
            {
                string filter = "";

                if((int)cmbDepsGrp.SelectedValue != 0)
                    filter += (filter.Length == 0 ? "" : " and ") + $"id_otdel  = {cmbDepsGrp.SelectedValue}";
                
                if (tbNameGrp.Text.Trim().Length != 0)
                    filter += (filter.Length == 0 ? "" : " and ") + $"cName like '%{tbNameGrp.Text.Trim()}%'";

                if (chbUsedPrc.Checked)
                    filter += (filter.Length == 0 ? "" : " and ") + $"id_percent is not null";

                dtGroups.DefaultView.RowFilter = filter;
            }
            catch
            {
                dtGroups.DefaultView.RowFilter = "id = -1";
            }
            finally
            {
                btDelGrp.Enabled = dtGroups.DefaultView.Count != 0;
                dgvDataGrp_SelectionChanged(null, null);
            }
        }

        private void dgvDataGrp_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDataGrp.CurrentRow == null || dgvDataGrp.CurrentRow.Index == -1 || dtGroups == null || dtGroups.DefaultView.Count == 0 || dgvDataGrp.CurrentRow.Index >= dtGroups.DefaultView.Count)
            {
                btDelGrp.Enabled = false;
                return;
            }

            //btDelGrp.Enabled = true;
            btDelGrp.Enabled = dtGroups.DefaultView[dgvDataGrp.CurrentRow.Index]["id_percent"] != DBNull.Value;
        }

        private void chbUsedPrc_CheckedChanged(object sender, EventArgs e)
        {
            setFilterGrp();
        }

        private void btDelGrp_Click(object sender, EventArgs e)
        {         
            if (dgvDataGrp.CurrentRow != null && dgvDataGrp.CurrentRow.Index != -1 && dtGroups != null && dtGroups.DefaultView.Count != 0)
            {
                decimal? MarkUpPercent = null;
                decimal? salePercent = null;
                
                DataRowView row = dtGroups.DefaultView[dgvDataGrp.CurrentRow.Index];
                int id = (int)row["id"];

                if (row["MarkUpPercent"] != DBNull.Value)
                    MarkUpPercent = (decimal)row["MarkUpPercent"];

                if (row["salePercent"] != DBNull.Value)
                    salePercent = (decimal)row["salePercent"];

                Task<DataTable> task = Config.hCntMain.setPercentSettingsGroups(id, MarkUpPercent, salePercent, true, 0, true);
                task.Wait();

                if (task.Result == null || task.Result.Rows.Count == 0)
                {
                    MessageBox.Show("Не удалось сохранить данные", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if ((int)task.Result.Rows[0]["id"] == -9999)
                {
                    MessageBox.Show($"{task.Result.Rows[0]["msg"].ToString()}", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if ((int)task.Result.Rows[0]["id"] == -1)
                {
                    MessageBox.Show(Config.centralText("Запись уже удалена другим пользователем\n"), "Удаление записи", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    getGroups();
                    return;
                }

                if (DialogResult.Yes == MessageBox.Show("Удалить выбранную запись?", "Удаление записи", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    task = Config.hCntMain.setPercentSettingsGroups(id, MarkUpPercent, salePercent, true, 1, true);
                    task.Wait();

                    #region log
                    Logging.StartFirstLevel(1591);
                    Logging.Comment("Начало удаления процентов наценки/распродажи у группы");
                    Logging.Comment($"id: {row["id"].ToString()}, Наименование: {row["cName"].ToString()}");
                    Logging.Comment($"Процент наценки: {MarkUpPercent}");
                    Logging.Comment($"Процент распродажи: {salePercent}");
                    Logging.Comment("Завершение удаления процентов наценки/распродажи у группы");
                    Logging.StopFirstLevel();
                    #endregion
                    getGroups();
                }
            }
        }

            private void btAddGrp_Click(object sender, EventArgs e)
        {
            if (dgvDataGrp.CurrentRow != null && dgvDataGrp.CurrentRow.Index != -1 && dtGroups != null && dtGroups.DefaultView.Count != 0)
            {
                DataRowView row = dtGroups.DefaultView[dgvDataGrp.CurrentRow.Index];

                if (new frmAddPercent() { row = row, Text = "Добавление процентов",isGroup=true }.ShowDialog() == DialogResult.OK)
                    getGroups();
            }
        }

        #endregion

        #region "Товары"

        private void cmbDepsTovar_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Task.Run(() => { init_combobox(false); });
        }

        private void cmbTU_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cmbInv.SelectedValue = 0;
            setFilterTovar();
        }

        private void cmbInv_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cmbTU.SelectedValue = 0;
            setFilterTovar();
        }

        private void dgvDataTovar_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            int width = 0;

            foreach (DataGridViewColumn col in dgvDataTovar.Columns)
            {
                if (!col.Visible) continue;

                if (col.Name.Equals(cEan.Name))
                {
                    tbEan.Location = new Point(dgvDataTovar.Location.X + 1 + width, tbEan.Location.Y);
                    tbEan.Size = new Size(cEan.Width, tbEan.Size.Height);
                }
                else if (col.Name.Equals(cNameTovar.Name))
                {
                    tbNameTovar.Location = new Point(dgvDataTovar.Location.X + 1 + width, tbEan.Location.Y);
                    tbNameTovar.Size = new Size(cNameTovar.Width, tbEan.Size.Height);
                }

                width += col.Width;
            }
        }

        private void dgvDataTovar_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDataTovar.CurrentRow == null || dgvDataTovar.CurrentRow.Index == -1 || dtGoods == null || dtGoods.DefaultView.Count == 0 || dgvDataTovar.CurrentRow.Index >= dtGoods.DefaultView.Count)
            {
                btDeleteTovar.Enabled = false;
                return;
            }

            //btDeleteTovar.Enabled = true;
            btDeleteTovar.Enabled = dtGoods.DefaultView[dgvDataTovar.CurrentRow.Index]["id_percent"] !=DBNull.Value;
        }

        private void chbUserPrcTovar_CheckedChanged(object sender, EventArgs e)
        {
            setFilterTovar();
        }

        private void tbEan_TextChanged(object sender, EventArgs e)
        {
            setFilterTovar();
        }

        private void btDeleteTovar_Click(object sender, EventArgs e)
        {
            if (dgvDataTovar.CurrentRow != null && dgvDataTovar.CurrentRow.Index != -1 && dtGoods != null && dtGoods.DefaultView.Count != 0)
            {              
                decimal? MarkUpPercent = null;
                decimal? salePercent = null;

                DataRowView row = dtGoods.DefaultView[dgvDataTovar.CurrentRow.Index];
                int id = (int)row["id"];

                if (row["MarkUpPercent"] != DBNull.Value)
                    MarkUpPercent = (decimal)row["MarkUpPercent"];

                if (row["salePercent"] != DBNull.Value)
                    salePercent = (decimal)row["salePercent"];

                Task<DataTable> task = Config.hCntMain.setPercentSettingsGroups(id, MarkUpPercent, salePercent, false, 0, true);
                task.Wait();

                if (task.Result == null || task.Result.Rows.Count == 0)
                {
                    MessageBox.Show("Не удалось сохранить данные", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if ((int)task.Result.Rows[0]["id"] == -9999)
                {
                    MessageBox.Show($"{task.Result.Rows[0]["msg"].ToString()}", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if ((int)task.Result.Rows[0]["id"] == -1)
                {
                    MessageBox.Show(Config.centralText("Запись уже удалена другим пользователем\n"), "Удаление записи", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    getGoods();
                    return;
                }

                if (DialogResult.Yes == MessageBox.Show("Удалить выбранную запись?", "Удаление записи", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    task = Config.hCntMain.setPercentSettingsGroups(id, MarkUpPercent, salePercent, false, 1, true);
                    task.Wait();

                    #region log
                    Logging.StartFirstLevel(1591);
                    Logging.Comment("Начало удаления процентов наценки/распродажи у товара");
                    Logging.Comment($"id: {row["id"].ToString()}, Наименование: {row["cName"].ToString()}");
                    Logging.Comment($"Процент наценки: {MarkUpPercent}");
                    Logging.Comment($"Процент распродажи: {salePercent}");
                    Logging.Comment("Завершение удаления процентов наценки/распродажи у товара");
                    Logging.StopFirstLevel();
                    #endregion
                    getGoods();
                }
            }
        }

        private void btAddGood_Click(object sender, EventArgs e)
        {
            if (dgvDataTovar.CurrentRow != null && dgvDataTovar.CurrentRow.Index != -1 && dtGoods != null && dtGoods.DefaultView.Count != 0)
            {
                DataRowView row = dtGoods.DefaultView[dgvDataTovar.CurrentRow.Index];

                if (new frmAddPercent() { row = row, Text = "Добавление процентов", isGroup = false }.ShowDialog() == DialogResult.OK)
                    getGoods();
            }
        }
       
        private void getGoods()
        {
            Task<DataTable> task = Config.hCntMain.getGoodsVsPercentSettingsGoods();
            task.Wait();

            dtGoods = task.Result;
            setFilterTovar();
            dgvDataTovar.DataSource = dtGoods;
        }

        private void setFilterTovar()
        {
            if (dtGoods == null || dtGoods.Rows.Count == 0)
            {
                btDeleteTovar.Enabled = false;
                return;
            }

            try
            {
                string filter = "";

                if (cmbDepsTovar.SelectedValue != null && (int)cmbDepsTovar.SelectedValue != 0)
                    filter += (filter.Length == 0 ? "" : " and ") + $"id_otdel  = {cmbDepsTovar.SelectedValue}";

                if (cmbTU.SelectedValue != null && (int)cmbTU.SelectedValue != 0)
                    filter += (filter.Length == 0 ? "" : " and ") + $"id_grp1  = {cmbTU.SelectedValue}";

                if (cmbInv.SelectedValue != null && (int)cmbInv.SelectedValue != 0)
                    filter += (filter.Length == 0 ? "" : " and ") + $"id_grp2  = {cmbInv.SelectedValue}";


                if (tbNameTovar.Text.Trim().Length != 0)
                    filter += (filter.Length == 0 ? "" : " and ") + $"cName like '%{tbNameTovar.Text.Trim()}%'";

                if (tbEan.Text.Trim().Length != 0)
                    filter += (filter.Length == 0 ? "" : " and ") + $"ean like '%{tbEan.Text.Trim()}%'";

                if (chbUserPrcTovar.Checked)
                    filter += (filter.Length == 0 ? "" : " and ") + $"id_percent is not null";

                dtGoods.DefaultView.RowFilter = filter;
            }
            catch
            {
                dtGoods.DefaultView.RowFilter = "id = -1";
            }
            finally
            {
                btDeleteTovar.Enabled =
                dtGoods.DefaultView.Count != 0;
                dgvDataTovar_SelectionChanged(null, null);
            }
        }

        #endregion
    }
}


/*
  if (dgvPercents.CurrentCell.ColumnIndex == 1 || dgvPercents.CurrentCell.ColumnIndex == 2)
            {
                e.Control.KeyPress -= new KeyPressEventHandler(NumericCheck);
                e.Control.KeyPress += new KeyPressEventHandler(NumericCheck);
                
            }
            else
            {
                e.Control.KeyPress -= new KeyPressEventHandler(NumericCheck);
            }
 */
