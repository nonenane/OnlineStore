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
using System.Threading;

namespace OnlineStore.dictonatyTovar
{
    public partial class frmAddAllTovar : Form
    {

        DataTable dtDeps;
        DataTable dtGroups;

        public frmAddAllTovar()
        {
            InitializeComponent();
        }

        private void frmAddAllTovar_Load(object sender, EventArgs e)
        {

            ToolTip tt = new ToolTip();
            tt.SetToolTip(btnAdd, "Добавить");
            tt.SetToolTip(btnExit, "Выход");
            dgvGroups.AutoGenerateColumns = false;
            Task.Run(() => { cbDeps_Init(); dgvGroups_Init(); } ) ;
        }

        private void DoOnUIThread(MethodInvoker d)
        {
            if (this.InvokeRequired) { this.Invoke(d); } else { d(); }
        }
        private void dgvGroups_Init()
        {
            int id_otdel = -1;
            DoOnUIThread(delegate ()
            {
                id_otdel = (int)cbDeps.SelectedValue;
            });
            Task<DataTable> task = Config.hCntMain.GetInvGroup(id_otdel);
            task.Wait();
            dtGroups = task.Result;
           
            DoOnUIThread(delegate () 
            {
                dgvGroups.DataSource = dtGroups;
                DateTime firstdate = new DateTime(1902, 1, 1);
                if (dtGroups.Rows.Count > 0)
                {
                    if (Convert.ToDateTime( dtGroups.Rows[0]["dateUpdate"].ToString()) > firstdate)
                        tbLastUpdate.Text = "Последнее добавление " + dtGroups.Rows[0]["dateUpdate"].ToString() + " с датой реализации " + Convert.ToDateTime(dtGroups.Rows[0]["dateRealiz"].ToString()).ToShortDateString();
                    else
                        tbLastUpdate.Text = "Обновления для этого отдела отсутствует";
                }

            });
          

            DoOnUIThread(delegate () { this.Enabled = true; });
        }

        private void setFilter()
        {
            if (dtGroups!= null && dtGroups.Rows.Count>0)
            {
                try
                {


                    string filter = "";
                    if (tbGroup.Text.Trim().Length != 0)
                        filter += (filter.Length == 0 ? "" : " and ") + string.Format("cname like '%{0}%'", tbGroup.Text);

                    dtGroups.DefaultView.RowFilter = filter;
                }
                catch
                {
                    dtGroups.DefaultView.RowFilter = "id = -1";
                }
            }
        }
        private void cbDeps_Init()
        {
            DoOnUIThread(delegate () { this.Enabled = false; });
            Task<DataTable> task = Config.hCntMain.getDeps();
            task.Wait();
            dtDeps = task.Result;
            DoOnUIThread(delegate ()
            {
                cbDeps.DataSource = dtDeps;
                cbDeps.DisplayMember = "cName";
                cbDeps.ValueMember = "id";
            });

            DoOnUIThread(delegate () { this.Enabled = true; });

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbDeps_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Task.Run(() => { dgvGroups_Init(); });

        }

        private void tbDecimal_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tbDecimal_Validating(object sender, CancelEventArgs e)
        {
            TextBox tb = (sender as TextBox);
            string text = tb.Text;

            if (text.Trim().Length == 0) return;

            decimal value;
            if (!decimal.TryParse(text, out value))
            { e.Cancel = true; return; }
            tb.Text = value.ToString("0.000");
        }

