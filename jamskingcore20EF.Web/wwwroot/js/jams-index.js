(function ($) {
    function JamsCon() {
        var $this = this;

        function initilizeModel() {
            $("#modal-action-jams").on('loaded.bs.modal', function (e) {
            }).on('hidden.bs.modal', function (e) {
                $(this).removeData('bs.modal');
            });
        }
        $this.init = function () {
            initilizeModel();
        }
    }
    $(function () {
        var self = new JamsCon();
        self.init();
    })
}(jQuery))
