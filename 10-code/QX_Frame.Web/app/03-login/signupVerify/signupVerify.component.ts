import { Component, OnInit } from '@angular/core';
//import { LoginUserModel } from './../signup.model';
import { Md5 } from "../../00-AQX_Frame.services/Md5.service";
import { appService } from "../../00-AQX_Frame.services/appService";
import { appBase } from '../../00-AQX_Frame.commons/appBase';


declare function escape(s: string): string;
declare function unescape(s: string): string;

@Component({
    selector: 'signupVerify',
    templateUrl: 'app/03-login/signupVerify/signupVerify.component.html',
    styleUrls: ['app/03-login/signup.component.css'],
    providers: []   //元数据中申明依赖
})

export class SignupVerifyComponent implements OnInit {

    //loginUserModel: LoginUserModel = {
    //    loginId: "",
    //    pwd: ""
    //};
    
    msg: string = "";
    sucMsg: string = "";     

    ////the final execute ...
    ngOnInit(): void {
        var self = this;
        var timer = null;
        var initSec = 3;
        $.ajax({
            url: appBase.DomainApi + "api/User?loginId=" + appService.GetQueryString("loginId"),
            type: "post",
            dataType: "json",
            contentType: "application/json; charset=UTF-8",
            success(data) {
                //timer=setInterval 
                if (data.isSuccess) {
                    if (data.errorCode == 3003) {
                       self.msg = "验证链接已失效，请重新验证！";
                    }
                    else if (data.errorCode == 3004) {
                        self.msg="验证失败，请重新验证~"
                    }
                    else {
                        self.sucMsg = '邮箱验证成功，<span style="color:#e72015">' + initSec +'</span>S后自动登录~';
                        timer = setInterval(function () {
                            if (initSec > 0) {
                                initSec--;
                                self.sucMsg = '邮箱验证成功，<span style="color:#e72015">' + initSec + '</span>S后自动登录~';
                            } else {
                                clearInterval(timer);
                                window.location.href = appBase.WebUrlDomain;
                            }
                        }, 1000);
                    }
                }
                else {
                    self.msg = "邮箱验证失败，请重新注册~";
                }
            },
            error(data) {
                self.msg = "请求失败，请稍后重试~";
            }
        });
    }
}