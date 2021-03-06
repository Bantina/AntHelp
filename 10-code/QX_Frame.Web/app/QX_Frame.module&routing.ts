﻿import { NgModule, ModuleWithProviders } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {  HttpModule } from '@angular/http';
import { Routes, RouterModule } from '@angular/router';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { FormsModule } from '@angular/forms';

/* common app component-> 00-* */
import { AppComponent } from './00-main/app.component';         //the root component
import { IndexComponent } from './01-index/index.component';    //the index component
/* start define components --there we add in ->-------------- 01 */
import { exampleComponent } from './02-example/example.component';
 /*bantina add start*/
import { SignUpComponent } from './03-login/signup.component'; 
import { LoginComponent } from './03-login/login/login.component';
import { SignupVerifyComponent } from './03-login/signupVerify/signupVerify.component';
import { PublishComponent } from './30-order/publish/publish.component';
import { PaymentComponent } from './30-order/payment/payment.component';
import { OrderDetailComponent } from './30-order/detail/detail.component';
import { ManagementComponent } from './20-management_center/management.component';
import { AdministratorComponent } from './20-management_center/administrator/administrator.component';
import { BlackLoginComponent } from './03-login/blackLogin/blackLogin.component';
import { MyorderDetailComponent } from './20-management_center/personal/myOrder/myorderDetail.component';
import { ComplaintComponent } from './20-management_center/personal/complaint/complaint.component';
import { ActivityComponent } from './60-activity/activity.component'; 
import { CategoryComponent } from './01-index/category/category.component';   
import { MassegeComponent } from './20-management_center/massege/massege.component'; 


 /*bantina add end*/

 /*zyq add start*/
import { Topic } from './70-community/71-topic/topic';
import { Detail } from './70-community/71-topic/detail/detail';
import { Friends } from './70-community/72-friends/friends';
import { FriendsInformation } from './70-community/72-friends/friendsInformation/friendsInformation';
 /*zyq add end*/

/* end define components */


const appRoutes: Routes = [
    {
        path: '',
        component: IndexComponent
    },
    {
        path: 'index',  // otherwise route.
        component: IndexComponent
    },
    /* start define components --there we add in ->----------- 02 */
    {
        path: 'example',
        component: exampleComponent
    },
     /*bantina add start*/
    {
        path: 'signup',
        component: SignUpComponent
    }, 
    {
        path: 'login',
        component: LoginComponent
    }, 
    {
        path: 'signupVerify',
        component: SignupVerifyComponent
    }, 
    {
        path: 'publish',
        component: PublishComponent
    },  
    {
        path: 'orderDetail',
        component: OrderDetailComponent
    }, 
    {
        path: 'managementCenter',
        component: ManagementComponent
    },
    {
        path: 'administrator',
        component: AdministratorComponent
    }, 
    {
        path: 'blackLogin',
        component: BlackLoginComponent
    }, 
     {
        path: 'myorderDetail',
        component: MyorderDetailComponent
    }, 
      {
        path: 'complaint',
        component: ComplaintComponent
     }, 
       {
         path: 'activity',
         component: ActivityComponent
      }, 
       {
          path: 'myMassege',
          component: MassegeComponent
       }, 
       {
           path: 'category',
           component: CategoryComponent
       }, 
       {
           path: 'payment',
           component: PaymentComponent
       }, 

     /*bantina add end*/


    /*zyq add start*/
    {
        path: 'topic',
        component: Topic
    },
    {
        path: 'detail',
        component: Detail
    },
    {
        path: 'friends',
        component: Friends
    },
    {
        path: 'friendsInformation',
        component: FriendsInformation
    },
    /*zyq add end*/

    /* end define components */
    {
        path: '**',  // otherwise route.
        component: IndexComponent
    }
];

const appComponents: any[] = [
    /* common app component-> 00-* */
    AppComponent,       //the root website
    IndexComponent,     //the index website
    /* start define components -- there we add in ->------------ 03 */
    exampleComponent,
    /*bantina add start*/
    SignUpComponent,
    LoginComponent,
    SignupVerifyComponent,
    PublishComponent,
    OrderDetailComponent,
    ManagementComponent,
    AdministratorComponent,
    BlackLoginComponent,
    MyorderDetailComponent,
    ComplaintComponent,
    ActivityComponent,
    MassegeComponent,
    CategoryComponent,
    PaymentComponent,
    /*bantina add end*/

    /*zyq add start*/
    Topic,
    Detail,
    Friends,
    FriendsInformation
    /*zyq add end*/

    /* end define components */
];





/**
 * !!! do not edit the flowing must existing items --qixiao
 */
export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);

@NgModule({
    imports: [BrowserModule, routing, HttpModule, FormsModule],
    declarations: appComponents,
    bootstrap: [AppComponent]
})

export class QX_Frame_AppModule { }

const platform = platformBrowserDynamic();
platform.bootstrapModule(QX_Frame_AppModule);