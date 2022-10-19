using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using RD.EL;

namespace RD.DAL
{
    public class dKhasra : DataBaseHelper
    {
        DbCommand oCmd;
        IDataReader oDReader;
        public dKhasra()
        {

        }

        public override void InitializeAccessors()
        {

        }

        public List<eKhasra> getKhasra(string sortExpression, string condition, long startRowIndex, int pageSize, ref long totalRecord)
        {
            string storProc = StoreProcedures.Proc_GetKhasra;
            oCmd = Db.GetStoredProcCommand(storProc);
            Db.AddInParameter(oCmd, "@sort_expression", DbType.String, sortExpression);
            Db.AddInParameter(oCmd, "@condition", DbType.String, condition);
            Db.AddInParameter(oCmd, "@start_row_index", DbType.Int64, startRowIndex);
            Db.AddInParameter(oCmd, "@page_size", DbType.Int32, pageSize);
            Db.AddOutParameter(oCmd, "@total_records", DbType.Int64, -1);
            oDReader = Db.ExecuteReader(oCmd);
            List<eKhasra> oeListKhasra = new List<eKhasra>();
            
            while (oDReader.Read())
            {
                eKhasra oeKhasra = new eKhasra();
                oeKhasra.Khasra_id = ValidateFields.GetSafeGuid(oDReader["khasra_id"].ToString());
                oeKhasra.Khewat_no = ValidateFields.GetSafeString(oDReader["khewat_no"].ToString());
                oeKhasra.Khatuni_no = ValidateFields.GetSafeString(oDReader["khatuni_no"].ToString());
                oeKhasra.Khasra_no = ValidateFields.GetSafeString(oDReader["khasra_no"].ToString());
                oeKhasra.Khasra_total_area = ValidateFields.GetSafeLong(oDReader["khasra_total_area"].ToString());
                oeKhasra.Transferred_area = ValidateFields.GetSafeLong(oDReader["transferred_area"].ToString());
                oeKhasra.Khasra_total_share = ValidateFields.GetSafeString(oDReader["khasra_total_share"].ToString());
                oeKhasra.Transferred_share = ValidateFields.GetSafeString(oDReader["transferred_share"].ToString());
                oeKhasra.Print_sequence_no = ValidateFields.GetSafeInteger(oDReader["print_sequence_no"].ToString());
                oeKhasra.Is_active = ValidateFields.GetSafeBoolean(oDReader["is_active"].ToString());
                oeKhasra.East = ValidateFields.GetSafeString(oDReader["east"].ToString());
                oeKhasra.West = ValidateFields.GetSafeString(oDReader["west"].ToString());
                oeKhasra.North = ValidateFields.GetSafeString(oDReader["north"].ToString());
                oeKhasra.South = ValidateFields.GetSafeString(oDReader["south"].ToString());

                oeKhasra.User_id = ValidateFields.GetSafeGuid(oDReader["user_id"].ToString());
                oeKhasra.Access_date_time = ValidateFields.GetSafeDateTime(oDReader["access_date_time"].ToString());
                //byte[] data = (byte[])oDReader["time_stamp"];
                //oeKhasra.Time_stamp = data;

                oeListKhasra.Add(oeKhasra);
            }
            totalRecord = oeListKhasra.Count;

            return oeListKhasra;
        }

