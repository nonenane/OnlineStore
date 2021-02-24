using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace winServiceOnline
{
    public partial class winServiceOnline : ServiceBase
    {
        OnlineStoreServiceLogic.Logic logic;        
        public winServiceOnline()
        {
            InitializeComponent();            
        }

        protected override void OnStart(string[] args)
        {
            logic = new OnlineStoreServiceLogic.Logic();
        }

        protected override void OnStop()
        {         
            if (logic != null)
                logic.Dispose();
        }
    }
}
