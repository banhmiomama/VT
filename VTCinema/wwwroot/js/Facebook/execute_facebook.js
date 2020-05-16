var numberBeginMess = 15;
var isSaveArea = 0;
var isSaveServiceCare = 0;
var isSaveDiscount = 0;
/// Get Phone
function Face_LoadPhoneChattingMessage(id, pageID) {
    if (id != "") {
        $.ajax({
            url: "/Views/Facebook/pageMessenger.aspx/Conversation_GetDetailConverationHavingPhone",
            dataType: "json",
            type: "POST",
            data: JSON.stringify({ 'converationid': id, 'pageID': pageID }),
            contentType: 'application/json; charset=utf-8',
            async: true,
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                notiError();
            },
            success: function (result) {
                if (result.d != "0") {
                    let data = JSON.parse(result.d);
                    Render_PhoneChattingMessage(data, "facebook_getphone");
                    //
                    // Thành Công
                } else {
                    // Thất Bại
                }
            }
        })
    }
}
function Face_LoadPhoneInContentReceipt(content) {
    if (content != "") {
        $.ajax({
            url: "/Views/Facebook/pageMessenger.aspx/CheckReceiptHavingPhone",
            dataType: "json",
            type: "POST",
            data: JSON.stringify({ 'content': content }),
            contentType: 'application/json; charset=utf-8',
            async: true,
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                notiError();
            },
            success: function (result) {
                if (result.d != "") {
                    let data = [];
                    let element = {};
                    element.message = result.d;
                    data.push(element);
                    Putting_PhoneWhenReceiptMessage(data, "facebook_getphone");
                    //
                    // co phone
                } else {
                    // khong co phone
                }
            }
        })
    }
}
function Putting_PhoneWhenReceiptMessage(data, id) {
    var childNode = document.getElementById(id).children;
    if (childNode != undefined) {
        let stringContent = '';
        if (data != undefined && data && data.length == 1) {
            let message = data[0].message;
            if (message != "") {
                let timespan = ConvertDateTimeToTimeSpan(data[0].created_time);
                let created_time = ConvertDateTimeUTC_Time(data[0].created_time);
                tr = '<div class="phone_get">'
                    + '<div style="display:inline;"><span id=phoneget_' + timespan + ' class="phone_get_mess">' + message + '</span>'
                    + '<br>' + '<span class="phone_get_time">' + created_time + '</span>'
                    + '</div>'
                    + ((ticketid_profile != "0") ? '' : ('<div class="phone_get_button">' + '<button class="buttonGrid"><img id=buttonimg_' + timespan + ' class="buttonNewTicketFace imgGrid" src="/img/ButtonImg/new_30.png"></button>' + '</div>'))
                    + '</div>'
                stringContent = stringContent + tr;
            }

        }
        if (stringContent != "") {
            $("#" + id).prepend(stringContent);
        }
    }
}
function Render_Messenger_List_Each(data, newMess) {

    let stringContent = "";
    let item = data;
    let pic = '//graph.facebook.com/' + item.id + '/picture?access_token=' + Currenttoken;
    let timespanread = ConvertDateTimeToTimeSpan(item.timespanread);
    let timespanupdate = ConvertDateTimeToTimeSpan(item.updated_time);
    let unread = 1;
    let staff = (item.staff != undefined && item.staff != null) ? Number(item.staff) : 0;
    //if (item.unread_count == "0" || timespanread == "" || timespanread == null || timespanread == undefined || Number(timespanread) >= Number(timespanupdate)) unread = 0;
    let staffname = (item.staffname != undefined) ? item.staffname : '';
    if (timespanread == "" || timespanread == null || timespanread == undefined || Number(timespanread) >= Number(timespanupdate)) unread = 0;
    let iditem = (item.type == "0") ? (item.conver_id + '__' + item.id) : (item.idcomment + '__' + item.idpost + '__' + item.id);

    let tr =
        '<img style="float: left !important;" class="ui mini circular image pageAvatar" src="' + pic + '" alt="label-image" />'
        + '<div class="divItemName">'
        + '<span class="snipTime_snippest">' + item.name + '</span>'
        + '<span class="snipTime_snippest snip_text">'
        + (
            (
                (item.idfrom != Currentpageid && item.idfrom != undefined && item.currentsend_id == null && item.IsSearch_Filter == null)
                ||
                (item.currentsend_id != null && item.currentsend_id != Currentpageid && item.IsSearch_Filter == null)
            )
                ? '<i class="share icon"></i>'
                : ''
        )
        + item.snippet.substring(0, 30)
        + '</span>'
        + '</div>'

        + '<div class="divRightCommentMess">'
        + '<span class="snipTime_time" data-time="' + item.updated_time + '">' + ConvertDateTimeUTC_NoYear(item.updated_time) + '</span>'
        + ((item.type == "0") ? '<img class="imgMessCom" title="Inbox" src="/img/Face/mess_.png" alt="label-image" />' : '<img class="imgMessCom" title="Comment" src="/img/Face/comment_.png" alt="label-image" />')
        + ((item.ticketid == "0" || item.ticketid == undefined || item.ticketid == null) ? '' : '<img class="imgMessCom" title="Có Hồ Sơ"  src="/img/Face/profile_.png" alt="label-image" />')
        
        + (
            (item.IsCallBack == undefined || item.IsCallBack == "0") ? '' : '<img class="imgMessCom" title="'
                + ConvertDateTimeUTC_Time(item.CallBackTime) + '" '
                + ((item.IsTakeCareCallBack=="0") ? 'src="/img/Face/time_not.png"' : 'src="/img/Face/time_done.png"')
                + ' alt="label-image" />'
        )
        + ((item.block != "1") ? '<img class="imgMessCom" id="block_' + iditem + '" title="Blocked" style="display:none;" class="" src="/img/Face/spam_.png" alt="label-image" />' : '<img class="imgMessCom" id="block_' + iditem + '" title="Blocked"   src="/img/Face/spam_.png" alt="label-image" />')
        + ((item.star != "1") ? '<img class="imgMessCom" title="Star" style="display:none;" id="star_' + iditem + '" class="" src="/img/Face/star_.png" alt="label-image" />' : '<img class="imgMessCom" title="Star" id="star_' + iditem + '" src="/img/Face/star_.png" alt="label-image" />')
        + '</div>'
        + '<span class="tagMessParent" id="tag_' + iditem + '" title="' + item.tag + '">' + Render_Tag_InMessegeList(item.tag)
        + (((item.type == "0")) ? '<img id="exe_' + iditem + '" class="imgExecute" src="/img/Face/dot.png" alt="label-image">' : '')
        + '</span>'
        + '<span title=' + staff + ' id="staffname_' + iditem + '" class="staffInConversation">' + staffname + '</span>'
    if (newMess != undefined) unread = 1
    else {

        //if ((item.idfrom != undefined && item.idfrom == Currentpageid && item.currentsend_id == null)
        //    || (item.currentsend_id != null && item.currentsend_id == Currentpageid)) unread = 0
    }
    if (unread == 0)
        stringContent = stringContent + '<a class="messegerItem" title="' + staff + '"  href="#" id="' + iditem + '">' + tr + '</a>';
    else
        stringContent = stringContent + '<a class="messegerItem newMessage" title="' + staff + '"  href="#" id="' + iditem + '">' + tr + '</a>';
    return stringContent;

}
function Render_Tag_InMessegeList(tag) {
    let resulf = "";
    let tagelement = "";
    if (tag != undefined && tag != "") {
        let x = tag.split(',');
        let indexCount = 0;
        for (i = 0; i < x.length; i++) {
            if (x[i] != "") {
                if (indexCount < 3) {
                    let id = Number(x[i]);
                    let color = "white";
                    let y = ser_facebookTag.filter(word => word["ID"] == id);
                    if (y[0] != undefined) {
                        color = y[0].Color;
                        let name = y[0].Name;
                        tagelement = '<span class="tagMessList" title="' + name + '" style="background-color:' + color + '"></span>';
                        resulf = resulf + tagelement;
                        indexCount = indexCount + 1;
                    }

                }
                else {
                    let numleft = x.length - indexCount - 1;
                    resulf = resulf + '<span class="tagMessMore">' + (numleft + ' more +') + '</span>';
                    i = x.length;
                }
            }
        }
    }
    if (resulf == "") resulf = '<span class="tagMessList"></span>';
    return resulf;
}
function Render_MessengerList(data, id) {
    var myNode = document.getElementById(id);
    if (myNode != null) {
        myNode.innerHTML = '';
        let stringContent = '';
        if (data && data.length > 0) {
            for (var i = 0; i < data.length; i++) {
                stringContent = stringContent + Render_Messenger_List_Each(data[i]);
            }
        }
        document.getElementById(id).innerHTML = stringContent;
    }
    
    $('#starProfileMess').attr('src', '/img/Face/star.png');
    $('#spamProfileMess').attr('src', '/img/Face/spam.png');
    $('.copy.icon').css('color', 'black');
    $('.copy.icon').css('font-size', '16px');
    Render_List_MakeEvent();

    $('#MessengerArea_List').on('scroll', function () {
        if ($(this).scrollTop() + $(this).innerHeight() >= $(this)[0].scrollHeight) {
        }
    })
}
function changetoRead() {
    let conver = SelectedConveration.split('__')[0];
    let profile = SelectedConveration.split('__')[1];
    Face_UpdateReadConveration(Currentpageid, conver, profile);
    ChangeElentmentTo_ReadConver(SelectedConveration);
}
function changetoUnRead() {
    let conver = SelectedConveration.split('__')[0];
    let profile = SelectedConveration.split('__')[1];
    Face_UpdateUnReadConveration(Currentpageid, conver, profile);
    ChangeElentmentTo_UnRead(SelectedConveration);
}
function changetoMailDone() {

}
function changetoMailInbox() {

}
function Render_List_MakeEvent() {
    $(".imgExecute").click(function (event) {
        $("#popupExecute").css({ left: event.pageX });
        $("#popupExecute").css({ top: event.pageY - 70 });
        $("#popupExecute").show();
        let id = this.id.replace('exe_', '');
        SelectedConveration = id;
        let newClassMess = "newMessage";
        if (document.getElementById(SelectedConveration).classList.contains(newClassMess)) {
            $("#face_mailread").show();
            $("#face_mailunread").hide();
        }
        else {

            $("#face_mailread").hide();
            $("#face_mailunread").show();
        }
        event.stopPropagation();
    });


    $(".messegerItem,.messegerItem.newMessage").click(function (event) {

        var id = this.id;
        if (id.length > 60) {
            // comment
            CURRENTMESSCOM = "COM";
            CurrentCommentId = id.split('__')[0];
            CurrentPostId = id.split('__')[1];
            Currentprofileid = id.split('__')[2];
            Face_UpdateReadComment(CurrentCommentId, CurrentPostId, Currentprofileid);
            Face_LoadCommentMessage(CurrentCommentId, CurrentPostId);
            $("#loadmoreDetail").prop('disabled', true);
            $("#nameFile").hide();
            $("#gotoProfileMess").show();
            $("#ticketinfoFace").hide();
            $("#starProfileMess").hide();
            $("#spamProfileMess").hide();
            $("#div_AreaMenu").hide();
            $("#div_Area").hide();
            $("#div_ServiceCareFaceMenu").hide();
            $("#div_ServiceCareFace").hide();
            $("#div_DiscountFaceMenu").hide();
            $("#div_DiscountFace").hide();
            LoadStaffToComment(CurrentPostId, Currentprofileid);
        }
        else {
            // inbox
            CURRENTMESSCOM = "MESS";
            CurrentConverationId = id.split('__')[0];
            Currentprofileid = id.split('__')[1];
            Face_UpdateReadConveration(Currentpageid, CurrentConverationId, Currentprofileid);
            numberBlockMess = numberBeginMess;
            Face_LoadChattingMessage(CurrentConverationId, numberBlockMess);
            $("#loadmoreDetail").prop('disabled', false);
            $("#nameFile").show();
            $("#gotoProfileMess").hide();
            $("#ticketinfoFace").show();
            $("#starProfileMess").show();
            $("#spamProfileMess").show();
            $("#profile_pageID").html(Currentpageid);
            $("#profile_PSID").html(Currentprofileid);
            $("#div_AreaMenu").show();
            $("#div_Area").show();
            $("#div_ServiceCareFaceMenu").show();
            $("#div_ServiceCareFace").show();
            $("#div_DiscountFaceMenu").show();
            $("#div_DiscountFace").show();
            onLoadPersonalInfo_Ticket();
            LoadStaffToInbox(Currentpageid, Currentprofileid);
            LoadAreaToInbox(Currentpageid, Currentprofileid);
            LoadServiceCareToInbox(Currentpageid, Currentprofileid);
            LoadDiscountToInbox(Currentpageid, Currentprofileid);
        }
        if ($('#' + id).length) {
            let child = $('#' + id).children();
            let idblock = "block_" + id;
            let idstar = "star_" + id;
            if (child != undefined && child != null) {
                if ($("#profile_Avatar").length) $('#profile_Avatar').attr('src', child[0].src);
                if ($("#face_name").length) document.getElementById("face_name").innerHTML = child[1].children[0].textContent;
                if ($("#" + idstar).length && $("#" + idstar).css('display') != 'none') {
                    $('#starProfileMess').attr('src', '/img/Face/star_.png');
                }
                else {
                    $('#starProfileMess').attr('src', '/img/Face/star.png');
                }
                if ($("#" + idblock).length && $("#" + idblock).css('display') != 'none') {
                    $('#spamProfileMess').attr('src', '/img/Face/spam_.png');
                    $("#MessengerArea_Chating").hide();
                    $("#MessengerArea_Chating_Hide").show();
                }
                else {
                    $('#spamProfileMess').attr('src', '/img/Face/spam.png');
                }
            }

        }
        ChangeElentmentTo_ReadConver(id);
        ChangeElementWhenClick(id);
        $("#MessengerArea_Info").show();
        $('#gotoProfileMess').attr('src', '/img/Face/mess.png')
    });
}
function Render_PhoneChattingMessage(data, id) {
    var myNode = document.getElementById(id);
    if (myNode != null) {
        myNode.innerHTML = '';
        let stringContent = '';
        if (data && data.length > 0) {
            for (var i = data.length - 1; i >= 0; i--) {
                let tr = "";
                let item = data[i];
                let message = item.message;
                if (message != "") {
                    let timespan = ConvertDateTimeToTimeSpan(item.created_time);
                    let created_time = ConvertDateTimeUTC_Time(item.created_time);
                    tr = '<div class="phone_get">'
                        + '<div style="display:inline;"><span id=phoneget_' + timespan + ' class="phone_get_mess">' + message + '</span>'
                        + '<br>' + '<span class="phone_get_time">' + created_time + '</span>'
                        + '</div>'
                        + ((ticketid_profile != "0") ? '' : ('<div class="phone_get_button">' + '<button class="buttonGrid"><img id=buttonimg_' + timespan + ' class="buttonNewTicketFace imgGrid" src="/img/ButtonImg/new_30.png"></button>' + '</div>'))
                        + '</div>'
                    stringContent = stringContent + tr;
                }
            }
        }
        document.getElementById(id).innerHTML = stringContent;
        CreateTicket_Face_Phone();
    }
}
function CreateTicket_Face_Phone() {
    $(".buttonNewTicketFace").on('click', function (event) {
        let timespanid_phone = (this.id).replace("buttonimg_", "phoneget_");

        let ServiceCareToken = $('#ServiceCareFace').dropdown('get value') ? $('#ServiceCareFace').dropdown('get value') : ''
        let phone = document.getElementById(timespanid_phone).innerHTML;
        if (ticketid_profile == "0") {
            let namme = document.getElementById("face_name").innerHTML;
            //let gender = document.getElementById("face_gender").innerHTML;
            document.getElementById("divDetailPopup").innerHTML = '';
            $("#divDetailPopup").load("/Views/Marketing/pageTicketDetail.aspx" + "?ver=" + versionofWebApplication + '&KeyPage=' + Currentpageid + '&faceid=' + Currentprofileid + '&name="' + encodeURI(namme) + '"' + "&phone='" + phone + "'" + "&servicecare=" + encodeURI(ServiceCareToken) +"");
            $('#divDetailPopup').modal('show');
        }
    });
}
function ReceiptCommentFromFace(data, commentid) {
    if (typeof Currentpageid !== 'undefined' && typeof CurrentCommentId !== 'undefined') {
        let dataobj = JSON.parse(data);
        let idPage = dataobj.entry[0].id;
        let isHavingPage = 0;
        if (ListPage_MessengerByUserAndPage != undefined && ListPage_MessengerByUserAndPage.length != 0) {
            for (i = 0; i < ListPage_MessengerByUserAndPage.length; i++) {
                if (ListPage_MessengerByUserAndPage[i].KeyPage == idPage) {
                    isHavingPage = 1;
                    i = ListPage_MessengerByUserAndPage.length;
                }
            }
        }
        if (isHavingPage == 1) {
            if (idPage == Currentpageid) {
                // Trong Facebook page
                ReceiptCommentFromFace_CheckWhenInCurrentpage(dataobj, commentid);
            }
            else {

                ReceiptCommentFromFace_MenuShow_Show(dataobj);
            }
        }
    }
    else {
        // Not in page
    }
}
function ReceiptMessageFromFace(data) {

    if (typeof Currentpageid !== 'undefined' && typeof CurrentConverationId !== 'undefined') {
        // In page
        $.ajax({
            url: "/Views/Facebook/pageMessenger.aspx/Conversation_ReceiptMessage",
            dataType: "json",
            type: "POST",
            data: JSON.stringify({ 'data': data }),
            contentType: 'application/json; charset=utf-8',
            async: true,
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                notiError();
            },
            success: function (result) {
                if (result.d != "0") {
                    let data = JSON.parse(result.d);
                    if (data != undefined && data != null && data.objfrom != undefined && data.objfrom != null) {
                        let idFrom = data.objfrom.id;
                        let idTo = data.objto.id;
                        let isHavingPage = 0;

                        if (ListPage_MessengerByUserAndPage != undefined && ListPage_MessengerByUserAndPage.length != 0) {
                            for (i = 0; i < ListPage_MessengerByUserAndPage.length; i++) {
                                if (ListPage_MessengerByUserAndPage[i].KeyPage == idTo) {
                                    isHavingPage = 1;
                                    i = ListPage_MessengerByUserAndPage.length;
                                }
                            }
                        }
                        if (isHavingPage == 1) {
                            if (idTo == Currentpageid) {
                                // trong page
                                if (idFrom == Currentprofileid && CURRENTMESSCOM == "MESS") {
                                    // Trong hoi thoai
                                    Putting_MessengerDetail_Receipt(data, "MessengerArea_Messenger");
                                    let content = (data != null && data.message != undefined) ? data.message : "";
                                    Face_LoadPhoneInContentReceipt(content);
                                    Putting_ConversationToTopWhenClickAndReceive(CurrentConverationId + "__" + Currentprofileid, data.message, '');
                                }
                                else {
                                    // Ngoai hoi thoai
                                    ReceiptMessageFromFace_CheckWhenNotCurrent(idFrom);
                                }
                            }
                            else {
                                // ngoai page facebook
                                ReceiptMessageFromFace_MenuShow_Show(idTo, idFrom);
                            }
                        }
                    }
                } else {
                    // Thất Bại
                }
            }
        });
    }
    else {
        // Not in page
    }
}
function ReceiptMessageFromFace_MenuShow_Show(idTo, idFrom) {

    $.ajax({
        url: "/Views/Facebook/pageMessenger.aspx/CheckNewMess_ByStaffID",
        dataType: "json",
        data: JSON.stringify({ 'Currentpage': idTo, 'fromid': idFrom, 'CurrentStaffID': CurrentStaffID }),
        type: "POST",
        contentType: 'application/json; charset=utf-8',
        async: true,
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            notiError();
        },
        success: function (result) {
            if (result.d != "0" && result.d != "null") {
                $("#icon-noti-general").show();
                $("#Pagechoosing_Current").css("background-color", "#0288d11f");
                if (!($("#Pagechoosing_Current").hasClass("flashit"))) {
                    $("#Pagechoosing_Current").addClass("flashit");
                }


                let id = "#new_" + idTo;
                if ($(id).length) {
                    $(id).show();
                }
            }
        }
    });

}
function ReceiptCommentFromFace_MenuShow_Show(dataobj) {
    let noti = dataobj.entry[0].changes[0].value;
    let idPost = noti.post_id;
    let idTo = idPost.split('_')[0];
    let idFrom = noti.from.id;
    $.ajax({
        url: "/Views/Facebook/pageMessenger.aspx/CheckNewComment_ByStaffID",
        dataType: "json",
        data: JSON.stringify({ 'Currentpage': idTo, 'fromid': idFrom, 'CurrentStaffID': CurrentStaffID }),
        type: "POST",
        contentType: 'application/json; charset=utf-8',
        async: true,
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            notiError();
        },
        success: function (result) {
            if (result.d != "0" && result.d != "null") {
                $("#icon-noti-general").show();
                $("#Pagechoosing_Current").css("background-color", "#0288d11f");
                if (!($("#Pagechoosing_Current").hasClass("flashit"))) {
                    $("#Pagechoosing_Current").addClass("flashit");
                }


                let id = "#new_" + idTo;
                if ($(id).length) {
                    $(id).show();
                }
            }
        }
    });

}

