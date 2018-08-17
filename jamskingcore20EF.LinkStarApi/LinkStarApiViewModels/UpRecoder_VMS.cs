using System;
using System.Collections.Generic;

namespace jamskingcore20EF.WebApi.LinkStarApiViewModels
{
    public partial class UpRecoder_VMS
    {
        public UpRecoder_VMS()
        {
            
        }
        public int UpRecoderId { get; set; }
        public int ApiAccountId { get; set; }
        public string ApiAccountCode { get; set; }
        public string ApiAccountUserName { get; set; }
        public string ApiEchoToken { get; set; }
        public string ApiSysUserName { get; set; }
        public string ApiSysPassWord { get; set; }
        public string ApiUrl { get; set; }
        public string ApiCon { get; set; }
        public string ApiFrom { get; set; }
        public DateTime LoginTime { get; set; }
        public DateTime CreatDate { get; set; }
        public string CreatUser { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedUser { get; set; }
        public int IsDel { get; set; }
        public int IsLock { get; set; }
    }
}
