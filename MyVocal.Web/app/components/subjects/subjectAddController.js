/// <reference path="E:\Document\Đồ án\Project\Git\MyVocal\MyVocal.Web\Assets/admin/libs/angular/angular.js" />
(function (app) {
    app.controller('subjectAddController', subjectAddController);
    subjectAddController.$inject = ['apiService', '$scope', 'notificationService', '$state'];

    function subjectAddController(apiService, $scope, notificationService, $state) {
        $scope.word = {

        }

        $scope.AddSubject = AddSubject;

        function AddSubject() {
            apiService.post('api/subject/create', $scope.subject,
                function (result) {
                    notificationService.displaySuccess(result.datasubjectName + ' đã được thêm mới thành công.');
                    $state.go('subjects');
                },
                function (error) {
                    notificationService.displayError('Thêm mới không thành công');
                });
        }

        function loadSubjetGroup() {

            apiService.get('api/subjectGroup/getAllForSubject', null, function (result) {
                $scope.subjectGroups = result.data;
            }, function () {
                console.log('Cannot get list parent');
            });
        }

        loadSubjetGroup();
       
    }
})(angular.module('myvocal.subjects'));