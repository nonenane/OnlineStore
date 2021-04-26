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
    public partial class frmSettingsTimeDelivery : Form
    {
        public frmSettingsTimeDelivery()
        {
            InitializeComponent();
        }

        private void frmSettingsTimeDelivery_Load(object sender, EventArgs e)
        {
            Task<DataTable> task = Config.hCntMain.getSettings("vrdd");
            task.Wait();
            if (task.Result != null && task.Result.Rows.Count > 0)
            {
                dtpTimeDelivery.Value = DateTime.Now.Date.Add(TimeSpan.Parse(task.Result.Rows[0]["value"].ToString()));
            }
            else
            {
                dtpTimeDelivery.Value = DateTime.Now.Date.Add(TimeSpan.Parse("14:00:00"));
            }
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private async void btSave_Click(object sender, EventArgs e)
        {
            Config.hCntMain.setSettings("vrdd", dtpTimeDelivery.Value.TimeOfDay.ToString()).Wait();

            MessageBox.Show("Данные сохранены.", "Сохранение данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
        }
    }
}
