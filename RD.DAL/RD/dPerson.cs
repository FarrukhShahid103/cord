using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using RD.EL;

namespace RD.DAL
{
    public class dPerson : DataBaseHelper
    {
        DbCommand oCmd;
        IDataReader oDReader;
        public dPerson()
        {

        }

        public override void InitializeAccessors()
        {

        }

        public List<ePerson> getPerson(string sortExpression, string condition, long startRowIndex, int pageSize, ref long totalRecord)
        {
            string storProc = StoreProcedures.Proc_GetPerson;
            oCmd = Db.GetStoredProcCommand(storProc);
            Db.AddInParameter(oCmd, "@sort_expression", DbType.String, sortExpression);
            Db.AddInParameter(oCmd, "@condition", DbType.String, condition);
            Db.AddInParameter(oCmd, "@start_row_index", DbType.Int64, startRowIndex);
            Db.AddInParameter(oCmd, "@page_size", DbType.Int32, pageSize);
            Db.AddOutParameter(oCmd, "@total_records", DbType.Int64, -1);
            oDReader = Db.ExecuteReader(oCmd);
            List<ePerson> oeListPerson = new List<ePerson>();

            while (oDReader.Read())
            {
                ePerson oePerson = new ePerson();
                oePerson.Person_id = ValidateFields.GetSafeGuid(oDReader["Person_id"].ToString());
                oePerson.Mauza_id = ValidateFields.GetSafeGuid(oDReader["mauza_id"].ToString());
                oePerson.First_name_eng = ValidateFields.GetSafeString(oDReader["first_name_eng"].ToString());
                oePerson.Last_name_eng = ValidateFields.GetSafeString(oDReader["last_name_eng"].ToString());
                oePerson.Address_eng = ValidateFields.GetSafeString(oDReader["address_eng"].ToString());
                oePerson.First_name_urd = ValidateFields.GetSafeString(oDReader["first_name_urd"].ToString());
                oePerson.Last_name_urd = ValidateFields.GetSafeString(oDReader["last_name_urd"].ToString());
                oePerson.Address_urd = ValidateFields.GetSafeString(oDReader["address_urd"].ToString());
                oePerson.Nic = ValidateFields.GetSafeString(oDReader["nic"].ToString());
                oePerson.Caste_id = ValidateFields.GetSafeGuid(oDReader["caste_id"].ToString());
                oePerson.Relation_id = ValidateFields.GetSafeInteger(oDReader["relation_id"].ToString());
                oePerson.Is_govt = ValidateFields.GetSafeBoolean(oDReader["is_govt"].ToString());
                oePerson.Is_department = ValidateFields.GetSafeBoolean(oDReader["is_department"].ToString());
                oePerson.Is_kashmiri = ValidateFields.GetSafeBoolean(oDReader["is_kashmiri"].ToString());
                oePerson.Is_active = ValidateFields.GetSafeBoolean(oDReader["is_active"].ToString());
                //oePerson.Thumb = ValidateFields.GetSafeByte(oDReader["thumb"].ToString());
                if (oDReader["thumb"] != DBNull.Value)
                    oePerson.Thumb = (byte[])oDReader["thumb"];
                oePerson.Pic_path = ValidateFields.GetSafeString(oDReader["pic_path"].ToString());
                if (oDReader["person_pic"] != DBNull.Value)
                    oePerson.Person_pic = (byte[])oDReader["person_pic"];
                oePerson.Is_blocked = ValidateFields.GetSafeBoolean(oDReader["is_blocked"].ToString());
                oePerson.Block_detail = ValidateFields.GetSafeString(oDReader["block_detail"].ToString());
                oePerson.User_id = ValidateFields.GetSafeGuid(oDReader["user_id"].ToString());
                oePerson.Access_date_time = ValidateFields.GetSafeDateTime(oDReader["access_date_time"].ToString());
                byte[] data = (byte[])oDReader["time_stamp"];
                oePerson.Time_stamp = data;

                oeListPerson.Add(oePerson);
            }
            totalRecord = oeListPerson.Count;

            return oeListPerson;
        }

