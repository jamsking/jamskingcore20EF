﻿using System;
using System.Collections.Generic;

namespace jamskingcore20EF.LinkStarApi.ApiViewModels
{
    public partial class ApiAccountGroup_VMS
    {
        public ApiAccountGroup_VMS()
        {
            
        }

        public int ApiAccountGroupId { get; set; }
        public string ApiAccountGroupName { get; set; }
        public string ApiAccountGroupCode { get; set; }
        public string ApiAccountGroupLevel { get; set; }
        
        public DateTime CreatDate { get; set; }
        public string CreatUser { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedUser { get; set; }
        public int IsDel { get; set; }
        public int IsLock { get; set; }
    }
}
