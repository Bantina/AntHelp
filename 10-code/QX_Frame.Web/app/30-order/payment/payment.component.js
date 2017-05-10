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
let PaymentComponent = class PaymentComponent {
    constructor(_router) {
        this.loginId = appService_1.appService.getCookie("loginId");
        this.balance = 0;
        this.router = _router;
    }
    /**
     * 获取账户余额；
     */
    getPersonalBalance() {
        var self = this;
        var appKey = Number(appService_1.appService.getCookie("appKey"));
        var token = appService_1.appService.getCookie("token");
        $.ajax({
            url: appBase_1.appBase.DomainApi + "api/UserMoney/" + self.loginId,
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
    UpdateBalance() {
        var self = this;
        var appKey = Number(appService_1.appService.getCookie("appKey"));
        var token = appService_1.appService.getCookie("token");
        var cardNo = $('.inputCard').val();
        var cardPwd = $('.inputPwd').val();
        var money = $('.inputBalance').val();
        var reg = new RegExp("[0-9]+");
        if (!reg.test(money)) {
            alert('充值金额输入为数字~');
        }
        else if (cardNo != '666666') {
            alert('请输入有效充值卡号~');
        }
        else if (cardPwd != '123456') {
            alert('充值密码输入错误~');
        }
        else {
            $.ajax({
                url: appBase_1.appBase.DomainApi + "api/UserMoney/",
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
                    }
                    else {
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
    ngOnInit() {
        appService_1.appService.IsLogin(this.router);
        this.getPersonalBalance();
        $(".re_block_ul li").on('click', function () {
            var getval = $(this).html();
            $(".inputBalance").val(getval);
        });
    }
};
PaymentComponent = __decorate([
    core_1.Component({
        selector: 'orderDetail',
        templateUrl: 'app/30-order/payment/payment.component.html',
        styleUrls: ['app/30-order/payment/payment.component.css'],
        providers: []
    }),
    __metadata("design:paramtypes", [router_1.Router])
], PaymentComponent);
exports.PaymentComponent = PaymentComponent;
//# sourceMappingURL=payment.component.js.map