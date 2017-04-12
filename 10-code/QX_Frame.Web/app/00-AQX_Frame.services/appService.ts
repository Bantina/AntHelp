import { appBase } from '../00-AQX_Frame.commons/appBase';

declare function escape(s: string): string;
declare function unescape(s: string): string;
export class appService {
     //获取url请求参数name值；
    static GetQueryString(name: string): string {
        var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
        var r = window.location.search.substr(1).match(reg);
        if (r != null) return unescape(r[2]); return null;
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