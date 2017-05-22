var topicConfig = {
    pageSize: 8,
    pageIndex:1,
    location: window.location.origin,
    groupId: $('#groupId').val(),
    userId: $('#userId').val()
}
var topicController = {

    init: function () {
        topicController.loadData();
    },

    loadData: function (changePageSize) {
        alert(topicConfig.userId);
        $.ajax({
            url: '/Topic/LoadAllTopic',
            type: 'GET',
            dataType:'json',
            data: {
                groupId: topicConfig.groupId,
                pageIndex: topicConfig.pageIndex,
                pageSize: topicConfig.pageSize
            },
            success: function (response) {
                if (response.status) {
                    var data = response.data;
                    var html = '';
                    var templateLearn = $('#listTopic-template').html();
                    var templateNotLearn = $('#listTopic-templateNo').html();
                    $.each(data, function (i, item) {
                      
                        if (item.isLearn) {
                            html += Mustache.render(templateLearn, {
                                link: location.origin + '/chu-de/hoc-chu-de?Id=' + item.SubjectId,
                                linkTest: location.origin + '/chu-de/kiem-tra-chu-de?Id=' + item.SubjectId,
                                image: location.origin + '/' + item.Image,
                                subjectName: item.SubjectName,
                                description: item.Description
                            });
                        }else
                            html += Mustache.render(templateNotLearn, {
                                link: location.origin + '/chu-de/hoc-chu-de?Id=' + item.SubjectId,  
                                image: location.origin + '/' + item.Image,
                                subjectName: item.SubjectName,
                                description: item.Description
                            });

                    });
                    $('#topicList').html(html);
                }
            },
            error: function (error) {
                console.log(error);
            }
        });
    },

}

topicController.init();