function ReceiptCommentFromFace_CheckWhenInCurrentpage(dataobj, commentid) {
    let noti = dataobj.entry[0].changes[0].value;
    let idFrom = noti.from.id;
    $.ajax({
        url: "/Views/Facebook/pageMessenger.aspx/CheckNewComment_ByStaffID",
        dataType: "json",
        data: JSON.stringify({ 'Currentpage': Currentpageid, 'fromid': idFrom, 'CurrentStaffID': CurrentStaffID }),
        type: "POST",
        contentType: 'application/json; charset=utf-8',
        async: true,
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            notiError();
        },
        success: function (result) {
            if (result.d != "0") {
                let dataresulf = JSON.parse(result.d)[0];
                if (dataresulf.RESULF != "0") {
                    Putting_CommentToTop(dataobj, commentid, dataresulf.ticketid, dataresulf.staffname, dataresulf.staffid);
                    Render_List_MakeEvent();
                    if (dataobj.entry[0] != undefined) {
                        NewMessageFacebook(noti.from.id, noti.from.name, noti.message, "1");
                        Putting_ConversationToTopWhenClickAndReceive(noti.parent_id + '__' + noti.post_id + '__' + noti.from.id, noti.message, noti.from.id);
                    }
                }
            }
        }
    });
}
function ReceiptMessageFromFace_CheckWhenNotCurrent(idFrom) {
    $.ajax({
        url: "/Views/Facebook/pageMessenger.aspx/CheckNewMess_ByStaffID",
        dataType: "json",
        data: JSON.stringify({ 'Currentpage': Currentpageid, 'fromid': idFrom, 'CurrentStaffID': CurrentStaffID }),
        type: "POST",
        contentType: 'application/json; charset=utf-8',
        async: true,
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            notiError();
        },
        success: function (result) {
            if (result.d != "0" && result.d != "null") {
                ReceiptMessageFromFace_NotCurrentChat(idFrom);
                Render_List_MakeEvent();
            }
        }
    });
}
function ReceiptMessageFromFace_NotCurrentChat(idFrom, trigger) {
    $.ajax({
        url: "/Views/Facebook/pageMessenger.aspx/Conversation_ReceiptMessage_NotCurrentChat",
        dataType: "json",
        type: "POST",
        data: JSON.stringify({ 'idfrom': idFrom }),
        contentType: 'application/json; charset=utf-8',
        async: true,
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            notiError();
        },
        success: function (result) {
            if (result.d != "0") {
                let data = JSON.parse(result.d);
                if (data != undefined && data != null && data.length != 0) {
                    Putting_ConversationToTop(data);
                    if (trigger == undefined) NewMessageFacebook(data.id, data.name, data.snippet);
                    Render_List_MakeEvent();
                    if (trigger != undefined) {
                        let id = data.conver_id + '__' + data.id;
                        $("#" + id).trigger("click");
                    }
                }
                else {
                    // gui tin nhan dau tien 
                    //let name = document.getElementById("face_name").innerHTML;
                    //const promise = notiConfirmSendContent("Inbox đến " + name);
                    //promise.then(function () { Face_SendFristTobeginConver(); }, function () { });
                }
            } else {
                // Thất Bại
            }
        }
    });
}
function Putting_CommentToTop(data, commentid, ticketid, staffname, staffid) {
    let change = data.entry[0].changes[0];
    let value = change.value;
    let id = value.from.id;
    let name = value.from.name;
    let post_id = value.post_id;
    let comment_id = commentid;
    let updated_time = value.post.updated_time;
    let message = (value.message != null) ? value.message : "";
    let parent_id = (value.parent_id != null) ? value.parent_id : "";

    let id_ = comment_id + '__' + post_id + '__' + id;
    if ($('#' + id_).length) {
        // Co trong chatting
        $('#' + id_).prependTo("#MessengerArea_List");
        ChangeElentmentTo_UnRead(id_);
    }
    else {

        let stringContent = "";
        let pic = '//graph.facebook.com/' + id + '/picture?access_token=' + Currenttoken;
        let tr =
            '<img style="float: left !important;" class="ui mini circular image pageAvatar" src="' + pic + '" alt="label-image" />'
            + '<div class="divItemName">'
            + '<span class="snipTime_snippest">' + name + '</span>'
            + '<span class="snipTime_snippest snip_text">' + message + '</span>'
            + '</div>'

            + '<div class="divRightCommentMess">'
            + '<span class="snipTime_time">' + ConvertDateTimeUTC_NoYear(updated_time) + '</span>'
            + '<img class="imgMessCom" title="Comment" class="" src="/img/Face/comment_.png" alt="label-image" />'
            + ((ticketid == "0" || ticketid == undefined || ticketid == null) ? '' : '<img class="imgMessCom" title="Có Hồ Sơ" class="" src="/img/Face/profile_.png" alt="label-image" />')
            + '</div>'
            + '<span class="tagMessParent"></span>'
            + '<span title=' + staffid + ' id="staffname_' + id_ + '" class="staffInConversation">' + staffname + '</span>'
        stringContent = stringContent + '<a class="messegerItem newMessage" href="#" id="' + id_ + '">' + tr + '</a>';
        var newelement = createElementFromHTML(stringContent);
        var list = document.getElementById("MessengerArea_List");
        list.insertBefore(newelement, list.childNodes[0]);
    }
}
function Putting_ConversationToTop(data) {
    let id = data.conver_id + '__' + data.id;
    if ($('#' + id).length) {
        // Co trong chatting
        $('#' + id).prependTo("#MessengerArea_List");
        ChangeElentmentTo_UnRead(id);
        Putting_ConversationToTopWhenClickAndReceive(id, data.snippet, '');
    }
    else {
        let element = Render_Messenger_List_Each(data, "new");
        var newelement = createElementFromHTML(element);
        var list = document.getElementById("MessengerArea_List");
        list.insertBefore(newelement, list.childNodes[0]);
    }
}
function ChangeElentmentTo_UnRead(id) {
    let newClassMess = "newMessage";
    if (!document.getElementById(id).classList.contains(newClassMess)) {
        document.getElementById(id).classList.add(newClassMess);
    }
}
function Putting_ConversationToTopWhenClickAndReceive(id, mess, idfrom) {
    if (mess != undefined) {
        if ($('#' + id).length) {
            // Co trong chatting
            $('#' + id).prependTo("#MessengerArea_List");
            let child = $('#' + id).children();
            // console.log(id)
            if (child != undefined && child != null) {
                if (idfrom == Currentpageid) { // tin nhan do page gui
                    child[1].children[1].innerHTML = mess.substring(0, 30);
                }
                else {
                    child[1].children[1].innerHTML = '<i class="share icon"></i>' + mess.substring(0, 30);
                }
                // child[1].children[1].innerHTML = mess.substring(0, 30);
                child[2].children[0].innerHTML = ConvertDateTimeUTC_Time_OnlyHour(new Date());
            }
        }
    }
}
function ChangeElementWhenClick(id) {
    let chooseMessage = "chooseMessage";
    var x = document.getElementsByClassName("messegerItem");
    for (i = 0; i < x.length; i++) {
        if (x[i].id != id) {
            if (document.getElementById(x[i].id).classList.contains(chooseMessage)) {
                document.getElementById(x[i].id).classList.remove(chooseMessage);
            }
        }
        else {
            if (!document.getElementById(x[i].id).classList.contains(chooseMessage)) {
                document.getElementById(x[i].id).classList.add(chooseMessage);
            }
        }
    }
}
function ChangeElentmentTo_ReadConver(id) {
    let newClassMess = "newMessage";

    if (document.getElementById(id).classList.contains(newClassMess)) {
        document.getElementById(id).classList.remove(newClassMess);
    }

}

