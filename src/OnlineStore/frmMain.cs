﻿using Nwuram.Framework.Logging;
using Nwuram.Framework.Settings.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OnlineStoreViewOrders;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Net;
using System.Diagnostics;

namespace OnlineStore
{
    public partial class frmMain : Form
    {
        private DataTable dtData;
        FolderBrowserDialog folderBrowserDialog1;

        //возврат сортировки после обновления
        private string columnFilter;
        private Dictionary<bool, string> dSort = new Dictionary<bool, string>() { { true, " asc" }, { false, " desc" } };
        private bool typeSort = true;
        private Point currentRow;


        public frmMain()
        {
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            ToolTip ttButton = new ToolTip();
            ttButton.SetToolTip(btAdd, "Добавить");
            ttButton.SetToolTip(btDel, "Удалить");
            ttButton.SetToolTip(btEdit, "Изменить");
            ttButton.SetToolTip(btPrint, "Печать");
            ttButton.SetToolTip(btUpdate, "Обновить");
            ttButton.SetToolTip(btnViewOrders, "Работа с заказами");
            ttButton.SetToolTip(btChangePrice, "Обновить цены");
            ttButton.SetToolTip(btnAddTovars, "Добавить товары");
            ttButton.SetToolTip(btnEditAttribute, "Редактировать атрибуты");
            ttButton.SetToolTip(btViewImage, "Просмотр картинки");

            tsLabel.Text = Nwuram.Framework.Settings.Connection.ConnectionSettings.GetServer() + " " +
                Nwuram.Framework.Settings.Connection.ConnectionSettings.GetDatabase();
            this.Text = Nwuram.Framework.Settings.Connection.ConnectionSettings.ProgramName + " - " + Nwuram.Framework.Settings.User.UserSettings.User.FullUsername;
            this.folderBrowserDialog1 = new FolderBrowserDialog();
            this.folderBrowserDialog1.Description = "Выберите каталог, для сохранения файлов CSV.";

            // Do not allow the user to create new files via the FolderBrowserDialog.
            this.folderBrowserDialog1.ShowNewFolderButton = true;

            // Default to the My Documents folder.
            this.folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;

            if (UserSettings.User.StatusCode == "РКВ") настройкаВремениДатыДоставкиToolStripMenuItem.Visible = настройкиПроцентовToolStripMenuItem.Visible = false;
            if (UserSettings.User.StatusCode.ToLower() == "пр")
                setEnabledPR();

            if (new List<string>() { "ДЗ" }.Contains(UserSettings.User.StatusCode))
            {
                справочникToolStripMenuItem.Visible =
                    формированиеCSVToolStripMenuItem.Visible =
                    сравнениеНаименованийТоваровToolStripMenuItem.Visible =
                    Settings.Visible = false;

                gbPriceChange.Visible = false;
                btnViewOrders.Visible =
                    btnEditAttribute.Visible =
                    btnAddTovars.Visible = false;
                   // btAdd.Visible =
                    //btEdit.Visible =
                   // btDel.Visible = false;


            }
            Task.Run(() => { init_combobox(true); get_data(); });

        }

