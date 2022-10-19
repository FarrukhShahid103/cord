using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using RD.EL;

namespace RD.DAL
{
    public class dFard :DataBaseHelper
    {
        DbCommand oCmd;
        IDataReader oDReader;
        public dFard()
        {

        }

        public override void InitializeAccessors()
        {

        }

        public List<eFard> getFard(string sortExpression, string condition, long startRowIndex, int pageSize, ref long totalRecord)
        {
            string storProc = StoreProcedures.Proc_GetFard;
            oCmd = Db.GetStoredProcCommand(storProc);
            Db.AddInParameter(oCmd, "@sort_expression", DbType.String, sortExpression);
            Db.AddInParameter(oCmd, "@condition", DbType.String, condition);
            Db.AddInParameter(oCmd, "@start_row_index", DbType.Int64, startRowIndex);
            Db.AddInParameter(oCmd, "@page_size", DbType.Int32, pageSize);
            Db.AddOutParameter(oCmd, "@total_records", DbType.Int64, -1);
            oDReader = Db.ExecuteReader(oCmd);
            List<eFard> oeListFard = new List<eFard>();
            
            while (oDReader.Read())
            {
                eFard oeFard = new eFard();
                oeFard.Fard_id = ValidateFields.GetSafeGuid(oDReader["fard_id"].ToString());
                oeFard.Registry_id = ValidateFields.GetSafeGuid(oDReader["registry_id"].ToString());
                oeFard.Fard_no = ValidateFields.GetSafeString(oDReader["fard_no"].ToString());
                oeFard.Fard_objective = ValidateFields.GetSafeString(oDReader["fard_objective"].ToString());
                oeFard.Is_shamlat = ValidateFields.GetSafeBoolean(oDReader["is_shamlat"].ToString());
                oeFard.Total_fee = ValidateFields.GetSafeInteger(oDReader["total_fee"].ToString());
                oeFard.Fard_status = ValidateFields.GetSafeBoolean(oDReader["fard_status"].ToString());
                oeFard.Remarks = ValidateFields.GetSafeString(oDReader["remarks"].ToString());
                oeFard.Is_active = ValidateFields.GetSafeBoolean(oDReader["is_active"].ToString());
                oeFard.User_id = ValidateFields.GetSafeGuid(oDReader["user_id"].ToString());
                oeFard.Access_datetime = ValidateFields.GetSafeDateTime(oDReader["access_datetime"].ToString());
                //byte[] data = (byte[])oDReader["time_stamp"];
                //oeFard.Time_stamp = data;

                oeListFard.Add(oeFard);
            }
            totalRecord = oeListFard.Count;

            return oeListFard;
        }

        public updatedNewEntryInfo insertFard(eFard oeFard)
        {
            string storProc = StoreProcedures.proc_Insertfard;
            int effectRow = 0;
            updatedNewEntryInfo insertInfo = new updatedNewEntryInfo();
            if (oeFard != null)
            {
                using (oCmd = Db.GetStoredProcCommand(storProc))
                {
                    try
                    {
                        Db.AddInParameter(oCmd, "@fard_id", DbType.Guid, oeFard.Fard_id);
                        Db.AddInParameter(oCmd, "@registry_id", DbType.Guid, oeFard.Registry_id);
                        Db.AddInParameter(oCmd, "@fard_no", DbType.String, oeFard.Fard_no);
                        Db.AddInParameter(oCmd, "@fard_objective", DbType.String, oeFard.Fard_objective);
                        Db.AddInParameter(oCmd, "@is_shamlat", DbType.Int64, oeFard.Is_shamlat);
                        Db.AddInParameter(oCmd, "@total_fee", DbType.Int64, oeFard.Total_fee);
                        Db.AddInParameter(oCmd, "@fard_status", DbType.String, oeFard.Fard_status);
                        Db.AddInParameter(oCmd, "@remarks", DbType.String, oeFard.Remarks);
                        Db.AddInParameter(oCmd, "@is_active", DbType.Boolean, oeFard.Is_active);
                        Db.AddInParameter(oCmd, "@user_id", DbType.Guid, oeFard.User_id);
                        Db.AddInParameter(oCmd, "@access_datetime", DbType.DateTime, oeFard.Access_datetime);
                        effectRow = Db.ExecuteNonQuery(oCmd);
                        if (effectRow != 0)
                        {
                            insertInfo.Id = oeFard.Fard_id;
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

        public updatedNewEntryInfo deleteFard(eFard oeFard)
        {
            string storProc = StoreProcedures.proc_DeleteFard;
            updatedNewEntryInfo deleteInfo = new updatedNewEntryInfo();
            int effectRow = 0;
            using (oCmd = Db.GetStoredProcCommand(storProc))
            {
                try
                {
                    Db.AddInParameter(oCmd, "@fard_id", DbType.Guid, oeFard.Fard_id);
                    effectRow = Db.ExecuteNonQuery(oCmd);
                    if (effectRow != 0)
                    {
                        deleteInfo.Id = oeFard.Fard_id;
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

        public updatedNewEntryInfo updateFard(eFard oeFard)
        {
            string storProc = StoreProcedures.proc_Updatefard;
            updatedNewEntryInfo updateInfo = new updatedNewEntryInfo();
            int effectRow = 0;
            if (oeFard != null)
            {
                using (oCmd = Db.GetStoredProcCommand(storProc))
                {
                    try
                    {

                        Db.AddInParameter(oCmd, "@fard_id", DbType.Guid, oeFard.Fard_id);
                        Db.AddInParameter(oCmd, "@registry_id", DbType.Guid, oeFard.Registry_id);
                        Db.AddInParameter(oCmd, "@fard_no", DbType.String, oeFard.Fard_no);
                        Db.AddInParameter(oCmd, "@fard_objective", DbType.String, oeFard.Fard_objective);
                        Db.AddInParameter(oCmd, "@is_shamlat", DbType.Boolean, oeFard.Is_shamlat);
                        Db.AddInParameter(oCmd, "@total_fee", DbType.Int32, oeFard.Total_fee);
                        Db.AddInParameter(oCmd, "@fard_status", DbType.Boolean, oeFard.Fard_status);
                        Db.AddInParameter(oCmd, "@remarks", DbType.String, oeFard.Remarks);
                        Db.AddInParameter(oCmd, "@is_active", DbType.Boolean, oeFard.Is_active);
                        Db.AddInParameter(oCmd, "@user_id", DbType.Guid, oeFard.User_id);
                        Db.AddInParameter(oCmd, "@access_datetime", DbType.DateTime, oeFard.Access_datetime);
                        effectRow = Db.ExecuteNonQuery(oCmd);
                        if (effectRow != 0)
                        {
                            updateInfo.Id = oeFard.Fard_id;
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
