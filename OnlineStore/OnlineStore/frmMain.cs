using Nwuram.Framework.Settings.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineStore
{
    public partial class frmMain : Form
    {
        private DataTable dtData;

        public frmMain()
        {
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Task.Run(() => { init_combobox(true); get_data(); });
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = MessageBox.Show(Config.centralText("Вы действительно хотите выйти\nиз программы?\n"), "Выход из программы", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No;
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void категорийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new dictonaryCategory.frmListCategory().ShowDialog();
        }

        private void init_combobox(bool isAll)
        {
            DoOnUIThread(delegate () { this.Enabled = false; });

            Task<DataTable> task;
            if (isAll)
            {
                task = Config.hCntMain.getDeps();
                task.Wait();
                DataTable dtDeps = task.Result;
                DoOnUIThread(delegate ()
                {
                    cmbDeps.DataSource = dtDeps;
                    cmbDeps.DisplayMember = "cName";
                    cmbDeps.ValueMember = "id";
                    if (UserSettings.User.StatusCode.ToLower().Equals("ркв"))
                    {
                        cmbDeps.SelectedValue = UserSettings.User.IdDepartment;
                        cmbDeps.Enabled = false;
                    }
                });
            }

            int id_otdel = -1;
            DoOnUIThread(delegate ()
            {
                id_otdel = (int)cmbDeps.SelectedValue;
            });

            task = Config.hCntMain.getDicCategoryWithDep(id_otdel);
            task.Wait();
            DataTable dtCategory = task.Result;
            task = null;

            if (dtCategory != null && dtCategory.Rows.Count > 0)
            {
                DataRow row = dtCategory.NewRow();
                row["id"] = 0;
                row["cName"] = "";
                row["isActive"] = 1;
                dtCategory.Rows.Add(row);

                dtCategory.DefaultView.RowFilter = "isActive = 1";
                dtCategory.DefaultView.Sort = "id ASC";
            }
            DoOnUIThread(delegate ()
            {
                cmbParentCategory.DataSource = dtCategory;
                cmbParentCategory.DisplayMember = "cName";
                cmbParentCategory.ValueMember = "id";
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
            
            DoOnUIThread(delegate () { this.Enabled = true; });
        }

        private void cmbDeps_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Task.Run(() => { init_combobox(false); get_data(); });
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

        private void dgvData_Paint(object sender, PaintEventArgs e)
        {
            tbName.Location = new Point(dgvData.Location.X+cId_tovar.Width+cEan.Width, tbName.Location.Y);
            tbName.Size = new Size(cName.Width, tbName.Height);
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            if (new dictonatyTovar.frmAddTovar() { Text = "Добавление товара", id = 0 }.ShowDialog() == DialogResult.OK)
                return;
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

        private void btEdit_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow != null && dgvData.CurrentRow.Index != -1 && dtData != null && dtData.DefaultView.Count != 0)
            {
                int id = (int)dtData.DefaultView[dgvData.CurrentRow.Index]["id"];
                if (DialogResult.OK == new dictonatyTovar.frmAddTovar() { id = id, row = dtData.DefaultView[dgvData.CurrentRow.Index], Text = "Редактирование товара" }.ShowDialog())
                    get_data();
            }
        }

        #region "Получение данных"
        private void DoOnUIThread(MethodInvoker d)
        {
            if (this.InvokeRequired) { this.Invoke(d); } else { d(); }
        }

        private void get_data()
        {
            DoOnUIThread(delegate () { this.Enabled = false; });

            int id_otdel = 0;
            DoOnUIThread(delegate ()
            {
                id_otdel = (int)cmbDeps.SelectedValue;
            });

            Task<DataTable> task = Config.hCntMain.getListGoods(id_otdel);
            task.Wait();
            dtData = task.Result;
            setFilter();
            DoOnUIThread(delegate ()
            {
                dgvData.DataSource = dtData;
            });

            DoOnUIThread(delegate () { this.Enabled = true; });
        }

        private void setFilter()
        {
            DoOnUIThread(delegate ()
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
                        filter += (filter.Length == 0 ? "" : " and ") + string.Format("ShortName like '%{0}%'", tbName.Text.Trim());

                    if (!chbUnable.Checked)
                        filter += (filter.Length == 0 ? "" : " and ") + string.Format("isActive = 1", "");

                    if (cmbTU.SelectedValue != null && (int)cmbTU.SelectedValue != 0)
                        filter += (filter.Length == 0 ? "" : " and ") + $"id_grp1 = {cmbTU.SelectedValue}";

                    if (cmbInv.SelectedValue != null && (int)cmbInv.SelectedValue != 0)
                        filter += (filter.Length == 0 ? "" : " and ") + $"id_grp2 = {cmbInv.SelectedValue}";

                    if (cmbParentCategory.SelectedValue != null && (int)cmbParentCategory.SelectedValue != 0)
                        filter += (filter.Length == 0 ? "" : " and ") + $"id_Category = {cmbParentCategory.SelectedValue}";


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
                    dgvData_SelectionChanged(null, null);
                }
            });
        }
        #endregion

        private void cmbParentCategory_SelectionChangeCommitted(object sender, EventArgs e)
        {
            setFilter();
        }

        private void chbUnable_CheckedChanged(object sender, EventArgs e)
        {
            setFilter();
        }

        private void btDel_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow != null && dgvData.CurrentRow.Index != -1 && dtData != null && dtData.DefaultView.Count != 0)
            {
                int id = (int)dtData.DefaultView[dgvData.CurrentRow.Index]["id"];
                bool isActive = (bool)dtData.DefaultView[dgvData.CurrentRow.Index]["isActive"];

                Task<DataTable> task = Config.hCntMain.validateDicGoods(id);
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
                    return;
                }
                result = -2;

                if (result == -2 && isActive)
                {
                    if (DialogResult.Yes == MessageBox.Show(Config.centralText("Выбранная для удаления запись используется в программе.\nСделать запись недействующей?\n"), "Удаление записи", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                    {
                        //setLog(id, 1520);
                        task = Config.hCntMain.delDicGoods(id, !isActive, result);
                        task.Wait();
                        if (task.Result == null)
                        {
                            MessageBox.Show(Config.centralText("При сохранение данных возникли ошибки записи.\nОбратитесь в ОЭЭС\n"), "Сохранение данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        Task.Run(()=>get_data());
                        return;
                    }
                }
                //else if (result == 0 && isActive)
                //{
                //    if (DialogResult.Yes == MessageBox.Show("Удалить выбранную запись?", "Удаление записи", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                //    {
                //        //setLog(id, 1519);
                //        task = Config.hCntMain.delDicGoods(id, !isActive, result);
                //        task.Wait();
                //        if (task.Result == null)
                //        {
                //            MessageBox.Show(Config.centralText("При сохранение данных возникли ошибки записи.\nОбратитесь в ОЭЭС\n"), "Сохранение данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //            return;
                //        }
                //        get_data();
                //        return;
                //    }
                //}
                else if (!isActive)
                {
                    if (DialogResult.Yes == MessageBox.Show("Сделать выбранную запись действующей?", "Восстановление записи", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                    {
                        //setLog(id, 1521);
                        task = Config.hCntMain.delDicGoods(id, !isActive, result);
                        task.Wait();
                        if (task.Result == null)
                        {
                            MessageBox.Show(Config.centralText("При сохранение данных возникли ошибки записи.\nОбратитесь в ОЭЭС\n"), "Сохранение данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        Task.Run(() => get_data());
                        return;
                    }
                }
            }
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            Task.Run(() => get_data());
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            setFilter();
        }

        private void btPrint_Click(object sender, EventArgs e)
        {

        }
    }
}
