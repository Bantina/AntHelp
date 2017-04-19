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
const appBase_1 = require('../../../00-AQX_Frame.commons/appBase');
const appService_1 = require('../../../00-AQX_Frame.services/appService');
//注入器的两种：NgModule/Component(只在当前及子组件中生效)
let Detail = class Detail {
    constructor() {
        // 话题对象
        this.article = {
            articleUid: "",
            articleTitle: "",
            articleContent: "",
            loginId: "",
            nickName: "",
            publishTime: "",
            clickCount: 0,
            praiseCount: 0,
            ArticleCategoryId: "",
            articleCategoryName: "",
            imagesNameList: ""
        };
        // 用户状态
        this.navStatus = appBase_1.appBase.AppObject.centerStatus; //-1未登录；
        this.loginId = appService_1.appService.getCookie("loginId");
        // 提示信息
        this.uploadErrorMsg = "";
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
    }
    // 获取话题
    GetTopic(topicId) {
        var self = this;
        $.ajax({
            url: appBase_1.appBase.DomainApi + "api/Article/" + topicId,
            type: "get",
            dataType: "json",
            contentType: "application/json; charset=UTF-8",
            data: {
                "appKey": appService_1.appService.getCookie("appKey"),
                "token": appService_1.appService.getCookie("token"),
                "articleUid": topicId
            },
            success(data) {
                if (data.isSuccess) {
                    var dataList = data.data;
                    self.article.articleTitle = dataList.articleTitle;
                    self.article.articleContent = dataList.articleContent;
                    self.article.loginId = dataList.loginId;
                    self.article.nickName = dataList.publisherInfo.nickName;
                    self.article.publishTime = dataList.publishTime;
                    self.article.clickCount = dataList.clickCount;
                    self.article.praiseCount = dataList.praiseCount;
                    self.article.ArticleCategoryId = dataList.ArticleCategoryId;
                    self.article.articleCategoryName = dataList.articleCategory.CategoryName;
                    self.article.imagesNameList = dataList.imagesNameList;
                }
                else {
                    alert(data.msg);
                }
            },
            error(data) {
                alert("服务器错误！");
            }
        });
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
                                    //$(".prePotrait img").eq(0).attr('src', data);
                                    self.userInfoModel.headImageUrl = data;
                                    console.log(data);
                                    $("#dp").attr('src', data);
                                },
                                error: function (data) {
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
    ////the final execute ...
    ngOnInit() {
        var topicId = appService_1.appService.GetQueryString('articleUid');
        this.GetTopic(topicId);
        this.getUserInfo();
    }
};
Detail = __decorate([
    core_1.Component({
        selector: 'detail',
        templateUrl: 'app/70-community/71-topic/detail/detail.html',
        styleUrls: ['app/70-community/71-topic/detail/detail.css'],
        providers: [] //元数据中申明依赖
    }), 
    __metadata('design:paramtypes', [])
], Detail);
exports.Detail = Detail;
//# sourceMappingURL=detail.js.map