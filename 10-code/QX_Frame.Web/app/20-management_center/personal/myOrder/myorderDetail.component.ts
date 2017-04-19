import { Component, OnInit } from '@angular/core';
import { appBase } from '../../../00-AQX_Frame.commons/appBase';
import { appService } from '../../../00-AQX_Frame.services/appService';
import { UserInfoModel } from '../.././management.model';

@Component({
    selector: 'managementCenter',
    templateUrl: 'app/20-management_center/personal/myOrder/myorderDetail.component.html',
    styleUrls: ['app/20-management_center/personal/myOrder/myorderDetail.component.css'],
    providers: []
})

export class MyorderDetailComponent implements OnInit {
    //模型绑定;
    userInfoModel: UserInfoModel = {
        loginId: appService.getCookie('loginId'),
        nickName: '',
        headImageUrl: "../../Images/20-management/user_default_img.png",
        email: "4527875@foxmail.com",
        phone: "18254688788",
        position: "天津市西青区",
        appKey: Number(appService.getCookie('appKey')),
        token: appService.getCookie('token'),
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
        personalizedDescription: ''
    }

   
    //the final execute ...
    ngOnInit(): void {
       

    }
}