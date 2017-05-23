/// <reference path="E:\Document\Đồ án\Project\Git\MyVocal\MyVocal.Web\Assets/admin/libs/angular/angular.js" />
(function (app) {
    app.controller('questionCategoriesListController', questionCategoriesListController);
    questionCategoriesListController.$inject = ['$scope', 'apiService', 'notificationService','$ngBootbox'];
    function questionCategoriesListController($scope, apiService, notificationService,$ngBootbox) {
        $scope.questionCategories = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.getQuestionCategories = getQuestionCategories;
        $scope.keyword = '';
        var isSearch=false;
        $scope.search = search;

        $scope.deleteQuestionCategory = deleteQuestionCategory;

        function deleteQuestionCategory(id) {
            $ngBootbox.confirm('Bạn có chắc muốn xóa?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('/api/questionCategory/delete', config, function () {
                    notificationService.displaySuccess('Xóa thành công');
                    search();
                }, function () {
                    notificationService.displayError('Xóa không thành công');
                })
            });
        }

        function search() {
            isSearch = true;
            getQuestionCategories();
        }

        function getQuestionCategories(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 2
                }
            }
            apiService.get('/api/questionCategory/getall', config, function (result) {
                if (isSearch) {
                    if (result.data.TotalCount == 0) {
                        notificationService.displayWarning('Không có bản ghi nào được tìm thấy.'); 
                    } else {
                        notificationService.displaySuccess('Đã tìm thấy ' + result.data.TotalCount + ' bản ghi.');
                    }
                    isSearch = false;
                }

                $scope.questionCategories = result.data.Items;
                $scope.page = result.data.Page;
                $scope.totalCount = result.data.TotalCount;
                $scope.pagesCount = result.data.TotalPages;
            }, function () {
                console.log('Load word categories failure');
            });
        }
        $scope.getQuestionCategories();
    }
})(angular.module('myvocal.questionCategories'));