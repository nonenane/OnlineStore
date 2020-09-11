using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStoreViewOrders
{
     static class Config
    {
        public static Procedures connect { get; set; } //осн. коннект
        public static Procedures connect2 { get; set; } //доп. коннект

        public static string[] RunArguments = null;

        public static DateTime _LASTLOADDATE { get; set; }


    }
}
