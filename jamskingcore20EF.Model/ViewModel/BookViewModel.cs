using System.ComponentModel.DataAnnotations;

namespace jamskingcore20EF.Model.ViewModel
{
    public class BookViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "ISBN No")]
        public string ISBN { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
    }
}
