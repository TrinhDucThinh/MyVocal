/// <reference path="E:\Document\Đồ án\Project\Git\MyVocal\MyVocal.Web\Assets/admin/libs/angular/angular.js" />
(function (app) {
    app.controller('questionsAddController', questionsAddController);
    questionsAddController.$inject = ['apiService','$scope','notificationService','$state'];

    function questionsAddController(apiService,$scope,notificationService,$state) {
        $scope.question = {
           
            
        }

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

        function loadQuestionCategories() {
            apiService.get('api/questionCategory/getAllQuestion', null, function (result) {
                $scope.questionCategories = result.data;
                
            }, function () {
                console.log('Cannot get list parent');
            });
        }
        
        function loadWords() {
            apiService.get('api/word/getAll', null, function (result) {
                $scope.words = result.data;

            }, function () {
                console.log('Cannot get list parent');
            });
        }
        loadQuestionCategories();
        loadWords();
    }
})(angular.module('myvocal.question'));