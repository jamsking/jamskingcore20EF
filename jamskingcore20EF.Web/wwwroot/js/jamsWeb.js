// Write your Javascript code.
var jamsWeb = function () {
    var now = new Date();
    return {
        getUser: function () {
            $.post("/user/getlogin?t=" + now.getTime(), function (data) {
                if (data) {
                    if (data.IsOk && data !== null) {
                        var user = data.Data;
                        $('.user-info').append(user.UserName);
                    }
                }
            });
        }
    }
}
//初始化
var jamsWeb = new jamsWeb();
//用户信息
jamsWeb.getUser();
