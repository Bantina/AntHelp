"use strict";
const router_1 = require('@angular/router');
/* start define routings --there we add in -> */
const dashboard_component_1 = require('./dashboard/dashboard.component');
const personalCabinet_component_1 = require('./personalCabinet/personalCabinet.component');
/* end define routings */
const appRoutes = [
    {
        path: '',
        component: dashboard_component_1.Dashboard
    },
    {
        path: 'personal',
        component: personalCabinet_component_1.PersonalCabinet
    },
    {
        path: '**',
        component: dashboard_component_1.Dashboard
    }
];
exports.routing = router_1.RouterModule.forRoot(appRoutes);
//# sourceMappingURL=app.routing.js.map