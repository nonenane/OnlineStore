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
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Task.Run(() => init_combobox(true));
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

        private void DoOnUIThread(MethodInvoker d)
        {
            if (this.InvokeRequired) { this.Invoke(d); } else { d(); }
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
                dtCategory.DefaultView.RowFilter = "isActive = 1";               
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
            Task.Run(() => init_combobox(false));
        }

        private void cmbTU_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cmbInv.SelectedValue = 0;
        }

        private void cmbInv_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cmbTU.SelectedValue = 0;
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
    }
}
