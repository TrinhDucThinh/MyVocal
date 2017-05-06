/// <reference path="E:\Document\Đồ án\Project\Git\MyVocal\MyVocal.Web\Assets/admin/libs/angular/angular.js" />
(function (app) {
    app.controller('wordCategoriesEditController', wordCategoriesEditController);
    wordCategoriesEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams'];

    function wordCategoriesEditController(apiService, $scope, notificationService, $state, $stateParams) {

        //Initial $scope variable to save wordCategory in View
        $scope.wordCategory = {
           
        }

        $scope.UpdateWordCategory = UpdateWordCategory;

        function loadWordCategoryDetail() {
            apiService.get('api/wordcategory/getbyid/' + $stateParams.id, null, function (result) {
                $scope.wordCategory = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        function UpdateWordCategory() {
            apiService.put('api/wordcategory/update', $scope.wordCategory,
                function (result) {
                    notificationService.displaySuccess(result.data.CategoryName + ' đã được cập nhật thành công.');
                    $state.go('word_categories');
                },
                function (error) {
                    notificationService.displayError('Thêm mới không thành công');
                });
        }

        loadWordCategoryDetail();

    }
})(angular.module('myvocal.word_categories'));