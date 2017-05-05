import { Component, OnInit } from '@angular/core';
import { appBase } from '../../../00-AQX_Frame.commons/appBase';
import { appService } from '../../../00-AQX_Frame.services/appService';
import { PublishAidModel, Order } from './../../../30-order/order.model';
import { UserInfoModel } from '../.././management.model';

@Component({
    selector: 'managementCenter',
    templateUrl: 'app/20-management_center/personal/myOrder/myorderDetail.component.html',
    styleUrls: ['app/20-management_center/personal/myOrder/myorderDetail.component.css'],
    providers: []
})

export class MyorderDetailComponent implements OnInit {
    //模型绑定;
    userInfoModel: UserInfoModel = {
        loginId: appService.getCookie('loginId'),
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
        imageUrls: "",
        imageDatas: []
    }

    orderStatus: string;
    GetsingleOrderByOrderUid(): void {
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
        this.GetsingleOrderByOrderUid();
    }
}