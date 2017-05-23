/// <reference path="E:\Document\Đồ án\Project\Git\MyVocal\MyVocal.Web\Assets/admin/libs/angular/angular.js" />
(function (app) {
    app.controller('questionCategoriesAddController', questionCategoriesAddController);
    questionCategoriesAddController.$inject = ['apiService','$scope','notificationService','$state'];

    function questionCategoriesAddController(apiService,$scope,notificationService,$state) {
        $scope.wordCategory = {};

        $scope.AddQuestionCategory = AddQuestionCategory;

        function AddQuestionCategory() {
            apiService.post('api/questionCategory/create', $scope.questionCategory,
                function (result) {
                    notificationService.displaySuccess(result.data.QuestionCategoryName + ' đã được thêm mới thành công.');
                    $state.go('questionCategories');
                },
                function (error) {
                    notificationService.displayError('Thêm mới không thành công');
                });
        }
    }
})(angular.module('myvocal.questionCategories'));