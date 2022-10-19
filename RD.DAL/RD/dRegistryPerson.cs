using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using RD.EL;

namespace RD.DAL
{
    public class dRegistryPerson : DataBaseHelper
    {
        DbCommand oCmd;
        IDataReader oDReader;
        public dRegistryPerson()
        {

        }

        public override void InitializeAccessors()
        {

        }

        public List<eRegistryPerson> getRegistryPerson(string sortExpression, string condition, long startRowIndex, int pageSize, ref long totalRecord)
        {
            string storProc = StoreProcedures.Proc_GetRegistryPerson;
            oCmd = Db.GetStoredProcCommand(storProc);
            Db.AddInParameter(oCmd, "@sort_expression", DbType.String, sortExpression);
            Db.AddInParameter(oCmd, "@condition", DbType.String, condition);
            Db.AddInParameter(oCmd, "@start_row_index", DbType.Int64, startRowIndex);
            Db.AddInParameter(oCmd, "@page_size", DbType.Int32, pageSize);
            Db.AddOutParameter(oCmd, "@total_records", DbType.Int64, -1);
            oDReader = Db.ExecuteReader(oCmd);
            List<eRegistryPerson> oeListRegistryPerson = new List<eRegistryPerson>();
            
            while (oDReader.Read())
            {
                eRegistryPerson oeRegistryPerson = new eRegistryPerson();
                oeRegistryPerson.Registryperson_id = ValidateFields.GetSafeGuid(oDReader["registryperson_id"].ToString());
                oeRegistryPerson.Registry_id = ValidateFields.GetSafeGuid(oDReader["registry_id"].ToString());
                oeRegistryPerson.Person_id = ValidateFields.GetSafeGuid(oDReader["person_id"].ToString());
                oeRegistryPerson.Party_type_id = ValidateFields.GetSafeGuid(oDReader["party_type_id"].ToString());
                oeRegistryPerson.Party_name_eng = ValidateFields.GetSafeString(oDReader["party_name_eng"].ToString());
                oeRegistryPerson.Party_name_urd = ValidateFields.GetSafeString(oDReader["party_name_urd"].ToString());
                oeRegistryPerson.Total_area = ValidateFields.GetSafeInt64(oDReader["total_area"].ToString());
                oeRegistryPerson.Transferred_area = ValidateFields.GetSafeInt64(oDReader["transferred_area"].ToString());
                oeRegistryPerson.Total_share = ValidateFields.GetSafeString(oDReader["total_share"].ToString());
                oeRegistryPerson.Transferred_share = ValidateFields.GetSafeString(oDReader["transferred_share"].ToString());

                oeRegistryPerson.User_id = ValidateFields.GetSafeGuid(oDReader["user_id"].ToString());
                oeRegistryPerson.Access_datetime = ValidateFields.GetSafeDateTime(oDReader["access_datetime"].ToString());
                //byte[] data = (byte[])oDReader["time_stamp"];
                //oeRegistryPerson.Time_stamp = data;

                oeListRegistryPerson.Add(oeRegistryPerson);
            }
            totalRecord = oeListRegistryPerson.Count;

            return oeListRegistryPerson;
        }

