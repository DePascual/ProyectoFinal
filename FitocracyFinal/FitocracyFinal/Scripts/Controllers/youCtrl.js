angular.module('Fitocracy')
    .controller('youCtrl', function ($scope) {

        $scope.cargaPartial = function (obj) {
            var idLink = obj.target.attributes.id.value;

            switch (idLink) {
                case "userInfo":
                    $('#vistaParcial').load("http://localhost:2841/PartialsViews/UserInfo");
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
        }

    })