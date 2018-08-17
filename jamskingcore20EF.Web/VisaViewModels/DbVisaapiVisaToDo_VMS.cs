using System;
using System.Collections.Generic;

namespace jamskingcore20EF.Web.VisaViewModels
{
    public partial class DbVisaapiVisaToDo_VMS
    {
        public DbVisaapiVisaToDo_VMS()
        {
            DbVisaapiVisaAccount_VMS = new HashSet<DbVisaapiVisaAccount_VMS>();
            DbVisaapiVisaFile_VMS = new HashSet<DbVisaapiVisaFile_VMS>();
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

        public DbVisaapiVisaToDoBatch_VMS VisaToDoBatch { get; set; }
        public ICollection<DbVisaapiVisaAccount_VMS> DbVisaapiVisaAccount_VMS { get; set; }
        public ICollection<DbVisaapiVisaFile_VMS> DbVisaapiVisaFile_VMS { get; set; }
    }
}
