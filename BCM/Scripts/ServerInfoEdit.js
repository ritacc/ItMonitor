var m_CbIsvirture; //虚拟机复选框
var m_divVirServer; // 虚拟机选择服务器Div

//主要运行项目    
var tableRunProject;
var divLoad;
$(document).ready(function () {
    divLoad = $("#divLoading");
    $.toCenter(divLoad);
    $("#divGetInfo").click(function () {
        //var span = $("span");
        //var a = $("a");

        var vServerName = $("#txtServerName").val();
        var vServerIP = $("#txtServerIp").val();
        var txtServerIP = $("#txtServerIp");
        var vAccountName = $("#txtServeraccount").val();
        var vAccountPwd = $("#txtServerpwd").val();
        if (vServerName == "" && vServerIP == "") {
            alert("请输入“服务器名称”或“服务器IP”！");
            return;
        }

        if (!$.yz.isIp(vServerIP)) {
            alert("请输入正确的“服务器IP”！");
            txtServerIP.focus();
            return;
        }

        if (vAccountName == "") {
            alert("请输入“服务器帐号”！");
            return;
        }
        if (vAccountPwd == "") {
            alert("请输入“服务器密码”！");
            return;
        }
        divLoad.html("正在获取服务器信息，请等待……");

        divLoad.show();
        var temp;
        $.ajax({
            url: "ServerInfoEdit.aspx",
            data: { type: "build", ServerName: vServerName, ServerIP: vServerIP, AccountName: vAccountName, AccountPwd: vAccountPwd },
            success: function (ajaxContext) {
                var errorArray = [];
                errorArray.push("出错了!\r\n\r\n\t错误信息：\t");
                if (ajaxContext != undefined
                            && ajaxContext.IsSuccess != undefined) {
                    if (ajaxContext.IsSuccess == true) {

                        loadDate(ajaxContext);
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
                divLoad.hide();
            }
        }); //$.ajax({
    });
    /****************************获取服务器名称*********************************/
    //GetServerName
    $("#divGetServerName").click(function () {
        var vServerIP = $("#txtServerIp");
        if (vServerIP.val() == "") {
            alert("请输入“服务器IP”！");
            vServerIP.focus();
            return;
        } else {
            if (!$.yz.isIp(vServerIP.val())) {
                alert("请输入正确的“服务器IP”！");
                vServerIP.focus();
                return;
            }
        }
        divLoad.html("正在获取服务器名称，请等待……");
        divLoad.show();
        $.ajax({
            url: "ServerInfoEdit.aspx",
            data: { type: "GetServerName", ServerIP: vServerIP.val() },
            success: function (ajaxContext) {
                var errorArray = [];
                errorArray.push("出错了!\r\n\r\n\t错误信息：\t");
                if (ajaxContext != undefined
                            && ajaxContext.IsSuccess != undefined) {
                    if (ajaxContext.IsSuccess == true) {
                        $("#txtServerName").val(ajaxContext.ErrorMsg);
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
                divLoad.hide();
            }
        }); //$.ajax({
        //GetServerName
    });
    /****************************End获取服务器名称*********************************/

    /****************************虚拟机，选择所在服务器**********************************/
    $("#imgVirServer").click(function () {
        var strVar = "SelectServer.aspx?id=" + request("id");
        $.popup({ title: "虚拟机，所在物理服务器", url: strVar, borderStyle: { height: 450, width: 600 }, ok: function (va) {
            $("#txtParentServerguid").val(va.Guid);
            $("#txtParentServerName").val(va.ShowVal);
        }
        }); //$.popup
    });
    m_CbIsvirture = $("#cbIsvirture");
    m_divVirServer = $(".divVirServer");
    m_CbIsvirture.click(function () {
        setChedk();
    });
    setChedk(); //页面加载时，执行
    /****************************End虚拟机，选择所在服务器**********************************/


    /***********************处理，变更流水的记录列表展开与关**********************/
    $(".divTitle").click(function () {
        var obj = $(this);
        HeadViewSatate(obj);
    });

    $("#trViewChange").dblclick(function () {
        var obj = $(this).find(".divTitle"); ;
        HeadViewSatate(obj);
    });
    /***********************END**处理，变更流水的记录列表展开与关*****************/


    /***************处理主要运行项目**********************/
    var runProjectGuid = $("#txtRuntProject");
    tableRunProject = $("#tableRunProject");
    $("#divAddProject").click(function () {
        var strVar = "../Appl/SelectProject.aspx";
        $.popup({ title: "主要运行项目选择", url: strVar, borderStyle: { height: 450, width: 600 }, ok: function (va) {
            if (isExistGuid(va.Guid)) {
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
    InitServerPro();
    /***************End处理主要运行项目**********************/
    if (request("opType") == "alert") {
        $("#tbChangeList").show();
    }
    else {
        $("#tbChangeList").hide();
    }

});                    //end $(document).ready

function headRemoveProgram() {
    $.each($(".cssImagePro"), function (i, o) {
        var obj = $(o);
        obj.unbind("click");
        obj.click(function () {
            if (confirm("确定要移出此关联项目吗？")) {
                var runProjectGuid = $("#txtRuntProject");
                var objTr = $(this).parents("tr:first");
                var mguid = objTr.attr("guid");
                runProjectGuid.val(runProjectGuid.val().replace(mguid + ";", "")); //文本框中移出
                objTr.remove();
            }
        });
    });
}

//复选择框处理
function setChedk() {
    if (m_CbIsvirture)
        m_CbIsvirture.attr("checked") ? m_divVirServer.show() : m_divVirServer.hide();
}

//查看流水处理
function HeadViewSatate(obj) {
    var trObj = $("#trViewChangeList");
    if (obj.hasClass("ex")) {
        obj.removeClass("ex");
        trObj.hide();
    }
    else {
        obj.addClass("ex");
        trObj.show();
    }
}

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
/****************************初使化服务器运行项目*********************************/
function InitServerPro() {
    var runProjectGuid = $("#txtRuntProject");
    if (runProjectGuid.val().length < 36)
        return;
    $.ajax({
        url: "ServerInfoEdit.aspx",
        data: { type: "InitServerPro", GuidArr: runProjectGuid.val() },
        success: function (ajaxContext) {
            var errorArray = [];
            errorArray.push("出错了!\r\n\r\n\t错误信息：\t");
            if (ajaxContext != undefined
                            && ajaxContext.IsSuccess != undefined) {
                if (ajaxContext.IsSuccess == true) {
                    SetTableRow(ajaxContext.listPro);
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
            //a.show();
            //span.hide();
        }
    });  //$.ajax({

}

function SetTableRow(dataArr) {
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
/****************************End初使化服务器运行项目*********************************/
//
function loadDate(ajaxContext) {
    
    $("#txtSerialNo").val(ajaxContext.SerialNo);
    $("#txtServerBrand").val(ajaxContext.ServerBrand);
    $("#txtServerModel").val(ajaxContext.ServerModel);
    $("#txtCpuCount").val(ajaxContext.CpuCount);
    $("#txtCpuKernelCount").val(ajaxContext.CpuKernelCount);
    $("#txtCpuRate").val(ajaxContext.ReadCpuRate);
    $("#txtMemorysize").val(ajaxContext.ReadMemorysize);
    $("#txtHdDrivnoInfo").val(ajaxContext.HdDrivnoInfo);
    $("#txtHdTotalSzie").val(ajaxContext.ReadHdTotalSzie);
    $("#txtHdMaxenableSize").val(ajaxContext.ReadHdMaxenableSize);
    $("#txtOsVersion").val(ajaxContext.OsVersion);
    $("#dpdOsLanguage").val(ajaxContext.OsLanguage);
    $("#txtOsWs").val(ajaxContext.OsWs);
    $("#txtDataBaseVersion").val(ajaxContext.ServerDBName);
   
    //$("#dpDBLanguageVersion").val(ajaxContext); 
    //加载，服务器数据库
    /*
    $.each(ajaxContext.ServerDataBase, function (i, o) {
    });
    */
}
