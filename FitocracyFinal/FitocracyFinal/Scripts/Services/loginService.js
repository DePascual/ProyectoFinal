﻿angular.module('Fitocracy')
    .service('loginService', function ($http) {

        this.UserLogin = function (User) {

            var response = $http({
                method: "post",
                url: "/Home/Logeo",
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