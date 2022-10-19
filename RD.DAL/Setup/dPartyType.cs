using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using RD.EL;

namespace RD.DAL
{
    public class dPartyType : DataBaseHelper
    {
        DbCommand oCmd;
        IDataReader oDReader;
        public dPartyType()
        {

        }

        public override void InitializeAccessors()
        {

        }

        public List<ePartyType> getPartyType(string sortExpression, string condition, long startRowIndex, int pageSize, ref long totalRecord)
        {
            string storProc = StoreProcedures.proc_GetPartyType;
            oCmd = Db.GetStoredProcCommand(storProc);
            Db.AddInParameter(oCmd, "@sort_expression", DbType.String, sortExpression);
            Db.AddInParameter(oCmd, "@condition", DbType.String, condition);
            Db.AddInParameter(oCmd, "@start_row_index", DbType.Int64, startRowIndex);
            Db.AddInParameter(oCmd, "@page_size", DbType.Int32, pageSize);
            Db.AddOutParameter(oCmd, "@total_records", DbType.Int64, -1);
            oDReader = Db.ExecuteReader(oCmd);
            List<ePartyType> oeListPartyType = new List<ePartyType>();
            
            while (oDReader.Read())
            {
                ePartyType oePartyType = new ePartyType();
                oePartyType.Party_type_id = ValidateFields.GetSafeGuid(oDReader["party_type_id"].ToString());
                oePartyType.Registry_type_id = ValidateFields.GetSafeGuid(oDReader["registry_type_id"].ToString());
                oePartyType.Party_name_eng = ValidateFields.GetSafeString(oDReader["party_name_eng"].ToString());
                oePartyType.Party_name_urd = ValidateFields.GetSafeString(oDReader["party_name_urd"].ToString());
                oePartyType.User_id = ValidateFields.GetSafeGuid(oDReader["user_id"].ToString());
                oePartyType.Access_date_time = ValidateFields.GetSafeDateTime(oDReader["access_date_time"].ToString());
                oeListPartyType.Add(oePartyType);
            }
            totalRecord = oeListPartyType.Count;

            return oeListPartyType;
        }

        public updatedNewEntryInfo insertPartyType(ePartyType oePartyType)
        {
            string storProc = StoreProcedures.proc_InsertPartyType;
            int effectRow = 0;
            updatedNewEntryInfo insertInfo = new updatedNewEntryInfo();
            if (oePartyType != null)
            {
                using (oCmd = Db.GetStoredProcCommand(storProc))
                {
                    try
                    {
                        Db.AddInParameter(oCmd, "@party_type_id", DbType.Guid, oePartyType.Party_type_id);
                        Db.AddInParameter(oCmd, "@Registry_type_id", DbType.Guid, oePartyType.Registry_type_id);
                        Db.AddInParameter(oCmd, "@party_name_eng", DbType.String, oePartyType.Party_name_eng);
                        Db.AddInParameter(oCmd, "@party_name_urd", DbType.String, oePartyType.Party_name_urd);
                        Db.AddInParameter(oCmd, "@user_id", DbType.Guid, oePartyType.User_id);
                        Db.AddInParameter(oCmd, "@access_date_time", DbType.DateTime, oePartyType.Access_date_time);
                        effectRow = Db.ExecuteNonQuery(oCmd);
                        if (effectRow != 0)
                        {
                            insertInfo.Id = oePartyType.Party_type_id;
                            insertInfo.Success = true;
                        }
                        else
                        {
                            insertInfo.Success = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        insertInfo.Exception = ex.Message;
                    }
                }
            }
            return insertInfo;
        }

        public updatedNewEntryInfo deletePartyType(Guid? partyTypeId)
        {
            string storProc = StoreProcedures.proc_DeletePartyType;
            updatedNewEntryInfo deleteInfo = new updatedNewEntryInfo();
            int effectRow = 0;
            using (oCmd = Db.GetStoredProcCommand(storProc))
            {
                try
                {
                    Db.AddInParameter(oCmd, "@party_type_id", DbType.Guid, partyTypeId);
                    effectRow = Db.ExecuteNonQuery(oCmd);
                    if (effectRow != 0)
                    {
                        deleteInfo.Id = partyTypeId;
                        deleteInfo.Success = true;
                    }
                    else
                    {
                        deleteInfo.Success = false;
                    }
                }
                catch (Exception ex)
                {
                    deleteInfo.Exception = ex.Message;
                }
            }
            return deleteInfo;
        }

        public updatedNewEntryInfo updatePartyType(ePartyType oePartyType)
        {
            string storProc = StoreProcedures.proc_UpdatePartyType;
            updatedNewEntryInfo updateInfo = new updatedNewEntryInfo();
            int effectRow = 0;
            if (oePartyType != null)
            {
                using (oCmd = Db.GetStoredProcCommand(storProc))
                {
                    try
                    {
                        Db.AddInParameter(oCmd, "@party_type_id", DbType.Guid, oePartyType.Party_type_id);
                        Db.AddInParameter(oCmd, "@Registry_type_id", DbType.Guid, oePartyType.Registry_type_id);
                        Db.AddInParameter(oCmd, "@party_name_eng", DbType.String, oePartyType.Party_name_eng);
                        Db.AddInParameter(oCmd, "@party_name_urd", DbType.String, oePartyType.Party_name_urd);
                        Db.AddInParameter(oCmd, "@user_id", DbType.Guid, oePartyType.User_id);
                        Db.AddInParameter(oCmd, "@access_date_time", DbType.DateTime, oePartyType.Access_date_time);
                        effectRow = Db.ExecuteNonQuery(oCmd);
                        if (effectRow != 0)
                        {
                            updateInfo.Id = oePartyType.Registry_type_id;
                            updateInfo.Success = true;
                        }
                        else
                        {
                            updateInfo.Success = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        updateInfo.Exception = ex.Message;
                    }
                }
            }
            return updateInfo;
        }
    }
}
