

$(document).ready(function () {


    /*****************展开*****************/
    //展开第一级
    var expand = $(".expand");
    expand.each(function (i, o) {
        var obj = $(o);
        obj.toggle(function () {
            var tr1 = obj.parents("tr").next("tr:first");
            tr1.show();
            obj.find("img").attr("src", "../images/Common/minus.gif");
        }, function () {
            var tr = obj.parents("tr").next("tr:first");
            tr.hide();
            obj.find("img").attr("src", "../images/Common/plus.gif");
        })
    });

    //展开基本信息
    var expand = $(".expandInfo");
    expand.each(function (i, o) {
        var obj = $(o);
        obj.toggle(function () {
            var tr1 = obj.parent("td").parent("tr").nextAll("tr");
            tr1.hide();
            obj.find("img").attr("src", "../images/Common/plus.gif");
        }, function () {
            var tr = obj.parent("td").parent("tr").nextAll("tr");
            tr.show();
            obj.find("img").attr("src", "../images/Common/minus.gif");
        })
    });

    //展开硬件信息
    var expand = $(".expandHD");
    expand.each(function (i, o) {
        var obj = $(o);
        obj.parent("td").parent("tr").nextAll("tr").hide();
        obj.toggle(function () {
            var tr = obj.parent("td").parent("tr").nextAll("tr");
            tr.show();
            obj.find("img").attr("src", "../images/Common/minus.gif");
        }, function () {
            var tr1 = obj.parent("td").parent("tr").nextAll("tr");
            tr1.hide();
            obj.find("img").attr("src", "../images/Common/plus.gif");
        })
    });

    //展开附加信息
    var expand = $(".expandAtta");
    expand.each(function (i, o) {
        var obj = $(o);
        obj.parent("td").parent("tr").nextAll("tr").hide();
        obj.toggle(function () {
            var tr = obj.parent("td").parent("tr").nextAll("tr");
            tr.show();
            obj.find("img").attr("src", "../images/Common/minus.gif");
        }, function () {
            var tr1 = obj.parent("td").parent("tr").nextAll("tr");
            tr1.hide();
            obj.find("img").attr("src", "../images/Common/plus.gif");
        })
    });
    /***************END展开*******************/




    /******************刷新选中服务器******************/
    var refreshChecked = $(".headerBtnRefresh");
    refreshChecked.click(function () {
        var divLoad = $("#divLoading");
        $.toCenter(divLoad);

        var guidArr = '';
        var checkbox = $(".cbCheck");
        checkbox.each(function (i, o) {
            var obj = $(o);
            if (obj.attr("checked")) {
                guidArr += "," + obj.val();
            }
        });
        if (guidArr == "") {
            alert("没有选择任何服务器！");
            return false;
        }
        else {
            divLoad.html("正在获取服务器信息，请等待……");
            divLoad.show();
            $.ajax({
                url: "ServerRefresh.aspx",
                data: { idArr: guidArr },
                timeout: 30000,
                success: function (ajaxContext) {
                    divLoad.hide();
                    if (ajaxContext == "true") {
                        var strVar = "ChangeRecordConfirm.aspx";
                        $.popup({ title: "变更确认", url: strVar, borderStyle: { width: 400, height: 200 }, ok: function () { $.popup.Refrsh(); } });
                    }
                    else if (ajaxContext == "false") {
                        alert("没有检测到数据更新！");
                        return false;
                    } else {
                        alert("出错了! \n\n\t错误信息：" + ajaxContext.substring(6, ajaxContext.length));
                        return false;
                    }
                },
                dataType: "text",
                cache: false,
                error: function (textStatus) {
                    divLoad.hide();
                    alert("出错了!\r\n\r\n\t错误信息：" + textStatus);
                    return false;
                },
                complete: function () {
                    divLoad.hide();
                    return false;
                }
            })
        }
    });
    /****************END刷新选中服务器*****************/

    //打印预览
    $(".cssBtnPrint").each(function (i, o) {
        $(o).click(function () {
            PrintObj = $(this).parents("tr:first");
            var m_url = "../Appl/print.aspx";
            $.popup({ title: "打印预览", url: m_url, borderStyle: { height: 560, width: 850 }
            }); //$.popup
        })
    });
    //End打印预览

    //处理添加删除权限
    var rightItem = $(".txtInfoRight").val(); //在textbox中存的权限
    var hideCounter = 0;
    if (rightItem.indexOf("Edit") == -1) {
        $(".tdServerEdit").hide();
        hideCounter++;
    }
    if (rightItem.indexOf("Delete") == -1) {
        $(".tdDServerelete").hide();
        hideCounter++;
    }
    if (hideCounter > 0) {
        $(".visibletd").each(function (i, o) {
            var obj = $(o);
            obj.attr("colspan", (Number(obj.attr("colspan")) - hideCounter));
        });
    }
    //End处理添加删除权限   
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //右键菜单开始


    // 右键菜单有选择性的灰化
    function applyrule(menu) {
        var p = $(this);
        var items = [];
        var name = "all";
        if (rightItem.indexOf("ping") == -1)
            items.push("ping");
        if (rightItem.indexOf("Close") == -1)
            items.push("Close");
        if (rightItem.indexOf("restart") == -1)
            items.push("restart");
        if (rightItem.indexOf("compZX") == -1)
            items.push("compZX");
        if (rightItem.indexOf("deskCon") == -1)
            items.push("deskCon");
        if (rightItem.indexOf("record") == -1)
            items.push("record");
        if (rightItem.indexOf("refersh") == -1)
            items.push("refersh");
        if (rightItem.indexOf("viewData") == -1)
            items.push("viewData");
        if (rightItem.indexOf("viewChange") == -1)
            items.push("viewChange");

        menu.applyrule({ name: name,
            disable: true,
            items: items
        });
    }

    var option = { width: 150, items: [
                    { text: "变更登记", icon: "../images/Common/server_edit.png", alias: "record", action: ChangeRecord },
                    { type: "splitLine" },
                    { text: "网络连通性", icon: "../images/icon/server_connect.gif", alias: "ping", action: pingServer },
                    { type: "splitLine" },
                    { text: "重启服务器", icon: "../images/icon/restart.gif", alias: "restart", action: restart },
                    { text: "注销服务器", icon: "../images/icon/logout.gif", alias: "compZX", action: compZX },
                    { text: "关闭服务器", icon: "../images/icon/close.gif", alias: "Close", action: CloseComputer },
                    { text: "远程桌面连接", icon: "../images/icon/remote.png", alias: "deskCon", action: deskCon },
                    { type: "splitLine" },
                    { text: "查看服务器资源", icon: "../images/icon/property.gif", alias: "viewData", action: viewData },
                    { text: "查看服务器变更记录", icon: "../images/icon/changeList.png", alias: "viewChange", action: viewChange },
                    { type: "splitLine" },
                    { text: "刷    新", icon: "../images/Common/refresh.gif", alias: "refersh", action: RefreshServer }
                    ], onShow: applyrule
    };


    //添加左键菜单
    $(".GridItem").each(function (i, o) {
        var obj = $(o);
        obj.mousedown(function () {
            ChangBG($(this));
        }).contextmenu(option);
    });
});                 //End Ready



    var divDisk = $(".divDisk");
    var divDiskLoading = $(".divDiskLoading");
    var diskTmp = $(".diskTmp");
    var divPerformance = $(".divPerformance");
    var divPerformanceLoading = $(".divPerformanceLoading");
    var divCPU = $(".divCPU");
    var divMemeory = $(".divMemeory");
    var spanAvailableBytes = $(".spanAvailableBytes");
    var spanPhysicalMemory = $(".spanPhysicalMemory");
    var spanVirtualMemory = $(".spanVirtualMemory");
    var spanCommittedBytes = $(".spanCommittedBytes");

    
    //查看服务器资源
    function viewData() {
        var strguid = GetGuid();
        var url = "ServerState.aspx?id=" + strguid;
        $.popup({ title: "服务器资源", url: url, borderStyle: { width: "600", height: "500" }, ok: function () { $.popup.Refrsh(); } });
    }

    //查看服务器变更记录
    function viewChange() {
        var strguid = GetGuid();
        var url = "ChangeRecordList.aspx?id=" + strguid;
        $.popup({ title: "服务器变更记录", url: url, borderStyle: { width: "500", height: "450" }, ok: function () { $.popup.Refrsh(); } });
    }

