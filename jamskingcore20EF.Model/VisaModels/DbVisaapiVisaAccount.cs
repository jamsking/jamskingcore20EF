using System;
using System.Collections.Generic;

namespace jamskingcore20EF.Model.VisaModels
{
    public partial class DbVisaapiVisaAccount
    {
        public DbVisaapiVisaAccount()
        {
            DbVisaapiVisaAccountFM = new HashSet<DbVisaapiVisaAccountFM>();
            DbVisaapiVisaAccountPT = new HashSet<DbVisaapiVisaAccountPT>();
            DbVisaapiVisaAccountTrip = new HashSet<DbVisaapiVisaAccountTrip>();
        }

        public int VisaAccountId { get; set; }
        public int? VisaToDoId { get; set; }
        public string VisaToDoCode { get; set; }
        public string VisaAccountFirstName { get; set; }
        public string VisaAccountLastName { get; set; }
        public string VisaAccountIdno { get; set; }
        public int? VisaAccountIdtype { get; set; }
        public string VisaAccountUsedName { get; set; }
        public int? VisaAccountMst { get; set; }
        public DateTime? VisaAccountBrithday { get; set; }
        public string VisaAccountBrithCo { get; set; }
        public string VisaAccountBrithP { get; set; }
        public string VisaAccountBrithC { get; set; }
        public string VisaAccountMob { get; set; }
        public string VisaAccountEmail { get; set; }
        public string VisaAccountPrco { get; set; }
        public string VisaAccountPrp { get; set; }
        public string VisaAccountPrc { get; set; }
        public string VisaAccountPradd { get; set; }
        public string VisaAccountTel { get; set; }
        public string VisaAccountZip { get; set; }
        public int? VisaAccountSex { get; set; }
        public DateTime? CreatDate { get; set; }
        public string CreatUser { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedUser { get; set; }
        public int? IsDel { get; set; }
        public string VisaAccountRco { get; set; }
        public string VisaAccountRp { get; set; }
        public string VisaAccountRc { get; set; }
        public string VisaAccountRadd { get; set; }
        public string VisaAccountComName { get; set; }
        public string VisaAccountComAdd { get; set; }
        public string VisaAccountComTel { get; set; }
        public string VisaAccountComJob { get; set; }
        public decimal? VisaAccountComSalary { get; set; }
        public decimal? VisaAccountComTax { get; set; }

        public DbVisaapiVisaToDo VisaToDo { get; set; }
        public ICollection<DbVisaapiVisaAccountFM> DbVisaapiVisaAccountFM { get; set; }
        public ICollection<DbVisaapiVisaAccountPT> DbVisaapiVisaAccountPT { get; set; }
        public ICollection<DbVisaapiVisaAccountTrip> DbVisaapiVisaAccountTrip { get; set; }
    }
}
