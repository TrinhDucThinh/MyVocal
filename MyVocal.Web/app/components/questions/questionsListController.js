/// <reference path="E:\Document\Đồ án\Project\Git\MyVocal\MyVocal.Web\Assets/admin/libs/angular/angular.js" />
(function (app) {
    app.controller('questionsListController', questionsListController);
    questionsListController.$inject = ['$scope', 'apiService', 'notificationService'];
    function questionsListController($scope, apiService, notificationService) {
        $scope.wordCategories = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.getWordCategories = getWordCategories;
        $scope.keyword = '';
        var isSearch=false;
        $scope.search = search;

        function search() {
            isSearch = true;
            getWordCategories();
        }

        function getWordCategories(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 2
                }
            }
            apiService.get('/api/WordCategory/getall', config, function (result) {
                if (isSearch) {
                    if (result.data.TotalCount == 0) {
                        notificationService.displayWarning('Không có bản ghi nào được tìm thấy.'); 
                    } else {
                        notificationService.displaySuccess('Đã tìm thấy ' + result.data.TotalCount + ' bản ghi.');
                    }
                    isSearch = false;
                }

                $scope.wordCategories = result.data.Items;
                $scope.page = result.data.Page;
                $scope.totalCount = result.data.TotalCount;
                $scope.pagesCount = result.data.TotalPages;
            }, function () {
                console.log('Load word categories failure');
            });
        }
        $scope.getWordCategories();
    }
})(angular.module('myvocal.question'));