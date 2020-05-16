function PrintPayment(id, branchid, type, versionofWebApplication) {

    $('#tablePrintForAll').empty();
    var formname = "";
    var width = 0;
    var height = 0;


    if (type == "1") {
        height = 650;
        width = 1200;
        formname = "print_Payment_1";       //Anna
    }
    if (type == "2") {
	    height = 650;
	    width = 1200;
	    formname = "print_Payment_2";       //Taza
    }
    if (type == "6") {
	    height = 650;
	    width = 600;
        formname = "print_Template";       //Thiên Nga
    }
    if (type == "7") {
        height = 650;
        width = 1200;
	    formname = "print_Payment_7";       //Korea
    }
    if (type == "8") {
	    height = 650;
	    width = 1200;
        formname = "print_Payment_8_Ladova";       //Ladova
    }
    window.open("/Views/Print/" + formname + ".aspx?id=" + id + "&branch=" + branchid + "&ver=" + versionofWebApplication, '_blank', 'location=yes,height=' + height + ',width=' + width +',scrollbars=yes,status=yes');
    //$('#tablePrintForAll').show();
    //$('#tablePrintForAll').load("/Views/Print/" + formname+".aspx?id=" + id + "&branch=" + branchid + "&ver=" + versionofWebApplication);

}