// Receipt Message
function Putting_MessengerDetail_Receipt(data, id) {
    var childNode = document.getElementById(id).children;
    var parrent = document.getElementById(id);
    let timespan = '';
    if (childNode != undefined) {
        let stringContent = '';
        if (data != undefined && data) {
            let tr = "";
            let item = data;
            let message = item.message;
            let objfrom_id = item.objfrom.id;
            let objto_id = item.objto.id;
            let attachments = item.attachments;
            let read = item.read;
            let created_time = ConvertTimeSpanUTC_Time(item.created_time);

            let created_time_onlyhour = ConvertDateTimeUTC_Time_OnlyHour(item.created_time);
            timespan = item.created_time;

            if (objfrom_id == Currentprofileid && objto_id == Currentpageid) {
                if (read != undefined && read && read == "1") {

                    // remove all read
                    $("div").remove(".messengerDetail_me.read");

                    // Da doc
                    tr =
                        '<div id="' + timespan + '" class="messengerDetail_me read">'
                        + Render_ReadMessage(created_time)
                        + '</div>'
                }
                else {
                    // Nhan tin
                    tr =
                        '<div id="' + timespan + '" class="messengerDetail_client">'
                        + ((message == "") ? '' : ('<span class="message_client" title="' + created_time + '">' + item.message + '</span>'))
                        + Render_MessengerDetail_Attachment(attachments, "client", created_time)
                        + '<span class="message_client message_client_time_send" id="send_' + timespan + '">' + created_time_onlyhour + '</span>'
                        + '</div>'
                }
            }
            stringContent = tr;

        }
        if (stringContent != "") {
            var newelement = createElementFromHTML(stringContent);
            let timespanNumber = (timespan != "") ? Number(timespan) : 0;
            let indexfind = 0;
            for (i = childNode.length - 1; i >= 0; i--) {
                let id = childNode[i].id;
                if (timespanNumber > id) {
                    indexfind = i;
                    i = 0;
                }
            }
            if (childNode[indexfind] != undefined && childNode[indexfind] != null && $("#send_" + childNode[indexfind].id).length) {
                $("#send_" + childNode[indexfind].id).remove();
            }

            if (indexfind == childNode.length - 1) parrent.appendChild(newelement)
            else parrent.insertBefore(newelement, parrent[indexfind - 1]);
        }
    }
    Face_ScrollContentToLast();
    Face_EventLickImage();
    $('.message_me,.message_client,.sticker_client,.sticker_me,.image_me,.video_me,.file_me,.image_client,.video_client,.file_client').qtip({ // Grab some elements to apply the tooltip to
        content: {
            text: function (event, api) {
                // 
                // Retrieve content from custom attribute of the $('.selector') elements.
                return $(this).attr('oldtitle');
            }
        }
    })
}
function Putting_InboxDetail_FromComment(message, id) {
    var childNode = document.getElementById(id).children;
    var parrent = document.getElementById(id);
    let timespan = '';
    if (childNode != undefined) {
        let stringContent = '';
        if (message != undefined && message) {
            let tr = "";
            let created_time = ConvertTimeSpanUTC_Time(new Date());
            let created_time_onlyhour = ConvertDateTimeUTC_Time_OnlyHour(new Date());
            timespan = (new Date()).getTime();
            // remove all read
            $("div").remove(".messengerDetail_me.read");

            tr =
                '<div id="' + timespan + '" class="messengerDetail_me">'
                + ((message == "") ? '' : ('<span class="message_me message_from_comment" title="' + created_time + '">' + message + '</span>'))
                + '<span class="message_me message_me_time_send" id="send_' + timespan + '">' + created_time_onlyhour + '</span>'
                + '</div>'
            stringContent = tr;

        }
        if (stringContent != "") {
            var newelement = createElementFromHTML(stringContent);
            let timespanNumber = (timespan != "") ? Number(timespan) : 0;
            let indexfind = 0;
            for (i = childNode.length - 1; i >= 0; i--) {
                let id = childNode[i].id;
                if (timespanNumber > id) {
                    indexfind = i;
                    i = 0;
                }
            }
            if (childNode[indexfind] != undefined && childNode[indexfind] != null && $("#send_" + childNode[indexfind].id).length) {
                $("#send_" + childNode[indexfind].id).remove();
            }

            if (indexfind == childNode.length - 1) parrent.appendChild(newelement)
            else parrent.insertBefore(newelement, parrent[indexfind - 1]);
        }
    }
    Face_ScrollContentToLast();
    Face_EventLickImage();
    $('.message_me,.message_client,.sticker_client,.sticker_me,.image_me,.video_me,.file_me,.image_client,.video_client,.file_client').qtip({ // Grab some elements to apply the tooltip to
        content: {
            text: function (event, api) {
                // 
                // Retrieve content from custom attribute of the $('.selector') elements.
                return $(this).attr('oldtitle');
            }
        }
    })
}
function Putting_MessengerDetail_Send(data, id) {
    var childNode = document.getElementById(id).children;
    var parrent = document.getElementById(id);
    let timespan = '';
    if (childNode != undefined) {
        let stringContent = '';
        if (data != undefined && data) {
            let dateBegin = new Date();
            let tr = "";
            let item = data;
            let sticker = item.sticker;
            let tag_read = item.tag_read;
            let tag_sent = item.tag_sent;
            let message = item.message;
            let objfrom_id = item.objfrom.id;
            let attachments = item.attachments;
            let created_time = ConvertDateTimeUTC_Time(item.created_time);
            let created_time_onlyhour = ConvertDateTimeUTC_Time_OnlyHour(item.created_time);
            timespan = ConvertDateTimeToTimeSpan(item.created_time);
            let dateLine = Render_MessengerDetail_Date(item.created_time, dateBegin);
            //let readsentStatus = (i == 0 && Currentpageid == objfrom_id) ? Render_MessengerDetail_ReadSent(tag_read, tag_sent) : '';
            dateBegin = new Date(item.created_time);
            if (Currentpageid == objfrom_id) {
                tr =
                    '<div id="' + timespan + '" title="' + created_time + '" class="messengerDetail_me">'
                    + ((message == "") ? '' : ('<span class="message_me" title="' + created_time + '">' + item.message + '</span>'))
                    + ((sticker == "") ? '' : ('<img class="sticker_me" title="' + created_time + '" src="' + item.sticker + '">'))
                    + Render_MessengerDetail_Attachment(attachments, "me", created_time)
                    + '<span class="message_me message_me_time_send" id="send_' + timespan + '">' + created_time_onlyhour + '</span>'
                    + '</div>';
            }
            else {
                tr =
                    '<div id="' + timespan + '" title="' + created_time + '" class="messengerDetail_client">'
                    + ((message == "") ? '' : ('<span class="message_client" title="' + created_time + '">' + item.message + '</span>'))
                    + ((sticker == "") ? '' : ('<img class="sticker_client" title="' + created_time + '" src="' + item.sticker + '">'))
                    + Render_MessengerDetail_Attachment(attachments, "client", created_time)
                    + '<span class="message_client message_client_time_send" id="send_' + timespan + '">' + created_time_onlyhour + '</span>'
                    + '</div>';

            }

            stringContent = /*dateLine +*/ tr //+ readsentStatus;
        }
        if (stringContent != "") {
            let timespanNumber = (timespan != "") ? Number(timespan) : 0;
            let indexfind = 0;
            for (i = childNode.length - 1; i >= 0; i--) {
                let id = childNode[i].id;
                if (timespanNumber > id) {
                    indexfind = i;
                    i = 0;
                }
            }
            if (childNode[indexfind] != undefined && childNode[indexfind] != null && $("#send_" + childNode[indexfind].id).length) {
                $("#send_" + childNode[indexfind].id).remove();
            }

            var newelement = createElementFromHTML(stringContent);
            if (indexfind == childNode.length - 1) parrent.appendChild(newelement)
            else parrent.insertBefore(newelement, parrent[indexfind - 1]);

        }
    }
    Face_ScrollContentToLast();
    Face_EventLickImage();
    $('.message_me,.message_client,.sticker_client,.sticker_me,.image_me,.video_me,.file_me,.image_client,.video_client,.file_client').qtip({ // Grab some elements to apply the tooltip to
        content: {
            text: function (event, api) {
                // 
                // Retrieve content from custom attribute of the $('.selector') elements.
                return $(this).attr('oldtitle');
            }
        }
    })
}
function Remove_MessenerDetail_Temp(timespan) {
    let id = "#" + Number(timespan);
    if ($(id).length) {
        $(id).remove();
    }
}
function Putting_MessengerDetail_Send_Temporary(message, timespan, id) {
    var childNode = document.getElementById(id).children;
    var parrent = document.getElementById(id);
    if (childNode != undefined) {
        let stringContent = '';
        if (message != undefined && message) {
            let tr = "";
            tr =
                '<div id="' + timespan + '"  class="messengerDetail_me">'
                + ((message == "") ? '' : ('<span class="message_me message_me_temp" >' + message + '</span>'))
                // + ((sticker == "") ? '' : ('<img class="sticker_me" title="' + created_time + '" src="' + item.sticker + '">'))
                // + Render_MessengerDetail_Attachment(attachments, "me", created_time)
                // + '<span class="message_me message_me_time_send" id="send_' + timespan + '">' + created_time_onlyhour + '</span>'
                + '</div>';

            stringContent = tr;

        }
        if (stringContent != "") {
            let timespanNumber = (timespan != "") ? Number(timespan) : 0;
            let indexfind = 0;
            for (i = childNode.length - 1; i >= 0; i--) {
                let id = childNode[i].id;
                if (timespanNumber > id) {
                    indexfind = i;
                    i = 0;
                }
            }
            if (childNode[indexfind] != undefined && childNode[indexfind] != null && $("#send_" + childNode[indexfind].id).length) {
                $("#send_" + childNode[indexfind].id).remove();
            }

            var newelement = createElementFromHTML(stringContent);
            if (indexfind == childNode.length - 1) parrent.appendChild(newelement)
            else parrent.insertBefore(newelement, parrent[indexfind - 1]);

        }
    }
    Face_ScrollContentToLast();
    Face_EventLickImage();
}
function Putting_CommentDetail_Send(data, id) {
    var childNode = document.getElementById(id).children;
    var parrent = document.getElementById(id);
    if (childNode != undefined) {
        let stringContent = '';

        if (data != undefined && data) {
            let dateBegin = new Date();
            let tr = "";
            let item = data;
            let message = item.message;
            let attachments = item.attachments;
            let created_time = ConvertDateTimeUTC_Time(item.created_time);
            let created_time_onlyhour = ConvertDateTimeUTC_Time_OnlyHour(item.created_time);
            let isDelete = (item.isDelete != undefined && item.isDelete != null) ? Number(item.isDelete) : 0;
            let isHidden = (item.isHidden != undefined && item.isHidden != null) ? ((item.isHidden == 'False') ? 0 : 1) : 0;
            let isLike = (item.isLike != undefined && item.isLike != null) ? Number(item.isLike) : 0;
            let comment_id = (item.comment_id != undefined && item.comment_id != null) ? item.comment_id : "";
            let timespan = ConvertDateTimeToTimeSpan(item.created_time);
            let dateLine = Render_MessengerDetail_Date(item.created_time, dateBegin);
            dateBegin = new Date(item.created_time);

            tr =
                '<div id="' + timespan + '" class="messengerDetail_me">'
                + ((message == "") ? '' : ('<span id="com_' + comment_id + '" class="'
                    + ((isHidden == 1) ? 'message_me me_hidden' : 'message_me')
                    + '" title="' + created_time + '">'
                    + item.message
                    + '<span style="display: flex;">'
                    + '<a class="commentedit_a" href="#"  id="edit_' + comment_id + '"><img  class="commentdelete commentdelete_img" src="/img/Face/edit.png">' + '</a>'
                    + '<a class="commentdelete_a" href="#" id="del_' + comment_id + '"><img id="imgDelete_' + comment_id + '" class="commentdelete commentdelete_img" src="' + ((isDelete == 1) ? '/img/Face/deleted.png' : '/img/Face/nodelete.png') + '">' + '</a>'
                    + '</span>'))
                + '</div>'
                + Render_MessengerDetail_Attachment(attachments, "me", created_time)
                + '</div>'
            tr = tr + '<span class="message_me message_me_time_send">' + created_time_onlyhour + '</span></br>';
            stringContent = stringContent + dateLine + tr;
        }
        if (stringContent != "") {
            var newelement = createElementFromHTML(stringContent);
            parrent.appendChild(newelement)
        }
    }
    //Face_EventCLickHiddenComment();
    Face_EventCLickDeleteComment();
    Face_EventCLickEditComment();
}
function Render_CommentDetail(data, id) {
    var myNode = document.getElementById(id);
    if (myNode != null) {
        myNode.innerHTML = '';
        let stringContent = '';
        if (data && data.length > 0) {
            let dateBegin = new Date();
            for (var i = data.length - 1; i >= 0; i--) {

                let tr = "";
                let item = data[i];
                let message = item.message;
                let attachments = item.attachments;
                let created_time = ConvertDateTimeUTC_Time(item.created_time);
                let created_time_onlyhour = ConvertDateTimeUTC_Time_OnlyHour(item.created_time);
                let isDelete = (item.isDelete != undefined && item.isDelete != null) ? Number(item.isDelete) : 0;
                let firstcommentIsDelete = 0;
                let isHidden = (item.isHidden != undefined && item.isHidden != null) ? ((item.isHidden == 'False') ? 0 : 1) : 0;
                let isLike = (item.isLike != undefined && item.isLike != null) ? Number(item.isLike) : 0;
                let isFirstComment = (item.isFirstComment != undefined && item.isFirstComment != null) ? Number(item.isFirstComment) : 0;
                let comment_id = (item.comment_id != undefined && item.comment_id != null) ? item.comment_id : "";
                let timespan = ConvertDateTimeToTimeSpan(item.created_time);
                let dateLine = Render_MessengerDetail_Date(item.created_time, dateBegin);
                let permalink_url = (item.permalink_url != undefined && item.permalink_url != null) ? item.permalink_url : "";
                dateBegin = new Date(item.created_time);
                if (isFirstComment == 1) {
                    firstcommentIsDelete = 1;
                }
                if (isFirstComment == 1 && isDelete == 1) {
                    $("#MessengerArea_Chating").hide();
                    $("#MessengerArea_Chating_Hide").show();

                }

                if (i == data.length - 1) {
                    tr =
                        '<div id="' + timespan + '" class="postDetail_me">'
                        + '<div class="divPostInMessage">'
                        + ((message == "") ? '' : ('<span class="postmessage_me" title="' + created_time + '">' + item.message + '</span>'))
                        + '<div class="postmessage_me postmessage_me_name">' + item.objfrom.name + '<br>' + created_time + '</div>'
                        //+ '<div style="width: 100%;display: flow-root;">' + Render_MessengerDetail_Attachment(attachments, "me", created_time) + '</div>'
                        + '</div>'
                        + '</div>'
                }
                else {
                    if (item.inboxfromcomment != null && item.inboxfromcomment == "1") {
                        // Inbox From Commment
                        tr =
                            '<div id="' + timespan + '" class="messengerDetail_me">'
                            + ((message == "") ? '' : ('<span class="message_me message_from_comment" title="' + created_time + '">' + message + '</span>'))
                            + '<span class="message_me message_me_time_send" id="send_' + timespan + '">' + created_time_onlyhour + '</span>'
                            + '</div>'
                    }
                    else {
                        if (item.objfrom.id != Currentprofileid) {
                            tr =
                                '<div id="' + timespan + '" class="messengerDetail_me">'
                                + ((message == "") ? '' : ('<span id="com_' + comment_id + '" class="'
                                    + ((isHidden == 1) ? 'message_me me_hidden' : 'message_me')
                                    + '" title="' + created_time + '">'
                                    + item.message
                                    + '<span style="display: flex;">'
                                    + '<a class="commentedit_a" href="#"  id="edit_' + comment_id + '"><img  class="commentdelete commentdelete_img" src="/img/Face/edit.png">' + '</a>'
                                    + '<a class="commentdelete_a" href="#" title="' + ((firstcommentIsDelete == 1) ? 'FC' : '') + '" id="del_' + comment_id + '"><img id="imgDelete_' + comment_id + '" class="commentdelete commentdelete_img" src="' + ((isDelete == 1) ? '/img/Face/deleted.png' : '/img/Face/nodelete.png') + '">' + '</a>'
                                    + '</span>'))
                                + '</span>'
                                + Render_MessengerDetail_Attachment(attachments, "me", created_time)
                                + '</div>'
                            if (i == 0 || (i != 0 && data[i - 1].objfrom != null && data[i - 1].objfrom.id == Currentprofileid)) tr = tr + '<span class="message_me message_me_time_send">' + created_time_onlyhour + '</span></br>';
                        }
                        else {
                            tr =
                                '<div id="' + timespan + '" class="messengerDetail_client">'
                                + ((message == "") ? '' : ('<span id="com_' + comment_id + '" class="'
                                    + ((isHidden == 1) ? 'message_client client_hidden' : 'message_client')
                                    + '" title="' + created_time + '">'
                                    + item.message
                                    + '<span style="display: flex;">'
                                    + '<a class="commentdelete_a" href="#" title="' + ((firstcommentIsDelete == 1) ? 'FC' : '') + '" id="del_' + comment_id + '"><img id="imgDelete_' + comment_id + '" class="commentdelete commentdelete_img" src="' + ((isDelete == 1) ? '/img/Face/deleted.png' : '/img/Face/nodelete.png') + '">' + '</a>'
                                    + ((isLike != 0) ? ('<img class="commentdelete commentdelete_img" title="Liked" src="/img/Face/facebook_like.png">') : '')
                                    + ((permalink_url != "") ? ('<a href="' + permalink_url + '" target="_blank"><img class="commentdelete commentdelete_img"  title="Link comment" src="/img/Face/facelink.png"></a>') : '')
                                    + '<a class="commenthidden" title="' + ((isHidden == 1) ? 'Bỏ ẩn' : 'Ẩn') + '" id="hidcom_' + comment_id + '" href="#"><img id="imghidcom_' + comment_id + '" class="commentdelete commentdelete_img" src="' + ((isHidden == 1) ? '/img/Face/nohide.png' : '/img/Face/hide.png') + '">' + '</a>'
                                    + '</span>'))
                                + '</span>'
                                + Render_MessengerDetail_Attachment(attachments, "client", created_time)
                                + '</div>'
                            if (i == 0 || (i != 0 && data[i - 1] != undefined && data[i - 1].objfrom != null && data[i - 1].objfrom.id != Currentprofileid)) tr = tr + '<span class="message_client message_client_time_send">' + created_time_onlyhour + '</span></br>';
                        }
                    }
                }
                stringContent = stringContent + dateLine + tr //+ readsentStatus;
            }
        }

        document.getElementById(id).innerHTML = stringContent;

    }
    //$("#MessengerArea_Messenger").niceScroll({
    //    cursorwidth: 7,
    //    cursoropacitymin: 0.4,
    //    cursorcolor: '#6e8cb6',
    //    cursorborder: 'none',
    //    scrollspeed: 30,
    //    mousescrollstep: 55,
    //    cursorborderradius: 4,
    //    autohidemode: true,
    //    horizrailenabled: false,
    //});
    $('.message_me,.message_client,.sticker_client,.sticker_me,.image_me,.video_me,.file_me,.image_client,.video_client,.file_client').qtip({ // Grab some elements to apply the tooltip to
        content: {
            text: function (event, api) {
                //
                // Retrieve content from custom attribute of the $('.selector') elements.
                return $(this).attr('oldtitle');
            }
        }
    })
    Face_ScrollContentToLast();
    Face_EventLickImage();
    Face_EventCLickHiddenComment();
    Face_EventCLickDeleteComment();
    Face_EventCLickEditComment();
}
function Render_MessengerDetails(data, id, loadmore) {
    var myNode = document.getElementById(id);
    if (myNode != null) {
        myNode.innerHTML = '';
        let stringContent = '';
        if (data && data.length > 0) {
            let dateBegin = new Date();
            for (var i = data.length - 1; i >= 0; i--) {
                let tr = "";
                let item = data[i];
                let sticker = item.sticker;
                //let tag_read = item.tag_read;
                //let tag_sent = item.tag_sent;
                let message = item.message;
                let objfrom_id = item.objfrom.id;
                let attachments = item.attachments;
                let created_time = ConvertDateTimeUTC_Time(item.created_time);
                let created_time_onlyhour = ConvertDateTimeUTC_Time_OnlyHour(item.created_time);
                let timespan = ConvertDateTimeToTimeSpan(item.created_time);
                let dateLine = Render_MessengerDetail_Date(item.created_time, dateBegin);
                // let readsentStatus = (i == 0 && Currentpageid == objfrom_id) ? Render_MessengerDetail_ReadSent(tag_read, tag_sent) : '';
                dateBegin = new Date(item.created_time);
                if (Currentpageid == objfrom_id) {
                    tr =
                        '<div id="' + timespan + '" class="messengerDetail_me">'
                        + ((message == "") ? '' : ('<span class="message_me" title="' + created_time + '">' + item.message + '</span>'))
                        + ((sticker == "") ? '' : ('<img class="sticker_me" title="' + created_time + '" src="' + item.sticker + '">'))
                        + Render_MessengerDetail_Attachment(attachments, "me", created_time)
                        + '</div>'
                    if (i == 0 || (i != 0 && data[i - 1].objfrom.id == Currentprofileid)) tr = tr + '<span class="message_me message_me_time_send" id="send_' + timespan + '">' + created_time_onlyhour + '</span>';
                }
                else {
                    tr =
                        '<div id="' + timespan + '" class="messengerDetail_client">'
                        + ((message == "") ? '' : ('<span class="message_client" title="' + created_time + '">' + item.message + '</span>'))
                        + ((sticker == "") ? '' : ('<img class="sticker_client" title="' + created_time + '" src="' + item.sticker + '">'))
                        + Render_MessengerDetail_Attachment(attachments, "client", created_time)
                        + '</div>'
                    if (i == 0 || (i != 0 && data[i - 1].objfrom.id != Currentprofileid)) tr = tr + '<span class="message_client message_client_time_send" id="send_' + timespan + '">' + created_time_onlyhour + '</span>';
                }

                stringContent = stringContent + dateLine + tr //+ readsentStatus;
            }
        }

        document.getElementById(id).innerHTML = stringContent;
    }
    //$("#MessengerArea_Messenger").niceScroll({
    //    cursorwidth: 7,
    //    cursoropacitymin: 0.4,
    //    cursorcolor: '#6e8cb6',
    //    cursorborder: 'none',
    //    scrollspeed: 20,
    //    mousescrollstep: 55,
    //    cursorborderradius: 4,
    //    autohidemode: true,
    //    horizrailenabled: false,
    //});
    // Face_MessageStatus("mark_seen");
    $('.message_me,.message_client,.sticker_client,.sticker_me,.image_me,.video_me,.file_me,.image_client,.video_client,.file_client').qtip({ // Grab some elements to apply the tooltip to
        content: {
            text: function (event, api) {
                //
                // Retrieve content from custom attribute of the $('.selector') elements.
                return $(this).attr('oldtitle');
            }
        }
    })

    Face_ScrollContentToLast(loadmore);
    Face_EventLickImage();
}
/// RENDER
function Render_ReadMessage(created_time) {
    let result = "";
    var profile_Avatar = document.getElementById("profile_Avatar");
    if (profile_Avatar != 'undefined' && profile_Avatar) {
        // In page
        let src = profile_Avatar.src;
        result = '<img class="ui mini circular image readAvatar"  src="' + src + '"><span style="float: right;margin-right: 4px;">' + created_time + '</span>';
    }
    return result;
}
function Render_MessengerDetail_Attachment(attachments, type, created_time) {
    if (attachments == null) return "";
    else {
        let resultMain = '';
        for (i = 0; i < attachments.length; i++) {
            if (attachments[i] != null) {
                let mime_type = attachments[i].mime_type;
                let url = attachments[i].url;
                let name = decodeURI(attachments[i].name);
                let result = "";
                if (type == "me") {
                    if (mime_type.includes('image')) result = '<img class="image_me" title="' + created_time + '" src="' + url + '">';
                    else if (mime_type.includes('video')) result = '<video class="video_me" title="' + created_time + '" controls><source type="' + mime_type + '" src="' + url + '"></video>';
                    else result = '<a class="file_me" title="' + created_time + '" href="' + url + '">' + '<i class="arrow down icon" style="display: contents;"></i>&nbsp;&nbsp;' + name + '</a>';

                }
                else {
                    if (mime_type.includes('image')) result = '<img class="image_client" title="' + created_time + '" src="' + url + '">';
                    else if (mime_type.includes('video')) result = '<video class="video_client" title="' + created_time + '" controls><source type="' + mime_type + '" src="' + url + '"></video>';
                    else result = '<a class="file_client" title="' + created_time + '" href="' + url + '">' + '<i class="arrow down icon" style="display: contents;"></i>&nbsp;&nbsp;' + name + '</a>';
                }
                resultMain = resultMain + result;
            }
        }
        return resultMain;
    }
}
function Render_MessengerDetail_Date(created_time, dateBegin) {

    var d = new Date(created_time);
    if (d.getDate() == dateBegin.getDate() && d.getYear() == dateBegin.getYear() && d.getMonth() == dateBegin.getMonth()) {
        return '';
    }
    else {
        return '<div class="linedate">' + 'Ngày ' + d.getDate() + ' tháng ' + (d.getMonth() + 1) + ' năm ' + d.getFullYear() + '</div>';
    }
}
function Render_MessengerDetail_ReadSent(tag_read, tag_sent) {
    return '<span class="readsent">' + tag_read + '</span>';

}
function Face_InboxFromComment(message) {
    $.ajax({
        url: "/Views/Facebook/pageMessenger.aspx/SaveInboxFromComment",
        dataType: "json",
        type: "POST",
        data: JSON.stringify({ 'CurrentCommentId': CurrentCommentId, 'CurrentPostId': CurrentPostId, 'message': message }),
        contentType: 'application/json; charset=utf-8',
        async: true,
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            notiError();
        },
        success: function (result) {
        }
    })
}
function Face_UpdateLastTimeConveration(page, profile) {
    $.ajax({
        url: "/Views/Facebook/pageMessenger.aspx/UpdateLastTimeConveration",
        dataType: "json",
        type: "POST",
        data: JSON.stringify({ 'page': page, 'profile': profile }),
        contentType: 'application/json; charset=utf-8',
        async: true,
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            notiError();
        },
        success: function (result) {
        }
    })
}
function Face_UpdateReadConveration(page, conver, profile) {
    $.ajax({
        url: "/Views/Facebook/pageMessenger.aspx/UpdateReadConveration",
        dataType: "json",
        type: "POST",
        data: JSON.stringify({ 'page': page, 'conver': conver, 'profile': profile }),
        contentType: 'application/json; charset=utf-8',
        async: true,
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            notiError();
        },
        success: function (result) {
        }
    })
}
function Face_UpdateUnReadConveration(page, conver, profile) {
    $.ajax({
        url: "/Views/Facebook/pageMessenger.aspx/UpdateUnReadConveration",
        dataType: "json",
        type: "POST",
        data: JSON.stringify({ 'page': page, 'conver': conver, 'profile': profile }),
        contentType: 'application/json; charset=utf-8',
        async: true,
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            notiError();
        },
        success: function (result) {
        }
    })
}

