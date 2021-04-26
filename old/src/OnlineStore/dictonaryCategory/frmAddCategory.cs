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
    public partial class frmAddCategory : Form
    {
        public int id { set; private get; }
        private bool isEdit = false;
        private DataTable dtTemp;
        public int id_dep { set; get; }

        public bool isEdited { get; set; } = false;

        public frmAddCategory()
        {
            InitializeComponent();
            ToolTip tp = new ToolTip();
            tp.SetToolTip(btClose,"Выход");
            tp.SetToolTip(btSave, "Сохранить");
        }

        private void frmAddCategory_Load(object sender, EventArgs e)
        {
            init_combobox();
            
            if (id != 0)
            {
                Task<DataTable> task = Config.hCntMain.getDicCategory(id);
                task.Wait();
                dtTemp = task.Result;
                if (dtTemp != null && dtTemp.Rows.Count > 0)
                {
                    tbName.Text = (string)dtTemp.Rows[0]["cName"];
                    tbPathImage.Text = (dtTemp.Rows[0]["PathImage"]==DBNull.Value ? "" : (string)dtTemp.Rows[0]["PathImage"]);
                    cmbDeps.SelectedValue = (int?)dtTemp.Rows[0]["id_Departments"];
                    if (dtTemp.Rows[0]["id_ParentCategory"] != DBNull.Value)
                        cmbParentCategory.SelectedValue = (int?)dtTemp.Rows[0]["id_ParentCategory"];
                    else
                        cmbParentCategory.SelectedValue = DBNull.Value;

                    bool isParent = (bool)dtTemp.Rows[0]["isParent"];
                    if (isParent) cmbDeps.Enabled = false;
                    chckIsUnload.Checked = (bool)dtTemp.Rows[0]["isUnload"];
                }
            }
            isEdit = false;
        }

        private void frmAddCategory_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = isEdit && MessageBox.Show(Config.centralText("На форме есть несохранёные данные.\nЗакрыть форму без сохранения данных?\n"), "Закрытие формы", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No;
        }

        private void DoOnUIThread(MethodInvoker d)
        {
            if (this.InvokeRequired) { this.Invoke(d); } else { d(); }
        }

        private void init_combobox()
        {
            DoOnUIThread(delegate () { this.Enabled = false; });

            Task<DataTable> task = Config.hCntMain.getDeps();
            task.Wait();
            DataTable dtDeps = task.Result;
            
            cmbDeps.DataSource = dtDeps;
            cmbDeps.DisplayMember = "cName";
            cmbDeps.ValueMember = "id";
            if (id_dep > 0) cmbDeps.SelectedValue = id_dep;
           // cmbDeps.SelectedIndex = -1;
            if (UserSettings.User.StatusCode.ToLower().Equals("ркв"))
            {
                cmbDeps.SelectedValue = UserSettings.User.IdDepartment;
                cmbDeps.Enabled = false;
            }

            init_category();
            //cmbParentCategory.SelectedIndex = -1;

            DoOnUIThread(delegate () { this.Enabled = true; });
        }

        private void init_category()
        {
            int id_deps = cmbDeps.SelectedValue == null ? -1 : (int)cmbDeps.SelectedValue;
            Task<DataTable> task = Config.hCntMain.getCategory(id_deps);
            task.Wait();
            DataTable dtCategory = task.Result;
            if (id != 0)
            {
                EnumerableRowCollection<DataRow> rowCollect = dtCategory.AsEnumerable().Where(r => r.Field<object>("id") != null && r.Field<object>("id") != DBNull.Value && r.Field<int>("id") == id);
                if (rowCollect.Count() > 0)
                {
                    rowCollect.First().Delete();
                    dtCategory.AcceptChanges();
                }
            }
            if (chckParentCategory.Checked)
            {
                Task<DataTable> task2 = Config.hCntMain.getDicCategoryParent();
                task2.Wait();
                DataTable dtCategoryParent = task2.Result;
                dtCategoryParent.DefaultView.RowFilter = " id_Departments <> " + cmbDeps.SelectedValue.ToString();
                dtCategory.Merge(dtCategoryParent.DefaultView.ToTable());
            }



            dtCategory.DefaultView.Sort = " id_Departments asc, cName asc";

            cmbParentCategory.DataSource = dtCategory;
            cmbParentCategory.DisplayMember = "cName";
            cmbParentCategory.ValueMember = "id";
        }

        private void cmpDeps_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if ((sender as ComboBox).Name.Equals(cmbDeps.Name))
            {
                init_category();
                cmbParentCategory.SelectedIndex = -1;
            }
            isEdit = true;
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            isEdit = true;
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (!validateToSave()) return;

            int id_dep = (int)cmbDeps.SelectedValue;
            int? id_ParentCategory = cmbParentCategory.SelectedValue == DBNull.Value ? null : (int?)cmbParentCategory.SelectedValue;
            string cName = tbName.Text.Trim();

            Task<DataTable> task = Config.hCntMain.validateDicCategory(id, cName);
            task.Wait();

            if (task.Result == null)
            {
                MessageBox.Show(Config.centralText("При проверке данных возникли ошибки записи.\nОбратитесь в ОЭЭС\n"), "Сохранение данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if ((int)task.Result.Rows[0]["id"] == -1)
            {
                MessageBox.Show(Config.centralText("В справочнике уже присутствует\nкатегория с таким наименованием.\n"), "Сохранение данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (id_ParentCategory != null)
            {                
                task = Config.hCntMain.validateDicCategory(id);
                task.Wait();

                if (task.Result == null)
                {
                    MessageBox.Show(Config.centralText("При проверке данных возникли ошибки записи.\nОбратитесь в ОЭЭС\n"), "Сохранение данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if ((int)task.Result.Rows[0]["id"] == -2)
                {
                    MessageBox.Show(Config.centralText("Данная категория используется как родительская\nНельзя назначить родительскую категорию!.\n"), "Сохранение данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            string pathImage = tbPathImage.Text.Trim();
            task = Config.hCntMain.setDicCategory(id,cName,id_dep, id_ParentCategory,pathImage,chckIsUnload.Checked);
            task.Wait();

            if (task.Result == null)
            {
                MessageBox.Show(Config.centralText("При сохранение данных возникли ошибки записи.\nОбратитесь в ОЭЭС\n"), "Сохранение данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (id == 0)
            {
                Logging.StartFirstLevel(43);

                Logging.Comment("Добавление новой категории товара");
                Logging.Comment($"ID:{task.Result.Rows[0]["id"].ToString()}");             
                Logging.Comment($"Наименование категории: {tbName.Text}");
                Logging.Comment($"Отдел категории id:{cmbDeps.SelectedValue.ToString()}; Наименование:{cmbDeps.Text}");

                if (id_ParentCategory != null)
                    Logging.Comment($"Родительская категория id:{cmbParentCategory.SelectedValue.ToString()}; Наименование:{cmbParentCategory.Text}");
                Logging.Comment($"Выгружать на сайт: {(chckIsUnload.Checked ? "Да" : "Нет")}");
                Logging.Comment($"Путь к картинке категории: {tbPathImage.Text}");
                Logging.StopFirstLevel();
            }
            else
            {
                if (dtTemp != null && dtTemp.Rows.Count > 0)
                {

                    Logging.StartFirstLevel(44);

                    Logging.Comment("Отредактирована категория в справочнике категорий");
                    Logging.Comment($"ID:{id}");

                    Logging.VariableChange("Наименование категории:", tbName.Text, (string)dtTemp.Rows[0]["cName"]);

                    Logging.VariableChange("Отдел категории id", cmbDeps.SelectedValue.ToString(), (int)dtTemp.Rows[0]["id_Departments"], typeLog._int);
                    Logging.VariableChange("Отдел категории Наименование", cmbDeps.Text.ToString(), dtTemp.Rows[0]["nameDep"], typeLog._string);
                    Logging.VariableChange("Выгружать на сайт", chckIsUnload.Checked, (bool)dtTemp.Rows[0]["isUnload"]);
                    Logging.VariableChange("Путь к картинке категории", tbPathImage.Text, dtTemp.Rows[0]["PathImage"].ToString());

                    /*
                    Logging.VariableChange("Родительская категория id", cmbParentCategory.SelectedValue, (int)dtTemp.Rows[0]["id_ParentCategory"], typeLog._int);
                    Logging.VariableChange("Родительская категория Наименование", cmbParentCategory.Text, dtTemp.Rows[0]["cNameParent"], typeLog._string);
                    */

                    Logging.StopFirstLevel();
                }
            }

            MessageBox.Show("Данные сохранены", "Сохранение данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
            isEdit = false;
            this.DialogResult = DialogResult.OK;

            isEdited = true;
        }

        private bool validateToSave()
        {
            if (tbName.Text.Trim().Length==0) { MessageBox.Show("Необходимо указать \"Наименование  категории\"!", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning); tbName.Focus(); return false; }
            if(cmbDeps.SelectedIndex==-1 || cmbDeps.SelectedValue==null) { MessageBox.Show("Необходимо выбрать \"Отдел  категории\"!", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning); cmbDeps.Focus(); return false; }

            return true;
        }

        private void chckParentCategory_CheckedChanged(object sender, EventArgs e)
        {
            init_category();
        }
    }
}
