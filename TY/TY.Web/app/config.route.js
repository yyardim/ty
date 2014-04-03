(function () {
    'use strict';

    var app = angular.module('app');

    // Collect the routes -YY: constant(name,value)
    app.constant('routes', getRoutes());
    
    // YY: $routeProvider - when(path, route);
    // Configure the routes and route resolvers
    app.config(['$routeProvider', 'routes', routeConfigurator]);
    function routeConfigurator($routeProvider, routes) {

        routes.forEach(function (r) {
            $routeProvider.when(r.url, r.config);
        });
        $routeProvider.otherwise({ redirectTo: '/' });
    }

    // Define the routes 
    function getRoutes() {
        return [
            {
                url: '/',
                config: {
                    templateUrl: 'app/dashboard/dashboard.html',
                    title: 'dashboard',
                    settings: {
                        nav: 1,
                        content: '<i class="fa fa-dashboard"></i> Dashboard'
                    }
                }
            }, {
                url: '/admin',
                config: {
                    title: 'admin',
                    templateUrl: 'app/admin/admin.html',
                    settings: {
                        nav: 2,
                        content: '<i class="fa fa-lock"></i> Admin'
                    }
                }
            }, {
                url: '/yorumlar',
                config: {
                    title: 'yorumlar',
                    templateUrl: 'app/yorum/yorumlar.html',
                    settings: {
                        nav: 3,
                        content: '<i class="icon-edit"></i> Yorumlar'
                    }
                }
            }
        ];
    }
})();