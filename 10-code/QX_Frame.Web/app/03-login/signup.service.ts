import { Injectable} from '@angular/core';
import { Http } from '@angular/http';
import { appBase } from '../00-AQX_Frame.commons/appBase.base';
import { UserAccountViewModel } from './signup.model';
import 'rxjs/add/operator/toPromise';


@Injectable()
export class SignupService {

    constructor(private http: Http) { }

    AddAccount(userAccountViewModel: UserAccountViewModel): Promise<any> {
        return this.http.post(appBase.DomainApi + 'api/Account', JSON.stringify(userAccountViewModel))
            .toPromise()
            ////.then(response => response.json())
            //.then(function (response) {
            //    console.log(response.json());
            //    var data = response.json();
            //    if (data.isSuccess) {
            //        this.msg = data.description;
            //    }
            //    else {
            //        this.msg = data.errorMessage;
            //    }
            //})
            .catch(this.handleError);
    }

    private handleError(error:any):Promise<any> {
        console.error('An error occurred', error); // for demo purposes only
        return Promise.reject(error.message || error);
    }
}