using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RD.EL
{
    public class eRegistry
    {
        #region Private Members
        private Guid registry_id;
        private string registry_no;
        private string doc_number;
        private DateTime registry_date;
        private Guid district_id;        
        private string district_name_eng;
        private string district_name_urd;
        private Guid tehsil_id;        
        private string tehsil_name_eng;
        private string tehsil_name_urd;
        private Guid mauza_id;
        private string mauza_name_eng;
        private string mauza_name_urd;
        private string Registry_type_description_eng;
        private string Registry_type_description_urd;
        #endregion
        #region Public Properties
        public Guid Registery_Id
        {
            get { return registry_id; }
            set { registry_id = value; }
        }
        public string Registery_no
        {
            get { return registry_no; }
            set { registry_no = value; }
        }
        public string Doc_number
        {
            get { return doc_number; }
            set { doc_number = value; }
        }

        public DateTime Registery_Date
        {
            get { return registry_date; }
            set { registry_date = value; }
        }

        public Guid District_Id
        {
            get { return district_id; }
            set { district_id = value; }
        }

        public string District_Name_Eng
        {
            get { return district_name_eng; }
            set { district_name_eng = value; }
        }

        public string District_Name_Urd
        {
            get { return district_name_urd; }
            set { district_name_urd = value; }
        }

        public Guid Tehsil_Id
        {
            get { return tehsil_id; }
            set { tehsil_id = value; }
        }


        public string Tehsil_Name_Eng
        {
            get { return tehsil_name_eng; }
            set { tehsil_name_eng = value; }
        }

        public string Tehsil_Name_Urd
        {
            get { return tehsil_name_urd; }
            set { tehsil_name_urd = value; }
        }

        public Guid Mauza_Id
        {
            get { return mauza_id; }
            set { mauza_id = value; }
        }

        public string Mauza_Name_Eng
        {
            get { return mauza_name_eng; }
            set { mauza_name_eng = value; }
        }

        public string Mauza_Name_Urd
        {
            get { return mauza_name_urd; }
            set { mauza_name_urd = value; }
        }

        public string Registry_Type_Description_Eng
        {
            get { return Registry_type_description_eng; }
            set { Registry_type_description_eng = value; }
        }

        public string Registry_Type_Description_Urd
        {
            get { return Registry_type_description_urd; }
            set { Registry_type_description_urd = value; }
        }


        #endregion

    }
}
