import { Component, OnInit } from '@angular/core';
import { appBase } from '../../00-AQX_Frame.commons/appBase';
import { appService } from '../../00-AQX_Frame.services/appService';
import { PublishAidModel, Order } from './../order.model';
import { Router, ActivatedRoute, Params } from '@angular/router';

@Component({
    selector: 'orderDetail',
    templateUrl: 'app/30-order/payment/payment.component.html',
    styleUrls: ['app/30-order/payment/payment.component.css'],
    providers: []
})

export class PaymentComponent implements OnInit {
    router: Router;
    constructor(_router: Router) {
        this.router = _router;
    }
    
    loginId: string = appService.getCookie("loginId");
    balance: any = 0;
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
     * 用户余额充值；
     */
    UpdateBalance(): void {
        var self = this;
        var appKey = Number(appService.getCookie("appKey"));
        var token = appService.getCookie("token");
        var cardNo = $('.inputCard').val();
        var cardPwd = $('.inputPwd').val();
        var money = $('.inputBalance').val();
        var reg = new RegExp("[0-9]+");
        if (!reg.test(money)) {
            alert('充值金额输入为数字~');
        }
        else if (cardNo != '666666') {
            alert('请输入有效充值卡号~');
        } else if (cardPwd != '123456') {
            alert('充值密码输入错误~');
        } else {
            $.ajax({
                url: appBase.DomainApi + "api/UserMoney/",
                type: "put",
                dataType: "json",
                contentType: "application/json; charset=UTF-8",
                data: JSON.stringify({
                    appKey: appKey,
                    token: token,
                    loginId: self.loginId,
                    money: money
                }),
                success(json) {
                    if (json.isSuccess) {
                        alert('充值成功~');
                        self.router.navigateByUrl('/managementCenter');
                    } else {
                        alert('充值失败，请稍后重试~');
                    }
                },
                error(data) {
                    console.error(data);
                }
            });
        }
        
    }
    
   
    //the final execute ...
    ngOnInit(): void {
        appService.IsLogin(this.router);
        this.getPersonalBalance();
        $(".re_block_ul li").on('click', function () {
            var getval = $(this).html();
            $(".inputBalance").val(getval);
        })

    }
}