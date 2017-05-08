(function (app) {
    app.controller('questionsEditController', questionsEditController);
    questionsEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams'];

    function questionsEditController(apiService, $scope, notificationService, $state, $stateParams) {

        //Initial $scope variable to save question in View
        $scope.question = {}

        $scope.questionUpdate = questionUpdate;

        function loadQuestionDetail() {
            apiService.get('api/question/getbyid/' + $stateParams.id, null, function (result) {
                $scope.question = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        function questionUpdate() {
            apiService.put('api/question/update', $scope.question,
                function (result) {
                    notificationService.displaySuccess(result.data.QuestionId + ' đã được cập nhật thành công.');
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
        loadQuestionDetail();

    }
})(angular.module('myvocal.questions'));