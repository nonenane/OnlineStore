﻿using System;
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

namespace OnlineStoreViewOrders
{
    class Procedures : SqlProvider
    {
        public Procedures(string server, string database, string username, string password, string appName)
      : base(server, database, username, password, appName)
        {

        }
        ArrayList ap = new ArrayList();

        public DataTable Get_tOrders(DateTime start, DateTime end,int type)
        {
            ap.Clear();
            ap.Add(start);
            ap.Add(end);
            if (UserSettings.User.StatusCode == "РКВ")
                ap.Add(UserSettings.User.IdDepartment);
            else ap.Add(0);
            ap.Add(type);
            return executeProcedure("[OnlineStore].[get_tOrders]",
                    new string[4] { "@startdate", "@enddate", "@id_dep", "@type" },
                    new DbType[4] { DbType.DateTime, DbType.DateTime, DbType.Int16, DbType.Int32 }, ap);

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
           string email, string phone, string address, decimal summa, string commentOrder, string typePay, string deliveryType)
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
        public DataTable SetCheckOrder(int CheckNumber, int KassNumber, DateTime dateCheck, decimal summa, int id_tOrder, bool isPackage)
        {
            ap.Clear();
            ap.Add(CheckNumber);
            ap.Add(KassNumber);
            ap.Add(dateCheck);
            ap.Add(summa);
            ap.Add(id_tOrder);
            ap.Add(UserSettings.User.Id);
            ap.Add(isPackage);
            return executeProcedure("[OnlineStore].[setCheckOrder]",
                new string[7] { "@CheckNumber", "@KassNumber", "@DateCheck", "@summa", "@id_tOrder", "@id_Editor", "@isPackage" },
                new DbType[7] { DbType.Int32, DbType.Int32, DbType.DateTime, DbType.Decimal, DbType.Int32, DbType.Int32, DbType.Boolean }, ap);
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

        public DataTable getOrderInfo(int id_tOrder)
        {
            ap.Clear();
            ap.Add(id_tOrder);
            return executeProcedure("[OnlineStore].[getInfoTOrder]",
                new string[] { "@id_tOrder" },
                new DbType[] { DbType.Int32 }, ap);
        }
        #region "Работа со статусами"

        public DataTable getDeps(bool isAll)
        {
            ap.Clear();
            ap.Add(true);

            DataTable dtResult = executeProcedure("[OnlineStore].[getDataComboForCategory]",
                 new string[1] { "@isDep" },
                 new DbType[1] { DbType.Boolean }, ap);

            if (isAll)
            {
                DataColumn col = new DataColumn("isMain", typeof(bool));
                col.DefaultValue = false;
                dtResult.Columns.Add(col);

                DataRow newRow = dtResult.NewRow();

                newRow["id"] = 0;
                newRow["cName"] = "Все Отделы";                
                newRow["isMain"] = true;

                dtResult.Rows.Add(newRow);                
                dtResult.DefaultView.Sort = "isMain desc, id asc";
                dtResult = dtResult.DefaultView.ToTable().Copy();
            }
            else
            {                
                dtResult.DefaultView.Sort = "id asc";
                dtResult = dtResult.DefaultView.ToTable().Copy();
            }

            return dtResult;            
        }

        public DateTime getDate()
        {
            ap.Clear();
            DataTable dtResult = executeProcedure("dbo.GetDate",
                new string[0] { },
                new DbType[0] { }, ap);

            if (dtResult == null || dtResult.Rows.Count == 0)
                return DateTime.Now;
            else
                return (DateTime)dtResult.Rows[0][0];
        }

        public DataTable getHistoryJournalStatus(int id_tOrders)
        {
            ap.Clear();
            ap.Add(id_tOrders);
            return executeProcedure("OnlineStore.getHistoryJournalStatus",
                 new string[] { "@id_tOrders" },
                new DbType[] { DbType.Int32 }, ap);
        }

        public DataTable setStatusOrder( int id_tOrder,decimal? DeliveriCost,DateTime? DeliveryDate, int id_status,string commentOrder)
        {
            ap.Clear();            
            ap.Add(id_tOrder);
            ap.Add(DeliveriCost);
            ap.Add(DeliveryDate);
            ap.Add(id_status);
            ap.Add(commentOrder);
            ap.Add(UserSettings.User.Id);
            return executeProcedure("OnlineStore.set_tOrder", 
                new string[6] { "@idOrder", "@DeliveriCost", "@DeliveryDate", "@id_status","@commentOrder", "@id_person" },
                new DbType[6] { DbType.Int32, DbType.Decimal,DbType.Date,DbType.Int32,DbType.String, DbType.Int32 }, ap);
        }

        public DataTable updateSummaDelivery(int id_tOrder, decimal summaDelivery,DateTime PlanDeliveryDate,string address,string deliveryType)
        {
            ap.Clear();
            ap.Add(id_tOrder);
            ap.Add(summaDelivery);
            ap.Add(UserSettings.User.Id);
            ap.Add(PlanDeliveryDate);
            ap.Add(address);
            ap.Add(deliveryType);
            return executeProcedure("OnlineStore.set_tOrder",
                new string[6] { "@idOrder", "@summaDelivery", "@id_person", "@PlanDeliveryDate","@address","@deliveryType" },
                new DbType[6] { DbType.Int32, DbType.Decimal, DbType.Int32, DbType.DateTime,DbType.String,DbType.String }, ap);
        }

        public DataTable getListStatus(bool isAll)
        {
            ap.Clear();
            DataTable dtResult = executeProcedure("[OnlineStore].[getListStatus]",
                new string[0] {  },
                new DbType[0] {}, ap);

            if (isAll)
            {
                DataColumn col = new DataColumn("isMain", typeof(bool));
                col.DefaultValue = false;
                dtResult.Columns.Add(col);

                DataRow newRow = dtResult.NewRow();

                newRow["id"] = 0;
                newRow["cName"] = "Все статусы";
                newRow["isActive"] = true;
                newRow["isMain"] = true;

                dtResult.Rows.Add(newRow);

                dtResult.DefaultView.RowFilter = "isActive = 1";
                dtResult.DefaultView.Sort = "isMain desc, id asc";
                dtResult = dtResult.DefaultView.ToTable().Copy();
            }
            else
            {
                dtResult.DefaultView.RowFilter = "isActive = 1";
                dtResult.DefaultView.Sort = "id asc";
                dtResult = dtResult.DefaultView.ToTable().Copy();
            }

            return dtResult;
        }

        public DataTable getReportData(DateTime dateStart, DateTime dateEnd,int id_status)
        {
            ap.Clear();
            ap.Add(dateStart.Date);
            ap.Add(dateEnd.Date);
            ap.Add(id_status);
            return executeProcedure("OnlineStore.getReportData",
                new string[3] { "@dateStart", "@dateEnd", "@id_status" },
                new DbType[3] { DbType.Date, DbType.Date, DbType.Int32 }, ap);
        }

        public DataTable getPopularTovarInfo(DateTime dateStart, DateTime dateEnd, int id_period)
        {
            ap.Clear();
            ap.Add(dateStart.Date);
            ap.Add(dateEnd.Date);
            ap.Add(id_period);

            return executeProcedure("OnlineStore.getPopularTovarInfo",
                new string[3] { "@dateStart", "@dateEnd", "@id_period" },
                new DbType[3] { DbType.Date, DbType.Date, DbType.Int32 }, ap);
        }

        public DataTable getStasticOrder(DateTime dateStart, DateTime dateEnd, int id_period)
        {
            ap.Clear();
            ap.Add(dateStart.Date);
            ap.Add(dateEnd.Date);
            ap.Add(id_period);

            return executeProcedure("OnlineStore.getStasticOrder",
                new string[3] { "@dateStart", "@dateEnd", "@id_period" },
                new DbType[3] { DbType.Date, DbType.Date, DbType.Int32 }, ap);
        }

        public DataTable getSumOrderWithRCena(DateTime dateStart, DateTime dateEnd, int id_period)
        {
            ap.Clear();
            ap.Add(dateStart.Date);
            ap.Add(dateEnd.Date);
            ap.Add(id_period);

            return executeProcedure("OnlineStore.getSumOrderWithRCena",
                new string[3] { "@StartDate", "@EndDate", "@id_period" },
                new DbType[3] { DbType.Date, DbType.Date, DbType.Int32 }, ap);
        }

        public DataTable getSumNotesOrderWithRCena(DateTime dateStart, DateTime dateEnd, int id_period)
        {
            ap.Clear();
            ap.Add(dateStart.Date);
            ap.Add(dateEnd.Date);
            ap.Add(id_period);

            return executeProcedure("OnlineStore.getSumNotesOrderWithRCena",
                new string[3] { "@StartDate", "@EndDate", "@id_period" },
                new DbType[3] { DbType.Date, DbType.Date, DbType.Int32 }, ap);
        }

        #endregion

        #region "Настройки"
        public async Task<DataTable> getSettings(string id_value)
        {
            ap.Clear();
            ap.Add(ConnectionSettings.GetIdProgram());
            ap.Add(id_value);

            DataTable dtResult = executeProcedure("[OnlineStore].[getSettings]",
                 new string[2] { "@id_prog", "@id_value" },
                 new DbType[2] { DbType.Int32, DbType.String }, ap);

            return dtResult;
        }

        public async Task<DataTable> setSettings(string id_value, string value)
        {
            ap.Clear();
            ap.Add(ConnectionSettings.GetIdProgram());
            ap.Add(id_value);
            ap.Add(value);


            DataTable dtResult = executeProcedure("[OnlineStore].[setSettings]",
                 new string[3] { "@id_prog", "@id_value", "@value" },
                 new DbType[3] { DbType.Int32, DbType.String, DbType.String }, ap);

            return dtResult;
        }

        public bool GetPropertyList(string id_value)
        {
            ap.Clear();
            ap.Add(ConnectionSettings.GetIdProgram());
            ap.Add(UserSettings.User.Id);
            ap.Add(id_value);

            DataTable dtResult = executeProcedure("[OnlineStore].[GetPropertyList]",
                 new string[3] { "@id_prog", "@id_user", "@id_val" },
                 new DbType[3] { DbType.Int32, DbType.Int32, DbType.String }, ap);

            if (dtResult == null || dtResult.Rows.Count == 0) return false;


            return dtResult.Rows[0]["val"].ToString().Equals("1");
        }

        #endregion

        #region "Получение остатков и продаж по заказу за текущий день"

        public DataTable GetOstOrderNow(int id_tOrders)
        {
            ap.Clear();
            ap.Add(id_tOrders);

            return executeProcedure("[OnlineStore].[GetOstOrderNow]",
                new string[1] { "@id_tOrders" },
                new DbType[1] { DbType.Int32 }, ap);
        }

        public DataTable GetRealizTovarForEan(string listEAN)
        {
            ap.Clear();
            ap.Add(listEAN);

            return executeProcedure("[OnlineStore].[GetRealizTovarForEan]",
                new string[1] { "@listEAN" },
                new DbType[1] { DbType.String }, ap);
        }

        #endregion
    }
}
