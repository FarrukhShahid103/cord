using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RD.EL
{
    public class eRegistryImages
    {
        #region Private Members

        private Guid registryImages_id;
        private Guid registry_id;
        private Guid transaction_id;
        private string imagetype_id;
        private byte[] image_file;
        private string image_file_path;
        private Guid user_id;
        private DateTime access_datetime;
        private byte[] time_stamp;

        #endregion

        #region Public Properties

        public Guid RegistryImages_id
        {
            get { return registryImages_id; }
            set { registryImages_id = value; }
        }

        public Guid Registry_id
        {
            get { return registry_id; }
            set { registry_id = value; }
        }

        public string Imagetype_id
        {
            get { return imagetype_id; }
            set { imagetype_id = value; }
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

        public Guid Transaction_id
        {
            get { return transaction_id; }
            set { transaction_id = value; }
        }

        #endregion
        
    }
}
