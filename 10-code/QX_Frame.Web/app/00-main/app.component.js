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
const appService_1 = require("../00-AQX_Frame.services/appService");
const appBase_1 = require("../00-AQX_Frame.commons/appBase");
const router_1 = require('@angular/router');
let AppComponent = class AppComponent {
    constructor(_router) {
        this.title = 'Ant Help';
        this.loginResult = {};
        //获取消息
        this.messageCount = 0;
        this.router = _router;
    }
    //个人中心菜单点击 切换
    setCenterStatus(num) {
        appBase_1.appBase.AppObject.centerStatus = num;
        //window.location.href = appBase.WebUrlDomain + "managementCenter";
        var manageCenterUl = $(".manageCenterUl li");
        manageCenterUl.removeClass("on");
        manageCenterUl.eq(appBase_1.appBase.AppObject.centerStatus).addClass("on");
        //内容切换；
        //manageCenterUl.eq(appBase.AppObject.centerStatus).click(event, appBase.AppObject.centerStatus);
        //manageCenterUl.eq(num).trigger('click', {event,num});
    }
    GetMessagePushList() {
        var self = this;
        $.ajax({
            url: appBase_1.appBase.DomainApi + "api/MessagePush",
            type: "get",
            dataType: "json",
            contentType: "application/json; charset=UTF-8",
            data: {
                "appKey": appService_1.appService.getCookie("appKey"),
                "token": appService_1.appService.getCookie("token"),
                "messagePushStatusId": 0,
                "loginId": appService_1.appService.getCookie("loginId"),
                "pageIndex": 1,
                "pageSize": 10,
                "isDesc": true
            },
            success(data) {
                if (data.isSuccess) {
                    self.messageCount = data.dataCount;
                }
                else {
                }
            },
            error(data) {
                //alert("服务器连接失败，请稍后重试...");
            }
        });
    }
    ngOnInit() {
        this.loginResult = appService_1.appService.IsLogin(this.router);
        //get message count
        this.GetMessagePushList();
    }
};
AppComponent = __decorate([
    core_1.Component({
        selector: 'my-app',
        templateUrl: 'app/00-main/app.component.html',
        styleUrls: ['app/00-main/app.component.css']
    }), 
    __metadata('design:paramtypes', [router_1.Router])
], AppComponent);
exports.AppComponent = AppComponent;
//# sourceMappingURL=app.component.js.map