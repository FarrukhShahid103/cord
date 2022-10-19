using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RD.EL.Setup
{
    public class eChakTashkhees
    {
        #region Private Members

        private Guid chak_tashkhees_id;
        private string chak_tashkhees_name_eng;
        private string chak_tashkhees_name_urd;
        private Guid user_id;
        private DateTime access_date_time;

        #endregion
        
        #region Public Properties

        public Guid Chak_tashkhees_id
        {
            get { return chak_tashkhees_id; }
            set { chak_tashkhees_id = value; }
        }

        public string Chak_tashkhees_name_eng
        {
            get { return chak_tashkhees_name_eng; }
            set { chak_tashkhees_name_eng = value; }
        }

        public string Chak_tashkhees_name_urd
        {
            get { return chak_tashkhees_name_urd; }
            set { chak_tashkhees_name_urd = value; }
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
