using System;
using System.Collections.Generic;

namespace jamskingcore20EF.Model.VisaModels
{
    public partial class DbVisaapiVisaInf
    {
        public DbVisaapiVisaInf()
        {
            DbVisaapiVisaCon = new HashSet<DbVisaapiVisaCon>();
        }

        public int VisaInfId { get; set; }
        public decimal? VisaPrice { get; set; }
        public decimal? VisaSettlement { get; set; }
        public string VisaName { get; set; }
        public string VisaNat { get; set; }
        public int? VisaType { get; set; }
        public int? VisaGOL { get; set; }
        public int? VisaSOM { get; set; }
        public double? VisaYear { get; set; }
        public double? VisaEXP { get; set; }
        public DateTime? CreatDate { get; set; }
        public string CreatUser { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedUser { get; set; }
        public int? IsDel { get; set; }

        public ICollection<DbVisaapiVisaCon> DbVisaapiVisaCon { get; set; }
    }
}
