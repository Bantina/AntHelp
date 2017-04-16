import { Component, OnInit } from '@angular/core';
import { appBase } from '../../00-AQX_Frame.commons/appBase';
import { PublishAidModel } from './../order.model';

@Component({
    selector: 'orderDetail',
    templateUrl: 'app/30-order/detail/detail.component.html',
    styleUrls: ['app/30-order/detail/detail.component.css'],
    providers: []
})

export class OrderDetailComponent implements OnInit {
  
    ////the final execute ...
    ngOnInit(): void {
        var defaults = {
            thumbSize: 20,
            slideSpeed: 1500,
            auto: true,
            loop: true
        };
        $('.orderDetail_slider').tilesSlider($.extend({}, defaults, { x: 20, y: 1, effect: 'updown', cssSpeed: 500, backReverse: true }));
    }
}