import { Component, OnInit } from '@angular/core';

declare function escape(s: string): string;
//注入器的两种：NgModule/Component(只在当前及子组件中生效)
@Component({
    selector: 'friends',
    templateUrl: 'app/70-community/72-friends/friends.html',
    styleUrls: ['app/70-community/72-friends/friends.css'],
    providers: []   //元数据中申明依赖
})

export class Friends implements OnInit {
   

    ////the final execute ...
    ngOnInit(): void {
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
}