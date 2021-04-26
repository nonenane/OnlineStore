using Nwuram.Framework.Logging;
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

namespace OnlineStore.dictonaryCategory
{
    public partial class frmListCategory : Form
    {
        private DataTable dtData;
        public bool isEdited { get; set; } = false;
        public frmListCategory()
        {
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
            ToolTip tp = new ToolTip();
            tp.SetToolTip(btPrint,"Печать");
            tp.SetToolTip(btDel, "Удалить");
            tp.SetToolTip(btAdd, "Добавить");
            tp.SetToolTip(btEdit, "Редактировать");
        }

        private void frmListCategory_Load(object sender, EventArgs e)
        {
            Task<DataTable> task = Config.hCntMain.getDeps();
            task.Wait();
            DataTable dtDeps = task.Result;

            cmbDeps.DataSource = dtDeps;
            cmbDeps.DisplayMember = "cName";
            cmbDeps.ValueMember = "id";            
            if (UserSettings.User.StatusCode.ToLower().Equals("ркв"))
            {
                cmbDeps.SelectedValue = UserSettings.User.IdDepartment;
                cmbDeps.Enabled = false;
            }

            get_data();
        }

        #region "Получение данных"
        private void DoOnUIThread(MethodInvoker d)
        {
            if (this.InvokeRequired) { this.Invoke(d); } else { d(); }
        }

        private void get_data()
        {
            DoOnUIThread(delegate () { this.Enabled = false; });

            Task<DataTable> task = Config.hCntMain.getDicCategory();
            task.Wait();
            dtData = task.Result;
            setFilter();
            dgvData.DataSource = dtData;

            DoOnUIThread(delegate () { this.Enabled = true; });
        }

        private void setFilter()
        {
            if (dtData == null || dtData.Rows.Count == 0)
            {
                btPrint.Enabled = btEdit.Enabled = btDel.Enabled = false;
                return;
            }
           
            try
            {
                string filter = "";

                if (tbName.Text.Trim().Length != 0)
                    filter += (filter.Length == 0 ? "" : " and ") + string.Format("cName like '%{0}%'", tbName.Text.Trim());

                if (cmbDeps.SelectedValue != null && (int)cmbDeps.SelectedValue != 0)
                    filter += (filter.Length == 0 ? "" : " and ") + $"id_Departments = {cmbDeps.SelectedValue}";
                

                if (!chbUnable.Checked)
                    filter += (filter.Length == 0 ? "" : " and ") + string.Format("isActive = 1", "");

                dtData.DefaultView.RowFilter = filter;

            }
            catch
            {
                dtData.DefaultView.RowFilter = "id = -1";
            }
            finally
            {
                btPrint.Enabled =
                    //btEdit.Enabled = btDel.Enabled = 
                    dtData.DefaultView.Count != 0;
                dtData.DefaultView.Sort = " id_Departments asc, cName asc";
                dgvData_SelectionChanged(null, null);
            }        

        }
        #endregion

        private void dgvData_Paint(object sender, PaintEventArgs e)
        {
            tbName.Location = new Point(dgvData.Location.X+cDeps.Width, tbName.Location.Y);
            tbName.Size = new Size(cName.Width, tbName.Height);
        }

        private void dgvData_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow == null || dgvData.CurrentRow.Index == -1 || dtData == null || dtData.DefaultView.Count == 0 || dgvData.CurrentRow.Index >= dtData.DefaultView.Count)
            {
                btDel.Enabled = false;
                btEdit.Enabled = false;
                return;
            }

