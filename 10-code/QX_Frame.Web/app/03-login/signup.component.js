"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
const core_1 = require('@angular/core');
const Md5_service_1 = require("../00-AQX_Frame.services/Md5.service");
const appBase_1 = require('../00-AQX_Frame.commons/appBase');
//注入器的两种：NgModule/Component(只在当前及子组件中生效)
let SignUpComponent = class SignUpComponent {
    constructor() {
        this.userAccountViewModel = {
            loginId: "",
            pwd: "",
            email: "",
            emailHtmlRoute: "signupVerify"
        };
        this.repassword = "";
        this.isEmail = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
        this.msg = "";
        this.sucMsg = "";
    }
    addAccount() {
        var self = this;
        //self.requestResult = self.signupService.AddAccount(self.userAccountViewModel)
        //    .then(function (response) {
        //        var data = response.json();
        //        console.log(data);
        //        if (data.isSuccess) {
        //            self.msg = data.msg;
        //        }
        //        else {
        //            self.msg = data.msg;
        //        }
        //        self.msg = data.msg;
        //    })
        self.msg = "";
        self.sucMsg = "";
        if (self.userAccountViewModel.loginId == "") {
            self.msg = "用户名不能为空！";
        }
        else if (self.userAccountViewModel.loginId.length < 3) {
            self.msg = "用户名不能小于3位！";
        }
        else if (self.userAccountViewModel.email == "") {
            self.msg = "邮箱不能为空！";
        }
        else if (!self.isEmail.test(self.userAccountViewModel.email)) {
            self.msg = "邮箱格式输入有误！";
        }
        else if (self.userAccountViewModel.pwd == "") {
            self.msg = "密码不能为空！";
        }
        else if (self.repassword == "") {
            self.msg = "确认密码不能为空！";
        }
        else if (self.userAccountViewModel.pwd !== self.repassword) {
            self.msg = "密码和确认密码不一致！";
        }
        else {
            self.msg = "";
            $.ajax({
                url: appBase_1.appBase.DomainApi + "api/Account",
                type: "post",
                dataType: "json",
                contentType: "application/json; charset=UTF-8",
                data: JSON.stringify({
                    loginId: self.userAccountViewModel.loginId,
                    pwd: Md5_service_1.Md5.hashStr(self.userAccountViewModel.pwd).toString(),
                    email: self.userAccountViewModel.email,
                    emailHtmlRoute: self.userAccountViewModel.emailHtmlRoute
                }),
                success(data) {
                    if (data.isSuccess) {
                        self.sucMsg = "注册邮件已发送到您的邮箱，请查收并点击邮箱中的连接完成注册！";
                        //set cookie2
                        document.cookie = "loginId=" + escape(data.loginId);
                        document.cookie = "appKey=" + data.appKey;
                        document.cookie = "secretKey=" + data.secretKey;
                        document.cookie = "token=" + data.token;
                    }
                    else if (data.errorCode == 3002) {
                        self.msg = "该用户已注册过，请直接登录~";
                    }
                    else {
                        self.msg = "服务器请求出错，请稍后重试~";
                    }
                },
                error(data) {
                    alert(JSON.stringify(data));
                }
            });
        }
    }
    ////the final execute ...
    ngOnInit() {
    }
};
SignUpComponent = __decorate([
    core_1.Component({
        selector: 'signup',
        templateUrl: 'app/03-login/signup.component.html',
        styleUrls: ['app/03-login/signup.component.css'],
        providers: [] //元数据中申明依赖
    }), 
    __metadata('design:paramtypes', [])
], SignUpComponent);
exports.SignUpComponent = SignUpComponent;
//# sourceMappingURL=signup.component.js.map