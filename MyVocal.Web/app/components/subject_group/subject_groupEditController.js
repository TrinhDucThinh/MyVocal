/// <reference path="E:\Document\Đồ án\Project\Git\MyVocal\MyVocal.Web\Assets/admin/libs/angular/angular.js" />
(function (app) {
    app.controller('subjectGroupEditController', subjectGroupEditController);
    subjectGroupEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams'];

    function subjectGroupEditController(apiService, $scope, notificationService, $state, $stateParams) {

        //Initial $scope variable to save wordCategory in View
        $scope.subjetGroup = {

        }
        //update
        $scope.subjectGroupUpdate = subjectGroupUpdate;

        function subjectGroupUpdate() {
            apiService.put('api/subjectGroup/update', $scope.subjetGroup,
                function (result) {
                    notificationService.displaySuccess(result.data.SubjectGroupName + ' đã được cập nhật thành công.');
                    $state.go('subjectGroups');
                },
                function (error) {
                    notificationService.displayError('Thêm mới không thành công');
                });
        }
    
        //Load detail
        function loadSubjectGroupDetail() {
            apiService.get('api/subjectGroup/getbyid/' + $stateParams.id, null, function (result) {
                $scope.subjectGroup = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

       
        loadSubjectGroupDetail();

    }
})(angular.module('myvocal.subjectGroups'));


