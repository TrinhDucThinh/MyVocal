/// <reference path="../plugins/angular/angular.js" />
var myModule = angular.module('myModule', []);

//register
myModule.controller('schoolController',function($scope){
    $scope.message = 'message of SchoolController';
});

myModule.controller('studenController', function ($scope) {
    //$scope.message = 'message of studentController';
});

myModule.controller('teacherController', function ($scope) {
    //$scope.message = 'message of teacherController';
});

