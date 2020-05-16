// Server to show client m-d-y
function formatDateClient(date) {
    if (date != undefined && date != "") {
        var d = new Date(date),
            month = '' + (d.getMonth() + 1),
            day = '' + d.getDate(),
            year = d.getFullYear();

        if (month.length < 2) month = '0' + month;
        if (day.length < 2) day = '0' + day;

        return [day, month, year].join('-');
    }
    else {
        return '01-01-1900';
    }
}
// Server to show client dd-mm
function yyyyMMdd_ddMM(date) {
    var x = date.split("-");
    return x[2] + "-" + x[1];
}

function DateFormat(date) {
    if (date !== undefined && date !== '' && date !== null) {
        date = date.split("-").reverse().join("-");
    }
    return date;
}
// Server to show client y-m-d
// date( d-m-y)
function formatDate(date) {
    if (date != undefined && date != "") {
        var d = new Date(date),
            month = '' + (d.getMonth() + 1),
            day = '' + d.getDate(),
            year = d.getFullYear();

        if (month.length < 2) month = '0' + month;
        if (day.length < 2) day = '0' + day;
        return [year, month, day].join('-');
    }
    else {
        return '1900-01-01';
    }
}
// Formate date for datetotpe
function formatDateInput(date) {
    if (date != undefined && date != "") {
        if (date.includes("-")) {
            var x = date.split("-");
            return x[0] + "-" + x[1] + "-" + x[2];
        }
        else if (date.includes("/")) {
            var x = date.split("/");
            return x[0] + "-" + x[1] + "-" + x[2];
        }
        else return '01-01-1900';
    }
    else {
        return '01-01-1900';
    }
}
// second to hms
function secondsToHms(totalSeconds) {
    let hours = Math.floor(totalSeconds / 3600);
    totalSeconds %= 3600;
    let minutes = Math.floor(totalSeconds / 60);
    let seconds = totalSeconds % 60;
    minutes = String(minutes).padStart(2, "0");
    hours = String(hours).padStart(2, "0");
    seconds = String(seconds).padStart(2, "0");
    return (hours + ":" + minutes + ":" + seconds);
}

// Server to show client dd-mm
function yyyyMMddHHMMM_ddMMyyyy(date) {
    var x = date.split(" ");
    var y = x[0].split("-");
    return y[2] + "-" + y[1] + "-" + y[0];
}

// Server to show client dd-mm
function yyyyMMddHHMMM_HHMM(date) {
    var x = date.split(" ");
    return x[1];
}