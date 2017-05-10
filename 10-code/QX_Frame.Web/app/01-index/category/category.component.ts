import { Router, ActivatedRoute, Params } from '@angular/router';
import { appBase } from '../../00-AQX_Frame.commons/appBase';
import { appService } from '../../00-AQX_Frame.services/appService';
import { Component, OnInit } from '@angular/core';
import { UserInfoModel, MyorderModel } from '../../20-management_center/management.model';


@Component({
    selector: 'category',
    templateUrl: 'app/01-index/category/category.component.html',
    styleUrls: ['app/01-index/category/category.component.css'],
})


export class CategoryComponent implements OnInit {
    router: Router;
    constructor(_router: Router) {
        this.router = _router;
    }
    categoryTitle: string;
    //根据Id获取分类名称；
    getCategoryTitle(cateId): void {
        var self = this;
        switch (cateId) {
            case '2':
                self.categoryTitle = '代购代帮';
                break;
            case '3':
                self.categoryTitle = '代理销售';
                break;
            case '4':
                self.categoryTitle = '维修装修';
                break;
            case '5':
                self.categoryTitle = '家政服务';
                break;
            case '6':
                self.categoryTitle = '免费专场';
                break;
            case '7':
                self.categoryTitle = '宠物之家';
                break;
            case '8':
                self.categoryTitle = '汽车服务';
                break;
            case '9':
                self.categoryTitle = '休闲服务';
                break;
            case '10':
                self.categoryTitle = '其他服务';
                break;
            default:
                self.categoryTitle = '宠物之家';
        }
    }

    //跳转订单详情页；
    goOrderDetail(event): void {
        var $targetP = $(event.target || event.srcElement);
        this.router.navigateByUrl('/orderDetail?orderUid=' + $targetP.attr('id'));//跳转未登录页面；
    }
    //根据orderCategoryId获取当前分类所有数据；
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
                        //订单状态-已支付 对其他用户可见
                        if (Number(data.data[i].orderStatusId) > 2) {
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
                        
                    }
                } else {
                    console.error(data.msg);
                }
            },
            error(data) {}
        });
    }

   
    ngOnInit(): void {
        var cateId = appService.GetQueryString("catetgoryId");
        this.getCategoryTitle(cateId);
        this.GetOrderList_free(-1, cateId, -1);
    }
}