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

namespace OnlineStoreViewOrders
{
    class Procedures : SqlProvider
    {
        public Procedures(string server, string database, string username, string password, string appName)
      : base(server, database, username, password, appName)
        {

        }
        ArrayList ap = new ArrayList();

        public DataTable Get_tOrders(DateTime start, DateTime end)
        {
            ap.Clear();
            ap.Add(start);
            ap.Add(end);
            if (UserSettings.User.StatusCode == "РКВ")
                ap.Add(UserSettings.User.IdDepartment);
            else ap.Add(0);
            return executeProcedure("[OnlineStore].[get_tOrders]",
                    new string[] { "@startdate", "@enddate","@id_dep" },
                    new DbType[] { DbType.DateTime, DbType.DateTime, DbType.Int16 }, ap);

        }

        public DataTable Get_Goods(int id_tOrder)
        {
            ap.Clear();
            ap.Add(id_tOrder);
            return executeProcedure("[OnlineStore].[get_Orders]",
                    new string[] { "@id_tOrder" },
                    new DbType[] { DbType.Int32 }, ap);
        }

        public DataTable GetNameGoods(int id_Tovar)
        {
            ap.Clear();
            ap.Add(id_Tovar);
            return executeProcedure("OnlineStore.getOrderVVO",
                    new string[] { "@id_tovar" },
                    new DbType[] { DbType.Int32 }, ap);
        }

        public DataTable Set_tOrder(int orderNum, DateTime dateOrder, string lastname, string name,
           string email, string phone, string address, decimal summa, string commentOrder, string typePay)
        {
            ap.Clear();
            ap.Add(orderNum);
            ap.Add(dateOrder);
            ap.Add(lastname);
            ap.Add(name);
            ap.Add(email);
            ap.Add(phone);
            ap.Add(address);
            ap.Add(summa);
            ap.Add(commentOrder);
            ap.Add(Nwuram.Framework.Settings.User.UserSettings.User.Id);
            ap.Add(typePay);

            return executeProcedure("OnlineStore.set_tOrder",
                new string[]    { "@orderNum", "@dateOrder", "@lastname", "@name",
                                "@email", "@phone","@address","@summaDelivery",
                                "@commentOrder","@id_person","@typePay"},
                new DbType[] {  DbType.Int32, DbType.DateTime, DbType.String, DbType.String,
                                DbType.String, DbType.String, DbType.String, DbType.Decimal,
                                DbType.String, DbType.Int32,DbType.String}, ap);

        }

        public DataTable Set_tOrderPackage(int count, int id_tOrder)
        {
            ap.Clear();
            ap.Add(count);
            ap.Add(id_tOrder);
            ap.Add(UserSettings.User.Id);
            return executeProcedure("OnlineStore.set_tOrder", new string[] { "@countPackage", "@idOrder", "@id_person" },
                                                                new DbType[] { DbType.Int32, DbType.Int32, DbType.Int32 }, ap);
        }

        public DataTable Set_Order(int id_tOrder, int id_tovar, string category, int position, decimal netto, decimal price)
        {
            ap.Clear();
            ap.Add(id_tOrder);
            ap.Add(id_tovar);
            ap.Add(category);
            ap.Add(position);
            ap.Add(netto);
            ap.Add(price);
            ap.Add(Nwuram.Framework.Settings.User.UserSettings.User.Id);
            return executeProcedure("OnlineStore.set_Orders",
                new string[] { "@id_tOrder", "@id_tovar", "@category", "@position", "@netto", "@price", "@id_person" },
                new DbType[] { DbType.Int32, DbType.Int32, DbType.String, DbType.Int32, DbType.Decimal, DbType.Decimal, DbType.Int32 },
                ap);
        }

        public DataTable GetDateLastUpdate()
        {
            ap.Clear();
            ap.Add(ConnectionSettings.GetIdProgram());
            return executeProcedure("OnlineStore.getDateLastUpdate",
                new string[] { "@id_prog" },
                new DbType[] { DbType.Int32 }, ap);
        }
        public DataTable SetDateLastUpdate()
        {
            ap.Clear();
            ap.Add(ConnectionSettings.GetIdProgram());
            ap.Add(DateTime.Now);
            return executeProcedure("OnlineStore.setDateLastUpdate",
                new string[] { "@id_prog", "@date" },
                new DbType[] { DbType.Int32, DbType.DateTime }, ap);
        }

