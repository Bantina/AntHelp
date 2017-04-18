import { Component, OnInit } from '@angular/core';
import { appBase } from '../../00-AQX_Frame.commons/appBase';
import { appService } from '../../00-AQX_Frame.services/appService';
import { PublishAidModel, Order } from './../order.model';
import { Router, ActivatedRoute, Params } from '@angular/router';

@Component({
    selector: 'orderDetail',
    templateUrl: 'app/30-order/detail/detail.component.html',
    styleUrls: ['app/30-order/detail/detail.component.css'],
    providers: []
})

export class OrderDetailComponent implements OnInit {
    router: Router;
    constructor(_router: Router) {
        this.router = _router;
    }
    
    order: Order =
    {
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
    }

    //发布者的loginId
    publisherLoginId: string;
    orderCategoryName: string;
    imageNameList: string[];
    imageSrcList: string[];

    //抢单标识
    getOrderButtonIsDisabled: number = 1;

    //立即抢单
    getOrder(): void {
        var self = this;

        if (appService.IsLogin(self.router).isLogin) {
            $.ajax({
                url: appBase.DomainApi + "api/Order/1",
                type: "put",
                dataType: "json",
                contentType: "application/json; charset=UTF-8",
                data: JSON.stringify(
                    {
                        "appKey": appService.getCookie("appKey"),
                        "token": appService.getCookie("token"),
                        "orderUid": self.order.orderUid,
                        "receiverLoginId": appService.getCookie("loginId"),
                        "orderStatusId": 4
                    }),
                success(data) {
                    if (data.isSuccess) {
                        alert("抢单成功~");
                        //这里可以进行跳转到订单详情页

                        //
                        self.getOrderButtonIsDisabled = 0;
                    } else {
                        if (data.errorCode == 3022) {
                            alert("手慢一步，订单被别人抢啦~");
                        } else {
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

    GetOrderByOrderUid(): void {
        var self = this;
        var orderUid = appService.GetQueryString("orderUid");

        $.ajax({
            url: appBase.DomainApi + "api/Order/" + orderUid,
            type: "get",
            dataType: "json",
            contentType: "application/json; charset=UTF-8",
            data: {
                //"id": orderUid,
                "appKey": appService.getCookie("appKey"),
                "token": appService.getCookie("token")
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
                            url: appBase.DomainApi + 'api/Files/' + self.imageNameList[i],
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

                    } else {
                        alert(data.msg);
                    }
                },
                error(data) {
                    alert("服务器错误！");
                }
            });
        } 
        
    //the final execute ...
    ngOnInit(): void {

        this.GetOrderByOrderUid();//通过OrderUid获取Order信息

        //var defaults = {
        //    thumbSize: 20,
        //    slideSpeed: 1500,
        //    auto: true,
        //    loop: true
        //};
        //$('.orderDetail_slider').tilesSlider($.extend({}, defaults, { x: 20, y: 1, effect: 'updown', cssSpeed: 500, backReverse: true }));
    }
}