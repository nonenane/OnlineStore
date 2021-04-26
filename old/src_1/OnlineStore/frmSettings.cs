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
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }
        private decimal old_Margin;
        private void frmSettings_Load(object sender, EventArgs e)
        {
            if (Config.needImage)
            {
                if (Config.ImageTovar) rbImgTovar.Checked = true;
                else rbImgCat.Checked = true;
            }
            else rbWithoutImage.Checked = true;
            ToolTip tt = new ToolTip();
            tt.SetToolTip(btExit, "Выход");

           /* if (Nwuram.Framework.Settings.User.UserSettings.User.StatusCode=="КД")
            {
                lblMargin.Visible = true;
                tbMargin.Visible = true;
            }*/
          //  Margin_Init();
            tbSizeFile.Text = Config.sizeCSV.ToString();
        }

     /*   private void Margin_Init()
        {

            DataTable result;
           // result = Config.hCntMain.getProgConfig();
            if (result.Rows.Count == 0)
                tbMargin.Text = "10";
            else
            {
               // old_Margin = decimal.Parse(result.Rows[0]["value"].ToString());
               // tbMargin.Text = old_Margin.ToString();
              //  Config.Margin = old_Margin;
            }
        }
        */

        private void btExit_Click(object sender, EventArgs e)
        {
            decimal tryParse;

           /* string current = tbMargin.Text.Replace('.',',');

            if (!(decimal.TryParse(current,out tryParse)))
            {
                MessageBox.Show("Наценка должна быть числом", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            */
          /*  if (old_Margin != tryParse)
            {
                Config.hCntMain.setConfig(tryParse);
                Config.Margin = tryParse;
            }*/
            int sizeCsv;
            if (int.TryParse(tbSizeFile.Text, out sizeCsv))
                Config.sizeCSV = sizeCsv;
            else if (sizeCsv<=0)
            {
                MessageBox.Show("Размер файла должен быть больше 0", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else 
            {
                MessageBox.Show("Размер файла должен быть целым числом", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.Close();
        }

        private void rbImgTovar_CheckedChanged(object sender, EventArgs e)
        {
            if (rbImgTovar.Checked) { Config.ImageTovar = true; Config.needImage = true; }
        }

        private void rbImgCat_CheckedChanged(object sender, EventArgs e)
        {
            if (rbImgCat.Checked) { Config.ImageTovar = false; Config.needImage = true; }
        }

        private void rbWithoutImage_CheckedChanged(object sender, EventArgs e)
        {
            if (rbWithoutImage.Checked) { Config.needImage = false; Config.ImageTovar = false; }
        }

        private void lblMargin_Click(object sender, EventArgs e)
        {

        }
    }
}
