import { Component } from '@angular/core';
import { OnInit } from '@angular/core';
import { SignupService } from './signup.service';

@Component({
    selector: 'signup',
    templateUrl: 'app/03-login/signup.component.html',
    styleUrls: ['app/03-login/signup.component.css'],
    providers: []
})

export class SignUpComponent implements OnInit {

    private requestResult: any;    //request requestResult
    private msg: string;
    private description: string; //decription message

    constructor(private signupService: SignupService) { }

    getAccount(): void {
        this.signupService.getAccount().then(t => this.requestResult = t);
        if (this.requestResult.isSuccess) {
            this.msg = "注册成功！";
        }
        else
        {
            this.msg = "注册失败";
        }
        this.description = this.requestResult.description;
    }

    //the final execute ...
    ngOnInit(): void {

    }
}