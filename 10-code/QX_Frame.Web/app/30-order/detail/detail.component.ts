import { Component, OnInit } from '@angular/core';
import { appBase } from '../../00-AQX_Frame.commons/appBase';
import { appService } from '../../00-AQX_Frame.services/appService';
import { PublishAidModel, Order } from './../order.model';

@Component({
    selector: 'orderDetail',
    templateUrl: 'app/30-order/detail/detail.component.html',
    styleUrls: ['app/30-order/detail/detail.component.css'],
    providers: []
})

export class OrderDetailComponent implements OnInit {

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

    orderPlus: any =
    {
        publisherInfo: {},
        receiverInfo: {},
        orderCategory: {},
        orderStatus: {},
        orderEvaluate: {}
    }

    ////the final execute ...
    ngOnInit(): void {
        //var defaults = {
        //    thumbSize: 20,
        //    slideSpeed: 1500,
        //    auto: true,
        //    loop: true
        //};
        //$('.orderDetail_slider').tilesSlider($.extend({}, defaults, { x: 20, y: 1, effect: 'updown', cssSpeed: 500, backReverse: true }));

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
                    self.order.orderUid=data.data.orderUid;
                    self.order.publishTime = data.data.publishTime;
                    self.order.orderDescription = data.data.orderDescription;
                    self.order.orderCategoryId=data.data.orderCategoryId;
                    self.order.receiverUid = data.data.receiverUid;
                    self.order.receiveTime = data.data.receiveTime;
                    self.order.orderStatusId = data.data.orderStatusId;
                    self.order.orderValue=data.data.orderValue;
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

                } else {
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
}