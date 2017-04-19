import { Component, OnInit } from '@angular/core';
import { appBase } from '../00-AQX_Frame.commons/appBase';
import { appService } from '../00-AQX_Frame.services/appService';
import { UserInfoModel } from './management.model';
import { Router, ActivatedRoute, Params } from '@angular/router';

@Component({
    selector: 'managementCenter',
    templateUrl: 'app/20-management_center/management.component.html',
    styleUrls: ['app/20-management_center/management.component.css'],
    providers: []
})

export class ManagementComponent implements OnInit {
    router: Router;
    constructor(_router: Router) {
        this.router = _router;
    }
    //模型绑定;
    userInfoModel: UserInfoModel = {
        loginId: appService.getCookie('loginId'),
        nickName: '',
        headImageUrl: "../../Images/20-management/user_default_img.png",
        email: "4527875@foxmail.com",
        phone: "18254688788",
        position: "天津市西青区",
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
        personalizedDescription: '',
        registerTime: '',
        statusId: 0,
        statusName: '',
        statusDescription: '正常',
        roleId: 0,
        roleName: '',
        roleDescription: '普通用户'
    }

    headerImageData: any;

    //global
    navStatus: number = appBase.AppObject.centerStatus; //-1未登录；
    loginId: string = appService.getCookie("loginId");
    //判断是否登录
    isLoginFlag(): void {
        if (!this.loginId || this.loginId == "undefined") {
            this.navStatus == -1;
        }
    }

    //左菜单点击事件；
    sidenavClick(event, num): void { //a
        if (!this.loginId || this.loginId == "undefined") {
            this.navStatus == -1;
        } else {
            this.navStatus = num;
        }
        var $targetP = $(event.target || event.srcElement).parent();
        $targetP.siblings().removeClass("on");
        $targetP.addClass("on");
        this.sidenavFun();
    }
    sidenavSpanClick(event, num): void { //span
        if (!this.loginId || this.loginId == "undefined") {
            this.navStatus == -1;
        } else {
            this.navStatus = num;
        }
        var $targetP = $(event.target || event.srcElement).parent().parent();
        $targetP.siblings().removeClass("on");
        $targetP.addClass("on");
        this.sidenavFun();
    }
    sidenavFun(): void { //切换 实质
        //////
    }

    ////个人账户
    //上传头像
    uploadFlag: boolean = false;
    uploadErrorMsg: string = "";
    personalHeadUpload(event): void {
        var self = this;
        var formData = new FormData((<HTMLFormElement[]><any>$("#uploadHeadForm"))[0]);
        $.ajax({
            url: appBase.DomainApi + 'api/Files',
            type: 'POST',
            data: formData,
            async: false,
            cache: false,
            contentType: false,
            processData: false,
            success: function (json) {
                if (json.errorCode == 2005) {
                    self.uploadFlag = false;
                    self.uploadErrorMsg = "文件类型不允许";
                }
                else {
                    self.uploadFlag = true;
                    self.userInfoModel.headImageUrl = json.data[0]; //头像地址保存
                    for (var i = 0; i < json.dataCount; i++) {
                        $.ajax({
                            url: appBase.DomainApi + 'api/Files/' + json.data[i],
                            type: "GET",
                            success: function (data) {
                                self.headerImageData = data;
                                $(".j_usr_img").attr('src', data);
                            },
                            error: function (data) {
                                self.uploadFlag = false;
                                self.uploadErrorMsg = "图片已上传成功，预览失败~";
                            }
                        });

                    }
                }
            },
            error: function (json) {
                self.uploadFlag = false;
            }
        });
    }
    //获取用户信息；
    getUserInfo(): void {
        var self = this;
        var appKey = Number(appService.getCookie("appKey"));
        var token = appService.getCookie("token");
        //当cookie值为空时，未登录；
        if (appKey == 0 || appKey == null || appKey == NaN) this.navStatus = -1;
        if (this.navStatus != -1) {
            $.ajax({
                url: appBase.DomainApi + "api/User/" + this.loginId,
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
                                url: appBase.DomainApi + 'api/Files/' + json.data.headImageUrl,
                                type: "GET",
                                success: function (data) {
                                    //$(".prePotrait img").eq(0).attr('src', data);
                                    self.headerImageData= data;
                                    $(".j_usr_img").attr('src', data);
                                },
                                error: function (data) {
                                    self.uploadFlag = false;
                                    self.uploadErrorMsg = "头像获取失败~";
                                }
                            });
                        }


                    }
                },
                error(data) {

                }
            });
        }

    }
    //保存 用户信息
    userInfoSave(): void {
        var self = this;
        $.ajax({
            url: appBase.DomainApi + "api/User",
            type: "put",
            dataType: "json",
            contentType: "application/json; charset=UTF-8",
            data: JSON.stringify(
                {
                    "appKey": appService.getCookie("appKey"),
                    "token": appService.getCookie("token"),
                    "loginId": self.userInfoModel.loginId,
                    "nickName": self.userInfoModel.nickName,
                    "phone": self.userInfoModel.phone,
                    "headImageUrl": self.userInfoModel.headImageUrl,
                    "age": self.userInfoModel.age,
                    "sexId": self.userInfoModel.sexId,
                    "birthday": self.userInfoModel.birthday,
                    "bloodTypeId": self.userInfoModel.bloodTypeId,
                    "position": self.userInfoModel.position,
                    "school": self.userInfoModel.school,
                    "location": self.userInfoModel.location,
                    "company": self.userInfoModel.company,
                    "constellation": self.userInfoModel.constellation,
                    "chineseZodiac": self.userInfoModel.chineseZodiac,
                    "personalizedSignature": self.userInfoModel.personalizedSignature,
                    "personalizedDescription": self.userInfoModel.personalizedDescription
                }),
            success(data) {
                if (data.isSuccess) {
                    alert("个人信息修改成功~");
                }
                else {
                    alert("个人信息修改失败，请稍后重试~");
                }
            },
            error(data) {
                alert("个人信息修改失败，请稍后重试~");
            }
        });
    }

    ////我的订单
    //条件帅选 点击；
    tabBoxClick_myorder(event): void {
        var $targetP = $(event.target || event.srcElement).parent();
        $targetP.siblings().removeClass("on");
        $targetP.addClass("on");
    }
    toMyorderDetail(): void {
        this.router.navigateByUrl('/myorderDetail');//跳转未登录页面；
    }

    ////我的发布

    //the final execute ...
    ngOnInit(): void {
        //左菜单 焦点 判断 显示；
        $(".manageCenterUl li").eq(appBase.AppObject.centerStatus).addClass("on");
        this.isLoginFlag(); //判断是否登录
        this.getUserInfo();

    }
}