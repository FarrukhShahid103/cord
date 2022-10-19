using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RD.DAL;
using RD.EL;

namespace RD.BLL
{
    public class bForms
    {
        private static long totalRecord = -1;
        dForms odForms;
        public List<eForms> getForms(eForms oeForms, string sortExpression, string condition, long startRowIndex, int pageSize)
        {
            condition = BuildCondition(oeForms);
            odForms = new dForms();
            List<eForms> oeListForms = new List<eForms>();
            oeListForms = odForms.getForms(sortExpression, condition, startRowIndex, pageSize, ref totalRecord);
            return oeListForms;
        }

        public updatedNewEntryInfo insertForms(eForms oeForms)
        {
            updatedNewEntryInfo insertInfo = new updatedNewEntryInfo();
            odForms = new dForms();
            insertInfo = odForms.insertForms(oeForms);
            return insertInfo;
        }

        public updatedNewEntryInfo udpateForms(eForms oeForms)
        {
            updatedNewEntryInfo updateInfo = new updatedNewEntryInfo();
            odForms = new dForms();
            updateInfo = odForms.updateForms(oeForms);
            return updateInfo;
        }

        public updatedNewEntryInfo deleteForms(eForms oeForms)
        {
            updatedNewEntryInfo deleteInfo = new updatedNewEntryInfo();
            odForms = new dForms();
            deleteInfo = odForms.deleteForms(oeForms.Form_id);
            return deleteInfo;
        }

        public static long GetFormsCount()
        {
            return totalRecord;
        }

        private string BuildCondition(eForms oeForms)
        {
            string result = "";

            if (oeForms.Form_id != Guid.Empty)
                result += (result == "" ? "" : " AND ") + "form_id = '" + oeForms.Form_id + "'";
            if (oeForms.Module_id != Guid.Empty)
                result += (result == "" ? "" : " AND ") + "module_id = '" + oeForms.Module_id + "'";
            if (oeForms.Menu_id != Guid.Empty)
                result += (result == "" ? "" : " AND ") + "menu_id = '" + oeForms.Menu_id + "'";
            if (oeForms.Description_eng != String.Empty && oeForms.Description_eng != null)
                result += (result == "" ? "" : " AND ") + "description_eng = '" + oeForms.Description_eng + "'";
            if (oeForms.Description_urd != String.Empty && oeForms.Description_urd != null)
                result += (result == "" ? "" : " AND ") + "description_urd = '" + oeForms.Description_urd + "'";
            if (oeForms.Path != String.Empty && oeForms.Path != null)
                result += (result == "" ? "" : " AND ") + "path = '" + oeForms.Path + "'";
            if (oeForms.Access_user_id != Guid.Empty)
                result += (result == "" ? "" : " AND ") + "access_user_id = " + oeForms.Access_user_id;
            if (oeForms.Access_datetime != DateTime.MinValue)
                result += (result == "" ? "" : " AND ") + "access_datetime = " + oeForms.Access_datetime;
            if (oeForms.Time_stamp != null)
                result += (result == "" ? "" : " AND ") + "time_stamp = '" + oeForms.Time_stamp + "'";

            if (result != "")
                result = (" WHERE " + result);

            return result;
        }
    }
}
