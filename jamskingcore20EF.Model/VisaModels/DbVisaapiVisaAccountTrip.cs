using System;
using System.Collections.Generic;

namespace jamskingcore20EF.Model.VisaModels
{
    public partial class DbVisaapiVisaAccountTrip
    {
        public int VisaAccountTripId { get; set; }
        public int? VisaAccountId { get; set; }
        public string VisaAccountIDNo { get; set; }
        public string VisaAccountTripPur { get; set; }
        public DateTime? VisaAccountTripSDate { get; set; }
        public DateTime? VisaAccountTripFDate { get; set; }
        public string VisaAccountTripCO { get; set; }
        public string VisaAccountTripP { get; set; }
        public string VisaAccountTripC { get; set; }
        public string VisaAccountTripAdd { get; set; }
        public string VisaAccountTripTRName { get; set; }
        public DateTime? CreatDate { get; set; }
        public string CreatUser { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedUser { get; set; }
        public int? IsDel { get; set; }

        public DbVisaapiVisaAccount VisaAccount { get; set; }
    }
}
