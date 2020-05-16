//#region  Popup Main
function CloseModal() {
    if ($('#divDetailPopupLV2').css('display') == 'none') {
        $('#divDetailPopup').modal('hide');
        $('#divDetailPopup').empty();
        document.getElementById("divDetailPopup").innerHTML = '';
    }
    else {
        $('#divDetailPopupLV2').modal('hide');
        $('#divDetailPopupLV2').empty();
        document.getElementById("divDetailPopupLV2").innerHTML = '';
        $("#divDetailPopup").css("opacity", "1");
    }
}
function CloseModalIncomingDetect() {
    $('#divDetailPopupDetectInComing').modal('hide');
}
function CloseModalSlide() {
    $('#divFistSlideGuide').modal('hide');
}
function PrepageModal2() {
    $("#divDetailPopup").css("opacity", "0");
    document.getElementById("divDetailPopupLV2").innerHTML = '';
    $("#divDetailPopup").prepend('<div id="topDetailPopup" style="position: absolute;height: 100 %;width: 100 %;z-index: 1;"> </div>');

}

        //#endregion