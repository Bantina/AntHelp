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
const app_component_1 = require('../../00-main/app.component');
const management_model_1 = require('./../management.model');
const complain_model_1 = require('../../00-models/complain.model');
let AdministratorComponent = class AdministratorComponent {
    constructor(_appComponet) {
        //模型绑定;
        this.userInfoModel = {
            loginId: appService_1.appService.getCookie('loginId'),
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
        };
        //用户信息列表
        this.userInfoModelList = [];
        //模态框Model
        this.model_userInfoModel = {
            loginId: "",
            nickName: '',
            headImageUrl: "",
            email: "",
            phone: "",
            position: "",
            age: 21,
            sexId: 0,
            birthday: "",
            bloodTypeId: 0,
            school: '',
            location: "",
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
        };
        //searchLoginId
        this.searchLoginId = "";
        //global
        this.navStatus = appBase_1.appBase.AppObject.administratorStatus; //-1未登录；
        this.loginId = appService_1.appService.getCookie("loginId");
        //------- complain ------------------
        //投诉信息
        this.complainModel = {
            complainUid: "",
            complainContent: "",
            complainUserUid: "",
            complainTime: "",
            complainStatusId: 0,
            complainStatusName: ""
        };
        this.complainModelList = [];
        ////订单管理
        //order-model
        this.model_orderModel = {
            orderUid: 0,
            publisherUid: 0,
            publisherInfo: "",
            publishTime: "",
            orderDescription: "",
            orderCategoryId: '',
            orderCategory: '',
            receiverUid: '',
            receiveTime: '',
            receiverInfo: '',
            orderStatusId: "",
            orderStatus: '',
            orderValue: '',
            allowVoucher: '',
            voucherMax: '',
            evaluateUid: 0,
            orderEvaluate: '',
            address: '',
            phone: '',
            imageUrls: '',
            firstImg: ''
        };
        //get AllorderList List 获取全部订单列表;
        this.allorderModelList = [];
        //点编辑的a标签事件，把本行的信息获取出来
        //GetThisLineOrderInfo(i: number): void {
        //    var self = this;
        //    self.model_orderModel.orderUid = self.allorderModelList[i].orderUid;
        //    self.model_orderModel.publisherUid = self.allorderModelList[i].publisherUid;
        //    self.model_orderModel.publisherInfo = self.allorderModelList[i].publisherInfo;
        //    self.model_orderModel.publishTime = self.allorderModelList[i].publishTime;
        //    self.model_orderModel.orderDescription = self.allorderModelList[i].orderDescription;
        //    self.model_orderModel.orderCategoryId = self.allorderModelList[i].orderCategoryId;
        //    self.model_orderModel.orderCategory = self.allorderModelList[i].orderCategory;
        //    self.model_orderModel.receiverUid = self.allorderModelList[i].receiverUid;
        //    self.model_orderModel.receiverInfo =self.allorderModelList[i].receiverInfo;
        //    self.model_orderModel.receiveTime =self.allorderModelList[i].receiveTime;
        //    self.model_orderModel.orderStatusId =self.allorderModelList[i].orderStatusId;
        //    self.model_orderModel.orderStatus =self.allorderModelList[i].orderStatus.orderStatusDescription;
        //    self.model_orderModel.orderValue =self.allorderModelList[i].orderValue;
        //    self.model_orderModel.allowVoucher =self.allorderModelList[i].allowVoucher;
        //    self.model_orderModel.voucherMax =self.allorderModelList[i].voucherMax;
        //    self.model_orderModel.evaluateUid =self.allorderModelList[i].evaluateUid;
        //    self.model_orderModel.orderEvaluate =self.allorderModelList[i].orderEvaluate;
        //    self.model_orderModel.address =self.allorderModelList[i].address;
        //    self.model_orderModel.phone =self.allorderModelList[i].phone;
        //    self.model_orderModel.imageUrls =self.allorderModelList[i].imageUrls;
        //    self.model_orderModel.firstImg ='';
        //}
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
        //----- 消息管理 end -------------------
        this.messageFlag = true;
        this.appComponent = _appComponet;
    }
    //判断是否登录
    isLoginFlag() {
        if (!this.loginId || this.loginId == "undefined") {
            this.navStatus == -1;
        }
    }
    //左菜单点击事件；
    sidenavClick_admin(event, num) {
        if (!this.loginId || this.loginId == "undefined") {
            this.navStatus == -1;
        }
        else {
            this.navStatus = num;
        }
        var $targetP = $(event.target || event.srcElement).parent();
        $targetP.siblings().removeClass("on");
        $targetP.addClass("on");
        this.sidenavFun();
    }
    sidenavSpanClick_admin(event, num) {
        if (!this.loginId || this.loginId == "undefined") {
            this.navStatus == -1;
        }
        else {
            this.navStatus = num;
        }
        var $targetP = $(event.target || event.srcElement).parent().parent();
        $targetP.siblings().removeClass("on");
        $targetP.addClass("on");
        this.sidenavFun();
    }
    sidenavFun() {
        //////
    }
    //获取用户信息；
    getUserInfo() {
        var self = this;
        var appKey = Number(appService_1.appService.getCookie("appKey"));
        var token = appService_1.appService.getCookie("token");
        //当cookie值为空时，未登录；
        if (appKey == 0 || appKey == null || appKey == NaN)
            this.navStatus = -1;
        if (this.navStatus != -1) {
            $.ajax({
                url: appBase_1.appBase.DomainApi + "api/User/" + this.loginId,
                type: "get",
                dataType: "json",
                contentType: "application/json; charset=UTF-8",
                data: {
                    appKey: appKey,
                    token: token
                },
                success(json) {
                    if (json.isSuccess) {
                        self.userInfoModel.nickName = json.data.nickName;
                        self.userInfoModel.email = json.data.email;
                        self.userInfoModel.phone = json.data.phone;
                        self.userInfoModel.position = json.data.position;
                        if (json.data.headImageUrl != null) {
                            $.ajax({
                                url: appBase_1.appBase.DomainApi + 'api/Files/' + json.data.headImageUrl,
                                type: "GET",
                                success: function (data) {
                                    $(".j_usr_img").attr('src', data);
                                },
                                error: function (data) { }
                            });
                        }
                    }
                },
                error(data) {
                }
            });
        }
    }
    ////账户管理
    model_userStatusModel_selectOnchange(obj) {
        //userstatus select
        var userModelStatus = obj;
        this.model_userInfoModel.statusId = Number(userModelStatus);
    }
    model_userRoleModel_selectOnchange(obj) {
        //userrole select
        var userModelRole = obj;
        this.model_userInfoModel.roleId = Number(userModelRole);
    }
    //SearchByLoginId
    SearchByLoginId() {
        this.GetUserInfoListByCondition(-1, -1);
    }
    //get userAccountInfo List
    tabBoxClick_UserCursor(event, roleId, statusId) {
        var $targetP = $(event.target || event.srcElement).parent();
        $targetP.siblings().removeClass("on");
        $targetP.addClass("on");
        //get list
        this.GetUserInfoListByCondition(roleId, statusId);
    }
    //get user Info List by condition roleId=-1 query all,status = -1 query all
    GetUserInfoListByCondition(roleId, statusId) {
        var self = this;
        $.ajax({
            url: appBase_1.appBase.DomainApi + "api/User",
            type: "get",
            dataType: "json",
            contentType: "application/json; charset=UTF-8",
            data: {
                //"id": orderUid,
                "appKey": appService_1.appService.getCookie("appKey"),
                "token": appService_1.appService.getCookie("token"),
                "roleId": roleId,
                "statusId": statusId,
                "loginId": self.searchLoginId,
                "pageIndex": 1,
                "pageSize": 10,
                "isDesc": true
            },
            success(data) {
                if (data.isSuccess) {
                    self.userInfoModelList = [];
                    for (var i = 0; i < data.data.length; i++) {
                        var per_userInfoModel = new management_model_1.UserInfoModel();
                        per_userInfoModel.loginId = data.data[i].loginId;
                        per_userInfoModel.nickName = data.data[i].nickName;
                        per_userInfoModel.phone = data.data[i].phone;
                        per_userInfoModel.position = data.data[i].position;
                        per_userInfoModel.email = data.data[i].email;
                        per_userInfoModel.statusId = data.data[i].statusId;
                        per_userInfoModel.statusName = data.data[i].statusName;
                        per_userInfoModel.statusDescription = data.data[i].statusDescription;
                        per_userInfoModel.roleId = data.data[i].roleId;
                        per_userInfoModel.roleName = data.data[i].roleName;
                        per_userInfoModel.roleDescription = data.data[i].roleDescription;
                        per_userInfoModel.age = data.data[i].age;
                        per_userInfoModel.sexId = data.data[i].sexId;
                        per_userInfoModel.birthday = data.data[i].birthday;
                        per_userInfoModel.bloodTypeId = data.data[i].bloodTypeId;
                        per_userInfoModel.school = data.data[i].school;
                        per_userInfoModel.location = data.data[i].location;
                        per_userInfoModel.company = data.data[i].company;
                        per_userInfoModel.constellation = data.data[i].constellation;
                        per_userInfoModel.chineseZodiac = data.data[i].chineseZodiac;
                        per_userInfoModel.personalizedSignature = data.data[i].personalizedSignature;
                        per_userInfoModel.personalizedDescription = data.data[i].personalizedDescription;
                        per_userInfoModel.registerTime = data.data[i].registerTime;
                        self.userInfoModelList.push(per_userInfoModel);
                    }
                }
                else {
                    alert(data.msg);
                }
            },
            error(data) {
                alert(JSON.stringify(data));
                alert("服务器连接失败，请稍后重试...");
            }
        });
    }
    //点编辑的a标签事件，把本行的信息获取出来
    GetThisLineUserInfo(i) {
        var self = this;
        self.model_userInfoModel.loginId = self.userInfoModelList[i].loginId;
        self.model_userInfoModel.nickName = self.userInfoModelList[i].nickName;
        self.model_userInfoModel.phone = self.userInfoModelList[i].phone;
        self.model_userInfoModel.position = self.userInfoModelList[i].position;
        self.model_userInfoModel.email = self.userInfoModelList[i].email;
        self.model_userInfoModel.statusId = self.userInfoModelList[i].statusId;
        self.model_userInfoModel.statusName = self.userInfoModelList[i].statusName;
        self.model_userInfoModel.statusDescription = self.userInfoModelList[i].statusDescription;
        self.model_userInfoModel.roleId = self.userInfoModelList[i].roleId;
        self.model_userInfoModel.roleName = self.userInfoModelList[i].roleName;
        self.model_userInfoModel.roleDescription = self.userInfoModelList[i].roleDescription;
        self.model_userInfoModel.age = self.userInfoModelList[i].age;
        self.model_userInfoModel.sexId = self.userInfoModelList[i].sexId;
        self.model_userInfoModel.birthday = self.userInfoModelList[i].birthday;
        self.model_userInfoModel.bloodTypeId = self.userInfoModelList[i].bloodTypeId;
        self.model_userInfoModel.school = self.userInfoModelList[i].school;
        self.model_userInfoModel.location = self.userInfoModelList[i].location;
        self.model_userInfoModel.company = self.userInfoModelList[i].company;
        self.model_userInfoModel.constellation = self.userInfoModelList[i].constellation;
        self.model_userInfoModel.chineseZodiac = self.userInfoModelList[i].chineseZodiac;
        self.model_userInfoModel.personalizedSignature = self.userInfoModelList[i].personalizedSignature;
        self.model_userInfoModel.personalizedDescription = self.userInfoModelList[i].personalizedDescription;
        self.model_userInfoModel.registerTime = self.userInfoModelList[i].registerTime;
        //userstatus/role select
        var userModelStatus = (document.getElementById("userModelStatus"));
        userModelStatus.selectedIndex = self.userInfoModelList[i].statusId;
        var userModelStatus = (document.getElementById("userModelRole"));
        userModelStatus.selectedIndex = self.userInfoModelList[i].roleId;
    }
    //保存编辑用户；
    EditUser() {
        var self = this;
        $.ajax({
            url: appBase_1.appBase.DomainApi + "api/User",
            type: "put",
            dataType: "json",
            contentType: "application/json; charset=UTF-8",
            data: JSON.stringify({
                "appKey": appService_1.appService.getCookie("appKey"),
                "token": appService_1.appService.getCookie("token"),
                "loginId": self.model_userInfoModel.loginId,
                "nickName": self.model_userInfoModel.nickName,
                "phone": self.model_userInfoModel.phone,
                "headImageUrl": self.model_userInfoModel.headImageUrl,
                "age": self.model_userInfoModel.age,
                "sexId": self.model_userInfoModel.sexId,
                "birthday": self.model_userInfoModel.birthday,
                "bloodTypeId": self.model_userInfoModel.bloodTypeId,
                "position": self.model_userInfoModel.position,
                "school": self.model_userInfoModel.school,
                "location": self.model_userInfoModel.location,
                "company": self.model_userInfoModel.company,
                "constellation": self.model_userInfoModel.constellation,
                "chineseZodiac": self.model_userInfoModel.chineseZodiac,
                "personalizedSignature": self.model_userInfoModel.personalizedSignature,
                "personalizedDescription": self.model_userInfoModel.personalizedDescription
            }),
            success(data) {
                if (data.isSuccess) {
                    $.ajax({
                        url: appBase_1.appBase.DomainApi + "api/UserStatus",
                        type: "put",
                        dataType: "json",
                        contentType: "application/json; charset=UTF-8",
                        data: JSON.stringify({
                            "appKey": appService_1.appService.getCookie("appKey"),
                            "token": appService_1.appService.getCookie("token"),
                            "loginId": self.model_userInfoModel.loginId,
                            "statusLevel": self.model_userInfoModel.statusId
                        }),
                        success(data) {
                            if (data.isSuccess) {
                                $.ajax({
                                    url: appBase_1.appBase.DomainApi + "api/UserRole",
                                    type: "put",
                                    dataType: "json",
                                    contentType: "application/json; charset=UTF-8",
                                    data: JSON.stringify({
                                        "appKey": appService_1.appService.getCookie("appKey"),
                                        "token": appService_1.appService.getCookie("token"),
                                        "loginId": self.model_userInfoModel.loginId,
                                        "roleLevel": self.model_userInfoModel.roleId
                                    }),
                                    success(data) {
                                        if (data.isSuccess) {
                                            alert("用户信息修改成功~");
                                            self.GetUserInfoListByCondition(-1, -1);
                                        }
                                        else {
                                            alert("该用户 用户角色修改失败，请稍后重试~");
                                        }
                                    },
                                    error(data) {
                                        alert("该用户 用户角色修改失败，请稍后重试~");
                                    }
                                });
                            }
                            else {
                                alert("该用户 用户状态修改失败，请稍后重试~");
                            }
                        },
                        error(data) {
                            alert("该用户 用户状态修改失败，请稍后重试~");
                        }
                    });
                }
                else {
                    alert("该用户信息修改失败，请稍后重试~");
                }
            },
            error(data) {
                alert("该用户信息修改失败，请稍后重试~");
            }
        });
    }
    //get complain info
    GetComplainList(queryId, complainStatusId) {
        var self = this;
        $.ajax({
            url: appBase_1.appBase.DomainApi + "api/Complain",
            type: "get",
            dataType: "json",
            contentType: "application/json; charset=UTF-8",
            data: {
                //"id": orderUid,
                "appKey": appService_1.appService.getCookie("appKey"),
                "token": appService_1.appService.getCookie("token"),
                "queryId": queryId,
                "complainStatusId": complainStatusId,
                "loginId": appService_1.appService.getCookie("loginId"),
                "pageIndex": 1,
                "pageSize": 10,
                "isDesc": true
            },
            success(data) {
                if (data.isSuccess) {
                    self.complainModelList = [];
                    for (var i = 0; i < data.data.length; i++) {
                        var complainModel2 = new complain_model_1.ComplainModel();
                        complainModel2.complainUid = data.data[i].complainUid;
                        complainModel2.complainContent = data.data[i].complainContent;
                        complainModel2.complainUserUid = data.data[i].complainUserUid;
                        complainModel2.complainTime = data.data[i].complainTime;
                        complainModel2.complainStatusId = data.data[i].complainStatusId;
                        complainModel2.complainStatusName = data.data[i].complainStatusName;
                        self.complainModelList.push(complainModel2);
                    }
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
    //get single line info
    GetComplainFromList(i) {
        this.complainModel.complainUid = this.complainModelList[i].complainUid;
        this.complainModel.complainContent = this.complainModelList[i].complainContent;
        this.complainModel.complainUserUid = this.complainModelList[i].complainUserUid;
        this.complainModel.complainTime = this.complainModelList[i].complainTime;
        this.complainModel.complainStatusId = this.complainModelList[i].complainStatusId;
        this.complainModel.complainStatusName = this.complainModelList[i].complainStatusName;
    }
    tabBoxClick_ComplainCursor(event, queryId, complainStatusId) {
        var $targetP = $(event.target || event.srcElement).parent();
        $targetP.siblings().removeClass("on");
        $targetP.addClass("on");
        //get list
        this.GetComplainList(queryId, complainStatusId);
    }
    MarkToRead() {
        var self = this;
        $.ajax({
            url: appBase_1.appBase.DomainApi + "api/Complain/" + self.complainModel.complainUid,
            type: "put",
            dataType: "json",
            contentType: "application/json; charset=UTF-8",
            data: JSON.stringify({
                "appKey": appService_1.appService.getCookie("appKey"),
                "token": appService_1.appService.getCookie("token"),
            }),
            success(data) {
                if (data.isSuccess) {
                    $(".btn_closeModel").click();
                    self.GetComplainList(-1, 0); //如果更改成功，重新获取未读列表
                }
                else {
                    console.error(data.msg);
                }
            },
            error(data) {
                alert("服务器连接失败，请稍后重试...");
            }
        });
    }
    //tabclick
    tabBoxClick_allOrder(event, queryId, orderCategoryId, orderStatusId) {
        var $targetP = $(event.target || event.srcElement).parent();
        $targetP.siblings().removeClass("on");
        $targetP.addClass("on");
        //get list
        this.GetAllorderList(queryId, orderCategoryId, orderStatusId);
    }
    GetAllorderList(queryId, orderCategoryId, orderStatusId) {
        var self = this;
        $.ajax({
            url: appBase_1.appBase.DomainApi + "api/Order",
            type: "get",
            dataType: "json",
            contentType: "application/json; charset=UTF-8",
            data: {
                //queryId=-1 all queryId=1 publish queryId=2 receive orderCategory = -1 all orderStatusId=-1 all
                "appKey": appService_1.appService.getCookie("appKey"),
                "token": appService_1.appService.getCookie("token"),
                "publisherOrReceiverLoginId": appService_1.appService.getCookie("loginId"),
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
                    self.allorderModelList = [];
                    for (var i = 0; i < data.data.length; i++) {
                        var per_myorderModel = new management_model_1.MyorderModel();
                        per_myorderModel.orderUid = data.data[i].orderUid;
                        per_myorderModel.publisherUid = data.data[i].publisherUid;
                        per_myorderModel.publisherInfo = data.data[i].publisherInfo;
                        per_myorderModel.publishTime = data.data[i].publishTime;
                        per_myorderModel.orderDescription = data.data[i].orderDescription;
                        per_myorderModel.orderCategoryId = data.data[i].orderCategoryId;
                        per_myorderModel.orderCategory = data.data[i].orderCategory.CategoryName;
                        if (data.data[i].receiverUid == '00000000-0000-0000-0000-000000000000') {
                            per_myorderModel.receiverUid = '暂无';
                        }
                        else {
                            per_myorderModel.receiverUid = data.data[i].receiverUid;
                        }
                        per_myorderModel.receiverInfo = data.data[i].receiverInfo;
                        per_myorderModel.receiveTime = data.data[i].receiveTime;
                        per_myorderModel.orderStatusId = data.data[i].orderStatusId;
                        per_myorderModel.orderStatus = data.data[i].orderStatus.orderStatusDescription;
                        per_myorderModel.orderValue = data.data[i].orderValue;
                        per_myorderModel.allowVoucher = data.data[i].allowVoucher;
                        per_myorderModel.voucherMax = data.data[i].voucherMax;
                        per_myorderModel.evaluateUid = data.data[i].evaluateUid;
                        per_myorderModel.orderEvaluate = data.data[i].orderEvaluate;
                        per_myorderModel.address = data.data[i].address;
                        per_myorderModel.phone = data.data[i].phone;
                        per_myorderModel.imageUrls = data.data[i].imageUrls;
                        per_myorderModel.firstImg = data.data[i].imageDatas[0];
                        self.allorderModelList.push(per_myorderModel);
                    }
                }
                else {
                    console.error(data.msg);
                }
            },
            error(data) {
                alert("服务器连接失败，请稍后重试...");
            }
        });
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
                "loginId": "",
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
    }
    //撤回消息
    ReSetMessage(i) {
        var self = this;
        if (confirm("确定撤回这条消息？")) {
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
    //条件帅选 点击；
    tabBoxClick_message(event, num) {
        var $targetP = $(event.target || event.srcElement).parent();
        $targetP.siblings().removeClass("on");
        $targetP.addClass("on");
        if (num == 1) {
            this.messageFlag = false;
        }
        else {
            this.messageFlag = true;
        }
    }
    //----- end 消息管理 ---
    ngOnInit() {
        //左菜单 焦点 判断 显示;
        $(".manageCenterUl li").eq(appBase_1.appBase.AppObject.administratorStatus).addClass("on");
        this.isLoginFlag(); //判断是否登录
        this.getUserInfo();
        //获取用户列表
        this.GetUserInfoListByCondition(-1, -1);
        //获取投诉消息
        this.GetComplainList(-1, -1);
        //获取信息列表
        this.GetMessagePushList(-1);
        //获取订单列表
        this.GetAllorderList(-1, -1, -1);
    }
};
AdministratorComponent = __decorate([
    core_1.Component({
        selector: 'administrator',
        templateUrl: 'app/20-management_center/administrator/administrator.component.html',
        styleUrls: ['app/20-management_center/management.component.css'],
        providers: []
    }), 
    __metadata('design:paramtypes', [app_component_1.AppComponent])
], AdministratorComponent);
exports.AdministratorComponent = AdministratorComponent;
//# sourceMappingURL=administrator.component.js.map