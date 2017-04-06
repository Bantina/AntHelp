"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const appBase_base_1 = require("../00-AQX_Frame.commons/appBase.base");
const signup_model_1 = require("./signup.model");
require("rxjs/add/operator/toPromise");
class SignupService {
    constructor(http) {
        this.http = http;
    }
    getAccount() {
        return this.http.post(appBase_base_1.appBase.DomainApi + 'api/Account', signup_model_1.UserAccountViewModel)
            .toPromise()
            .then(response => response.json())
            .catch(this.handleError);
    }
    handleError(error) {
        console.error('An error occurred', error); // for demo purposes only
        return Promise.reject(error.message || error);
    }
}
exports.SignupService = SignupService;
//# sourceMappingURL=signup.service.js.map