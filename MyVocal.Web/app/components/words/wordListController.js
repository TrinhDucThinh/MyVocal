/// <reference path="E:\Document\Đồ án\Project\Git\MyVocal\MyVocal.Web\Assets/admin/libs/angular/angular.js" />
(function (app) {
    app.controller('wordListController', wordListController);
    wordListController.$inject = ['$scope', 'apiService', 'notificationService'];
    function wordListController($scope, apiService, notificationService) {
        $scope.words = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.getWords = getWords;
        $scope.keyword = '';
        var isSearch=false;
        $scope.search = search;

        function search() {
            isSearch = true;
            getWords();
        }

        function getWords(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 10
                }
            }
            apiService.get('/api/word/getall', config, function (result) {
                if (isSearch) {
                    if (result.data.TotalCount == 0) {
                        notificationService.displayWarning('Không có bản ghi nào được tìm thấy.'); 
                    } else {
                        notificationService.displaySuccess('Đã tìm thấy ' + result.data.TotalCount + ' bản ghi.');
                    }
                    isSearch = false;
                }

                $scope.words = result.data.Items;
                $scope.page = result.data.Page;
                $scope.totalCount = result.data.TotalCount;
                $scope.pagesCount = result.data.TotalPages;
            }, function () {
                console.log('Load words failure');
            });
        }

        $scope.getWords();
    }
})(angular.module('myvocal.word'));