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
let MyorderDetailComponent = class MyorderDetailComponent {
    constructor() {
        //模型绑定;
        this.userInfoModel = {
            loginId: appService_1.appService.getCookie('loginId'),
            nickName: '',
            headImageUrl: "../../Images/20-management/user_default_img.png",
            email: "4527875@foxmail.com",
            phone: "18254688788",
            position: "",
            age: 21,
            sexId: 0,
            birthday: '2017-04-16',
            bloodTypeId: 0,
            school: '',
            location: '天津市西青区',
            company: '',
            constellation: '',
            chineseZodiac: '',
            personalizedSignature: '',
            personalizedDescription: '',
            registerTime: '',
            statusId: 0,
            statusName: '',
            statusDescription: '正常',
            roleId: 0,
            roleName: '',
            roleDescription: '普通用户'
        };
        this.order = {
            orderUid: "",
            publisherUid: "",
            publishTime: "",
            orderDescription: "",
            orderCategoryId: "10",
            receiverUid: "",
            receiveTime: "",
            orderStatusId: "",
            orderValue: "0",
            allowVoucher: "",
            voucherMax: "",
            evaluateUid: "",
            address: "",
            phone: "",
            imageUrls: "",
            imageDatas: []
        };
    }
    GetsingleOrderByOrderUid() {
        var self = this;
        var orderUid = appService_1.appService.GetQueryString("orderUid");
        $.ajax({
            url: appBase_1.appBase.DomainApi + "api/Order/" + orderUid,
            type: "get",
            dataType: "json",
            contentType: "application/json; charset=UTF-8",
            data: {
                //"id": orderUid,
                "appKey": appService_1.appService.getCookie("appKey"),
                "token": appService_1.appService.getCookie("token")
            },
            success(data) {
                var _html = '';
                if (data.isSuccess) {
                    self.order.publisherUid = data.data.publisherUid;
                    self.order.orderUid = data.data.orderUid;
                    self.order.publishTime = data.data.publishTime;
                    self.order.orderDescription = data.data.orderDescription;
                    self.order.orderCategoryId = data.data.orderCategoryId;
                    self.order.receiverUid = data.data.receiverUid;
                    self.order.receiveTime = data.data.receiveTime;
                    self.order.orderStatusId = data.data.orderStatusId;
                    self.order.orderValue = data.data.orderValue;
                    self.order.allowVoucher = data.data.allowVoucher;
                    self.order.voucherMax = data.data.voucherMax;
                    self.order.evaluateUid = data.data.evaluateUid;
                    self.order.address = data.data.address;
                    self.order.phone = data.data.phone;
                    self.order.imageUrls = data.data.imageUrls;
                    self.order.imageDatas = data.data.imageDatas;
                    ////
                    self.orderStatus = data.data.orderStatus.orderStatusDescription;
                }
                else {
                    alert(data.msg);
                }
            },
            error(data) {
                alert("服务器错误！");
            }
        });
    }
    //the final execute ...
    ngOnInit() {
        this.GetsingleOrderByOrderUid();
    }
};
MyorderDetailComponent = __decorate([
    core_1.Component({
        selector: 'managementCenter',
        templateUrl: 'app/20-management_center/personal/myOrder/myorderDetail.component.html',
        styleUrls: ['app/20-management_center/personal/myOrder/myorderDetail.component.css'],
        providers: []
    }), 
    __metadata('design:paramtypes', [])
], MyorderDetailComponent);
exports.MyorderDetailComponent = MyorderDetailComponent;
//# sourceMappingURL=myorderDetail.component.js.map