var Fitocracy = angular.module('Fitocracy', ['ngRoute']);

var configFunction = function ($routeProvider) {
    $routeProvider.
         when('/', {
             templateUrl: 'Home/Home',
         })
        .when('/Home', {
            templateUrl: 'Home/Home',
        })
        .when('/Coach', {
            templateUrl: 'Coach/Home',
        })
        .when('/About', {
            templateUrl: 'Home/About',
        })
        .when('/Login', {
            templateUrl: 'Home/Login',
            controller: 'loginCtrl'
        })
        .when('/Registro', {
            templateUrl: 'Home/Registro',
            controller: 'registroCtrl'
        });
}
configFunction.$inject = ['$routeProvider'];

Fitocracy.config(configFunction);