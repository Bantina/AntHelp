import { Component, OnInit } from '@angular/core';
import { appBase } from '../../00-AQX_Frame.commons/appBase';
import { appService } from '../../00-AQX_Frame.services/appService';
import { MessagePushModel } from '../../00-models/MessagePush.model';
import { AppComponent } from '../../00-main/app.component';
import { UserInfoModel, MyorderModel } from './../management.model';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { ComplainModel } from '../../00-models/complain.model';

@Component({
    selector: 'myMassege',
    templateUrl: 'app/20-management_center/massege/massege.component.html',
    styleUrls: ['app/20-management_center/management.component.css'],
    providers: []
})

export class MassegeComponent implements OnInit {
    router: Router;
    constructor(_router: Router) {
        this.router = _router;
    }

    //条件帅选 点击；
    notReadFlag: boolean = true;
    tabBoxClick_myMassege(event, statusId): void {
        var $targetP = $(event.target || event.srcElement).parent();
        $targetP.siblings().removeClass("on");
        $targetP.addClass("on");
        this.GetMessagePushList(statusId);
        if (statusId == 0) {
            this.notReadFlag = true;
        } else {
            this.notReadFlag = false;
        }
    }

    //----- 消息管理 --------
    messagePush: MessagePushModel =
    {
        messageUid: "",
        messageContent: "",
        messagePusher: "",
        messagePushTime: "",
        messageCategoryId: 0,
        messagePushCategoryName: "",
        messagePushStatusId: 0,
        messagePushStatusName: "",
        pushToUserUid: ""
    }

    messagePushList: MessagePushModel[] = [];

    GetMessagePushList(statusId: number): void {
        var self = this;
        $.ajax({
            url: appBase.DomainApi + "api/MessagePush",
            type: "get",
            dataType: "json",
            contentType: "application/json; charset=UTF-8",
            data: {
                "appKey": appService.getCookie("appKey"),
                "token": appService.getCookie("token"),
                "messagePushStatusId": statusId,
                "loginId": appService.getCookie("loginId"),
                "pageIndex": 1,
                "pageSize": 10,
                "isDesc": true
            },
            success(data) {
                if (data.isSuccess) {
                    self.messagePushList = [];
                    for (var i = 0; i < data.data.length; i++) {
                        var messagePushModelTemp = new MessagePushModel();

                        messagePushModelTemp.messageUid = data.data[i].messageUid;
                        messagePushModelTemp.messageContent = data.data[i].messageContent;
                        messagePushModelTemp.messagePusher = data.data[i].messagePusher;
                        messagePushModelTemp.messagePushTime = data.data[i].messagePushTime;
                        messagePushModelTemp.messageCategoryId = data.data[i].messageCategoryId;
                        messagePushModelTemp.messagePushCategoryName = data.data[i].messagePushCategoryName;
                        messagePushModelTemp.messagePushStatusId = data.data[i].messagePushStatusId;
                        messagePushModelTemp.messagePushStatusName = data.data[i].messagePushStatusName;
                        messagePushModelTemp.pushToUserUid = data.data[i].pushToUserUid;

                        self.messagePushList.push(messagePushModelTemp);
                    }
                    appBase.MessageCount = data.dataCount;
                } else {
                    alert(data.msg);
                }
            },
            error(data) {
                alert("服务器连接失败，请稍后重试...");
            }
        });
    }

    GetSingleMessage(i: number) {
        this.messagePush.messageUid = this.messagePushList[i].messageUid;
        this.messagePush.messageContent = this.messagePushList[i].messageContent;
        this.messagePush.messagePusher = this.messagePushList[i].messagePusher;
        this.messagePush.messagePushTime = this.messagePushList[i].messagePushTime;
        this.messagePush.messageCategoryId = this.messagePushList[i].messageCategoryId;
        this.messagePush.messagePushCategoryName = this.messagePushList[i].messagePushCategoryName;
        this.messagePush.messagePushStatusId = this.messagePushList[i].messagePushStatusId;
        this.messagePush.messagePushStatusName = this.messagePushList[i].messagePushStatusName;
        this.messagePush.pushToUserUid = this.messagePushList[i].pushToUserUid;

        //update message status;
        this.UpdateMessageStatus(i);
    }
    //删除消息
    ReSetMessage(i: number): void {
        var self = this;
        if (confirm("确定删除这条消息？")) {
            $.ajax({
                url: appBase.DomainApi + "api/MessagePush",
                type: "delete",
                dataType: "json",
                contentType: "application/json; charset=UTF-8",
                data: JSON.stringify({
                    "appKey": appService.getCookie("appKey"),
                    "token": appService.getCookie("token"),
                    "messagePushUid": self.messagePushList[i].messageUid
                }),
                success(data) {
                    if (data.isSuccess) {
                        //获取信息列表
                        self.GetMessagePushList(1);
                    } else {
                        alert(data.msg);
                    }
                },
                error(data) {
                    alert("服务器连接失败，请稍后重试...");
                }
            });
        }
    }
    //修改消息读取状态；
    UpdateMessageStatus(i: number): void {
        var self = this;
        $.ajax({
            url: appBase.DomainApi + "api/MessagePush/1",
            type: "put",
            dataType: "json",
            contentType: "application/json; charset=UTF-8",
            data: JSON.stringify({
                "appKey": appService.getCookie("appKey"),
                "token": appService.getCookie("token"),
                "messagePushUid": self.messagePushList[i].messageUid
            }),
        });
    }
    //send msg
    SendMessage() {
        var self = this;
        $.ajax({
            url: appBase.DomainApi + "api/MessagePush",
            type: "post",
            dataType: "json",
            contentType: "application/json; charset=UTF-8",
            data: JSON.stringify({
                "appKey": appService.getCookie("appKey"),
                "token": appService.getCookie("token"),
                "messagePusher": "System",
                "messageContent": self.messagePush.messageContent,
                "messageCategoryId": 0,
                "loginId": self.messagePush.pushToUserUid
            }),
            success(data) {
                if (data.isSuccess) {
                    alert("发送成功~");
                    self.messagePush.messageContent = "";
                    self.messagePush.pushToUserUid = "";
                    self.GetMessagePushList(-1);
                } else {
                    alert(data.msg);
                }
            },
            error(data) {
                alert("服务器连接失败，请稍后重试...");
            }
        });
    }

    //----- 消息管理 end -------------------


    ngOnInit(): void {
        appService.IsLogin(this.router);

        this.GetMessagePushList(0);
    }
}