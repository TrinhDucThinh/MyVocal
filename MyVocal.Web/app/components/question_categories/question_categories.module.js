/// <reference path="E:\Document\Đồ án\Project\Git\MyVocal\MyVocal.Web\Assets/admin/libs/angular/angular.js" />
(function () {
    angular.module('myvocal.questionCategories', ['myvocal.common']).config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('question_categories', {
            url: "/question_categories",
            parent: 'base',
            templateUrl: "/app/components/question_categories/question_categoriesListView.html",
            controller: "question_categoriesListController"
        }).state('question_categories_add', {
            url: "/question_categories_add",
            parent: 'base',
            templateUrl: "/app/components/question_categories/question_categoriesAddView.html",
            controller: "question_categoriesAddController"
        });
    }
})();