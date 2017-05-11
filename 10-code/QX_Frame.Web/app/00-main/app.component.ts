import { Component } from '@angular/core';
import { appService } from "../00-AQX_Frame.services/appService";
import { appBase } from "../00-AQX_Frame.commons/appBase";
import { Router, ActivatedRoute, Params } from '@angular/router';

@Component({
    selector: 'my-app',
    templateUrl: 'app/00-main/app.component.html',
    styleUrls: ['app/00-main/app.component.css']
})


export class AppComponent {
    title = 'Ant Help'
    router: Router;
    constructor(_router: Router) {
        this.router = _router;
    }

    loginResult: any = {};

    //个人中心菜单点击 切换
    setCenterStatus(num): void {
        appBase.AppObject.centerStatus = num;
        var manageCenterUl = $(".manageCenterUl li");
        manageCenterUl.removeClass("on");
        manageCenterUl.eq(appBase.AppObject.centerStatus).addClass("on");
    }

    //获取消息
    messageCount: number = 0;
    GetMessagePushList(): void {
        var self = this;
        $.ajax({
            url: appBase.DomainApi + "api/MessagePush",
            type: "get",
            dataType: "json",
            contentType: "application/json; charset=UTF-8",
            data: {
                "appKey": appService.getCookie("appKey"),
                "token": appService.getCookie("token"),
                "messagePushStatusId": 0,
                "loginId": appService.getCookie("loginId"),
                "pageIndex": 1,
                "pageSize": 10,
                "isDesc": true
            },
            success(data) {
                if (data.isSuccess) {
                    self.messageCount = data.dataCount;
                } else {
                    //alert(data.msg);
                }
            },
            error(data) {
                //alert("服务器连接失败，请稍后重试...");
            }
        });
    }

    ngOnInit(): void {
        this.loginResult = appService.IsLogin(this.router);
        //get message count
        if (this.loginResult.isLogin) {
            this.GetMessagePushList();
        }
    }
}