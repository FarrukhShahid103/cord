using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RD.EL
{
    public class ePersonWithRegistry
    {
        #region Private Variables

        private Guid registryperson_id;
        private Guid registry_id;
        private Guid person_id;
        private Guid party_type_id;
        private string party_name_eng;
        private string party_name_urd;
        private double total_area;
        private double transferred_area;
        private string total_share;
        private string transferred_share;

        private Guid mauza_id;
        private Guid old_person_id;
        private string first_name_eng;
        private string last_name_eng;
        private string address_eng;
        private string first_name_urd;
        private string last_name_urd;
        private string address_urd;
        private string nic;
        private Guid caste_id;
        private int relation_id;
        private bool is_govt;
        private bool is_department;
        private bool is_kashmiri;
        private bool is_active;
        private byte[] thumb;
        private string pic_path;
        private byte[] person_pic;
        private bool is_blocked;
        private string block_detail;
        private Guid user_id;
        private DateTime access_date_time;
        private byte[] time_stamp;

        #endregion

        #region Public Properties

        public Guid Registryperson_id
        {
            get { return registryperson_id; }
            set { registryperson_id = value; }
        }

        public Guid Registry_id
        {
            get { return registry_id; }
            set { registry_id = value; }
        }

        public Guid Person_id
        {
            get { return person_id; }
            set { person_id = value; }
        }

        public Guid Party_type_id
        {
            get { return party_type_id; }
            set { party_type_id = value; }
        }

        public string Party_name_urd
        {
            get { return party_name_urd; }
            set { party_name_urd = value; }
        }

        public string Party_name_eng
        {
            get { return party_name_eng; }
            set { party_name_eng = value; }
        }

        public double Total_area
        {
            get { return total_area; }
            set { total_area = value; }
        }

        public double Transferred_area
        {
            get { return transferred_area; }
            set { transferred_area = value; }
        }

        public string Total_share
        {
            get { return total_share; }
            set { total_share = value; }
        }

        public string Transferred_share
        {
            get { return transferred_share; }
            set { transferred_share = value; }
        }

        public Guid Mauza_id
        {
            get { return mauza_id; }
            set { mauza_id = value; }
        }

        public Guid Old_person_id
        {
            get { return old_person_id; }
            set { old_person_id = value; }
        }

        public string First_name_eng
        {
            get { return first_name_eng; }
            set { first_name_eng = value; }
        }

        public string Last_name_eng
        {
            get { return last_name_eng; }
            set { last_name_eng = value; }
        }

        public string Address_eng
        {
            get { return address_eng; }
            set { address_eng = value; }
        }

        public string First_name_urd
        {
            get { return first_name_urd; }
            set { first_name_urd = value; }
        }

        public string Last_name_urd
        {
            get { return last_name_urd; }
            set { last_name_urd = value; }
        }

        public string Address_urd
        {
            get { return address_urd; }
            set { address_urd = value; }
        }

        public string Nic
        {
            get { return nic; }
            set { nic = value; }
        }

        public Guid Caste_id
        {
            get { return caste_id; }
            set { caste_id = value; }
        }

        public int Relation_id
        {
            get { return relation_id; }
            set { relation_id = value; }
        }

        public bool Is_govt
        {
            get { return is_govt; }
            set { is_govt = value; }
        }

        public bool Is_department
        {
            get { return is_department; }
            set { is_department = value; }
        }

        public bool Is_kashmiri
        {
            get { return is_kashmiri; }
            set { is_kashmiri = value; }
        }

        public bool Is_active
        {
            get { return is_active; }
            set { is_active = value; }
        }

        public byte[] Thumb
        {
            get { return thumb; }
            set { thumb = value; }
        }

        public string Pic_path
        {
            get { return pic_path; }
            set { pic_path = value; }
        }

        public byte[] Person_pic
        {
            get { return person_pic; }
            set { person_pic = value; }
        }

        public bool Is_blocked
        {
            get { return is_blocked; }
            set { is_blocked = value; }
        }

        public string Block_detail
        {
            get { return block_detail; }
            set { block_detail = value; }
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
