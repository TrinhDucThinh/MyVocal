var wordConfig = {
    index: 1,
    strTest: '',
    path: 'https://drive.google.com/uc?id=',
    location: window.location.origin
}
var wordController = {
    init: function () {

        wordController.loadData();
        wordController.registerEvent();
    },
    //Load data for list word of topic anything
    loadData: function () {
        $(document).ready(function () {
            $('.sidebar-mini').addClass('sidebar-collapse');
            $('.carousel').carousel({
                interval: 1200000
            })
        })
        var subjectId = $('#TopicId').val();
        $.ajax({
            url: '/Topic/ListAllBySubjectId',
            type: 'GET',
            dataType: 'json',
            data: {
                subjectId: subjectId,
            },
            success: function (response) {
                if (response.status) {
                    var data = response.data;
                    var html = '';
                    var template = $('#listWord-template').html();
                    $.each(data, function (i, item) {
                        if (i == 0) {
                            html += Mustache.render(template, {
                                Id: i + 1,
                                Active: 'active',
                                WordName: item.WordName,
                                Image: location.origin + '/' + item.Image,
                                Defination: item.Defination,
                                Meaning: item.Meaning,
                                Transcription: item.Transcription,
                                Sound: wordConfig.path + '' + item.Sound,
                                SoundExample: wordConfig.path + '' + item.SoundExample,
                                Example: item.Example,
                                ExampleTranslation: item.ExampleTranslation
                            });
                        } else
                            html += Mustache.render(template, {
                                Id: i + 1,
                                Active: 'panel',
                                WordName: item.WordName,
                                Image: location.origin + '/' + item.Image,
                                Defination: item.Defination,
                                Meaning: item.Meaning,
                                Transcription: item.Transcription,
                                Sound: wordConfig.path + '' + item.Sound,
                                SoundExample: wordConfig.path + '' + item.SoundExample,
                                Example: item.Example,
                                ExampleTranslation: item.ExampleTranslation
                            });
                    });
                    $('#listword').html(html);
                    //Must be call registerEvent after
                    wordController.registerEvent();
                }
            },
            error: function (error) {
                console.log(error);
            }
        });
    },

    //Catch and process event
    registerEvent: function () {
        //When next Slide
        $('#next').click(function () {
            wordController.refreshResult();
            if (wordConfig.index == 20) {
               
                $('#p' + wordConfig.index).slideUp("4000").removeClass("active");
                wordConfig.index = 1;
                $('#p' + wordConfig.index).slideDown("4000").addClass("active");

            } else {
                
                $('#p' + wordConfig.index).slideUp("slow").removeClass("active");
                wordConfig.index++;
                
                $('#p' + wordConfig.index).slideDown("slow").addClass("active");
               
            }
            wordController.fireSound('#audioSound');
        });
        $('#prev').click(function () {

            if (wordConfig.index == 1) {
                $('#p' + wordConfig.index).slideUp("4000").removeClass("active");
                wordConfig.index = 20;
                $('#p' + wordConfig.index).slideDown("4000").addClass("active");

            } else {
                $('#p' + wordConfig.index).slideUp("slow").removeClass("active");
                wordConfig.index--;
                $('#p' + wordConfig.index).slideDown("slow").addClass("active");
            }

        });
        //When click child1
        $('body .item .child1').each(function () {
            $(this).click(function () {
                wordController.fireSound('#audioSound');
                $(this).hide();
                $(this).parent('.item').find('.child2').fadeIn("4000");
                $(this).parent('.item').find('.child3').hide();
            });
        });
        $('body .item .child2').each(function () {
            $(this).click(function () {
                wordController.fireSound('#audioSound');
                $(this).hide();
                $(this).parent('.item').find('.child3').fadeIn("4000");
                $(this).parent('.item').find('.child1').hide();
            });
        });
        $('body .item .child3').each(function () {
            $(this).click(function () {
                wordController.fireSound('#audioSound');
                $(this).hide();
                $(this).parent('.item').find('.child1').fadeIn("4000");
                $(this).parent('.item').find('.child2').hide();
            });
        });
       
        //when enter
        $('.learning-fill-word').on("keydown", function (event) {
            if (event.which == 13) {
                var answer = $('.item.active').data('word').toLowerCase();
                var userAnswer = $('.learning-fill-word').val().toString().toLowerCase();
                //$('.item.active audio').play();
                //$('.item.active #audioSound').trigger('play');
                wordController.fireSound('#audioSound');
                var result = answer.localeCompare(userAnswer);
                if (result == 0) {
                    $('.learning-wrong-group').removeClass('displayNoti');
                    $('.learning-right-group').addClass('displayNoti');
                } else {
                    $('.learning-right-group').removeClass('displayNoti');
                    $('.learning-wrong-group').addClass('displayNoti');
                }
            }
        });

        //when check result input
        $('.btn-learning-check').click(function () {
            var answer = $('.item.active').data('word').toLowerCase();
            var userAnswer = $('.learning-fill-word').val().toString().toLowerCase();
            //$('.item.active audio').play();
            //$('.item.active #audioSound').trigger('play');
            wordController.fireSound('#audioSound');
            var result = answer.localeCompare(userAnswer);
            if (result == 0) {
                $('.learning-wrong-group').removeClass('displayNoti');
                $('.learning-right-group').addClass('displayNoti');
            } else {
                $('.learning-right-group').removeClass('displayNoti');
                $('.learning-wrong-group').addClass('displayNoti');
            }
        });
        //when click 
    },

    fireSound: function (TagId) {
        var soundID = '.item.active ' + TagId;
        $(soundID).trigger('play');
    },
    refreshResult: function () {
        $('.learning-fill-word').val('');
        $('.learning-right-group').removeClass('displayNoti');
        $('.learning-wrong-group').removeClass('displayNoti');
    }
}

wordController.init();
