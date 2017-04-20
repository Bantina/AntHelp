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
const management_model_1 = require('./../management.model');
let AdministratorComponent = class AdministratorComponent {
    constructor() {
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
        //删除用户；
        //DeleteUser(): void {
        //}
        ////订单管理
        ////投诉管理
        ////消息管理
        this.messageFlag = true;
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
    //the final execute ...
    ngOnInit() {
        //左菜单 焦点 判断 显示；
        $(".manageCenterUl li").eq(appBase_1.appBase.AppObject.administratorStatus).addClass("on");
        this.isLoginFlag(); //判断是否登录
        this.getUserInfo();
        //获取用户列表
        this.GetUserInfoListByCondition(-1, -1);
    }
};
AdministratorComponent = __decorate([
    core_1.Component({
        selector: 'administrator',
        templateUrl: 'app/20-management_center/administrator/administrator.component.html',
        styleUrls: ['app/20-management_center/management.component.css'],
        providers: []
    }), 
    __metadata('design:paramtypes', [])
], AdministratorComponent);
exports.AdministratorComponent = AdministratorComponent;
//# sourceMappingURL=administrator.component.js.map