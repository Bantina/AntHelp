"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
const core_1 = require("@angular/core");
let OrderDetailComponent = class OrderDetailComponent {
    ////the final execute ...
    ngOnInit() {
        //var defaults = {
        //    thumbSize: 20,
        //    slideSpeed: 1500,
        //    auto: true,
        //    loop: true
        //};
        //$('.orderDetail_slider').tilesSlider($.extend({}, defaults, { x: 20, y: 1, effect: 'updown', cssSpeed: 500, backReverse: true }));
    }
};
OrderDetailComponent = __decorate([
    core_1.Component({
        selector: 'orderDetail',
        templateUrl: 'app/30-order/detail/detail.component.html',
        styleUrls: ['app/30-order/detail/detail.component.css'],
        providers: []
    })
], OrderDetailComponent);
exports.OrderDetailComponent = OrderDetailComponent;
//# sourceMappingURL=detail.component.js.map