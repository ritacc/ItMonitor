
var tableRunProject;
var json;

//判断是否已经存在Guid
function isExistGuid(strGuid) {
    var strProjectGuid = $("#txtRuntProject").val();

    if (strProjectGuid.length == 0)
        return false;

    var isB = false;
    var strArr = strProjectGuid.split(';');
    $.each(strArr, function (i, o) {
        if (strGuid == o) {
            isB = true;
        }
    });
    return isB;
}
function isExistDB(objInfo) {
    var valu = false;
    $.each(json, function (i, o) {
        if (objInfo.IP == o.IP && objInfo.ServerNmae == o.ServerNmae && objInfo.DBType == o.DBType) {
            valu = true;
        }
    });
    return valu;
}
function SetDBArr(va) {
    json.push(va);
    $("#txtDataBaseServer").val($.jsonToString(json));
}

function headRemoveDB() {
    $.each($(".cssImageDB"), function (i, o) {
        var obj = $(o);
        obj.unbind("click");
        obj.click(function () {
            if (confirm("确定要移出此数据库吗？")) {
                var runProjectGuid = $("#txtRuntProject");
                var objTr = $(this).parents("tr:first");
                var mguid = objTr.attr("guid");
                runProjectGuid.val(runProjectGuid.val().replace(mguid + ";", "")); //文本框中移出
                objTr.remove();
                GetDBJosonString();
            }
        });
    });
}


function headRemoveProgram() {
    $.each($(".cssImagePro"), function (i, o) {
        var obj = $(o);
        obj.unbind("click");
        obj.click(function () {
            if (confirm("确定要移出此运行服务器吗？")) {
                var runProjectGuid = $("#txtRuntProject");
                var objTr = $(this).parents("tr:first");
                var mguid = objTr.attr("guid");
                runProjectGuid.val(runProjectGuid.val().replace(mguid + ";", "")); //文本框中移出
                objTr.remove();
            }
        });
    });
}


/****************************初使化服务器运行项目*********************************/
function InitServerPro() {
    var runProjectGuid = $("#txtRuntProject");
    if (runProjectGuid.val().length < 36)
        return;
    
    $.ajax({
        url: "InfoEdit.aspx",
        data: { type: "InitServer", GuidArr: runProjectGuid.val() },
        success: function (ajaxContext) {
            var errorArray = [];
            errorArray.push("出错了!\r\n\r\n\t错误信息：\t");
            if (ajaxContext != undefined
                            && ajaxContext.IsSuccess != undefined) {
                if (ajaxContext.IsSuccess == true) {
                    SetTableRow(ajaxContext.listServer);
                    headRemoveProgram();
                    return;
                }
                else {
                    errorArray.push(ajaxContext.ErrorMsg);
                }
            }
            alert(errorArray.join(""));
        },
        dataType: "json",
        cache: false,
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            if (typeof error == "function") {
                error();
            } else {
                var errorArray = [];
                errorArray.push("出错了!\r\n\r\n\t错误信息：");
                errorArray.push(textStatus);
                alert(errorArray.join(""));
            }
        },
        complete: function () {
        }
    });  //$.ajax({

}

function SetTableRow(dataArr) {
    var tbody = tableRunProject.find("tbody");
    $.each(dataArr, function (i, va) {
        var mAddtr = " <tr class='RowStyle' guid='" + va.Guid + "'><td>" + va.ShowVal + "</td><td>" + va.Server_IP + "</td><td> " + va.AdminName + "</td><td> "
+ va.Server_Brand + "</td><td>" + va.Server_Model + "</td><td><img class='cssImagePro' src='../images/Common/delete.gif'/></td></tr>";

        if (tbody) {
            tbody.append(mAddtr);
        }
        else {
            tableRunProject.append(mAddtr);
        }
    }); //each
}
/****************************End初使化服务器运行项目*********************************/

/****************************初使化初使化数据库*********************************/
function InitServerDB() {
    if (request("id").length < 36)
        return;
    $.ajax({
        url: "InfoEdit.aspx",
        data: { type: "InitDB", Guid: request("id") },
        success: function (ajaxContext) {
            var errorArray = [];
            errorArray.push("出错了!\r\n\r\n\t错误信息：\t");
            if (ajaxContext != undefined
                            && ajaxContext.IsSuccess != undefined) {
                if (ajaxContext.IsSuccess == true) {
                    SetTableRowDB(ajaxContext.listDB);
                    headRemoveDB();
                    GetDBJosonString();
                    return;
                }
                else {
                    errorArray.push(ajaxContext.Message);
                }
            }
            alert(errorArray.join(""));
        },
        dataType: "json",
        cache: false,
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            if (typeof error == "function") {
                error();
            } else {
                var errorArray = [];
                errorArray.push("出错了!\r\n\r\n\t错误信息：");
                errorArray.push(textStatus);
                alert(errorArray.join(""));
            }
        },
        complete: function () {
            //a.show();
            //span.hide();
        }
    });    //$.ajax({

}

