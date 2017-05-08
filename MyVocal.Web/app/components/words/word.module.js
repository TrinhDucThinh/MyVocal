/// <reference path="E:\Document\Đồ án\Project\Git\MyVocal\MyVocal.Web\Assets/admin/libs/angular/angular.js" />
(function () {
    angular.module('myvocal.words', ['myvocal.common']).config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('words', {
            url: "/words",
            templateUrl: "/app/components/words/wordListView.html",
            controller: "wordListController"
        }).state('add_word', {
            url: "/add_word",
            templateUrl: "/app/components/words/wordAddView.html",
            controller: "wordAddController"
        }).state('edit_word', {
            url: "/edit_word/:id",
            templateUrl: "/app/components/words/wordEditView.html",
            controller: "wordEditController"
        });
    }
})();