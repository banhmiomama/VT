var lobibox_message

function notiSuccess() {
    Lobibox.notify("success", {
        size: "normal",
        rounded: false,
        delayIndicator: true,
        msg: "Thành Công ",
        //icon: null,
        //title: "aaaaaa",
        soundPath: '/dist/plugins/lobibox/sounds/',   // The folder path where sounds are located
        soundExt: '.ogg',           // Default extension for all sounds
        sound: 'sound4',
        showClass: "fadeInDown",
        hideClass: "zoomOut",
        delay: 1000,
        sound: true,
        img: null,

    });
}
function notiSuccessMess(mes) {
    Lobibox.notify("success", {
        size: "normal",
        rounded: false,
        delayIndicator: true,
        msg: mes,
        //icon: null,
        //title: "aaaaaa",
        soundPath: '/dist/plugins/lobibox/sounds/',   // The folder path where sounds are located
        soundExt: '.ogg',           // Default extension for all sounds
        sound: 'sound4',
        showClass: "fadeInDown",
        hideClass: "zoomOut",
        delay: 4000,
        sound: true,
        img: null,

    });
}


function notiError(errormess) {
    Lobibox.notify("error", {
        size: "normal",
        rounded: false,
        delayIndicator: true,
        msg: errormess,
        soundPath: '/dist/plugins/lobibox/sounds/',   // The folder path where sounds are located
        soundExt: '.ogg',           // Default extension for all sounds
        sound: 'sound2',
        showClass: "fadeInDown",
        hideClass: "zoomOut",
        delay: 6000,
        sound: true,
        img: null,

    });
}
function notiWarning(notimess) {
    Lobibox.notify("warning", {
        size: "normal",
        rounded: false,
        delayIndicator: true,
        msg: notimess,
        //icon: null,
        //title: "aaaaaa",
        soundPath: '/dist/plugins/lobibox/sounds/',   // The folder path where sounds are located
        soundExt: '.ogg',           // Default extension for all sounds
        sound: 'sound3',
        showClass: "fadeInDown",
        hideClass: "zoomOut",
        delay: 4000,
        sound: true,
        img: null,

    });
}

async function notiConfirm() {
    let result = await swal(
        {
            title: "Xác Nhận",
            text: "Bạn Thật Sự Muốn Xóa",
            type: "warning",
            showCancelButton: true,
            confirmButtonColor: "#DD6B55",
            confirmButtonText: "Yes",
            cancelButtonText: "No",
            closeOnConfirm: true,
            closeOnCancel: true
        },
        function (isConfirm) {
            if (isConfirm) {
                return true;
            } else {
                return false;
            }
        });
}
async function notiConfirmSendContent(content) {
    let result = await swal(
        {
            title: "Xác Nhận",
            text: content,
            type: "warning",
            showCancelButton: true,
            confirmButtonColor: "#DD6B55",
            confirmButtonText: "Yes",
            cancelButtonText: "No",
            closeOnConfirm: true,
            closeOnCancel: true
        },
        function (isConfirm) {
            if (isConfirm) {
                return true;
            } else {
                return false;
            }
        });
}
async function notiConfirmPayment() {
    let result = await swal(
        {
            title: "Xác Nhận",
            text: "Bạn Thật Sự Muốn Xóa Hóa Đơn Này",
            type: "warning",
            showCancelButton: true,
            confirmButtonColor: "#DD6B55",
            confirmButtonText: "Yes",
            cancelButtonText: "No",
            closeOnConfirm: true,
            closeOnCancel: true
        },
        function (isConfirm) {
            if (isConfirm) {
                return true;
            } else {
                return false;
            }
        });
}
async function notiConfirmDeleteTicket() {
    let result = await swal(
        {
            title: "Xác Nhận",
            text: "Bạn Thật Sự Muốn Khôi Phục",
            showCancelButton: true,
            confirmButtonColor: "#DD6B55",
            confirmButtonText: "Yes",
            cancelButtonText: "No",
            closeOnConfirm: true,
            closeOnCancel: true
        },
        function (isConfirm) {
            if (isConfirm) {
                return true;
            } else {
                return false;
            }
        });
}
function notiAlarmSchedule(title, content) {
    Lobibox.notify("success", {
        size: "normal",
        rounded: false,
        delayIndicator: true,
        msg: content,
        //icon: null,
        title: title,
        soundPath: '/dist/plugins/lobibox/sounds/',   // The folder path where sounds are located
        soundExt: '.ogg',           // Default extension for all sounds
        sound: 'sound7',
        showClass: "fadeInDown",
        hideClass: "zoomOut",
        delay: 5000,
        img: "/img/Alarm.png",

    });
}


/// Title, message
function notification_title_message(title, message, timedelay) {
    if (lobibox_message != undefined) lobibox_message.remove();
     lobibox_message= Lobibox.notify("info", {
        size: "normal",
        rounded: false,
        delayIndicator: true,
        msg: message,
        title: title,
        soundPath: '/dist/plugins/lobibox/sounds/',   // The folder path where sounds are located
        soundExt: '.ogg',           // Default extension for all sounds
        sound: 'sound4',
        showClass: "fadeInDown",
        hideClass: "zoomOut",
        delay: timedelay,
        sound: true,
        img: '/img/ButtonImg/newmessage.png',

    });
}
