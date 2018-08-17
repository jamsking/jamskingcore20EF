using System;
using System.Collections.Generic;
using System.Text;
using jamskingcore20EF.Entity.Base;

namespace jamskingcore20EF.Model.Model
{
    public class Book : BaseEntity
    {
        public string Name { get; set; }
        public string ISBN { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
    }

}
