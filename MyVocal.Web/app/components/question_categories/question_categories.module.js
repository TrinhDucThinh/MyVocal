(function () {
    angular.module('myvocal.questionCategories', ['myvocal.common']).config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('questionCategories', {
            url: "/questionCategories",
            parent: 'base',
            templateUrl: "/app/components/question_categories/question_categoriesListView.html",
            controller: "questionCategoriesListController"
        }).state('questionCategoriesAdd', {
            url: "/questionCategoriesAdd",
            parent: 'base',
            templateUrl: "/app/components/question_categories/question_categoriesAddView.html",
            controller: "questionCategoriesAddController"
        }).state('questionCategoriesEdit', {
            url: "/questionCategoriesEidt/:id",
            parent: 'base',
            templateUrl: "/app/components/question_categories/question_categoriesEditView.html",
            controller: "questionCategoriesEditController"
        });
    }
})();