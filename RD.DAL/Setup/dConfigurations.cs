using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using RD.EL;

namespace RD.DAL
{
    public class dConfigurations : DataBaseHelper
    {
        DbCommand oCmd;
        IDataReader oDReader;
        public dConfigurations()
        {

        }

        public override void InitializeAccessors()
        {

        }

        public List<eConfigurations> getConfigurations(string sortExpression, string condition, long startRowIndex, int pageSize, ref long totalRecord)
        {
            string storProc = StoreProcedures.proc_GetConfigurations;
            oCmd = Db.GetStoredProcCommand(storProc);
            Db.AddInParameter(oCmd, "@sort_expression", DbType.String, sortExpression);
            Db.AddInParameter(oCmd, "@condition", DbType.String, condition);
            Db.AddInParameter(oCmd, "@start_row_index", DbType.Int64, startRowIndex);
            Db.AddInParameter(oCmd, "@page_size", DbType.Int32, pageSize);
            Db.AddOutParameter(oCmd, "@total_records", DbType.Int64, -1);
            oDReader = Db.ExecuteReader(oCmd);
            List<eConfigurations> oeListConfigurations = new List<eConfigurations>();
            
            while (oDReader.Read())
            {
                eConfigurations oeConfigurations = new eConfigurations();
                oeConfigurations.Config_id = ValidateFields.GetSafeInteger(oDReader["config_id"].ToString());
                oeConfigurations.Config_key = ValidateFields.GetSafeString(oDReader["config_key"].ToString());
                oeConfigurations.Config_value = ValidateFields.GetSafeString(oDReader["config_value"].ToString());
                oeListConfigurations.Add(oeConfigurations);
            }
            totalRecord = oeListConfigurations.Count;

            return oeListConfigurations;
        }

        public updatedNewEntryInfo insertConfigurations(eConfigurations oeConfigurations)
        {
            string storProc = StoreProcedures.proc_InsertConfigurations;
            int effectRow = -1;
            updatedNewEntryInfo insertInfo = new updatedNewEntryInfo();
            if (oeConfigurations != null)
            {
                using (oCmd = Db.GetStoredProcCommand(storProc))
                {
                    try
                    {
                        Db.AddInParameter(oCmd, "@config_key", DbType.String, oeConfigurations.Config_key);
                        Db.AddInParameter(oCmd, "@config_value", DbType.String, oeConfigurations.Config_value);
                        effectRow = Db.ExecuteNonQuery(oCmd);
                        if (effectRow > 0)
                        {
                            //insertInfo.Id = oeConfigurations.Party_type_id;
                            insertInfo.Success = true;
                        }
                        else
                        {
                            insertInfo.Success = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            return insertInfo;
        }

        public updatedNewEntryInfo deleteConfigurations(Int32? ConfigurationsId)
        {
            string storProc = StoreProcedures.proc_DeleteConfigurations;
            updatedNewEntryInfo deleteInfo = new updatedNewEntryInfo();
            int effectRow = -1;
            using (oCmd = Db.GetStoredProcCommand(storProc))
            {
                try
                {
                    Db.AddInParameter(oCmd, "@config_id", DbType.Int32, ConfigurationsId);
                    effectRow = Db.ExecuteNonQuery(oCmd);
                    if (effectRow > 0)
                    {
                        //deleteInfo.Id = ConfigurationsId;
                        deleteInfo.Success = true;
                    }
                    else
                    {
                        deleteInfo.Success = false;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return deleteInfo;
        }

        public updatedNewEntryInfo updateConfigurations(eConfigurations oeConfigurations)
        {
            string storProc = StoreProcedures.proc_UpdateConfigurations;
            updatedNewEntryInfo updateInfo = new updatedNewEntryInfo();
            int effectRow = -1;
            if (oeConfigurations != null)
            {
                using (oCmd = Db.GetStoredProcCommand(storProc))
                {
                    try
                    {
                        Db.AddInParameter(oCmd, "@config_id", DbType.Int32, oeConfigurations.Config_id);
                        Db.AddInParameter(oCmd, "@config_key", DbType.String, oeConfigurations.Config_key);
                        Db.AddInParameter(oCmd, "@config_value", DbType.String, oeConfigurations.Config_value);
                        effectRow = Db.ExecuteNonQuery(oCmd);
                        if (effectRow > 0)
                        {
                            //updateInfo.Id = oeConfigurations.Config_id;
                            updateInfo.Success = true;
                        }
                        else
                        {
                            updateInfo.Success = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            return updateInfo;
        }
    }
}
