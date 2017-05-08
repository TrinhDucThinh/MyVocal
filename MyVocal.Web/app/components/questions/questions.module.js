/// <reference path="E:\Document\Đồ án\Project\Git\MyVocal\MyVocal.Web\Assets/admin/libs/angular/angular.js" />
(function () {
    angular.module('myvocal.question', ['myvocal.common']).config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('questions', {
            url: "/questions",
            templateUrl: "/app/components/questions/questionsListView.html",
            controller: "questionsListController"
        }).state('questionAdd', {
            url: "/questionAdd",
            templateUrl: "/app/components/questions/questionsAddView.html",
            controller: "questionsAddController"
        });
    }
})();