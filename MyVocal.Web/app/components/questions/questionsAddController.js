/// <reference path="E:\Document\Đồ án\Project\Git\MyVocal\MyVocal.Web\Assets/admin/libs/angular/angular.js" />
(function (app) {
    app.controller('questionsAddController', questionsAddController);
    questionsAddController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams'];

    function questionsAddController(apiService, $scope, notificationService, $state, $stateParams) {
        //variable question scope is Model
       
        //load Word by Id
        $scope.word = '';
        function loadWordById() {
            apiService.get('/api/word/getbyid/' + $stateParams.wordId, null, function (result) {
                $scope.word = result.data;
                $scope.question = {
                    WordId: $scope.word.WordId,
                    Image: $scope.word.Image,
                    Audio: $scope.word.Sound,
                }
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        //function to load all subjects
        function loadSubjects() {
            apiService.get('/api/subject/getallSubject', null, function (result) {
                $scope.subjects = result.data;

            }, function () {
                console.log('Cannot get list subject');
            });
        }
        //change subject
        $scope.hasChanged = function () {
            loadWords($scope.subjectId);
        }

        //function to load question category
        function loadQuestionCategories() {
            apiService.get('/api/questionCategory/getAllQuestion', null, function (result) {
                $scope.questionCategories = result.data;

            }, function () {
                console.log('Cannot get list parent');
            });
        }
        //change questionCagories
        $scope.hasChangedQuestionCategory = function () {
            
            $scope.question.QuestionName = $scope.word.Example;
            alert($scope.question.QuestionName);
        }
        //function add question
        $scope.questionAdd = questionAdd;
        function questionAdd() {
            apiService.post('/api/question/create',$scope.question,
                function (result) {
                    notificationService.displaySuccess(result.data.QuestionId + ' đã được thêm mới thành công.');
                    $state.go('questions');
                },
                function (error) {
                    notificationService.displayError('Thêm mới không thành công');
                });
        }

        //function to load all word
        //function loadWords(subjectId) {
        //    apiService.get('/api/word/getAllBySubjectId/' + subjectId, null, function (result) {
        //        $scope.words = result.data;

        //    }, function () {
        //        console.log('Cannot get list parent');
        //    });
        //}

        loadQuestionCategories();
        //loadWords($stateParams.subjectId);
        loadSubjects();
        loadWordById();

    }
})(angular.module('myvocal.questions'));