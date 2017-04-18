import { Component, OnInit } from '@angular/core';
import { appBase } from '../../00-AQX_Frame.commons/appBase';
import { appService } from '../../00-AQX_Frame.services/appService';

@Component({
    selector: 'blackLogin',
    templateUrl: 'app/03-login/blackLogin/blackLogin.component.html',
    styleUrls: ['app/03-login/blackLogin/blackLogin.component.css'],
    providers: []   //元数据中申明依赖
})

export class BlackLoginComponent implements OnInit {



    ////the final execute ...
    ngOnInit(): void {

    }
}