import { Component } from '@angular/core';
import { appService } from "../00-AQX_Frame.services/appService";
import { appBase } from "../00-AQX_Frame.commons/appBase";
import { Router, ActivatedRoute, Params } from '@angular/router';

@Component({
    selector: 'my-app',
    templateUrl: 'app/00-main/app.component.html',
    styleUrls: ['app/00-main/app.component.css']
})


export class AppComponent {
    title = 'Ant Help'
    router: Router;
    constructor(_router: Router) {
        this.router = _router;
    }

    loginResult: any = {};



    //个人中心菜单点击 切换
    setCenterStatus(num): void{
        appBase.AppObject.centerStatus = num;
        //window.location.href = appBase.WebUrlDomain + "managementCenter";
        var manageCenterUl = $(".manageCenterUl li");
        manageCenterUl.removeClass("on");
        manageCenterUl.eq(appBase.AppObject.centerStatus).addClass("on");

        //内容切换；
        //manageCenterUl.eq(appBase.AppObject.centerStatus).click(event, appBase.AppObject.centerStatus);
        //manageCenterUl.eq(num).trigger('click', {event,num});


    }

    ngOnInit(): void {
        this.loginResult = appService.IsLogin(this.router); 

    }
}