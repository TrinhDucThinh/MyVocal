 /// <reference path="E:\Document\Đồ án\Project\Git\MyVocal\MyVocal.Web\Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('myvocal',
        ['myvocal.wordCategories',
        'myvocal.words',
        'myvocal.subjects',
        'myvocal.subjectGroups',
        'myvocal.semantics',
        'myvocal.questions',
        'myvocal.questionCategories',
        'myvocal.common'
        ]).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('home', {
            url: "/admin",
            templateUrl: "/app/components/home/homeView.html",
            controller: "homeController"
        });
        $urlRouterProvider.otherwise('/admin');
    }
})();
