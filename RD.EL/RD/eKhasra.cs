using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RD.EL
{
    public class eKhasra
    {
        #region Private Variables

        private Guid khasra_id;
        private Guid registry_id;
        private string khewat_no;
        private string khatuni_no;
        private string khasra_no;
        private long? khasra_total_area;
        private long? transferred_area;
        private string khasra_total_share;
        private string transferred_share;
        private int? print_sequence_no;
        private bool is_active;
        private string east;
        private string west;
        private string north;
        private string south;
        private Guid user_id;
        private DateTime access_date_time;
        private byte[] time_stamp;

        #endregion

        #region Public Properties

        public Guid Khasra_id
        {
            get { return khasra_id; }
            set { khasra_id = value; }
        }

        public string Khewat_no
        {
            get { return khewat_no; }
            set { khewat_no = value; }
        }

        public string Khatuni_no
        {
            get { return khatuni_no; }
            set { khatuni_no = value; }
        }

        public string Khasra_no
        {
            get { return khasra_no; }
            set { khasra_no = value; }
        }

        public long? Khasra_total_area
        {
            get { return khasra_total_area; }
            set { khasra_total_area = value; }
        }

        public long? Transferred_area
        {
            get { return transferred_area; }
            set { transferred_area = value; }
        }

        public string Khasra_total_share
        {
            get { return khasra_total_share; }
            set { khasra_total_share = value; }
        }

        public string Transferred_share
        {
            get { return transferred_share; }
            set { transferred_share = value; }
        }

        public int? Print_sequence_no
        {
            get { return print_sequence_no; }
            set { print_sequence_no = value; }
        }

        public bool Is_active
        {
            get { return is_active; }
            set { is_active = value; }
        }

        public string East
        {
            get { return east; }
            set { east = value; }
        }

        public string West
        {
            get { return west; }
            set { west = value; }
        }

        public string North
        {
            get { return north; }
            set { north = value; }
        }

        public string South
        {
            get { return south; }
            set { south = value; }
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

        public Guid Registry_id
        {
            get { return registry_id; }
            set { registry_id = value; }
        }

        #endregion
    }
}
