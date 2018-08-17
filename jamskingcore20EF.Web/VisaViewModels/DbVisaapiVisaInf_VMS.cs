using System.ComponentModel.DataAnnotations;

namespace jamskingcore20EF.Web.VisaViewModels
{
    public class DbVisaapiVisaInf_VMS
    {
        
        public int? VisaInfId { get; set; }
        public decimal? VisaPrice { get; set; }
        public decimal? VisaSettlement { get; set; }


        
        public string VisaName { get; set; }
        
        public string VisaNat { get; set; }
        public int? VisaType { get; set; }
        public int? VisaGOL { get; set; }
        public int? VisaSOM { get; set; }
        public double? VisaYear { get; set; }
        public double? VisaEXP { get; set; }
        public string CreatDate { get; set; }
        public string CreatUser { get; set; }
        public string ModifiedDate { get; set; }
        public string ModifiedUser { get; set; }
        public int? IsDel { get; set; }

       
    }
}