///远程桌面
function deskCon() {
    var strType = "deskCon";
     ComputerInfo("正在对服务器进行关闭，请等待...........", strType);
}

///关闭计算机
function CloseComputer() {
    var strType = "CloseComputer";
    if(confirm("确定要“关闭”服务器吗？"))
        ComputerInfo("正在对服务器进行关闭，请等待...........", strType);
}
//注销
function compZX() {
    var strType = "compZX";
    if (confirm("确定要“注销”服务器吗？"))
        ComputerInfo("正在对服务器进行注销，请等待...........", strType);
}

//重启
function restart() {
    var strType = "restart";
    if (confirm("确定要“重启”服务器吗？"))
         ComputerInfo("正在对服务器进行重启，请等待...........", strType);
}
function pingServer() {
    var strType = "pingServer";
    ComputerInfo("正在连接服务器，请等待...........", strType);
}

function ComputerInfo(tsInfo, strType) {
    var strguid = GetGuid();
    if (strguid == null || strguid == undefined || strguid == "") {
        alert("获取参数ID失败！");
        return;
    }
    var divLoad = $("#divLoading");
    $.toCenter(divLoad);
    divLoad.html(tsInfo);
    divLoad.show();
    $.ajax({
        url: "ServerInfoList.aspx",
        data: { id: strguid, commputerYW: strType },
        success: function (ajaxContext) {
            if (ajaxContext.IsSuccess) {
                divLoad.hide();
                if (strType == "deskCon") {
                    var tc = document.getElementById("ocxRemDesk");
                    var DominName = ajaxContext.Domain;
                    var ServerIP = ajaxContext.Server_IP;
                    var LoginName = ajaxContext.ServerAccount;
                    var LoginPwd = ajaxContext.ServerPwd;
                    tc.Connect(DominName, ServerIP, LoginName, LoginPwd);
                }
                else {
                    alert(ajaxContext.Message);
                }
            }
            else {
                divLoad.hide();
                alert(ajaxContext.ErrorMsg);
            }
        },
        dataType: "json",
        cache: false,
        error: function (textStatus) {
            alert("出错了!\r\n\r\n\t错误信息：" + textStatus);
            return;
        },
        complete: function () {
            divLoad.hide();
        }
    });
}

