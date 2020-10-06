using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineStoreViewOrders
{
     static class Config
    {
        public static Procedures connect { get; set; } //осн. коннект
        public static Procedures connect2 { get; set; } //доп. коннект

        public static string[] RunArguments = null;

        public static DateTime _LASTLOADDATE { get; set; }

        public static void DoOnUIThread(MethodInvoker d, Form _this)
        {
            if (_this.InvokeRequired) { _this.Invoke(d); } else { d(); }
        }
    }
}
