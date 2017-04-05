import { Component } from '@angular/core';
import { OnInit } from '@angular/core';

import { LinkModel } from './example.model';
import { DomainModel } from './example.model';
import { UsefullLinkService } from './example.service';
import { appBase } from '../00-AQX_Frame.commons/appBase.base';
import { Http } from '@angular/http';

@Component({
    selector: 'example',
    templateUrl: 'app/02-example/example.component.html',
    styleUrls: ['app/02-example/example.component.css'],
    providers: [UsefullLinkService]
})

export class exampleComponent implements OnInit {

    private _usefullLinkService: UsefullLinkService;
    private http: Http;

    private _linkList: LinkModel[];
    get LinkList() { return this._linkList; }

    public domain: DomainModel = { domainApi:"" };

    constructor(private linkService: UsefullLinkService) {
        this._usefullLinkService = linkService;
        this.domain.domainApi = appBase.DomainApi;
        //this.http.post("", {});
    }

    public ngOnInit(): void {
        this._linkList = this._usefullLinkService.GetLinks();
    }
}