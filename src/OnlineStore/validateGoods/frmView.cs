using Nwuram.Framework.Settings.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineStore.validateGoods
{
    public partial class frmView : Form
    {
        public DataTable dtGoods { set; private get; }
        private DataTable dtData;
        public frmView()
        {
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
        }

        private void frmView_Load(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                Config.DoOnUIThread(delegate () { this.Enabled = false; }, this);
                init_combobox(true);
                get_data();
                Config.DoOnUIThread(delegate () { this.Enabled = true; }, this);
            });

        }
        private void init_combobox(bool isAll)
        {
            int id_otdel = -1;

            Task<DataTable> task;

            if (isAll)
            {
                task = Config.hCntMain.getDeps();
                task.Wait();
                DataTable dtDeps = task.Result;
                Config.DoOnUIThread(delegate ()
                {
                    DataRow row = dtDeps.NewRow();
                    row["id"] = 0;
                    row["cName"] = "Все отделы";
                    dtDeps.Rows.Add(row);
                    dtDeps.DefaultView.Sort = "id asc";

                    cmbDeps.DataSource = dtDeps;
                    cmbDeps.DisplayMember = "cName";
                    cmbDeps.ValueMember = "id";
                    if (UserSettings.User.StatusCode.ToLower().Equals("ркв"))
                    {
                        cmbDeps.SelectedValue = UserSettings.User.IdDepartment;
                        cmbDeps.Enabled = false;
                    }
                },this);
            }


            Config.DoOnUIThread(delegate ()
            {
                id_otdel = (int)cmbDeps.SelectedValue;
            },this);

            task = Config.hCntMain.getTU(id_otdel);
            task.Wait();
            DataTable dtTU = task.Result;
            task = null;

            Config.DoOnUIThread(delegate ()
            {
                cmbTU.DataSource = dtTU;
                cmbTU.DisplayMember = "cName";
                cmbTU.ValueMember = "id";
            },this);


            task = Config.hCntMain.getInv(id_otdel);
            task.Wait();
            DataTable dtInv = task.Result;
            task = null;

            Config.DoOnUIThread(delegate ()
            {
                cmbInv.DataSource = dtInv;
                cmbInv.DisplayMember = "cName";
                cmbInv.ValueMember = "id";
            },this);

           
        }

        private void get_data()
        {
            int id_otdel = 0;
            Config.DoOnUIThread(delegate ()
            {
                if (this.Enabled)
                    this.Enabled = false;
                id_otdel = (int)cmbDeps.SelectedValue;
            }, this);

            Task<DataTable> task = Config.hCntMain.getValidateGoods();
            task.Wait();
            dtData = task.Result;

            setFilter();

            Config.DoOnUIThread(delegate ()
            {
                dgvData.DataSource = dtData;
                if (!this.Enabled)
                    this.Enabled = true;
            }, this);
        }

        private void setFilter()
        {
            Config.DoOnUIThread(delegate ()
            {
                if (dtData == null || dtData.Rows.Count == 0)
                {
                    btPrint.Enabled = btUpdatePrice.Enabled = false;
                    return;
                }

                try
                {
                    string filter = "";

                    if (tbName.Text.Trim().Length != 0)
                        filter += (filter.Length == 0 ? "" : " and ") + string.Format("nameTovarTerminal like '%{0}%'", tbName.Text.Trim());

                    if (tbNameTerminal.Text.Trim().Length != 0)
                        filter += (filter.Length == 0 ? "" : " and ") + string.Format("nameTovarOnlineStore like '%{0}%'", tbNameTerminal.Text.Trim());

                    if (tbEan.Text.Length > 0)
                        filter += (filter.Length == 0 ? "" : " and ") + $"ean like '%{tbEan.Text.Trim()}%'";

                    if (cmbTU.SelectedValue != null && (int)cmbTU.SelectedValue != 0)
                        filter += (filter.Length == 0 ? "" : " and ") + $"id_grp1 = {cmbTU.SelectedValue}";

                    if (cmbInv.SelectedValue != null && (int)cmbInv.SelectedValue != 0)
                        filter += (filter.Length == 0 ? "" : " and ") + $"id_grp2 = {cmbInv.SelectedValue}";

                    if (cmbDeps.SelectedValue != null && (int)cmbDeps.SelectedValue != 0)
                        filter += (filter.Length == 0 ? "" : " and ") + $"id_otdel = {cmbDeps.SelectedValue}";

                    if (rbSingle.Checked)
                        filter += (filter.Length == 0 ? "" : " and ") + $"len(ean)  <> 4";
                    else
                    if (rbMass.Checked)
                        filter += (filter.Length == 0 ? "" : " and ") + $"len(ean) = 4";

                    dtData.DefaultView.RowFilter = filter;

                }
                catch
                {
                    dtData.DefaultView.RowFilter = "id = -1";
                }
                finally
                {
                    btPrint.Enabled =
                        dtData.DefaultView.Count != 0;
                    isButtonUpdateEnable();
                }
            }, this);
        }

        private void cmbDeps_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Task.Run(() => { init_combobox(false); });

            cmbTU.SelectedIndex = 0;
            cmbInv.SelectedIndex = 0;
            setFilter();
        }

        private void cmbTU_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cmbInv.SelectedValue = 0;
            setFilter();

        }

        private void cmbInv_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cmbTU.SelectedValue = 0;
            setFilter();

        }

        private void dgvData_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            int width = dgvData.Location.X;

            foreach (DataGridViewColumn col in dgvData.Columns)
            {
                if (!col.Visible) continue;
                if (col.Name.Equals(cEan.Name))
                {
                    tbEan.Location = new Point(width + 1, tbEan.Location.Y);
                    tbEan.Size = new Size(col.Width, tbEan.Size.Height);
                }

                if (col.Name.Equals(cName.Name))
                {
                    tbName.Location = new Point(width + 1, tbEan.Location.Y);
                    tbName.Size = new Size(col.Width, tbEan.Size.Height);
                }

                if (col.Name.Equals(cNameTovarTerminal.Name))
                {
                    tbNameTerminal.Location = new Point(width + 1, tbEan.Location.Y);
                    tbNameTerminal.Size = new Size(col.Width, tbEan.Size.Height);
                }
                              

                width += col.Width;
            }
        }

        private void tbEan_TextChanged(object sender, EventArgs e)
        {
            setFilter();
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (cV.Index == e.ColumnIndex)
            {
                dtData.DefaultView[e.RowIndex]["isSelect"] = !(bool)dtData.DefaultView[e.RowIndex]["isSelect"];
                isButtonUpdateEnable();
            }
        }

        private void isButtonUpdateEnable()
        {
            btUpdatePrice.Enabled = dtData != null && dtData.DefaultView.Count > 0 && dtData.DefaultView.ToTable().AsEnumerable().Where(r => r.Field<bool>("isSelect")).Count() > 0;
        }
        private void setWidthColumn(int indexRow, int indexCol, int width, Nwuram.Framework.ToExcelNew.ExcelUnLoad report)
        {
            report.SetColumnWidth(indexRow, indexCol, indexRow, indexCol, width);
        }

        private void setValueToCell(int indexRow, int indexCol, object value)
        {
            if (value is DateTime)
                report.AddSingleValue(((DateTime)value).ToShortDateString(), indexRow, indexCol);
            else
               if (value is decimal || value is double)
            {
                report.AddSingleValueObject(value, indexRow, indexCol);
                report.SetFormat(indexRow, indexCol, indexRow, indexCol, "0.00");
            }
            else
                report.AddSingleValue(value.ToString(), indexRow, indexCol);
        }

        private Nwuram.Framework.UI.Service.EnableControlsServiceInProg blockers = new Nwuram.Framework.UI.Service.EnableControlsServiceInProg();
        private Nwuram.Framework.ToExcelNew.ExcelUnLoad report = null;

        private async void btPrint_Click(object sender, EventArgs e)
        {

            var result = await Task<bool>.Factory.StartNew(() =>
            {

                if (dtData == null || dtData.Rows.Count == 0 || dtData.DefaultView.Count==0)
                {
                    MessageBox.Show("Нет данных для формирования отчёта.", "Печать", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                report = new Nwuram.Framework.ToExcelNew.ExcelUnLoad();


                int indexRow = 1;
                int maxColumns = 0;
                Config.DoOnUIThread(() =>
                {
                    blockers.SaveControlsEnabledState(this);
                    blockers.SetControlsEnabled(this, false);
                    progressBar1.Visible = true;
                }, this);

                foreach (DataGridViewColumn col in dgvData.Columns)
                {
                    if (!col.Visible || col.Name.Equals(cV.Name)) continue;
                    maxColumns++;
                    if (col.Name.Equals(cEan.Name))
                        setWidthColumn(indexRow, maxColumns, 17, report);
                    else
                        setWidthColumn(indexRow, maxColumns, 60, report);
                }


                #region "Head"
                report.Merge(indexRow, 1, indexRow, maxColumns);
                report.SetWrapText(indexRow, 1, indexRow, 1);
                report.SetRowHeight(indexRow, 1, indexRow, 1, 45);
                report.AddSingleValue($"Сравнение наименований товаров", indexRow, 1);
                report.SetFontBold(indexRow, 1, indexRow, 1);
                report.SetFontSize(indexRow, 1, indexRow, 1, 16);
                report.SetCellAlignmentToCenter(indexRow, 1, indexRow, 1);
                indexRow++;
                indexRow++;

                Config.DoOnUIThread(() =>
                {
                    report.Merge(indexRow, 1, indexRow, maxColumns);
                    report.AddSingleValue($"Отдел: {cmbDeps.Text}", indexRow, 1);
                    indexRow++;

                    report.Merge(indexRow, 1, indexRow, maxColumns);
                    report.AddSingleValue($"Т/У группа: {cmbTU.Text}", indexRow, 1);
                    indexRow++;

                    report.Merge(indexRow, 1, indexRow, maxColumns);
                    report.AddSingleValue($"Инв. группа: {cmbInv.Text}", indexRow, 1);
                    indexRow++;

                    string typeGoods = rbAll.Checked ? rbAll.Text : rbMass.Checked ? rbMass.Text : rbSingle.Checked ? rbSingle.Text : "";

                    report.Merge(indexRow, 1, indexRow, maxColumns);
                    report.AddSingleValue($"Тип товара: {typeGoods}", indexRow, 1);
                    indexRow++;

                    report.Merge(indexRow, 1, indexRow, maxColumns);
                    report.AddSingleValue($"Отдел: {cmbDeps.Text}", indexRow, 1);
                    indexRow++;

                    report.Merge(indexRow, 1, indexRow, maxColumns);
                    report.AddSingleValue("Выгрузил: " + Nwuram.Framework.Settings.User.UserSettings.User.FullUsername, indexRow, 1);
                    indexRow++;

                    report.Merge(indexRow, 1, indexRow, maxColumns);
                    report.AddSingleValue("Дата выгрузки: " + DateTime.Now.ToString(), indexRow, 1);
                }, this);
                indexRow++;
                indexRow++;
                #endregion

                int j = 0;
                foreach (DataGridViewColumn col in dgvData.Columns)
                {
                    if (!col.Visible || col.Name.Equals(cV.Name)) continue;
                    j++;
                    report.AddSingleValue(col.HeaderText, indexRow, j);
                }

                report.SetFontBold(indexRow, 1, indexRow, maxColumns);
                report.SetBorders(indexRow, 1, indexRow, maxColumns);
                report.SetCellAlignmentToCenter(indexRow, 1, indexRow, maxColumns);
                report.SetCellAlignmentToJustify(indexRow, 1, indexRow, maxColumns);
                report.SetWrapText(indexRow, 1, indexRow, maxColumns);
                indexRow++;

                foreach (DataRowView row in dtData.DefaultView)
                {
                    j = 0;
                    foreach (DataGridViewColumn col in dgvData.Columns)
                    {
                        
                        if (!col.Visible || col.Name.Equals(cV.Name)) continue;
                        j++;
                        setValueToCell(indexRow, j, row[col.DataPropertyName]);
                    }
                    
                    report.SetBorders(indexRow, 1, indexRow, maxColumns);
                    report.SetCellAlignmentToCenter(indexRow, 1, indexRow, maxColumns);
                    report.SetCellAlignmentToJustify(indexRow, 1, indexRow, maxColumns);
                    indexRow++;
                }
                                   
                Config.DoOnUIThread(() =>
                {
                    blockers.RestoreControlEnabledState(this);
                    progressBar1.Visible = false;
                }, this);

                report.SetPageSetup(1, 9999, true);
                report.Show();
                return true;
            });
        }

        private void tbSingle_Click(object sender, EventArgs e)
        {
            setFilter();
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            get_data();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btUpdatePrice_Click(object sender, EventArgs e)
        {
            EnumerableRowCollection<DataRow> rowCOllect = dtData.AsEnumerable().Where(r => r.Field<bool>("isSelect"));
            if (rowCOllect.Count() == 1) {

                int id = (int)rowCOllect.First()["id"];
                string ean  = (string)rowCOllect.First()["ean"];


                Task<DataTable> task = Config.hCntMain.getGoods(ean);
                task.Wait();
                if (task.Result == null || task.Result.Rows.Count == 0)
                {
                    MessageBox.Show("Нет данных по товару!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if ((int)task.Result.Rows[0]["id"] == -1)
                {
                    MessageBox.Show("Нет товара!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                dtGoods.DefaultView.RowFilter = $"id = {id}";
                DataRowView row = dtGoods.DefaultView[0];

                row["ShortName"] = (string)task.Result.Rows[0]["cNameShort"];
                row["ShortDescription"] = (string)task.Result.Rows[0]["cNameFull"];
                row["FullName"] = (string)task.Result.Rows[0]["cNameFull"];
                if (DialogResult.OK == new dictonatyTovar.frmAddTovar() { id = id, row = row, Text = "Редактирование товара" }.ShowDialog())
                {
                    get_data();
                    return;
                }
            }
            else if (rowCOllect.Count() > 1)
            {

                foreach (DataRow row in rowCOllect)
                {
                    int id = (int)rowCOllect.First()["id"];
                    string ean = (string)rowCOllect.First()["ean"];

                    Task<DataTable> task = Config.hCntMain.getGoods(ean);
                    task.Wait();
                    if (task.Result == null || task.Result.Rows.Count == 0)
                    {
                        //MessageBox.Show("Нет данных по товару!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        continue;
                    }

                    if ((int)task.Result.Rows[0]["id"] == -1)
                    {
                        //MessageBox.Show("Нет товара!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        continue;
                    }

                    Config.hCntMain.UpdateGoodsName(id, (string)task.Result.Rows[0]["cNameShort"], (string)task.Result.Rows[0]["cNameFull"], (string)task.Result.Rows[0]["cNameFull"]).Wait();
                }
                MessageBox.Show("Данные сохранены", "Сохранение данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                get_data();
                return;
            }
        }
    }
}
