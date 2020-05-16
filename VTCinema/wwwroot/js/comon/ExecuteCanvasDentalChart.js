
function _Add_Disease_(diseaseid, type, teethid, typecircle, path, face, root) {
    let find = false;
    for (ii = 0; ii < CurrentDisease.length; ii++) {
        if (CurrentDisease[ii].type == type && CurrentDisease[ii].teethid == teethid && CurrentDisease[ii].typecircle == typecircle) {
            CurrentDisease[ii].diseaseid = diseaseid;
            CurrentDisease[ii].diseasename = data_disease.filter(word => word["ID"] == diseaseid)[0].Name;
            CurrentDisease[ii].empid = sys_employeeID_Main;
            CurrentDisease[ii].empname = sys_employeeName_Main;
            CurrentDisease[ii].userid = sys_userID_Main;
            CurrentDisease[ii].date = GetDateTime_Now_To_String();
            CurrentDisease[ii].updatetime = GetDateTime_Now_To_String();
            find = true;
            ii = CurrentDisease.length;
        }
    }
    if (!find) {
        let e = {};
        e.diseaseid = diseaseid;
        e.diseasename = data_disease.filter(word => word["ID"] == diseaseid)[0].Name;
        e.type = type;
        e.teethid = teethid;
        e.typecircle = typecircle;
        e.pathcircle = path;
        e.face = face;
        e.root = root;
        e.userid = sys_userID_Main;
        e.empid = sys_employeeID_Main;
        e.empname = sys_employeeName_Main;
        e.date = GetDateTime_Now_To_String();
        e.updatetime = GetDateTime_Now_To_String();
        e.DeleteButton = 1;
        CurrentDisease.push(e);

    }
}
function _Draw_Disease_Design_TEETH_WHOLE() {

    for (k = 0; k < CurrentDisease.length; k++) {
        if (Number(CurrentDisease[k].type) == 2) {
            // disease circle
            let datapath = data_layout_path.filter(word => word["ID"] == CurrentDisease[k].pathcircle)[0];
            if (datapath != undefined) {
                let path = datapath.pathData;
                //  let data = JSON.parse(data_disease.filter(word => word["ID"] == CurrentDisease[k].diseaseid)[0].Data).data[0];
                let data = JSON.parse(data_disease.filter(word => word["ID"] == CurrentDisease[k].diseaseid)[0].Data).data[0].data;
                Particular_Draw_CIRCLE(CurrentDisease[k].teethid, CurrentDisease[k].typecircle, path, data);
            }
        }
        else {

            let data = JSON.parse(data_disease.filter(word => word["ID"] == CurrentDisease[k].diseaseid)[0].Data).data;
            for (let item = 0; item < data.length; item++) {

                switch (data[item].area) {

                    case "l": case "t": case "r": case "b": case "c":
                        let idcanvas = 'teeth_circle_' + data[item].area + '_' + CurrentDisease[k].teethid;
                        let pathincanvas = document.getElementById(idcanvas).attributes.data_path.value;
                        let datapath = data_layout_path.filter(word => word["ID"] == pathincanvas)[0];
                        if (datapath != undefined) {
                            let path = datapath.pathData;
                            Particular_Draw_CIRCLE(CurrentDisease[k].teethid, data[item].area, path, data[item].data);
                        }
                        break;
                    case "rootface":
                        Particular_Draw_FACEROOT(CurrentDisease[k].teethid, data[item].data, CurrentDisease[k].root, CurrentDisease[k].face);
                        break;
                }

            }
        }
    }
}
function Particular_GetPath_Image(imageid, typesign) {
    let _data_image_ = data_layout_image_disease.filter(word => word["ID"] == imageid)[0];
    let resulf = "";
    switch (typesign) {
        case "Root_1_U": resulf = _data_image_.Root_1_U; break;
        case "Root_3_U": resulf = _data_image_.Root_3_U; break;
        case "Root_1_D": resulf = _data_image_.Root_1_D; break;
        case "Root_3_D": resulf = _data_image_.Root_3_D; break;
        default: break;
    }
    return resulf;
}
function Particular_GetPath_Design(designid, typesign) {
    let _data_design_ = data_layout_design_disease.filter(word => word["ID"] == designid)[0];
    let resulf = "";
    switch (typesign) {
        case "Root_1_U": resulf = _data_design_.Root_1_U; break;
        case "Root_3_U": resulf = _data_design_.Root_3_U; break;
        case "Root_1_D": resulf = _data_design_.Root_1_D; break;
        case "Root_3_D": resulf = _data_design_.Root_3_D; break;
        default: break;
    }
    return resulf;
}
function Particular_Draw_FACEROOT(id, data, root, face) {
    for (i = 0; i < CanvasObject.length; i++) {
        if (CanvasObject[i].id == id && CanvasObject[i].type == "") {
            let faceSign = CanvasObject[i].face_sign;
            let rootSign = CanvasObject[i].root_sign;
            let can = CanvasObject[i].canvas;
            let ctx = can.getContext('2d');
            ctx.clearRect(0, 0, can.width, can.height);
            let dataroot = data_layout_path.filter(word => word["ID"] == root)[0];
            let dataface = data_layout_path.filter(word => word["ID"] == face)[0];

            for (yy = 0; yy < data.length; yy++) {
                if (data[yy].area == "root") {
                    let data_root = data[yy].data;
                    if (data_root != undefined && data_root.length != 0) {
                        let _2d = new Path2D(dataroot.pathData);
                        for (let xx = 0; xx < data_root.length; xx++) {
                            switch (data_root[xx].type) {
                                case "color":
                                    if (data_root[xx].having == "1") {
                                        ctx.fillStyle = data_root[xx].fill;
                                        ctx.strokeStyle = data_root[xx].stroke;
                                        ctx.fill(_2d);
                                        ctx.stroke(_2d);
                                    }
                                    break;
                                case "pattern":
                                    if (data_root[xx].having == "1") {
                                        let img = new Image();
                                        img.src = '/img/teeth/' + data_root[xx].patternlink + '.png';
                                        img.onload = function () {
                                            var pattern = ctx.createPattern(img, 'repeat');
                                            ctx.fillStyle = pattern;
                                            ctx.fill(_2d);
                                        };
                                    }
                                    break;
                                case "image":
                                    if (data_root[xx].having == "1") {
                                        let linkimage = Particular_GetPath_Image(data_root[xx].imageid, rootSign);
                                        var img = new Image();
                                        img.src = '/img/teeth/' + linkimage + '.svg';
                                        img.onload = function () {
                                            ctx.drawImage(img, 0, 0);
                                        }
                                    }
                                    break;
                                case "design":
                                    if (data_root[xx].having == "1") {
                                        let pathDesign = Particular_GetPath_Design(data_root[xx].designid, rootSign);
                                        let _design = new Path2D(pathDesign);
                                        ctx.fillStyle = data_root[xx].fill;
                                        ctx.strokeStyle = data_root[xx].stroke;
                                        ctx.fill(_design);
                                        ctx.stroke(_design);
                                        if (data_root[xx].ispattern == "1") {
                                            let img = new Image();
                                            img.src = '/img/teeth/' + data_root[xx].patternlink + '.png';
                                            img.onload = function () {
                                                var pattern = ctx.createPattern(img, 'repeat');
                                                ctx.fillStyle = pattern;
                                                ctx.fill(_design);
                                            };
                                        }
                                    }
                                    break;
                                default: break;
                            }
                        }
                    }
                }
                if (data[yy].area == "face") {
                    let data_face = data[yy].data;
                    if (data_face != undefined && data_face.length != 0) {
                        let _2d = new Path2D(dataface.pathData);
                        for (let xx = 0; xx < data_face.length; xx++) {
                            switch (data_face[xx].type) {
                                case "color":
                                    if (data_face[xx].having == "1") {
                                        ctx.fillStyle = data_face[xx].fill;
                                        ctx.strokeStyle = data_face[xx].stroke;
                                        ctx.fill(_2d);
                                        ctx.stroke(_2d);
                                    }
                                    break;
                                case "pattern":
                                    if (data_face[xx].having == "1") {
                                        let img = new Image();
                                        img.src = '/img/teeth/' + data_face[xx].patternlink + '.png';
                                        img.onload = function () {
                                            var pattern = ctx.createPattern(img, 'repeat');
                                            ctx.fillStyle = pattern;
                                            ctx.fill(_2d);
                                        };
                                    }
                                    break;
                            }
                        }
                    }
                }


            }
            i = CanvasObject.length;
        }
    }
}
function Particular_Draw_CIRCLE(id, type, data_path, data) {
    for (i = 0; i < CanvasObject.length; i++) {
        if (CanvasObject[i].id == id && CanvasObject[i].type == type) {
            let can = CanvasObject[i].canvas;
            let ctx = can.getContext('2d');
            if (data != undefined && data.length != 0) {
                ctx.clearRect(0, 0, can.width, can.height);
                let _2d = new Path2D(data_path);
                for (let xx = 0; xx < data.length; xx++) {
                    switch (data[xx].type) {
                        case "color":
                            if (data[xx].having == "1") {
                                ctx.fillStyle = data[xx].fill;
                                ctx.strokeStyle = data[xx].stroke;
                                ctx.fill(_2d);
                                ctx.stroke(_2d);
                            }
                            break;
                        case "pattern":
                            if (data[xx].having == "1") {
                                let img = new Image();
                                img.src = '/img/teeth/' + data[xx].patternlink + '.png';
                                img.onload = function () {
                                    var pattern = ctx.createPattern(img, 'repeat');
                                    ctx.fillStyle = pattern;
                                    ctx.fill(_2d);
                                };
                            }
                            break;
                    }
                }
            }
            i = CanvasObject.length;
        }
    }
}
function Event_Click_Disease() {
    $(".disease_for_face_root_teeth").mousedown(function () {
        if (IDTeethFaceSelect.length != 0 || IDTeethCircleSelect != 0) {
            let diseaseID = $(this).attr('data_id');
            for (i = 0; i < IDTeethFaceSelect.length; i++) {
                // type = 1;//"faceroot";
                _Add_Disease_(diseaseID, 1, IDTeethFaceSelect[i].id, '', '', IDTeethFaceSelect[i].face, IDTeethFaceSelect[i].root);
            }

            for (i = 0; i < IDTeethCircleSelect.length; i++) {
                //type = 2;//"circle";
                _Add_Disease_(diseaseID, 2, IDTeethCircleSelect[i].id, IDTeethCircleSelect[i].type, IDTeethCircleSelect[i].path, '', '');
            }
            IDTeethFaceSelect = [];
            IDTeethCircleSelect = [];
            Clear_Selected_Teeth();
            _Draw_Disease_Design_TEETH_WHOLE();
            Render_Table_Desease_List(CurrentDisease, "dtContentDisease_DetailBody");
        }
    });
}
function Event_Click_Choose_FR_Teeth() {
    $(".teeth_part_root_face").mousedown(function () {
        if (IDTeethCircleSelect.length != 0) {
            IDTeethCircleSelect = [];
            Clear_Selected_Teeth_Cicle();
        }
        let teethID = $(this).attr('data_teeth');
        let face = $(this).attr('data_face');
        let root = $(this).attr('data_root');

        if (!$(this).hasClass("selectedColorFR")) {
            $(this).addClass("selectedColorFR");
            let e = {};
            e.id = teethID;
            e.face = face;
            e.root = root;
            IDTeethFaceSelect.push(e);
        }
        else {
            $(this).removeClass("selectedColorFR");
            for (i = IDTeethFaceSelect.length - 1; i >= 0; i--) {
                if (Number(IDTeethFaceSelect[i].id) == Number(teethID)) {
                    IDTeethFaceSelect.splice(i, 1);
                }
            }
        }

        ShowHide_Disease_ByType();
    });

}
function Event_Click_Choose_Circle_Teeth() {
    $(".div_circle_all").mousedown(function () {
        if (IDTeethFaceSelect.length != 0) {
            IDTeethFaceSelect = [];
            Clear_Selected_Teeth_FC();
        }

        let type = $(this).attr('data_type');
        let id = $(this).attr('data_id');
        let data_path = $(this).attr('data_path');
        if (!$(this).hasClass("selectedColorCircle")) {
            $(this).addClass("selectedColorCircle");
            let e = {};
            e.id = id;
            e.type = type;
            e.path = data_path;
            IDTeethCircleSelect.push(e);
        }
        else {
            $(this).removeClass("selectedColorCircle");
            for (i = IDTeethCircleSelect.length - 1; i >= 0; i--) {
                if (Number(IDTeethCircleSelect[i].id) == Number(id) && IDTeethCircleSelect[i].type == type) {
                    IDTeethCircleSelect.splice(i, 1);
                }
            }
        }
        ShowHide_Disease_ByType();
    });

}
function ShowHide_Disease_ByType() {

    if (IDTeethFaceSelect.length == 0 && IDTeethCircleSelect.length != 0) {
        let x = document.getElementsByClassName('disease_for_face_root_teeth');
        for (zz = 0; zz < x.length; zz++) {
            // Hide disease fc
            if (x[zz].attributes["data_type"].value == "1") {
                $('#' + 'desease_' + x[zz].attributes["data_id"].value).hide();
            }
            else {
                $('#' + 'desease_' + x[zz].attributes["data_id"].value).show();
            }
        }
    }
    else if (IDTeethCircleSelect.length == 0 && IDTeethFaceSelect.length != 0) {
        let x = document.getElementsByClassName('disease_for_face_root_teeth');
        for (zz = 0; zz < x.length; zz++) {
            // Hide disease fc
            if (x[zz].attributes["data_type"].value == "2") {
                $('#' + 'desease_' + x[zz].attributes["data_id"].value).hide();
            }
            else {
                $('#' + 'desease_' + x[zz].attributes["data_id"].value).show();
            }
        }
    }
    else {
        let x = document.getElementsByClassName('disease_for_face_root_teeth');
        for (zz = 0; zz < x.length; zz++) {
            $('#' + 'desease_' + x[zz].attributes["data_id"].value).show();
        }
    }
}
function Clear_Selected_Teeth_FC() {
    let x = document.getElementsByClassName('teeth_part_root_face');
    for (i = 0; i < x.length; i++) {
        if (x[i].className.includes("selectedColorFR")) {
            x[i].className = "teeth_part_root_face";
        }
    }
}
function Clear_Selected_Teeth_Cicle() {
    let x = document.getElementsByClassName('div_circle_all');
    for (i = 0; i < x.length; i++) {
        if (x[i].className.includes("selectedColorCircle")) {
            x[i].className = "div_circle_all";
        }
    }
}
function Clear_Selected_Teeth() {
    Clear_Selected_Teeth_FC();
    Clear_Selected_Teeth_Cicle();
    ShowHide_Disease_ByType();
}
function Event_Click_Desease_List() {
    $('#dtContentDisease_Detail tbody').on('click', '.buttonDeleteClass', function () {
        let diseaseid = $(this).closest('tr')[0].childNodes[0].innerHTML;
        let teethid = $(this).closest('tr')[0].childNodes[1].innerHTML;
        let type = $(this).closest('tr')[0].childNodes[2].innerHTML;
        let typecircle = $(this).closest('tr')[0].childNodes[3].innerHTML;
        for (iiii = CurrentDisease.length - 1; iiii >= 0; iiii--) {
            if (CurrentDisease[iiii].diseaseid == diseaseid
                && CurrentDisease[iiii].teethid == teethid
                && CurrentDisease[iiii].type == type
                && CurrentDisease[iiii].typecircle == typecircle) {
                CurrentDisease.splice(iiii, 1);
                break;
            }
        }
        Clear_Selected_Teeth();
        Execute_Clear_Draw_One_Teeth(teethid, type);
        _Draw_Disease_Design_TEETH_WHOLE();
        Render_Table_Desease_List(CurrentDisease, "dtContentDisease_DetailBody");
    });
}


