import { Component } from '@angular/core';
import { appService } from "../00-AQX_Frame.services/appService";

@Component({
    selector: 'my-app',
    templateUrl: 'app/00-main/app.component.html',
    styleUrls: ['app/00-main/app.component.css'],
})


export class AppComponent {
    title = 'Ant Help'
    loginResult = appService.IsLogin();
}