        public updatedNewEntryInfo insertKhasra(eKhasra oeKhasra)
        {
            string storProc = StoreProcedures.proc_InsertKhasra;
            int effectRow = 0;
            updatedNewEntryInfo insertInfo = new updatedNewEntryInfo();
            if (oeKhasra != null)
            {
                using (oCmd = Db.GetStoredProcCommand(storProc))
                {
                    try
                    {
                        Db.AddInParameter(oCmd, "@Registry_id", DbType.Guid, oeKhasra.Registry_id);
                        Db.AddInParameter(oCmd, "@Khasra_id", DbType.Guid, oeKhasra.Khasra_id);
                        Db.AddInParameter(oCmd, "@khewat_no", DbType.String, oeKhasra.Khewat_no);
                        Db.AddInParameter(oCmd, "@khatuni_no", DbType.String, oeKhasra.Khatuni_no);
                        Db.AddInParameter(oCmd, "@khasra_no", DbType.String, oeKhasra.Khasra_no);
                        Db.AddInParameter(oCmd, "@khasra_total_area", DbType.Int64, oeKhasra.Khasra_total_area);
                        Db.AddInParameter(oCmd, "@transferred_area", DbType.Int64, oeKhasra.Transferred_area);
                        Db.AddInParameter(oCmd, "@khasra_total_share", DbType.String, oeKhasra.Khasra_total_share);
                        Db.AddInParameter(oCmd, "@transferred_share", DbType.String, oeKhasra.Transferred_share);
                        Db.AddInParameter(oCmd, "@print_sequence_no", DbType.Int32, oeKhasra.Print_sequence_no);
                        Db.AddInParameter(oCmd, "@is_active", DbType.Boolean, oeKhasra.Is_active);
                        Db.AddInParameter(oCmd, "@east", DbType.String, oeKhasra.East);
                        Db.AddInParameter(oCmd, "@west", DbType.String, oeKhasra.West);
                        Db.AddInParameter(oCmd, "@north", DbType.String, oeKhasra.North);
                        Db.AddInParameter(oCmd, "@south", DbType.String, oeKhasra.South);

                        Db.AddInParameter(oCmd, "@user_id", DbType.Guid, oeKhasra.User_id);
                        Db.AddInParameter(oCmd, "@access_date_time", DbType.DateTime, oeKhasra.Access_date_time);
                        effectRow = Db.ExecuteNonQuery(oCmd);
                        if (effectRow != 0)
                        {
                            insertInfo.Id = oeKhasra.Khasra_id;
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

        public updatedNewEntryInfo deleteKhasra(eKhasra oeKhasra)
        {
            string storProc = StoreProcedures.proc_DeleteKhasra;
            updatedNewEntryInfo deleteInfo = new updatedNewEntryInfo();
            int effectRow = 0;
            using (oCmd = Db.GetStoredProcCommand(storProc))
            {
                try
                {
                    Db.AddInParameter(oCmd, "@khasra_id", DbType.Guid, oeKhasra.Khasra_id);
                    effectRow = Db.ExecuteNonQuery(oCmd);
                    if (effectRow != 0)
                    {
                        deleteInfo.Id = oeKhasra.Khasra_id;
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

        public updatedNewEntryInfo updateKhasra(eKhasra oeKhasra)
        {
            string storProc = StoreProcedures.proc_UpdateKhasra;
            updatedNewEntryInfo updateInfo = new updatedNewEntryInfo();
            int effectRow = 0;
            if (oeKhasra != null)
            {
                using (oCmd = Db.GetStoredProcCommand(storProc))
                {
                    try
                    {

                        Db.AddInParameter(oCmd, "@Khasra_id", DbType.Guid, oeKhasra.Khasra_id);
                        Db.AddInParameter(oCmd, "@registry_id", DbType.Guid, oeKhasra.Registry_id);
                        Db.AddInParameter(oCmd, "@khewat_no", DbType.String, oeKhasra.Khewat_no);
                        Db.AddInParameter(oCmd, "@khatuni_no", DbType.String, oeKhasra.Khatuni_no);
                        Db.AddInParameter(oCmd, "@khasra_no", DbType.String, oeKhasra.Khasra_no);
                        Db.AddInParameter(oCmd, "@khasra_total_area", DbType.Int64, oeKhasra.Khasra_total_area);
                        Db.AddInParameter(oCmd, "@transferred_area", DbType.Int64, oeKhasra.Transferred_area);
                        Db.AddInParameter(oCmd, "@khasra_total_share", DbType.String, oeKhasra.Khasra_total_share);
                        Db.AddInParameter(oCmd, "@transferred_share", DbType.String, oeKhasra.Transferred_share);
                        Db.AddInParameter(oCmd, "@print_sequence_no", DbType.Int32, oeKhasra.Print_sequence_no);
                        Db.AddInParameter(oCmd, "@is_active", DbType.Boolean, oeKhasra.Is_active);
                        Db.AddInParameter(oCmd, "@east", DbType.String, oeKhasra.East);
                        Db.AddInParameter(oCmd, "@west", DbType.String, oeKhasra.West);
                        Db.AddInParameter(oCmd, "@north", DbType.String, oeKhasra.North);
                        Db.AddInParameter(oCmd, "@south", DbType.String, oeKhasra.South);
                        Db.AddInParameter(oCmd, "@user_id", DbType.Guid, oeKhasra.User_id);
                        Db.AddInParameter(oCmd, "@access_date_time", DbType.DateTime, oeKhasra.Access_date_time);
                        effectRow = Db.ExecuteNonQuery(oCmd);
                        if (effectRow != 0)
                        {
                            updateInfo.Id = oeKhasra.Khasra_id;
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
