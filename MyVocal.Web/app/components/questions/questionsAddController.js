/// <reference path="E:\Document\Đồ án\Project\Git\MyVocal\MyVocal.Web\Assets/admin/libs/angular/angular.js" />
(function (app) {
    app.controller('questionsAddController', questionsAddController);
    questionsAddController.$inject = ['apiService','$scope','notificationService','$state'];

    function questionsAddController(apiService,$scope,notificationService,$state) {
        //variable question scope is Model
        $scope.question = {}
        
        //variable quesion scope subjectId
        $scope.subjectId = '';

        //function add question
        $scope.questionAdd = questionAdd;

        function questionAdd() {
            apiService.post('api/question/create',$scope.question,
                function (result) {
                    notificationService.displaySuccess(result.data.QuestionId + ' đã được thêm mới thành công.');
                    $state.go('questions');
                },
                function (error) {
                    notificationService.displayError('Thêm mới không thành công');
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
        $scope.hasChanged = function () {
            loadWords($scope.subjectId);
        }
        //function to load question category
        function loadQuestionCategories() {
            apiService.get('api/questionCategory/getAllQuestion', null, function (result) {
                $scope.questionCategories = result.data;
                
            }, function () {
                console.log('Cannot get list parent');
            });
        }
        
        //function to load all word
        function loadWords(subjectId) {
            apiService.get('api/word/getAllBySubjectId/' + subjectId, null, function (result) {
                $scope.words = result.data;

            }, function () {
                console.log('Cannot get list parent');
            });
        }

        loadQuestionCategories();
        loadWords(1);
        loadSubjects();
    }
})(angular.module('myvocal.questions'));