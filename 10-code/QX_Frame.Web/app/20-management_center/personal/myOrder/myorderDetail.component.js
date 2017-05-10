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
Object.defineProperty(exports, "__esModule", { value: true });
const core_1 = require("@angular/core");
const appBase_1 = require("../../../00-AQX_Frame.commons/appBase");
const appService_1 = require("../../../00-AQX_Frame.services/appService");
const router_1 = require("@angular/router");
let MyorderDetailComponent = class MyorderDetailComponent {
    constructor(_router) {
        this.isMyPublish = true; //是否为我的发布/接单的标识
        this.loginId = appService_1.appService.getCookie("loginId");
        this.balance = 0; //余额
        //模型绑定;
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
        this.orderUid = appService_1.appService.GetQueryString("orderUid");
        /**
         * 判断余额是否充足；
         */
        this.canPay = 'false';
        this.router = _router;
    }
    /**
     * *根据Id获取订单详情；
     */
    GetsingleOrderByOrderUid() {
        var self = this;
        //var orderUid = appService.GetQueryString("orderUid");
        $.ajax({
            url: appBase_1.appBase.DomainApi + "api/Order/" + self.orderUid,
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
                    self.publisherInfo = data.data.publisherInfo.loginId;
                    if (data.data.receiverInfo != null) {
                        self.receiverInfo = data.data.receiverInfo.loginId;
                    }
                    if (appService_1.appService.getCookie("loginId") == data.data.publisherInfo.loginId) {
                        self.isMyPublish = true; //我的发布
                    }
                    else {
                        self.isMyPublish = false; //我的接单
                    }
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
    //跳转到充值页；
    goPayment() {
        $('#paymentModal').modal('hide');
        this.router.navigateByUrl('/payment');
    }
    forPayment() {
        var self = this;
        if ((self.balance - Number(self.order.orderValue)) >= 0) {
            self.canPay = 'true';
        }
        else {
            self.canPay = 'false';
        }
    }
    /**
     * 获取账户余额；
     */
    getPersonalBalance() {
        var self = this;
        var appKey = Number(appService_1.appService.getCookie("appKey"));
        var token = appService_1.appService.getCookie("token");
        $.ajax({
            url: appBase_1.appBase.DomainApi + "api/UserMoney/" + self.loginId,
            type: "get",
            dataType: "json",
            contentType: "application/json; charset=UTF-8",
            data: {
                appKey: appKey,
                token: token
            },
            success(json) {
                if (json.isSuccess) {
                    self.balance = json.data.money;
                }
            },
            error(data) {
                console.error(data);
            }
        });
    }
    /**
     * 确认支付；
     */
    toPayment() {
        var self = this;
        var appKey = Number(appService_1.appService.getCookie("appKey"));
        var token = appService_1.appService.getCookie("token");
        $.ajax({
            url: appBase_1.appBase.DomainApi + "api/UserMoney/",
            type: "put",
            dataType: "json",
            contentType: "application/json; charset=UTF-8",
            data: JSON.stringify({
                appKey: appKey,
                token: token,
                loginId: self.loginId,
                money: -Number(self.order.orderValue)
            }),
            success(json) {
                if (json.isSuccess) {
                    self.UpdateOrderStatus(3); //修改订单状态
                    self.canPay = 'already';
                }
                else {
                    alert('支付失败，请稍后重试~');
                }
            },
            error(data) {
                console.error(data);
            }
        });
    }
    refresh() {
        this.router.navigateByUrl('/managementCenter');
    }
    /**
     * 修改订单状态
     * @param status 订单状态id
     */
    UpdateOrderStatus(status) {
        var self = this;
        $.ajax({
            url: appBase_1.appBase.DomainApi + "api/Order/2",
            type: "put",
            dataType: "json",
            contentType: "application/json; charset=UTF-8",
            data: JSON.stringify({
                "appKey": appService_1.appService.getCookie("appKey"),
                "token": appService_1.appService.getCookie("token"),
                "orderUid": self.orderUid,
                "receiverLoginId": appService_1.appService.getCookie("loginId"),
                "orderStatusId": status
            }),
            error(data) {
                alert("服务器连接失败!请稍后重试...");
            }
        });
    }
    //the final execute ...
    ngOnInit() {
        this.GetsingleOrderByOrderUid();
        this.getPersonalBalance();
    }
};
MyorderDetailComponent = __decorate([
    core_1.Component({
        selector: 'managementCenter',
        templateUrl: 'app/20-management_center/personal/myOrder/myorderDetail.component.html',
        styleUrls: ['app/20-management_center/personal/myOrder/myorderDetail.component.css'],
        providers: []
    }),
    __metadata("design:paramtypes", [router_1.Router])
], MyorderDetailComponent);
exports.MyorderDetailComponent = MyorderDetailComponent;
//# sourceMappingURL=myorderDetail.component.js.map