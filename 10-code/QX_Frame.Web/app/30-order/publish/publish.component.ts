﻿import { Component, OnInit } from '@angular/core';
import { appBase } from '../../00-AQX_Frame.commons/appBase';
import { PublishAidModel, Order } from './../order.model';
import { appService } from '../../00-AQX_Frame.services/appService';
import { Router, ActivatedRoute, Params } from '@angular/router';

@Component({
    selector: 'publish',
    templateUrl: 'app/30-order/publish/publish.component.html',
    styleUrls: ['app/30-order/publish/publish.component.css'],
    providers: []
})

export class PublishComponent implements OnInit {
    router: Router;
    constructor(_router: Router) {
        this.router = _router;
    }
    publishAidModel: PublishAidModel = {
        loginId: "",
        kinds: "",
        imges: "",
        description: "",
        price: 0,
        address: "",
        phone: 1001688
    };

    order: Order =
    {
        orderUid: "",
        publisherUid: "",
        publishTime: "",
        orderDescription: "",
        orderCategoryId: "10",
        receiverUid: "",
        receiveTime: "",
        orderStatusId: "",
        orderValue: "0",
        allowVoucher: "",
        voucherMax: "",
        evaluateUid: "",
        address: "",
        phone: "",
        imageUrls: "",
        imageDatas: []
    }

    //publish_kinds: any = {
    //    count: 9,
    //    imgSrc: ["../images/octopus.png", "../images/octopus.png", "../images/octopus.png", "../images/octopus.png", "../images/octopus.png", "../images/octopus.png", "../images/octopus.png", "../images/octopus.png", "../images/octopus.png"],
    //    kindName: ["二手市级","免费专场","房屋租赁","人才招聘","生活服务","寻人启示","宠物之家","兼职实习","教育培训"]
    //}


    //kinds list 

    kindsName: string = "代购代帮";
    publish_kinds: any = {
        publish: [
            {
                id: 2,
                imgSrc: "../../../Images/30-order/kinds_icon01.png",
                kindName: "代购代帮"
            }, {
                id: 3,
                imgSrc: "../../../Images/30-order/kinds_icon02.png",
                kindName: "代理销售"
            }, {
                id: 4,
                imgSrc: "../../../Images/30-order/kinds_icon03.png",
                kindName: "维修装修"
            }, {
                id: 5,
                imgSrc: "../../../Images/30-order/kinds_icon04.png",
                kindName: "家政服务"
            }, {
                id: 6,
                imgSrc: "../../../Images/30-order/kinds_icon05.png",
                kindName: "免费专场"
            }, {
                id: 7,
                imgSrc: "../../../Images/30-order/kinds_icon06.png",
                kindName: "宠物之家"
            }, {
                id: 8,
                imgSrc: "../../../Images/30-order/kinds_icon07.png",
                kindName: "汽车服务"
            }, {
                id: 9,
                imgSrc: "../../../Images/30-order/kinds_icon08.png",
                kindName: "休闲服务"
            }, {
                id: 10,
                imgSrc: "../../../Images/30-order/kinds_icon09.png",
                kindName: "其他服务"
            }
        ]
    }

    imageList: any = [];
    imageNameList: any = [];
    uploadFlag: string = "";
    changeInput: string = "";
    uploadErrorMsg = "上传失败,请重新上传~";
    showImg: boolean = true;

    //打开模态框-修改分类
    openModal(event): void {
        var target = event.target || event.srcElement;
        var kindTar = $(target).parent().find(".public_kind");
        if (kindTar.selector == ".public_kind") {
            kindTar = $(target).parent().parent().find(".public_kind");
        }
        if (kindTar != undefined) {
            this.kindsName = kindTar.text();
        }
        this.order.orderCategoryId = kindTar.parent().attr("id");
        if (this.order.orderCategoryId == '6') {
            $('.publish_price').attr('readonly', 'readonly').val('0');
            this.order.orderValue = '0';
        } else {
            $('.publish_price').removeAttr('readonly').val('');
        }

    }

    //上传图片
    addUpload(event): void {
        $('#publish_upload').click();
    }
    publishUpload(event): void {
        var self = this;
        var formData = new FormData((<HTMLFormElement[]><any>$("#uploadForm"))[0]);
        $.ajax({
            url: appBase.DomainApi + 'api/Files',
            type: 'POST',
            data: formData,
            async: false,
            cache: false,
            contentType: false,
            processData: false,
            success: function (json) {
                self.showImg = true;
                if (json.errorCode == 2005) {
                    self.uploadFlag = "false";
                    self.uploadErrorMsg = "文件类型不允许";
                }
                else {
                    self.uploadFlag = "true";

                    for (var j in json.data) {
                        self.imageNameList.push(json.data[j]);
                    }

                    for (var i = 0; i < json.dataCount; i++) {
                        $.ajax({
                            url: appBase.DomainApi + 'api/Files/' + json.data[i],
                            type: "GET",
                            success: function (data) {
                                self.imageList.push(data);
                            },
                            error: function (data) {
                                self.uploadFlag = "false";
                                self.uploadErrorMsg = "图片已上传成功，预览失败~";
                            }
                        });
                    }
                }
            },
            error: function (json) {
                self.uploadFlag = "false";
            }
        });
    }

    publishAid(): void {
        var self = this;
        var a = 1;
    }

    /**
     * 发布订单
     */
    OrderPublish(): void {

        var self = this;
        self.order.imageUrls = "";
        for (var i = 0; i < self.imageNameList.length; i++) {
            if (self.imageNameList.length == 1) {
                self.order.imageUrls += self.imageNameList[i];
            } else {
                if (i == 0) {
                    self.order.imageUrls += self.imageNameList[i];
                } else {
                    self.order.imageUrls += ("&" + self.imageNameList[i]);
                }
            }
        }

        if (self.order.orderCategoryId == "") {
            alert("orderCategoryId cannot be null!");
        } else if (self.order.orderValue == "") {
            alert("orderValue cannot be null!");
        } else if (self.order.phone == "") {

            alert("phone number cannot be null!");
        } else {
            $.ajax({
                url: appBase.DomainApi + "api/Order",
                type: "post",
                dataType: "json",
                contentType: "application/json; charset=UTF-8",
                data: JSON.stringify(
                    {
                        "appKey": appService.getCookie("appKey"),
                        "token": appService.getCookie("token"),
                        "publisherLoginId": appService.getCookie("loginId"),
                        "orderDescription": self.order.orderDescription,
                        "orderCategoryId": self.order.orderCategoryId,
                        "orderValue": self.order.orderValue,
                        "address": self.order.address,
                        "phone": self.order.phone,
                        "imageUrls": self.order.imageUrls
                    }),
                success(data) {
                    if (data.isSuccess) {
                        alert("订单下发成功~");
                        self.imageNameList = [];
                        //数据清空；
                        self.OrderPublishClear();

                    } else {
                        alert(data.msg);
                    }
                },
                error(data) {
                    alert("服务器错误！");
                }
            });
        }
        
    }

    /**
    当用户关闭/取消发布模态框时，清除已输入数据；
    */
    OrderPublishClear(): void{
        var self = this;
        self.order.orderDescription = "";
        self.order.address = "";
        self.order.phone = "";
        self.imageList = [];
        self.showImg = false;
        if (self.order.orderCategoryId == '6') {
            $('.publish_price').val('0');
            this.order.orderValue = '0';
        } else {
            self.order.orderValue = "";
        }
    }

    ////the final execute ...
    ngOnInit(): void {
        appService.IsLogin(this.router);
    }
}