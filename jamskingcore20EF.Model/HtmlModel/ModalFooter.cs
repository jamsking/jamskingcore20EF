namespace jamskingcore20EF.Model.HtmlModel

{
    public class ModalFooter
    {
        public string SubmitButtonText { get; set; } = "确认";
        public string CancelButtonText { get; set; } = "取消";
        public string SubmitButtonID { get; set; } = "btn-submit";
        public string CancelButtonID { get; set; } = "btn-cancel";
        public bool OnlyCancelButton { get; set; }
    }
}