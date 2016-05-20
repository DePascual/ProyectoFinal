﻿angular.module('Fitocracy')
    .controller('userCtrl', function ($scope, $http, $compile, $window, $location) {
        alert('en el ctroleeerrr')

        if (sessionStorage.getItem("infoUsuario") != null) {
            var usuSession = JSON.parse(sessionStorage.getItem("infoUsuario"))

            $scope.usuario = {
                _id: usuSession._id,
                Username: usuSession.Username,
                Email: usuSession.Email
            }

            $("li[usu=true]").show();

            var dropUsuActivo = $('#dropUsu').attr('activo');
            if (dropUsuActivo == "false") {
                $('#dropUsu').attr('activo', 'true');
                $('#dropUsu').append('<a class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false" style="color:#0079ff; font-weight:bold">' + usuSession.Username + '<span class="caret"></span></a>'
                                    + '<ul class="dropdown-menu" id="listUsu">'
                                    + '<li><a value="custom" href="/You">Custom You</a></li>'
                                    + '<li><a id="linkGoHome" value="signOut">Sign Out</a></li>'
                                    + '</ul>');

                $('#linkGoHome').attr('ng-click', 'goHome()');
                $compile($('#linkGoHome'))($scope);
            }

            

        }

        //ng-href="@Url.Action("SignOut", "ZonaUsuarios")/' + usuSession._id + '"

        $scope.goHome = function () {
            $window.sessionStorage.removeItem("infoUsuario");
            $http.post("/ZonaUsuarios/SignOut", { "idUsuario": usuSession._id }).success(function () {
                alert("ok")
                //Proceso contrario que cuando se loguea
                //Ocultar opciones de usuario
            })
            $location.path("/Home");
        }
    })