        public List<ePersonWithRegistry> getPersonByRegistryId(string sortExpression, string condition, long startRowIndex, int pageSize, ref long totalRecord)
        {
            string storProc = StoreProcedures.Proc_GetPersonByRegistryid;
            oCmd = Db.GetStoredProcCommand(storProc);
            Db.AddInParameter(oCmd, "@sort_expression", DbType.String, sortExpression);
            Db.AddInParameter(oCmd, "@condition", DbType.String, condition);
            Db.AddInParameter(oCmd, "@start_row_index", DbType.Int64, startRowIndex);
            Db.AddInParameter(oCmd, "@page_size", DbType.Int32, pageSize);
            Db.AddOutParameter(oCmd, "@total_records", DbType.Int64, -1);
            oDReader = Db.ExecuteReader(oCmd);
            List<ePersonWithRegistry> oeListRegistryPerson = new List<ePersonWithRegistry>();

            while (oDReader.Read())
            {
                ePersonWithRegistry oeRegistryPerson = new ePersonWithRegistry();
                oeRegistryPerson.Registryperson_id = ValidateFields.GetSafeGuid(oDReader["registryperson_id"].ToString());
                oeRegistryPerson.Registry_id = ValidateFields.GetSafeGuid(oDReader["registry_id"].ToString());
                oeRegistryPerson.Person_id = ValidateFields.GetSafeGuid(oDReader["person_id"].ToString());
                oeRegistryPerson.Party_type_id = ValidateFields.GetSafeGuid(oDReader["party_type_id"].ToString());
                oeRegistryPerson.Party_name_eng = ValidateFields.GetSafeString(oDReader["party_name_eng"].ToString());
                oeRegistryPerson.Party_name_urd = ValidateFields.GetSafeString(oDReader["party_name_urd"].ToString());
                oeRegistryPerson.Total_area = ValidateFields.GetSafeInt64(oDReader["total_area"].ToString());
                oeRegistryPerson.Transferred_area = ValidateFields.GetSafeInt64(oDReader["transferred_area"].ToString());
                oeRegistryPerson.Total_share = ValidateFields.GetSafeString(oDReader["total_share"].ToString());
                oeRegistryPerson.Transferred_share = ValidateFields.GetSafeString(oDReader["transferred_share"].ToString());

                oeRegistryPerson.Mauza_id = ValidateFields.GetSafeGuid(oDReader["mauza_id"].ToString());
                oeRegistryPerson.First_name_eng = ValidateFields.GetSafeString(oDReader["first_name_eng"].ToString());
                oeRegistryPerson.Last_name_eng = ValidateFields.GetSafeString(oDReader["last_name_eng"].ToString());
                oeRegistryPerson.Address_eng = ValidateFields.GetSafeString(oDReader["address_eng"].ToString());
                oeRegistryPerson.First_name_urd = ValidateFields.GetSafeString(oDReader["first_name_urd"].ToString());
                oeRegistryPerson.Last_name_urd = ValidateFields.GetSafeString(oDReader["last_name_urd"].ToString());
                oeRegistryPerson.Address_urd = ValidateFields.GetSafeString(oDReader["address_urd"].ToString());
                oeRegistryPerson.Nic = ValidateFields.GetSafeString(oDReader["nic"].ToString());
                oeRegistryPerson.Caste_id = ValidateFields.GetSafeGuid(oDReader["caste_id"].ToString());
                oeRegistryPerson.Relation_id = ValidateFields.GetSafeInteger(oDReader["relation_id"].ToString());
                oeRegistryPerson.Is_govt = ValidateFields.GetSafeBoolean(oDReader["is_govt"].ToString());
                oeRegistryPerson.Is_department = ValidateFields.GetSafeBoolean(oDReader["is_department"].ToString());
                oeRegistryPerson.Is_kashmiri = ValidateFields.GetSafeBoolean(oDReader["is_kashmiri"].ToString());
                oeRegistryPerson.Is_active = ValidateFields.GetSafeBoolean(oDReader["is_active"].ToString());
                oeRegistryPerson.Thumb = ValidateFields.GetSafeByte(oDReader["thumb"].ToString());
                oeRegistryPerson.Pic_path = ValidateFields.GetSafeString(oDReader["pic_path"].ToString());
                if (oDReader["person_pic"] != DBNull.Value)
                    oeRegistryPerson.Person_pic = (byte[])oDReader["person_pic"];
                oeRegistryPerson.Is_blocked = ValidateFields.GetSafeBoolean(oDReader["is_blocked"].ToString());
                oeRegistryPerson.Block_detail = ValidateFields.GetSafeString(oDReader["block_detail"].ToString());

                oeRegistryPerson.User_id = ValidateFields.GetSafeGuid(oDReader["user_id"].ToString());
                oeRegistryPerson.Access_date_time = ValidateFields.GetSafeDateTime(oDReader["access_date_time"].ToString());
                //byte[] data = (byte[])oDReader["time_stamp"];
                //oeRegistryPerson.Time_stamp = data;

                oeListRegistryPerson.Add(oeRegistryPerson);
            }
            totalRecord = oeListRegistryPerson.Count;

            return oeListRegistryPerson;
        }

