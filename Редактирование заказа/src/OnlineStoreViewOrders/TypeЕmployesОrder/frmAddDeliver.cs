using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineStoreViewOrders.TypeЕmployesОrder
{
    public partial class frmAddDeliver : Form
    {
        public bool isCollector { private set; get; }
        public bool isKassTerminal { private set; get; }
        public bool isDeliver { private set; get; }
        public frmAddDeliver()
        {
            InitializeComponent();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            isCollector = chbCollector.Checked;
            isKassTerminal = chbKassTerminal.Checked;
            isDeliver = chbDeliver.Checked;
            this.DialogResult = DialogResult.OK;
        }
    }
}
