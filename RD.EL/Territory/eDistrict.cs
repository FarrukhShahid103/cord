using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RD.EL
{
    public class eDistrict
    {
        #region Private Members

        private Guid district_id;
        private int province_id;
        private string district_name_eng;
        private string district_name_urd;
        private string district_FullName;
        private bool is_locked;
        private Guid user_id;
        private DateTime access_date_time;
        private byte[] time_stamp;

        #endregion

        #region Public Properties

        public Guid District_id
        {
            get { return district_id; }
            set { district_id = value; }
        }

        public int Province_id
        {
            get { return province_id; }
            set { province_id = value; }
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
        public string District_FullName
        {
            get { return district_FullName; }
            set { district_FullName = value; }
        }
        public bool Is_locked
        {
            get { return is_locked; }
            set { is_locked = value; }
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
