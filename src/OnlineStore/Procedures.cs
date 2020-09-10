using System.Text;
using System.Collections;
using Nwuram.Framework.Data;
using Nwuram.Framework.Settings.Connection;
using System.Data;
using System;
using Nwuram.Framework.Settings.User;
using System.Threading.Tasks;
using System.Threading;


namespace OnlineStore
{
    class Procedures : SqlProvider
    {
        public Procedures(string server, string database, string username, string password, string appName)
              : base(server, database, username, password, appName)
        {
        }
        ArrayList ap = new ArrayList();

        #region "Категории"

        public async Task<DataTable> getDicCategory()
        {
            ap.Clear();
            if (UserSettings.User.StatusCode.ToLower().Equals("ркв"))
                ap.Add(UserSettings.User.IdDepartment);
            else ap.Add(0);

            DataTable dtResult = executeProcedure("[OnlineStore].[getDicCategory]",
                 new string[1] { "@id_deps" },
                 new DbType[1] { DbType.Int32 }, ap);

            return dtResult;
        }

        public async Task<DataTable> getDicCategory(int? id)
        {
            ap.Clear();
            ap.Add(id);            

            DataTable dtResult = executeProcedure("[OnlineStore].[getDicCategory]",
                 new string[1] { "@id" },
                 new DbType[1] { DbType.Int32}, ap);

            return dtResult;
        }

        public async Task<DataTable> getDicCategoryParent()
        {
            ap.Clear();
            ap.Add(0);
            DataTable dtResult = executeProcedure("[OnlineStore].[getDicCategory]",
                 new string[1] { "@id_deps" },
                 new DbType[1] { DbType.Int32 }, ap);
            dtResult.DefaultView.RowFilter = " isParent = 1";
            return dtResult.DefaultView.ToTable();
        }



        public async Task<DataTable> validateDicCategory(int id,string cName)
        {
            ap.Clear();
            ap.Add(id);
            ap.Add(cName);

            DataTable dtResult = executeProcedure("[OnlineStore].[validateDicCategory]",
                 new string[2] { "@id","@cName" },
                 new DbType[2] { DbType.Int32,DbType.String }, ap);

            return dtResult;
        }

        public async Task<DataTable> validateDicCategory(int id)
        {
            ap.Clear();
            ap.Add(id);

            DataTable dtResult = executeProcedure("[OnlineStore].[validateDicCategory]",
                 new string[1] { "@id" },
                 new DbType[1] { DbType.Int32 }, ap);

            return dtResult;
        }

        public async Task<DataTable> delDicCategory(int id, bool isActive,int  result)
        {
            ap.Clear();
            ap.Add(id);
            ap.Add(isActive);
            ap.Add(false);
            ap.Add(result);
            ap.Add(UserSettings.User.Id);

            DataTable dtResult = executeProcedure("[OnlineStore].[setDicCategory]",
                 new string[5] { "@id", "@isActive", "@isAdd", "@result", "@id_user" },
                 new DbType[5] { DbType.Int32, DbType.Boolean, DbType.Boolean, DbType.Int32, DbType.Int32 }, ap);

            return dtResult;
        }

        public async Task<DataTable> getDeps()
        {
            ap.Clear();
            ap.Add(true);

            DataTable dtResult = executeProcedure("[OnlineStore].[getDataComboForCategory]",
                 new string[1] { "@isDep" },
                 new DbType[1] { DbType.Boolean }, ap);

            return dtResult;
        }

        public async Task<DataTable> getCategory(int id_deps)
        {
            ap.Clear();
            ap.Add(true);
            ap.Add(id_deps);

            //if (UserSettings.User.StatusCode.ToLower().Equals("ркв"))
            //    ap.Add(UserSettings.User.IdDepartment);
            //else ap.Add(0);

            DataTable dtResult = executeProcedure("[OnlineStore].[getDataComboForCategory]",
                 new string[2] { "@isCategory","@id_deps" },
                 new DbType[2] { DbType.Boolean,DbType.Int32 }, ap);

            return dtResult;
        }

