var tableRunProject;
var json;
//判断是否已经存在Guid
function isExistGuid(strGuid) {
    var strProjectGuid = $("#<%= txtRuntZc.ClientID  %>").val();
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

$(document).ready(function () {
    var runProjectGuid = $("#<%= txtRuntZc.ClientID  %>");
    var runType = $("#<%=txtRunType.ClientID %>");
    tableRunProject = $("#tableRunServer");
    alert($("#txtRuntZc").val());
    $("#divAddZc").click(function () {
        var strVar = "../Task/SelectZC.aspx";
        $.popup({ title: "选择受影响资产", url: strVar, borderStyle: { height: 450, width: 600 }, ok: function (va) {

            if (isExistGuid(va.Guid)) {
                alert("资产名称：“" + va.Name + "”已经添加！");
                return;
            }
            runProjectGuid.val(runProjectGuid.val() + va.Guid + ";");
            runType.val(va.zcType);

            var tbody = tableRunProject.find("tbody");
            var mAddtr = " <tr class='RowStyle' guid='" + va.Guid + "'><td>" + va.Name + "</td><td>" + va.zcType + "</td><td> "
+ va.zcWZ + "</td><td>" + va.zcWHBM + "</td><td><img class='cssImageZc' src='../images/Common/delete.gif'/></td></tr>";
            if (tbody) {
                tbody.append(mAddtr);
            }
            else {
                tableRunProject.append(mAddtr);
            }
            //alert(tableRunProject.html());
            headRemoveProgram();
            $("#<%= txt_Remark.ClientID %>").focus();
        }, cancel: function () { $("#<%= txt_Remark.ClientID %>").focus(); }, close: function () { $("#<%= txt_Remark.ClientID %>").focus(); }
        }); //$.popup
    });

    //详细描述
    $("#LinkXX").click(function () {
        var strVar = "../Task/SelectDetail.aspx";
        $.popup({ title: "选择匹配的描述格式", url: strVar, borderStyle: { height: 450, width: 600 }, ok: function (va) {
            $("#<%=txt_Remark.ClientID%>").val(va.XXMS);

        }, cancel: function () { $("#<%= txt_Remark.ClientID %>").focus(); }, close: function () { $("#<%= txt_Remark.ClientID %>").focus(); }

        });

    });
    //初始化
    InitServerPro();

});


function InitServerPro() {
    var runProjectGuid = $("#<%=txtRuntZc.ClientID %>");
    var runType = $("#<%=txtRunType.ClientID %>");

    if (runProjectGuid.val().length < 36)
        return;
    if (runType.val().length < 0) {
        return;
    }

    $.ajax({
        url: "TaskEdit.aspx",
        data: { type: "InitZc", Guid: runProjectGuid.val() },
        success: function (ajaxContext) {

            var errorArray = [];
            errorArray.push("出错了!\r\n\r\n\t错误信息：\t");
            if (ajaxContext != undefined
                            && ajaxContext.IsSuccess != undefined) {
                if (ajaxContext.IsSuccess == true) {

                    SetTableRow(ajaxContext.listsyxzc);
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
    });     //$.ajax({

}
function SetTableRow(dataArr) {
    var tbody = tableRunProject.find("tbody");
    $.each(dataArr, function (i, va) {
        var mAddtr = " <tr class='RowStyle' guid='" + va.Guid + "'><td>" + va.Name + "</td><td>" + va.zcType + "</td><td> "
+ va.zcWZ + "</td><td>" + va.zcWHBM + "</td><td><img class='cssImageZc' src='../images/Common/delete.gif'/></td></tr>";

        if (tbody) {
            tbody.append(mAddtr);
        }
        else {
            tableRunProject.append(mAddtr);
        }
    }); //each
}

function headRemoveProgram() {
    $.each($(".cssImageZc"), function (i, o) {
        var obj = $(o);
        obj.unbind("click");
        obj.click(function () {
            if (confirm("确定要移出此资产吗？")) {
                var runProjectGuid = $("#<%= txtRuntZc.ClientID  %>");
                var objTr = $(this).parents("tr:first");
                var mguid = objTr.attr("Guid");
                runProjectGuid.val(runProjectGuid.val().replace(mguid + ";", "")); //文本框中移出
                objTr.remove();
            }
        });
    });
}