        public updatedNewEntryInfo insertRegistryPerson(eRegistryPerson oeRegistryPerson)
        {
            string storProc = StoreProcedures.proc_InsertRegistryPerson;
            int effectRow = 0;
            updatedNewEntryInfo insertInfo = new updatedNewEntryInfo();
            if (oeRegistryPerson != null)
            {
                using (oCmd = Db.GetStoredProcCommand(storProc))
                {
                    try
                    {
                        Db.AddInParameter(oCmd, "@RegistryPerson_id", DbType.Guid, oeRegistryPerson.Registryperson_id);
                        Db.AddInParameter(oCmd, "@Registry_id", DbType.Guid, oeRegistryPerson.Registry_id);
                        Db.AddInParameter(oCmd, "@Person_id", DbType.Guid, oeRegistryPerson.Person_id);
                        Db.AddInParameter(oCmd, "@party_type_id", DbType.Guid, oeRegistryPerson.Party_type_id);
                        //Db.AddInParameter(oCmd, "@party_name_eng", DbType.String, oeRegistryPerson.Party_name_eng);
                        //Db.AddInParameter(oCmd, "@party_name_urd", DbType.String, oeRegistryPerson.Party_name_urd);
                        Db.AddInParameter(oCmd, "@total_area", DbType.Int64, oeRegistryPerson.Total_area);
                        Db.AddInParameter(oCmd, "@transferred_area", DbType.Int64, oeRegistryPerson.Transferred_area);
                        Db.AddInParameter(oCmd, "@total_share", DbType.String, oeRegistryPerson.Total_share);
                        Db.AddInParameter(oCmd, "@transferred_share", DbType.String, oeRegistryPerson.Transferred_share);

                        Db.AddInParameter(oCmd, "@user_id", DbType.Guid, oeRegistryPerson.User_id);
                        Db.AddInParameter(oCmd, "@access_datetime", DbType.DateTime, oeRegistryPerson.Access_datetime);
                        effectRow = Db.ExecuteNonQuery(oCmd);
                        if (effectRow != 0)
                        {
                            insertInfo.Id = oeRegistryPerson.Registryperson_id;
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

        public updatedNewEntryInfo deleteRegistryPerson(eRegistryPerson oeRegistryPerson)
        {
            string storProc = StoreProcedures.proc_DeleteRegistryPerson;
            updatedNewEntryInfo deleteInfo = new updatedNewEntryInfo();
            int effectRow = 0;
            using (oCmd = Db.GetStoredProcCommand(storProc))
            {
                try
                {
                    Db.AddInParameter(oCmd, "@RegistryPerson_id", DbType.Guid, oeRegistryPerson.Registryperson_id);
                    effectRow = Db.ExecuteNonQuery(oCmd);
                    if (effectRow != 0)
                    {
                        deleteInfo.Id = oeRegistryPerson.Registryperson_id;
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

        public updatedNewEntryInfo updateRegistryPerson(eRegistryPerson oeRegistryPerson)
        {
            string storProc = StoreProcedures.proc_UpdateRegistryPerson;
            updatedNewEntryInfo updateInfo = new updatedNewEntryInfo();
            int effectRow = 0;
            if (oeRegistryPerson != null)
            {
                using (oCmd = Db.GetStoredProcCommand(storProc))
                {
                    try
                    {

                        Db.AddInParameter(oCmd, "@RegistryPerson_id", DbType.Guid, oeRegistryPerson.Registryperson_id);
                        Db.AddInParameter(oCmd, "@Registry_id", DbType.Guid, oeRegistryPerson.Registry_id);
                        Db.AddInParameter(oCmd, "@Person_id", DbType.Guid, oeRegistryPerson.Person_id);
                        Db.AddInParameter(oCmd, "@party_type_id", DbType.Guid, oeRegistryPerson.Party_type_id);
                        //Db.AddInParameter(oCmd, "@party_name_eng", DbType.String, oeRegistryPerson.Party_name_eng);
                        //Db.AddInParameter(oCmd, "@party_name_urd", DbType.String, oeRegistryPerson.Party_name_urd);
                        Db.AddInParameter(oCmd, "@total_area", DbType.Int64, oeRegistryPerson.Total_area);
                        Db.AddInParameter(oCmd, "@transferred_area", DbType.Int64, oeRegistryPerson.Transferred_area);
                        Db.AddInParameter(oCmd, "@total_share", DbType.String, oeRegistryPerson.Total_share);
                        Db.AddInParameter(oCmd, "@transferred_share", DbType.String, oeRegistryPerson.Transferred_share);

                        Db.AddInParameter(oCmd, "@user_id", DbType.Guid, oeRegistryPerson.User_id);
                        Db.AddInParameter(oCmd, "@access_datetime", DbType.DateTime, oeRegistryPerson.Access_datetime);
                        effectRow = Db.ExecuteNonQuery(oCmd);
                        if (effectRow != 0)
                        {
                            updateInfo.Id = oeRegistryPerson.Registryperson_id;
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
