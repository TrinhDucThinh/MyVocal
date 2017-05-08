﻿/// <reference path="E:\Document\Đồ án\Project\Git\MyVocal\MyVocal.Web\Assets/admin/libs/angular/angular.js" />
(function (app) {
    app.controller('subjectAddController', subjectAddController);
    subjectAddController.$inject = ['apiService','$scope','notificationService','$state'];

    function subjectAddController(apiService,$scope,notificationService,$state) {
        $scope.wordCategory = {
            
        }

        $scope.AddWordCategory = AddWordCategory;

        function AddWordCategory() {
            apiService.post('api/wordcategory/create',$scope.wordCategory,
                function (result) {
                    notificationService.displaySuccess(result.data.CategoryName + ' đã được thêm mới thành công.');
                    $state.go('word_categories');
                },
                function (error) {
                    notificationService.displayError('Thêm mới không thành công');
                });
        }
    }
})(angular.module('myvocal.subjects'));