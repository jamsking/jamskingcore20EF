using System;
using System.Collections.Generic;

namespace jamskingcore20EF.Model.LinkStarApiModels
{
    public partial class ReRecoder
    {
        public ReRecoder()
        {
            
        }
        public int ReRecoderId { get; set; }
       
        public string ApiEchoToken { get; set; }
        public string ApiCorrelationID { get; set; }
        public string TimeSpamp { get; set; }
        public string ApiReCon { get; set; }
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
