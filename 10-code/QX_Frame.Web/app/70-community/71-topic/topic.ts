import { Component, OnInit } from '@angular/core';

declare function escape(s: string): string;
//注入器的两种：NgModule/Component(只在当前及子组件中生效)
@Component({
    selector: 'topic',
    templateUrl: 'app/70-community/71-topic/topic.html',
    styleUrls: ['app/70-community/71-topic/topic.css'],
    providers: []   //元数据中申明依赖
})

export class Topic implements OnInit {
    // 点击回到顶部按钮
    toTop(): void {
        $('html, body').animate({ scrollTop: 0 }, 1000); //回到顶端
    }

    ////the final execute ...
    ngOnInit(): void {
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