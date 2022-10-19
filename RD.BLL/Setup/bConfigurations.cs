using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RD.DAL;
using RD.EL;

namespace RD.BLL
{
    public class bConfigurations
    {
        private static long totalRecord = -1;
        dConfigurations odConfigurations;
        public List<eConfigurations> getConfigurations(eConfigurations oeConfigurations, string sortExpression, string condition, long startRowIndex, int pageSize)
        {
            condition = BuildCondition(oeConfigurations);
            odConfigurations = new dConfigurations();
            List<eConfigurations> oeListConfigurations = new List<eConfigurations>();
            oeListConfigurations = odConfigurations.getConfigurations(sortExpression, condition, startRowIndex, pageSize, ref totalRecord);
            return oeListConfigurations;
        }

        public updatedNewEntryInfo insertConfigurations(eConfigurations oeConfigurations)
        {
            updatedNewEntryInfo insertInfo = new updatedNewEntryInfo();
            odConfigurations = new dConfigurations();
            insertInfo = odConfigurations.insertConfigurations(oeConfigurations);
            return insertInfo;
        }

        public updatedNewEntryInfo udpateConfigurations(eConfigurations oeConfigurations)
        {
            updatedNewEntryInfo updateInfo = new updatedNewEntryInfo();
            odConfigurations = new dConfigurations();
            updateInfo = odConfigurations.updateConfigurations(oeConfigurations);
            return updateInfo;
        }

        public updatedNewEntryInfo deleteConfigurations(eConfigurations oeConfigurations)
        {
            updatedNewEntryInfo deleteInfo = new updatedNewEntryInfo();
            odConfigurations = new dConfigurations();
            deleteInfo = odConfigurations.deleteConfigurations(oeConfigurations.Config_id);
            return deleteInfo;
        }

        public static long GetConfigurationsCount()
        {
            return totalRecord;
        }

        private string BuildCondition(eConfigurations oeConfigurations)
        {
            string result = "";

            if (oeConfigurations.Config_id != 0)
                result += (result == "" ? "" : " AND ") + "config_id = '" + oeConfigurations.Config_id + "'";
            if (oeConfigurations.Config_key != null && oeConfigurations.Config_key != string.Empty)
                result += (result == "" ? "" : " AND ") + "config_key = '" + oeConfigurations.Config_key + "'";
            if (oeConfigurations.Config_value != String.Empty && oeConfigurations.Config_value != null)
                result += (result == "" ? "" : " AND ") + "config_value = '" + oeConfigurations.Config_value + "'";

            //Concatenate if any condition exists
            if (result != "")
                result = (" WHERE " + result);

            return result;
        }
    }
}
