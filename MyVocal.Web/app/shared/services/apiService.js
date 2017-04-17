/// <reference path="E:\Document\Đồ án\Project\Git\MyVocal\MyVocal.Web\Assets/admin/libs/angular/angular.js" />

(function (app) {
    app.factory('apiService', apiService);
    apiService.$inject = ['$http','notificationService'];
    function apiService($http,notificationService) {
        return {
            get: get,
            post: post,
            del: del
        }

        function post(url, data, success, failure) {
            $http.post(url, data).then(function (result) {
                success(result);
            },
            function (error) {
                if (error.status === 401) {
                    notificationService.displayError('Bạn cần đăng nhập để sử dụng chức năng này');
                } else if (failure != null) {
                    failure(error);
                }
            });
        }

        function del(url, data, success, failure) {
            $http.post(url, data).then(function (result) {
                success(result);
            },
            function (error) {
                if (error.status === 401) {
                    notificationService.displayError('Bạn cần đăng nhập để sử dụng chức năng này');
                } else if (failure != null) {
                    failure(error);
                }
            });
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