import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'index',
    templateUrl: 'app/01-index/index.component.html',
    styleUrls: ['app/01-index/index.component.css'],
})


export class IndexComponent implements OnInit {


    ////the final execute ...
    ngOnInit(): void {
        var defaults = {
            thumbSize: 20,
            slideSpeed: 1500,
            auto: true,
            loop: true
        };
        $('.index_slider').tilesSlider($.extend({}, defaults, { x: 20, y: 3, effect: 'flipud', reverse: true, rewind: 75 }));
    }
}