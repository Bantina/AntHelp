﻿import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

/* common app component-> 00-* */
import { AppComponent } from './00-main/app.component';         //the root component
import { IndexComponent } from './01-index/index.component';    //the index component
/* start define components --there we add in ->-------------- 01 */
import { exampleComponent } from './02-example/example.component';



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



    /* end define components */
    {
        path: '**',  // otherwise route.
        component: IndexComponent
    },
];

const appComponents: any[] = [
    /* common app component-> 00-* */
    AppComponent,       //the root website
    IndexComponent,     //the index website
    /* start define components -- there we add in ->------------ 03 */
    exampleComponent



    /* end define components */
];





/**
 * !!! do not edit the flowing must existing items --qixiao
 */
export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);

@NgModule({
    imports: [BrowserModule, routing],
    declarations: appComponents,
    bootstrap: [AppComponent]
})

export class QX_Frame_AppModule { }

const platform = platformBrowserDynamic();
platform.bootstrapModule(QX_Frame_AppModule);