/// <reference path="E:\Document\Đồ án\Project\Git\MyVocal\MyVocal.Web\Assets/admin/libs/angular/angular.js" />
(function (app) {
    app.controller('wordAddController', wordAddController);
    wordAddController.$inject = ['apiService', '$scope', 'notificationService', '$state'];

    function wordAddController(apiService, $scope, notificationService, $state) {
        //$scope.wordCategory = {
            
        //}

        //$scope.wordAddController = wordAddController;

        //function wordAddController() {
        //    apiService.post('api/wordcategory/create',$scope.word,
        //        function (result) {
        //            notificationService.displaySuccess(result.data.CategoryName + ' đã được thêm mới thành công.');
        //            $state.go('word_categories');
        //        },
        //        function (error) {
        //            notificationService.displayError('Thêm mới không thành công');
        //        });
        //}
    }
})(angular.module('myvocal.word'));