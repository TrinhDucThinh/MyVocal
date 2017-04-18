var topicConfig = {
    pageSize: 8,
    pageIndex:1,
    location: window.location.origin
}

var topicController = {

    init: function () {
        topicController.loadData();
    },

    loadData: function (changePageSize) {
        $.ajax({
            url: '/Topic/LoadAllTopic',
            type: 'GET',
            dataType:'json',
            data: {
                groupId: 8,
                pageIndex: topicConfig.pageIndex,
                pageSize: topicConfig.pageSize
            },
            success: function (response) {
                if (response.status) {
                    var data = response.data;
                    var html = '';
                    var template = $('#listTopic-template').html();    
                    $.each(data, function (i, item) {
                       
                        html += Mustache.render(template,{
                            image: location.origin +'/'+ item.Image,
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