function SetTableRowDB(dataArr) {
    var tbody = tableRunDB.find("tbody");
    $.each(dataArr, function (i, va) {
        var mAddtr = " <tr class='trData RowStyle'><td>" + va.ServerNmae + "</td><td>" + va.IP + "</td><td> " + va.DBType + "</td><td> " + va.DBName
                    + "</td><td value='" + va.DBPwd + "'>***</td><td><img class='cssImageDB' src='../images/Common/delete.gif'/></td></tr>";

        if (tbody) {
            tbody.append(mAddtr);
        }
        else {
            tableRunProject.append(mAddtr);
        }
    });  //each
}
/****************************End初使化数据库*********************************/


function GetDBJosonString() {
    json = new Array();
    $.each(tableRunDB.find("tr"), function (i, o) {
        var obj = $(o);

        if (obj.hasClass("trData")) {
            var item = new Object();
            var i = 0;
            $.each(obj.find("td"), function (i, o) {
                switch (i) {
                    case 0:
                        item.ServerNmae = $(o).html();
                        //json.push("{\"IP\": \"" + $(o).html() + "\"");
                        break;
                    case 1:
                        item.IP = $(o).html();
                        //json.push("\"ServerNmae\": \"" + $(o).html() + "\"");
                        break;
                    case 2:
                        item.DBType = $(o).html();
                        //json.push("\"DBType\": \"" + $(o).html() + "\"");
                        break;
                    case 3:
                        item.DBName = $(o).html();
                        //json.push("\"DBName\": \"" + $(o).html() + "\"");
                        break;
                    case 4:
                        item.DBPwd = $(o).attr("value");
                        //json.push("\"DBPwd\": \"" + $(o).attr("value") + "\"}");
                        break;
                }
                i++;
            }); //each td
            json.push(item);
        } //if
    });         //end each tr
    var strval = $.jsonToString(json);
    if (strval.length == 2)
        strval = "";
    $("#txtDataBaseServer").val(strval);
}






$(document).ready(function () {
    /***************处理所在服务器**********************/
    var runProjectGuid = $("#txtRuntProject");
    tableRunProject = $("#tableRunProject");
    $("#divAddProject").click(function () {
        var strVar = "../Server/SelectServer.aspx";
        $.popup({ title: "选择所在服务器", url: strVar, borderStyle: { height: 450, width: 600 }, ok: function (va) {
            if (isExistGuid(va.Guid)) {
                alert("服务器：“" + va.ShowVal + "”已经添加！");
                return;
            }
            runProjectGuid.val(runProjectGuid.val() + va.Guid + ";");
            var tbody = tableRunProject.find("tbody");
            var mAddtr = " <tr class='RowStyle' guid='" + va.Guid + "'><td>" + va.ShowVal + "</td><td>" + va.Server_IP + "</td><td> " + va.AdminName + "</td><td> "
+ va.Server_Brand + "</td><td>" + va.Server_Model + "</td><td><img class='cssImagePro' src='../images/Common/delete.gif'/></td></tr>";
            if (tbody) {
                tbody.append(mAddtr);
            }
            else {
                tableRunProject.append(mAddtr);
            }
            //alert(tableRunProject.html());
            headRemoveProgram();            
        }
        }); //$.popup
    });

    //初使化时，根据
    InitServerPro();
    /***************End处理所在服务器**********************/


    /***************数据库服务器**********************/
    json = new Array();
    var runDBGuid = $("#txtDataBaseServer");
    tableRunDB = $("#tbDBServer");
    $("#imgDataBase").click(function () {
        var strVar = "SelectDB.aspx";
        $.popup({ title: "添加数据库服务器", url: strVar, borderStyle: { height: 350, width: 350 }, ok: function (va) {
            if (isExistDB(va)) {
                alert("数据库服务器已添加！");
                return;
            }
            runDBGuid.val(runProjectGuid.val() + va.Guid + ";");
            var tbody = tableRunDB.find("tbody");
            var mAddtr = " <tr class='trData RowStyle'><td>" + va.ServerNmae + "</td><td>" + va.IP + "</td><td> " + va.DBType + "</td><td> " + va.DBName
                    + "</td><td value='" + va.DBPwd + "'>***</td><td><img class='cssImageDB' src='../images/Common/delete.gif'/></td></tr>";
            if (tbody) {
                tbody.append(mAddtr);
            }
            else {
                tableRunDB.append(mAddtr);
            }
            //alert(tableRunProject.html());
            headRemoveDB();
            SetDBArr(va);
        }
        }); //$.popup
    });

    //初使化时，根据
    InitServerDB();
    /***************数据库服务器**********************/
});      //End ready

    