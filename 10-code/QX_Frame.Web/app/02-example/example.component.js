"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
const core_1 = require('@angular/core');
const example_service_1 = require('./example.service');
const appBase_base_1 = require('../00-AQX_Frame.commons/appBase.base');
let exampleComponent = class exampleComponent {
    constructor(linkService) {
        this.linkService = linkService;
        this.domain = { domainApi: "" };
        this._usefullLinkService = linkService;
        this.domain.domainApi = appBase_base_1.appBase.DomainApi;
        //this.http.post("", {});
    }
    get LinkList() { return this._linkList; }
    ngOnInit() {
        this._linkList = this._usefullLinkService.GetLinks();
    }
};
exampleComponent = __decorate([
    core_1.Component({
        selector: 'example',
        templateUrl: 'app/02-example/example.component.html',
        styleUrls: ['app/02-example/example.component.css'],
        providers: [example_service_1.UsefullLinkService]
    }), 
    __metadata('design:paramtypes', [example_service_1.UsefullLinkService])
], exampleComponent);
exports.exampleComponent = exampleComponent;
//# sourceMappingURL=example.component.js.map