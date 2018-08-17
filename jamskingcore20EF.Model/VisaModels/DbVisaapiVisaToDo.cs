using System;
using System.Collections.Generic;

namespace jamskingcore20EF.Model.VisaModels
{
    public partial class DbVisaapiVisaToDo
    {
        public DbVisaapiVisaToDo()
        {
            DbVisaapiVisaAccount = new HashSet<DbVisaapiVisaAccount>();
            DbVisaapiVisaFile = new HashSet<DbVisaapiVisaFile>();
        }

        public int VisaToDoId { get; set; }
        public int? VisaToDoBatchId { get; set; }
        public string VisaToDoBatchCode { get; set; }
        public string VisaToDoCode { get; set; }
        public int? VisaInfId { get; set; }
        public decimal? VisaPrice { get; set; }
        public decimal? VisaSettlement { get; set; }
        public string VisaName { get; set; }
        public string VisaNat { get; set; }
        public int? VisaType { get; set; }
        public int? VisaGOL { get; set; }
        public int? VisaSOM { get; set; }
        public decimal? VisaYear { get; set; }
        public decimal? VisaEXP { get; set; }
        public decimal? VisaToDoProfit { get; set; }
        public decimal? VisaToDoDIS { get; set; }
        public DateTime? CreatDate { get; set; }
        public string CreatUser { get; set; }
        public string ModifiedUser { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? IsDel { get; set; }

        public DbVisaapiVisaToDoBatch VisaToDoBatch { get; set; }
        public ICollection<DbVisaapiVisaAccount> DbVisaapiVisaAccount { get; set; }
        public ICollection<DbVisaapiVisaFile> DbVisaapiVisaFile { get; set; }
    }
}
