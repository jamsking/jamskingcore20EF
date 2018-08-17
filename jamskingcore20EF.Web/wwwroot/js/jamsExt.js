(function ($) {
    $jams = {
        openDialog: function (options, callback) {
            if (!options) {
                $r.alert("参数错误！");
            }
            callback = callback || options.callback;
            if (options.callback) {
                delete options.callback;
            }
            var wh = $jams.windowHeight();
            options.height = options.height || wh;
            if (options.height > wh) {
                options.height = wh;
            }
            options.content = options.content || options.url;
            options = $.extend(options, {
                type: 2,
                shadeClose: true,
                shade: 0.3,
                success: function (layero, index) {
                    var iframe = layero.find('iframe')[0];
                    iframe.callback = callback;
                }
            });
            return layer.open(options);
        },
        windowHeight: function () {
            var pw = window;
            while (pw !== pw.parent) {
                pw = pw.parent;
            }
            return $(pw).height();
        },
        callbackDialog: function (result, isclose) {
            if (frameElement) {
                //弹出框架打开
                if (frameElement.callback) {
                    frameElement.callback(result);
                }
                if (isclose) {
                    $jams.closeDialog();
                     
                }
            }
            else {
                $jams.msg("操作成功！");
            }
        },
        closeDialog: function () {
            if (frameElement) {
                //弹出框架打开
                var index = parent.layer.getFrameIndex(window.name); //先得到当前iframe层的索引
                parent.layer.close(index); //再执行关闭
            }
            else {
                //刷新父窗口
                return window.opener.location.reload();window.close();
            }
        },
        closeDialogByIndex: function (index) {
            layer.close(index);
        },
        msg: function (message) {
            layer.msg(message);
        },
        alert: function (message) {
            layer.alert(message);
        }
        
    }
})(jQuery)