﻿(function () {
    'use strict';
    
    var app = angular.module('app', [
        // Angular modules 
        'ngAnimate',        // animations
        'ngRoute',          // routing
        'ngSanitize',       // sanitizes html bindings (ex: sidebar.js)

        // Custom modules 
        'common',           // common functions, logger, spinner
        'common.bootstrap', // bootstrap dialog wrapper functions

        // 3rd Party Modules
        'breeze.angular',  // tells breeze to use $q instead of Q.js
        'breeze.directives', // breeze validation directive (zValidate)
        'ui.bootstrap'       // ui-bootstrap (ex: carousel, pagination, dialog)
    ]);
    
    // Handle routing errors and success events.
    // Trigger breeze configuration
    app.run(['$route', function ($route) {
        // Include $route to kick start the router.
    }]);
})();