using System;
using System.Collections.Generic;

namespace jamskingcore20EF.Web.VisaViewModels
{
    public partial class DbVisaapiVisaToDoBatch_VMS
    {
        public DbVisaapiVisaToDoBatch_VMS()
        {
            DbVisaapiVisaToDo_VMS = new HashSet<DbVisaapiVisaToDo_VMS>();
        }

        public int VisaToDoBatchId { get; set; }
        public string VisaToDoBatchCode { get; set; }
        public DateTime? VisaToDoBatchToDate { get; set; }
        public DateTime? VisaToDoBatchPredictTGdate { get; set; }
        public string VisaToDoBatchUser { get; set; }
        public string VisaToDoBatchAdd { get; set; }
        public string VisaToDoBatchCO { get; set; }
        public DateTime? CreatDate { get; set; }
        public string CreatUser { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedUser { get; set; }
        public int? IsDel { get; set; }

        public ICollection<DbVisaapiVisaToDo_VMS> DbVisaapiVisaToDo_VMS { get; set; }
    }
}
