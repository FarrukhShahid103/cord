using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RD.EL.Users
{
    public class eMauzaRights
    {
        #region Private Members

        private Guid mauza_rights_id;
        private Guid mauza_id;
        private Guid user_id;
        private Guid access_user_id;
        private DateTime access_date_time;

        #endregion

        #region Public Properties

        public Guid Mauza_rights_id
        {
            get { return mauza_rights_id; }
            set { mauza_rights_id = value; }
        }

        public Guid Mauza_id
        {
            get { return mauza_id; }
            set { mauza_id = value; }
        }

        public Guid User_id
        {
            get { return user_id; }
            set { user_id = value; }
        }

        public Guid Access_user_id
        {
            get { return access_user_id; }
            set { access_user_id = value; }
        }

        public DateTime Access_date_time
        {
            get { return access_date_time; }
            set { access_date_time = value; }
        }

        #endregion
    }
}
