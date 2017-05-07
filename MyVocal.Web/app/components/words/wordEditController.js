/// <reference path="E:\Document\Đồ án\Project\Git\MyVocal\MyVocal.Web\Assets/admin/libs/angular/angular.js" />
(function (app) {
    app.controller('wordEditController', wordEditController);
    wordEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams'];

    function wordEditController(apiService, $scope, notificationService, $state, $stateParams) {

        //Initial $scope variable to save wordCategory in View
        $scope.word = {

        }

        $scope.UpdateWord = UpdateWord;

        function loadWordDetail() {
            apiService.get('api/word/getbyid/' + $stateParams.id, null, function (result) {
                $scope.word = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        function UpdateWord() {
            apiService.put('api/word/update', $scope.wordCategory,
                function (result) {
                    notificationService.displaySuccess(result.data.CategoryName + ' đã được cập nhật thành công.');
                    $state.go('word');
                },
                function (error) {
                    notificationService.displayError('Thêm mới không thành công');
                });
        }
        function loadWordCategory() {
            apiService.get('api/wordcategory/getall_for_word', null, function (result) {
                $scope.wordCategories = result.data;
                console.log('pass');
            }, function () {
                console.log('Cannot get list parent');
            });
        }

        function loadSubject() {
            apiService.get('api/subject/getallSubject', null, function (result) {
                $scope.Subjects = result.data;
                console.log('ad');
            }, function () {
                console.log('Cannot get list subject');
            });
        }

        loadWordCategory();
        loadSubject();
        loadWordDetail();

    }
})(angular.module('myvocal.word'));