//#region  // Draw Default Teeth
function Execute_Draw_FR_Teeth(can, ctx, id, data_face, data_root, data_face_sign, data_root_sign) {

    let _face = data_layout_path.filter(word => word["ID"] == data_face)[0];
    let _root = data_layout_path.filter(word => word["ID"] == data_root)[0];
    let e = {};
    e.canvas = can;
    e.id = id;
    e.type = "";
    e.face_sign = data_face_sign;
    e.root_sign = data_root_sign;
    e.path_sign = "";
    e.data_circle = "";
    e.data_face = data_face;
    e.data_root = data_root;
    CanvasObject.push(e);

    ctx.clearRect(0, 0, 40, 90);
    ctx.fillStyle = "#ffffff";
    ctx.globalAlpha = 0.2;
    ctx.fillRect(0, 0, 40, 90);
    ctx.globalAlpha = 1.0;
    ctx.lockMovementX = true;
    ctx.lockMovementY = true;
    ctx.lockScalingX = true;
    ctx.lockScalingY = true;
    ctx.lockUniScaling = true;
    ctx.lockRotation = true;
    ctx.hasControls = false;
    ctx.hasBorders = false;
    ctx.selectable = true;

    ctx.strokeStyle = _face.strokeColor;
    ctx.stroke(new Path2D(_face.pathData));
    ctx.strokeStyle = _root.strokeColor;
    ctx.stroke(new Path2D(_root.pathData));
}
function Execute_Draw_Circle(can, ctx, id, type, data_path, data_sign) {
    let path = data_layout_path.filter(word => word["ID"] == data_path)[0];
    ctx.beginPath();
    ctx.clearRect(0, 0, can.width, can.height);
    let e = {};
    e.canvas = can;
    e.id = id;
    e.type = type;
    e.face_sign = "";
    e.root_sign = "";
    e.path_sign = data_sign;
    e.data_circle = data_path;
    e.data_face = "";
    e.data_root = "";
    CanvasObject.push(e);

   
    ctx.fillStyle = "#ffffff";
    ctx.globalAlpha = 0.2;
    ctx.globalAlpha = 1.0;
    ctx.lockMovementX = true;
    ctx.lockMovementY = true;
    ctx.lockScalingX = true;
    ctx.lockScalingY = true;
    ctx.lockUniScaling = true;
    ctx.lockRotation = true;
    ctx.hasControls = false;
    ctx.hasBorders = false;
    ctx.selectable = true;
    ctx.strokeStyle = path.strokeColor;
    ctx.stroke(new Path2D(path.pathData));

}
function Execute_Clear_Draw_One_Teeth(teethid, type) {

    for (i = 0; i < CanvasObject.length; i++) {
        if (CanvasObject[i].id == teethid ) {
            var ctx = CanvasObject[i].canvas.getContext('2d');
            ctx.beginPath();
            ctx.clearRect(0, 0, CanvasObject[i].canvas.width, CanvasObject[i].canvas.height);
            ctx.fillStyle = "#ffffff";
            ctx.globalAlpha = 0.2;
            ctx.globalAlpha = 1.0;
            ctx.lockMovementX = true;
            ctx.lockMovementY = true;
            ctx.lockScalingX = true;
            ctx.lockScalingY = true;
            ctx.lockUniScaling = true;
            ctx.lockRotation = true;
            ctx.hasControls = false;
            ctx.hasBorders = false;
            ctx.selectable = true;
            if (CanvasObject[i].data_circle == "") {
                let _face = data_layout_path.filter(word => word["ID"] == CanvasObject[i].data_face)[0];
                let _root = data_layout_path.filter(word => word["ID"] == CanvasObject[i].data_root)[0];
                ctx.strokeStyle = _face.strokeColor;
                ctx.stroke(new Path2D(_face.pathData));
                ctx.strokeStyle = _root.strokeColor;
                ctx.stroke(new Path2D(_root.pathData));
            }
            else {
                let path = data_layout_path.filter(word => word["ID"] == CanvasObject[i].data_circle)[0];
                ctx.strokeStyle = path.strokeColor;
                ctx.stroke(new Path2D(path.pathData));
            }
        }
    }
}
function Execute_Draw_Whole_Teeth() {
    $('.canvasTeethFace').each(function (i, obj) {
        var canvas = new fabric.Canvas(this.id);
        var ctx = canvas.getContext('2d');
        let data_face = $(this).attr('data_face');
        let data_root = $(this).attr('data_root');
        let data_id = $(this).attr('data_id');
        let datapath_face = data_layout_path.filter(word => word["ID"] == data_face)[0];
        let datapath_root = data_layout_path.filter(word => word["ID"] == data_root)[0];
        Execute_Draw_FR_Teeth(canvas, ctx, data_id, data_face, data_root, datapath_face.Sign, datapath_root.Sign)
    });

    $('.canvasTeethCircle').each(function (i, obj) {
        var canvas = new fabric.Canvas(this.id);
        var ctx = canvas.getContext('2d');
        let data_path = $(this).attr('data_path');
        let data_type = $(this).attr('data_type');
        let data_id = $(this).attr('data_id');
        let datapath_ = data_layout_path.filter(word => word["ID"] == data_path)[0];
        Execute_Draw_Circle(canvas, ctx, data_id, data_type, data_path, datapath_.Sign)
        //canvas.on({
        //    'mouse:over': function (e) {
        //    },
        //    'mouse:out': function (e) {
        //    },
        //    'mouse:down': function (e) {
        //        //debugger
        //        if (this.upperCanvasEl.parentNode.firstChild.attributes["data_id"] != undefined) {
        //            Execute_Draw_Circle(this, this.getContext('2d')
        //                , this.upperCanvasEl.parentNode.firstChild.attributes["data_id"].value
        //                , this.upperCanvasEl.parentNode.firstChild.attributes["data_type"].value
        //                , this.upperCanvasEl.parentNode.firstChild.attributes["data_path"].value, 0)
        //        }
        //    }
        //});

    });
}
// #endregion

