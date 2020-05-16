// Login

var facebook_accessToken;
var facebook_userID;
var facebook_link_permission = "https://graph.facebook.com/v4.0/me/permissions";
var facebook_link_getlistpage = "https://graph.facebook.com/v4.0/me/accounts?fields=picture{url},id,access_token,name,link";
var facebook_permission_need = ['manage_pages', 'publish_pages', 'pages_messaging'];
var facebook_page_list = [];




function Facbook_Logout() {
    //FB.logout(function (response) {
    //    window.location.replace("/Views/Facebook/pageFacebookConnect.aspx?ver=" + versionofWebApplication);
    //});
    alert("logout")
}
function statusChangeCallback_facebooklogin(response) {
    if (response.authResponse != undefined && response.status == "connected") {
        facebook_accessToken = response.authResponse.accessToken;
        facebook_userID = response.authResponse.userID;
        $("#loginbutton").hide();
        $("#login").hide();
        Face_SuccessLogin();
    }
    else {
        Facbook_Logout();
    }
}


// After login, check permission
function Face_SuccessLogin(e) {
    //if (e != null && e != undefined) location.reload();
    $.ajax({
        url: facebook_link_permission + "?access_token=" + facebook_accessToken,
        dataType: "json",
        type: "GET",
        data: JSON.stringify({}),
        contentType: 'application/json; charset=utf-8',
        async: true,
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            Facbook_Logout();
        },
        success: function (result) {
            if (result.data != undefined && result.data.length != undefined) {
                let author = true;
                for (i = 0; i < facebook_permission_need.length; i++) {
                    let authorEach = false;
                    for (j = 0; j < result.data.length; j++) {
                        if (facebook_permission_need[i] == result.data[j].permission) {
                            if (result.data[j].status == "granted") authorEach = true;
                        }
                    }
                    if (!authorEach) {
                        author = false;
                        break;
                    }
                }

                if (author) { console.log("OK"); Face_GetListPage();  }
                else Facbook_Logout();
            }
        }
    })
}

// Get page list facebook fanpage
function Face_GetListPage() {
    $.ajax({
        url: facebook_link_getlistpage + "&access_token=" + facebook_accessToken,
        dataType: "json",
        type: "GET",
        data: JSON.stringify({}),
        contentType: 'application/json; charset=utf-8',
        async: true,
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            notiError();
        },
        success: function (result) {
            let data = result.data;
            if (data != undefined && data.length != 0) {
                console.log(data)
                facebook_page_list = data;
                Facebook_Render_PageList(facebook_page_list, "facebook_list_fanpage");
            }
            else {
                Facbook_Logout();
            }
        }
        ,
        beforeSend: function () {
            $("#Pagechoosing_Current").hide();
            $("#Pagechoosing_Current_Register").show();
        },
        complete: function () {
            $("#Pagechoosing_Current").show();
            $("#Pagechoosing_Current_Register").hide();
        }

    })
}




function Facebook_Render_PageList(data, id) {
    var myNode = document.getElementById(id);
    if (myNode != null) {
        myNode.innerHTML = '';
        let stringContent = '';
        if (data && data.length > 0) {
            for (var i = 0; i < data.length; i++) {
                let item = data[i];
                let tr =
                    '<div>'
                    + '<img class="ui mini circular image pageAvatar" src="' + item.picture.data.url + '" alt="label-image" />'
                    + '<span id="new_' + item.id + '" class="icon-noti_new" style="display: none;">*</span>'
                    + '<span style="display: inline;padding-left: 10px;">' + item.name + '</span>'
                    + '</div>'
                stringContent = stringContent + '<a class="item pageFaceMenu" href="#" title="' + item.id + '">' + tr + '</a>';
            }
        }

        document.getElementById(id).innerHTML = stringContent;
        if (stringContent != "") {
            $("#menuChoosingPage").show();
            $("#MessengerArea").show();

        }
        else {
            $("#menuChoosingPage").hide();
            $("#MessengerArea").hide();


        }
        var target = document.getElementById('loginbutton')
        document.getElementById('facebook_list_fanpage').appendChild(target)
        $('#loginbutton').css('display', '');
        $('#loginbutton').css('margin', '5px 34px');
        $('#facebook_list_fanpage').append('<div id="loguot" style="position: absolute;height: 50px;z-index: 15;width: 217px;bottom: 0px;cursor: pointer;"></div>')
        $('#loguot').click(function () {
            Facbook_Logout();
        });
    }
    $(".pageFaceMenu").click(function (event) {
        var id = this.title;
        Face_SetCurrentPage(id);
        $("#starProfileMess").hide();
        $("#spamProfileMess").hide();

    });
}