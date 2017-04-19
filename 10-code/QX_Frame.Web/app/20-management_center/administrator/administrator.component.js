"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
const core_1 = require("@angular/core");
const appBase_1 = require("../../00-AQX_Frame.commons/appBase");
const appService_1 = require("../../00-AQX_Frame.services/appService");
let AdministratorComponent = class AdministratorComponent {
    constructor() {
        //模型绑定;
        this.userInfoModel = {
            loginId: appService_1.appService.getCookie('loginId'),
            nickName: '',
            headImageUrl: "../../Images/20-management/user_default_img.png",
            email: "4527875@foxmail.com",
            phone: "18254688788",
            position: "天津市西青区",
            appKey: Number(appService_1.appService.getCookie('appKey')),
            token: appService_1.appService.getCookie('token'),
            age: 21,
            sexId: 0,
            birthday: '2017-04-16',
            bloodTypeId: 0,
            school: '',
            location: '',
            company: '',
            constellation: '',
            chineseZodiac: '',
            personalizedSignature: '',
            personalizedDescription: ''
        };
        //global
        this.navStatus = appBase_1.appBase.AppObject.administratorStatus; //-1未登录；
        this.loginId = appService_1.appService.getCookie("loginId");
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
    ////个人账户
    //上传头像
    //uploadFlag: boolean = false;
    //uploadErrorMsg: string = "";
    //personalHeadUpload(event): void {
    //    var self = this;
    //    var formData = new FormData((<HTMLFormElement[]><any>$("#uploadHeadForm"))[0]);
    //    $.ajax({
    //        url: appBase.DomainApi + 'api/Files',
    //        type: 'POST',
    //        data: formData,
    //        async: false,
    //        cache: false,
    //        contentType: false,
    //        processData: false,
    //        success: function (json) {
    //            if (json.errorCode == 2005) {
    //                self.uploadFlag = false;
    //                self.uploadErrorMsg = "文件类型不允许";
    //            }
    //            else {
    //                self.uploadFlag = true;
    //                self.userInfoModel.headImageUrl = json.data[0]; //头像地址保存
    //                for (var i = 0; i < json.dataCount; i++) {
    //                    $.ajax({
    //                        url: appBase.DomainApi + 'api/Files/' + json.data[i],
    //                        type: "GET",
    //                        success: function (data) {
    //                            //$(".prePotrait img").eq(0).attr('src', data);
    //                            self.userInfoModel.headImageUrl = data;
    //                            $(".j_usr_img").attr('src', data);
    //                        },
    //                        error: function (data) {
    //                            self.uploadFlag = false;
    //                            self.uploadErrorMsg = "图片已上传成功，预览失败~";
    //                        }
    //                    });
    //                }
    //            }
    //        },
    //        error: function (json) {
    //            self.uploadFlag = false;
    //        }
    //    });
    //}
    ////获取用户信息；
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
    ////保存 用户信息
    //userInfoSave(): void {
    //    var self = this;
    //    $.ajax({
    //        url: appBase.DomainApi + "api/User",
    //        type: "put",
    //        dataType: "json",
    //        contentType: "application/json; charset=UTF-8",
    //        data: JSON.stringify(
    //            {
    //                "appKey": self.userInfoModel.appKey,
    //                "token": self.userInfoModel.token,
    //                "loginId": self.userInfoModel.loginId,
    //                "nickName": self.userInfoModel.nickName,
    //                "phone": self.userInfoModel.phone,
    //                "headImageUrl": self.userInfoModel.headImageUrl,
    //                "age": self.userInfoModel.age,
    //                "sexId": self.userInfoModel.sexId,
    //                "birthday": self.userInfoModel.birthday,
    //                "bloodTypeId": self.userInfoModel.bloodTypeId,
    //                "position": self.userInfoModel.position,
    //                "school": self.userInfoModel.school,
    //                "location": self.userInfoModel.location,
    //                "company": self.userInfoModel.company,
    //                "constellation": self.userInfoModel.constellation,
    //                "chineseZodiac": self.userInfoModel.chineseZodiac,
    //                "personalizedSignature": self.userInfoModel.personalizedSignature,
    //                "personalizedDescription": self.userInfoModel.personalizedDescription
    //            }),
    //        success(data) {
    //            if (data.isSuccess) {
    //                alert("个人信息修改成功~");
    //            }
    //            else {
    //                alert("个人信息修改失败，请稍后重试~");
    //            }
    //        },
    //        error(data) {
    //            alert("个人信息修改失败，请稍后重试~");
    //        }
    //    });
    //}
    ////账户管理
    selectOnchang(obj) {
        alert(obj);
        return obj;
    }
    //编辑用户；
    EditUser() {
    }
    //删除用户；
    //DeleteUser(): void {
    //}
    ////订单管理
    ////投诉管理
    //the final execute ...
    ngOnInit() {
        //左菜单 焦点 判断 显示；
        $(".manageCenterUl li").eq(appBase_1.appBase.AppObject.administratorStatus).addClass("on");
        this.isLoginFlag(); //判断是否登录
        this.getUserInfo();
    }
};
AdministratorComponent = __decorate([
    core_1.Component({
        selector: 'administrator',
        templateUrl: 'app/20-management_center/administrator/administrator.component.html',
        styleUrls: ['app/20-management_center/management.component.css'],
        providers: []
    })
], AdministratorComponent);
exports.AdministratorComponent = AdministratorComponent;
//# sourceMappingURL=administrator.component.js.map