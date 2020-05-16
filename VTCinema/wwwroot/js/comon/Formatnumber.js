//#region Format Number
function formatNumber(num) {
    if (num != undefined && num != 'null' && num != '') {
        return num.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1,')
    }
    else return '0';
}
function formatNumberPrice(number) {
    let num = number;
    if (num && num > 1000) {
        if (num >= 1000000) {
            if ((num % 1000000) == 0) {
                num = (num / 1000000).toFixed(0);
            } else if ((num % 1000000 % 100000) / 10000 == 0) {
                num = (num / 1000000).toFixed(1);
            } else {
                num = (num / 1000000).toFixed(2);
            }
            num = num + " Tr";
        }
        else if (num >= 1000) {
            num = (num / 1000).toFixed(0) + " Ng";
        }
    } else {
        return num + ' VND'
    }
    let value = num.toString();
    let length = value.length;
    let tail = value.substring(length - 2, length);
    let ret = value.substring(0, length - 2);
    return formatNumber(ret) + tail;
};
        //#endregion