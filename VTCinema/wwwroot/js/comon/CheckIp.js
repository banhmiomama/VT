function CheckIPUser(ip) {
    $.ajax({
        url: "/Views/Login/Login.aspx/DetectIP",
        dataType: "json",
        type: "POST",
        data: JSON.stringify({ 'ip': ip }),
        contentType: 'application/json; charset=utf-8',
        async: true,
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            notiError();
        },
        success: function (result) {
            if (result.d == "0") {
                window.open("/Error/index_ip.html", "_self")
            }
        }
    });

}
