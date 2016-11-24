import { Injectable } from '@angular/core';

import { LinkModel } from './example.model';

@Injectable()
export class UsefullLinkService {
    public GetLinks(): LinkModel[] {
        return [
            { name: 'Angular2 cookbook', href: 'https://angular.io/docs/ts/latest/cookbook/' },
            { name: 'Angular2 style guide', href: 'https://github.com/johnpapa/angular-styleguide/blob/master/a2/README.md' },
            { name: 'Angular2 installation guide', href: 'https://github.com/Drag13/Angular2WebTemplate1' },
        ];
    }
}