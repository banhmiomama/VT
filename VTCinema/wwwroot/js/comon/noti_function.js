
function notiSuccess() {
    Lobibox.notify("success", {
        size: "normal",
        rounded: false,
        delayIndicator: true,
        msg: "Thành Công ",
        //icon: null,
        //title: "aaaaaa",
        soundPath: '/plugins/lobibox/sounds/',   // The folder path where sounds are located
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
        soundPath: '/plugins/lobibox/sounds/',   // The folder path where sounds are located
        soundExt: '.ogg',           // Default extension for all sounds
        sound: 'sound4',
        showClass: "fadeInDown",
        hideClass: "zoomOut",
        delay: 1000,
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
        soundPath: '/plugins/lobibox/sounds/',   // The folder path where sounds are located
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
        soundPath: '/plugins/lobibox/sounds/',   // The folder path where sounds are located
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


