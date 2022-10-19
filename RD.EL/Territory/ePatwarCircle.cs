using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RD.EL.Territory
{
    public class ePatwarCircle
    {
        #region Private Members

        private Guid patwar_circle_id;
        private Guid qanoon_goi_id;
        private string patwar_circle_name_eng;
        private string patwar_circle_name_urd;
        private Guid user_id;
        private DateTime access_date_time;

        #endregion

        #region Public Properties

        public Guid Patwar_circle_id
        {
            get { return patwar_circle_id; }
            set { patwar_circle_id = value; }
        }

        public Guid Qanoon_goi_id
        {
            get { return qanoon_goi_id; }
            set { qanoon_goi_id = value; }
        }

        public string Patwar_circle_name_eng
        {
            get { return patwar_circle_name_eng; }
            set { patwar_circle_name_eng = value; }
        }

        public string Patwar_circle_name_urd
        {
            get { return patwar_circle_name_urd; }
            set { patwar_circle_name_urd = value; }
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
