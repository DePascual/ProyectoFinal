angular.module('Fitocracy')
    .controller('trackCtrl', function ($scope, trackService, $window, $compile) {

        if (sessionStorage.getItem("workouts") == null) {
            var getData = trackService.preMadeWorkouts();
            getData.then(function (msg) {
                $scope.preMadeWorkouts = msg.data;
                sessionStorage["workouts"] = JSON.stringify(msg.data);
                alert('primera vez. Metido en session!')
            })
        } else {
            $scope.preMadeWorkouts = JSON.parse(sessionStorage.getItem("workouts"));
        }
     
        $scope.buscar = function () {
            var textoBusqueda = {
                texto: $scope.textBusqueda
            }
        };

        $scope.showDiv = function (divId, obj) {
            var visible = obj.target.attributes.show.value;


            if (visible == 'false') {
                $('#' + divId).show();
                $('#showDiv').attr('show', 'true');
                $('#showDiv').children().removeClass("fa fa-chevron-up").addClass("fa fa-chevron-down");
            } else {
                $('#' + divId).hide();
                $('#showDiv').attr('show', 'false');
                $('#showDiv').children().removeClass("fa fa-chevron-down").addClass("fa fa-chevron-up");
            }
        };

        $scope.descripcionEnPartial = function (obj) {
            $('#vistaParcial').empty();

            var idHandler = obj.target.attributes.data.value;

            $.each($scope.preMadeWorkouts, function (pos, el)
            {
                if (el._id == idHandler) {
                    $scope.Tracks = el.Tracks;
                }             
            })

            $('#vistaParcial').append('<div id="divTracks">'
                                        +'<p>{{track.Nombre}}</p>'
                                        +'</div>');
            $('#divTracks').attr('ng-repeat', 'track in Tracks');
            $compile($('#divTracks'))($scope);
        };
    })