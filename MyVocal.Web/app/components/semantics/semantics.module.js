/// <reference path="E:\Document\Đồ án\Project\Git\MyVocal\MyVocal.Web\Assets/admin/libs/angular/angular.js" />
(function () {
    angular.module('myvocal.semantics', ['myvocal.common']).config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('semantics', {
            url: "/semantics",
            templateUrl: "/app/components/semantics/semanticsListView.html",
            controller: "semanticsListController"
        }).state('semantics_add', {
            url: "/semantics_add",
            templateUrl: "/app/components/semantics/semanticsAddView.html",
            controller: "semanticsAddController"
        });
    }
})();