        public async Task<DataTable> setDicCategory(int id, string cName, int id_dep, int? id_parentCategory, string pathImage, bool isUnload)
        {
            ap.Clear();
            ap.Add(id);
            ap.Add(cName);
            ap.Add(id_dep);
            ap.Add(id_parentCategory);
            ap.Add(true);
            ap.Add(true);            
            ap.Add(UserSettings.User.Id);
            ap.Add(pathImage);
            ap.Add(isUnload);

            DataTable dtResult = executeProcedure("[OnlineStore].[setDicCategory]",
                 new string[9] { "@id","@cName", "@id_dep", "@id_parentCategory", "@isActive", "@isAdd", "@id_user", "@pathImage","@isUnload" },
                 new DbType[9] { DbType.Int32, DbType.String, DbType.Int32, DbType.Int32, DbType.Boolean, DbType.Boolean, DbType.Int32, DbType.String,DbType.Boolean }, ap);

            return dtResult;
        }

        #endregion

        #region "Товары"

        public async Task<DataTable> getGoods(string ean)
        {
            ap.Clear();
            ap.Add(ean);
            if (UserSettings.User.StatusCode.ToLower().Equals("ркв"))
                ap.Add(UserSettings.User.IdDepartment);
            else ap.Add(0);

            DataTable dtResult = executeProcedure("[OnlineStore].[getGoods]",
                 new string[2] { "@ean", "@id_deps" },
                 new DbType[2] { DbType.String, DbType.Int32 }, ap);

            return dtResult;
        }

        public async Task<DataTable> getDicCategoryWithDep( int id_deps)
        {
            ap.Clear();
            ap.Add(id_deps);

            DataTable dtResult = executeProcedure("[OnlineStore].[getDicCategory]",
                 new string[1] { "@id_deps" },
                 new DbType[1] { DbType.Int32 }, ap);

            return dtResult;
        }

        public async Task<DataTable> validateDicGoods(int id, int id_tovar)
        {
            ap.Clear();
            ap.Add(id);
            ap.Add(id_tovar);

            DataTable dtResult = executeProcedure("[OnlineStore].[validateDicGoods]",
                 new string[2] { "@id", "@id_tovar" },
                 new DbType[2] { DbType.Int32, DbType.Int32 }, ap);

            return dtResult;
        }

        public async Task<DataTable> validateDicGoods(int id)
        {
            ap.Clear();
            ap.Add(id);

            DataTable dtResult = executeProcedure("[OnlineStore].[validateDicGoods]",
                 new string[1] { "@id" },
                 new DbType[1] { DbType.Int32 }, ap);

            return dtResult;
        }

        public async Task<DataTable> setDicGoods(int id,int id_tovar,string ShortName,  string FullName, int id_Category, decimal BasicPrice, decimal? StockPrice,bool isActive)
        {
            ap.Clear();
            ap.Add(id);
            ap.Add(id_tovar);
            ap.Add(ShortName);
            ap.Add(FullName);
            ap.Add(id_Category);
            ap.Add(BasicPrice);
            ap.Add(StockPrice);
            ap.Add(isActive);
            ap.Add(0);
            ap.Add(true);
            ap.Add(UserSettings.User.Id);

            DataTable dtResult = executeProcedure("[OnlineStore].[setDicGoods]",
                 new string[11] { "@id","@id_tovar", "@ShortName","@FullName", "@id_Category", "@BasicPrice", "@StockPrice", "@isActive","@isInsert", "@isAdd", "@id_user" },
                 new DbType[11] { DbType.Int32, DbType.Int32, DbType.String, DbType.String, DbType.Int32,DbType.Decimal,DbType.Decimal, DbType.Boolean,DbType.Int32, DbType.Boolean, DbType.Int32 }, ap);

            return dtResult;
        }

        public async Task<DataTable> delDicGoods(int id, bool isActive, int result)
        {
            ap.Clear();
            ap.Add(id);
            ap.Add(isActive);
            ap.Add(false);
            ap.Add(result);
            ap.Add(UserSettings.User.Id);

            DataTable dtResult = executeProcedure("[OnlineStore].[setDicGoods]",
                 new string[5] { "@id", "@isActive", "@isAdd", "@result", "@id_user" },
                 new DbType[5] { DbType.Int32, DbType.Boolean, DbType.Boolean, DbType.Int32, DbType.Int32 }, ap);

            return dtResult;
        }

        public async Task<DataTable> getInv(int id_deps)
        {
            ap.Clear();
            ap.Add(true);            
            ap.Add(id_deps);

            DataTable dtResult = executeProcedure("[OnlineStore].[getDataComboForCategory]",
                 new string[2] { "@isInv", "@id_deps" },
                 new DbType[2] { DbType.Boolean, DbType.Int32 }, ap);

            return dtResult;
        }

