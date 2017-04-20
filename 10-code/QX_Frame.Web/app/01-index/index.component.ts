import { Router, ActivatedRoute, Params } from '@angular/router';
import { appBase } from '../00-AQX_Frame.commons/appBase';
import { appService } from '../00-AQX_Frame.services/appService';
import { Component, OnInit } from '@angular/core';
import { UserInfoModel, MyorderModel } from '../20-management_center/management.model';


@Component({
    selector: 'index',
    templateUrl: 'app/01-index/index.component.html',
    styleUrls: ['app/01-index/index.component.css'],
})


export class IndexComponent implements OnInit {
    router: Router;
    constructor(_router: Router) {
        this.router = _router;
    }

    //跳转订单详情页；
    goOrderDetail(event): void {
        var $targetP = $(event.target || event.srcElement).parent();
        this.router.navigateByUrl('/orderDetail?orderUid=' + $targetP.attr('id'));//跳转未登录页面；
    }
    //get  首页获取订单列表;
    trackIndex(index, item): void {
        if (index > 3) {
            return;
        }
    }
    //免费专场
    OrderList_free: MyorderModel[] = [];
    GetOrderList_free(queryId, orderCategoryId, orderStatusId): void {
        var self = this;
        $.ajax({
            url: appBase.DomainApi + "api/Order",
            type: "get",
            dataType: "json",
            contentType: "application/json; charset=UTF-8",
            data: {
                //queryId=-1 all queryId=1 publish queryId=2 receive orderCategory = -1 all orderStatusId=-1 all
                "appKey": appService.getCookie("appKey"),
                "token": appService.getCookie("token"),
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
                        var per_myorderModel = new MyorderModel();

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
                } else {
                    console.error(data.msg);
                }
            },
            error(data) {}
        });
    }

    //代购代帮
    OrderList_buy: MyorderModel[] = [];
    GeOrderList_buy(queryId, orderCategoryId, orderStatusId): void {
        var self = this;
        $.ajax({
            url: appBase.DomainApi + "api/Order",
            type: "get",
            dataType: "json",
            contentType: "application/json; charset=UTF-8",
            data: {
                //queryId=-1 all queryId=1 publish queryId=2 receive orderCategory = -1 all orderStatusId=-1 all
                "appKey": appService.getCookie("appKey"),
                "token": appService.getCookie("token"),
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
                        var per_myorderModel = new MyorderModel();

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
                } else {
                    console.error(data.msg);
                }
            },
            error(data) { }
        });
    }

    //宠物之家
    OrderList_pet: MyorderModel[] = [];
    GetOrderList_pet(queryId, orderCategoryId, orderStatusId): void {
        var self = this;
        $.ajax({
            url: appBase.DomainApi + "api/Order",
            type: "get",
            dataType: "json",
            contentType: "application/json; charset=UTF-8",
            data: {
                //queryId=-1 all queryId=1 publish queryId=2 receive orderCategory = -1 all orderStatusId=-1 all
                "appKey": appService.getCookie("appKey"),
                "token": appService.getCookie("token"),
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
                        var per_myorderModel = new MyorderModel();

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
                } else {
                    console.error(data.msg);
                }
            },
            error(data) { }
        });
    }

    //家政服务
    OrderList_family: MyorderModel[] = [];
    GetOrderList_family(queryId, orderCategoryId, orderStatusId): void {
        var self = this;
        $.ajax({
            url: appBase.DomainApi + "api/Order",
            type: "get",
            dataType: "json",
            contentType: "application/json; charset=UTF-8",
            data: {
                //queryId=-1 all queryId=1 publish queryId=2 receive orderCategory = -1 all orderStatusId=-1 all
                "appKey": appService.getCookie("appKey"),
                "token": appService.getCookie("token"),
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
                        var per_myorderModel = new MyorderModel();

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
                } else {
                    console.error(data.msg);
                }
            },
            error(data) { }
        });
    }


    ngOnInit(): void {
        this.GetOrderList_free(-1, 6, -1);
        this.GetOrderList_pet(-1, 7, -1);
        this.GeOrderList_buy(-1, 2, -1);
        this.GetOrderList_family(-1, 5, -1);
    }
}