import { Component, OnInit } from '@angular/core';
import { appBase } from '../../../00-AQX_Frame.commons/appBase';
import { appService } from '../../../00-AQX_Frame.services/appService';
import { ComplainModel } from '../../../00-models/complain.model';
import { Router, ActivatedRoute, Params } from '@angular/router';

@Component({
    selector: 'complaint',
    templateUrl: 'app/20-management_center/personal/complaint/complaint.component.html',
    styleUrls: ['app/20-management_center/personal/complaint/complaint.component.css'],
    providers: []
})

export class ComplaintComponent implements OnInit {
    router: Router;
    constructor(_router: Router) {
        this.router = _router;
    }

    //------- complain ------------------
    //投诉信息
    complainModel: ComplainModel =
    {
        complainUid: "",
        complainContent: "",
        complainUserUid: "",
        complainTime: "",
        complainStatusId: 0,
        complainStatusName: ""
    }

    SendComplain(): void {
        var self = this;
        $.ajax({
            url: appBase.DomainApi + "api/Complain",
            type: "post",
            dataType: "json",
            contentType: "application/json; charset=UTF-8",
            data: JSON.stringify({
                "appKey": appService.getCookie("appKey"),
                "token": appService.getCookie("token"),
                "complainContent": self.complainModel.complainContent
            }),
            success(data) {
                if (data.isSuccess) {
                    alert("谢谢您的建议，请耐心等待我们的回复~");
                    self.complainModel.complainContent = "";
                } else {
                    console.error(data.msg);
                }
            },
            error(data) {
                alert("服务器连接失败，请稍后重试...");
            }
        });
    }
    //------complain end -----------------



    //the final execute ...
    ngOnInit(): void {

        appService.IsLogin(this.router);
    }
}