using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace RD.EL
{
    public class updatedNewEntryInfo
    {
        public bool Success { get; set; }

        public Guid? Id { get; set; }

        public string Exception { get; set; }

        public int? IdNumeric { get; set; }

        public updatedNewEntryInfo() { }

        public updatedNewEntryInfo(Guid? id, bool success, string exception)
        {
            this.Id = id;
            this.Success = success;
            this.Exception = exception;
        }
    }
}
