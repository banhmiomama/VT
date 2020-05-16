//#region Export
function exportToExcel(id, filename) {

    $("#tablePrintForAll").empty();
    var idbody = document.getElementById(id).tBodies[0].id;
    var table = $("#" + id).clone();
    let newtableid = id + "Copy";
    let newbodytableid = idbody + "Copy";
    table.attr('id', newtableid);
    $("#tablePrintForAll").html(table);
    document.getElementById(newtableid).tBodies[0].id = newbodytableid;
    // Detect TH Hide
    let foundTH = 0;
    let THHide = [];

    table = document.getElementById(newtableid);
    for (var i = 0, row; row = table.rows[i]; i++) {
        for (var j = 0, col; col = row.cells[j]; j++) {
            if (row.cells[j].nodeName == "TH") {
                if (row.cells[j].style.display == "none" || row.cells[j].innerHTML == "Sửa" || row.cells[j].innerHTML == "Xóa") {
                    let element = {};
                    element.NodeName = j;
                    THHide.push(element);
                }
                foundTH = 1;
            }
        }
        if (foundTH === 1) break;
    }

    for (var i = 0, row; row = table.rows[i]; i++) {
        for (var j = table.rows[i].cells.length - 1, col; col = row.cells[j]; j--) {

            for (var z = 0; z < THHide.length; z++) {
                if (j == THHide[z].NodeName) row.deleteCell(j);
            }
        }
    }
    // Change class td
    $("#tablePrintForAll td").each(function () {
        $(this).addClass("tableexport-string targets")
        // compare id to what you want
    });

    GetTemplateXLSX("tablePrintForAll", filename)
    $("#tablePrintForAll").empty();

}

var divHeightGlobalPDF;
var divWidthGlobalPDF;
var ratioGlobalPDF;

function ExportPDFContainer(id, filename) {
    id = "dtContentReport";
    let element = $("#" + id);
    divHeightGlobalPDF = element.height();
    divWidthGlobalPDF = element.width();
    ratioGlobalPDF = divHeightGlobalPDF / divWidthGlobalPDF;

    html2canvas(element, {
        height: divHeightGlobalPDF,
        width: divWidthGlobalPDF,
        onrendered: function (canvas) {

            //  var ctx = canvas.getContext("2d");
            //  ctx.fillStyle = '#ffffff'; 
            var gl = canvas.getContext("2d");
            gl.fillStyle = '#ffffff';
            // gl.fillRect(0, 0, canvas.width, canvas.height);
            var image = canvas.toDataURL("image/jpeg", 1.0);
            var doc = new jsPDF();
            var width = doc.internal.pageSize.width;
            var height = ratioGlobalPDF * width;
            doc.addImage(image, 'JPEG', 0, 0, width, height);
            doc.save(filename + '.pdf');
        }
    });
}
function GetTemplateXLSX(id, filename) {
    var table = TableExport(document.getElementById(id), {
        exportButtons: false,
        //trimWhitespace: false,
        headers: true,
        footers: true,
        bootstrap: false,
        position: 'bottom',
        ignoreRows: null,
        ignoreCols: null,
        trimWhitespace: true,
        RTL: false,
        sheetname: 'data'
    });
    var exportData = table.getExportData();

    var xlsxData = exportData[id]['xlsx']; // Replace with the kind of file you want from the exportData
    table.export2file(xlsxData.data, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", filename, xlsxData.fileExtension, xlsxData.merges, xlsxData.RTL, "data")
}
//#endregion

function exportToExcel_Xls(id, filename) {
    $("#tablePrintForAll").empty();
    var idbody = document.getElementById(id).tBodies[0].id;
    var table = $("#" + id).clone();
    let newtableid = id + "Copy";
    let newbodytableid = idbody + "Copy";
    table.attr('id', newtableid);
    $("#tablePrintForAll").html(table);
    document.getElementById(newtableid).tBodies[0].id = newbodytableid;
    // Detect TH Hide
    let foundTH = 0;
    let THHide = [];
    table = document.getElementById(newtableid);
    for (var i = 0, row; row = table.rows[i]; i++) {
        for (var j = 0, col; col = row.cells[j]; j++) {
            if (row.cells[j].nodeName == "TH") {
                if (row.cells[j].style.display == "none" || row.cells[j].innerHTML == "Sửa" || row.cells[j].innerHTML == "Xóa") {
                    let element = {};
                    element.NodeName = j;
                    THHide.push(element);
                }
                foundTH = 1;
            }
        }
        if (foundTH === 1) break;
    }

    for (var i = 0, row; row = table.rows[i]; i++) {
        for (var j = table.rows[i].cells.length - 1, col; col = row.cells[j]; j--) {

            for (var z = 0; z < THHide.length; z++) {
                if (j == THHide[z].NodeName) row.deleteCell(j);
            }
        }
    }
    $("#" + newtableid).table2excel({
        exclude: ".csv",
        name: "Worksheet Name",
        filename: filename,
        fileext: ".csv" // file extension
    });

    $("#tablePrintForAll").empty();

}