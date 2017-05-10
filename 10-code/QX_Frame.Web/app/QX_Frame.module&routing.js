"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
const core_1 = require("@angular/core");
const platform_browser_1 = require("@angular/platform-browser");
const http_1 = require("@angular/http");
const router_1 = require("@angular/router");
const platform_browser_dynamic_1 = require("@angular/platform-browser-dynamic");
const forms_1 = require("@angular/forms");
/* common app component-> 00-* */
const app_component_1 = require("./00-main/app.component"); //the root component
const index_component_1 = require("./01-index/index.component"); //the index component
/* start define components --there we add in ->-------------- 01 */
const example_component_1 = require("./02-example/example.component");
/*bantina add start*/
const signup_component_1 = require("./03-login/signup.component");
const login_component_1 = require("./03-login/login/login.component");
const signupVerify_component_1 = require("./03-login/signupVerify/signupVerify.component");
const publish_component_1 = require("./30-order/publish/publish.component");
const detail_component_1 = require("./30-order/detail/detail.component");
const management_component_1 = require("./20-management_center/management.component");
const administrator_component_1 = require("./20-management_center/administrator/administrator.component");
const blackLogin_component_1 = require("./03-login/blackLogin/blackLogin.component");
const myorderDetail_component_1 = require("./20-management_center/personal/myOrder/myorderDetail.component");
const complaint_component_1 = require("./20-management_center/personal/complaint/complaint.component");
const activity_component_1 = require("./60-activity/activity.component");
const category_component_1 = require("./01-index/category/category.component");
const massege_component_1 = require("./20-management_center/massege/massege.component");
/*bantina add end*/
/*zyq add start*/
const topic_1 = require("./70-community/71-topic/topic");
const detail_1 = require("./70-community/71-topic/detail/detail");
const friends_1 = require("./70-community/72-friends/friends");
const friendsInformation_1 = require("./70-community/72-friends/friendsInformation/friendsInformation");
/*zyq add end*/
/* end define components */
const appRoutes = [
    {
        path: '',
        component: index_component_1.IndexComponent
    },
    {
        path: 'index',
        component: index_component_1.IndexComponent
    },
    /* start define components --there we add in ->----------- 02 */
    {
        path: 'example',
        component: example_component_1.exampleComponent
    },
    /*bantina add start*/
    {
        path: 'signup',
        component: signup_component_1.SignUpComponent
    },
    {
        path: 'login',
        component: login_component_1.LoginComponent
    },
    {
        path: 'signupVerify',
        component: signupVerify_component_1.SignupVerifyComponent
    },
    {
        path: 'publish',
        component: publish_component_1.PublishComponent
    },
    {
        path: 'orderDetail',
        component: detail_component_1.OrderDetailComponent
    },
    {
        path: 'managementCenter',
        component: management_component_1.ManagementComponent
    },
    {
        path: 'administrator',
        component: administrator_component_1.AdministratorComponent
    },
    {
        path: 'blackLogin',
        component: blackLogin_component_1.BlackLoginComponent
    },
    {
        path: 'myorderDetail',
        component: myorderDetail_component_1.MyorderDetailComponent
    },
    {
        path: 'complaint',
        component: complaint_component_1.ComplaintComponent
    },
    {
        path: 'activity',
        component: activity_component_1.ActivityComponent
    },
    {
        path: 'myMassege',
        component: massege_component_1.MassegeComponent
    },
    {
        path: 'category',
        component: category_component_1.CategoryComponent
    },
    /*bantina add end*/
    /*zyq add start*/
    {
        path: 'topic',
        component: topic_1.Topic
    },
    {
        path: 'detail',
        component: detail_1.Detail
    },
    {
        path: 'friends',
        component: friends_1.Friends
    },
    {
        path: 'friendsInformation',
        component: friendsInformation_1.FriendsInformation
    },
    /*zyq add end*/
    /* end define components */
    {
        path: '**',
        component: index_component_1.IndexComponent
    }
];
const appComponents = [
    /* common app component-> 00-* */
    app_component_1.AppComponent,
    index_component_1.IndexComponent,
    /* start define components -- there we add in ->------------ 03 */
    example_component_1.exampleComponent,
    /*bantina add start*/
    signup_component_1.SignUpComponent,
    login_component_1.LoginComponent,
    signupVerify_component_1.SignupVerifyComponent,
    publish_component_1.PublishComponent,
    detail_component_1.OrderDetailComponent,
    management_component_1.ManagementComponent,
    administrator_component_1.AdministratorComponent,
    blackLogin_component_1.BlackLoginComponent,
    myorderDetail_component_1.MyorderDetailComponent,
    complaint_component_1.ComplaintComponent,
    activity_component_1.ActivityComponent,
    massege_component_1.MassegeComponent,
    category_component_1.CategoryComponent,
    /*bantina add end*/
    /*zyq add start*/
    topic_1.Topic,
    detail_1.Detail,
    friends_1.Friends,
    friendsInformation_1.FriendsInformation
    /*zyq add end*/
    /* end define components */
];
/**
 * !!! do not edit the flowing must existing items --qixiao
 */
exports.routing = router_1.RouterModule.forRoot(appRoutes);
let QX_Frame_AppModule = class QX_Frame_AppModule {
};
QX_Frame_AppModule = __decorate([
    core_1.NgModule({
        imports: [platform_browser_1.BrowserModule, exports.routing, http_1.HttpModule, forms_1.FormsModule],
        declarations: appComponents,
        bootstrap: [app_component_1.AppComponent]
    })
], QX_Frame_AppModule);
exports.QX_Frame_AppModule = QX_Frame_AppModule;
const platform = platform_browser_dynamic_1.platformBrowserDynamic();
platform.bootstrapModule(QX_Frame_AppModule);
//# sourceMappingURL=QX_Frame.module&routing.js.map