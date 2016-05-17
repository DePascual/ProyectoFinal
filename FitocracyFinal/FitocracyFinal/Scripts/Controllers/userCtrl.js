angular.module('User')
    .controller('userCtrl', function ($scope, $http) {

        $scope.goHome = function () {
            $window.sessionStorage.removeItem("infoUsuario");
            window.location.href = "/";
        }
    })