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
const appBase_1 = require("../../00-AQX_Frame.commons/appBase");
const appService_1 = require("../../00-AQX_Frame.services/appService");
const router_1 = require("@angular/router");
let OrderDetailComponent = class OrderDetailComponent {
    constructor(_router) {
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
            imageUrls: ""
        };
        //抢单标识
        this.getOrderButtonIsDisabled = 1;
        this.router = _router;
    }
    //立即抢单
    getOrder() {
        var self = this;
        if (appService_1.appService.IsLogin(self.router).isLogin) {
            $.ajax({
                url: appBase_1.appBase.DomainApi + "api/Order/1",
                type: "put",
                dataType: "json",
                contentType: "application/json; charset=UTF-8",
                data: JSON.stringify({
                    "appKey": appService_1.appService.getCookie("appKey"),
                    "token": appService_1.appService.getCookie("token"),
                    "orderUid": self.order.orderUid,
                    "receiverLoginId": appService_1.appService.getCookie("loginId"),
                    "orderStatusId": 4
                }),
                success(data) {
                    if (data.isSuccess) {
                        alert("抢单成功~");
                        //这里可以进行跳转到订单详情页
                        //
                        self.getOrderButtonIsDisabled = 0;
                    }
                    else {
                        if (data.errorCode == 3022) {
                            alert("手慢一步，订单被别人抢啦~");
                        }
                        else {
                            alert("抢单失败，请重试！");
                        }
                    }
                },
                error(data) {
                    alert("服务器连接失败!请稍后重试...");
                }
            });
        }
    }
    GetOrderByOrderUid() {
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
                    self.publisherLoginId = data.data.publisherInfo.loginId;
                    self.orderCategoryName = data.data.orderCategory.CategoryName;
                    self.imageNameList = self.order.imageUrls.split('&');
                    self.imageSrcList = [];
                    for (var i = 0; i < self.imageNameList.length; i++) {
                        if (self.imageNameList[i] == "") {
                            self.imageNameList[i] = "default.jpg";
                        }
                        $.ajax({
                            url: appBase_1.appBase.DomainApi + 'api/Files/' + self.imageNameList[i],
                            type: "GET",
                            success: function (imageData) {
                                self.imageSrcList.push(imageData);
                            },
                            error: function (imageData) {
                                //self.imageSrcList.push("#");
                            }
                        });
                    }
                    //判断是否能点击
                    if (self.order.orderStatusId != "1") {
                        //如果不是未接单的状态，则不能进行抢单操作
                        self.getOrderButtonIsDisabled = 0;
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
    //the final execute ...
    ngOnInit() {
        this.GetOrderByOrderUid(); //通过OrderUid获取Order信息
        //var defaults = {
        //    thumbSize: 20,
        //    slideSpeed: 1500,
        //    auto: true,
        //    loop: true
        //};
        //$('.orderDetail_slider').tilesSlider($.extend({}, defaults, { x: 20, y: 1, effect: 'updown', cssSpeed: 500, backReverse: true }));
    }
};
OrderDetailComponent = __decorate([
    core_1.Component({
        selector: 'orderDetail',
        templateUrl: 'app/30-order/detail/detail.component.html',
        styleUrls: ['app/30-order/detail/detail.component.css'],
        providers: []
    }),
    __metadata("design:paramtypes", [router_1.Router])
], OrderDetailComponent);
exports.OrderDetailComponent = OrderDetailComponent;
//# sourceMappingURL=detail.component.js.map