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
        }).state('subjectAdd', {
            url: "/subjectAdd",
            parent: 'base',
            templateUrl: "/app/components/subjects/subjectAddView.html",
            controller: "subjectAddController"
        }).state('subjectEdit', {
            url: "/subjectEdit/:id",
            parent: 'base',
            templateUrl: "/app/components/subjects/subjectEditView.html",
            controller: "subjectEditController"
        });
    }
})();