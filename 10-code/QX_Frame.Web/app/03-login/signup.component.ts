import { Component, OnInit } from '@angular/core';
import { UserAccountViewModel } from './signup.model';
import { Md5 } from "ts-md5/dist/md5";
import { appBase } from '../00-AQX_Frame.commons/appBase';

//注入器的两种：NgModule/Component(只在当前及子组件中生效)
@Component({
    selector: 'signup',
    templateUrl: 'app/03-login/signup.component.html',
    styleUrls: ['app/03-login/signup.component.css'],
    providers: []   //元数据中申明依赖
})

export class SignUpComponent implements OnInit {

    userAccountViewModel: UserAccountViewModel = {
        loginId: "",
        pwd: "",
        email: ""
    };

    msg: string = "this is a message";

    constructor() { }

    addAccount(): void {


        var self = this;

        //Md5.hashStr('123456').toString();
        
        //self.requestResult = self.signupService.AddAccount(self.userAccountViewModel)
        //    .then(function (response) {
        //        var data = response.json();
        //        console.log(data);
        //        if (data.isSuccess) {
        //            self.msg = data.msg;
        //        }
        //        else {
        //            self.msg = data.msg;
        //        }
        //        self.msg = data.msg;
        //    })

        $.ajax({
            url: appBase.DomainApi + "api/Account",
            type: "post",
            dataType: "json",
            contentType: "application/json; charset=UTF-8",
            data: JSON.stringify(
                {
                    loginId: this.userAccountViewModel.loginId,
                    pwd: this.userAccountViewModel.pwd,
                    email: this.userAccountViewModel.email
                }),
            success(data)
            {
                this.msg = data.msg;
                if (data.isSuccess) {
                    console.log(JSON.stringify(data));
                }
                else
                {
                    console.log(JSON.stringify(data));
                }
            },
            error(data)
            {
                alert(JSON.stringify(data));
            }
        });

    }

    ////the final execute ...
    ngOnInit(): void {

    }
}