using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nwuram.Framework.Data;
using Nwuram.Framework.Logging;
using System.Collections;
using System.Data;
using Nwuram.Framework.Settings;

namespace OnlineShopOrders
{
    class readSQL : SqlProvider
    {
        ArrayList ap = new ArrayList();

        public readSQL(string server, string database, string username, string password, string appName)
     : base(server, database, username, password, appName)
        {
        }

        public DataTable Set_tOrder(int orderNum, DateTime dateOrder, string lastname, string name,
            string email,string phone, string address, decimal summa, string commentOrder, string typePay, string deliveryType)
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
            ap.Add(deliveryType);
            return executeProcedure("OnlineStore.set_tOrder", 
                new string[]    { "@orderNum", "@dateOrder", "@lastname", "@name",
                                "@email", "@phone","@address","@summaDelivery",
                                "@commentOrder","@id_person","@typePay", "@deliveryType"},
                new DbType[] {  DbType.Int32, DbType.DateTime, DbType.String, DbType.String,
                                DbType.String, DbType.String, DbType.String, DbType.Decimal,
                                DbType.String, DbType.Int32,DbType.String, DbType.String}, ap);

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

        /// <summary>
        /// удаление шапки заказа, если косяк с телом (ОБРАБОТАТЬ (с) Света)
        /// </summary>
        /// <param name="id_tOrder"></param>
        /// <returns></returns>
        public DataTable delOrder(int id_tOrder)
        {
            ap.Clear();
            ap.Add(id_tOrder);
            return executeProcedure("[OnlineStore].[delOrderFromFileLoad]",
                new string[] { "@id_tOrder" },
                new DbType[] { DbType.Int32 }, ap);
        }

    }
}
