var User = angular.module('User', ['ngRoute', 'ui.bootstrap', 'ngAnimate']);

var configFunction = function ($routeProvider, $locationProvider) {
    $routeProvider.
         when('/', {
             templateUrl: 'Home/Home',
         })
        .when('/ZonaUsuarios', {
            templateUrl: 'ZonaUsuarios/Home',
        })
        .when('/Home', {
            templateUrl: 'ZonaUsuarios/Home',
        })
         .when('/You', {
             templateUrl: 'ZonaUsuarios/You',
         })
        .when('/Track', {
            templateUrl: 'ZonaUsuarios/Track',
        })
        .when('/Coach', {
            templateUrl: 'Coach/Home',
        })
        .when('/Connect', {
            templateUrl: 'ZonaUsuarios/Connect',
        })
        .when('/Leaders', {
            templateUrl: 'ZonaUsuarios/Leaders',
        })
        .when('/ZonaUsuarios/SignOut', {
            templateUrl: function (params) {
                return 'ZonaUsuarios/SignOut?idUsuario=' + params.idUsuario;
            },
            controller: 'userCtrl'
        });
    $locationProvider.html5Mode(true).hashPrefix('!');
}
configFunction.$inject = ['$routeProvider', '$locationProvider'];

User.config(configFunction);