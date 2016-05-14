angular.module('Fitocracy')
    .service('loginService', function ($http) {
        this.UserLogin = function (User) {
            var response = $http({
                method: "post",
                url: "/Home/loginRecupUsuario",
                data: JSON.stringify(User),
                dataType: "json"
            }).success(function (result) {
                response = result;
            }).error(function (data, status, headers, config) {
                response = status;
            });
            return response;
        }
    })
