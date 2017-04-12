"use strict";
const appBase_1 = require('../00-AQX_Frame.commons/appBase');
class appService {
    //获取url请求参数name值；
    static GetQueryString(name) {
        var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
        var r = window.location.search.substr(1).match(reg);
        if (r != null)
            return unescape(r[2]);
        return null;
    }
    //Cookie设置
    static setCookie(c_name, value, expiredays) {
        var exdate = new Date();
        exdate.setDate(exdate.getDate() + expiredays);
        // document.cookie = c_name + "=" + escape(value) +
        //((expiredays == null) ? "" : ";expires=" + exdate.toGMTString())
    }
    //判断用户是否登录
    static IsLogin(loginId, appKey, secretKey, token) {
        $.ajax({
            url: appBase_1.appBase.DomainApi + "api/User?loginId=" + loginId,
            type: "post",
            dataType: "json",
            contentType: "application/json; charset=UTF-8",
            success(data) {
                //timer=setInterval 
                if (data.isSuccess) {
                    return true;
                }
                else {
                    return false;
                }
            },
            error(data) {
                return false;
            }
        });
        return true;
    }
}
exports.appService = appService;
//# sourceMappingURL=appService.js.map