function Face_UpdateReadComment(comment, post, profile) {
    $.ajax({
        url: "/Views/Facebook/pageMessenger.aspx/UpdateReadComent",
        dataType: "json",
        type: "POST",
        data: JSON.stringify({ 'comment': comment, 'post': post, 'profile': profile }),
        contentType: 'application/json; charset=utf-8',
        async: true,
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            notiError();
        },
        success: function (result) {
        }
    })
}
async function onLoadPersonalInfo_Ticket() {
    $("#ticketinfoFace_loaderList").show();
    $("#ticketinfoFace").hide();
    await onLoadPersonalInfo_TicketAsync();
    $("#ticketinfoFace_loaderList").hide();
    $("#ticketinfoFace").show();
    return false;
}
function onLoadPersonalInfo_TicketAsync(extension) {
    return new Promise((resolve, reject) => {
        setTimeout(
            () => {
                LoadTicketProfileToFace();
                resolve()
            },
            Math.floor(Math.random() * 300) + 1
        )
    })
}
function SaveNewTicketValue() {
    $('#notiTicketvalue').html('');
    if (ticketid_profile != "0") {
        let content = $('#txtContentValueTicketFace').val() ? $('#txtContentValueTicketFace').val() : "";
        if (content != "") {
            $('#txtContentValueTicketFace').val('');
            $.ajax({
                url: "/Views/Facebook/pageMessenger.aspx/SaveNewTicketValue",
                dataType: "json",
                type: "POST",
                data: JSON.stringify({ 'ticketid': ticketid_profile, 'content': content }),
                contentType: 'application/json; charset=utf-8',
                async: false,
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    notiError("Lỗi Hệ Thống");
                },
                success: function (result) {
                    if (result.d != "0") {
                        LoadTicketProfileToFace();
                    }
                }
            });
        } else {
            $('#notiTicketvalue').html('Nội dung không được rỗng');
        }
    }
}
function SaveNewcallbackValue() {
    let datecallback = $('#Date_from_call_back').val() ? $('#Date_from_call_back').val() : "";
    $.ajax({
        url: "/Views/Facebook/pageMessenger.aspx/SaveNewCallBack",
        dataType: "json",
        type: "POST",
        data: JSON.stringify({ 'profileid': Currentprofileid, 'pageid': Currentpageid, 'datecallback': datecallback }),
        contentType: 'application/json; charset=utf-8',
        async: false,
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            notiError("Lỗi Hệ Thống");
        },
        success: function (result) {
            if (result.d != "0") {
                LoadTicketProfileToFace();
            }
        }
    });
}
function DeleteCallBackValue(id) {
    $.ajax({
        url: "/Views/Facebook/pageMessenger.aspx/DeleteCallBack",
        dataType: "json",
        type: "POST",
        data: JSON.stringify({ 'currentid': id }),
        contentType: 'application/json; charset=utf-8',
        async: false,
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            notiError("Lỗi Hệ Thống");
        },
        success: function (result) {
            if (result.d != "0") {
                LoadTicketProfileToFace();
            }
        }
    });
}
function FromFaceToCustomer() {
    if (customerid_profile != "0" && customerid_profile != "") {
        window.open("/Views/Customer/MainCustomer.aspx?CustomerID=" + customerid_profile + "&ver=" + versionofWebApplication);
    }
}
function FromFaceToTicket() {
    if (ticketid_profile != "0" && ticketid_profile != "") {
        window.open("/Views/Marketing/pageTicketAction.aspx?CustomerID=" + customerid_profile + "&TicketID=" + ticketid_profile + "&ver=" + versionofWebApplication);
    }
    else {
        let namme = document.getElementById("face_name").innerHTML;
        let ServiceCareToken = $('#ServiceCareFace').dropdown('get value') ? $('#ServiceCareFace').dropdown('get value') : ''
        //let gender = document.getElementById("face_gender").innerHTML;
        document.getElementById("divDetailPopup").innerHTML = '';
        $("#divDetailPopup").load("/Views/Marketing/pageTicketDetail.aspx" + "?ver=" + versionofWebApplication + '&KeyPage=' + Currentpageid + '&faceid=' + Currentprofileid + '&servicecare=' + encodeURI(ServiceCareToken) + '&name="' + encodeURI(namme) + '"');
        $('#divDetailPopup').modal('show');
    }
}
//function ScrollTagPersional() {
//    //$("#ticketinfoFace").niceScroll({
//    //    cursorwidth: 7,
//    //    cursoropacitymin: 0.4,
//    //    cursorcolor: '#6e8cb6',
//    //    cursorborder: 'none',
//    //    scrollspeed: 30,
//    //    mousescrollstep: 55,
//    //    cursorborderradius: 4,
//    //    autohidemode: true,
//    //    horizrailenabled: false,
//    //});
//    //$('.ui.accordion').accordion({
//    //    exclusive: false,
//    //    duration: 500
//    //});
//}
//function ScrollTagPersional_History() {
//    $("#ticketvalue").niceScroll({
//        cursorwidth: 7,
//        cursoropacitymin: 0.4,
//        cursorcolor: '#6e8cb6',
//        cursorborder: 'none',
//        scrollspeed: 30,
//        mousescrollstep: 55,
//        cursorborderradius: 4,
//        autohidemode: true,
//        horizrailenabled: false,
//    });
//    $('.ui.accordion').accordion({
//        exclusive: false,
//        duration: 500
//    });
//    $("#ticketinfoFace").getNiceScroll().resize();
//}

