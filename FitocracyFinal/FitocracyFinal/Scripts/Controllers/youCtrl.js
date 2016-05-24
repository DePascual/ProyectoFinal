angular.module('Fitocracy')
    .controller('youCtrl', function ($scope, $window, $location, $compile) {


        $scope.cargaPartial = function (obj) {
            var idLink = obj.target.attributes.id.value;

            switch (idLink) {
                case "userInfo":
                    $('#vistaParcial').load("http://localhost:2841/PartialsViews/UserInfo", function () {
                        //alert('deberia de estar cargada');
                        $compile($('#vistaParcial'))($scope);
                    });
                    break;
                case "userWorkouts":
                    $('#vistaParcial').load("http://localhost:2841/PartialsViews/UserWorkouts");
                    break;
                case "userEvolution":
                    $('#vistaParcial').load("http://localhost:2841/PartialsViews/UserEvolution");
                    break;
                case "summaryLevels":
                    $('#vistaParcial').load("http://localhost:2841/PartialsViews/SummaryLevels");
                    break;
            }

           
        };

        $scope.actualizar = function (isValid) {
            if (isValid) {
                var usuario = {
                    Username: $scope.uName,
                    Email: $('#uEmail').val(),
                    Birthday: $('#uBirthday').val(),
                    Description: $scope.uDescripcion,
                    PasswordOld: $scope.uPassOld,
                    PasswordNew: $scope.uPassNew
                }
            }
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