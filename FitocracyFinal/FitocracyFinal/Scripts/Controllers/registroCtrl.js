angular.module('Fitocracy')
    .controller('registroCtrl', function ($scope, registroService) {

        //Muestra la ventana emergente
        $("#modalRegistro").modal('show');

        $scope.awesomeThings = [
            'AngularJS'
        ];

        $scope.irALogin = function () {



            $("#modalRegistro").modal('hide');
            window.location.href = "#/Login";
        }

        $scope.registrar = function (isValid) {
            if (isValid) {
                var usuario = {
                    Email: $scope.uEmail,
                    Username: $scope.uName,
                    Password: $scope.uPass
                };
                alert('Campos correctos ===> ' + usuario.Username + ' ' + usuario.Email + ' ' + usuario.Password);

                //Envio de datos a loginService
                var getData = registroService.UserRegistro(usuario);
                //Respuesta de loginService
                getData.then(function (msg) {
                    if (msg.data == "False") {
                        alert("Upppsss Incorrect !");                  
                        //$("#alertModal").modal('show');
                        //$scope.info = "Upss Incorrect !";
                    }
                    else {
                        //Meter en sesion al usuario
                        alert("OK");
                        //window.location.href = "/ZonaUsuarios/Index";
                    }
                })

            } else {
                alert('Algo malo pasa')
            }
        }
    })