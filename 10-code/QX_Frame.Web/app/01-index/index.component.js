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
const router_1 = require("@angular/router");
const appBase_1 = require("../00-AQX_Frame.commons/appBase");
const appService_1 = require("../00-AQX_Frame.services/appService");
const core_1 = require("@angular/core");
const management_model_1 = require("../20-management_center/management.model");
let IndexComponent = class IndexComponent {
    constructor(_router) {
        //免费专场
        this.OrderList_free = [];
        //代购代帮
        this.OrderList_buy = [];
        //宠物之家
        this.OrderList_pet = [];
        //家政服务
        this.OrderList_family = [];
        this.router = _router;
    }
    //跳转订单详情页；
    goOrderDetail(event) {
        var $targetP = $(event.target || event.srcElement).parent();
        this.router.navigateByUrl('/orderDetail?orderUid=' + $targetP.attr('id')); //跳转未登录页面；
    }
    //跳转分类页；
    goCategory(cateId) {
        this.router.navigateByUrl('/category?catetgoryId=' + cateId);
    }
    //get  首页获取订单列表;
    trackIndex(index, item) {
        if (index > 3) {
            return;
        }
    }
    GetOrderList_free(queryId, orderCategoryId, orderStatusId) {
        var self = this;
        $.ajax({
            url: appBase_1.appBase.DomainApi + "api/Order",
            type: "get",
            dataType: "json",
            contentType: "application/json; charset=UTF-8",
            data: {
                //queryId=-1 all queryId=1 publish queryId=2 receive orderCategory = -1 all orderStatusId=-1 all
                "appKey": appService_1.appService.getCookie("appKey"),
                "token": appService_1.appService.getCookie("token"),
                "publisherOrReceiverLoginId": "",
                "queryId": queryId,
                "orderCategoryId": orderCategoryId,
                "orderStatusId": orderStatusId,
                "orderDescription": "",
                "pageIndex": 1,
                "pageSize": 10,
                "isDesc": true
            },
            success(data) {
                if (data.isSuccess) {
                    self.OrderList_free = [];
                    for (var i = 0; i < data.data.length; i++) {
                        //订单状态-已支付 对其他用户可见
                        if (Number(data.data[i].orderStatusId) > 2) {
                            var per_myorderModel = new management_model_1.MyorderModel();
                            per_myorderModel.orderUid = data.data[i].orderUid;
                            per_myorderModel.publisherUid = data.data[i].nickNamepublisherUid;
                            per_myorderModel.publisherInfo = data.data[i].publisherInfo;
                            per_myorderModel.publishTime = data.data[i].publishTime;
                            per_myorderModel.orderDescription = data.data[i].orderDescription;
                            per_myorderModel.orderCategoryId = data.data[i].orderCategoryId;
                            per_myorderModel.orderCategory = data.data[i].orderCategory;
                            per_myorderModel.receiverUid = data.data[i].receiverUid;
                            per_myorderModel.receiverInfo = data.data[i].receiverInfo;
                            per_myorderModel.receiveTime = data.data[i].receiveTime;
                            per_myorderModel.orderStatusId = data.data[i].orderStatusId;
                            per_myorderModel.orderStatus = data.data[i].orderStatus;
                            per_myorderModel.orderValue = data.data[i].orderValue;
                            per_myorderModel.allowVoucher = data.data[i].allowVoucher;
                            per_myorderModel.voucherMax = data.data[i].voucherMax;
                            per_myorderModel.evaluateUid = data.data[i].evaluateUid;
                            per_myorderModel.orderEvaluate = data.data[i].orderEvaluate;
                            per_myorderModel.address = data.data[i].address;
                            per_myorderModel.phone = data.data[i].phone;
                            per_myorderModel.imageUrls = data.data[i].imageUrls;
                            per_myorderModel.firstImg = data.data[i].imageDatas[0];
                            self.OrderList_free.push(per_myorderModel);
                        }
                    }
                }
                else {
                    console.error(data.msg);
                }
            },
            error(data) { }
        });
    }
    GeOrderList_buy(queryId, orderCategoryId, orderStatusId) {
        var self = this;
        $.ajax({
            url: appBase_1.appBase.DomainApi + "api/Order",
            type: "get",
            dataType: "json",
            contentType: "application/json; charset=UTF-8",
            data: {
                //queryId=-1 all queryId=1 publish queryId=2 receive orderCategory = -1 all orderStatusId=-1 all
                "appKey": appService_1.appService.getCookie("appKey"),
                "token": appService_1.appService.getCookie("token"),
                "publisherOrReceiverLoginId": "",
                "queryId": queryId,
                "orderCategoryId": orderCategoryId,
                "orderStatusId": orderStatusId,
                "orderDescription": "",
                "pageIndex": 1,
                "pageSize": 10,
                "isDesc": true
            },
            success(data) {
                if (data.isSuccess) {
                    self.OrderList_buy = [];
                    for (var i = 0; i < data.data.length; i++) {
                        //订单状态-已支付 对其他用户可见
                        if (Number(data.data[i].orderStatusId) > 2) {
                            var per_myorderModel = new management_model_1.MyorderModel();
                            per_myorderModel.orderUid = data.data[i].orderUid;
                            per_myorderModel.publisherUid = data.data[i].nickNamepublisherUid;
                            per_myorderModel.publisherInfo = data.data[i].publisherInfo;
                            per_myorderModel.publishTime = data.data[i].publishTime;
                            per_myorderModel.orderDescription = data.data[i].orderDescription;
                            per_myorderModel.orderCategoryId = data.data[i].orderCategoryId;
                            per_myorderModel.orderCategory = data.data[i].orderCategory;
                            per_myorderModel.receiverUid = data.data[i].receiverUid;
                            per_myorderModel.receiverInfo = data.data[i].receiverInfo;
                            per_myorderModel.receiveTime = data.data[i].receiveTime;
                            per_myorderModel.orderStatusId = data.data[i].orderStatusId;
                            per_myorderModel.orderStatus = data.data[i].orderStatus;
                            per_myorderModel.orderValue = data.data[i].orderValue;
                            per_myorderModel.allowVoucher = data.data[i].allowVoucher;
                            per_myorderModel.voucherMax = data.data[i].voucherMax;
                            per_myorderModel.evaluateUid = data.data[i].evaluateUid;
                            per_myorderModel.orderEvaluate = data.data[i].orderEvaluate;
                            per_myorderModel.address = data.data[i].address;
                            per_myorderModel.phone = data.data[i].phone;
                            per_myorderModel.imageUrls = data.data[i].imageUrls;
                            per_myorderModel.firstImg = data.data[i].imageDatas[0];
                            self.OrderList_buy.push(per_myorderModel);
                        }
                    }
                }
                else {
                    console.error(data.msg);
                }
            },
            error(data) { }
        });
    }
    GetOrderList_pet(queryId, orderCategoryId, orderStatusId) {
        var self = this;
        $.ajax({
            url: appBase_1.appBase.DomainApi + "api/Order",
            type: "get",
            dataType: "json",
            contentType: "application/json; charset=UTF-8",
            data: {
                //queryId=-1 all queryId=1 publish queryId=2 receive orderCategory = -1 all orderStatusId=-1 all
                "appKey": appService_1.appService.getCookie("appKey"),
                "token": appService_1.appService.getCookie("token"),
                "publisherOrReceiverLoginId": "",
                "queryId": queryId,
                "orderCategoryId": orderCategoryId,
                "orderStatusId": orderStatusId,
                "orderDescription": "",
                "pageIndex": 1,
                "pageSize": 10,
                "isDesc": true
            },
            success(data) {
                if (data.isSuccess) {
                    self.OrderList_pet = [];
                    for (var i = 0; i < data.data.length; i++) {
                        //订单状态-已支付 对其他用户可见
                        if (Number(data.data[i].orderStatusId) > 2) {
                            var per_myorderModel = new management_model_1.MyorderModel();
                            per_myorderModel.orderUid = data.data[i].orderUid;
                            per_myorderModel.publisherUid = data.data[i].nickNamepublisherUid;
                            per_myorderModel.publisherInfo = data.data[i].publisherInfo;
                            per_myorderModel.publishTime = data.data[i].publishTime;
                            per_myorderModel.orderDescription = data.data[i].orderDescription;
                            per_myorderModel.orderCategoryId = data.data[i].orderCategoryId;
                            per_myorderModel.orderCategory = data.data[i].orderCategory;
                            per_myorderModel.receiverUid = data.data[i].receiverUid;
                            per_myorderModel.receiverInfo = data.data[i].receiverInfo;
                            per_myorderModel.receiveTime = data.data[i].receiveTime;
                            per_myorderModel.orderStatusId = data.data[i].orderStatusId;
                            per_myorderModel.orderStatus = data.data[i].orderStatus;
                            per_myorderModel.orderValue = data.data[i].orderValue;
                            per_myorderModel.allowVoucher = data.data[i].allowVoucher;
                            per_myorderModel.voucherMax = data.data[i].voucherMax;
                            per_myorderModel.evaluateUid = data.data[i].evaluateUid;
                            per_myorderModel.orderEvaluate = data.data[i].orderEvaluate;
                            per_myorderModel.address = data.data[i].address;
                            per_myorderModel.phone = data.data[i].phone;
                            per_myorderModel.imageUrls = data.data[i].imageUrls;
                            per_myorderModel.firstImg = data.data[i].imageDatas[0];
                            self.OrderList_pet.push(per_myorderModel);
                        }
                    }
                }
                else {
                    console.error(data.msg);
                }
            },
            error(data) { }
        });
    }
    GetOrderList_family(queryId, orderCategoryId, orderStatusId) {
        var self = this;
        $.ajax({
            url: appBase_1.appBase.DomainApi + "api/Order",
            type: "get",
            dataType: "json",
            contentType: "application/json; charset=UTF-8",
            data: {
                //queryId=-1 all queryId=1 publish queryId=2 receive orderCategory = -1 all orderStatusId=-1 all
                "appKey": appService_1.appService.getCookie("appKey"),
                "token": appService_1.appService.getCookie("token"),
                "publisherOrReceiverLoginId": "",
                "queryId": queryId,
                "orderCategoryId": orderCategoryId,
                "orderStatusId": orderStatusId,
                "orderDescription": "",
                "pageIndex": 1,
                "pageSize": 10,
                "isDesc": true
            },
            success(data) {
                if (data.isSuccess) {
                    self.OrderList_family = [];
                    for (var i = 0; i < data.data.length; i++) {
                        //订单状态-已支付 对其他用户可见
                        if (Number(data.data[i].orderStatusId) > 2) {
                            var per_myorderModel = new management_model_1.MyorderModel();
                            per_myorderModel.orderUid = data.data[i].orderUid;
                            per_myorderModel.publisherUid = data.data[i].nickNamepublisherUid;
                            per_myorderModel.publisherInfo = data.data[i].publisherInfo;
                            per_myorderModel.publishTime = data.data[i].publishTime;
                            per_myorderModel.orderDescription = data.data[i].orderDescription;
                            per_myorderModel.orderCategoryId = data.data[i].orderCategoryId;
                            per_myorderModel.orderCategory = data.data[i].orderCategory;
                            per_myorderModel.receiverUid = data.data[i].receiverUid;
                            per_myorderModel.receiverInfo = data.data[i].receiverInfo;
                            per_myorderModel.receiveTime = data.data[i].receiveTime;
                            per_myorderModel.orderStatusId = data.data[i].orderStatusId;
                            per_myorderModel.orderStatus = data.data[i].orderStatus;
                            per_myorderModel.orderValue = data.data[i].orderValue;
                            per_myorderModel.allowVoucher = data.data[i].allowVoucher;
                            per_myorderModel.voucherMax = data.data[i].voucherMax;
                            per_myorderModel.evaluateUid = data.data[i].evaluateUid;
                            per_myorderModel.orderEvaluate = data.data[i].orderEvaluate;
                            per_myorderModel.address = data.data[i].address;
                            per_myorderModel.phone = data.data[i].phone;
                            per_myorderModel.imageUrls = data.data[i].imageUrls;
                            per_myorderModel.firstImg = data.data[i].imageDatas[0];
                            self.OrderList_family.push(per_myorderModel);
                        }
                    }
                }
                else {
                    console.error(data.msg);
                }
            },
            error(data) { }
        });
    }
    ngOnInit() {
        this.GetOrderList_free(-1, 6, -1);
        this.GetOrderList_pet(-1, 7, -1);
        this.GeOrderList_buy(-1, 2, -1);
        this.GetOrderList_family(-1, 5, -1);
    }
};
IndexComponent = __decorate([
    core_1.Component({
        selector: 'index',
        templateUrl: 'app/01-index/index.component.html',
        styleUrls: ['app/01-index/index.component.css'],
    }),
    __metadata("design:paramtypes", [router_1.Router])
], IndexComponent);
exports.IndexComponent = IndexComponent;
//# sourceMappingURL=index.component.js.map