
//(date) 2020-03-16T00:00:00   -> 2020-03-16 (string)
function ConvertDT_To_StringYMD(x) {
    try {
        var d = new Date(x);
        let _month = d.getMonth() + 1;
        let month = (_month < 10) ? ("0" + _month) : _month;
        let date = (d.getDate() < 10) ? ("0" + d.getDate()) : d.getDate();
        return d.getFullYear() + '-' + month + '-' + date;

    }
    catch (err) {
        return "";
    }
}
function GetDateTime_Now_To_String() {
    try {
        var datenow = new Date();
        let hour = (datenow.getHours() < 10) ? ("0" + datenow.getHours()) : datenow.getHours();
        let minute = (datenow.getMinutes() < 10) ? ("0" + datenow.getMinutes()) : datenow.getMinutes();
        let second = (datenow.getSeconds() < 10) ? ("0" + datenow.getSeconds()) : datenow.getSeconds();
        return hour + ":" + minute + ":" + second;
    }
    catch (err) {
        return "";
    }
}
// (Date) 1900-01-01 -> ''
function ConvertToDateRemove1900(x) {
    
    try {
        var d = new Date(x);
        if (Number(d.getFullYear()) == 1900) return "";
        else return x
    }
    catch (err) {
        return x;
    }
}


// convert datetime to string 
function ConvertStringYMD_DMY(x) {
    try {
        let j = x.split('-');
        return (j[2] + "-" + j[1] + "-" + j[0]);
    }
    catch (err) {
        return "";
    }
}

function ConvertDateTimeToString(x) {
    try {
        let j = x.split('-');
        return ('ngày ' + j[0] + ' tháng ' + j[1] + ' năm ' + j[2]);
    }
    catch (err) {
        return "";
    }
}
function ConvertDateTimeToStringRemove1900(x) {
    try {
        let j = x.split('-');
        if (j[2] == "1900") return "";
        else return (j[0] + " - " + j[1] + " - " + j[2]);
    }
    catch (err) {
        return "";
    }
}
function ConvertDateTimeUTC_DMY(x) {
    try {
        var d = new Date(x);
        let _month = d.getMonth() + 1;
        let month = (_month < 10) ? ("0" + _month) : _month;
        let date = (d.getDate() < 10) ? ("0" + d.getDate()) : d.getDate();
        return d.getFullYear() + "-" + month + "-" + date;
    }
    catch (err) {
        return "";
    }
}

