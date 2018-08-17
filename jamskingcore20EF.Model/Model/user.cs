using System;
using System.ComponentModel.DataAnnotations;

namespace jamskingcore20EF.Model.Model
{
    public class tb_User
    {
         [Key]
        public string ID { get; set; }


       
        public string UserName { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
