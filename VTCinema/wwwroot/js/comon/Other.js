//#region   Resource Browser
function ReloadResourceForBrowser() {
    var h, a, f;
    a = document.getElementsByTagName('link');
    for (h = 0; h < a.length; h++) {
        f = a[h];
        if (f.rel.toLowerCase().match(/stylesheet/) && f.href) {
            var g = f.href.replace(/(&|\?)rnd=\d+/, '');
            f.href = g + (g.match(/\?/) ? '&' : '?');
            f.href += 'rnd=' + (new Date().valueOf());
        }
    } // for
}
//#endregion

function ScrollTableAnimation(tableid, line) {
    var w = $(window);
    window.scrollTo(1000, 2000);
}

// Responsive header master
$('.InfoDropdown').click(function () {
    $(this).toggleClass('active');
    $('.InfoDropdown_Item').toggleClass('active');
});

$(window).resize(function () {
    if ($(window).width() < 904) {
        $('.InfoDropdown_Item div:nth-child(2n)').each(function () {
            $(this).html('')
        })
    }
    else {
        $('.InfoDropdown_Item div:nth-child(2n)').each(function () {
            $(this).html('&nbsp')
        })
    }
})
// End responsive header master
// Refresh nice scroll

String.prototype.replaceAll = function (strReplace, strWith) {
    var esc = strReplace.replace(/[-\/\\^$*+?.()|[\]{}]/g, '\\$&');
    var reg = new RegExp(esc, 'ig');
    return this.replace(reg, strWith);
};

function createElementFromHTML(htmlString) {
    var div = document.createElement('div');
    div.innerHTML = htmlString.trim();
    return div.firstChild;
}
var hexDigits = new Array
    ("0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f");

//Function to convert rgb color to hex format
function rgb2hex(rgb) {
    rgb = rgb.match(/^rgb\((\d+),\s*(\d+),\s*(\d+)\)$/);
    if (rgb != null && rgb.length > 3) {
        return "#" + hex(rgb[1]) + hex(rgb[2]) + hex(rgb[3]);
    }
    else return "";
}

function hex(x) {
    return isNaN(x) ? "00" : hexDigits[(x - x % 16) / 16] + hexDigits[x % 16];
}