function ConvertDateTimeUTC(x) {
    try {
        var d = new Date(x);
        let _month = d.getMonth() + 1;
        var datenow = new Date();
        let hour = (d.getHours() < 10) ? ("0" + d.getHours()) : d.getHours();
        let minute = (d.getMinutes() < 10) ? ("0" + d.getMinutes()) : d.getMinutes();
        let month = (_month < 10) ? ("0" + _month) : _month;
        let date = (d.getDate() < 10) ? ("0" + d.getDate()) : d.getDate();

        if (d.getDate() == datenow.getDate() && d.getYear() == datenow.getYear() && d.getMonth() == datenow.getMonth()) {
            return hour + ":" + minute;
        }
        else {
            return date + "-" + month + "-" + d.getFullYear();
        }
        return d;
    }
    catch (err) {
        return "";
    }
}
function ConvertDateTimeUTC_NoYear(x) {


    try {
        var d = new Date(x);
        let _month = d.getMonth() + 1;
        var datenow = new Date();
        let hour = (d.getHours() < 10) ? ("0" + d.getHours()) : d.getHours();
        let minute = (d.getMinutes() < 10) ? ("0" + d.getMinutes()) : d.getMinutes();
        let month = (_month < 10) ? ("0" + _month) : _month;
        let date = (d.getDate() < 10) ? ("0" + d.getDate()) : d.getDate();

        if (d.getDate() == datenow.getDate() && d.getYear() == datenow.getYear() && d.getMonth() == datenow.getMonth()) {
            return hour + ":" + minute;
        }
        else {
            return date + "-" + month + "-" + d.getFullYear();
        }
        //return d;
    }
    catch (err) {
        return "";
    }
}
function ConvertDateTimeUTC_Time(x) {
    try {
        
        if (x != undefined) {
            if (x == "") return "";
            var d = new Date(x);
            var datenow = new Date();
            let _month = d.getMonth() + 1;
            let hour = (d.getHours() < 10) ? ("0" + d.getHours()) : d.getHours();
            let minute = (d.getMinutes() < 10) ? ("0" + d.getMinutes()) : d.getMinutes();
            let month = (_month < 10) ? ("0" + _month) : _month;
            let date = (d.getDate() < 10) ? ("0" + d.getDate()) : d.getDate();

            if (d.getDate() == datenow.getDate() && d.getYear() == datenow.getYear() && d.getMonth() == datenow.getMonth()) {
                return hour + ":" + minute;
            }
            else {
                return hour + ":" + minute + "  " + date + "-" + month + "-" + d.getFullYear();
            }
            return d;
        }
        else {
            var d = new Date();
            let hour = (d.getHours() < 10) ? ("0" + d.getHours()) : d.getHours();
            let minute = (d.getMinutes() < 10) ? ("0" + d.getMinutes()) : d.getMinutes();
            return hour + ":" + minute;
        }
    }
    catch (err) {
        return "";
    }
}
function ConvertDateTimeUTC_DMYHM(x) {
    try {

        if (x != undefined) {
            if (x == "") return "";
            var d = new Date(x);
            let _month = d.getMonth() + 1;
            let hour = (d.getHours() < 10) ? ("0" + d.getHours()) : d.getHours();
            let minute = (d.getMinutes() < 10) ? ("0" + d.getMinutes()) : d.getMinutes();
            let month = (_month < 10) ? ("0" + _month) : _month;
            let date = (d.getDate() < 10) ? ("0" + d.getDate()) : d.getDate();
            return hour + ":" + minute + "  " + date + "-" + month + "-" + d.getFullYear();
        }
        else {
            return "";
        }
    }
    catch (err) {
        return "";
    }
}
function ConvertDateTimeUTC_DMY(x) {
    try {

        if (x != undefined) {
            if (x == "") return "";
            var d = new Date(x);
            let _month = d.getMonth() + 1;
            let hour = (d.getHours() < 10) ? ("0" + d.getHours()) : d.getHours();
            let minute = (d.getMinutes() < 10) ? ("0" + d.getMinutes()) : d.getMinutes();
            let month = (_month < 10) ? ("0" + _month) : _month;
            let date = (d.getDate() < 10) ? ("0" + d.getDate()) : d.getDate();
            return  date + "-" + month + "-" + d.getFullYear();
        }
        else {
            return "";
        }
    }
    catch (err) {
        return "";
    }
}
function ConvertDateTimeUTC_Time_OnlyHour(x) {
    try {

        var d = isNaN(x) ? new Date(x) : new Date(Number(x));
        let hour = (d.getHours() < 10) ? ("0" + d.getHours()) : d.getHours();
        let minute = (d.getMinutes() < 10) ? ("0" + d.getMinutes()) : d.getMinutes();
        return hour + ":" + minute;
    }
    catch (err) {
        return "";
    }
}
function ConvertTimeSpanUTC_Time(x) {
    try {

        var d = isNaN(x) ? new Date(x) : new Date(Number(x));
        var datenow = new Date();
        let _month = d.getMonth() + 1;
        let hour = (d.getHours() < 10) ? ("0" + d.getHours()) : d.getHours();
        let minute = (d.getMinutes() < 10) ? ("0" + d.getMinutes()) : d.getMinutes();
        let month = (_month < 10) ? ("0" + _month) : _month;
        let date = (d.getDate() < 10) ? ("0" + d.getDate()) : d.getDate();

        if (d.getDate() == datenow.getDate() && d.getYear() == datenow.getYear() && d.getMonth() == datenow.getMonth()) {
            return hour + ":" + minute;
        }
        else {
            return hour + ":" + minute + "  " + date + "-" + month + "-" + d.getFullYear();
        }
        return d;
    }
    catch (err) {
        return "";
    }
}
function ConvertDateTimeToTimeSpan(x) {

    try {
        if (x != undefined) {
            let d = new Date(x);

            return d.getTime();
        }
        else {
            let d = new Date();
            return d.getTime();
        }
    }
    catch (err) {
        return "";
    }
}
// Convert datetime to number
function ConvertDateByNumbers(startDate) {

    let chars = [' ', '<br>'];
    try {
        for (i = 0; i < chars.length; i++) {
            let char = chars[i];
            if (startDate.includes(char)) {
                startDate = startDate.split(char)[0];
            }
            if (startDate != "" || startDate != undefined) {
                var parts = startDate.split('-');
                startDate = parts[1] + '-' + parts[0] + '-' + parts[2];
                var date = new Date(startDate);
                return Number(date.getTime());
            }
            else return 0;
        }

    }
    catch (err) {
        return 0;
    }

}

