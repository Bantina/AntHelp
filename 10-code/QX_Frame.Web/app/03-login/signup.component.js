"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
const core_1 = require("@angular/core");
const appBase_1 = require("../00-AQX_Frame.commons/appBase");
//注入器的两种：NgModule/Component(只在当前及子组件中生效)
let SignUpComponent = class SignUpComponent {
    constructor() {
        this.userAccountViewModel = {
            loginId: "",
            pwd: "",
            email: ""
        };
        this.msg = "this is a message";
    }
    addAccount() {
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
            url: appBase_1.appBase.DomainApi + "api/Account",
            type: "post",
            dataType: "json",
            contentType: "application/json; charset=UTF-8",
            data: JSON.stringify({
                loginId: this.userAccountViewModel.loginId,
                pwd: this.userAccountViewModel.pwd,
                email: this.userAccountViewModel.email
            }),
            success(data) {
                this.msg = data.msg;
                if (data.isSuccess) {
                    console.log(JSON.stringify(data));
                }
                else {
                    console.log(JSON.stringify(data));
                }
            },
            error(data) {
                alert(JSON.stringify(data));
            }
        });
    }
    ////the final execute ...
    ngOnInit() {
    }
};
SignUpComponent = __decorate([
    core_1.Component({
        selector: 'signup',
        templateUrl: 'app/03-login/signup.component.html',
        styleUrls: ['app/03-login/signup.component.css'],
        providers: [] //元数据中申明依赖
    }),
    __metadata("design:paramtypes", [])
], SignUpComponent);
exports.SignUpComponent = SignUpComponent;
//# sourceMappingURL=signup.component.js.map