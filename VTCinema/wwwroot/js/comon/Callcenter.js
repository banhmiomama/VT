// #region  Callcenter

function ReceiptIncommingCall(header, headername) {
    let phonenumber = '';
    let name = '';
    if (headername != "0") {
        phonenumber = headername;
    }
    else {
        let resdouble = header.split(":");
        let res = resdouble[1].split("@");
        phonenumber = res[0];

    }

    $.ajax({
        url: "/Views/Call/pageIncomingCall.aspx/Loadata",
        dataType: "json",
        type: "POST",
        data: JSON.stringify({ 'Phone': phonenumber }),
        contentType: 'application/json; charset=utf-8',
        async: true,
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            notiError();
        },
        success: function (result) {
            if (result.d != "0") {
                let data = JSON.parse(result.d)
                name = data[0].Name;
                document.getElementById("incommingName").innerHTML = name;
                document.getElementById("incommingPhone").innerHTML = phonenumber;
                $('#incomingCallCustomer').attr('src', 'data:image/png;base64, ' + data[0].Image);
            } else {
                name = 'unknown';
                document.getElementById("incommingName").innerHTML = name;
                document.getElementById("incommingPhone").innerHTML = phonenumber;
                let _defaultImage = "<%=_defaultImage %>";
                $('#incomingCallCustomer').attr('src', 'data:image/png;base64, ' + _defaultImage);
            }

        }
    });

}
function DeclineIncommingCall() {
    Incommingaudio.pause();
    Incommingaudio.currentTime = 0;
    Callinghangup();
    $('#IncommingCallDiv').hide();
    $('#divDetailPopupCall').modal('hide');
    document.getElementById("divDetailPopupCall").innerHTML = '';
    return false;
}
function FailIncommingCall(phonenumber) {

    if (Incommingaudio != undefined && Incommingaudio != null) {
        Incommingaudio.pause();
        Incommingaudio.currentTime = 0;
    }
    $('#IncommingCallDiv').hide();
    $('#divDetailPopupCall').modal('hide');
    document.getElementById("divDetailPopupCall").innerHTML = '';
    if (phonenumber != undefined && phonenumber != "") {

        if (typeof DetectingCallInBound !== 'undefined' && $.isFunction(DetectingCallInBound)) {
            DetectingCallInBound(phonenumber);
        }
    }

}
function InccomingCall(header, headername) {
    try {
        $('#IncommingCallDiv').show();
        Incommingaudio.loop = true;
        Incommingaudio.play();

    }
    catch (err) {
        console.log("Sound Error");
    }
    ReceiptIncommingCall(header, headername);


}
function AcceptIncommingCall() {

    try {
        Incommingaudio.pause();
        Incommingaudio.currentTime = 0;
        $('#IncommingCallDiv').hide();
        document.getElementById("divDetailPopupCall").innerHTML = '';
        let phonenumber = document.getElementById("incommingPhone").innerHTML;
        $("#divDetailPopupCall").load("/Views/Call/pageIncomingCall.aspx" + '?ver=' + versionofWebApplication + "&PhoneNumber=" + phonenumber + "&Type=0");
        $('#divDetailPopupCall').modal('show');
        return false;
    }
    catch (err) {
        console.log("Sound Error");
        return false;
    }
}
function MakingOutcomingCall(phone, customer, ticket, line) {
    if (LineCallCenterOutsite != "" && LinkClickToCallOutsite != "") {
        let url = LinkClickToCallOutsite + "?LineToCall=" + LineCallCenterOutsite + "&Phone=" + phone; 
        $.ajax(url, { 
            beforeSend: function (jqXHR, settings) {
                jqXHR.setRequestHeader('custom-xid-header', null);
            },
            dataType: 'json',  
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                notiError();
            },
            success: function (data, status, xhr) {   // success callback function
                notiSuccess();
            },
           
               
        });
    } else {
        Incommingaudio.pause();
        Incommingaudio.currentTime = 0;
        $('#divDetailPopupCall').empty();
        document.getElementById("divDetailPopupCall").innerHTML = '';
        $("#divDetailPopupCall").load("/Views/Call/pageIncomingCall.aspx" + '?ver=' + versionofWebApplication + "&PhoneNumber=" + phone + "&Customer=" + customer + "&Ticket=" + ticket + "&Line=" + line + "&Type=1");
        $('#divDetailPopupCall').modal('show');
        return false;
    }
    
}
function DetectingCallInBound(phonenumber) {
    document.getElementById("divDetailPopupDetectInComing").innerHTML = '';
    $("#divDetailPopupDetectInComing").load("/Views/Call/pageDetectIncoming.aspx" + '?ver=' + versionofWebApplication + "&phonenumber=" + phonenumber);
    $('#divDetailPopupDetectInComing').modal('show');
}
        //#endregion