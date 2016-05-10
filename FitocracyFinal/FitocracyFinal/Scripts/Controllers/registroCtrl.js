angular.module('Fitocracy')
    .controller('registroCtrl', function ($scope, registroService) {

        //Muestra la ventana emergente
        $("#modalRegistro").modal('show');

        $scope.awesomeThings = [
            'AngularJS'
        ];

        $scope.irALogin = function () {
            $("#modalRegistro").modal('hide');
            window.location.href = "/#/Login";
        }
    })