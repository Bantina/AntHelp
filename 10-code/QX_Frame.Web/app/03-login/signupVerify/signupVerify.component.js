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
const appService_1 = require("../../00-AQX_Frame.services/appService");
const appBase_1 = require('../../00-AQX_Frame.commons/appBase');
let SignupVerifyComponent = class SignupVerifyComponent {
    constructor() {
        //loginUserModel: LoginUserModel = {
        //    loginId: "",
        //    pwd: ""
        //};
        this.msg = "";
        this.sucMsg = "";
    }
    ////the final execute ...
    ngOnInit() {
        var self = this;
        var timer = null;
        var initSec = 3;
        $.ajax({
            url: appBase_1.appBase.DomainApi + "api/User?loginId=" + appService_1.appService.GetQueryString("loginId"),
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
                        self.msg = "验证失败，请重新验证~";
                    }
                    else {
                        self.sucMsg = "邮箱验证成功，" + initSec + "S后自动登录~";
                        timer = setInterval(function () {
                            if (initSec > 0) {
                                initSec--;
                                self.sucMsg = "邮箱验证成功，" + initSec + "S后自动登录~";
                            }
                            else {
                                clearInterval(timer);
                                window.location.href = appBase_1.appBase.WebUrlDomain;
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
};
SignupVerifyComponent = __decorate([
    core_1.Component({
        selector: 'signupVerify',
        templateUrl: 'app/03-login/signupVerify/signupVerify.component.html',
        styleUrls: ['app/03-login/signup.component.css'],
        providers: [] //元数据中申明依赖
    }), 
    __metadata('design:paramtypes', [])
], SignupVerifyComponent);
exports.SignupVerifyComponent = SignupVerifyComponent;
//# sourceMappingURL=signupVerify.component.js.map