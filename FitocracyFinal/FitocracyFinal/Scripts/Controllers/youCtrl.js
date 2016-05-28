﻿angular.module('Fitocracy')
    .controller('youCtrl', function ($scope, youService, trackService, $window, $location, $compile, ngTableParams) {


        $scope.cargaPartial = function (obj) {
            var idLink = obj.target.attributes.id.value;

            switch (idLink) {
                case "userInfo":
                    $('#vistaParcial').load("http://localhost:2841/PartialsViews/UserInfo", function () {
                        $compile($('#vistaParcial'))($scope);
                    });
                    break;
                case "userChangePass":
                    $('#vistaParcial').load("http://localhost:2841/PartialsViews/UserChangePass", function () {
                        $compile($('#vistaParcial'))($scope);
                    });
                    break;
                case "userWorkouts":
                    $('#vistaParcial').load("http://localhost:2841/PartialsViews/UserWorkouts", function () {
                        var getData = trackService.recuperaWorkoutsUsu();
                        getData.then(function (msg) {
                            $scope.recentWorkouts = msg.data;
                        })
                        $compile($('#vistaParcial'))($scope);
                    });

                    break;
                case "userEvolution":
                    $('#vistaParcial').load("http://localhost:2841/PartialsViews/UserEvolution", function () {
                        
                        $.getJSON('/PartialsViews/evolucionUsu',
                              function (data) {
                                  Morris.Area({
                                      element: 'graphic',
                                      data: data,
                                      xkey: 'Mes',
                                      parseTime: false,
                                      ykeys: ['Puntos'],
                                      labels: ['Puntos']
                                  });
                              }
                           );

                        $compile($('#vistaParcial'))($scope);
                    });
                    break;
                case "summaryLevels":
                    $('#vistaParcial').load("http://localhost:2841/PartialsViews/SummaryLevels", function () {

                        $compile($('#vistaParcial'))($scope);
                    });
                 
                    break;
            }


        };

        $scope.actualizarUserInfo = function () {
            var usuario = {
                Username: $scope.uName,
                Email: $('#uEmail').val(),
                Birthday: $('#uBirthday').val(),
                Description: $scope.uDescripcion,
            }

            var getData = youService.UpdateUser(usuario);

            getData.then(function (msg) {
                if (msg.data != "") {
                    $('#modalChangesOK').modal('show')
                }
            })
        };


        $scope.actualizarPassword = function () {
            var cambioPass = {
                PassOld: $scope.uPassOld,
                PassNew: $scope.uPassNew,
                PassNewRep: $scope.uPassNewRep
            }

            var getData = youService.UpdatePass(cambioPass);

            getData.then(function (msg) {
                if (msg.data == "True") {
                    alert('contraseña cambiada')
                    $('#modalChangesOK').show();
                }
            })
        };



        $scope.showDiv = function (divId, obj) {
            var visible = obj.target.attributes.show.value;
            if (visible == 'false') {
                $('#' + divId).show();
                $('#link_' + divId).attr('show', 'true');
                $('#link_' + divId).children().removeClass("fa fa-chevron-up").addClass("fa fa-chevron-down");

                //$('#BtnChangeInfoUsu').attr('ng-click', 'actualizar(userForm.$valid && passWordForm.$valid)');
                //$('#BtnChangeInfoUsu').attr('ng-disabled', 'userForm.$valid && passWordForm.$valid');
                $('#BtnChangeInfoUsu').removeAttr('ng-click');
                $('#BtnChangeInfoUsu').removeAttr('ng-disabled');

                // $compile($('#BtnChangeInfoUsu'))($scope);
            } else {
                $('#' + divId).hide();
                $('#link_' + divId).attr('show', 'false');
                $('#link_' + divId).children().removeClass("fa fa-chevron-down").addClass("fa fa-chevron-up");
            }

        };
    })