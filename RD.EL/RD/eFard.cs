using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RD.EL
{
    public class eFard
    {
        #region Private Members

        private Guid fard_id;
        private string fard_no;
        private string fard_objective;
        private Guid? registry_id;
        private bool is_shamlat;
        private int total_fee;
        private bool fard_status;
        private Guid user_id;
        private string remarks;
        private bool is_active;
        private DateTime access_datetime;
        private byte[] time_stamp;

        #endregion

        #region Public Properties

        public Guid Fard_id
        {
            get { return fard_id; }
            set { fard_id = value; }
        }

        public Guid? Registry_id
        {
            get { return registry_id; }
            set { registry_id = value; }
        }

        public string Fard_no
        {
            get { return fard_no; }
            set { fard_no = value; }
        }

        public string Fard_objective
        {
            get { return fard_objective; }
            set { fard_objective = value; }
        }

        public bool Is_shamlat
        {
            get { return is_shamlat; }
            set { is_shamlat = value; }
        }

        public int Total_fee
        {
            get { return total_fee; }
            set { total_fee = value; }
        }

        public bool Fard_status
        {
            get { return fard_status; }
            set { fard_status = value; }
        }

        public Guid User_id
        {
            get { return user_id; }
            set { user_id = value; }
        }

        public string Remarks
        {
            get { return remarks; }
            set { remarks = value; }
        }

        public bool Is_active
        {
            get { return is_active; }
            set { is_active = value; }
        }

        public DateTime Access_datetime
        {
            get { return access_datetime; }
            set { access_datetime = value; }
        }

        public byte[] Time_stamp
        {
            get { return time_stamp; }
            set { time_stamp = value; }
        }

        #endregion
    }
}
