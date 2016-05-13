var Fitocracy = angular.module('Fitocracy', ['ngRoute', 'ngMessages']);

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