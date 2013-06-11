<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StateApplication.aspx.cs"
    Inherits="GDK.BCM.StateMonitor.StateApplication" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="../UI/pagenavigate.ascx" TagName="pagenavigate" TagPrefix="uc2" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../Styles/gridview.css" rel="Stylesheet" />
    <link href="../Styles/Site.css" rel="Stylesheet" />
    <link href="../Styles/right.css" rel="Stylesheet" />
    <script type="text/javascript" src="../Scripts/jquery-1.4.4.min.js"></script>
    <script type="text/javascript" src="../Scripts/Common.js"></script>
    <script type="text/javascript" src="../Scripts/MonitorList.js"></script>
    <style type="text/css">
        .ex{background-position: left bottom;}
        .divTitleMu{padding-top:1px;padding-bottom:1px;}
        .divTitle{
            background-image: url(../images/SysAdmin/device.gif);
            background-repeat: no-repeat;
            text-align: left;
            height:18px;
            cursor: pointer;
            zoom: 1; 
            display: inline-block;
            *display:inline;
        }
        .divItem{
            background-image: url(../images/icon/look.gif);
            background-repeat: no-repeat;
            text-align: left;
            height:18px;
            cursor: pointer;
            zoom: 1; 
            display: inline-block;
            *display:inline;
        }
        
        .Title1{width:15px;}
        .Title2{width:15px;margin-left:10px;}
        .Title3{width:15px;margin-left:20px;}
        .Title3{width:15px;margin-left:30px;}
        .Title4{width:15px;margin-left:40px;}
        .divContent{ text-align:center;}
       .spanLadDate{padding:4px 6px;}
       .NoShow{display: none;}
        
        .w75{ width:75px;}
        .w120{ width:120px;}
        .tableContent{ width:100%;border-bottom: 1px dashed #BBBBBB;}
        .tableContentTH{ width:100%;border-bottom: 1px dashed #BBBBBB;}
        .tableContent td{ text-align:left; }
        .tableContentTH td{  font-size:12px;  font-weight:bold;}
    </style>
    <script type="text/javascript">
        var timer = null;
        var lastClickObj = null;
        $(document).ready(function () {
            var arrTitle = $(".divTitle").each(function (i, o) {
                var obj = $(o);
                obj.click(function () {
                    eventClickHeadle(obj);
                }); //obj.click
            });   //each

            autoSize();
        });

        function autoSize() {
            var tdIframe = $("#tdIframe");
            var overflow_grid1 = $(".overflow_grid1");
            if (!timer) {
                window.clearTimeout(timer);
            }
            timer = window.setTimeout(function () {
                var layout = $.getLayout();
                var height = layout.innerHeight - 238;
                tdIframe.height(height);
                overflow_grid1.height(height);
            }, 100);
        }

        $(window).resize(autoSize);


        function eventClickHeadle(obj) {
            var parentDiv = obj.parents("div:first");
            var divContentobj = obj.parents("table:first").siblings(".divContent");

            if (obj.hasClass("ex")) {
                obj.removeClass("ex");
                if (divContentobj.length) {
                    divContentobj.addClass("NoShow");
                }
            }
            else {
                obj.addClass("ex");
                if (divContentobj.length) {
                    divContentobj.removeClass("NoShow");
                    return;
                } else {
                    LoadDate(parentDiv.attr("Guid"), parentDiv);
                }
            }
        }

        function LoadDate(Guid, parentDiv) {
            //初使化div
            var strUrl = "StateApplicationLoad.aspx?Guid=" + Guid
                    + "&type=" + parentDiv.attr("type")
                    + "&dep=" + parentDiv.attr("dep");
            $.ajax({
                url: strUrl,
                cache: false,
                dataType: "html",
                success: function (data) {
                    var tempTeml = $(data); //.find(".divContent").html();
                    if ($(tempTeml).html().length == 0) {
                        //这里还需要处理
                        //parentDiv.removeClass("ex");
                        return;
                    }
                    parentDiv.append(tempTeml);
                    parentDiv.find(".divTitle").each(function (i, o) {
                        var tempobj = $(o);
                        tempobj.unbind();
                        tempobj.click(function () {
                            eventClickHeadle(tempobj);
                        }); //obj.click
                    });   //each
                }, //success function(i,item)
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert("加载数据出错！");
                }
            });
        }
        function selectObjectReLoad() {
            //alert("ok");
            var varSelectobjArr = $(".ObjSelectItem");
            if (varSelectobjArr.length == 0)
                return;
            varSelectobjArr.next().remove();
            if (varSelectobjArr.prev("p").hasClass("ex")) {
                varSelectobjArr.prev("p").removeClass("ex");
            }
        }
        
    </script>
</head>
<body>
    <form id="form1" runat="server" style="overflow-x: hidden">
    <div class="divgrid">
        <table class="gridheader_table" cellpadding="0" cellspacing="0">
            <tr>
                <td width="6">
                    <img src="../images/gridview/gridheader_03.gif" alt="" />
                </td>
                <td>
                    应用状态列表
                </td>
                <td width="6">
                    <img src="../images/gridview/gridheader_06.gif" alt="" />
                </td>
            </tr>
        </table>
        <div class="overflow_grid1">
            <div id="tdIframe" style="overflow: auto;">
                <table class="tableContentTH">
                    <tr>
                        <td class="w75">
                            &nbsp;
                        </td>
                        <td>
                            名称
                        </td>
                        <td class="w120">
                            类型
                        </td>
                        <td class="w120">
                            状态
                        </td>
                        <td class="w120">
                            预警
                        </td>
                    </tr>
                </table>
                <asp:Repeater ID="rpApp" runat="server">
                    <ItemTemplate>
                        <div class="divTitleMu" type='top' dep='1' guid='<%# Eval("DeviceID")%>'>
                            <table class="tableContent">
                                <tr>
                                    <td class="w75">
                                        <span class="divTitle Title1">&nbsp;</span>
                                    </td>
                                    <td>
                                        <span class="spanLadDate">
                                            <%# Eval("DeviceName")%>
                                        </span>
                                    </td>
                                    <td class="w120">
                                        <%# Eval("TypeName")%>
                                    </td>
                                    <td class="w120">
                                       <img  src="../images/Common/stata<%# Eval("DeviceStatus")%>.gif" alt="状态"/> 
                                        <%# Eval("DeviceStatusName")%>
                                    </td>
                                    <td class="w120">
                                    <img  src="../images/Common/stata<%# Eval("WarningStatus")%>.gif" alt="状态"/> 
                                    <%# Eval("WarningStatusName")%>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
