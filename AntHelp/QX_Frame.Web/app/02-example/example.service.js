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
let UsefullLinkService = class UsefullLinkService {
    GetLinks() {
        return [
            { name: 'Angular2 cookbook', href: 'https://angular.io/docs/ts/latest/cookbook/' },
            { name: 'Angular2 style guide', href: 'https://github.com/johnpapa/angular-styleguide/blob/master/a2/README.md' },
            { name: 'Angular2 installation guide', href: 'https://github.com/Drag13/Angular2WebTemplate1' },
        ];
    }
};
UsefullLinkService = __decorate([
    core_1.Injectable(), 
    __metadata('design:paramtypes', [])
], UsefullLinkService);
exports.UsefullLinkService = UsefullLinkService;
//# sourceMappingURL=example.service.js.map