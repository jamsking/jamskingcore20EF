using System;
using System.Collections.Generic;
using System.Text;

namespace jamskingcore20EF.Entity.Base
{
    public class BEEntity
    {
        
        public DateTime CreateDate{ get; set; }
        public DateTime ModifiedDate { get; set; }
        public string CreateUser { get; set; }
        public string ModifiedUser { get; set; }
    }
}
