/// <reference path="E:\Document\Đồ án\Project\Git\MyVocal\MyVocal.Web\Assets/admin/libs/angular/angular.js" />
(function (app) {
    app.controller('subjectGroupAddController', subjectGroupAddController);
    subjectGroupAddController.$inject = ['apiService','$scope','notificationService','$state'];

    function subjectGroupAddController(apiService,$scope,notificationService,$state) {
        $scope.subjectGroup = {
            
        }

        $scope.AddSubjectGroup = AddSubjectGroup;

        function AddSubjectGroup() {
            apiService.post('api/subjectGroup/create', $scope.subjectGroup,
                function (result) {
                    notificationService.displaySuccess(result.data.SubjectGroupName + ' đã được thêm mới thành công.');
                    $state.go('subjectGroups');
                },
                function (error) {
                    notificationService.displayError('Thêm mới không thành công');
                });
        }
    }
})(angular.module('myvocal.subjectGroups'));
