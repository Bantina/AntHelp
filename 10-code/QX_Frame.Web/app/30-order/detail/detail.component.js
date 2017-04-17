"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
const core_1 = require("@angular/core");
const appBase_1 = require("../../00-AQX_Frame.commons/appBase");
const appService_1 = require("../../00-AQX_Frame.services/appService");
let OrderDetailComponent = class OrderDetailComponent {
    constructor() {
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
        this.orderPlus = {
            publisherInfo: {},
            receiverInfo: {},
            orderCategory: {},
            orderStatus: {},
            orderEvaluate: {}
        };
    }
    //立即抢单
    getOrder() {
    }
    ////the final execute ...
    ngOnInit() {
        //var defaults = {
        //    thumbSize: 20,
        //    slideSpeed: 1500,
        //    auto: true,
        //    loop: true
        //};
        //$('.orderDetail_slider').tilesSlider($.extend({}, defaults, { x: 20, y: 1, effect: 'updown', cssSpeed: 500, backReverse: true }));
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
                    self.orderPlus.publisherInfo = data.data.publisherInfo;
                    self.orderPlus.receiverInfo = data.data.receiverInfo;
                    self.orderPlus.orderCategory = data.data.orderCategory;
                    self.orderPlus.orderStatus = data.data.orderStatus;
                    self.orderPlus.orderEvaluate = data.data.orderEvaluate;
                }
                else {
                    alert(data.msg);
                }
            },
            error(data) {
                alert("服务器错误！");
            }
        });
        var defaults = {
            thumbSize: 20,
            slideSpeed: 1500,
            auto: true,
            loop: true
        };
        $('.orderDetail_slider').tilesSlider($.extend({}, defaults, { x: 20, y: 1, effect: 'updown', cssSpeed: 500, backReverse: true }));
    }
};
OrderDetailComponent = __decorate([
    core_1.Component({
        selector: 'orderDetail',
        templateUrl: 'app/30-order/detail/detail.component.html',
        styleUrls: ['app/30-order/detail/detail.component.css'],
        providers: []
    })
], OrderDetailComponent);
exports.OrderDetailComponent = OrderDetailComponent;
//# sourceMappingURL=detail.component.js.map