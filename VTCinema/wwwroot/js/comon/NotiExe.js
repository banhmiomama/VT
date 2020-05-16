//start notiApp
//var IncommingaudioApp = new Audio('/img/Call/incommingCall.mp3');
function InccomingApp(data) {
    try {

        //IncommingaudioApp.loop = true;
        //IncommingaudioApp.play();
        $('#AppNotiDiv').show();
        $('#AppNotiDiv').attr('data-id', data.ID);
        $('#AppPageName').html(data.TypeName);
        $('#AppRecipientName').html('Khách hàng: ' + data.UserName + ' (' + data.UserPhone + ')');
        $('#AppageNoti').html(data.Message);
        $('#AppPageBranch').html(data.BranchName);

    }
    catch (err) {
        console.log("Sound Error");
    }
}
function AcceptAppNoti() {
    //IncommingaudioApp.pause();
    //IncommingaudioApp.currentTime = 0;
    $('#AppNotiDiv').hide();
    //show
    window.location.href = '/Views/Notification/pageNotificationList.aspx?Value=' + $('#AppNotiDiv').attr('data-id');
    return false;
}
function DeclineApp() {
    //IncommingaudioApp.pause();
    //IncommingaudioApp.currentTime = 0;
    $('#AppNotiDiv').hide();
    return false;
}
function LoadNotiCountUnRead() {
    $.ajax({
        url: "/Views/Notification/pageNotificationList.aspx/LoadNotiReadUnCount",
        dataType: "json",
        type: "POST",
        data: JSON.stringify({}),
        contentType: 'application/json; charset=utf-8',
        async: true,
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            notiError("Lỗi Hệ Thống");
        },
        success: function (result) {
            let data = JSON.parse(result.d)[0];
            if (data.CountUnRead > 0) {
                $('#icon-noti-app1').css('display', 'block');
                $('#icon-noti-app2').css('display', 'block');
                $('#icon-noti-app1').html(data.CountUnRead);
                $('#icon-noti-app2').html(data.CountUnRead);

            } else {
                $('#icon-noti-app1').css('display', 'none');
                $('#icon-noti-app2').css('display', 'none');
            }
        }
    })
}
//end notiapp

//start notiPage
function InccomingPage(pageName, RetName, MessageNoti) {
    try {
        $('#MessPageDiv').show();
        Messagegaudio.loop = true;
        Messagegaudio.play();
        $('#MessPageName').html(pageName);
        $('#MessRecipientName').html('( ' + RetName + ' )');
        $('#MessageNoti').html(MessageNoti);

    }
    catch (err) {
        console.log("Sound Error");
    }
}
function NewMessageFacebook(id, name, text, commment) {
    try {
        if (commment != undefined) {
            $("#NewMessageFacebook_DIV").css("border-top-color", "#21ba45");
            $("#NewMessageFacebook_DIV").css("background-color", "#def8e4");


        }
        else {
            $("#NewMessageFacebook_DIV").css("border-top-color", "#0288d1");
            $("#NewMessageFacebook_DIV").css("background-color", "#e1ecf4");
        }
        document.getElementById("NewMessageFacebook_name").innerHTML = "";
        document.getElementById("NewMessageFacebook_text").innerHTML = "";
        $("#NewMessageFacebook_img").attr("src", "#");
        $('#NewMessageFacebook').show();

        let pic = '//graph.facebook.com/' + id + '/picture?access_token=' + Currenttoken;
        $("#NewMessageFacebook_img").attr("src", pic);
        document.getElementById("NewMessageFacebook_name").innerHTML = name;
        document.getElementById("NewMessageFacebook_text").innerHTML = text.substring(0, 70);
        Messagegaudio.loop = true;
        Messagegaudio.play();

        setTimeout(function () {
            Messagegaudio.pause();
            Messagegaudio.currentTime = 0;
            $('#NewMessageFacebook').hide();
        }, 4000);

    }
    catch (err) {
        console.log("Sound Error");
    }
}

function DeclinePage() {
    Messagegaudio.pause();
    Messagegaudio.currentTime = 0;
    $('#MessPageDiv').hide();
    return false;
}
function AcceptMessPage() {
    Messagegaudio.pause();
    Messagegaudio.currentTime = 0;
    $('#MessPageDiv').hide();
    //show lên trả lời tin
    window.location.href = '/Views/Marketing/pageFacebookChat.aspx?ver=' + versionofWebApplication
    return false;
}




function NotiExe_ToUser(json) {

    let data = JSON.parse(json);
    if (data != undefined ) {
        let empid = data.empid;
        let title = data.title;
        let message = data.message;
        if (Number(empid) == Number(sys_employeeID_Main)) {
            notification_title_message(title, message,10000);
        }

    }

}