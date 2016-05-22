angular.module('Fitocracy')
    .controller('trackCtrl', function ($scope, trackService, $window, $compile) {

    
        if (sessionStorage.getItem("workouts") == null) {
            var getData = trackService.preMadeWorkouts();
            getData.then(function (msg) {
                $scope.preMadeWorkouts = msg.data;
                sessionStorage["workouts"] = JSON.stringify(msg.data);
                //alert('primera vez. Metido en session!')
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

            if (divId == "recentWorkouts") {
                recuperaWorkoutsUsu();
            }

            var links = $('#subMenu').find('a[show]');

            $.each(links, function (pos, el) {
                if ($(this).attr('show') == 'true') {
                    var idDiv = $(this).attr('id').split('link_')[1];
                    $('#' + idDiv).hide();
                    $('#link_' + idDiv).attr('show', 'false');
                    $('#link_' + idDiv).children().removeClass("fa fa-chevron-down").addClass("fa fa-chevron-up");
                }
            })

            var visible = obj.target.attributes.show.value;
            if (visible == 'false') {
                $('#' + divId).show();
                $('#link_' + divId).attr('show', 'true');
                $('#link_' + divId).children().removeClass("fa fa-chevron-up").addClass("fa fa-chevron-down");
            } else {
                $('#' + divId).hide();
                $('#link_' + divId).attr('show', 'false');
                $('#link_' + divId).children().removeClass("fa fa-chevron-down").addClass("fa fa-chevron-up");
            }
        };

        $scope.descripcionEnPartial = function (obj) {
            //$('#vistaParcial').empty();
            // $('#grid').css('display', 'block');

            $scope.gridOptions

            var idHandler = obj.target.attributes.data.value;

            $.each($scope.preMadeWorkouts, function (pos, el) {
                if (el._id == idHandler) {
                    $scope.workout = el;
                    $scope.Tracks = el.Tracks;
                }
            })

            $('#vistaParcial').load("http://localhost:2841/PartialsViews/TablaDatosWorkout", { "workout": $scope.workout, "tracks": $scope.Tracks });




            //$scope.gridOptions = {
            //    columnDefs: [
            //        { name: '_id', visible: false }
            //    ]
            //};


            //$('#vistaParcial').append('<div id="divTracks">'
            //                            +'<p>{{track.Nombre}}</p>'
            //                            +'</div>');
            //$('#divTracks').attr('ng-repeat', 'track in Tracks');
            //$compile($('#divTracks'))($scope);


        };

        function recuperaWorkoutsUsu() {
            var getData = trackService.recuperaWorkoutsUsu();
            getData.then(function (msg) {
                $scope.recentWorkouts = msg.data;
                //sessionStorage["workouts"] = JSON.stringify(msg.data);
                //alert('primera vez. Metido en session!')
            })
        }


    })