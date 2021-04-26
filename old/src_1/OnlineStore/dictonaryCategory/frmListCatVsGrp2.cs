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
    public partial class frmListCatVsGrp2 : Form
    {

        DataTable dtDeps;
        DataTable dtData;
        DataTable dtCategor;
        public frmListCatVsGrp2()
        {
            InitializeComponent();
        }

    

        private void cbDeps_Init()
        {
            
            Task<DataTable> task = Config.hCntMain.getDeps();
            task.Wait();
            dtDeps = task.Result;
         
                cbDeps.DataSource = dtDeps;
                cbDeps.DisplayMember = "cName";
                cbDeps.ValueMember = "id";
                cbDeps.SelectedIndex = 0;               
        }

        private void cmbCategory_Init()
        {
            Task<DataTable> task = Config.hCntMain.getDicCategoryWithDep(int.Parse(cbDeps.SelectedValue.ToString()));
            task.Wait();
            dtCategor = task.Result;


            //dtCategor.DefaultView.RowFilter = "id >0";
            //cmbCategory.DataSource = dtCategor;
            cmbCategory.DataSource = dtCategor;
            cmbCategory.DisplayMember = "cName";
            cmbCategory.ValueMember = "id";
            if (dtCategor.Rows.Count <=1)
                cmbCategory.SelectedIndex = -1;
        }

        private void setEnableButtons()
        {
            if (dtData ==  null || dtData.DefaultView.Count == 0)
            {
                btnAdd.Enabled = btnDel.Enabled = false;
            }
            else
            {
                btnAdd.Enabled = btnDel.Enabled = true;
            }
            if ((int)cmbCategory.SelectedValue == 0)
                btnAdd.Enabled = false;
            else btnAdd.Enabled = true;
        }


        private void dgvData_Init()
        {
            // int id_otdel;// = -1;        
            //  id_otdel = (int)cbDeps.SelectedValue;

            if (cmbCategory.SelectedValue == null)
            {
                dtData = null;
                dgvData.DataSource = dtData;
                setEnableButtons();
                return;
            }
            dtData =  Config.hCntMain.GetCategoryVsGroup(int.Parse(cbDeps.SelectedValue.ToString()), int.Parse(cmbCategory.SelectedValue.ToString()));

            dtData.DefaultView.RowFilter = "idgrp>0";
            dgvData.DataSource = dtData;
            setEnableButtons();
        }

        private void frmListCatVsGrp2_Load(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(btnAdd, "Добавить");
            tt.SetToolTip(btnDel, "Удалить");
            tt.SetToolTip(btnExit, "Выход");

            dgvData.AutoGenerateColumns = false;
            cbDeps_Init();
            cmbCategory_Init();
            dgvData_Init();
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        bool IsTheSameCellValue(int column, int row)
        {
           // DataGridViewCell cell1 = dgvData[column, row];
          //  DataGridViewCell cell2 = dgvData[column, row - 1];
            var cell1 = dtData.DefaultView[row][column].ToString();
            var cell2 = dtData.DefaultView[row - 1][column].ToString();

            return cell1.ToString() == cell2.ToString();
        }


        private void cbDeps_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cmbCategory_Init();
            dgvData_Init();
        }

        private void dgvData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
           /* e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
            if (e.RowIndex < 1 || e.ColumnIndex < 0)
                return;
            if (e.ColumnIndex == 0)
            {
                if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex))
                {
                    e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
                   // dtData.DefaultView[e.RowIndex]["NameCategory"] = "";
                   // dgvData.Rows[e.RowIndex].Cells[0].Value = "";
                }
                else
                {
                    e.AdvancedBorderStyle.Top = dgvData.AdvancedCellBorderStyle.Top;
                }
            }
            else
            {
                e.AdvancedBorderStyle.Top = dgvData.AdvancedCellBorderStyle.Top;
            }*/
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            frmAddCatVsGrp2 frm = new frmAddCatVsGrp2() { id_dep = int.Parse(cbDeps.SelectedValue.ToString()),
                dep = cbDeps.Text,
                id_cat = int.Parse(cmbCategory.SelectedValue.ToString()),
                cat = cmbCategory.Text
            };
            frm.ShowDialog();

            if (frm.isEdit)
                dgvData_Init();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            Task<DataTable> task = Config.hCntMain.DelCategoryVsGroup(int.Parse(dtData.DefaultView[dgvData.CurrentRow.Index]["id"].ToString()),
                                                                      int.Parse(dtData.DefaultView[dgvData.CurrentRow.Index]["idgrp"].ToString()));
            task.Wait();
            MessageBox.Show("Связь удалена", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvData_Init();
        }


        private void cmbCategory_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dgvData_Init();
            setEnableButtons();
        }
    }
}
