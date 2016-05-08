angular.module('Fitocracy')
    .controller('registroCtrl', function ($scope, registroService) {

        //Muestra la ventana emergente
        $("#modalLogin").modal('hide');
        $("#modalRegistro").modal('show');

        $scope.awesomeThings = [
            'AngularJS'
        ];

        $scope.redirigir = function () {
            $("#modalLogin").modal('hide');
            window.location.href = "/Home/Registro";
        }
    })