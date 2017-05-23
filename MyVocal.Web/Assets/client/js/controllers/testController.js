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

    //load data len view
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

            }, 15000);
        })
    },

    //register all event
    registerEvent: function () {

        //When click into a answer
         $('.select-vocabulary').each(function () {
            $(this).find('.btn-check-test').click(function () {
                var txt = $(this).text();
               // alert(txt);
                testController.nextSlide();
            });
        //when user click kiemTra button
            var userAnswer=$(this).find('.txt-check');

            $(this).find('.btn-check').click(function () {
               // alert(userAnswer.val());
                testController.nextSlide();
            });
        //when user press enter
            $(this).find('.txt-check').on("keydown", function (event) {
                if (event.which == 13)
                   // alert(userAnswer.val());
                testController.nextSlide();
            });
        });
    },

    //play video with source is tagId
    fireSound: function (TagId) {
        var soundID = TagId;
        $(soundID).trigger('play');
    },

    nextSlide: function () {
        if (testConfig.index < 20) {
            $('.layer#item' + testConfig.index).removeClass('show');
            testConfig.index++;
            $('.layer#item' + testConfig.index).addClass('show');
        }
    }
}
testController.init();
