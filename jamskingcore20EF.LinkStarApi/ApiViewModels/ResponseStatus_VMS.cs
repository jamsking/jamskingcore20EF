using System;
using System.Collections.Generic;

namespace jamskingcore20EF.LinkStarApi.ApiViewModels
{
    public partial class ResponseStatus_VMS
    {
        public ResponseStatus_VMS()
        {
            
        }

        public int RSId { get; set; }
        public string Position { get; set; }
        public string Infmation { get; set; }
        public int Success { get; set; }
        public string Message { get; set; }
        public int Errorcode { get; set; }
        public string Remark { get; set; }
        public string ApiCode { get; set; }
        public string ApiFrom { get; set; }
        
        public DateTime CreatDate { get; set; }
        public string CreatUser { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedUser { get; set; }
        public int IsDel { get; set; }
        public int IsLock { get; set; }
    }
}
