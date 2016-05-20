angular.module('Fitocracy')
    .service('trackService', function ($http) {

        this.preMadeWorkouts = function () {
            var response = $http({
                method: "post",
                url: "/ZonaUsuarios/recuperaWorkouts",
            }).success(function (result) {
                response = result;
            }).error(function (data, status, headers, config) {
                response = status;
            });
            return response;
        }
    })