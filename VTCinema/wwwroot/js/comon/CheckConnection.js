//JUST AN EXAMPLE, PLEASE USE YOUR OWN PICTURE!
var imageAddr = "";
var downloadSize = 4995374; //bytes

function ShowProgressMessage(msg, speedMbps) {
    //if (console) {
    //    if (typeof msg == "string") {
    //        console.log(msg);
    //    } else {
    //        for (var i = 0; i < msg.length; i++) {
    //            console.log(msg[i]);
    //        }
    //    }
    //}

    let oProgress = document.getElementById("StatusOfNetwork");
    if (oProgress) {
        oProgress.innerHTML = msg;
        if (Number(speedMbps) > 200) {
            oProgress.style.color = "#00d933";
        }
        else {
            oProgress.style.color = "#c68d8d";
        }
    }
}
function InitiateSpeedDetection() {
    ShowProgressMessage("Checking connection, please wait...");
    window.setTimeout(MeasureConnectionSpeed, 1);
};
function CheckConnection(image) {
    debugger
    if (image != "") {
        imageAddr = image;
        InitiateSpeedDetection();
    }
    else {
        let oProgress = document.getElementById("StatusOfNetwork");
        oProgress.innerHTML = "Checking Fail...."
    }
    return false;
}
function MeasureConnectionSpeed() {
    var startTime, endTime;
    var download = new Image();
    download.onload = function () {
        endTime = (new Date()).getTime();
        showResults();
    }
    download.onerror = function (err, msg) {
        ShowProgressMessage("Invalid or error checking");
    }
    startTime = (new Date()).getTime();
    var cacheBuster = "?nnn=" + startTime;
    download.src = imageAddr + cacheBuster;
    function showResults() {
        var duration = (endTime - startTime) / 1000;
        var bitsLoaded = downloadSize * 8;
        var speedBps = (bitsLoaded / duration).toFixed(2);
        var speedKbps = (speedBps / 1024).toFixed(2);
        var speedMbps = (speedKbps / 1024).toFixed(2);
        ShowProgressMessage(("Your connection speed is </br>" + speedMbps + " vts"), speedMbps);
    }
}

function CheckingvoiceDevice() {
    debugger
    let oProgress = document.getElementById("StatusOfVoiceDevice");
    navigator.getUserMedia = navigator.getUserMedia ||
        navigator.webkitGetUserMedia ||
        navigator.mozGetUserMedia;

    if (navigator.getUserMedia) {
        debugger
        navigator.getUserMedia({ audio: true, video: false },
            function (stream) {
                oProgress.innerHTML = "Accessed the Microphone";
                oProgress.style.color = "#00d933";
            },
            function (err) {
                oProgress.innerHTML = "Not connect Microphone";
                oProgress.style.color = "#c68d8d";
            }
        );
    } else {
    }
}