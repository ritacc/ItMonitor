<%@ Page Title="" Language="C#" MasterPageFile="~/Main/SiteMain.Master" AutoEventWireup="true" CodeBehind="DepartmentsList.aspx.cs" Inherits="GDK.BCM.Sysadmin.DepartmentsList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
        .ex
        {
            background-position: left bottom;
        }
        .divTitleMu
        {
            margin-left: 15px;
            border-left: 1px dashed #BBBBBB;
            padding-top:4px;
            padding-bottom:4px;
        }
        .divTitleMuDepart
        {
            border-bottom: 1px solid #BBBBBB;
        }
        .divTitle
        {
            background-image: url(../images/SysAdmin/device.gif);
            background-repeat: no-repeat;
            text-align: left;
            width: 15px;
            height:18px;
            cursor: pointer;
            zoom: 1; 
            display: inline-block;
            *display:inline;
        }
       .spanLadDate
       {
           padding:4px 6px;
        }
        .NoShow
        {
            display: none;
        }
        #tdIframe span
        {
        	cursor:pointer;
        }
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

            $(".spanLadDate").each(function (i, o) {
                var obj = $(o);
                obj.click(function () {
                    ChageFromUrl(obj.parent("div:first").attr("guid")); //; eventClickHeadle(obj);
                    obj.addClass("ObjSelectItem");
                    if (lastClickObj)
                        lastClickObj.removeClass("ObjSelectItem");
                    lastClickObj = obj;
                }); //obj.click
            });   //each

//$("#spanView").click(function() 
//$("#inputView").val($("#tdIframe").html()); // alert($("#tdIframe").html());
//});
            autoSize();
        });

        function autoSize() {
            var tableIframe = $("#tableIframe");
            var tdIframe = $("#tdIframe");
            var DepartmentsMain = $("#DepartmentsMain");
            if (!timer) {
                window.clearTimeout(timer);
            }
            timer = window.setTimeout(
                function () {
                    var layout = $.getLayout();
                    var height = layout.innerHeight - 187;
                    tableIframe.height(height);
                    tdIframe.height(height);
                    DepartmentsMain.height(height);
                }, 100);
        }

        $(window).resize(autoSize);

        function eventClickHeadle(obj) {
            var parentDiv = obj.parent("div:first");
            var divContentobj = obj.siblings(".divContent");

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
            var strUrl = "DepartmentLoadDep.aspx?Guid=" + Guid;

            $.ajax({
                url: strUrl,
                cache: false,
                dataType: "html",
                success: function (data) {
                    var tempTeml = $(data).find(".divContent").html();
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

                    parentDiv.find(".spanLadDate").each(function (i, o) {
                        var obj = $(o);
                        obj.unbind();
                        obj.click(function () {
                            if (lastClickObj == obj)
                                return;
                            ChageFromUrl(obj.parent("div:first").attr("guid")); //; eventClickHeadle(obj);
                            obj.addClass("ObjSelectItem");
                            if (lastClickObj)
                                lastClickObj.removeClass("ObjSelectItem");
                            lastClickObj = obj;
                        }); //obj.click
                    });   //each


                }, //success function(i,item)
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    // 通常 textStatus 和 errorThrown 之中
                    // 只有一个会包含信息
                    // 调用本次AJAX请求时传递的options参数
                    alert("加载数据出错！");

                }

            });
        }

        function ChageFromUrl(strGUID) {
            var toUrl = "DepartmentsMain.aspx?GUID=" + strGUID;
            $("#DepartmentsMain").attr("src", toUrl);
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

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="right_box">
    <table cellpadding="0" id="tableIframe" cellspacing="1" border="0" width="100%">
        <tr>
            <td  style="vertical-align: top; width: 250px;  border: 1px solid #cccccc;">
                <div id="tdIframe" style="overflow:auto;">
                <asp:Repeater ID="rpDepartment" runat="server">
                    <ItemTemplate>
                        <div class="divTitleMu divTitleMuDepart" guid="<%# Eval("GUID")%>">
                            <span class="divTitle">
                                &nbsp;</span>
                            <span class="controlWidth1 spanLadDate">
                                <%# Eval("DISPLAY_NAME")%></span>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                </div>
            </td>
            <td style="vertical-align: top; border: 1px solid #CCCCCC;">
                <iframe id="DepartmentsMain" width="100%"  frameborder="0" style="overflow:hidden;overflow-x:hidden;" >
                </iframe>
            </td>
        </tr>
    </table>
</div>
</asp:Content>