        public DataTable Get_PackageOrder(int id)
        {
            ap.Clear();
            ap.Add(id);
            return executeProcedure("[OnlineStore].[get_tOrderPackage]",
                new string[] { "@id_Order" },
                new DbType[] { DbType.Int32 }, ap);
        }

        public DataTable GetGoodByEan(string ean)
        {
            ap.Clear();
            ap.Add(ean);
            return executeProcedure("[OnlineStore].[getGoodsByEan]",
                new string[] { "@ean" },
                new DbType[] { DbType.String }, ap);
        }

        public DataTable GetCheckvsOrder(int id_tOrder)
        {
            ap.Clear();
            ap.Add(id_tOrder);
            return executeProcedure("[OnlineStore].[getCheckOrder]",
                new string[] { "@id_tOrder" },
                new DbType[] { DbType.Int32 }, ap);
        }

        public DataTable GetCheckInfo(DateTime date, int doc_id, int terminal)
        {
            ap.Clear();
            ap.Add(date);
            ap.Add(doc_id);
            ap.Add(terminal);
            return executeProcedure("[OnlineStore].[getCheckInfo]",
                new string[] { "@date", "@doc_id", "@terminal" },
                new DbType[] { DbType.DateTime, DbType.Int32, DbType.Int32}, ap);
        }

        public DataTable DelCheckOrder(int id)
        {
            ap.Clear();
            ap.Add(id);
            return executeProcedure("[OnlineStore].[setCheckOrder]",
                new string[] { "@id" },
                new DbType[] { DbType.Int32 }, ap);
        }
        public DataTable SetCheckOrder(int CheckNumber, int KassNumber, DateTime dateCheck, int id_tOrder, bool isPackage)
        {
            ap.Clear();
            ap.Add(CheckNumber);
            ap.Add(KassNumber);
            ap.Add(dateCheck);
            ap.Add(id_tOrder);
            ap.Add(UserSettings.User.Id);
            ap.Add(isPackage);
            return executeProcedure("[OnlineStore].[setCheckOrder]",
                new string[] { "@CheckNumber", "@KassNumber", "@DateCheck", "@id_tOrder", "@id_Editor", "@isPackage" },
                new DbType[] { DbType.Int32, DbType.Int32, DbType.DateTime, DbType.Int32, DbType.Int32, DbType.Boolean }, ap);
        }

        public DataTable getPackage(int doc_id, DateTime date, int terminal)
        {
            ap.Clear();
            ap.Add(doc_id);
            ap.Add(date);
            ap.Add(terminal);
            return executeProcedure("OnlineStore.getPackage",
                new string[] { "@doc_id", "@date", "@terminal" },
                new DbType[] { DbType.Int32, DbType.DateTime, DbType.Int32 }, ap);
        }

        /// <summary>
        /// просмотр чека
        /// </summary>
        /// <param name="doc_id"></param>
        /// <param name="date"></param>
        /// <param name="terminal"></param>
        /// <returns></returns>
        public DataTable getCheckInfo(int doc_id, DateTime date, int terminal)
        {
            ap.Clear();
            ap.Add(doc_id);
            ap.Add(date);
            ap.Add(terminal);
            return executeProcedure("OnlineStore.getCheck",
                 new string[] { "@doc_id", "@date", "@terminal" },
                new DbType[] { DbType.Int32, DbType.DateTime, DbType.Int32 }, ap);
        }

        #region "Работа со статусами"
        public DataTable getHistoryJournalStatus(int id_tOrders)
        {
            ap.Clear();
            ap.Add(id_tOrders);
            return executeProcedure("OnlineStore.getHistoryJournalStatus",
                 new string[] { "@id_tOrders" },
                new DbType[] { DbType.Int32 }, ap);
        }


        #endregion
    }
}
