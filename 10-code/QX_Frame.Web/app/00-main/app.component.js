"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
const core_1 = require("@angular/core");
const appService_1 = require("../00-AQX_Frame.services/appService");
const appBase_1 = require("../00-AQX_Frame.commons/appBase");
let AppComponent = class AppComponent {
    constructor() {
        this.title = 'Ant Help';
        this.loginResult = appService_1.appService.IsLogin();
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
};
AppComponent = __decorate([
    core_1.Component({
        selector: 'my-app',
        templateUrl: 'app/00-main/app.component.html',
        styleUrls: ['app/00-main/app.component.css'],
    })
], AppComponent);
exports.AppComponent = AppComponent;
//# sourceMappingURL=app.component.js.map