// #region // Render Disease List
function Render_Table_Desease_List(data, id) {
    var myNode = document.getElementById(id);
    if (myNode != null) {
        myNode.innerHTML = '';
        let stringContent = '';
        if (data && data.length > 0) {
            for (var i = 0; i < data.length; i++) {
                let item = data[i];
                let tr =
                    '<td style="display:none !important">' + item.diseaseid + '</td>'
                    + '<td style="display:none !important">' + item.teethid + '</td>'
                    + '<td style="display:none !important">' + item.type + '</td>'
                    + '<td style="display:none !important">' + item.typecircle + '</td>'
                    + '<td style="display:none !important">' + item.userid + '</td>'
                    + '<td>' + (i + 1) + '</td>'
                    + '<td>' + item.date + '</td>'
                    + '<td>' + item.diseasename + '</td>'
                    + '<td>' + 'Tình Trạng' + '</td>'
                    + '<td>' + item.teethid + '</td>'
                    + '<td>' + 'Nội Dung' + '</td>'
                    + '<td>' + item.empname + '</td>'
                    + ((item.DeleteButton === 1)
                        ? ('<td><button class="buttonGrid" value="'
                            + item.ID
                            + '"><img class="buttonDeleteClass imgGrid" src="/img/ButtonImg/delete.png"></button></td>')
                        : '<td></td>')

                stringContent = stringContent + '<tr role="row">' + tr + '</tr>';
            }
        }
        document.getElementById(id).innerHTML = stringContent;
    }
    Event_Click_Desease_List();
}

// #endregion