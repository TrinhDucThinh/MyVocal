/// <reference path="E:\Document\Đồ án\Project\Git\MyVocal\MyVocal.Web\Assets/admin/libs/angular/angular.js" />
(function (app) {
    app.controller('wordCategoriesListController', wordCategoriesListController);
    wordCategoriesListController.$inject = ['$scope', 'apiService'];
    function wordCategoriesListController($scope, apiService) {
        $scope.wordCategories = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.getWordCategories = getWordCategories;
        $scope.keyword = '';

        $scope.search = search;
        
        function search() {
            getWordCategories();
        }

        function getWordCategories(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword:$scope.keyword,
                    page:page,
                    pageSize:2
                }
            }
            apiService.get('/api/WordCategory/getall', config, function (result) {
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
})(angular.module('myvocal.word_categories'));