        private bool validateToSave()
        {
            if (tbMin.Text.Trim().Length == 0)
            {
                MessageBox.Show(Config.centralText($"Необходимо заполнить:\n \"Минимальное количество заказа\"!\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbMin.Focus(); return false;
            }
            if (tbMax.Text.Trim().Length == 0)
            {
                MessageBox.Show(Config.centralText($"Необходимо заполнить:\n \"Максимальное количество заказа\"!\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbMax.Focus(); return false;
            }
            if (tbStep.Text.Trim().Length == 0)
            {
                MessageBox.Show(Config.centralText($"Необходимо заполнить:\n \"Шаг количества заказа\"!\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbStep.Focus(); return false;
            }
            if (tbDefault.Text.Trim().Length == 0)
            {
                MessageBox.Show(Config.centralText($"Необходимо заполнить:\n \"Значение заказанного товара по умолчанию\"!\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbDefault.Focus(); return false;
            }

            if (tbPriceSuffix.Text.Trim().Length == 0)
            {
                MessageBox.Show(Config.centralText($"Необходимо заполнить:\n \"Суффикс к цене товара\"!\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbPriceSuffix.Focus(); return false;
            }
            if (tbQuantitySuffix.Text.Trim().Length == 0)
            {
                MessageBox.Show(Config.centralText($"Необходимо заполнить:\n \"Суффикс к количеству товара\"!\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbQuantitySuffix.Focus(); return false;
            }
            decimal _tmpMin = 0, _tmpMax = 0, _tmpDefault = 0, _tmpStep = 0;

            if (!decimal.TryParse(tbMin.Text, out _tmpMin))
            {
                MessageBox.Show(Config.centralText($"Необходимо заполнить:\n \"Минимальное количество заказа\"!\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbMin.Focus(); return false;
            }

            if (_tmpMin < 0 || _tmpMin > 100)
            {
                MessageBox.Show(Config.centralText($"Значение \"Минимальное количество заказа\"\n должно быть от 0 до 100.\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbMin.Focus(); return false;
            }

            if (!decimal.TryParse(tbMax.Text, out _tmpMax))
            {
                MessageBox.Show(Config.centralText($"Необходимо заполнить:\n \"Максимальное количество заказа\"!\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbMax.Focus(); return false;
            }

            if (_tmpMax < 0 || _tmpMax > 100)
            {
                MessageBox.Show(Config.centralText($"Значение \"Максимального количества товара\"\n должно быть от 0 до 100.\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbMax.Focus(); return false;
            }

            if (_tmpMin > _tmpMax)
            {
                MessageBox.Show(Config.centralText($"Минимальное количество заказа должно быть меньше\n Максимального количества заказа!\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbMin.Focus(); return false;
            }

            if (!decimal.TryParse(tbDefault.Text, out _tmpDefault))
            {
                MessageBox.Show(Config.centralText($"Необходимо заполнить:\n \"Значение заказанного товара по умолчанию\"!\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbDefault.Focus(); return false;
            }

            if (_tmpDefault < 0 || _tmpDefault > 100)
            {
                MessageBox.Show(Config.centralText($"Значение \"Значение заказанного товара по умолчанию\"\n должно быть от 0 до 100.\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbDefault.Focus(); return false;
            }

            if (_tmpDefault < _tmpMin || _tmpDefault > _tmpMax)
            {
                MessageBox.Show(Config.centralText($"Значение заказанного товара по умолчанию\nдолжно быть от {_tmpMin.ToString("0.000")} до {_tmpMax.ToString("0.000")} \n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbDefault.Focus(); return false;
            }

            if (!decimal.TryParse(tbStep.Text, out _tmpStep))
            {
                MessageBox.Show(Config.centralText($"Необходимо заполнить:\n \"Шаг количества заказа\"!\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbStep.Focus(); return false;
            }

            if (_tmpStep < 0 || _tmpStep > 100)
            {
                MessageBox.Show(Config.centralText($"Значение \"Шаг количества заказа\"\n должно быть от 0 до 100.\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbStep.Focus(); return false;
            }
            if (_tmpStep > _tmpMax / 2)
            {
                MessageBox.Show(Config.centralText($"Значение \"Шаг количества заказа\"\n должно быть от 0 до {(_tmpMax / 2).ToString("0.000")}.\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbStep.Focus(); return false;
            }


            return true;
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!validateToSave()) return;

            EnumerableRowCollection<DataRow> rowColl = dtGroups.AsEnumerable().Where(r => (r.Field<bool>("selected") && !r.Field<bool>("isAdded")));
            if (rowColl.Count() >0)
            {
                dictonaryCategory.frmNeedCatGrp frm = new dictonaryCategory.frmNeedCatGrp() { dtGroups = rowColl.CopyToDataTable() , 
                    id_dep = int.Parse(cbDeps.SelectedValue.ToString())};
                frm.ShowDialog();
                if (!frm.isAdd)
                    return;
            }

            string selectedGroups = "";
            foreach (DataRow dr in dtGroups.Rows)
            {
                if (dr["selected"].ToString() == "True")
                    selectedGroups += dr["id"].ToString() + ",";
            }
            if (selectedGroups.Length==0)
            {
                MessageBox.Show("Должна быть выбрана хотя бы одна группа", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            selectedGroups = selectedGroups.Substring(0, selectedGroups.Length - 1);

            Thread t = new Thread(new ParameterizedThreadStart(setData));
            t.IsBackground = true;
            t.Start(selectedGroups);
            ShowForm();
            /*  Task<DataTable> task = Config.hCntMain.SetTovarByGroup(selectedGroups, dtpRealiz.Value,
                  decimal.Parse(tbMin.Text), decimal.Parse(tbMax.Text), decimal.Parse(tbStep.Text), decimal.Parse(tbDefault.Text),
                  tbPriceSuffix.Text, tbQuantitySuffix.Text, int.Parse(cbDeps.SelectedValue.ToString()));



              task.Wait();*/

            // MessageBox.Show("Товары добавлены", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);


            /*while (!(t.ThreadState == ThreadState.Aborted))
            {

            }*/

            /*       while (t.IsAlive)
                   {
                       Console.WriteLine("поток запущен");
                   }*/


           // dgvGroups_Init();
            
            //CloseForm();
            #region LOG
            Logging.StartFirstLevel(5);
            Logging.Comment("Начало добавление новых товаров");
            Logging.Comment("Дата реализации: " + dtpRealiz.Value.ToString() + ", " +
                "Отдел id: " + cbDeps.SelectedValue.ToString() + ", наименование: " + cbDeps.Text);
            foreach (DataRow dr in dtGroups.Rows)
            {
                if (dr["selected"].ToString() == "True")
                    Logging.Comment("id инв. группы: " + dr["id"].ToString() + ", наименование группы: " + dr["cname"].ToString());
            }
            Logging.StopFirstLevel();
            #endregion

        }
       
        private  void setData(object selectedGroups)
        {
            Thread.CurrentThread.Name = "Проца";
            
            DateTime dateRealiz = DateTime.Now;
            decimal min = 0;
            decimal max = 0;
            decimal step = 0;
            decimal tDefault = 0;
            string pSuf = "";
            string qSuf = "";
            int dep = 0;
          //  DoOnUIThread(delegate ()
         //   {
                dateRealiz = dtpRealiz.Value;
                min = decimal.Parse(tbMin.Text);
                max = decimal.Parse(tbMax.Text);
                step = decimal.Parse(tbStep.Text);
                tDefault = decimal.Parse(tbDefault.Text);
                pSuf = tbPriceSuffix.Text;
                qSuf = tbQuantitySuffix.Text;
            DoOnUIThread(delegate ()
            {
                dep = int.Parse(cbDeps.SelectedValue.ToString());
            });
                
         //   });
            Task<DataTable> task = null ;
            task = Config.hCntMain.SetTovarByGroup(selectedGroups.ToString(), dateRealiz,
              min, max, step, tDefault,
               pSuf, qSuf, dep);
           // Task<DataTable> task = Config.hCntMain.SetTovarByGroup(selectedGroups.ToString(), dateRealiz,
            //  min, max, step, tDefault,
            //   pSuf, qSuf, dep);
            task.Wait();          
            if (!form.IsDisposed)
                DoOnUIThread(delegate ()
                {
                    dgvGroups_Init();
                    CloseForm();
                });

            MessageBox.Show("Товары добавлены", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        frmWait form;
        private void ShowForm ()
        {
            form = new frmWait();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.TopMost = false;
                form.Show();


        }
        private void CloseForm()
        {

               form.Close();

        }

        private void dgvGroups_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex>-1)
                dtGroups.DefaultView[e.RowIndex]["selected"] = !(bool)dtGroups.DefaultView[e.RowIndex]["selected"];
        }

        private void dgvGroups_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void dgvGroups_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex != -1 && dtGroups != null && dtGroups.DefaultView.Count != 0)
            {
                Color rColor = Color.White;
                dgvGroups.Rows[e.RowIndex].DefaultCellStyle.BackColor = rColor;
                dgvGroups.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = rColor;
                dgvGroups.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;
            }
        }

        private bool selected = true;

        private void dgvGroups_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvGroups_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex == cSelect.Index)
            {
                foreach (DataRow dr in dtGroups.Rows)
                {
                    dr["selected"] = selected;
                }
                selected = !selected;
                dtGroups.AcceptChanges();
            }
            else
                return;
        }

        private void tbMin_Leave(object sender, EventArgs e)
        {
          
        }

        private void tbMin_Validated(object sender, EventArgs e)
        {
            tbDefault.Text = tbMin.Text;
        }

        private void tbGroup_TextChanged(object sender, EventArgs e)
        {
            setFilter();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
