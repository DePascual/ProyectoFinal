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

        $scope.registrar = function (isValid) {
            if (isValid) {
                var usuario = {
                    Email: $scope.uEmail,
                    Username: $scope.uName,
                    Password: $scope.uPass
                };
                alert('Campos correctos ===> ' + usuario.Username + ' ' + usuario.Email + ' ' + usuario.Password);
            } else {
                alert('Algo malo pasa')
            }
        }
    })