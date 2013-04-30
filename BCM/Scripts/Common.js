////*************cookie处理*****************//
$.cookie = function (name, value, options) {
    if (typeof value != 'undefined') { // name and value given, set cookie
        options = options || {};
        if (value === null) {
            value = '';
            options.expires = -1;
        }
        var expires = '';
        if (options.expires && (typeof options.expires == 'number' || options.expires.toUTCString)) {
            var date;
            if (typeof options.expires == 'number') {
                date = new Date();
                date.setTime(date.getTime() + (options.expires * 24 * 60 * 60 * 1000));
            } else {
                date = options.expires;
            }
            expires = '; expires=' + date.toUTCString(); // use expires attribute, max-age is not supported by IE
        }
        var path = options.path ? '; path=' + options.path : '';
        var domain = options.domain ? '; domain=' + options.domain : '';
        var secure = options.secure ? '; secure' : '';
        document.cookie = [name, '=', encodeURIComponent(value), expires, path, domain, secure].join('');
    } else { // only name given, get cookie
        var cookieValue = null;
        if (document.cookie && document.cookie != '') {
            var cookies = document.cookie.split(';');
            for (var i = 0; i < cookies.length; i++) {
                var cookie = jQuery.trim(cookies[i]);
                // Does this cookie string begin with the name we want?
                if (cookie.substring(0, name.length + 1) == (name + '=')) {
                    cookieValue = decodeURIComponent(cookie.substring(name.length + 1));
                    break;
                }
            }
        }
        return cookieValue;
    }
};

// change color for single click ##################################################################################
//背景颜色
var lastobj = null;

function ChangBG(currentobj) {
    var obj = $(currentobj);
    if (lastobj == obj)
        return;
        
    if (lastobj)
        lastobj.removeClass("ObjSelectItem");
        
    obj.addClass("ObjSelectItem");
    lastobj = obj;
}

function SetCurentRow(obj) {
    if (lastobj != obj) {
        ChangBG(obj);
        var rdiObj = $(obj).find("input:radio:first");
        if (rdiObj) {
            rdiObj.attr("checked", true);
        }
    }
}
function InitRowSelect() {
    var arrList = $(".GridItem");
    if (arrList) {
        arrList.each(function (i, o) {
            var obj = $(o);
            obj.click(function () {
                SetCurentRow(o);
            });
        });
    }
}
/**************设置所选择项事件***************/
setTimeout(InitRowSelect, 500);

function request(paras) {
    var url = location.href;
    var paraString = url.substring(url.indexOf("?") + 1, url.length).split("&");
    var paraObj = {}
    for (i = 0; j = paraString[i]; i++) {
        paraObj[j.substring(0, j.indexOf("=")).toLowerCase()] = j.substring(j.indexOf("=") + 1, j.length);
    }
    var returnValue = paraObj[paras.toLowerCase()];
    if (typeof (returnValue) == "undefined") {
        return "";
    } else {
        return returnValue;
    }
}

