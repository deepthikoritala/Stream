streamApp.controller("StreamController", function ($scope,$http) {

  
    $scope.helloTo = {};
    $scope.helloTo.title = "World, AngularJS";
    $scope.Languages = [];
    $scope.selectedIndex=-1;
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

    $scope.onMenuSelect = function (index) {
     
        $scope.selectedIndex = index;

      

    }

    $scope.onSubMenuSelect = function (type) {
        $http({
            method: 'GET',
            url: '/Home/getContent',
            data: { language: $scope.Languages[$scope.selectedIndex].Language}

        }).then(function successCallback(response) {

            $scope.Content = response.data;
        }, function errorCallback(response) {

        });

    }
});