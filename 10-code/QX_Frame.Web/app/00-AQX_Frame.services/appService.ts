import { appBase } from '../00-AQX_Frame.commons/appBase';

declare function escape(s: string): string;
declare function unescape(s: string): string;
declare function toGMTString(): string;
export class appService {
     //获取url请求参数name值；
    static GetQueryString(name: string): string {
        var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
        var r = window.location.search.substr(1).match(reg);
        if (r != null) return unescape(r[2]); return null;
    }

    //Cookie设置
    static setCookie(c_name, value, expiredays): void{
        var exdate = new Date()
        exdate.setDate(exdate.getDate() + expiredays)
       // document.cookie = c_name + "=" + escape(value) +
            //((expiredays == null) ? "" : ";expires=" + exdate.toGMTString())
    }

    //判断用户是否登录
    static IsLogin(loginId: string, appKey: string, secretKey: string, token: string): boolean {
        $.ajax({
            url: appBase.DomainApi + "api/User?loginId=" + loginId,
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