using System;
using System.Collections.Generic;

namespace jamskingcore20EF.Model.ApiModels
{
    public partial class ApiAccount
    {
        public ApiAccount()
        {
            
        }
        public int ApiAccountId { get; set; }
        public string ApiAccountCode { get; set; }
        public string ApiAccountUserName { get; set; }
        public string ApiAccountPassWord { get; set; }
        public string ApiAccountRealPassWord { get; set; }
        public string ApiAccountRealName { get; set; }
        public string ApiAccountComName { get; set; }
        public string ApiAccountMob { get; set; }
        public string ApiAccountTel { get; set; }
        public string ApiAccountAddress { get; set; }
        public string ApiAccountCity { get; set; }
        public string ApiAccountNat { get; set; }
        public string ApiUserGroup { get; set; }
        public string ApiFrom { get; set; }
        public DateTime LoginTime { get; set; }
        public DateTime CreatDate { get; set; }
        public string CreatUser { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedUser { get; set; }
        public int IsDel { get; set; }
        public int IsLock { get; set; }
        public DateTime ExpTime { get; set; }
    }
}
