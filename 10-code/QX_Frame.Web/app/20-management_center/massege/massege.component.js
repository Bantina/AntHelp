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
const core_1 = require('@angular/core');
const appBase_1 = require('../../00-AQX_Frame.commons/appBase');
const appService_1 = require('../../00-AQX_Frame.services/appService');
const MessagePush_model_1 = require('../../00-models/MessagePush.model');
const router_1 = require('@angular/router');
let MassegeComponent = class MassegeComponent {
    constructor(_router) {
        //条件帅选 点击；
        this.notReadFlag = true;
        //----- 消息管理 --------
        this.messagePush = {
            messageUid: "",
            messageContent: "",
            messagePusher: "",
            messagePushTime: "",
            messageCategoryId: 0,
            messagePushCategoryName: "",
            messagePushStatusId: 0,
            messagePushStatusName: "",
            pushToUserUid: ""
        };
        this.messagePushList = [];
        this.router = _router;
    }
    tabBoxClick_myMassege(event, statusId) {
        var $targetP = $(event.target || event.srcElement).parent();
        $targetP.siblings().removeClass("on");
        $targetP.addClass("on");
        this.GetMessagePushList(statusId);
        if (statusId == 0) {
            this.notReadFlag = true;
        }
        else {
            this.notReadFlag = false;
        }
    }
    GetMessagePushList(statusId) {
        var self = this;
        $.ajax({
            url: appBase_1.appBase.DomainApi + "api/MessagePush",
            type: "get",
            dataType: "json",
            contentType: "application/json; charset=UTF-8",
            data: {
                "appKey": appService_1.appService.getCookie("appKey"),
                "token": appService_1.appService.getCookie("token"),
                "messagePushStatusId": statusId,
                "loginId": appService_1.appService.getCookie("loginId"),
                "pageIndex": 1,
                "pageSize": 10,
                "isDesc": true
            },
            success(data) {
                if (data.isSuccess) {
                    self.messagePushList = [];
                    for (var i = 0; i < data.data.length; i++) {
                        var messagePushModelTemp = new MessagePush_model_1.MessagePushModel();
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
                    appBase_1.appBase.MessageCount = data.dataCount;
                }
                else {
                    alert(data.msg);
                }
            },
            error(data) {
                alert("服务器连接失败，请稍后重试...");
            }
        });
    }
    GetSingleMessage(i) {
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
    ReSetMessage(i) {
        var self = this;
        if (confirm("确定删除这条消息？")) {
            $.ajax({
                url: appBase_1.appBase.DomainApi + "api/MessagePush",
                type: "delete",
                dataType: "json",
                contentType: "application/json; charset=UTF-8",
                data: JSON.stringify({
                    "appKey": appService_1.appService.getCookie("appKey"),
                    "token": appService_1.appService.getCookie("token"),
                    "messagePushUid": self.messagePushList[i].messageUid
                }),
                success(data) {
                    if (data.isSuccess) {
                        //获取信息列表
                        self.GetMessagePushList(1);
                    }
                    else {
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
    UpdateMessageStatus(i) {
        var self = this;
        $.ajax({
            url: appBase_1.appBase.DomainApi + "api/MessagePush/1",
            type: "put",
            dataType: "json",
            contentType: "application/json; charset=UTF-8",
            data: JSON.stringify({
                "appKey": appService_1.appService.getCookie("appKey"),
                "token": appService_1.appService.getCookie("token"),
                "messagePushUid": self.messagePushList[i].messageUid
            }),
        });
    }
    //send msg
    SendMessage() {
        var self = this;
        $.ajax({
            url: appBase_1.appBase.DomainApi + "api/MessagePush",
            type: "post",
            dataType: "json",
            contentType: "application/json; charset=UTF-8",
            data: JSON.stringify({
                "appKey": appService_1.appService.getCookie("appKey"),
                "token": appService_1.appService.getCookie("token"),
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
                }
                else {
                    alert(data.msg);
                }
            },
            error(data) {
                alert("服务器连接失败，请稍后重试...");
            }
        });
    }
    //----- 消息管理 end -------------------
    ngOnInit() {
        appService_1.appService.IsLogin(this.router);
        this.GetMessagePushList(0);
    }
};
MassegeComponent = __decorate([
    core_1.Component({
        selector: 'myMassege',
        templateUrl: 'app/20-management_center/massege/massege.component.html',
        styleUrls: ['app/20-management_center/management.component.css'],
        providers: []
    }), 
    __metadata('design:paramtypes', [router_1.Router])
], MassegeComponent);
exports.MassegeComponent = MassegeComponent;
//# sourceMappingURL=massege.component.js.map