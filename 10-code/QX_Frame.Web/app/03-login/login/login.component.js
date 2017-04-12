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
const Md5_service_1 = require("../../00-AQX_Frame.services/Md5.service");
const appBase_1 = require('../../00-AQX_Frame.commons/appBase');
//注入器的两种：NgModule/Component(只在当前及子组件中生效)
let LoginComponent = class LoginComponent {
    constructor() {
        this.loginUserModel = {
            loginId: "",
            pwd: ""
        };
        this.msg = "";
        this.sucMsg = "";
    }
    loginAccount() {
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
                url: appBase_1.appBase.DomainApi + "api/Login",
                type: "post",
                dataType: "json",
                contentType: "application/json; charset=UTF-8",
                data: JSON.stringify({
                    loginId: self.loginUserModel.loginId,
                    random: _random,
                    timeStamp: _timeStamp,
                    secretString: Md5_service_1.Md5.hashStr(self.loginUserModel.loginId + Md5_service_1.Md5.hashStr(self.loginUserModel.pwd) + _random + _timeStamp)
                }),
                success(data) {
                    if (data.isSuccess) {
                        self.sucMsg = "您已登录成功~";
                        //set cookie
                        document.cookie = "loginId=" + escape(self.loginUserModel.loginId);
                        document.cookie = "appKey=" + data.appKey;
                        document.cookie = "secretKey=" + data.secretKey;
                        document.cookie = "token=" + data.token;
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
    ngOnInit() {
    }
};
LoginComponent = __decorate([
    core_1.Component({
        selector: 'login',
        templateUrl: 'app/03-login/login/login.component.html',
        styleUrls: ['app/03-login/signup.component.css'],
        providers: [] //元数据中申明依赖
    }), 
    __metadata('design:paramtypes', [])
], LoginComponent);
exports.LoginComponent = LoginComponent;
//# sourceMappingURL=login.component.js.map