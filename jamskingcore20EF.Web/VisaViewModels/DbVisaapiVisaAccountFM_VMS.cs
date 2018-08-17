using System;
using System.Collections.Generic;

namespace jamskingcore20EF.Web.VisaViewModels
{
    public partial class DbVisaapiVisaAccountFM_VMS
    {
        public int VisaAccountFMId { get; set; }
        public int? VisaAccountId { get; set; }
        public string VisaAccountIDNo { get; set; }
        public string VisaAccountFMFirstName { get; set; }
        public string VisaAccountFMLastName { get; set; }
        public string VisaAccountFMFirstEnname { get; set; }
        public string VisaAccountFMLastEnname { get; set; }
        public DateTime? VisaAccountFMBrithday { get; set; }
        public string VisaAccountFMJob { get; set; }
        public int? VisaAccountFMRel { get; set; }
        public DateTime? CreatDate { get; set; }
        public string CreatUser { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedUser { get; set; }
        public int? IsDel { get; set; }

        public DbVisaapiVisaAccount_VMS VisaAccount { get; set; }
    }
}
