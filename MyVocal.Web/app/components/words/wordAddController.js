/// <reference path="E:\Document\Đồ án\Project\Git\MyVocal\MyVocal.Web\Assets/admin/libs/angular/angular.js" />
(function (app) {
    app.controller('wordAddController', wordAddController);
    wordAddController.$inject = ['apiService', '$scope', 'notificationService', '$state'];

    function wordAddController(apiService, $scope, notificationService, $state) {
        $scope.word = {
            
        }

        $scope.AddWord = AddWord;

        function AddWord() {
            apiService.post('api/word/create',$scope.word,
                function (result) {
                    notificationService.displaySuccess(result.data.WordName + ' đã được thêm mới thành công.');
                    $state.go('words');
                },
                function (error) {
                    notificationService.displayError('Thêm mới không thành công');
                });
        }

        function loadWordCategory() {
            apiService.get('api/wordCategory/getall_for_word', null, function (result) {
                $scope.wordCategories = result.data;
            }, function () {
                console.log('Cannot get list parent');
            });
        }

        function loadSubject() {
            apiService.get('api/subject/getallSubject', null, function (result) {
                $scope.Subjects = result.data;
            }, function () {
                console.log('Cannot get list subject');
            });
        }

        loadWordCategory();
        loadSubject();
    }
})(angular.module('myvocal.word'));