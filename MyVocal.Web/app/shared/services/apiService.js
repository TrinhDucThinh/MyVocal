﻿/// <reference path="E:\Document\Đồ án\Project\Git\MyVocal\MyVocal.Web\Assets/admin/libs/angular/angular.js" />

(function (app) {
    app.factory('apiService', apiService);
    apiService.$inject = ['$http'];
    function apiService($http) {
        return {
            get:get
        }

        function get(url, params,success,failure) {
            $http.get(url, params).then(function (result) {
                success(result);
            }, function (error) {
                failure(error);
            });
        }
    }
})(angular.module('myvocal.common'));