        public async Task<DataTable> getTU(int id_deps)
        {
            ap.Clear();
            ap.Add(true);
            ap.Add(id_deps);

            DataTable dtResult = executeProcedure("[OnlineStore].[getDataComboForCategory]",
                 new string[2] { "@isTu", "@id_deps" },
                 new DbType[2] { DbType.Boolean, DbType.Int32 }, ap);

            return dtResult;
        }

        public async Task<DataTable> getListGoods(int id_deps)
        {
            ap.Clear();
            //ap.Add(id_deps);
            if (UserSettings.User.StatusCode.ToLower().Equals("ркв"))
                ap.Add(UserSettings.User.IdDepartment);
            else ap.Add(0);


            DataTable dtResult = executeProcedure("[OnlineStore].[getListGoods]",
                 new string[1] { "@id_deps" },
                 new DbType[1] { DbType.Int32 }, ap);

            return dtResult;
        }


        public async Task<DataTable> setAttribute(int id, int id_Goods, decimal MinOrder, decimal MaxOrder, decimal Step, decimal DefaultNetto, string PriceSuffix,string QuantitySuffix)
        {
            ap.Clear();
            ap.Add(id);
            ap.Add(id_Goods);
            ap.Add(MinOrder);
            ap.Add(MaxOrder);
            ap.Add(Step);
            ap.Add(DefaultNetto);
            ap.Add(PriceSuffix);
            ap.Add(QuantitySuffix);
            ap.Add(UserSettings.User.Id);

            DataTable dtResult = executeProcedure("[OnlineStore].[setAttribute]",
                 new string[9] { "@id", "@id_Goods", "@MinOrder", "@MaxOrder", "@Step", "@DefaultNetto", "@PriceSuffix", "@QuantitySuffix", "@id_user" },
                 new DbType[9] { DbType.Int32, DbType.Int32, DbType.Decimal, DbType.Decimal, DbType.Decimal, DbType.Decimal, DbType.String, DbType.String, DbType.Int32 }, ap);

            return dtResult;
        }

        public async Task<DataTable> setInsertGoods(int id)
        {
            ap.Clear();
            ap.Add(id);
            ap.Add(UserSettings.User.Id);

            DataTable dtResult = executeProcedure("[OnlineStore].[setInsertGoods]",
                 new string[2] { "@id", "@id_user" },
                 new DbType[2] { DbType.Int32, DbType.Int32 }, ap);

            return dtResult;
        }

        public async Task<DataTable> UpdatePrice(string id_tovars)
        {
            ap.Clear();
            ap.Add(id_tovars);
            ap.Add(Nwuram.Framework.Settings.Connection.ConnectionSettings.GetIdProgram());
            ap.Add(UserSettings.User.Id);
            ap.Add(Config.isSale);
            return executeProcedure("[OnlineStore].[setGoodsOnlinePrice]",
                new string[] { "@id", "@id_prog","@id_user","@useSale" },
                new DbType[] { DbType.String, DbType.Int32, DbType.Int32, DbType.Boolean }, ap);
        }

        public async Task<DataTable> UpdatePrice (int id_dep)
        {
            ap.Clear();
            ap.Add(id_dep);
            ap.Add(ConnectionSettings.GetIdProgram());
            ap.Add(UserSettings.User.Id);
            ap.Add(Config.isSale);
            return executeProcedure("[OnlineStore].[setGoodsOnlinePrice]",
                new string[] { "@id_dep", "@id_prog","@id_user","@useSale" },
                new DbType[] { DbType.Int32, DbType.Int32,DbType.Int32, DbType.Boolean }, ap);
        }

        #endregion

        #region Настройки
        /// <summary>
        /// получение настройки использования распродажи
        /// </summary>
        /// <returns></returns>
        public DataTable getProgConfig()
        {
            ap.Clear();
            ap.Add(Nwuram.Framework.Settings.Connection.ConnectionSettings.GetIdProgram());

            return executeProcedure("OnlineStore.getConfig",
                new string[] { "@id_prog" },
                new DbType[] { DbType.Int32 }, ap);
        }
        /// <summary>
        /// запись настройки использования распродажи
        /// </summary>
        /// <param name="isSale"></param>
        /// <returns></returns>
        public DataTable setConfig(string isSale)
        {
            ap.Clear();
            ap.Add(Nwuram.Framework.Settings.Connection.ConnectionSettings.GetIdProgram());
            ap.Add(isSale);
            return executeProcedure("OnlineStore.setConfig",
                new string[] { "@id_prog", "@isSale" },
                new DbType[] { DbType.Int32, DbType.String }, ap);

        }
        
