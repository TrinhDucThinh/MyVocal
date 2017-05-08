/// <reference path="E:\Document\Đồ án\Project\Git\MyVocal\MyVocal.Web\Assets/admin/libs/angular/angular.js" />
(function () {
    angular.module('myvocal.wordCategories', ['myvocal.common']).config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('word_categories', {
            url: "/word_categories",
            templateUrl: "/app/components/word_categories/wordCategoriesListView.html",
            controller: "wordCategoriesListController"
        })
            .state('add_word_categories', {
            url: "/word_categories_add",
            templateUrl: "/app/components/word_categories/wordCategoryAddView.html",
            controller: "wordCategoriesAddController"
        })
            .state('edit_word_categories', {
            url: "/edit_word_categories_add/:id",
            templateUrl: "/app/components/word_categories/wordCategoryEditView.html",
            controller: "wordCategoriesEditController"
        });
    }
})();