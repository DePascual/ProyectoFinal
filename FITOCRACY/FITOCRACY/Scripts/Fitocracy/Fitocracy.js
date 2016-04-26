var Fitocracy = angular.module('Fitocracy', ['ngRoute']);

Fitocracy.controller('menuPpalController', menuPpalController);
//Fitocracy.controller('mainController', mainController);
//Fitocracy.controller('aboutController', aboutController);
//Fitocracy.controller('contactController', contactController);

var configFunction = function ($routeProvider) {
    $routeProvider.
         when('/', {
             templateUrl: 'home/home',
         })
        .when('/home', {
            templateUrl: 'home/home',
        })
        .when('/hireCoach', {
            templateUrl: 'coach/index',
        })
        .when('/about', {
            templateUrl: 'home/about',
        })
        .when('/login', {
            templateUrl: 'home/login',
        });
}
configFunction.$inject = ['$routeProvider'];

Fitocracy.config(configFunction);