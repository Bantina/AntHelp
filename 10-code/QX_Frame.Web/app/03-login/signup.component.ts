import { Component, OnInit } from '@angular/core';
import { UserAccountViewModel } from './signup.model'
import { SignupService } from './signup.service';


@Component({
    selector: 'signup',
    templateUrl: 'app/03-login/signup.component.html',
    styleUrls: ['app/03-login/signup.component.css'],
    providers: [SignupService]
})

export class SignUpComponent implements OnInit {

    requestResult: Promise<any>;    //request requestResult
    msg: any = "status";
    description: string; //decription message

    userAccountViewModel: UserAccountViewModel = {
        loginId: "",
        pwd: "",
        email: ""
    };

    constructor(private signupService: SignupService) { }

    addAccount(): void {
        var self = this;
        self.requestResult = self.signupService.AddAccount(self.userAccountViewModel)
            .then(function (response) {
                var data = response.json();
                console.log(data);
                if (data.isSuccess) {
                    self.msg = data.msg;
                }
                else {
                    self.msg = data.msg;
                }
                self.description = data.msg;
            })

    }

    ////the final execute ...
    ngOnInit(): void {

    }
}