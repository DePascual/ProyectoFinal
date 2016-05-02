var loginController = function ($scope, $location) {
    $scope.submit = function () {
        var usuarioLogin = {
            uname : $scope.username,
            pass : $scope.password
        }
        
        $http.post('http://localhost:16563/Home/existeUsu', usuarioLogin)

    }
}


