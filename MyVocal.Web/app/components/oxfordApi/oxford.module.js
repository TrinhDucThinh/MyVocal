(function () {
    angular.module('myvocal.oxfordDictionary', ['myvocal.common']).config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('oxfordDictionary', {
            url: "/oxfordDictionary",
            parent: 'base',
            templateUrl: "/app/components/oxfordApi/getWordView.html",
            controller: "oxfordDictionaryController"
        })
    }
})();

