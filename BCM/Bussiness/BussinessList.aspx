<%@ Page Title="" Language="C#" MasterPageFile="~/Main/SiteMain.Master" AutoEventWireup="true" CodeBehind="BussinessList.aspx.cs" Inherits="GDK.BCM.Bussiness.BussinessList" %>

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
        .divTitleItem
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
            BindTitle();
            autoSize();
        });
        
        function LoadChildURL() {
            $(".DataItem").each(function (i, o) {
                var obj = $(o);
                obj.unbind("click");
                obj.click(function () {
                    var parentDiv=obj.parent("div:first");
                    ChageFromUrl(parentDiv.attr("guid")
                    , parentDiv.attr("type")); //; eventClickHeadle(obj);
                    obj.addClass("ObjSelectItem");
                    if (lastClickObj)
                        lastClickObj.removeClass("ObjSelectItem");
                    lastClickObj = obj;
                }); //obj.click
            });    //each
        }

        function BindTitle() {
            var arrTitle = $(".divTitle").each(function (i, o) {
                var obj = $(o);
                obj.unbind("click");
                obj.click(function () {
                    eventClickHeadle(obj);
                }); //obj.click
            });   //each
        }

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
                    LoadChild(parentDiv);
                }
            }
        }

        function LoadChild(parentDiv) {
            //alert(parentDiv.attr("guid"));
            var ID = parentDiv.attr("guid");

            parentDiv.append($("#divSys").html().replace(/(#guid)/g, ID));
            LoadChildURL();
            BindTitle();
        }

        function ChageFromUrl(strGUID, mtype) {
            var toUrl = "BussinessEdit.aspx?GUID=" + strGUID + "&type=" + mtype;
            $("#DepartmentsMain").attr("src", toUrl);
        }


        function selectObjectReLoad() {
        	$.popup.Refrsh();
        }
        
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="right_box">
    <table cellpadding="0" id="tableIframe" cellspacing="1" border="0" width="100%">
        <tr>
            <td  style="vertical-align: top; width: 250px;  border: 1px solid #cccccc;">
                <div id="tdIframe" style="overflow:auto;">

                     <div class="divTitleMu divTitleMuDepart" type="top" guid="-1">
                        <span class="divTitleItem divTitle ex">&nbsp;</span>
                        <span class="spanLadDate DataItem ObjSelectItem">应用系统</span>
                        <div class="divContent">
                            <asp:Repeater ID="rpDepartment" runat="server">
                                <ItemTemplate>
                                    <div class="divTitleMu" guid="<%# Eval("DeviceID")%>">
                                        <span class="divTitle divTitleItem">
                                            &nbsp;</span>
                                        <span class="spanLadDate">
                                            <%# Eval("DeviceName")%></span>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>

                    </div>

                </div>
            </td>
            <td style="vertical-align: top; border: 1px solid #CCCCCC;">
                <iframe id="DepartmentsMain" width="100%" src="BussinessEdit.aspx?type=top&GUID=-1"  frameborder="0" style="overflow:hidden;overflow-x:hidden;" >
                </iframe>
            </td>
        </tr>
    </table>
</div>
<div id="divSys" style=" display:none;">
                    <div class="divContent">
                        <div class="divTitleMu" >
                            <span class="divTitleItem ex">&nbsp;</span>
                            <span class="spanLadDate">软件层</span>
                            <div class="divContent">
                                <div class="divTitleMu" type="web" guid="#guid">
                                    <span class="divTitleItem">&nbsp;</span>
                                    <span class="spanLadDate DataItem">Web层</span>
                                </div>
                                <div class="divTitleMu" type="use" guid="#guid">
                                    <span class="divTitleItem">&nbsp;</span>
                                    <span class="spanLadDate DataItem">应用层</span>
                                </div>
                             </div>
                        </div>
                        <div class="divTitleMu" type="db" guid="#guid">
                            <span class="divTitleItem">&nbsp;</span>
                            <span class="spanLadDate DataItem">数据库层</span>
                        </div>
                        <div class="divTitleMu">
                            <span class="divTitleItem ex">&nbsp;</span>
                            <span class="spanLadDate">硬件层</span>
                             <div class="divContent">
                                <div class="divTitleMu" type="host"  guid="#guid">
                                    <span class="divTitleItem">&nbsp;</span>
                                    <span class="spanLadDate DataItem">服务器</span>
                                </div>
                             </div>
                        </div>
                    </div>
</div>
</asp:Content>
