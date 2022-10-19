using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RD.EL
{
    public class eTehsil
    {
        #region Private Members

        private Guid tehsil_id;
        private Guid district_id;
        private string tehsil_name_eng;
        private string tehsil_name_urd;
        private string tehsil_FullName;
        private bool is_locked;
        private Guid user_id;
        private DateTime access_date_time;
        private byte[] time_stamp;

        #endregion

        #region Public Properties

        public Guid Tehsil_id
        {
            get { return tehsil_id; }
            set { tehsil_id = value; }
        }

        public Guid District_id
        {
            get { return district_id; }
            set { district_id = value; }
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
        public string Tehsil_FullName
        {
            get { return tehsil_FullName; }
            set { tehsil_FullName = value; }
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
