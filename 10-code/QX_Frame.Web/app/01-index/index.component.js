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
let IndexComponent = class IndexComponent {
    ////the final execute ...
    ngOnInit() {
        var defaults = {
            thumbSize: 20,
            slideSpeed: 1500,
            auto: true,
            loop: true
        };
        $('.index_slider').tilesSlider($.extend({}, defaults, { x: 20, y: 3, effect: 'flipud', reverse: true, rewind: 75 }));
    }
};
IndexComponent = __decorate([
    core_1.Component({
        selector: 'index',
        templateUrl: 'app/01-index/index.component.html',
        styleUrls: ['app/01-index/index.component.css'],
    }), 
    __metadata('design:paramtypes', [])
], IndexComponent);
exports.IndexComponent = IndexComponent;
//# sourceMappingURL=index.component.js.map