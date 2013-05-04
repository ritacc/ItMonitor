<%@ Page Title="" Language="C#" MasterPageFile="~/Main/SiteMain.Master" AutoEventWireup="true" CodeBehind="HealthConfigList.aspx.cs" Inherits="GDK.BCM.AlertAdmin.HealthConfigList" %>
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
            $(".spanLadDate").each(function (i, o) {
                var obj = $(o);
                obj.click(function () {
                    var fidrtDiv = obj.parent("div:first");
                    ChageFromUrl(fidrtDiv.attr("guid"), fidrtDiv.attr("DeviceTypeID")); //; eventClickHeadle(obj);
                    obj.addClass("ObjSelectItem");
                    if (lastClickObj)
                        lastClickObj.removeClass("ObjSelectItem");
                    lastClickObj = obj;
                }); //obj.click
            });   //each

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

        function ChageFromUrl(strGUID, DeviceTypeID) {

            var toUrl = "HealthConfigMain.aspx?DeviceID=" + strGUID + "&StationID="
             + $("#<%= dpdStationID.ClientID %>").val() + "&DeviceTypeID=" + DeviceTypeID;
            $("#DepartmentsMain").attr("src", toUrl);
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="right_box">
    <table cellpadding="0" id="tableIframe" cellspacing="1" border="0" width="100%">
        <tr>
            <td  style="vertical-align: top; width: 250px;  border: 1px solid #cccccc;">
                <div id="tdIframe" style="overflow:auto;">
                <div   style=" font-size:12px; padding:5px; padding-left:14px;">
                请选择机房：&nbsp;&nbsp; <asp:DropDownList ID="dpdStationID" AutoPostBack="true"  
                        runat="server" onselectedindexchanged="dpdStationID_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
                <div style=" font-size:12px; padding:5px; padding-left:14px;">
                该机房所有设备测点：</div>
                <asp:Repeater ID="rpDepartment" runat="server">
                    <ItemTemplate>
                        <div class="divTitleMu divTitleMuDepart" DeviceTypeID="<%# Eval("DeviceTypeID")%>" 
                        guid="<%# Eval("Deviceid")%>">
                            <span class="divTitle">
                                &nbsp;</span>
                            <span class="controlWidth1 spanLadDate">
                                <%# Eval("DeviceName")%></span>
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


