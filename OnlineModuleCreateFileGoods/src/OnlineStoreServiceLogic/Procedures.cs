using Nwuram.Framework.Data;
using Nwuram.Framework.Settings.User;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStoreServiceLogic
{
    class Procedures : SqlProvider
    {
        public Procedures(string server, string database, string username, string password, string appName)
              : base(server, database, username, password, appName)
        {
        }
        ArrayList ap = new ArrayList();

        #region "Заказы"
        public async Task<DataTable> GetOrderNow()
        {
            ap.Clear();

            DataTable dtResult = executeProcedure("[OnlineStore].[GetOrderNow]",
                 new string[0] { },
                 new DbType[0] { }, ap);

            return dtResult;
        }

        public DataTable getListGoodsKassRealiz()
        {
            ap.Clear();

            DataTable dtResult = executeProcedure("[OnlineStore].[getListGoodsKassRealiz]",
                 new string[0] { },
                 new DbType[0] { }, ap);

            return dtResult;
        }

        public DataTable GetSpravTerminal()
        {
            ap.Clear();

            return executeProcedure("[OnlineStore].[GetSpravTerminal]",
                new string[0] { },
                new DbType[0] { }, ap);

        }

        public DataTable getListDeps()
        {
            ap.Clear();
            return executeProcedure("[OnlineStore].[getListDeps]",
                new string[] { },
                new DbType[] { }, ap);
        }

        public  DataTable getListGrp()
        {
            ap.Clear();
            return executeProcedure("[OnlineStore].[getListGrp]",
                new string[] { },
                new DbType[] { }, ap);
        }

        #endregion
    }
}
