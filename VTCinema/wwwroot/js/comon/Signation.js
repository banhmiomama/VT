 
var Signature_ResultSignation = "";
var Signature_IsStopTimeout = 0;


function Signature_Stop_Timeout() {
    Signature_IsStopTimeout = 1;
   
}
function Signature_Action() {
    return new Promise((resolve, reject) => {
        setTimeout(
            () => {
                Signature_InitSignation();
                Signature_IsStopTimeout = 0;
                Signature_ResultSignation = "";
                var timeout = setInterval(change, 500);
                function change() {
                    if (Signature_IsStopTimeout == 1) {
                        clearInterval(timeout);
                        resolve()
                    }
                }
                
            },
        )
    })
}
function Signature_InitSignation() { 
    document.getElementById("divDetailPopupSign").innerHTML = '';
    $("#divDetailPopupSign").load("/Views/Signature/pageSignature.aspx");
    $('#divDetailPopupSign').modal('show');
    
} 