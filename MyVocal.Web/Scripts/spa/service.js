/// <reference path="../plugins/angular/angular.js" />
var myService = angular.module('myService', []);

myService.controller('serviceController', serviceController);

myService.service('checkNumber', checkNumber);
serviceController.$inject=['$scope','checkNumber']

function serviceController($scope, checkNumber) {

    $scope.CheckNumber = function () {
        
        $scope.message=checkNumber.check($scope.num);
    };

}

function checkNumber() {
    return {
        check:check
    }
    function check(number) {
        if (number % 2 == 0) {
            return 'This is even';
        } else {
            return 'This is odd';
        }
    }
}