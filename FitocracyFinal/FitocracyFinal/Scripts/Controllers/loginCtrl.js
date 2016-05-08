angular.module('Fitocracy')
    .controller('loginCtrl', function ($scope, loginService) {

        //Muestra la ventana emergente
        //$("#modalRegistro").modal('hide');
        $("#modalLogin").modal('show');

        $scope.awesomeThings = [
            'AngularJS'
        ];

        //Funciones
        $scope.logear = function () {
            var usuario = {
                Username: $scope.uName,
                Password: $scope.uPass
            };

            //Envio de datos a loginService
            var getData = loginService.UserLogin(usuario);

            //Respuesta de loginService
            getData.then(function (msg) {
                if (msg.data == "False") {
                    //alert("Upppsss Incorrect !");                  
                    $("#alertModal").modal('show');
                    $scope.info = "Upss Incorrect !";
                }
                else {
                    //Meter en sesion al usuario
                    alert("OK");
                    window.location.href = "/ZonaUsuarios/Index";
                }
            })
        }

       

        $scope.alertmsg = function () {
            $("#alertModal").modal('hide');
            $('#uName').removeClass('ng-valid').addClass('ng-invalid');
            $('#uPass').removeClass('ng-valid').addClass('ng-invalid');
        };

    });