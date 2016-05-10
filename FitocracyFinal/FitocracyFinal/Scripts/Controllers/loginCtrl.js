angular.module('Fitocracy')
    .controller('loginCtrl', function ($scope, loginService) {

        //Muestra la ventana emergente
        //$("#modalRegistro").modal('hide');
        $("#modalLogin").modal('show');

        $scope.awesomeThings = [
            'AngularJS'
        ];

        //Funciones
        $scope.logear = function (isValid) {
            if (isValid) {
                var usuario = {
                    Username: $scope.uName,
                    Password: $scope.uPass
                };

                //Envio de datos a loginService
                var getData = loginService.UserLogin(usuario);

                //Respuesta de loginService
                getData.then(function (msg) {
                    if (msg.data == "False") {
                        $("#errorLogin").css('display', 'block');
                        $('#uName').removeClass('ng-valid').addClass('ng-invalid');
                        $('#uPass').removeClass('ng-valid').addClass('ng-invalid');
                    }
                    else {
                        //Meter en sesion al usuario
                        alert("OK");
                        window.location.href = "/ZonaUsuarios/Index";
                    }
                })
            } else {
                alert('Algo va mal en el login');
            }
        };

        $scope.irARegistro = function () {
            $("#modalLogin").modal('hide');
            window.location.href = "/#/Registro";
        }

       

        $scope.alertmsg = function () {
            $("#errorLogin").css('display', 'block');
        };

    });