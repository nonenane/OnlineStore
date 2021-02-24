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
    public partial class frmNeedCatGrp : Form
    {
       public DataTable dtGroups { get; set; }
        public int id_dep { get; set; }

        private DataTable dtCategory;

        public bool  isAdd = false;

        public frmNeedCatGrp()
        {
            InitializeComponent();
        }

        private void dgvData_Init()
        {
            dgvData.AutoGenerateColumns = false;
            dgvData.DataSource = dtGroups;
           
            Task<DataTable> task = Config.hCntMain.getDicCategoryWithDep(id_dep);
            task.Wait();
            dtCategory = task.Result;

            dtCategory.DefaultView.RowFilter = "isActive = 1 and isParent = 0";

            cCat.DataSource = dtCategory;
            cCat.ValueMember = "id";
            cCat.DisplayMember = "cName";
            idgrp.DataPropertyName = "id";
           // cCat.DataPropertyName = "cName";
        }

        private void frmNeedCatGrp_Load(object sender, EventArgs e)
        {

            ToolTip tt = new ToolTip();
            tt.SetToolTip(btnAdd, "Добавить");
            tt.SetToolTip(btnExit, "Выход");

            dgvData_Init();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            isAdd = false;
            this.Close();
        }

        private bool validateGroup()
        {
            foreach (DataGridViewRow dr in dgvData.Rows)
            {
                if (dr.Cells["cCat"].Value==null)
                    return true;
            }


          
            return false;
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (validateGroup())
            {
                MessageBox.Show("Заполнены не все данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            foreach (DataGridViewRow dr in dgvData.Rows)
            {
                Config.hCntMain.SetCategoryVsGroup(int.Parse(dr.Cells["cCat"].Value.ToString()), int.Parse(dr.Cells["idgrp"].Value.ToString()));             
            }

            MessageBox.Show("Связь группы и категории добавлена", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            isAdd = true;
            this.Close();

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
            if (e.RowIndex != -1 && dtGroups != null && dtGroups.DefaultView.Count != 0)
            {
                Color rColor = Color.White;
                dgvData.Rows[e.RowIndex].DefaultCellStyle.BackColor = rColor;
                dgvData.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = rColor;
                dgvData.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;
            }
        }
    }
}
