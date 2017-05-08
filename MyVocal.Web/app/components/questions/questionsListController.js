(function (app) {
    app.controller('questionsListController', questionsListController);
    questionsListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox'];
    function questionsListController($scope, apiService, notificationService, $ngBootbox) {
        $scope.questions = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.getQuestions = getQuestions;
        $scope.keyword = '';
        var isSearch = false;
        $scope.search = search;

        function search() {
            isSearch = true;
            getQuestions();
        }
        //get all question
        function getQuestions(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 10
                }
            }
            apiService.get('/api/question/getall', config, function (result) {
                if (isSearch) {
                    if (result.data.TotalCount == 0) {
                        notificationService.displayWarning('Không có bản ghi nào được tìm thấy.');
                    } else {
                        notificationService.displaySuccess('Đã tìm thấy ' + result.data.TotalCount + ' bản ghi.');
                    }
                    isSearch = false;
                }

                $scope.questions = result.data.Items;
                $scope.page = result.data.Page;
                $scope.totalCount = result.data.TotalCount;
                $scope.pagesCount = result.data.TotalPages;
            }, function () {
                console.log('Load words failure');
            });
        }
        //delete question
        $scope.deleteQuestion = deleteQuestion;
        function deleteQuestion(id) {
            $ngBootbox.confirm('Bạn có chắc muốn xóa?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('/api/question/delete', config, function () {
                    notificationService.displaySuccess('Xóa thành công');
                    search();
                }, function () {
                    notificationService.displayError('Xóa không thành công');
                })
            });
        }
        $scope.getQuestions();
    }
})(angular.module('myvocal.questions'));