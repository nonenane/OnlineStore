using Nwuram.Framework.Logging;
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
    public partial class frmAddCatVsGrp2 : Form
    {
        DataTable dtData;
        public int id_dep { get; set; }
        public string dep { get; set; }

        public int id_cat { get; set; }

        public string cat { get; set; }

        public bool isEdit { get; private set; } = false;
    
        public frmAddCatVsGrp2()
        {
            InitializeComponent();
        }


        private void dgvData_Init()
        {
            
            int id_otdel = -1;          
            id_otdel = id_dep;         
            Task<DataTable> task = Config.hCntMain.GetInvGroup(id_otdel);
            task.Wait();
            dtData = task.Result;        
            dgvGroups.DataSource = dtData;           
            filter();
            
        }

        private void filter()
        {
            dtData.DefaultView.RowFilter = "isAdded = 0";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddCatVsGrp2_Load(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(btnExit, "Выход");
            tt.SetToolTip(btnSave, "Сохранить");

            dgvGroups.AutoGenerateColumns = false;
            dgvData_Init();
            label1.Text = "Отдел: " + dep + "\r\nКатегория: " + cat;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int id_grp = int.Parse(dtData.DefaultView[dgvGroups.CurrentRow.Index]["id"].ToString());
            int selectedIndex = dgvGroups.CurrentRow.Index;
            DataTable dt = Config.hCntMain.SetCategoryVsGroup(id_cat, id_grp);

           
            if (int.Parse(dt.Rows[0][0].ToString())>0)
            {
                Logging.StartFirstLevel(1583);
                Logging.Comment("Добавлении связи группы и категории");
              
                Logging.Comment($"id Категории: {id_cat}, Наименование: {cat}");
                Logging.Comment($"id группы: {id_grp}, Наименование: {dtData.DefaultView[dgvGroups.CurrentRow.Index]["cname"].ToString()}");
                Logging.Comment($"Завершение добавления связи группы и категории");
                Logging.StopFirstLevel();
                MessageBox.Show("Связь добавлена", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);            
                dgvData_Init();
                if (dgvGroups.Rows.Count > selectedIndex)
                {
                    dgvGroups.CurrentCell = dgvGroups.Rows[selectedIndex].Cells[0];
                    dgvGroups.CurrentCell.Selected = true;
                }
                else if (dgvGroups.Rows.Count>0)
                {
                    dgvGroups.CurrentCell = dgvGroups.Rows[dgvGroups.Rows.Count-1].Cells[0];
                    dgvGroups.CurrentCell.Selected = true;
                }

            }
            else
            {
                MessageBox.Show("Группа уже принадлежит другой категории", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvData_Init();
                if (dgvGroups.Rows.Count > selectedIndex)
                {
                    dgvGroups.CurrentCell = dgvGroups.Rows[selectedIndex].Cells[0];
                    dgvGroups.CurrentCell.Selected = true;
                }
                else if (dgvGroups.Rows.Count > 0)
                {
                    dgvGroups.CurrentCell = dgvGroups.Rows[dgvGroups.Rows.Count - 1].Cells[0];
                    dgvGroups.CurrentCell.Selected = true;
                }
            }
            isEdit = true;

            dt.Dispose();
        }

        private void dgvGroups_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex != -1 && dtData != null && dtData.DefaultView.Count != 0)
            {
                Color rColor = Color.White;
                dgvGroups.Rows[e.RowIndex].DefaultCellStyle.BackColor = rColor;
                dgvGroups.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = rColor;
                dgvGroups.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;
            }
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

        private void dgvGroups_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>-1 && dtData != null && dtData.DefaultView.Count>0)
            {
                int id_grp = int.Parse(dtData.DefaultView[dgvGroups.CurrentRow.Index]["id"].ToString());
                DataTable dt = Config.hCntMain.SetCategoryVsGroup(id_cat, id_grp);

                if (int.Parse(dt.Rows[0][0].ToString()) > 0)
                {
                    Logging.StartFirstLevel(1583);
                    Logging.Comment("Добавлении связи группы и категории");
                   
                    Logging.Comment($"id Категории: {id_cat}, Наименование: {cat}");
                    Logging.Comment($"id группы: {id_grp}, Наименование: {dtData.DefaultView[dgvGroups.CurrentRow.Index]["cname"].ToString()}");
                    Logging.Comment($"Завершение добавления связи группы и категории");
                    Logging.StopFirstLevel();
                    MessageBox.Show("Связь добавлена", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    int selectedIndex = e.RowIndex;
                    dgvData_Init();

                    if (dgvGroups.Rows.Count > selectedIndex)
                    {
                        dgvGroups.CurrentCell = dgvGroups.Rows[selectedIndex].Cells[0];
                        dgvGroups.CurrentCell.Selected = true;
                    }
                    else if (dgvGroups.Rows.Count > 0)
                    {
                        dgvGroups.CurrentCell = dgvGroups.Rows[dgvGroups.Rows.Count - 1].Cells[0];
                        dgvGroups.CurrentCell.Selected = true;
                    }
                }
                else
                {
                    int selectedIndex = e.RowIndex;
                    MessageBox.Show("Группа уже принадлежит другой категории", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgvData_Init();
                    if (dgvGroups.Rows.Count > selectedIndex)
                    {
                        dgvGroups.CurrentCell = dgvGroups.Rows[selectedIndex].Cells[0];
                        dgvGroups.CurrentCell.Selected = true;
                    }
                    else if (dgvGroups.Rows.Count > 0)
                    {
                        dgvGroups.CurrentCell = dgvGroups.Rows[dgvGroups.Rows.Count - 1].Cells[0];
                        dgvGroups.CurrentCell.Selected = true;
                    }
                }

                isEdit = true;

                dt.Dispose();
            }
        }
    }
}
