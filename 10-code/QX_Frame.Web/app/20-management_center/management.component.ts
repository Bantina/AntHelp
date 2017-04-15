import { Component, OnInit } from '@angular/core';
import { appBase } from '../00-AQX_Frame.commons/appBase';
import { ManagementModel } from './management.model';

@Component({
    selector: 'managementCenter',
    templateUrl: 'app/20-management_center/management.component.html',
    styleUrls: ['app/20-management_center/management.component.css'],
    providers: []
})

export class ManagementComponent implements OnInit {
    navStatus: number = appBase.AppObject.centerStatus;

    //左菜单点击事件；
    sidenavClick(event,num): void { //a
        this.navStatus = num;
        var $targetP = $(event.target || event.srcElement).parent();
        $targetP.siblings().removeClass("on");
        $targetP.addClass("on");
        this.sidenavFun();
    }
    sidenavSpanClick(event, num): void { //span
        this.navStatus = num;
        var $targetP = $(event.target || event.srcElement).parent().parent();
        $targetP.siblings().removeClass("on");
        $targetP.addClass("on");
        this.sidenavFun();
    }
    sidenavFun(): void { //切换 实质
        //////
    }
  
    //the final execute ...
    ngOnInit(): void {
        //左菜单 焦点 判断 显示；
        $(".manageCenterUl li").eq(appBase.AppObject.centerStatus).addClass("on");
    }
}