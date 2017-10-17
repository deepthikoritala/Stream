streamApp.controller("StreamController", function ($scope,$http) {
    $scope.helloTo = {};
    $scope.helloTo.title = "World, AngularJS";
    $scope.Languages = [];
    $scope.selectedLanguage=0;
    $scope.getlanguages = function () {
     
        $http({
            method: 'GET',
            url: '/home/getLanguages'
        }).then(function successCallback(response) {
          
            $scope.Languages = response.data;
        }, function errorCallback(response) {

        });
    }
    $scope.getlanguages();

    $scope.onMenuSelect = function (lang) {
     
        $scope.selectedLanguage = lang;

    }
});