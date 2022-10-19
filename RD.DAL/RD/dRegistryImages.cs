using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using RD.EL;

namespace RD.DAL
{
    public class dRegistryImages : DataBaseHelper
    {
         DbCommand oCmd;
        IDataReader oDReader;
        public dRegistryImages()
        {

        }

        public override void InitializeAccessors()
        {

        }

        public List<eRegistryImages> getRegistryImages(string sortExpression, string condition, long startRowIndex, int pageSize, ref long totalRecord)
        {
            string storProc = StoreProcedures.proc_GetRegistryImages;
            oCmd = Db.GetStoredProcCommand(storProc);
            Db.AddInParameter(oCmd, "@sort_expression", DbType.String, sortExpression);
            Db.AddInParameter(oCmd, "@condition", DbType.String, condition);
            Db.AddInParameter(oCmd, "@start_row_index", DbType.Int64, startRowIndex);
            Db.AddInParameter(oCmd, "@page_size", DbType.Int32, pageSize);
            Db.AddOutParameter(oCmd, "@total_records", DbType.Int64, -1);
            oDReader = Db.ExecuteReader(oCmd);
            List<eRegistryImages> oeListRegistryImages = new List<eRegistryImages>();
            
            while (oDReader.Read())
            {
                eRegistryImages oeRegistryImages = new eRegistryImages();
                oeRegistryImages.RegistryImages_id = ValidateFields.GetSafeGuid(oDReader["registryImages_id"].ToString());
                oeRegistryImages.Registry_id = ValidateFields.GetSafeGuid(oDReader["registry_id"].ToString());
                oeRegistryImages.Transaction_id = ValidateFields.GetSafeGuid(oDReader["transaction_id"].ToString());
                oeRegistryImages.Imagetype_id = ValidateFields.GetSafeString(oDReader["imagetype_id"].ToString());
                //oeRegistryImages.Image_file = ValidateFields.GetSafeByte(oDReader["image_file"].ToString());
                if (oDReader["image_file"] != DBNull.Value)
                    oeRegistryImages.Image_file = (byte[])oDReader["image_file"];
                oeRegistryImages.Image_file_path = ValidateFields.GetSafeString(oDReader["image_file_path"].ToString());

                oeRegistryImages.User_id = ValidateFields.GetSafeGuid(oDReader["user_id"].ToString());
                oeRegistryImages.Access_datetime = ValidateFields.GetSafeDateTime(oDReader["access_datetime"].ToString());
                //byte[] data = (byte[])oDReader["time_stamp"];
                //oeRegistryImages.Time_stamp = data;

                oeListRegistryImages.Add(oeRegistryImages);
            }
            totalRecord = oeListRegistryImages.Count;

            return oeListRegistryImages;
        }
       
        public updatedNewEntryInfo insertRegistryImages(eRegistryImages oeRegistryImages)
        {
            string storProc = StoreProcedures.proc_InsertRegistryImages;
            int effectRow = 0;
            updatedNewEntryInfo insertInfo = new updatedNewEntryInfo();
            if (oeRegistryImages != null)
            {
                using (oCmd = Db.GetStoredProcCommand(storProc))
                {
                    try
                    {
                        Db.AddInParameter(oCmd, "@RegistryImages_id", DbType.Guid, oeRegistryImages.RegistryImages_id);
                        Db.AddInParameter(oCmd, "@Registry_id", DbType.Guid, oeRegistryImages.Registry_id);
                        Db.AddInParameter(oCmd, "@transaction_id", DbType.Guid, oeRegistryImages.Transaction_id);
                        Db.AddInParameter(oCmd, "@imagetype_id", DbType.String, oeRegistryImages.Imagetype_id);
                        Db.AddInParameter(oCmd, "@image_file", DbType.Binary, oeRegistryImages.Image_file);
                        Db.AddInParameter(oCmd, "@image_file_path", DbType.String, oeRegistryImages.Image_file_path);

                        Db.AddInParameter(oCmd, "@user_id", DbType.Guid, oeRegistryImages.User_id);
                        Db.AddInParameter(oCmd, "@access_datetime", DbType.DateTime, oeRegistryImages.Access_datetime);
                        effectRow = Db.ExecuteNonQuery(oCmd);
                        if (effectRow != 0)
                        {
                            insertInfo.Id = oeRegistryImages.RegistryImages_id;
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

        public updatedNewEntryInfo deleteRegistryImages(eRegistryImages oeRegistryImages)
        {
            string storProc = StoreProcedures.proc_DeleteRegistryImages;
            updatedNewEntryInfo deleteInfo = new updatedNewEntryInfo();
            int effectRow = 0;
            using (oCmd = Db.GetStoredProcCommand(storProc))
            {
                try
                {
                    Db.AddInParameter(oCmd, "@RegistryImages_id", DbType.Guid, oeRegistryImages.RegistryImages_id);
                    effectRow = Db.ExecuteNonQuery(oCmd);
                    if (effectRow != 0)
                    {
                        deleteInfo.Id = oeRegistryImages.RegistryImages_id;
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

        public updatedNewEntryInfo updateRegistryImages(eRegistryImages oeRegistryImages)
        {
            string storProc = StoreProcedures.proc_UpdateRegistryImages;
            updatedNewEntryInfo updateInfo = new updatedNewEntryInfo();
            int effectRow = 0;
            if (oeRegistryImages != null)
            {
                using (oCmd = Db.GetStoredProcCommand(storProc))
                {
                    try
                    {
                        Db.AddInParameter(oCmd, "@RegistryImages_id", DbType.Guid, oeRegistryImages.RegistryImages_id);
                        Db.AddInParameter(oCmd, "@Registry_id", DbType.Guid, oeRegistryImages.Registry_id);
                        Db.AddInParameter(oCmd, "@transaction_id", DbType.Guid, oeRegistryImages.Transaction_id);
                        Db.AddInParameter(oCmd, "@imagetype_id", DbType.String, oeRegistryImages.Imagetype_id);
                        Db.AddInParameter(oCmd, "@image_file", DbType.Binary, oeRegistryImages.Image_file);
                        Db.AddInParameter(oCmd, "@image_file_path", DbType.String, oeRegistryImages.Image_file_path);

                        Db.AddInParameter(oCmd, "@user_id", DbType.Guid, oeRegistryImages.User_id);
                        Db.AddInParameter(oCmd, "@access_datetime", DbType.DateTime, oeRegistryImages.Access_datetime);
                        effectRow = Db.ExecuteNonQuery(oCmd);
                        if (effectRow != 0)
                        {
                            updateInfo.Id = oeRegistryImages.RegistryImages_id;
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
