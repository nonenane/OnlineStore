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
    public partial class frmSelectData : Form
    {
        public static DateTime date;
        public frmSelectData()
        {
            InitializeComponent();
            dateTimePicker1.MaxDate = DateTime.Now;
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            date = dateTimePicker1.Value.Date;
        }
    }
}
