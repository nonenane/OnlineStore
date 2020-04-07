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

        public async Task<DataTable> getCategory()
        {
            ap.Clear();
            ap.Add(true);

            DataTable dtResult = executeProcedure("[OnlineStore].[getDataComboForCategory]",
                 new string[1] { "@isCategory" },
                 new DbType[1] { DbType.Boolean }, ap);

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
    }
}
