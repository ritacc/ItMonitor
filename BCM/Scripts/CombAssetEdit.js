var tableRunServer;
var tableRunProject;
//判断是否已经存在Guid
function isExistGuidServer(strGuid) {
    var strServerGuid = $("#txtRuntServer").val();

    if (strServerGuid.length == 0)
        return false;

    var isB = false;
    var strArr = strServerGuid.split(';');
    $.each(strArr, function (i, o) {
        if (strGuid == o) {
            isB = true;
        }
    });
    return isB;
}

function isExistProject(strGuid) {
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

function headRemoveServer() {
    $.each($(".cssImageServer"), function (i, o) {
        var obj = $(o);
        obj.unbind("click");
        obj.click(function () {
            if (confirm("确定要移出此服器资产吗？")) {
                var runServerGuid = $("#txtRuntServer");
                var objTr = $(this).parents("tr:first");
                var mguid = objTr.attr("guid");
                runServerGuid.val(runServerGuid.val().replace(mguid + ";", "")); //文本框中移出
                objTr.remove();
            }
        });
    });
}

function headRemoveProgram() {
    $.each($(".cssImagePro"), function (i, o) {
        var obj = $(o);
        obj.unbind("click");
        obj.click(function () {
            if (confirm("确定要移出此应用资产吗？")) {
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
function InitServer() {
    var runServerGuid = $("#txtRuntServer");
    if (runServerGuid.val().length < 36)
        return;

    $.ajax({
        url: "CombAssetEdit.aspx",
        data: { type: "InitServer", GuidArr: runServerGuid.val() },
        success: function (ajaxContext) {
            var errorArray = [];
            errorArray.push("出错了!\r\n\r\n\t错误信息：\t");
            if (ajaxContext != undefined
                            && ajaxContext.IsSuccess != undefined) {
                if (ajaxContext.IsSuccess == true) {
                    SetTableRowServer(ajaxContext.listServer);
                    headRemoveServer();
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
            //a.show();
            //span.hide();
        }
    });  //$.ajax({

}

function SetTableRowServer(dataArr) {
    var tbody = tableRunServer.find("tbody");
    $.each(dataArr, function (i, va) {
        var mAddtr = " <tr class='RowStyle' guid='" + va.Guid + "'><td>" + va.ShowVal + "</td><td>" + va.Server_IP + "</td><td> " + va.AdminName + "</td><td> "
+ va.Server_Brand + "</td><td>" + va.Server_Model + "</td><td><img class='cssImageServer' src='../images/Common/delete.gif'/></td></tr>";

        if (tbody) {
            tbody.append(mAddtr);
        }
        else {
            tableRunServer.append(mAddtr);
        }
    }); //each
}
/****************************End初使化服务器运行项目*********************************/

/****************************初使化应用资产*********************************/
function InitProject() {
    var runProjectGuid = $("#txtRuntProject");
    
    if (runProjectGuid.val().length < 36)
        return;

    $.ajax({
        url: "CombAssetEdit.aspx",
        data: { type: "InitProject", GuidArr: runProjectGuid.val() },
        success: function (ajaxContext) {
            
            var errorArray = [];
            errorArray.push("出错了!\r\n\r\n\t错误信息：\t");
            if (ajaxContext != undefined
                            && ajaxContext.IsSuccess != undefined) {
                if (ajaxContext.IsSuccess == true) {
                    SetTableRowProject(ajaxContext.listPro);
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
    });   //$.ajax({

}

function SetTableRowProject(dataArr) {
    if (dataArr == null) return;
    var tbody = tableRunProject.find("tbody");
    $.each(dataArr, function (i, va) {
        var mAddtr = " <tr class='RowStyle' guid='" + va.Guid + "'><td>" + va.Name + "</td><td>" + va.Domain + "</td><td> " + va.Struct + "</td><td> "
+ va.OnlinTime + "</td><td>" + va.administrator + "</td><td><img class='cssImagePro' src='../images/Common/delete.gif'/></td></tr>";
            
        if (tbody) {
            tbody.append(mAddtr);
        }
        else {
            tableRunProject.append(mAddtr);
        }
    }); //each
}
/****************************End初使化应用资产*********************************/

$(document).ready(function () {
    /***************处理所在服务器**********************/
    var runServerGuid = $("#txtRuntServer");
    tableRunServer = $("#tableRunServer");
    $("#divAddServer").click(function () {
        var strVar = "../Server/SelectServer.aspx";
        $.popup({ title: "选择服务器资产", url: strVar, borderStyle: { height: 450, width: 600 }, ok: function (va) {
            if (isExistGuidServer(va.Guid)) {
                alert("服务器：“" + va.ShowVal + "”已经添加！");
                return;
            }
            runServerGuid.val(runServerGuid.val() + va.Guid + ";");
            var tbody = tableRunServer.find("tbody");
            var mAddtr = " <tr class='RowStyle' guid='" + va.Guid + "'><td>" + va.ShowVal + "</td><td>" + va.Server_IP + "</td><td> " + va.AdminName + "</td><td> "
+ va.Server_Brand + "</td><td>" + va.Server_Model + "</td><td><img class='cssImageServer' src='../images/Common/delete.gif'/></td></tr>";
            if (tbody) {
                tbody.append(mAddtr);
            }
            else {
                tableRunServer.append(mAddtr);
            }
            //alert(tableRunServer.html());
            headRemoveServer();
        }
        }); //$.popup
    });

    //初使化时，根据
    InitServer();
    /***************End处理所在服务器**********************/

    /***************处理应用资产**********************/
    var runProjectGuid = $("#txtRuntProject");
    tableRunProject = $("#tableRunProject");
    $("#divAddProject").click(function () {
        var strVar = "../Appl/SelectProject.aspx";
        $.popup({ title: "选择项目资产", url: strVar, borderStyle: { height: 450, width: 600 }, ok: function (va) {
            if (isExistProject(va.Guid)) {
                alert("项目：“" + va.Name + "”已经添加！");
                return;
            }
            runProjectGuid.val(runProjectGuid.val() + va.Guid + ";");
            var tbody = tableRunProject.find("tbody");
            var mAddtr = " <tr class='RowStyle' guid='" + va.Guid + "'><td>" + va.Name + "</td><td>" + va.Domain + "</td><td> " + va.Struct + "</td><td> "
+ va.OnlinTime + "</td><td>" + va.administrator + "</td><td><img class='cssImagePro' src='../images/Common/delete.gif'/></td></tr>";
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
    InitProject();
    /***************End处理应用资产**********************/

});       //End ready

    