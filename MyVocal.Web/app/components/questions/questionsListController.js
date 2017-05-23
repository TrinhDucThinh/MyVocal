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
        //function searching
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

        //function to load all subjects
        function loadSubjects() {
            apiService.get('api/subject/getallSubject', null, function (result) {
                $scope.subjects = result.data;
            }, function () {
                console.log('Cannot get list subject');
            });
        }

        //change subject
        $scope.hasChangedSubject = function () {
            loadWords($scope.subjectId);
        }

        //change subject
        //$scope.hasChangeWord = function (item) {
        //    isSearch = true;
        //    alert($scope.word);
        //    $scope.words.push(item.text);
        //    //$scope.keyword=
        //    //getQuestions();
        //}
      
        $scope.changedValue = function (item) {
            isSearch = true;
            if (item != null) {
                $scope.keyword = item.WordName;
                getQuestions();
                $scope.keyword = '';
            }
        }
        //function to load all word
        function loadWords(subjectId) {
            if (typeof subjectId == 'undefined') {
                apiService.get('api/word/getAllBySubjectId/1', null, function (result) {
                    $scope.words = result.data;

                }, function () {
                    console.log('Cannot get list parent');
                });
            } else {
                apiService.get('api/word/getAllBySubjectId/' + subjectId, null, function (result) {
                    $scope.words = result.data;

                }, function () {
                    console.log('Cannot get list parent');
                });
            }
            
        }

        loadWords();
        loadSubjects();

        $scope.getQuestions();
    }
})(angular.module('myvocal.questions'));