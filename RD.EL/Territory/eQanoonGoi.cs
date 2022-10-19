using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RD.EL.Territory
{
    public class eQanoonGoi
    {
        #region Private Members

        private Guid qanoon_goi_id;
        private Guid tehsil_id;
        private string qanoon_goi_name_eng;
        private string qanoon_goi_name_urd;
        private Guid user_id;
        private DateTime access_date_time;

        #endregion

        #region Public Properties

        public Guid Qanoon_goi_id
        {
            get { return qanoon_goi_id; }
            set { qanoon_goi_id = value; }
        }

        public Guid Tehsil_id
        {
            get { return tehsil_id; }
            set { tehsil_id = value; }
        }

        public string Qanoon_goi_name_eng
        {
            get { return qanoon_goi_name_eng; }
            set { qanoon_goi_name_eng = value; }
        }

        public string Qanoon_goi_name_urd
        {
            get { return qanoon_goi_name_urd; }
            set { qanoon_goi_name_urd = value; }
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

        #endregion

    }
}
