import { Component, OnInit } from '@angular/core';
import { ArticleList, Article } from './topic.model';
import { appBase } from '../../00-AQX_Frame.commons/appBase';
import { appService } from '../../00-AQX_Frame.services/appService';

//注入器的两种：NgModule/Component(只在当前及子组件中生效)
@Component({
    selector: 'topic',
    templateUrl: 'app/70-community/71-topic/topic.html',
    styleUrls: ['app/70-community/71-topic/topic.css'],
    providers: []   //元数据中申明依赖
})

export class Topic implements OnInit {

    article: Article = {
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

    articleList: Article[] = [];

    // 点击回到顶部按钮
    toTop(): void {
        $('html, body').animate({ scrollTop: 0 }, 1000); //回到顶端
    }

    GetTopic(): void {
        var  self = this;
        $.ajax({
            url: appBase.DomainApi + "api/Article",
            type: "get",
            dataType: "json",
            contentType: "application/json; charset=UTF-8",
            data:
            {
                "appKey": appService.getCookie("appKey"),
                "token": appService.getCookie("token"),
                "articleTitle": "",
                "pageIndex": 1,
                "pageSize": 10,
                "isDesc": true
            },
            success(data) {
                if (data.isSuccess) {
                    var dataList = data.data;
                    self.articleList = [];
                    for (var i = 0; i < dataList.length; i++) {
                      var articleObject = new Article();
                       articleObject.articleUid = dataList[i].articleUid;
                       articleObject.articleTitle = dataList[i].articleTitle;
                       articleObject.articleContent = dataList[i].articleContent;
                       articleObject.loginId = dataList[i].loginId;
                       articleObject.nickName = dataList[i].publisherInfo.nickName;
                       articleObject.publishTime = dataList[i].publishTime;
                       articleObject.clickCount = dataList[i].clickCount;
                       articleObject.praiseCount = dataList[i].praiseCount;
                       articleObject.ArticleCategoryId = dataList[i].ArticleCategoryId;
                       articleObject.articleCategoryName = dataList[i].articleCategory.CategoryName;
                       articleObject.imagesNameList = dataList[i].imagesNameList;
                       self.articleList.push(articleObject);
                    }
                } else {
                    alert(data.msg);
                }
            },
            error(data) {
                alert("服务器错误！");
            }
        });
    }

    ////the final execute ...
    ngOnInit(): void {

        this.GetTopic();

        var App = {
            int: function () {
                // 向上箭头淡入淡出功能
                $(window).scroll(App.scrollFromTop);
            },
            scrollFromTop: function () {
                var scrollTop = $(this).scrollTop();
                var scrollHeight = $(document).height();
                var windowHeight = $(this).height();
                if (scrollTop + windowHeight > scrollHeight) {  //滚动到底部执行事件
                    $('#back-to-top').fadeIn("1000");
                }
                if (scrollTop == 0) {  //滚动到头部部执行事件
                    $('#back-to-top').fadeOut("1000");
                }
            },
        }
        App.int();
    }
}