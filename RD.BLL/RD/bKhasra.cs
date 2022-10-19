using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RD.DAL;
using RD.EL;

namespace RD.BLL
{
    public class bKhasra
    {
            private static long totalRecord = -1;
            dKhasra odKhasra;
            public List<eKhasra> getKhasra(eKhasra oeKhasra, string sortExpression, string condition, long startRowIndex, int pageSize)
            {
                condition = BuildCondition(oeKhasra);
                odKhasra = new dKhasra();
                List<eKhasra> oeListKhasra = new List<eKhasra>();
                oeListKhasra = odKhasra.getKhasra(sortExpression, condition, startRowIndex, pageSize, ref totalRecord);
                return oeListKhasra;
            }

            public updatedNewEntryInfo insertKhasra(eKhasra oeKhasra)
            {
                updatedNewEntryInfo insertInfo = new updatedNewEntryInfo();
                odKhasra = new dKhasra();
                insertInfo = odKhasra.insertKhasra(oeKhasra);
                return insertInfo;
            }

            public updatedNewEntryInfo udpateKhasra(eKhasra oeKhasra)
            {
                updatedNewEntryInfo updateInfo = new updatedNewEntryInfo();
                odKhasra = new dKhasra();
                updateInfo = odKhasra.updateKhasra(oeKhasra);
                return updateInfo;
            }

            public updatedNewEntryInfo deleteKhasra(eKhasra oeKhasra)
            {
                updatedNewEntryInfo deleteInfo = new updatedNewEntryInfo();
                odKhasra = new dKhasra();
                deleteInfo = odKhasra.deleteKhasra(oeKhasra);
                return deleteInfo;
            }

            public static long GetKhasraCount()
            {
                return totalRecord;
            }

            private string BuildCondition(eKhasra oeKhasra)
            {
                string result = "";

                if (oeKhasra.Khasra_id != Guid.Empty)
                    result += (result == "" ? "" : " AND ") + "Khasra_id = '" + oeKhasra.Khasra_id + "'";
                if (oeKhasra.Registry_id != Guid.Empty)
                    result += (result == "" ? "" : " AND ") + "registry_id = '" + oeKhasra.Registry_id + "'";
                if (oeKhasra.Khewat_no != string.Empty && oeKhasra.Khewat_no != null)
                    result += (result == "" ? "" : " AND ") + "khewat_no = '" + oeKhasra.Khewat_no + "'";
                if (oeKhasra.Khatuni_no != String.Empty && oeKhasra.Khatuni_no != null)
                    result += (result == "" ? "" : " AND ") + "khatuni_no = '" + oeKhasra.Khatuni_no + "'";
                if (oeKhasra.Khasra_no != String.Empty && oeKhasra.Khasra_no != null)
                    result += (result == "" ? "" : " AND ") + "khasra_no = '" + oeKhasra.Khasra_no + "'";
                if (oeKhasra.Khasra_total_area != null && oeKhasra.Khasra_total_area != 0)
                    result += (result == "" ? "" : " AND ") + "khasra_total_area = '" + oeKhasra.Khasra_total_area + "'";
                if (oeKhasra.Transferred_area != null && oeKhasra.Transferred_area != 0)
                    result += (result == "" ? "" : " AND ") + "transferred_area = '" + oeKhasra.Transferred_area + "'";
                if (oeKhasra.Khasra_total_share != String.Empty && oeKhasra.Khasra_total_share != null)
                    result += (result == "" ? "" : " AND ") + "khasra_total_share = '" + oeKhasra.Khasra_total_share + "'";
                if (oeKhasra.Transferred_share != String.Empty && oeKhasra.Transferred_share != null)
                    result += (result == "" ? "" : " AND ") + "transferred_share = '" + oeKhasra.Transferred_share + "'";
                if (oeKhasra.Print_sequence_no != null && oeKhasra.Print_sequence_no != 0)
                    result += (result == "" ? "" : " AND ") + "print_sequence_no = '" + oeKhasra.Print_sequence_no + "'";
                if (oeKhasra.Is_active != null && oeKhasra.Is_active != false)
                    result += (result == "" ? "" : " AND ") + "is_active = '" + oeKhasra.Is_active + "'";
                if (oeKhasra.East != String.Empty && oeKhasra.East != null)
                    result += (result == "" ? "" : " AND ") + "east = '" + oeKhasra.East + "'";
                if (oeKhasra.West != String.Empty && oeKhasra.West != null)
                    result += (result == "" ? "" : " AND ") + "west = '" + oeKhasra.West + "'";
                if (oeKhasra.North != String.Empty && oeKhasra.North != null)
                    result += (result == "" ? "" : " AND ") + "north = '" + oeKhasra.North + "'";
                if (oeKhasra.South != String.Empty && oeKhasra.South != null)
                    result += (result == "" ? "" : " AND ") + "south = '" + oeKhasra.South + "'";

                if (oeKhasra.User_id != Guid.Empty)
                    result += (result == "" ? "" : " AND ") + "user_id = " + oeKhasra.User_id;
                if (oeKhasra.Access_date_time != DateTime.MinValue)
                    result += (result == "" ? "" : " AND ") + "access_date_time = " + oeKhasra.Access_date_time;
                if (oeKhasra.Time_stamp != null)
                    result += (result == "" ? "" : " AND ") + "time_stamp = '" + oeKhasra.Time_stamp + "' ";

                //Concatenate if any condition exists
                if (result != "")
                    result = (" WHERE " + result);

                return result;
            }

    }
}
