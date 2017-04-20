"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
const core_1 = require("@angular/core");
const detail_model_1 = require("./detail.model");
const appBase_1 = require("../../../00-AQX_Frame.commons/appBase");
const appService_1 = require("../../../00-AQX_Frame.services/appService");
//注入器的两种：NgModule/Component(只在当前及子组件中生效)
let Detail = class Detail {
    //注入器的两种：NgModule/Component(只在当前及子组件中生效)
    constructor() {
        // 话题id
        this.topicId = appService_1.appService.GetQueryString('articleUid');
        // 回复者id集合
        this.UserIdList = [];
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
            imageDatas: ""
        };
        // 回复对象
        this.commentReply = {
            commentUid: "",
            articleIdOrCommentId: 1,
            commentUserLoginId: "",
            commentContent: "",
            commentTime: ""
        };
        this.commentReplyList = [];
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
    GetTopic() {
        var self = this;
        $.ajax({
            url: appBase_1.appBase.DomainApi + "api/Article/" + this.topicId,
            type: "get",
            dataType: "json",
            contentType: "application/json; charset=UTF-8",
            data: {
                "appKey": appService_1.appService.getCookie("appKey"),
                "token": appService_1.appService.getCookie("token"),
                "articleUid": this.topicId
            },
            success(data) {
                if (data.isSuccess) {
                    var dataList = data.data;
                    self.article.articleUid = dataList.articleUid;
                    self.article.articleTitle = dataList.articleTitle;
                    self.article.articleContent = dataList.articleContent;
                    self.article.loginId = dataList.publisherInfo.loginId;
                    self.article.nickName = dataList.publisherInfo.nickName;
                    self.article.publishTime = dataList.publishTime;
                    self.article.clickCount = dataList.clickCount;
                    self.article.praiseCount = dataList.praiseCount;
                    self.article.ArticleCategoryId = dataList.ArticleCategoryId;
                    self.article.articleCategoryName = dataList.articleCategory.CategoryName;
                    self.article.imageDatas = dataList.imageDatas[0];
                    // 设置头像
                    $("#dp").attr('src', self.article.imageDatas);
                    // 请求头像绝对路径
                    /* $.ajax({
                         url: appBase.DomainApi + 'api/Files/' + dataList.publisherInfo.headImageUrl,
                         type: "GET",
                         success: function (data) {
                             // 设置头像
                             $("#dp").attr('src', data);
                         },
                         error: function (data) {
                            
                         }
                     });*/
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
    // 获取登陆用户信息；
    /*getUserInfo(): void {
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
                                    self.userInfoModel.headImageUrl = data;
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

    }*/
    // 增加点赞量
    addPraiseCount() {
        var self = this;
        $.ajax({
            url: appBase_1.appBase.DomainApi + "api/Article/3",
            type: "put",
            dataType: "json",
            contentType: "application/json; charset=UTF-8",
            data: JSON.stringify({
                "appKey": appService_1.appService.getCookie("appKey"),
                "token": appService_1.appService.getCookie("token"),
                "articleUid": this.topicId
            }),
            success(data) {
                if (data.isSuccess) {
                    console.log(data);
                    var dataList = data.data;
                    self.article.praiseCount = dataList.praiseCount;
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
    // 获取回复
    getCommentReply() {
        var self = this;
        $.ajax({
            url: appBase_1.appBase.DomainApi + "api/CommentReply",
            type: "get",
            dataType: "json",
            contentType: "application/json; charset=UTF-8",
            data: {
                "appKey": appService_1.appService.getCookie("appKey"),
                "token": appService_1.appService.getCookie("token"),
                "articleUid": this.topicId,
                "PageIndex": 1,
                "PageSize": 5,
                "IsDESC": true
            },
            success(data) {
                if (data.isSuccess) {
                    var dataList = data.data;
                    // console.log(dataList)
                    // 条数
                    var dataCount = data.dataCount;
                    // 分页
                    self.getPage(5, dataCount);
                    self.commentReplyList = [];
                    for (var i = 0; i < dataList.length; i++) {
                        var commentReplyObject = new detail_model_1.CommentReply();
                        commentReplyObject.commentUid = dataList[i].commentUid;
                        commentReplyObject.articleIdOrCommentId = dataList[i].articleIdOrCommentId;
                        commentReplyObject.commentUserLoginId = dataList[i].commentUserLoginId;
                        commentReplyObject.commentContent = dataList[i].commentContent;
                        commentReplyObject.commentTime = dataList[i].commentTime;
                        self.commentReplyList.push(commentReplyObject);
                        self.UserIdList[i] = dataList[i].commentUserLoginId;
                    }
                }
                else {
                    alert(data.msg);
                }
            },
            error(data) {
                alert("服务器错误！");
            }
        });
        self.getReplyImg();
        var use = setInterval(function () {
            if (self.UserIdList.length !== 0) {
                self.getReplyImg();
                clearInterval(use);
            }
        }, 200);
    }
    // 获取回复者头像
    getReplyImg() {
        var self = this;
        //console.log(self.UserIdList.length)
    }
    // 分页
    getPage(pageDataCount, dataCount) {
        var pageCount = Number(dataCount) / pageDataCount;
        //console.log(pageCount);
    }
    // 回复
    addCommentReply() {
        var self = this;
        var commentText = $("#editor_id").val();
        var id = self.article.articleUid;
        console.log(this.topicId);
        console.log(this.loginId);
        console.log(commentText);
        $.ajax({
            url: appBase_1.appBase.DomainApi + "api/CommentReply",
            type: "post",
            dataType: "json",
            contentType: "application/json; charset=UTF-8",
            data: JSON.stringify({
                "appKey": appService_1.appService.getCookie("appKey"),
                "token": appService_1.appService.getCookie("token"),
                "articleIdOrCommentId": this.topicId,
                "commentUserLoginId": this.loginId,
                "commentContent": commentText
            }),
            success(data) {
                if (data.isSuccess) {
                    // 查询回复列表
                    self.getCommentReply();
                }
                else {
                }
            },
            error(data) {
                alert("服务器错误！");
            }
        });
    }
    // 修改话题
    modefiyTopic() {
        var topicId = appService_1.appService.GetQueryString('articleUid');
        $.ajax({
            url: appBase_1.appBase.DomainApi + "api/Article/1",
            type: "put",
            dataType: "json",
            contentType: "application/json; charset=UTF-8",
            data: JSON.stringify({
                "appKey": appService_1.appService.getCookie("appKey"),
                "token": appService_1.appService.getCookie("token"),
                "articleUid": topicId,
                "articleTitle": $("#topicName").val(),
                "articleContent": $("#topicContent").val(),
                // "ArticleCategoryId": $("#topicType").val(),
                "imagesUrls": ""
            }),
            success(data) {
                if (data.isSuccess) {
                    var dataList = data.data;
                    console.log(data);
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
    ////the final execute ...
    ngOnInit() {
        this.GetTopic();
        this.getCommentReply();
        $('#modefiyTopic').on('click', this.modefiyTopic);
    }
};
Detail = __decorate([
    core_1.Component({
        selector: 'detail',
        templateUrl: 'app/70-community/71-topic/detail/detail.html',
        styleUrls: ['app/70-community/71-topic/detail/detail.css'],
        providers: [] //元数据中申明依赖
    })
], Detail);
exports.Detail = Detail;
//# sourceMappingURL=detail.js.map