// 
// 
// 
/** 
* function:是否存在特定的值
* @para radioName radio名称
* @para svalue 被查找的值
* @return true(存在)
*/
/**
function jamsradiocreate(parentId, eleType, eleName, eleId, eleValue, eleText, eleChecked) {
    var board = document.getElementById(parentId);
    var e = jamsradiocreateElement("input", eleName);
    e.type = eleType;
    e.id = eleId;
    e.value = eleValue;
    board.appendChild(e);
    //设置选中 
    if (eleChecked=="checked") {
        e.setAttribute("checked", eleChecked);
    }
    //添加文字  
    board.appendChild(document.createTextNode(eleText));
}

function jamsradiocreate(parentId, eleType, eleName, eleId, eleValue, eleText, eleChecked) {
    var vs = $("#textbox").val().split(',');
    var app = "";
    for (var i = 0; i < vs.length; i++) {
        app = app + "<input type=\"radio\" name='cb' id=\"rd" + i + "\" value=\"" + vs[i] + "\"  />" + vs[i] + "</br>";
    }
    $("#content").append(app);
    var board = document.getElementById(parentId);
    var e = jamsradiocreateElement("input", eleName);
    e.type = eleType;
    e.id = eleId;
    e.value = eleValue;
    board.appendChild(e);
    //设置选中 
    if (eleChecked == "checked") {
        e.setAttribute("checked", eleChecked);
    }
    //添加文字  
    board.appendChild(document.createTextNode(eleText));
}

function jamsradiocreateElement(type, name) {
    var element = null;
    try {
        // First try the IE way; if this fails then use the standard way    
        element = document.createElement_x('<' + type + ' name="' + name + '">');
    } catch (e) {
        // Probably failed because we’re not running on IE  
    }
    if (!element) {
        element = document.createElement(type);
        element.name = name;
    }
    return element;
}
function Jams_Radio_ExistSpecialValue(radioName, svalue) {

    $("input[type=radio][@name=" + radioName + "]").each(function () {
        if (this.value == svalue) {
            return true;
        }
    });
    return false;
}

function jams2Create() {
    var vs = $("#textbox").val().split(',');
    var app = "";
    for (var i = 0; i < vs.length; i++) {
        app = app + "<input type=\"radio\" name='cb' id=\"rd" + i + "\" value=\"" + vs[i] + "\"  />" + vs[i] + "</br>";
    }
    $("#content").append(app);
}

function jams2Get() {
    var sele = $("input:radio[name='cb']:checked");
    alert(sele.val());
}
/** 
 * function:全部取消选中
 * @para radioName radio名称
 * @para svalue 被查找的值
 */
/*
function Jams_Radio_SelectSpeciaItem(radioName, svalue) {
    //$("input[name='chkCity']").attr("checked","false"); //这个有问题,不能实现全部取消的效果
    $("input[type=radio][@name=" + radioName + "]").each(function () {
        if (this.value == svalue) {
            this.checked = true;
        }
    });
}



/** 
 * function:查看选中的值
 * @para radioName radio名称
 * @return 选中的值, 如果有多个,使用逗号隔开
 */
/*
function Jams_Radio_GetSelectedValue(radioName) {
    var sltvalue = "";
    var isHave = false;
    //alert($("intput[name=chkCity][checked]").val());
    $("input[type=radio][@name=" + radioName + "][@checked]").each(function () {
        if (this.checked) {
            sltvalue += this.value;
            sltvalue += ",";
        }
    });

    if ("" != sltvalue) {
        var length = sltvalue.length;
        sltvalue = sltvalue.substring(0, length - 1);
    }

    return sltvalue;
}

/**
 * function: 取消选中状态
 * @para radio的名称
 */
/*
function Jams_Radio_CancalSelectAll(radioName) {
    $("input[type=radio][@name=" + radioName + "]").each(function () {
        this.checked = false;
    });
}
*/
//----------------------------

(function ($) {
    //1.定义jquery的扩展方法radiocombobox
    $.fn.radiocombobox = function (options, param) {
        if (typeof options == 'string') {
            return $.fn.radiocombobox.methods[options](this, param);
        }
        //2.将调用时候传过来的参数和default参数合并
        options = $.extend({}, $.fn.radiocombobox.defaults, options || {});
        //3.添加默认值
        var target = $(this);
        target.attr('valuefield', options.valueField);
        target.attr('textfield', options.textField);
        target.attr('namefield', options.nameField);
        target.empty();
        //var option = $('<input/>');
        //option.attr('value', '');
        //option.text(options.placeholder);
        //target.append(option);
        //4.判断用户传过来的参数列表里面是否包含数据data数据集，如果包含，不用发ajax从后台取，否则否送ajax从后台取数据
        if (options.data) {
            init(target, options.data);
        }
        else {
            //var param = {};
            options.onBeforeLoad.call(target, options.param);
            if (!options.url) return;
            $.getJSON(options.url, options.param, function (data) {
                init(target, data);
            });
        }
        function init(target, data) {
            $.each(data, function (i, item) {
                var option = $('<input>');
                option.attr('type', 'radio');
                option.attr('name', item[options.nameField]);
                option.attr('value', item[options.valueField]);
                option.attr('id', item[options.nameField] + item[options.valueField]);
                target.append(option);
                target.append(item[options.textField]);
            });
            options.onLoadSuccess.call(target);
        }
        target.unbind("change");
        target.on("change", function (e) {
            if (options.onChange)
                return options.onChange(target.val());
        });
    }

    //5.如果传过来的是字符串，代表调用方法。
    $.fn.radiocombobox.methods = {
        getValue: function (jq) {
            return jq.val();
        },
        setValue: function (jq, param) {
            jq.val(param);
        },
        load: function (jq, url) {
            $.getJSON(url, function (data) {
                jq.empty();
                //var option = $('<input>');
                //option.attr('value', '');
                //option.text('请选择');
                //option.attr('name', '');
                //jq.append(option);
                $.each(data, function (i, item) {
                    var option = $('<input>');
                    option.attr('type', 'radio');
                    option.attr('value', item[jq.attr('valuefield')]);
                    option.attr('name', item[jq.attr('namefield')]);
                    option.attr('id', item[jq.attr('namefield')] + item[jq.attr('valuefield')]);
                    jq.append(option);
                    jq.append(item[jq.attr('textfield')]);
                    
                });
            });
        }
    };

    //6.默认参数列表
    $.fn.radiocombobox.defaults = {
        url: null,
        param: null,
        data: null,
        valueField: 'value',
        textField: 'text',
        nameField:'name',
        placeholder: '请选择',
        onBeforeLoad: function (param) { },
        onLoadSuccess: function () { },
        onChange: function (value) { }
    };
})(jQuery);