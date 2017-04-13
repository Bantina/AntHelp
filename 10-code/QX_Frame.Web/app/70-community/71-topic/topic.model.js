"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
//export class UserAccountViewModel {
//    public loginId: string;
//    public email: string;
//    public pwd: string;
//}
class UserAccountViewModel {
    constructor(loginId, email, pwd, emailHtmlRoute) {
        this.loginId = loginId;
        this.email = email;
        this.pwd = pwd;
        this.emailHtmlRoute = emailHtmlRoute;
    }
}
exports.UserAccountViewModel = UserAccountViewModel;
//login
class LoginUserModel {
    constructor(loginId, pwd) {
        this.loginId = loginId;
        this.pwd = pwd;
    }
}
exports.LoginUserModel = LoginUserModel;
class UserAccountModel {
}
exports.UserAccountModel = UserAccountModel;
class UserAccountInfoModel {
}
exports.UserAccountInfoModel = UserAccountInfoModel;
//# sourceMappingURL=topic.model.js.map