angular.module('Fitocracy')
    .controller('userCtrl', function ($scope, $http) {
        alert('e el ctroleeerrr')

        if (sessionStorage.getItem("infoUsuario") != null) {
            alert('hay usuario');

            $("li[usu=true]").show();
        }
       

        $scope.goHome = function () {
            $window.sessionStorage.removeItem("infoUsuario");
            window.location.href = "/";
        }
    })