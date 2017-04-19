"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
const core_1 = require("@angular/core");
const appService_1 = require("../../../00-AQX_Frame.services/appService");
let MyorderDetailComponent = class MyorderDetailComponent {
    constructor() {
        //模型绑定;
        this.userInfoModel = {
            loginId: appService_1.appService.getCookie('loginId'),
            nickName: '',
            headImageUrl: "../../Images/20-management/user_default_img.png",
            email: "4527875@foxmail.com",
            phone: "18254688788",
            position: "天津市西青区",
            appKey: Number(appService_1.appService.getCookie('appKey')),
            token: appService_1.appService.getCookie('token'),
            age: 21,
            sexId: 0,
            birthday: '2017-04-16',
            bloodTypeId: 0,
            school: '',
            location: '',
            company: '',
            constellation: '',
            chineseZodiac: '',
            personalizedSignature: '',
            personalizedDescription: ''
        };
    }
    //the final execute ...
    ngOnInit() {
    }
};
MyorderDetailComponent = __decorate([
    core_1.Component({
        selector: 'managementCenter',
        templateUrl: 'app/20-management_center/personal/myOrder/myorderDetail.component.html',
        styleUrls: ['app/20-management_center/personal/myOrder/myorderDetail.component.css'],
        providers: []
    })
], MyorderDetailComponent);
exports.MyorderDetailComponent = MyorderDetailComponent;
//# sourceMappingURL=myorderDetail.component.js.map