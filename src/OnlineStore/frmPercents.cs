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
        }

        DataTable dtPercent, dtPercentOld;
        public bool lChanged = false;
        private bool oldSale;


        private void frmPercents_Load(object sender, EventArgs e)
        {
            dgvPercents_Init();
            chckUseSale.Checked = Config.isSale;
            oldSale = Config.isSale;


        }


        private void dgvPercents_Init()
        {
            dtPercent = Config.hCntMain.GetPercents();
            dgvPercents.AutoGenerateColumns = false;
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
                Logging.Comment("Изменение настроек процента наценки/распродажи");
                Logging.CompareDataTable(dtPercentOld, dtPercent, "id", new int[2] { 2, 3 });
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
            MessageBox.Show("Проценты сохранены", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
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
