/// <reference path="E:\Document\Đồ án\Project\Git\MyVocal\MyVocal.Web\Assets/admin/libs/angular/angular.js" />
(function (app) {
    app.controller('subjectListController', subjectListController);
    subjectListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox'];
    function subjectListController($scope, apiService, notificationService, $ngBootbox) {
        $scope.subjects = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.getSubjects = getSubjects;
        $scope.keyword = '';
        var isSearch=false;
        $scope.search = search;

        function search() {
            isSearch = true;
            getSubjects();
        }

        function getSubjects(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 2
                }
            }
            apiService.get('/api/subject/getAll', config, function (result) {
                if (isSearch) {
                    if (result.data.TotalCount == 0) {
                        notificationService.displayWarning('Không có bản ghi nào được tìm thấy.'); 
                    } else {
                        notificationService.displaySuccess('Đã tìm thấy ' + result.data.TotalCount + ' bản ghi.');
                    }
                    isSearch = false;
                }

                $scope.subjects = result.data.Items;
                $scope.page = result.data.Page;
                $scope.totalCount = result.data.TotalCount;
                $scope.pagesCount = result.data.TotalPages;
            }, function () {
                console.log('Load word categories failure');
            });
        }

        //delete subject
        //delete word
        $scope.subjectDelete = subjectDelete;

        function subjectDelete(id) {
            $ngBootbox.confirm('Bạn có chắc muốn xóa?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('/api/subject/delete', config, function () {
                    notificationService.displaySuccess('Xóa thành công');
                    search();
                }, function () {
                    notificationService.displayError('Xóa không thành công');
                })
            });
        }
        $scope.getSubjects();
    }
})(angular.module('myvocal.subjects'));