using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineStore
{
    public partial class frmSettingDayDelivery : Form
    {
        public frmSettingDayDelivery()
        {
            InitializeComponent();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void frmSettingDayDelivery_Load(object sender, EventArgs e)
        {
            Task<DataTable> task =  Config.hCntMain.getSettings("vrdd");
            task.Wait();

            if (task.Result != null && task.Result.Rows.Count > 0)
            {
                dtpPlanDeliveryDate.Value = DateTime.Now.Date.Add(TimeSpan.Parse(task.Result.Rows[0]["value"].ToString()));
            }
        }

        private async void btSave_Click(object sender, EventArgs e)
        {
            await Config.hCntMain.setSettings("vrdd", dtpPlanDeliveryDate.Value.TimeOfDay.ToString());
            MessageBox.Show("Данные сохранены.", "Сохранение данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
        }
    }
}