function RenderTagFacebookToTicket(data, id, tagfacebook) {

    tagfacebook = "," + tagfacebook;
    var myNode = document.getElementById(id);
    let stringContent = '';
    if (myNode != null) {
        myNode.innerHTML = '';
        if (data && data != undefined && data != "") {
            for (var i = 0; i < data.length; i++) {
                let item = data[i];
                let id = item.ID;
                let divcheck = '';
                id = ',' + id + ',';

                if (tagfacebook.includes(id)) {
                    divcheck =
                        '<div class="ui checkbox facebooktag_ticket_checked">'
                        + '<input id="tickettag' + item.ID + '" type="checkbox" value=' + item.ID + ' class="facebooktag" checked>'
                        + '<label for="tickettag' + item.ID + '" class="tagface_text">' + item.Name + '</label>'
                        + '<i class="circle mini red icon avt circle_tag" style="font-size: 12px;color:' + item.Color + ' !important" ></i>'
                        + '</div>';
                }
                else {
                    divcheck =
                        '<div class="ui checkbox facebooktag_ticket">'
                        + '<input  id="tickettag' + item.ID + '" type="checkbox" value=' + item.ID + ' class="facebooktag">'
                        + '<label  for="tickettag' + item.ID + '" class="tagface_text">' + item.Name + '</label>'
                        + '<i class="circle mini red icon avt circle_tag" style="font-size: 12px;color:' + item.Color + ' !important"></i>'
                        + '</div>';
                }
                stringContent = stringContent + divcheck;
            }
        }
        document.getElementById(id).innerHTML = stringContent;
    }
    //   ScrollTagPersional();
    $(".facebooktag").change(function () {
        currentchecktag = "";
        var x = document.getElementsByClassName("facebooktag");
        for (let i = 0; i < x.length; i++) {
            if (x[i].checked) {
                currentchecktag = currentchecktag + x[i].value + ",";
            }
        }
        $.ajax({
            url: "/Views/Facebook/pageMessenger.aspx/CheckFacebookTag",
            dataType: "json",
            type: "POST",
            data: JSON.stringify({ 'fromid': Currentprofileid, 'pageid': Currentpageid, 'tag': currentchecktag }),
            contentType: 'application/json; charset=utf-8',
            async: true,
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                notiError("Lỗi Hệ Thống");
            },
            success: function (result) {
                if (result.d != "0") {

                    RenderTagFacebookToTicket(ser_facebookTag, "facebooktag_ticket", currentchecktag);
                    let _currenttag = Render_Tag_InMessegeList(currentchecktag);
                    let id = CurrentConverationId + "__" + Currentprofileid;
                    let imgexe = '<img id="exe_' + id + '" class="imgExecute" src="/img/Face/dot.png" alt="label-image">';
                    if ($('#' + id).length) {
                        let child = $('#' + id).children();
                        if (child != undefined && child != null) {
                            child[3].title = currentchecktag;
                            child[3].innerHTML = _currenttag + imgexe;
                        }
                    }
                    Render_List_MakeEvent();
                    // ScrollTagPersional();
                }
            }
        });
    });
}


