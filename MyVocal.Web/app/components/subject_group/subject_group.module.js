/// <reference path="E:\Document\Đồ án\Project\Git\MyVocal\MyVocal.Web\Assets/admin/libs/angular/angular.js" />
(function () {
    angular.module('myvocal.subjectGroups', ['myvocal.common']).config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('subjectGroups', {
            url: "/subjectGroups",
            parent: 'base',
            templateUrl: "/app/components/subject_group/subject_groupListView.html",
            controller: "subjectGroupListController"
        }).state('subjectGroupAdd', {
            url: "/subjectGroupAdd",
            parent: 'base',
            templateUrl: "/app/components/subject_group/subject_groupAddView.html",
            controller: "subjectGroupAddController"
        }).state('subjectGroupEdit', {
            url: "/subjectGroupEdit/:id",
            parent: 'base',
            templateUrl: "/app/components/subject_group/subject_groupEditView.html",
            controller: "subjectGroupEditController"
        });
    }
})();

