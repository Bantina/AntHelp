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
const appBase_1 = require('../../../00-AQX_Frame.commons/appBase');
const appService_1 = require('../../../00-AQX_Frame.services/appService');
const router_1 = require('@angular/router');
let ComplaintComponent = class ComplaintComponent {
    constructor(_router) {
        //------- complain ------------------
        //投诉信息
        this.complainModel = {
            complainUid: "",
            complainContent: "",
            complainUserUid: "",
            complainTime: "",
            complainStatusId: 0,
            complainStatusName: ""
        };
        this.router = _router;
    }
    SendComplain() {
        var self = this;
        $.ajax({
            url: appBase_1.appBase.DomainApi + "api/Complain",
            type: "post",
            dataType: "json",
            contentType: "application/json; charset=UTF-8",
            data: JSON.stringify({
                "appKey": appService_1.appService.getCookie("appKey"),
                "token": appService_1.appService.getCookie("token"),
                "complainContent": self.complainModel.complainContent
            }),
            success(data) {
                if (data.isSuccess) {
                    alert("谢谢您的建议，请耐心等待我们的回复~");
                    self.complainModel.complainContent = "";
                }
                else {
                    console.error(data.msg);
                }
            },
            error(data) {
                alert("服务器连接失败，请稍后重试...");
            }
        });
    }
    //------complain end -----------------
    //the final execute ...
    ngOnInit() {
        appService_1.appService.IsLogin(this.router);
    }
};
ComplaintComponent = __decorate([
    core_1.Component({
        selector: 'complaint',
        templateUrl: 'app/20-management_center/personal/complaint/complaint.component.html',
        styleUrls: ['app/20-management_center/personal/complaint/complaint.component.css'],
        providers: []
    }), 
    __metadata('design:paramtypes', [router_1.Router])
], ComplaintComponent);
exports.ComplaintComponent = ComplaintComponent;
//# sourceMappingURL=complaint.component.js.map