using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using RD.EL;
using System.Data.Common;
using System.Data;

namespace RD.DAL
{
    public class DRegistryLrmisSync : DataBaseHelper
    {
        DbCommand oCmd;
        IDataReader oDReader;
        public DRegistryLrmisSync()
        {
        
        }
        public DRegistryLrmisSync(string ConnectionStringName)
            : base(ConnectionStringName)
        {
           
        }

        public override void InitializeAccessors()
        {
            
        }
        public updatedNewEntryInfo InsertLrmisRegistrySync(eRegistryOperations oeRegistryOperations)
        {
            string storProc = StoreProcedures.proc_InsertLrmisRegistryInfo;
            int effectRow = 0;
            updatedNewEntryInfo insertInfo = new updatedNewEntryInfo();
            if (oeRegistryOperations != null)
            {
                using (oCmd = Db.GetStoredProcCommand(storProc))
                {
                    try
                    {
                        oeRegistryOperations.Registry_id = Guid.NewGuid();
                        Db.AddInParameter(oCmd, "@rdinfo_id", DbType.Guid, oeRegistryOperations.Registry_id);
                        Db.AddInParameter(oCmd, "@registery_no", DbType.String, oeRegistryOperations.Registry_no);
                        Db.AddInParameter(oCmd, "@bahi_no", DbType.Int16, ValidateFields.GetSafeInt64(oeRegistryOperations.Bahi_no));
                        Db.AddInParameter(oCmd, "@jild_no", DbType.Int32, ValidateFields.GetSafeInt64(oeRegistryOperations.Jild_no));
                        Db.AddInParameter(oCmd, "@user_id", DbType.Guid, oeRegistryOperations.User_id);
                        Db.AddInParameter(oCmd, "@RegistryDate", DbType.DateTime, oeRegistryOperations.Access_datetime);
                        Db.AddInParameter(oCmd, "@image_file", DbType.Binary, oeRegistryOperations.Image_file);
                        Db.AddInParameter(oCmd, "@registrytype", DbType.String, oeRegistryOperations.RegistryDescription);
                        effectRow = Db.ExecuteNonQuery(oCmd);
                        if (effectRow != 0)
                        {
                            insertInfo.Id = oeRegistryOperations.Registry_id;
                            insertInfo.Success = true;
                        }
                        else
                        {
                            insertInfo.Success = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        insertInfo.Exception = ex.Message.ToString();
                    }
                }
            }
            return insertInfo;
        }
    }
}
