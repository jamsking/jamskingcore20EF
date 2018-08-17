using System;
using System.Collections.Generic;

namespace jamskingcore20EF.Model.VisaModels
{
    public partial class DbVisaapiVisaCon
    {
        public int VisaConId { get; set; }
        public int? VisaInfId { get; set; }
        public string VisaConName { get; set; }
        public string VisaConNtext { get; set; }
        public decimal? VisaConAgeLim { get; set; }
        public int? VisaConJobType { get; set; }
        public int? VisaConMst { get; set; }
        public int? VisaConSex { get; set; }
        public int? VisaConType { get; set; }
        public int? VisaConSign { get; set; }
        public int? VisaConOpt { get; set; }
        public int? VisaConAtta { get; set; }
        public int? VisaConFitem { get; set; }
        public DateTime? CreatDate { get; set; }
        public string CreatUser { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedUser { get; set; }
        public int? IsDel { get; set; }

        public DbVisaapiVisaInf VisaInf { get; set; }
    }
}
