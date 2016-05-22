//var jq = $.noConflict();

angular.module('Fitocracy')
    .controller('loginCtrl', function ($scope, loginService, $window, $location) {

        //Muestra la ventana emergente
        //$("#modalRegistro").modal('hide');
        $("#modalLogin").modal('show');

        //$scope.uName = false;
        //$scope.uPass = false;

        //if ($scope.myForm.data) {
        //    $scope.myForm.$setDirty
        //}

        //$scope.awesomeThings = [
        //    'AngularJS'
        //];

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

                        $location.path("/ZonaUsuarios");
                        //$window.location.href = "ZonaUsuarios";
                        $("#modalLogin").modal('hide');

                      
                        //$http.post("/ZonaUsuarios/Index", { "usuario": msg.data }).success(function () { alert(ok)})
                    }
                })
            } else {
                alert('Algo va mal en el login');
            }
        };

        $scope.irARegistro = function () {
            $("#modalLogin").modal('hide');
            window.location.href = "#/Registro";
        };
    
        $scope.alertmsg = function () {
            $("#errorLogin").css('display', 'block');
        };

        $scope.cerrar = function () {
            $("#modalLogin").modal('hide');
            window.location.href = "#/Home"
        };

    });