using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Common;
using System.Data.Common;

namespace RD.DAL
{
    public abstract class DataBaseHelper
    {
        private string sConStr = "ConnStr";
        //private string sConStr;
        private Database db;

        protected Database Db
        {
            get
            {
                if (db == null)
                {
                    db = DatabaseFactory.CreateDatabase(sConStr);
                }
                return db;
            }
        }

        public abstract void InitializeAccessors();

        public DataBaseHelper()
        {

        }

        public DataBaseHelper(string dbString)
        {
            sConStr = dbString;
        }

        public Database GetDatabase()
        {
            try
            {
                db = null;
                return db = DatabaseFactory.CreateDatabase(sConStr);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
