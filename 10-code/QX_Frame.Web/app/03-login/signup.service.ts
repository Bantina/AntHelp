import { Http } from '@angular/http';
import { appBase } from '../00-AQX_Frame.commons/appBase.base';
import { UserAccountViewModel } from './signup.model';
import 'rxjs/add/operator/toPromise';

export class SignupService {
    constructor(private http: Http) { }
    getAccount(): Promise<any> {
        return this.http.post(appBase.DomainApi + 'api/Account', UserAccountViewModel)
            .toPromise()
            .then(response => response.json())
            .catch(this.handleError);
    }

    private handleError(error:any):Promise<any> {
        console.error('An error occurred', error); // for demo purposes only
        return Promise.reject(error.message || error);
    }
}