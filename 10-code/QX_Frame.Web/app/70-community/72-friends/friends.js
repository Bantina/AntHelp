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
//注入器的两种：NgModule/Component(只在当前及子组件中生效)
let Friends = class Friends {
    ////the final execute ...
    ngOnInit() {
        var size_li = $("#myList li").length;
        var x = 1;
        $('#myList li:lt(' + x + ')').show();
        $('#loadMore').click(function () {
            x = (x + 1 <= size_li) ? x + 1 : size_li;
            $('#myList li:lt(' + x + ')').show();
        });
        $('#showLess').click(function () {
            x = (x - 1 < 0) ? 1 : x - 1;
            $('#myList li').not(':lt(' + x + ')').hide();
        });
    }
};
Friends = __decorate([
    core_1.Component({
        selector: 'friends',
        templateUrl: 'app/70-community/72-friends/friends.html',
        styleUrls: ['app/70-community/72-friends/friends.css'],
        providers: [] //元数据中申明依赖
    }), 
    __metadata('design:paramtypes', [])
], Friends);
exports.Friends = Friends;
//# sourceMappingURL=friends.js.map