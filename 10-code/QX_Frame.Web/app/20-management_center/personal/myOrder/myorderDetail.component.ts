import { Component, OnInit } from '@angular/core';
import { appBase } from '../../../00-AQX_Frame.commons/appBase';
import { appService } from '../../../00-AQX_Frame.services/appService';
import { PublishAidModel, Order } from './../../../30-order/order.model';
import { UserInfoModel } from '../.././management.model';
import { Router, ActivatedRoute, Params } from '@angular/router';

@Component({
    selector: 'managementCenter',
    templateUrl: 'app/20-management_center/personal/myOrder/myorderDetail.component.html',
    styleUrls: ['app/20-management_center/personal/myOrder/myorderDetail.component.css'],
    providers: []
})

export class MyorderDetailComponent implements OnInit {

    router: Router;
    constructor(_router: Router) {
        this.router = _router;
    }

    isMyPublish: boolean = true; //是否为我的发布/接单的标识
    loginId: string = appService.getCookie("loginId");
    balance: any = 0; //余额
    //模型绑定;
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
    orderUid: string = appService.GetQueryString("orderUid");
    orderStatus: string;
    publisherInfo: string;
    receiverInfo: string;

    /**
     * *根据Id获取订单详情；
     */
    GetsingleOrderByOrderUid(): void {
        var self = this;
        //var orderUid = appService.GetQueryString("orderUid");
        $.ajax({
            url: appBase.DomainApi + "api/Order/" + self.orderUid,
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
                    self.publisherInfo = data.data.publisherInfo.loginId;
                    if (data.data.receiverInfo != null) {
                        self.receiverInfo = data.data.receiverInfo.loginId;
                    }

                    if (appService.getCookie("loginId") == data.data.publisherInfo.loginId) {
                        self.isMyPublish = true; //我的发布
                    } else {
                        self.isMyPublish = false; //我的接单
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
    //跳转到充值页；
    goPayment(): void {
        $('#paymentModal').modal('hide');
        this.router.navigateByUrl('/payment');
    }

    /**
     * 判断余额是否充足；
     */
    canPay: string = 'false';
    forPayment(): void {
        var self = this;
        if ((self.balance - Number(self.order.orderValue)) >= 0) {
            self.canPay = 'true';
        } else {
            self.canPay = 'false';
        }
    }

    /**
     * 获取账户余额；
     */
    getPersonalBalance(): void {
        var self = this;
        var appKey = Number(appService.getCookie("appKey"));
        var token = appService.getCookie("token");
        $.ajax({
            url: appBase.DomainApi + "api/UserMoney/" + self.loginId,
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
    toPayment(): void {
        var self = this;
        var appKey = Number(appService.getCookie("appKey"));
        var token = appService.getCookie("token");
        $.ajax({
            url: appBase.DomainApi + "api/UserMoney/",
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
                if (json.isSuccess) { //支付成功
                    self.UpdateOrderStatus(3);//修改订单状态
                    self.canPay = 'already';
                } else {
                    alert('支付失败，请稍后重试~');
                }
            },
            error(data) {
                console.error(data);
            }
        });
    }
    refresh(): void {
        this.router.navigateByUrl('/managementCenter');
    }
    
    /**
     * 修改订单状态
     * @param status 订单状态id
     */
    UpdateOrderStatus(status): void {
        var self = this;
        $.ajax({
            url: appBase.DomainApi + "api/Order/2",
            type: "put",
            dataType: "json",
            contentType: "application/json; charset=UTF-8",
            data: JSON.stringify(
                {
                    "appKey": appService.getCookie("appKey"),
                    "token": appService.getCookie("token"),
                    "orderUid": self.orderUid,
                    "receiverLoginId": appService.getCookie("loginId"),
                    "orderStatusId": status
                }),
            error(data) {
                alert("服务器连接失败!请稍后重试...");
            }
        });
    }

    //the final execute ...
    ngOnInit(): void {
        this.GetsingleOrderByOrderUid();
        this.getPersonalBalance();
    }
}