        public updatedNewEntryInfo insertPerson(ePerson oePerson)
        {
            string storProc = StoreProcedures.proc_InsertPerson;
            int effectRow = 0;
            updatedNewEntryInfo insertInfo = new updatedNewEntryInfo();
            if (oePerson != null)
            {
                using (oCmd = Db.GetStoredProcCommand(storProc))
                {
                    try
                    {
                        Db.AddInParameter(oCmd, "@person_id", DbType.Guid, oePerson.Person_id);
                        Db.AddInParameter(oCmd, "@mauza_id", DbType.Guid, oePerson.Mauza_id);
                        Db.AddInParameter(oCmd, "@first_name_eng", DbType.String, oePerson.First_name_eng);
                        Db.AddInParameter(oCmd, "@last_name_eng", DbType.String, oePerson.Last_name_eng);
                        Db.AddInParameter(oCmd, "@address_eng", DbType.String, oePerson.Address_eng);
                        Db.AddInParameter(oCmd, "@first_name_urd", DbType.String, oePerson.First_name_urd);
                        Db.AddInParameter(oCmd, "@last_name_urd", DbType.String, oePerson.Last_name_urd);
                        Db.AddInParameter(oCmd, "@address_urd", DbType.String, oePerson.Address_urd);
                        Db.AddInParameter(oCmd, "@nic", DbType.String, oePerson.Nic);
                        Db.AddInParameter(oCmd, "@caste_id", DbType.Guid, oePerson.Caste_id);
                        Db.AddInParameter(oCmd, "@relation_id", DbType.Int32, oePerson.Relation_id);
                        Db.AddInParameter(oCmd, "@is_govt", DbType.Boolean, oePerson.Is_govt);
                        Db.AddInParameter(oCmd, "@is_department", DbType.Boolean, oePerson.Is_department);
                        Db.AddInParameter(oCmd, "@is_kashmiri", DbType.Boolean, oePerson.Is_kashmiri);
                        Db.AddInParameter(oCmd, "@is_active", DbType.Boolean, oePerson.Is_active);
                        Db.AddInParameter(oCmd, "@thumb", DbType.Binary, oePerson.Thumb);
                        Db.AddInParameter(oCmd, "@pic_path", DbType.String, oePerson.Pic_path);
                        Db.AddInParameter(oCmd, "@person_pic", DbType.Binary, oePerson.Person_pic);
                        Db.AddInParameter(oCmd, "@is_blocked", DbType.Boolean, oePerson.Is_blocked);
                        Db.AddInParameter(oCmd, "@block_detail", DbType.String, oePerson.Block_detail);
                        Db.AddInParameter(oCmd, "@user_id", DbType.Guid, oePerson.User_id);
                        Db.AddInParameter(oCmd, "@access_date_time", DbType.DateTime, oePerson.Access_date_time);
                        effectRow = Db.ExecuteNonQuery(oCmd);
                        if (effectRow != 0)
                        {
                            insertInfo.Id = oePerson.Person_id;
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

        public updatedNewEntryInfo insertPersonPicByPersonId(ePerson oePerson)
        {
            string storProc = StoreProcedures.proc_InsertPersonPicByPersonId;
            int effectRow = 0;
            updatedNewEntryInfo insertInfo = new updatedNewEntryInfo();
            if (oePerson != null)
            {
                using (oCmd = Db.GetStoredProcCommand(storProc))
                {
                    try
                    {
                        Db.AddInParameter(oCmd, "@person_id", DbType.Guid, oePerson.Person_id);
                        Db.AddInParameter(oCmd, "@pic_path", DbType.String, oePerson.Pic_path);
                        Db.AddInParameter(oCmd, "@person_pic", DbType.Binary, oePerson.Person_pic);
                        Db.AddInParameter(oCmd, "@access_date_time", DbType.DateTime, oePerson.Access_date_time);
                        effectRow = Db.ExecuteNonQuery(oCmd);
                        if (effectRow != 0)
                        {
                            insertInfo.Id = oePerson.Person_id;
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

        public updatedNewEntryInfo deletePerson(Guid? PersonId)
        {
            string storProc = "";
            updatedNewEntryInfo deleteInfo = new updatedNewEntryInfo();
            int effectRow = -1;
            using (oCmd = Db.GetStoredProcCommand(storProc))
            {
                try
                {
                    Db.AddInParameter(oCmd, "@person_id", DbType.Guid, PersonId);
                    effectRow = Db.ExecuteNonQuery(oCmd);
                    if (effectRow > 0)
                    {
                        deleteInfo.Id = PersonId;
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

        public updatedNewEntryInfo updatePerson(ePerson oePerson, bool isEnglish)
        {
            string storProc = StoreProcedures.proc_UpdatePerson;
            updatedNewEntryInfo updateInfo = new updatedNewEntryInfo();
            int effectRow = 0;
            if (oePerson != null)
            {
                using (oCmd = Db.GetStoredProcCommand(storProc))
                {
                    try
                    {
                        Db.AddInParameter(oCmd, "@person_id", DbType.Guid, oePerson.Person_id);
                        Db.AddInParameter(oCmd, "@mauza_id", DbType.Guid, oePerson.Mauza_id);
                        Db.AddInParameter(oCmd, "@first_name_eng", DbType.String, oePerson.First_name_eng);
                        Db.AddInParameter(oCmd, "@last_name_eng", DbType.String, oePerson.Last_name_eng);
                        Db.AddInParameter(oCmd, "@address_eng", DbType.String, oePerson.Address_eng);
                        Db.AddInParameter(oCmd, "@first_name_urd", DbType.String, oePerson.First_name_urd);
                        Db.AddInParameter(oCmd, "@last_name_urd", DbType.String, oePerson.Last_name_urd);
                        Db.AddInParameter(oCmd, "@address_urd", DbType.String, oePerson.Address_urd);
                        Db.AddInParameter(oCmd, "@nic", DbType.String, oePerson.Nic);
                        Db.AddInParameter(oCmd, "@caste_id", DbType.Guid, oePerson.Caste_id);
                        Db.AddInParameter(oCmd, "@relation_id", DbType.Int32, oePerson.Relation_id);
                        Db.AddInParameter(oCmd, "@is_govt", DbType.Boolean, oePerson.Is_govt);
                        Db.AddInParameter(oCmd, "@is_department", DbType.Boolean, oePerson.Is_department);
                        Db.AddInParameter(oCmd, "@is_kashmiri", DbType.Boolean, oePerson.Is_kashmiri);
                        Db.AddInParameter(oCmd, "@is_active", DbType.Boolean, oePerson.Is_active);
                        Db.AddInParameter(oCmd, "@thumb", DbType.Binary, oePerson.Thumb);
                        Db.AddInParameter(oCmd, "@pic_path", DbType.String, oePerson.Pic_path);
                        Db.AddInParameter(oCmd, "@person_pic", DbType.Binary, oePerson.Person_pic);
                        Db.AddInParameter(oCmd, "@is_blocked", DbType.Boolean, oePerson.Is_blocked);
                        Db.AddInParameter(oCmd, "@block_detail", DbType.String, oePerson.Block_detail);
                        Db.AddInParameter(oCmd, "@user_id", DbType.Guid, oePerson.User_id);
                        Db.AddInParameter(oCmd, "@access_date_time", DbType.DateTime, oePerson.Access_date_time);
                        Db.AddInParameter(oCmd, "@is_eng", DbType.Boolean, isEnglish);
                        effectRow = Db.ExecuteNonQuery(oCmd);
                        if (effectRow != 0)
                        {
                            updateInfo.Id = oePerson.Person_id;
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
                        throw ex;
                    }
                }
            }
            return updateInfo;
        }

        public updatedNewEntryInfo updatePersonPicByPersonId(ePerson oePerson, bool isEnglish)
        {
            string storProc = StoreProcedures.proc_UpdatePersonPicByPersonId;
            updatedNewEntryInfo updateInfo = new updatedNewEntryInfo();
            int effectRow = 0;
            if (oePerson != null)
            {
                using (oCmd = Db.GetStoredProcCommand(storProc))
                {
                    try
                    {
                        Db.AddInParameter(oCmd, "@person_id", DbType.Guid, oePerson.Person_id);
                        Db.AddInParameter(oCmd, "@pic_path", DbType.String, oePerson.Pic_path);
                        Db.AddInParameter(oCmd, "@person_pic", DbType.Binary, oePerson.Person_pic);
                        Db.AddInParameter(oCmd, "@access_date_time", DbType.DateTime, oePerson.Access_date_time);
                        effectRow = Db.ExecuteNonQuery(oCmd);
                        if (effectRow != 0)
                        {
                            updateInfo.Id = oePerson.Person_id;
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
                        throw ex;
                    }
                }
            }
            return updateInfo;
        }
    }
}
