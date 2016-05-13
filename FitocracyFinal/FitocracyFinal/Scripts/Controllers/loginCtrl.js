angular.module('Fitocracy')
    .controller('loginCtrl', function ($scope, loginService, $window) {

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
                    Password: $scope.uPass,
                    _id: "null"
                };

                //Envio de datos a loginService
                var getData = loginService.UserLogin(usuario);

                //Respuesta de loginService
                getData.then(function (msg) {
                    if (msg.data == "") {
                        $("#errorLogin").css('display', 'block');
                        $('#uName').removeClass('ng-valid').addClass('ng-invalid');
                        $('#uPass').removeClass('ng-valid').addClass('ng-invalid');
                    }
                    else {
                        $window.sessionStorage["infoUsuario"] = JSON.stringify(msg.data);
                        window.location.href = "/ZonaUsuarios/Index";
                        //$http.post("/ZonaUsuarios/Index", { "usuario": msg.data }).success(function () { alert(ok)})
                    }
                })
            } else {
                alert('Algo va mal en el login');
            }
        };

        $scope.irARegistro = function () {
            $("#modalLogin").modal('hide');
            window.location.href = "/#/Registro";
        };
    
        $scope.alertmsg = function () {
            $("#errorLogin").css('display', 'block');
        };

        $scope.cerrar = function () {
            $("#modalLogin").modal('hide');
            window.location.href = "/#/Home"
        };

    });