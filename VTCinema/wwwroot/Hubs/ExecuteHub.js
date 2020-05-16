$(function () {
    var notificationHubProxy = null;
    if ($.connection != undefined) {
        var chat = $.connection.chatHub;


        $.connection.hub.start().done(function () {
            console.log("started hub");
        }).fail(function (result) {
            console.log(result);
        });
        notificationHubProxy = $.connection.chatHub;


        notificationHubProxy.client.Facebook_PostingFromComment = function (data, commentid) {
            //console.log(data)
            ReceiptCommentFromFace(data, commentid);
        }

        notificationHubProxy.client.Facebook_PostingFromMessage = function (data) {
            ReceiptMessageFromFace(data);
        };
    }
});

