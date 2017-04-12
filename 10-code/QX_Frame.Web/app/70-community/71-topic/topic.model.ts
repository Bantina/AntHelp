//export class UserAccountViewModel {
//    public loginId: string;
//    public email: string;
//    public pwd: string;
//}
export class UserAccountViewModel {
    constructor(
        public loginId: string,
        public email: string,
        public pwd: string,
        public emailHtmlRoute: string
    ) { }
}

//login
export class LoginUserModel {
    constructor(
        public loginId: string,
        public pwd: string
    ) { }
}

export class UserAccountModel {
    public loginId: string;
    public pwd: string;
}
export class UserAccountInfoModel {
    public loginId: string;
    public email: string;
    ///...
}

