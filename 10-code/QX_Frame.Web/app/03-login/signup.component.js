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
const signup_service_1 = require("./signup.service");
let SignUpComponent = class SignUpComponent {
    constructor(signupService) {
        this.signupService = signupService;
    }
    getAccount() {
        this.signupService.getAccount().then(t => this.requestResult = t);
        if (this.requestResult.isSuccess) {
            this.msg = "注册成功！";
        }
        else {
            this.msg = "注册失败";
        }
        this.description = this.requestResult.description;
    }
    //the final execute ...
    ngOnInit() {
    }
};
SignUpComponent = __decorate([
    core_1.Component({
        selector: 'signup',
        templateUrl: 'app/03-login/signup.component.html',
        styleUrls: ['app/03-login/signup.component.css'],
        providers: []
    }),
    __metadata("design:paramtypes", [signup_service_1.SignupService])
], SignUpComponent);
exports.SignUpComponent = SignUpComponent;
//# sourceMappingURL=signup.component.js.map