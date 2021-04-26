using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Nwuram.Framework.Data;
using Nwuram.Framework.Settings.User;
using Nwuram.Framework.Settings.Connection;
using System.Collections;
using System.Windows.Forms;

namespace reportForNewUsersBuys
{
    class Procedures : SqlProvider
    {
        public Procedures(string server, string database, string username, string password, string appName)
      : base(server, database, username, password, appName)
        {

        }
        ArrayList ap = new ArrayList();

        public async Task<DataTable> getReportNewUserBuy(DateTime start, DateTime end)
        {
            ap.Clear();
            ap.Add(start);
            ap.Add(end);
            
            return executeProcedure("[OnlineStore].[getReportNewUserBuy]",
                    new string[2] { "@dateStart", "@dateEnd" },
                    new DbType[2] { DbType.DateTime, DbType.DateTime }, ap);

        }

        public async Task<DataTable> getReportWarhouse(string listOrser)
        {
            ap.Clear();
            ap.Add(listOrser);

            return executeProcedure("[OnlineStore].[getReportWarhouse]",
                    new string[1] { "@listOrser" },
                    new DbType[1] {DbType.String }, ap);
        }
    }
}
