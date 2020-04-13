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

        public async Task<DataTable> setDicCategory(int id,string cName, int id_dep, int? id_parentCategory)
        {
            ap.Clear();
            ap.Add(id);
            ap.Add(cName);
            ap.Add(id_dep);
            ap.Add(id_parentCategory);
            ap.Add(true);
            ap.Add(true);            
            ap.Add(UserSettings.User.Id);

            DataTable dtResult = executeProcedure("[OnlineStore].[setDicCategory]",
                 new string[7] { "@id","@cName", "@id_dep", "@id_parentCategory", "@isActive", "@isAdd", "@id_user" },
                 new DbType[7] { DbType.Int32, DbType.String, DbType.Int32, DbType.Int32, DbType.Boolean, DbType.Boolean, DbType.Int32 }, ap);

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

        #endregion


    }
}
