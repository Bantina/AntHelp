import { Component, OnInit } from '@angular/core';
import { LoginUserModel } from './../signup.model';
import { Md5 } from "../../00-AQX_Frame.services/Md5.service";
import { appBase } from '../../00-AQX_Frame.commons/appBase';
import { appService } from '../../00-AQX_Frame.services/appService';

declare function escape(s: string): string;
//注入器的两种：NgModule/Component(只在当前及子组件中生效)
@Component({
    selector: 'login',
    templateUrl: 'app/03-login/login/login.component.html',
    styleUrls: ['app/03-login/signup.component.css'],
    providers: []   //元数据中申明依赖
})

export class LoginComponent implements OnInit {

    loginUserModel: LoginUserModel = {
        loginId: "",
        pwd: ""
    };

    msg: string = "";
    sucMsg: string = "";

    loginAccount(): void {   
        var self = this;
        self.msg = "";
        self.sucMsg = "";
        var _random = Math.ceil(Math.random() * 1000);
        var _timeStamp = (new Date()).valueOf();

        if (self.loginUserModel.loginId == "") {
            self.msg = "用户名不能为空！";
        }
        else if (self.loginUserModel.pwd == "") {
            self.msg = "密码不能为空！";
        }
        else {
            self.msg = "";
            $.ajax({
                url: appBase.DomainApi + "api/Login",
                type: "post",
                dataType: "json",
                contentType: "application/json; charset=UTF-8",
                data: JSON.stringify(
                    {
                        loginId: self.loginUserModel.loginId,
                        random: _random,
                        timeStamp: _timeStamp,
                        secretString: Md5.hashStr(self.loginUserModel.loginId + Md5.hashStr(self.loginUserModel.pwd) + _random + _timeStamp)
                    }),
                success(data) {
                    if (data.isSuccess) {
                        self.sucMsg = "您已登录成功~";
                        //set cookie
                        appService.setCookie("loginId", self.loginUserModel.loginId,7);
                        appService.setCookie("appKey", data.appKey,7);
                        appService.setCookie("secretKey", data.secretKey,7);
                        appService.setCookie("token", data.token, 7);
                        //document.cookie = "loginId=" + escape(self.loginUserModel.loginId);
                        //document.cookie = "appKey=" + data.appKey;
                        //document.cookie = "secretKey=" + data.secretKey;
                        //document.cookie = "token=" + data.token;
                        //页面跳转
                        window.location.href = appBase.WebUrlDomain;
                    }
                    else {
                        if (data.errorCode == 3001) {
                            self.msg = "该用户尚未注册~";
                        }
                        else if (data.errorCode == 3006) {
                            self.msg = "请求超时，请稍后重试~";
                        }
                        else if (data.errorCode == 3007) {
                            self.msg = "不能重复请求登录~";
                        }
                        else if (data.errorCode == 3008) {
                            self.msg = "用户名或密码错误！";
                        }
                        else {
                            self.msg = "服务器请求出错，请稍后重试~";
                        }
                    }
                },
                error(data) {
                    self.msg = "请求失败，请稍后重试~";
                }
            });
        }

    }

    ////the final execute ...
    ngOnInit(): void {

    }
}