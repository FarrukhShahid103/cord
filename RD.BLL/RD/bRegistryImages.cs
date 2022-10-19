using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RD.DAL;
using RD.EL;

namespace RD.BLL
{
    public class bRegistryImages
    {
        private static long totalRecord = -1;
        dRegistryImages odRegistryImages;
        public List<eRegistryImages> getRegistryImages(eRegistryImages oeRegistryImages, string sortExpression, string condition, long startRowIndex, int pageSize)
        {
            condition = BuildCondition(oeRegistryImages);
            odRegistryImages = new dRegistryImages();
            List<eRegistryImages> oeListRegistryImages = new List<eRegistryImages>();
            oeListRegistryImages = odRegistryImages.getRegistryImages(sortExpression, condition, startRowIndex, pageSize, ref totalRecord);
            return oeListRegistryImages;
        }

        public updatedNewEntryInfo insertRegistryImages(eRegistryImages oeRegistryImages)
        {
            updatedNewEntryInfo insertInfo = new updatedNewEntryInfo();
            odRegistryImages = new dRegistryImages();
            insertInfo = odRegistryImages.insertRegistryImages(oeRegistryImages);
            return insertInfo;
        }

        public updatedNewEntryInfo updateRegistryImages(eRegistryImages oeRegistryImages)
        {
            updatedNewEntryInfo updateInfo = new updatedNewEntryInfo();
            odRegistryImages = new dRegistryImages();
            updateInfo = odRegistryImages.updateRegistryImages(oeRegistryImages);
            return updateInfo;
        }

        public updatedNewEntryInfo deleteRegistryImages(eRegistryImages oeRegistryImages)
        {
            updatedNewEntryInfo deleteInfo = new updatedNewEntryInfo();
            odRegistryImages = new dRegistryImages();
            deleteInfo = odRegistryImages.deleteRegistryImages(oeRegistryImages);
            return deleteInfo;
        }

        public static long GetRegistryImagesCount()
        {
            return totalRecord;
        }

        private string BuildCondition(eRegistryImages oeRegistryImages)
        {
            string result = "";

            if (oeRegistryImages.RegistryImages_id != Guid.Empty)
                result += (result == "" ? "" : " AND ") + "RegistryImages_id = '" + oeRegistryImages.RegistryImages_id + "'";
            if (oeRegistryImages.Registry_id != Guid.Empty)
                result += (result == "" ? "" : " AND ") + "registry_id = '" + oeRegistryImages.Registry_id + "'";
            if (oeRegistryImages.Imagetype_id != null && oeRegistryImages.Imagetype_id != string.Empty)
                result += (result == "" ? "" : " AND ") + "imagetype_id = '" + oeRegistryImages.Imagetype_id + "'";
            if (oeRegistryImages.Image_file != null)
                result += (result == "" ? "" : " AND ") + "image_file = '" + oeRegistryImages.Image_file + "'";
            if (oeRegistryImages.Image_file_path != null)
                result += (result == "" ? "" : " AND ") + "image_file_path = '" + oeRegistryImages.Image_file_path + "'";

            if (oeRegistryImages.User_id != Guid.Empty)
                result += (result == "" ? "" : " AND ") + "user_id = " + oeRegistryImages.User_id;
            if (oeRegistryImages.Access_datetime != DateTime.MinValue)
                result += (result == "" ? "" : " AND ") + "access_datetime = " + oeRegistryImages.Access_datetime;
            if (oeRegistryImages.Time_stamp != null)
                result += (result == "" ? "" : " AND ") + "time_stamp = '" + oeRegistryImages.Time_stamp + "' ";

            //Concatenate if any condition exists
            if (result != "")
                result = (" WHERE " + result);

            return result;
        }
    }
}
