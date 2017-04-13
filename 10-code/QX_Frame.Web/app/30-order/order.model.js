"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
//发布分类；
class KindModel {
    constructor(loginId, email, pwd, emailHtmlRoute) {
        this.loginId = loginId;
        this.email = email;
        this.pwd = pwd;
        this.emailHtmlRoute = emailHtmlRoute;
    }
}
exports.KindModel = KindModel;
class PublishAidModel {
    constructor(loginId, kinds, imges, description, price, address, phone) {
        this.loginId = loginId;
        this.kinds = kinds;
        this.imges = imges;
        this.description = description;
        this.price = price;
        this.address = address;
        this.phone = phone;
    }
}
exports.PublishAidModel = PublishAidModel;
//# sourceMappingURL=order.model.js.map