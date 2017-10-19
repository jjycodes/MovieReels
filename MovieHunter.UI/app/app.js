// Application definition
// Configures the UI routes
(function () {
    // Define the main module
    var app = angular.module("Reels", ["ngRoute"]);
  
    app.config(['$routeProvider',
        function ($routeProvider) {
            $routeProvider
                .when("/", {
                    templateUrl: "app/welcomeView.html"
                })
                .when("/reels", {
                    templateUrl: "app/Reels/ReelsCtrl.html",
                    controller: "ReelsCtrl"
                })
                .otherwise({
                    redirectTo: "/"
                })
        }]);
}());