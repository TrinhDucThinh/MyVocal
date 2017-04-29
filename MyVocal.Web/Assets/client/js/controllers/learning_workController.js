var wordConfig = {
    index: 1,
    strTest:'',
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
            $('.carousel').carousel({
                interval: 1200000
            })
        })

        //$.ajax({
        //    url: '/Word/ListAllBySubjectId',
        //    type: 'GET',
        //    dataType: 'json',
        //    data: {
        //        subjectId: 8,
        //    },
        //    success: function (response) {
        //        if (response.status) {
        //            var data = response.data;
        //            var html = '';
        //            var template = $('#listWord-template').html();
        //            $.each(data, function (i, item) {
        //                if (i == 0) {
        //                    html += Mustache.render(template, {
        //                        Id:i+1,
        //                        Active: 'active',
        //                        WordName: item.WordName,
        //                        Image: location.origin + '/' + item.Image,
        //                        Defination: item.Defination,
        //                        Meaning: item.Meaning,
        //                        Transcription: item.Transcription,
        //                        Sound: wordConfig.path + '' + item.Sound,
        //                        SoundExample: wordConfig.path + '' + item.SoundExample,
        //                        Example: item.Example,
        //                        ExampleTranslation: item.ExampleTranslation
        //                    });
        //                }else
        //                    html += Mustache.render(template, {
        //                    Id:i+1,
        //                    Active:'panel',
        //                    WordName:item.WordName,
        //                    Image: location.origin + '/' + item.Image,
        //                    Defination: item.Defination,
        //                    Meaning: item.Meaning,
        //                    Transcription: item.Transcription,
        //                    Sound: wordConfig.path + '' + item.Sound,
        //                    SoundExample: wordConfig.path + '' + item.SoundExample,
        //                    Example: item.Example,
        //                    ExampleTranslation: item.ExampleTranslation
        //                });
        //            });
        //            $('#listword').html(html);
        //        }
        //    },
        //    error: function (error) {
        //        console.log(error);
        //    }
        //});
    },

    //Catch and process event
    registerEvent: function () {
       
        $('#next').click(function () {

            if (wordConfig.index == 20) {
                $('#p' + wordConfig.index).slideUp("4000").removeClass("active");
                wordConfig.index = 1;
                $('#p' + wordConfig.index).slideDown("4000").addClass("active");

            } else {
                $('#p' + wordConfig.index).slideUp("slow").removeClass("active");
                wordConfig.index++;
                $('#p' + wordConfig.index).slideDown("slow").addClass("active");
            }

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

        $('.item .child1').each(function () {
            $(this).click(function () {
                $(this).hide();
                $(this).parent('.item').find('.child2').fadeIn("4000");
                $(this).parent('.item').find('.child3').hide();
            });
        });
        $('.item .child2').each(function () {
            $(this).click(function () {
                $(this).hide();
                $(this).parent('.item').find('.child3').fadeIn("4000");
                $(this).parent('.item').find('.child1').hide();
            });
        });
        $('.item .child3').each(function () {
            $(this).click(function () {
                $(this).hide();
                $(this).parent('.item').find('.child1').fadeIn("4000");
                $(this).parent('.item').find('.child2').hide();
            });
        });

        $('.btn-learning-check').click(function () {
            var answer = $('.item.active').data('word');
            var userAnswer = $('.learning-fill-word').val();
            //$('.item.active audio').play();
            $('.item.active audio').trigger('play');
            if (answer.toString().toLowerCase == userAnswer.toLowerCase) {
               
                $('.learning-right-group').addClass('displayNoti');
            } else {
                alert('false');
                $('.learning-wrong-group').addClass('displayNoti');
            }
        });
    }
}

wordController.init();