function StringYMDTODate(x) {
    try {
        if (x.includes('T')) {
            x = x.split('T')[0];
        }
        let j = x.split('-');
        return new Date(Number(j[0]), Number(j[1]) - 1, Number(j[2])); // 0-11 for month
    }
    catch (err) {
        return new Date();
    }
}

function ConvertDateTimeToStringDMY_HM(x) {
    try {
        var d = new Date(x);
        let _month = d.getMonth() + 1;
        var datenow = new Date();
        let hour = (d.getHours() < 10) ? ("0" + d.getHours()) : d.getHours();
        let minute = (d.getMinutes() < 10) ? ("0" + d.getMinutes()) : d.getMinutes();
        let month = (_month < 10) ? ("0" + _month) : _month;
        let date = (d.getDate() < 10) ? ("0" + d.getDate()) : d.getDate();

        if (d.getDate() == datenow.getDate() && d.getYear() == datenow.getYear() && d.getMonth() == datenow.getMonth()) {
            return hour + ":" + minute;
        }
        else {
            return hour + ":" + minute + "  " + date + "-" + month + "-" + d.getFullYear();
        }
        return d;
    }
    catch (err) {
        return "";
    }
}
function ConvertDateTimeToStringDMY_HMS(x) {
    try {
        var d = new Date(x);
        let _month = d.getMonth() + 1;
        var datenow = new Date();
        let hour = (d.getHours() < 10) ? ("0" + d.getHours()) : d.getHours();
        let minute = (d.getMinutes() < 10) ? ("0" + d.getMinutes()) : d.getMinutes();
        let month = (_month < 10) ? ("0" + _month) : _month;
        let date = (d.getDate() < 10) ? ("0" + d.getDate()) : d.getDate();
        let second = (d.getSeconds() < 10) ? ("0" + d.getSeconds()) : d.getSeconds();

        return date + "-" + month + "-" +  d.getFullYear() + " " + hour + ":" + minute + ":" + second;

    }
    catch (err) {
        return "";
    }
}

function ConvertStringDMY_HMSToDateTime(x) {
    try {
        var d = new Date(x);
        let _month = d.getMonth() + 1;
        var datenow = new Date();
        let hour = (d.getHours() < 10) ? ("0" + d.getHours()) : d.getHours();
        let minute = (d.getMinutes() < 10) ? ("0" + d.getMinutes()) : d.getMinutes();
        let month = (_month < 10) ? ("0" + _month) : _month;
        let date = (d.getDate() < 10) ? ("0" + d.getDate()) : d.getDate();
        let second = (d.getSeconds() < 10) ? ("0" + d.getSeconds()) : d.getSeconds();


        return d.getFullYear() + "-" + month + "-" + date; /*+ " " + hour + ":" + minute + ":" + second;*/
        return d;
    }
    catch (err) {
        return "";
    }
}