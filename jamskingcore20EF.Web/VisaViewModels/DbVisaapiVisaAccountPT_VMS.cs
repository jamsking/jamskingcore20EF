using System;
using System.Collections.Generic;

namespace jamskingcore20EF.Web.VisaViewModels
{
    public partial class DbVisaapiVisaAccountPT_VMS
    {
        public int VisaAccountPTId { get; set; }
        public int? VisaAccountId { get; set; }
        public string VisaAccountIDNo { get; set; }
        public string VisaAccountPTCode { get; set; }
        public int? VisaAccountPTType { get; set; }
        public string VisaAccountPTFirstENName { get; set; }
        public string VisaAccountPTLastENName { get; set; }
        public DateTime? VisaAccountPTIssueDay { get; set; }
        public string VisaAccountPTIssueATCO { get; set; }
        public string VisaAccountPTIssueATP { get; set; }
        public string VisaAccountPTIssueATC { get; set; }
        public DateTime? VisaAccountPTEXP { get; set; }
        public DateTime? CreatDate { get; set; }
        public string CreatUser { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedUser { get; set; }
        public int? IsDel { get; set; }

        public DbVisaapiVisaAccount_VMS VisaAccount { get; set; }
    }
}
