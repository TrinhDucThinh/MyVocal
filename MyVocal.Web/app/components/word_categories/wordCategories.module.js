/// <reference path="E:\Document\Đồ án\Project\Git\MyVocal\MyVocal.Web\Assets/admin/libs/angular/angular.js" />
(function () {
    angular.module('myvocal.word_categories', ['myvocal.common']).config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('word_categories', {
            url: "/word_categories",
            templateUrl: "/app/components/word_categories/wordCategoriesListView.html",
            controller: "wordCategoriesListController"
        }).state('word_categories_add', {
            url: "/word_categories_add",
            templateUrl: "/app/components/word_categories/wordCategoryAddView.html",
            controller: "wordCategoriesAddController"
        });
    }
})();