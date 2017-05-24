/// <reference path="E:\Document\Đồ án\Project\Git\MyVocal\MyVocal.Web\Assets/admin/libs/angular/angular.js" />
(function (app) {
    app.controller('subjectGroupListController', subjectGroupListController);
    subjectGroupListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox'];
    function subjectGroupListController($scope, apiService, notificationService, $ngBootbox) {
        $scope.subjectGroups = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.getSubjectGroups = getSubjectGroups;
        $scope.keyword = '';
        var isSearch = false;
        $scope.search = search;

        $scope.subjectGroupDelete = subjectGroupDelete;

        function subjectGroupDelete(id) {
            $ngBootbox.confirm('Bạn có chắc muốn xóa?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('/api/subjectGroup/delete', config, function () {
                    notificationService.displaySuccess('Xóa thành công');
                    search();
                }, function () {
                    notificationService.displayError('Xóa không thành công');
                })
            });
        }

        function search() {
            isSearch = true;
            getSubjectGroups();
        }

        function getSubjectGroups(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 2
                }
            }
            apiService.get('/api/subjectGroup/getall', config, function (result) {
                if (isSearch) {
                    if (result.data.TotalCount == 0) {
                        notificationService.displayWarning('Không có bản ghi nào được tìm thấy.');
                    } else {
                        notificationService.displaySuccess('Đã tìm thấy ' + result.data.TotalCount + ' bản ghi.');
                    }
                    isSearch = false;
                }

                $scope.subjectGroups = result.data.Items;
                $scope.page = result.data.Page;
                $scope.totalCount = result.data.TotalCount;
                $scope.pagesCount = result.data.TotalPages;
            }, function () {
                console.log('Load word categories failure');
            });
        }

        //delete subject group
        $scope.deleteSubject = deleteSubject;

        function deleteSubject(id) {
            $ngBootbox.confirm('Bạn có chắc muốn xóa?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('/api/subjectGroup/delete', config, function () {
                    notificationService.displaySuccess('Xóa thành công');
                    search();
                }, function () {
                    notificationService.displayError('Xóa không thành công');
                })
            });
        }

        $scope.getSubjectGroups();
    }
})(angular.module('myvocal.wordCategories'));