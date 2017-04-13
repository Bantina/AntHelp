"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
const core_1 = require("@angular/core");
//注入器的两种：NgModule/Component(只在当前及子组件中生效)
let Topic = class Topic {
    // 点击回到顶部按钮
    toTop() {
        $('html, body').animate({ scrollTop: 0 }, 1000); //回到顶端
    }
    ////the final execute ...
    ngOnInit() {
        var App = {
            int: function () {
                // 向上箭头淡入淡出功能
                $(window).scroll(App.scrollFromTop);
            },
            scrollFromTop: function () {
                var scrollTop = $(this).scrollTop();
                var scrollHeight = $(document).height();
                var windowHeight = $(this).height();
                if (scrollTop + windowHeight > scrollHeight) {
                    $('#back-to-top').fadeIn("1000");
                }
                if (scrollTop == 0) {
                    $('#back-to-top').fadeOut("1000");
                }
            },
        };
        App.int();
    }
};
Topic = __decorate([
    core_1.Component({
        selector: 'topic',
        templateUrl: 'app/70-community/71-topic/topic.html',
        styleUrls: ['app/70-community/71-topic/topic.css'],
        providers: [] //元数据中申明依赖
    })
], Topic);
exports.Topic = Topic;
//# sourceMappingURL=topic.js.map