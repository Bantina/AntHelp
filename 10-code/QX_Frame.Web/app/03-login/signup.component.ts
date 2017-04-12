import { Component, OnInit } from '@angular/core';
import { UserAccountViewModel } from './signup.model';
import { Md5 } from "../00-AQX_Frame.services/Md5.service";
import { appService } from '../00-AQX_Frame.services/appService';
import { appBase } from '../00-AQX_Frame.commons/appBase';

declare function escape(s: string): string;
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
        email: "",
        emailHtmlRoute:"signupVerify"
    };

    repassword: string = "";
    isEmail: any = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    msg: string = "";
    sucMsg: string = "";

    constructor() { }

    addAccount(): void {
        
        var self = this;
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

        self.msg = "";
        self.sucMsg = "";
        if (self.userAccountViewModel.loginId == "") {
            self.msg = "用户名不能为空！";
        }
        else if (self.userAccountViewModel.loginId.length<3) {
            self.msg = "用户名不能小于3位！";
        }
        else if (self.userAccountViewModel.email == "") {
            self.msg = "邮箱不能为空！";
        }
        else if (!self.isEmail.test(self.userAccountViewModel.email)) {
            self.msg = "邮箱格式输入有误！";
        }
        else if (self.userAccountViewModel.pwd == "") {
            self.msg = "密码不能为空！";
        }
        else if (self.repassword == "") {
            self.msg = "确认密码不能为空！";
        }
        else if (self.userAccountViewModel.pwd !== self.repassword) {
            self.msg = "密码和确认密码不一致！";
        }
        else {
            self.msg = "";
            $.ajax({
                url: appBase.DomainApi + "api/Account",
                type: "post",
                dataType: "json",
                contentType: "application/json; charset=UTF-8",
                data: JSON.stringify(
                    {
                        loginId: self.userAccountViewModel.loginId,
                        pwd: Md5.hashStr(self.userAccountViewModel.pwd).toString(),
                        email: self.userAccountViewModel.email,
                        emailHtmlRoute: self.userAccountViewModel.emailHtmlRoute
                    }),
                success(data) {
                    if (data.isSuccess) {
                        self.sucMsg = "注册邮件已发送到您的邮箱，请查收并点击邮箱中的连接完成注册！";
                    }
                    else if (data.errorCode == 3002) {
                        self.msg = "该用户已注册过，请直接登录~";
                    }
                    else {
                        self.msg = "服务器请求出错，请稍后重试~";
                    }
                },
                error(data) {
                    alert(JSON.stringify(data));
                }
            });
        }

    }

    ////the final execute ...
    ngOnInit(): void {

    }
}