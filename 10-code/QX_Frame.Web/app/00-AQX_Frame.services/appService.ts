import { appBase } from '../00-AQX_Frame.commons/appBase';
import { AppKeyTokenModel } from '../00-AQX_Frame.models/AppKeyTokenModel';

declare function escape(s: string): string;
declare function unescape(s: string): string;
export class appService {
     //获取url请求参数name值；
    static GetQueryString(name: string): string {
        var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
        var r = window.location.search.substr(1).match(reg);
        if (r != null) return unescape(r[2]); return null;
    }

    //创建Cookie(名称、值以、过期天数)
    static setCookie(c_name: string, value: string, expiredays: number): void{
        var exdate = new Date();
        exdate.setDate(exdate.getDate() + expiredays); //set valid expires；
        document.cookie = c_name + "=" + escape(value) +
            ((expiredays == null) ? "" : ";expires=" + exdate.toUTCString()); //toUTCString() instead of toGMTString()
    }

    //获取Cookie值
    static getCookie(c_name: string): string{
        var c_start, c_end;
        if (document.cookie.length > 0) {
            c_start = document.cookie.indexOf(c_name + "=");
            if (c_start != -1) {
                c_start = c_start + c_name.length + 1;
                c_end = document.cookie.indexOf(";", c_start);
                if (c_end == -1) c_end = document.cookie.length;
                return unescape(document.cookie.substring(c_start, c_end));
            }
        }
        return "";
    }

    //判断用户是否登录
    static IsLogin(): any {
        var appKey = Number(appService.getCookie("appKey"));
        var token = appService.getCookie("token");
        var _random = Math.ceil(Math.random() * 1000);
        var _timeStamp = Number((new Date()).valueOf());
        var loginResult = {
            isLogin: false,
            loginId:""
        }
        //当cookie值为空时，未登录；
        if (appKey == 0 || appKey == null || appKey == NaN) return loginResult;

        else {
            $.ajax({
                //url: appBase.DomainApi + "api/Login?appKey=" + appKey + "&random" + _random + "&timeStamp" + _timeStamp + "&token" + token,
                url: appBase.DomainApi + "api/Login",
                type: "get",
                dataType: "json",
                contentType: "application/json; charset=UTF-8",
                data: {
                    appKey: appKey,
                    random: _random,
                    timeStamp: _timeStamp,
                    token: token
                },
                success(data) {
                    //timer=setInterval 
                    if (data.isSuccess) {
                        loginResult.isLogin = true;
                        loginResult.loginId = data.data.loginId;
                    }
                },
                error(data) {

                }
            });
        }
        return loginResult;
    }

    //get token from cookie
    private static appKeyTokenModel: AppKeyTokenModel;
    static GetAppKeyToken(): AppKeyTokenModel
    {
        this.appKeyTokenModel.appKey = appService.getCookie("appKey");
        this.appKeyTokenModel.token = appService.getCookie("token");
        this.appKeyTokenModel.loginId = appService.getCookie("loginId");
        return this.appKeyTokenModel;
    }
 
}