function LoadStaffToInbox(pageid, fromid) {
    $("#DectectStaffOnConver").dropdown("refresh");
    $("#DectectStaffOnConver").dropdown("clear");
    $.ajax({
        url: "/Views/Facebook/pageMessenger.aspx/LoadStaffToInbox",
        dataType: "json",
        type: "POST",
        data: JSON.stringify({ 'pageid': pageid, 'fromid': fromid }),
        contentType: 'application/json; charset=utf-8',
        async: true,
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            notiError("Lỗi Hệ Thống");
        },
        success: function (result) {
            currentstaff_isloadcombo = result.d;
            $("#DectectStaffOnConver").dropdown("refresh");
            $("#DectectStaffOnConver").dropdown("set selected", result.d);
        }
    });
}
function Face_AfterSaveStaff() {
    let messegerItem = document.getElementsByClassName("messegerItem");

    for (i = messegerItem.length - 1; i >= 0; i--) {
        id = messegerItem[i].id;
        if (id.includes(Currentprofileid)) {
            if ($("#" + id).length)
                $("#" + id).remove();

        }
    }
}
function Face_SaveDetectStaff() {
    let staffselectedid = (Number($('#DectectStaffOnConver').dropdown('get value')) ? Number($('#DectectStaffOnConver').dropdown('get value')) : 0)
    if (staffselectedid != 0) {
        if (CURRENTMESSCOM == "MESS") {
            $.ajax({
                url: "/Views/Facebook/pageMessenger.aspx/SaveStaff_FromInbox",
                dataType: "json",
                type: "POST",
                data: JSON.stringify({ 'pageid': Currentpageid, 'fromid': Currentprofileid, 'staffid': staffselectedid }),
                contentType: 'application/json; charset=utf-8',
                async: true,
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    notiError("Lỗi Hệ Thống");
                },
                success: function (result) {
                    currentstaff_isloadcombo = result.d;
                    ShowAnimationSave();
                }
            });
        }
        else {
            $.ajax({
                url: "/Views/Facebook/pageMessenger.aspx/SaveStaff_FromComment",
                dataType: "json",
                type: "POST",
                data: JSON.stringify({ 'postid': CurrentPostId, 'fromid': Currentprofileid, 'staffid': staffselectedid }),
                contentType: 'application/json; charset=utf-8',
                async: true,
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    notiError("Lỗi Hệ Thống");
                },
                success: function (result) {
                    currentstaff_isloadcombo = result.d;
                    ShowAnimationSave();
                }
            });
        }
    }
}
function ShowAnimationSave() {
    $('#face_asign_success').show();
    var counter = 4;
    var timer_status = setInterval(function () {
        counter--;
        if (counter < 0) {
            $('#face_asign_success').hide();
            clearInterval(timer_status);
            Face_AfterSaveStaff();
            Face_ResetAllFiledChat();
            $("#MessengerArea_Info").hide();
        }
    }, 100);
}
function LoadStaffToComment(postid, fromid) {
    $("#DectectStaffOnConver").dropdown("refresh");
    $("#DectectStaffOnConver").dropdown("clear");
    $.ajax({
        url: "/Views/Facebook/pageMessenger.aspx/LoadStaffToComment",
        dataType: "json",
        type: "POST",
        data: JSON.stringify({ 'postid': postid, 'fromid': fromid }),
        contentType: 'application/json; charset=utf-8',
        async: true,
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            notiError("Lỗi Hệ Thống");
        },
        success: function (result) {
            currentstaff_isloadcombo = result.d;
            $("#DectectStaffOnConver").dropdown("set selected", result.d);
        }
    });
}
function LoadAreaToInbox(postid, fromid) {
    $("#Area").dropdown("refresh");
    $("#Area").dropdown("clear");
    $.ajax({
        url: "/Views/Facebook/pageMessenger.aspx/LoadAreaToInbox",
        dataType: "json",
        type: "POST",
        data: JSON.stringify({ 'pageid': postid, 'fromid': fromid }),
        contentType: 'application/json; charset=utf-8',
        async: false,
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            notiError("Lỗi Hệ Thống");
        },
        success: function (result) {
            isSaveArea = 0;
            $("#Area").dropdown("set selected", result.d);
            isSaveArea = 1;
        }
    });
}
function LoadServiceCareToInbox(pageid, fromid) {
   
    isSaveServiceCare = 0;
    $("#ServiceCareFace").dropdown("refresh");
    $("#ServiceCareFace").dropdown("clear");
    $.ajax({
        url: "/Views/Facebook/pageMessenger.aspx/LoadServiceCareToInbox",
        dataType: "json",
        type: "POST",
        data: JSON.stringify({ 'pageid': pageid, 'fromid': fromid }),
        contentType: 'application/json; charset=utf-8',
        async: false,
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            notiError("Lỗi Hệ Thống");
        },
        success: function (result) {
            if (result.d != 0) {
                let data = JSON.parse(result.d);
                for (i = 0; i < data.length; i++) {
                    $("#ServiceCareFace").dropdown("set selected", data[i].ID);
                }
               
            }
        }
    });
    isSaveServiceCare = 1;
}
function LoadTicketProfileToFace() {
    document.getElementById("profile_name_facebook").innerHTML = '';
    document.getElementById("profile_phone1").innerHTML = '';
    document.getElementById("profile_phone2").innerHTML = '';
    document.getElementById("profile_link").setAttribute('href', '');
    document.getElementById("profile_gender").innerHTML = '';
    document.getElementById("profile_birthday").innerHTML = '';
    $("#profile_link").hide();
    let pageID = Currentpageid;
    let fromID = Currentprofileid;
    $.ajax({
        url: "/Views/Facebook/pageMessenger.aspx/Loadata",
        dataType: "json",
        type: "POST",
        data: JSON.stringify({ 'pageID': pageID, 'fromID': fromID }),
        contentType: 'application/json; charset=utf-8',
        async: true,
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            notiError("Lỗi Hệ Thống");
        },
        success: function (result) {
            if (result.d != "0") {
                ResetTicketInfo();
                let _TicketDetail = JSON.parse(result.d).Table;
                let _TicketValue = JSON.parse(result.d).Table1;
                let _Tag = JSON.parse(result.d).Table2;
                let _BackTime = JSON.parse(result.d).Table3;
                if (_Tag != undefined && _Tag.length != 0) RenderTagFacebookToTicket(ser_facebookTag, "facebooktag_ticket", _Tag[0].tag);
                else RenderTagFacebookToTicket(ser_facebookTag, "facebooktag_ticket", '0');

                if (_TicketValue != undefined && _TicketValue) {
                    RenderTicketValueFace(_TicketValue, "dtContentTicketValueBody")
                }
                if (_BackTime != undefined && _BackTime) {
                    RenderTicketBackTime(_BackTime, "dtContentcallbackValueBody")
                }

                if (_TicketDetail != undefined && _TicketDetail.length != 0) {
                    document.getElementById("profile_name_facebook").innerHTML = _TicketDetail[0].Name;
                    document.getElementById("profile_phone1").innerHTML = _TicketDetail[0].Phone1;
                    document.getElementById("profile_phone2").innerHTML = _TicketDetail[0].Phone2;
                    document.getElementById("profile_gender").innerHTML = _TicketDetail[0].Gender;
                    document.getElementById("profile_link").setAttribute('href', _TicketDetail[0].Facebookurl);
                    document.getElementById("profile_birthday").innerHTML = ConvertDateTimeToStringRemove1900(_TicketDetail[0].Birthday);
                    ticketid_profile = _TicketDetail[0].TicketID;
                    customerid_profile = _TicketDetail[0].CusID;
                    if (_TicketDetail[0].Facebookurl != "") {
                        $("#profile_link").show();
                    }
                    if (customerid_profile != "0") {
                        document.querySelector('#facetoCustomer').textContent = _TicketDetail[0].CusCode;

                        $('#facetoticket').attr('src', '/img/Face/T.png');
                        $('#facetoticket').attr('title', 'Đến Ticket');

                        $("#facetoticket").show();
                        $("#facetoCustomer").show();
                    }
                    else {
                        $('#facetoticket').attr('src', '/img/Face/T.png');
                        $('#facetoticket').attr('title', 'Đến Ticket');
                        $("#facetoticket").show();
                        $("#facetoCustomer").hide();
                    }
                    $("#ticketinfo").show();
                    $("#ticketvalue").show();
                    $("#ticketinfoshow").show();
                }
                else {
                    $('#facetoticket').attr('src', '/img/Face/newticket.png');
                    $('#facetoticket').attr('title', 'Tạo Ticket');


                    $("#facetoticket").show();
                    $("#facetoCustomer").hide();
                    $("#ticketinfo").hide();
                    $("#ticketvalue").hide();
                    $("#ticketinfoshow").hide();
                    ticketid_profile = "0";
                    customerid_profile = "0";
                }
                //  ScrollTagPersional();
            }
        }
    });
    return false;
}
function InsertProfile_ToList() {
    let id = CurrentConverationId + "__" + Currentprofileid;
    if ($('#' + id).length) {
        let child = $('#' + id).children();
        if (child != undefined && child != null) {
            var newelement = createElementFromHTML('<img class="imgMessCom" title="Có Hồ Sơ" style="right: 20px !important;" src="/img/Face/profile_.png" alt="label-image">');
            child[2].append(newelement);
        }
    }
}
function ResetTicketInfo() {
    ticketid_profile = "0";
    customerid_profile = "0";
}
function RenderTicketValueFace(data, id) {
    var myNode = document.getElementById(id);
    if (myNode != null) {
        myNode.innerHTML = '';
        let stringContent = '';
        if (data && data.length > 0) {
            for (var i = 0; i < data.length; i++) {
                let item = data[i];
                let tr =
                    '<td>' + item.Content
                    + '<span class="noteticket_per">' + item.CreatedName + '</span>'
                    + '<span class="noteticket_date">' + item.CreatedHour + '  ' + item.CreatedDay + '</span>'

                    + '</td>'
                stringContent = stringContent + '<tr role="row">' + tr + '</tr>';
            }
        }
        document.getElementById(id).innerHTML = stringContent;
    }
}

