using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Common;

namespace Employees
{
    public static class DBHelper
    {
        private static string AppDatabaseName;

        static DBHelper()
        {
            //AppDatabaseName = System.Configuration.ConfigurationSettings.AppSettings["ConnStr"];
        }

        public static Database GetDatabase(string dbName)
        {
            try
            {
                Database db = null;
                if (dbName == null)
                {
                    return db = DatabaseFactory.CreateDatabase();
                }
                else
                {
                    return db = DatabaseFactory.CreateDatabase(dbName);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
