using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RD.EL
{
    public class eTerritoryWithMauza
    {
        #region Private Members

        private Guid town_id;
        private string town_name_eng;
        private string town_name_urd;
        private Guid district_id;
        private string district_name_eng;
        private string district_name_urd;
        private Guid tehsil_id;
        private string tehsil_name_eng;
        private string tehsil_name_urd;
        private Guid mauza_id;
        private string mauza_name_eng;
        private string mauza_name_urd;
        private int had_bust_no;
        private int feet_per_marla;
        private int preparation_year;
        private bool is_mauza_sikni;
        private bool is_marla_calculation_unit;
        private int area_format;
        private Guid user_id;
        private DateTime access_date_time;
        private byte[] time_stamp;

        #endregion

        #region Public Properties

        public Guid Town_id
        {
            get { return town_id; }
            set { town_id = value; }
        }

        public string Town_name_eng
        {
            get { return town_name_eng; }
            set { town_name_eng = value; }
        }

        public string Town_name_urd
        {
            get { return town_name_urd; }
            set { town_name_urd = value; }
        }

        public Guid District_id
        {
            get { return district_id; }
            set { district_id = value; }
        }

        public string District_name_eng
        {
            get { return district_name_eng; }
            set { district_name_eng = value; }
        }

        public string District_name_urd
        {
            get { return district_name_urd; }
            set { district_name_urd = value; }
        }

        public Guid Tehsil_id
        {
            get { return tehsil_id; }
            set { tehsil_id = value; }
        }

        public string Tehsil_name_eng
        {
            get { return tehsil_name_eng; }
            set { tehsil_name_eng = value; }
        }

        public string Tehsil_name_urd
        {
            get { return tehsil_name_urd; }
            set { tehsil_name_urd = value; }
        }

        public Guid Mauza_id
        {
            get { return mauza_id; }
            set { mauza_id = value; }
        }

        public string Mauza_name_eng
        {
            get { return mauza_name_eng; }
            set { mauza_name_eng = value; }
        }

        public string Mauza_name_urd
        {
            get { return mauza_name_urd; }
            set { mauza_name_urd = value; }
        }

        public int Had_bust_no
        {
            get { return had_bust_no; }
            set { had_bust_no = value; }
        }

        public int Feet_per_marla
        {
            get { return feet_per_marla; }
            set { feet_per_marla = value; }
        }

        public int Preparation_year
        {
            get { return preparation_year; }
            set { preparation_year = value; }
        }

        public bool Is_mauza_sikni
        {
            get { return is_mauza_sikni; }
            set { is_mauza_sikni = value; }
        }

        public bool Is_marla_calculation_unit
        {
            get { return is_marla_calculation_unit; }
            set { is_marla_calculation_unit = value; }
        }

        public int Area_format
        {
            get { return area_format; }
            set { area_format = value; }
        }

        public Guid User_id
        {
            get { return user_id; }
            set { user_id = value; }
        }

        public DateTime Access_date_time
        {
            get { return access_date_time; }
            set { access_date_time = value; }
        }

        public byte[] Time_stamp
        {
            get { return time_stamp; }
            set { time_stamp = value; }
        }

        #endregion
    }
}
