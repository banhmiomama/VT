function Checking_TabControl_Permission_Exe(data) {
    x = document.getElementsByClassName("_tab_control_");
    if (x != undefined && x.length != 0) {
        for (i = x.length - 1; i >= 0; i--) {
            let datatab = x[i].attributes["data-tab"].value;
            if (Checking_DataTab_IS_Allow(data, datatab) == 0 && datatab != "" && datatab != "undefined") {
                switch (x[i].nodeName.toLowerCase()) {
                    case 'td':
                        x[i].innerHTML = "*******";
                        break;
                    case 'a':
                        x[i].remove();
                        break;
                    case 'button':
                        x[i].remove();
                        break;
                    case 'div':
                        x[i].innerHTML = "";
                        break;
                    case 'input':
                        if (x[i].value != "") {
                            //x[i].value = "00000000000";
                            x[i].setAttribute("type", "password");
                            x[i].setAttribute("disabled", "true");
                        }
                        break;
                }
            }
        }
    }
}
function Checking_DataTab_IS_Allow(data, datatab) {
    let result = 0;
    if (data != undefined && data.length != 0) {
        for (j = 0; j < data.length; j++) {
            if (data[j].Name == datatab) {
                j = data.length;
                return 1;
            }
        }
    }
    else result = 0;
    return result;
}