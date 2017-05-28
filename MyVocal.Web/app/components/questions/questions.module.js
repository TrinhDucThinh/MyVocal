/// <reference path="E:\Document\Đồ án\Project\Git\MyVocal\MyVocal.Web\Assets/admin/libs/angular/angular.js" />
(function () {
    angular.module('myvocal.questions', ['myvocal.common']).config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('questions', {
                url: "/questions",
                parent: 'base',
                templateUrl: "/app/components/questions/questionsListView.html",
                controller: "questionsListController"
            })
            .state('questionAdd', {
                url: "/questionAdd/:subjectId/:wordId",
                parent: 'base',
                templateUrl: "/app/components/questions/questionsAddView.html",
                controller: "questionsAddController"
            })
            .state('questionEdit', {
                url: "/questionEdit/:id",
                parent: 'base',
                templateUrl: "/app/components/questions/questionsEditView.html",
                controller: "questionsEditController"
            });
    }
})();