function GetGuid() {
    var SelectItemGu = $(".ObjSelectItem").find(".cbCheck").val();
    return SelectItemGu;
}
function ChangeRecord() {
    var strVar = "ServerChangeRcdEdit.aspx?opType=add&id=" + GetGuid();
    $.popup({ title: "服务器资产变更登记", url: strVar, borderStyle: { height: 400, width: 550 }, ok: function () {
        $.popup.Refrsh();
    } 
    }); //$.popup
}

/***************刷新服务器*****************/
function RefreshServer() {
    var divLoad = $("#divLoading");
    $.toCenter(divLoad);

    divLoad.html("正在获取服务器信息，请等待……");
    divLoad.show();
    var strguid = GetGuid();
    $.ajax({
        url: "ServerRefresh.aspx",
        data: { id: strguid },
        timeout: 30000,
        success: function (ajaxContext) {
            divLoad.hide();
            if (ajaxContext == "true") {
                var strVar = "ChangeRecordConfirm.aspx";
                $.popup({ title: "变更确认", url: strVar, borderStyle: { width: 400, height: 200 }, ok: function () { $.popup.Refrsh(); }
                });
            } else if (ajaxContext == "false") {
                alert("没有检测到数据更新！");
                return false;
            } else {
                alert("出错了! \n\n\t错误信息：" + ajaxContext.substring(6, ajaxContext.length));
                return false;
            }
        },
        dataType: "text",
        cache: false,
        error: function (textStatus) {
            divLoad.hide();
            alert("出错了!\r\n\r\n\t错误信息：" + textStatus);
            return false;
        },
        complete: function () {
            divLoad.hide();
            return false;
        }
    });
}
/****************END刷新服务器****************/