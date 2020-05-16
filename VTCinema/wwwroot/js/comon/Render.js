//#region  Render Menu,poup up user
function RenderMenuPopupUser(data, id) {
    var myNode = document.getElementById(id);
    if (myNode != null) {
        myNode.innerHTML = '';
        let stringContent = '';
        if (data && data.length > 0) {
            let idGroup = "0";
            for (var i = 0; i < data.length; i++) {
                let item = data[i];

                if (item.Group.length > 0) {

                    if (item.Group != idGroup) {
                        stringContent = stringContent +
                            '<div class="item">' +
                            '<span class="text">' + item.Group + '</span>' +
                            '<i class="right dropdown icon"></i>' +
                            '<div class="left menu transition hidden" style="box-shadow: rgb(99, 98, 98) 0px 0px 5px -3px;">';
                    }
                    stringContent = stringContent + '<a class="item" id="' + item.Name + '" href="' + item.Link + '?ver=' + versionofWebApplication + '">' + item.Text;

                    if (item.Name == 'notificationList') stringContent += '<span id="icon-noti-app2" class="icon-noti-dow" ></span>'

                    stringContent += '</a>';


                    idGroup = item.Group;

                } else {
                    if (item.Group != idGroup) {
                        stringContent = stringContent + '</div></div>';
                    }

                    stringContent = stringContent + '<a class="item" id="' + item.Name + '" href="' + item.Link + '?ver=' + versionofWebApplication + '">' + item.Text;
                    if (item.Name == 'notificationList') stringContent += '<span id="icon-noti-app2" class="icon-noti-dow" ></span>'
                    stringContent += '</a>';
                }

            }
        }
        document.getElementById(id).innerHTML = stringContent;
    }
}
function RenderMenuMobile(data, id) {
    var myNode = document.getElementById(id);
    if (myNode != null) {
        myNode.innerHTML = '';
        let stringContent = '';
        if (data && data.length > 0) {
            let imgGroup = "";
            let textGroup = "";
            let idGroup = 0;
            for (var i = 0; i < data.length; i++) {
                let item = data[i];
                if (item.GroupID != idGroup) {
                    imgGroup = item.GroupImage;
                    textGroup = item.GroupText;
                    idGroup = item.GroupID;
                    stringContent = stringContent +
                        '<div class="ui dropdown item displaynone scrolling menuSmallDropdown">'
                        + '<span>' + textGroup + '</span>'
                        + '<img src="/img/ButtonImg/' + imgGroup + '" />'
                        + '<div class="menu" style="background-color: #30536d;min-height: 2000px;"><div class="header" style="color: white;">' + textGroup + '</div><div class="ui divider"></div>'

                }

                stringContent = stringContent + '<a data-tab="' + item.MenuTab + '" style="color:white !important; font-size: 11px !important;" class="item _tab_control_" '
                    +
                    (
                        (item.MenuIDText != "")
                            ? 'id="' + ((item.MenuIDText == 'menuCustomerCreate') ? 'menuCustomerCreate1' : item.MenuIDText) + '"'
                            : ''
                    )
                    +
                    ' href="' + item.MenuURL + '?ver=' + versionofWebApplication + '">' + item.MenuText + '</a>'
                if ((i === data.length - 1) || idGroup !== data[i + 1].GroupID) {
                    stringContent = stringContent + "</div></div>";
                }
            }
        }
        document.getElementById(id).innerHTML = stringContent;
    }
    Checking_TabControl_Permission();
    EventAddCustomer();
}

//<div class="header">
//    People You Might Know
//                                </div>
//    <div class="item">
//        <img class="ui avatar image" src="img/avatar/people/enid.png" alt="label-image" />
//        Janice Robinson
//                                </div>

function RenderNotificationBYUser(data, id) {
    var myNode = document.getElementById(id);
    if (myNode != null) {
        myNode.innerHTML = '';
        let stringContent = '<div class="header">Thông Báo Chăm Sóc Và Follow Khách Hàng</div>';
        if (data && data.length > 0) {
            for (var i = 0; i < data.length; i++) {
                let item = data[i];
                stringContent = stringContent
                    + '<div class="item" style="height: 40px;">'
                    + '<div class="ui red label mini circular notification_by_user_detail">' + item.Num + '</div>'
                    + '<a href="' + item.Link + '" class="header">'
                    + item.Type
                    + '</a>'
                    + '</div>'
            }
        }
        document.getElementById(id).innerHTML = stringContent;
    }

}

function RenderMenuDesktop(data, id, active) {

    var myNode = document.getElementById(id);
    if (myNode != null) {
        myNode.innerHTML = '';
        let stringContent = '';
        if (data && data.length > 0) {
            let imgGroup = "";
            let textGroup = "";
            let idGroup = 0;
            let indexGroup = -1;
            for (var i = 0; i < data.length; i++) {
                let item = data[i];
                if (item.GroupID != idGroup) {
                    indexGroup = indexGroup + 1;
                    imgGroup = item.GroupImage;
                    textGroup = item.GroupText;
                    idGroup = item.GroupID;
                    stringContent = stringContent +
                        '<div><div class="title item ' + ((active != undefined) ? "active" : "") + '">'
                        + '<img src="/img/ButtonImg/' + imgGroup + '" />'
                        + '<i class="dropdown icon"></i>' + textGroup + '</div><div class="content ' + ((active != undefined) ? "active" : "") + '">'

                }
                stringContent = stringContent + '<a  data-tab="' + item.MenuTab + '" data-index="' + indexGroup + '" data-search="' + item.MenuNoSign + '" class="item menudesktop_render _tab_control_" style="font-size: 11px !important;"'
                    +
                    (
                        (item.MenuIDText != "")
                            ? 'id="' + item.MenuIDText + '"'
                            : '')
                    + ' href="' + item.MenuURL + '?ver=' + versionofWebApplication
                    + '">' + item.MenuText + '</a>'
                if ((i === data.length - 1) || idGroup !== data[i + 1].GroupID) {
                    stringContent = stringContent + "</div></div>";
                }
            }
        }

        document.getElementById(id).innerHTML = stringContent;
    }
    Checking_TabControl_Permission();
    EventAddCustomer();
}
//#endregion