import { Component, OnInit } from '@angular/core';
import { appBase } from '../00-AQX_Frame.commons/appBase';
import { appService } from '../00-AQX_Frame.services/appService';
import { UserInfoModel, MyorderModel } from './management.model';
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

    //个人订单信息列表
    myorderModelList: MyorderModel[] = [];
    myorderImgArr: any = [];




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
    sidenavClick(event, num, queryId, orderCategoryId, orderStatusId): void { //a
        if (!this.loginId || this.loginId == "undefined") {
            this.navStatus == -1;
        } else {
            this.navStatus = num;
        }
        var $targetP = $(event.target || event.srcElement).parent();
        $targetP.siblings().removeClass("on");
        $targetP.addClass("on");
        if (num != 0) {
            this.GetMyorderList(queryId, orderCategoryId, orderStatusId);
        }
    }
    sidenavSpanClick(event, num, queryId, orderCategoryId, orderStatusId): void { //span
        if (!this.loginId || this.loginId == "undefined") {
            this.navStatus == -1;
        } else {
            this.navStatus = num;
        }
        var $targetP = $(event.target || event.srcElement).parent().parent();
        $targetP.siblings().removeClass("on");
        $targetP.addClass("on");
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
                url: appBase.DomainApi + "api/User?id=" + self.loginId,
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
                                    self.headerImageData = data;
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
                    console.error(data);
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
    tabBoxClick_myorder(event, queryId, orderCategoryId, orderStatusId): void {
        var $targetP = $(event.target || event.srcElement).parent();
        $targetP.siblings().removeClass("on");
        $targetP.addClass("on");
        this.GetMyorderList(queryId, orderCategoryId, orderStatusId);
    }
    toMyorderDetail(index: number): void {
        //this.router.navigateByUrl('/myorderDetail');//跳转订单详情页面
        this.router.navigateByUrl('/myorderDetail?orderUid=' + this.myorderModelList[index].orderUid);//跳转订单详情页面
    }

    //get MyorderList List 获取个人订单列表;--我的订单
    GetMyorderList(queryId, orderCategoryId, orderStatusId): void {
        var self = this;
        $.ajax({
            url: appBase.DomainApi + "api/Order",
            type: "get",
            dataType: "json",
            contentType: "application/json; charset=UTF-8",
            data: {
                //queryId=-1 all queryId=1 publish queryId=2 receive orderCategory = -1 all orderStatusId=-1 all
                "appKey": appService.getCookie("appKey"),
                "token": appService.getCookie("token"),
                "publisherOrReceiverLoginId": appService.getCookie("loginId"),
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
                    self.myorderModelList = [];
                    for (var i = 0; i < data.data.length; i++) {
                        var per_myorderModel = new MyorderModel();

                        per_myorderModel.orderUid = data.data[i].orderUid;
                        per_myorderModel.publisherUid = data.data[i].nickNamepublisherUid;
                        per_myorderModel.publisherInfo = data.data[i].publisherInfo;
                        per_myorderModel.publishTime = data.data[i].publishTime;
                        per_myorderModel.orderDescription = data.data[i].orderDescription;
                        per_myorderModel.orderCategoryId = data.data[i].orderCategoryId;
                        per_myorderModel.orderCategory = data.data[i].orderCategory;
                        per_myorderModel.receiverUid = data.data[i].receiverUid;
                        per_myorderModel.receiverInfo = data.data[i].receiverInfo;
                        per_myorderModel.receiveTime = data.data[i].receiveTime;
                        per_myorderModel.orderStatusId = data.data[i].orderStatusId;
                        per_myorderModel.orderStatus = data.data[i].orderStatus;
                        per_myorderModel.orderValue = data.data[i].sexIdorderValue;
                        per_myorderModel.allowVoucher = data.data[i].allowVoucher;
                        per_myorderModel.voucherMax = data.data[i].voucherMax;
                        per_myorderModel.evaluateUid = data.data[i].evaluateUid;
                        per_myorderModel.orderEvaluate = data.data[i].orderEvaluate;
                        per_myorderModel.address = data.data[i].address;
                        per_myorderModel.phone = data.data[i].phone;
                        per_myorderModel.imageUrls = data.data[i].imageUrls;
                        per_myorderModel.firstImg = data.data[i].imageDatas[0];

                        self.myorderModelList.push(per_myorderModel);
                    }
                } else {
                    console.error(data.msg);
                }
            },
            error(data) {
                alert("服务器连接失败，请稍后重试...");
            }
        });
    }

    //我的发布


    //the final execute ...
    ngOnInit(): void {
        //左菜单 焦点 判断 显示；
        $(".manageCenterUl li").eq(appBase.AppObject.centerStatus).addClass("on");
        this.isLoginFlag(); //判断是否登录
        this.getUserInfo();
        this.GetMyorderList(2, -1, -1);

    }
}