using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RD.EL
{
    public class eMauza
    {
        #region Private Members

        private Guid mauza_id;
        private Guid tehsil_id;
        private Guid? town_id;
        private string mauza_name_eng;
        private string mauza_name_urd;
        private int had_bust_no;
        private int feet_per_marla;
        private int preparation_year;
        private bool is_mauza_sikni;
        private bool is_mauza_misl_mayadi;
        private bool is_marla_calculation_unit;
        private int mauza_stage;
        private int area_format;
        private int mauza_type;
        private bool is_shamilat;
        private Guid user_id;
        private DateTime access_date_time;
        private byte[] time_stamp;

        #endregion

        #region Public Properties

        public Guid Mauza_id
        {
            get { return mauza_id; }
            set { mauza_id = value; }
        }

        public Guid Tehsil_id
        {
            get { return tehsil_id; }
            set { tehsil_id = value; }
        }

        public Guid? Town_id
        {
            get { return town_id; }
            set { town_id = value; }
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

        public bool Is_mauza_Misal_miyadi
        {
            get { return is_mauza_misl_mayadi; }
            set { is_mauza_misl_mayadi = value; }
        }
        public bool Is_marla_calculation_unit
        {
            get { return is_marla_calculation_unit; }
            set { is_marla_calculation_unit = value; }
        }
        public bool Has_Shamilat
        {
            get { return is_shamilat; }
            set { is_shamilat = value; }
        }
        public int Area_format
        {
            get { return area_format; }
            set { area_format = value; }
        }
        public int Mauza_Type
        {
            get { return mauza_type; }
            set { mauza_type = value; }
        }
        public int Mauza_Stage
        {
            get { return mauza_stage; }
            set { mauza_stage = value; }
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