function RenderTicketBackTime(data, id) {
    var myNode = document.getElementById(id);
    if (myNode != null) {
        myNode.innerHTML = '';
        let stringContent = '';
        let NumberOfDay = 0;
        if (data && data.length > 0) {
            let CreatedDate = "";
            let unevent_event = 0;
            for (var i = 0; i < data.length; i++) {
                let item = data[i];
                let setLevel = 0;
                let CountRow = 0;
                if (CreatedDate != item.BackTimeDate) {
                    NumberOfDay = NumberOfDay + 1;
                    CreatedDate = item.BackTimeDate;
                    setLevel = 1;
                    unevent_event = unevent_event + 1;
                    for (let j = 0; j < data.length; j++) {
                        if (data[j].BackTimeDate == CreatedDate) {
                            CountRow = CountRow + 1;
                        }
                    }
                }

                let tr =
                    '<td style="display:none !important;">' + item.ID + '</td>'
                    + ((setLevel == 0) ? '' : ('<td rowspan="' + CountRow + '">' + '<div class="NumberOfDay">N ' + NumberOfDay + '</div>' + '</td>'))
                    + '<td>' + ConvertDateTimeUTC_DMYHM(item.BackTime) + '</td>'
                    + ((item.DeleteButton === 1)
                        ? ('<td><button class="buttonGrid" value="'
                            + item.ID
                            + '"><img class="buttonDeleteClass imgGrid" src="/img/ButtonImg/delete.png"></button></td>')
                        : '<td></td>')
                stringContent = stringContent + '<tr role="row" style="background-color:' + ((unevent_event % 2 == 0) ? '#dfebf6ad' : 'white') + '">' + tr + '</tr>';
            }
        }
        document.getElementById(id).innerHTML = stringContent;
    }

}
function Face_SaveArea() {
    let Areaselectedid = (Number($('#Area').dropdown('get value')) ? Number($('#Area').dropdown('get value')) : 0)
    if (Areaselectedid != 0 && isSaveArea == 1) {
        if (CURRENTMESSCOM == "MESS") {
            $.ajax({
                url: "/Views/Facebook/pageMessenger.aspx/SaveArea_FromInbox",
                dataType: "json",
                type: "POST",
                data: JSON.stringify({ 'pageid': Currentpageid, 'fromid': Currentprofileid, 'areaid': Areaselectedid }),
                contentType: 'application/json; charset=utf-8',
                async: true,
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    notiError("Lỗi Hệ Thống");
                },
                success: function (result) {
                }
            });
        }
    }
}
function Face_SaveServiceCare() {
    let ServiceCareToken = $('#ServiceCareFace').dropdown('get value') ? $('#ServiceCareFace').dropdown('get value') : ''
    if (ServiceCareToken != '' && isSaveServiceCare == 1) {
        if (CURRENTMESSCOM == "MESS") {
            $.ajax({
                url: "/Views/Facebook/pageMessenger.aspx/SaveServiceCare_FromInbox",
                dataType: "json",
                type: "POST",
                data: JSON.stringify({ 'pageid': Currentpageid, 'fromid': Currentprofileid, 'ServiceCareToken': ServiceCareToken }),
                contentType: 'application/json; charset=utf-8',
                async: true,
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    notiError("Lỗi Hệ Thống");
                },
                success: function (result) {
                }
            });
        }
    }
}
function LoadDiscountToInbox(pageid, fromid) {
    $.ajax({
        url: "/Views/Facebook/pageMessenger.aspx/LoadDiscountToInbox",
        dataType: "json",
        type: "POST",
        data: JSON.stringify({ 'pageid': pageid, 'fromid': fromid }),
        contentType: 'application/json; charset=utf-8',
        async: false,
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            notiError("Lỗi Hệ Thống");
        },
        success: function (result) {
            isSaveDiscount = 0;
            $("#DiscountFace").dropdown("clear");
            let dataDiscountCB;
            let idDiscount = 0;
            if (result.d != 0) {
                let data = JSON.parse(result.d);
                dataDiscountCB = DiscountFace_Combo.filter(function (discount) {
                    let date_fromStr = discount.Date_From.split('-');
                    let date_toStr = discount.Date_To.split('-');
                    let date_From = new Date(date_fromStr[0], (date_fromStr[1]-1), date_fromStr[2], 0, 0, 0, 0);
                    let date_To = new Date(date_toStr[0], (date_toStr[1]-1), date_toStr[2], 0, 0, 0, 0);
                    let datenow = new Date();
                    if ((discount.State == 1 && (datenow > date_From && datenow < date_To) ) || (discount.ID == data[0].ID)) {
                        return discount;
                    }
                })
                idDiscount = data[0].ID;
               
            } else {
                dataDiscountCB = DiscountFace_Combo.filter(function (discount) {
                    let date_fromStr = discount.Date_From.split('-');
                    let date_toStr = discount.Date_To.split('-');
                    let date_From = new Date(date_fromStr[0], (date_fromStr[1] - 1), date_fromStr[2], 0, 0, 0, 0);
                    let date_To = new Date(date_toStr[0], (date_toStr[1] - 1), date_toStr[2], 0, 0, 0, 0);
                    let datenow = new Date();
                    if ((discount.State == 1 && (datenow > date_From && datenow < date_To))) {
                        return discount;
                    }
                })
            }
            LoadCombo(dataDiscountCB, "cbbDiscountFace");
            $("#DiscountFace").dropdown("refresh");
            $("#DiscountFace").dropdown("set selected", idDiscount);
            isSaveDiscount = 1;
        }
    });
}
function Face_SaveDiscount() {
    let DiscountID = $('#DiscountFace').dropdown('get value') ? $('#DiscountFace').dropdown('get value') : 0;
    if (CURRENTMESSCOM == "MESS" && isSaveDiscount == 1) {
        $.ajax({
            url: "/Views/Facebook/pageMessenger.aspx/SaveDiscount_FromInbox",
            dataType: "json",
            type: "POST",
            data: JSON.stringify({ 'pageid': Currentpageid, 'fromid': Currentprofileid, 'DiscountID': DiscountID }),
            contentType: 'application/json; charset=utf-8',
            async: true,
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                notiError("Lỗi Hệ Thống");
            },
            success: function (result) {
            }
        });
    }
}
function LoadMessengerTemplate(){
    let text = $('#searchingMessengerTemplate').val() ? $('#searchingMessengerTemplate').val() : '';
    $.ajax({
        url: "/Views/Facebook/pageMessenger.aspx/LoadMessengerTemplate",
        dataType: "json",
        type: "POST",
        data: JSON.stringify({ 'text': text }),
        contentType: 'application/json; charset=utf-8',
        async: false,
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            notiError("Lỗi Hệ Thống");
        },
        success: function (result) {
            if (result.d != 0) {
                let data = JSON.parse(result.d);
                RenderMessengerTemplate(data, 'MessengerTemplateBody');
            }
        }
    });
}
function RenderMessengerTemplate(data, id) {
    var myNode = document.getElementById(id);
    if (myNode != null) {
        myNode.innerHTML = '';
        let stringContent = '';
        if (data.length > 0) {
            
            for (let i = 0; i < data.length; i++) {
                let item = data[i];
                let tr = '<div class="TemplateItemTitle">'
                    + item.Title
                    + '</div>'
                    + '<div class="TemplateItemBody">'
                    + item.Description
                    + '</div>'
                   
                stringContent = stringContent + '<div class="TemplateItem">' + tr + '</div>';
            }
        }
        document.getElementById(id).innerHTML = stringContent;
    }
    EventMessengerTemplate();
}
function EventMessengerTemplate() {
    $('#MessengerTemplateBody').on('click', '.TemplateItem', function () {
        let elms = $(this).children('.TemplateItemBody');
        $('#txtContentMessage').val($(elms).html());
    });
}