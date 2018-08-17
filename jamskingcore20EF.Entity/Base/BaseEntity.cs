using System;
using System.Collections.Generic;
using System.Text;

namespace jamskingcore20EF.Entity.Base
{
    public class BaseEntity
    {
        public Int32 Id { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string IPAddress { get; set; }
    }
}
