(function (app) {
    app.controller('wordListController', wordListController);
    wordListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox'];
    function wordListController($scope, apiService, notificationService, $ngBootbox) {
        $scope.words = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.getWords = getWords;
        $scope.keyword = '';
        var isSearch = false;
        $scope.search = search;

        //searching word
        function search() {
            isSearch = true;
            getWords();
        }

        //get list word
        function getWords(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 10
                }
            }
            apiService.get('/api/word/getAllByPagging', config, function (result) {
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

        //delete word
        $scope.deleteWord = deleteWord;

        function deleteWord(id) {
            $ngBootbox.confirm('Bạn có chắc muốn xóa?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('/api/word/delete', config, function () {
                    notificationService.displaySuccess('Xóa thành công');
                    search();
                }, function () {
                    notificationService.displayError('Xóa không thành công');
                })
            });
        }

        $scope.getWords();
    }
})(angular.module('myvocal.words'));