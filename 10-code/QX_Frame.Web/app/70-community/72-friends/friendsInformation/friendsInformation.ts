import { Component, OnInit } from '@angular/core';

declare function escape(s: string): string;
//注入器的两种：NgModule/Component(只在当前及子组件中生效)
@Component({
    selector: 'friendsInformation',
    templateUrl: 'app/70-community/72-friends/friendsInformation/friendsInformation.html',
    styleUrls: ['app/70-community/72-friends/friendsInformation/friendsInformation.css'],
    providers: []   //元数据中申明依赖
})

export class FriendsInformation implements OnInit {
   

    ////the final execute ...
    ngOnInit(): void {

    }
}