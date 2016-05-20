angular.module('Fitocracy')
    .controller('trackCtrl', function ($scope, trackService) {

        var getData = trackService.preMadeWorkouts;
        getData.then(function (msg) {
            $scope.preMadeWorkouts = msg.data;
        })


        //$scope.alumnos = [
        //  { nombre: "Carolina de Pascual", telefono: "666666666", curso: "2DAW" },
        //  { nombre: "Marta de Pascual", telefono: "888888888", curso: "4Psicologia" },
        //  { nombre: "Fernando Gomez", telefono: "777777777", curso: "2Aeronautica" }
        //]


        $scope.buscar = function () {
            var textoBusqueda = {
                texto: $scope.textBusqueda
            }
        };

        $scope.showDiv = function (divId) {
            $('#' + divId).show();
        }
    })