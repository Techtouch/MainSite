(function () {
    var myApp = angular.module("myApp", []);
    var HomeCtrl = function ($scope, $http) {

        var onError = function () {
            $scope.error = "Unable to retrieve data.";
        }

        var bestProducts = function (response) {
            $scope.bestProducts = response.data;
        }

        var cheapestProducts = function (response) {
            $scope.cheapestProducts = response.data;
        }

        $http.get("/api/ProductsApi/GetBestProducts/6").then(bestProducts, onError);
        $http.get("/api/ProductsApi/GetCheapestProducts/6").then(cheapestProducts, onError);
    };

    myApp.controller("HomeCtrl", ["$scope", "$http", HomeCtrl]);
}());