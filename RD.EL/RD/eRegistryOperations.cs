using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RD.EL
{
    public class eRegistryOperations
    {
        #region Private Members

        private Guid registry_id;
        private Guid? mauza_id;
        private Guid? service_centre_id;
        private Guid? subregistrar_id;
        private int? registery_stage;
        private int? commission_type;
        private Guid registry_type_id;
        private string registry_no;
        private string bahi_no;
        private string jild_no;
        private string doc_number;
        private int? mutation_Fee;
        private int? cvt;
        private int? stamp_Duty;
        private int? registry_fee;
        private int? tma_fee;
        private int? district_council_fee;
        private int? challan_fee;
        private int? selling_price;
        private int amount;
        private bool is_active;
        private string remarks;
        private Guid user_id;
        private DateTime access_datetime;
        private byte[] time_stamp;
        private DateTime registry_date;
        private int is_urban;
        private byte[] image_file;
        private string image_file_path;
        private string Description;
        #endregion

        #region Public Properties        
        public Guid Registry_id
        {
            get { return registry_id; }
            set { registry_id = value; }
        }

        public Guid? Mauza_id
        {
            get { return mauza_id; }
            set { mauza_id = value; }
        }

        public Guid? Service_centre_id
        {
            get { return service_centre_id; }
            set { service_centre_id = value; }
        }

        public Guid? Subregistrar_id
        {
            get { return subregistrar_id; }
            set { subregistrar_id = value; }
        }

        public int? Registery_stage
        {
            get { return registery_stage; }
            set { registery_stage = value; }
        }

        public int? Commission_type
        {
            get { return commission_type; }
            set { commission_type = value; }
        }


        public Guid Registry_type_id
        {
            get { return registry_type_id; }
            set { registry_type_id = value; }
        }

        public string Registry_no
        {
            get { return registry_no; }
            set { registry_no = value; }
        }

        public string Bahi_no
        {
            get { return bahi_no; }
            set { bahi_no = value; }
        }

        public string Jild_no
        {
            get { return jild_no; }
            set { jild_no = value; }
        }

        public string Doc_number
        {
            get { return doc_number; }
            set { doc_number = value; }
        }

        public int? Mutation_Fee
        {
            get { return mutation_Fee; }
            set { mutation_Fee = value; }
        }
        public int? Cvt
        {
            get { return cvt; }
            set { cvt = value; }
        }
        public int? Stamp_Duty
        {
            get { return stamp_Duty; }
            set { stamp_Duty = value; }
        }

        public int? Registry_fee
        {
            get { return registry_fee; }
            set { registry_fee = value; }
        }

        public int? Tma_fee
        {
            get { return tma_fee; }
            set { tma_fee = value; }
        }

        public int? District_council_fee
        {
            get { return district_council_fee; }
            set { district_council_fee = value; }
        }

        public int? Challan_fee
        {
            get { return challan_fee; }
            set { challan_fee = value; }
        }

        public int? Selling_price
        {
            get { return selling_price; }
            set { selling_price = value; }
        }

        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public bool Is_active
        {
            get { return is_active; }
            set { is_active = value; }
        }
        
        public string Remarks
        {
            get { return remarks; }
            set { remarks = value; }
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

        public byte[] Time_stamp
        {
            get { return time_stamp; }
            set { time_stamp = value; }
        }

        public DateTime Registry_date
        {
            get { return registry_date; }
            set { registry_date = value; }
        }

        public int Is_urban
        {
            get { return is_urban; }
            set { is_urban = value; }
        }
        public byte[] Image_file
        {
            get { return image_file; }
            set { image_file = value; }
        }

        public string Image_file_path
        {
            get { return image_file_path; }
            set { image_file_path = value; }
        }
        public string RegistryDescription
        {
            get { return Description; }
            set { Description = value; }
        }
        #endregion
    }
}
