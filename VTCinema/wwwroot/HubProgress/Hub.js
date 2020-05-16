$(function () {
    var notificationHubProxy = $.connection.Hub;
    notificationHubProxy.client.connection = function () {
    };
    SJ.iwc.SignalR.start().done(function () {
    });
    // To User
    notificationHubProxy.client.SendMessageClient_ToUser = function (jsonString) {
        HubExecute_ToUser(jsonString);
    };
    // From App
    notificationHubProxy.client.SendMessageClient_From_App = function (jsonString) {
        HubExecute_FromAapp(jsonString);
    };

    // From Face
    notificationHubProxy.client.ReceiptMessageFromFace = function (jsonString) {
        if (typeof ReceiptMessageFromFace == 'function' && $.isFunction(ReceiptMessageFromFace)) {
            ReceiptMessageFromFace(jsonString);
        }
    };
    notificationHubProxy.client.ReceiptCommentFromFace = function (jsonString, commentid) {
        if (typeof ReceiptCommentFromFace == 'function' && $.isFunction(ReceiptCommentFromFace)) {
            ReceiptCommentFromFace(jsonString, commentid);
        }
    };
    //Notier

    notificationHubProxy.client.Send_Notier_Client = function (jsonString) {
        Notier.notify(0, JSON.parse(jsonString));
    };
});


/////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////
// #region // To User
function HubExecute_ToUser(pram) {
    NotiExe_ToUser(pram);
}
// #endregion
/////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////
// #region // From App
function HubExecute_FromAapp(pram) {
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
}
function NoticeApp(Page) {

}
function NoticeEntirePageApp(data) {
    //If the account is authorized fanpage
    InccomingApp(data);
    // if settings for notifications = true
    setTimeout(function () {
        DeclineApp();
    }, 10000);
}
// #endregion
/////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////
