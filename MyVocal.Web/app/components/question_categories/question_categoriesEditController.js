/// <reference path="E:\Document\Đồ án\Project\Git\MyVocal\MyVocal.Web\Assets/admin/libs/angular/angular.js" />
(function (app) {
    app.controller('questionCategoriesEditController', questionCategoriesEditController);
    questionCategoriesEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams'];

    function questionCategoriesEditController(apiService, $scope, notificationService, $state, $stateParams) {

        //Initial $scope variable to save wordCategory in View
        $scope.questionCategory = {}

        $scope.questionCategoryEdit = questionCategoryEdit;

        //update question category
        function questionCategoryEdit() {
            apiService.put('api/questionCategory/update', $scope.questionCategory,
                function (result) {
                    notificationService.displaySuccess(result.data.QuestionCategoryName + ' đã được cập nhật thành công.');
                    $state.go('questionCategories');
                },
                function (error) {
                    notificationService.displayError('Thêm mới không thành công');
                });
        }

        //Load detail
        function loadQuestionCategoryDetail() {
            apiService.get('api/questionCategory/getbyid/' + $stateParams.id, null, function (result) {
                $scope.questionCategory = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }
        loadQuestionCategoryDetail();

    }
})(angular.module('myvocal.wordCategories'));