            btDel.Enabled = true;
            btEdit.Enabled = (bool)dtData.DefaultView[dgvData.CurrentRow.Index]["isActive"];
        }

        private void dgvData_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void dgvData_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex != -1 && dtData != null && dtData.DefaultView.Count != 0)
            {
                Color rColor = Color.White;
                if (!(bool)dtData.DefaultView[e.RowIndex]["isActive"])
                    rColor = panel1.BackColor;
                //else
                //    if (e.RowIndex % 2 == 0)
                //        rColor = Color.Aqua;

                dgvData.Rows[e.RowIndex].DefaultCellStyle.BackColor = rColor;
                dgvData.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = rColor;

                dgvData.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;
            }
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            setFilter();
        }

        private void chbUnable_CheckedChanged(object sender, EventArgs e)
        {
            setFilter();
        }

        private void btPrint_Click(object sender, EventArgs e)
        {

            Logging.StartFirstLevel(79);

            Logging.Comment("Выгрузка отчёта из справочника категорий");
            if (!string.IsNullOrWhiteSpace(tbName.Text))
                Logging.Comment($"Фильтр по наименованию категорий: {tbName.Text}");            
            Logging.StopFirstLevel();

            Nwuram.Framework.ToExcelNew.ExcelUnLoad report = new Nwuram.Framework.ToExcelNew.ExcelUnLoad("list-1");

            int rIndex = 1;

            report.Merge(rIndex, 1, rIndex, 5);
            report.AddSingleValue("Справочник категорий", rIndex, 1);
            report.SetCellAlignmentToCenter(rIndex, 1, rIndex, 1);
            report.SetFontBold(rIndex, 1, rIndex, 1);
            report.SetFontSize(rIndex, 1, rIndex, 1, 14);
            rIndex++;

            report.Merge(rIndex, 3, rIndex, 5);
            report.AddSingleValue("Выгрузил: " + UserSettings.User.FullUsername, rIndex, 3);
            report.SetCellAlignmentToRight(rIndex, 3, rIndex, 3);
            rIndex++;


            report.Merge(rIndex, 1, rIndex, 2);
            report.Merge(rIndex, 3, rIndex, 5);
            report.AddSingleValue("Фильтры: " + tbName.Text, rIndex, 1);
            report.AddSingleValue("Дата выгрузки: " + DateTime.Now.ToString(), rIndex, 3);
            report.SetCellAlignmentToRight(rIndex, 3, rIndex, 3);
            rIndex++;                        
            rIndex++;



            int cIndex = 0;
            foreach (DataGridViewColumn col in dgvData.Columns)
            {
                if (col.Visible)
                {
                    cIndex++;
                    report.AddSingleValue(col.HeaderText, rIndex, cIndex);
                }
            }
            report.SetBorders(rIndex, 1, rIndex, cIndex);
            report.SetCellAlignmentToCenter(rIndex, 1, rIndex, cIndex);
            rIndex++;

            foreach (DataRowView row in dtData.DefaultView)
            {
                report.AddSingleValue(row["nameDep"].ToString(), rIndex, 1);
                report.AddSingleValue(row["cName"].ToString(), rIndex, 2);                
                report.AddSingleValue(row["cNameParent"].ToString(), rIndex, 3);
                 if (!(bool)row["isActive"])
                     report.SetCellColor(rIndex, 1, rIndex, cIndex, panel1.BackColor);

                report.SetBorders(rIndex, 1, rIndex, cIndex);
                report.SetCellAlignmentToCenter(rIndex, 1, rIndex, cIndex);
                rIndex++;
            }

            report.Merge(rIndex, 2, rIndex, 5);
            report.SetCellColor(rIndex, 1, rIndex, 1, panel1.BackColor);
            report.AddSingleValue("- не действующие", rIndex, 2);
            rIndex++;

            report.SetColumnAutoSize(1, 1, rIndex, 5);
            report.Show();
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow != null && dgvData.CurrentRow.Index != -1 && dtData != null && dtData.DefaultView.Count != 0)
            {
                int id = (int)dtData.DefaultView[dgvData.CurrentRow.Index]["id"];
                int id_dep = (int)dtData.DefaultView[dgvData.CurrentRow.Index]["id_Departments"];
                if (DialogResult.OK == new frmAddCategory() { id = id, Text = "Редактировать категорию", id_dep = id_dep }.ShowDialog())
                {
                    get_data();
                    isEdited = true;
                }
            }
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            //id отдела!!!!!!!!!!!!!!!!!!!!!!!!!!!
            int id_dep = (int)cmbDeps.SelectedValue;
            if (DialogResult.OK == new frmAddCategory() { id = 0, Text = "Добавить категорию", id_dep = id_dep  }.ShowDialog())
            {
                get_data();
                isEdited = true;
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btDel_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow != null && dgvData.CurrentRow.Index != -1 && dtData != null && dtData.DefaultView.Count != 0)
            {
                int id = (int)dtData.DefaultView[dgvData.CurrentRow.Index]["id"];
                bool isActive = (bool)dtData.DefaultView[dgvData.CurrentRow.Index]["isActive"];

                Task<DataTable> task = Config.hCntMain.validateDicCategory(id);
                task.Wait();

                if (task.Result == null)
                {
                    MessageBox.Show(Config.centralText("При сохранение данных возникли ошибки записи.\nОбратитесь в ОЭЭС\n"), "Сохранение данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int result = (int)task.Result.Rows[0]["id"];

                if (result == -1)
                {
                    MessageBox.Show(Config.centralText("Запись уже удалена другим пользователем\n"), "Удаление записи", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    get_data();
                    isEdited = true;
                    return;
                }


                if (result == -2 && isActive)
                {
                    if (DialogResult.Yes == MessageBox.Show(Config.centralText("Выбранная для удаления запись используется в программе.\nСделать запись недействующей?\n"), "Удаление записи", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                    {
                        setLog(id, 1520);
                        task = Config.hCntMain.delDicCategory(id, !isActive, result);
                        task.Wait();
                        if (task.Result == null)
                        {
                            MessageBox.Show(Config.centralText("При сохранение данных возникли ошибки записи.\nОбратитесь в ОЭЭС\n"), "Сохранение данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        get_data();
                        isEdited = true;
                        return;
                    }
                }
                else
                if (result == 0 && isActive)
                {
                    if (DialogResult.Yes == MessageBox.Show("Удалить выбранную запись?", "Удаление записи", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                    {
                        setLog(id, 1519);
                        task = Config.hCntMain.delDicCategory(id, !isActive, result);
                        task.Wait();
                        if (task.Result == null)
                        {
                            MessageBox.Show(Config.centralText("При сохранение данных возникли ошибки записи.\nОбратитесь в ОЭЭС\n"), "Сохранение данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        get_data();
                        isEdited = true;
                        return;
                    }
                }
                else if (!isActive)
                {
                    if (DialogResult.Yes == MessageBox.Show("Сделать выбранную запись действующей?", "Восстановление записи", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                    {
                        setLog(id, 1521);
                        task = Config.hCntMain.delDicCategory(id, !isActive, result);
                        task.Wait();
                        if (task.Result == null)
                        {
                            MessageBox.Show(Config.centralText("При сохранение данных возникли ошибки записи.\nОбратитесь в ОЭЭС\n"), "Сохранение данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        get_data();
                        isEdited = true;
                        return;
                    }
                }
            }
        }

        private void setLog(int id, int id_log)
        {
            Task<DataTable> task = Config.hCntMain.getDicCategory(id);
            task.Wait();
            DataTable dtTemp = task.Result;

            if (dtTemp != null && dtTemp.Rows.Count > 0)
            {

                Logging.StartFirstLevel(id_log);
                switch (id_log)
                {
                    case 1519: Logging.Comment("Удаление категории"); break;
                    case 1520: Logging.Comment("Категория переведена в недействующие в справочнике категорий"); break;
                    case 1521: Logging.Comment("Категория переведена в действующие в справочнике категорий"); break;
                    default: break;
                }

                Logging.Comment($"ID:{id}");
                Logging.Comment($"Наименование категории: {dtTemp.Rows[0]["cName"]}");
                Logging.Comment($"Отдел категории id:{dtTemp.Rows[0]["id_Departments"].ToString()}; Наименование:{dtTemp.Rows[0]["nameDep"]}");

                if (dtTemp.Rows[0]["nameDep"] != DBNull.Value)
                    Logging.Comment($"Родительская категория id:{dtTemp.Rows[0]["id_ParentCategory"].ToString()}; Наименование:{dtTemp.Rows[0]["cNameParent"].ToString()}");
             
                Logging.StopFirstLevel();
            }

        }

        private void cmbDeps_SelectionChangeCommitted(object sender, EventArgs e)
        {
            setFilter();
        }
    }
}
