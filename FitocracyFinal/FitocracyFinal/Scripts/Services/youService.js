angular.module('Fitocracy')
    .service('youService', function ($http) {

        this.UpdateUser = function (User) {

            var response = $http({
                method: "post",
                url: "/ZonaUsuarios/UpdateUser",
                data: JSON.stringify(User),
                dataType: "json"
            }).success(function (data, status, headers, config) {
                response = data;
            }).error(function (data, status, headers, config) {
                response = status;
            });
            return response;
        }
    })