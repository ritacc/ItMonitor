﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Main/SiteMain.Master" AutoEventWireup="true"
    CodeBehind="PerfSystemFailure.aspx.cs" Inherits="GDK.BCM.AlertAdmin.PerfSystemFailure" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .NoShow
        {
            display: none;
        }
        #tdIframe span
        {
            cursor: pointer;
        }
    </style>
    <script type="text/javascript">
        var timer = null;
        $(document).ready(function () {
            autoSize();
        });

        function autoSize() {
            var tableIframe = $("#tableIframe");
            var tdIframe = $("#tdIframe");
            var DepartmentsMain = $("#ifList");
            if (!timer) {
                window.clearTimeout(timer);
            }
            timer = window.setTimeout(
                function () {
                    var layout = $.getLayout();
                    var height = layout.innerHeight - 184;
                    tableIframe.height(height);
                    tdIframe.height(height);
                    DepartmentsMain.height(height);
                }, 100);
        }

        $(window).resize(autoSize);
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right_box">
        <table cellpadding="0" id="tableIframe" cellspacing="1" border="0" width="100%">
            <tr>
                <td style="vertical-align: top; width: 280px; border: 1px solid #cccccc;">
                    <div id="tdIframe" style="overflow: auto;">
                        <asp:Repeater ID="rpAlertType" runat="server">
                            <ItemTemplate>
                                <a target="ifList" href="PerfSystemFailureList.aspx?typeid=<%# Eval("typeid")%>"
                                    style="width: 125px; height: 30px; float: left; margin: 3px 0px 0px 3px; padding: 10px 0px 0px 10px;
                                    background: url(../images/icon/bottonbg.gif);">
                                    <img src="../images/icon/<%# Eval("imgpath")%>" alt="" border="0" style="vertical-align: middle;" />
                                    <%# Eval("NameCN")%>
                                    :<%# Eval("num")%>
                                </a>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </td>
                <td style="vertical-align: top; border: 1px solid #CCCCCC;">
                    <iframe id="ifList" width="100%" name="ifList" frameborder="0" style="overflow: hidden;
                        overflow-x: hidden;"></iframe>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
