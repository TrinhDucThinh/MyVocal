/// <reference path="E:\Document\DoAn\Project\Git\MyVocal\MyVocal.Web\Assets/admin/libs/angular/angular.js" />

//(function (app) {
//    app.controller('oxfordDictionaryController', oxfordDictionaryController);
//    oxfordDictionaryController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox'];
//    function oxfordDictionaryController($scope, apiService, notificationService, $ngBootbox) {
//        $scope.word_id='teacher';
//        $scope.language = 'en';

//        function search() {
//            alert('hello');
//        }
//        function getWordOxford() {
//            var config = {
//                params: {
//                    word_id: $scope.word_id,
//                    'app_id': app_id, 
//                    'app_key': app_key
//                }
//            }
//            apiService.get('https://od-api.oxforddictionaries.com/api/v1/entries/' + $scope.language + '/' + $scope.word_id, config,
//                function (result) {
//                    if (result.data.TotalCount == 0) {
//                        notificationService.displayWarning('Không có bản ghi nào được tìm thấy.');
//                    } else {
//                        notificationService.displaySuccess('Đã tìm thấy ' + result.data.TotalCount + ' bản ghi.');
//                    }
                     
//                },function () {
//                console.log('Load word categories failure');
//            });
//        }
//    }
//})(angular.module('myvocal.oxfordDictionary'));

(function (app) {
    app.controller('oxfordDictionaryController', oxfordDictionaryController);
    oxfordDictionaryController.$inject = ['$scope', '$http'];
    function oxfordDictionaryController($scope, $http) {
        $scope.getWord = getWord;
        $scope.keyword = 'test';
       
        function getWord() {
           
            //$http.get('https://od-api.oxforddictionaries.com/api/v1/entries/en/'+$scope.keyword, {
            //    headers: {
            //        'app_id': '5a70d539',
            //        'app_key': 'b51d905b4ce6338773c9839def5b4121',
            //        'Access-Control-Allow-Credentials':'true'
            //    }
            //}).then(function (success) {
            //        alert('succes');
            //    })
            //    , function (error) {
            //        alert('error');
            //    };
            $.ajax({
                url: "https://od-api.oxforddictionaries.com/api/v1/entries/en/test",
                headers: { 'app_id':'5a70d539','app_key':'b51d905b4ce6338773c9839def5b4121','Access-Control-Allow-Origin':'true' },
                type: "GET",
                success: function (result) { 
                    var test=result.results[0].lexicalEntries[0].lexicalCategory; 
                    alert(test);
						
                },
                error: function (error) { alert('err'); },

            });
        }
        
        
        

            //$.ajax({
            //    url: "https://od-api.oxforddictionaries.com/api/v1/entries/en/test",
            //    //data: { signature: authHeader },
            //    type: "GET",
            //    headers:{
            //        'app_id':'5a70d539',
            //        'app_key':'b51d905b4ce6338773c9839def5b4121',
            //        'Access-Control-Allow-Origin':'true'
            //    },
            //    success: function () { alert('Success!' ); },
            //    error: function (error) { alert(error); },

            //});
        

        //page = page || 0;
        //var config = {
        //    params: {
        //        app_id: '5a70d539',
        //        app_key: '6ae543f75099b7e7b2c43ba414003b24'
        //    }
        //}
        //apiService.get('https://od-api.oxforddictionaries.com/api/v1/entries/en/teacher', config, {
        //    function (result) {
        //        alert("success");
        //    },function () {
        //        alert('error');
        //    }
        //});   
    }
})(angular.module('myvocal.oxfordDictionary'));