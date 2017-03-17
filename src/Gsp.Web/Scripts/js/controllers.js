angular.module("starter.controllers", [])
    .controller("HeaderCtrl", [
        "$scope", "$state", function ($scope, $state) {
            $scope.testlogin = function () {
                console.log("aaa");
            }
        }
    ]).controller("LeftSideCtrl", [
        "$scope", "$state", function ($scope, $state) {

        }
    ]).controller("ContentCtrl", [
        "$scope", "$state", function ($scope, $state) {

        }
    ]).controller("FooterCtrl", [
        "$scope", "$state", function ($scope, $state) {

        }
    ]).controller("ControlSidebarCtrl", [
        "$scope", "$state", function ($scope, $state) {

        }
    ]);
