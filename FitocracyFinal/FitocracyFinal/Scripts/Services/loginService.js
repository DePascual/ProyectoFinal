angular.module('Fitocracy')
    .service('loginService', function ($http) {

        //this.UserLogin = function (User) {

        //    var response = $http({
        //        method: "post",
        //        url: "/Home/loginRecupUsuario",
        //        data: JSON.stringify(User),
        //        dataType: "json"
        //    }).success(function (data, status, headers, config) {
        //        //response = data; (boolean)
        //        response = config.data;
        //    }).error(function (data, status, headers, config) {
        //        response = status;
        //    });
        //    return response;

   

        this.UserLogin = function (User) {

            var usu;

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
