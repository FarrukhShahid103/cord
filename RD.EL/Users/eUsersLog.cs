using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RD.EL.Users
{
    public class eUsersLog
    {
        #region Private Members

        private Guid userlog_id;
        private Guid operation_id;
        private string tablename;
        private Guid transaction_id;
        private string ipaddress;
        private Guid user_id;
        private DateTime access_datetime;

        #endregion

        #region Public Properties

        public Guid Userlog_id
        {
            get { return userlog_id; }
            set { userlog_id = value; }
        }

        public Guid Operation_id
        {
            get { return operation_id; }
            set { operation_id = value; }
        }

        public string Tablename
        {
            get { return tablename; }
            set { tablename = value; }
        }

        public Guid Transaction_id
        {
            get { return transaction_id; }
            set { transaction_id = value; }
        }

        public string Ipaddress
        {
            get { return ipaddress; }
            set { ipaddress = value; }
        }

        public Guid User_id
        {
            get { return user_id; }
            set { user_id = value; }
        }

        public DateTime Access_datetime
        {
            get { return access_datetime; }
            set { access_datetime = value; }
        }

        #endregion
    }
}
