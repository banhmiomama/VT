$(function () {
    var notificationHubProxy = null;

    if ($.connection != undefined) {
        debugger
        var App = $.connection.AppHub;
        //$.connection.hub.start().done(function () {
        //    //$('#btnSend').click(function () {
        //    //    App.server.send($('#name').val(), $('#txtMessage').val());
        //    //    // $('#txtMessage').val('').foucs();
        //    //});
        //    App.server.send("aaaaaaa","asdasd");

        //});
        $.connection.hub.start().done(function () {
            console.log("started hub App");
        }).fail(function (result) {
            console.log(result);
        });
        notificationHubProxy = $.connection.AppHub;

        notificationHubProxy.client.hello = function (pram) {
            console.log(pram);
            debugger
            LoadNotiCountUnRead();
            let data = JSON.parse(pram);
            //param API response
            let nameRecipient = data.UserID;
            let CustomerID = data.CustomerID;
            let nameType = data.TypeName;
            let messageNoti = data.Message;
            let type = data.Type;
            let id = data.ID;
            let branch = data.BranchName;
            //split listPermission
            let listPermission = _PermissionClientApp.split(',');
            //end param API response
            let isPage = window.location.pathname;

            // Nếu không ở tap App
            if (listPermission[Number(type - 1)] == '1') {
                if (isPage != '/Views/Notification/pageNotificationList.aspx') {
                    NoticeEntirePageApp(data);
                } else {
                    NoticeApp('');
                }
            }
            // load data : argument ?
        };
        App.client.broadcastMessage = function (name, message) {
            alert(name + message);
        };
        //App.client.send = function (name,message) {
        //    alert(message)

        //};
    }
});


