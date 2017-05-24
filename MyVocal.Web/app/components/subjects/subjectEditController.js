/// <reference path="E:\Document\Đồ án\Project\Git\MyVocal\MyVocal.Web\Assets/admin/libs/angular/angular.js" />
(function (app) {
    app.controller('subjectEditController', subjectEditController);
    subjectEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams'];

    function subjectEditController(apiService, $scope, notificationService, $state, $stateParams) {

        //Initial $scope variable to save wordCategory in View
        $scope.subject = {

        }

        $scope.subjectUpdate = subjectUpdate;
        function subjectUpdate() {
            apiService.put('api/subject/update', $scope.subject,
                function (result) {
                    notificationService.displaySuccess(result.data.SubjectName + ' đã được cập nhật thành công.');
                    $state.go('subjects');
                },
                function (error) {
                    notificationService.displayError('Thêm mới không thành công');
                });
        }
        function loadWordDetail() {
            apiService.get('api/subject/getbyid/' + $stateParams.id, null, function (result) {
                $scope.subject = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
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
        loadWordDetail();
    }
})(angular.module('myvocal.subjects'));