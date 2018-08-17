using System;
using System.Collections.Generic;

namespace jamskingcore20EF.Model.VisaModels
{
    public partial class DbVisaapiVisaFile
    {
        public int VisaFileId { get; set; }
        public string VisaFileName { get; set; }
        public string VisaToDoCode { get; set; }
        public int? VisaToDoId { get; set; }
        public int? VisaConId { get; set; }
        public int? VisaInfId { get; set; }
        public string VisaConName { get; set; }
        public string VisaConNtext { get; set; }
        public decimal? VisaConAgeLim { get; set; }
        public int? VisaConJobType { get; set; }
        public int? VisaConMst { get; set; }
        public int? VisaConSex { get; set; }
        public int? VisaConType { get; set; }
        public int? VisaConSign { get; set; }
        public int? VisaConOpt { get; set; }
        public int? VisaFileAtta { get; set; }
        public int? VisaFileRe { get; set; }
        public int? VisaConFitem { get; set; }
        public int? VisaFileFitemAn { get; set; }
        public DateTime? CreatDate { get; set; }
        public string CreatUser { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedUser { get; set; }
        public int? IsDel { get; set; }
        public string VisaFileAntext { get; set; }

        public DbVisaapiVisaToDo VisaToDo { get; set; }
    }
}