        private void setEnabledPR()
        {
            gbPriceChange.Enabled = btDel.Enabled = btAdd.Enabled = btEdit.Enabled = btnAddTovars.Enabled = btnEditAttribute.Enabled =
               menuStrip1.Enabled = false;
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
            dictonaryCategory.frmListCategory frm = new dictonaryCategory.frmListCategory();
            frm.ShowDialog();

            //new dictonaryCategory.frmListCategory().ShowDialog();
            init_combo_category();
            if (frm.isEdited)
                get_data();
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
                });
            }

            int id_otdel = -1;
            DoOnUIThread(delegate ()
            {
                id_otdel = (int)cmbDeps.SelectedValue;
            });

            init_combo_category();

            DoOnUIThread(delegate ()
            {
                DataTable dtTypePage = new DataTable();
                dtTypePage.Columns.Add("id", typeof(int));
                dtTypePage.Columns.Add("cName", typeof(string));
                dtTypePage.Rows.Add(0, "Все");
                dtTypePage.Rows.Add(1, "Новые");
                dtTypePage.Rows.Add(2, "На сайте");
                cmbGoodOnPage.DataSource = dtTypePage;
                cmbGoodOnPage.ValueMember = "id";
                cmbGoodOnPage.DisplayMember = "cName";


                DataTable dtTypeImage = new DataTable();
                dtTypeImage.Columns.Add("id", typeof(int));
                dtTypeImage.Columns.Add("cName", typeof(string));
                dtTypeImage.Rows.Add(0, "Все");
                dtTypeImage.Rows.Add(1, "С картинками");
                dtTypeImage.Rows.Add(2, "Без картинок");
                cmbImageOnPage.DataSource = dtTypeImage;
                cmbImageOnPage.ValueMember = "id";
                cmbImageOnPage.DisplayMember = "cName";

            });

            //task = Config.hCntMain.getDicCategoryWithDep(id_otdel);
            //task.Wait();
            //DataTable dtCategory = task.Result;
            //task = null;

            //if (dtCategory != null && dtCategory.Rows.Count > 0)
            //{
            //    DataRow row = dtCategory.NewRow();
            //    row["id"] = 0;
            //    row["cName"] = "";
            //    row["isActive"] = 1;
            //    dtCategory.Rows.Add(row);

            //    dtCategory.DefaultView.RowFilter = "isActive = 1";
            //    dtCategory.DefaultView.Sort = "id ASC";
            //}

            //DoOnUIThread(delegate ()
            //{
            //    cmbParentCategory.DataSource = dtCategory;
            //    cmbParentCategory.DisplayMember = "cName";
            //    cmbParentCategory.ValueMember = "id";
            //});

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

        private void init_combo_category()
        {
            Task<DataTable> task;
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
                row["isParent"] = 0;

                dtCategory.Rows.InsertAt(row, 0);
                dtCategory.DefaultView.RowFilter = "isActive = 1 and isParent = 0";
                //dtCategory.DefaultView.Sort = "id ASC";
            }

            DoOnUIThread(delegate ()
            {
                cmbParentCategory.DataSource = dtCategory;
                cmbParentCategory.DisplayMember = "cName";
                cmbParentCategory.ValueMember = "id";
            });
        }

        private void cmbDeps_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Task.Run(() => { init_combobox(false); });

            cmbParentCategory.SelectedIndex = 0;
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

        private void dgvData_Paint(object sender, PaintEventArgs e)
        {
            tbName.Location = new Point(dgvData.Location.X + cId_tovar.Width + cEan.Width, tbName.Location.Y);
            tbName.Size = new Size(cName.Width, tbName.Height);

            //Место для остатков
            tbStock.Location = new Point(tbName.Location.X + cName.Width + cNameCategory.Width + cCountOnline.Width + сMoveNow.Width, tbStock.Location.Y);
            tbStock.Size = new Size(cOstNow.Width, tbStock.Height);

            lblStock.Location = new Point(tbStock.Location.X - 160, lblStock.Location.Y);

            //место для ean
            tbEan.Location = new Point(dgvData.Location.X + cId_tovar.Width, tbEan.Location.Y);
            tbEan.Size = new Size(cEan.Width - 3, tbEan.Height);

        }

        private async void btAdd_Click(object sender, EventArgs e)
        {
            if (new List<string>() { "ДЗ" }.Contains(UserSettings.User.StatusCode))
            {
                if (dgvData.CurrentRow != null && dgvData.CurrentRow.Index != -1 && dtData != null && dtData.DefaultView.Count != 0)
                {
                    selectFile();
                    return;
                }

            }
            else
            {
                if (new dictonatyTovar.frmAddTovar() { Text = "Добавление товара", id = 0 }.ShowDialog() == DialogResult.OK)
                    Task.Run(() => get_data());
            }
        }

        private void dgvData_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex != -1 && dtData != null && dtData.DefaultView.Count != 0)
            {
                Color rColor = Color.White;
                if (!(bool)dtData.DefaultView[e.RowIndex]["isActive"])
                    rColor = panel1.BackColor;
                //else if ((bool)dtData.DefaultView[e.RowIndex]["isSelect"] )
                //   rColor = Color.FromArgb(153, 217, 234);
                else if (dtData.DefaultView[e.RowIndex]["rcenaOnline"].ToString() != (Math.Truncate(((decimal)dtData.DefaultView[e.RowIndex]["rcena"] * (100 + (decimal)dtData.DefaultView[e.RowIndex]["MarkUpPercent"]) / 100) * 100) / 100).ToString("0.00"))
                    rColor = panel2.BackColor;
                if ((bool)dtData.DefaultView[e.RowIndex]["isSelect"])
                    rColor = Color.FromArgb(153, 217, 234);



                dgvData.Rows[e.RowIndex].DefaultCellStyle.BackColor = rColor;
                dgvData.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = rColor;
                dgvData.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;

                if ((bool)dtData.DefaultView[e.RowIndex]["isSelect"] && dtData.DefaultView[e.RowIndex]["rcenaOnline"].ToString() != (Math.Truncate(((decimal)dtData.DefaultView[e.RowIndex]["rcena"] * (100 + (decimal)dtData.DefaultView[e.RowIndex]["MarkUpPercent"]) / 100) * 100) / 100).ToString("0.00"))
                {

                    dgvData.Rows[e.RowIndex].Cells["cRcenaOnline"].Style.BackColor =
                        dgvData.Rows[e.RowIndex].Cells["cRcenaOnline"].Style.SelectionBackColor = panel2.BackColor;
                }
                if (dtData.DefaultView[e.RowIndex]["isInsert"].ToString() == "0")
                {
                    dgvData.Rows[e.RowIndex].Cells["cName"].Style.BackColor =
                        dgvData.Rows[e.RowIndex].Cells["cName"].Style.SelectionBackColor = panel3.BackColor;
                }
                if (dtData.DefaultView[e.RowIndex]["rcenaPromo_str"].ToString().Length > 0)
                {
                    dgvData.Rows[e.RowIndex].Cells["cRcenaOnlineAction"].Style.BackColor =
                        dgvData.Rows[e.RowIndex].Cells["cRcenaOnlineAction"].Style.SelectionBackColor = panel4.BackColor;
                }
                if (dtData.Columns.Contains("isPicture"))
                    if (dtData.DefaultView[e.RowIndex]["isPicture"] != DBNull.Value)
                        if (!(bool)dtData.DefaultView[e.RowIndex]["isPicture"])
                        {
                            dgvData.Rows[e.RowIndex].Cells["cEan"].Style.BackColor =
                       dgvData.Rows[e.RowIndex].Cells["cEan"].Style.SelectionBackColor = panel5.BackColor;
                        }
                        else
                        {
                            dgvData.Rows[e.RowIndex].Cells["cEan"].Style.BackColor =
                       dgvData.Rows[e.RowIndex].Cells["cEan"].Style.SelectionBackColor = rColor;
                        }


                //if ((bool)dtData.DefaultView[e.RowIndex]["isSelect"])
                //    dgvData.Rows[e.RowIndex].Cells[cId_tovar.Index].Style.BackColor =
                //         dgvData.Rows[e.RowIndex].Cells[cId_tovar.Index].Style.SelectionBackColor = Color.Blue;
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
                btAdd.Enabled = !new List<string>() { "ДЗ" }.Contains(UserSettings.User.StatusCode);
                btViewImage.Enabled = false;
                return;
            }

            if (new List<string>() { "ДЗ" }.Contains(UserSettings.User.StatusCode))
            {

                btDel.Enabled = (bool)dtData.DefaultView[dgvData.CurrentRow.Index]["isPicture"];
                btEdit.Enabled = (bool)dtData.DefaultView[dgvData.CurrentRow.Index]["isPicture"];
                btAdd.Enabled = !(bool)dtData.DefaultView[dgvData.CurrentRow.Index]["isPicture"];
                btViewImage.Enabled = (bool)dtData.DefaultView[dgvData.CurrentRow.Index]["isPicture"];
            }
            else
            {
                btDel.Enabled = true && (UserSettings.User.StatusCode.ToLower() != "пр");
                btEdit.Enabled = (bool)dtData.DefaultView[dgvData.CurrentRow.Index]["isActive"] && (UserSettings.User.StatusCode.ToLower() != "пр");
                btViewImage.Enabled = (bool)dtData.DefaultView[dgvData.CurrentRow.Index]["isPicture"];
                if (dgvData.CurrentCellAddress != new Point(0, 0))
                    currentRow = dgvData.CurrentCellAddress;
            }
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtData != null && dtData.Rows.Count > 0 && dtData.DefaultView.Count > 0 && e.RowIndex != -1)
            {

                dtData.DefaultView[e.RowIndex]["isSelect"] = !(bool)dtData.DefaultView[e.RowIndex]["isSelect"];
                // dtData.AcceptChanges();

            }
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow != null && dgvData.CurrentRow.Index != -1 && dtData != null && dtData.DefaultView.Count != 0)
            {
                int id = (int)dtData.DefaultView[dgvData.CurrentRow.Index]["id"];
                string ean = (string)dtData.DefaultView[dgvData.CurrentRow.Index]["ean"];

                if (new List<string>() { "ДЗ" }.Contains(UserSettings.User.StatusCode))
                {
                    selectFile();
                    return;
                }
                else if (DialogResult.OK == new dictonatyTovar.frmAddTovar() { id = id, row = dtData.DefaultView[dgvData.SelectedRows[0].Index], Text = "Редактирование товара" }.ShowDialog())
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

            Task<DataTable> task = (UserSettings.User.StatusCode == "РКВ" ? Config.hCntMain.getListGoods(id_otdel) : Config.hCntMain.getListGoods(0));
            task.Wait();
            dtData = task.Result;
            dtData.Columns.Add("BasicPricePrecent", typeof(decimal));
            foreach (DataRow dr in dtData.Rows)
            {
                dr["BasicPricePrecent"] = (Math.Truncate(((decimal)dr["rcena"] * (100 + (decimal)dr["MarkUpPercent"]) / 100) * 100) / 100).ToString("0.00");
            }

            setFilter();
            DoOnUIThread(delegate ()
            {
                if (columnFilter != null)
                {
                    dtData.DefaultView.Sort = columnFilter + dSort[typeSort];
                    //dtData = dtData.DefaultView.ToTable();
                }
                dgvData.DataSource = dtData;

                /*  if (currentRow != null)
                  {
                      if (dtData.DefaultView.Count > 0)
                          dgvData.Rows[0].Selected = false;
                      if (currentRow.Y < dtData.DefaultView.Count)
                          dgvData.Rows[currentRow.Y].Selected = true;

                  }*/
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
                        //filter += (filter.Length == 0 ? "" : " and ") + $"id_Category = {cmbParentCategory.SelectedValue}";
                        filter += (filter.Length == 0 ? "" : " and ") + $"id_Category like '%,{cmbParentCategory.SelectedValue},%'";

                    if (cmbDeps.SelectedValue != null && (int)cmbDeps.SelectedValue != 0)
                        filter += (filter.Length == 0 ? "" : " and ") + $"id_otdel = {cmbDeps.SelectedValue}";
                    int stock;
                    if (tbStock.Text.Trim().Length > 0)
                    {
                        if (int.TryParse(tbStock.Text, out stock))
                            filter += (filter.Length == 0 ? "" : " and ") + $"ostNow >= {stock}";
                    }
                    if (tbEan.Text.Length > 0)
                    {
                        //Int64 ean;
                        //if (Int64.TryParse(tbEan.Text, out ean))
                        filter += (filter.Length == 0 ? "" : " and ") + $"ean like '%{tbEan.Text.Trim()}%'";
                    }
                    if (chckPrice.Checked)
                    {
                        filter += (filter.Length == 0 ? "" : " and ") + $"basicPricePrecent <> rcenaOnline";
                    }

                    if ((int)cmbGoodOnPage.SelectedValue != 0) filter += (filter.Length == 0 ? "" : " and ") + $"isInsert = {((int)cmbGoodOnPage.SelectedValue == 1 ? 0 : 1)}";
                    if ((int)cmbImageOnPage.SelectedValue != 0) filter += (filter.Length == 0 ? "" : " and ") + $"isPicture = {((int)cmbImageOnPage.SelectedValue == 1 ? 1 : 0)}";

                    if (chckSale.Checked)
                        filter += (filter.Length == 0 ? "" : " and ") + $"rcenaPromo>0";
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

        private async void btDel_Click(object sender, EventArgs e)
        {
            if (dtData == null || dtData.Rows.Count == 0 || dtData.DefaultView.Count == 0) return;

            if (new List<string>() { "ДЗ" }.Contains(UserSettings.User.StatusCode))
            {
                if (dgvData.CurrentRow != null && dgvData.CurrentRow.Index != -1 && dtData != null && dtData.DefaultView.Count != 0)
                {

                    if (DialogResult.No == MessageBox.Show("Удалить у выбранного товара картинку?", "Удаление картинки у товара", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)) return;
                    remoteDataFtpAndFolder();
                }
                return;
            }
            else
            {
                EnumerableRowCollection<DataRow> rowCollect = dtData.AsEnumerable()
                .Where(r => r.Field<bool>("isSelect"));
                if (rowCollect.Count() != 0)
                {
                    if (MessageBox.Show(Config.centralText("Выбранные товары станут недействующими.\nВы хотите продолжить?\n"), "Неактивные товары", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        return;
                    foreach (DataRow dr in rowCollect)
                    {
                        Task<DataTable> t =
                        Config.hCntMain.delDicGoods((int)dr["id"], false, -2);
                        t.Wait();
                        setLog(1586, dr);
                    }
                    Task.Run(() => get_data());
                    return;
                }

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
                        if (DialogResult.Yes == MessageBox.Show(Config.centralText("Выбранная для удаления запись\nиспользуется в программе.\nСделать запись недействующей?\n"), "Удаление записи", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                        {
                            setLog(1585, dtData.DefaultView[dgvData.CurrentRow.Index].Row);
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
                            decimal rcena = (decimal)dtData.DefaultView[dgvData.CurrentRow.Index]["rcena"];
                            decimal percent = (decimal)dtData.DefaultView[dgvData.CurrentRow.Index]["MarkUpPercent"];
                            decimal pricePercent = (decimal)dtData.DefaultView[dgvData.CurrentRow.Index]["rcenaOnline"];
                            bool? changePrice = null;
                            if (Math.Round(pricePercent, 2) != Math.Truncate((rcena * (100 + percent))) / 100)
                            {
                                if (DialogResult.Yes == MessageBox.Show(Config.centralText("Цена товара изменилась.\nХотите поменять цену на сайте?\n"), "Редактирование товара", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                                    changePrice = true;
                                else changePrice = false;
                            }
                            setLog(1586, dtData.DefaultView[dgvData.CurrentRow.Index].Row, changePrice);
                            task = Config.hCntMain.delDicGoods(id, !isActive, result, changePrice);
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
        }

        private void setLog(int id_log, DataRow dr, bool? isChangePrice = null)
        {
            Logging.StartFirstLevel(id_log);
            string end = "";
            switch (id_log)
            {
                case 1585: Logging.Comment("Перевод товара в недействующие"); end = "недействующие"; break;
                case 1586: Logging.Comment("Перевод товара в действующие"); end = "действующие"; break;
            }

            int id_tovar = (int)dr["id_tovar"];
            string fullname = dr["FullName"].ToString();
            string shortname = dr["ShortName"].ToString();
            string id_category = dr["id_Category"].ToString();
            string name_category = dr["nameCategory"].ToString();
            decimal rcena = (decimal)dr["rcena"];
            decimal rcenaOnline = (decimal)dr["rcenaOnline"];
            string rcenaOld = dr["rcenaPromo"].ToString();
            string minOrder = dr["MinOrder"].ToString();
            string maxOrder = dr["MaxOrder"].ToString();
            string step = dr["Step"].ToString();
            string defaulNetto = dr["DefaultNetto"].ToString();
            string priceSuffix = dr["PriceSuffix"].ToString();
            string quantitySuffix = dr["QuantitySuffix"].ToString();
            Logging.Comment($"id_tovar: {id_tovar}, EAN: {dr["ean"].ToString()}");
            Logging.Comment($"Полное наименование: {fullname}");
            Logging.Comment($"Короткое наименование: {shortname}");
            Logging.Comment($"id_категории: {id_category}, Наименование: {name_category}");
            Logging.Comment($"Цена продажи: {rcena}, Цена на сайте: {rcenaOnline}, Старая цена распродажи: {rcenaOld}");
            if (isChangePrice != null)
                Logging.Comment($"Изменение цены товара: {((bool)isChangePrice ? "ДА" : "НЕТ")}");
            if (dr["ean"].ToString().Length == 4)
            {
                Logging.Comment($"Мин. кол-во заказа: {minOrder}, макс. кол-во заказа: {maxOrder}, шаг: {step}");
                Logging.Comment($"Значение товара по умолчанию: {defaulNetto}");
                Logging.Comment($"Суффикс к цене товара: {priceSuffix}, суффикс к кол-ву товара: {quantitySuffix}");
            }
            Logging.Comment($"Завершение перевода товара в {end}");
            Logging.StopFirstLevel();
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

            Logging.StartFirstLevel(79);

            Logging.Comment("Выгрузка отчёта с главной формы");
            if (!string.IsNullOrWhiteSpace(tbName.Text))
                Logging.Comment($"Фильтр по наименованию товара: {tbName.Text}");
            Logging.StopFirstLevel();

            Nwuram.Framework.ToExcelNew.ExcelUnLoad report = new Nwuram.Framework.ToExcelNew.ExcelUnLoad("list-1");

            int rIndex = 1;
            int maxMerge = 0;
            foreach (DataGridViewColumn col in dgvData.Columns)
                if (col.Visible)
                    maxMerge++;

            report.Merge(rIndex, 1, rIndex, maxMerge);
            report.AddSingleValue("Список товаров", rIndex, 1);
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
            report.SetWrapText(rIndex, 1, rIndex, cIndex);
            rIndex++;

            foreach (DataRowView row in dtData.DefaultView)
            {
                cIndex = 0;
                foreach (DataGridViewColumn col in dgvData.Columns)
                    if (col.Visible)
                    {
                        cIndex++;
                        report.AddSingleValue(row[col.DataPropertyName].ToString(), rIndex, cIndex);
                    }

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

            report.SetColumnAutoSize(1, 1, rIndex, maxMerge);
            report.Show();
        }

        private void отображаемыеНаФормеТоварыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dtData == null || dtData.Rows.Count == 0 || dtData.DefaultView.Count == 0)
            {
                MessageBox.Show("Нет данных для отчета", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataTable dtLoad = dtData.DefaultView.ToTable();
            dtLoad.DefaultView.RowFilter = " isUnload=1";

            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string folderName = folderBrowserDialog1.SelectedPath;
                CheckNtypetovars(dtLoad.DefaultView.ToTable());
                TableToCsv tableToCsv = new TableToCsv();
                try
                {
                    tableToCsv.insertData(dtLoad.DefaultView.ToTable().Copy(), folderName, true);
                    MessageBox.Show("Выгрузка завершена!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch
                {
                    MessageBox.Show("Ошибка записи файла", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                #region Логирование
                Logging.StartFirstLevel(981);
                Logging.Comment("Выгрузка в файл CSV товаров с формы");
                Logging.Comment($"Значения фильтров: ean: {tbEan.Text}");
                string strTovars = "Наименования: ";
                foreach (DataRowView dr in dtLoad.DefaultView)
                {
                    strTovars += dr["FullName"].ToString();
                }
                Logging.Comment(strTovars);
                strTovars = "Короткое описание: ";
                foreach (DataRowView dr in dtLoad.DefaultView)
                    strTovars += dr["ShortDescription"].ToString();
                Logging.Comment(strTovars);
                if (Config.ImageTovar)
                    Logging.Comment("С картинкой по товару");
                else
                    Logging.Comment("Без картинки");
                Logging.Comment($"Размер файла: {Config.sizeCSV}");
                Logging.Comment($"Завершение выгрузки товаров с формы");
                Logging.StopFirstLevel();
                #endregion

            }
        }

        private void выгрузитьИзмененныеТоварыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dtData == null || dtData.Rows.Count == 0 || dtData.DefaultView.Count == 0) return;

            if (DialogResult.OK == new frmSelectData().ShowDialog())
            {
                DateTime dateSelect = frmSelectData.date;
                EnumerableRowCollection<DataRow> rowCollect = dtData.AsEnumerable()
               .Where(r => r.Field<DateTime>("DateEdit").Date >= dateSelect.Date && r.Field<bool>("isActive") && r.Field<bool>("isUnload") == true);

                if (rowCollect.Count() > 0)
                {
                    DialogResult result = folderBrowserDialog1.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        string folderName = folderBrowserDialog1.SelectedPath;
                        CheckNtypetovars(rowCollect.CopyToDataTable());
                        TableToCsv tableToCsv = new TableToCsv();
                        try
                        {
                            tableToCsv.insertData(rowCollect.CopyToDataTable(), folderName);
                            MessageBox.Show("Выгрузка завершена!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch
                        {
                            MessageBox.Show("Ошибка записи файла", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        #region логирование
                        Logging.StartFirstLevel(981);
                        Logging.Comment("Выгрузка в файл CSV измененных товаров");
                        Logging.Comment($"Дата начала выборки: {dateSelect.ToShortDateString()}");
                        string strTovars = "Короткое описание: ";
                        foreach (DataRow dr in rowCollect)
                            strTovars += dr["ShortDescription"].ToString();
                        Logging.Comment(strTovars);
                        if (Config.ImageTovar)
                            Logging.Comment("С картинкой по товару");
                        else
                            Logging.Comment("Без картинки");
                        Logging.Comment($"Размер файла: {Config.sizeCSV}");
                        Logging.Comment($"Завершение выгрузки товаров с формы");
                        Logging.StopFirstLevel();
                        #endregion


                    }
                }
                else
                {
                    MessageBox.Show("Нет данных для отчета", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }



            }

        }

        private void выгрузитьВыбранныеТоварыВФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dtData == null || dtData.Rows.Count == 0 || dtData.DefaultView.Count == 0) return;

            EnumerableRowCollection<DataRow> rowCollect = dtData.AsEnumerable()
                .Where(r => r.Field<bool>("isSelect") && r.Field<bool>("isUnload") == true);

            if (rowCollect.Count() > 0)
            {
                DialogResult result = folderBrowserDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string folderName = folderBrowserDialog1.SelectedPath;
                    CheckNtypetovars(rowCollect.CopyToDataTable());
                    TableToCsv tableToCsv = new TableToCsv();
                    try
                    {
                        tableToCsv.insertData(rowCollect.CopyToDataTable(), folderName, true);
                        MessageBox.Show("Выгрузка завершена!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка записи файла", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    #region логирование
                    Logging.StartFirstLevel(981);
                    Logging.Comment("Выгрузка в файл CSV выбранных товаров");
                    string strTovars = "Товары: ";
                    foreach (DataRow dr in rowCollect)
                    {
                        strTovars += $"id товара: {dr["id_Tovar"].ToString()}, ean: {dr["ean"].ToString()}, Наименование: {dr["FullName"].ToString()}, Короткое описание: " +
                            $"{dr["ShortDescription"].ToString()};";
                        dr["isSelect"] = false;
                    }

                    Logging.Comment(strTovars);
                    if (Config.ImageTovar)
                        Logging.Comment("С картинкой по товару");
                    else
                        Logging.Comment("Без картинки");
                    Logging.Comment($"Размер файла: {Config.sizeCSV}");
                    Logging.Comment($"Завершение выгрузки товаров с формы");
                    Logging.StopFirstLevel();
                    #endregion
                }
            }
            else
            {
                MessageBox.Show("Нет данных для отчета", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void выгрузитьВсеДоступныеТоварыВФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Task<DataTable> task = Config.hCntMain.getListGoods(0);
            task.Wait();
            DataTable dtLoad = task.Result;
            dtLoad.DefaultView.RowFilter = " isUnload=1 ";
            if (dtLoad != null && dtLoad.Rows.Count > 0)
            {
                DialogResult result = folderBrowserDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string folderName = folderBrowserDialog1.SelectedPath;
                    CheckNtypetovars(dtLoad.DefaultView.ToTable());
                    TableToCsv tableToCsv = new TableToCsv();
                    try
                    {
                        tableToCsv.insertData(dtLoad.DefaultView.ToTable(), folderName, true);
                        MessageBox.Show("Выгрузка завершена!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка записи файла", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    #region логирование
                    Logging.StartFirstLevel(981);
                    Logging.Comment("Выгрузка в файл CSV всех доступных товаров");
                    string strTovars = "Короткое описание: ";
                    foreach (DataRowView dr in dtLoad.DefaultView)
                        strTovars += dr["ShortDescription"].ToString();
                    Logging.Comment(strTovars);
                    if (Config.ImageTovar)
                        Logging.Comment("С картинкой по товару");
                    else
                        Logging.Comment("Без картинки");
                    Logging.Comment($"Размер файла: {Config.sizeCSV}");
                    Logging.Comment($"Завершение выгрузки товаров с формы");
                    Logging.StopFirstLevel();
                    #endregion

                }
            }
            else
            {
                MessageBox.Show("Нет данных для отчета", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CheckNtypetovars(DataTable dtTovars)
        {
            EnumerableRowCollection<DataRow> rowCollect = dtTovars.AsEnumerable().Where(r => (r.Field<int>("ntypetovar") == 1 || r.Field<int>("ntypetovar") == 3) && r.Field<decimal>("ostNow") > 0);
            if (rowCollect.Count() > 0)
                MessageBox.Show(Config.centralText("Среди товаров присутствуют товары\n\"Резерв\" или \"Резерв-Уценка\"\nс положительным остатком\n"), "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            // frmSettings settings = new frmSettings();
            // settings.ShowDialog();
        }

        private void tbStock_TextChanged(object sender, EventArgs e)
        {
            setFilter();
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                if (columnFilter != dgvData.Columns[e.ColumnIndex].DataPropertyName)
                {
                    columnFilter = dgvData.Columns[e.ColumnIndex].DataPropertyName;
                    typeSort = true;
                }
                else
                {
                    typeSort = false;
                }


            }
            //  Console.WriteLine(dtData.DefaultView[dgvData.CurrentRow.Index]["BasicPricePrecent"].ToString());
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void tbEan_TextChanged(object sender, EventArgs e)
        {
            setFilter();
        }

        private void btnViewOrders_Click(object sender, EventArgs e)
        {
            frmViewOrders frm = new frmViewOrders();
            frm.ShowDialog();
        }

        private void btChangePrice_Click(object sender, EventArgs e)
        {

            if (DialogResult.Yes == MessageBox.Show("Обновить цены?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                if (rbAll.Checked)
                {
                    ChangePriceDepartment();
                    get_data();
                    return;
                }
                if (rbSelected.Checked)
                {
                    EnumerableRowCollection<DataRow> rowCollect = dtData.AsEnumerable()
                        .Where(r => r.Field<bool>("isSelect"));
                    if (rowCollect.Count() > 0)
                    {
                        ChangePrice(rowCollect.CopyToDataTable());
                        get_data();
                    }
                    return;
                }
                if (rbView.Checked)
                {

                    ChangePrice(dtData.DefaultView.ToTable());
                    get_data();
                    return;
                }
            }
        }

        private void ChangePriceDepartment()
        {
            int id_dep = (int)cmbDeps.SelectedValue;
            Task<DataTable> task;
            task = Config.hCntMain.UpdatePrice(id_dep);
            task.Wait();

            #region Логирование
            DataTable drPrec = Config.dtPercents.AsEnumerable().Where(r => r.Field<Int16>("id_Department") == id_dep &&
            r.Field<Int16>("id_Department") > 0).Count() > 0 ? Config.dtPercents.AsEnumerable().Where(r => r.Field<Int16>("id_Department") == id_dep &&
              r.Field<Int16>("id_Department") > 0).CopyToDataTable() : null;



            Logging.StartFirstLevel(1528);
            Logging.Comment($"Начало обновления цен товаров отдела {cmbDeps.Text}");
            Logging.Comment("Обновление цен для распродажи: " + Config.isSale.ToString());
            foreach (DataRow row in dtData.Rows)
            {
                Logging.Comment("ID: " + row["id_tovar"].ToString() + "; ean: " + row["ean"].ToString() + $", процент наценки: {row["MarkUpPercent"].ToString()}, процент распродажи: {row["SalePercent"].ToString()}");
            }
            Logging.Comment("Окончание обновления цен товаров");
            Logging.StopFirstLevel();

            #endregion
        }

        private void ChangePrice(DataTable dtGoods)
        {

            string id_tovars = "";
            foreach (DataRow row in dtGoods.Rows)
            {
                id_tovars += row["id_tovar"].ToString() + ",";
            }
            Task<DataTable> task;
            task = Config.hCntMain.UpdatePrice(id_tovars);
            task.Wait();

            #region Логирование
            Logging.StartFirstLevel(1528);
            Logging.Comment("Начало обновления цен товаров");
            if (rbAll.Checked)
                Logging.Comment("Обновление всех товаров");
            if (rbSelected.Checked)
                Logging.Comment("Обновление выбранных товаров");
            if (rbView.Checked)
                Logging.Comment("Обновление видимых товаров");
            Logging.Comment("Обновление цен для распродажи: " + Config.isSale.ToString());

            foreach (DataRow row in dtGoods.Rows)
            {
                Logging.Comment("ID: " + row["id_tovar"].ToString() + "; ean: " + row["ean"].ToString() + $", процент наценки: {row["MarkUpPercent"].ToString()}, процент распродажи: {row["SalePercent"].ToString()}");
            }
            Logging.Comment("Окончание обновления цен товаров");
            Logging.StopFirstLevel();
            #endregion

        }
        private void rbAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAll.Checked) btChangePrice.Enabled = true;
        }

        private void rbView_CheckedChanged(object sender, EventArgs e)
        {
            if (rbView.Checked) btChangePrice.Enabled = true;
        }

        private void rbSelected_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSelected.Checked) btChangePrice.Enabled = true;
        }

        private void gbPriceChange_Enter(object sender, EventArgs e)
        {

        }

        private void chckPrice_CheckedChanged(object sender, EventArgs e)
        {
            setFilter();
        }

        private void chckUnloaded_CheckedChanged(object sender, EventArgs e)
        {
            setFilter();
        }

        private void cmbParentCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void настройкиCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSettings settings = new frmSettings();
            settings.ShowDialog();
        }

        private void настройкиПроцентовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPercents frm = new frmPercents();
            frm.ShowDialog();
            if (frm.lChanged)
                get_data();
        }

        private void chckSale_CheckedChanged(object sender, EventArgs e)
        {
            setFilter();
        }

        private void btnAddTovars_Click(object sender, EventArgs e)
        {
            dictonatyTovar.frmAddAllTovar frm = new dictonatyTovar.frmAddAllTovar();
            frm.ShowDialog();
        }

        private void категорийИГруппToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dictonaryCategory.frmListCatVsGrp2 frmList = new dictonaryCategory.frmListCatVsGrp2();
            frmList.ShowDialog();
        }

        private void btnEditAttribute_Click(object sender, EventArgs e)
        {
            dictonatyTovar.frmEditAttribute frm = new dictonatyTovar.frmEditAttribute();
            frm.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void настройкаВремениДатыДоставкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmSettingsTimeDelivery().ShowDialog();
        }

        private void сравнениеНаименованийТоваровToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new validateGoods.frmView() { dtGoods = dtData.Copy() }.ShowDialog();
        }

        private void CmbGoodOnPage_SelectionChangeCommitted(object sender, EventArgs e)
        {
            setFilter();
        }

        private void DgvData_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex != -1)
            {
                DataGridView dgv = (DataGridView)sender;
                dgv.CurrentCell = dgv[e.ColumnIndex, e.RowIndex];
                contextMenuStrip1.Show(MousePosition);
            }
        }

        private void ContextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (!new List<string>() { "ДЗ" }.Contains(UserSettings.User.StatusCode)) { e.Cancel = true; return; }

            DataRowView row = dtData.DefaultView[dgvData.CurrentRow.Index];

            просмотретьИзображениеТовараToolStripMenuItem.Enabled = (bool)row["isPicture"];
        }

        private void BtViewImage_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow != null && dgvData.CurrentRow.Index != -1 && dtData != null && dtData.DefaultView.Count != 0)
            {
                string ean = (string)dtData.DefaultView[dgvData.CurrentRow.Index]["ean"];

                NetworkShare net = new NetworkShare(true);
                Image img = null;
                try
                {
                    byte[] byteImg = net.GetFileBytes($"{ean}.png");
                    if (byteImg == null) return;

                    using (var ms = new MemoryStream(byteImg))
                    {
                        img = Image.FromStream(ms);
                        if (!Directory.Exists(Application.StartupPath + $"\\tmp"))
                            Directory.CreateDirectory(Application.StartupPath + $"\\tmp");

                        string dirFile = Application.StartupPath + $"\\tmp\\{ean}.png";

                        img.Save(dirFile);
                        try
                        {
                            Process.Start(dirFile);
                        }
                        catch
                        {
                            MessageBox.Show(Config.centralText("Программа не может запустить программу\nпросмотра изображения товара изза её отсутствия.\nПросмотр изображения товара невозможно.\nОбратитесь в ОЭЭС.\n"), "Просмотр изображения товара", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                catch
                {

                }
            }
        }

        private void ПросмотретьИзображениеТовараToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BtViewImage_Click(null, null);
        }

        private void СправочникСвязиТоваровСКатегориямиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new dictonaryCategory.frmMultyGoodCategory().ShowDialog();
        }


        private void selectFile()
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.Filters.Add(new CommonFileDialogFilter("PNG Files", "*.png"));

            dialog.IsFolderPicker = false;
            dialog.EnsureFileExists = true;
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                string file = dialog.FileName;
                int id = (int)dtData.DefaultView[dgvData.CurrentRow.Index]["id"];
                string ean = (string)dtData.DefaultView[dgvData.CurrentRow.Index]["ean"];

                if (!validateFileToUpLoad(file, ean)) return;
                if (!uploadFile(file)) return;
                if (!insertDataToDataBase(id)) return;
            }
        }

        private bool validateFileToUpLoad(string folderName,string ean)
        {
            
            List<string> fileHead = new List<string>();

            List<string> jpg = new List<string> { "FF", "D8" };
            List<string> bmp = new List<string> { "42", "4D" };
            List<string> gif = new List<string> { "47", "49", "46" };
            List<string> png = new List<string> { "89", "50", "4E", "47", "0D", "0A", "1A", "0A" };

            using (FileStream stream = File.OpenRead(folderName))
            {
                for (int i = 0; i < 8; i++)
                {
                    string bit = stream.ReadByte().ToString("X2");
                    fileHead.Add(bit);
                }
            }

            if (!ean.Equals(Path.GetFileNameWithoutExtension(folderName)))
            {
                MessageBox.Show(Config.centralText("Имя выбранного файла не соответствует EAN товара.\nДобавление изображения товара невозможно.\n"), "Добавление изображения товара", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (png.Except(fileHead).Any())
            {
                MessageBox.Show(Config.centralText("Выбранный файл не соответствует формату PNG.\nДобавление изображения товара невозможно.\n"), "Добавление изображения товара", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            
            Image image1 = Image.FromFile(folderName);
            int width = 800;
            int height = 800;

            if (image1.Width != width && image1.Height != height)
            {
                MessageBox.Show(Config.centralText($"Выбранный файл не соответствует разрешению {width}x{height}.\nДобавление изображения товара невозможно.\n"), "Добавление изображения товара", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                            
                return false;
            }
            
            return true;
        }

        private bool uploadFile(string folderName)
        {
            DataTable dt = Config.hCntMain.getSettings("ftps").Result;
            string ftpServer = dt.Rows[0]["value"].ToString();

            dt = Config.hCntMain.getSettings("ftpl").Result;
            string ftpUsername = dt.Rows[0]["value"].ToString();

            dt = Config.hCntMain.getSettings("ftpp").Result;
            string ftpPassword = dt.Rows[0]["value"].ToString();

            using (var client = new WebClient())
            {
                client.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
                client.UploadFile($"ftp://{ftpServer}//" + $"{Path.GetFileName(folderName)}", WebRequestMethods.Ftp.UploadFile, folderName);
            }

            //FtpWebRequest request = (FtpWebRequest)WebRequest.Create($"ftp://{ftpServer}/");

            //request.Method = WebRequestMethods.Ftp.ListDirectory;
            //request.Credentials = new NetworkCredential(ftpUsername, ftpPassword);

            //FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            //Console.WriteLine("Содержимое сервера:");
            //Console.WriteLine();

            //Stream responseStream = response.GetResponseStream();
            //StreamReader reader = new StreamReader(responseStream, true);

            //while (!reader.EndOfStream)
            //{
            //    Console.WriteLine(reader.ReadLine());
            //}

            //reader.Close();
            //responseStream.Close();
            //response.Close();

            NetworkShare net = new NetworkShare(true);
            net.CopyFile(folderName);

            return true;                   
        }

        private bool insertDataToDataBase(int id)
        {
            Config.hCntMain.setPictureGood(id, true);
            dtData.DefaultView[dgvData.CurrentRow.Index]["isPicture"] = true;
            dgvData_SelectionChanged(null, null);
            dgvData.Refresh();

            return true;
        }

        private bool remoteDataFtpAndFolder()
        {
            DataTable dt = Config.hCntMain.getSettings("ftps").Result;
            string ftpServer = dt.Rows[0]["value"].ToString();

            dt = Config.hCntMain.getSettings("ftpl").Result;
            string ftpUsername = dt.Rows[0]["value"].ToString();

            dt = Config.hCntMain.getSettings("ftpp").Result;
            string ftpPassword = dt.Rows[0]["value"].ToString();

            int id = (int)dtData.DefaultView[dgvData.CurrentRow.Index]["id"];
            string ean = (string)dtData.DefaultView[dgvData.CurrentRow.Index]["ean"];

            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create($"ftp://{ftpServer}/");
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                request.Credentials = new NetworkCredential(ftpUsername, ftpPassword);

                //request = (FtpWebRequest)WebRequest.Create($"ftp://{ftpServer}//" + $"{Path.GetFileName(folderName)}");
                request = (FtpWebRequest)WebRequest.Create($"ftp://{ftpServer}//" + $"{ean}.png");
                request.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
                request.Method = WebRequestMethods.Ftp.DeleteFile;

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                Console.WriteLine("Delete status: {0}", response.StatusDescription);
                response.Close();
            }
            catch
            {
            }

            NetworkShare net = new NetworkShare(true);
            net.RemoveFile($"{ean}.png");

            Config.hCntMain.setPictureGood(id, false);

            dtData.DefaultView[dgvData.CurrentRow.Index]["isPicture"] = false;
            dgvData_SelectionChanged(null, null);
            dgvData.Refresh();
            return true;
        }

    }
}
