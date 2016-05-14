angular.module('Fitocracy')
    .controller('entrenadoresCtrl', function ($scope, $http) {
        $scope.myInterval = 5000;
        $scope.noWrapSlides = false;
        $scope.active = 0;

        $http({
            method: 'post',
            url: '/Coach/GetEntrenadores'
        }).success(function (data, status, headers, config) {
            $scope.slides = data;
        }).error(function (data, status, headers, config) {
            $scope.message = 'Unexpected Error';
        });
    })