        public DataTable GetPercents()
        {
            ap.Clear();
            return executeProcedure("OnlineStore.getPercents", new string[] { }, new DbType[] { }, ap);
        }

        public DataTable SetPercents(int id_settings, decimal MarkUpP, decimal saleP)
        {
            ap.Clear();
            ap.Add(id_settings);
            ap.Add(MarkUpP);
            ap.Add(saleP);
            ap.Add(UserSettings.User.Id);
            return executeProcedure("OnlineStore.setPercents",
                new string[] { "@id", "@up", "@sale","@id_user" },
                new DbType[] { DbType.Int32, DbType.Decimal, DbType.Decimal, DbType.Int32 }, ap);
        }


     


        #endregion


        #region Добавление всех товаров

        public async Task<DataTable> GetInvGroup(int id_dep)
        {
            ap.Clear();
            ap.Add(id_dep);
            return executeProcedure("[OnlineStore].[getInvGroup]",
                new string[] { "@id_Dep" },
                new DbType[] { DbType.Int32 }, ap);
        }

        public async Task<DataTable> SetTovarByGroup(string id_groups, DateTime drealiz, decimal minOrder, decimal maxOrder, decimal step, decimal defaultNetto,
            string priceSuffix, string quantitySuffix, int id_dep)
        {
            ap.Clear();
            ap.Add(id_groups);
            ap.Add(drealiz);
            ap.Add(UserSettings.User.Id);
            ap.Add(minOrder);
            ap.Add(maxOrder);
            ap.Add(step);
            ap.Add(defaultNetto);
            ap.Add(priceSuffix);
            ap.Add(quantitySuffix);
            ap.Add(id_dep);
            return executeProcedure("[OnlineStore].[setGoodsByGroups]",
                new string[] { "@id_groups", "@drealiz", "@id_person", "@minOrder", "@maxOrder", "@step", "@defaultNetto", "@priceSuffix", "@quantitySuffix", "@id_department" },
                new DbType[] { DbType.String, DbType.DateTime, DbType.Int32, DbType.Decimal, DbType.Decimal, DbType.Decimal, DbType.Decimal, DbType.String, DbType.String, DbType.Int32 }, ap);
        }

        public async Task<DataTable> setAttributeGroup(string id_groups, object minOrder, object maxOrder, object step, object defaultNetto,
            object priceSuffix, object quantitySuffix)
        {
            ap.Clear();
            ap.Add(id_groups);
          
            ap.Add(UserSettings.User.Id);
            ap.Add(minOrder);
            ap.Add(maxOrder);
            ap.Add(step);
            ap.Add(defaultNetto);
            ap.Add(priceSuffix);
            ap.Add(quantitySuffix);
            return executeProcedure("[OnlineStore].[setAttributesGroup]",
                new string[] { "@id_groups", "@id_person", "@minOrder", "@maxOrder", "@step", "@defaultNetto", "@priceSuffix", "@quantitySuffix" },
                new DbType[] { DbType.String, DbType.Int32, DbType.Decimal, DbType.Decimal, DbType.Decimal, DbType.Decimal, DbType.String, DbType.String }, ap);
        }



        #endregion


        #region группы против категорий
        public DataTable GetCategoryVsGroup(int id_dep, int id_cat)
        {
            ap.Clear();
            ap.Add(id_dep);
            ap.Add(id_cat);
            return executeProcedure("[OnlineStore].[getCategoryVsGroup]",
                new string[] { "@id_Dep", "@id_Cat" },
                new DbType[] { DbType.Int32, DbType.Int32 }, ap);
        }

        public DataTable SetCategoryVsGroup(int id_category, int id_group)
        {
            ap.Clear();
            ap.Add(id_category);
            ap.Add(id_group);
            ap.Add(UserSettings.User.Id);
            return executeProcedure("[OnlineStore].[setCategoryVsGroup]",
                new string[] { "@id_category", "@id_grp", "@id_user" }, 
                new DbType[] {DbType.Int32, DbType.Int32, DbType.Int32 }, ap);
        
        }

       public async Task<DataTable> DelCategoryVsGroup (int id_category, int id_grp) 
        {
            ap.Clear();
            ap.Add(id_category);
            ap.Add(id_grp);
            return executeProcedure("[OnlineStore].[delCategoryVsGroup]",
                new string[] { "@id_category", "@id_grp" },
                new DbType[] { DbType.Int32, DbType.Int32 }, ap);
        }


       

        #endregion
    }
}
