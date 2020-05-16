// #region LoadCombo
function LoadCombo(data, id) {
    var myNode = document.getElementById(id);
    if (myNode != null) {
        myNode.innerHTML = '';
        let stringContent = '';
        if (data && data.length > 0) {
            for (var i = 0; i < data.length; i++) {
                let item = data[i];
                let tr =
                    '<div class="item" data-value=' + item.ID + '>' + item.Name + '</div>'
                stringContent = stringContent + tr;
            }
        }
        document.getElementById(id).innerHTML = stringContent;
    }
}
function LoadComboIcon(data, id) {
    var myNode = document.getElementById(id);
    if (myNode != null) {
        myNode.innerHTML = '';
        let stringContent = '';
        if (data && data.length > 0) {
            for (var i = 0; i < data.length; i++) {
                let item = data[i];
                let tr =
                    '<div class="item" data-value=' + item.ID + '><i class="' + item.Icon + '"></i>' + item.Name + '</div>'
                stringContent = stringContent + tr;
            }
        }
        document.getElementById(id).innerHTML = stringContent;
    }
}

        //#endregion

function LoadComboSearch(data, id) {
    let findIdComboMax = 0;
    var myNode = document.getElementById(id);
    if (myNode != null) {
        myNode.innerHTML = '';
        let stringContent = '';
        if (data && data.length > 0) {
            for (var i = 0; i < data.length; i++) {
                let item = data[i];
                let tr = '<div class="item" data-value=' + item.ID + '>' + item.Name + '</div>'
                stringContent = stringContent + tr;
                findIdComboMax = item.ID;
            }
            findIdComboMax = findIdComboMax + 1;
            stringContent = stringContent + '<div class="item" data-value=' + findIdComboMax + '>' + 'Tất Cả' + '</div>';
        }
        document.getElementById(id).innerHTML = stringContent;
    }
    return findIdComboMax;
}