var testConfig = {
    index: 1,
    strTest: '',
    path: 'https://drive.google.com/uc?id=',
    location: window.location.origin
}
var testController = {
    init: function () {
        setInterval(testController.fireSound('#tick'), 1000);
        testController.loadData();
        testController.registerEvent();
    },

    loadData: function () {
        $(document).ready(function () {
            var intervalTick = window.setInterval(function () {
                $('#tick').trigger('play');
                $('#tick').stop();
            }, 1000);

            window.setInterval(function () {
                if (testConfig.index < 20) {
                    $('.layer#item' + testConfig.index).removeClass('show');
                    testConfig.index++;
                    $('.layer#item' + testConfig.index).addClass('show');
                    $('#tick').src = "";

                }
                else {
                    clearInterval(intervalTick);
                }

            }, 200000);
        })
    },
    registerEvent: function () {
         $('.select-vocabulary').each(function () {
            $(this).find('.btn-check-test').click(function () {
                var txt = $(this).text();
                alert(txt);
            });
            
            var userAswer=$(this).find('.txt-check').html();

            $(this).find('.btn-check').click(function () {
                alert(userAswer);
            });

        });
    },
    fireSound: function (TagId) {
        var soundID = TagId;
        $(soundID).trigger('play');
    },
}
testController.init();
