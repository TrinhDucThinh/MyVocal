/// <reference path="E:\Document\Đồ án\Project\Git\MyVocal\MyVocal.Web\Assets/admin/libs/angular/angular.js" />
(function () {
    angular.module('myvocal.subjects', ['myvocal.common']).config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('subjects', {
            url: "/subjects",
            parent: 'base',
            templateUrl: "/app/components/subjects/subjectListView.html",
            controller: "subjectListController"
        }).state('subject_add', {
            url: "/subject_add",
            parent: 'base',
            templateUrl: "/app/components/subjects/subjectAddView.html",
            controller: "subjectAddController"
        });
    }
})();