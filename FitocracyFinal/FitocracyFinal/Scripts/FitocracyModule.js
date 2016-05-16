var Fitocracy = angular.module('Fitocracy', ['ngRoute', 'ui.bootstrap', 'ngAnimate']);

var configFunction = function ($routeProvider, $locationProvider) {
    $routeProvider.
         when('/', {
             templateUrl: 'Home/Home',
         })
        .when('/Home', {
            templateUrl: 'Home/Home',
        })
        .when('/Coach', {
            templateUrl: 'Coach/Home',
            //controller: 'entrenadoresCtrl'
        })

         .when('/Coach/detalleEntrenamiento', {
             templateUrl:function(params){
                 return  'Coach/detalleEntrenamiento?idEntrenador=' + params.idEntrenador + '&idEntrenamiento='+params.idEntrenamiento;
             }
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
    $locationProvider.html5Mode(true).hashPrefix('!');
}
configFunction.$inject = ['$routeProvider', '$locationProvider'];

var compareTo = function () {
    return {
        require: "ngModel",
        scope: {
            otherModelValue: "=compareTo"
        },
        link: function (scope, element, attributes, ngModel) {

            ngModel.$validators.compareTo = function (modelValue) {
                return modelValue == scope.otherModelValue;
            };

            scope.$watch("otherModelValue", function () {
                ngModel.$validate();
            });
        }
    };
};

Fitocracy.directive("compareTo", compareTo);

Fitocracy.config(configFunction);